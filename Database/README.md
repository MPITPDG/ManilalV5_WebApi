# Stored procedures

Until now stored procedures lived **only in the database**. Nothing was in
version control, so there was no history, no review, and no way to tell what a
deployed procedure was supposed to do or when it last changed. This folder
starts fixing that.

```
Database/StoredProcedures/<Module>/<SP_NAME>.sql
```

One file per procedure, named exactly as the procedure. Each file is
re-runnable: a `DROP PROCEDURE IF EXISTS` guard followed by `CREATE PROCEDURE`,
so it can be executed against any environment without editing.

Existing procedures are **not** here yet. Add each one as you touch it rather
than attempting a bulk export — a scripted dump of several hundred procedures
nobody has read is not the same as version control.

---

## Adding a new endpoint

Four things change. Only two of them are code.

| # | What | Where |
|---|---|---|
| 1 | The stored procedure | `Database/StoredProcedures/<Module>/` + deployed to the DB |
| 2 | The controller action | `Manilal_V5NG/Controllers/<Module>BLL/<Module>Controller.cs` |
| 3 | *(nothing)* | no route config — see below |
| 4 | *(nothing)* | no Swagger registration — see below |

There is **no** route change: `WebApiConfig` maps
`api/{controller}/{action}/{id}` by convention and the controllers use no
`[Route]` attributes, so a new public action is reachable immediately. There is
**no** Swagger entry: Swashbuckle reflects over every `ApiController` action.
There is **no** repository layer — `DAL` is instantiated directly.

---

## The conventions that actually matter

### 1. `STATUS` comes from the procedure, not from C#

The Angular client checks `data.Table[0].STATUS === "100"` on every call. That
column is selected by the **stored procedure**. C# never adds it on the success
path.

```sql
IF (SELECT COUNT(*) FROM #facts) > 0
BEGIN
    SELECT '100' AS STATUS, ...     -- success: STATUS on the first result set
END
ELSE
BEGIN
    SELECT '103' AS STATUS, 'NO RECORD FOUND' AS statustext;
END
```

Follow `USP_EXPT_EXPORT_DASHBOARD` for the exact shape. Note `'103'` for the
empty case, not `'100'`.

**C# only injects STATUS on the failure path**, via `ErrorLog.Error(ex, url)`,
which returns `STATUS = 101` plus `STATUSTEXT` and `url`. Two traps in that
class:

- `ErrorLog.Success(status, message)` **ignores its `status` argument** and
  always writes `101`. Calling `ErrorLog.Success("100", ...)` does not produce
  a success response. Don't use it.
- `Error()` names the column `STATUSTEXT`; `Success()` names it `statusText`.
  Both spellings exist in the wild.

Errors return **HTTP 200** with a `101` body, never a 4xx/5xx.

### 2. Parameters bind by POSITION, not by name

`DAL.ExecuteDataset` takes `params object[]` and assigns them to the procedure's
parameters in the order `SqlCommandBuilder.DeriveParameters` reports them. There
is no name matching.

```csharp
ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
    CommandType.StoredProcedure,
    "USP_EXPT_EXPORT_DASHBOARD_BOARD",
    CmpCode, CityCode, Days, Mode, PerColumn);   // MUST match @CMPCODE, @CITYCODE, @DAYS, @MODE, @PERCOLUMN
```

Adding a parameter in the middle of a procedure's signature silently corrupts
every existing call. **Append new parameters at the end, with defaults.**

### 3. Result sets are named by ADO.NET

`SqlDataAdapter.Fill` with no table mappings names them `Table`, `Table1`,
`Table2`… in the order the procedure's `SELECT`s execute. Json.NET then
serialises the `DataSet` as `{ "Table": [...], "Table1": [...] }`.

So the Nth `SELECT` in the procedure *is* `TableN-1` on the client. Adding a
`SELECT` in the middle renumbers everything after it and breaks the client
silently. **Append new result sets at the end.**

### 4. Target SQL Server 2008 R2

The live server is `10.50.2550.0`. Not available:

`IIF` · `CONCAT` · `TRY_CONVERT` · `TRY_CAST` · `OFFSET/FETCH` · `STRING_AGG` ·
`LAG`/`LEAD` · `THROW` · sequences

Available and used freely: `ROW_NUMBER() OVER (PARTITION BY ...)`, CTEs, `MERGE`,
`#temp` tables, table variables, `DATEADD`/`DATEDIFF`.

### 5. Dates are varchar `dd/MM/yyyy`

Most date columns in this schema are `varchar(10)` or `char(10)` holding
`dd/MM/yyyy`, not `date`. Consequences:

- Test emptiness with `LTRIM(RTRIM(ISNULL(col,''))) <> ''`, never `IS NOT NULL`
  — `char(10)` columns are blank-padded, not null.
- Use the existing scalar UDF `dbo.CONVERTDATE_YYYYMMDD(col)` to compare or sort
  chronologically. Do not hand-roll a `CONVERT(..., 103)`.
- Some columns hold unparseable junk (years like `5010`, `1000`). Filtering on a
  converted varchar date forces a scan across the whole table.
- Where a real `datetime` exists — e.g. `EXPT_MASTER.SYSEXPT_DOCRECD` alongside
  the operator-typed `EXPT_DOCRECD` — **filter on the datetime.**

### 6. Watch parameter sniffing

Measured on `USP_EXPT_EXPORT_DASHBOARD_BOARD`, same query, same data:

| approach | time |
|---|---|
| parameters used directly | ~39 s |
| `OPTION (RECOMPILE)` | ~46 s (worse) |
| parameters copied to local variables | ~3 s |

Copying parameters into local variables defeats sniffing and makes the optimiser
use average-density estimates, which on these wide tables produces a far better
plan than an accurate estimate does.

```sql
DECLARE @lCITY VARCHAR(3) = @CITYCODE;   -- then use @lCITY in the query
```

This is not cargo cult — measure before and after. But if a new procedure is
unexpectedly slow, try this first.

---

## Testing a procedure before deploying it

Run the **body** as a script with `DECLARE` statements standing in for the
parameters. Nothing is created, so it is safe against any environment:

```sql
DECLARE @CMPCODE VARCHAR(6) = '01', @CITYCODE VARCHAR(3) = 'MUM',
        @DAYS INT = 90, @MODE VARCHAR(5) = 'ALL', @PERCOLUMN INT = 50;
-- ... paste the procedure body ...
```

Then check the result-set count and shape match what the client expects.

**Timings taken during business hours are unreliable.** The production server
carries ~24 concurrent user sessions; the same query has measured anywhere from
0.7 s to 97 s depending on load. Benchmark in a quiet window before concluding a
procedure is slow.

---

## Known indexing gap

`EXPT_MASTER` is 304,581 rows and **289 columns**, with ~35 non-clustered
indexes — and **none containing `SYSEXPT_DOCRECD`**. Every branch-and-window
query scans the whole table.

```sql
-- Proposed. NOT applied: DDL on a table this wide belongs in a maintenance
-- window, not a working afternoon.
CREATE NONCLUSTERED INDEX IX_expt_master_cmpcode_citycode_sysdocrecd
    ON EXPT_MASTER (CMPCODE, CITYCODE, SYSEXPT_DOCRECD);
```

This would turn the dashboard's scope query from a scan into a seek. Any future
procedure filtering by branch and date window will hit the same wall.

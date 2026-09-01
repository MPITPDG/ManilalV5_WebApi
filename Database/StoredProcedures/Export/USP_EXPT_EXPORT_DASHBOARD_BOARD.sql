/*
================================================================================
 USP_EXPT_EXPORT_DASHBOARD_BOARD

 Backs the #/export dashboard. Answers "where is every open job right now" for
 one branch, over a rolling window.

 Called by ExportController.EXPT_EXPORT_DASHBOARD_Board, which returns the
 DataSet as-is, so ADO.NET names the result sets Table / Table1:

   Table   - one row per stage: STATUS, STAGE_CODE, N
             Complete GROUP BY counts over the whole filtered window.
             Safe to sum. Carries the '100' STATUS the Angular client checks,
             matching the convention in USP_EXPT_EXPORT_DASHBOARD.
   Table1  - the newest @PERCOLUMN jobs per stage.
             A SAMPLE, not a total. Anything the UI derives from these rows is
             a floor and is labelled as such on screen.

 Written for SQL Server 2008 R2 (the live version): no IIF, CONCAT,
 TRY_CONVERT, OFFSET/FETCH or STRING_AGG.

 Stage ladder - a job's stage is the FURTHEST rung it has reached, not the
 first one it missed, so a job that skipped a step still reports what actually
 happened to it:

   0 opened            an EXPT_MASTER row exists
   1 shipping-bill     EXPT_SHIPBILLNO filled in
   2 cargo-received    an EXPT_CARGORECPT line exists
   3 carted            an EXPT_CARTING row exists (sea) or CARTEDDT set (air)
   4 containerised     an EXPT_CONTAINER1 line links job to container [SEA ONLY]
   5 out-of-charge     OUTCHARGEDT set
   6 document-issued   FCR/HBL, master BL, MAWB or HAWB number recorded
   7 prealert          PREALERTDT set
  99 cancelled         EXPTCANCEL = 'Y'

 DOCSENTDT ("destination docs sent") is deliberately NOT a rung. 24,032 rows
 have it set but the most recently opened job among them is from 22 Jul 2019 -
 nothing in seven years. It would be a permanently-zero row. Add it back as
 stage 8 if the column returns to use.

 Date columns here are varchar dd/MM/yyyy, so emptiness is tested with
 LTRIM(RTRIM(ISNULL(col,''))) <> '' rather than IS NOT NULL. The window is
 filtered on SYSEXPT_DOCRECD, a real datetime, deliberately: EXPT_DOCRECD is
 operator-typed varchar containing unparseable values, and converting it in a
 WHERE clause would force a scan.
================================================================================
*/
IF OBJECT_ID('dbo.USP_EXPT_EXPORT_DASHBOARD_BOARD','P') IS NOT NULL
    DROP PROCEDURE dbo.USP_EXPT_EXPORT_DASHBOARD_BOARD;
GO

CREATE PROCEDURE [dbo].[USP_EXPT_EXPORT_DASHBOARD_BOARD]
    @CMPCODE    VARCHAR(6),
    @CITYCODE   VARCHAR(3),
    @DAYS       INT           = 90,
    @MODE       VARCHAR(5)    = 'ALL',   -- ALL | SEA | AIR
    @PERCOLUMN  INT           = 50
AS
BEGIN
    SET NOCOUNT ON;

    IF @DAYS IS NULL OR @DAYS < 1     SET @DAYS = 90;
    IF @DAYS > 1095                   SET @DAYS = 1095;
    IF @PERCOLUMN IS NULL OR @PERCOLUMN < 1 SET @PERCOLUMN = 50;
    IF @PERCOLUMN > 50                SET @PERCOLUMN = 50;
    SET @MODE = UPPER(LTRIM(RTRIM(ISNULL(@MODE,'ALL'))));

    -- Parameters are copied into local variables on purpose. It stops the
    -- optimiser sniffing them and makes it use average-density estimates, which
    -- here produces a dramatically better plan: measured 46s with the sniffed
    -- values (and with OPTION (RECOMPILE), which was worse still) versus ~3s
    -- this way. EXPT_MASTER has no index on SYSEXPT_DOCRECD and its branch
    -- indexes all lead with EXPT_MODE, so a sniffed narrow range tempts a
    -- nested-loop plan over a table with 289 columns. Do not "simplify" this by
    -- using the parameters directly.
    DECLARE @lCMP VARCHAR(6)  = @CMPCODE;
    DECLARE @lCITY VARCHAR(3) = @CITYCODE;
    DECLARE @lDAYS INT        = @DAYS;
    DECLARE @lMODE VARCHAR(5) = @MODE;
    DECLARE @lPER  INT        = @PERCOLUMN;

    ---------------------------------------------------------------------------
    -- 1. The filtered slice, once. DISTINCT because a job number is the unit of
    --    work; if EXPT_MASTER ever holds two rows for one EXPTNO the board must
    --    still show it once.
    ---------------------------------------------------------------------------
    SELECT DISTINCT EM.EXPTNO
    INTO #scope
    FROM EXPT_MASTER EM
    WHERE EM.CMPCODE  = @lCMP
      AND EM.CITYCODE = @lCITY
      AND EM.SYSEXPT_DOCRECD >= DATEADD(day, -@lDAYS, GETDATE())
      AND ( @lMODE = 'ALL'
         OR (@lMODE = 'AIR' AND LOWER(LTRIM(RTRIM(ISNULL(EM.EXPT_MODE,'')))) = 'air')
         OR (@lMODE = 'SEA' AND LOWER(LTRIM(RTRIM(ISNULL(EM.EXPT_MODE,'')))) <> 'air') );

    CREATE CLUSTERED INDEX IX_scope ON #scope (EXPTNO);

    ---------------------------------------------------------------------------
    -- 2. One row per job: its furthest stage plus everything a card shows.
    ---------------------------------------------------------------------------
    SELECT
        EM.ID,
        EM.EXPTNO,
        LOWER(LTRIM(RTRIM(ISNULL(EM.EXPT_MODE,''))))    AS MODE,
        ISNULL(CO.CON_NAME,'')                          AS CONSIGNEE,
        ISNULL(VM.VSL_NAME,'')                          AS VSL_NAME,
        ISNULL(VM.VSL_VOYNO,'')                         AS VSL_VOYNO,
        ISNULL(VP.ETD,'')                               AS ETD,
        EM.SYSEXPT_DOCRECD,
        LTRIM(RTRIM(ISNULL(EM.EXPT_HBLNO,'')))          AS HBLNO,
        LTRIM(RTRIM(ISNULL(EM.EXPT_BLNO,'')))           AS BLNO,
        LTRIM(RTRIM(ISNULL(EM.AEROBILLNO,'')))          AS MAWB,
        LTRIM(RTRIM(ISNULL(EM.HOUSEBILLNO,'')))         AS HAWB,
        CASE WHEN LTRIM(RTRIM(ISNULL(EM.EXPTCANCEL,''))) = 'Y'
             THEN 1 ELSE 0 END                          AS CANCELLED,
        CASE
            WHEN LTRIM(RTRIM(ISNULL(EM.EXPTCANCEL,''))) = 'Y'  THEN 99
            WHEN LTRIM(RTRIM(ISNULL(EM.PREALERTDT,'')))  <> '' THEN 7
            WHEN ( LTRIM(RTRIM(ISNULL(EM.EXPT_HBLNO,'')))  <> ''
                OR LTRIM(RTRIM(ISNULL(EM.EXPT_BLNO,'')))   <> ''
                OR LTRIM(RTRIM(ISNULL(EM.AEROBILLNO,'')))  <> ''
                OR LTRIM(RTRIM(ISNULL(EM.HOUSEBILLNO,''))) <> '' ) THEN 6
            WHEN LTRIM(RTRIM(ISNULL(EM.OUTCHARGEDT,''))) <> '' THEN 5
            WHEN ISNULL(CN.N,0) > 0                            THEN 4
            WHEN ( ISNULL(CT.N,0) > 0
                OR LTRIM(RTRIM(ISNULL(EM.CARTEDDT,''))) <> '' ) THEN 3
            WHEN ISNULL(CR.N,0) > 0                            THEN 2
            WHEN LTRIM(RTRIM(ISNULL(EM.EXPT_SHIPBILLNO,''))) <> '' THEN 1
            ELSE 0
        END                                             AS STAGE_CODE
    INTO #facts
    FROM EXPT_MASTER EM
    JOIN #scope SC ON SC.EXPTNO = EM.EXPTNO
    LEFT JOIN ( SELECT R.EXPTNO, COUNT(*) AS N
                FROM EXPT_CARGORECPT R
                JOIN #scope S ON S.EXPTNO = R.EXPTNO
                GROUP BY R.EXPTNO ) CR ON CR.EXPTNO = EM.EXPTNO
    LEFT JOIN ( SELECT C.EXPTNO, COUNT(*) AS N
                FROM EXPT_CARTING C
                JOIN #scope S ON S.EXPTNO = C.EXPTNO
                GROUP BY C.EXPTNO ) CT ON CT.EXPTNO = EM.EXPTNO
    LEFT JOIN ( SELECT K.EXPTNO, COUNT(*) AS N
                FROM EXPT_CONTAINER1 K
                JOIN #scope S ON S.EXPTNO = K.EXPTNO
                GROUP BY K.EXPTNO ) CN ON CN.EXPTNO = EM.EXPTNO
    LEFT JOIN CONSIGNEE_MASTER CO ON CO.CON_CODE = EM.EXPT_CONSIGNEE
    LEFT JOIN VSL_MASTER       VM ON VM.VSL_RTNO = EM.EXPT_VESSEL
    LEFT JOIN ( SELECT P.VSL_RTNO, P.PORT, MAX(P.ETD) AS ETD
                FROM VSL_PORTDTLS P
                WHERE LEN(LTRIM(RTRIM(ISNULL(P.ETD,'')))) = 10
                GROUP BY P.VSL_RTNO, P.PORT ) VP
           ON VP.VSL_RTNO = EM.EXPT_VESSEL AND VP.PORT = EM.VSL_PORT;

    ---------------------------------------------------------------------------
    -- Table  : complete per-stage counts, with the house STATUS envelope.
    ---------------------------------------------------------------------------
    IF (SELECT COUNT(*) FROM #facts) > 0
    BEGIN
        SELECT '100' AS STATUS, STAGE_CODE, COUNT(*) AS N
        FROM #facts
        GROUP BY STAGE_CODE
        ORDER BY STAGE_CODE;

        -----------------------------------------------------------------------
        -- Table1 : newest @PERCOLUMN jobs per stage. A sample, not a total.
        -----------------------------------------------------------------------
        SELECT EXPTNO, STAGE_CODE, MODE, CONSIGNEE, VSL_NAME, VSL_VOYNO, ETD,
               SYSEXPT_DOCRECD, CANCELLED, HBLNO, BLNO, MAWB, HAWB
        FROM ( SELECT F.*,
                      ROW_NUMBER() OVER ( PARTITION BY F.STAGE_CODE
                                          ORDER BY F.SYSEXPT_DOCRECD DESC, F.ID DESC ) AS RN
               FROM #facts F ) R
        WHERE R.RN <= @lPER
        ORDER BY R.STAGE_CODE, R.RN;
    END
    ELSE
    BEGIN
        SELECT '103' AS STATUS, 'NO RECORD FOUND' AS statustext;
    END

    DROP TABLE #facts;
    DROP TABLE #scope;
END

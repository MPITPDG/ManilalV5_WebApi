using System;
using System.Collections.Concurrent;
using System.Data;
using System.Runtime.Caching;

namespace Manilal_V5NG.Utils
{
    /// <summary>
    /// Response cache for the Finance Dashboard.
    ///
    /// The dashboard proc takes ~27s for a full-year, all-branch run. The underlying
    /// figures are accounting balances that move slowly, so serving a cached DataSet for
    /// up to two hours turns the second and subsequent views into sub-second responses.
    ///
    /// Uses a DEDICATED MemoryCache rather than MemoryCache.Default so the memory limits
    /// set here cannot be affected by, or affect, anything else in the process.
    /// </summary>
    public static class DashboardCache
    {
        /// <summary>Bump this when the proc's result-set SHAPE changes, otherwise a redeploy
        /// keeps serving old-shaped DataSets to a new front end for up to the TTL.</summary>
        private const string SchemaVersion = "v2";

        private const int TtlMinutes = 120;

        private static MemoryCache _cache;
        private static readonly ConcurrentDictionary<string, object> _locks =
            new ConcurrentDictionary<string, object>();

        /// <summary>Cached payload plus the moment it was produced.</summary>
        private class Entry
        {
            public DataSet Data;
            public DateTime StoredAt;
        }

        /// <summary>Called once from Application_Start.</summary>
        public static void Configure()
        {
            if (_cache != null) return;

            var config = new System.Collections.Specialized.NameValueCollection();
            // Hard ceiling. Realistic key space is ~100 combinations at ~845KB each (~85MB);
            // 256MB leaves headroom without letting a pathological filter set recycle the pool.
            config["CacheMemoryLimitMegabytes"] = "256";
            config["PhysicalMemoryLimitPercentage"] = "10";
            config["PollingInterval"] = "00:02:00";

            _cache = new MemoryCache("FinanceDashboardCache", config);
        }

        private static MemoryCache Cache
        {
            get
            {
                if (_cache == null) Configure();
                return _cache;
            }
        }

        /// <summary>
        /// Builds the cache key. Company and branch are non-negotiable parts of it - a key
        /// that omitted branch would serve one branch's numbers to another.
        /// </summary>
        public static string BuildKey(string cmpCode, string cityCode, string fromDate,
                                      string toDate, string clientCode, string topN)
        {
            Func<string, string> n = s => (s ?? string.Empty).Trim().ToUpperInvariant();

            // Blank client normalises to '*' rather than empty so it cannot collide with a
            // client code that happens to trim to nothing.
            string client = n(clientCode);
            if (client.Length == 0) client = "*";

            return string.Join("|", "FD", SchemaVersion, n(cmpCode), n(cityCode),
                               n(fromDate), n(toDate), client, n(topN));
        }

        /// <summary>
        /// Single-client runs are never cached: they are already the fast path (~14s) and
        /// they are the only thing that can explode the footprint (410 clients x 9 branches
        /// would be several GB). Excluding them caps the cache at roughly 85MB.
        /// </summary>
        public static bool IsCacheable(string clientCode)
        {
            return string.IsNullOrEmpty((clientCode ?? string.Empty).Trim());
        }

        public static bool IsSyncNow(string syncNow)
        {
            string s = (syncNow ?? string.Empty).Trim();
            return s.Equals("1", StringComparison.OrdinalIgnoreCase)
                || s.Equals("Y", StringComparison.OrdinalIgnoreCase)
                || s.Equals("TRUE", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns the cached DataSet for <paramref name="key"/>, or runs <paramref name="produce"/>
        /// and caches the result.
        ///
        /// A per-key lock prevents a cache stampede: without it, N users arriving together on
        /// a cold key would each start a 27-second proc against the same SQL box.
        /// </summary>
        public static DataSet GetOrAdd(string key, bool cacheable, bool forceRefresh,
                                       Func<DataSet> produce, out DateTime storedAt, out bool wasCached)
        {
            if (!cacheable)
            {
                storedAt = DateTime.Now;
                wasCached = false;
                return produce();
            }

            if (!forceRefresh)
            {
                var hit = Cache.Get(key) as Entry;
                if (hit != null)
                {
                    storedAt = hit.StoredAt;
                    wasCached = true;
                    return hit.Data;
                }
            }

            object gate = _locks.GetOrAdd(key, _ => new object());
            lock (gate)
            {
                if (!forceRefresh)
                {
                    // Re-check inside the lock: another thread may have populated it while we waited.
                    var hit = Cache.Get(key) as Entry;
                    if (hit != null)
                    {
                        storedAt = hit.StoredAt;
                        wasCached = true;
                        return hit.Data;
                    }
                }

                DataSet fresh = produce();
                var entry = new Entry { Data = fresh, StoredAt = DateTime.Now };

                // Absolute, not sliding: a sliding window on a finance page means a heavily
                // viewed dashboard could serve numbers that never refresh.
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(TtlMinutes),
                    RemovedCallback = args =>
                    {
                        object dead;
                        _locks.TryRemove(args.CacheItem.Key, out dead);
                    }
                };
                Cache.Set(key, entry, policy);

                storedAt = entry.StoredAt;
                wasCached = false;
                return fresh;
            }
        }

        /// <summary>
        /// Appends a one-row metadata table so the page can show "as of ... (2h ago)".
        ///
        /// Appended by the API AFTER the proc returns, as the LAST table, so (a) the proc
        /// stays cache-agnostic and testable in SSMS and (b) existing table ordinals
        /// (Table..Table11) do not shift. Built fresh per response - the cached DataSet is
        /// shared by concurrent readers and must never be mutated in place.
        /// </summary>
        public static DataSet WithFreshness(DataSet ds, DateTime storedAt, bool wasCached, bool cacheable)
        {
            if (ds == null) return null;

            var meta = new DataTable("CACHEINFO");
            meta.Columns.Add("CACHED_AT", typeof(string));
            meta.Columns.Add("IS_CACHED", typeof(int));
            meta.Columns.Add("AGE_SECONDS", typeof(int));
            meta.Columns.Add("TTL_MINUTES", typeof(int));
            meta.Columns.Add("CACHEABLE", typeof(int));

            int age = (int)Math.Max(0, (DateTime.Now - storedAt).TotalSeconds);
            meta.Rows.Add(storedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                          wasCached ? 1 : 0, age, TtlMinutes, cacheable ? 1 : 0);

            // Copy the table into the returned DataSet without touching the cached instance.
            DataSet outer = new DataSet();
            foreach (DataTable t in ds.Tables) outer.Tables.Add(t.Copy());
            outer.Tables.Add(meta);
            return outer;
        }
    }
}

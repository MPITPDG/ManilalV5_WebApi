using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using Manilal_V5NG.Controllers.CommonBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mail;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data.OleDb;
using System.Data.SqlClient;
using Manilal_V5NG.Utils;
using Newtonsoft.Json;
//using OfficeOpenXml;
using ExcelDataReader;
using Microsoft.VisualBasic.FileIO;
using System.IO.Compression;

namespace Manilal_V5NG.Controllers.AccountsBLL
{
    /// <summary>Body of a "Mark as Filed" request from the GSTR-3B screen.</summary>
    public class Gstr3bFiling
    {
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string CMPCODE { get; set; }
        public string FILEDBY { get; set; }
        public string REMARKS { get; set; }
    }

    public class AccountsController : ApiController
    {
        /// <summary>Perform MIS INVOICE PENDING JOB records.</summary>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_INVOICE_PENDING_JOB(String FROMDATE, String TODATE, String MODE, String CMPCODE, String CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_INVOICE_PENDING_JOB", FROMDATE, TODATE, MODE, CMPCODE, CITYCODE, CITYCODE1);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_INVOICE_PENDING_JOB");
            }
            return Ok(ds);
        }

        /// <summary>
        /// Finance Dashboard - receivables, collection performance, billing mix, unbilled
        /// exposure and service-wise margin in a single call.
        /// </summary>
        /// <param name="FROMDATE">Period start, format dd/MM/yyyy (e.g. 01/04/2025).</param>
        /// <param name="TODATE">Period end and "as-on" date, format dd/MM/yyyy (e.g. 31/03/2026).</param>
        /// <param name="CMPCODE">Company code, e.g. 01.</param>
        /// <param name="CITYCODE">Branch: CITYCODE1 (101), 3-letter code (MUM), or ALL for consolidated.</param>
        /// <param name="CLIENTCODE">Client code (E......), blank for all clients.</param>
        /// <param name="TOPN">Row count for the top-N chart tables, blank/0 defaults to 10.</param>
        /// <param name="SYNCNOW">Optional. "1"/"Y"/"true" bypasses the 2-hour response cache and refreshes it.</param>
        /// <returns>
        /// DataSet with eight tables:
        /// Table  = KPI summary (single row),
        /// Table1 = client exposure and risk,
        /// Table2 = credit period vs actual recovery days (top N),
        /// Table3 = taxable / non-taxable split by currency,
        /// Table4 = unbilled ageing buckets,
        /// Table5 = unbilled job list,
        /// Table6 = receivable ageing, 9 buckets (top N),
        /// Table7 = margin by service category.
        /// Note: outstanding / ageing / exposure are AS-ON TODATE, while billing mix,
        /// collection days, margin and unbilled are bound to FROMDATE..TODATE.
        /// </returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_FINANCE_DASHBOARD(String FROMDATE, String TODATE, String CMPCODE, String CITYCODE, String CLIENTCODE, String TOPN, String SYNCNOW = null)
        {
            DataSet ds = new DataSet();
            DateTime storedAt = DateTime.Now;
            bool wasCached = false;
            bool cacheable = DashboardCache.IsCacheable(CLIENTCODE);

            try
            {
                string key = DashboardCache.BuildKey(CMPCODE, CITYCODE, FROMDATE, TODATE, CLIENTCODE, TOPN);

                ds = DashboardCache.GetOrAdd(key, cacheable, DashboardCache.IsSyncNow(SYNCNOW), () =>
                {
                    DAL objDal = new DAL();
                    // An omitted or empty query-string value binds to null here, and the DAL
                    // assigns it straight onto the SqlParameter. ADO.NET treats a null Value as
                    // "not supplied" and the call fails before it reaches SQL. CLIENTCODE is
                    // blank on the default all-clients view, so coalesce every parameter.
                    return objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                                 "USP_ACC_RPT_FINANCE_DASHBOARD",
                                                 FROMDATE ?? "", TODATE ?? "", CMPCODE ?? "",
                                                 CITYCODE ?? "", CLIENTCODE ?? "", TOPN ?? "");
                }, out storedAt, out wasCached);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_FINANCE_DASHBOARD");
            }

            // Appends CACHEINFO as the final table; never mutates the cached DataSet.
            return Ok(DashboardCache.WithFreshness(ds, storedAt, wasCached, cacheable));
        }

        /// <summary>
        /// Payable Dashboard - the supplier side of the finance dashboard.
        /// Cached like the receivable one; the accounts team presses Sync now after a
        /// payment run to see the effect immediately.
        /// </summary>
        /// <param name="FROMDATE">Period start, dd/MM/yyyy.</param>
        /// <param name="TODATE">Period end AND the as-on date, dd/MM/yyyy.</param>
        /// <param name="CMPCODE">Company code.</param>
        /// <param name="CITYCODE">Branch (CITYCODE1, 3-letter, or ALL).</param>
        /// <param name="SUPPLIERCODE">Supplier code; blank = all suppliers.</param>
        /// <param name="TOPN">Rows for the top-N sets.</param>
        /// <param name="LOOKBACK">Months of purchase history to load; blank = 12.</param>
        /// <param name="INFLOW">'1' also computes the receivable leg of the cash forecast.</param>
        /// <param name="SYNCNOW">'1' bypasses the cache.</param>
        /// <returns>
        /// Table  = KPI row,           Table1 = supplier exposure,
        /// Table2 = supplier ageing,   Table3 = portfolio ageing buckets,
        /// Table4 = cash forecast,     Table5 = open bill worklist,
        /// Table6 = how fast we pay,   Table7 = unlinked expense,
        /// Table8 = discrepancy summary, Table9 = discrepancy rows.
        /// </returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_PAYABLE_DASHBOARD(String FROMDATE, String TODATE, String CMPCODE, String CITYCODE, String SUPPLIERCODE, String TOPN, String LOOKBACK = null, String INFLOW = null, String SYNCNOW = null)
        {
            DataSet ds = new DataSet();
            DateTime storedAt = DateTime.Now;
            bool wasCached = false;
            bool cacheable = DashboardCache.IsCacheable(SUPPLIERCODE);

            try
            {
                // distinct namespace from the receivable dashboard, and the two switches
                // that change the result set are part of the key
                string key = "PAYABLE|" + DashboardCache.BuildKey(CMPCODE, CITYCODE, FROMDATE, TODATE, SUPPLIERCODE, TOPN)
                           + "|" + (LOOKBACK ?? "") + "|" + (INFLOW ?? "");

                ds = DashboardCache.GetOrAdd(key, cacheable, DashboardCache.IsSyncNow(SYNCNOW), () =>
                {
                    DAL objDal = new DAL();
                    // POSITIONAL - the proc signature is
                    //   @FROMDATE @TODATE @CMPCODE @CITYCODE @SUPPLIERCODE @TOPN
                    //   @DEFTERM @LOOKBACK @INCDED @INFLOW
                    // DEFTERM and INCDED are passed blank so the proc's own defaults apply
                    // (30 days assumed terms; the bill is already net of TDS).
                    return objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                                 "USP_ACC_RPT_PAYABLE_DASHBOARD",
                                                 FROMDATE ?? "", TODATE ?? "", CMPCODE ?? "",
                                                 CITYCODE ?? "", SUPPLIERCODE ?? "", TOPN ?? "",
                                                 "", LOOKBACK ?? "", "", INFLOW ?? "");
                }, out storedAt, out wasCached);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_PAYABLE_DASHBOARD");
            }

            return Ok(DashboardCache.WithFreshness(ds, storedAt, wasCached, cacheable));
        }

        /// <summary>
        /// Finance Dashboard data-quality audit (the AUDIT tab). Deliberately NOT cached:
        /// fixing a credit period or matching a receipt should be visible immediately.
        /// </summary>
        /// <param name="FROMDATE">Period start, dd/MM/yyyy.</param>
        /// <param name="TODATE">Period end, dd/MM/yyyy.</param>
        /// <param name="CMPCODE">Company code.</param>
        /// <param name="CITYCODE">Branch (CITYCODE1, 3-letter, or ALL).</param>
        /// <param name="CLIENTCODE">Accepted for interface parity; checks are portfolio level.</param>
        /// <param name="TOPN">Unused; interface parity.</param>
        /// <returns>Table = one row per check; Table1 = drill rows (top 500 per check).</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_FINANCE_DASHBOARD_AUDIT(String FROMDATE, String TODATE, String CMPCODE, String CITYCODE, String CLIENTCODE, String TOPN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                           "USP_ACC_RPT_FINANCE_DASHBOARD_AUDIT",
                                           FROMDATE ?? "", TODATE ?? "", CMPCODE ?? "",
                                           CITYCODE ?? "", CLIENTCODE ?? "", TOPN ?? "");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_FINANCE_DASHBOARD_AUDIT");
            }
            return Ok(ds);
        }

        /// <summary>GSTR-3B working, branch wise - output liability vs input set-off.</summary>
        /// <param name="FROMDATE">Period start, format dd-MMM-yyyy (e.g. 01-Jul-2026).</param>
        /// <param name="TODATE">Period end, format dd-MMM-yyyy (e.g. 31-Jul-2026).</param>
        /// <param name="CMPCODE">Company code, blank for all companies.</param>
        /// <returns>
        /// DataSet with five tables:
        /// Table  = GSTR-3B section-wise summary per branch,
        /// Table1 = net position per branch,
        /// Table2 = ledger-wise break-up,
        /// Table3 = reconciliation warnings,
        /// Table4 = reverse-charge ITC deferred to next month.
        /// </returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_GSTR3B_BRANCHWISE(String FROMDATE, String TODATE, String CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                           "USP_ACC_RPT_GSTR3B_BRANCHWISE", FROMDATE, TODATE, CMPCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_GSTR3B_BRANCHWISE");
            }
            return Ok(ds);
        }

        /// <summary>Archive the GSTR-3B figures for a period as proof of what was filed.</summary>
        /// <param name="obj">Period, company, who filed it and any remark.</param>
        /// <returns>DataSet with the new filing id and the row counts archived.</returns>
        /// <remarks>POST because it writes. The figures are recomputed server-side rather than
        /// taken from the browser, so the archive is evidence rather than a client echo.</remarks>
        [HttpPost]
        public IHttpActionResult ACC_GSTR3B_FILING_SAVE([FromBody] Gstr3bFiling obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                           "USP_ACC_GSTR3B_FILING_SAVE",
                                           obj.FROMDATE, obj.TODATE, obj.CMPCODE, obj.FILEDBY, obj.REMARKS);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_GSTR3B_FILING_SAVE");
            }
            return Ok(ds);
        }

        /// <summary>List the archived GSTR-3B filings for a company.</summary>
        /// <param name="CMPCODE">Company code, blank for all.</param>
        /// <returns>DataSet of filings, newest first.</returns>
        [HttpGet]
        public IHttpActionResult ACC_GSTR3B_FILING_LIST(String CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                           "USP_ACC_GSTR3B_FILING_LIST", CMPCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_GSTR3B_FILING_LIST");
            }
            return Ok(ds);
        }

        /// <summary>Open one archived filing next to a live recomputation of the same period.</summary>
        /// <param name="FILINGID">Primary key of the filing.</param>
        /// <returns>
        /// DataSet with three tables: Table = header incl. CHANGED_ROWS,
        /// Table1 = ledger statement as filed vs live with a CHANGED flag,
        /// Table2 = the GSTR-3B figures as filed.
        /// </returns>
        [HttpGet]
        public IHttpActionResult ACC_GSTR3B_FILING_VIEW(String FILINGID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                                           "USP_ACC_GSTR3B_FILING_VIEW", FILINGID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_GSTR3B_FILING_VIEW");
            }
            return Ok(ds);
        }

        /// <summary>Perform DownloadZip records.</summary>
        /// <param name="fileName">file Name parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        [Route("DownloadZip")]
        public HttpResponseMessage DownloadZip(string fileName)
        {
            var filePath = HttpContext.Current.Server.MapPath("~/DATA/MIS/" + fileName + ".zip");

            if (!File.Exists(filePath))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "File not found.");
            }

            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName + ".zip"
            };
            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/zip");

            return result;
        }
        [System.Web.Http.Description.ApiExplorerSettings(IgnoreApi = true)]
        public string ZipExcelFiles(List<string> filePaths, string zipFilePath)
        {
            using (FileStream zipToOpen = new FileStream(zipFilePath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    ZipArchiveEntry entry = archive.CreateEntry(fileName);
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(entryStream);
                    }
                }
            }

            return zipFilePath;
        }

        /// <summary>Perform GenerateConsigneeJobProfit records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GenerateConsigneeJobProfit([FromBody] consigneejobprofit obj)
        {
            var sb = new StringBuilder();
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strHeader = "";

            try
            {
                strHeader += $"<tr><td style='font-family:Calibri; font-size:normal;' >Timeline :</td><td width='700px' style='font-family:Calibri; font-size:normal;'>{obj.headerfromdt} - {obj.headertodt} [{obj.Mode}]</td></tr>";
                strHeader += $"<tr style='font-family:Calibri; font-size:normal;'><td width='700px'>Consignee - {obj.consgname}</td></tr>";
                strHeader = $"<table border='0' cellpadding='0' cellspacing='0' width='800px'>{strHeader}</table>";

                ds = objDal.ExecuteDataset(
                    ConnectionString.getConnString(), CommandType.StoredProcedure,
                    "USP_ACC_RPT_JOBPROFITS_NEW",
                   obj.FromDate, obj.ToDate, obj.JobNoFrom, obj.JobNoTo, obj.SearchType, obj.DateType,
                    obj.Mode, obj.citycode1, obj.citycode, obj.cmpcode, obj.concode
                );

                if (ds.Tables[0].Rows[0][0].ToString() == "100")
                {
                    // Add additional header rows
                    string strStringStart = "<table border='1' cellpadding='0' cellspacing='0'><tr>" +
                        "<td colspan='3' style='font-family:Calibri;font-weight:bold; font-size:normal;' align='center'>[G100236] CUSTOM DUTY</td>" +
                        "<td></td><td></td><td></td>" +
                        "<td colspan='3' style='font-family:Calibri;font-weight:bold; font-size:normal;' align='center'>TOTAL</td>";

                    string STRSTRING = "";

                    foreach (DataRow row in ds.Tables[5].Rows)
                    {
                        STRSTRING += $"<td colspan='3' style='font-family:Calibri; font-weight:bold;font-size:normal;' width='100%' align='center'>{row["ACCTCODENAME"]}</td>";
                    }

                    STRSTRING += "</tr></table>";

                    strHeader += strStringStart + STRSTRING;

                    if (ds.Tables.Count > 2)
                    {
                        string fileKey = $"{obj.FromDate.Substring(6, 4) + obj.FromDate.Substring(3, 2) + obj.FromDate.Substring(0, 2)}_{obj.ToDate.Substring(6, 4) + obj.ToDate.Substring(3, 2) + obj.ToDate.Substring(0, 2)}";
                        Generate_ExcelFile("2", ds.Tables[2], fileKey, strHeader, obj.username);
                        string excelPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\MIS\" + obj.username + "_JOBPROFIT_" + fileKey + "_" + "2" + "_" + "CONSIGNEE_JOB_TANS_SUMMARY" + "_RPT.xls";
                        var filesToZip = new List<string> { excelPath };
                        string zipPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\MIS\" + fileKey + "_" + obj.username + "_CONSIGNEEJOBPROFIT" + ".zip";
                        ZipExcelFiles(filesToZip, zipPath);
                        string flname = fileKey + "_" + obj.username + "_CONSIGNEEJOBPROFIT";
                        // ✅ Return download path to Angular
                        string downloadUrl = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\MIS\" + fileKey + ".zip";
                        return Ok(new { status = "success", downloadUrl, flname });
                    }
                }
                else
                {
                    sb.Append("No data found for the specified parameters.");
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/GenerateConsigneeJobProfit");
                sb.Append("An error occurred while generating the report.");
            }

            return Ok(new { status = "no_data", message = "No data found for the specified parameters." });
        }

        public string Generate_ExcelFile(string iFiles, DataTable dt, string sDate, string strHeader, string username)
        {
            string vDepartment = string.Empty;
            string vUSER = username;

            switch (iFiles)
            {
                case "0":
                    vDepartment = "CONSIGNEE_SUMMARY";
                    break;
                case "1":
                    vDepartment = "CONSIGNEE_JOB_SUMMARY";
                    break;
                case "2":
                    vDepartment = "CONSIGNEE_JOB_TANS_SUMMARY";
                    break;
                case "3":
                    vDepartment = "CONSIGNEE_JOB_DETAILS";
                    break;
            }

            string strFileName = "\\" + vUSER + "_JOBPROFIT_" + sDate + "_" + iFiles + "_" + vDepartment + "_RPT.xls";
            // string strFilePath = System.Web.HttpContext.Current.Server.MapPath("~/") +
            //       System.Configuration.ConfigurationManager.AppSettings["PATH_EXPORTTOXL"] +
            //     "/MIS/" + strFileName;
            string strFilePath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\MIS\" + strFileName;


            StringBuilder sb = new StringBuilder();

            // Add header
            sb.Append(strHeader);

            // Start HTML table
            sb.Append("<table border='1' cellpadding='0' cellspacing='0' style='font-family:Calibri;' >");

            // Add column headers
            sb.Append("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append($"<td style='font-family:Calibri; font-size:normal;'>{col.ColumnName}</td>");
            }
            sb.Append("</tr>");

            // Add rows
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (var cell in row.ItemArray)
                {
                    sb.Append($"<td>{cell}</td>");
                }
                sb.Append("</tr>");
            }

            // End table
            sb.Append("</table>");

            // Write to file
            File.WriteAllText(strFilePath, sb.ToString(), Encoding.UTF8);

            return strFileName;
        }

        /// <summary>Retrieve print/view data for CREDITNOTE VIEW OLDENTRY records.</summary>
        /// <param name="CREDITNOTENO">CREDITNOTENO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CREDITNOTE_VIEW_OLDENTRY(String CREDITNOTENO, String CMPCODE, String CITYCODE, String CMPID, String VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_CreditNote_Print_35_ng", CREDITNOTENO, CMPCODE, CITYCODE, CMPID, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CREDITNOTE_VIEW_OLDENTRY");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for CRTNOTE RESET INVOICE records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_RESET_INVOICE(string CMPID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRNOTE_INVDTLS_OLDENTRY_RESET", CMPID, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_RESET_INVOICE");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update CRTNOTE INVOICE records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CRTNOTE_INVOICE_IU([FromBody]creditnote obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_Invoicet_IU_OldEntry", (obj.CMPID == null) ? "" : obj.CMPID, (obj.CRT_NO == null) ? "" : obj.CRT_NO, (obj.MAKERIP == null) ? "" : obj.MAKERIP, (obj.VGUID == null) ? "" : obj.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_INVOICE_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform CashBook BankRecousillationAsOnDate records.</summary>
        /// <param name="_ourbank"> ourbank parameter.</param>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CashBook_BankRecousillationAsOnDate(string _ourbank, string _FromDt, string _ToDt, string cmpcode, string citycode, string citycode1, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_BankRecousillation_AsOndate", _ourbank, _FromDt, _ToDt, cmpcode, citycode, citycode1, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CashBook_BankRecousillationAsOnDate");
            }
            return Ok(ds);
        }
        /// <summary>Perform CashBook BankRecousillation UpdateNew records.</summary>
        /// <param name="_reconsillationstr"> reconsillationstr parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CashBook_BankRecousillation_UpdateNew(string _reconsillationstr, string OURBANK, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Acc_CashBook_BankRecousillation_UpdateNew", _reconsillationstr,  OURBANK, FROMDATE, TODATE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/Acc_CashBook_BankRecousillation_UpdateNew");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform CREDITNOTE GETINVOICE BALAMOUNT records.</summary>
        /// <param name="invno">Invoice number.</param>
        /// <param name="crtno">crtno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CREDITNOTE_GETINVOICE_BALAMOUNT(string invno, string crtno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_acc_creditnote_getInvoiceamt", invno, (crtno != null) ? crtno : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CREDITNOTE_GETINVOICE_BALAMOUNT");
            }
            return Ok(ds);
        }
        /// <summary>Perform ECREDITNOTERESETDATA FORJSON records.</summary>
        /// <param name="JSONFILEID">JSONFILEID parameter.</param>
        /// <param name="CRNOTEID">CRNOTEID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ECREDITNOTERESETDATA_FORJSON(string JSONFILEID, string CRNOTEID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_ECREDITNOTE_RESETJSON_UPDATEGSTIRN_NG", JSONFILEID, CRNOTEID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ECREDITNOTERESETDATA_FORJSON");
            }
            return Ok(ds);
        }
        /// <summary>Perform ECreditNote ResetJsonList records.</summary>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ECreditNote_ResetJsonList(string FINSTARTDT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_ECREDITNOTE_RESET_JSONDATA", FINSTARTDT, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ECreditNote_ResetJsonList");
            }
            return Ok(ds);
        }
        /// <summary>Upload UploadBnkReconcilFile records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UploadBnkReconcilFile()
        {
            //HttpResponseMessage response = null;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var ourbank = HttpContext.Current.Request.Params["ourbank"];
            var fromdt = HttpContext.Current.Request.Params["fromdt"];
            var todt = HttpContext.Current.Request.Params["todt"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\BankReconcil\\", fileName);

                    if (File.Exists(filePath) == true)
                    {
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("MSG", typeof(string));
                        drow = dtbl.NewRow();
                        drow[0] = "104";
                        drow[1] = fileName + " already exists";
                        dtbl.Rows.Add(drow);
                        ds1.Merge(dtbl);
                    }
                    else
                    {


                        file.SaveAs(filePath);
                        string strExtension;
                        strExtension = Path.GetExtension(fileName);
                        //ds1 = fN_upload_BankreconcilExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
                        //  ds1 = UploadBankReconcilFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
                        if (strExtension == ".xlsx")
                        {
                            ds1 = UploadBankReconcilFilexlsx(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
                        }
                        else if (strExtension == ".xls")
                        {
                            ds1 = UploadBankReconcilFilexls(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
                        }
                        else if (strExtension == ".csv")
                        {
                            ds1 = UploadBankReconcilFilecsv(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
                        }


                        if (ds1.Tables.Count > 0 &&  //&& ds1.Tables[0].Rows.Count > 0
                                         ds1.Tables[0].Columns.Count > 0)
                        {
                            // Access the first column of the first row in the first table
                            if (ds1.Tables[0].Rows[0][0].ToString() == "104")
                            {
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                    //Console.WriteLine($"File {filePath} deleted successfully.");
                                }
                            }

                            else
                            {
                                dtbl.Columns.Add("STATUS", typeof(string));
                                dtbl.Columns.Add("MSG", typeof(string));
                                drow = dtbl.NewRow();
                                drow[0] = "100";
                                drow[1] = fileName + " uploaded successfully";
                                // drow[0] = fileName + " uploaded successfully";
                                dtbl.Rows.Add(drow);
                                ds1.Merge(dtbl);
                            }
                        }


                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/UploadBnkReconcilFile");
            }
            return Ok(ds1);

        }

        /// <summary>Upload a bank reconciliation statement (V2) and update clearance dates via USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT_V2.</summary>
        /// <remarks>
        /// Multipart form upload. Expects a single file plus the following form/query fields:
        /// cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt.
        /// Calls USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT_V2 with a hardcoded @LOOKBACKYEARS=2
        /// and @DEBUG=0.
        /// Accepts .xlsx, .xls, and .csv statement files.
        /// </remarks>
        /// <returns>DataSet with the upload/clearance status serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UploadBnkReconcilFileV2()
        {
            const string SPNAME = "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT_V2";

            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            DataRow drow = dtbl.NewRow();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var ourbank = HttpContext.Current.Request.Params["ourbank"];
            var fromdt = HttpContext.Current.Request.Params["fromdt"];
            var todt = HttpContext.Current.Request.Params["todt"];
            try
            {
                // Fail fast with a readable message if the V2 proc has not been
                // deployed. Without this the SqlException is swallowed by the
                // handler's own catch (ErrorLog.Error disposes its DataSet in a
                // finally block and the caller discards the return value), the
                // handler returns an EMPTY DataSet, and the browser gets an
                // unexplained "unexpected response from the server".
                object procId;
                using (SqlConnection chk = new SqlConnection(ConnectionString.getConnString()))
                {
                    chk.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT OBJECT_ID(@p)", chk))
                    {
                        cmd.Parameters.AddWithValue("@p", "dbo." + SPNAME);
                        procId = cmd.ExecuteScalar();
                    }
                }
                if (procId == null || procId == DBNull.Value)
                {
                    dtbl.Columns.Add("STATUS", typeof(string));
                    dtbl.Columns.Add("MSG", typeof(string));
                    drow = dtbl.NewRow();
                    drow[0] = "104";
                    drow[1] = "Stored procedure " + SPNAME + " does not exist on this database. Run the _V2 script, then retry.";
                    dtbl.Rows.Add(drow);
                    ds1.Merge(dtbl);
                    return Ok(ds1);
                }

                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\BankReconcil\\", fileName);

                    // DATA\BankReconcil is not in source control and is absent on a
                    // fresh checkout, so file.SaveAs threw "Could not find a part of
                    // the path". Create it on demand instead of requiring a manual
                    // step on every new environment.
                    string uploadDir = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    if (File.Exists(filePath) == true)
                    {
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("MSG", typeof(string));
                        drow = dtbl.NewRow();
                        drow[0] = "104";
                        drow[1] = fileName + " already exists on the server. Rename the file, or delete it from DATA\\BankReconcil, then retry.";
                        dtbl.Rows.Add(drow);
                        ds1.Merge(dtbl);
                    }
                    else
                    {
                        file.SaveAs(filePath);
                        string strExtension = Path.GetExtension(fileName);

                        // true = the _V2 proc takes @LOOKBACKYEARS and @DEBUG on top
                        // of the original four parameters, and the DAL requires every
                        // one of them to be supplied explicitly.
                        if (strExtension == ".xlsx")
                        {
                            ds1 = UploadBankReconcilFilexlsx(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt, SPNAME, true);
                        }
                        else if (strExtension == ".xls")
                        {
                            ds1 = UploadBankReconcilFilexls(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt, SPNAME, true);
                        }
                        else if (strExtension == ".csv")
                        {
                            ds1 = UploadBankReconcilFilecsv(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt, SPNAME, true);
                        }

                        if (ds1.Tables.Count > 0 && ds1.Tables[0].Columns.Count > 0)
                        {
                            if (ds1.Tables[0].Rows.Count > 0 && ds1.Tables[0].Rows[0][0].ToString() == "104")
                            {
                                if (File.Exists(filePath))
                                {
                                    File.Delete(filePath);
                                }
                            }
                            else
                            {
                                dtbl.Columns.Add("STATUS", typeof(string));
                                dtbl.Columns.Add("MSG", typeof(string));
                                drow = dtbl.NewRow();
                                drow[0] = "100";
                                drow[1] = fileName + " uploaded successfully";
                                dtbl.Rows.Add(drow);
                                ds1.Merge(dtbl);
                            }
                        }
                        else
                        {
                            // The handler returned an EMPTY DataSet, which means it
                            // caught an exception internally. ErrorLog now stashes
                            // the message in HttpContext.Items, so report the real
                            // cause instead of a guess.
                            string detail = HttpContext.Current.Items[ErrorLog.LastErrorKey] as string;

                            // Preserve the file for inspection, then clear the
                            // original so the retry does not trip "already exists".
                            try
                            {
                                if (File.Exists(filePath))
                                {
                                    string failedDir = Path.Combine(uploadDir, "_failed");
                                    if (!Directory.Exists(failedDir)) Directory.CreateDirectory(failedDir);
                                    string keep = Path.Combine(failedDir, fileName);
                                    if (File.Exists(keep)) File.Delete(keep);
                                    File.Move(filePath, keep);
                                }
                            }
                            catch { /* keeping a copy is best-effort */ }

                            dtbl.Columns.Add("STATUS", typeof(string));
                            dtbl.Columns.Add("MSG", typeof(string));
                            drow = dtbl.NewRow();
                            drow[0] = "104";
                            drow[1] = string.IsNullOrEmpty(detail)
                                    ? ("The server could not process " + fileName + ", and no error detail was captured.")
                                    : ("Could not process " + fileName + ". Server error: " + detail);
                            dtbl.Rows.Add(drow);
                            ds1.Merge(dtbl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/UploadBnkReconcilFileV2");

                // ErrorLog swallows everything (it disposes its own DataSet and
                // the return value is discarded), so surface the message here or
                // the caller gets an empty DataSet with no explanation.
                DataSet dsErr = new DataSet();
                DataTable terr = new DataTable();
                terr.Columns.Add("STATUS", typeof(string));
                terr.Columns.Add("MSG", typeof(string));
                terr.Rows.Add("104", "Upload failed: " + ex.Message);
                dsErr.Tables.Add(terr);
                return Ok(dsErr);
            }
            return Ok(ds1);
        }

        public DataSet UploadBankReconcilFilecsv(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string OURBANK, string FROMDT, string TODT, string SPNAME = "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT", bool SPTAKESV2ARGS = false)
        {
            DataSet dsupdate = new DataSet();
            string uploadedfromdate = "";
            string uploadedtodate = "";
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {

                string strFilePath;
                strFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "DATA", "BankReconcil", strFileName);
                file.SaveAs(strFilePath);


                // if (strExtension.ToLower() == ".csv")
                //{
                //// Handle CSV file
                using (var reader = new StreamReader(strFilePath))
                {
                    // Skip the first two lines (assuming the third line contains the dates)
                    for (int i = 0; i < 2; i++)
                    {
                        reader.ReadLine();
                    }

                    // Read the third line to extract uploaded from date and to date
                    var thirdLine = reader.ReadLine();
                    string[] lineParts = thirdLine.Split(',');
                    var datestr = lineParts[1];

                    //string[] dates = thirdLine.Split(new string[] { "To" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (dates.Length == 2)
                    //{
                    //    string fromDatePart = dates[0].Substring(dates[0].IndexOf(',') + 1).Trim(); // Extract from date
                    //    string toDatePart = dates[1].Trim().TrimEnd(','); // Extract to date

                    //    // Parse the dates
                    //    DateTime parsedFromDate, parsedToDate;
                    //    if (DateTime.TryParse(fromDatePart, out parsedFromDate) &&
                    //        DateTime.TryParse(toDatePart, out parsedToDate))
                    //    {
                    //        uploadedfromdate = parsedFromDate.ToString("dd/MM/yyyy");
                    //        uploadedtodate = parsedToDate.ToString("dd/MM/yyyy");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Invalid date format in the cell.");
                    //        // Handle the error as needed
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invalid date format in the cell.");
                    //    // Handle the error as needed
                    //}

                    // Initialize a DataTable to store the CSV data
                    DataTable csvData = new DataTable();

                    for (int i = 0; i < 1; i++)
                    {
                        reader.ReadLine();
                    }

                    // Read the header line to determine column names
                    var headerLine = reader.ReadLine();
                    headerLine = headerLine.Replace("\"", "");
                    Console.WriteLine($"Header line: {headerLine}");
                    var headers = headerLine.Split(',');

                    // Remove any empty or whitespace entries in the headers
                    headers = headers.Where(h => !string.IsNullOrWhiteSpace(h)).ToArray();

                    // Add columns to the DataTable based on the header line
                    foreach (var header in headers)
                    {
                        csvData.Columns.Add(header.Trim()); // Trim to remove leading/trailing spaces
                    }


                    // Use TextFieldParser to properly parse CSV data
                    using (var parser = new TextFieldParser(reader))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");

                        int lineCount = 0;
                        // Read the CSV data line by line
                        while (!parser.EndOfData)
                        {
                            // Read current line and parse it
                            string[] fields = parser.ReadFields();
                            // Increment line count
                            //lineCount++;

                            // Skip last three lines
                            //if (lineCount > (totalLines - 3))
                            //{
                            //    continue;
                            //}
                            // Create a new DataRow
                            DataRow row = csvData.NewRow();

                            // Assign values to each column in the DataRow
                            for (int i = 0; i < fields.Length; i++)
                            {
                                row[headers[i].Trim()] = fields[i].Trim(); // Use column names from headers
                            }

                            // Add the DataRow to the DataTable
                            csvData.Rows.Add(row);
                        }
                    }

                    if (csvData.Rows.Count >= 3)
                    {
                        // Remove the last three rows
                        for (int i = 0; i < 3; i++)
                        {
                            csvData.Rows.RemoveAt(csvData.Rows.Count - 1);
                        }
                    }
                    else
                    {
                        // Handle the case where there are less than three rows in the DataTable
                        Console.WriteLine("DataTable does not have enough rows to remove.");
                    }
                    // Now you have the CSV data in the DataTable (csvData)
                    // Process the DataTable as needed, e.g., insert into the database
                    DataSet dsupload = new DataSet();
                    DAL objDal = new DAL();
                    dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_UPLOAD_BANKRECONCILXL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "BANKRECONCIL", datestr);
                    string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();
                    if (status == "100")
                    {
                        string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();

                        // Process the DataTable and insert into the database
                        using (SqlConnection connection = new SqlConnection(ConnectionString.getConnString()))
                        {
                            connection.Open();
                            foreach (DataRow row in csvData.Rows)
                            {
                                // Access data from each row and insert into the database
                                string insertQuery = "INSERT INTO ACC_BANKRECONCIL_UPLOADSTATEMENT_TMP (FK_LOGID,DATE, BTRANSACTION, CURRENCY, DEPOSIT, WITHDRAWAL, RUNNINGBAL, UPLOADEDBY, UPLOADEDDATE) " +
                                                     "VALUES (@logid,@Date, @Transaction, @Currency, @Deposit, @Withdrawal, @RunningBalance, @UPLOADEDBY, @UPLOADEDDATE)";
                                SqlCommand command = new SqlCommand(insertQuery, connection);
                                if (int.TryParse(logid.Trim('"'), out int parsedlogid))
                                {
                                    // Add the parsed CMPID as a parameter
                                    command.Parameters.AddWithValue("@logid", parsedlogid);
                                }
                                else
                                {
                                    // Handle the error if parsing fails
                                    Console.WriteLine("Error: Unable to parse logid to integer.");
                                }
                                //  command.Parameters.AddWithValue("@logid", logid);
                                command.Parameters.AddWithValue("@Date", row["Date"].ToString());
                                command.Parameters.AddWithValue("@Transaction", row["Transaction"].ToString());
                                command.Parameters.AddWithValue("@Currency", row["Currency"].ToString());
                                //string depositString = row["Deposit"].ToString();
                                //decimal depositValue;
                                //if (decimal.TryParse(depositString.Replace(",", ""), out depositValue))
                                //{
                                //    // Successfully parsed the deposit value without commas
                                //    // Now you can insert depositValue into the database
                                //    command.Parameters.AddWithValue("@Deposit", depositValue);
                                //}
                                //else
                                //{
                                //   Console.WriteLine("Failed to parse deposit value: " + depositString);
                                //}
                                // Assuming row["Deposit"] is a string containing the Deposit value
                                // Assuming row["Deposit"] is a string containing the Deposit value
                                string DepositString = row["Deposit"].ToString();

                                // Check if the Deposit value is not empty
                                if (!string.IsNullOrWhiteSpace(DepositString))
                                {
                                    // Remove commas from the Deposit value
                                    decimal DepositValue;
                                    if (decimal.TryParse(DepositString.Replace(",", ""), out DepositValue))
                                    {
                                        // Successfully parsed the Deposit value without commas
                                        // Now you can insert DepositValue into the database
                                        command.Parameters.AddWithValue("@Deposit", DepositValue);
                                    }
                                    else
                                    {
                                        // Failed to parse the Deposit value
                                        // Handle the error or insert a default value as needed
                                        // For example:
                                        // command.Parameters.AddWithValue("@Deposit", DBNull.Value); // Insert NULL value
                                        // or
                                        // Log an error message
                                        Console.WriteLine("Failed to parse Deposit value: " + DepositString);
                                    }
                                }
                                else
                                {
                                    // The Deposit value is empty, so you can handle it accordingly
                                    // For example, you can insert a default value or NULL into the database
                                    // Here, I'm inserting NULL into the database
                                    command.Parameters.AddWithValue("@Deposit", DBNull.Value);
                                }
                                // Assuming row["Withdrawal"] is a string containing the withdrawal value
                                string withdrawalString = row["Withdrawal"].ToString();

                                // Check if the withdrawal value is not empty
                                if (!string.IsNullOrWhiteSpace(withdrawalString))
                                {
                                    // Remove commas from the withdrawal value
                                    decimal withdrawalValue;
                                    if (decimal.TryParse(withdrawalString.Replace(",", ""), out withdrawalValue))
                                    {
                                        // Successfully parsed the withdrawal value without commas
                                        // Now you can insert withdrawalValue into the database
                                        command.Parameters.AddWithValue("@Withdrawal", withdrawalValue);
                                    }
                                    else
                                    {
                                        // Failed to parse the withdrawal value
                                        // Handle the error or insert a default value as needed
                                        // For example:
                                        // command.Parameters.AddWithValue("@Withdrawal", DBNull.Value); // Insert NULL value
                                        // or
                                        // Log an error message
                                        Console.WriteLine("Failed to parse withdrawal value: " + withdrawalString);
                                    }
                                }
                                else
                                {
                                    // The withdrawal value is empty, so you can handle it accordingly
                                    // For example, you can insert a default value or NULL into the database
                                    // Here, I'm inserting NULL into the database
                                    command.Parameters.AddWithValue("@Withdrawal", DBNull.Value);
                                }
                                string RunningBalanceString = row["Running Balance"].ToString();
                                decimal RunningBalanceValue;
                                if (decimal.TryParse(RunningBalanceString.Replace(",", ""), out RunningBalanceValue))
                                {
                                    // Successfully parsed the deposit value without commas
                                    // Now you can insert depositValue into the database
                                    command.Parameters.AddWithValue("@RunningBalance", RunningBalanceValue);
                                }
                                else
                                {
                                    Console.WriteLine("Failed to parse RunningBalance value: " + RunningBalanceString);
                                }
                                // command.Parameters.AddWithValue("@Deposit", row["Deposit"].ToString());
                                // command.Parameters.AddWithValue("@Withdrawal", row["Withdrawal"].ToString());
                                // command.Parameters.AddWithValue("@RunningBalance", row["Running Balance"].ToString()); // Use the exact column name from headers
                                if (int.TryParse(CMPID.Trim('"'), out int parsedCMPID))
                                {
                                    // Add the parsed CMPID as a parameter
                                    command.Parameters.AddWithValue("@UPLOADEDBY", parsedCMPID);
                                }
                                else
                                {
                                    // Handle the error if parsing fails
                                    Console.WriteLine("Error: Unable to parse CMPID to integer.");
                                }
                                // command.Parameters.AddWithValue("@UPLOADEDBY", CMPID);
                                command.Parameters.AddWithValue("@UPLOADEDDATE", DateTime.Now);
                                command.ExecuteNonQuery();
                            }
                        }
                        // See the note in the xlsx handler: the DAL discovers proc
                        // parameters from the database and requires an exact count,
                        // so _V2's @LOOKBACKYEARS and @DEBUG must be passed here.
                        dsupdate = SPTAKESV2ARGS
                            ? objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid, 2, 0)
                            : objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid);
                    }
                    else
                    {
                        DataTable dtbl = new DataTable();
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("MSG", typeof(string));

                        DataRow drow = dtbl.NewRow();
                        drow["STATUS"] = "104";

                        if (dsupload.Tables.Count > 0 && dsupload.Tables[0].Columns.Contains("STATUSTEXT"))
                        {
                            drow["MSG"] = dsupload.Tables[0].Rows[0]["STATUSTEXT"].ToString();
                        }
                        else
                        {
                            // Handle the case when "STATUSTEXT" column is not found in dsupload.Tables[0]
                            drow["MSG"] = "Status text not available";
                        }

                        dtbl.Rows.Add(drow);

                        if (dsupdate.Tables.Contains("Table"))
                        {
                            dtbl.TableName = "Table"; // Set the table name explicitly
                            dsupdate.Tables.Add(dtbl.Copy());
                        }
                        else
                        {
                            dsupdate.Tables.Add(dtbl); // Add the table without setting its name
                        }
                    }
                }
            }
            // Remaining code for processing and database operations...

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_BankreconcilFile");
            }
            return dsupdate;
        }
        public DataSet UploadBankReconcilFilexls(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string OURBANK, string FROMDT, string TODT, string SPNAME = "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT", bool SPTAKESV2ARGS = false)
        {
            DataSet dsupdate = new DataSet();
            string uploadedfromdate = "";
            string uploadedtodate = "";
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                //strFileName = Path.GetFileName(strFileName);
                //string strExtension;
                //strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "DATA", "BankReconcil", strFileName);
                file.SaveAs(strFilePath);


                //if (strExtension.ToLower() == ".xls")
                //{
                // Handle XLS file
                using (var stream = File.Open(strFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateBinaryReader(stream))

                    {
                        var result = reader.AsDataSet();
                        var sheet = result.Tables[0]; // Assuming data is in the first sheet

                        // Extract the uploaded from date and to date from a specific cell
                        string cellValue = sheet.Rows[2][1].ToString(); // Assuming the cell is at B3
                        string[] dates = cellValue.Split(new string[] { " To " }, StringSplitOptions.RemoveEmptyEntries);
                        //if (dates.Length == 2)
                        //{
                        //    // Assuming the date format is dd/MM/yyyy, parse the dates
                        //    if (DateTime.TryParse(dates[0], out DateTime fromDate) && DateTime.TryParse(dates[1], out DateTime toDate))
                        //    {
                        //        Console.WriteLine($"From Date: {fromDate.ToString("dd/MM/yyyy")}");
                        //        Console.WriteLine($"To Date: {toDate.ToString("dd/MM/yyyy")}");
                        //        uploadedfromdate = fromDate.ToString("dd/MM/yyyy");
                        //        uploadedtodate = toDate.ToString("dd/MM/yyyy");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Invalid date format in the cell.");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Unable to extract dates from the cell.");
                        //}
                        DataSet dsupload = new DataSet();
                        DAL objDal = new DAL();
                        dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_UPLOAD_BANKRECONCILXL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "BANKRECONCIL", cellValue);
                        string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();
                        if (status == "100")
                        {
                            string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                            using (SqlConnection connection = new SqlConnection(ConnectionString.getConnString()))
                            {
                                connection.Open();

                                for (int rowIdx = 5; rowIdx < sheet.Rows.Count - 3; rowIdx++) // Assuming data starts from row 6
                                {
                                    var row = sheet.Rows[rowIdx];

                                    // Access data from columns (adjust column indexes as needed)
                                    // var dateValue = row[0].ToString();
                                    string dateValue = row[0].ToString().Trim();
                                    var transactionValue = row[1].ToString();
                                    var currencyValue = row[2].ToString();
                                    decimal depositValue, withdrawalValue, runbalValue;
                                    if (!decimal.TryParse(row[3].ToString(), out depositValue)) depositValue = 0;
                                    if (!decimal.TryParse(row[4].ToString(), out withdrawalValue)) withdrawalValue = 0;
                                    if (!decimal.TryParse(row[5].ToString(), out runbalValue)) runbalValue = 0;
                                    //var depositValue = row[3].ToString();
                                    //var withdrawalValue = row[4].ToString();
                                    //var runbalValue = row[5].ToString();

                                    // Insert data into SQL Server table
                                    string insertQuery = "INSERT INTO ACC_BANKRECONCIL_UPLOADSTATEMENT_TMP (FK_LOGID, DATE, BTRANSACTION, CURRENCY, DEPOSIT, WITHDRAWAL, RUNNINGBAL, UPLOADEDBY, UPLOADEDDATE) VALUES (@logid, @Date, @Transaction, @Currency, @Deposit, @Withdrawal, @RunningBalance, @UPLOADEDBY, @UPLOADEDDATE)";
                                    SqlCommand command = new SqlCommand(insertQuery, connection);
                                    command.Parameters.AddWithValue("@logid", logid);
                                    command.Parameters.AddWithValue("@Date", dateValue);
                                    command.Parameters.AddWithValue("@Transaction", transactionValue);
                                    command.Parameters.AddWithValue("@Currency", currencyValue);
                                    command.Parameters.AddWithValue("@Deposit", depositValue);
                                    command.Parameters.AddWithValue("@Withdrawal", withdrawalValue);
                                    command.Parameters.AddWithValue("@RunningBalance", runbalValue);
                                    if (int.TryParse(CMPID.Trim('"'), out int parsedCMPID))
                                    {
                                        // Add the parsed CMPID as a parameter
                                        command.Parameters.AddWithValue("@UPLOADEDBY", parsedCMPID);
                                    }
                                    else
                                    {
                                        // Handle the error if parsing fails
                                        Console.WriteLine("Error: Unable to parse CMPID to integer.");
                                    }
                                    //command.Parameters.AddWithValue("@UPLOADEDBY", CMPID);
                                    command.Parameters.AddWithValue("@UPLOADEDDATE", DateTime.Now);
                                    command.ExecuteNonQuery();
                                }
                            }
                            // DAL.ExecuteDataset discovers the proc's parameters from
                            // the DATABASE (GetSpParameterSet) and then throws
                            // "Parameter count does not match Parameter Value count."
                            // unless exactly that many values are supplied. Discovery
                            // includes parameters that have SQL defaults, so the _V2
                            // proc's @LOOKBACKYEARS and @DEBUG must be passed
                            // explicitly -- omitting them does NOT fall back to the
                            // defaults, it throws.
                            dsupdate = SPTAKESV2ARGS
                                ? objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid, 2, 0)
                                : objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid);
                        }

                        else
                        {
                            DataTable dtbl = new DataTable();
                            dtbl.Columns.Add("STATUS", typeof(string));
                            dtbl.Columns.Add("MSG", typeof(string));

                            DataRow drow = dtbl.NewRow();
                            drow["STATUS"] = "104";

                            if (dsupload.Tables.Count > 0 && dsupload.Tables[0].Columns.Contains("STATUSTEXT"))
                            {
                                drow["MSG"] = dsupload.Tables[0].Rows[0]["STATUSTEXT"].ToString();
                            }
                            else
                            {
                                // Handle the case when "STATUSTEXT" column is not found in dsupload.Tables[0]
                                drow["MSG"] = "Status text not available";
                            }

                            dtbl.Rows.Add(drow);

                            if (dsupdate.Tables.Contains("Table"))
                            {
                                dtbl.TableName = "Table"; // Set the table name explicitly
                                dsupdate.Tables.Add(dtbl.Copy());
                            }
                            else
                            {
                                dsupdate.Tables.Add(dtbl); // Add the table without setting its name
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_BankreconcilFile");
            }
            return dsupdate;
        }
        public DataSet UploadBankReconcilFilexlsx(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string OURBANK, string FROMDT, string TODT, string SPNAME = "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT", bool SPTAKESV2ARGS = false)
        {
            DataSet dsupdate = new DataSet();
            string uploadedfromdate = "";
            string uploadedtodate = "";
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                //strFileName = Path.GetFileName(strFileName);
                //string strExtension;
                //strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~"), "DATA", "BankReconcil", strFileName);
                file.SaveAs(strFilePath);

                // if (strExtension.ToLower() == ".xlsx")
                // {
                // Handle XLS file
                using (var stream = File.Open(strFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var sheet = result.Tables[0]; // Assuming data is in the first sheet

                        // Extract the uploaded from date and to date from a specific cell
                        string cellValue = sheet.Rows[2][1].ToString(); // Assuming the cell is at B3
                        string[] dates = cellValue.Split(new string[] { " To " }, StringSplitOptions.RemoveEmptyEntries);
                        //if (dates.Length == 2)
                        //{
                        //    // Assuming the date format is dd/MM/yyyy, parse the dates
                        //    if (DateTime.TryParse(dates[0], out DateTime fromDate) && DateTime.TryParse(dates[1], out DateTime toDate))
                        //    {
                        //        Console.WriteLine($"From Date: {fromDate.ToString("dd/MM/yyyy")}");
                        //        Console.WriteLine($"To Date: {toDate.ToString("dd/MM/yyyy")}");
                        //        uploadedfromdate = fromDate.ToString("dd/MM/yyyy");
                        //        uploadedtodate = toDate.ToString("dd/MM/yyyy");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("Invalid date format in the cell.");
                        //    }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Unable to extract dates from the cell.");
                        //}
                        DataSet dsupload = new DataSet();
                        DAL objDal = new DAL();
                        dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_UPLOAD_BANKRECONCILXL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "BANKRECONCIL", cellValue);
                        string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();
                        if (status == "100")
                        {
                            string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                            using (SqlConnection connection = new SqlConnection(ConnectionString.getConnString()))
                            {
                                connection.Open();

                                for (int rowIdx = 5; rowIdx < sheet.Rows.Count - 3; rowIdx++) // Assuming data starts from row 6
                                {
                                    var row = sheet.Rows[rowIdx];

                                    // Access data from columns (adjust column indexes as needed)
                                    // var dateValue = row[0].ToString();
                                    string dateValue = row[0].ToString().Trim();
                                    var transactionValue = row[1].ToString();
                                    var currencyValue = row[2].ToString();
                                    decimal depositValue, withdrawalValue, runbalValue;
                                    if (!decimal.TryParse(row[3].ToString(), out depositValue)) depositValue = 0;
                                    if (!decimal.TryParse(row[4].ToString(), out withdrawalValue)) withdrawalValue = 0;
                                    if (!decimal.TryParse(row[5].ToString(), out runbalValue)) runbalValue = 0;
                                    //var depositValue = row[3].ToString();
                                    //var withdrawalValue = row[4].ToString();
                                    //var runbalValue = row[5].ToString();

                                    // Insert data into SQL Server table
                                    string insertQuery = "INSERT INTO ACC_BANKRECONCIL_UPLOADSTATEMENT_TMP (FK_LOGID, DATE, BTRANSACTION, CURRENCY, DEPOSIT, WITHDRAWAL, RUNNINGBAL, UPLOADEDBY, UPLOADEDDATE) VALUES (@logid, @Date, @Transaction, @Currency, @Deposit, @Withdrawal, @RunningBalance, @UPLOADEDBY, @UPLOADEDDATE)";
                                    SqlCommand command = new SqlCommand(insertQuery, connection);
                                    command.Parameters.AddWithValue("@logid", logid);
                                    command.Parameters.AddWithValue("@Date", dateValue);
                                    command.Parameters.AddWithValue("@Transaction", transactionValue);
                                    command.Parameters.AddWithValue("@Currency", currencyValue);
                                    command.Parameters.AddWithValue("@Deposit", depositValue);
                                    command.Parameters.AddWithValue("@Withdrawal", withdrawalValue);
                                    command.Parameters.AddWithValue("@RunningBalance", runbalValue);
                                    if (int.TryParse(CMPID.Trim('"'), out int parsedCMPID))
                                    {
                                        // Add the parsed CMPID as a parameter
                                        command.Parameters.AddWithValue("@UPLOADEDBY", parsedCMPID);
                                    }
                                    else
                                    {
                                        // Handle the error if parsing fails
                                        Console.WriteLine("Error: Unable to parse CMPID to integer.");
                                    }
                                    //command.Parameters.AddWithValue("@UPLOADEDBY", CMPID);
                                    command.Parameters.AddWithValue("@UPLOADEDDATE", DateTime.Now);
                                    command.ExecuteNonQuery();
                                }
                            }
                            // DAL.ExecuteDataset discovers the proc's parameters from
                            // the DATABASE (GetSpParameterSet) and then throws
                            // "Parameter count does not match Parameter Value count."
                            // unless exactly that many values are supplied. Discovery
                            // includes parameters that have SQL defaults, so the _V2
                            // proc's @LOOKBACKYEARS and @DEBUG must be passed
                            // explicitly -- omitting them does NOT fall back to the
                            // defaults, it throws.
                            dsupdate = SPTAKESV2ARGS
                                ? objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid, 2, 0)
                                : objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME, OURBANK, FROMDT, TODT, logid);
                        }
                        else
                        {
                            DataTable dtbl = new DataTable();
                            dtbl.Columns.Add("STATUS", typeof(string));
                            dtbl.Columns.Add("MSG", typeof(string));

                            DataRow drow = dtbl.NewRow();
                            drow["STATUS"] = "104";

                            if (dsupload.Tables.Count > 0 && dsupload.Tables[0].Columns.Contains("STATUSTEXT"))
                            {
                                drow["MSG"] = dsupload.Tables[0].Rows[0]["STATUSTEXT"].ToString();
                            }
                            else
                            {
                                // Handle the case when "STATUSTEXT" column is not found in dsupload.Tables[0]
                                drow["MSG"] = "Status text not available";
                            }

                            dtbl.Rows.Add(drow);

                            if (dsupdate.Tables.Contains("Table"))
                            {
                                dtbl.TableName = "Table"; // Set the table name explicitly
                                dsupdate.Tables.Add(dtbl.Copy());
                            }
                            else
                            {
                                dsupdate.Tables.Add(dtbl); // Add the table without setting its name
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_BankreconcilFile");
            }
            return dsupdate;
        }
        /// <summary>Perform MIS REPORT CLIENTJOBPROFIT records.</summary>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="Frmdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="JobNoFrom">Job number.</param>
        /// <param name="JobNoTo">Job number.</param>
        /// <param name="FromVal">From Val parameter.</param>
        /// <param name="ToVal">To Val parameter.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="rpttype">rpttype parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MIS_REPORT_CLIENTJOBPROFIT(string Client, string SearchType, string Frmdt, string Todt, string Mode, string JobNoFrom, string JobNoTo, string FromVal, string ToVal, string CMP_CODE, string CITYCODE1, string CMPID, string rpttype)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {

                {
                    SearchCTA = objRpt.SEARCHCRITERIA("Client:" + Client, " Search Type:" + SearchType, " From:" + FromVal, " To:" + ToVal, " Mode:" + Mode);
                    SqlQueryPARA = objRpt.SQLQUERY_PARA(Client, SearchType, Frmdt, Todt, Mode, (JobNoFrom != null) ? JobNoFrom : "", (JobNoTo != null) ? JobNoTo : "", CITYCODE1, CMP_CODE);
                    if (rpttype == "CLIENT")
                    {
                        PKID = objRpt.REPORT_LOG_BATCH_CLIENTPROFIT("25", SearchCTA, SqlQueryPARA, CMPID, rpttype);
                    }
                    else
                    {
                        PKID = objRpt.REPORT_LOG_BATCH_CLIENTPROFIT("35", SearchCTA, SqlQueryPARA, CMPID, rpttype);
                    }

                }
                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/MIS_REPORT_CLIENTJOBPROFIT");
            }
            return Ok(ds1);
        }
        /// <summary>Perform CLIENT BR GETLIST records.</summary>
        /// <param name="BILLNO">BILLNO parameter.</param>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CLIENT_BR_GETLIST(string BILLNO, string CLIENT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_BR_GETLIST", BILLNO, CLIENT, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CLIENT_BR_GETLIST");
            }
            return Ok(ds);
        }
        /// <summary>Perform BRBP GETBILLAMOUNT records.</summary>
        /// <param name="BILLNO">BILLNO parameter.</param>
        /// <param name="ACC_CODE">ACC CODE parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="BANKDTLSID">BANKDTLSID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBP_GETBILLAMOUNT(string BILLNO, string ACC_CODE, string CMPCODE, string CITYCODE, string BANKDTLSID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBP_GETBILLAMOUNT", BILLNO, ACC_CODE, CMPCODE, CITYCODE, BANKDTLSID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBP_GETBILLAMOUNT");
            }
            return Ok(ds);
        }
        /// <summary>Perform SUPPLIER AS AGENT records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_SUPPLIER_AS_AGENT()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_SUPPLIER_AS_AGENT");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_SUPPLIER_AS_AGENT");
            }
            return Ok(ds);
        }
        /// <summary>Perform bankreconcillation exporttoxl records.</summary>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage acc_bankreconcillation_exporttoxl(string OURBANK, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_acc_bankreconcillation_list.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BANKRECONCIL_GETUPLOADDATA", (OURBANK != null) ? OURBANK : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Accounts", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "reconcilledlist_" + FROMDATE + "_" + TODATE + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform BANKRECONCILLATION UPLOAD GETDATA records.</summary>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BANKRECONCILLATION_UPLOAD_GETDATA(string OURBANK, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BANKRECONCIL_GETUPLOADDATA", (OURBANK != null) ? OURBANK : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BANKRECONCILLATION_UPLOAD_GETDATA");
            }
            return Ok(ds);
        }
        public string GenerateCreditNoteJson(DataSet ds)
        {

            DAL objDal = new DAL();
            var r = new EInvoice();
            String crtno = "";
            String dataString1 = "";
            String dataString = "";
            string strPath = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                crtno = row["CRTNO"].ToString();
                DataView dvtrans = new DataView(ds.Tables[1]);
                DataView dvdoc = new DataView(ds.Tables[2]);
                DataView dvSeller = new DataView(ds.Tables[3]);
                DataView dvBuyer = new DataView(ds.Tables[4]);
                DataView dvValue = new DataView(ds.Tables[5]);
                DataView dvItem = new DataView(ds.Tables[6]);
                dvtrans.RowFilter = "CRTNO = " + crtno;
                dvdoc.RowFilter = "CRTNO = " + crtno;
                dvSeller.RowFilter = "CRTNO = " + crtno;
                dvBuyer.RowFilter = "CRTNO = " + crtno;
                dvValue.RowFilter = "CRTNO = " + crtno;
                dvItem.RowFilter = "CRTNO = " + crtno;
                DataTable DtTrans;
                DtTrans = dvtrans.ToTable();
                DtTrans.Columns.Remove("CRTNO");

                DataTable DtDoc;
                DtDoc = dvdoc.ToTable();
                DtDoc.Columns.Remove("CRTNO");

                DataTable DtSeller;
                DtSeller = dvSeller.ToTable();
                DtSeller.Columns.Remove("CRTNO");

                DataTable DtBuyer;
                DtBuyer = dvBuyer.ToTable();
                DtBuyer.Columns.Remove("CRTNO");

                DataTable DtValue;
                DtValue = dvValue.ToTable();
                DtValue.Columns.Remove("CRTNO");

                DataTable DtItem;
                DtItem = dvItem.ToTable();
                DtItem.Columns.Remove("CRTNO");

                //object info = GenericMapper.GetItem(ds.Tables[0]);
                object Transinfo = GenericMapper.GetItem(DtTrans);
                object Docinfo = GenericMapper.GetItem(DtDoc);
                object Sellerinfo = GenericMapper.GetItem(DtSeller);
                object Buyerinfo = GenericMapper.GetItem(DtBuyer);
                object Valinfo = GenericMapper.GetItem(DtValue);
                object Iteminfo = GenericMapper.GetItem(DtItem);
               
                object regRevObject = ExtractObject.GetValFromObj(Transinfo, "RegRev");
                string regRevValue = RemoveQuotesAndNull(Convert.ToString(regRevObject));

                object ecmGstinObject = ExtractObject.GetValFromObj(Transinfo, "EcmGstin");
                string ecmGstinValue = RemoveQuotesAndNull(Convert.ToString(ecmGstinObject));

                r.TranDtls = new tranDtls
                {
                    TaxSch = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "TaxSch")),
                    SupTyp = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "SupTyp")),
                    IgstOnIntra = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "IgstOnIntra")),
                    RegRev = regRevValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "RegRev"))),
                    EcmGstin = ecmGstinValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "EcmGstin"))),

                    //RegRev = regRevValue ?? (string)null, // Assign null explicitly to string property
                    //EcmGstin = ecmGstinValue ?? (string)null 

                };
                r.DocDtls = new docDtls
                {
                    Typ = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Typ")),
                    No = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "No")),
                    Dt = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Dt")),
                };
                //  string pinValue = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Pin"));
                r.SellerDtls = new sellerDtls
                {
                    Gstin = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Gstin")),
                    LglNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "LglNm")),
                    TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "TrdNm")),
                    Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr1")),
                    Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr2")),
                    Loc = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Loc")),
                    //Pin = pinValue != null ? pinValue.Trim('"') : null,
                    Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Sellerinfo, "Pin")),
                    // Pin = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Pin")),
                    Stcd = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Stcd")),


                };
                //  string pinValuebuyer = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Pin"));
                r.BuyerDtls = new buyerDtls
                {
                    Gstin = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Gstin")),
                    LglNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "LglNm")),
                    TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "TrdNm")),
                    Pos = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Pos")),
                    Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr1")),
                    Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr2")),
                    Loc = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Loc")),
                    Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Buyerinfo, "Pin")),
                    Stcd = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Stcd")),


                };
                r.Valdtls = new valDtls
                {

                    AssVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "AssVal")),
                    IgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "IgstVal")),
                    CgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "CgstVal")),
                    SgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "SgstVal")),
                    CesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal")),
                    StCesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal")),
                    Discount = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount")),
                    OthChrg = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg")),
                    RndOffAmt = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "RndOffAmt")),
                    TotInvVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "TotInvVal"))

                };
                r.ItemList = GetItemDtls(DtItem);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    dataString = JsonConvert.SerializeObject(r);
                }
                else
                {

                    dataString1 = JsonConvert.SerializeObject(r);
                    if (dataString == "")
                    {
                        dataString = dataString1;
                    }
                    else
                    {
                        dataString = dataString + "," + dataString1;
                    }
                }
                Console.WriteLine(dataString1);
            }
            // dataString = "[" + dataString + "]";
            string output = "";
            output = "[" + dataString + "]";
            System.IO.StreamWriter oWrite;
            strPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\EInvoice\ECNJson\" + ds.Tables[7].Rows[0]["FileNameT"];
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            oWrite = File.CreateText(strPath);
            oWrite.WriteLine(output);
            oWrite.Close();
            return dataString;
            // Console.WriteLine(dataString1);
        }
        /// <summary>Perform ECREDITNOTEGETDATA FORJSON records.</summary>
        /// <param name="CRTNO">CRTNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ECREDITNOTEGETDATA_FORJSON(string CRTNO, string CMPCODE, string CITYCODE, string CMPID, string MAKERIP, string FINSTARTDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            var r = new EInvoice();
            try
            {
             ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_ECREDITNOTE_JSON_GENERATE", CRTNO, CMPCODE, CITYCODE, CMPID, MAKERIP, FINSTARTDT);
                GenerateCreditNoteJson(ds);
            }

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ECREDITNOTEGETDATA_FORJSON");
            }
            return Ok(ds);

        }
        /// <summary>Retrieve list of ECreditNote records.</summary>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ECreditNote_List(string FINSTARTDT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_ECREDITNOTE_GETDATA", FINSTARTDT, CMPCODE, CITYCODE);
             }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ECreditNote_List");
            }
            return Ok(ds);
        }
        //public DataSet fN_upload_BankreconcilExcelFile(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string OURBANK, string FROMDT, string TODT)
        //{

        //    DataSet gstDS1 = new DataSet();
        //    DataSet gstResust = new DataSet();
        //    DataSet dsupdate = new DataSet();
        //    string uploadedfromdate = "";
        //    string uploadedtodate = "";
        //    var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
        //    try
        //    {
        //        strFileName = Path.GetFileName(strFileName);
        //        string strExtension;
        //        strExtension = Path.GetExtension(strFileName);
        //        string strFilePath;
        //        strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\BankReconcil\\" + strFileName);
        //        file.SaveAs(strFilePath);
        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //        using (var package = new ExcelPackage(new System.IO.FileInfo(strFilePath)))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Access the first worksheet (index 0)

        //            // Get the value from cell B3
        //            string cellValue = worksheet.Cells["B3"].Text;

        //            // Split the cell value by "To" to get the from date and to date
        //            string[] dates = cellValue.Split(new string[] { " To " }, StringSplitOptions.RemoveEmptyEntries);

        //            DateTime fromDate; // Declare fromDate outside the if block
        //            DateTime toDate; // Declare toDate outside the if block

        //            if (dates.Length == 2)
        //            {
        //                // Assuming the date format is dd/MM/yyyy, parse the dates
        //                if (DateTime.TryParse(dates[0], out fromDate) && DateTime.TryParse(dates[1], out toDate))
        //                {
        //                    //Console.WriteLine($"From Date: {fromDate.ToString("dd/MM/yyyy")}");
        //                    //Console.WriteLine($"To Date: {toDate.ToString("dd/MM/yyyy")}");
        //                    uploadedfromdate = fromDate.ToString("dd/MM/yyyy");
        //                    uploadedtodate = toDate.ToString("dd/MM/yyyy");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid date format in the cell.");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Unable to extract dates from the cell.");
        //            }
        //        }


        //        DataSet dsupload = new DataSet();
        //        DAL objDal = new DAL();
        //        dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_UPLOAD_BANKRECONCILXL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "BANKRECONCIL", uploadedfromdate, uploadedtodate);

        //        string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();
        //        if (status == "100")
        //        {

        //            string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
        //            DataSet DS = new DataSet();
        //            DataSet MP_DS = new DataSet();
        //            OleDbDataAdapter Adapter = new OleDbDataAdapter();
        //            OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=No\"; ");

        //            // string filePath = "YourExcelFile.xlsx";
        //            // ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //            // Load the Excel file using EPPlus
        //            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //            using (ExcelPackage package = new ExcelPackage(new FileInfo(strFilePath)))
        //            {
        //                // Get the first worksheet in the Excel file
        //                // ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //                int worksheetCount = package.Workbook.Worksheets.Count;
        //                try
        //                {
        //                    if (package.Workbook.Worksheets.Count > 0)
        //                    {
        //                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Accessing the first worksheet
        //                        int startRow = 6;
        //                        int rowCount = worksheet.Dimension.Rows;
        //                        string connectionString = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
        //                        using (SqlConnection connection = new SqlConnection(connectionString))
        //                        {
        //                            connection.Open();
        //                            for (int row = startRow; row <= rowCount; row++)
        //                            {
        //                                // Access data from columns (adjust column indexes as needed)
        //                                var cellValue = worksheet.Cells[row, 1].Value;
        //                                string dateValue = cellValue != null ? cellValue.ToString() : string.Empty; // Assuming Date is in column 1



        //                                cellValue = worksheet.Cells[row, 2].Value;
        //                                string transactionValue = cellValue != null ? cellValue.ToString() : string.Empty; // Assuming Transaction is in column 2

        //                                cellValue = worksheet.Cells[row, 3].Value;
        //                                string currencyValue = cellValue != null ? cellValue.ToString() : string.Empty; // Assuming Currency is in column 3

        //                                if (string.IsNullOrWhiteSpace(currencyValue))
        //                                {
        //                                    continue;
        //                                }

        //                                cellValue = worksheet.Cells[row, 4].Value;
        //                                string depositValue = string.Empty;
        //                                decimal depositDecimal = 0;
        //                                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
        //                                {
        //                                    if (decimal.TryParse(cellValue.ToString(), out depositDecimal))
        //                                    {
        //                                        // Conversion successful, assign the decimal value
        //                                        depositValue = depositDecimal.ToString(); // or depositDecimal.ToString(CultureInfo.InvariantCulture); for invariant culture
        //                                    }
        //                                    else
        //                                    {
        //                                        // Conversion failed, handle the error or set a default value
        //                                        // For example:
        //                                        depositValue = string.Empty;  // Set a default value
        //                                        // Log or handle the conversion error
        //                                    }
        //                                }




        //                                cellValue = worksheet.Cells[row, 5].Value;
        //                                string withdrawalValue = string.Empty;
        //                                decimal withdrawalDecimal = 0;
        //                                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
        //                                {
        //                                    if (decimal.TryParse(cellValue.ToString(), out withdrawalDecimal))
        //                                    {
        //                                        // Conversion successful, assign the decimal value
        //                                        withdrawalValue = withdrawalDecimal.ToString(); // or depositDecimal.ToString(CultureInfo.InvariantCulture); for invariant culture
        //                                    }
        //                                    else
        //                                    {
        //                                        // Conversion failed, handle the error or set a default value
        //                                        // For example:
        //                                        withdrawalValue = string.Empty;  // Set a default value
        //                                        // Log or handle the conversion error
        //                                    }
        //                                }
        //                                cellValue = worksheet.Cells[row, 6].Value;
        //                                string runbalValue = string.Empty;
        //                                decimal runbalDecimal = 0;

        //                                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
        //                                {
        //                                    if (decimal.TryParse(cellValue.ToString(), out runbalDecimal))
        //                                    {
        //                                        // Conversion successful, assign the decimal value
        //                                        runbalValue = runbalDecimal.ToString(); // or depositDecimal.ToString(CultureInfo.InvariantCulture); for invariant culture
        //                                    }
        //                                    else
        //                                    {
        //                                        // Conversion failed, handle the error or set a default value
        //                                        // For example:
        //                                        runbalValue = string.Empty;  // Set a default value
        //                                        // Log or handle the conversion error
        //                                    }
        //                                }

        //                                // Insert data into SQL Server table
        //                                string insertQuery = "INSERT INTO ACC_BANKRECONCIL_UPLOADSTATEMENT_TMP (FK_LOGID,DATE, BTRANSACTION, CURRENCY,DEPOSIT,WITHDRAWAL,RUNNINGBAL,UPLOADEDBY,UPLOADEDDATE) VALUES (@logid,@Date, @Transaction, @Currency,@Deposit,@Withdrawal,@RunningBalance,@UPLOADEDBY,@UPLOADEDDATE)";
        //                                SqlCommand command = new SqlCommand(insertQuery, connection);
        //                                command.Parameters.AddWithValue("@logid", logid);
        //                                command.Parameters.AddWithValue("@Date", dateValue.Trim());
        //                                command.Parameters.AddWithValue("@Transaction", transactionValue);
        //                                command.Parameters.AddWithValue("@Currency", currencyValue);
        //                                if (!string.IsNullOrWhiteSpace(depositValue))
        //                                {
        //                                    // Use depositValue if it's not empty
        //                                    command.Parameters.AddWithValue("@Deposit", depositValue);
        //                                }
        //                                else
        //                                {
        //                                    // Use depositDecimal if depositValue is empty
        //                                    command.Parameters.AddWithValue("@Deposit", depositDecimal);
        //                                }
        //                                if (!string.IsNullOrWhiteSpace(withdrawalValue))
        //                                {
        //                                    // Use withdrawalValue if it's not empty
        //                                    command.Parameters.AddWithValue("@Withdrawal", withdrawalValue);
        //                                }
        //                                else
        //                                {
        //                                    // Use withdrawalDecimal if withdrawalValue is empty
        //                                    command.Parameters.AddWithValue("@Withdrawal", withdrawalDecimal);
        //                                }
        //                                if (!string.IsNullOrWhiteSpace(runbalValue))
        //                                {
        //                                    // Use depositValue if it's not empty
        //                                    command.Parameters.AddWithValue("@RunningBalance", runbalValue);
        //                                }
        //                                else
        //                                {
        //                                    // Use depositDecimal if depositValue is empty
        //                                    command.Parameters.AddWithValue("@RunningBalance", runbalDecimal);
        //                                }
        //                                command.Parameters.AddWithValue("@UPLOADEDBY", CMPID);
        //                                command.Parameters.AddWithValue("@UPLOADEDDATE", DateTime.Now);
        //                                command.ExecuteNonQuery();
        //                            }
        //                        }
        //                        // Use the 'worksheet' object as needed
        //                    }
        //                    else
        //                    {
        //                        // Handle case when there are no worksheets in the workbook
        //                        Console.WriteLine("No worksheets found in the workbook.");
        //                    }

        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine("Error accessing worksheet: " + ex.Message);
        //                }
        //                // Start reading from the 6th row (index 5)



        //            }
        //            dsupdate = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT", OURBANK, FROMDT, TODT, logid);
        //        }
        //        else
        //        {
        //            DataTable dtbl = new DataTable();
        //            // DataRow drow = new DataRow;
        //            DataRow drow = dtbl.NewRow();
        //            dtbl.Columns.Add("STATUS", typeof(string));
        //            dtbl.Columns.Add("MSG", typeof(string));
        //            drow = dtbl.NewRow();
        //            drow[0] = "104";
        //            drow[1] = dsupload.Tables[0].Rows[0]["STATUSTEXT"].ToString();
        //            dtbl.Rows.Add(drow);
        //            dsupdate.Merge(dtbl);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/fN_upload_BankreconcilExcelFile");
        //    }
        //    return dsupdate;

        //}
        //[HttpPost]
        //public IHttpActionResult UploadBnkReconcilFile()
        //{
        //    //HttpResponseMessage response = null;
        //    DataSet ds = new DataSet();
        //    DataSet ds1 = new DataSet();
        //    DataTable dtbl = new DataTable();
        //    // DataRow drow = new DataRow;
        //    DataRow drow = dtbl.NewRow();
        //    var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
        //    var cmpid = HttpContext.Current.Request.Params["cmpid"];
        //    var vguid = HttpContext.Current.Request.Params["vguid"];
        //    var makerip = HttpContext.Current.Request.Params["makerip"];
        //    var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
        //    var citycode = HttpContext.Current.Request.Params["citycode"];
        //    var citycode1 = HttpContext.Current.Request.Params["citycode1"];
        //    var ourbank = HttpContext.Current.Request.Params["ourbank"];
        //    var fromdt = HttpContext.Current.Request.Params["fromdt"];
        //    var todt = HttpContext.Current.Request.Params["todt"];
        //    try
        //    {
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            string fileName = Path.GetFileName(file.FileName);
        //            var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\BankReconcil\\", fileName);

        //            if (File.Exists(filePath) == true)
        //            {
        //                dtbl.Columns.Add("STATUS", typeof(string));
        //                dtbl.Columns.Add("MSG", typeof(string));
        //                drow = dtbl.NewRow();
        //                drow[0] = "104";
        //                drow[1] = fileName + " already exists";
        //                dtbl.Rows.Add(drow);
        //                ds1.Merge(dtbl);
        //            }
        //            else
        //            {


        //                file.SaveAs(filePath);
        //                ds1 = fN_upload_BankreconcilExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, ourbank, fromdt, todt);
        //                dtbl.Columns.Add("STATUS", typeof(string));
        //                dtbl.Columns.Add("MSG", typeof(string));
        //                drow = dtbl.NewRow();
        //                drow[0] = "100";
        //                drow[1] = fileName + " uploaded successfully";
        //                // drow[0] = fileName + " uploaded successfully";
        //                dtbl.Rows.Add(drow);
        //                ds1.Merge(dtbl);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/UploadBnkReconcilFile");
        //    }
        //    return Ok(ds1);

        //}
        /// <summary>UploadBnkReconcilFileold operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]

        public IHttpActionResult UploadBnkReconcilFileold()
        {
            //HttpResponseMessage response = null;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\BankReconcil\\", fileName);

                    if (File.Exists(filePath) == true)
                    {
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("MSG", typeof(string));
                        drow = dtbl.NewRow();
                        drow[0] = "104";
                        drow[1] = fileName + " already exists";
                        dtbl.Rows.Add(drow);
                        ds1.Merge(dtbl);
                    }
                    else
                    {


                        file.SaveAs(filePath);
                        //fN_upload_BankreconcilExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1);
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("MSG", typeof(string));
                        drow = dtbl.NewRow();
                        drow[0] = "100";
                        drow[1] = fileName + " uploaded successfully";
                        // drow[0] = fileName + " uploaded successfully";
                        dtbl.Rows.Add(drow);
                        ds1.Merge(dtbl);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/UploadBnkReconcilFile");
            }
            return Ok(ds1);

        }
        [Route("api/Accounts/DownloadAttachment")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage DownloadAttachment(string fileName, string FileType)
        {
            //below code locate physical file on server 
            //var localFilePath = HttpContext.Current.Server.MapPath("../../uploadFiles/" + fileName);
            var localFilePath = "";
            if (FileType == "invoice")
            {
                localFilePath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\EInvoice\EInvoiceJson\" + fileName;
            }
            else
            {
                localFilePath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\EInvoice\ECNJson\" + fileName;
            }
            HttpResponseMessage response = null;
            if (!File.Exists(localFilePath))
            {
                //if file not found than return response as resource not present 
                response = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                //if file present than read file 
                var fStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read);

                //compose response and include file as content in it
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    // Content = new StreamContent(fStream)
                    Content = new StreamContent(fStream)
                };

                //set content header of reponse as file attached in reponse
                response.Content.Headers.ContentDisposition =
                new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(fStream.Name)
                };
                //set the content header content type as application/octet-stream as it      
                //returning file as reponse 
                response.Content.Headers.ContentType = new
                              MediaTypeHeaderValue("application/octet-stream");


                response.Content.Headers.ContentLength = fStream.Length;
                response.Headers.Add("fileName", fileName);

            }
            return response;
        }
        /// <summary>Retrieve list of EInvoice records.</summary>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_EInvoice_List(string FINSTARTDT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_GETDATA", FINSTARTDT, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_EInvoice_List");
            }
            return Ok(ds);
        }
        /// <summary>Perform EInvoice ResetJsonList records.</summary>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_EInvoice_ResetJsonList(string FINSTARTDT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_RESET_JSONDATA", FINSTARTDT, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_EInvoice_ResetJsonList");
            }
            return Ok(ds);
        }
        /// <summary>Perform EINVOICERESETDATA FORJSON records.</summary>
        /// <param name="JSONFILEID">JSONFILEID parameter.</param>
        /// <param name="INVOICEID">INVOICEID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_EINVOICERESETDATA_FORJSON(string JSONFILEID, string INVOICEID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_RESETJSON_UPDATEGSTIRN_NG", JSONFILEID, INVOICEID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_EINVOICERESETDATA_FORJSON");
            }
            return Ok(ds);
        }

        /// <summary>Perform EINVOICEGETDATA FORJSON records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <param name="FINSTARTDT">Start date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_EINVOICEGETDATA_FORJSON(string INVNO, string CMPCODE, string CITYCODE, string CMPID, string MAKERIP, string FINSTARTDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            var r = new EInvoice();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_JSON_GENERATE", INVNO, CMPCODE, CITYCODE, CMPID, MAKERIP, FINSTARTDT);
                GenerateJson(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_EINVOICEGETDATA_FORJSON");
            }
            return Ok(ds);
        }
        string RemoveQuotesAndNull(string value)
        {
            if (value != null)
            {
                value = value.Trim(); // Remove leading and trailing whitespaces

                if (value == "null")
                {
                    return null;
                }
                else if (value.StartsWith("\"") && value.EndsWith("\""))
                {
                    return value.Substring(1, value.Length - 2);
                }
            }
            return value; // Return value as is if null, doesn't have quotes, or is not trimmed
        }
        public static double SafeConvertToDouble(object value, int decimals = 2)
        {
            double result;

            if (double.TryParse(Convert.ToString(value), out result))
            {
                if (result == 0) return 0; // Explicitly return 0 as an integer.
                return Math.Round(result, decimals);
            }

            return 0; // Default for invalid or null values.
        }
        public string GenerateJson(DataSet ds)
        {

            DAL objDal = new DAL();
            var r = new EInvoice();
            String invoiceno = "";
            String dataString1 = "";
            String dataString = "";
            string strPath = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                invoiceno = row["InvoiceNo"].ToString();
                DataView dvtrans = new DataView(ds.Tables[1]);
                DataView dvdoc = new DataView(ds.Tables[2]);
                DataView dvSeller = new DataView(ds.Tables[3]);
                DataView dvBuyer = new DataView(ds.Tables[4]);
                DataView dvValue = new DataView(ds.Tables[5]);
                DataView dvItem = new DataView(ds.Tables[6]);
                dvtrans.RowFilter = "InvoiceNo = " + invoiceno;
                dvdoc.RowFilter = "InvoiceNo = " + invoiceno;
                dvSeller.RowFilter = "InvoiceNo = " + invoiceno;
                dvBuyer.RowFilter = "InvoiceNo = " + invoiceno;
                dvValue.RowFilter = "InvoiceNo = " + invoiceno;
                dvItem.RowFilter = "InvoiceNo = " + invoiceno;
                DataTable DtTrans;
                DtTrans = dvtrans.ToTable();
                DtTrans.Columns.Remove("InvoiceNo");

                DataTable DtDoc;
                DtDoc = dvdoc.ToTable();
                DtDoc.Columns.Remove("InvoiceNo");

                DataTable DtSeller;
                DtSeller = dvSeller.ToTable();
                DtSeller.Columns.Remove("InvoiceNo");

                DataTable DtBuyer;
                DtBuyer = dvBuyer.ToTable();
                DtBuyer.Columns.Remove("InvoiceNo");

                DataTable DtValue;
                DtValue = dvValue.ToTable();
                DtValue.Columns.Remove("InvoiceNo");

                DataTable DtItem;
                DtItem = dvItem.ToTable();
                DtItem.Columns.Remove("InvoiceNo");

                //object info = GenericMapper.GetItem(ds.Tables[0]);
                object Transinfo = GenericMapper.GetItem(DtTrans);
                object Docinfo = GenericMapper.GetItem(DtDoc);
                object Sellerinfo = GenericMapper.GetItem(DtSeller);
                object Buyerinfo = GenericMapper.GetItem(DtBuyer);
                object Valinfo = GenericMapper.GetItem(DtValue);
                object Iteminfo = GenericMapper.GetItem(DtItem);
                //EInvoice data = new EInvoice();
                // public string invoiceno;
                //var r = new EInvoice();
                object regRevObject = ExtractObject.GetValFromObj(Transinfo, "RegRev");
                string regRevValue = RemoveQuotesAndNull(Convert.ToString(regRevObject));

                object ecmGstinObject = ExtractObject.GetValFromObj(Transinfo, "EcmGstin");
                string ecmGstinValue = RemoveQuotesAndNull(Convert.ToString(ecmGstinObject));

                r.TranDtls = new tranDtls
                {
                    TaxSch = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "TaxSch")),
                    SupTyp = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "SupTyp")),
                    IgstOnIntra = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "IgstOnIntra")),
                    RegRev = regRevValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "RegRev"))),
                    EcmGstin = ecmGstinValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "EcmGstin"))),
                    //RegRev = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "RegRev")),
                    //EcmGstin = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "EcmGstin")),

                };
                r.DocDtls = new docDtls
                {
                    Typ = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Typ")),
                    No = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "No")),
                    Dt = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Dt")),
                };
                r.SellerDtls = new sellerDtls
                {
                    Gstin = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Gstin")),
                    LglNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "LglNm")),
                    TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "TrdNm")),
                    Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr1")),
                    Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr2")),
                    Loc = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Loc")),
                    Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Sellerinfo, "Pin")),
                    Stcd = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Stcd")),
                };
                r.BuyerDtls = new buyerDtls
                {
                    Gstin = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Gstin")),
                    LglNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "LglNm")),
                    TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "TrdNm")),
                    Pos = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Pos")),
                    Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr1")),
                    Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr2")),
                    Loc = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Loc")),
                    Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Buyerinfo, "Pin")),
                    Stcd = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Stcd")),

                };
                r.Valdtls = new valDtls
                {
                    AssVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "AssVal")),
                    IgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "IgstVal")),
                    CgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "CgstVal")),
                    SgstVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "SgstVal")),
                    CesVal = Convert.ToInt32(ExtractObject.GetValFromObj(Valinfo, "CesVal")),

                    ////CesVal = SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal"),0),old one 
                    // //StCesVal = SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal"),0),
                    //  //Discount = SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount"),0),
                    //   //OthChrg = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg")),
                   // CesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal")) == 0 ? 0 : SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal"), 0),
                    StCesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal")) == 0 ? 0 : SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal"), 0),
                    Discount = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount")) == 0 ? 0 : SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount"), 0),
                    OthChrg = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg")) == 0 ? 0 : SafeConvertToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg"), 0),
                    RndOffAmt = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "RndOffAmt")),
                    TotInvVal = Convert.ToDecimal(ExtractObject.GetValFromObj(Valinfo, "TotInvVal"))
                };
                //r.Valdtls = new valDtls
                //{

                //    AssVal = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "AssVal")),2),
                //    IgstVal = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "IgstVal")),2),
                //    CgstVal = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CgstVal")),2),
                //    SgstVal = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "SgstVal")),2),
                //    CesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal")),
                //    StCesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal")),
                //    Discount = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount")),
                //    OthChrg = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg")),
                //    RndOffAmt = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "RndOffAmt")), 2),
                //    TotInvVal = Math.Round(Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "TotInvVal")), 2)

                //};
                r.ItemList = GetItemDtls(DtItem);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //dataString = JsonConvert.SerializeObject(r);
                    dataString = JsonConvert.SerializeObject(r, Newtonsoft.Json.Formatting.Indented);
                    //string jsonResult = JsonConvert.SerializeObject(einvoice, Newtonsoft.Json.Formatting.Indented);
                    //string finalJson = $"[{jsonResult}]";
                    //return finalJson;
                }
                else
                {

                    dataString1 = JsonConvert.SerializeObject(r, Newtonsoft.Json.Formatting.Indented); //JsonConvert.SerializeObject(r);
                    if (dataString == "")
                    {
                        dataString = dataString1;
                    }
                    else
                    {
                        // dataString = dataString + "," + dataString1;
                        dataString += $",\n{dataString1}";
                    }


                }
                Console.WriteLine(dataString1);
            }


            // dataString = "[" + dataString + "]";
            string output = "";
            output = $"[\n{dataString}\n]";//"[" + dataString + "]";
            System.IO.StreamWriter oWrite;
            strPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\EInvoice\EInvoiceJson\" + ds.Tables[7].Rows[0]["FileNameT"];
            if (File.Exists(strPath))
            {
                File.Delete(strPath);
            }
            oWrite = File.CreateText(strPath);
            oWrite.WriteLine(output);
            oWrite.Close();
            return dataString;
            // Console.WriteLine(dataString1);
        }
        //public string GenerateJson_bkup20241224(DataSet ds)
        //{

        //    DAL objDal = new DAL();
        //    var r = new EInvoice();
        //    String invoiceno = "";
        //    String dataString1 = "";
        //    String dataString = "";
        //    string strPath = "";
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        invoiceno = row["InvoiceNo"].ToString();
        //        DataView dvtrans = new DataView(ds.Tables[1]);
        //        DataView dvdoc = new DataView(ds.Tables[2]);
        //        DataView dvSeller = new DataView(ds.Tables[3]);
        //        DataView dvBuyer = new DataView(ds.Tables[4]);
        //        DataView dvValue = new DataView(ds.Tables[5]);
        //        DataView dvItem = new DataView(ds.Tables[6]);
        //        dvtrans.RowFilter = "InvoiceNo = " + invoiceno;
        //        dvdoc.RowFilter = "InvoiceNo = " + invoiceno;
        //        dvSeller.RowFilter = "InvoiceNo = " + invoiceno;
        //        dvBuyer.RowFilter = "InvoiceNo = " + invoiceno;
        //        dvValue.RowFilter = "InvoiceNo = " + invoiceno;
        //        dvItem.RowFilter = "InvoiceNo = " + invoiceno;
        //        DataTable DtTrans;
        //        DtTrans = dvtrans.ToTable();
        //        DtTrans.Columns.Remove("InvoiceNo");

        //        DataTable DtDoc;
        //        DtDoc = dvdoc.ToTable();
        //        DtDoc.Columns.Remove("InvoiceNo");

        //        DataTable DtSeller;
        //        DtSeller = dvSeller.ToTable();
        //        DtSeller.Columns.Remove("InvoiceNo");

        //        DataTable DtBuyer;
        //        DtBuyer = dvBuyer.ToTable();
        //        DtBuyer.Columns.Remove("InvoiceNo");

        //        DataTable DtValue;
        //        DtValue = dvValue.ToTable();
        //        DtValue.Columns.Remove("InvoiceNo");

        //        DataTable DtItem;
        //        DtItem = dvItem.ToTable();
        //        DtItem.Columns.Remove("InvoiceNo");

        //        //object info = GenericMapper.GetItem(ds.Tables[0]);
        //        object Transinfo = GenericMapper.GetItem(DtTrans);
        //        object Docinfo = GenericMapper.GetItem(DtDoc);
        //        object Sellerinfo = GenericMapper.GetItem(DtSeller);
        //        object Buyerinfo = GenericMapper.GetItem(DtBuyer);
        //        object Valinfo = GenericMapper.GetItem(DtValue);
        //        object Iteminfo = GenericMapper.GetItem(DtItem);
              
        //        object regRevObject = ExtractObject.GetValFromObj(Transinfo, "RegRev");
        //        string regRevValue = RemoveQuotesAndNull(Convert.ToString(regRevObject));

        //        object ecmGstinObject = ExtractObject.GetValFromObj(Transinfo, "EcmGstin");
        //        string ecmGstinValue = RemoveQuotesAndNull(Convert.ToString(ecmGstinObject));

        //        r.TranDtls = new tranDtls
        //        {
        //            TaxSch = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "TaxSch")),
        //            SupTyp = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "SupTyp")),
        //            IgstOnIntra = Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "IgstOnIntra")),
        //            RegRev = regRevValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "RegRev"))),
        //            EcmGstin = ecmGstinValue,//RemoveQuotes(Convert.ToString(ExtractObject.GetValFromObj(Transinfo, "EcmGstin"))),
                 

        //        };
        //        r.DocDtls = new docDtls
        //        {
        //            Typ = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Typ")),
        //            No = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "No")),
        //            Dt = Convert.ToString(ExtractObject.GetValFromObj(Docinfo, "Dt")),
        //        };
        //        r.SellerDtls = new sellerDtls
        //        {
        //            Gstin = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Gstin")),
        //            LglNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "LglNm")),
        //            TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "TrdNm")),
        //            Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr1")),
        //            Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Addr2")),
        //            Loc = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Loc")),
        //            Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Sellerinfo, "Pin")),
        //            Stcd = Convert.ToString(ExtractObject.GetValFromObj(Sellerinfo, "Stcd")),
        //        };
        //        r.BuyerDtls = new buyerDtls
        //        {
        //            Gstin = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Gstin")),
        //            LglNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "LglNm")),
        //            TrdNm = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "TrdNm")),
        //            Pos = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Pos")),
        //            Addr1 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr1")),
        //            Addr2 = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Addr2")),
        //            Loc = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Loc")),
        //            Pin = Convert.ToInt32(ExtractObject.GetValFromObj(Buyerinfo, "Pin")),
        //            Stcd = Convert.ToString(ExtractObject.GetValFromObj(Buyerinfo, "Stcd")),

        //        };
        //        r.ValDtls = new valDtls
        //        {
        //            AssVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "AssVal")),
        //            IgstVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "IgstVal")),
        //            CgstVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CgstVal")),
        //            SgstVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "SgstVal")),
        //            CesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "CesVal")),
        //            StCesVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "StCesVal")),
        //            Discount = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "Discount")),
        //            OthChrg = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "OthChrg")),
        //            RndOffAmt = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "RndOffAmt")),
        //            TotInvVal = Convert.ToDouble(ExtractObject.GetValFromObj(Valinfo, "TotInvVal"))

        //        };
        //        r.ItemList = GetItemDtls(DtItem);
        //        if (ds.Tables[0].Rows.Count == 1)
        //        {
        //            dataString = JsonConvert.SerializeObject(r);
        //        }
        //        else
        //        {

        //            dataString1 = JsonConvert.SerializeObject(r);
        //            if (dataString == "")
        //            {
        //                dataString = dataString1;
        //            }
        //            else
        //            {
        //                dataString = dataString + "," + dataString1;
        //            }


        //        }
        //        Console.WriteLine(dataString1);
        //    }
            
        //    string output = "";
        //    output = "[" + dataString + "]";
        //    System.IO.StreamWriter oWrite;
        //    strPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\EInvoice\EInvoiceJson\" + ds.Tables[7].Rows[0]["FileNameT"];
        //    if (File.Exists(strPath))
        //    {
        //        File.Delete(strPath);
        //    }
        //    oWrite = File.CreateText(strPath);
        //    oWrite.WriteLine(output);
        //    oWrite.Close();
        //    return dataString;
         
        //}
        public static List<itemlist> GetItemDtls(DataTable dt)
        {
            List<itemlist> Item = new List<itemlist>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item.Add(new itemlist
                {
                    SlNo = Convert.ToString(dt.Rows[i]["SlNo"]),
                    PrdDesc = Convert.ToString(dt.Rows[i]["PrdDesc"]),
                    IsServc = Convert.ToString(dt.Rows[i]["IsServc"]),
                    HsnCd = Convert.ToString(dt.Rows[i]["HsnCd"]),
                    Qty = Convert.ToDouble(dt.Rows[i]["Qty"]),
                    UnitPrice = Convert.ToDouble(dt.Rows[i]["UnitPrice"]),
                    TotAmt = Convert.ToDouble(dt.Rows[i]["TotAmt"]),
                    Discount = Convert.ToDouble(dt.Rows[i]["Discount"]),
                    PreTaxVal = Convert.ToDouble(dt.Rows[i]["PreTaxVal"]),
                    AssAmt = Convert.ToDouble(dt.Rows[i]["AssAmt"]),
                    GstRt = Convert.ToDouble(dt.Rows[i]["GstRt"]),
                    IgstAmt = Convert.ToDouble(dt.Rows[i]["IgstAmt"]),
                    CgstAmt = Convert.ToDouble(dt.Rows[i]["CgstAmt"]),
                    SgstAmt = Convert.ToDouble(dt.Rows[i]["SgstAmt"]),
                    CesRt = Convert.ToDouble(dt.Rows[i]["CesRt"]),
                    CesAmt = Convert.ToDouble(dt.Rows[i]["CesAmt"]),
                    CesNonAdvlAmt = Convert.ToDouble(dt.Rows[i]["CesNonAdvlAmt"]),
                    StateCesRt = Convert.ToDouble(dt.Rows[i]["StateCesRt"]),
                    StateCesAmt = Convert.ToDouble(dt.Rows[i]["StateCesAmt"]),
                    StateCesNonAdvlAmt = Convert.ToDouble(dt.Rows[i]["StateCesNonAdvlAmt"]),
                    OthChrg = Convert.ToDouble(dt.Rows[i]["OthChrg"]),
                    TotItemVal = Convert.ToDouble(dt.Rows[i]["TotItemVal"])
                });
            }

            return Item;
        }
        /// <summary>UploadIRNFile operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        // [Route("api/Accounts")]
        public IHttpActionResult UploadIRNFile()
        {

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable("Table");
            DataRow drow = dtbl.NewRow();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var transtype = HttpContext.Current.Request.Params["transtype"];
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\EInvoice\\ResponseIrn\\", fileName);

                    if (File.Exists(filePath) == true)
                    {
                        dtbl.Columns.Add("STATUS", typeof(string));
                        dtbl.Columns.Add("STATUSTXT", typeof(string));
                        drow = dtbl.NewRow();
                        drow[0] = "104";
                        drow[1] = fileName + " already exists";
                        dtbl.Rows.Add(drow);
                        ds.Merge(dtbl);
                    }
                    else
                    {

                        file.SaveAs(filePath);
                        ds = fN_upload_IRNFile(fileName, transtype, cmpid, vguid, makerip);
                        file.SaveAs(filePath);

                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/UploadItemMrpExcelFile");
            }
            return Ok(ds);

        }
        public DataSet fN_upload_IRNFile(string strFileName, string transtype, string CMPID, string VGUID, string MAKERIP)
        {
            DataSet ds_fst = new DataSet();
            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();

            DAL objDal = new DAL();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);

                string strFilePath;
                // strFilePath = HttpContext.Current.Server.MapPath(@"..\") + @"DATA\EInvoice\ResponseIrn\" + strFileName;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\EInvoice\\ResponseIrn\\" + strFileName);


                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                // If transtype = "INV" Then
                Query = string.Format("Select [IRN],[Ack No],[Ack Date],[Doc No],[Doc Date],[Signed QR Code] FROM [{0}]", "UploadedInvoiceDetails$");


                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                try
                {
                    myExcelConn.Open();

                    OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                    myExcelConn.Close();
                    oda.Fill(DS);
                    DataTable Exceldt = DS.Tables[0];
                    string invstr = "";
                    Exceldt.Columns.Add("UserId", typeof(string));
                    Exceldt.Columns.Add("VGUID", typeof(string));
                    Exceldt.Columns.Add("TRANSTYPE", typeof(string));
                    int i = Exceldt.Rows.Count;
                    for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
                    {
                        Exceldt.Rows[i]["UserId"] = CMPID;
                        Exceldt.Rows[i]["VGUID"] = VGUID;
                        Exceldt.Rows[i]["TRANSTYPE"] = transtype;
                    }

                    SqlConnection con = new SqlConnection();

                    // creating object of SqlBulkCopy    
                    SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                    sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                    con = new SqlConnection(sqlconn);

                    // assigning Destination table name    
                    objbulk.DestinationTableName = "ACC_INVOICE_EINVOICE_EXCEL";
                    // Mapping Table column    
                    objbulk.ColumnMappings.Add("Doc No", "INV_NO");
                    objbulk.ColumnMappings.Add("Ack No", "ACKNO");
                    objbulk.ColumnMappings.Add("Ack Date", "ACKDATE");
                    objbulk.ColumnMappings.Add("IRN", "IRNNO");
                    objbulk.ColumnMappings.Add("Doc Date", "INV_DATE");
                    // objbulk.ColumnMappings.Add("Inv Value.", "TOTALAMT")
                    objbulk.ColumnMappings.Add("Signed QR Code", "QRCODE");
                    objbulk.ColumnMappings.Add("UserId", "USERID");
                    objbulk.ColumnMappings.Add("VGUID", "VGUID");
                    objbulk.ColumnMappings.Add("TRANSTYPE", "TRANSTYPE");

                    // inserting Datatable Records to DataBase    
                    con.Open();


                    objbulk.WriteToServer(Exceldt);
                    con.Close();
                    ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_UPLOAD_XL_UPDATEGSTIRN", CMPID, MAKERIP, VGUID, strFileName, strFilePath, transtype);
                }
                catch (Exception excelEx)
                {
                    //Console.WriteLine($"Excel Operation Failed: {excelEx.Message}");
                    //Console.WriteLine($"Stack Trace: {excelEx.StackTrace}");
                    //ErrorLog.Error(excelEx, "Accounts/ExcelProcessing");
                    DataTable dtbl = new DataTable("Table");
                    // DataRow drow = new DataRow;
                    DataRow drow = dtbl.NewRow();
                    dtbl.Columns.Add("STATUS", typeof(string));
                    dtbl.Columns.Add("STATUSTXT", typeof(string));
                    drow = dtbl.NewRow();
                    drow[0] = "103";
                    drow[1] = excelEx.Message;
                    dtbl.Rows.Add(drow);
                    ds_fst.Merge(dtbl);
                    throw; // Re-throw to stop execution or let outer catch handle it

                }
                finally
                {
                    if (myExcelConn.State == ConnectionState.Open)
                    {
                        myExcelConn.Close();
                    }
                }



            }

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
            }
            return ds_fst;


        }

        //[HttpPost]
        //// [Route("api/Accounts")]
        //public IHttpActionResult UploadIRNFile()
        //{
        //    //HttpResponseMessage response = null;
        //    DataSet ds = new DataSet();
        //    var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
        //    var transtype = HttpContext.Current.Request.Params["transtype"];
        //    var cmpid = HttpContext.Current.Request.Params["cmpid"];
        //    var vguid = HttpContext.Current.Request.Params["vguid"];
        //    var makerip = HttpContext.Current.Request.Params["makerip"];
        //    if (file != null && file.ContentLength > 0)
        //    {

        //        var fileName = Path.GetFileName(file.FileName);
        //        var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\EInvoice\\ResponseIrn\\", fileName);
        //        file.SaveAs(filePath);
        //        ds = fN_upload_IRNFile(fileName, transtype, cmpid, vguid, makerip);
        //    }
        //    return Ok(ds);

        //}
        //public DataSet fN_upload_IRNFile(string strFileName, string transtype, string CMPID, string VGUID, string MAKERIP)
        //{
        //    DataSet ds_fst = new DataSet();
        //    DataSet gstDS1 = new DataSet();
        //    DataSet gstResust = new DataSet();

        //    DAL objDal = new DAL();
        //    var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
        //    try
        //    {
        //        strFileName = Path.GetFileName(strFileName);
        //        string strExtension;
        //        strExtension = Path.GetExtension(strFileName);

        //        string strFilePath;
        //        // strFilePath = HttpContext.Current.Server.MapPath(@"..\") + @"DATA\EInvoice\ResponseIrn\" + strFileName;
        //        strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\EInvoice\\ResponseIrn\\" + strFileName);
        //        if (File.Exists(strFilePath) == true)
        //        {
        //            //lblError.Visible = true;
        //            //lblError.Text = strFileName + " File Already Exists - Please Check";

        //            //  return;
        //        }

        //         file.SaveAs(strFilePath);

        //        // Step 2

        //        DataSet DS = new DataSet();
        //        DataSet MP_DS = new DataSet();
        //        OleDbDataAdapter Adapter = new OleDbDataAdapter();
        //        OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

        //        string Query, sqlconn;
        //        // If transtype = "INV" Then
        //        Query = string.Format("Select [IRN],[Ack No],[Ack Date],[Doc No],[Doc Date],[Signed QR Code] FROM [{0}]", "UploadedInvoiceDetails$");
        //        // ElseIf transtype = "CN" Then
        //        // Query = String.Format("Select [IRN],[Ack No],[Ack Date],[Doc No],[Doc Date],[Signed QR Code] FROM [{0}]", "Sheet1$")
        //        // End If

        //        OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
        //        myExcelConn.Open();

        //        OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
        //        myExcelConn.Close();
        //        oda.Fill(DS);
        //        DataTable Exceldt = DS.Tables[0];
        //        string invstr = "";
        //        Exceldt.Columns.Add("UserId", typeof(string));
        //        Exceldt.Columns.Add("VGUID", typeof(string));
        //        Exceldt.Columns.Add("TRANSTYPE", typeof(string));
        //        int i = Exceldt.Rows.Count;
        //        for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
        //        {
        //            Exceldt.Rows[i]["UserId"] = CMPID;
        //            Exceldt.Rows[i]["VGUID"] = VGUID;
        //            Exceldt.Rows[i]["TRANSTYPE"] = transtype;
        //        }


        //        SqlConnection con = new SqlConnection();

        //        // creating object of SqlBulkCopy    
        //        SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
        //        sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
        //        con = new SqlConnection(sqlconn);

        //        // assigning Destination table name    
        //        objbulk.DestinationTableName = "ACC_INVOICE_EINVOICE_EXCEL";
        //        // Mapping Table column    
        //        objbulk.ColumnMappings.Add("Doc No", "INV_NO");
        //        objbulk.ColumnMappings.Add("Ack No", "ACKNO");
        //        objbulk.ColumnMappings.Add("Ack Date", "ACKDATE");
        //        objbulk.ColumnMappings.Add("IRN", "IRNNO");
        //        objbulk.ColumnMappings.Add("Doc Date", "INV_DATE");
        //        // objbulk.ColumnMappings.Add("Inv Value.", "TOTALAMT")
        //        objbulk.ColumnMappings.Add("Signed QR Code", "QRCODE");
        //        objbulk.ColumnMappings.Add("UserId", "USERID");
        //        objbulk.ColumnMappings.Add("VGUID", "VGUID");
        //        objbulk.ColumnMappings.Add("TRANSTYPE", "TRANSTYPE");

        //        // inserting Datatable Records to DataBase    
        //        con.Open();


        //        // DataSet ds_fst = null/* TODO Change to default(_) if this is not a reference type */;
        //      //  DataSet ds_fst = new DataSet();
        //        objbulk.WriteToServer(Exceldt);
        //        con.Close();

        //       ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_UPLOAD_XL_UPDATEGSTIRN", CMPID, MAKERIP, VGUID, strFileName, strFilePath, transtype);

        //    }

        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
        //    }
        //    return ds_fst;
        //    //return "success";
        //    //return Ok(gstDS1);
        //}
        /* Added for bankpayment tds */

        /// <summary>Load page reference data for CHEQUE PREVIEWPRINT PAGELOAD records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="STRCHEQUENO">STRCHEQUENO parameter.</param>
        /// <param name="COUNT">COUNT parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="STRVALUE">STRVALUE parameter.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHEQUE_PREVIEWPRINT_PAGELOAD_NG(string CMPID, string CMPCODE, string CITYCODE1, string STRCHEQUENO, string COUNT, string OURBANK, string ENTRYNO, string STRVALUE, string MAKERIP)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CHEQUE_PREVIEWPRINT_PAGELOAD_NG", CMPID, CMPCODE, CITYCODE1, STRCHEQUENO, COUNT, OURBANK, ENTRYNO, STRVALUE, MAKERIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CHEQUE_PREVIEWPRINT_PAGELOAD_NG");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for BRBPCRCPCE RESET records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_RESET_NG(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_RESET_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_RESET_NG");
            }
            return Ok(ds);
        }
        /// <summary>Generate BRBPCRCPCE PAYORDER GENERATE records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="BPReqNo">BPReq No parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_PAYORDER_GENERATE_NG(string CMPID, string CMPCODE, string CITYCODE1, string OURBANK, String BPReqNo, String MAKERID, String MAKERIP)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_PAYORDER_GENERATE_NG", CMPID, CMPCODE, CITYCODE1, OURBANK, BPReqNo, MAKERID, MAKERIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_PAYORDER_GENERATE");
            }
            return Ok(ds);
        }
        /// <summary>Delete BRBPCRCPCE TMP DEL records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_BANKDTLS_ID">ACC BANKDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_TMP_DEL_NG(string ID, string VGUID, string ACC_BANKDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_TMP_DEL_NG", ID, VGUID, ACC_BANKDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_TMP_DEL_NG");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for BPDIIDE TDS RESET records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BPDIIDE_TDS_RESET_NG(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BPDIIDE_TDS_RESET_NG", VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BPDIIDE_TDS_RESET_NG");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for BRBPCRCPCE View records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_View_NG(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS, String CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_VIEW_NG", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_View_NG");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update BRBPCRCPCE IU records.</summary>
        /// <param name="BR">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BRBPCRCPCE_IU_NG([FromBody]BRBPCRCPCE BR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (BR.ENTRYNO == " ")
            {
                spName = "USP_ACC_BRBPCRCPCE_INSERT_NG";
            }
            else
            {
                spName = "USP_ACC_BRBPCRCPCE_UPDATE_NG";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, BR.CMPID, BR.CMPCODE, BR.CITYCODE1, BR.CITYCODE, BR.USERNAME, BR.ENTRYNO, BR.ENTRYDT, BR.STATUS, (BR.OURBANK != null) ? BR.OURBANK : "", (BR.OURBANKNM != null) ? BR.OURBANKNM : "", BR.CHEQUETYPE, (BR.CHEQUENO != null) ? BR.CHEQUENO : "", (BR.CHEQUEDT != null) ? BR.CHEQUEDT : "", (BR.BANK != null) ? BR.BANK : "", BR.NARRATION, BR.ACTUALAMOUNT, BR.VGUID, BR.MAKER_ID, BR.MAKER_IP, BR.NOTOVERFLAG, BR.ACTION, BR.PAYEENAME, BR.BANKREFNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update BPDIIDE TDS TMP IU records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BPDIIDE_TDS_TMP_IU_NG([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BPDIIDE_TDS_TMP_IU_NG", PID.cmpid, PID.STATUS, PID.VGUID, PID.STR);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BPDIIDE_TDS_TMP_IU_NG");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update BRBPCRCPCE TMP IU records.</summary>
        /// <param name="BRD">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BRBPCRCPCE_TMP_IU_NG([FromBody]BRBPCRCPCEDTL BRD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (BRD.ISOLDENTRY == "1")
            {
                spName = "USP_ACC_BRBPCRCPCE_TMP_IU_OLD";
            }
            else
            {
                spName = "USP_ACC_BRBPCRCPCE_TMP_IU_NG";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, BRD.ID, BRD.ENTRYNO, BRD.CLIENT, (BRD.JOBNO != null) ? BRD.JOBNO : "", (BRD.BILLNO != null) ? BRD.BILLNO : "", BRD.DEDUCTION, BRD.AMOUNT, BRD.ENTRYTYPE, BRD.EMP_CODE, BRD.USERNAME, BRD.CRPARENTENTRYNO, (BRD.NARRATION != null) ? BRD.NARRATION : "", BRD.IS_NOT_EDIT_ABLE, BRD.ITEMCODE, (BRD.DEPTID != null) ? BRD.DEPTID : "", BRD.VGUID, BRD.ACCOUNT_NAME, BRD.ITEM, (BRD.DEPARTMENT != null) ? BRD.DEPARTMENT : "", BRD.ACC_BANKDTLS_ID, BRD.STATUS, BRD.ISJOBREPORT, BRD.EMP_CODE_VALUE, BRD.EMP_CODE_TEXT, BRD.ITEM_DATAVALUE, BRD.CMPCODE, BRD.CITYCODE, BRD.CMPID, BRD.IS_GST, BRD.ISTDSCALC, BRD.IS_TDS, BRD.GSTRATE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_TMP_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform BP TDSCAL records.</summary>
        /// <param name="ENTRYDT">ENTRYDT parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_TDSCAL(string ENTRYDT, string VGUID, string CMPCODE, string CMPID, string CITYCODE, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BP_TDSCAL", ENTRYDT, VGUID, CMPCODE, CMPID, CITYCODE, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_TDSCAL");
            }
            return Ok(ds);
        }

        /// <summary>Perform BP TDSCAL records.</summary>
        /// <param name="SUPPCODE">SUPPCODE parameter.</param>
        /// <param name="PURCHASEDT">PURCHASEDT parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_TDSCAL_NG(string SUPPCODE, string PURCHASEDT, string VGUID, string CMPCODE, string CMPID, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BP_TDSCAL_NG", SUPPCODE, PURCHASEDT, VGUID, CMPCODE, CMPID, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_TDSCAL_NG");
            }
            return Ok(ds);
        }
        /*  Added For Staff Purchase Request  14/08/2020*/

        /// <summary>Load page reference data for PURCHASE records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="PSTATUS">PSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_PAGELOAD(string cmp_code, string citycode, string citycode1, string PSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_PAGELOAD", cmp_code, citycode, citycode1, PSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_PAGELOAD");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for PURCHASE records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_VIEW(string cmp_code, string citycode, string ENTRYNO, string VGUID, string STATUS,string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_VIEW", cmp_code, citycode, ENTRYNO, VGUID, STATUS,CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_VIEW");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update PURCHASE records.</summary>
        /// <param name="PIM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_INSERT([FromBody]StaffPurchaseInvoiceMaster PIM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_INSERT", PIM.CMPID, PIM.CMPCODE, PIM.CITYCODE1, PIM.CITYCODE, PIM.USERNAME, (PIM.ENTRYNO != null)? PIM.ENTRYNO :"", PIM.ENTRYDT, PIM.STATUS, PIM.SUP_CODE, PIM.SUP_NAME, PIM.SUP_INVNO, PIM.SUP_INVDT, PIM.SUP_BILLRECEIVEDDT, PIM.SUP_DUEDT, PIM.PASSFLAG, PIM.PASSEDBY, PIM.PASSEDAMT, PIM.INVAMT, PIM.VOUCHERNO, PIM.MAWBN0, PIM.FREIGHTG100235, PIM.SURCHARGEG101468, PIM.AIRFRTCOMMG100153, PIM.FRTREBATEG100186, PIM.NARRATION, PIM.ACTUALAMOUNT, PIM.VGUID, PIM.MAKER_ID, PIM.MAKER_IP, PIM.ACTION, PIM.DOCUMENTG100179, PIM.FK_SUP_ADDR_ID, PIM.AMSENSEXP_G102024, PIM.MISCEXP_G102025);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_INSERT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Insert or update PURCHASE records.</summary>
        /// <param name="PIM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_UPDATE([FromBody]StaffPurchaseInvoiceMaster PIM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_UPDATE", PIM.CMPID, PIM.CMPCODE, PIM.CITYCODE1, PIM.CITYCODE, PIM.USERNAME, PIM.ENTRYNO, PIM.ENTRYDT, PIM.STATUS, PIM.SUP_CODE, PIM.SUP_NAME, PIM.SUP_INVNO, PIM.SUP_INVDT, PIM.SUP_BILLRECEIVEDDT, PIM.SUP_DUEDT, PIM.PASSFLAG, PIM.PASSEDBY, PIM.PASSEDAMT, PIM.INVAMT, PIM.VOUCHERNO, PIM.MAWBN0, PIM.FREIGHTG100235, PIM.SURCHARGEG101468, PIM.AIRFRTCOMMG100153, PIM.FRTREBATEG100186, PIM.NARRATION, PIM.ACTUALAMOUNT, PIM.VGUID, PIM.MAKER_ID, PIM.MAKER_IP, PIM.ACTION, PIM.DOCUMENTG100179, PIM.FK_SUP_ADDR_ID, PIM.AMSENSEXP_G102024, PIM.MISCEXP_G102025);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Delete PURCHASE TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_PURCHASEDTLS_ID">ACC PURCHASEDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_TMP_DEL(string ID, string VGUID, string ACC_PURCHASEDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TMP_DEL", ID, VGUID, ACC_PURCHASEDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_DEL");
            }
            return Ok(ds);
        }


        /// <summary>Reset temporary data for PURCHASE records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_RESET");
            }
            return Ok(ds);
        }
       

        /// <summary>Insert or update PURCHASE TMP records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_TMP_IU([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TMP_IU", PID.ID, PID.ENTRYNO, PID.CLIENT, PID.JOBNO, PID.DEDUCTION, PID.AMOUNT, PID.USERNAME, PID.NARRATION, PID.IS_NOT_EDIT_ABLE, PID.ITEMCODE, PID.VGUID, PID.ACCOUNT_NAME, PID.ITEM, PID.ACC_PURCHASEDTLS_ID, PID.STATUS, PID.IsJobReport, PID.ITEM_DATAVALUE, PID.SRPIPASSAMOUNT,PID.cmpid); 
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Perform PURCHASE TMP IUOLD records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_TMP_IUOLD([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TMP_IU_OLD", PID.ID, PID.ENTRYNO, PID.CLIENT, PID.JOBNO, PID.DEDUCTION, PID.AMOUNT, PID.USERNAME, PID.NARRATION, PID.IS_NOT_EDIT_ABLE, PID.ITEMCODE, PID.VGUID, PID.ACCOUNT_NAME, PID.ITEM, PID.ACC_PURCHASEDTLS_ID, PID.STATUS, PID.IsJobReport, PID.ITEM_DATAVALUE, PID.SRPIPASSAMOUNT,PID.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_IUOLD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve PURCHASE SEARCH RPI records.</summary>
        /// <param name="PUR_CODE">PUR CODE parameter.</param>
        /// <param name="PUR_SUPPLIER">Supplier code.</param>
        /// <param name="PUR_INVNO">Invoice number.</param>
        /// <param name="PUR_JOBNO">Job number.</param>
        /// <param name="AMOUNT">AMOUNT parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <param name="FIN_STARTDATE">Start date for the date range filter.</param>
        /// <param name="FIN_ENDDATE">End date for the date range filter.</param>
        /// <param name="USERID">USERID parameter.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_SEARCH_RPI(string PUR_CODE, string PUR_SUPPLIER, string PUR_INVNO, string PUR_JOBNO, string AMOUNT, string FROMDATE, string TODATE, string cmp_code, string citycode, string TYPE, string DISPLAYTYPE, string YEAR_ID, string FIN_STARTDATE, string FIN_ENDDATE, string USERID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_SEARCH_REQUEST", (PUR_CODE != null) ? PUR_CODE : "", (PUR_SUPPLIER != null) ? PUR_SUPPLIER : "", (PUR_INVNO != null) ? PUR_INVNO : "", (PUR_JOBNO != null) ? PUR_JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", cmp_code, citycode, TYPE, DISPLAYTYPE, YEAR_ID, FIN_STARTDATE, FIN_ENDDATE, USERID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_SEARCH_RPI");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve PURCHASE SEARCH PI records.</summary>
        /// <param name="PUR_CODE">PUR CODE parameter.</param>
        /// <param name="PUR_SUPPLIER">Supplier code.</param>
        /// <param name="PUR_INVNO">Invoice number.</param>
        /// <param name="PUR_JOBNO">Job number.</param>
        /// <param name="AMOUNT">AMOUNT parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <param name="FIN_STARTDATE">Start date for the date range filter.</param>
        /// <param name="FIN_ENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_SEARCH_PI(string PUR_CODE, string PUR_SUPPLIER, string PUR_INVNO, string PUR_JOBNO, string AMOUNT, string FROMDATE, string TODATE, string cmp_code, string citycode, string TYPE, string DISPLAYTYPE, string YEAR_ID, string FIN_STARTDATE, string FIN_ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_Purchase_Search", (PUR_CODE != null) ? PUR_CODE : "", (PUR_SUPPLIER != null) ? PUR_SUPPLIER : "", (PUR_INVNO != null) ? PUR_INVNO : "", (PUR_JOBNO != null) ? PUR_JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", cmp_code, citycode, TYPE, DISPLAYTYPE, (YEAR_ID!=null)? YEAR_ID:"", FIN_STARTDATE, FIN_ENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_SEARCH_PI");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for PURCHASE PRINT PI records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="PUR_CODE">PUR CODE parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="PUR_SUPPLIER">Supplier code.</param>
        /// <param name="PUR_INVNO">Invoice number.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_PRINT_PI(string cmp_code, string citycode,string PUR_CODE, string FROMDATE, string TODATE, string PUR_SUPPLIER, string PUR_INVNO, string DISPLAYTYPE, string YEAR_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_Purchase_Search", cmp_code, citycode, (PUR_CODE != null) ? PUR_CODE : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (PUR_SUPPLIER != null) ? PUR_SUPPLIER : "",(PUR_INVNO != null) ? PUR_INVNO:"", DISPLAYTYPE, YEAR_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_SEARCH_PI");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for PURCHASE PRINT RPI records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="PUR_CODE">PUR CODE parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="PUR_SUPPLIER">Supplier code.</param>
        /// <param name="PUR_INVNO">Invoice number.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_PRINT_RPI(string cmp_code, string citycode, string PUR_CODE, string FROMDATE, string TODATE, string PUR_SUPPLIER, string PUR_INVNO, string DISPLAYTYPE, string YEAR_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RPI_PRINT", cmp_code, citycode, (PUR_CODE != null) ? PUR_CODE : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (PUR_SUPPLIER != null) ? PUR_SUPPLIER : "", (PUR_INVNO != null) ? PUR_INVNO : "", DISPLAYTYPE, YEAR_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_PRINT_RPI");
            }
            return Ok(ds);
        }
        /// <summary>Validate PURCHASE SUPINVNO records.</summary>
        /// <param name="SUPCODE">SUPCODE parameter.</param>
        /// <param name="SUPINVNO">Invoice number.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_SUPINVNO_VALIDATE(string SUPCODE,string SUPINVNO,string ENTRYNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_SUPINVNO_VALIDATE", SUPCODE, SUPINVNO,(ENTRYNO != null) ? ENTRYNO :"");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_SUPINVNO_VALIDATE");
            }
            return Ok(ds);
        }
        /// <summary>Perform Purchase Check Input VoucherNo records.</summary>
        /// <param name="VoucherNo">Voucher No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Purchase_Check_Input_VoucherNo(string VoucherNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CHECK_VOUCHERNO_EXIST_IN_JV_PUR_35", VoucherNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Purchase_Check_Input_VoucherNo");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve PURCHASE SEARCH PERDAY records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="FIN_STARTDATE">Start date for the date range filter.</param>
        /// <param name="FIN_ENDDATE">End date for the date range filter.</param>
        /// <param name="DAY">DAY parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_SEARCH_PERDAY(string cmp_code, string citycode, string TYPE, string FIN_STARTDATE, string FIN_ENDDATE, string DAY)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_Purchase_Search_Day", cmp_code, citycode, TYPE, FIN_STARTDATE, FIN_ENDDATE, DAY);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_SEARCH_PERDAY");
            }
            return Ok(ds);
        }
        /// <summary>Perform PURCHASE RESTALL records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_RESTALL(string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET_ALL", CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_RESTALL");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of PURCHASE MAWBNO records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWBNO_LIST(string CMPID, string CMPCODE, string CITYCODE , string TYPE, string MAWBNO )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_PAGELOAD",CMPID,CMPCODE,CITYCODE,TYPE, (MAWBNO != null) ? MAWBNO : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWBNO_LIST");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for PURCHASE MAWBNO records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <param name="FREIGHT">FREIGHT parameter.</param>
        /// <param name="SURCHARGE">SURCHARGE parameter.</param>
        /// <param name="AIRFRTCOMM_G100153">AIRFRTCOMM G100153 parameter.</param>
        /// <param name="FRTREBATE_G100186">FRTREBATE G100186 parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="DOCUMENT_G100179">DOCUMENT G100179 parameter.</param>
        /// <param name="AMSENSEXP_G102024">AMSENSEXP G102024 parameter.</param>
        /// <param name="MISCEXP_G102025">MISCEXP G102025 parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWBNO_PAGELOAD(string CMPID, string CMPCODE, string CITYCODE,string MAWBNO,string FREIGHT, string SURCHARGE,string AIRFRTCOMM_G100153,string FRTREBATE_G100186,string VGUID,string STATUS,string DOCUMENT_G100179,string AMSENSEXP_G102024, string MISCEXP_G102025 )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB", CMPID, CMPCODE, CITYCODE,MAWBNO, (FREIGHT != null) ? FREIGHT : "0", (SURCHARGE != null) ? SURCHARGE : "0", (AIRFRTCOMM_G100153 != null) ? AIRFRTCOMM_G100153 : "0", (FRTREBATE_G100186 != null) ? FRTREBATE_G100186 : "0",VGUID,STATUS, (DOCUMENT_G100179 != null) ? DOCUMENT_G100179 : "0", (AMSENSEXP_G102024 != null) ? AMSENSEXP_G102024 : "0",  (MISCEXP_G102025 != null) ? MISCEXP_G102025 : "0");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWBNO_PAGELOAD");
            }
            return Ok(ds);
        }

        //--MULTICONTAIER PUCHASE 
        /*
        /// <summary>Insert or update PURCHASE MULTICONTAINER TMP records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_TMP_IU([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINER_TMP_IU", PID.ID, PID.ENTRYNO, PID.VGUID, PID.CLIENT, PID.ACCOUNT_NAME, PID.JOBNO, PID.AMOUNT, PID.DEDUCTION, PID.NARRATION, PID.ITEMCODE ,PID.ITEM_DATAVALUE, PID.ACC_PURCHASEDTLS_ID , PID.IsJobReport,PID.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }*/
        /// <summary>Insert or update PURCHASE MULTICONTAINER TMP records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_TMP_IU([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINER_TMP_IU", PID.ID, (PID.ENTRYNO == null) ? "" : PID.ENTRYNO, PID.VGUID, PID.CLIENT, PID.ACCOUNT_NAME, PID.JOBNO, PID.AMOUNT, PID.DEDUCTION, PID.NARRATION, (PID.ITEMCODE == null) ? "" : PID.ITEMCODE, (PID.ITEM_DATAVALUE == null) ? "" : PID.ITEM_DATAVALUE, PID.ACC_PURCHASEDTLS_ID, PID.IsJobReport, PID.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update PURCHASE MULTICONTAINER records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_IU(string CMPCODE, string CITYCODE1,string VGUID,string TYPE,String CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTTCONTAINER_STEP1_IU", CMPCODE,  CITYCODE1, VGUID,TYPE ,CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_IU");
            }
            return Ok(ds);
        }

        //----AUTHORISATION INVOICE



        /// <summary>Retrieve list of invoice auth records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="RoleType">Role Type parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_auth_list(string  cmpid , string cmp_code, string RoleType , string Type )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_AUTHORISATION", cmpid,cmp_code,RoleType,Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_auth_list");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for invoice Proforma Print records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="RoleType">Role Type parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_Proforma_Print_list(string cmpid, string cmp_code, string RoleType, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_PROFORMA_LIST", cmpid, cmp_code, RoleType, Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_Proforma_Print_list");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update invoice Authorisation records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_Authorisation_Update([FromBody]Authorisation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_AUTHORISATION_ASSIGN", obj.cmp_code,obj.citycode,obj.NOSTR,obj.CHKAuthorityFlag,obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_Authorisation_Update");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for invoice records.</summary>
        /// <param name="invoiceno">invoiceno parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_view(string invoiceno, string cmp_code )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_AUTHORISATION_VIEW", invoiceno, cmp_code);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_view");
            }
            return Ok(ds);
        }
        //CreditNote UNAuthorisation 
        /// <summary>Insert or update CN Authorisation records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CN_Authorisation_Update([FromBody]Authorisation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_AUTHORISATION_ASSIGN", obj.cmp_code, obj.citycode, obj.NOSTR, obj.CHKAuthorityFlag, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CN_Authorisation_Update");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for CN records.</summary>
        /// <param name="CNno">CNno parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="type">type parameter.</param>
        /// <param name="finstartdt">Start date for the date range filter.</param>
        /// <param name="fin_enddt">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CN_view(string CNno, string cmp_code,string citycode,string type,string finstartdt,string fin_enddt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_CreditNote_Print", CNno, cmp_code,citycode,type,finstartdt,fin_enddt);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CN_view");
            }
            return Ok(ds);
        }
        //invoice UNAuthorisation 
        /// <summary>Retrieve list of invoice unauth records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="RoleType">Role Type parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_unauth_list(string cmpid, string cmp_code, string RoleType, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_unAUTHORISATION", cmpid, cmp_code, RoleType, Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_unauth_list");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update invoice UnAuthorisation records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_UnAuthorisation_Update([FromBody]Authorisation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_UNAUTHORISATION_ASSIGN", obj.cmp_code, obj.citycode, obj.NOSTR, obj.CHKAuthorityFlag, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_unAuthorisation_Update");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform invoice AUTHORISATION CHECK records.</summary>
        /// <param name="invno">Invoice number.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_AUTHORISATION_CHECK(string invno, string cmp_code )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PRINT_AUTHORISATION_CHECK", invno, cmp_code );

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_AUTHORISATION_CHECK");
            }
            return Ok(ds);
        }

        /// <summary>Perform invoice Chk Inv NONINR records.</summary>
        /// <param name="invno">Invoice number.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_Chk_Inv_NONINR(string invno, string cmp_code,string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Acc_Chk_INV_NONINR", invno, cmp_code,citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_Chk_Inv_NONINR");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for invoice records.</summary>
        /// <param name="invno">Invoice number.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_invoice_Print(string invno, string cmp_code, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Acc_INV_Print_New", invno, cmp_code, citycode);
                            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_invoice_Print");
            }
            return Ok(ds);
        }
       

        /*INVOICE */
        /// <summary>Perform INVOICE PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_PAGE_LOAD(string CMPCODE, string CITYCODE,string CITYCODE1,string cmpid,string INVNO,string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1, cmpid, (INVNO == null) ? "" : INVNO, type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of INVOICE LIST JOB records.</summary>
        /// <param name="frmdt">Start date for the date range filter.</param>
        /// <param name="todt">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_LIST_JOB(string frmdt,string todt ,string CMPCODE, string CITYCODE, string CITYCODE1 ,string Type )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_LIST_JOB",frmdt,todt, CMPCODE, CITYCODE, CITYCODE1, Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_LIST_JOB");
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for INVOICE JOB records.</summary>
        /// <param name="JOBSTR">JOBSTR parameter.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_JOB_POPULATE(string JOBSTR, string TYPE, string CMPID,string GUID, string INVNO,string CMPCODE )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_JOB_POPULATE", JOBSTR, TYPE, CMPID, GUID, (INVNO == null) ? "" : INVNO, CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_JOB_POPULATE");
            }
            return Ok(ds);
        }
        /// <summary>Perform INVOICE PAYBYDATE GET records.</summary>
        /// <param name="clientcode">Client/exporter code.</param>
        /// <param name="invdt">invdt parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="ISPAYBYDT_AIR">ISPAYBYDT AIR parameter.</param>
        /// <param name="ISPAYBYDT_SEA">ISPAYBYDT SEA parameter.</param>
        /// <param name="CREDITPERIOD_SEA">CREDITPERIOD SEA parameter.</param>
        /// <param name="CREDITPERIOD_AIR">CREDITPERIOD AIR parameter.</param>
        /// <param name="HAWBDT">HAWBDT parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_PAYBYDATE_GET(string clientcode, string invdt, string mode, string ISPAYBYDT_AIR, string ISPAYBYDT_SEA,string CREDITPERIOD_SEA,string CREDITPERIOD_AIR, string HAWBDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_PAYBYDATE_GET", clientcode,invdt, (mode==null) ? "" : mode, ISPAYBYDT_AIR, ISPAYBYDT_SEA, CREDITPERIOD_SEA, CREDITPERIOD_AIR, (HAWBDT == null)? "" : HAWBDT);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_PAYBYDATE_GET");
            }
            return Ok(ds);
        }
         
        /// <summary>Perform invoice Job TMP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_Job_TMP([FromBody]InvJobDtls obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_JOBNODTLS_TMP_IU", obj.ID, (obj.INV_NO == null) ? "" : obj.INV_NO, obj.INV_JOBNO, (obj.INV_PKGS == null) ? "" : obj.INV_PKGS, (obj.INV_GRWT == null) ? "" : obj.INV_GRWT, obj.VGUID, obj.ACC_JOBDTLS_ID, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_Job_TMP");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform invoice Charge TMP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_Charge_TMP([FromBody]InvChrgeDtls obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP3_CHARGES_DTLS_TMP_IU", obj.ID,(obj.INV_NO==null)?"": obj.INV_NO, obj.INV_CHRGCODE,obj.INV_ACCOUNT,obj.ACCOUNT_NAME,(obj.INV_DESC_CHRG==null)?"": obj.INV_DESC_CHRG, (obj.INV_DESC1_CHRG1==null)?"": obj.INV_DESC1_CHRG1, (obj.INV_DESC2_CHRG1==null)?"": obj.INV_DESC2_CHRG1, obj.INV_TAXABLE,obj.INV_AMOUNT,obj.INV_INRAMT,obj.INV_TAXABLE_AMOUNT,obj.INV_TAXABLE_INRAMT,obj.USERNAME,obj.VGUID,obj.ACC_CHARGDTLS_ID,obj.CMPID,obj.CMPCODE,obj.CITYCODE1,obj.CITYCODE,obj.INV_QTY,obj.INV_RATE,obj.INV_CURRENCY,obj.INV_EXRATE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_Job_TMP");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete INVOICE JOB records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_JOBDTLS_ID">ACC JOBDTLS ID parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_JOB_DELETE(string ID ,string  GUID, string   ACC_JOBDTLS_ID,string MAKERID )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_JOBNODTLS_TMP_DEL", ID , GUID, ACC_JOBDTLS_ID, MAKERID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_JOB_DELETE");
            }
            return Ok(ds);
        }

        /// <summary>Delete INVOICE CHARGES records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_CHARGS_ID">ACC CHARGS ID parameter.</param>
        /// <param name="INV_CHRGCODE">INV CHRGCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_CHARGES_DELETE(string ID, string GUID, string ACC_CHARGS_ID,string INV_CHRGCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP3_CHRGDTLS_TMP_DEL", ID, GUID, ACC_CHARGS_ID, INV_CHRGCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_CHARGES_DELETE");
            }
            return Ok(ds);
        }

        /// <summary>Perform invoice enclosure TMPIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_enclosure_TMPIU([FromBody]InvEnclosure obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP4_ENCLOSURE_DTLS_TMP_IU", (obj.ID==null)?"0": obj.ID, obj.INV_NO, obj.INV_ENCLCODE, obj.INV_DESC, obj.INV_NUMBER, obj.USERNAME, obj.VGUID, (obj.ACC_ENCLDTLS_ID==null)?"0": obj.ACC_ENCLDTLS_ID, obj.CMPID, obj.CMPCODE, obj.CITYCODE1, obj.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_enclosure_TMPIU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete INVOICE ENCLOSURE records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_ENCLDTLS_ID">ACC ENCLDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_ENCLOSURE_DELETE(string ID, string GUID, string ACC_ENCLDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP4_ENCLOSUER_DTLS_TMP_DEL", ID, GUID, ACC_ENCLDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_ENCLOSURE_DELETE");
            }
            return Ok(ds);
        }
        /// <summary>Perform invoice Dispatch TMPIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_Dispatch_TMPIU([FromBody]InvDispatch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP5_DESPATCH_DTLS_TMP_IU", (obj.ID==null)?"0": obj.ID, obj.INV_NO, obj.INV_DESPCODE, obj.INV_DESC, obj.INV_NUMBER, obj.USERNAME, obj.VGUID, (obj.ACC_DESPDTLS_ID==null)?"0": obj.ACC_DESPDTLS_ID, obj.CMPID, obj.CMPCODE, obj.CITYCODE1, obj.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_Dispatch_TMPIU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete INVOICE dispatch records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_DESPDTLS_ID">ACC DESPDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_dispatch_DELETE(string ID, string GUID, string ACC_DESPDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_STEP5_DESPATCH_DTLS_TMP_DEL", ID, GUID, ACC_DESPDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_dispatch_DELETE");
            }
            return Ok(ds);
        }
        
        /// <summary>Insert or update invoice records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_INSERT([FromBody]InvoiceMain obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_MAINDTLS_INSERT", obj.CMPID, obj.CMPCODE, obj.CITYCODE1, obj.CITYCODE, (obj.INV_NO == null) ? "" : obj.INV_NO, (obj.INV_DATE == null) ? "" : obj.INV_DATE, obj.INV_CLIENT, (obj.INV_CLIENT_NM == null) ? "" : obj.INV_CLIENT_NM, obj.INV_SHIPPER, obj.INV_BILLTYPE, (obj.INV_PKGS == null) ? "" : obj.INV_PKGS, (obj.INV_TYPEOFPKG == null) ? "" : obj.INV_TYPEOFPKG, (obj.INV_NOOFPCS == null) ? "" : obj.INV_NOOFPCS, (obj.INV_TYPEOFPCS == null) ? "" : obj.INV_TYPEOFPCS, (obj.INV_CLIENTREF == null) ? "" : obj.INV_CLIENTREF, (obj.INV_WT == null) ? "" : obj.INV_WT, (obj.INV_VOL == null) ? "" : obj.INV_VOL, (obj.INV_HAWBNO == null) ? "" : obj.INV_HAWBNO, (obj.INV_HAWBDT == null) ? "" : obj.INV_HAWBDT, (obj.INV_CARRIER == null) ? "" : obj.INV_CARRIER, (obj.INV_GOODS == null) ? "" : obj.INV_GOODS, obj.INV_CUR, obj.INV_CURINR, obj.INV_CURRATE, obj.INV_CURRATE1, (obj.INV_TAX == null) ? "" : obj.INV_TAX, (obj.INV_ADVANCE == null) ? "" : obj.INV_ADVANCE, obj.NARRATIONDESC, obj.VGUID, obj.MAKER_ID, obj.MAKER_IP, (obj.SHIPINGBILLNO == null) ? "" : obj.SHIPINGBILLNO, (obj.SHIPBILLDT == null) ? "" : obj.SHIPBILLDT, obj.paydt, obj.INV_TYPE, obj.CLIENTCONT,obj.INVSTARTDATE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        } 
        /// <summary>Insert or update invoice records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_invoice_UPDATE([FromBody]InvoiceMain obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_MAINDTLS_UPDATE", obj.CMPID, obj.CMPCODE, obj.CITYCODE1, obj.CITYCODE, (obj.INV_NO == null) ? "" : obj.INV_NO, (obj.INV_DATE == null) ? "" : obj.INV_DATE, obj.INV_CLIENT, (obj.INV_CLIENT_NM == null) ? "" : obj.INV_CLIENT_NM, obj.INV_SHIPPER, obj.INV_BILLTYPE, (obj.INV_PKGS == null) ? "" : obj.INV_PKGS, (obj.INV_TYPEOFPKG == null) ? "" : obj.INV_TYPEOFPKG, (obj.INV_NOOFPCS == null) ? "" : obj.INV_NOOFPCS, (obj.INV_TYPEOFPCS == null) ? "" : obj.INV_TYPEOFPCS, (obj.INV_CLIENTREF == null) ? "" : obj.INV_CLIENTREF, (obj.INV_WT == null) ? "" : obj.INV_WT, (obj.INV_VOL == null) ? "" : obj.INV_VOL, (obj.INV_HAWBNO == null) ? "" : obj.INV_HAWBNO, (obj.INV_HAWBDT == null) ? "" : obj.INV_HAWBDT, (obj.INV_CARRIER == null) ? "" : obj.INV_CARRIER, (obj.INV_GOODS == null) ? "" : obj.INV_GOODS, obj.INV_CUR, obj.INV_CURINR, obj.INV_CURRATE, obj.INV_CURRATE1, (obj.INV_TAX == null) ? "" : obj.INV_TAX, (obj.INV_ADVANCE == null) ? "" : obj.INV_ADVANCE, obj.NARRATIONDESC, obj.VGUID, obj.MAKER_ID, obj.MAKER_IP, (obj.SHIPINGBILLNO == null) ? "" : obj.SHIPINGBILLNO, (obj.SHIPBILLDT == null) ? "" : obj.SHIPBILLDT, obj.paydt, obj.INV_TYPE, obj.CLIENTCONT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_invoice_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve INVOICE Search Pageloag records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_Search_Pageloag(string cmp_code,string citycode,string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillExpoterCity",cmp_code,citycode,citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_Search_Pageloag");
            }
            return Ok(ds);
        } 
        /// <summary>Search and retrieve INVOICE Search records.</summary>
        /// <param name="InvoiceNo">Invoice No parameter.</param>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="JobNo">Job number.</param>
        /// <param name="Amount">Amount parameter.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_Search_List(string InvoiceNo, string Client, string JobNo, string Amount, string FromDate, string ToDate, string cmp_code, string citycode, string TYPE, string Fin_StartDate, string Fin_EndDate, string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_INVSearchClient_Get", (InvoiceNo == null) ? "" : InvoiceNo, (Client == null) ? "" : Client, (JobNo == null) ? "" : JobNo, (Amount == null) ? "" : Amount, (FromDate == null) ? "" : FromDate, (ToDate == null) ? "" : ToDate, cmp_code, citycode, TYPE, Fin_StartDate, Fin_EndDate, cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_Search_List");
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for INVOICE Edit records.</summary>
        /// <param name="InvoiceNo">Invoice No parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_Edit_Populate(string InvoiceNo, string cmp_code, string citycode,string makerid,string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_EDITPOPUALTE", InvoiceNo, cmp_code, citycode,makerid,vguid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_Edit_Populate");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve INVOICE SEARCH PERDAY records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="FIN_STARTDATE">Start date for the date range filter.</param>
        /// <param name="FIN_ENDDATE">End date for the date range filter.</param>
        /// <param name="DAY">DAY parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet] 
        public IHttpActionResult ACC_INVOICE_SEARCH_PERDAY(string cmp_code, string citycode, string FIN_STARTDATE, string FIN_ENDDATE, string DAY)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_InvoiceList_Day", cmp_code, citycode, FIN_STARTDATE, FIN_ENDDATE, DAY);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_SEARCH_PERDAY");
            }
            return Ok(ds);
        }
        /*AIR FREIGHT INVOICE*/
        /*Freight Invoice  step1*/
        /// <summary>Load page reference data for INV MAWB AIRFRT CONS PUR records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="MakerIP">IP address of the record maker.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CONS_PUR_PAGELOAD(string cmpid, string MakerIP, string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR_PAGELOAD", cmpid, MakerIP, cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CONS_PUR_PAGELOAD");
            }
            return Ok(ds);
        }
        /*AF invoice History*/
        /// <summary>Retrieve list of INV MAWB AIRFRT CONS PUR records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CONS_PUR_LIST(string cmpid, string cmpcode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR_LIST", cmpid, cmpcode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CONS_PUR_LIST");
            }
            return Ok(ds);
        }

        //[HttpGet]
        //public IHttpActionResult ACCT_INV_MAWB_FRT_SOF_AUTO(string INVNO, string TransType)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    string spName = "";
        //    if (TransType == "INV")
        //    {
        //        spName = "USP_ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT";
        //    }
        //    else if (TransType == "CRT")
        //    {
        //        spName = "USP_ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT_CNINV_IU";
        //    }
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, INVNO);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Accounts/ACCT_INV_MAWB_FRT_SOF_AUTO");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();

        //    }
        //    return Ok(ds);
        //}
        /*STEP1 v2*/
        //[HttpGet]
        //public IHttpActionResult ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT_PAGELOAD(string invno)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {

        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT_PAGELOAD", invno);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT_PAGELOAD");
        //    }
        //    return Ok(ds);
        //}

        ///*FRT INVOICE DETAIL RESET*/
        //[HttpGet]
        //public IHttpActionResult ACCT_INV_MAWB_FRT_SOF_AUTO_RESET(string INVCNCONPI_LOGID)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {

        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_SHAREOFPROFIT_REST", INVCNCONPI_LOGID);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/ACCT_INV_MAWB_FRT_SOF_AUTO_RESET");
        //    }
        //    return Ok(ds);
        //}
        /*AFAutoviewInv */
        /// <summary>Retrieve print/view data for INV MAWB AIRFRT CN SHAREOFPROFIT INV records.</summary>
        /// <param name="INVCNCONPI_LOGID">INVCNCONPI LOGID parameter.</param>
        /// <param name="INVTYPE">INVTYPE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_INV_VIEW(string INVCNCONPI_LOGID, string INVTYPE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_INV_VIEW", INVCNCONPI_LOGID, INVTYPE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_INV_VIEW");
            }
            return Ok(ds);
        }

        /*AFAutoview Inv v2 */
        /// <summary>Retrieve print/view data for INV MAWB AIRFRT INV records.</summary>
        /// <param name="INVCNCONPI_LOGID">INVCNCONPI LOGID parameter.</param>
        /// <param name="FRTINVNO">Invoice number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_INV_VIEW(string INVCNCONPI_LOGID, string FRTINVNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_INV_VIEW", INVCNCONPI_LOGID, FRTINVNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_INV_VIEW");
            }
            return Ok(ds);
        }
        /* AIRFRT_CN_SHAREOFPROFIT_CN_VIEW */
        /// <summary>Retrieve print/view data for INV MAWB AIRFRT CN SHAREOFPROFIT CN records.</summary>
        /// <param name="INVCNCONPI_LOGID">INVCNCONPI LOGID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CN_VIEW(string INVCNCONPI_LOGID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CN_VIEW", INVCNCONPI_LOGID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CN_VIEW");
            }
            return Ok(ds);
        }
        /* AIRFREIGHT_CONSOLE_PURCAHSE_VIEW*/
        /// <summary>Retrieve print/view data for INV CN MAWB AIRFREIGHT CONSOLE PURCAHSE records.</summary>
        /// <param name="INVCNCONPI_LOGID">INVCNCONPI LOGID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCT_INV_CN_MAWB_AIRFREIGHT_CONSOLE_PURCAHSE_VIEW(string INVCNCONPI_LOGID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONSPUR_VIEW", INVCNCONPI_LOGID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCT_INV_CN_MAWB_AIRFREIGHT_CONSOLE_PURCAHSE_VIEW");
            }
            return Ok(ds);
        }

        /* AIRFRT_CN_SHAREOFPROFIT_CONS_PUR */
        /// <summary>Perform INV MAWB AIRFRT CN SHAREOFPROFIT CONS PUR records.</summary>
        /// <param name="FK_LOGID">FK LOGID parameter.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR(string FK_LOGID, string MAWBNO, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR", FK_LOGID, MAWBNO, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR");
            }
            return Ok(ds);
        }
        /*FRT INVOICE DETAIL INVCN RESET*/
        /// <summary>Perform INV MAWB AIRFRT CN SOF INVCN REST records.</summary>
        /// <param name="FK_LOGID">FK LOGID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CN_SOF_INVCN_REST(string FK_LOGID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_INVCN_REST", FK_LOGID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CN_SOF_INVCN_REST");
            }
            return Ok(ds);
        }


        /*FRT INVOICE DETAIL CN GENERATE*/
        /// <summary>Generate INV MAWB AIRFRT CN SOF CONS PUR records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="FK_LOGID">FK LOGID parameter.</param>
        /// <param name="LOCALIPADD">LOCALIPADD parameter.</param>
        /// <param name="ROUTERIPADD">ROUTERIPADD parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INV_MAWB_AIRFRT_CN_SOF_CONS_PUR_GENERATE(string CMPID, string CMPCODE, string CITYCODE1, string CITYCODE, string FK_LOGID, string LOCALIPADD, string ROUTERIPADD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INV_MAWB_AIRFRT_CN_SHAREOFPROFIT_CONS_PUR_GENERATE", CMPID, CMPCODE, CITYCODE1, CITYCODE, FK_LOGID, LOCALIPADD, ROUTERIPADD);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INV_MAWB_AIRFRT_CN_SOF_CONS_PUR_GENERATE");
            }
            return Ok(ds);
        }
        /*FRT INVOICE PURCHASE*/
        /// <summary>Retrieve print/view data for TRAN PURCHASE records.</summary>
        /// <param name="entryno">entryno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_TRAN_PURCHASE_PRINT(string entryno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_TRAN_PURCHASE_PRINT", entryno);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCFRA_TRAN_PURCHASE_PRINT");
            }
            return Ok(ds);
        }


        /*CREDIT NOTE*/
        /// <summary>Search and retrieve CREDITNOTE SEARCH PERDAY records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="DAY">DAY parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CREDITNOTE_SEARCH_PERDAY(string cmp_code, string citycode , string DAY)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_CreditNote_day", DAY,cmp_code, citycode, DAY);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CREDITNOTE_SEARCH_PERDAY");
            }
            return Ok(ds);
        }
        /// <summary>Populate form with existing data for CRTNOTE JOB records.</summary>
        /// <param name="JOBSTR">JOBSTR parameter.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_JOB_POPULATE(string JOBSTR, string TYPE, string CMPID, string GUID, string INVNO, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_JOB_POPULATE", JOBSTR, TYPE, CMPID, GUID, INVNO, CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_JOB_POPULATE");
            }
            return Ok(ds);
        }
        /*
       /// <summary>Perform CRTNOTE JOB TMP records.</summary>
       /// <param name="obj">Request body model containing the record fields.</param>
       /// <returns>DataSet with the requested data serialized as JSON.</returns>
       [HttpPost]
       public IHttpActionResult ACC_CRTNOTE_JOB_TMP([FromBody]InvJobDtls obj)
       {
           DataSet ds = new DataSet();
           DAL objDal = new DAL();
           try
           {
               ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_JOBNODTLS_TMP_IU", obj.ID, obj.INV_NO, obj.INV_JOBNO, (obj.INV_PKGS == null) ? "" : obj.INV_PKGS, (obj.INV_GRWT == null) ? "" : obj.INV_GRWT, obj.VGUID, obj.ACC_JOBDTLS_ID, obj.CMPID);
           }
           catch (Exception ex)
           {
               ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_JOB_TMP");
           }
           finally
           {
               objDal.Dispose();

           }
           return Ok(ds);
       }*/
        /// <summary>Perform CRTNOTE JOB TMP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CRTNOTE_JOB_TMP([FromBody]InvJobDtls obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_JOBNODTLS_TMP_IU", obj.ID, (obj.INV_NO == null) ? "" : obj.INV_NO, obj.INV_JOBNO, (obj.INV_PKGS == null) ? "" : obj.INV_PKGS, (obj.INV_GRWT == null) ? "" : obj.INV_GRWT, obj.VGUID, obj.ACC_JOBDTLS_ID, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_JOB_TMP");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform CRTNOTE CHARGE TMP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CRTNOTE_CHARGE_TMP([FromBody]InvChrgeDtls obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_STEP3_CHARGES_DTLS_TMP_IU", obj.ID, (obj.INV_NO == null) ? "" : obj.INV_NO, obj.INV_CHRGCODE, obj.INV_ACCOUNT, obj.ACCOUNT_NAME, (obj.INV_DESC_CHRG == null) ? "" : obj.INV_DESC_CHRG, (obj.INV_DESC1_CHRG1 == null) ? "" : obj.INV_DESC1_CHRG1, (obj.INV_DESC2_CHRG1 == null) ? "" : obj.INV_DESC2_CHRG1, obj.INV_TAXABLE, obj.INV_AMOUNT, obj.INV_INRAMT, obj.INV_TAXABLE_AMOUNT, obj.INV_TAXABLE_INRAMT, obj.USERNAME, obj.VGUID, obj.ACC_CHARGDTLS_ID, obj.CMPID, obj.CMPCODE, obj.CITYCODE1, obj.CITYCODE, obj.INV_QTY, obj.INV_RATE, obj.INV_CURRENCY, obj.INV_EXRATE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_CHARGE_TMP");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete CRTNOTE JOB records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_JOBDTLS_ID">ACC JOBDTLS ID parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_JOB_DELETE(string ID, string GUID, string ACC_JOBDTLS_ID, string MAKERID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_JOBNODTLS_TMP_DEL", ID, GUID, ACC_JOBDTLS_ID, MAKERID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_JOB_DELETE");
            }
            return Ok(ds);
        }

        /// <summary>Delete CRTNOTE CHARGES records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_CHARGS_ID">ACC CHARGS ID parameter.</param>
        /// <param name="INV_CHRGCODE">INV CHRGCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_CHARGES_DELETE(string ID, string GUID, string ACC_CHARGS_ID, string INV_CHRGCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_CHRGDTLS_TMP_DEL", ID, GUID, ACC_CHARGS_ID, INV_CHRGCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_CHARGES_DELETE");
            }
            return Ok(ds);
        }


        /// <summary>Perform CRTNOTE INVOICE TMP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CRTNOTE_INVOICE_TMP([FromBody]creditnoteBillno obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_INVOICE_DTLS_TMP_IU", obj.ID, (obj.CRT_NO == null) ? "" : obj.CRT_NO, obj.CRT_INVNO, obj.CRT_AMOUNT, obj.CRT_ADJUST, obj.CMPID, obj.VGUID, obj.ACC_INVDTLS_ID, obj.INVSTATUS, (obj.CRT_CLIENT == null) ? "" : obj.CRT_CLIENT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_INVOICE_TMP");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Delete CRTNOTE INV records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_INVDTLS_ID">ACC INVDTLS ID parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_INV_DELETE(string ID, string GUID, string ACC_INVDTLS_ID, string MAKERID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_INVDTLS_TMP_DEL", ID, GUID, ACC_INVDTLS_ID, MAKERID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_INV_DELETE");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update CRTNOTE Final records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CRTNOTE_Final_IU([FromBody]creditnote obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_FINAL_IU", (obj.CMPID == null) ? "" : obj.CMPID, (obj.CMPCODE == null) ? "" : obj.CMPCODE, (obj.CITYCODE1 == null) ? "" : obj.CITYCODE1, (obj.CITYCODE == null) ? "" : obj.CITYCODE, (obj.ID == null) ? "" : obj.ID, (obj.CRT_NO == null) ? "" : obj.CRT_NO, (obj.CRT_DATE == null) ? "" : obj.CRT_DATE, (obj.CRT_CLIENT == null) ? "" : obj.CRT_CLIENT, (obj.CRT_SHIPPER == null) ? "" : obj.CRT_SHIPPER, (obj.CRT_BILLTYPE == null) ? "" : obj.CRT_BILLTYPE, (obj.CRT_PKGS == null) ? "" : obj.CRT_PKGS, (obj.CRT_TYPEOFPKG == null) ? "" : obj.CRT_TYPEOFPKG, (obj.CRT_NOOFPCS == null) ? "" : obj.CRT_NOOFPCS, (obj.CRT_TYPEOFPCS == null) ? "" : obj.CRT_TYPEOFPCS, (obj.CRT_CLIENTREF == null) ? "" : obj.CRT_CLIENTREF, (obj.CRT_WT == null) ? "" : obj.CRT_WT, (obj.CRT_VOL == null) ? "" : obj.CRT_VOL, (obj.CRT_HAWBNO == null) ? "" : obj.CRT_HAWBNO, (obj.CRT_HAWBDT == null) ? "" : obj.CRT_HAWBDT, (obj.CRT_CARRIER == null) ? "" : obj.CRT_CARRIER, (obj.CRT_GOODS == null) ? "" : obj.CRT_GOODS, (obj.CRT_CUR == null) ? "" : obj.CRT_CUR, (obj.CRT_CURINR == null) ? "" : obj.CRT_CURINR, (obj.CRT_CURRATE == null) ? "" : obj.CRT_CURRATE, (obj.CRT_CURRATE1 == null) ? "" : obj.CRT_CURRATE1, (obj.CRT_TAX == null) ? "" : obj.CRT_TAX, (obj.CRT_CUR_NM == null) ? "" : obj.CRT_CUR_NM, (obj.NARRATIONDESC == null) ? "" : obj.NARRATIONDESC, (obj.MAKERIP == null) ? "" : obj.MAKERIP, (obj.BILLTOADDID == null) ? "" : obj.BILLTOADDID, (obj.VGUID == null) ? "" : obj.VGUID, (obj.CN_TYPE == null) ? "" : obj.CN_TYPE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_Final_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve CREDITNOTE Search records.</summary>
        /// <param name="CREDITNO">CREDITNO parameter.</param>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="JobNo">Job number.</param>
        /// <param name="Amount">Amount parameter.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="yearid">yearid parameter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CREDITNOTE_Search_List(string CREDITNO, string Client, string JobNo, string Amount, string FromDate, string ToDate, string cmp_code, string citycode, string TYPE, string yearid, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_CreditNote_Search", (CREDITNO != null) ? CREDITNO : "", (Client != null) ? Client : "", (JobNo != null) ? JobNo : "", (Amount != null) ? Amount : "", (FromDate != null) ? FromDate : "", (ToDate != null) ? ToDate : "", cmp_code, citycode, TYPE, (yearid != null) ? yearid : "" , Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CREDITNOTE_Search_List");
            }
            return Ok(ds);
        }
        /// <summary>Populate form with existing data for CRTNOTE Edit records.</summary>
        /// <param name="CRTNOTE">CRTNOTE parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CRTNOTE_Edit_Populate(string CRTNOTE, string cmp_code, string citycode, string makerid, string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CRTNOTE_EDITPOPUALTE", CRTNOTE, cmp_code, citycode, makerid, vguid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CRTNOTE_Edit_Populate");
            }
            return Ok(ds);
        }
        /// <summary>Perform creditNote Chk Inv NONINR records.</summary>
        /// <param name="invno">Invoice number.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_creditNote_Chk_Inv_NONINR(string invno, string cmp_code, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CHK_CREDITNOTE_NONINR", invno, cmp_code, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_creditNote_Chk_Inv_NONINR");
            }
            return Ok(ds);
        }
        /* JV start */
        /// <summary>Load page reference data for JV records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="PSTATUS">PSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_PAGELOAD(string cmp_code, string citycode, string citycode1, string PSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_PAGELOAD", cmp_code, citycode, citycode1, PSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_PAGELOAD");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update JV records.</summary>
        /// <param name="JVM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_JV_IU([FromBody]JournalVoucherMaster JVM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (JVM.ENTRYNO == " ")
            {
                spName = "USP_ACC_JV_INSERT";
            }
            else
            {
                spName = "USP_ACC_JV_UPDATE";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, JVM.CMPID, JVM.CMPCODE, JVM.CITYCODE1, JVM.CITYCODE, JVM.USERNAME, JVM.ENTRYNO, JVM.ENTRYDT, JVM.STATUS, JVM.NARRATION, JVM.VGUID, JVM.MAKER_ID, JVM.MAKER_IP, JVM.ACTION);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_JV_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }



        /// <summary>
        /// JV Request Excel upload.
        ///
        /// Saves the uploaded workbook under ~\DATA\JVRequest\CMPCODE\yyyyMM\ for audit,
        /// parses it with ExcelDataReader, then hands the rows to
        /// USP_ACC_JV_UPLOAD_VALIDATE_INS which validates and loads them into the same
        /// temp table the manual Add button uses. All-or-nothing: a rejected file
        /// inserts nothing and comes back with the failing row numbers.
        ///
        /// Modelled on UploadBnkReconcilFileV2 above.
        /// </summary>
        [HttpPost]
        public IHttpActionResult UploadJVRequestExcel()
        {
            const string SPNAME = "USP_ACC_JV_UPLOAD_VALIDATE_INS";

            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var status = HttpContext.Current.Request.Params["status"];
            var defEntryType = HttpContext.Current.Request.Params["def_entrytype"] ?? "";
            var defJobNo = HttpContext.Current.Request.Params["def_jobno"] ?? "";
            var defBillNo = HttpContext.Current.Request.Params["def_billno"] ?? "";
            var defDeptId = HttpContext.Current.Request.Params["def_deptid"] ?? "";

            string savedPath = null;
            try
            {
                if (file == null || file.ContentLength == 0)
                    return Ok(JvUploadError("No file was received."));

                string ext = Path.GetExtension(file.FileName ?? "").ToLowerInvariant();
                if (ext != ".xlsx" && ext != ".xls")
                    return Ok(JvUploadError("Only .xlsx and .xls files can be uploaded."));

                // Fail fast with a readable message if the proc has not been deployed,
                // rather than letting the DAL swallow the SqlException and return empty.
                object procId;
                using (SqlConnection chk = new SqlConnection(ConnectionString.getConnString()))
                {
                    chk.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT OBJECT_ID(@p)", chk))
                    {
                        cmd.Parameters.AddWithValue("@p", "dbo." + SPNAME);
                        procId = cmd.ExecuteScalar();
                    }
                }
                if (procId == null || procId == DBNull.Value)
                    return Ok(JvUploadError("Stored procedure " + SPNAME
                        + " does not exist on this database. Run the script in _DB_FIX, then retry."));

                // ---- archive the file (the audit requirement)
                string baseDir = System.Configuration.ConfigurationManager.AppSettings["JVUploadPath"];
                if (string.IsNullOrEmpty(baseDir))
                    baseDir = HttpContext.Current.Server.MapPath("~") + "\\DATA\\JVRequest\\";
                string dir = Path.Combine(baseDir, (cmpcode ?? "NA"), DateTime.Now.ToString("yyyyMM"));
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                // timestamp prefix: never collides, so no "file already exists" rejection
                string safeName = Path.GetFileName(file.FileName);
                savedPath = Path.Combine(dir, DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + safeName);
                file.SaveAs(savedPath);

                // ---- parse
                string parseError;
                string rowsXml = BuildJvRowsXml(savedPath, ext, out parseError);
                if (parseError != null)
                {
                    MoveJvFileToFailed(savedPath, dir);
                    return Ok(JvUploadError(parseError));
                }

                DataSet ds = new DataSet();
                DAL objDal = new DAL();
                try
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                        SPNAME, rowsXml, vguid, cmpcode, citycode, citycode1, cmpid, status,
                        defEntryType, defJobNo, defBillNo, defDeptId);
                }
                finally { objDal.Dispose(); }

                // Keep a copy of anything the proc rejected, so the file can be inspected.
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0
                    && ds.Tables[1].Rows[0]["STATUS"].ToString().StartsWith("104"))
                {
                    MoveJvFileToFailed(savedPath, dir);
                }
                return Ok(ds);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/UploadJVRequestExcel");
                if (savedPath != null)
                {
                    try { MoveJvFileToFailed(savedPath, Path.GetDirectoryName(savedPath)); }
                    catch { /* keeping a copy is best-effort */ }
                }
                return Ok(JvUploadError("Upload failed: " + ex.Message));
            }
        }

        /// <summary>Reads the JVLines sheet into the XML the proc expects.</summary>
        private string BuildJvRowsXml(string path, string ext, out string error)
        {
            error = null;
            var sb = new StringBuilder();
            sb.Append("<ROWS>");
            int dataRows = 0;

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ext == ".xls"
                    ? ExcelReaderFactory.CreateBinaryReader(stream)
                    : ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                var dsRaw = reader.AsDataSet();
                if (dsRaw == null || dsRaw.Tables.Count == 0)
                { error = "The workbook is empty."; return null; }

                // the template names it JVLines; fall back to the first sheet
                DataTable sheet = dsRaw.Tables.Contains("JVLines") ? dsRaw.Tables["JVLines"] : dsRaw.Tables[0];
                if (sheet.Rows.Count < 2)
                { error = "The sheet has no data rows."; return null; }

                // Header lookup is trimmed + case-insensitive so column order may drift.
                var col = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                DataRow header = sheet.Rows[0];
                for (int c = 0; c < sheet.Columns.Count; c++)
                {
                    string h = (header[c] ?? "").ToString().Trim();
                    if (h.Length > 0 && !col.ContainsKey(h)) col[h] = c;
                }
                if (!col.ContainsKey("Particulars"))
                { error = "Column 'Particulars' was not found in row 1. Please use the downloaded template."; return null; }

                for (int r = 1; r < sheet.Rows.Count; r++)
                {
                    DataRow row = sheet.Rows[r];
                    string particulars = JvCell(row, col, "Particulars");
                    string debit = JvCell(row, col, "Debit");
                    string credit = JvCell(row, col, "Credit");

                    // the first fully blank row ends the data - this is what keeps the
                    // template's TOTAL row out of the upload
                    if (particulars.Length == 0 && debit.Length == 0 && credit.Length == 0) break;
                    if (particulars.Equals("TOTAL", StringComparison.OrdinalIgnoreCase)) break;

                    dataRows++;
                    sb.Append("<ROW>");
                    sb.Append("<ROWNO>").Append(r + 1).Append("</ROWNO>");   // Excel row number
                    // AccountCode wins when present: it is the formula-resolved code.
                    string acct = JvCell(row, col, "AccountCode");
                    if (acct.Length == 0 || acct.Equals("NOT FOUND", StringComparison.OrdinalIgnoreCase))
                        acct = particulars;
                    sb.Append("<ACCOUNT>").Append(JvXml(acct)).Append("</ACCOUNT>");
                    sb.Append("<DEBIT>").Append(JvXml(debit)).Append("</DEBIT>");
                    sb.Append("<CREDIT>").Append(JvXml(credit)).Append("</CREDIT>");
                    sb.Append("<ENTRYTYPE>").Append(JvXml(JvCode(JvCell(row, col, "EntryType")))).Append("</ENTRYTYPE>");
                    sb.Append("<JOBNO>").Append(JvXml(JvCell(row, col, "JobNo"))).Append("</JOBNO>");
                    sb.Append("<BILLNO>").Append(JvXml(JvCell(row, col, "BillNo"))).Append("</BILLNO>");
                    sb.Append("<DEPARTMENT>").Append(JvXml(JvCell(row, col, "Department"))).Append("</DEPARTMENT>");
                    sb.Append("<ITEMCODE>").Append(JvXml(JvCode(JvCell(row, col, "ItemCode")))).Append("</ITEMCODE>");
                    sb.Append("<NARRATION>").Append(JvXml(JvCell(row, col, "LineNarration"))).Append("</NARRATION>");
                    sb.Append("</ROW>");
                }
            }
            sb.Append("</ROWS>");

            if (dataRows == 0) { error = "No data rows were found in the sheet."; return null; }
            return sb.ToString();
        }

        private static string JvCell(DataRow row, Dictionary<string, int> col, string name)
        {
            int idx;
            if (!col.TryGetValue(name, out idx)) return "";
            if (idx >= row.Table.Columns.Count) return "";
            object v = row[idx];
            if (v == null || v == DBNull.Value) return "";
            if (v is double) return ((double)v).ToString(System.Globalization.CultureInfo.InvariantCulture);
            if (v is decimal) return ((decimal)v).ToString(System.Globalization.CultureInfo.InvariantCulture);
            return v.ToString().Trim();
        }

        /// <summary>Template dropdowns read "CODE | Description"; the proc wants the code.</summary>
        private static string JvCode(string v)
        {
            if (string.IsNullOrEmpty(v)) return "";
            int p = v.IndexOf('|');
            return p > 0 ? v.Substring(0, p).Trim() : v.Trim();
        }

        private static string JvXml(string v)
        {
            if (string.IsNullOrEmpty(v)) return "";
            return v.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }

        private static void MoveJvFileToFailed(string savedPath, string dir)
        {
            try
            {
                if (!File.Exists(savedPath)) return;
                string failedDir = Path.Combine(dir, "_failed");
                if (!Directory.Exists(failedDir)) Directory.CreateDirectory(failedDir);
                string keep = Path.Combine(failedDir, Path.GetFileName(savedPath));
                if (File.Exists(keep)) File.Delete(keep);
                File.Move(savedPath, keep);
            }
            catch { /* keeping a copy is best-effort */ }
        }

        /// <summary>Error shaped exactly like the proc's own output so the UI has one code path.</summary>
        private static DataSet JvUploadError(string message)
        {
            DataSet ds = new DataSet();
            DataTable errs = new DataTable();
            errs.Columns.Add("ROWNO", typeof(int));
            errs.Columns.Add("ACCOUNTCODE", typeof(string));
            errs.Columns.Add("ERRORTEXT", typeof(string));
            errs.Rows.Add(0, "", message);
            ds.Tables.Add(errs);

            DataTable st = new DataTable();
            st.Columns.Add("TOTDEBIT", typeof(string));
            st.Columns.Add("TOTCREDIT", typeof(string));
            st.Columns.Add("STATUS", typeof(string));
            st.Columns.Add("STATUSTEXT", typeof(string));
            st.Rows.Add("0", "0", "104#" + message, "Upload rejected");
            ds.Tables.Add(st);
            return ds;
        }

        /// <summary>
        /// Serves the blank JV Request upload template.
        ///
        /// FIRST CUT: streams the committed template from ~\DATA\JVRequest\_template\.
        /// The plan is to generate it per company from USP_ACC_JV_PAGELOAD (ClosedXML)
        /// so the account and department lists can never go stale; until then, refresh
        /// the file in that folder whenever the masters change.
        /// </summary>
        [HttpGet]
        public HttpResponseMessage DownloadJVRequestTemplate(string cmpcode = "", string citycode = "", string citycode1 = "")
        {
            try
            {
                string baseDir = System.Configuration.ConfigurationManager.AppSettings["JVUploadPath"];
                if (string.IsNullOrEmpty(baseDir))
                    baseDir = HttpContext.Current.Server.MapPath("~") + "\\DATA\\JVRequest\\";
                string path = Path.Combine(baseDir, "_template", "JV_Request_Upload_Template.xlsx");

                if (!File.Exists(path))
                {
                    var missing = Request.CreateResponse(HttpStatusCode.NotFound);
                    missing.Content = new StringContent(
                        "Template not found on the server. Place JV_Request_Upload_Template.xlsx in "
                        + Path.GetDirectoryName(path));
                    return missing;
                }

                var result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(File.ReadAllBytes(path));
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                result.Content.Headers.ContentDisposition =
                    new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "JV_Request_Template_" + cmpcode + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"
                    };
                return result;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/DownloadJVRequestTemplate");
                var err = Request.CreateResponse(HttpStatusCode.InternalServerError);
                err.Content = new StringContent("Could not build the template: " + ex.Message);
                return err;
            }
        }

        /// <summary>Insert or update JV TMP records.</summary>
        /// <param name="JVD">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_JV_TMP_IU([FromBody]JournalVoucherDtls JVD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (JVD.ISOLDENTRY == "1")
            {
                spName = "USP_ACC_JV_TMP_IU_OLD";
            }
            else
            {
                spName = "USP_ACC_JV_TMP_IU";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, JVD.ID, JVD.ENTRYNO, JVD.CLIENT, (JVD.JOBNO != null) ? JVD.JOBNO : "", (JVD.BILLNO != null) ? JVD.BILLNO : "", JVD.JV_TRN, JVD.DEBIT, JVD.CREDIT, JVD.ENTRYTYPE, (JVD.NARRATION != null) ? JVD.NARRATION : "", JVD.ITEMCODE, (JVD.DEPTID != null) ? JVD.DEPTID : "", JVD.VGUID, JVD.ACCOUNT_NAME, JVD.ITEM, (JVD.DEPARTMENT != null) ? JVD.DEPARTMENT : "", JVD.JV_DTLS_ID, JVD.STATUS, JVD.ISJOBREPORT, JVD.ITEM_DATAVALUE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_JV_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Delete JV TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="JV_DTLS_ID">JV DTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_TMP_DEL(string ID, string VGUID, string JV_DTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_TMP_DEL", ID, VGUID, JV_DTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_TMP_DEL");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for JV records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_RESET");
            }
            return Ok(ds);
        }


        /// <summary>Search and retrieve JV records.</summary>
        /// <param name="CODE">CODE parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="TYPEVALUE">TYPEVALUE parameter.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="Details_flag">Details flag parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <param name="FIN_STARTDATE">Start date for the date range filter.</param>
        /// <param name="FIN_ENDDATE">End date for the date range filter.</param>
        /// <param name="USERID">USERID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_SEARCH(string CODE, string FROMDATE, string TODATE, string TYPEVALUE, string TYPE, string Details_flag, string CITYCODE, string CMP_CODE, string YEAR_ID, string FIN_STARTDATE, string FIN_ENDDATE, string USERID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (TYPE == "JV")
            {
                spName = "usp_Acct_N_JV_Search_new";
            }
            else
            {
                spName = "USP_ACC_JV_SEARCH_REQ";
            }
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, (CODE != null) ? CODE : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (TYPEVALUE != null) ? TYPEVALUE : "", (TYPE != null) ? TYPE : "", (Details_flag != null) ? Details_flag : "", CITYCODE, CMP_CODE, YEAR_ID, FIN_STARTDATE, FIN_ENDDATE, USERID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_SEARCH");
            }
            return Ok(ds);
        }


        /// <summary>Retrieve print/view data for JV records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_View(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_VIEW", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_View");
            }
            return Ok(ds);
        }

        /// <summary>Validate JV JOBNO records.</summary>
        /// <param name="JVJOBNO">Job number.</param>
        /// <param name="JVACCOUNT">JVACCOUNT parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_JOBNO_VALIDATE(string JVJOBNO, string JVACCOUNT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_VALIDATE_JOBNO", JVJOBNO, JVACCOUNT);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_JOBNO_VALIDATE");
            }
            return Ok(ds);
        }
        /*   Added on 07092020 for BankReceipt */

        /// <summary>Load page reference data for CASHBOOK BRBPCRCPCE records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="PSTATUS">PSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_BRBPCRCPCE_PAGELOAD(string CMPCODE, string CITYCODE, string CITYCODE1, string PSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_PAGELOAD", CMPCODE, CITYCODE, CITYCODE1, PSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_BRBPCRCPCE_PAGELOAD");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update BRBPCRCPCE records.</summary>
        /// <param name="BR">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BRBPCRCPCE_IU([FromBody]BRBPCRCPCE BR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (BR.ENTRYNO == " ")
            {
                spName = "USP_ACC_BRBPCRCPCE_INSERT";
            }
            else
            {
                spName = "USP_ACC_BRBPCRCPCE_UPDATE";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, BR.CMPID, BR.CMPCODE, BR.CITYCODE1, BR.CITYCODE, BR.USERNAME, BR.ENTRYNO, BR.ENTRYDT, BR.STATUS, (BR.OURBANK != null) ? BR.OURBANK : "", (BR.OURBANKNM != null) ? BR.OURBANKNM : "", BR.CHEQUETYPE, (BR.CHEQUENO != null) ? BR.CHEQUENO : "", (BR.CHEQUEDT != null) ? BR.CHEQUEDT : "", (BR.BANK != null) ? BR.BANK : "", BR.NARRATION, BR.ACTUALAMOUNT, BR.VGUID, BR.MAKER_ID, BR.MAKER_IP, BR.NOTOVERFLAG, BR.ACTION, BR.PAYEENAME, (BR.BANKREFNO != null) ? BR.BANKREFNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Delete BRBPCRCPCE TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_BANKDTLS_ID">ACC BANKDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_TMP_DEL(string ID, string VGUID, string ACC_BANKDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_TMP_DEL", ID, VGUID, ACC_BANKDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_TMP_DEL");
            }
            return Ok(ds);
        }



        /// <summary>Insert or update BRBPCRCPCE TMP records.</summary>
        /// <param name="BRD">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BRBPCRCPCE_TMP_IU([FromBody]BRBPCRCPCEDTL BRD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string spName = "";
            if (BRD.ISOLDENTRY == "1")
            {
                spName = "USP_ACC_BRBPCRCPCE_TMP_IU_OLD";
            }
            else
            {
                spName = "USP_ACC_BRBPCRCPCE_TMP_IU";
            }
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, BRD.ID, BRD.ENTRYNO, BRD.CLIENT, (BRD.JOBNO != null) ? BRD.JOBNO : "", (BRD.BILLNO != null) ? BRD.BILLNO : "", BRD.DEDUCTION, BRD.AMOUNT, BRD.ENTRYTYPE, BRD.EMP_CODE, BRD.USERNAME, BRD.CRPARENTENTRYNO, (BRD.NARRATION != null) ? BRD.NARRATION : "", BRD.IS_NOT_EDIT_ABLE, BRD.ITEMCODE, (BRD.DEPTID != null) ? BRD.DEPTID : "", BRD.VGUID, BRD.ACCOUNT_NAME, BRD.ITEM, (BRD.DEPARTMENT != null) ? BRD.DEPARTMENT : "", BRD.ACC_BANKDTLS_ID, BRD.STATUS, BRD.ISJOBREPORT, BRD.EMP_CODE_VALUE, BRD.EMP_CODE_TEXT, BRD.ITEM_DATAVALUE, BRD.CMPCODE, BRD.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for BRBPCRCPCE records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_RESET");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for BRBPCRCPCE records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_View(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_VIEW", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_View");
            }
            return Ok(ds);
        }


        /// <summary>Search and retrieve CASHBOOK records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="CHEQUENO">CHEQUENO parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="JOBNO">Job number.</param>
        /// <param name="AMOUNT">AMOUNT parameter.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEARID">YEARID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_SEARCH(string CMPCODE, string CITYCODE, string ENTRYNO, string FROMDATE, string TODATE, string CLIENT, string CHEQUENO, string OURBANK, string JOBNO, string AMOUNT, string STATUS, string MODE, string DISPLAYTYPE, string YEARID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_Search1", (CMPCODE != null) ? CMPCODE : "", CITYCODE, (ENTRYNO != null) ? ENTRYNO : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (CLIENT != null) ? CLIENT : "", (CHEQUENO != null) ? CHEQUENO : "", (OURBANK != null) ? OURBANK : "", (JOBNO != null) ? JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (STATUS != null) ? STATUS : "", (MODE != null) ? MODE : "", (DISPLAYTYPE != null) ? DISPLAYTYPE : "", (YEARID != null) ? YEARID : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_SEARCH");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for CASHBOOK RCP records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="CHEQUENO">CHEQUENO parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="JOBNO">Job number.</param>
        /// <param name="AMOUNT">AMOUNT parameter.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEARID">YEARID parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_RCP_PRINT(string CMPCODE, string CITYCODE, string ENTRYNO, string FROMDATE, string TODATE, string CLIENT, string CHEQUENO, string OURBANK, string JOBNO, string AMOUNT, string STATUS, string MODE, string DISPLAYTYPE, string YEARID,string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CP_REQUEST_SEARCH", (CMPCODE != null) ? CMPCODE : "", CITYCODE, (ENTRYNO != null) ? ENTRYNO : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (CLIENT != null) ? CLIENT : "", (CHEQUENO != null) ? CHEQUENO : "", (OURBANK != null) ? OURBANK : "", (JOBNO != null) ? JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (STATUS != null) ? STATUS : "", (MODE != null) ? MODE : "", (DISPLAYTYPE != null) ? DISPLAYTYPE : "", (YEARID != null) ? YEARID : "", cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_RCP_PRINT");
            }
            return Ok(ds);
        }
        /*----------------------*/
        /// <summary>Perform CASHBOOK AUTOGENERATE BIND records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="FRDT">Start date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CASHBOOK_AUTOGENERATE_BIND(string CMPCODE, string CITYCODE, string FRDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_CE_GetDataForGenerateCR", CMPCODE  , CITYCODE,FRDT);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/CASHBOOK_AUTOGENERATE_BIND");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve FillCE Employees records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult FillCE_Employees(string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CE_FillEmployees", CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/FillCE_Employees");
            }
            return Ok(ds);
        }
        /// <summary>Perform CE STAEMENT records.</summary>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <param name="usr_StartDate">Start date for the date range filter.</param>
        /// <param name="usr_EndDate">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ACCTCODE">ACCTCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CE_STAEMENT(string Fin_StartDate, string Fin_EndDate, string usr_StartDate, string usr_EndDate, string CMPCODE, string CITYCODE, string ACCTCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            //WithJob ALL FILES ARE COMPULSORY 
            //WITH CRT REPORT DISCUSS AFTER WARDS
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_EmpStatement_Expenses", Fin_StartDate, Fin_EndDate, usr_StartDate, usr_EndDate,CMPCODE, CITYCODE, ACCTCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/CE_STAEMENT");
            }
            return Ok(ds);
        }
        /// <summary>Perform EMPLOYEE STAEMENT records.</summary>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <param name="usr_StartDate">Start date for the date range filter.</param>
        /// <param name="usr_EndDate">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EMPLOYEE_STAEMENT(string Fin_StartDate, string Fin_EndDate, string usr_StartDate, string usr_EndDate, string CMPCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            //WithJob ALL FILES ARE COMPULSORY 
            //WITH CRT REPORT DISCUSS AFTER WARDS
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_EmployeeStatement", Fin_StartDate, Fin_EndDate, usr_StartDate, usr_EndDate, CMPCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/EMPLOYEE_STAEMENT");
            }
            return Ok(ds);
        }
        
        /// <summary>Perform BRBPCRCPCE CE AutoGenerateCR records.</summary>
        /// <param name="BRD">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BRBPCRCPCE_CE_AutoGenerateCR([FromBody]BRBPCRCPCE BRD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();            
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_CE_AutoGenerateCR", BRD.CMPID, BRD.CMPCODE, BRD.CITYCODE1, BRD.CITYCODE, BRD.USERNAME, (BRD.ENTRYNO != null) ? BRD.ENTRYNO : "", (BRD.ENTRYDT != null) ? BRD.ENTRYDT : "", BRD.STATUS, (BRD.NARRATION != null) ? BRD.NARRATION : "", BRD.MAKER_IP, BRD.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_CE_AutoGenerateCR");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /*----------------Auto CR----------------------*/
        /// <summary>Populate form with existing data for RECEIPT POPULATE CLIENTBILL records.</summary>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RECEIPT_POPULATE_CLIENTBILL(string CLIENT, string FINSTARTDATE, string FINENDDATE, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCOUNTS_RECEIPT_POPULATE_CLIENTBILL", (CLIENT != null) ? CLIENT : "", (FINSTARTDATE != null) ? FINSTARTDATE : "", (FINENDDATE != null) ? FINENDDATE : "", (CMPCODE != null) ? CMPCODE : "", CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RECEIPT_POPULATE_CLIENTBILL");
            }
            return Ok(ds);
        }


        /// <summary>Perform RECEIPT BIND CLIENTBILL records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RECEIPT_BIND_CLIENTBILL(string VGUID, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BR_BILLPOPULATE", VGUID, CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RECEIPT_BIND_CLIENTBILL");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update BR BLHELP TMP records.</summary>
        /// <param name="BRD">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_BR_BLHELP_TMP_IU([FromBody]BRBPCRCPCEDTL BRD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
              try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BR_BLHELP_TMP_IU", BRD.CLIENT, BRD.ITEMCODE, BRD.STATUS, BRD.CMPCODE, BRD.CITYCODE, BRD.VGUID, BRD.USERNAME, BRD.STRINGTEXT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_BR_BLHELP_TMP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Perform CASHBOOK VALIDATECHQ records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CHQNO">CHQNO parameter.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_VALIDATECHQ(string CMPCODE, string CITYCODE, string CHQNO, string STATUS, string OURBANK, string ENTRYNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Acc_CAshBook_ChequeValidate", CMPCODE, CITYCODE, (CHQNO != null) ? CHQNO : "", STATUS, OURBANK, (ENTRYNO != null) ? ENTRYNO : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RECEIPT_POPULATE_CLIENTBILL");
            }
            return Ok(ds);
        }

        /// <summary>Validate CASHBOOK BILLNO VALIDATION records.</summary>
        /// <param name="BILLNO">BILLNO parameter.</param>
        /// <param name="ACC_CODE">ACC CODE parameter.</param>
        /// <param name="ENTRYTYPE">ENTRYTYPE parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_BILLNO_VALIDATION(string BILLNO, string ACC_CODE, string ENTRYTYPE, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_Acc_CashBank_BillNo_Validation", BILLNO, ACC_CODE, ENTRYTYPE, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_BILLNO_VALIDATION");
            }
            return Ok(ds);
        }

        /*CR*/
        /// <summary>Perform CASHBOOK CR CHECKISAUTOGENERATED records.</summary>
        /// <param name="Entryno">Entryno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_CR_CHECKISAUTOGENERATED(string Entryno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_CR_CheckIsAutoGenerated", Entryno);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_CR_CHECKISAUTOGENERATED");
            }
            return Ok(ds);
        }

        //  Computerised Cheque

        /// <summary>Perform CHEQUESTOCK FILLOURBANK records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHEQUESTOCK_FILLOURBANK(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_ChequeStock_FillOurbank", cmpcode,citycode,citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CHEQUESTOCK_FILLOURBANK");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update CHEQUESTOCK records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CHEQUESTOCK_IU([FromBody]ChequeStock obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();


            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_ChequeStock_Add", obj.CHQ_CREATER_ID,obj.USER_IP,obj.CHQ_CREATED_DATE,obj.CMP_CODE,obj.CITY_CODE,obj.OURBANK,obj.STCHEQUENO,obj.ENDCHEQUENO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_CHEQUESTOCK_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of CHEQUESTOCK records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CHEQUNO">CHEQUNO parameter.</param>
        /// <param name="BANK">BANK parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHEQUESTOCK_LIST(string CMPCODE, string CITYCODE, string CHEQUNO, string BANK)//BANK=''
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_ChequeStock_List", CMPCODE, CITYCODE, (CHEQUNO == null) ? "" : CHEQUNO, (BANK == null) ? "" : BANK);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CHEQUESTOCK_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for CASHBOOK BRBPCRCPCE PAGELOAD RBP records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="PSTATUS">PSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CASHBOOK_BRBPCRCPCE_PAGELOAD_RBP(string CMPCODE, string CITYCODE, string CITYCODE1, string PSTATUS)//CC
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_PAGELOAD_RBP", CMPCODE, CITYCODE, CITYCODE1, PSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CASHBOOK_BRBPCRCPCE_PAGELOAD_RBP");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve ReqBP records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="CHEQUENO">CHEQUENO parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="JOBNO">Job number.</param>
        /// <param name="AMOUNT">AMOUNT parameter.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEARID">YEARID parameter.</param>
        /// <param name="Cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ReqBP_SEARCH(string CMPCODE, string CITYCODE, string ENTRYNO, string FROMDATE, string TODATE, string CLIENT, string CHEQUENO, string OURBANK, string JOBNO, string AMOUNT, string STATUS, string MODE, string DISPLAYTYPE, string YEARID,string Cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_BP_CMP_Search", (CMPCODE != null) ? CMPCODE : "", CITYCODE, (ENTRYNO != null) ? ENTRYNO : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (CLIENT != null) ? CLIENT : "", (CHEQUENO != null) ? CHEQUENO : "", (OURBANK != null) ? OURBANK : "", (JOBNO != null) ? JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (STATUS != null) ? STATUS : "", (MODE != null) ? MODE : "", (DISPLAYTYPE != null) ? DISPLAYTYPE : "", (YEARID != null) ? YEARID : "",Cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ReqBP_SEARCH");
            }
            return Ok(ds);
        }
        
            /// <summary>Search and retrieve BP SEARCH DAY records.</summary>
            /// <param name="CMPCODE">Company code identifier.</param>
            /// <param name="CITYCODE">City/branch code.</param>
            /// <param name="ENTRYNO">ENTRYNO parameter.</param>
            /// <param name="FROMDATE">Start date for the date range filter.</param>
            /// <param name="TODATE">End date for the date range filter.</param>
            /// <param name="CLIENT">Client/exporter code.</param>
            /// <param name="CHEQUENO">CHEQUENO parameter.</param>
            /// <param name="OURBANK">OURBANK parameter.</param>
            /// <param name="JOBNO">Job number.</param>
            /// <param name="AMOUNT">AMOUNT parameter.</param>
            /// <param name="STATUS">STATUS parameter.</param>
            /// <param name="MODE">Operation mode or filter type.</param>
            /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
            /// <param name="YEARID">YEARID parameter.</param>
            /// <returns>DataSet with the requested data serialized as JSON.</returns>
            [HttpGet]
        public IHttpActionResult ACC_BP_SEARCH_DAY(string CMPCODE, string CITYCODE, string ENTRYNO, string FROMDATE, string TODATE, string CLIENT, string CHEQUENO, string OURBANK, string JOBNO, string AMOUNT, string STATUS, string MODE, string DISPLAYTYPE, string YEARID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_Search1_Day", (CMPCODE != null) ? CMPCODE : "", CITYCODE, (ENTRYNO != null) ? ENTRYNO : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (CLIENT != null) ? CLIENT : "", (CHEQUENO != null) ? CHEQUENO : "", (OURBANK != null) ? OURBANK : "", (JOBNO != null) ? JOBNO : "", (AMOUNT != null) ? AMOUNT : "", (STATUS != null) ? STATUS : "", (MODE != null) ? MODE : "", (DISPLAYTYPE != null) ? DISPLAYTYPE : "", (YEARID != null) ? YEARID : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ReqBP_SEARCH");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for CMPBP Fill Vouchers Authorisation records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="status">status parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CMPBP_Fill_Vouchers_Authorisation(string cmpid,string CMPCODE,  string citycode, string status)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CMPBP_Fill_Vouchers_Authorisation", cmpid  , CMPCODE,citycode, (status != null) ? status : "" );

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CMPBP_Fill_Vouchers_Authorisation");
            }
            return Ok(ds);
        }
        /// <summary>Perform CMPBP Assign Authorisation ChqPrint records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="status">status parameter.</param>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <param name="CHKAuthorityFlag">CHKAuthority Flag parameter.</param>
        /// <param name="AuthorisationDt">Authorisation Dt parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CMPBP_Assign_Authorisation_ChqPrint(string cmpid, string CMPCODE, string citycode, string status, string EntryNo, string CHKAuthorityFlag, string AuthorisationDt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CMPBP_Assign_Authorisation_ChqPrint",   CMPCODE, citycode, status, EntryNo, CHKAuthorityFlag, AuthorisationDt,cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_Assign_Authorisation_ChqPrint");
            }
            return Ok(ds);
        }
        /// <summary>Perform CMPBP REJECT BPREQUEST records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="status">status parameter.</param>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <param name="CHKAuthorityFlag">CHKAuthority Flag parameter.</param>
        /// <param name="AuthorisationDt">Authorisation Dt parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CMPBP_REJECT_BPREQUEST(string cmpid, string CMPCODE, string citycode, string status, string EntryNo, string CHKAuthorityFlag, string AuthorisationDt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CMPBP_REJECT_BPREQUEST", CMPCODE, citycode, status, EntryNo, CHKAuthorityFlag, AuthorisationDt, cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_REJECT_BPREQUEST");
            }
            return Ok(ds);
        }

	/// <summary>Perform CMPBP REJECT BPView records.</summary>
	/// <param name="cmpid">Primary key of the company.</param>
	/// <param name="CMPCODE">Company code identifier.</param>
	/// <param name="citycode">City/branch code.</param>
	/// <param name="status">status parameter.</param>
	/// <returns>DataSet with the requested data serialized as JSON.</returns>
	[HttpGet]
        public IHttpActionResult Acc_CMPBP_REJECT_BPView(string cmpid, string CMPCODE, string citycode, string status)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CMPBP_FILL_BPREQUEST_REJECTED_LIST", cmpid, CMPCODE, citycode, status);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_REJECT_BPView");
            }
            return Ok(ds);
        }
	/// <summary>Perform CMPBP BPView records.</summary>
	/// <param name="EntryNo">Entry No parameter.</param>
	/// <returns>DataSet with the requested data serialized as JSON.</returns>
	[HttpGet]
        public IHttpActionResult Acc_CMPBP_BPView(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_COMPCHEQ_REQUEST_BP_VIEW",EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_BPView");
            }
            return Ok(ds);
        }

	/// <summary>Perform CMPBP BPlISTView records.</summary>
	/// <param name="EntryNo">Entry No parameter.</param>
	/// <returns>DataSet with the requested data serialized as JSON.</returns>
	[HttpGet]
        public IHttpActionResult Acc_CMPBP_BPlISTView(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_COMP_CHEQUE_BP_REQUEST_BILL_VIEW",EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_BPView");
            }
            return Ok(ds);
        }
         
        /// <summary>Search and retrieve BP CMP CHEQUE SEARCH PRINTING records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="FROMDT">Start date for the date range filter.</param>
        /// <param name="TODAT">TODAT parameter.</param>
        /// <param name="OURBNK">OURBNK parameter.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="STATUStype">STATUStype parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CMP_CHEQUE_SEARCH_PRINTING(string CMPID, string CMPCODE, string CITYCODE, string ENTRYNO, string FROMDT,String TODAT ,String OURBNK,string TYPE,string STATUStype)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_BP_CMP_Cheque_Search_Printing_35", CMPID, CMPCODE, CITYCODE, (ENTRYNO != null) ? ENTRYNO : "" , (FROMDT != null) ? FROMDT : "" , (TODAT != null) ? TODAT : "" ,OURBNK, (TYPE != null) ? TYPE : "", (STATUStype != null) ? STATUStype : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CMP_CHEQUE_SEARCH_PRINTING");
            }
            return Ok(ds);
        }
        /// <summary>Perform BP CHEQUE AVAILABILITY records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CHEQUNO">CHEQUNO parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="PRINTCNTVAL">PRINTCNTVAL parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CHEQUE_AVAILABILITY( string CMPCODE, string CITYCODE1, string CHEQUNO,string OURBANK, String PRINTCNTVAL)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Cheque_Stock_Availability", CMPCODE, CITYCODE1, CHEQUNO, OURBANK,PRINTCNTVAL);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CHEQUE_AVAILABILITY");
            }
            return Ok(ds);
        }
        /// <summary>Generate BRBPCRCPCE PAYORDER records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="BPReqNo">BPReq No parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_PAYORDER_GENERATE(string CMPID ,string CMPCODE, string CITYCODE1, string OURBANK, String BPReqNo,string MAKERID,string MAKERIP)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_PAYORDER_GENERATE", CMPID, CMPCODE, CITYCODE1, OURBANK, BPReqNo, MAKERID, MAKERIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_PAYORDER_GENERATE");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of CMP BP CHEQUENO ASSIGNTOPRINT records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="chequNo">chequ No parameter.</param>
        /// <param name="count">count parameter.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="BPReqNo">BPReq No parameter.</param>
        /// <param name="Pstatus">Pstatus parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CMP_BP_CHEQUENO_ASSIGNTOPRINT_LIST( string CMPCODE, string CITYCODE1, string chequNo ,string count,string OURBANK, string BPReqNo,string Pstatus)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_ChequeNo_AssignedTo_Cmp_BPNo_For_Print_Cancel", CMPCODE, CITYCODE1, chequNo, count,OURBANK, BPReqNo, Pstatus);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CMP_BP_CHEQUENO_ASSIGNTOPRINT_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Perform CHEQUE STOCK HELPVIEW records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="OURBANK">OURBANK parameter.</param>
        /// <param name="chequeno">chequeno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHEQUE_STOCK_HELPVIEW(string CMPCODE, string CITYCODE1, string OURBANK, String chequeno)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CHEQUESTOCK_HELPVIEW", CMPCODE, CITYCODE1, (chequeno != null) ? chequeno : "", OURBANK);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CHEQUE_STOCK_HELPVIEW");
            }
            return Ok(ds);
        }


        /// <summary>Load page reference data for CHEQUE PREVIEWPRINT records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="COUNT">COUNT parameter.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHEQUE_PREVIEWPRINT_PAGELOAD(string CMPID, string CMPCODE, string CITYCODE1, string COUNT , string ENTRYNO,string MAKERIP)//CHQUE STATUS
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CHEQUE_PREVIEWPRINT_PAGELOAD", CMPID,  CMPCODE,  CITYCODE1 , COUNT, ENTRYNO,MAKERIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CHEQUE_PREVIEWPRINT_PAGELOAD");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for CPJVPI REQUEST AUTHORISATION records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CPJVPI_REQUEST_AUTHORISATION_PAGELOAD(string CMPID, string CMPCODE, string CITYCODE, string STATUS, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_FILL_AUTHORISATION_PAGELOAD", CMPID, CMPCODE, CITYCODE, STATUS, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CPJVPI_REQUEST_AUTHORISATION_PAGELOAD");
            }
            return Ok(ds);
        }

        /// <summary>Perform CPJVPI REQUEST AUTHORISATION records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CPJVPI_REQUEST_AUTHORISATION(string CMPID, string CMPCODE, string CITYCODE, string STATUS, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_FILL_AUTHORISATION", CMPID, CMPCODE, CITYCODE, STATUS, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CPJVPI_REQUEST_AUTHORISATION");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update CPJVPI REQUEST Authorisation records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="JVREQNO">JVREQNO parameter.</param>
        /// <param name="AUTHORISATIONDT">AUTHORISATIONDT parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CPJVPI_REQUEST_Authorisation_Update(string CMPCODE, string CITYCODE1, string CITYCODE, string STATUS, string JVREQNO, string AUTHORISATIONDT, string CMPID, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_AUTHORISATION_UPDATE", CMPCODE, CITYCODE1, CITYCODE, STATUS, JVREQNO, (AUTHORISATIONDT != null) ? AUTHORISATIONDT : "", CMPID, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CPJVPI_REQUEST_Authorisation_Update");
            }
            return Ok(ds);
        }

        /// <summary>Perform CPJVPI REQUEST Authorisation REJECT records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="JVREQNO">JVREQNO parameter.</param>
        /// <param name="AUTHORISATIONDT">AUTHORISATIONDT parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CPJVPI_REQUEST_Authorisation_REJECT(string CMPCODE, string CITYCODE1, string CITYCODE, string STATUS, string JVREQNO, string AUTHORISATIONDT, string CMPID, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_AUTHORISATION_REJECTMULTI", CMPCODE, CITYCODE1, CITYCODE, STATUS, JVREQNO, (AUTHORISATIONDT != null) ? AUTHORISATIONDT : "", CMPID, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CPJVPI_REQUEST_Authorisation_REJECT");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update CPJVPI REQUEST Management records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="JVREQNO">JVREQNO parameter.</param>
        /// <param name="AUTHORISATIONDT">AUTHORISATIONDT parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CPJVPI_REQUEST_Management_UPDATE(string CMPCODE, string CITYCODE1, string CITYCODE, string STATUS, string JVREQNO, string AUTHORISATIONDT, string CMPID, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_MANAGEMENT_UPDATE", CMPCODE, CITYCODE1, CITYCODE, STATUS, JVREQNO, CMPID, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CPJVPI_REQUEST_Management_UPDATE");
            }
            return Ok(ds);
        }


        /// <summary>Perform CMPBP Cheque Report records.</summary>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="FromVal">From Val parameter.</param>
        /// <param name="ToVal">To Val parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CMPBP_Cheque_Report(string SearchType, string FromVal, string ToVal, string Type, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BP_CHEQUE_REPORT_NG", SearchType, FromVal, ToVal, Type, CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CMPBP_Cheque_Report");
            }
            return Ok(ds);
        }

        /// <summary>Perform  ChequePrintError Report records.</summary>
        /// <param name="ChequeNo">Cheque No parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="MakerIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc__ChequePrintError_Report(string ChequeNo, string cmpid, string MakerIP)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_CompCheque_RePrintCheque_AssignReqNo_NotGenerate_BPNo", ChequeNo, cmpid, MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_ChequePrintError_Report");
            }
            return Ok(ds);
        }


        /// <summary>Perform BP CMP CHEQUENO CANCEL records.</summary>
        /// <param name="USERID">USERID parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="Remark">Remark parameter.</param>
        /// <param name="MakerIP">IP address of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CMP_CHEQUENO_CANCEL(string USERID, string CMPCODE, string citycode, string ENTRYNO, string Remark, string MakerIP)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_BP_CMP_Chequeno_Cancel", USERID, CMPCODE, citycode, ENTRYNO, Remark, MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CMP_CHEQUENO_CANCEL");
            }
            return Ok(ds);
        }

        /// <summary>Perform BP CMP REQNO GET records.</summary>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CMP_REQNO_GET(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_BP_CMP_ReqNo_Get", EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CMP_REQNO_GET");
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve BP CMP CHEQUE SEARCH READYTO REPRINT records.</summary>
        /// <param name="USERID">USERID parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="OURBNK">OURBNK parameter.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="STATUSTYPE">STATUSTYPE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CMP_CHEQUE_SEARCH_READYTO_REPRINT(string USERID, string CMPCODE, string citycode, string ENTRYNO, string FROMDATE, string TODATE, string OURBNK, string TYPE, string STATUSTYPE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_BP_CMP_Cheque_Search_ReadyTo_Reprint", USERID, CMPCODE, citycode, (ENTRYNO != null) ? ENTRYNO : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", OURBNK, (TYPE != null) ? TYPE : "", (STATUSTYPE != null) ? STATUSTYPE : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CMP_CHEQUE_SEARCH_READYTO_REPRINT");
            }
            return Ok(ds);
        }




        /// <summary>Retrieve print/view data for BP CMP CHEQUE READYTO PRINT LIST 35 records.</summary>
        /// <param name="strentryNo">strentry No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BP_CMP_CHEQUE_READYTO_PRINT_LIST_35(string strentryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Cheque_ReadyTo_Print_List_35", strentryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BP_CMP_CHEQUE_READYTO_PRINT_LIST_35");
            }
            return Ok(ds);
        }



        /// <summary>Perform SETDEFAULT records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_SETDEFAULT(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_SETDEFA", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_SETDEFAULT");
            }
            return Ok(ds);
        }


        /*report start here*/
        /* Reports Register from Invoice to CN  */

        /// <summary>Search and retrieve fn Acc Rpt Invoice Register XL Search records.</summary>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_Invoice_Register_XL_Search_Register(string _FromDt, string _ToDt, string cmp_code, string citycode, string FINSTARTDATE, string FINENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_N_Inv_Search_Register", _FromDt, _ToDt, cmp_code, citycode, (FINSTARTDATE != null) ? FINSTARTDATE : "", (FINENDDATE != null) ? FINENDDATE : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_Invoice_Register_XL_Search_Register");
            }
            return Ok(ds);
        }

        /// <summary>EXPWOP register: foreign-currency invoices with receipt details for Excel export.</summary>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="FINSTARTDATE">Financial year start date.</param>
        /// <param name="FINENDDATE">Financial year end date.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_EXPWOP_Register_XL(string _FromDt, string _ToDt, string cmp_code, string citycode, string FINSTARTDATE, string FINENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Acc_Rpt_EXPWOP_Register", _FromDt, _ToDt, cmp_code, citycode, (FINSTARTDATE != null) ? FINSTARTDATE : "", (FINENDDATE != null) ? FINENDDATE : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_EXPWOP_Register_XL");
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve fn Acc Rpt Invoice Register ActDetail XL Search Acct details records.</summary>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_Invoice_Register_ActDetail_XL_Search_Acct_details(string _FromDt, string _ToDt, string cmp_code, string citycode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Acct_Invoice_Register_Acct_Detail", _FromDt, _ToDt, cmp_code, citycode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_Invoice_Register_ActDetail_XL_Search_Acct_details");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for fn Acc Rpt CashBook Register XL Fill CashBook records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_CashBook_Register_XL_Fill_CashBook(string FromDate, string ToDate, string CmpCode, string CityCode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_Cashbook_Register_new", FromDate, ToDate, CmpCode, CityCode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_CashBook_Register_XL_Fill_CashBook");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for fn Acc Rpt Purchase Register XL records.</summary>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_Purchase_Register_XL_Fill(string _FromDt, string _ToDt, string cmp_code, string citycode, string FINSTARTDATE, string FINENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_Purchase_Register", _FromDt, _ToDt, cmp_code, citycode, FINSTARTDATE, FINENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_Purchase_Register_XL_Fill");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for fn Acc Rpt storage Register XL records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_storage_Register_XL_Fill(string FromDate, string ToDate, string CmpCode, string CityCode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_storage_Register", FromDate, ToDate, CmpCode, CityCode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_storage_Register_XL_Fill");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for fn frm Acc Rpt Brokerage Register XL records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_frm_Acc_Rpt_Brokerage_Register_XL_Fill(string FromDate, string ToDate, string CmpCode, string CityCode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Brokerage_Register", FromDate, ToDate, CmpCode, CityCode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_frm_Acc_Rpt_Brokerage_Register_XL_Fill");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve list of fn Acc Rpt CN Register AcctDetail XL records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_CN_Register_AcctDetail_XL(string FromDate, string ToDate, string CmpCode, string CityCode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Acct_CreditNote_Register_Act_Detail", FromDate, ToDate, CmpCode, CityCode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_CN_Register_AcctDetail_XL");
            }
            return Ok(ds);
        }

        /// <summary>Perform fn Acc Rpt Common CompanyDetails records.</summary>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult fn_Acc_Rpt_Common_CompanyDetails(string CmpCode, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Common_Company", CmpCode, CityCode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fn_Acc_Rpt_Common_CompanyDetails");
            }
            return Ok(ds);
        }
        //job profit
        /// <summary>Retrieve dropdown data for ACCOUNT FILL JOBPROFIT records.</summary>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="CityCode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_ACCOUNT_FILL_JOBPROFIT_Fill(string CmpCode, string CityCode, string CityCode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_ACCOUNT_FILL_JOBPROFIT", CmpCode, CityCode, CityCode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_ACCOUNT_FILL_JOBPROFIT_Fill");//frm_Acc_Rpt_Search_Jobwise_New.aspx single 
            }
            return Ok(ds);
        }
        
        /// <summary>Perform RPT JOBWISE ACCOUNT JOBNO records.</summary>
        /// <param name="ACCTCODE">ACCTCODE parameter.</param>
        /// <param name="BRANCH_CODE">BRANCH CODE parameter.</param>
        /// <param name="DATE_TYPE">DATE TYPE parameter.</param>
        /// <param name="FRDATE_U">FRDATE U parameter.</param>
        /// <param name="TODATE_U">End date for the date range filter.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCT_RPT_JOBWISE_ACCOUNT_JOBNO(string ACCTCODE, string BRANCH_CODE, string DATE_TYPE, string FRDATE_U, string TODATE_U,string CmpCode, string CityCode, string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_JOBWISE_ACCOUNT_JOBNO", ACCTCODE, BRANCH_CODE, DATE_TYPE, FRDATE_U, TODATE_U,CmpCode, CityCode, cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCT_RPT_JOBWISE_ACCOUNT_JOBNO");//frm_Acc_Rpt_Search_Jobwise_New.aspx single 
            }
            return Ok(ds);
        }

        /// <summary>Perform RPT JOBPROFITS NEW records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="JobNoFrom">Job number.</param>
        /// <param name="JobNoTo">Job number.</param>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="DateType">Date Type parameter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="con_code">con code parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_JOBPROFITS_NEW(string FromDate, string ToDate, string JobNoFrom, string JobNoTo, string SearchType, string DateType, string Mode, string citycode1, string CityCode, string CmpCode, string con_code)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_JOBPROFITS_NEW", FromDate, ToDate, (JobNoFrom != null) ? JobNoFrom : "", (JobNoTo != null) ? JobNoTo : "", SearchType, DateType, Mode, citycode1, CityCode, CmpCode, (con_code != null) ? con_code : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_JOBPROFITS_NEW");//frm_Acc_Rpt_Search_Jobwise_New.aspx single 
            }
            return Ok(ds);
        }

        /// <summary>Perform RPT JOBPROFITS JOBWISE records.</summary>
        /// <param name="JOBNO">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_JOBPROFITS_JOBWISE(string JOBNO  )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_JOB_PROFIT", JOBNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_JOBPROFITS_JOBWISE"); 
            }
            return Ok(ds);
        }
        /// <summary>Perform RPT MAWBPROFITS JOBWISE records.</summary>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="searchno">searchno parameter.</param>
        /// <param name="strVessel">str Vessel parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_MAWBPROFITS_JOBWISE(string SearchType, String searchno, String strVessel)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_REPORT_CONTAINER_MAWB_SUMMARY_NG", SearchType, searchno, (strVessel != null) ? strVessel : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_MAWBPROFITS_JOBWISE");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for CMP FillClient records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CMP_FillClient(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillClient_new", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CMP_FillClient");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of Rpt ClientOutstandingALL AllCITY records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="User_StartDate">Start date for the date range filter.</param>
        /// <param name="User_EndDate">End date for the date range filter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_ClientOutstandingALL_AllCITY_LIST(string ClientCode, string cmp_code, string User_StartDate, string User_EndDate, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_CLIENT_OUTSTANDING_ALLCITY_LIST", ClientCode, cmp_code, User_StartDate, User_EndDate, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_ClientOutstandingALL_AllCITY_LIST");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for Rpt TrialBalance With Advance Print GetAll records.</summary>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="STARTDATE">Start date for the date range filter.</param>
        /// <param name="ENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_With_Advance_Print_GetAll(string ClCode, string cmp_code, string citycode1, string STARTDATE, string ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_ClientOutstanding_AdvanceAll_35", ClCode, cmp_code, citycode1, STARTDATE, ENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_With_Advance_Print_GetAll");
            }
            return Ok(ds);
        }


        /// <summary>Retrieve print/view data for Rpt TrialBalance With Advance Print Get records.</summary>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="STARTDATE">Start date for the date range filter.</param>
        /// <param name="ENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_With_Advance_Print_Get(string ClCode, string FINSTARTDATE, string FINENDDATE, string cmp_code, string citycode1, string STARTDATE, string ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_ClientOutstanding_Advance_35", ClCode, FINSTARTDATE, FINENDDATE, cmp_code, citycode1, STARTDATE, ENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_With_Advance_Print_Get");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt ClientOutstandingList GetAll records.</summary>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="STARTDATE">Start date for the date range filter.</param>
        /// <param name="ENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_ClientOutstandingList_GetAll(string ClCode, string cmp_code, string citycode1, string STARTDATE, string ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_ClientOutstandingAll_35", ClCode, cmp_code, citycode1, STARTDATE, ENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_ClientOutstandingList_GetAll");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt ClientOutstandingList Get records.</summary>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="STARTDATE">Start date for the date range filter.</param>
        /// <param name="ENDDATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_ClientOutstandingList_Get(string ClCode, string FINSTARTDATE, string FINENDDATE, string cmp_code, string citycode1, string STARTDATE, string ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_ClientOutstandingNew_030409_35", ClCode, FINSTARTDATE, FINENDDATE, cmp_code, citycode1, STARTDATE, ENDDATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_ClientOutstandingList_Get");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt TrialBalance ClientOutstandingList Remark Add records.</summary>
        /// <param name="Remark">Remark parameter.</param>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="UserName">User Name parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_ClientOutstandingList_Remark_Add(string Remark, string ClCode, string cmp_code, string citycode, string UserName)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_Remark_Add", Remark, ClCode, cmp_code, citycode, UserName);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_ClientOutstandingList_Remark_Add");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt TrialBalance ClientOutstandingList Remark Get records.</summary>
        /// <param name="ClCode">Cl Code parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_ClientOutstandingList_Remark_Get(string ClCode, string cmp_code, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_Remark_Get", ClCode, cmp_code, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_ClientOutstandingList_Remark_Get");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt ClientOutstandingList Get AllCITY records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="User_StartDate">Start date for the date range filter.</param>
        /// <param name="User_EndDate">End date for the date range filter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <param name="cmpname">cmpname parameter.</param>
        /// <param name="subhead1">subhead1 parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Acc_Rpt_ClientOutstandingList_Get_AllCITY([FromUri]string ClientCode, string cmp_code, string User_StartDate, string User_EndDate, string Fin_StartDate, string Fin_EndDate,string cmpname ,string subhead1)

        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
           // var advmainhead_ary =[];
            string[] advmainhead_ary;

            
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_CLIENTOUTSTANDINGALL_CITY", ClientCode, cmp_code, User_StartDate, User_EndDate, Fin_StartDate, Fin_EndDate);

                StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Account_Statement_columnwise.html");
                string readFile = reader.ReadToEnd();
                string myString = string.Empty;
                string header1 = "", header2 = "", header3 = "";
                header1 = cmpname;
                header2 = "Account Statement with All Branch From " + User_StartDate + " To "  + User_EndDate;
                header3 = subhead1;
                StringBuilder sb = new StringBuilder();
                StringBuilder sb1 = new StringBuilder();

                StringBuilder sb2 = new StringBuilder();
                StringBuilder sb3 = new StringBuilder();
                myString = readFile;
            if (ds.Tables.Count > 0)
                {
                    advmainhead_ary = Convert.ToString(ds.Tables[2].Rows[0]["CITYNAME"]).Split(';');                   

                    foreach (var item in advmainhead_ary)
                    {
                        sb.AppendLine("<td class='xl65' colspan='2' style='border-right:.5pt solid windowtext;border-bottom:.5pt solid windowtext;' x:str> ");
                        sb.AppendLine(item);
                        sb.AppendLine("</td>");

                        sb1.AppendLine("<td class='xl65'   style='border-right:.5pt solid windowtext;border-bottom:.5pt solid windowtext;' x:str> Debit </td>");
                        sb1.AppendLine("<td class='xl65'   style='border-right:.5pt solid windowtext;border-bottom:.5pt solid windowtext;' x:str> Credit </td>");

                    }
                string str="";
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                    sb2.AppendLine("<tr height='24' style = 'height:14.40pt ' > ");
                    for (int j = 0; j < ds.Tables[1].Columns.Count; j++)
                        {
                            
                            if (j == 0) {
                                str = ds.Tables[1].Rows[i][j].ToString().Replace("<TD colspan=4>", "");
                                str = str.Replace("</TD>", "");

                                sb2.AppendLine("<td class='xl71' colspan='5' style='border-right:.5pt solid windowtext;border-bottom:.5pt solid windowtext;' x:str'> ");
                                sb2.AppendLine(str);
                                sb2.AppendLine("</td>");
                            }
                            else {
                                sb2.AppendLine("<td class='xl72' align='right' x:num'> ");
                                sb2.AppendLine(Convert.ToString(ds.Tables[1].Rows[i][j]));
                                sb2.AppendLine("</td>");
                            }
                        }
                    sb2.AppendLine("</tr>");

                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                    sb3.AppendLine("<tr height='24' style = 'height:14.40pt ' > ");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            
                            if (j <= 3)
                            {
                                sb3.AppendLine("<td class='xl75' x:str'> ");
                                sb3.AppendLine(Convert.ToString(ds.Tables[0].Rows[i][j]));
                                sb3.AppendLine("</td>");
                            }
                            else
                            {
                                sb3.AppendLine("<td class='xl75' align='right' x:num'> ");
                                sb3.AppendLine(Convert.ToString(ds.Tables[0].Rows[i][j]));
                                sb3.AppendLine("</td>");
                            }
                            
                        }
                    sb3.AppendLine("</tr>");
                }

                }
            myString = myString.Replace("[header1]", header1)
            .Replace("[header2]", header2)
            .Replace("[header3]", header3)
            .Replace("[header3]", header3)
            .Replace("[advmainhead]", Convert.ToString(sb))
            .Replace("[advmainhead1]", Convert.ToString(sb1))
            .Replace("[advmainrowdata1]", Convert.ToString(sb2))
             .Replace("[rowdatadynamic]", Convert.ToString(sb3));           

            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Accounts StatementAll With AllCity_"+ ClientCode+".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;

        }
        /// <summary>Retrieve list of Rpt ItemWise Statement records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="ItemCode">Item Code parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="city_code">city code parameter.</param>
        /// <param name="User_StartDate">Start date for the date range filter.</param>
        /// <param name="User_EndDate">End date for the date range filter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_ItemWise_Statement_List(string ClientCode, string ItemCode, string cmp_code, string city_code,string User_StartDate, string User_EndDate, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_ITEMSTATEMENT_LIST", ClientCode, ItemCode, cmp_code, city_code, User_StartDate, User_EndDate, Fin_StartDate, Fin_EndDate);
           }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_ItemWise_Statement_List");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of Rpt AccountWise ItemStatement records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="User_StartDate">Start date for the date range filter.</param>
        /// <param name="User_EndDate">End date for the date range filter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_AccountWise_ItemStatement_List(string ClientCode, string cmp_code, string User_StartDate, string User_EndDate, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_ACCOUTWISE_ITEMSTATEMENT_LIST", ClientCode, cmp_code, User_StartDate, User_EndDate, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_AccountWise_ItemStatement_List");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve Fill ITEMACCOUNT records.</summary>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="CityCode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_ITEMACCOUNT(string CmpCode, string CityCode, string CityCode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_ITEM_FILL_PAGELOAD", CmpCode, CityCode, CityCode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/Fill_ITEMACCOUNT");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve Fill ACCOUNTWISE ITEM records.</summary>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="CityCode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_ACCOUNTWISE_ITEM(string CmpCode, string CityCode, string CityCode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_ACCOUTWISE_ITEM_FILL_PAGELOAD", CmpCode, CityCode, CityCode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/Fill_ACCOUNTWISE_ITEM");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of Rpt NotOver records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_NotOver_List(string cmpcode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Acct_Cashook_BP_NotOver_List", cmpcode, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_NotOver_List");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt Receivable AdvFromClients records.</summary>
        /// <param name="Jobno">Job number.</param>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="All">All parameter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_Receivable_AdvFromClients(string Jobno, string ClientCode, string All, string cmpcode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_ADVANCE_FROM_CLIENT", (Jobno != null) ? Jobno : "", (ClientCode != null) ? ClientCode : "", (All != null) ? All : "", cmpcode, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_Receivable_AdvFromClients");
            }
            return Ok(ds);
        }
	/// <summary>Perform Rpt ClientOutstandingAll 35 Special ledger records.</summary>
	/// <param name="ClientCode">Client/exporter code.</param>
	/// <param name="cmpcode">Company code identifier.</param>
	/// <param name="UserStartDate">Start date for the date range filter.</param>
	/// <param name="UserEndDate">End date for the date range filter.</param>
	/// <param name="FinStartDate">Start date for the date range filter.</param>
	/// <param name="FinEndDate">End date for the date range filter.</param>
	/// <returns>DataSet with the requested data serialized as JSON.</returns>
	[HttpGet]
        public IHttpActionResult Acct_Rpt_ClientOutstandingAll_35_Special_ledger(string ClientCode,string cmpcode,string UserStartDate,string UserEndDate ,string FinStartDate,string FinEndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_ClientOutstandingAll_35_Special_ledger", ClientCode,cmpcode, UserStartDate, UserEndDate, FinStartDate, FinEndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acct_Rpt_ClientOutstandingAll_35_Special_ledger");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for FILL UNDERGROUP ACCOUNTS records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_FILL_UNDERGROUP_ACCOUNTS(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_FILL_UNDERGROUP_ACCOUNTS", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_FILL_UNDERGROUP_ACCOUNTS");
            }
            return Ok(ds);
        }
        /// <summary>Perform MIS INCOME TAX records.</summary>
        /// <param name="AccountCode">Account Code parameter.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_INCOME_TAX(string AccountCode, string FromDate, string ToDate, string cmpcode, string citycode, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_INCOME_TAX", AccountCode, FromDate, ToDate, cmpcode, citycode, mode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_INCOME_TAX");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for CMP FillClient records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CMP_FillClient(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillClient", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/CMP_FillClient");
            }
            return Ok(ds);
        }
        /// <summary>Perform RPT CLIENT OUTSTANDING ALLCITY ACCOUNT WISE records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_CLIENT_OUTSTANDING_ALLCITY_ACCOUNT_WISE(string ClientCode, string cmpcode, string FromDate, string ToDate, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_CLIENT_OUTSTANDING_ALLCITY_ACCOUNT_WISE", ClientCode, cmpcode, FromDate, ToDate, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_CLIENT_OUTSTANDING_ALLCITY_ACCOUNT_WISE");
            }
            return Ok(ds);
        }
        /// <summary>Perform MIS INVOICE DELAY records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_INVOICE_DELAY(string FromDate, string ToDate, string Mode, string cmpcode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_INVOICE_DELAY", FromDate, ToDate, Mode, cmpcode, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_INVOICE_DELAY");
            }
            return Ok(ds);
        }
        /// <summary>Perform MIS MAWB NET FREGHT records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="Branch">Branch parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_MAWB_NET_FREGHT(string cmpcode, string citycode1, string FromDate, string ToDate, string Branch)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_MAWB_NET_FREGHT", cmpcode, citycode1, FromDate, ToDate, (Branch != null) ? Branch : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_MAWB_NET_FREGHT");
            }
            return Ok(ds);

        }
        /// <summary>Perform MIS AIRFREIGHT STATEMENT records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_AIRFREIGHT_STATEMENT(string FromDate, string ToDate, string cmpcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_AIRFREIGHT_STATEMENT", FromDate, ToDate, cmpcode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_AIRFREIGHT_STATEMENT");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of RPT AIRFRT INVO SERACH records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_AIRFRT_INVO_SERACH_LIST(string FromDate, string ToDate, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_AIRFRT_INVO_SERACH_LIST", FromDate, ToDate, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_AIRFRT_INVO_SERACH_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Perform MIS SUNDRY EXPENSES records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="NoOfDays">No Of Days parameter.</param>
        /// <param name="Department">Department parameter.</param>
        /// <param name="cmpcitycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MIS_SUNDRY_EXPENSES(string FromDate, string ToDate, string NoOfDays, string Department, string cmpcitycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_SUNDRY_EXPENSES", FromDate, ToDate, NoOfDays, Department, cmpcitycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_MIS_SUNDRY_EXPENSES");
            }
            return Ok(ds);
        }
        /// <summary>Perform CMP FillGenralAccount records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CMP_FillGenralAccount(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillGenralAccount", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/CMP_FillGenralAccount");
            }
            return Ok(ds);
        }

        /// <summary>Perform ServiceTaxRegSupport records.</summary>
        /// <param name="Frmdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="FinFrndt">Fin Frndt parameter.</param>
        /// <param name="FinTodt">End date for the date range filter.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ServiceTaxRegSupport(string Frmdt, string Todt, string FinFrndt ,string FinTodt,string CMP_CODE,string CITYCODE1,string CMPID )
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
           // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA ,PKID ;
            try
            {
                SearchCTA = objRpt.SEARCHCRITERIA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE, CITYCODE1);
                SqlQueryPARA = objRpt.SQLQUERY_PARA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE, CITYCODE1);
                PKID=  objRpt.REPORT_LOG("47", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));
                
                drow = dtbl.NewRow();
                drow[0] =   PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);


            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ServiceTaxRegSupport");
            }
            return Ok(ds1);
        }
        /// <summary>Perform REPORT LOG SCRIPT records.</summary>
        /// <param name="fkID">fk ID parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult REPORT_LOG_SCRIPT(string fkID, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_SCRIPT_LIST", fkID,CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/REPORT_LOG_SCRIPT");
            }
            return Ok(ds);
        }
        /// <summary>Perform REPORT LOG DOWNLOAD records.</summary>
        /// <param name="fkID">fk ID parameter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult REPORT_LOG_DOWNLOAD(string fkID, string Mode, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_DOWNLOADED", fkID, Mode, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/REPORT_LOG_DOWNLOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform GstRegister records.</summary>
        /// <param name="Frmdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="FinFrndt">Fin Frndt parameter.</param>
        /// <param name="FinTodt">End date for the date range filter.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GstRegister(string Frmdt, string Todt, string FinFrndt, string FinTodt, string CMP_CODE, string CITYCODE, string CMPID)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                SearchCTA = objRpt.SEARCHCRITERIA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE, CITYCODE);
                SqlQueryPARA = objRpt.SQLQUERY_PARA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE, CITYCODE);
                PKID = objRpt.REPORT_LOG("50", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/GstRegister");
            }
            return Ok(ds1);
        }
        /// <summary>Perform Receivable AnyOneClient AllBranch records.</summary>
        /// <param name="ClientName">Client/exporter code.</param>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Receivable_AnyOneClient_AllBranch(string ClientName, string ClientCode, string CMP_CODE, string CMPID)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                SearchCTA = objRpt.SEARCHCRITERIA(ClientName);
                SqlQueryPARA = objRpt.SQLQUERY_PARA(ClientCode, CMP_CODE);
                PKID = objRpt.REPORT_LOG("3", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Receivable_AnyOneClient_AllBranch");
            }
            return Ok(ds1);
        }

        /// <summary>Perform MIS Receivable AnyOneClient Branch AsOn records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="ClientName">Client/exporter code.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="AsOnDate">As On Date parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_MIS_Receivable_AnyOneClient_Branch_AsOn(string ClientCode, string ClientName, string CMP_CODE, string AsOnDate, string CMPID)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                SearchCTA = ClientName + " OUTSTANDING - RECEIVABLE - ALL BRANCH - AS ON";
                SqlQueryPARA = objRpt.SQLQUERY_PARA(ClientCode, CMP_CODE, AsOnDate);
                PKID = objRpt.REPORT_LOG("38", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_MIS_Receivable_AnyOneClient_Branch_AsOn");
            }
            return Ok(ds1);
        }

        /// <summary>Perform Rpt Receivable AnyOneClient XL Client Oustanding ClientBill 35 Branch records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_Receivable_AnyOneClient_XL_Client_Oustanding_ClientBill_35_Branch(string ClientCode, string cmp_code, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_Outstanding_ClientBill_35_Branch", ClientCode, "", "", cmp_code, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_Receivable_AnyOneClient_XL_Client_Oustanding_ClientBill_35_Branch");
            }
            return Ok(ds);
        }


        /// <summary>Perform Rpt Receivable AgeWise XL 35 records.</summary>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="FinStartDate">Start date for the date range filter.</param>
        /// <param name="FinEndDate">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_Receivable_AgeWise_XL_35(string ClientCode, string FinStartDate, string FinEndDate, string cmpcode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_Outstanding_ClientBill_35_Agewise", ClientCode, FinStartDate, FinEndDate, cmpcode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_Receivable_AgeWise_XL_35");
            }
            return Ok(ds);
        }
        /// <summary>Perform Rpt TrialBalance DateWise records.</summary>
        /// <param name="Usr_StartDate">Start date for the date range filter.</param>
        /// <param name="Usr_EndDate">End date for the date range filter.</param>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="FinStartDate">Start date for the date range filter.</param>
        /// <param name="FinEndDate">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_DateWise(string Usr_StartDate, string Usr_EndDate, string ClientCode, string FinStartDate, string FinEndDate, string cmp_code, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_TRIALBALANCE_DATEWISE", Usr_StartDate, Usr_EndDate, FinStartDate, FinEndDate, cmp_code, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_DateWise");
            }
            return Ok(ds);
        }
        /// <summary>Perform Rpt TrialBalance DateWise All records.</summary>
        /// <param name="Usr_StartDate">Start date for the date range filter.</param>
        /// <param name="Usr_EndDate">End date for the date range filter.</param>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="FinStartDate">Start date for the date range filter.</param>
        /// <param name="FinEndDate">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_DateWise_All(string Usr_StartDate, string Usr_EndDate, string ClientCode, string FinStartDate, string FinEndDate, string cmp_code)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_TRIALBALANCE_DATEWISE_ALL", Usr_StartDate, Usr_EndDate, FinStartDate, FinEndDate, cmp_code);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_DateWise_All");
            }
            return Ok(ds);
        }

        /// <summary>Perform TrialBalance Datewise records.</summary>
        /// <param name="Frmdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="FinFrndt">Fin Frndt parameter.</param>
        /// <param name="FinTodt">End date for the date range filter.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CityName">City Name parameter.</param>
        /// <param name="chkcity">chkcity parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult TrialBalance_Datewise(string Frmdt, string Todt, string FinFrndt, string FinTodt, string CMP_CODE, string CITYCODE1, string CMPID, string CityName, string chkcity)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                if (chkcity == "1")
                {
                    SearchCTA = objRpt.SEARCHCRITERIA("Branch : " + CityName, " From:" + Frmdt, " To:" + Todt);
                    SqlQueryPARA = objRpt.SQLQUERY_PARA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE, CITYCODE1);
                    PKID = objRpt.REPORT_LOG("7", SearchCTA, SqlQueryPARA, CMPID);
                }
                else
                {
                    SearchCTA = objRpt.SEARCHCRITERIA("All Branch " + " From:" + Frmdt, " To:" + Todt);
                    SqlQueryPARA = objRpt.SQLQUERY_PARA(Frmdt, Todt, FinFrndt, FinTodt, CMP_CODE);
                    PKID = objRpt.REPORT_LOG("6", SearchCTA, SqlQueryPARA, CMPID);
                }
                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/TrialBalance_Datewise");
            }
            return Ok(ds1);
        }
        /// <summary>Perform Rpt TrialBalance GrpWiseDtls All ToExcel TrialBalanceGroupDetail records.</summary>
        /// <param name="FinStartDate">Start date for the date range filter.</param>
        /// <param name="FinEndDate">End date for the date range filter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="CityCode1">Secondary city/branch code.</param>
        /// <param name="FinEndDate1">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_TrialBalance_GrpWiseDtls_All_ToExcel_TrialBalanceGroupDetail(string FinStartDate, string FinEndDate, string cmp_code, string CityCode1, string FinEndDate1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acct_Rpt_Trialbalance_byGrpDtls_NG", FinStartDate, FinEndDate, cmp_code, CityCode1, FinEndDate1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_TrialBalance_GrpWiseDtls_All_ToExcel_TrialBalanceGroupDetail");
            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt ItemStatement records.</summary>
        /// <param name="ACCTCODE">ACCTCODE parameter.</param>
        /// <param name="ITEMCODE">ITEMCODE parameter.</param>
        /// <param name="Frmdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <param name="CMP_CODE">Company code identifier.</param>
        /// <param name="ITEMNAME">ITEMNAME parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Rpt_ItemStatement(string ACCTCODE, string ITEMCODE, string Frmdt, string Todt, string FINSTARTDATE, string FINENDDATE, string CMP_CODE, string ITEMNAME, string CMPID,string CITYCODE)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                SearchCTA = "Item:" + ITEMNAME + " From: " + Frmdt + " To: " + Todt;
                SqlQueryPARA = objRpt.SQLQUERY_PARA(ACCTCODE, ITEMCODE, Frmdt, Todt, FINSTARTDATE, FINENDDATE, CMP_CODE, CITYCODE);
                PKID = objRpt.REPORT_LOG("23", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Rpt_ItemStatement");
            }
            return Ok(ds1);
        }

        /// <summary>Load page reference data for CMP FILL GACCOUNT SPECIAL LEDGER records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CMP_FILL_GACCOUNT_SPECIAL_LEDGER_PAGELOAD(string cmpcode, string citycode, string citycode1, string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FILL_GACCOUNT_SPECIAL_LEDGER_PAGELOAD", cmpcode, citycode, citycode1, cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CMP_FILL_GACCOUNT_SPECIAL_LEDGER_PAGELOAD");
            }
            return Ok(ds);
        }

         

        /// <summary>Retrieve dropdown data for Fill Export records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_Fill_Export(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillExpoterCity", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_Fill_Export");
            }
            return Ok(ds);
        }
           /// <summary>Perform RPT CLIENTOUTSTANDING AGEING records.</summary>
           /// <param name="cmpcode">Company code identifier.</param>
           /// <returns>DataSet with the requested data serialized as JSON.</returns>
           [HttpGet]
        public IHttpActionResult ACC_RPT_CLIENTOUTSTANDING_AGEING(string cmpcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_MIS_CLIENTOUTSTANDING_AGEING_EXE_LOG_MP", cmpcode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_CLIENTOUTSTANDING_AGEING");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for JV records.</summary>
        /// <param name="JVCode">JVCode parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_PRINT(string JVCode, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                if (Type == "JV" || Type == "GENJV")
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JVREPORT", JVCode);
                }
                else
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_PRINT_REQ", JVCode);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for REPORT LOG records.</summary>
        /// <param name="CmpId">Primary key of the company.</param>
        /// <param name="FormId">Form Id parameter.</param>
        /// <param name="ReportMode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult REPORT_LOG_FILL(string CmpId, string FormId, string ReportMode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_FILL", CmpId, "", ReportMode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/REPORT_LOG_FILL");
            }
            return Ok(ds);
        }
        /// <summary>Perform CashBook FillOurbank records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CashBook_FillOurbank(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_FillOurbank", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CashBook_FillOurbank");
            }
            return Ok(ds);
        }
        /// <summary>Perform CashBook BankRecousillation records.</summary>
        /// <param name="_ourbank"> ourbank parameter.</param>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CashBook_BankRecousillation(string _ourbank, string _FromDt, string _ToDt, string cmpcode, string citycode, string citycode1, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CashBook_BankRecousillation", _ourbank, _FromDt, _ToDt, cmpcode, citycode, citycode1, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CashBook_BankRecousillation");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update CashBook BankRecousillation records.</summary>
        /// <param name="_reconsillationstr"> reconsillationstr parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CashBook_BankRecousillation_Update(string _reconsillationstr)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Acc_CashBook_BankRecousillation_Update", _reconsillationstr);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/Acc_CashBook_BankRecousillation_Update");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve Fill CashBook BankRecRpt records.</summary>
        /// <param name="_ourbank"> ourbank parameter.</param>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_CashBook_BankRecRpt(string _ourbank, string _FromDt, string _ToDt, string cmpcode, string citycode1, string citycode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Acc_Cashbook_bankRecRpt", _ourbank, _FromDt, _ToDt, cmpcode, citycode1, citycode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Fill_CashBook_BankRecRpt");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve Fill CashBook BankRecRptNew1 records.</summary>
        /// <param name="_ourbank"> ourbank parameter.</param>
        /// <param name="_FromDt">Start date for the date range filter.</param>
        /// <param name="_ToDt">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="Fin_StartDate">Start date for the date range filter.</param>
        /// <param name="Fin_EndDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_CashBook_BankRecRptNew1(string _ourbank, string _FromDt, string _ToDt, string cmpcode, string citycode1, string citycode, string Fin_StartDate, string Fin_EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Acc_Cashbook_bankRecRptnew", _ourbank, _FromDt, _ToDt, cmpcode, citycode1, citycode, Fin_StartDate, Fin_EndDate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Fill_CashBook_BankRecRptNew1");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for CMP FILL GACCOUNT records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CMP_FILL_GACCOUNT_PAGELOAD(string cmpcode, string citycode, string citycode1, string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FILL_GACCOUNT_PAGELOAD", cmpcode, citycode, citycode1, cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_CMP_FILL_GACCOUNT_PAGELOAD");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for EXP MST EXPORT MISC JOB FILL CLIENT records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_EXP_MST_EXPORT_MISC_JOB_FILL_CLIENT( string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_MISC_JOB_FILL_CLIENT", citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_EXP_MST_EXPORT_MISC_JOB_FILL_CLIENT");
            }
            return Ok(ds);
        }
        /// <summary>Perform TRA CLIENT STATUS FOLLOWUP GETDTLS records.</summary>
        /// <param name="EXP_CODE">EXP CODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_TRA_CLIENT_STATUS_FOLLOWUP_GETDTLS(string EXP_CODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_TRAN_CLIENT_STATUS_FOLLOWUP_GETDTLS", EXP_CODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_TRA_CLIENT_STATUS_FOLLOWUP_GETDTLS");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update TRA CLIENT STATUS FOLLOWUP records.</summary>
        /// <param name="CmpId">Primary key of the company.</param>
        /// <param name="Exp_Code">Exp Code parameter.</param>
        /// <param name="AssignTo">Assign To parameter.</param>
        /// <param name="Client_Status">Client/exporter code.</param>
        /// <param name="AssignOn">Assign On parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_TRA_CLIENT_STATUS_FOLLOWUP_IU(string CmpId,string Exp_Code, string AssignTo, string Client_Status,string AssignOn)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_TRAN_CLIENT_STATUS_FOLLOWUP_IU", CmpId,Exp_Code, AssignTo, Client_Status, AssignOn);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_TRA_CLIENT_STATUS_FOLLOWUP_IU");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for REQUEST FILL TO GENERATE records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_REQUEST_FILL_TO_GENERATE_PAGELOAD(string CMPID, string CMPCODE, string CITYCODE, string CITYCODE1, string STATUS, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_REQUEST_FILL_TO_GENERATE_PAGELOAD", CMPID, CMPCODE, CITYCODE, CITYCODE1, STATUS, AUTHORISATIONSTATUS,"194");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_REQUEST_FILL_TO_GENERATE_PAGELOAD");
            }
            return Ok(ds);
        }
  

    /// <summary>Generate GENERATE FINAL CODE CPJVPI records.</summary>
    /// <param name="CMPID">Primary key of the company.</param>
    /// <param name="CMPCODE">Company code identifier.</param>
    /// <param name="CITYCODE1">Secondary city/branch code.</param>
    /// <param name="CITYCODE">City/branch code.</param>
    /// <param name="MAKERIP">IP address of the record maker.</param>
    /// <param name="REQCODE">REQCODE parameter.</param>
    /// <param name="STATUS">STATUS parameter.</param>
    /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
    /// <param name="FormId">Form Id parameter.</param>
    /// <returns>DataSet with the requested data serialized as JSON.</returns>
    [HttpGet]
    public IHttpActionResult ACC_GENERATE_FINAL_CODE_CPJVPI(string CMPID,string CMPCODE,string CITYCODE1,string CITYCODE,string MAKERIP,string REQCODE,string STATUS,string AUTHORISATIONSTATUS,string FormId)
    {
        DataSet ds = new DataSet();
        DAL objDal = new DAL();
        string spName = "";
        if (STATUS == "JVREQ")
        {
            spName = "USP_ACC_JV_GENERATE";
        }
        else if (STATUS == "RCP")
            {
            spName = "USP_ACC_CP_GENERATE";
        }
            else if (STATUS == "RPI")
            {
                spName = "USP_ACC_PI_GENERATE";
            }
            else if (STATUS == "SRPI")
            {
                spName = "USP_ACC_SRPI_GENERATE";
            }
            try
        {
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, spName, CMPID, CMPCODE, CITYCODE1, CITYCODE, CMPID, MAKERIP,REQCODE, STATUS, AUTHORISATIONSTATUS, FormId);
        }
        catch (Exception ex)
        {
            ds = ErrorLog.Error(ex, "Accounts/ACC_GENERATE_FINAL_CODE_CPJVPI");
        }
        finally
        {
            objDal.Dispose();

        }
        return Ok(ds);
    }

        /// <summary>Perform CPJVPI REQUEST AUTHORISATION UPDATEMULTI records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="JVREQNO">JVREQNO parameter.</param>
        /// <param name="AUTHORISATIONDT">AUTHORISATIONDT parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="AUTHORISATIONSTATUS">AUTHORISATIONSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Acc_CPJVPI_REQUEST_AUTHORISATION_UPDATEMULTI(string CMPCODE, string CITYCODE1, string CITYCODE, string STATUS, string JVREQNO, string AUTHORISATIONDT, string CMPID, string AUTHORISATIONSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CPJVPI_REQUEST_AUTHORISATION_UPDATEMULTI", CMPCODE, CITYCODE1, CITYCODE, STATUS, JVREQNO, (AUTHORISATIONDT != null) ? AUTHORISATIONDT : "", CMPID, AUTHORISATIONSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Acc_CPJVPI_REQUEST_AUTHORISATION_UPDATEMULTI");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for PURCHASE PRINT SRPI records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="PUR_CODE">PUR CODE parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <param name="PUR_SUPPLIER">Supplier code.</param>
        /// <param name="PUR_INVNO">Invoice number.</param>
        /// <param name="DISPLAYTYPE">DISPLAYTYPE parameter.</param>
        /// <param name="YEAR_ID">YEAR ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_PRINT_SRPI(string cmp_code, string citycode, string PUR_CODE, string FROMDATE, string TODATE, string PUR_SUPPLIER, string PUR_INVNO, string DISPLAYTYPE, string YEAR_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_SRPI_PRINT", cmp_code, citycode, (PUR_CODE != null) ? PUR_CODE : "", (FROMDATE != null) ? FROMDATE : "", (TODATE != null) ? TODATE : "", (PUR_SUPPLIER != null) ? PUR_SUPPLIER : "", (PUR_INVNO != null) ? PUR_INVNO : "", DISPLAYTYPE, YEAR_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_PRINT_SRPI");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve Export Search List acct records.</summary>
        /// <param name="searchtype">Search type/column identifier.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Export_Search_List_acct(string searchtype,string searchval,string cmp_code, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SEARCH_LIST", searchtype,searchval, cmp_code, CityCode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Export_Search_List_acct");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of MST RPT CLIENT records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCT_MST_RPT_CLIENT_REGISTER()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_RPT_CLIENT_REGISTER");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCT_MST_RPT_CLIENT_REGISTER");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of USP MST RPT SUPPLIER records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCT_USP_MST_RPT_SUPPLIER_REGISTER()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_RPT_SUPPLIER_REGISTER");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCT_USP_MST_RPT_SUPPLIER_REGISTER");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for BRBPCRCPCE View OLD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_BRBPCRCPCE_View_OLD(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BRBPCRCPCE_VIEW_OLD", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_BRBPCRCPCE_View_OLD");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for JV View OLD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_JV_View_OLD(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_JV_VIEW_OLD", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_JV_View_OLD");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for PURCHASE VIEW OLD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_VIEW_OLD(string CMPCODE, string CITYCODE, string ENTRYNO, string VGUID, string STATUS,string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_VIEW_OLD", CMPCODE, CITYCODE, ENTRYNO, VGUID, STATUS, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_VIEW_OLD");
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for PAYMENT POPULATE SUPPLIERBILL records.</summary>
        /// <param name="SUPPLIER">Supplier code.</param>
        /// <param name="FINSTARTDATE">Start date for the date range filter.</param>
        /// <param name="FINENDDATE">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PAYMENT_POPULATE_SUPPLIERBILL(string SUPPLIER, string FINSTARTDATE, string FINENDDATE, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCOUNTS_PAYMENT_POPULATE_SUPPLIERBILL", (SUPPLIER != null) ? SUPPLIER : "", (FINSTARTDATE != null) ? FINSTARTDATE : "", (FINENDDATE != null) ? FINENDDATE : "", (CMPCODE != null) ? CMPCODE : "", CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PAYMENT_POPULATE_SUPPLIERBILL");
            }
            return Ok(ds);
        }

        /// <summary>Perform OutstandingReceivableOverseasAgent records.</summary>
        /// <param name="ClientName">Client/exporter code.</param>
        /// <param name="ClientCode">Client/exporter code.</param>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult OutstandingReceivableOverseasAgent(string ClientName, string ClientCode, string CmpCode, string CMPID)
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();

            DAL objDal = new DAL();
            Report objRpt = new Report();
            string SearchCTA, SqlQueryPARA, PKID;
            try
            {
                SearchCTA = objRpt.SEARCHCRITERIA(ClientName);
                SqlQueryPARA = objRpt.SQLQUERY_PARA(ClientCode, CmpCode, CMPID);
                PKID = objRpt.REPORT_LOG_BATCH("33", SearchCTA, SqlQueryPARA, CMPID);

                dtbl.Columns.Add("PKID", typeof(string));

                drow = dtbl.NewRow();
                drow[0] = PKID;
                dtbl.Rows.Add(drow);
                ds1.Merge(dtbl);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/OutstandingReceivableOverseasAgent");
            }
            return Ok(ds1);
        }

        /// <summary>Perform FILLEXPOTERCITY OVERSEAS AGENT records.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_FILLEXPOTERCITY_OVERSEAS_AGENT(string cmpcode, string citycode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FILLEXPOTERCITY_OVERSEAS_AGENT", cmpcode, citycode, citycode1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_FILLEXPOTERCITY_OVERSEAS_AGENT");
            }
            return Ok(ds);
        }
        /// <summary>Validate PURCHASE MContainer records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MContainer_Validate(string CMPCODE, string CITYCODE, string CONTAINERNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINERNO_VALIDATE", CMPCODE, CITYCODE, CONTAINERNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MContainer_Validate");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for PURCHASE MultiContainer records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MultiContainer_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINER_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MultiContainer_RESET");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for PURCHASE MULTICONTAINER NG records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_NG_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_NG_RESET");
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for PURCHASE PAGELOAD MAWB records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="PSTATUS">PSTATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_PAGELOAD_MAWB(string cmp_code, string citycode, string citycode1, string PSTATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_PAGELOAD_MAWB", cmp_code, citycode, citycode1, PSTATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_PAGELOAD_MAWB");
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for PURCHASE MAWBNO PAGELOAD TDS records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="STR">STR parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWBNO_PAGELOAD_TDS(string CMPID, string CMPCODE, string CITYCODE, string MAWBNO, string VGUID, string STATUS, string STR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB", CMPID, CMPCODE, CITYCODE, MAWBNO, VGUID, STATUS, STR);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWBNO_PAGELOAD_TDS");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for PURCHASE MAWB NG records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWB_NG_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_RESET_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWB_NG_RESET");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for PURCHASE MAWB RESET STEP1 records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWB_RESET_STEP1(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_RESET_STEP1", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWB_RESET_STEP1");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for PURCHASE MAWBNO PAGELOAD records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWBNO_PAGELOAD_NG(string CMPID, string CMPCODE, string CITYCODE, string MAWBNO, string VGUID, string STATUS)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_NG", CMPID, CMPCODE, CITYCODE, MAWBNO, VGUID, STATUS);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWBNO_PAGELOAD_NG");
            }
            return Ok(ds);
        }

        /// <summary>Validate PURCHASE MAWB records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="MAWBNO">Master airway bill number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MAWB_VALIDATE(string CMPCODE, string CITYCODE, string MAWBNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_VALIDATE", CMPCODE, CITYCODE, MAWBNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWB_VALIDATE");
            }
            return Ok(ds);
        }
        /// <summary>Perform PURCHASE RESETMAWB records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_RESETMAWB(string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET_MAWB", CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_RESETMAWB");
            }
            return Ok(ds);
        }
        /* ADDED FOR TDS PART IN NG  */
        /// <summary>Insert or update PURCHASE TMP IU records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_TMP_IU_NG([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TMP_IU_NG", PID.ID, PID.ENTRYNO, PID.CLIENT, PID.JOBNO, PID.DEDUCTION, PID.AMOUNT, PID.USERNAME, PID.NARRATION, PID.IS_NOT_EDIT_ABLE, PID.ITEMCODE, PID.VGUID, PID.ACCOUNT_NAME, PID.ITEM, PID.ACC_PURCHASEDTLS_ID, PID.STATUS, PID.IsJobReport, PID.ITEM_DATAVALUE, PID.SRPIPASSAMOUNT, PID.cmpid, PID.PUR_TAXABLE, PID.ISTDSAPP, PID.PUR_TDS, PID.MAWBFLAG);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        //[HttpGet]
        //public IHttpActionResult ACC_PURCHASE_GET_FINALTDSDATA_NG(string TYPE, string SUPPCODE, string PURCHASEDT, string VGUID, string CMPCODE, string CMPID)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {

        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_GET_FINALTDSDATA_NG", TYPE, SUPPCODE, PURCHASEDT, VGUID, CMPCODE, CMPID);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_GET_FINALTDSDATA_NG");
        //    }
        //    return Ok(ds);
        //}
        /// <summary>Perform PIBP GET TDSDATA records.</summary>
        /// <param name="SUPPCODE">SUPPCODE parameter.</param>
        /// <param name="PURCHASEDT">PURCHASEDT parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PIBP_GET_TDSDATA_NG(string SUPPCODE, string PURCHASEDT, string VGUID, string CMPCODE, string CMPID, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PIBP_TDSCAL_NG_FINAL", SUPPCODE, PURCHASEDT, VGUID, CMPCODE, CMPID, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PIBP_GET_TDSDATA_NG");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update PURCHASE TMP TDSMULTI IU records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_TMP_TDSMULTI_IU_NG([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TDS_TMPMULTI_IU_NG", PID.cmpid, PID.STATUS, PID.VGUID, PID.SUPCODE, PID.STR);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_TDSMULTI_IU_NG");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for PURCHASE TDS RESET records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_TDS_RESET_NG(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TDS_RESET_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TDS_RESET_NG");
            }
            return Ok(ds);
        }
        /* MULTICONTAINER */
        /// <summary>Insert or update PURCHASE MULTICONTAINER TMP IU records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_TMP_IU_NG([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINER_TMP_IU_NG", PID.ID, (PID.ENTRYNO == null) ? "" : PID.ENTRYNO, PID.VGUID, PID.CLIENT, PID.ACCOUNT_NAME, PID.JOBNO, PID.AMOUNT, PID.DEDUCTION, PID.NARRATION, (PID.ITEMCODE == null) ? "" : PID.ITEMCODE, (PID.ITEM_DATAVALUE == null) ? "" : PID.ITEM_DATAVALUE, PID.ACC_PURCHASEDTLS_ID, PID.IsJobReport, PID.cmpid, PID.PUR_TAXABLE, PID.ISTDSAPP, PID.PUR_TDS);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_TMP_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update PURCHASE MULTICONTAINER IU records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_IU_NG(string CMPCODE, string CITYCODE1, string VGUID, string TYPE, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTTCONTAINER_STEP1_IU_NG", CMPCODE, CITYCODE1, VGUID, TYPE, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_IU_NG");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update PURCHASE MAWB TMP IU records.</summary>
        /// <param name="PID">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_MAWB_TMP_IU_NG([FromBody]StaffPurchaseInvoiceDtls PID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_TMP_IU_NG", PID.ID, (PID.ENTRYNO == null) ? "" : PID.ENTRYNO, PID.VGUID, PID.CLIENT, PID.ACCOUNT_NAME, PID.AMOUNT, PID.DEDUCTION, (PID.MAWBNO == null) ? "" : PID.MAWBNO, PID.ACC_PURCHASEDTLS_ID, PID.IsJobReport, PID.cmpid, PID.PUR_TAXABLE, PID.ISTDSAPP, PID.PUR_TDS);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MAWB_TMP_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete PURCHASEE MAWB TMP DEL records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASEE_MAWB_TMP_DEL_NG(string ID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MAWB_TMP_DEL_NG", ID, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASEE_MAWB_TMP_DEL_NG");
            }
            return Ok(ds);
        }
        /// <summary>Delete PURCHASE TMP DEL records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="ACC_PURCHASEDTLS_ID">ACC PURCHASEDTLS ID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_TMP_DEL_NG(string ID, string VGUID, string ACC_PURCHASEDTLS_ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_TMP_DEL_NG", ID, VGUID, ACC_PURCHASEDTLS_ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_TMP_DEL_NG");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update PURCHASE UPDATE records.</summary>
        /// <param name="PIM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_UPDATE_NG([FromBody]StaffPurchaseInvoiceMaster PIM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_UPDATE_NG", PIM.CMPID, PIM.CMPCODE, PIM.CITYCODE1, PIM.CITYCODE, PIM.USERNAME, PIM.ENTRYNO, PIM.ENTRYDT, PIM.STATUS, PIM.SUP_CODE, PIM.SUP_NAME, PIM.SUP_INVNO, PIM.SUP_INVDT, PIM.SUP_BILLRECEIVEDDT, PIM.SUP_DUEDT, PIM.PASSFLAG, PIM.PASSEDBY, PIM.PASSEDAMT, PIM.INVAMT, PIM.VOUCHERNO, PIM.MAWBN0, PIM.FREIGHTG100235, PIM.SURCHARGEG101468, PIM.AIRFRTCOMMG100153, PIM.FRTREBATEG100186, PIM.NARRATION, PIM.ACTUALAMOUNT, PIM.VGUID, PIM.MAKER_ID, PIM.MAKER_IP, PIM.ACTION, PIM.DOCUMENTG100179, PIM.FK_SUP_ADDR_ID, PIM.AMSENSEXP_G102024, PIM.MISCEXP_G102025);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_UPDATE_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update PURCHASE INSERT records.</summary>
        /// <param name="PIM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_PURCHASE_INSERT_NG([FromBody]StaffPurchaseInvoiceMaster PIM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_INSERT_NG", PIM.CMPID, PIM.CMPCODE, PIM.CITYCODE1, PIM.CITYCODE, PIM.USERNAME, (PIM.ENTRYNO != null) ? PIM.ENTRYNO : "", PIM.ENTRYDT, PIM.STATUS, PIM.SUP_CODE, PIM.SUP_NAME, PIM.SUP_INVNO, PIM.SUP_INVDT, PIM.SUP_BILLRECEIVEDDT, PIM.SUP_DUEDT, PIM.PASSFLAG, PIM.PASSEDBY, PIM.PASSEDAMT, PIM.INVAMT, PIM.VOUCHERNO, PIM.MAWBN0, PIM.FREIGHTG100235, PIM.SURCHARGEG101468, PIM.AIRFRTCOMMG100153, PIM.FRTREBATEG100186, PIM.NARRATION, PIM.ACTUALAMOUNT, PIM.VGUID, PIM.MAKER_ID, PIM.MAKER_IP, PIM.ACTION, PIM.DOCUMENTG100179, PIM.FK_SUP_ADDR_ID, PIM.AMSENSEXP_G102024, PIM.MISCEXP_G102025);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_INSERT_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for PURCHASE VIEW records.</summary>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="ENTRYNO">ENTRYNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="STATUS">STATUS parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_VIEW_NG(string cmp_code, string citycode, string ENTRYNO, string VGUID, string STATUS, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_VIEW_NG", cmp_code, citycode, ENTRYNO, VGUID, STATUS, CMPID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_VIEW_NG");
            }
            return Ok(ds);
        }
        /// <summary>Perform PURCHASE GETTDSTYPE records.</summary>
        /// <param name="SUPPCODE">SUPPCODE parameter.</param>
        /// <param name="PURCHASEDT">PURCHASEDT parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_GETTDSTYPE(string SUPPCODE, string PURCHASEDT, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_GETTDSTYPE", SUPPCODE, PURCHASEDT, CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_GETTDSTYPE");
            }
            return Ok(ds);
        }

        /// <summary>Reset temporary data for PURCHASE MULTICONTAINER RESET STEP1 records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_MULTICONTAINER_RESET_STEP1(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_MULTICONTAINER_RESET_STEP1", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_MULTICONTAINER_RESET_STEP1");
            }
            return Ok(ds);
        }
        /// <summary>Perform PURCHASE RESETMAWB records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_RESETMAWB_NG(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET_MAWB_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_RESETMAWB_NG");
            }
            return Ok(ds);
        }
        /// <summary>Perform PURCHASE RESETMULTICONTAINER records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_PURCHASE_RESETMULTICONTAINER_NG(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_PURCHASE_RESET_MULTICONTAINER_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_PURCHASE_RESETMULTICONTAINER_NG");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for INVOICE NG records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_NG_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_RESET_NG", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_NG_RESET");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for INVOICE RESET CHRGCURRENCY records.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CURRENCY">CURRENCY parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_INVOICE_RESET_CHRGCURRENCY(string CMPID, string VGUID, string CURRENCY)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_INVOICE_RESET_CURCHARGES", CMPID, VGUID, CURRENCY);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_INVOICE_RESET_CHRGCURRENCY");
            }
            return Ok(ds);
        }
        /// <summary>Branch list of a company (for the BS / P&amp;L branch selector).</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with CITYCODE1 and CITYNAME of every branch of the company.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_COMPANY_BRANCH_LIST(String CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_COMPANY_BRANCHLIST", CMPCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_COMPANY_BRANCH_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Branch-wise Profit and Loss statement (Trading + P&amp;L sections).</summary>
        /// <param name="FIN_STARTDATE">Financial year start date, e.g. 1-Apr-2025.</param>
        /// <param name="FIN_ENDDATE">Financial year end date, e.g. 31-Mar-2026.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="USR_ENDDATE">Report as-on date (period end for the statement).</param>
        /// <returns>DataSet: Table 0 = P&amp;L summary (Gross/Net profit), Table 1 = section/group totals, Table 2 = ledger detail.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_PROFIT_AND_LOSS(String FIN_STARTDATE, String FIN_ENDDATE, String CMPCODE, String CITYCODE, String USR_ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_PROFIT_AND_LOSS", FIN_STARTDATE, FIN_ENDDATE, CMPCODE, CITYCODE, USR_ENDDATE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_PROFIT_AND_LOSS");
            }
            return Ok(ds);
        }
        /// <summary>Branch-wise Balance Sheet as on the given date.</summary>
        /// <param name="FIN_STARTDATE">Financial year start date, e.g. 1-Apr-2025.</param>
        /// <param name="FIN_ENDDATE">Financial year end date, e.g. 31-Mar-2026.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="USR_ENDDATE">Report as-on date.</param>
        /// <returns>DataSet: Table 0 = Balance Sheet group level (Liabilities/Assets with totals), Table 1 = summary, Table 2 = ledger detail.</returns>
        [HttpGet]
        public IHttpActionResult ACC_RPT_BALANCE_SHEET(String FIN_STARTDATE, String FIN_ENDDATE, String CMPCODE, String CITYCODE, String USR_ENDDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_RPT_BALANCE_SHEET", FIN_STARTDATE, FIN_ENDDATE, CMPCODE, CITYCODE, USR_ENDDATE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACC_RPT_BALANCE_SHEET");
            }
            return Ok(ds);
        }
        /// <summary>FY-wide debit/credit difference audit — flags vouchers where header/detail totals disagree, credit note allocations exceed the note total, or child rows are orphaned from a missing parent.</summary>
        /// <param name="FIN_STARTDATE">Financial year start date, e.g. 1-Apr-2025.</param>
        /// <param name="FIN_ENDDATE">Financial year end date, e.g. 31-Mar-2026.</param>
        /// <param name="COMPANYCODE">Company code identifier; blank = all companies.</param>
        /// <param name="CITYCODE">City/branch code; blank = all branches.</param>
        /// <returns>DataSet: Table 0 = per-CHECKTYPE summary (entry count + total diff), Table 1 = voucher-level detail rows.</returns>
        [HttpGet]
        public IHttpActionResult ACCT_RPT_FY_DRCR_DIFF_AUDIT(String FIN_STARTDATE, String FIN_ENDDATE, String COMPANYCODE, String CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_RPT_FY_DRCR_DIFF_AUDIT", FIN_STARTDATE, FIN_ENDDATE, COMPANYCODE, CITYCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/ACCT_RPT_FY_DRCR_DIFF_AUDIT");
            }
            return Ok(ds);
        }

        #region 26AS TDS Reconciliation

        /// <summary>Upload a TRACES Form 26AS statement (.txt native download or .xlsx conversion), parse PART-I, auto-match deductors to clients and return the reconciliation summary.</summary>
        /// <remarks>
        /// Multipart form upload. Fields: file, cmpid, vguid, makerip, cmpcode, citycode, citycode1,
        /// finyear (e.g. 2025-26; blank = accept the file's FY), expectedpan (blank = accept the file's PAN).
        /// Re-uploading the same PAN + FY replaces the previous batch (USP_ACC_TDS26AS_UPLOADLOG);
        /// the TAN-&gt;client map is preserved. Only PART-I is read; parsing stops at PART-II.
        /// </remarks>
        /// <returns>DataSet: Table = per-deductor summary, Table1 = client dropdown, Table2 = batch header, plus a STATUS/MSG/LOGID table ("100" ok / "104" error).</returns>
        [HttpPost]
        public IHttpActionResult Upload26ASFile()
        {
            const string SPNAME = "USP_ACC_TDS26AS_UPLOADLOG";

            DataSet ds1 = new DataSet();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var finyear = HttpContext.Current.Request.Params["finyear"];
            var expectedpan = HttpContext.Current.Request.Params["expectedpan"];
            string filePath = "";
            try
            {
                // Fail fast with a readable message if the feature's DB objects have
                // not been deployed (same guard as UploadBnkReconcilFileV2).
                object procId;
                using (SqlConnection chk = new SqlConnection(ConnectionString.getConnString()))
                {
                    chk.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT OBJECT_ID(@p)", chk))
                    {
                        cmd.Parameters.AddWithValue("@p", "dbo." + SPNAME);
                        procId = cmd.ExecuteScalar();
                    }
                }
                if (procId == null || procId == DBNull.Value)
                {
                    return Ok(Tds26ASStatus("104", "Stored procedure " + SPNAME + " does not exist on this database. Run the TDS26AS_TABLES_AND_SPS script, then retry."));
                }

                if (file == null || file.ContentLength == 0)
                {
                    return Ok(Tds26ASStatus("104", "No file was received by the server."));
                }

                string fileName = Path.GetFileName(file.FileName);
                string strExtension = Path.GetExtension(fileName).ToLower();
                if (strExtension != ".txt" && strExtension != ".xlsx")
                {
                    return Ok(Tds26ASStatus("104", "Only the native 26AS .txt download or an .xlsx conversion is supported (got " + strExtension + ")."));
                }

                string uploadDir = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~"), "DATA", "TDS26AS");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                filePath = Path.Combine(uploadDir, fileName);
                // Re-upload of the same statement is expected (the SP replaces the
                // batch), so overwrite instead of rejecting like the bank upload does.
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                file.SaveAs(filePath);

                // ---- parse PART-I into memory ----
                string pan, fy, assessee;
                List<string[]> deductors;               // per deductor: SRNO, NAME, TAN, TOTAMT, TOTTAX, TOTTDS
                List<List<string[]>> details;           // parallel list: SRNO, SECTION, TXNDATE, BOOKSTATUS, BOOKDATE, REMARKS, AMT, TAX, TDS
                if (strExtension == ".txt")
                {
                    ParseTds26ASTxt(filePath, out pan, out fy, out assessee, out deductors, out details);
                }
                else
                {
                    ParseTds26ASXlsx(filePath, out pan, out fy, out assessee, out deductors, out details);
                }

                if (deductors.Count == 0)
                {
                    Tds26ASPreserveFailed(uploadDir, filePath, fileName);
                    return Ok(Tds26ASStatus("104", "No PART-I deductor rows could be read from " + fileName + ". Is this a Form 26AS statement?"));
                }
                if (!string.IsNullOrEmpty(expectedpan) && !string.IsNullOrEmpty(pan) &&
                    !string.Equals(expectedpan.Trim(), pan.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return Ok(Tds26ASStatus("104", "The statement belongs to PAN " + pan + ", not the company's PAN " + expectedpan + "."));
                }
                if (!string.IsNullOrEmpty(finyear) && !string.IsNullOrEmpty(fy) &&
                    !string.Equals(finyear.Trim(), fy.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return Ok(Tds26ASStatus("104", "The statement is for FY " + fy + ", but FY " + finyear + " was selected."));
                }

                // ---- create batch ----
                DAL objDal = new DAL();
                DataSet dslog = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, SPNAME,
                    cmpid, makerip, vguid, fileName, filePath, pan, fy, assessee);
                if (dslog.Tables.Count == 0 || dslog.Tables[0].Rows.Count == 0 || dslog.Tables[0].Rows[0]["STATUS"].ToString() != "100")
                {
                    string msg = (dslog.Tables.Count > 0 && dslog.Tables[0].Rows.Count > 0 && dslog.Tables[0].Columns.Contains("STATUSTEXT"))
                        ? dslog.Tables[0].Rows[0]["STATUSTEXT"].ToString() : "Could not create the upload log.";
                    return Ok(Tds26ASStatus("104", msg));
                }
                string logid = dslog.Tables[0].Rows[0]["LOGID"].ToString();

                // ---- inserts: deductors row-by-row (need SCOPE_IDENTITY), details
                //      via one SqlBulkCopy - 4,000+ single INSERTs over the WAN to
                //      the DB server took minutes and left the batch half-visible ----
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("FK_DEDID", typeof(int));
                dtDetail.Columns.Add("FK_LOGID", typeof(int));
                dtDetail.Columns.Add("SRNO", typeof(int));
                dtDetail.Columns.Add("SECTION", typeof(string));
                dtDetail.Columns.Add("TXNDATE", typeof(DateTime));
                dtDetail.Columns.Add("BOOKINGSTATUS", typeof(string));
                dtDetail.Columns.Add("BOOKINGDATE", typeof(DateTime));
                dtDetail.Columns.Add("REMARKS", typeof(string));
                dtDetail.Columns.Add("AMTCREDITED", typeof(decimal));
                dtDetail.Columns.Add("TAXDEDUCTED", typeof(decimal));
                dtDetail.Columns.Add("TDSDEPOSITED", typeof(decimal));

                using (SqlConnection connection = new SqlConnection(ConnectionString.getConnString()))
                {
                    connection.Open();
                    int logidInt = int.Parse(logid);
                    for (int d = 0; d < deductors.Count; d++)
                    {
                        string[] ded = deductors[d];
                        int dedid;
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO ACC_TDS26AS_DEDUCTOR (FK_LOGID, SRNO, DEDUCTOR_NAME, TAN, TOT_AMTCREDITED, TOT_TAXDEDUCTED, TOT_TDSDEPOSITED) " +
                            "VALUES (@logid, @srno, @name, @tan, @amt, @tax, @tds); SELECT CAST(SCOPE_IDENTITY() AS INT)", connection))
                        {
                            command.Parameters.AddWithValue("@logid", logid);
                            command.Parameters.AddWithValue("@srno", Tds26ASInt(ded[0]));
                            command.Parameters.AddWithValue("@name", ded[1]);
                            command.Parameters.AddWithValue("@tan", ded[2]);
                            command.Parameters.AddWithValue("@amt", Tds26ASAmt(ded[3]));
                            command.Parameters.AddWithValue("@tax", Tds26ASAmt(ded[4]));
                            command.Parameters.AddWithValue("@tds", Tds26ASAmt(ded[5]));
                            dedid = (int)command.ExecuteScalar();
                        }
                        foreach (string[] det in details[d])
                        {
                            dtDetail.Rows.Add(dedid, logidInt, Tds26ASInt(det[0]), det[1], Tds26ASDate(det[2]),
                                det[3], Tds26ASDate(det[4]), det[5], Tds26ASAmt(det[6]), Tds26ASAmt(det[7]), Tds26ASAmt(det[8]));
                        }
                    }
                    using (SqlBulkCopy bulk = new SqlBulkCopy(connection))
                    {
                        bulk.DestinationTableName = "dbo.ACC_TDS26AS_DETAIL";
                        foreach (DataColumn col in dtDetail.Columns)
                        {
                            bulk.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                        }
                        bulk.BulkCopyTimeout = 300;
                        bulk.WriteToServer(dtDetail);
                    }
                }

                // ---- auto-match, then return the summary + status ----
                objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_TDS26AS_MATCH", logid);
                ds1 = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_TDS26AS_GETSUMMARY", logid, cmpcode, citycode, citycode1);

                DataTable dtbl = new DataTable();
                dtbl.Columns.Add("STATUS", typeof(string));
                dtbl.Columns.Add("MSG", typeof(string));
                dtbl.Columns.Add("LOGID", typeof(string));
                dtbl.Rows.Add("100", fileName + " uploaded: " + deductors.Count + " deductors parsed.", logid);
                ds1.Merge(dtbl);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/Upload26ASFile");
                if (!string.IsNullOrEmpty(filePath))
                {
                    Tds26ASPreserveFailed(Path.GetDirectoryName(filePath), filePath, Path.GetFileName(filePath));
                }
                return Ok(Tds26ASStatus("104", "Upload failed: " + ex.Message));
            }
            return Ok(ds1);
        }

        /// <summary>Reconciliation summary of a parsed 26AS batch (per-deductor 26AS totals vs FY invoiced totals).</summary>
        [HttpGet]
        public IHttpActionResult TDS26AS_GetSummary(String LOGID, String CMPCODE, String CITYCODE, String CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_TDS26AS_GETSUMMARY", LOGID, CMPCODE, CITYCODE, CITYCODE1);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/TDS26AS_GetSummary");
            }
            return Ok(ds);
        }

        /// <summary>26AS transaction rows of one deductor plus the matched client's FY invoices.</summary>
        [HttpGet]
        public IHttpActionResult TDS26AS_GetDetail(String DEDID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_TDS26AS_GETDETAIL", DEDID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/TDS26AS_GetDetail");
            }
            return Ok(ds);
        }

        /// <summary>Delete one uploaded 26AS batch (LOGID 0 = latest). Saved TAN-client mappings are kept.</summary>
        [HttpGet]
        public IHttpActionResult TDS26AS_ClearStatement(String LOGID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_TDS26AS_CLEARSTATEMENT", LOGID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/TDS26AS_ClearStatement");
            }
            return Ok(ds);
        }

        /// <summary>Persist a manual TAN-to-client mapping so future uploads auto-match this deductor.</summary>
        [HttpGet]
        public IHttpActionResult TDS26AS_SaveMapping(String TAN, String EXPCODE, String CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_TDS26AS_SAVEMAPPING", TAN, EXPCODE, CMPID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/TDS26AS_SaveMapping");
            }
            return Ok(ds);
        }

        /* ---- 26AS parsing helpers ------------------------------------------------ */

        // TAN looks like AGRA11531C. Used to tell a deductor summary line apart from
        // anything else that begins with a number.
        private static readonly System.Text.RegularExpressions.Regex Tds26ASTanRegex =
            new System.Text.RegularExpressions.Regex(@"^[A-Z]{4}\d{5}[A-Z]$");

        /// <summary>Parse the native TRACES ^-delimited text download. PART-I only.</summary>
        private void ParseTds26ASTxt(string path, out string pan, out string fy, out string assessee,
            out List<string[]> deductors, out List<List<string[]>> details)
        {
            pan = ""; fy = ""; assessee = "";
            deductors = new List<string[]>();
            details = new List<List<string[]>>();

            string[] lines = File.ReadAllLines(path);
            bool inPart1 = false;
            bool headerNext = false;
            foreach (string raw in lines)
            {
                string line = raw ?? "";
                if (headerNext)
                {
                    // File Creation Date ^ PAN ^ Status ^ FY ^ AY ^ Name ^ address...
                    string[] h = line.Split('^');
                    if (h.Length > 5) { pan = h[1].Trim(); fy = h[3].Trim(); assessee = h[5].Trim(); }
                    headerNext = false;
                    continue;
                }
                if (line.IndexOf("Permanent Account Number (PAN)", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    headerNext = true;
                    continue;
                }
                if (line.IndexOf("PART-I ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    line.IndexOf("PART-I -", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    inPart1 = true;
                    continue;
                }
                if (inPart1 && line.IndexOf("PART-II", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    break;                              // PART-I is over - ignore the rest
                }
                if (!inPart1 || line.Trim().Length == 0)
                {
                    continue;
                }

                string[] f = line.Split('^');
                if (f.Length > 9 && f[0].Trim().Length > 0 && Tds26ASIsInt(f[0]) && Tds26ASTanRegex.IsMatch(f[2].Trim()))
                {
                    // deductor summary: SrNo ^ Name ^ TAN ^^^^^ TotAmt ^ TotTax ^ TotTDS
                    deductors.Add(new string[] { f[0].Trim(), f[1].Trim(), f[2].Trim(), f[7].Trim(), f[8].Trim(), f[9].Trim() });
                    details.Add(new List<string[]>());
                }
                else if (f.Length > 9 && f[0].Trim().Length == 0 && Tds26ASIsInt(f[1]) && deductors.Count > 0)
                {
                    // detail: ^ SrNo ^ Section ^ TxnDate ^ BookStatus ^ BookDate ^ Remarks ^ Amt ^ Tax ^ TDS
                    details[details.Count - 1].Add(new string[] { f[1].Trim(), f[2].Trim(), f[3].Trim(), f[4].Trim(), f[5].Trim(), f[6].Trim(), f[7].Trim(), f[8].Trim(), f[9].Trim() });
                }
                // anything else (column headers, "Sr. No." sub-headers) is skipped
            }
        }

        /// <summary>Parse an .xlsx conversion of the 26AS statement (Sheet1, same row shapes as the txt).</summary>
        private void ParseTds26ASXlsx(string path, out string pan, out string fy, out string assessee,
            out List<string[]> deductors, out List<List<string[]>> details)
        {
            pan = ""; fy = ""; assessee = "";
            deductors = new List<string[]>();
            details = new List<List<string[]>>();

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
            {
                DataTable sheet = reader.AsDataSet().Tables[0];
                bool inPart1 = false;
                bool headerNext = false;
                for (int r = 0; r < sheet.Rows.Count; r++)
                {
                    DataRow row = sheet.Rows[r];
                    int cols = sheet.Columns.Count;
                    // Date cells come back as real DateTimes from ExcelDataReader;
                    // render them invariant so Tds26ASDate never has to guess
                    // dd-MM vs MM-dd from a culture-dependent string.
                    Func<int, string> cell = i =>
                    {
                        if (i >= cols || row[i] == DBNull.Value) return "";
                        if (row[i] is DateTime) return ((DateTime)row[i]).ToString("dd-MMM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        return Convert.ToString(row[i]).Trim();
                    };

                    string joined = "";
                    for (int i = 0; i < Math.Min(cols, 3); i++) joined += cell(i) + "|";

                    if (headerNext)
                    {
                        pan = cell(1); fy = cell(3); assessee = cell(5);
                        headerNext = false;
                        continue;
                    }
                    if (joined.IndexOf("Permanent Account Number (PAN)", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        headerNext = true;
                        continue;
                    }
                    if (joined.IndexOf("PART-I ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                        joined.IndexOf("PART-I -", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        inPart1 = true;
                        continue;
                    }
                    if (inPart1 && joined.IndexOf("PART-II", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        break;
                    }
                    if (!inPart1)
                    {
                        continue;
                    }

                    // xlsx layout: deductor = SrNo(0) Name(1) TAN(2) ... TotAmt(7) TotTax(8) TotTDS(9)
                    //              detail   = blank(0) SrNo(1) Section(2) TxnDate(3) BookStatus(4) BookDate(5) Remarks(6) Amt(7) Tax(8) TDS(9)
                    if (cell(0).Length > 0 && Tds26ASIsInt(cell(0)) && Tds26ASTanRegex.IsMatch(cell(2)))
                    {
                        deductors.Add(new string[] { cell(0), cell(1), cell(2), cell(7), cell(8), cell(9) });
                        details.Add(new List<string[]>());
                    }
                    else if (cell(0).Length == 0 && Tds26ASIsInt(cell(1)) && deductors.Count > 0)
                    {
                        details[details.Count - 1].Add(new string[] { cell(1), cell(2), cell(3), cell(4), cell(5), cell(6), cell(7), cell(8), cell(9) });
                    }
                }
            }
        }

        private static bool Tds26ASIsInt(string s)
        {
            int n;
            return int.TryParse((s ?? "").Trim(), out n);
        }

        private static object Tds26ASInt(string s)
        {
            int n;
            return int.TryParse((s ?? "").Trim(), out n) ? (object)n : DBNull.Value;
        }

        private static object Tds26ASAmt(string s)
        {
            decimal d;
            return decimal.TryParse((s ?? "").Trim().Replace(",", ""), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out d) ? (object)d : DBNull.Value;
        }

        // Dates arrive as dd-MMM-yyyy in the txt, and as either that string or a real
        // datetime rendering in an xlsx conversion.
        private static object Tds26ASDate(string s)
        {
            s = (s ?? "").Trim();
            if (s.Length == 0 || s == "-") return DBNull.Value;
            DateTime dt;
            if (DateTime.TryParseExact(s, new string[] { "dd-MMM-yyyy", "dd-MM-yyyy", "yyyy-MM-dd" },
                System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                return dt;
            if (DateTime.TryParse(s, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dt))
                return dt;
            return DBNull.Value;
        }

        private static DataSet Tds26ASStatus(string status, string msg)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("STATUS", typeof(string));
            dtbl.Columns.Add("MSG", typeof(string));
            dtbl.Rows.Add(status, msg);
            ds.Tables.Add(dtbl);
            return ds;
        }

        // Keep an unprocessable file for inspection under _failed, and clear the
        // original so a retry does not collide (same convention as the bank upload).
        private static void Tds26ASPreserveFailed(string uploadDir, string filePath, string fileName)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string failedDir = Path.Combine(uploadDir, "_failed");
                    if (!Directory.Exists(failedDir)) Directory.CreateDirectory(failedDir);
                    string keep = Path.Combine(failedDir, fileName);
                    if (File.Exists(keep)) File.Delete(keep);
                    File.Move(filePath, keep);
                }
            }
            catch { /* keeping a copy is best-effort */ }
        }

        #endregion
    }
}

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
namespace Manilal_V5NG.Controllers.AccountsFraBLL
{
    public class AccountsFraController : ApiController
    {
        /**************************************Auto (Excel/CSV) Purchase API Start Here****************************************/
        // Consolidated from AutoPurchaseController. Angular port of
        // UI/AccountsFra/frm_AccFra_Tran_Purchase_Excel_IU.aspx (+ .vb + js).
        // Categories: 1 = GENERAL EXCEL (.xls) | 2 = SWISS PORT EXCEL (.xls/.xlsx)
        //             3/4 = FRANCE HANDLING CSV (.csv)
        private const string ConsolePurchaseFolder = "~/DATA/CONSOLE_PURCHASE/";

        // 1. Dropdowns (suppliers, supplier addresses, file categories) + the
        //    purchase-date validation message. Mirrors Fill_DropDown() in the .vb.
        [HttpGet]
        public IHttpActionResult FillDropDown([FromUri] string citycode)
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_FILL_DROPDOWN_NG",
                    (citycode == null) ? "" : citycode);

                dsDateValidate = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_PURCHASE_DATE_VALIDATE", "", 268, 0);

                if (dsDateValidate.Tables.Count > 0)
                {
                    dsDateValidate.Tables[0].TableName = "DATE_VALIDATE";
                    ds.Tables.Add(dsDateValidate.Tables[0].Copy());
                    dsDateValidate.Clear();
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/FillDropDown");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 2. Category 1 - GENERAL EXCEL (.xls). Saves the file, bulk-loads it into
        //    TBL_ACCFRA_CONSPUR_GENERAL_EXL, stages it (USP_ACCFRA_CONSPUR_EXL_TMP_IU)
        //    and returns the validated account details.
        [HttpPost]
        [Route("api/AccountsFra/UploadGeneralExcel")]
        public IHttpActionResult UploadGeneralExcel()
        {
            var request = HttpContext.Current.Request;
            var cmpid = request.Params["cmpid"];
            var vguid = request.Params["vguid"];
            var postedfile = request.Files["file"];
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                if (postedfile == null || postedfile.ContentLength == 0)
                    return Ok(StatusDataSet("105", "Please select file."));

                string fileName = Path.GetFileName(postedfile.FileName);
                if (!string.Equals(Path.GetExtension(fileName), ".xls", StringComparison.OrdinalIgnoreCase))
                    return Ok(StatusDataSet("105", "Invalid File Selected! Please Select xls File."));

                string filePath = HttpContext.Current.Server.MapPath(ConsolePurchaseFolder) + fileName;
                if (File.Exists(filePath))
                    return Ok(StatusDataSet("104", fileName + " File Already Exists - Please Check"));

                postedfile.SaveAs(filePath);

                // Read the sheet and bulk-copy it into the general staging table.
                BulkLoadGeneralExcel(filePath);

                // Stage the raw rows into the per-session purchase temp.
                objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_TMP_IU", cmpid, vguid);

                // Validate + fetch the account details / totals for the grid.
                ds = BuildValidationResult(vguid, fileName);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/UploadGeneralExcel");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 3. Category 2 - SWISS PORT EXCEL (.xls / .xlsx).
        [HttpPost]
        [Route("api/AccountsFra/UploadSwissExcel")]
        public IHttpActionResult UploadSwissExcel()
        {
            var request = HttpContext.Current.Request;
            var cmpid = request.Params["cmpid"];
            var vguid = request.Params["vguid"];
            var purchaseDate = request.Params["purchasedate"];
            var vatAmt = request.Params["vatamt"];
            var netAmt = request.Params["netamt"];
            var postedfile = request.Files["file"];
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                if (postedfile == null || postedfile.ContentLength == 0)
                    return Ok(StatusDataSet("105", "Please select file."));

                string fileName = Path.GetFileName(postedfile.FileName);
                string ext = Path.GetExtension(fileName);
                if (!string.Equals(ext, ".xls", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(ext, ".xlsx", StringComparison.OrdinalIgnoreCase))
                    return Ok(StatusDataSet("105", "Invalid File Selected! Please Select xls or xlsx File."));

                string filePath = HttpContext.Current.Server.MapPath(ConsolePurchaseFolder) + fileName;
                if (File.Exists(filePath))
                    return Ok(StatusDataSet("104", fileName + " File Already Exists - Please Check"));

                postedfile.SaveAs(filePath);
                BulkLoadSwissExcel(filePath, ext);

                // Stage into the swiss temp.
                DataSet dsTmp = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_SWISS_TMP_IU", cmpid, vguid);
                if (StatusEquals(dsTmp, "103"))
                    return Ok(StatusDataSet("103", "IN A ROW PREFIX AND HAWBNO CANNOT BE BLANK !"));

                // Validate the staged swiss rows.
                DataSet dsChk = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_SWISS_VAL_CHK_TMP", vguid);
                if (StatusEquals(dsChk, "102"))
                    return Ok(StatusDataSet("102", StatusMessage(dsChk)));

                // Fetch the account details / totals for the grid.
                DataSet dsDtls = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_SWISS_GETDTLS",
                    vguid, cmpid, purchaseDate, vatAmt, netAmt, fileName);
                if (StatusEquals(dsDtls, "103"))
                    return Ok(StatusDataSet("103", StatusMessage(dsDtls)));

                // Normalise to the common { Table, Table1, Table2(details), Table3(totals) } shape.
                DataTable details = dsDtls.Tables.Count > 1 ? dsDtls.Tables[1].Copy() : new DataTable();
                DataTable totals = dsDtls.Tables.Count > 2 ? dsDtls.Tables[2].Copy() : new DataTable();
                ds = ComposeResult("100", "", details, totals, null);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/UploadSwissExcel");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 4. Category 3 / 4 - FRANCE HANDLING CSV (.csv). Bill no / purchase date /
        //    to-be-paid date are read out of the CSV and returned in META.
        [HttpPost]
        [Route("api/AccountsFra/UploadFranceCsv")]
        public IHttpActionResult UploadFranceCsv()
        {
            var request = HttpContext.Current.Request;
            var cmpid = request.Params["cmpid"];
            var vguid = request.Params["vguid"];
            var categoryid = request.Params["categoryid"];
            var supplier = request.Params["supplier"];
            var postedfile = request.Files["file"];
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                if (postedfile == null || postedfile.ContentLength == 0)
                    return Ok(StatusDataSet("105", "Please select file."));

                string fileName = Path.GetFileName(postedfile.FileName);
                if (!string.Equals(Path.GetExtension(fileName), ".csv", StringComparison.OrdinalIgnoreCase))
                    return Ok(StatusDataSet("105", "Invalid File Selected! Please Select csv File."));

                string filePath = HttpContext.Current.Server.MapPath(ConsolePurchaseFolder) + fileName;
                if (File.Exists(filePath))
                    return Ok(StatusDataSet("104", fileName + " File Already Exists - Please Check"));

                postedfile.SaveAs(filePath);

                // Parse + stage the CSV. Returns status in Table[0] and the parsed
                // header values (bill no / purchase date / paid date) in Table[1].
                DataSet dsFr = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_CSV_FRAHAND_TMP_IU_NG",
                    filePath, vguid, cmpid, categoryid);

                if (!StatusEquals(dsFr, "100"))
                    return Ok(StatusDataSet("102", StatusMessage(dsFr)));

                string billNo = "", purDate = "", paidDate = "";
                if (dsFr.Tables.Count > 1 && dsFr.Tables[1].Rows.Count > 0)
                {
                    DataRow r = dsFr.Tables[1].Rows[0];
                    billNo = SafeCol(r, "FACTURE", 0);
                    purDate = SafeCol(r, "PURDATE", 1);
                    paidDate = SafeCol(r, "PDT", 2);
                }

                // Log the invoice against the supplier (dupe-check happens in the SP).
                DataSet dsLog = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_LOG_IU",
                    cmpid, fileName, filePath, supplier, billNo, vguid, categoryid);
                if (StatusEquals(dsLog, "104"))
                {
                    string supName = dsLog.Tables[0].Columns.Contains("SUPPLIERNAME")
                        ? Convert.ToString(dsLog.Tables[0].Rows[0]["SUPPLIERNAME"]) : "";
                    string oldEntry = dsLog.Tables[0].Columns.Contains("ENTRYNO")
                        ? Convert.ToString(dsLog.Tables[0].Rows[0]["ENTRYNO"]) : "";
                    return Ok(StatusDataSet("104",
                        "Invoice No " + billNo + " of supplier " + supName +
                        " already accounted vide Purchase Entry " + oldEntry));
                }

                // Validate + fetch details, then attach the header meta values.
                ds = BuildValidationResult(vguid, fileName);
                DataTable meta = new DataTable("META");
                meta.Columns.Add("BILLNO");
                meta.Columns.Add("PURDATE");
                meta.Columns.Add("PDT");
                meta.Rows.Add(billNo, purDate, paidDate);
                ds.Tables.Add(meta);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/UploadFranceCsv");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 5. Final "Save entry" - generates the purchase entry.
        [HttpPost]
        public IHttpActionResult SavePurchase([FromBody] AutoPurchaseSaveRequest obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                // _NG variant (17 params, incl. SUP_ADDRID) - present in live manilal.
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_PUR_GENERATE_NG",
                    obj.ID, obj.ENTRYNO, obj.ENTRYDATE, obj.SUPPLIER, obj.BILLNO, obj.PAIDDT, obj.TOT_EURO,
                    obj.CMPID, obj.CITYCODE1, obj.CMP_CODE, obj.MAKERIP, obj.GUID, obj.CITYCODE,
                    obj.StrFilename, obj.CATID, obj.SUPINVDT, obj.SUP_ADDRID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/SavePurchase");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 6. Reset - clears the per-session temp rows.
        [HttpPost]
        public IHttpActionResult ResetAll([FromBody] AutoPurchaseResetRequest obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_TRAN_CONSPUR_EXL_RESET_ALL",
                    (obj != null) ? obj.GUID : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ResetAll");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        // 7. Download the comparison-purchase Excel (categories 2 & 4).
        [HttpGet]
        [Route("api/AccountsFra/DownloadCompareReport")]
        public HttpResponseMessage DownloadCompareReport([FromUri] string entryno, [FromUri] string cateid,
            [FromUri] string cmpid, [FromUri] string guid)
        {
            DAL objDal = new DAL();
            try
            {
                DataSet ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_SWISS_RPT",
                    guid, cmpid, cateid);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(ds.GetXml());
                string excel = CommonFunction.ConvertToExcel_open("AccountsFra",
                    "XSL_AccFra_Tran_Purchase_Exl_RPT.xsl", xmlDoc);

                byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(excel));
                MemoryStream stream = new MemoryStream(byteArray);
                stream.WriteTo(HttpContext.Current.Response.OutputStream);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                response.Content.Headers.ContentDisposition.FileName = "COMPARE_PURCHASE_" + entryno + ".xls";
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                return response;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/DownloadCompareReport");
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            finally
            {
                objDal.Dispose();
            }
        }

        // ---- Auto-purchase helpers ------------------------------------------------

        /// <summary>
        /// Runs the combined validation-check-and-get-details SPs for the general /
        /// CSV categories, normalised into { Table(status), Table1, Table2(details), Table3(totals) }.
        /// </summary>
        private DataSet BuildValidationResult(string guid, string fileName)
        {
            DAL objDal = new DAL();
            try
            {
                DataSet chk = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_VAL_CHK_TMP_NG",
                    guid, fileName);

                if (!StatusEquals(chk, "100"))
                    return StatusDataSet(FirstStatus(chk), StatusMessage(chk));

                DataSet dtls = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_GETDTLS", guid);

                DataTable details = dtls.Tables.Count > 1 ? dtls.Tables[1].Copy() : new DataTable();
                DataTable totals = dtls.Tables.Count > 2 ? dtls.Tables[2].Copy() : new DataTable();
                return ComposeResult("100", "", details, totals, null);
            }
            finally
            {
                objDal.Dispose();
            }
        }

        /// <summary>Reads + bulk-copies a general purchase .xls into TBL_ACCFRA_CONSPUR_GENERAL_EXL.</summary>
        private void BulkLoadGeneralExcel(string filePath)
        {
            // .xls -> JET (Excel 8.0), .xlsx -> ACE (Excel 12.0). The 32-bit host may
            // lack ACE but has JET, so .xls (all General uploads) reads via JET. All
            // destination columns are varchar, so IMEX=1 (read as text) is safe.
            string ext = Path.GetExtension(filePath);
            string conn = string.Equals(ext, ".xls", StringComparison.OrdinalIgnoreCase)
                ? "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";"
                : "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\";";
            string query = "Select [MAWB_CONTAINER],[HAWB_HBLNO],[JOBNO],[G100052],[G100063],[G100062]," +
                "[G100059],[G100058],[G100018],[G100068],[G100051],[G100061],[G100049],[G100057],[G100066]," +
                "[G101633],[G101632],[G100069],[G101635],[G100100],[G100065],[G100053],[G100077],[G100070]," +
                "[G100032],[G100117],[G100127],[G100094],[G100026],[G102069],[SHORT NARRATION] FROM [Sheet1$]";

            DataSet excelDs = new DataSet();
            using (OleDbConnection excelConn = new OleDbConnection(conn))
            using (OleDbDataAdapter oda = new OleDbDataAdapter(query, excelConn))
            {
                oda.Fill(excelDs);
            }
            DataTable excelDt = excelDs.Tables[0];

            string sqlConn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
            using (SqlConnection con = new SqlConnection(sqlConn))
            using (SqlBulkCopy bulk = new SqlBulkCopy(sqlConn))
            {
                bulk.DestinationTableName = "TBL_ACCFRA_CONSPUR_GENERAL_EXL";
                bulk.ColumnMappings.Add("MAWB_CONTAINER", "MAWBNO");
                bulk.ColumnMappings.Add("HAWB_HBLNO", "HAWBNO");
                bulk.ColumnMappings.Add("JOBNO", "jobno");
                string[] gCols = {
                    "G100052","G100063","G100062","G100059","G100058","G100018","G100068","G100051",
                    "G100061","G100049","G100057","G100066","G101633","G101632","G100069","G101635",
                    "G100100","G100065","G100053","G100077","G100070","G100032","G100117","G100127",
                    "G100094","G100026","G102069" };
                foreach (string c in gCols) { bulk.ColumnMappings.Add(c, c); }
                bulk.ColumnMappings.Add("SHORT NARRATION", "SHORTNARRATION");

                con.Open();
                bulk.WriteToServer(excelDt);
                con.Close();
            }
        }

        /// <summary>Reads + bulk-copies a swissport .xls/.xlsx into TBL_ACCFRA_CONSPUR_SWISS_PORT_EXL.</summary>
        private void BulkLoadSwissExcel(string filePath, string extension)
        {
            string conn = string.Equals(extension, ".xls", StringComparison.OrdinalIgnoreCase)
                ? "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";"
                : "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\";";

            DataSet excelDs = new DataSet();
            using (OleDbConnection excelConn = new OleDbConnection(conn))
            using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excelConn))
            {
                oda.Fill(excelDs);
            }

            string sqlConn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
            using (SqlBulkCopy bulk = new SqlBulkCopy(sqlConn))
            {
                bulk.DestinationTableName = "TBL_ACCFRA_CONSPUR_SWISS_PORT_EXL";
                bulk.WriteToServer(excelDs.Tables[0]);
            }
        }

        /// <summary>Builds a single-row status DataSet: { Table: [ { STATUS, STATUSMSG } ] }.</summary>
        private DataSet StatusDataSet(string status, string message)
        {
            DataSet ds = new DataSet();
            DataTable t = new DataTable("Table");
            t.Columns.Add("STATUS");
            t.Columns.Add("STATUSMSG");
            t.Rows.Add(status, message);
            ds.Tables.Add(t);
            return ds;
        }

        /// <summary>
        /// Normalises an upload result into the common shape the Angular grid reads:
        /// Table (status), Table1 (spacer), Table2 (details), Table3 (totals).
        /// </summary>
        private DataSet ComposeResult(string status, string message, DataTable details, DataTable totals, DataTable meta)
        {
            DataSet ds = new DataSet();

            DataTable t0 = new DataTable("Table");
            t0.Columns.Add("STATUS");
            t0.Columns.Add("STATUSMSG");
            t0.Rows.Add(status, message);
            ds.Tables.Add(t0);

            ds.Tables.Add(new DataTable("Table1"));

            details = details ?? new DataTable();
            details.TableName = "Table2";
            ds.Tables.Add(details);

            totals = totals ?? new DataTable();
            totals.TableName = "Table3";
            ds.Tables.Add(totals);

            if (meta != null)
            {
                meta.TableName = "META";
                ds.Tables.Add(meta);
            }
            return ds;
        }

        /// <summary>True when the first row's STATUS column of table[0] equals the given code.</summary>
        private bool StatusEquals(DataSet ds, string code)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return false;
            DataTable t = ds.Tables[0];
            object val = t.Columns.Contains("STATUS") ? t.Rows[0]["STATUS"] : t.Rows[0][0];
            return string.Equals(Convert.ToString(val), code, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Reads the status code (STATUS, or 1st column) from table[0].</summary>
        private string FirstStatus(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return "";
            DataTable t = ds.Tables[0];
            object val = t.Columns.Contains("STATUS") ? t.Rows[0]["STATUS"] : t.Rows[0][0];
            return Convert.ToString(val);
        }

        /// <summary>Reads the status message (STATUSMSG, or 2nd column) from table[0].</summary>
        private string StatusMessage(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0) return "";
            DataTable t = ds.Tables[0];
            if (t.Columns.Contains("STATUSMSG")) return Convert.ToString(t.Rows[0]["STATUSMSG"]);
            return t.Columns.Count > 1 ? Convert.ToString(t.Rows[0][1]) : "";
        }

        /// <summary>Reads a column by name, falling back to an ordinal index if absent.</summary>
        private string SafeCol(DataRow r, string name, int ordinalFallback)
        {
            if (r.Table.Columns.Contains(name)) return Convert.ToString(r[name]).Trim();
            return r.Table.Columns.Count > ordinalFallback ? Convert.ToString(r[ordinalFallback]).Trim() : "";
        }
        /**************************************Master API Start Here****************************************/
        /// <summary>Perform deliverynotinvoiced exporttoxl records.</summary>
        /// <param name="frmdt">Start date for the date range filter.</param>
        /// <param name="todt">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage acc_deliverynotinvoiced_exporttoxl(string frmdt, string todt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "Xsl_Accfra_Rpt_Delivery_NotInvoiced.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_DELIVERY_NOTINVOICED", (frmdt == null) ? "" : frmdt, (todt == null) ? "" : todt);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "deliverynotinvoiced" + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform DELIVERY NOTINVOICED records.</summary>
        /// <param name="Fromdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_DELIVERY_NOTINVOICED(string Fromdt, string Todt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_DELIVERY_NOTINVOICED", (Fromdt == null) ? "" : Fromdt, (Todt == null) ? "" : Todt);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_DELIVERY_NOTINVOICED");
            }
            return Ok(ds);
        }
        /// <summary>Perform BRAND ORIGIN MONTH WISE TONNAGE SUMMARY records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage ACCFRA_BRAND_ORIGIN_MONTH_WISE_TONNAGE_SUMMARY([FromUri]string fromdate, string todate, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;



            strSpName = "USP_ACCFRA_BRAND_ORIGIN_MONTH_WISE_TONNAGE_SUMMARY_NG";
            strXslFilename = "Xsl_Accfra_Rpt_Brand_Origin_Tonnage_Summary.xsl";

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, fromdate, todate, mode);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            strData = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Brand Origin Tonnage Summary.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
        /// <summary>Perform GENERAL ACCOUNT WISE TURNOVER SUMMARY records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="GAccount">GAccount parameter.</param>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage ACCFRA_GENERAL_ACCOUNT_WISE_TURNOVER_SUMMARY(string FromDate, string ToDate, string GAccount, string Client, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;

            if (Type == "GAccount")
            {
                strSpName = "USP_ACCFRA_GENERAL_ACCOUNT_TURNOVER";
                strXslFilename = "xsl_Accfra_Rpt_General_Account_TurnOver.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, FromDate, ToDate, GAccount);
            }
            else
            {
                strSpName = "USP_ACCFRA_CLIENT_ND_ORIGIN_WISE_TURNOVER_SUMMARY";
                strXslFilename = "Xsl_AccFra_Rpt_Client_nd_Origin_wise_Turnover_Summary.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, FromDate, ToDate, (Client == null) ? "" : Client, Type);
            }


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            strData = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "TurnOverSummary.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
        /// <summary>Populate form with existing data for FILLCLIENT GENERAL ACCOUNT records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE_NG"
                  );
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE");
            }
            finally
            {
                objDal.Dispose();
            }

            return Ok(ds);
        }
        /// <summary>Perform CLIENT WISE TURNOVER SUMMARY records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY(string FromDate, string ToDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY",
                  FromDate, ToDate);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY");
            }
            finally
            {
                objDal.Dispose();
            }

            return Ok(ds);
        }
        /// <summary>Retrieve list of REPORT REGISTER INVOICE records.</summary>
        /// <param name="CLIENT">Client/exporter code.</param>
        /// <param name="FROMDT">Start date for the date range filter.</param>
        /// <param name="TODT">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_REPORT_REGISTER_INVOICE_NG(string CLIENT, string FROMDT, string TODT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_acctfra_rpt_clientinv_register.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_REPORT_REGISTER_INVOICE_NG", CLIENT, FROMDT, TODT);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Accountsfra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CLIENT + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Retrieve list of CLIENT INVOICE REGISTER records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CLIENT_INVOICE_REGISTER_NG(string client, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_REPORT_REGISTER_INVOICE_NG", client, fromdate, todate);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CLIENT_INVOICE_REGISTER_NG");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of RPT CREDIT NOTE records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_RPT_CREDIT_NOTE_REGISTER(string fromdate, string todate, string citycode, string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_RPT_CREDITNOTE_REGISTER", fromdate, todate, citycode, type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_RPT_CREDIT_NOTE_REGISTER");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for TRAN PURCHASE EXL RESET ALL records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_TRAN_PURCHASE_EXL_RESET_ALL([FromBody]PurchaseDetailsIu obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_TRAN_CONSPUR_EXL_RESET_ALL", obj.Guid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_TRAN_PURCHASE_EXL_RESET_ALL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update TRANS PURCHASE EXL records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_TRANS_PURCHASE_EXL_IU([FromBody]AutoPurchase obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_CONSPUR_EXL_PUR_GENERATE_NG",
                    obj.ID, obj.ENTRYNO, obj.ENTRYDATE, obj.SUPPLIER, obj.BILLNO, obj.PAIDDT, obj.TOT_EURO,
                    obj.CMPID, obj.CITYCODE1, obj.CMP_CODE, obj.MAKERIP, obj.GUID, obj.CITYCODE, obj.StrFilename,
                    obj.CATID, obj.SUPINVDT, obj.SUP_ADDRID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_TRANS_PURCHASE_EXL_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
       
        /// <summary>Perform CONSPUR EXL VAL CHK TMP records.</summary>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <param name="StrFileName">Str File Name parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CONSPUR_EXL_VAL_CHK_TMP(string GUID, string StrFileName)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_VAL_CHK_TMP_NG", GUID, StrFileName);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CONSPUR_EXL_VAL_CHK_TMP");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Upload UploadExcel records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        [Route("api/AccountsFra/UploadExcel")]
        public IHttpActionResult UploadExcel()
        {
            string fileName = null;
            var httpRequest = HttpContext.Current.Request;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var postedfile = httpRequest.Files["file"];
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (postedfile != null)
            {
                fileName = Path.GetFileName(postedfile.FileName);
                // var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\EInvoice\\ResponseIrn\\", fileName);
                //fileName = new String(Path.GetFileNameWithoutExtension(postedfile.FileName).Take(10).ToArray()).Replace(" ", ".");
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedfile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/DATA/CONSOLE_PURCHASE/") + fileName;
                if (File.Exists(filePath))
                {
                    DataTable table = new DataTable();
                    table.TableName = "Table";
                    table.Columns.Add("STATUS", typeof(int));
                    table.Columns.Add("STATUSMSG", typeof(string));
                    DataRow row = table.NewRow();
                    row["STATUS"] = 104; // Status code
                    row["STATUSMSG"] = fileName + " File Already Exists - Please Check"; // Message
                    table.Rows.Add(row);
                    ds.Tables.Add(table);
                }
                else
                {
                    postedfile.SaveAs(filePath);
                    ds = fN_upload_ExcelFile(fileName, cmpid, vguid);
                }
            }

            // return Request.CreateResponse(HttpStatusCode.Created);
            //return  "success";
            return Ok(ds);

        }
        public DataSet fN_upload_ExcelFile(string strFileName, string CMPID, string VGUID)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();
            DataSet ds_fst = new DataSet();
            DAL objDal = new DAL();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strFilePath;
                // strFilePath = HttpContext.Current.Server.MapPath(@"..\") + @"DATA\EInvoice\ResponseIrn\" + strFileName;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\CONSOLE_PURCHASE\\" + strFileName);


                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                // If transtype = "INV" Then
                Query = string.Format("Select [MAWB_CONTAINER],[HAWB_HBLNO],[JOBNO],[G100052],[G100063],[G100062],[G100059],[G100058],[G100018],[G100068],[G100051],[G100061],[G100049],[G100057],[G100066],[G101633],[G101632],[G100069],[G101635],[G100100],[G100065],[G100053],[G100077],[G100070],[G100032],[G100117],[G100127],[G100094],[G100026],[G102069],[SHORT NARRATION] FROM [{0}]", "Sheet1$");
                // ElseIf transtype = "CN" Then
                // Query = String.Format("Select [IRN],[Ack No],[Ack Date],[Doc No],[Doc Date],[Signed QR Code] FROM [{0}]", "Sheet1$")
                // End If

                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);

                // assigning Destination table name    
                objbulk.DestinationTableName = "TBL_ACCFRA_CONSPUR_GENERAL_EXL";
                // Mapping Table column    
                objbulk.ColumnMappings.Add("MAWB_CONTAINER", "MAWBNO");
                objbulk.ColumnMappings.Add("HAWB_HBLNO", "HAWBNO");
                objbulk.ColumnMappings.Add("JOBNO", "jobno");
                objbulk.ColumnMappings.Add("G100052", "G100052");
                objbulk.ColumnMappings.Add("G100063", "G100063");
                objbulk.ColumnMappings.Add("G100062", "G100062");
                objbulk.ColumnMappings.Add("G100059", "G100059");
                objbulk.ColumnMappings.Add("G100058", "G100058");
                objbulk.ColumnMappings.Add("G100018", "G100018");
                objbulk.ColumnMappings.Add("G100068", "G100068");
                objbulk.ColumnMappings.Add("G100051", "G100051");
                objbulk.ColumnMappings.Add("G100061", "G100061");
                objbulk.ColumnMappings.Add("G100049", "G100049");
                objbulk.ColumnMappings.Add("G100057", "G100057");
                objbulk.ColumnMappings.Add("G100066", "G100066");
                objbulk.ColumnMappings.Add("G101633", "G101633");
                objbulk.ColumnMappings.Add("G101632", "G101632");
                objbulk.ColumnMappings.Add("G100069", "G100069");
                objbulk.ColumnMappings.Add("G101635", "G101635");
                objbulk.ColumnMappings.Add("G100100", "G100100");
                objbulk.ColumnMappings.Add("G100065", "G100065");
                objbulk.ColumnMappings.Add("G100053", "G100053");
                objbulk.ColumnMappings.Add("G100077", "G100077");
                objbulk.ColumnMappings.Add("G100070", "G100070");
                objbulk.ColumnMappings.Add("G100032", "G100032");
                objbulk.ColumnMappings.Add("G100117", "G100117");
                objbulk.ColumnMappings.Add("G100127", "G100127");
                objbulk.ColumnMappings.Add("G100094", "G100094");
                objbulk.ColumnMappings.Add("G100026", "G100026");
                objbulk.ColumnMappings.Add("G102069", "G102069");
                objbulk.ColumnMappings.Add("SHORT NARRATION", "SHORTNARRATION");

                // inserting Datatable Records to DataBase    
                con.Open();

                /* TODO Change to default(_) if this is not a reference type */
                ;
                objbulk.WriteToServer(Exceldt);
                con.Close();
                //ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_EINVOICE_UPLOAD_XL_UPDATEGSTIRN", CMPID, MAKERIP, VGUID, strFileName, strFilePath, transtype);
                ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_EXL_TMP_IU", CMPID, VGUID);
            }

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
            }
            //return "success";
            return ds_fst;
        }

        /// <summary>Upload UploadCSV records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        [Route("api/AccountsFra/UploadCSV")]
        public IHttpActionResult UploadCSV()
        {
            string fileName = null;
            var httpRequest = HttpContext.Current.Request;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var categoryid = HttpContext.Current.Request.Params["categoryid"];
            var postedfile = httpRequest.Files["file"];
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            if (postedfile != null)
            {
                fileName = Path.GetFileName(postedfile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/DATA/CONSOLE_PURCHASE/") + fileName;
                if (File.Exists(filePath))
                {
                    DataTable table = new DataTable();
                    table.TableName = "Table";
                    table.Columns.Add("STATUS", typeof(int));
                    table.Columns.Add("STATUSMSG", typeof(string));
                    DataRow row = table.NewRow();
                    row["STATUS"] = 104; // Status code
                    row["STATUSMSG"] = fileName + " File Already Exists - Please Check"; // Message
                    table.Rows.Add(row);
                    ds.Tables.Add(table);
                }
                else
                {
                    postedfile.SaveAs(filePath);
                    ds = fN_Upload_France_Handling(fileName, cmpid, vguid, categoryid);
                }
            }

            // return Request.CreateResponse(HttpStatusCode.Created);
            //return  "success";
            return Ok(ds);

        }
        public DataSet fN_Upload_France_Handling(string strFileName, string CMPID, string VGUID, string CategoryId)
        {

            DataSet dS_FR = new DataSet();
            DataSet MP_DS = new DataSet();
            DataSet ds_fst = new DataSet();
            DAL objDal = new DAL();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strFilePath;
                // strFilePath = HttpContext.Current.Server.MapPath(@"..\") + @"DATA\EInvoice\ResponseIrn\" + strFileName;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\CONSOLE_PURCHASE\\" + strFileName);
              
                // file.SaveAs(strFilePath);

                ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONSPUR_CSV_FRAHAND_TMP_IU_NG", strFilePath, VGUID, CMPID, CategoryId);
            }

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/fN_Upload_France_Handling");
            }
            //return "success";
            return ds_fst
                ;


        }
        /// <summary>Retrieve print/view data for CREDIT records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_VIEW(string INVNO, string cmp_code, string CMPID, string citycode1, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDITNOTE_VIEW_NG", INVNO, cmp_code, CMPID, citycode1, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for CREDITNOTE PRINTVIEW records.</summary>
        /// <param name="CRTNO">CRTNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDITNOTE_PRINTVIEW(string CRTNO, string CMPCODE, string CMPID, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDITNOTE_VIEW_FORAUTH", CRTNO, CMPCODE, CMPID, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDITNOTE_PRINTVIEW");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve CREDIT SEARCH records.</summary>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="Value">Search filter value.</param>
        /// <param name="Value1">Search filter value.</param>
        /// <param name="Value2">Search filter value.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_SEARCH_LIST(string SearchType, string Value, string Value1, string Value2)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_SEARCH_LIST", SearchType, (Value == null) ? "" : Value, (Value1 == null) ? "" : Value1, (Value2 == null) ? "" : Value2);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_SEARCH_LIST");
            }
            return Ok(ds);
        }


        /// <summary>Retrieve dropdown data for CLIENT IMP Common FillClient records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CLIENT_IMP_Common_FillClient(string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_Common_FillClient_Address", citycode);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CLIENT_IMP_Common_FillClient");
            }
            return Ok(ds);
        }        

        /// <summary>Perform CREDITNOTE AUTHORISE ASSIGN records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_CREDITNOTE_AUTHORISE_ASSIGN([FromBody]Authorisation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONS_CREDITNOTE_AUTHORISE_ASSIGN", obj.CRTNO, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDITNOTE_AUTHORISE_ASSIGN");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform CREDIT GET BILLNO records.</summary>
        /// <param name="b">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_CREDIT_GET_BILLNO([FromBody] creditnotebill b)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_GET_BILLNO", b.BILLNO, b.AMT, b.VGUID, b.CMPID, b.client);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_GET_BILLNO");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update AUTO CREDIT ACCOUNTDET TMP records.</summary>
        /// <param name="n">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_AUTO_CREDIT_ACCOUNTDET_TMP_IU([FromBody] creditnotechr n)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_ACCOUNTDET_TMP_IU", (n.ID != null) ? n.ID : "", (n.INVNO != null) ? n.INVNO : "", n.CHRGCODE, n.ACCOUNT, n.CHRGDESC, n.CHRGDESC1, n.TAXABLE, n.AMTEURO, n.IsEdit, n.CMPID, n.EX_RATE, (n.TMP_STR != null) ? n.TMP_STR : "", n.CITYCODE, n.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_CREDIT_ACCOUNTDET_TMP_IU");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update AUTO CREDIT ENCLOSURE TMP records.</summary>
        /// <param name="c">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_AUTO_CREDIT_ENCLOSURE_TMP_IU([FromBody] Creditnoteclosure c)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_ENCLOSURE_TMP_IU", (c.ID != null) ? c.ID : "", (c.INVNO != null) ? c.INVNO : "", c.ENCLOSURE, c.CMPID, c.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_CREDIT_ENCLOSURE_TMP_IU");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for CREDIT FILL JOB records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_FILL_JOB([FromUri]Filjobcreditnote m)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_CREDIT_FILLJOBNO", (m.SEARCH_MODE != null) ? m.SEARCH_MODE : "", (m.JOBNO != null) ? m.JOBNO : "", (m.REM_JOBNO != null) ? m.REM_JOBNO : "", m.cmpid, m.client, m.CITYCODE, m.vguid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_FILL_JOB");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for CREDIT records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_RESET(string INVNO, string CMPID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_RESET", INVNO, CMPID, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_RESET");
            }
            return Ok(ds);
        }

        /// <summary>Delete CREDIT BILLNO records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_BILLNO_DELETE(string ID, string VGUID, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_BILLNO_DELETE", ID, VGUID, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_BILLNO_DELETE");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update CREDIT records.</summary>
        /// <param name="S">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_CREDIT_IU([FromBody] Creditubmit S)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_IU_NG", S.INVNO, S.INVDT, (S.PAYDT != null) ? S.Typ_pkgs : "", S.client, S.NOOF_PKS, (S.Typ_pkgs != null) ? S.Typ_pkgs : "", (S.Clent_Ref != null) ? S.Clent_Ref : "", S.NoofPcs, S.Wt_Kilo, S.CHBLWT, S.HAWBNO, (S.HAWBDT != null) ? S.HAWBDT : "", S.Vref, (S.Carrier != null) ? S.Carrier : "", (S.ETD != null) ? S.ETD : "", (S.ETA != null) ? S.ETA : "", S.CUR_ID, S.EX_Rate, S.CMP_CODE, S.citycode, S.citycode1, S.CMPID, S.Chk_Print, S.VGUID,(S.CRT_ADDID != null) ? S.CRT_ADDID : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_IU");
            }
            return Ok(ds);
        }
        /// <summary>Delete CREDIT DELETE ACCOUNTDET records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="EXCHANGE_RATE">EXCHANGE RATE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_DELETE_ACCOUNTDET(string ID, string CMPID, string EXCHANGE_RATE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_ACCOUNTDET_DELETE", ID, CMPID, EXCHANGE_RATE, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_DELETE_ACCOUNTDET");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for CREDIT FILL JOB ModelPop records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="JOBNO">Job number.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_FILL_JOB_ModelPop(string client, string JOBNO, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_CREDIT_FILL_JOB", client, JOBNO, CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_FILL_JOB_ModelPop");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Delete CREDIT DELETE ENCLOSURE records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_CREDIT_DELETE_ENCLOSURE(string ID, string CMPID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CREDIT_ENCLOSURE_DELETE", ID, CMPID, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_CREDIT_DELETE_ENCLOSURE");
            }
            return Ok(ds);
        }

       
        /// <summary>Perform PrintPurchase records.</summary>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_PrintPurchase(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_TRAN_PURCHASE_PRINT", EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_PrintPurchase");
            }
            return Ok(ds);
        }
        /// <summary>Perform INVOICE CLIENT REFRESH records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="EXPCODE">EXPCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_CLIENT_REFRESH(string VGUID, string MAKERID, string EXPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_CLIENT_REFRESH", VGUID, MAKERID, EXPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_CLIENT_REFRESH");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for Print Purchase records.</summary>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_Print_Purchase(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_IMP_PRINT_PURCHASE", EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_Print_Purchase");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for TRAN PURCHASE records.</summary>
        /// <param name="EntryNo">Entry No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_TRAN_PURCHASE_VIEW(string EntryNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_TRAN_PURCHASE_VIEW", EntryNo);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_TRAN_PURCHASE_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Perform CONS INVOICE AUTHORISE ASSIGN records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_CONS_INVOICE_AUTHORISE_ASSIGN([FromBody]Authorisation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONS_INVOICE_AUTHORISE_ASSIGN", obj.INVOICENO, obj.CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CONS_INVOICE_AUTHORISE_ASSIGN");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for INV PRINT AUTHORISATION records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INV_PRINT_AUTHORISATION(string cmpid, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INV_PRINT_AUTHORISATION", cmpid, Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INV_PRINT_AUTHORISATION");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for Print Invoice records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="Printeuro">Printeuro parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_Print_Invoice(string INVNO, string Printeuro, string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_IMP_PRINT_INVOICE", INVNO, Printeuro, CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_Print_Invoice");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for Common FillClient Address records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_Common_FillClient_Address(string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_Common_FillClient_Address", citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/IMP_Common_FillClient_Address");
            }
            return Ok(ds);
        }
        /// <summary>Validate INVOICE DATE records.</summary>
        /// <param name="DATE">DATE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_DATE_VALIDATE(string DATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_DATE_VALIDATE", DATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_DATE_VALIDATE");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve INVOICE SEARCH records.</summary>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="Value">Search filter value.</param>
        /// <param name="Value1">Search filter value.</param>
        /// <param name="Value2">Search filter value.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_SEARCH_LIST(string SearchType, string Value, string Value1, string Value2)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_SEARCH_LIST", SearchType, (Value == null) ? "" : Value, (Value1 == null) ? "" : Value1, (Value2 == null) ? "" : Value2);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_SEARCH_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for INVOICE RESET JSON records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_RESET_JSON(string INVNO, string CMPID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_RESET", (INVNO != null) ? INVNO : "", CMPID, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_RESET_JSON");
            }
            return Ok(ds);
        }
        /// <summary>Delete INVOICE DELETE ACCOUNTDET JSON records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="EXCHANGERATE">EXCHANGERATE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_DELETE_ACCOUNTDET_JSON(string ID, string CMPID, string EXCHANGERATE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_ACCOUNTDET_DELETE", ID, CMPID, EXCHANGERATE, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_DELETE_ACCOUNTDET_JSON");
            }
            return Ok(ds);
        }
        /// <summary>Delete INVOICE DELETE ENCLOSURE JSON records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_DELETE_ENCLOSURE_JSON(string ID, string CMPID, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_ENCLOSURE_DELETE", ID, CMPID, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_DELETE_ENCLOSURE_JSON");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for INVOICE records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_VIEW(string INVNO, string CMPCODE, string CMPID, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_VIEW_NG", INVNO, CMPCODE, CMPID, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for AUTO INVOICE records.</summary>
        /// <param name="INVNO">Invoice number.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_AUTO_INVOICE_VIEW(string INVNO, string CMPCODE, string CMPID, string CITYCODE1, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_AUTO_INVOICE_VIEW_NG", INVNO, CMPCODE, CMPID, CITYCODE1, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_INVOICE_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for INVOICE records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_PAGELOAD([FromUri]Filjobdata b)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_INVOICE_PAGELOAD", b.SEARCH_TYPE, b.INV_TYPE, (b.JOBNO != null) ? b.JOBNO : "", (b.REM_JOBNO != null) ? b.REM_JOBNO : "", b.MODE, b.cmpid, b.client, b.CITYCODE, b.vguid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for INVOICE FILL JOB records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_INVOICE_FILL_JOB([FromUri]Filjob j)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_INVOICE_FILL_JOB", (j.SEARCH_MODE != null) ? j.SEARCH_MODE : "", j.client, j.INV_TYPE, (j.FRM_DT != null) ? j.FRM_DT : "", (j.TO_DT != null) ? j.TO_DT : "", j.MODE, j.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_FILL_JOB");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for AUTO INVOICE RATE ENTRY records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_AUTO_INVOICE_RATE_ENTRY_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_AUTO_INVOICE_RATE_ENTRY_PAGELOAD");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_INVOICE_RATE_ENTRY_PAGELOAD");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for CLIENT  IMP Common FillClient records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CLIENT__IMP_Common_FillClient(string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_Common_FillClients", citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CLIENT__IMP_Common_FillClient");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update INVOICE IU JSON records.</summary>
        /// <param name="main">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_INVOICE_IU_JSON([FromBody] InvFraMain main)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_IU_NG", main.INVNO, main.INVDT, main.PAYDT, main.INV_TYPE, main.MODE, main.client, main.NOOF_PKS, main.Typ_pkgs, (main.Clent_Ref != null) ? main.Clent_Ref : "", main.NoofPcs, main.Wt_Kilo, main.CHBLWT, main.HAWBNO, main.HAWBDT, (main.Vref != null) ? main.Vref : "", main.Carrier, (main.ETD != null) ? main.ETD : "", (main.ETA != null) ? main.ETA : "", main.CUR_ID, main.EX_Rate, main.CMP_CODE, main.citycode, main.citycode1, main.CMPID, "0", main.VGUID, (main.Inv_AddId != null) ? main.Inv_AddId : "0");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_INVOICE_IU_JSON");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update AUTO INVOICE ACCOUNTDET TMP records.</summary>
        /// <param name="invchrg">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_AUTO_INVOICE_ACCOUNTDET_TMP_IU([FromBody] InvFraChrgeDtls invchrg)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_ACCOUNTDET_TMP_IU", (invchrg.ID != null) ? invchrg.ID : "", (invchrg.INVNO != null) ? invchrg.INVNO : "", invchrg.CHRGCODE, invchrg.ACCOUNT, invchrg.CHRGDESC, invchrg.CHRGDESC1, invchrg.TAXABLE, invchrg.AMTEURO, invchrg.ISEDITABLE, invchrg.CMPID, invchrg.EX_RATE, (invchrg.TMP_STR != null) ? invchrg.TMP_STR : "", invchrg.CITYCODE, invchrg.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_INVOICE_ACCOUNTDET_TMP_IU");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update AUTO INVOICE ENCLOSURE TMP IU JSON records.</summary>
        /// <param name="invenc">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACCFRA_AUTO_INVOICE_ENCLOSURE_TMP_IU_JSON([FromBody] InvFraEnclosure invenc)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_INVOICE_ENCLOSURE_TMP_IU", (invenc.ID != null) ? invenc.ID : "", (invenc.INVNO != null) ? invenc.INVNO : "", invenc.ENCLOSURE, invenc.CMPID, invenc.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_AUTO_INVOICE_ENCLOSURE_TMP_IU_JSON");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for CLIENT  INVOICE REGISTER FILL DROPDOWN records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CLIENT__INVOICE_REGISTER_FILL_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_REGISTER_INVOICE_FILL_DROPDOWN");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CLIENT__INVOICE_REGISTER_FILL_DROPDOWN");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of CLIENT INVOICE records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="client">Client/exporter code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CLIENT_INVOICE_REGISTER(string fromdate, string todate, string client)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_REPORT_REGISTER_INVOICE", fromdate, todate, client);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CLIENT_INVOICE_REGISTER");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve list of CREDIT NOTE records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CREDIT_NOTE_REGISTER(string fromdate, string todate, string citycode, string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_RPT_CREDITNOTE_REGISTER", fromdate, todate, citycode, type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/CREDIT_NOTE_REGISTER");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve list of INVOICE REGISTER SUMMARY records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult INVOICE_REGISTER_SUMMARY(string fromdate, string todate, string citycode, string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_RPT_INVOICE_REGISTER", fromdate, todate, citycode, type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/INVOICE_REGISTER_SUMMARY");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of PURCHASE records.</summary>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PURCHASE_REGISTER(string fromdate, string todate, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CONSOLE_PURCHASE_REGISTER_DETAILS", fromdate, todate, citycode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/PURCHASE_REGISTER");
            }
            return Ok(ds);
        }
        //[HttpGet]
        //public IHttpActionResult ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE()
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE_NG"
        //          );
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_FILLCLIENT_GENERAL_ACCOUNT_POPULATE");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }

        //    return Ok(ds);
        //}

        //[HttpGet]
        //public HttpResponseMessage ACCFRA_GENERAL_ACCOUNT_WISE_TURNOVER_SUMMARY(string FromDate, string ToDate, string GAccount, string Client, string Type)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    string strSpName = string.Empty, strXslFilename = string.Empty;
        //    string strData = string.Empty;

        //    if (Type == "GAccount")
        //    {
        //        strSpName = "USP_ACCFRA_GENERAL_ACCOUNT_TURNOVER";
        //        strXslFilename = "xsl_Accfra_Rpt_General_Account_TurnOver.xsl";
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, FromDate, ToDate, GAccount);
        //    }
        //    else
        //    {
        //        strSpName = "USP_ACCFRA_CLIENT_ND_ORIGIN_WISE_TURNOVER_SUMMARY";
        //        strXslFilename = "Xsl_AccFra_Rpt_Client_nd_Origin_wise_Turnover_Summary.xsl";
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, FromDate, ToDate, (Client == null) ? "" : Client, Type);
        //    }


        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.LoadXml(ds.GetXml());
        //    strData = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

        //    byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
        //    MemoryStream stream = new MemoryStream(byteArray);
        //    stream.WriteTo(HttpContext.Current.Response.OutputStream);

        //    HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
        //    httpResponseMessage.Content = new StreamContent(stream);
        //    httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    httpResponseMessage.Content.Headers.ContentDisposition.FileName = "TurnOverSummary.xls";
        //    httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

        //    return httpResponseMessage;
        //}
        //[HttpGet]
        //public IHttpActionResult ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY(string FromDate, string ToDate)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY",
        //          FromDate, ToDate);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_CLIENT_WISE_TURNOVER_SUMMARY");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }

        //    return Ok(ds);
        //}
        public IHttpActionResult ACCFRA_REPORT_EXPORT_SUMMARY([FromBody]ReportConsoleSummary r)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_IMP_REPORT_PROFIT_EXPOT_SUMMARY",
                   r.TYPE, r.CONSOLENOFR, r.CONSOLENOTO, r.CONS_MODE, "ALL", (r.IMPOTERCODE != null) ? r.IMPOTERCODE : "");// r.CITY
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_EXPORT_SUMMARY");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform REPORT CONSOLE SUMMARY XL records.</summary>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CONSOLENOFR">CONSOLENOFR parameter.</param>
        /// <param name="CONSOLENOTO">CONSOLENOTO parameter.</param>
        /// <param name="CONS_MODE">Operation mode or filter type.</param>
        /// <param name="CITY">CITY parameter.</param>
        /// <param name="IMPOTERCODE">IMPOTERCODE parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage ACCFRA_REPORT_CONSOLE_SUMMARY_XL([FromUri]string TYPE, string CONSOLENOFR, string CONSOLENOTO, string CONS_MODE, string CITY, string IMPOTERCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            //strSpName = "Usp_Export_Shipment_Status_New";

            strXslFilename = "xsl_AccFra_Rpt_ConsoleSummary_XL.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_CONSOLE_SUMMARY1", TYPE, CONSOLENOFR, CONSOLENOTO, CONS_MODE, "ALL", (IMPOTERCODE != null) ? IMPOTERCODE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "ConsoleProfitSummary_" + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform REPORT EXPORT SUMMARY XL records.</summary>
        /// <param name="TYPE">TYPE parameter.</param>
        /// <param name="CONSOLENOFR">CONSOLENOFR parameter.</param>
        /// <param name="CONSOLENOTO">CONSOLENOTO parameter.</param>
        /// <param name="CONS_MODE">Operation mode or filter type.</param>
        /// <param name="CITY">CITY parameter.</param>
        /// <param name="IMPOTERCODE">IMPOTERCODE parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage ACCFRA_REPORT_EXPORT_SUMMARY_XL([FromUri]string TYPE, string CONSOLENOFR, string CONSOLENOTO, string CONS_MODE, string CITY, string IMPOTERCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            //strSpName = "Usp_Export_Shipment_Status_New";

            strXslFilename = "xsl_AccFra_Rpt_ExportSummary_XL.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_IMP_REPORT_PROFIT_EXPOT_SUMMARY", TYPE, CONSOLENOFR, CONSOLENOTO, CONS_MODE, "ALL", (IMPOTERCODE != null) ? IMPOTERCODE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("AccountsFra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "ConsoleProfitSummary_" + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Retrieve list of MST INVOICE EXCHRATE DAILY records.</summary>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="forcurreny">forcurreny parameter.</param>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_MST_INVOICE_EXCHRATE_DAILY_LIST([FromUri]string cmpid, string forcurreny, string fromdate, string todate, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_FRA_ACC_MST_INVOICE_EXCHRATE_FILL_GRID",
                    forcurreny, (!string.IsNullOrEmpty(fromdate)) ? fromdate : "", (!string.IsNullOrEmpty(todate)) ? todate : "", mode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACC_MST_INVOICE_EXCHRATE_DAILY_LIST");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform MST INVOICE EXCHRATE records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_MST_INVOICE_EXCHRATE([FromBody]MasterInvoiceExchangRate obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_FRA_ACC_MST_INVOICE_EXCHRATE_IU",
                    obj.PkId, obj.For, obj.FromDate, obj.ToDate, obj.Rate, obj.MakerId, obj.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/ACC_MST_INVOICE_EXCHRATE");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /**************************************Master API Ends Here****************************************/

        /**************************************Transaction API Start Here****************************************/
        /// <summary>Perform PurchaseDropdownFill records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PurchaseDropdownFill([FromUri]string citycode)
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_FILL_DROPDOWN_NG",
                    citycode);
                dsDateValidate = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_PURCHASE_DATE_VALIDATE"
                    , "", 268, 0);
                dsDateValidate.Tables[0].TableName = "DATE_VALIDATE";
                ds.Tables.Add(((DataTable)dsDateValidate.Tables[0]).Copy());
                dsDateValidate.Clear();
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseDropdownFill");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseJobNoSearch records.</summary>
        /// <param name="searchtype">Search type/column identifier.</param>
        /// <param name="code">code parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PurchaseJobNoSearch([FromUri]string searchtype, string code)
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_JOBNO_SEARCH",
                    (searchtype != null) ? searchtype : "", (code != null) ? code : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseJobNoSearch");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update PurchaseDetails records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PurchaseDetails_IU([FromBody]PurchaseDetailsIu obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_DTLS_IU",
                    obj.Id, obj.TableIndex_Id, obj.EntryNo, obj.Account, obj.MawbMbl, obj.JobNo, obj.Narration, obj.InvoiceEuro, obj.DeductionEuro,
                    obj.MakerId, obj.Guid, obj.MakerIp, obj.Rate);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseDetails_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseDetailsDeleteIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PurchaseDetailsDeleteIU([FromBody]PurchaseDetailsIu obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_DTLS_DELETE",
                    obj.Id, obj.TableIndex_Id, obj.EntryNo, obj.MakerId, obj.Guid, obj.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseDetailsDeleteIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseResetAllIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PurchaseResetAllIU([FromBody]PurchaseDetailsIu obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_RESET_ALL",
                    obj.MakerId, obj.Guid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseResetAllIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseEditData records.</summary>
        /// <param name="entryno">entryno parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PurchaseEditData([FromUri]string entryno, string cmpid, string guid)
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_POPULATE_NG",
                    entryno, cmpid, guid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseEditData");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PurchaseIU([FromBody]PurchaseIu obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_IU_NG",
                    obj.Id, obj.EntryNo, obj.Supplier, obj.EntryDate, obj.BillNo, obj.BillDate, obj.TotalEuro, obj.InvoiceCurrency,
                    obj.ExRate, obj.MakerId, obj.Guid, obj.CmpCode, obj.CityCode, obj.CityCode1, obj.MakerId, obj.MakerIp,
                    obj.SupplierInvDate, (obj.Sup_addrid == null) ? "0" : obj.Sup_addrid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseSupplierData records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PurchaseSupplierData()
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_SEARCH_FILLDROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseSupplierData");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PurchaseSearchList records.</summary>
        /// <param name="searchtype">Search type/column identifier.</param>
        /// <param name="searchvalue">searchvalue parameter.</param>
        /// <param name="searchvalue1">searchvalue1 parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PurchaseSearchList([FromUri]string searchtype, string searchvalue, string searchvalue1)
        {
            DataSet ds = new DataSet();
            DataSet dsDateValidate = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ACCFRA_TRAN_PURCHASE_SEARCH_LIST",
                    searchtype, searchvalue, (searchvalue1!=null)? searchvalue1 : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/PurchaseSearchList");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        public IHttpActionResult AccFra_Report_Console_Summary([FromBody]ReportConsoleSummary r)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_CONSOLE_SUMMARY1",
                   r.TYPE, r.CONSOLENOFR, r.CONSOLENOTO, r.CONS_MODE, "ALL", r.IMPOTERCODE);// r.CITY
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "AccountsFra/AccFra_Report_Console_Summary");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for REPORT IMPORTER SUMMARY FILL DROPDOWN records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_REPORT_IMPORTER_SUMMARY_FILL_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_IMPORTER_SUMMARY_FILL_DROPDOWN");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_IMPORTER_SUMMARY_FILL_DROPDOWN");
            }
            return Ok(ds);
        }
        /// <summary>Perform REPORT ANOMALY SUMMARY records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_REPORT_ANOMALY_SUMMARY()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_CONSOLE_SUMMARY_PP_NG");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_ANOMALY_SUMMARY");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for REPORT ACCOUNTWISE RECOVERY FILL DROPDOWN records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_REPORT_ACCOUNTWISE_RECOVERY_FILL_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_ACCOUNTWISE_RECOVERY_FILL_DROPDOWN");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_ACCOUNTWISE_RECOVERY_FILL_DROPDOWN");
            }
            return Ok(ds);
        }
        /// <summary>Perform REPORT ACCOUNTWISE RECOVERY records.</summary>
        /// <param name="ACCTCODE">ACCTCODE parameter.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_REPORT_ACCOUNTWISE_RECOVERY(string ACCTCODE, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_REPORT_ACCOUNTWISE_RECIVERY", ACCTCODE, FROMDATE, TODATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_ACCOUNTWISE_RECOVERY");
            }
            return Ok(ds);
        }
        /// <summary>Perform REPORT JOBWISE RECOVERY records.</summary>
        /// <param name="JOBNO">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACCFRA_REPORT_JOBWISE_RECOVERY(string JOBNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_IMP_REPORT_JOBPROFIT", JOBNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "AccountsFra/ACCFRA_REPORT_JOBWISE_RECOVERY");
            }
            return Ok(ds);
        }

        /**************************************Transaction API Ends Here****************************************/
    }
}

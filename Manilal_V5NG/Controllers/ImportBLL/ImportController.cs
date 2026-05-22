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
using System.Reflection;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ExcelDataReader;
namespace Manilal_V5NG.Controllers.ImportBLL
{

    public class ImportController : ApiController
    {

        /// <summary>excellocaldatafile operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        // [Route("upload/excellocaldatafile")]
        public IHttpActionResult excellocaldatafile()
        {

            var httpRequest = HttpContext.Current.Request;
            var cmpcode = HttpContext.Current.Request.Params["CMPCODE"];
            var citycode = HttpContext.Current.Request.Params["CITYCODE"];
            var citycode1 = HttpContext.Current.Request.Params["CITYCODE1"];
            var makerid = HttpContext.Current.Request.Params["MAKERID"];
            var makerip = HttpContext.Current.Request.Params["MAKERIP"];
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            DataRow drow = dtbl.NewRow();
            try
            {

                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\", fileName);

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
                        ProcessExcel(filePath, cmpcode, citycode, citycode1, makerid, makerip);
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
                ErrorLog.Error(ex, "Import/UploadItemMrpExcelFile");
            }
            return Ok(ds1);
        }
        public void ProcessExcel(string filePath, string cmpcode, string citycode, string citycode1, string makerid, string makerip)
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = null;

                if (filePath.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (filePath.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                DataSet result = reader.AsDataSet();
                DataTable table = result.Tables[0];
                string connectionString = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var row = table.Rows[i];
                        string ship = row[14]?.ToString();

                        //DateTime? shipDate = null;

                        //if (shipObj != null)
                        //{
                        //    if (shipObj is double)
                        //        shipDate = DateTime.FromOADate((double)shipObj);
                        //    else
                        //        shipDate = ConvertDate(shipObj.ToString());
                        //}
                        // ✅ Skip cancelled rows
                        if (!string.IsNullOrWhiteSpace(ship) && ship.Trim().ToLower() == "cancelled")
                            continue;
                        string po = row[1]?.ToString();
                        string codefrs = row[2]?.ToString();
                        string supplier = row[3]?.ToString();
                        // string delivery = row[4]?.ToString();
                        object deliveryObj = row[4];

                        DateTime? deliveryDate = null;

                        if (deliveryObj != null)
                        {
                            if (deliveryObj is double)
                                deliveryDate = DateTime.FromOADate((double)deliveryObj);
                            else
                                deliveryDate = ConvertDate(deliveryObj.ToString());
                        }
                        string coderef = row[5]?.ToString();
                        string color = row[6]?.ToString();
                        string van = row[7]?.ToString();
                        string ean = row[8]?.ToString();
                        string taille = row[9]?.ToString();
                        string pcs = row[10]?.ToString();
                        string path = row[11]?.ToString();
                        string devpath = row[12]?.ToString();
                        string ware = row[13]?.ToString();
                        // string ship = row[14]?.ToString();
                        // string est = row[15]?.ToString();
                        object estObj = row[15];

                        DateTime? estDate = null;

                        if (estObj != null)
                        {
                            if (estObj is double)
                                estDate = DateTime.FromOADate((double)estObj);
                            else
                                estDate = ConvertDate(estObj.ToString());
                        }
                        string qty = row[16]?.ToString();
                        // string actual = row[17]?.ToString();
                        object actualObj = row[17];

                        DateTime? actualDate = null;

                        if (actualObj != null)
                        {
                            if (actualObj is double)
                                actualDate = DateTime.FromOADate((double)actualObj);
                            else
                                actualDate = ConvertDate(actualObj.ToString());
                        }
                        string rem = row[18]?.ToString();
                        string bxno = row[19]?.ToString();
                        //string cmpcode1 = cmpcode;
                        //string citycode1 = citycode;
                        //string makerid1 = makerid;
                        //string makerip1 = makerip;

                        if (string.IsNullOrWhiteSpace(po))
                            continue;

                        SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO TBL_IMP_WMS_LOCALDATAFILE_UPLOAD
                        (PO_NUMBER,CODE_FRS,SUPPLIER_NAME,DELIVERY_DATE,CODE_REFERENCE,COLOR,VAN,EAN,CODE_TAILLE,
                         NO_OF_PIECES,PATH_FRS_INITIAL,CODE_DEV_PATH_FRS,WAREHOUSE,SHIPPING_APPROVED,
                         EST_ARRIVAL_DATE,QTY_RECEIVED,ACTUAL_ARRIVAL_DATE,REMARKS,
                         CMPCODE,CITYCODE,MAKERID,MAKERIP,BOXNUMBER)
                        VALUES
                        (@PO,@CODEFRS,@SUPPLIER,@DELIVERY,@CODEREF,@COLOR,@VAN,@EAN,@TAILLE,
                         @PCS,@PATH,@DEVPATH,@WARE,@SHIP,@EST,@QTY,@ACTUAL,@REM,
                         @CMPCODE,@CITYCODE,@MAKERID,@MAKERIP,@BOXNUMBER)", con);

                        cmd.Parameters.AddWithValue("@PO", po);
                        cmd.Parameters.AddWithValue("@CODEFRS", codefrs);
                        cmd.Parameters.AddWithValue("@SUPPLIER", supplier);
                        cmd.Parameters.AddWithValue("@DELIVERY", (object)deliveryDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CODEREF", coderef);
                        cmd.Parameters.AddWithValue("@COLOR", color);
                        cmd.Parameters.AddWithValue("@VAN", van);
                        cmd.Parameters.AddWithValue("@EAN", ean);
                        cmd.Parameters.AddWithValue("@TAILLE", taille);
                        cmd.Parameters.AddWithValue("@PCS", pcs);
                        cmd.Parameters.AddWithValue("@PATH", path);
                        cmd.Parameters.AddWithValue("@DEVPATH", devpath);
                        cmd.Parameters.AddWithValue("@WARE", ware);
                        // cmd.Parameters.AddWithValue("@SHIP", ConvertDate(ship));
                        if (string.IsNullOrWhiteSpace(ship))
                        {
                            cmd.Parameters.AddWithValue("@SHIP", DBNull.Value);
                        }
                        else if (ship.Trim().Equals("cancelled", StringComparison.OrdinalIgnoreCase))
                        {
                            continue;
                        }
                        else
                        {
                            DateTime parsedDate;
                            if (DateTime.TryParse(ship, out parsedDate))
                            {
                                cmd.Parameters.AddWithValue("@SHIP", parsedDate);
                            }
                            else
                            {
                                // optional: handle invalid format
                                cmd.Parameters.AddWithValue("@SHIP", DBNull.Value);
                            }
                        }
                        cmd.Parameters.AddWithValue("@EST", (object)estDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@QTY", qty);
                        cmd.Parameters.AddWithValue("@ACTUAL", (object)actualDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@REM", rem);
                        cmd.Parameters.AddWithValue("@CMPCODE", cmpcode);
                        cmd.Parameters.AddWithValue("@CITYCODE", citycode);
                        cmd.Parameters.AddWithValue("@MAKERID", makerid);
                        cmd.Parameters.AddWithValue("@MAKERIP", makerip);
                        cmd.Parameters.AddWithValue("@BOXNUMBER", bxno);
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                    DataSet dsupload = new DataSet();
                    DAL objDal = new DAL();
                    dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GENERATE_AUTO_WAREHOUSE_JOBS", cmpcode, citycode, citycode1, makerid, makerip);
                }
            }
        }
        private DateTime? ConvertDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            DateTime date;

            // Try dd/MM/yyyy first
            if (DateTime.TryParseExact(input, "d/M/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }

            // Try MM/dd/yyyy (for delivery date case)
            if (DateTime.TryParseExact(input, "M/d/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }

            // Last fallback (auto parse)
            if (DateTime.TryParse(input, out date))
            {
                return date;
            }

            return null;
        }
        private DateTime? ConvertDateUS(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            DateTime date;

            if (DateTime.TryParseExact(input, "M/d/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date))
            {
                return date;
            }

            return null;
        }
        /// <summary>Perform WMS LOCALGRN BOXDTLS records.</summary>
        /// <param name="BXNO">BXNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_LOCALGRN_BOXDTLS(string BXNO, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_GETLOCALBOXDTLS", (BXNO != null) ? BXNO : "0", VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_LOCALGRN_BOXDTLS");
            }
            return Ok(ds);
        }
        public string fN_upload_ItemExcelFile(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string CONTAINERNO, string SHIPMENTTYPE, string SHIPMENTNO)
        {
            try
            {
                strFileName = Path.GetFileName(strFileName);

                string strFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);

                DAL objDal = new DAL();

                // LOG ENTRY
                DataSet dsupload = objDal.ExecuteDataset(
                    ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_WMS_UPLOAD_XL_UPDATELOG",
                    CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMEXCEL", SHIPMENTTYPE, CMPCODE, CITYCODE1
                );

                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();

                if (SHIPMENTTYPE == "LOC")
                {
                    CONTAINERNO = dsupload.Tables[0].Rows[0]["SHIPMENTNO"].ToString();
                }

                // =========================
                // ✅ READ EXCEL
                // =========================

                using (FileStream stream = File.Open(strFilePath, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader = null;

                    if (strFilePath.EndsWith(".xls"))
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    else
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    DataSet result = reader.AsDataSet();
                    DataTable table = result.Tables[0]; // first sheet

                    string connectionString = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // skip header (i=1)
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            var row = table.Rows[i];
                            // Query = string.Format("Select [GTIN],[ShippedQty],[VendorSkuCode],[ArticleType],[Brand Size],[Prominent Colour],[MRP],[AgeGroup],[ShortProductTitle],[MyntraPicture1URL],[MyntraPicture2URL] ,[MyntraPicture3URL],[Country of Origin],[Weight],[HSN],[SUPCODE],[PONO] FROM [{0}]", "MPCargoDataSet$");
                            string sku = row[0]?.ToString();              // VendorSkuCode
                            string coderef = row[1]?.ToString();          // Code_ref
                            string colorCode = row[2]?.ToString();        // Code_coloris
                            string gtin = row[3]?.ToString();             // GTIN
                            string shippedQty = row[5]?.ToString();       // ShippedQty
                            string weight = row[6]?.ToString();           // Weight
                            string origin = row[10]?.ToString();           // countryoforigin
                            string articleType = row[11]?.ToString();     // ArticleType
                            string size = row[12]?.ToString();            //  Size
                            string color = row[13]?.ToString();           // Prominent Colour
                            string hsn = row[14]?.ToString();             // HSN
                            string mrp = row[16]?.ToString();             // MRP
                            string age = row[17]?.ToString();             // AgeGroup
                            string title = row[19]?.ToString();           // ShortProductTitle
                            string pic1 = row[20]?.ToString();            // MyntraPicture1URL
                            string pic2 = row[21]?.ToString();            // MyntraPicture2URL
                            string pic3 = row[22]?.ToString();            // MyntraPicture3URL
                            string supcode = row[23]?.ToString();         // SUPCODE
                            string pono = row[24]?.ToString();


                            // Skip empty row
                            if (string.IsNullOrWhiteSpace(gtin))
                                continue;

                            SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO WMS_ITEM_MASTER_UPLOAD_TMP
                    (EAN,SKU,QTY,LIBELLE_COLORIS_EN,HSN,TAILLE,MRP,GROUPE_ANGLAIS,
                     INFO_DOUANIERE,DPT_ANGLAIS,PICTURE,PIC3,ZMPICTURE,
                     ORIGINCOUNTRY,WEIGHT,FK_SUPCODE,PONO,
                     FK_LOGID,CMPCODE,CITYCODE)
                    VALUES
                    (@EAN,@SKU,@QTY,@COLOR,@HSN,@SIZE,@MRP,@AGE,
                     @TITLE,@ARTICLE,@PIC1,@PIC2,@PIC3,
                     @ORIGIN,@WEIGHT,@SUPCODE,@PONO,
                     @LOGID,@CMPCODE,@CITYCODE)", con);

                            cmd.Parameters.AddWithValue("@EAN", gtin);
                            cmd.Parameters.AddWithValue("@SKU", sku);
                            cmd.Parameters.AddWithValue("@QTY", shippedQty);
                            cmd.Parameters.AddWithValue("@COLOR", color);
                            cmd.Parameters.AddWithValue("@HSN", hsn);
                            cmd.Parameters.AddWithValue("@SIZE", size);
                            cmd.Parameters.AddWithValue("@MRP", mrp);
                            cmd.Parameters.AddWithValue("@AGE", age);
                            cmd.Parameters.AddWithValue("@TITLE", title);
                            cmd.Parameters.AddWithValue("@ARTICLE", articleType);
                            cmd.Parameters.AddWithValue("@PIC1", pic1);
                            cmd.Parameters.AddWithValue("@PIC2", pic2);
                            cmd.Parameters.AddWithValue("@PIC3", pic3);
                            cmd.Parameters.AddWithValue("@ORIGIN", origin);
                            //cmd.Parameters.AddWithValue("@WEIGHT", weight);
                            cmd.Parameters.AddWithValue("@WEIGHT",
                                    string.IsNullOrWhiteSpace(row[6]?.ToString())
                                    ? (object)DBNull.Value
                                    : Convert.ToDecimal(row[6])
                                );
                            cmd.Parameters.AddWithValue("@SUPCODE", supcode);
                            cmd.Parameters.AddWithValue("@PONO", pono);
                            cmd.Parameters.AddWithValue("@LOGID", logid);
                            cmd.Parameters.AddWithValue("@CMPCODE", CMPCODE);
                            cmd.Parameters.AddWithValue("@CITYCODE", CITYCODE1);

                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                    }
                }

                // =========================
                // ✅ CALL FINAL SP
                // =========================

                objDal.ExecuteDataset(
                    ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_WMS_ITEM_MASTER_INSERT_BULKUPLOAD",
                    CMPID, MAKERIP, VGUID, logid, CMPCODE, CITYCODE, CITYCODE1, CONTAINERNO
                );

                return "success";
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ItemExcelFile");
                return "error";
            }
        }
        /// <summary>IMP WMS LOCALGRN PAGE LOAD operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]

        public IHttpActionResult IMP_WMS_LOCALGRN_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_LOCALGRN_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_LOCALGRN_PAGE_LOAD");
            }
            return Ok(ds);
        }

        /// <summary>Perform WMS GRN LOCALBOXDTLS records.</summary>
        /// <param name="BXNO">BXNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_LOCALBOXDTLS(string BXNO, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_GETLOCALBOXDTLS", (BXNO != null) ? BXNO : "0", VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_LOCALBOXDTLS");
            }
            return Ok(ds);
        }

        /// <summary>Upload UploadGoodsReturnCSV records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        [Route("api/Import/UploadGoodsReturnCSV")]
        public IHttpActionResult UploadGoodsReturnCSV()
        {

            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var httpRequest = HttpContext.Current.Request;

            var clientcode = HttpContext.Current.Request.Params["clientcode"];
            var clientaddid = HttpContext.Current.Request.Params["clientaddid"];
            var grtndate = HttpContext.Current.Request.Params["grtndate"];
            var returndate = HttpContext.Current.Request.Params["returndate"];
            var returnno = HttpContext.Current.Request.Params["returnno"];
            var clinvoiceno = HttpContext.Current.Request.Params["clinvoiceno"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var guid = HttpContext.Current.Request.Params["guid"];
            var postedfile = httpRequest.Files["file"];
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            DataRow drow = dtbl.NewRow();
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\GoodsReturn\\", fileName);

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
                        ds1 = fN_Upload_GoodsReturn(fileName, clientcode, clientaddid, grtndate, returndate, returnno, clinvoiceno, cmpcode, citycode, citycode1, cmpid, makerip, guid);
                        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 &&
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
                ErrorLog.Error(ex, "Import/UploadGoodsReturnCSV");
            }
            return Ok(ds1);

        }

        public DataSet fN_Upload_GoodsReturn(string strFileName, string clientcode, string clientaddid, string grtndate, string returndate, string returnno, string clinvoiceno, string cmpcode, string citycode, string citycode1, string cmpid, string makerip, string guid)
        {
            DataSet dsupdate = new DataSet();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\GoodsReturn\\" + strFileName);
                file.SaveAs(strFilePath);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_UPLOAD_GOODSRETURN_CSV_UPDATELOG", cmpid, makerip, guid, strFileName, strFilePath, "GOODSRETURN");
                string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();

                if (status == "100")
                {
                    string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                    DataSet DS = new DataSet();
                    DataSet MP_DS = new DataSet();
                    dsupdate = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_BULKINSERT_CSV", strFilePath, strFileName, logid, clientcode, clientaddid, grtndate, returndate, returnno, clinvoiceno, cmpcode, citycode, citycode1, cmpid, makerip);
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

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_Upload_GoodsReturn");

                // Create a new DataSet to hold the error information
                dsupdate = new DataSet();
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("STATUS", typeof(string));
                errorTable.Columns.Add("MSG", typeof(string));

                // Populate the error information
                DataRow errorRow = errorTable.NewRow();
                errorRow["STATUS"] = "500"; // Indicate internal server error
                errorRow["MSG"] = ex.Message; // Include the error message
                errorTable.Rows.Add(errorRow);

                // Add the error table to the DataSet
                dsupdate.Tables.Add(errorTable);
            }
            return dsupdate;

        }
        /// <summary>Perform WMS SHIPMENTWISE ITEMSTATUS ALL MRPQTY XL records.</summary>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ASONDATE">ASONDATE parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTWISE_ITEMSTATUS_ALL_MRPQTY_XL(string CONTAINERNO, string CMPCODE, string CITYCODE, string ASONDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            if (CONTAINERNO == "All")
            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus_all_mrpqty.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS_ALL_MRPQTY", CMPCODE, CITYCODE, ASONDATE);

            }
            else
            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS", CONTAINERNO, CMPCODE, CITYCODE, ASONDATE);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CONTAINERNO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Insert or update WMS GRN BOXWISE records.</summary>
        /// <param name="GRITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_BOXWISE_IU([FromBody] GRNITEM GRITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_BOXWISE_IU", GRITEM.GRNNO, GRITEM.VGUID, GRITEM.MAKERID, GRITEM.ORDERNO, GRITEM.CONTAINERNO, GRITEM.ENTRYSTARTDTTIME, GRITEM.BOXNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BOXWISE_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETBDSHIPMENTNO records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETBDSHIPMENTNO()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETBDSHIPMENTNO");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETBDSHIPMENTNO");
            }
            return Ok(ds);
        }
        /// <summary>Upload UploadInvoice records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpPost]
        public HttpResponseMessage UploadInvoice()
        {
            try
            {
                DataSet dsupdate = new DataSet();
                var httpRequest = HttpContext.Current.Request;
                var cmpid = HttpContext.Current.Request.Params["cmpid"];
                var vguid = HttpContext.Current.Request.Params["vguid"];
                var makerip = HttpContext.Current.Request.Params["makerip"];
                var shipmentno = HttpContext.Current.Request.Params["shipmentno"];
                if (httpRequest.Files.Count == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No file uploaded.");

                var postedFile = httpRequest.Files[0];
                string uploadPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\WMS\Invoice";

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                string originalFileName = Path.GetFileName(postedFile.FileName);
                string savedFilePath = Path.Combine(uploadPath, originalFileName);

                // ✅ Check if same file exists
                if (File.Exists(savedFilePath))
                    return Request.CreateResponse(HttpStatusCode.Conflict, new { message = "File already exists." });

                postedFile.SaveAs(savedFilePath);

                // ✅ Extract invoice number from filename (e.g., CFM-253046224)
                var match = Regex.Match(originalFileName, @"CFM-\d+");
                if (!match.Success)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invoice number not found in filename.");

                string invoiceNo = match.Value;

                // ✅ Check invoice existence via stored procedure
                DataSet dsUpload = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConnectionString.getConnString()))
                using (SqlCommand cmd = new SqlCommand("usp_imp_wms_upload_checkinvoicenoexists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dsUpload);
                }

                string status = dsUpload.Tables[0].Rows[0]["STATUS"].ToString();
                if (status != "0")
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Invoice already exists or invalid status.");

                // ✅ Prepare to read Excel
                string ext = Path.GetExtension(savedFilePath);
                string conStr = "";

                if (ext == ".xls")
                    conStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={savedFilePath};Extended Properties='Excel 8.0;HDR=NO;'";
                else if (ext == ".xlsx")
                    conStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={savedFilePath};Extended Properties='Excel 12.0 Xml;HDR=NO;'";

                using (OleDbConnection excelCon = new OleDbConnection(conStr))
                {
                    excelCon.Open();

                    // ✅ Get first sheet name
                    DataTable dtSheet = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();

                    string query = $"SELECT * FROM [{sheetName}]";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, excelCon))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count >= 43)
                        {
                            // Step 1: Take the header row (row 43, index 42)
                            DataRow headerRow = dt.Rows[42];

                            // Step 2: Set column names
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string colName = headerRow[i]?.ToString().Trim(); // safe null check
                                if (string.IsNullOrWhiteSpace(colName))
                                {
                                    colName = "Column" + (i + 1); // default name if blank
                                }
                                dt.Columns[i].ColumnName = colName;
                            }

                            // Remove header row from data
                            //for (int i = 0; i <= 42; i++)
                            //    dt.Rows.RemoveAt(0);
                            for (int i = 42; i >= 0; i--)
                                dt.Rows.RemoveAt(i);

                            dt.AcceptChanges();
                        }


                        // Promote header row to column names
                        //DataRow headerRow = dt.Rows[0];
                        //for (int i = 0; i < dt.Columns.Count; i++)
                        //{
                        //    dt.Columns[i].ColumnName = headerRow[i].ToString().Trim();
                        //}

                        //// Remove header row from data
                        //dt.Rows.RemoveAt(0);



                        // ✅ Remove footer rows like “Terms of payment”, “Net Total”, etc.
                        List<string> stopWords = new List<string>
                {
                    "Terms of payment", "Mode of payment", "Supplier Name", "Beneficiary Bank",
                    "Net Total", "Tax code", "Total Tax", "Total Items", "Total EUR"
                };

                        int stopIndex = dt.Rows.Count;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            bool foundStopWord = false;

                            foreach (var cell in dt.Rows[i].ItemArray)
                            {
                                string cellValue = cell?.ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(cellValue) &&
                                    stopWords.Any(word => cellValue.StartsWith(word, StringComparison.OrdinalIgnoreCase)))
                                {
                                    foundStopWord = true;
                                    break;
                                }
                            }

                            if (foundStopWord)
                            {
                                stopIndex = i;
                                break;
                            }
                        }

                        // ✅ Remove everything from the stopword row downward
                        for (int i = dt.Rows.Count - 1; i >= stopIndex; i--)
                            dt.Rows.RemoveAt(i);

                        dt.AcceptChanges();

                        // ✅ Forward-fill merged cells
                        object[] lastValues = new object[dt.Columns.Count];
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            bool isRowEmpty = true;

                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                var cellValue = dt.Rows[r][c];
                                if (cellValue != DBNull.Value && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                                {
                                    lastValues[c] = cellValue;
                                    isRowEmpty = false;
                                }
                                else if (!isRowEmpty) // only forward-fill if row has some data
                                {
                                    dt.Rows[r][c] = lastValues[c];
                                }
                            }
                        }

                        // ✅ Remove empty rows
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            var row = dt.Rows[i];
                            bool isEmpty = row.ItemArray.All(x => string.IsNullOrWhiteSpace(x?.ToString()));
                            if (isEmpty)
                                dt.Rows.RemoveAt(i);
                        }
                        dt.AcceptChanges();

                        // ✅ Verify required columns
                        string[] requiredColumns = new string[]
                        {
                    "EAN Code", "Reference", "Size", "Color", "Description",
                    "HS Code European", "Origin", "Unit Price EUR", "Quantity", "Net Total EUR"
                        };

                        foreach (var col in requiredColumns)
                        {
                            if (!dt.Columns.Contains(col))
                                throw new Exception($"Excel file does not contain required column '{col}'");
                        }

                        // ✅ Insert cleaned data into SQL
                        using (SqlConnection conn = new SqlConnection(ConnectionString.getConnString()))
                        {
                            conn.Open();

                            foreach (DataRow row in dt.Rows)
                            {
                                if (!dt.Columns.Contains("EAN Code")) continue;
                                var ean = row["EAN Code"]?.ToString().Trim();
                                if (string.IsNullOrWhiteSpace(ean))
                                {
                                    bool anyData = row.ItemArray.Any(x => !string.IsNullOrWhiteSpace(x?.ToString()));
                                    if (!anyData) continue;
                                }

                                string sql = @"
                        INSERT INTO tbl_imp_wms_docinvoice_upload
                        (InvoiceNo, ean, Reference, Size, color, description, hsncode, Origin, Unitprice, Qty, NetTotal,SHIPMENTNO,MakerId)
                        VALUES
                        (@InvoiceNo, @ean, @Reference, @Size, @color, @description, @hsncode, @Origin, @Unitprice, @Qty, @NetTotal,@SHIPMENTNO,@MakerId)";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                                    cmd.Parameters.AddWithValue("@ean", ean);
                                    cmd.Parameters.AddWithValue("@Reference", row["Reference"].ToString());
                                    cmd.Parameters.AddWithValue("@Size", row["Size"].ToString());
                                    cmd.Parameters.AddWithValue("@color", row["Color"].ToString());
                                    cmd.Parameters.AddWithValue("@description", row["Description"].ToString());
                                    cmd.Parameters.AddWithValue("@hsncode", row["HS Code European"].ToString());
                                    cmd.Parameters.AddWithValue("@Origin", row["Origin"].ToString());
                                    cmd.Parameters.AddWithValue("@Unitprice", row["Unit Price EUR"].ToString());
                                    cmd.Parameters.AddWithValue("@Qty", row["Quantity"].ToString());
                                    cmd.Parameters.AddWithValue("@NetTotal", row["Net Total EUR"].ToString());
                                    cmd.Parameters.AddWithValue("@SHIPMENTNO", shipmentno);
                                    cmd.Parameters.AddWithValue("@MakerId", cmpid);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { message = $"File uploaded and data inserted for invoice {invoiceNo}" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        /// <summary>Upload UploadPackingList records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpPost]
        public HttpResponseMessage UploadPackingList()
        {
            try
            {
                DataSet dsupdate = new DataSet();
                var httpRequest = HttpContext.Current.Request;
                var cmpid = HttpContext.Current.Request.Params["cmpid"];
                var vguid = HttpContext.Current.Request.Params["vguid"];
                var makerip = HttpContext.Current.Request.Params["makerip"];
                var shipmentno = HttpContext.Current.Request.Params["shipmentno"];
                if (httpRequest.Files.Count == 0)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No file uploaded.");

                var postedFile = httpRequest.Files[0];
                string uploadPath = HttpContext.Current.Server.MapPath(@"..\..\") + @"DATA\WMS\PackingList";

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                string originalFileName = Path.GetFileName(postedFile.FileName);
                string savedFilePath = Path.Combine(uploadPath, originalFileName);

                if (File.Exists(savedFilePath))
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, new { message = "File already exists." });
                }

                postedFile.SaveAs(savedFilePath);
                //DataSet dsupload = new DataSet();
                //DAL objDal = new DAL();
                //dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_DOCPL_UPLOAD_XL_UPDATELOG", cmpid, makerip, vguid, originalFileName, savedFilePath, "PACKINGLIST");
                //string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();

                // ✅ Extract invoice number from filename (e.g., CFM-253046224)
                var match = Regex.Match(originalFileName, @"CFM-\d+");
                if (!match.Success)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invoice number not found in filename.");

                string invoiceNo = match.Value;

                // ✅ Check invoice existence via stored procedure
                DataSet dsUpload = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConnectionString.getConnString()))
                using (SqlCommand cmd = new SqlCommand("usp_imp_wms_checkinvoicenoexists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dsUpload);
                }

                string status = dsUpload.Tables[0].Rows[0]["STATUS"].ToString();
                if (status != "0")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Invoice already exists or invalid status.");
                }

                // ✅ Prepare to read Excel
                string ext = Path.GetExtension(savedFilePath);
                string conStr = "";

                if (ext == ".xls")
                    conStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={savedFilePath};Extended Properties='Excel 8.0;HDR=NO;'";
                else if (ext == ".xlsx")
                    conStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={savedFilePath};Extended Properties='Excel 12.0 Xml;HDR=NO;'";

                using (OleDbConnection excelCon = new OleDbConnection(conStr))
                {
                    excelCon.Open();

                    // ✅ Get first sheet name
                    DataTable dtSheet = excelCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = dtSheet.Rows[1]["TABLE_NAME"].ToString();

                    string query = $"SELECT * FROM [{sheetName}]";
                    using (OleDbDataAdapter da = new OleDbDataAdapter(query, excelCon))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // ✅ Skip first 6 rows
                        for (int i = 0; i < 6 && dt.Rows.Count > 0; i++)
                            dt.Rows.RemoveAt(0);
                        dt.AcceptChanges();

                        // ✅ Use next row as column headers
                        if (dt.Rows.Count > 0)
                        {
                            DataRow headerRow = dt.Rows[0];
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string colName = headerRow[i]?.ToString().Trim();
                                if (string.IsNullOrWhiteSpace(colName))
                                    colName = $"Column{i + 1}";
                                dt.Columns[i].ColumnName = colName;
                            }
                            dt.Rows.RemoveAt(0);
                            dt.AcceptChanges();
                        }

                        // ✅ Forward-fill merged cells
                        object[] lastValues = new object[dt.Columns.Count];
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                if (dt.Rows[r][c] != DBNull.Value && !string.IsNullOrWhiteSpace(dt.Rows[r][c].ToString()))
                                    lastValues[c] = dt.Rows[r][c];
                                else
                                    dt.Rows[r][c] = lastValues[c];
                            }
                        }

                        if (dt.Rows.Count > 1)
                        {
                            var last = dt.Rows[dt.Rows.Count - 1];
                            var prev = dt.Rows[dt.Rows.Count - 2];

                            bool isDuplicate = true;
                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                if (last[c]?.ToString().Trim() != prev[c]?.ToString().Trim())
                                {
                                    isDuplicate = false;
                                    break;
                                }
                            }

                            if (isDuplicate)
                            {
                                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                                dt.AcceptChanges();
                            }
                        }


                        // ✅ Remove completely empty rows safely
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            var row = dt.Rows[i];
                            bool isEmpty = true;

                            foreach (var item in row.ItemArray)
                            {
                                if (item != DBNull.Value && !string.IsNullOrWhiteSpace(item.ToString()))
                                {
                                    isEmpty = false;
                                    break;
                                }
                            }

                            if (isEmpty)
                                dt.Rows.RemoveAt(i);
                        }
                        dt.AcceptChanges();

                        // ✅ Verify required columns
                        string[] requiredColumns = new string[]
                        {
                    "Pallet Number", "Box Number", "EAN Code", "Style", "European HS Code",
                    "HS description", "Commercial Description", "Theme Description",
                    "Departement", "Country of Origin", "Brand", "Composition",
                    "Unit price/HS Code inEUR", "Qty", "Total Amount", "Net Weight/HS Code", "Size"
                        };

                        foreach (var col in requiredColumns)
                        {
                            if (!dt.Columns.Contains(col))
                                throw new Exception($"Excel file does not contain required column '{col}'");
                        }

                        // ✅ Insert cleaned data into SQL
                        using (SqlConnection conn = new SqlConnection(ConnectionString.getConnString()))
                        {
                            conn.Open();

                            foreach (DataRow row in dt.Rows)
                            {
                                // Skip rows where Pallet Number & all other fields are blank
                                if (!dt.Columns.Contains("Pallet Number")) continue;
                                var pallet = row["Pallet Number"]?.ToString().Trim();
                                if (string.IsNullOrWhiteSpace(pallet))
                                {
                                    bool anyData = row.ItemArray.Any(x => !string.IsNullOrWhiteSpace(x?.ToString()));
                                    if (!anyData) continue;
                                }

                                string sql = @"
                            INSERT INTO tbl_imp_wms_docpl_upload
                            (InvoiceNo, PalletNumber, BoxNo, ean, style, hsn, Hsdesc, commdesc, Themedesc, Departement,
                             CountryofOrigin, Brand, Composition, Unitprice, Qty, TotalAmount, NetWt, Size,SHIPMENTNO,MakerId)
                            VALUES
                            (@InvoiceNo, @PalletNumber, @BoxNo + '' + CONVERT(VARCHAR, dbo.fn_CheckDigit(@BoxNo)), @ean, @style, @hsn, @Hsdesc, @commdesc, @Themedesc, @Departement,
                             @CountryofOrigin, @Brand, @Composition, @Unitprice, @Qty, @TotalAmount, @NetWt, @Size,@SHIPMENTNO,@MakerId)";

                                using (SqlCommand cmd = new SqlCommand(sql, conn))
                                {
                                    cmd.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                                    cmd.Parameters.AddWithValue("@PalletNumber", row["Pallet Number"].ToString());
                                    cmd.Parameters.AddWithValue("@BoxNo", row["Box Number"].ToString());
                                    cmd.Parameters.AddWithValue("@ean", row["EAN Code"].ToString());
                                    cmd.Parameters.AddWithValue("@style", row["Style"].ToString());
                                    cmd.Parameters.AddWithValue("@hsn", row["European HS Code"].ToString());
                                    cmd.Parameters.AddWithValue("@Hsdesc", row["HS description"].ToString());
                                    cmd.Parameters.AddWithValue("@commdesc", row["Commercial Description"].ToString());
                                    cmd.Parameters.AddWithValue("@Themedesc", row["Theme Description"].ToString());
                                    cmd.Parameters.AddWithValue("@Departement", row["Departement"].ToString());
                                    cmd.Parameters.AddWithValue("@CountryofOrigin", row["Country of Origin"].ToString());
                                    cmd.Parameters.AddWithValue("@Brand", row["Brand"].ToString());
                                    cmd.Parameters.AddWithValue("@Composition", row["Composition"].ToString());
                                    cmd.Parameters.AddWithValue("@Unitprice", row["Unit price/HS Code inEUR"].ToString());
                                    cmd.Parameters.AddWithValue("@Qty", row["Qty"].ToString());
                                    cmd.Parameters.AddWithValue("@TotalAmount", row["Total Amount"].ToString());
                                    cmd.Parameters.AddWithValue("@NetWt", row["Net Weight/HS Code"].ToString());
                                    cmd.Parameters.AddWithValue("@Size", row["Size"].ToString());
                                    cmd.Parameters.AddWithValue("@SHIPMENTNO", shipmentno);
                                    cmd.Parameters.AddWithValue("@MakerId", cmpid);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                // ✅ Delete uploaded file
                /// File.Delete(savedFilePath);
                //dsupdate = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BANKRECONCIL_UPDATECLEARANCEDT", OURBANK, FROMDT, TODT, logid);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = $"File uploaded and data inserted for invoice {invoiceNo}" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        /// <summary>Perform WMS SHIPMENTHBL DOWNLOADTEMPLATE records.</summary>
        /// <param name="HBLNO">Bill of lading number.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTHBL_DOWNLOADTEMPLATE(string HBLNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_shipmenthbl_template.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETSHIPMENTHBL_DOWNLOADTEMPLATE", (HBLNO != null) ? HBLNO : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            string xsltContent = File.ReadAllText(HttpContext.Current.Server.MapPath("~") + "\\include\\xml\\Import" + "\\" + strXslFilename);

            // Define the worksheet name
            string worksheetName = HBLNO;

            // Replace placeholder with worksheet name
            xsltContent = Regex.Replace(xsltContent, "{worksheetName}", worksheetName);

            // Load modified XSLT content
            XslCompiledTransform transformer = new XslCompiledTransform();
            using (StringReader xsltReader = new StringReader(xsltContent))
            {
                using (XmlReader xsltXmlReader = XmlReader.Create(xsltReader))
                {
                    transformer.Load(xsltXmlReader);
                }
            }
            StringWriter writer = new StringWriter();

            // Transform the XML with the XSLT
            transformer.Transform(xmlDoc, null, writer);

            // Prepare the transformed content for response
            string transformedXml = writer.ToString();

            //  myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(transformedXml));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = HBLNO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Retrieve list of WMS GETSHIPMENTHBL records.</summary>
        /// <param name="Shipmentno">Shipmentno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETSHIPMENTHBL_LIST(string Shipmentno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETSHIPMENTHBL_LIST", Shipmentno);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETSHIPMENTHBL_LIST");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of WMS GOODSRETURN LIST XL records.</summary>
        /// <param name="GRTNNO">GRTNNO parameter.</param>
        /// <param name="GRTNFROMDATE">Start date for the date range filter.</param>
        /// <param name="GRTNTODATE">End date for the date range filter.</param>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_GOODSRETURN_LIST_XL(string GRTNNO, string GRTNFROMDATE, string GRTNTODATE, string SEARCHTYPE, string CITYCODE, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_goodsreturnlist.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_SEARCH", (GRTNNO != null) ? GRTNNO : "", (GRTNFROMDATE != null) ? GRTNFROMDATE : "", (GRTNTODATE != null) ? GRTNTODATE : "", SEARCHTYPE, CITYCODE, CMPCODE);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "goodsreturnlist_asondate_" + GRTNFROMDATE + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS GETKIABICODEWISE DTLS GOODSRETURN records.</summary>
        /// <param name="KIABICODE">KIABICODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETKIABICODEWISE_DTLS_GOODSRETURN(string KIABICODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETKIABICODEWISE_DTLS_GOODSRETURN", KIABICODE, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETKIABICODEWISE_DTLS_GOODSRETURN");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS MULTIEAN RACKNO records.</summary>
        /// <param name="GRNITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MULTIEAN_RACKNO_UPDATE([FromBody]GRNITEM GRNITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_MULTIEAN_RACKNO_UPDATE", GRNITEM.EANNO, GRNITEM.RACKNO, GRNITEM.MAKERID, GRNITEM.MAKERIP, GRNITEM.NEWRACKNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MULTIEAN_RACKNO_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GET EANDTLS FROMRACKNO records.</summary>
        /// <param name="RACKNO">RACKNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GET_EANDTLS_FROMRACKNO(string RACKNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GET_EANDTLS_FROMRACKNO", RACKNO);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GET_EANDTLS_FROMRACKNO");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS DASHBOARD GETRACKNO records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_DASHBOARD_GETRACKNO()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_DASHBOARD_GETRACKNO");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_DASHBOARD_GETRACKNO");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GRN BARCODEITEM IU MANUAL records.</summary>
        /// <param name="GRITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_BARCODEITEM_IU_MANUAL([FromBody]GRNITEM GRITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_BARCODEITEM_IU_MANUAL", GRITEM.ID, GRITEM.GRNNO, GRITEM.FK_ITEMID, GRITEM.QTY, GRITEM.GRNDTLSID, GRITEM.EDFLAG, GRITEM.VGUID, GRITEM.MAKERID, GRITEM.ORDERNO, GRITEM.EANNO, GRITEM.WHCODE, (GRITEM.RACKNO != null) ? GRITEM.RACKNO : "", GRITEM.CONTAINERNO, GRITEM.ENTRYSTARTDTTIME, GRITEM.BOXNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BARCODEITEM_IU_MANUAL");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANBOXWISE DTLS GRN MANUAL records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="BOXNO">BOXNO parameter.</param>
        /// <param name="SHIPMENTTYPE">SHIPMENTTYPE parameter.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANBOXWISE_DTLS_GRN_MANUAL(string EANCODE, string VGUID, string CONTAINERNO, string BOXNO, string SHIPMENTTYPE, string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANBOXWISE_DTLS_GRN_MANUAL", EANCODE, VGUID, CONTAINERNO, BOXNO, SHIPMENTTYPE, PONO);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANBOXWISE_DTLS_GRN_MANUAL");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GRN BOXDTLS MANUAL records.</summary>
        /// <param name="BXNO">BXNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="SHIPMENTTYPE">SHIPMENTTYPE parameter.</param>
        /// <param name="SUPCODE">SUPCODE parameter.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_BOXDTLS_MANUAL(string BXNO, string VGUID, string SHIPMENTTYPE, string SUPCODE, string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_GETBOXDTLS_MANUAL", (BXNO != null) ? BXNO : "0", VGUID, SHIPMENTTYPE, (SUPCODE != null) ? SUPCODE : "0", (PONO != null) ? PONO : "0");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BOXDTLS");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SHIPMENTSTOCK STATUS PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_SHIPMENTSTOCK_STATUS_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_SHIPMENTSTOCK_STATUS_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_SHIPMENTSTOCK_STATUS_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GRN GETSHIPMENTNO FORLOCAL records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="SUPCODE">SUPCODE parameter.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_GETSHIPMENTNO_FORLOCAL(string CMPCODE, string CITYCODE, string SUPCODE, string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_GETSHIPMENTNO_FORLOCAL", CMPCODE, CITYCODE, SUPCODE, (PONO != null) ? PONO : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_GETSHIPMENTNO_FORLOCAL");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SHIPMENTWISE ITEMSTATUS MONTHWISE records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTWISE_ITEMSTATUS_MONTHWISE(string CMPCODE, string CITYCODE, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus_monthwise.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS_ALL_MONTHWISE", CMPCODE, CITYCODE, FROMDATE, TODATE);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CMPCODE + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS SHIPMENTWISE ITEMSTATUS OP XL records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTWISE_ITEMSTATUS_OP_XL(string CMPCODE, string CITYCODE, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus_all.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS_ALL_WITHOP", CMPCODE, CITYCODE, FROMDATE, TODATE);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CMPCODE + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS GOODSISSUE EXPORTTOXL records.</summary>
        /// <param name="GINNO">GINNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_GOODSISSUE_EXPORTTOXL(string GINNO, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_goodsissue.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_PRINT", (GINNO != null) ? GINNO : "", (CMPCODE != null) ? CMPCODE : "", (CITYCODE != null) ? CITYCODE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "deliverychallan_" + GINNO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS COMMONSEARCH RACKWISE GETDATA records.</summary>
        /// <param name="RACKNO">RACKNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_COMMONSEARCH_RACKWISE_GETDATA(String RACKNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_COMMONSEARCH_RACKWISE_GETDATA", RACKNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_COMMONSEARCH_RACKWISE_GETDATA");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS MULTICONT EANWISE RACKNO records.</summary>
        /// <param name="GRNITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MULTICONT_EANWISE_RACKNO_UPDATE([FromBody]GRNITEM GRNITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_MULTICONT_EANWISE_RACKNO_UPDATE", GRNITEM.EANNO, GRNITEM.RACKNO, GRNITEM.CONTAINERNO, GRNITEM.MAKERID, GRNITEM.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MULTICONT_EANWISE_RACKNO_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GOODSISSUE GETMULTICONTAINEREANDTLS records.</summary>
        /// <param name="EAN">EAN parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_GETMULTICONTAINEREANDTLS(string EAN, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_GETEANDTLS", EAN, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_GETMULTICONTAINEREANDTLS");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SKUWISE GETDATA ADV records.</summary>
        /// <param name="SKU">SKU parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CONTNO">CONTNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_SKUWISE_GETDATA_ADV(String SKU, string CMPCODE, string CITYCODE, string CONTNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_SKUWISE_GETDATA_ADV", SKU, CMPCODE, CITYCODE, CONTNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_SKUWISE_GETDATA_ADV");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS RACKUPDATE GETDATA records.</summary>
        /// <param name="EAN">EAN parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_RACKUPDATE_GETDATA(String EAN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_RACKUPDATE_GETDATA", EAN);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_RACKUPDATE_GETDATA");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS GOODSRETURN records.</summary>
        /// <param name="GRTNNO">GRTNNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_PRINT(string GRTNNO, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_PRINT", GRTNNO, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Delete WMS GOODSRETURN ITEMDTLS TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="GRTNDTLSID">GRTNDTLSID parameter.</param>
        /// <param name="EAN">EAN parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_ITEMDTLS_TMP_DEL(string ID, string VGUID, string GRTNDTLSID, string EAN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_DTLS_TMP_DEL", ID, VGUID, GRTNDTLSID, EAN);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_ITEMDTLS_TMP_DEL");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve WMS GOODSRETURN records.</summary>
        /// <param name="GRTNNO">GRTNNO parameter.</param>
        /// <param name="GRTNFROMDATE">Start date for the date range filter.</param>
        /// <param name="GRTNTODATE">End date for the date range filter.</param>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_SEARCH(string GRTNNO, string GRTNFROMDATE, string GRTNTODATE, string SEARCHTYPE, string CITYCODE, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_WMS_GOODSRETURN_SEARCH",
                    (GRTNNO != null) ? GRTNNO : "", (GRTNFROMDATE != null) ? GRTNFROMDATE : "", (GRTNTODATE != null) ? GRTNTODATE : "", SEARCHTYPE, CITYCODE, CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_SEARCH");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS GOODSRETURN records.</summary>
        /// <param name="GRTNNO">GRTNNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_VIEW(string GRTNNO, string CMPCODE, string CITYCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_VIEW", GRTNNO, CMPCODE, CITYCODE, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GOODSRETURN records.</summary>
        /// <param name="GI">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSRETURN_INSERT([FromBody]GOODSRETURN GI)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_INSERT", (GI.GRTNNO != null) ? GI.GRTNNO : "", GI.GRTNDATE, GI.CLIENT, GI.CLIENTADDID, (GI.RETURNNO != null) ? GI.RETURNNO : "", (GI.CLIENTINVNO != null) ? GI.CLIENTINVNO : "", (GI.RETURNDATE != null) ? GI.RETURNDATE : "", (GI.REMARK != null) ? GI.REMARK : "", GI.MAKERID, GI.MAKERIP, GI.CMPCODE, GI.CITYCODE, GI.CITYCODE1, GI.VGUID, GI.ACTION, GI.SCANTYPE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_INSERT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GOODSRETURN records.</summary>
        /// <param name="GI">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSRETURN_UPDATE([FromBody]GOODSRETURN GI)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_UPDATE", (GI.GRTNNO != null) ? GI.GRTNNO : "", GI.GRTNDATE, GI.CLIENT, GI.CLIENTADDID, (GI.RETURNNO != null) ? GI.RETURNNO : "", (GI.CLIENTINVNO != null) ? GI.CLIENTINVNO : "", (GI.RETURNDATE != null) ? GI.RETURNDATE : "", (GI.REMARK != null) ? GI.REMARK : "", GI.MAKERID, GI.MAKERIP, GI.CMPCODE, GI.CITYCODE, GI.CITYCODE1, GI.VGUID, GI.ACTION, GI.SCANTYPE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for WMS GOODSRETURN records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_RESET");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GOODSRETURN TMP records.</summary>
        /// <param name="GRTITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSRETURN_TMP_IU([FromBody]GOODSRETURNITEM GRTITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_TMP_IU", GRTITEM.ID, (GRTITEM.FK_GRTNNO != null) ? GRTITEM.FK_GRTNNO : "", GRTITEM.FK_ITEMID, GRTITEM.RETURNQTY, GRTITEM.EAN, GRTITEM.FK_RETURNREASON, GRTITEM.FK_RETURNTYPE, GRTITEM.GRTNDTLSID, GRTITEM.EDFLAG, GRTITEM.VGUID, GRTITEM.MAKERID, GRTITEM.CONTAINERNO, GRTITEM.BOXNO, (GRTITEM.KIABICODE != null) ? GRTITEM.KIABICODE : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_TMP_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANWISE DTLS GOODSRETURN records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANWISE_DTLS_GOODSRETURN(string EANCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANWISE_DTLS_GOODSRETURN", EANCODE, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANWISE_DTLS_GOODSRETURN");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GOODSRETURN PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSRETURN_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1, string MODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSRETURN_PAGELOAD", CMPCODE, CITYCODE, CITYCODE1, MODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSRETURN_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS MULTIEANWISE RACKSHELF records.</summary>
        /// <param name="ITEMMST">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MULTIEANWISE_RACKSHELF_UPDATE([FromBody]wmsitemmaster ITEMMST)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_RACKSHELF_UPDATE", ITEMMST.STR, ITEMMST.CMP_CODE, ITEMMST.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MULTIEANWISE_RACKSHELF_UPDATE");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS ITEM GETDATA SHIPMENTWISE records.</summary>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="FROMDATE">Start date for the date range filter.</param>
        /// <param name="TODATE">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEM_GETDATA_SHIPMENTWISE(String CONTAINERNO, string CMPCODE, string CITYCODE, string FROMDATE, string TODATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Imp_wms_shipmentwise_Getdata", CONTAINERNO, CMPCODE, CITYCODE, FROMDATE, TODATE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_GETDATA_SHIPMENTWISE");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SKUWISE GETDATA WITHSKU records.</summary>
        /// <param name="SKU">SKU parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_SKUWISE_GETDATA_WITHSKU(String SKU, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_SKUWISE_GETDATA", SKU, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_SKUWISE_GETDATA_WITHSKU");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SKUWISE GETDATA records.</summary>
        /// <param name="SKU">SKU parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CONTNO">CONTNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_SKUWISE_GETDATA(String SKU, string CMPCODE, string CITYCODE, string CONTNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_SKUWISE_GETDATA", SKU, CMPCODE, CITYCODE, CONTNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_SKUWISE_GETDATA");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS SHIPMENTWISE STOCKSTATUS XL records.</summary>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ASONDATE">ASONDATE parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTWISE_STOCKSTATUS_XL(string CONTAINERNO, string CMPCODE, string CITYCODE, string ASONDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_item_stock_report.xsl";

            if (CONTAINERNO == null)
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Imp_wms_Stock_Report", ASONDATE, CMPCODE, CITYCODE);

            }
            else
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Imp_wms_Stock_Report_shipmentwise", CONTAINERNO, CMPCODE, CITYCODE, ASONDATE);
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CONTAINERNO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS SHIPMENTWISE ITEMSTATUS XL records.</summary>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="ASONDATE">ASONDATE parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_SHIPMENTWISE_ITEMSTATUS_XL(string CONTAINERNO, string CMPCODE, string CITYCODE, string ASONDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            if (CONTAINERNO == "All")
            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus_all.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS_ALL", CMPCODE, CITYCODE, ASONDATE);

            }
            else
            {
                strXslFilename = "xsl_import_shipmentwise_stockstatus.xsl";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_SHIPMENTWISE_STOCK_STATUS", CONTAINERNO, CMPCODE, CITYCODE, ASONDATE);
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = CONTAINERNO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS DASHBOARD SHIPMENTWISE records.</summary>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_DASHBOARD_SHIPMENTWISE(string CONTAINERNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_DASHBOARD_SHIPMENTWISE", CONTAINERNO);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_DASHBOARD_SHIPMENTWISE");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS ITEMUPLOAD PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEMUPLOAD_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEMUPLOAD_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEMUPLOAD_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GRN BOXDTLS records.</summary>
        /// <param name="BXNO">BXNO parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="SHIPMENTTYPE">SHIPMENTTYPE parameter.</param>
        /// <param name="SUPCODE">SUPCODE parameter.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_BOXDTLS(string BXNO, string VGUID, string SHIPMENTTYPE, string SUPCODE, string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_GETBOXDTLS", (BXNO != null) ? BXNO : "0", VGUID, SHIPMENTTYPE, (SUPCODE != null) ? SUPCODE : "0", (PONO != null) ? PONO : "0");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BOXDTLS");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANBOXWISE DTLS GRN records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="CONTAINERNO">CONTAINERNO parameter.</param>
        /// <param name="BOXNO">BOXNO parameter.</param>
        /// <param name="SHIPMENTTYPE">SHIPMENTTYPE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANBOXWISE_DTLS_GRN(string EANCODE, string VGUID, string CONTAINERNO, string BOXNO, string SHIPMENTTYPE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANBOXWISE_DTLS_GRN", EANCODE, VGUID, CONTAINERNO, BOXNO, SHIPMENTTYPE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANBOXWISE_DTLS_GRN");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GRN BARCODEITEM records.</summary>
        /// <param name="GRITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_BARCODEITEM_IU([FromBody]GRNITEM GRITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_BARCODEITEM_IU", GRITEM.ID, GRITEM.GRNNO, GRITEM.FK_ITEMID, GRITEM.QTY, GRITEM.GRNDTLSID, GRITEM.EDFLAG, GRITEM.VGUID, GRITEM.MAKERID, GRITEM.ORDERNO, GRITEM.EANNO, GRITEM.WHCODE, (GRITEM.RACKNO != null) ? GRITEM.RACKNO : "", GRITEM.CONTAINERNO, GRITEM.ENTRYSTARTDTTIME, GRITEM.BOXNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BARCODEITEM_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform WMS CLIENT PO DOWNLOAD records.</summary>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_CLIENT_PO_DOWNLOAD(string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_clientpo.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GET_CLIENTPO_DOWNLOADEXCEL", PONO);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            string xsltContent = File.ReadAllText(HttpContext.Current.Server.MapPath("~") + "\\include\\xml\\Import" + "\\" + strXslFilename);

            // Define the worksheet name
            string worksheetName = PONO;

            // Replace placeholder with worksheet name
            xsltContent = Regex.Replace(xsltContent, "{worksheetName}", worksheetName);

            // Load modified XSLT content
            XslCompiledTransform transformer = new XslCompiledTransform();
            using (StringReader xsltReader = new StringReader(xsltContent))
            {
                using (XmlReader xsltXmlReader = XmlReader.Create(xsltReader))
                {
                    transformer.Load(xsltXmlReader);
                }
            }
            StringWriter writer = new StringWriter();

            // Transform the XML with the XSLT
            transformer.Transform(xmlDoc, null, writer);

            // Prepare the transformed content for response
            string transformedXml = writer.ToString();

            //  myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(transformedXml));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = PONO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Retrieve list of WMS GET CLIENTPO records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GET_CLIENTPO_LIST(String FromDate, string ToDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
                    "USP_IMP_WMS_GET_CLIENTPO_LIST", (FromDate != null) ? FromDate : "", (ToDate != null) ? ToDate : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GET_CLIENTPO_LIST");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS EANWISE RACKNO records.</summary>
        /// <param name="GRNITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_EANWISE_RACKNO_UPDATE([FromBody]GRNITEM GRNITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_EANWISE_RACKNO_UPDATE", GRNITEM.EANNO, GRNITEM.RACKNO, GRNITEM.MAKERID, GRNITEM.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_EANWISE_RACKNO_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS CLIENTPOUPLOAD PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_CLIENTPOUPLOAD_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_CLIENTPOUPLOAD_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GOODSISSUE PACKINGLIST DOWNLOAD records.</summary>
        /// <param name="ISSUENO">ISSUENO parameter.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_GOODSISSUE_PACKINGLIST_DOWNLOAD(string ISSUENO, string PONO, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_packinglist.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_PACKINGLIST", ISSUENO, PONO, (CMPCODE != null) ? CMPCODE : "", (CITYCODE != null) ? CITYCODE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            string xsltContent = File.ReadAllText(HttpContext.Current.Server.MapPath("~") + "\\include\\xml\\Import" + "\\" + strXslFilename);

            // Define the worksheet name
            string worksheetName = PONO;

            // Replace placeholder with worksheet name
            xsltContent = Regex.Replace(xsltContent, "{worksheetName}", worksheetName);

            // Load modified XSLT content
            XslCompiledTransform transformer = new XslCompiledTransform();
            using (StringReader xsltReader = new StringReader(xsltContent))
            {
                using (XmlReader xsltXmlReader = XmlReader.Create(xsltReader))
                {
                    transformer.Load(xsltXmlReader);
                }
            }
            StringWriter writer = new StringWriter();

            // Transform the XML with the XSLT
            transformer.Transform(xmlDoc, null, writer);

            // Prepare the transformed content for response
            string transformedXml = writer.ToString();

            //  myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(transformedXml));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = PONO + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Load page reference data for WMS COMMONSEARCH records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_COMMONSEARCH_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_WMS_COMMONSEARCH_PAGELOAD");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_COMMONSEARCH_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Upload UploadClientPOCSV records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        [Route("api/Import/UploadClientPOCSV")]
        public IHttpActionResult UploadClientPOCSV()
        {

            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var httpRequest = HttpContext.Current.Request;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var clientcode = HttpContext.Current.Request.Params["clientcode"];
            var clientaddid = HttpContext.Current.Request.Params["clientaddid"];
            var postedfile = httpRequest.Files["file"];
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            DataRow drow = dtbl.NewRow();
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\ClientPo\\", fileName);

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
                        ds1 = fN_Upload_ClientPO(fileName, cmpid, vguid, makerip, clientcode, clientaddid);
                        if (ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0 &&
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
                ErrorLog.Error(ex, "Import/UploadBnkReconcilFile");
            }
            return Ok(ds1);

        }


        public DataSet fN_Upload_ClientPO(string strFileName, string CMPID, string VGUID, string MAKERIP, string CLIENTCODE, string CLIENTADDID)
        {
            DataSet dsupdate = new DataSet();
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\ClientPo\\" + strFileName);
                file.SaveAs(strFilePath);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_UPLOAD_CLIENTPO_CSV_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "CLIENTPO");
                string status = dsupload.Tables[0].Rows[0]["STATUS"].ToString();

                if (status == "100")
                {
                    string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                    DataSet DS = new DataSet();
                    DataSet MP_DS = new DataSet();
                    dsupdate = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_CLIENT_PO_INSERT", strFilePath, strFileName, logid, CMPID, MAKERIP, VGUID, CLIENTCODE, CLIENTADDID);
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

            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_Upload_ClientPO");

                // Create a new DataSet to hold the error information
                dsupdate = new DataSet();
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("STATUS", typeof(string));
                errorTable.Columns.Add("MSG", typeof(string));

                // Populate the error information
                DataRow errorRow = errorTable.NewRow();
                errorRow["STATUS"] = "500"; // Indicate internal server error
                errorRow["MSG"] = ex.Message; // Include the error message
                errorTable.Rows.Add(errorRow);

                // Add the error table to the DataSet
                dsupdate.Tables.Add(errorTable);
            }
            return dsupdate;

        }


        /// <summary>Retrieve list of WMS GRN LIST XL records.</summary>
        /// <param name="GRNNO">GRNNO parameter.</param>
        /// <param name="GRNFROMDATE">Start date for the date range filter.</param>
        /// <param name="GRNTODATE">End date for the date range filter.</param>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_GRN_LIST_XL(string GRNNO, string GRNFROMDATE, string GRNTODATE, string SEARCHTYPE, string CITYCODE, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_grnlist.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_SEARCH", (GRNNO != null) ? GRNNO : "", (GRNFROMDATE != null) ? GRNFROMDATE : "", (GRNTODATE != null) ? GRNTODATE : "", SEARCHTYPE, CITYCODE, CMPCODE);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "grnlist_asondate_" + GRNTODATE + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Populate form with existing data for WMS ITEM MASTER records.</summary>
        /// <param name="ItemId">Item Id parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEM_MASTER_POPULATE(String ItemId)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_POPULATE", ItemId);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_MASTER_POPULATE");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS ITEM MASTER COMMONSEARCH records.</summary>
        /// <param name="EAN">EAN parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEM_MASTER_COMMONSEARCH(String EAN, string CMPCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_COMMONSEARCH", EAN, CMPCODE, CITYCODE1);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_MASTER_COMMONSEARCH");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GOODSISSUE CARTONPRINT records.</summary>
        /// <param name="GINNO">GINNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_CARTONPRINT(String GINNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_CARTONPRINT", GINNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_CARTONPRINT");
            }
            return Ok(ds);
        }
        //[HttpGet]
        //public IHttpActionResult IMP_WMS_ITEM_MASTER_COMMONSEARCH(String EAN)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {

        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_MASTER_SEARCHDATA", EAN);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_MASTER_COMMONSEARCH");
        //    }
        //    return Ok(ds);
        //}
        /// <summary>Perform WMS GETDATA FORASSIGN MRPLABLES TOUSERS ONLOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="USERID">USERID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS_ONLOAD(string CMPCODE, string CITYCODE, string USERID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETDATA_FOR_MRPLABLES_ONLOAD", CMPCODE, CITYCODE, USERID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS_ONLOAD");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS GRN records.</summary>
        /// <param name="GRNNO">GRNNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_PRINT(string GRNNO, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_PRINT", GRNNO, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS MRPLABEL ASSIGNUSERS records.</summary>
        /// <param name="im">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MRPLABEL_ASSIGNUSERS_UPDATE([FromBody]wmsitemmaster im)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_MRPLABLE_PRINT_ASSIGNUSER_IU", (im.STR != null) ? im.STR : "", im.IsChecked, im.UserId, im.MakerID, im.MakerIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MRPLABEL_ASSIGNUSERS_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS MRPLABEL ASSIGNUSERS UPDATEOLD records.</summary>
        /// <param name="im">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MRPLABEL_ASSIGNUSERS_UPDATEOLD([FromBody]wmsitemmaster im)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_MRPLABLE_PRINT_ASSIGNUSER_IU", (im.STR != null) ? im.STR : "", im.IsChecked, im.UserId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MRPLABEL_ASSIGNUSERS_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS ITEMSTOCK REPORT XL records.</summary>
        /// <param name="TODT">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage IMP_WMS_ITEMSTOCK_REPORT_XL(string TODT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_import_wms_item_stock_report.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Imp_wms_Stock_Report", (TODT != null) ? TODT : "", (CMPCODE != null) ? CMPCODE : "", (CITYCODE != null) ? CITYCODE : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "itemstockreport_asondate_" + TODT + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Perform WMS GETEANWISE DTLS GOODSISSUE POWISE records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="PONO">PONO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANWISE_DTLS_GOODSISSUE_POWISE(string EANCODE, string VGUID, string PONO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANWISE_DTLS_GOODSISSUE_POWISE", EANCODE, VGUID, PONO);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANWISE_DTLS_GOODSISSUE_POWISE");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANWISE DTLS GOODSISSUE records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANWISE_DTLS_GOODSISSUE(string EANCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANWISE_DTLS_GOODSISSUE", EANCODE, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANWISE_DTLS_GOODSISSUE");
            }
            return Ok(ds);
        }
        public string fN_upload_ItemExcelFile_20260401(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string CONTAINERNO, string SHIPMENTTYPE, string SHIPMENTNO)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);

                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMEXCEL", SHIPMENTTYPE, CMPCODE, CITYCODE1);
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                if (SHIPMENTTYPE == "LOC")
                {
                    CONTAINERNO = dsupload.Tables[0].Rows[0]["SHIPMENTNO"].ToString();
                }
              
                // Step 2

                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                Query = string.Format("Select [GTIN],[ShippedQty],[VendorSkuCode],[ArticleType],[Brand Size],[Prominent Colour],[MRP],[AgeGroup],[ShortProductTitle],[MyntraPicture1URL],[MyntraPicture2URL] ,[MyntraPicture3URL],[Country of Origin],[Weight],[HSN],[SUPCODE],[PONO] FROM [{0}]", "MPCargoDataSet$");
                // Query = string.Format("Select [SKU],[Inventory Position (QTY)],[EAN],[REF],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[PICTURE_ZOOM],[Elt 1 (eng)],[Elt 2 (eng)],[INFO_DOUANIERE] FROM [{0}]", "Inventory$");
                // Query = string.Format("Select [REF],[SKU],[EAN],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[Elt 1 (eng)] FROM [{0}]", "ExportSpreadsheet$");


                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];
                //string invstr = "";
                //Exceldt.Columns.Add("UserId", typeof(string));
                //Exceldt.Columns.Add("MAKERIP", typeof(string));
                //Exceldt.Columns.Add("MAKERDT", typeof(string));
                Exceldt.Columns.Add("CMPCODE", typeof(string));
                Exceldt.Columns.Add("CITYCODE", typeof(string));
                Exceldt.Columns.Add("FK_LOGID", typeof(string));
                //Exceldt.Columns.Add("VGUID", typeof(string));
                int i = Exceldt.Rows.Count;
                for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
                {

                    Exceldt.Rows[i]["FK_LOGID"] = logid;
                    Exceldt.Rows[i]["CMPCODE"] = CMPCODE;
                    Exceldt.Rows[i]["CITYCODE"] = CITYCODE1;
                }

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);

                //// assigning Destination table name    
                //objbulk.DestinationTableName = "WMS_ITEM_MASTER_KIABI";
                //// Mapping Table column    
                //objbulk.ColumnMappings.Add("REF", "REFERENCE");
                //objbulk.ColumnMappings.Add("SKU", "SKU");
                //objbulk.ColumnMappings.Add("EAN", "EAN");
                //objbulk.ColumnMappings.Add("TAILLE", "TAILLE");
                //objbulk.ColumnMappings.Add("NUMERO_COLORIS", "NUMERO_COLORIS");
                //objbulk.ColumnMappings.Add("LIBELLE_COLORIS_EN", "LIBELLE_COLORIS_EN");
                //objbulk.ColumnMappings.Add("GROUPE_ANGLAIS", "GROUPE_ANGLAIS");
                //objbulk.ColumnMappings.Add("MARCHE_ANGLAIS", "MARCHE_ANGLAIS");
                //objbulk.ColumnMappings.Add("DPT_ANGLAIS", "DPT_ANGLAIS");
                //objbulk.ColumnMappings.Add("PICTURE", "PICTURE");
                //objbulk.ColumnMappings.Add("PICTURE_ZOOM", "ZMPICTURE");
                //objbulk.ColumnMappings.Add("Elt 1 (eng)", "ELT1");
                //objbulk.ColumnMappings.Add("Elt 2 (eng)", "ELT2");
                //objbulk.ColumnMappings.Add("INFO_DOUANIERE", "INFO_DOUANIERE"); 
                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                //objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");
                //objbulk.ColumnMappings.Add("VGUID", "VGUID");

                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_UPLOAD_TMP";
                // Mapping Table column    
                objbulk.ColumnMappings.Add("GTIN", "EAN");
                objbulk.ColumnMappings.Add("VendorSkuCode", "SKU");
                objbulk.ColumnMappings.Add("ShippedQty", "QTY");
                objbulk.ColumnMappings.Add("Prominent Colour", "LIBELLE_COLORIS_EN");
                objbulk.ColumnMappings.Add("HSN", "HSN");
                objbulk.ColumnMappings.Add("Brand Size", "TAILLE");
                objbulk.ColumnMappings.Add("MRP", "MRP");
                objbulk.ColumnMappings.Add("AgeGroup", "GROUPE_ANGLAIS");
                objbulk.ColumnMappings.Add("ShortProductTitle", "INFO_DOUANIERE");
                objbulk.ColumnMappings.Add("ArticleType", "DPT_ANGLAIS");
                objbulk.ColumnMappings.Add("MyntraPicture1URL", "PICTURE");
                objbulk.ColumnMappings.Add("MyntraPicture3URL", "ZMPICTURE");
                objbulk.ColumnMappings.Add("MyntraPicture2URL", "PIC3");
                objbulk.ColumnMappings.Add("Country of Origin", "ORIGINCOUNTRY");
                objbulk.ColumnMappings.Add("Weight", "WEIGHT");
                objbulk.ColumnMappings.Add("SUPCODE", "FK_SUPCODE");
                objbulk.ColumnMappings.Add("PONO", "PONO");
                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");
                objbulk.ColumnMappings.Add("CMPCODE", "CMPCODE");
                objbulk.ColumnMappings.Add("CITYCODE", "CITYCODE");

                // inserting Datatable Records to DataBase    
                con.Open();
                DataSet ds_fst = new DataSet();/* TODO Change to default(_) if this is not a reference type */;
                objbulk.WriteToServer(Exceldt);
                con.Close();
                ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEM_MASTER_INSERT_BULKUPLOAD", CMPID, MAKERIP, VGUID, logid, CMPCODE, CITYCODE, CITYCODE1, CONTAINERNO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
            }
            return "success";
            //return Ok(gstDS1);
        }
        public string fN_upload_ItemExcelFileOld(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                if (strExtension == ".xls" | strExtension == ".xlsx")
                {
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "Invalid File Selected! Please Select xls File.";
                    // return;
                }
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMEXCEL");
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();

                // Step 2

                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                Query = string.Format("Select [GTIN],[ShippedQty],[VendorSkuCode],[ArticleType],[Brand Size],[Prominent Colour],[MRP],[AgeGroup],[ShortProductTitle],[MyntraPicture1URL],[MyntraPicture2URL] FROM [{0}]", "MPCargoDataSet$");
                // Query = string.Format("Select [SKU],[Inventory Position (QTY)],[EAN],[REF],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[PICTURE_ZOOM],[Elt 1 (eng)],[Elt 2 (eng)],[INFO_DOUANIERE] FROM [{0}]", "Inventory$");
                // Query = string.Format("Select [REF],[SKU],[EAN],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[Elt 1 (eng)] FROM [{0}]", "ExportSpreadsheet$");


                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];
                //string invstr = "";
                //Exceldt.Columns.Add("UserId", typeof(string));
                //Exceldt.Columns.Add("MAKERIP", typeof(string));
                //Exceldt.Columns.Add("MAKERDT", typeof(string));
                //Exceldt.Columns.Add("FK_LOGID", typeof(string));
                //Exceldt.Columns.Add("VGUID", typeof(string));
                int i = Exceldt.Rows.Count;
                //for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
                //{
                //    Exceldt.Rows[i]["UserId"] = CMPID;
                //    Exceldt.Rows[i]["MAKERIP"] = MAKERIP;
                //    Exceldt.Rows[i]["MAKERDT"] = DateTime.Now;
                //    Exceldt.Rows[i]["FK_LOGID"] = logid;
                //}

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);

                //// assigning Destination table name    
                //objbulk.DestinationTableName = "WMS_ITEM_MASTER_KIABI";
                //// Mapping Table column    
                //objbulk.ColumnMappings.Add("REF", "REFERENCE");
                //objbulk.ColumnMappings.Add("SKU", "SKU");
                //objbulk.ColumnMappings.Add("EAN", "EAN");
                //objbulk.ColumnMappings.Add("TAILLE", "TAILLE");
                //objbulk.ColumnMappings.Add("NUMERO_COLORIS", "NUMERO_COLORIS");
                //objbulk.ColumnMappings.Add("LIBELLE_COLORIS_EN", "LIBELLE_COLORIS_EN");
                //objbulk.ColumnMappings.Add("GROUPE_ANGLAIS", "GROUPE_ANGLAIS");
                //objbulk.ColumnMappings.Add("MARCHE_ANGLAIS", "MARCHE_ANGLAIS");
                //objbulk.ColumnMappings.Add("DPT_ANGLAIS", "DPT_ANGLAIS");
                //objbulk.ColumnMappings.Add("PICTURE", "PICTURE");
                //objbulk.ColumnMappings.Add("PICTURE_ZOOM", "ZMPICTURE");
                //objbulk.ColumnMappings.Add("Elt 1 (eng)", "ELT1");
                //objbulk.ColumnMappings.Add("Elt 2 (eng)", "ELT2");
                //objbulk.ColumnMappings.Add("INFO_DOUANIERE", "INFO_DOUANIERE"); 
                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                //objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");
                //objbulk.ColumnMappings.Add("VGUID", "VGUID");

                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_UPLOAD_TMP";
                // Mapping Table column    
                objbulk.ColumnMappings.Add("GTIN", "EAN");
                objbulk.ColumnMappings.Add("VendorSkuCode", "SKU");
                objbulk.ColumnMappings.Add("ShippedQty", "QTY");
                objbulk.ColumnMappings.Add("Prominent Colour", "LIBELLE_COLORIS_EN");
                objbulk.ColumnMappings.Add("Brand Size", "TAILLE");
                objbulk.ColumnMappings.Add("MRP", "MRP");
                objbulk.ColumnMappings.Add("AgeGroup", "GROUPE_ANGLAIS");
                objbulk.ColumnMappings.Add("ShortProductTitle", "INFO_DOUANIERE");
                objbulk.ColumnMappings.Add("ArticleType", "DPT_ANGLAIS");
                objbulk.ColumnMappings.Add("MyntraPicture1URL", "PICTURE");
                objbulk.ColumnMappings.Add("MyntraPicture2URL", "ZMPICTURE");

                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                //objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");

                // inserting Datatable Records to DataBase    
                con.Open();
                DataSet ds_fst = new DataSet();/* TODO Change to default(_) if this is not a reference type */;
                objbulk.WriteToServer(Exceldt);
                con.Close();
                ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEM_MASTER_INSERT_BULKUPLOAD", CMPID, MAKERIP, VGUID, logid, CMPCODE, CITYCODE, CITYCODE1);



            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
            }
            return "success";
            //return Ok(gstDS1);
        }
        /// <summary>Retrieve print/view data for WMSGOODSISSUE records.</summary>
        /// <param name="GINO">GINO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMSGOODSISSUE_PRINT(string GINO, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_PRINT", GINO, CMPCODE, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/IMP_WMSGOODSISSUE_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANWISE DTLS records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANWISE_DTLS(string EANCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANWISE_DTLS", EANCODE, VGUID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANWISE_DTLS");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS MRPLABLE records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_MRPLABLE_PRINT(string ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GET_MRPLABLE_PRINT", ID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_MRPLABLE_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS MRPLABEL ASSIGNUSERS records.</summary>
        /// <param name="im">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_MRPLABEL_ASSIGNUSERS_INSERT([FromBody]wmsitemmaster im)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_MRPLABLE_ASSIGNUSER_IU", (im.pk_Id != null) ? im.pk_Id : "", im.Ean, im.Qty, im.UserName, im.NoofLables, im.MakerID, im.MakerIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_MRPLABEL_ASSIGNUSERS_INSERT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETDATA FORASSIGN MRPLABLES TOUSERS records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="USERID">USERID parameter.</param>
        /// <param name="BOXNO">BOXNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS(string CMPCODE, string CITYCODE, string USERID, string BOXNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETDATA_FOR_MRPLABLES", CMPCODE, CITYCODE, USERID, BOXNO == null ? "" : BOXNO);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETDATA FORASSIGN MRPLABLES TOUSERSOLD records.</summary>
        /// <param name="ITEMGROUP">ITEMGROUP parameter.</param>
        /// <param name="ITEMSUBGRP">ITEMSUBGRP parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="USERID">USERID parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERSOLD(string ITEMGROUP, string ITEMSUBGRP, string CMPCODE, string CITYCODE, string USERID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS", (ITEMGROUP != null) ? ITEMGROUP : "0", (ITEMSUBGRP != null) ? ITEMSUBGRP : "0", CMPCODE, CITYCODE, USERID);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETDATA_FORASSIGN_MRPLABLES_TOUSERS");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS ITEM records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEM_PRINT(string EANCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_PRINT", EANCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GETEANWISE DTLS records.</summary>
        /// <param name="EANCODE">EANCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GETEANWISE_DTLS(string EANCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GETEANWISE_DTLS", EANCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GETEANWISE_DTLS");
            }
            return Ok(ds);
        }

        /// <summary>UploadItemMrpExcelFile operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        // [Route("api/Accounts")]
        public IHttpActionResult UploadItemMrpExcelFile()
        {
            //HttpResponseMessage response = null;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();
            string msg;
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var containerno = HttpContext.Current.Request.Params["containerno"];
            var shipmenttype = HttpContext.Current.Request.Params["shipmenttype"];
            var shipmentno = HttpContext.Current.Request.Params["shipmentno"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\", fileName);

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
                        fN_upload_ItemMrpExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1,containerno, shipmenttype, shipmentno);
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
                ErrorLog.Error(ex, "Import/UploadItemMrpExcelFile");
            }
            return Ok(ds1);
        }
        public string fN_upload_ItemMrpExcelFile(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1, string CONTAINERNO, string SHIPMENTTYPE, string SHIPMENTNO)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMMRPEXCEL", SHIPMENTTYPE, CMPCODE, CITYCODE1);
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                if (SHIPMENTTYPE == "LOC")
                {
                    CONTAINERNO = SHIPMENTNO;
                }
                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                //Query = string.Format("Select [EAN],[QTY],[PRICE],[PRODUCT TYPE],[Item Name],[Dimension],[Manufactured On],[Manufactured By ],[Imported On],[COUNTRY OF ORIGIN],[Imported By  and Address],[Customer Service Contact no],[Customer Service Email] FROM [{0}]", "MRPLabelFinal$");
                Query = string.Format("Select [EAN],[QTY],[PRICE],[PRODUCT TYPE],[Item Name],[Dimension],[Manufactured On],[Imported On],[COUNTRY OF ORIGIN],[Imported By  and Address],[Customer Service Contact no],[Customer Service Email],[Box number] FROM [{0}]", "MRPLabelFinal$");

                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];
                Exceldt.Columns.Add("CONTAINERNO", typeof(string));
                Exceldt.Columns.Add("CMPCODE", typeof(string));
                Exceldt.Columns.Add("CITYCODE", typeof(string));
                Exceldt.Columns.Add("BALQTY", typeof(string));

                int i = Exceldt.Rows.Count;
                for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
                {

                    Exceldt.Rows[i]["CMPCODE"] = CMPCODE;
                    Exceldt.Rows[i]["CITYCODE"] = CITYCODE1;
                    Exceldt.Rows[i]["CONTAINERNO"] = CONTAINERNO;
                }



                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);
                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_MRPLABEL";
                // Mapping Table column    

                objbulk.ColumnMappings.Add("EAN", "EAN");
                objbulk.ColumnMappings.Add("QTY", "QTY");
                objbulk.ColumnMappings.Add("PRICE", "PRICE");
                objbulk.ColumnMappings.Add("PRODUCT TYPE", "PRODUCTTYPE");
                objbulk.ColumnMappings.Add("Item Name", "ITEMNAME");
                objbulk.ColumnMappings.Add("Dimension", "DIMENSION");
                objbulk.ColumnMappings.Add("Manufactured On", "MFGON");
                //  objbulk.ColumnMappings.Add("Manufactured By ", "MFGBY");
                objbulk.ColumnMappings.Add("Imported On", "IMPON");
                objbulk.ColumnMappings.Add("COUNTRY OF ORIGIN", "ORIGINCOUNTRY");
                objbulk.ColumnMappings.Add("Imported By  and Address", "IMPBYADDRESS");
                objbulk.ColumnMappings.Add("Customer Service Contact no", "CSCONTACTNO");
                objbulk.ColumnMappings.Add("Customer Service Email", "CSEMAIL");
                objbulk.ColumnMappings.Add("Box number", "BOXNO");
                objbulk.ColumnMappings.Add("QTY", "BALQTY");
                objbulk.ColumnMappings.Add("CMPCODE", "CMPCODE");
                objbulk.ColumnMappings.Add("CITYCODE", "CITYCODE");
                objbulk.ColumnMappings.Add("CONTAINERNO", "CONTAINERNO");

                // inserting Datatable Records to DataBase    
                con.Open();
                objbulk.WriteToServer(Exceldt);
                con.Close();

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ItemMrpExcelFile");
            }
            return "success";

        }
        public string fN_upload_ItemMrpExcelFileold(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMMRPEXCEL");
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                Query = string.Format("Select [EAN],[QTY],[PRICE],[PRODUCT TYPE],[Item Name],[Dimension],[Manufactured On],[Manufactured By ],[Imported On],[COUNTRY OF ORIGIN],[Imported By  and Address],[Customer Service Contact no],[Customer Service Email] FROM [{0}]", "MRPLabelFinal$");

                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];

                //Exceldt.Columns.Add("MAKERID", typeof(string));
                // Exceldt.Columns.Add("MAKERIP", typeof(string));
                // foreach (DataRow row in Exceldt.Rows)
                // {
                //     row["MAKERIP"] = MAKERIP;
                // }
                //Exceldt.Columns.Add("MAKERDT", typeof(DateTime));

                //foreach (DataRow row in Exceldt.Rows)
                //{
                //    row["MAKERDT"] = DateTime.Now; 
                //}

                //Exceldt.Columns["MAKERID"].Expression = CMPID;
                //// Exceldt.Columns["MAKERIP"].Expression = MAKERIP;
                // //Exceldt.Columns["MAKERDT"].Expression = DateTime.Now;

                // DateTime defaultMakerDate = DateTime.Now;

                // foreach (DataRow row in Exceldt.Rows)
                // {
                //     row.SetField("MAKERDT", defaultMakerDate);
                // }
                // int i = Exceldt.Rows.Count;

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);
                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_MRPLABEL";
                // Mapping Table column    

                objbulk.ColumnMappings.Add("EAN", "EAN");
                objbulk.ColumnMappings.Add("QTY", "QTY");
                objbulk.ColumnMappings.Add("PRICE", "PRICE");
                objbulk.ColumnMappings.Add("PRODUCT TYPE", "PRODUCTTYPE");
                objbulk.ColumnMappings.Add("Item Name", "ITEMNAME");
                objbulk.ColumnMappings.Add("Dimension", "DIMENSION");
                objbulk.ColumnMappings.Add("Manufactured On", "MFGON");
                objbulk.ColumnMappings.Add("Manufactured By ", "MFGBY");
                objbulk.ColumnMappings.Add("Imported On", "IMPON");
                objbulk.ColumnMappings.Add("COUNTRY OF ORIGIN", "ORIGINCOUNTRY");
                objbulk.ColumnMappings.Add("Imported By  and Address", "IMPBYADDRESS");
                objbulk.ColumnMappings.Add("Customer Service Contact no", "CSCONTACTNO");
                objbulk.ColumnMappings.Add("Customer Service Email", "CSEMAIL");
                //objbulk.ColumnMappings.Add("MAKERID", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");

                // inserting Datatable Records to DataBase    
                con.Open();
                objbulk.WriteToServer(Exceldt);
                con.Close();

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ItemMrpExcelFile");
            }
            return "success";

        }
        public string fN_upload_ItemMrpExcelFileOld(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMMRPEXCEL");
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();
                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                Query = string.Format("Select [EAN],[QTY],[PRICE],[PRODUCT TYPE],[Item Name],[Dimenssion],[Manufactured On],[Manufactured By ],[Imported On],[COUNTRY OF ORIGIN],[Imported By  and Address],[Customer Service Contact no],[Customer Service Email] FROM [{0}]", "KIABI_MRP$");

                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];

                Exceldt.Columns.Add("MAKERID", typeof(string));
                Exceldt.Columns.Add("MAKERIP", typeof(string));
                foreach (DataRow row in Exceldt.Rows)
                {
                    row["MAKERIP"] = MAKERIP;
                }
                Exceldt.Columns.Add("MAKERDT", typeof(DateTime));

                foreach (DataRow row in Exceldt.Rows)
                {
                    row["MAKERDT"] = DateTime.Now;
                }

                Exceldt.Columns["MAKERID"].Expression = CMPID;
                //// Exceldt.Columns["MAKERIP"].Expression = MAKERIP;
                // //Exceldt.Columns["MAKERDT"].Expression = DateTime.Now;

                // DateTime defaultMakerDate = DateTime.Now;

                // foreach (DataRow row in Exceldt.Rows)
                // {
                //     row.SetField("MAKERDT", defaultMakerDate);
                // }
                // int i = Exceldt.Rows.Count;

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);
                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_MRPLABEL";
                // Mapping Table column    

                objbulk.ColumnMappings.Add("EAN", "EAN");
                objbulk.ColumnMappings.Add("QTY", "QTY");
                objbulk.ColumnMappings.Add("PRICE", "PRICE");
                objbulk.ColumnMappings.Add("PRODUCT TYPE", "PRODUCTTYPE");
                objbulk.ColumnMappings.Add("Item Name", "ITEMNAME");
                objbulk.ColumnMappings.Add("Dimenssion", "DIMENSION");
                objbulk.ColumnMappings.Add("Manufactured On", "MFGON");
                objbulk.ColumnMappings.Add("Manufactured By ", "MFGBY");
                objbulk.ColumnMappings.Add("Imported On", "IMPON");
                objbulk.ColumnMappings.Add("COUNTRY OF ORIGIN", "ORIGINCOUNTRY");
                objbulk.ColumnMappings.Add("Imported By  and Address", "IMPBYADDRESS");
                objbulk.ColumnMappings.Add("Customer Service Contact no", "CSCONTACTNO");
                objbulk.ColumnMappings.Add("Customer Service Email", "CSEMAIL");
                objbulk.ColumnMappings.Add("MAKERID", "MAKERID");
                objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");

                // inserting Datatable Records to DataBase    
                con.Open();
                objbulk.WriteToServer(Exceldt);
                con.Close();

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ItemMrpExcelFile");
            }
            return "success";

        }
        /// <summary>Upload UploadItemExcelFile records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UploadItemExcelFile()
        {
            //HttpResponseMessage response = null;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();
            string msg;
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var containerno = HttpContext.Current.Request.Params["containerno"];
            var shipmenttype = HttpContext.Current.Request.Params["shipmenttype"];
            var shipmentno = HttpContext.Current.Request.Params["shipmentno"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\", fileName);

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
                        fN_upload_ItemExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, containerno, shipmenttype, shipmentno);
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
                ErrorLog.Error(ex, "Import/UploadItemExcelFile");
            }
            return Ok(ds1);
        }
        public IHttpActionResult UploadItemExcelFileold()
        {
            //HttpResponseMessage response = null;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataTable dtbl = new DataTable();
            // DataRow drow = new DataRow;
            DataRow drow = dtbl.NewRow();
            string msg;
            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            var cmpid = HttpContext.Current.Request.Params["cmpid"];
            var vguid = HttpContext.Current.Request.Params["vguid"];
            var makerip = HttpContext.Current.Request.Params["makerip"];
            var cmpcode = HttpContext.Current.Request.Params["cmpcode"];
            var citycode = HttpContext.Current.Request.Params["citycode"];
            var citycode1 = HttpContext.Current.Request.Params["citycode1"];
            var containerno = HttpContext.Current.Request.Params["containerno"];
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\", fileName);

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
                       // fN_upload_ItemExcelFile(fileName, cmpid, vguid, makerip, cmpcode, citycode, citycode1, containerno);
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
                ErrorLog.Error(ex, "Import/UploadItemExcelFile");
            }
            return Ok(ds1);
        }
        public string fN_upload_ItemExcelFileOld1(string strFileName, string CMPID, string VGUID, string MAKERIP, string CMPCODE, string CITYCODE, string CITYCODE1)
        {

            DataSet gstDS1 = new DataSet();
            DataSet gstResust = new DataSet();


            var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
            try
            {
                strFileName = Path.GetFileName(strFileName);
                string strExtension;
                strExtension = Path.GetExtension(strFileName);
                if (strExtension == ".xls" | strExtension == ".xlsx")
                {
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "Invalid File Selected! Please Select xls File.";
                    // return;
                }
                string strFilePath;
                strFilePath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~") + "\\DATA\\WMS\\itemmaster\\" + strFileName);
                DataSet dsupload = new DataSet();
                DAL objDal = new DAL();
                dsupload = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_UPLOAD_XL_UPDATELOG", CMPID, MAKERIP, VGUID, strFileName, strFilePath, "ITEMEXCEL");
                string logid = dsupload.Tables[0].Rows[0]["LOGID"].ToString();

                // Step 2

                DataSet DS = new DataSet();
                DataSet MP_DS = new DataSet();
                OleDbDataAdapter Adapter = new OleDbDataAdapter();
                OleDbConnection myExcelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFilePath + ";Extended Properties=\"Excel 12.0;HDR=Yes\"; ");

                string Query, sqlconn;
                Query = string.Format("Select [SKU],[Inventory Position (QTY)],[EAN],[REF],[COLORIS_TECHNIQUE],[TAILLE],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[PICTURE_ZOOM],[Elt 1 (eng)],[Elt 2 (eng)],[INFO_DOUANIERE] FROM [{0}]", "Inventory$");
                // Query = string.Format("Select [SKU],[Inventory Position (QTY)],[EAN],[REF],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[PICTURE_ZOOM],[Elt 1 (eng)],[Elt 2 (eng)],[INFO_DOUANIERE] FROM [{0}]", "Inventory$");
                // Query = string.Format("Select [REF],[SKU],[EAN],[TAILLE],[NUMERO_COLORIS],[LIBELLE_COLORIS_EN],[GROUPE_ANGLAIS],[MARCHE_ANGLAIS],[DPT_ANGLAIS],[PICTURE],[Elt 1 (eng)] FROM [{0}]", "ExportSpreadsheet$");


                OleDbCommand Ecom = new OleDbCommand(Query, myExcelConn);
                myExcelConn.Open();

                OleDbDataAdapter oda = new OleDbDataAdapter(Query, myExcelConn);
                myExcelConn.Close();
                oda.Fill(DS);
                DataTable Exceldt = DS.Tables[0];
                //string invstr = "";
                //Exceldt.Columns.Add("UserId", typeof(string));
                //Exceldt.Columns.Add("MAKERIP", typeof(string));
                //Exceldt.Columns.Add("MAKERDT", typeof(string));
                //Exceldt.Columns.Add("FK_LOGID", typeof(string));
                //Exceldt.Columns.Add("VGUID", typeof(string));
                int i = Exceldt.Rows.Count;
                //for (i = 0; i <= Exceldt.Rows.Count - 1; i++)
                //{
                //    Exceldt.Rows[i]["UserId"] = CMPID;
                //    Exceldt.Rows[i]["MAKERIP"] = MAKERIP;
                //    Exceldt.Rows[i]["MAKERDT"] = DateTime.Now;
                //    Exceldt.Rows[i]["FK_LOGID"] = logid;
                //}

                SqlConnection con = new SqlConnection();

                // creating object of SqlBulkCopy    
                SqlBulkCopy objbulk = new SqlBulkCopy(System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"]);
                sqlconn = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                con = new SqlConnection(sqlconn);

                //// assigning Destination table name    
                //objbulk.DestinationTableName = "WMS_ITEM_MASTER_KIABI";
                //// Mapping Table column    
                //objbulk.ColumnMappings.Add("REF", "REFERENCE");
                //objbulk.ColumnMappings.Add("SKU", "SKU");
                //objbulk.ColumnMappings.Add("EAN", "EAN");
                //objbulk.ColumnMappings.Add("TAILLE", "TAILLE");
                //objbulk.ColumnMappings.Add("NUMERO_COLORIS", "NUMERO_COLORIS");
                //objbulk.ColumnMappings.Add("LIBELLE_COLORIS_EN", "LIBELLE_COLORIS_EN");
                //objbulk.ColumnMappings.Add("GROUPE_ANGLAIS", "GROUPE_ANGLAIS");
                //objbulk.ColumnMappings.Add("MARCHE_ANGLAIS", "MARCHE_ANGLAIS");
                //objbulk.ColumnMappings.Add("DPT_ANGLAIS", "DPT_ANGLAIS");
                //objbulk.ColumnMappings.Add("PICTURE", "PICTURE");
                //objbulk.ColumnMappings.Add("PICTURE_ZOOM", "ZMPICTURE");
                //objbulk.ColumnMappings.Add("Elt 1 (eng)", "ELT1");
                //objbulk.ColumnMappings.Add("Elt 2 (eng)", "ELT2");
                //objbulk.ColumnMappings.Add("INFO_DOUANIERE", "INFO_DOUANIERE"); 
                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                //objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");
                //objbulk.ColumnMappings.Add("VGUID", "VGUID");

                // assigning Destination table name    
                objbulk.DestinationTableName = "WMS_ITEM_MASTER_UPLOAD_TMP";
                // Mapping Table column    

                objbulk.ColumnMappings.Add("SKU", "SKU");
                objbulk.ColumnMappings.Add("Inventory Position (QTY)", "QTY");
                objbulk.ColumnMappings.Add("EAN", "EAN");
                objbulk.ColumnMappings.Add("REF", "REFERENCE");
                objbulk.ColumnMappings.Add("COLORIS_TECHNIQUE", "COLORIS_TECHNIQUE");
                objbulk.ColumnMappings.Add("TAILLE", "TAILLE");
                objbulk.ColumnMappings.Add("LIBELLE_COLORIS_EN", "LIBELLE_COLORIS_EN");
                objbulk.ColumnMappings.Add("GROUPE_ANGLAIS", "GROUPE_ANGLAIS");
                objbulk.ColumnMappings.Add("MARCHE_ANGLAIS", "MARCHE_ANGLAIS");
                objbulk.ColumnMappings.Add("DPT_ANGLAIS", "DPT_ANGLAIS");
                objbulk.ColumnMappings.Add("PICTURE", "PICTURE");
                objbulk.ColumnMappings.Add("PICTURE_ZOOM", "ZMPICTURE");
                objbulk.ColumnMappings.Add("Elt 1 (eng)", "ELT1");
                objbulk.ColumnMappings.Add("Elt 2 (eng)", "ELT2");
                objbulk.ColumnMappings.Add("INFO_DOUANIERE", "INFO_DOUANIERE");
                //objbulk.ColumnMappings.Add("UserId", "MAKERID");
                //objbulk.ColumnMappings.Add("MAKERIP", "MAKERIP");
                //objbulk.ColumnMappings.Add("MAKERDT", "MAKERDT");
                //objbulk.ColumnMappings.Add("FK_LOGID", "FK_LOGID");

                // inserting Datatable Records to DataBase    
                con.Open();
                DataSet ds_fst = new DataSet();/* TODO Change to default(_) if this is not a reference type */;
                objbulk.WriteToServer(Exceldt);
                con.Close();
                ds_fst = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEM_MASTER_INSERT_BULKUPLOAD", CMPID, MAKERIP, VGUID, logid, CMPCODE, CITYCODE, CITYCODE1);



            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Accounts/fN_upload_ExcelFile");
            }
            return "success";
            //return Ok(gstDS1);
        }
        /// <summary>Insert or update WMS GOODSISSUE BARCODEITEM records.</summary>
        /// <param name="GITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSISSUE_BARCODEITEM_IU([FromBody]GOODISSUEITEM GITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_BARCODEITEM_IU", GITEM.ID, GITEM.GINNO, GITEM.FK_ITEMID, GITEM.ISSUEQTY, GITEM.GINDTLSID, GITEM.EDFLAG, GITEM.VGUID, GITEM.MAKERID, GITEM.EAN, (GITEM.BOXNO != null) ? GITEM.BOXNO : "0",(GITEM.PONO != null) ? GITEM.PONO : "", (GITEM.CONTAINERNO != null) ? GITEM.CONTAINERNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_BARCODEITEM_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        //[HttpPost]
        //public IHttpActionResult IMP_WMS_GOODSISSUE_BARCODEITEM_IU([FromBody]GOODISSUEITEM GITEM)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPORT_WMS_GOODSISSUE_BARCODEITEM_IU", GITEM.ID, GITEM.GINNO, GITEM.FK_ITEMID, GITEM.ISSUEQTY, GITEM.GINDTLSID, GITEM.EDFLAG, GITEM.VGUID, GITEM.MAKERID, GITEM.EAN);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_BARCODEITEM_IU");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }
        //    return Ok(ds);
        //}
        //[HttpGet]
        //public IHttpActionResult IMP_WMS_ITEM_PRINT(string EANCODE)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_ITEM_PRINT", EANCODE);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_PRINT");
        //    }
        //    return Ok(ds);
        //}
        /// <summary>Perform WMS GRN BARCODEITEM IUold records.</summary>
        /// <param name="GRITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_BARCODEITEM_IUold([FromBody]GRNITEM GRITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPORT_WMS_GRN_BARCODEITEM_IU", GRITEM.ID, GRITEM.GRNNO, GRITEM.FK_ITEMID, GRITEM.QTY, GRITEM.GRNDTLSID, GRITEM.EDFLAG, GRITEM.VGUID, GRITEM.MAKERID, GRITEM.ORDERNO, GRITEM.EANNO, GRITEM.WHCODE, (GRITEM.RACKNO != null) ? GRITEM.RACKNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_BARCODEITEM_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform WMS ITEM STOCK REPORT records.</summary>
        /// <param name="TODT">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_ITEM_STOCK_REPORT(string TODT, string CMPCODE, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Imp_wms_Stock_Report",  TODT, CMPCODE, CITYCODE);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_ITEM_STOCK_REPORT");
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS DASHBOARD records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_DASHBOARD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_DASHBOARD");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_DASHBOARD");
            }
            return Ok(ds);
        }
        /// <summary>Generate SEA CONSOLE GENERATE AUTO records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_SEA_CONSOLE_GENERATE_AUTO([FromBody]CommonEight obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_CONSOLE_GENERATE_SEA_IU",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5, obj.Type6, obj.Type7, obj.Type8);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_SEA_CONSOLE_GENERATE_AUTO");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Load page reference data for CONT MAWB PAGELOAD records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXP_CONT_MAWB_PAGELOAD_LIST([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_CONT_MAWB_PAGELOAD_LIST",
                    obj.Type1, obj.Type2, obj.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/EXP_CONT_MAWB_PAGELOAD_LIST");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for WMS GRN records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMSGRN_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS GRN records.</summary>
        /// <param name="GRNNO">GRNNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_VIEW(string GRNNO, string CMPCODE, string CITYCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_VIEW", GRNNO, CMPCODE, CITYCODE, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve WMS GRN records.</summary>
        /// <param name="GRNNO">GRNNO parameter.</param>
        /// <param name="GRNFROMDATE">Start date for the date range filter.</param>
        /// <param name="GRNTODATE">End date for the date range filter.</param>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_SEARCH(string GRNNO, string GRNFROMDATE, string GRNTODATE, string SEARCHTYPE, string CITYCODE, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_WMS_GRN_SEARCH",
                    (GRNNO != null) ? GRNNO : "", (GRNFROMDATE != null) ? GRNFROMDATE : "", (GRNTODATE != null) ? GRNTODATE : "", SEARCHTYPE, CITYCODE, CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_SEARCH");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Delete WMS GRN ITEMDTLS TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="GRNDTLSID">GRNDTLSID parameter.</param>
        /// <param name="EAN">EAN parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_ITEMDTLS_TMP_DEL(string ID, string VGUID, string GRNDTLSID, string EAN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRNDTLS_TMP_DEL", ID, VGUID, GRNDTLSID, EAN);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_ITEMDTLS_TMP_DEL");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GRN ITEMDTLS TMP records.</summary>
        /// <param name="GITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_ITEMDTLS_TMP_IU([FromBody]GRNITEM GITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRNDTLS_TMP_IU", GITEM.ID, GITEM.GRNNO, GITEM.FK_ITEMID, GITEM.FK_ITEMGRPID, GITEM.FK_ITEMTYPEID, GITEM.FK_ITEMSIZEID, GITEM.QTY, GITEM.UOM, GITEM.GRNDTLSID, GITEM.EDFLAG, GITEM.VGUID, GITEM.MAKERID, GITEM.ORDERNO, GITEM.EANNO, (GITEM.WHCODE != null) ? GITEM.WHCODE : "", (GITEM.RACKNO != null) ? GITEM.RACKNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_ITEMDTLS_TMP_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GRN ORDERDETAILS GET records.</summary>
        /// <param name="orderno">orderno parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <param name="shiptype">shiptype parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GRN_ORDERDETAILS_GET(string orderno, string vguid, string shiptype)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_ORDERDETAILS_GET", orderno, vguid,shiptype);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_ORDERDETAILS_GET");
            }
            return Ok(ds);
        }
        /// <summary>IMP WMS GRN PAGE LOAD operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
       
        public IHttpActionResult IMP_WMS_GRN_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1, string MODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_PAGE_LOAD", CMPCODE, CITYCODE, CITYCODE1, MODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GRN_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GRN records.</summary>
        /// <param name="GR">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_INSERT([FromBody]GRN GR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_INSERT", (GR.GRNNO != null) ? GR.GRNNO : "", GR.GRNDATE, GR.CONTAINERNO, GR.ORDERNO, GR.MAKERID, GR.MAKERIP, GR.CMPCODE, GR.CITYCODE, GR.CITYCODE1, GR.VGUID, GR.STATUS, GR.ACTION, (GR.FK_SUPPLIER != null) ? GR.FK_SUPPLIER : "", (GR.SHIPMENTTYPE != null) ? GR.SHIPMENTTYPE : "", (GR.GRNTYPE != null) ? GR.GRNTYPE : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_INSERT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GRN records.</summary>
        /// <param name="GR">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GRN_UPDATE([FromBody]GRN GR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GRN_UPDATE", GR.GRNNO, GR.GRNDATE, GR.CONTAINERNO, GR.ORDERNO, GR.MAKERID, GR.MAKERIP, GR.CMPCODE, GR.CITYCODE, GR.CITYCODE1, GR.VGUID, GR.STATUS, GR.ACTION, (GR.FK_SUPPLIER != null) ? GR.FK_SUPPLIER : "", (GR.SHIPMENTTYPE != null) ? GR.SHIPMENTTYPE : "", (GR.GRNTYPE != null) ? GR.GRNTYPE : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GRN_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for WMS GOODSISSUE records.</summary>
        /// <param name="GINNO">GINNO parameter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_VIEW(string GINNO, string CMPCODE, string CITYCODE, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_VIEW", GINNO, CMPCODE, CITYCODE, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_VIEW");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve WMS GOODSISSUE records.</summary>
        /// <param name="GINNO">GINNO parameter.</param>
        /// <param name="GINFROMDATE">Start date for the date range filter.</param>
        /// <param name="GINTODATE">End date for the date range filter.</param>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_SEARCH(string GINNO, string GINFROMDATE, string GINTODATE, string SEARCHTYPE, string CITYCODE, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_WMS_GOODSISSUE_SEARCH",
                    (GINNO != null) ? GINNO : "", (GINFROMDATE != null) ? GINFROMDATE : "", (GINTODATE != null) ? GINTODATE : "", SEARCHTYPE, CITYCODE, CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_SEARCH");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for WMS GOODSISSUE records.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_RESET");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GOODSISSUE records.</summary>
        /// <param name="GI">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSISSUE_INSERT([FromBody]GOODSISSUE GI)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_INSERT", (GI.GINNO != null) ? GI.GINNO : "", GI.GINDATE, GI.CLIENT, GI.CLIENTADDRESS, GI.ISSUEDATE, (GI.LRNO != null) ? GI.LRNO : "", (GI.LRDATE != null) ? GI.LRDATE : "", (GI.DELAGENT != null) ? GI.DELAGENT : "", (GI.ACKNO != null) ? GI.ACKNO : "", GI.MAKERID, GI.MAKERIP, GI.CMPCODE, GI.CITYCODE, GI.CITYCODE1, GI.VGUID, (GI.REMARK != null) ? GI.REMARK : "", GI.ACTION);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_INSERT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update WMS GOODSISSUE records.</summary>
        /// <param name="GI">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSISSUE_UPDATE([FromBody]GOODSISSUE GI)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_UPDATE", (GI.GINNO != null) ? GI.GINNO : "", GI.GINDATE, GI.CLIENT, GI.CLIENTADDRESS, GI.ISSUEDATE, (GI.LRNO != null) ? GI.LRNO : "", (GI.LRDATE != null) ? GI.LRDATE : "", (GI.DELAGENT != null) ? GI.DELAGENT : "", (GI.ACKNO != null) ? GI.ACKNO : "", GI.MAKERID, GI.MAKERIP, GI.CMPCODE, GI.CITYCODE, GI.CITYCODE1, GI.VGUID, (GI.REMARK != null) ? GI.REMARK : "", GI.ACTION);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Delete WMS GOODSISSUE ITEMDTLS TMP records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <param name="GINDTLSID">GINDTLSID parameter.</param>
        /// <param name="EAN">EAN parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_ITEMDTLS_TMP_DEL(string ID, string VGUID, string GINDTLSID, string EAN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_DTLS_TMP_DEL", ID, VGUID, GINDTLSID, EAN);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_ITEMDTLS_TMP_DEL");
            }
            return Ok(ds);
        }
        //[HttpPost]
        //public IHttpActionResult IMP_WMS_GOODSISSUE_DTLS_TMP_IU([FromBody]GOODISSUEITEM GISSUEITEM)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_DTLS_TMP_IU", GISSUEITEM.ID, GISSUEITEM.GINNO, GISSUEITEM.FK_ITEMID, GISSUEITEM.ISSUEQTY, GISSUEITEM.UOM, GISSUEITEM.GINDTLSID, GISSUEITEM.EDFLAG, GISSUEITEM.VGUID, GISSUEITEM.MAKERID, GISSUEITEM.EAN, (GISSUEITEM.BOXNO != null) ? GISSUEITEM.BOXNO : "0");
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_DTLS_TMP_IU");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }
        //    return Ok(ds);
        //}
        /// <summary>Insert or update WMS GOODSISSUE DTLS TMP records.</summary>
        /// <param name="GISSUEITEM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult IMP_WMS_GOODSISSUE_DTLS_TMP_IU([FromBody]GOODISSUEITEM GISSUEITEM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                // ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_DTLS_TMP_IU", GISSUEITEM.ID, GISSUEITEM.GINNO, GISSUEITEM.FK_ITEMID, GISSUEITEM.ISSUEQTY, GISSUEITEM.UOM, GISSUEITEM.GINDTLSID, GISSUEITEM.EDFLAG, GISSUEITEM.VGUID, GISSUEITEM.MAKERID, GISSUEITEM.EAN, (GISSUEITEM.BOXNO != null) ? GISSUEITEM.BOXNO : "0");
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_BARCODEITEM_IU", GISSUEITEM.ID, GISSUEITEM.GINNO, GISSUEITEM.FK_ITEMID, GISSUEITEM.ISSUEQTY, GISSUEITEM.GINDTLSID, GISSUEITEM.EDFLAG, GISSUEITEM.VGUID, GISSUEITEM.MAKERID, GISSUEITEM.EAN, (GISSUEITEM.BOXNO != null) ? GISSUEITEM.BOXNO : "0");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_DTLS_TMP_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform WMS GOODSISSUE PAGE LOAD records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="CITYCODE1">Secondary city/branch code.</param>
        /// <param name="MODE">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMP_WMS_GOODSISSUE_PAGE_LOAD(string CMPCODE, string CITYCODE, string CITYCODE1, string MODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMP_WMS_GOODSISSUE_PAGELOAD", CMPCODE, CITYCODE, CITYCODE1, MODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/IMP_WMS_GOODSISSUE_PAGE_LOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform MSW ITEM MASTER POPULATES records.</summary>
        /// <param name="ItemId">Item Id parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MSW_ITEM_MASTER_POPULATES(String ItemId)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MSW_ITEM_MASTER_POPULATES", ItemId);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/MSW_ITEM_MASTER_POPULATES");
            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve Wms Item Master records.</summary>
        /// <param name="SEARCHTYPE">Search type/column identifier.</param>
        /// <param name="SEARCHVALUE">SEARCHVALUE parameter.</param>
        /// <param name="ITEMSUBGROUP">ITEMSUBGROUP parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Imp_Wms_Item_Master_SEARCH(string SEARCHTYPE, string SEARCHVALUE, string ITEMSUBGROUP)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEM_MASTER_SEARCH", (SEARCHTYPE != null) ? SEARCHTYPE : "", SEARCHVALUE, (ITEMSUBGROUP != null) ? ITEMSUBGROUP : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/Imp_Wms_Item_Master_SEARCH");
            }
            return Ok(ds);
        } //
        /// <summary>Load page reference data for WMS ITEMMASTER records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult WMS_ITEMMASTER_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEMMASTER_PAGELOAD");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/WMS_ITEMMASTER_PAGELOAD");
            }
            return Ok(ds);
        }
        public IHttpActionResult Imp_Wms_Item_Master_IU([FromBody] wmsitemmaster b)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_WMS_ITEM_MASTER_IU",
                   (b.ItemId != null) ? b.ItemId : "", (b.ItemCode != null) ? b.ItemCode : "", b.ItemName, b.LocalItemName, b.ItemGroupId, b.ItemSubgroup,
                    b.Size, (b.Dimension != null) ? b.Dimension : "", b.Netwt, b.Qty, b.Rate, b.TotalAmt, (b.IssueStatus != null) ? b.IssueStatus : "",
                    b.OpeningStock, b.currentstock, b.minimumstock, b.rejectedstock,
                    b.scrappedstock, b.ReserveStock, b.ReorderLevel, b.MinOrderQty, b.MinLeadTime,
                    b.MaxLeadTime, b.MakerID, b.MakerIP, b.CMP_CODE, b.CITYCODE, b.CityCode1, b.Ean);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Import/Imp_Wms_Item_Master_IU");
            }
            return Ok(ds);
        }

        /// <summary>Perform PRINT DOSSIER records.</summary>
        /// <param name="CONSOLENO">CONSOLENO parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage PRINT_DOSSIER([FromUri]string CONSOLENO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;



            strSpName = "USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW";
            strXslFilename = "xsl_Expo_Rpt_Print_Dossier.xsl";

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, CONSOLENO);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            strData = CommonFunction.ConvertToExcel_open("import", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Print Dossier.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
        /// <summary>Retrieve Fill Dropdown records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="iu_mode">Operation mode or filter type.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Dropdown([FromUri]string mode, string iu_mode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_FILL_DROPDOWN",
                    mode, iu_mode, citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Dropdown");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetLocalCurrency records.</summary>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetLocalCurrency([FromUri]string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_MST_IMPORT_LOCALCURRENCY",
                    citycode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/GetLocalCurrency");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetContainerType records.</summary>
        /// <param name="container_size">container size parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetContainerType([FromUri]string container_size)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_GETCONTTYPE",
                    container_size);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/GetContainerType");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform populate import records.</summary>
        /// <param name="importid">importid parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult populate_import([FromUri]string importid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_Populate",
                    importid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/populate_import");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve filltables records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult filltables([FromBody]System.Collections.Generic.List<FillTable> obj)
        {
            DataSet tempDs = new DataSet();
            DataSet finalDs = new DataSet();
            DAL objDal = new DAL();
            try
            {
                for (int i = 0; i < obj.Count; i++)
                {
                    tempDs = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP35_IMP_FILL_TABLE",
                        obj[i].ImportId, obj[i].TableNo);
                    tempDs.Tables[0].TableName = obj[i].TableName;
                    finalDs.Tables.Add(tempDs.Tables[obj[i].TableName].Copy());
                    tempDs.Reset();
                }

            }
            catch (Exception ex)
            {
                finalDs = ErrorLog.Error(ex, "Import/filltables");
            }
            finally
            {
                objDal.Dispose();
                tempDs.Dispose();
            }
            return Ok(finalDs);
        }

        /// <summary>Insert or update Import records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Import_Iu([FromBody]Import obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            DataSet dsChildTables = new DataSet();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                                    CommandType.StoredProcedure,
                                    "USP35_IMP_AddUpdate",
                                    obj.ImpMode, obj.imp_id, obj.fk_Imp_Code, obj.fk_Vsl_Air_name, obj.fk_Agt_name, obj.Mbl_Mabl_NO,
                                    obj.Mbl_Mabl_DT, obj.Bbl_Habl_NO, obj.Bbl_Habl_DT, obj.Dir_vessel, obj.fk_Trans_vsl_name, obj.fk_Trans_Port,
                                    obj.Bank_Ref_No, obj.Party_Ref_No, obj.GlDate, obj.LastFreeDate, obj.fk_ShipmentPort, obj.Desc_Good,
                                    obj.NumOfPkg1, obj.TypeOfPkg, obj.GrossWt, obj.NetWt, obj.BoeNo, obj.BoeDt, obj.BoeRemark, obj.InvoiceNo,
                                    obj.InvoiceDt, obj.fk_Incoterm, obj.InvoiceValue, obj.fk_cur_name, obj.InvExchRate, obj.InvTot, obj.FrightAmt,
                                    obj.fk_FrightCur, obj.FrightExchRate, obj.FrightTot, obj.InsAmt, obj.fk_InsCur, obj.InsExchRate, obj.InsTot,
                                    obj.ComAmt, obj.fk_ComCur, obj.ComExchRate, obj.ComTot, obj.CifAmt, obj.AccessValue, obj.AdvRec1, obj.AdvRec1Dt,
                                    obj.AdvRec2, obj.AdvRec2Dt, obj.AdvRec3, obj.AdvRec3Dt, obj.AdvRec4, obj.AdvRec4Dt, obj.ExamDate, obj.ExamRemark,
                                    obj.AssessDate, obj.AssessRemark, obj.CustomClerk, obj.DockClerk, obj.fk_BillTo, obj.fk_BillOfEntry, obj.MakerID,
                                    obj.MakerIP, obj.Citycode1, obj.CmpCode, obj.ArrivingDateAtICD, obj.Doc_Cancel, obj.Remark, obj.fk_ArilineId, obj.FightNo,
                                    obj.FightDate, obj.fk_ArilineId_Transhipment, obj.FightNo_Transhipment, obj.FightDate_Transhipment, obj.fk_ArrivalPort,
                                    obj.Exp_Arrival_Date, obj.Act_Arrival_Date, obj.BusinessAssociate, obj.Bill_EntryNO, obj.EXWORKS, obj.CUSTOM_CLR, obj.FREIGHT_FRD,
                                    (obj.VSL_NAME != null) ? obj.VSL_NAME : " ",(obj.VSL_VOYAGENO != null) ? obj.VSL_VOYAGENO : "  ",
                                    (obj.VSL_IGMNO != null) ? obj.VSL_IGMNO : "  ",  (obj.VSL_ARRIVALPORT != null) ? obj.VSL_ARRIVALPORT : " ",
                                    (obj.VSL_ARRIVALPORTPOD != null) ? obj.VSL_ARRIVALPORTPOD : " ",
                                    (obj.VSL_BERTHNO != null) ? obj.VSL_BERTHNO : "  ", (obj.PARTY_REFNO != null) ? obj.PARTY_REFNO : "  ",
                                    (obj.FINAL_DESTPORT != null) ? obj.FINAL_DESTPORT : "  ",  (obj.ARRV_DTFINALDEST != null) ? obj.ARRV_DTFINALDEST : "  ",
                                    (obj.ONLINE_SUB_DT != null) ? obj.ONLINE_SUB_DT : " ",  (obj.ONLINE_SUB_BY != null) ? obj.ONLINE_SUB_BY : "0",
                                    (obj.DUTY_AMT != null) ? obj.DUTY_AMT : "0",  (obj.STAMP_DUTY != null) ? obj.STAMP_DUTY : "0",
                                    (obj.DUTYPAIDBY != null) ? obj.DUTYPAIDBY : "  ",  (obj.DO_RECEIVED_ON != null) ? obj.DO_RECEIVED_ON : "  ",
                                    (obj.DELIVERY_VALIDATE_DT != null) ? obj.DELIVERY_VALIDATE_DT : " ", (obj.DELIVERYMODE != null) ? obj.DELIVERYMODE : "  ",
                                     (obj.IGMdt != null) ? obj.IGMdt : " "
                                    );



                DataTable dtDateOfRod = ToDataTable(obj.DateOfRod);
                dtDateOfRod.TableName = "dtDateOfRod";
                dsChildTables.Tables.Add(dtDateOfRod);

                if (obj.ImpMode == "Sea")
                {
                    DataTable dtGoods = ToDataTable(obj.Goods);
                    dtGoods.TableName = "dtGoods";
                    dsChildTables.Tables.Add(dtGoods);
                    dtGoods.Dispose();
                }

                DataTable dtBOE = ToDataTable(obj.Boe);
                dtBOE.TableName = "dtBOE";
                dsChildTables.Tables.Add(dtBOE);

                DataTable dtDuty = ToDataTable(obj.Duty);
                dtDuty.TableName = "dtDuty";
                dsChildTables.Tables.Add(dtDuty);

                DataTable dtSteAgent = ToDataTable(obj.SteAgent);
                dtSteAgent.TableName = "dtSteAgent";
                dsChildTables.Tables.Add(dtSteAgent);

                DataTable dtPort = ToDataTable(obj.Port);
                dtPort.TableName = "dtPort";
                dsChildTables.Tables.Add(dtPort);

                DataTable dtOctroi = ToDataTable(obj.Octroi);
                dtOctroi.TableName = "dtOctroi";
                dsChildTables.Tables.Add(dtOctroi);

                DataTable dtDelivery = ToDataTable(obj.Delivery);   
                dtDelivery.TableName = "dtDelivery";
                dsChildTables.Tables.Add(dtDelivery);

                DataTable dtInvoice = ToDataTable(obj.Invoice);
                dtInvoice.TableName = "dtInvoice";
                dsChildTables.Tables.Add(dtInvoice);

                DataTable dtDocCallForUs = ToDataTable(obj.DocCallForUs);
                dtDocCallForUs.TableName = "dtDocCallForUs";
                dsChildTables.Tables.Add(dtDocCallForUs);

                Child_Table_IU(Convert.ToString(ds.Tables[1].Rows[0]["pk_Id"]), Convert.ToString(ds.Tables[1].Rows[0]["Import_Code"]), Convert.ToString(ds.Tables[1].Rows[0]["fk_TrackId"]), obj.ImpMode, dsChildTables, obj.MakerID, obj.MakerIP);

                dtDateOfRod.Dispose();
                dtBOE.Dispose();
                dtDuty.Dispose();
                dtSteAgent.Dispose();
                dtPort.Dispose();
                dtOctroi.Dispose();
                dtDelivery.Dispose();
                dtInvoice.Dispose();
                dtDocCallForUs.Dispose();
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Import_Iu");
            }
            finally
            {
                objDal.Dispose();
                dsChildTables.Dispose();
            }
            return Ok(ds);
        }

        public void Child_Table_IU(string pkId, string Import_Code, string fk_TrackId, string MODE, DataSet dsChildTables, string MakerId, string MakerIp)
        {
            string SQL = string.Empty;
            string ChildSQL = string.Empty;
            DataTable tbl = new DataTable();
            DataSet dsMainTbl = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ChildSQL = "Declare @TblId int;";
                tbl = dsChildTables.Tables["dtDateOfRod"];
                SQL = "select  '100' STATUS, fk_ImpoterId,Import_Code, pk__DateOfROD_DtlsId, pk_tblIndex, DateOfRODdt, DateOfRODremark from Tbl_Imp_Mst_DateOfROD where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_DateOfROD", "pk__DateOfROD_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "01", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                if (MODE == "Sea")
                {
                    tbl = dsChildTables.Tables["dtGoods"];
                    SQL = "SELECT '100' STATUS, fk_ImpoterId,Import_Code, pk__Good_DtlsId, pk_tblIndex, ContainerNumber, ContainerSize, NoOfPackages, ContLength, ContType FROM Tbl_Imp_Mst_Good where fk_ImpoterId=" + pkId + "";
                    dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                    ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_Good", "pk__Good_DtlsId", Import_Code, MakerId, MakerIp);
                    ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "02", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);
                }

                tbl = dsChildTables.Tables["dtBOE"];
                SQL = "SELECT '100' STATUS, fk_ImpoterId,Import_Code,pk__BOE_DtlsId, pk_tblIndex, BOEno, BOEdt, BOEremark FROM Tbl_Imp_Mst_DocSub where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_DocSub", "pk__BOE_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "03", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtDuty"];
                SQL = "SELECT '100' STATUS, fk_ImpoterId, Import_Code, pk__Duty_DtlsId, pk_tblIndex, DutyPaid, DutyIns, DutyPaidOn, DutyCashNo, DutyRemark FROM Tbl_Imp_Mst_Duty where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_Duty", "pk__Duty_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "04", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtSteAgent"];
                SQL = "SELECT  '100' STATUS, fk_ImpoterId, Import_Code, pk__SteAgent_DtlsId, pk_tblIndex, SteType, SteRecNo, StePaydt, SteAmount, SteTypeValue, SteRemark FROM Tbl_Imp_Mst_SteAgent where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_SteAgent", "pk__SteAgent_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "05", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtPort"];
                SQL = "SELECT '100' STATUS, fk_ImpoterId, Import_Code, pk__Port_DtlsId, pk_tblIndex, PortRecNo, PortPaiddt, PortAmount, PortRemark FROM Tbl_Imp_Mst_PortCfs where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_PortCfs", "pk__Port_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "06", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtOctroi"];
                SQL = "SELECT '100' STATUS, fk_ImpoterId, Import_Code,  pk__Octroi_DtlsId, pk_tblIndex, OctRecNo, OctRecPaidDT, OctAmount, OctRemark FROM Tbl_Imp_Mst_Octroi where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_Octroi", "pk__Octroi_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "07", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtDelivery"];
                SQL = "SELECT '100' STATUS,  FK_IMPOTERID, Import_Code, PK__DEL_DTLSID, PK_TBLINDEX, OH_TRUCK, TRACKVALUE, TRUCKNO, TRUCKTYPE, RATEAGREED, DELDATE, DELREMARK, TRUCK FROM TBL_IMP_MST_DELIVERY where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "TBL_IMP_MST_DELIVERY", "PK__DEL_DTLSID", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "08", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtInvoice"];
                SQL = "SELECT '100' STATUS,  FK_IMPOTERID,Import_Code, pk_Inv_DtlsId, pk_tblIndex,Invoice_No,Invoice_Date FROM Tbl_Imp_Mst_Invoice where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "Tbl_Imp_Mst_Invoice", "pk_Inv_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "09", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                tbl = dsChildTables.Tables["dtDocCallForUs"];
                SQL = "SELECT '100' STATUS,  fk_ImpoterId,Import_Code, pk_DocCall_DtlsId, pk_tblIndex,DocName,ISNULL(ReceivedOn,'') ReceivedOn,ISNULL(AcknowledgedOn,'') AcknowledgedOn FROM DOCUMENT_CALL_FOR_US where fk_ImpoterId=" + pkId + "";
                dsMainTbl = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, SQL);
                ChildSQL = ChildSQL + Child_Table_Delete(dsMainTbl.Tables[0], tbl, fk_TrackId, "DOCUMENT_CALL_FOR_US", "pk_DocCall_DtlsId", Import_Code, MakerId, MakerIp);
                ChildSQL = ChildSQL + Child_Table_AddUpdate(tbl, dsMainTbl.Tables[0], "10", pkId, Import_Code, fk_TrackId, MakerId, MakerIp);

                objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.Text, ChildSQL);
            }
            finally
            {
            }
        }

        public string Child_Table_Delete(DataTable mTable, DataTable sTable, string fkTrackID, string TblName, string IdColumnName, string Import_Code, string MakerId, string MakerIp)
        {
            bool isExist = false;
            string Sql = string.Empty;
            for (Int32 iMainTbl = 0; iMainTbl <= mTable.Rows.Count - 1; iMainTbl++)
            {
                for (Int32 iTmpTbl = 0; iTmpTbl <= sTable.Rows.Count - 1; iTmpTbl++)
                {
                    if (Convert.ToString((Convert.ToString(sTable.Rows[iTmpTbl][IdColumnName]) == "") ? 0 : sTable.Rows[iTmpTbl][IdColumnName]) == Convert.ToString(mTable.Rows[iMainTbl][IdColumnName]))
                    {
                        isExist = true;
                        break;
                    }
                    else
                        isExist = false;
                }
                if (isExist == false)
                {
                    Sql = Sql + "Delete " + TblName + " WHERE " + IdColumnName + "=" + Convert.ToString(mTable.Rows[iMainTbl][IdColumnName]).Trim() + ";";
                    Sql = Sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                    Sql = Sql + "Values(" + fkTrackID + ",'" + MakerId + "', GETDATE(),'Delete','" + TblName + "','" + IdColumnName + "|Import_Code','" + Convert.ToString(mTable.Rows[iMainTbl][IdColumnName]) + "|" + Import_Code + "','','" + Convert.ToString(mTable.Rows[iMainTbl][IdColumnName]) + "','" + MakerIp + "','" + MakerIp + "');";
                }
            }
            return Sql;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public string Child_Table_AddUpdate(DataTable tbl, DataTable Mtbl, string tblNo, string fk_ImpoterId, string Import_Code, string fk_TrackId, string MakerId, string MakerIp)
        {
            string sql = string.Empty;
            string ColumnName = string.Empty;
            string OriginalData = string.Empty;
            string ModifiedData = string.Empty;
            string TblID = "0";
            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i <= tbl.Rows.Count - 1; i++)
                {
                    switch (tblNo)
                    {
                        case "01" // pk__DateOfROD_DtlsId
                       :
                            {
                                // Dim fk_ImpoterId As String 'Int
                                // Dim pk__DateOfROD_DtlsId As String 'int
                                string pk_tblIndex; // varchar
                                string DateOfRODdt; // varchar
                                string DateOfRODremark; // varchar
                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                DateOfRODdt = Convert.ToString(tbl.Rows[i]["DateOfRODdt"]);
                                DateOfRODremark = Convert.ToString(tbl.Rows[i]["DateOfRODremark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|DateOfRODdt|DateOfRODremark|pk_tblIndex|pk__DateOfROD_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + DateOfRODdt + "|" + DateOfRODremark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_DateOfROD(Import_Code,fk_ImpoterId,DateOfRODdt,DateOfRODremark,pk_tblIndex) ";
                                    sql = sql + "Values('" + Import_Code + "'," + Convert.ToString((fk_ImpoterId == null) ? "0" : fk_ImpoterId) + ",'" + DateOfRODdt + "','" + DateOfRODremark + "','" + Convert.ToString((pk_tblIndex == null) ? "0" : pk_tblIndex) + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_DateOfROD','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__DateOfROD_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (DateOfRODdt != withBlock["DateOfRODdt"])
                                                {
                                                    ColumnName = ColumnName + "DateOfRODdt|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DateOfRODdt"]) + "|";
                                                    ModifiedData = ModifiedData + DateOfRODdt + "|";
                                                }
                                                if (DateOfRODremark != withBlock["DateOfRODremark"])
                                                {
                                                    ColumnName = ColumnName + "DateOfRODremark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DateOfRODremark"]) + "|";
                                                    ModifiedData = ModifiedData + DateOfRODremark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_DateOfROD Set DateOfRODdt='" + DateOfRODdt + "',DateOfRODremark='" + DateOfRODremark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__DateOfROD_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__DateOfROD_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_DateOfROD','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "02" // pk__Good_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string ContainerNumber; // varchar
                                string ContainerSize; // varchar
                                string NoOfPackages;
                                string ContLength;
                                string ContType;
                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                ContainerNumber = Convert.ToString(tbl.Rows[i]["ContainerNumber"]);
                                ContainerSize = Convert.ToString(tbl.Rows[i]["ContainerSize"]);
                                NoOfPackages = Convert.ToString(tbl.Rows[i]["NoOfPackages"]);
                                ContLength = Convert.ToString(tbl.Rows[i]["ContLength"]);
                                ContType = Convert.ToString(tbl.Rows[i]["ContType"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|ContainerNumber|ContainerSize|NoOfPackages|ContLength|ContType|pk_tblIndex|pk__Good_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + ContainerNumber + "|" + ContainerSize + "|" + NoOfPackages + "|" + ContLength + "|" + ContType + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_Good(Import_Code,fk_ImpoterId,pk_tblIndex,ContainerNumber,ContainerSize,NoOfPackages,ContLength,ContType) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + ContainerNumber + "','" + ContainerSize + "','" + NoOfPackages + "','" + ContLength + "','" + ContType + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_Good','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__Good_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (ContainerNumber != withBlock["ContainerNumber"])
                                                {
                                                    ColumnName = ColumnName + "ContainerNumber|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["ContainerNumber"]) + "|";
                                                    ModifiedData = ModifiedData + ContainerNumber + "|";
                                                }
                                                if (ContainerSize != withBlock["ContainerSize"])
                                                {
                                                    ColumnName = ColumnName + "ContainerSize|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["ContainerSize"]) + "|";
                                                    ModifiedData = ModifiedData + ContainerSize + "|";
                                                }
                                                if (NoOfPackages != withBlock["NoOfPackages"])
                                                {
                                                    ColumnName = ColumnName + "NoOfPackages|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["NoOfPackages"]) + "|";
                                                    ModifiedData = ModifiedData + NoOfPackages + "|";
                                                }
                                                if (ContLength != withBlock["ContLength"])
                                                {
                                                    ColumnName = ColumnName + "ContLength|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["ContLength"]) + "|";
                                                    ModifiedData = ModifiedData + ContLength + "|";
                                                }
                                                if (ContType != withBlock["ContType"])
                                                {
                                                    ColumnName = ColumnName + "ContType|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["ContType"]) + "|";
                                                    ModifiedData = ModifiedData + ContType + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_Good Set ContainerNumber='" + ContainerNumber + "',ContainerSize='" + ContainerSize + "',NoOfPackages='" + NoOfPackages + "',ContLength='" + ContLength + "',ContType='" + ContType + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__Good_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__Good_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_Good','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "03" // pk__BOE_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string BOEno; // varchar
                                string BOEdt; // varchar
                                string BOEremark;

                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                BOEno = Convert.ToString(tbl.Rows[i]["BOEno"]);
                                BOEdt = Convert.ToString(tbl.Rows[i]["BOEdt"]);
                                BOEremark = Convert.ToString(tbl.Rows[i]["BOEremark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|BOEno|BOEdt|BOEremark|pk_tblIndex|pk__BOE_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + BOEno + "|" + BOEdt + "|" + BOEremark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_DocSub(Import_Code,fk_ImpoterId,pk_tblIndex,BOEno,BOEdt,BOEremark) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + BOEno + "','" + BOEdt + "','" + BOEremark + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_DocSub','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__BOE_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (BOEno != withBlock["BOEno"])
                                                {
                                                    ColumnName = ColumnName + "BOEno|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["BOEno"]) + "|";
                                                    ModifiedData = ModifiedData + BOEno + "|";
                                                }
                                                if (BOEdt != withBlock["BOEdt"])
                                                {
                                                    ColumnName = ColumnName + "BOEdt|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["BOEdt"]) + "|";
                                                    ModifiedData = ModifiedData + BOEdt + "|";
                                                }
                                                if (BOEremark != withBlock["BOEremark"])
                                                {
                                                    ColumnName = ColumnName + "BOEremark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["BOEremark"]) + "|";
                                                    ModifiedData = ModifiedData + BOEremark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_DocSub Set BOEno='" + BOEno + "',BOEdt='" + BOEdt + "',BOEremark='" + BOEremark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__BOE_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__BOE_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_DocSub','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "04" // pk__Duty_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string DutyPaid; // varchar
                                string DutyIns;
                                string DutyPaidOn;
                                string DutyCashNo;
                                string DutyRemark;
                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                DutyPaid = Convert.ToString(tbl.Rows[i]["DutyPaid"]);
                                DutyIns = Convert.ToString(tbl.Rows[i]["DutyIns"]);
                                DutyPaidOn = Convert.ToString(tbl.Rows[i]["DutyPaidOn"]);
                                DutyCashNo = Convert.ToString(tbl.Rows[i]["DutyCashNo"]);
                                DutyRemark = Convert.ToString(tbl.Rows[i]["DutyRemark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|DutyPaid|DutyIns|DutyPaidOn|DutyCashNo|DutyRemark|pk_tblIndex|pk__Duty_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + DutyPaid + "|" + DutyIns + "|" + DutyPaidOn + "|" + DutyCashNo + "|" + DutyRemark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_Duty(Import_Code,fk_ImpoterId,pk_tblIndex,DutyPaid,DutyIns,DutyPaidOn,DutyCashNo,DutyRemark) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + DutyPaid + "','" + DutyIns + "','" + DutyPaidOn + "','" + DutyCashNo + "','" + DutyRemark + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_Duty','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__Duty_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (DutyPaid != withBlock["DutyPaid"])
                                                {
                                                    ColumnName = ColumnName + "DutyPaid|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DutyPaid"]) + "|";
                                                    ModifiedData = ModifiedData + DutyPaid + "|";
                                                }
                                                if (DutyIns != withBlock["DutyIns"])
                                                {
                                                    ColumnName = ColumnName + "DutyIns|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DutyIns"]) + "|";
                                                    ModifiedData = ModifiedData + DutyIns + "|";
                                                }
                                                if (DutyPaidOn != withBlock["DutyPaidOn"])
                                                {
                                                    ColumnName = ColumnName + "DutyPaidOn|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DutyPaidOn"]) + "|";
                                                    ModifiedData = ModifiedData + DutyPaidOn + "|";
                                                }
                                                if (DutyCashNo != withBlock["DutyCashNo"])
                                                {
                                                    ColumnName = ColumnName + "DutyCashNo|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DutyCashNo"]) + "|";
                                                    ModifiedData = ModifiedData + DutyCashNo + "|";
                                                }
                                                if (DutyRemark != withBlock["DutyRemark"])
                                                {
                                                    ColumnName = ColumnName + "DutyRemark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DutyRemark"]) + "|";
                                                    ModifiedData = ModifiedData + DutyRemark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_Duty Set DutyPaid='" + DutyPaid + "',DutyIns='" + DutyIns + "',DutyPaidOn='" + DutyPaidOn + "',DutyCashNo='" + DutyCashNo + "',DutyRemark='" + DutyRemark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__Duty_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__Duty_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_Duty','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "05" // pk__SteAgent_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string SteType; // varchar
                                string SteRecNo;
                                string StePaydt;
                                string SteAmount;
                                string SteTypeValue;
                                string SteRemark;

                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                SteType = Convert.ToString(tbl.Rows[i]["SteType"]);
                                SteRecNo = Convert.ToString(tbl.Rows[i]["SteRecNo"]);
                                StePaydt = Convert.ToString(tbl.Rows[i]["StePaydt"]);
                                SteAmount = Convert.ToString(tbl.Rows[i]["SteAmount"]);
                                SteTypeValue = Convert.ToString(tbl.Rows[i]["SteTypeValue"]);
                                SteRemark = Convert.ToString(tbl.Rows[i]["SteRemark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|SteType|SteRecNo|StePaydt|SteAmount|SteTypeValue|SteRemark|pk_tblIndex|pk__SteAgent_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + SteType + "|" + SteRecNo + "|" + StePaydt + "|" + SteAmount + "|" + SteTypeValue + "|" + SteRemark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_SteAgent(Import_Code,fk_ImpoterId,pk_tblIndex,SteType,SteRecNo,StePaydt,SteAmount,SteTypeValue,SteRemark) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + SteType + "','" + SteRecNo + "','" + StePaydt + "','" + SteAmount + "','" + SteTypeValue + "','" + SteRemark + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_SteAgent','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__SteAgent_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (SteType != withBlock["SteType"])
                                                {
                                                    ColumnName = ColumnName + "SteType|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["SteType"]) + "|";
                                                    ModifiedData = ModifiedData + SteType + "|";
                                                }
                                                if (SteRecNo != withBlock["SteRecNo"])
                                                {
                                                    ColumnName = ColumnName + "SteRecNo|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["SteRecNo"]) + "|";
                                                    ModifiedData = ModifiedData + SteRecNo + "|";
                                                }
                                                if (StePaydt != withBlock["StePaydt"])
                                                {
                                                    ColumnName = ColumnName + "StePaydt|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["StePaydt"]) + "|";
                                                    ModifiedData = ModifiedData + StePaydt + "|";
                                                }
                                                if (SteAmount != withBlock["SteAmount"])
                                                {
                                                    ColumnName = ColumnName + "SteAmount|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["SteAmount"]) + "|";
                                                    ModifiedData = ModifiedData + SteAmount + "|";
                                                }
                                                if (SteTypeValue != withBlock["SteTypeValue"])
                                                {
                                                    ColumnName = ColumnName + "SteTypeValue|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["SteTypeValue"]) + "|";
                                                    ModifiedData = ModifiedData + SteTypeValue + "|";
                                                }
                                                if (SteRemark != withBlock["SteRemark"])
                                                {
                                                    ColumnName = ColumnName + "SteRemark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["SteRemark"]) + "|";
                                                    ModifiedData = ModifiedData + SteRemark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_SteAgent Set SteType='" + SteType + "',SteRecNo='" + SteRecNo + "',StePaydt='" + StePaydt + "',SteAmount='" + SteAmount + "',SteTypeValue='" + SteTypeValue + "',SteRemark='" + SteRemark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__SteAgent_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__SteAgent_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_SteAgent','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "06" // pk__Port_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string PortRecNo; // varchar
                                string PortPaiddt;
                                string PortAmount;
                                string PortRemark;


                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                PortRecNo = Convert.ToString(tbl.Rows[i]["PortRecNo"]);
                                PortPaiddt = Convert.ToString(tbl.Rows[i]["PortPaiddt"]);
                                PortAmount = Convert.ToString(tbl.Rows[i]["PortAmount"]);
                                PortRemark = Convert.ToString(tbl.Rows[i]["PortRemark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|PortRecNo|PortPaiddt|PortAmount|PortRemark|pk_tblIndex|pk__Port_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + PortRecNo + "|" + PortPaiddt + "|" + PortAmount + "|" + PortRemark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_PortCfs(Import_Code,fk_ImpoterId,pk_tblIndex,PortRecNo,PortPaiddt,PortAmount,PortRemark) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + PortRecNo + "','" + PortPaiddt + "','" + PortAmount + "','" + PortRemark + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_PortCfs','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__Port_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (PortRecNo != withBlock["PortRecNo"])
                                                {
                                                    ColumnName = ColumnName + "PortRecNo|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["PortRecNo"]) + "|";
                                                    ModifiedData = ModifiedData + PortRecNo + "|";
                                                }
                                                if (PortPaiddt != withBlock["PortPaiddt"])
                                                {
                                                    ColumnName = ColumnName + "PortPaiddt|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["PortPaiddt"]) + "|";
                                                    ModifiedData = ModifiedData + PortPaiddt + "|";
                                                }
                                                if (PortAmount != withBlock["PortAmount"])
                                                {
                                                    ColumnName = ColumnName + "PortAmount|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["PortAmount"]) + "|";
                                                    ModifiedData = ModifiedData + PortAmount + "|";
                                                }
                                                if (PortRemark != withBlock["PortRemark"])
                                                {
                                                    ColumnName = ColumnName + "PortRemark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["PortRemark"]) + "|";
                                                    ModifiedData = ModifiedData + PortRemark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_PortCfs Set PortRecNo='" + PortRecNo + "',PortPaiddt='" + PortPaiddt + "',PortAmount='" + PortAmount + "',PortRemark='" + PortRemark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__Port_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__Port_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_PortCfs','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "07" // pk__Octroi_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string OctRecNo; // varchar
                                string OctRecPaidDT;
                                string OctAmount;
                                string OctRemark;


                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                OctRecNo = Convert.ToString(tbl.Rows[i]["OctRecNo"]);
                                OctRecPaidDT = Convert.ToString(tbl.Rows[i]["OctRecPaidDT"]);
                                OctAmount = Convert.ToString(tbl.Rows[i]["OctAmount"]);
                                OctRemark = Convert.ToString(tbl.Rows[i]["OctRemark"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|OctRecNo|OctRecPaidDT|OctAmount|OctRemark|pk_tblIndex|pk__Octroi_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + OctRecNo + "|" + OctRecPaidDT + "|" + OctAmount + "|" + OctRemark + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_Octroi(Import_Code,fk_ImpoterId,pk_tblIndex,OctRecNo,OctRecPaidDT,OctAmount,OctRemark) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + OctRecNo + "','" + OctRecPaidDT + "','" + OctAmount + "','" + OctRemark + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_Octroi','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__Octroi_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (OctRecNo != withBlock["OctRecNo"])
                                                {
                                                    ColumnName = ColumnName + "OctRecNo|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["OctRecNo"]) + "|";
                                                    ModifiedData = ModifiedData + OctRecNo + "|";
                                                }
                                                if (OctRecPaidDT != withBlock["OctRecPaidDT"])
                                                {
                                                    ColumnName = ColumnName + "OctRecPaidDT|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["OctRecPaidDT"]) + "|";
                                                    ModifiedData = ModifiedData + OctRecPaidDT + "|";
                                                }
                                                if (OctAmount != withBlock["OctAmount"])
                                                {
                                                    ColumnName = ColumnName + "OctAmount|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["OctAmount"]) + "|";
                                                    ModifiedData = ModifiedData + OctAmount + "|";
                                                }
                                                if (OctRemark != withBlock["OctRemark"])
                                                {
                                                    ColumnName = ColumnName + "OctRemark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["OctRemark"]) + "|";
                                                    ModifiedData = ModifiedData + OctRemark + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_Octroi Set OctRecNo='" + OctRecNo + "',OctRecPaidDT='" + OctRecPaidDT + "',OctAmount='" + OctAmount + "',OctRemark='" + OctRemark + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__Octroi_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__Octroi_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_Octroi','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "08" // pk__Del_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string OH_truck; // varchar
                                string trackValue;
                                string TruckNo;
                                string TruckType;
                                string RateAgreed; // varchar
                                string DelDate;
                                string DelRemark;
                                string truck;


                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                OH_truck = Convert.ToString(tbl.Rows[i]["OH_truck"]);
                                trackValue = Convert.ToString(tbl.Rows[i]["trackValue"]);
                                TruckNo = Convert.ToString(tbl.Rows[i]["TruckNo"]);
                                TruckType = Convert.ToString(tbl.Rows[i]["TruckType"]);
                                RateAgreed = Convert.ToString(tbl.Rows[i]["RateAgreed"]);
                                DelDate = Convert.ToString(tbl.Rows[i]["DelDate"]);
                                DelRemark = Convert.ToString(tbl.Rows[i]["DelRemark"]);
                                truck = Convert.ToString(tbl.Rows[i]["truck"]);
                                if (Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|OH_truck|trackValue|TruckNo|TruckType|RateAgreed|DelDate|DelRemark|truck|pk_tblIndex|pk__Del_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + OH_truck + "|" + trackValue + "|" + TruckNo + "|" + TruckType + "|" + RateAgreed + "|" + DelDate + "|" + DelRemark + "|" + truck + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into TBL_IMP_MST_DELIVERY(Import_Code,fk_ImpoterId,pk_tblIndex,OH_truck,trackValue,TruckNo,TruckType,RateAgreed,DelDate,DelRemark,truck) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + OH_truck + "','" + trackValue + "','" + TruckNo + "','" + TruckType + "','" + RateAgreed + "','" + DelDate + "','" + DelRemark + "','" + truck + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','TBL_IMP_MST_DELIVERY','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk__Del_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (OH_truck != withBlock["OH_truck"])
                                                {
                                                    ColumnName = ColumnName + "OH_truck|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["OH_truck"]) + "|";
                                                    ModifiedData = ModifiedData + OH_truck + "|";
                                                }
                                                if (trackValue != withBlock["trackValue"])
                                                {
                                                    ColumnName = ColumnName + "trackValue|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["trackValue"]) + "|";
                                                    ModifiedData = ModifiedData + trackValue + "|";
                                                }
                                                if (TruckNo != withBlock["TruckNo"])
                                                {
                                                    ColumnName = ColumnName + "TruckNo|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["TruckNo"]) + "|";
                                                    ModifiedData = ModifiedData + TruckNo + "|";
                                                }
                                                if (TruckType != withBlock["TruckType"])
                                                {
                                                    ColumnName = ColumnName + "TruckType|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["TruckType"]) + "|";
                                                    ModifiedData = ModifiedData + TruckType + "|";
                                                }
                                                if (RateAgreed != withBlock["RateAgreed"])
                                                {
                                                    ColumnName = ColumnName + "RateAgreed|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["RateAgreed"]) + "|";
                                                    ModifiedData = ModifiedData + RateAgreed + "|";
                                                }
                                                if (DelDate != withBlock["DelDate"])
                                                {
                                                    ColumnName = ColumnName + "DelDate|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DelDate"]) + "|";
                                                    ModifiedData = ModifiedData + DelDate + "|";
                                                }
                                                if (DelRemark != withBlock["DelRemark"])
                                                {
                                                    ColumnName = ColumnName + "DelRemark|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DelRemark"]) + "|";
                                                    ModifiedData = ModifiedData + DelRemark + "|";
                                                }
                                                if (truck != withBlock["truck"])
                                                {
                                                    ColumnName = ColumnName + "truck|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["truck"]) + "|";
                                                    ModifiedData = ModifiedData + truck + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update TBL_IMP_MST_DELIVERY Set OH_truck='" + OH_truck + "',trackValue='" + trackValue + "',TruckNo='" + TruckNo + "',TruckType='" + TruckType + "',RateAgreed='" + RateAgreed + "',DelDate='" + DelDate + "',DelRemark='" + DelRemark + "',truck='" + truck + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk__Del_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk__Del_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','TBL_IMP_MST_DELIVERY','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "09" // pk_Inv_DtlsId
                 :
                            {
                                string pk_tblIndex; // varchar
                                string Invoice_No; // varchar
                                string Invoice_Date;


                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                Invoice_No = Convert.ToString(tbl.Rows[i]["Invoice_No"]);
                                Invoice_Date = Convert.ToString(tbl.Rows[i]["Invoice_Date"]);

                                if (Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|Invoice_No|Invoice_Date|pk_tblIndex|pk_Inv_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + Invoice_No + "|" + Invoice_Date + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into Tbl_Imp_Mst_Invoice(Import_Code,fk_ImpoterId,pk_tblIndex,Invoice_No,Invoice_Date) ";
                                    sql = sql + "Values('" + Import_Code + "'," + fk_ImpoterId + ",'" + pk_tblIndex + "','" + Invoice_No + "','" + Invoice_Date + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','Tbl_Imp_Mst_Invoice','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk_Inv_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (Invoice_No != Convert.ToString(withBlock["Invoice_No"]))
                                                {
                                                    ColumnName = ColumnName + "Invoice_No|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["Invoice_No"]) + "|";
                                                    ModifiedData = ModifiedData + Invoice_No + "|";
                                                }
                                                if (Invoice_Date != Convert.ToString(withBlock["Invoice_Date"]))
                                                {
                                                    ColumnName = ColumnName + "Invoice_Date|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["Invoice_Date"]) + "|";
                                                    ModifiedData = ModifiedData + Invoice_Date + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update Tbl_Imp_Mst_Invoice Set Invoice_No='" + Invoice_No + "',Invoice_Date='" + Invoice_Date + "',pk_tblIndex='" + pk_tblIndex.ToString() + "' Where pk_Inv_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk_Inv_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','Tbl_Imp_Mst_Invoice','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }

                        case "10" // pk__DateOfROD_DtlsId
                 :
                            {
                                // Dim fk_ImpoterId As String 'Int
                                // Dim pk__DateOfROD_DtlsId As String 'int
                                string pk_tblIndex; // varchar
                                string DocName = string.Empty; // varchar
                                string ReceivedOn = string.Empty; // varchar
                                pk_tblIndex = Convert.ToString(tbl.Rows[i]["pk_tblIndex"]);
                                DocName = Convert.ToString(tbl.Rows[i]["DocName"]);
                                ReceivedOn = Convert.ToString(tbl.Rows[i]["ReceivedOn"]);
                                if (Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]) == null || Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]) == "")
                                {
                                    ColumnName = "Import_Code|fk_ImpoterId|DocName|ReceivedOn|pk_tblIndex|pk_DocCall_DtlsId";
                                    OriginalData = Import_Code + "|" + fk_ImpoterId + "|" + DocName + "|" + ReceivedOn + "|" + pk_tblIndex + "|";
                                    sql = sql + "Insert Into DOCUMENT_CALL_FOR_US(Import_Code,fk_ImpoterId,DocName,ReceivedOn,pk_tblIndex) ";
                                    sql = sql + "Values('" + Import_Code + "'," + Convert.ToString((fk_ImpoterId == null) ? "0" : fk_ImpoterId) + ",'" + Convert.ToString(DocName) + "','" + Convert.ToString(ReceivedOn) + "','" + Convert.ToString(pk_tblIndex) + "');";

                                    sql = sql + "set @TblId = ISNULL(@@identity," + fk_ImpoterId.ToString() + ");";

                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Add','DOCUMENT_CALL_FOR_US','" + ColumnName + "','" + OriginalData + "'+Convert(varchar,@TblId),'',convert(varchar,@TblId),'" + MakerIp + "','" + MakerIp + "');";
                                }
                                else
                                {
                                    for (int iMainTbl = 0; iMainTbl <= Mtbl.Rows.Count - 1; iMainTbl++)
                                    {
                                        if (Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]).Trim() == Convert.ToString(Mtbl.Rows[iMainTbl]["pk_DocCall_DtlsId"]).Trim())
                                        {
                                            {
                                                var withBlock = Mtbl.Rows[iMainTbl];
                                                ColumnName = "Import_Code|";
                                                OriginalData = Import_Code + "|";
                                                ModifiedData = Import_Code + "|";
                                                if (DocName != withBlock["DocName"])
                                                {
                                                    ColumnName = ColumnName + "DocName|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["DocName"]) + "|";
                                                    ModifiedData = ModifiedData + DocName + "|";
                                                }
                                                if (ReceivedOn != withBlock["ReceivedOn"])
                                                {
                                                    ColumnName = ColumnName + "ReceivedOn|";
                                                    OriginalData = OriginalData + Convert.ToString(withBlock["ReceivedOn"]) + "|";
                                                    ModifiedData = ModifiedData + ReceivedOn + "|";
                                                }
                                                ColumnName = ColumnName + "ID";
                                                OriginalData = OriginalData + Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]);
                                                ModifiedData = ModifiedData + Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]);
                                                TblID = Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]);
                                            }
                                            break;
                                        }
                                    }
                                    sql = sql + "Update DOCUMENT_CALL_FOR_US Set DocName='" + DocName + "',ReceivedOn='" + ReceivedOn + "',pk_tblIndex='" + Convert.ToString(pk_tblIndex) + "' Where pk_DocCall_DtlsId=" + Convert.ToString(tbl.Rows[i]["pk_DocCall_DtlsId"]) + ";";
                                    sql = sql + "Insert Into TBL_USERTRACK_IMPORT_DETAILS (fkTrackId,UserID,[Datetime] ,Mode ,TableName ,ColumnName ,OriginalData ,ModifiedData ,RecordId ,LocalIPAdd ,RouterIPAdd) ";
                                    sql = sql + "Values(" + fk_TrackId + ",'" + MakerId + "',getdate(),'Edit','DOCUMENT_CALL_FOR_US','" + ColumnName + "','" + OriginalData + "','" + ModifiedData + "','" + TblID + "','" + MakerIp + "','" + MakerIp + "');";
                                }

                                break;
                            }
                    }
                }
            }
            return sql;
        }

        /// <summary>Search and retrieve Fill Dropdown Report records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Dropdown_Report_Search([FromUri]string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_IMPORT_RPT_Search_Fill_Dropdown",
                    citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Dropdown_Report_Search");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve Report records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Report_Search([FromBody]ImportSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_IMPORT_RPT_Search",
                    obj.Mode, obj.ImportCode, obj.ImportFromDate, obj.ImportToDate, obj.Importer, obj.ImporterType, obj.BillTo,
                    obj.BillToType, obj.Vessel, obj.VesselType, obj.Agent, obj.AgentType, obj.GlFromDate, obj.GlToDate, obj.SearchType,
                    obj.CityCode1, obj.CmpCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Report_Search");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform SeaAirDocketPrint records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="importcode">importcode parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult SeaAirDocketPrint([FromUri]string mode, string importcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_DOCKET_PRINT_SEA_AND_AIR",
                    mode, importcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/SeaAirDocketPrint");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetArrivalPort records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetArrivalPort()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_VESSEL_FILLPORT");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/GetArrivalPort");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform VesselDetails records.</summary>
        /// <param name="vessel_id">vessel id parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult VesselDetails([FromUri] string vessel_id)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_VESSEL_FILLDET", vessel_id);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/VesselDetails");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Vessel records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Vessel_IU([FromBody]Vessel obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_VESSEL_IU",
                    obj.Id, obj.Name, obj.VoyageNo, obj.IGMNo, obj.ExpectedArrivalDate,
                    obj.ActualArrivalDate, obj.BerthNo, obj.ArrivalPort,
                    obj.MakerIp, obj.MakerId, obj.CityCode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Vessel_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve Vessel records.</summary>
        /// <param name="search">search parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Imp_Vessel_Search([FromUri]string search)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_VESSEL_SEARCH",
                    (search != null) ? search : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Vessel_Search");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform CurrencyAndCity records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CurrencyAndCity()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_CURRENCY_FILLCURRNCITY");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/CurrencyAndCity");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform CurrencyDetails records.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult CurrencyDetails([FromUri] string id)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_CURRENCY_POPULATE", id);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/CurrencyDetails");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Currency records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Currency_IU([FromBody]Currency obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_CURRENCY_IU",
                    obj.Id, obj.CurrencyType, obj.Cities, obj.FromDate, obj.ToDate,
                    obj.ExchangeRate, obj.MakerIp, obj.MakerId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Currency_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve Currency records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Currency_Search([FromBody]Currency obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_CURRENCY_SEARCH",
                    obj.CurrencyType, obj.Cities, obj.FromDate, obj.ToDate, obj.ExchangeRate);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Currency_Search");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AirlineDetails records.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult AirlineDetails([FromUri] string id)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_AIRLINE_POPULATE", id);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/AirlineDetails");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Airline records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Airline_IU([FromBody]Airline obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_AIRLINE_IU",
                    obj.Id, obj.AirlineCode, obj.AirlineName, obj.MakerId, obj.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Airline_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve Airline records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Airline_Search([FromBody]Airline obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_IMP_AIRLINE_SEARCH",
                    obj.SearchText);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Airline_Search");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetClient records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetClient([FromUri] string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_MST_IMPORT_MISC_JOB_FILL_CLIENT", citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/GetClient");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform MiscellaneousDetails records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MiscellaneousDetails([FromUri]Miscellaneous obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_MISC_JOB_POPULATE", obj.JobNo, obj.CmpCode, obj.CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/MiscellaneousDetails");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Miscellaneous records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Imp_Miscellaneous_IU([FromBody]Miscellaneous obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMP_MST_IMPORT_MISC_JOB_IU",
                    obj.Id, obj.JobNo, obj.ClientName, obj.NoOfPkgs, obj.Narration,
                    obj.MakerId, obj.MakerIp, obj.CmpCode, obj.CityCode, obj.CityCode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Imp_Miscellaneous_IU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

    }       
}

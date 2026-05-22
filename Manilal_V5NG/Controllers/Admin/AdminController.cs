using System;
using System.Collections.Generic;
using System.Linq;
using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using Manilal_V5NG.Controllers.CommonBLL;
 
using System.Data;
 
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

namespace Manilal_V5NG.Controllers.Admin
{
    public class AdminController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ADMIN_QUOTATION_CLIENT_IU([FromBody] Quotation_Client QC)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_CLIENT_INSERT",
                QC.PK_CLIENTID, (QC.CLIENT_NAME != null) ? QC.CLIENT_NAME : "", (QC.CLIENT_ADD1 != null) ? QC.CLIENT_ADD1 : "", (QC.CLIENT_ADD2 != null) ? QC.CLIENT_ADD2 : "", (QC.CLIENT_CITY != null) ? QC.CLIENT_CITY : "", (QC.CLIENT_COUNTRY != null) ? QC.CLIENT_COUNTRY : "", QC.CMPCODE, QC.CITYCODE, QC.MAKERID,
                QC.MAKERIP);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_CLIENT_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public HttpResponseMessage ADMIN_SALESENQUIRY_LIST_XL(string SEARCHVAL, string SEARCHTXT, string STARTDT, string ENDDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;


            strXslFilename = "xsl_Admin_enquirylist.xsl";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_SEARCH_LIST", (SEARCHVAL != null) ? SEARCHVAL : "", (SEARCHTXT != null) ? SEARCHTXT : "", (STARTDT != null) ? STARTDT : "", (ENDDT != null) ? ENDDT : "");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Admin", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "enquirylist_asondate_" + ENDDT + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }

        [HttpGet]
        public IHttpActionResult ADMIN_SALESENQUIRY_SEARCHLIST(string SEARCHVAL, string SEARCHTXT, string STARTDT, string ENDDT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_SEARCH_LIST", (SEARCHVAL != null) ? SEARCHVAL : "", (SEARCHTXT != null) ? SEARCHTXT : "", (STARTDT != null) ? STARTDT : "", (ENDDT != null) ? ENDDT : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_SALESENQUIRY_SEARCHLIST");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_SALESENQUIRY_POPULATE(string EnqNo, string Makerid, string VGuid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_POPULATE", EnqNo, Makerid, VGuid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_SALESENQUIRY_POPULATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult Admin_SalesEnquiry_IU([FromBody] SalesEnquiry se)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_IU", (se.PK_ID != null) ? se.PK_ID : "0", (se.ENQREFNO != null) ? se.ENQREFNO : "", se.ENQRECPTDT, (se.ENQTYPE != null) ? se.ENQTYPE : "",   se.EXIM, (se.INCOTERM != null) ? se.INCOTERM : "", se.NETWORK, se.COUNTRY_CODE, se.AGENT_NAME, (se.SALESPERSON != null) ? se.SALESPERSON : "", (se.BRANCH != null) ? se.BRANCH : "", (se.MODE != null) ? se.MODE : "",  (se.DIMENSION != null) ? se.DIMENSION : "", (se.POL != null) ? se.POL : "", (se.POD != null) ? se.POD : "", (se.EMAIL != null) ? se.EMAIL : "", (se.REMARK != null) ? se.REMARK : "",  (se.SHIPPER != null) ? se.SHIPPER : "", (se.CONSIGNEE != null) ? se.CONSIGNEE : "", (se.STATUS != null) ? se.STATUS : "",  (se.CMPCODE != null) ? se.CMPCODE : "", (se.CITYCODE != null) ? se.CITYCODE : "", (se.CITYCODE1 != null) ? se.CITYCODE1 : "", (se.MAKERID != null) ? se.MAKERID : "", (se.MAKERIP != null) ? se.MAKERIP : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Admin_SalesEnquiry_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_SALESENQUIRY_PAGELOAD(string CMPCODE, string CITYCODE, string CITYCODE1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_PAGELOAD", CMPCODE, CITYCODE, CITYCODE1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_SALESENQUIRY_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult GetAdmingSalesEnquiryPageload([FromBody] SalesEnquiry se)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_SALESENQUIRY_PAGELOAD", se.CMPCODE, se.CITYCODE, se.CITYCODE1); //USP_ASP_EXP_NEW_EXPORT_CONSIGNMENT_PAGELOAD
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/GetAdmingSalesEnquiryPageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_QUOTATION_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_RESET");
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult ADMIN_QUOTATION_TMP_DEL(string ID, string VGUID, string QUOTDTLID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_TMP_DEL", ID, VGUID, QUOTDTLID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_TMP_DEL");
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_QUOTATION_PAGELOAD(string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_PAGELOAD", CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_QUOTATION_SEARCHLIST(string SearchVal, string SearchText, string efftfrdt, string effttodt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_SEARCH_LIST", (SearchVal != null) ? SearchVal : "", (SearchText != null) ? SearchText : "", (efftfrdt != null) ? efftfrdt : "", (effttodt != null) ? effttodt : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_SEARCHLIST");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_QUOTATION_POPULATE(string pkid, string Makerid, string VGuid, string QuotNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_POPULATE", pkid, Makerid, VGuid, QuotNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_POPULATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult ADMIN_QUOTATION_CHILD_IU([FromBody] Quotation_Details QD)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_TMP_IU", QD.PKID, QD.FK_QUOTID, QD.QUOT_CODE, QD.CHRG_CODE, QD.CHRG_TYPE, QD.CURCODE, QD.RATE, QD.EX_RATE, QD.MIN_RATE, QD.UNIT, QD.UNITTYPE, QD.QUOTDTLID, QD.MAKERID, QD.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_CHILD_IU");
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult ADMIN_QUOTATION_MST_INSERT([FromBody] Quotation_Master QM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_INSERT", QM.PK_QUOTID, QM.QUOT_CODE, QM.QUOT_DATE, QM.VALIDUPTO, QM.CLIENT_CODE, QM.CLIENT_ORIGIN, QM.SHIP_MODE, QM.SHIP_TYPE, QM.COMPANY_CODE, (QM.SHIPPINGLINE != null) ? QM.SHIPPINGLINE : "", QM.POL, QM.POD, QM.WEIGHT, QM.CHWEIGHT, QM.VOLUME, QM.LOAD, QM.INCOTERM, (QM.CONTLOADTYPE != null) ? QM.CONTLOADTYPE : "", (QM.NARRATION != null) ? QM.NARRATION : "", (QM.AIRLINE != null) ? QM.AIRLINE : "", QM.MAKERID, QM.MAKERIP, QM.VGUID, QM.CMPCODE, QM.CITYCODE, QM.CITYCODE1, "INSERT");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_MST_INSERT");
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult ADMIN_QUOTATION_MST_UPDATE([FromBody] Quotation_Master QM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_QUOTATION_UPDATE", QM.PK_QUOTID, QM.QUOT_CODE, QM.QUOT_DATE, QM.VALIDUPTO, QM.CLIENT_CODE, QM.CLIENT_ORIGIN, QM.SHIP_MODE, QM.SHIP_TYPE, QM.COMPANY_CODE, QM.SHIPPINGLINE, QM.POL, QM.POD, QM.WEIGHT, QM.CHWEIGHT, QM.VOLUME, QM.LOAD, QM.INCOTERM, QM.CONTLOADTYPE, (QM.NARRATION != null) ? QM.NARRATION : "", (QM.AIRLINE != null) ? QM.AIRLINE : "", QM.MAKERID, QM.MAKERIP, QM.VGUID, QM.CMPCODE, QM.CITYCODE, QM.CITYCODE1, "UPDATE");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ADMIN_QUOTATION_MST_UPDATE");
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Fill_Usercity()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_admin_user_city_new");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_Usercity");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Fill_Location()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_USER_LOCATION_NEW");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_Location");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Fill_UserPopulate()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Admin_User_Select_new" );
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_UserPopulate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }



        //
        [HttpGet]
        public IHttpActionResult Profile_details_populate([FromUri]string CMP_USERCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Admin_User_Popuate_new", CMP_USERCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Profile_details_populate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult Admin_Profile_IU([FromBody]IAdmin cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_USER_IU", (cd.USRCODE != null) ? cd.USRCODE : "", cd.USRNAME, cd.PASSWORD, cd.DATELINE, cd.FULLNAME, cd.GREET, (cd.EMAIL != null) ? cd.EMAIL : "", cd.ACTIVECITY, cd.ACTIVECITYCODE, cd.AUTHORITY, (cd.ISADMIN != null) ? cd.ISADMIN : "", (cd.ROLE != null) ? cd.ROLE : "", (cd.IMG != null) ? cd.IMG : "person-icon.gif", (cd.LOCATION != null) ? cd.LOCATION : "", cd.ID, (cd.NOOFDAYS != null) ? cd.NOOFDAYS : "", (cd.UNBLOCK != null) ? cd.UNBLOCK : "", (cd.ISRESIGNED != null) ? cd.ISRESIGNED : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Admin_Profile_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult UploadFiles()
        {
            string result = string.Empty;
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files["IMAGE"];
                var IMAGE = postedFile.FileName;
                var name = httpRequest.Form["USERNAME"].Trim();
                var extension = Path.GetExtension(IMAGE);
                var IMAGE_FILENAME = name + extension;

                var filePath = HttpContext.Current.Server.MapPath("~/DATA/pics/" + IMAGE_FILENAME);
                try
                {

                    var destpath=("D:\\Application\\Manilal_V5NG\\Manilal_V5NG_CLIENT\\pics\\" + IMAGE_FILENAME);
                    //var destpath =    ("E:\\Programming\\pics\\" + IMAGE_FILENAME);
                    if (File.Exists(destpath))
                    {
                        File.Delete(filePath);
                    }
                    postedFile.SaveAs(filePath);
                    result = "files uploaded succesfully";
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_USER_IMAGE", httpRequest.Form["CMPID"], IMAGE_FILENAME);
                    File.Copy(filePath, destpath, true);
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }

            return Ok("");
        }
        //[HttpPost]
        //public IHttpActionResult UploadFiles()
        //{
        //    var uploadedFileNames = new List<string>();
        //    string result = string.Empty;
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        //httpRequest.Form["cmpid"]

        //        HttpResponseMessage response = new HttpResponseMessage();
        //        var httpRequest = HttpContext.Current.Request;
        //        if (httpRequest.Files.Count > 0)
        //        {
        //            var postedFile = httpRequest.Files[0];
        //            var folderpath = HttpContext.Current.Server.MapPath("~/MP/");
        //            var filePath = HttpContext.Current.Server.MapPath("~/MP/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);
        //          //  uploadedFileNames.Add(httpRequest.Files[0].FileName);
        //          //  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_EXPOTER_TMP_UPLOAD_IU", 0, "", httpRequest.Form["DOCTYPE"], postedFile.FileName, "", httpRequest.Form["CMPID"], httpRequest.Form["guid"], folderpath, httpRequest.Form["filesize"], httpRequest.Form["Makerip"]);
        //          //  var imageName = ds.Tables[1].Rows[0]["ACTFILENAME"].ToString();
        //           // File.Move(filePath, HttpContext.Current.Server.MapPath("~/DATA/Edoc/" + imageName));
        //           // File.Delete(filePath);

        //        }
        //        result = "files uploaded succesfully";

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Master/UploadFiles");
        //    }
        //    return Ok(ds);
        //}
        /* ADDED FOR FINANCIAL YEAR PAGE*/
        [HttpGet]
        public IHttpActionResult FillCity(string userid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillCity", userid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/FillCity");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult FillCompanyAll(string citycode, string cmpcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillCompany_All", citycode, "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/FillCompanyAll");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult FillCompanyAllEDIT(string citycode, string cmpcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillCompany_AllEDIT", "", "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/FillCompanyAllEDIT");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult Acc_AddFinanceYear([FromBody]FinancialYear cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Acc_FinanceYear_Add", (cd.Citycode != null) ? cd.Citycode : "", (cd.CmpCode != null) ? cd.CmpCode : "", cd.StartDate, cd.EndDate);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Acc_AddFinanceYear");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpGet]

        public IHttpActionResult ADMIN_FINANCIALYEAR_Search(string StartDate, string EndDate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_FINANCIALYEAR_SEARCHLIST", StartDate, EndDate);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_FINANCIALYEAR_Search");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        //public IHttpActionResult ADMIN_FINANCIALYEAR_Search([FromBody]FinancialYear cd)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_FINANCIALYEAR_SEARCHLIST", cd.StartDate, cd.EndDate);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Admin/ADMIN_FINANCIALYEAR_Search");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();

        //    }
        //    return Ok(ds);
        //}

        [HttpGet]
        public IHttpActionResult Fill_Admin_FinancialYearDetails(string yearid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ADMIN_FINANCIALYEAR_FILLDETAILS", yearid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_Admin_FinancialYearDetails");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /* ADDED FOR COMPANY MAASTER PAGE*/
        [HttpPost]
        public IHttpActionResult Company_Master_IU([FromBody]companymain cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYMASTER_IU",
                cd.pk_cmpId, (cd.cmpname != null) ? cd.cmpname : "", (cd.cmpaddr1 != null) ? cd.cmpaddr1 : "", (cd.cmpaddr2 != null) ? cd.cmpaddr2 : "", (cd.cmpaddr3 != null) ? cd.cmpaddr3 : "",
                (cd.cmpcity != null) ? cd.cmpcity : "", (cd.cmpactivecity != null) ? cd.cmpactivecity : "", (cd.cmpactivecitycode != null) ? cd.cmpactivecitycode : "", (cd.cmpcustlicno != null) ? cd.cmpcustlicno : "", (cd.cmpiatacode != null) ? cd.cmpiatacode : "",
                (cd.cmptelno != null) ? cd.cmptelno : "", (cd.cmpfaxno != null) ? cd.cmpfaxno : "", (cd.cmpemail != null) ? cd.cmpemail : "", (cd.cmprgdsrvtax != null) ? cd.cmprgdsrvtax : "",
                (cd.cmprgdtpttax != null) ? cd.cmprgdtpttax : "", (cd.cmprgdauxtax != null) ? cd.cmprgdauxtax : "", (cd.cmprgdesic != null) ? cd.cmprgdesic : "", (cd.cmprgdinctaxno != null) ? cd.cmprgdinctaxno : "",
                (cd.cmptanno != null) ? cd.cmptanno : "", (cd.cmprgdstrtax != null) ? cd.cmprgdstrtax : "", (cd.cmprgdchsrvtax != null) ? cd.cmprgdchsrvtax : "", cd.MakerIP, cd.MakerID, "", cd.VGUID);

                var expcode = ds.Tables[0].Rows[0]["CMPCODE"].ToString();
                ///UploadFilesMovetoEdoc(expcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_Master_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult Company_Address_IU([FromBody]companychild cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADDRCHILD_IU", cd.pk_cmpaddressid, cd.braddrs1, cd.braddrs2, cd.braddrs3, cd.fk_cityId, (cd.brphoneno != null) ? cd.brphoneno : "", (cd.brfaxno != null) ? cd.brfaxno : "", (cd.bremail != null) ? cd.bremail : "", (cd.brcmpImage != null) ? cd.brcmpImage : "", (cd.brcmpurl != null) ? cd.brcmpurl : "", (cd.brtax != null) ? cd.brtax : "", (cd.brgstno != null) ? cd.brgstno : "", (cd.bracstmntfrom != null) ? cd.bracstmntfrom : "", (cd.bracstmntfrmemail != null) ? cd.bracstmntfrmemail : "", (cd.brishblissu != null) ? cd.brishblissu : "", (cd.brishawbissw != null) ? cd.brishawbissw : "", (cd.brisactive != null) ? cd.brisactive : "", (cd.brismore != null) ? cd.brismore : "", (cd.vguid != null) ? cd.vguid : "", (cd.MakerIP != null) ? cd.MakerIP : "", (cd.MakerID != null) ? cd.MakerID : "", (cd.cmpid != null) ? cd.cmpid : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_Address_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult Company_Address_UPDATE([FromBody]companychild cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADDRCHILD_UPDATE", cd.pk_cmpaddressid, cd.braddrs1, cd.braddrs2, cd.braddrs3, cd.fk_cityId, (cd.brphoneno != null) ? cd.brphoneno : "", (cd.brfaxno != null) ? cd.brfaxno : "", (cd.bremail != null) ? cd.bremail : "", (cd.brcmpImage != null) ? cd.brcmpImage : "", (cd.brcmpurl != null) ? cd.brcmpurl : "", (cd.brtax != null) ? cd.brtax : "", (cd.brgstno != null) ? cd.brgstno : "", (cd.bracstmntfrom != null) ? cd.bracstmntfrom : "", (cd.bracstmntfrmemail != null) ? cd.bracstmntfrmemail : "", (cd.brishblissu != null) ? cd.brishblissu : "", (cd.brishawbissw != null) ? cd.brishawbissw : "", (cd.brisactive != null) ? cd.brisactive : "", (cd.brismore != null) ? cd.brismore : "", (cd.vguid != null) ? cd.vguid : "", (cd.MakerIP != null) ? cd.MakerIP : "", (cd.MakerID != null) ? cd.MakerID : "", (cd.cmpid != null) ? cd.cmpid : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_Address_UPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult Company_Address_delete([FromUri]string id, string guid, string makerid, string ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADRESS_DELETE", id, guid, makerid, (ID != null) ? ID : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_Address_delete");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult Company_Address_deleteNew([FromUri]string id, string guid, string makerid, string ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADRESS_DELETENEW", id, guid, makerid, (ID != null) ? ID : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_Address_delete");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Fill_Company_Details([FromUri]string _CmpCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYFILLDETAILS", _CmpCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_Company_Details");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult Company_MST_Search()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Admin_Company_Master_Search");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_MST_Search");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Fill_CompanyBranch_DetailsPageLoad(string ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ADMIN_COMPANYBRANCHFILLDETAILSATPAGELOAD");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Fill_CompanyBranch_DetailsPageLoad");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult Companypageload([FromBody]companymain cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANY_PAGELOAD", cd.MakerID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/masterpageload");
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Company_MST_Search1([FromBody]companymain cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Admin_Company_Master_Search", cd.cmpname);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/Company_MST_Search1");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        //Bank Payment Group 
        [HttpGet]
            public IHttpActionResult ADMIN_Fill_ChequePrintAuthority(string cmpcode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Acc_CHQPRINT_FillAuthority", cmpcode, citycode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_Fill_ChequePrintAuthority");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult ADMIN_BP_Bank_Payment_Group_FILL(string fkGroupCmpId ,string cmpcode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_BANK_PAYMENT_GROUP_FILL", fkGroupCmpId, cmpcode, citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ADMIN_BP_Bank_Payment_Group_FILL");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult Admin_BP_Bank_Payment_Group_Add([FromBody]BP_Bank_Payment_Group cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_BANK_PAYMENT_GROUP_ADD", cd.fkGroupCmpId, cd.GroupCmp_UserName, cd.STR_TEXT, cd.MakerID, cd.MakerIP, cd.MODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/Admin_BP_Bank_Payment_Group_Add");
            }
            return Ok(ds);
        }



        [HttpGet]
        public IHttpActionResult ACC_CLIENT_RATE_PAGELOAD( string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_RATE_PAGELOAD",CMPID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ACC_CLIENT_RATE_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult ACC_CLIENT_RATE_CHILD_IU([FromBody]Client_Rate_Details cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_RATE_CHILD_IU",cd.PKID, cd.FK_QUTID, cd.FK_QUTDETID, cd.CHRG_CODE,cd.CHRG_TYPE, cd.CURCODE, cd.RATE,cd.EXRATE, cd.MIN_RATE, cd.UNIT, cd.MAKERID, cd.VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ACC_CLIENT_RATE_CHILD_IU");
            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult ACC_CLIENT_RATE_MST_IU([FromBody]Client_Rate_Master cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_RATE_MST_IU",cd.PKQUTID, cd.CLIENT_CODE, cd.CLIENT_ORIGIN, cd.SHIP_MODE, cd.EFFECT_FRMDT, cd.EFFECT_TODT,  cd.MAKERID, cd.MAKERIP, cd.VGUID,cd.CMPCODE,cd.SHIP_TYPE,cd.SHIPPINGLINE,cd.CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/ACC_CLIENT_RATE_MST_IU");
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult ACC_CLIENT_RATE_SEARCHLIST(string SearchVal, string SearchText,string efftfrdt, string effttodt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_RATE_SEARCH_LIST", (SearchVal != null) ? SearchVal : "", (SearchText != null) ? SearchText : "" , (efftfrdt != null) ? efftfrdt : "", (effttodt != null) ? effttodt : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ACC_CLIENT_RATE_SEARCHLIST");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult ACC_CLIENT_RATE_POPULATE(string pkid,string Makerid ,string VGuid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACC_CLIENT_RATE_POPULATE", pkid, Makerid, VGuid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/ACC_CLIENT_RATE_POPULATE");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult MST_QUOT_RATE_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_QUOT_RATE_PAGELOAD");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/MST_QUOT_RATE_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult MST_QUOTATION_RATE_IU([FromBody]QUOT_RATE_MASTER QR)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_QUOT_RATE_MASTER_IU", QR.PKRTID, QR.SHIPPINGLINE, QR.SHIP_TYPE, QR.SHIP_MODE, QR.STUFF_TYPE, QR.POL, QR.TERMINAL, QR.POD, QR.CONT_SIZE, QR.CONT_TYPE, QR.ITEM_TYPE, QR.CHARGE_CODE,QR.RATE,QR.CURRCODE,QR.EXRATE, QR.EFRMDT,QR.ETODT,QR.MAKERID,QR.MAKERDT,QR.MAKERIP);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/MST_QUOTATION_RATE_IU");
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult MST_QUOTATION_RATE_DELETE(string PKRTID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_QUOT_RATE_MASTER_DELETE",  (PKRTID != null) ? PKRTID : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/MST_QUOTATION_RATE_DELETE");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult MST_QUOTATION_RATE_GETDATAFORCLIENT(string ShippingLine,string shiptype ,string shipmode,string frmdt,string todt,string MakerId,string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GETQUOT_DATA_FORCLIENTORIGINRATE", ShippingLine, shiptype, shipmode, frmdt, todt, MakerId, VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Admin/MST_QUOTATION_RATE_GETDATAFORCLIENT");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
    }
}
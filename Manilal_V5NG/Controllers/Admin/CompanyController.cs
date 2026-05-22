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

namespace Manilal_V5NG.Controllers.Admin
{
    public class CompanyController : ApiController


    {


        //public IHttpActionResult Company_Master_IU([FromBody]companymain cd)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYMASTER_IU",
        //        cd.pk_cmpId, (cd.cmpname != null) ? cd.cmpname : "", (cd.cmpaddr1 != null) ? cd.cmpaddr1 : "", (cd.cmpaddr2 != null) ? cd.cmpaddr2 : "", (cd.cmpaddr3 != null) ? cd.cmpaddr3 : "",
        //        (cd.cmpcity != null) ? cd.cmpcity : "", (cd.cmpactivecity != null) ? cd.cmpactivecity : "", (cd.cmpactivecitycode != null) ? cd.cmpactivecitycode : "", (cd.cmpcustlicno != null) ? cd.cmpcustlicno : "", (cd.cmpiatacode != null) ? cd.cmpiatacode : "",
        //        (cd.cmptelno != null) ? cd.cmptelno : "", (cd.cmpfaxno != null) ? cd.cmpfaxno : "", (cd.cmpemail != null) ? cd.cmpemail : "", (cd.cmprgdsrvtax != null) ? cd.cmprgdsrvtax : "",
        //        (cd.cmprgdtpttax != null) ? cd.cmprgdtpttax : "", (cd.cmprgdauxtax != null) ? cd.cmprgdauxtax : "", (cd.cmprgdesic != null) ? cd.cmprgdesic : "", (cd.cmprgdinctaxno != null) ? cd.cmprgdinctaxno : "",
        //        (cd.cmptanno != null) ? cd.cmptanno : "", (cd.cmprgdstrtax != null) ? cd.cmprgdstrtax : "", (cd.cmprgdchsrvtax != null) ? cd.cmprgdchsrvtax : "", cd.MakerIP, cd.MakerID,"", cd.VGUID);

        //        var expcode = ds.Tables[0].Rows[0]["CMPCODE"].ToString();
        //        ///UploadFilesMovetoEdoc(expcode);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Company/Company_Master_IU");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();

        //    }
        //    return Ok(ds);
        //}
        //[HttpGet]
        //public IHttpActionResult Fill_Company_Details([FromUri]string _CmpCode)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
        //            CommandType.StoredProcedure,
        //            "USP_ADMIN_COMPANYFILLDETAILS", _CmpCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Company/Fill_Company_Details");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }
        //    return Ok(ds);
        //}
   
    //[HttpPost]
    //public IHttpActionResult Fill_CompanyBranch_DetailsPageLoad(string ID)
    //{
    //    DataSet ds = new DataSet();
    //    DAL objDal = new DAL();
    //    try
    //    {
    //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
    //            CommandType.StoredProcedure,
    //            "USP_ADMIN_COMPANYBRANCHFILLDETAILSATPAGELOAD");
    //    }
    //    catch (Exception ex)
    //    {
    //        ds = ErrorLog.Error(ex, "Company/Fill_CompanyBranch_DetailsPageLoad");
    //    }
    //    finally
    //    {
    //        objDal.Dispose();
    //    }
    //    return Ok(ds);
    //}
        //[HttpPost]
        //public IHttpActionResult Company_Address_IU([FromBody]companychild cd)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADDRCHILD_IU", cd.pk_cmpaddressid, cd.braddrs1, cd.braddrs2, cd.braddrs3, cd.fk_cityId, (cd.brphoneno != null) ? cd.brphoneno : "", (cd.brfaxno != null) ? cd.brfaxno : "", (cd.bremail != null) ? cd.bremail : "", (cd.brcmpImage != null) ? cd.brcmpImage : "", (cd.brcmpurl != null) ? cd.brcmpurl : "", (cd.brtax != null) ? cd.brtax : "", (cd.brgstno != null) ? cd.brgstno : "" , (cd.bracstmntfrom != null) ? cd.bracstmntfrom : "", (cd.bracstmntfrmemail != null) ? cd.bracstmntfrmemail : "", (cd.brishblissu != null) ? cd.brishblissu : "", (cd.brishawbissw != null) ? cd.brishawbissw : "", (cd.brisactive != null) ? cd.brisactive : "", (cd.brismore != null) ? cd.brismore : "", (cd.vguid != null) ? cd.vguid : "", (cd.MakerIP != null) ? cd.MakerIP : "", (cd.MakerID != null) ? cd.MakerID : "", (cd.cmpid != null) ? cd.cmpid : "" );
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Company/Company_Address_IU");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();

        //    }
        //    return Ok(ds);
        //}
        /// <summary>Delete a company branch address record.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        //public IHttpActionResult Company_Address_delete([FromUri]string id, string guid, string makerid,string ID)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANYADRESS_DELETE", id, guid, makerid, (ID != null) ? ID : "");
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Company/Company_Address_delete");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();
        //    }
        //    return Ok(ds);
        //}
        //[HttpGet]
        //public IHttpActionResult Company_MST_Search(string cmpname)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();

        //    try
        //    {
        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_Admin_Company_Master_Search", cmpname);
        //    }
        //    catch (Exception ex)
        //    {
        //        ds = ErrorLog.Error(ex, "Company/Company_MST_Search");
        //    }
        //    finally
        //    {
        //        objDal.Dispose();

        //    }
        //    return Ok(ds);
        //}
        //[HttpGet]
        //public IHttpActionResult Companypageload(string CMPID)
        //{
        //    DataSet ds = new DataSet();
        //    DAL objDal = new DAL();
        //    try
        //    {

        //        ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ADMIN_COMPANY_PAGELOAD", CMPID);

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.Error(ex, "Company/masterpageload");
        //    }
        //    return Ok(ds);
        //}
        /// <summary>Search company master records by company name.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
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
                ds = ErrorLog.Error(ex, "Company_MST_Search1");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        /// <summary> operation.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}

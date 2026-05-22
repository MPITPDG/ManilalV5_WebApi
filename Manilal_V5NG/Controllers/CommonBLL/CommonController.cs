using Manilal_V5NG.BaseBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Manilal_V5NG.Controllers.CommonBLL
{
    public class CommonController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetMenuList()
        {
            var stream = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/Include/json/menulist.json"), FileMode.Open);

            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return ResponseMessage(result); 
        }

        [HttpPost]
        public IHttpActionResult getVerifyRight([FromBody]VerifyRights cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_GetUserRightsForForms", cd.CmpId, cd.FormId, cd.CodeCity, cd.EntryDt);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/getVerifyRight");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult getCompanyName([FromUri]string cmpcode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_GetImage", cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/getCompanyName");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult getCityList()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_NormalFillCity");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/getCityList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpGet]
        public IHttpActionResult getConsigneeList()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillConsignee");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/getConsigneeList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult GetFinancialYear(string cmpcode, string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_CMP_FillFinancialYear", cmpcode, citycode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/getFinancialYear");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //
        [HttpGet]
        public IHttpActionResult GetFillcity()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_COMMON_FILLCITY" );
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/GetFillcity");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /* Added for filling company in Supplier Master */
        [HttpGet]
        public IHttpActionResult FillCompany()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillCompany_MASTER");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Common/FillCompany");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

    }
}
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
        /// <summary>Retrieve the application menu list from the JSON configuration file.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetMenuList()
        {
            var stream = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/Include/json/menulist.json"), FileMode.Open);

            var result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return ResponseMessage(result); 
        }

        /// <summary>Verify user access rights for a given form and company.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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

        /// <summary>Retrieve company name and logo image details for the given company code.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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

        /// <summary>Retrieve the full list of cities for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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

        /// <summary>Retrieve the full list of consignees for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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
        /// <summary>Retrieve the financial year list for the given company and city.</summary>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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
        /// <summary>Retrieve the common city fill list for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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
        /// <summary>Retrieve all companies for the master company dropdown.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
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

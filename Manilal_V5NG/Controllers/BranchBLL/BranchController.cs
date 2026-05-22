using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Manilal_V5NG.Controllers
{
    public class BranchController : ApiController
    {

        [HttpPost]
        public IHttpActionResult GetBranch([FromBody]Branch branch)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                if (branch.comptype == "FRT") {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FILLCITY_FRT", branch.cmpid);
                }
                else
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillCity", branch.cmpid);
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Branch/GetBranch");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult GetCompany([FromBody]Branch branch)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FILLCOMPANY_FRT_NG", branch.citycode, branch.cmpcode, branch.comptype, branch.cmpid, branch.logintype);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Branch/GetCompany");
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
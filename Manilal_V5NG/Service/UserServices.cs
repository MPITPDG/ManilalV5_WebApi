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

namespace Manilal_V5NG.Service
{
    public class UserServices
    {
        public object GetUserById(Login login)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_VERIFY_LOGIN", login._username, login._password, "", "ERP-ng");
                ds.Tables[0].Columns.Add("CMPTYPE", typeof(String), null);
                ds.Tables[0].Columns.Add("MODULEID", typeof(String), null);
                ds.Tables[0].Columns.Add("CMPCODE", typeof(String), null);
                ds.Tables[0].Columns.Add("CITYCODE1", typeof(String), null);
                ds.Tables[0].Columns.Add("MAKERIP", typeof(String), Convert.ToString("'" + HttpContext.Current.Request.UserHostAddress + "'"));
                ds.Tables[0].Columns.Add("RIGHTS_CODE", typeof(String), null);
                ds.Tables[0].Columns.Add("CITYNAME", typeof(String), null);
                ds.Tables[0].Columns.Add("ISADMIN", typeof(String), null);
                ds.Tables[0].Columns.Add("STATE_CODE", typeof(String), null);
                ds.Tables[0].Columns.Add("COUNTRY", typeof(String), null);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Login/VerifyLogin");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return ds;
        }
    }
}
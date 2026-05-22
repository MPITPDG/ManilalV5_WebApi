using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Manilal_V5NG.Service;


namespace Manilal_V5NG.Controllers
{
    public class LoginController : ApiController
    {
        /// <summary>Verifies user credentials and returns session/user data including city, module, and rights information.</summary>
        /// <param name="login">Login object containing _username and _password.</param>
        /// <returns>DataSet with user session info: GUID, USERID, CMPTYPE, MODULEID, CMPCODE, CITYCODE1, MAKERIP, RIGHTS_CODE, CITYNAME, ISADMIN, STATE_CODE, COUNTRY.</returns>
        [HttpPost]
        public IHttpActionResult VerifyLogin([FromBody]Login login)
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
                ds.Tables[0].Columns.Add("MAKERIP", typeof(String), Convert.ToString("'"+HttpContext.Current.Request.UserHostAddress+"'"));
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
            return Ok(ds);
        }

        /// <summary>Health check endpoint to verify the API is running.</summary>
        /// <returns>200 OK with message "API Working Successfully."</returns>
        [HttpGet]
        public IHttpActionResult Check_Api_Working()
        {
            return Ok("API Working Successfully.");
        }
        /// <summary>Changes user password using old password verification.</summary>
        /// <param name="oldpwd">Current (old) password.</param>
        /// <param name="newpwd">New password to set.</param>
        /// <param name="userencode">Encoded user identifier.</param>
        /// <returns>DataSet with result of password change operation.</returns>
        [HttpGet]
        public IHttpActionResult changePassword([FromUri]string oldpwd, string newpwd, string userencode) //USP_CMP_VerifyLogin_35_CHANGE_PASSWORD
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_VerifyLogin_35_CHANGE_PASSWORD", oldpwd, newpwd, userencode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Login/changePassword");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        //[HttpPost]
        //public bool CheckLogin([FromBody] Login login)
        //{
        //    // Perform your login verification logic here
        //    // You can access the username and password from the `login` parameter

        //    string username = login.Username;
        //    string password = login.Password;

        //    // Implement your authentication logic here
        //    // Return true if the login is successful, otherwise return false

        //    // Example verification logic
        //    bool isAuthenticated = (username == "admin" && password == "password");

        //    return isAuthenticated;
        //}

        /*
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage GenerateToken([FromBody] Login l)
        {
            UserService login = new UserService();

            if (!string.IsNullOrWhiteSpace(l._username) &&
                !string.IsNullOrWhiteSpace(l._password) &&
                !string.IsNullOrWhiteSpace(l.grant_type))
            { }
            else
            {
                return HttpResponseMessageApi.Error400(l, "_username or _password or grant_type  is Empty!");
            }
            //else if (!string.IsNullOrWhiteSpace(l._username) &&
            //        !string.IsNullOrWhiteSpace(l._password))
            //{
            //    return HttpResponseMessageApi.Error400(l, "_username and _password is Empty!");
            //}
            //else if (!string.IsNullOrWhiteSpace(l._username))
            //{
            //    return HttpResponseMessageApi.Error400(l, "_username is Empty!");
            //}
            //else if (!string.IsNullOrWhiteSpace(l._password))
            //{
            //    return HttpResponseMessageApi.Error400(l, "_password is Empty!");
            //}
            //else if (!string.IsNullOrWhiteSpace(l.grant_type))
            //{
            //    return HttpResponseMessageApi.Error400(l, "grant_type is Empty!");
            //}

            var response = login.GetUserById(l);
            try
            {
                if (response == null)
                {
                    return HttpResponseMessageApi.Error404(null, "User Not Found");
                }
                else
                {
                    DataTable dt = (DataTable)response;
                    object userInfo = GenericMapper.GetItem(dt);
                    LoginInfo log = new LoginInfo()
                    {
                        Guid = Convert.ToString(ExtractObject.GetValFromObj(userInfo, "GUID")),
                        UserId = Convert.ToString(ExtractObject.GetValFromObj(userInfo, "USERID"))
                    };
                    return HttpResponseMessageApi.Success(new { access_token = JwtManager.GenerateToken(log) }, "User Found");
                }
            }
            catch (Exception ex)
            {
                return HttpResponseMessageApi.Error500(null, ex.Message);
            }
        }
        */
    }
}
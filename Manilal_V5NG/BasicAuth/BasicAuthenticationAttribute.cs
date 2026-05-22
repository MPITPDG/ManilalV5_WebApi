using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Text;
using Manilal_V5NG.Controllers;
using Manilal_V5NG.Models;
using System.Web.UI.WebControls;
using System.Security.Claims;
using Login = Manilal_V5NG.Models.Login;

namespace Manilal_V5NG.BasicAuth
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        //public object login { get; private set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);    
            if (actionContext.Request.Headers.Authorization == null)
            {

                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized, "Please Login with Correct UserName and Password !!");
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                //username:password base64 Encoded
                //Admin:Password

                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                String[] usernamepassword = decodedAuthToken.Split(':');
                string username = usernamepassword[0];
                string password = usernamepassword[1];

                

                LoginController objlogin = new LoginController();
                //objlogin.VerifyLogin(Login)
               
                

                //if (objlogin.VerifyLogin( [FromBodyAttribute]  Login))
                //{
                    
                //}
            }
        }
    }
}
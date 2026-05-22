using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Manilal_V5NG
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            // 1. First, register your Web API routes
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // 2. Then, manually call the Swagger registration
            SwaggerConfig.Register();
        }
    }
}

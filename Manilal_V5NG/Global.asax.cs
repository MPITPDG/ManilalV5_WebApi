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
            //SwaggerConfig.Register();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.ToLower().Contains("/swagger"))
            {
                string authHeader = Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    string[] creds = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Substring(6))).Split(':');
                    string user = creds[0];
                    string pass = creds[1];

                    string connStr = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
                    using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                    {
                        // 1. Get the comma-separated IDs for this user
                        string userSql = "SELECT AllowedModules FROM SwaggerUsers WHERE Username=@u AND Password=@p";
                        var cmd = new System.Data.SqlClient.SqlCommand(userSql, conn);
                        cmd.Parameters.AddWithValue("@u", user);
                        cmd.Parameters.AddWithValue("@p", pass);
                        conn.Open();

                        object allowedIdsObj = cmd.ExecuteScalar();
                        if (allowedIdsObj != null)
                        {
                            string allowedIds = allowedIdsObj.ToString();
                            List<string> allowedNames = new List<string>();

                            if (allowedIds == "ALL")
                            {
                                HttpContext.Current.Items["UserModules"] = "ALL";
                            }
                            else
                            {
                                // 2. Convert "1,2,5" into names using your tbl_mst_module
                                // We use an IN clause: SELECT ModuleName FROM tbl_mst_module WHERE pk_ModuleId IN (1,2,5)
                                string moduleSql = string.Format("SELECT ModuleName FROM tbl_mst_module WHERE pk_ModuleId IN ({0})", allowedIds);
                                var moduleCmd = new System.Data.SqlClient.SqlCommand(moduleSql, conn);
                                using (var reader = moduleCmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        allowedNames.Add(reader["ModuleName"].ToString());
                                    }
                                }
                                HttpContext.Current.Items["UserModules"] = string.Join(",", allowedNames);
                            }

                            var identity = new System.Security.Principal.GenericIdentity(user);
                            HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(identity, null);
                            return;
                        }
                    }
                }

                // Show login popup if not authenticated
                Response.AddHeader("WWW-Authenticate", "Basic realm=\"Manilal API Login\"");
                Response.StatusCode = 401;
                Response.End();
            }
        }
    }
}

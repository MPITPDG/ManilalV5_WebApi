using System.Web.Http;
using WebActivatorEx;
using Manilal_V5NG;
using Swashbuckle.Application;
using System;
using System.IO;
using System.Linq;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Manilal_V5NG.SwaggerConfig), "Register")]

namespace Manilal_V5NG
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    // 1. Basic Info
                    c.SingleApiVersion("v1", "Manilal V5NG - Finance API");

                    var xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Manilal_V5NG.xml");
                    if (File.Exists(xmlFile))
                    {
                        c.IncludeXmlComments(xmlFile);
                    }

                    // 2. Include XML Comments (Ensure you follow Step 2 below)
                    //var xmlFile = string.Format(@"{0}\bin\Manilal_V5NG.xml", AppDomain.CurrentDomain.BaseDirectory);
                    //if (File.Exists(xmlFile))
                    //{
                    //    c.IncludeXmlComments(xmlFile);
                    //}

                    // 3. Add Bearer Token Authorization (Authorize Button)
                    c.ApiKey("Bearer")
                        .Description("JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"")
                        .Name("Authorization")
                        .In("header");

                    // 4. Fix for conflicting routes (common in Web API 2)
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                })
                .EnableSwaggerUi(c =>
                {
                    // Custom Title in Browser Tab
                    c.DocumentTitle("Manilal ERP API Documentation");

                    // Expand all controllers by default
                    c.DocExpansion(DocExpansion.List);

                    // Enable the Authorize button for headers
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}
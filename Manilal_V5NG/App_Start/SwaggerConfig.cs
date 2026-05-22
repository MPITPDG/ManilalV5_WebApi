using System.Web.Http;
using WebActivatorEx;
using Manilal_V5NG;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http.Description;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Manilal_V5NG.SwaggerConfig), "Register")]

namespace Manilal_V5NG
{
    /// <summary>
    /// Overrides DefaultContractResolver to prevent the "Invalid type owner for DynamicMethod"
    /// crash that occurs when Newtonsoft.Json tries to call GetDefaultCreator on a raw T[] type.
    /// Arrays cannot own DynamicMethods in .NET Framework — they don't have constructors anyway.
    /// This resolver catches that specific crash and safely initialises the array contract manually.
    /// </summary>
    public class SafeContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        // Cache fallback contracts so they're built only once per type
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, Newtonsoft.Json.Serialization.JsonContract> _fallback
            = new System.Collections.Concurrent.ConcurrentDictionary<Type, Newtonsoft.Json.Serialization.JsonContract>();

        public override Newtonsoft.Json.Serialization.JsonContract ResolveContract(Type type)
        {
            try
            {
                return base.ResolveContract(type);
            }
            catch (ArgumentException ex) when (ex.Message.Contains("Invalid type owner"))
            {
                System.Diagnostics.Debug.WriteLine(
                    "[SafeContractResolver] DynamicMethod crash for: " + type.FullName
                    + " — returning fallback contract.");

                // Minimal array contract — Swashbuckle will use 'object' as item type
                return _fallback.GetOrAdd(type,
                    t => new Newtonsoft.Json.Serialization.JsonArrayContract(t));
            }
        }
    }

    public class SafeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // intentional no-op safety net
        }
    }

    public class SwaggerConfig
    {
        public static void Register()
        {
            // ROOT FIX: replace the JSON contract resolver with one that doesn't crash
            // on raw T[] types. Swashbuckle reads this resolver from the JSON formatter.
            // SafeContractResolver extends DefaultContractResolver — only difference is
            // CreateArrayContract catches the DynamicMethod crash for T[] types.
            GlobalConfiguration.Configuration.Formatters.JsonFormatter
                .SerializerSettings.ContractResolver = new SafeContractResolver();

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Manilal V5NG - Finance API");

                    var xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "Manilal_V5NG.xml");
                    if (File.Exists(xmlFile))
                        c.IncludeXmlComments(xmlFile);

                    c.ApiKey("Bearer")
                        .Description("JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"")
                        .Name("Authorization")
                        .In("header");

                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    c.MapType<System.Data.DataSet>(() => new Schema { type = "object", description = "ADO.NET DataSet (JSON)" });
                    c.MapType<System.Data.DataTable>(() => new Schema { type = "object", description = "ADO.NET DataTable (JSON)" });

                    c.OperationFilter<SafeOperationFilter>();
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("Manilal ERP API Documentation");
                    c.DocExpansion(DocExpansion.List);
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}
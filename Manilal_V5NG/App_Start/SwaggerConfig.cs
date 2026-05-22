using System.Web.Http;
using WebActivatorEx;
using Manilal_V5NG;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        protected override Newtonsoft.Json.Serialization.JsonArrayContract CreateArrayContract(Type objectType)
        {
            if (!objectType.IsArray)
                return base.CreateArrayContract(objectType); // non-array collections work fine

            // Raw T[] types: InitializeContract calls GetDefaultCreator(T[]) which crashes
            // because array types cannot own a DynamicMethod in .NET Framework.
            var contract = new Newtonsoft.Json.Serialization.JsonArrayContract(objectType);

            try
            {
                InitializeContract(contract); // may crash for T[]
            }
            catch (ArgumentException ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "[SafeContractResolver] Caught DynamicMethod crash for array type: "
                    + objectType.FullName + " — " + ex.Message);
                // Safe to swallow: arrays have no default constructor anyway
            }

            // Ensure Swashbuckle can read the element type for schema generation
            contract.CollectionItemType = objectType.GetElementType();
            contract.IsMultidimensionalArray = objectType.GetArrayRank() > 1;

            System.Diagnostics.Debug.WriteLine(
                "[SafeContractResolver] Safe array contract created for: " + objectType.FullName
                + " (element type: " + (contract.CollectionItemType?.FullName ?? "null") + ")");

            return contract;
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
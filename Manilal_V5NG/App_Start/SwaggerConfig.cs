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
    /// Wraps the default Swashbuckle provider. Before generating the doc,
    /// removes any ApiDescription whose parameter types would cause a
    /// "Invalid type owner for DynamicMethod" crash (raw T[] or interface types).
    /// </summary>
    public class SafeSwaggerProvider : ISwaggerProvider
    {
        private static readonly System.Diagnostics.TraceSource Log =
            new System.Diagnostics.TraceSource("SwaggerSafeProvider");

        private readonly ISwaggerProvider _inner;
        private readonly HttpConfiguration _config;

        public SafeSwaggerProvider(ISwaggerProvider inner, HttpConfiguration config)
        {
            _inner = inner;
            _config = config;
        }

        public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
        {
            var apiExplorer = _config.Services.GetApiExplorer();
            var toRemove = new List<ApiDescription>();

            System.Diagnostics.Debug.WriteLine("[SwaggerSafe] Scanning " + apiExplorer.ApiDescriptions.Count + " API descriptions...");

            foreach (var desc in apiExplorer.ApiDescriptions)
            {
                foreach (var param in desc.ParameterDescriptions)
                {
                    var t = param.ParameterDescriptor?.ParameterType;
                    if (t == null) continue;
                    if (IsProblematic(t))
                    {
                        var msg = string.Format(
                            "[SwaggerSafe] SKIP — {0} {1} | param '{2}' type '{3}' (IsArray={4} IsInterface={5})",
                            desc.HttpMethod, desc.RelativePath,
                            param.Name, t.FullName, t.IsArray, t.IsInterface);

                        System.Diagnostics.Debug.WriteLine(msg);
                        System.Diagnostics.Trace.WriteLine(msg);

                        toRemove.Add(desc);
                        break;
                    }
                }
            }

            if (toRemove.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("[SwaggerSafe] No problematic operations found.");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[SwaggerSafe] Removing " + toRemove.Count + " problematic operation(s) before schema gen.");
                foreach (var desc in toRemove)
                    apiExplorer.ApiDescriptions.Remove(desc);
            }

            try
            {
                return _inner.GetSwagger(rootUrl, apiVersion);
            }
            catch (Exception ex)
            {
                // Still crashed after filtering — log full details
                var err = "[SwaggerSafe] CRASH after filter: " + ex.GetType().Name + " — " + ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(err);
                System.Diagnostics.Trace.WriteLine(err);
                throw; // re-throw so Swagger UI shows the real error
            }
        }

        // Recursively check type AND all public properties for raw T[] or interface types
        // that crash Newtonsoft DynamicMethod owner check
        private static bool IsProblematic(Type t, HashSet<Type> visited = null)
        {
            if (t == null) return false;
            if (visited == null) visited = new HashSet<Type>();
            if (!visited.Add(t)) return false; // prevent infinite recursion on circular refs

            // Raw array type (T[]) = invalid DynamicMethod owner
            if (t.IsArray)
            {
                System.Diagnostics.Debug.WriteLine("[SwaggerSafe] Problematic (IsArray): " + t.FullName);
                return true;
            }
            // Interface type = cannot instantiate
            if (t.IsInterface)
            {
                System.Diagnostics.Debug.WriteLine("[SwaggerSafe] Problematic (IsInterface): " + t.FullName);
                return true;
            }

            // Recurse into generic type arguments (e.g. List<BadType[]>)
            if (t.IsGenericType)
            {
                foreach (var arg in t.GetGenericArguments())
                    if (IsProblematic(arg, visited)) return true;
            }

            // Recurse into public instance properties of the type
            // (Swashbuckle generates schemas for nested model properties too)
            try
            {
                foreach (var prop in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    if (IsProblematic(prop.PropertyType, visited)) return true;
            }
            catch { /* reflection on some framework types throws — safe to ignore */ }

            return false;
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

                    // 2. Bearer Token Authorization button
                    c.ApiKey("Bearer")
                        .Description("JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"")
                        .Name("Authorization")
                        .In("header");

                    // 3. Fix conflicting routes
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    // 4. Map complex ADO.NET types to plain object
                    c.MapType<System.Data.DataSet>(() => new Schema { type = "object", description = "ADO.NET DataSet (JSON)" });
                    c.MapType<System.Data.DataTable>(() => new Schema { type = "object", description = "ADO.NET DataTable (JSON)" });
                    c.MapType<System.Collections.IEnumerable>(() => new Schema { type = "array" });
                    c.MapType<Manilal_V5NG.Models.FillTable[]>(() => new Schema { type = "array", items = new Schema { @ref = "#/definitions/FillTable" } });

                    // 5. Safety filters
                    c.OperationFilter<SafeOperationFilter>();

                    // 6. Wrap default provider — strips any operation with T[]/interface params
                    //    before schema generation runs, preventing DynamicMethod crash
                    c.CustomProvider((defaultProvider) =>
                        new SafeSwaggerProvider(defaultProvider, GlobalConfiguration.Configuration));
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
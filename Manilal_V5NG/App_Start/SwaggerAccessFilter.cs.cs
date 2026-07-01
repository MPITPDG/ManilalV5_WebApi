using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG
{
    public class SwaggerAccessFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            // 1. Get the names of allowed modules we saved in Global.asax
            var allowedModulesString = HttpContext.Current.Items["UserModules"] as string;

            // 2. If the user is an Admin (ALL), show everything
            if (allowedModulesString == "ALL") return;

            // 3. If no modules are found (or not logged in), hide everything
            if (string.IsNullOrEmpty(allowedModulesString))
            {
                swaggerDoc.paths.Clear();
                return;
            }

            // 4. Turn the string "Account,Export" into a list
            var allowedList = allowedModulesString.Split(',')
                                .Select(x => x.Trim().ToLower())
                                .ToList();

            // 5. Loop through every API path in Swagger
            foreach (var path in swaggerDoc.paths.ToList())
            {
                // Check if the URL (e.g., /api/Account/Get) contains any of the allowed module names
                bool hasAccess = allowedList.Any(m => path.Key.ToLower().Contains("/" + m + "/"));

                // If the programmer does NOT have access to this module name, remove it from the screen
                if (!hasAccess)
                {
                    swaggerDoc.paths.Remove(path.Key);
                }
            }
        }
    }
}
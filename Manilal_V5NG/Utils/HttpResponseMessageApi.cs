using Manilal_V5NG.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Manilal_V5NG.Utils
{
    public static class HttpResponseMessageApi
    {
        public static HttpResponseMessage Success(object data, string message = "Success")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            object constructResult = ConstructResponse(data, message);
            response.Content = new ObjectContent(constructResult.GetType(), constructResult, new JsonMediaTypeFormatter());
            return response;
        }

        public static HttpResponseMessage Error500(object data, string message = "Internal Server Error", string ReasonPhrase = "Internal Server Error")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = (HttpStatusCode)500;
            response.ReasonPhrase = ReasonPhrase;
            object constructResult = ConstructResponse(data, message, 500);
            response.Content = new ObjectContent(constructResult.GetType(), constructResult, new JsonMediaTypeFormatter());
            return response;
        }
        public static HttpResponseMessage Error404(object data, string message = "Not Found", string ReasonPhrase = "Not Found")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = (HttpStatusCode)404;
            response.ReasonPhrase = ReasonPhrase;
            object constructResult = ConstructResponse(data, message, 404);
            response.Content = new ObjectContent(constructResult.GetType(), constructResult, new JsonMediaTypeFormatter());
            return response;
        }
        public static HttpResponseMessage Error403(object data, string message = "Exist", string ReasonPhrase = "Exist")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = (HttpStatusCode)403;
            response.ReasonPhrase = ReasonPhrase;
            object constructResult = ConstructResponse(data, message, 403);
            response.Content = new ObjectContent(constructResult.GetType(), constructResult, new JsonMediaTypeFormatter());
            return response;
        }
        public static HttpResponseMessage Error400(object data, string message = "Is Empty", string ReasonPhrase = "Bad Request")
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = (HttpStatusCode)400;
            response.ReasonPhrase = ReasonPhrase;
            object constructResult = ConstructResponse(data, message, 400);
            response.Content = new ObjectContent(constructResult.GetType(), constructResult, new JsonMediaTypeFormatter());
            return response;
        }
        private static object ConstructResponse(object data, string message = "Success", int status = 200)
        {
            return new ApiResponse() { status = status, message = message, data = data };
        }

    }
}
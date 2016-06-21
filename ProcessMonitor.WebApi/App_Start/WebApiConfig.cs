using System.Net.Http.Headers;
using System.Web.Http;

namespace ProcessMonitor.WebApi
{
    /// <summary>
    /// Configuration class.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Routes register of API controllers.
        /// </summary>
        /// <param name="config">Http server configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}

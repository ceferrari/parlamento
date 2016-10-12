using System.Web.Http;
using Newtonsoft.Json;

namespace ParlamentoApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable CORS
            //app.UseCors(CorsOptions.AllowAll);
            config.EnableCors();

            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            formatters.Remove(formatters.XmlFormatter);
            settings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
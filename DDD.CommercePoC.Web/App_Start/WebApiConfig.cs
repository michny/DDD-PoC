using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace DDD.CommercePoC.Web
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }
        
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: UrlPrefix + "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Setting camelCasing on JSON properties
            HttpConfiguration globalConfig = GlobalConfiguration.Configuration;
            globalConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            globalConfig.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}

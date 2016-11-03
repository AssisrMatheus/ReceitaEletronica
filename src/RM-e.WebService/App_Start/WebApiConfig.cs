using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace RM_e.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormat = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormat.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormat.Indent = true;
        }
    }
}

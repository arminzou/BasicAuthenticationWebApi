using BasicAuthenticationWebApi.MessageHandlers;
using BasicAuthenticationWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BasicAuthenticationWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new BasicAuthenticationAttribute());
            //config.MessageHandlers.Add(new CustomMessageHandler());
            //config.MessageHandlers.Add(new CustomMessageHandler2());
            config.MessageHandlers.Add(new XHTTPMethodOverrideHandler());
            //config.MessageHandlers.Add(new CustomHeaderHandler());
            //config.MessageHandlers.Add(new ApiKeyHandler("secretkey"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
        }
    }
}

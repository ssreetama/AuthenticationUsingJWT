using BasicAuthenticationUsingJWT.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BasicAuthenticationUsingJWT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //enable http to https
            config.Filters.Add(new CustomeRequireHttpsAttribute());
            config.Filters.Add(new BasicAuth());
            // Web API configuration and services
            //enable cors
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Account",
                routeTemplate: "api/Account/Index",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

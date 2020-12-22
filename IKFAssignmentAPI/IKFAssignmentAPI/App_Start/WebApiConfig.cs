using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IKFAssignmentAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string origin = "http://localhost:4200";
            EnableCorsAttribute cors = new EnableCorsAttribute(origin, "*", "GET,POST,PUT,PATCH,DELETE");
            config.EnableCors(cors);

            // Web API configuration and services
            //config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

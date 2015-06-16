using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MBP_WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultPage",
                routeTemplate: "",
                defaults: new { controller = "default"}
            );

            config.Routes.MapHttpRoute(
                name: "AuthenticationLogin",
                routeTemplate: "authenticate/login",
                defaults: new { controller = "authenticatelogin" }
            );

            config.Routes.MapHttpRoute(
                name: "AuthenticationLogout",
                routeTemplate: "authenticate/logout",
                defaults: new { controller = "authenticatelogout" }
            );

            config.Routes.MapHttpRoute(
                name: "OnlineGame",
                routeTemplate: "onlinegame",
                defaults: new { controller = "OnlineGame" }
            );
        }
    }
}

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
                defaults: new { controller = "authenticate"}
            );

            config.Routes.MapHttpRoute(
                name: "AuthenticationLogout",
                routeTemplate: "authenticate/logout",
                defaults: new { controller = "authenticate" }
            );

            config.Routes.MapHttpRoute(
                name: "GetShipCatalog",
                routeTemplate: "shipcatalog",
                defaults: new { controller = "shipcatalog" }
            );

            config.Routes.MapHttpRoute(
                name: "NewOnlineGame",
                routeTemplate: "onlinegame/newonlinegame",
                defaults: new { controller = "onlinegame", action = "postnewonlinegame" }
            );

            config.Routes.MapHttpRoute(
                name: "AlreadyStartedOnlineGame",
                routeTemplate: "onlinegame/alreadystarted",
                defaults: new { controller = "onlinegame", action = "getalreadystarted"}
            );

            config.Routes.MapHttpRoute(
                name: "OnlineWaitingGames",
                routeTemplate: "onlinegame/waitinggames",
                defaults: new { controller = "onlinegame", action = "getwaitinggames" }
            );

            config.Routes.MapHttpRoute(
                name: "SelectOnlineGame",
                routeTemplate: "onlinegame/selectonlinegame",
                defaults: new { controller = "onlinegame", action = "getselectonlinegame" }
            );

            config.Routes.MapHttpRoute(
                name: "JoinOnlineGame",
                routeTemplate: "onlinegame/joinonlinegame",
                defaults: new { controller = "onlinegame", action = "postjoinonlinegame" }
            );

            config.Routes.MapHttpRoute(
                name: "GameFeeds",
                routeTemplate: "onlinegame/gamefeeds",
                defaults: new { controller = "onlinegame", action = "getgamefeeds" }
            );

            config.Routes.MapHttpRoute(
                name: "ChatNewMessage",
                routeTemplate: "chat/newmessage",
                defaults: new { controller = "chat", action = "postnewmessage" }
            );

            config.Routes.MapHttpRoute(
                name: "MakeShot",
                routeTemplate: "shot/makeshot",
                defaults: new { controller = "shot", action = "postmakeshot" }
            );
        }
    }
}

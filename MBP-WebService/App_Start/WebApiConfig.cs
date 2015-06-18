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
                name: "FinaleGameFeeds",
                routeTemplate: "onlinegame/finalegamefeeds",
                defaults: new { controller = "onlinegame", action = "getfinalegamefeeds" }
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

            config.Routes.MapHttpRoute(
                name: "ExtraShotAbility",
                routeTemplate: "ability/extrashot",
                defaults: new { controller = "abilities", action = "postextrashotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ThreeExtraShotAbility",
                routeTemplate: "ability/threeextrashot",
                defaults: new { controller = "abilities", action = "postthreeextrashotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ExtraTurnShotAbility",
                routeTemplate: "ability/extraturnshot",
                defaults: new { controller = "abilities", action = "postextraturnshotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "AntiShieldAbility",
                routeTemplate: "ability/antishield",
                defaults: new { controller = "abilities", action = "postantishieldactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "BombAbility",
                routeTemplate: "ability/bomb",
                defaults: new { controller = "abilities", action = "postbombactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "LifeGuardAbility",
                routeTemplate: "ability/lifeguard",
                defaults: new { controller = "abilities", action = "postlifeguardactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "OnePlusVerticalAbility",
                routeTemplate: "ability/oneplusvertical",
                defaults: new { controller = "abilities", action = "postoneplusverticalactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "OnePlusHorizontalAbility",
                routeTemplate: "ability/oneplushorizontal",
                defaults: new { controller = "abilities", action = "postoneplushorizontalactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "SpyAbility",
                routeTemplate: "ability/spy",
                defaults: new { controller = "abilities", action = "postspyactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ShieldAbility",
                routeTemplate: "ability/shield",
                defaults: new { controller = "abilities", action = "postshieldactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "GameAbilities",
                routeTemplate: "ability/game",
                defaults: new { controller = "abilities", action = "getgameabilities" }
            );

            config.Routes.MapHttpRoute(
                name: "GameUserStatistics",
                routeTemplate: "gameuser/statistics",
                defaults: new { controller = "gameuser", action = "getstatisticsuser" }
            );

            config.Routes.MapHttpRoute(
                name: "GameFullUserStatistics",
                routeTemplate: "gameuser/fullstatistics",
                defaults: new { controller = "gameuser", action = "getfullstatisticsuser" }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MBP_WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultPage",
                routeTemplate: "",
                defaults: new { controller = "default"}
            );

            config.Routes.MapHttpRoute(
                name: "AuthenticationLogin",
                routeTemplate: "onlinegame/authenticate/login",
                defaults: new { controller = "authenticate"}
            );

            config.Routes.MapHttpRoute(
                name: "AuthenticationLogout",
                routeTemplate: "onlinegame/authenticate/logout",
                defaults: new { controller = "authenticate" }
            );

            config.Routes.MapHttpRoute(
                name: "GetShipCatalog",
                routeTemplate: "onlinegame/shipcatalog",
                defaults: new { controller = "shipcatalog", action = "getonlinegameshipcatalog" }
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
                routeTemplate: "onlinegame/chat/newmessage",
                defaults: new { controller = "chat", action = "postnewmessage" }
            );

            config.Routes.MapHttpRoute(
                name: "OnlineMakeShot",
                routeTemplate: "onlinegame/shot/makeshot",
                defaults: new { controller = "shotonline", action = "postmakeshot" }
            );

            config.Routes.MapHttpRoute(
                name: "ExtraShotAbility",
                routeTemplate: "onlinegame/ability/extrashot",
                defaults: new { controller = "abilities", action = "postextrashotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ThreeExtraShotAbility",
                routeTemplate: "onlinegame/ability/threeextrashot",
                defaults: new { controller = "abilities", action = "postthreeextrashotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ExtraTurnShotAbility",
                routeTemplate: "onlinegame/ability/extraturnshot",
                defaults: new { controller = "abilities", action = "postextraturnshotactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "AntiShieldAbility",
                routeTemplate: "onlinegame/ability/antishield",
                defaults: new { controller = "abilities", action = "postantishieldactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "BombAbility",
                routeTemplate: "onlinegame/ability/bomb",
                defaults: new { controller = "abilities", action = "postbombactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "LifeGuardAbility",
                routeTemplate: "onlinegame/ability/lifesaver",
                defaults: new { controller = "abilities", action = "postlifeguardactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "OnePlusVerticalAbility",
                routeTemplate: "onlinegame/ability/oneplusvertical",
                defaults: new { controller = "abilities", action = "postoneplusverticalactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "OnePlusHorizontalAbility",
                routeTemplate: "onlinegame/ability/oneplushorizontal",
                defaults: new { controller = "abilities", action = "postoneplushorizontalactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "SpyAbility",
                routeTemplate: "onlinegame/ability/spy",
                defaults: new { controller = "abilities", action = "postspyactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "ShieldAbility",
                routeTemplate: "onlinegame/ability/shield",
                defaults: new { controller = "abilities", action = "postshieldactivate" }
            );

            config.Routes.MapHttpRoute(
                name: "GameAbilities",
                routeTemplate: "onlinegame/ability/game",
                defaults: new { controller = "abilities", action = "getgameabilities" }
            );

            config.Routes.MapHttpRoute(
                name: "GameUserStatistics",
                routeTemplate: "onlinegame/gameuser/statistics",
                defaults: new { controller = "gameuser", action = "getstatisticsuser" }
            );

            config.Routes.MapHttpRoute(
                name: "NewGameUser",
                routeTemplate: "onlinegame/gameuser/new",
                defaults: new { controller = "gameuser", action = "postnewgameuser" }
            );

            config.Routes.MapHttpRoute(
                name: "GameFullUserStatistics",
                routeTemplate: "onlinegame/gameuser/fullstatistics",
                defaults: new { controller = "gameuser", action = "getfullstatisticsuser" }
            );

            config.Routes.MapHttpRoute(
                name: "NewModeratorUser",
                routeTemplate: "onlinegame/moderatoruser/new",
                defaults: new { controller = "moderatoruser", action = "postnewmoderatoruser" }
            );

            config.Routes.MapHttpRoute(
                name: "NewAdminUser",
                routeTemplate: "onlinegame/administratoruser/new",
                defaults: new { controller = "administratoruser", action = "postnewadministratoruser" }
            );

            config.Routes.MapHttpRoute(
                name: "LiveGameShipCatalog",
                routeTemplate: "livegame/shipcatalog",
                defaults: new { controller = "shipcatalog", action = "getlivegameshipcatalog" }
            );

            config.Routes.MapHttpRoute(
                name: "TerminalKeyDevice",
                routeTemplate: "livegame/terminal/key",
                defaults: new { controller = "terminal", action = "postaddterminalkey" }
            );

            config.Routes.MapHttpRoute(
                name: "ValidateTerminalKeyDevice",
                routeTemplate: "livegame/terminal/key/validate",
                defaults: new { controller = "terminal", action = "postterminalkeyvalidate" }
            );

            config.Routes.MapHttpRoute(
                name: "NewLiveGame",
                routeTemplate: "livegame/newlivegame",
                defaults: new { controller = "livegame", action = "postnewlivegame" }
            );

            config.Routes.MapHttpRoute(
                name: "LiveGameTurnChange",
                routeTemplate: "livegame/turnchange",
                defaults: new { controller = "livegame", action = "postmaketurnchange" }
            );

            config.Routes.MapHttpRoute(
                name: "LiveMakeShot",
                routeTemplate: "livegame/shot/makeshot",
                defaults: new { controller = "shotlive", action = "postmakeshot" }
            );

            config.Routes.MapHttpRoute(
                name: "LiveShotFeeds",
                routeTemplate: "livegame/shot/feeds",
                defaults: new { controller = "shotlive", action = "getliveshotsfeed" }
            );

            config.Routes.MapHttpRoute(
                name: "FinaleLiveGameFeeds",
                routeTemplate: "livegame/finalegamefeeds",
                defaults: new { controller = "livegame", action = "getfinalegamefeeds" }
            );
        }
    }
}

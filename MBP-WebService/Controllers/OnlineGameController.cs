using MBP_Cross.DTO.ProtocolDTO;
using MBP_Logic.Comunication;
using MBP_Logic.Interface.FacadeInterface;
using MBP_Logic.Manager;
using MBP_WebService.Models.Errors;
using MBP_WebService.Models.Generals;
using MBP_WebService.Models.JsonSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Security;

namespace MBP_WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class OnlineGameController : ApiController
    {
        //GET /onlinegame/waitinggames
        //Obtiene los waiting games
        [Authorize]
        public HttpResponseMessage GetWaitingGames()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<IList<WaitingGameDTO>> waitingGames = onlineGameFacade.getOnlineWaitingGames();
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(waitingGames), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //GET /onlinegame/selectonlinegame
        //Selecciona un juego para jugar
        [Authorize]
        public HttpResponseMessage GetSelectOnlineGame(string pCreatorNickname)
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<IList<ShipDTO>> selectOnlineGame = onlineGameFacade.selectOnlineGame(pCreatorNickname);
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(selectOnlineGame), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //GET /onlinegame/alreadystarted
        //Pregunta si un juego ya inicio
        [Authorize]
        public HttpResponseMessage GetAlreadyStarted()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<bool> alreadyStarted = onlineGameFacade.alreadyStarted(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(alreadyStarted), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //GET /onlinegame/gamefeeds
        //Obtiene los feeds del juego
        [Authorize]
        public HttpResponseMessage GetGameFeeds()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<GameFeedDTO> gameFeed = onlineGameFacade.getGameFeed(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(gameFeed), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //GET /onlinegame/finalegamefeeds
        //Obtiene los finale feeds del juego
        [Authorize]
        public HttpResponseMessage GetFinaleGameFeeds()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<FinaleFeedsDTO> finaleGameFeed = onlineGameFacade.getFinaleFeeds(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(finaleGameFeed), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //POST /onlinegame/newonlinegame
        //Crea un nuevo juego online
        [Authorize]
        public HttpResponseMessage PostNewOnlineGame()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if(ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    DataGameDTO dataGame = JSONSerialize.deserealizeJson<DataGameDTO>(datosPost);
                    dataGame.setNickname(ExtractorValues.getNickname(authCookie.Name));
                    ResponseObject<string> newOnlineGameCreated = onlineGameFacade.newOnlineGame(dataGame);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(newOnlineGameCreated), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //POST /onlinegame/joinonlinegame
        //Se une a una partida
        [Authorize]
        public HttpResponseMessage PostJoinOnlineGame()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    JoinGameDTO joinGameData = JSONSerialize.deserealizeJson<JoinGameDTO>(datosPost);
                    joinGameData.setCreatorNickname(ExtractorValues.getNickname(authCookie.Name));
                    ResponseObject<string> joinOnlineGameData = onlineGameFacade.joinOnlineGame(joinGameData);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(joinOnlineGameData), Encoding.UTF8, "text/plain");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }
    }
}

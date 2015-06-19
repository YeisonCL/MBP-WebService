using MBP_Cross.DTO.ProtocolDTO;
using MBP_Logic.Comunication;
using MBP_WebService.Models.Errors;
using MBP_WebService.Models.Generals;
using MBP_WebService.Models.JsonSerialize;
using MBPL_Logic.Interface.FacadeInterface;
using MBPL_Logic.Manager.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace MBP_WebService.Controllers
{
    public class LiveGameController : ApiController
    {
        //POST livegame/newlivegame
        //Crea un nuevo juego en linea
        [Authorize]
        public HttpResponseMessage PostNewLiveGame()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 1)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    DataLiveGameDTO dataGame = JSONSerialize.deserealizeJson<DataLiveGameDTO>(datosPost);
                    dataGame.setpNicknameModUser(ExtractorValues.getNickname(authCookie.Name));
                    ResponseObject<IList<ShipDTO>> newliveGameCreated = liveGameFacade.newLiveGame(dataGame);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(newliveGameCreated), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
        }

        //POST livegame/turnchange
        //Realiza un cambio de turno
        [Authorize]
        public HttpResponseMessage PostMakeTurnChange()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 1)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    DataLiveGameDTO dataGame = JSONSerialize.deserealizeJson<DataLiveGameDTO>(datosPost);
                    liveGameFacade.makeTurnChange(dataGame.getNicknamePlayerOne(), dataGame.getNicknamePlayerTwo());

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent("", Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
        }

        //GET /livegame/finalegamefeeds
        //Obtiene los finale feeds del juego
        [Authorize]
        public HttpResponseMessage GetFinaleGameFeeds(string pNickname)
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<FinaleFeedsDTO> finaleGameFeed = liveGameFacade.getFinaleFeeds(pNickname);
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(finaleGameFeed), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
                else
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getNotAllowed()), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
        }
    }
}

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
using System.Web.Security;

namespace MBP_WebService.Controllers
{
    public class AbilitiesController : ApiController
    {
        //GET /ability/game
        //Obtiene las habilidades que tiene un jugador para ser usadas en el juego
        [Authorize]
        public HttpResponseMessage GetGameAbilities()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<IList<GameAbilityFeedDTO>> gameAbilities = onlineGameFacade.getGameAbilities(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(gameAbilities), Encoding.UTF8, "text/plain");
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

        //POST ability/extrashot
        //Activa la habilidad disparo extra
        [Authorize]
        public HttpResponseMessage PostExtraShotActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<string> extraShotActivate = onlineGameFacade.extraShotsActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(extraShotActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/threeextrashot
        //Activa la habilidad de tres disparos extra
        [Authorize]
        public HttpResponseMessage PostThreeExtraShotActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<string> threeExtraShotActivate = onlineGameFacade.threeExtraShotActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(threeExtraShotActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/extraturnshot
        //Activa la habilidad de un tiro extra por turno
        [Authorize]
        public HttpResponseMessage PostExtraTurnShotActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {   
                    ResponseObject<string> extraTurnShotActivate = onlineGameFacade.extraTurnShotActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(extraTurnShotActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/antishield
        //Activa la habilidad de anti escudo
        [Authorize]
        public HttpResponseMessage PostAntiShieldActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<string> antiShieldActivate = onlineGameFacade.antiShieldActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(antiShieldActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/bomb
        //Activa la habilidad de bomba
        [Authorize]
        public HttpResponseMessage PostBombActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<string> bombActivate = onlineGameFacade.bombActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(bombActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/lifeguard
        //Activa la habilidad de salvavidas
        [Authorize]
        public HttpResponseMessage PostLifeGuardActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    ShipPositionDTO shipPosition = JSONSerialize.deserealizeJson<ShipPositionDTO>(datosPost);
                    ResponseObject<string> shipPositionResponse = onlineGameFacade.lifeGuardActivate(ExtractorValues.getNickname(authCookie.Name), shipPosition.getColumnPosition(), shipPosition.getRawPosition());

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(shipPositionResponse), Encoding.UTF8, "text/plain");
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

        //POST ability/oneplusvertical
        //Activa la habilidad de mas uno vertical
        [Authorize]
        public HttpResponseMessage PostOnePlusVerticalActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    ResponseObject<string> onePlusVertical = onlineGameFacade.onePlusVerticalActivate(ExtractorValues.getNickname(authCookie.Name), datosPost);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(onePlusVertical), Encoding.UTF8, "text/plain");
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

        //POST ability/oneplushorizontal
        //Activa la habilidad de mas uno horizontal
        [Authorize]
        public HttpResponseMessage PostOnePlusHorizontalActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    ResponseObject<string> onePlusHorizontal = onlineGameFacade.onePlusHorizontalActivate(ExtractorValues.getNickname(authCookie.Name), datosPost);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(onePlusHorizontal), Encoding.UTF8, "text/plain");
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

        //POST ability/spy
        //Activa la habilidad de espia
        [Authorize]
        public HttpResponseMessage PostSpyActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<SpyDTO> spyActivate = onlineGameFacade.spyActivate(ExtractorValues.getNickname(authCookie.Name));

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(spyActivate), Encoding.UTF8, "text/plain");
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

        //POST ability/shield
        //Activa la habilidad de escudo
        [Authorize]
        public HttpResponseMessage PostShieldActivate()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    ShipPositionDTO shipPosition = JSONSerialize.deserealizeJson<ShipPositionDTO>(datosPost);
                    ResponseObject<IList<ShipPositionDTO>> shieldActivate = onlineGameFacade.shieldActivate(ExtractorValues.getNickname(authCookie.Name), shipPosition.getColumnPosition(), shipPosition.getRawPosition());

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(shieldActivate), Encoding.UTF8, "text/plain");
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

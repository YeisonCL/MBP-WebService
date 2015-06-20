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
    public class GameUserController : ApiController
    {
        //GET gameuser/statistics
        //Obtiene las estadisticas de un game user
        [Authorize]
        public HttpResponseMessage GetStatisticsUser()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<StatisticsGameDTO> statisticsUser = onlineGameFacade.getStatisticsUser(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(statisticsUser), Encoding.UTF8, "text/plain");
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

        //GET gameuser/fullstatistics
        //Obtiene las estadisticas completas de un game user
        [Authorize]
        public HttpResponseMessage GetFullStatisticsUser()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<FullStatisticsGameDTO> fullStatisticsUser = onlineGameFacade.getFullStatisticUser(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(fullStatisticsUser), Encoding.UTF8, "text/plain");
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

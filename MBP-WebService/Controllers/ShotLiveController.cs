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
using System.Web.Http.Cors;
using System.Web.Security;

namespace MBP_WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ShotLiveController : ApiController
    {
        //POST livegame/shot/makeshot
        //Realizar un disparo
        public HttpResponseMessage PostMakeShot()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                string datosPost = Request.Content.ReadAsStringAsync().Result;
                liveGameFacade.makeShot(Convert.ToInt32(datosPost.Split(':').ElementAt(0)), datosPost.Split(':').ElementAt(1));

                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent("", Encoding.UTF8, "text/plain");
                return _request;
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                return _request;
            }
        }

        //GET livegame/shot/feeds
        //Obtiene los feeds de los disparos en vivo
        [Authorize]
        public HttpResponseMessage GetLiveShotsFeed()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 1)
                {
                    ResponseObject<IList<ShotFeedDTO>> shotsFeed = liveGameFacade.getShotsFeed(ExtractorValues.getNickname(authCookie.Name));
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(shotsFeed), Encoding.UTF8, "text/plain");
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

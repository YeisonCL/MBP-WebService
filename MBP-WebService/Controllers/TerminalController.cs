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
    public class TerminalController : ApiController
    {
        //POST livegame/terminal/key
        //Realizar un disparo
        public HttpResponseMessage PostAddTerminalKey()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                string datosPost = Request.Content.ReadAsStringAsync().Result;
                liveGameFacade.addTerminalKey(datosPost);

                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent("", Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError()), Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
        }

        //POST livegame/terminal/key/validate
        //Realizar un disparo
        public HttpResponseMessage PostAddTerminalKeyValidate()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 1)
                {
                    string datosPost = Request.Content.ReadAsStringAsync().Result;
                    ResponseObject<bool> terminalKey = liveGameFacade.validateTerminalKey(datosPost);

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(terminalKey), Encoding.UTF8, "text/plain");
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

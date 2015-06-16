using MBP_Cross.DTO.DatabaseDTO;
using MBP_Logic.Comunication;
using MBP_Logic.Interface.FacadeInterface;
using MBP_Logic.Manager;
using MBP_WebService.Models.Errors;
using MBP_WebService.Models.JsonSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Security;

namespace MBP_WebService.Controllers
{
    public class AuthenticateController : ApiController
    {

        //GET /authenticate/logout
        //Hace logout a un cliente
        public HttpResponseMessage GetAuthenticateLogout()
        {
            try
            {
                FormsAuthentication.SignOut();
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(DefaultErrors.notError()), Encoding.UTF8, "text/plain");
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

        //POST /authenticate/login
        //Autentica un nuevo jugador dandole una cookie
        public HttpResponseMessage PostAuthenticateLogin()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                string datosPost = Request.Content.ReadAsStringAsync().Result;
                UserNickPassDTO userNickPass = JSONSerialize.deserealizeJson<UserNickPassDTO>(datosPost);
                ResponseObject<Tuple<bool, int>> validationUser = onlineGameFacade.checkUser(userNickPass.getNickname(), userNickPass.getPassword());
                if (!validationUser.getError())
                {
                    System.Web.HttpCookie cookie = FormsAuthentication.GetAuthCookie(userNickPass.getNickname() + ":" + userNickPass.getPassword() + 
                        ":" + validationUser.getObject().Item2.ToString(), true);
                    validationUser.setObject(null);

                    CookieHeaderValue exitCookie = new CookieHeaderValue(cookie.Name, cookie.Value);
                    exitCookie.Expires = DateTimeOffset.Now.AddHours(4);
                    exitCookie.Domain = cookie.Domain;
                    exitCookie.Path = cookie.Path;

                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Headers.AddCookies(new CookieHeaderValue[] { exitCookie });
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(validationUser), Encoding.UTF8, "text/plain");
                    _request.Headers.Add("Access-Control-Allow-Origin", "*");
                    return _request;
                }
                else 
                {
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(validationUser), Encoding.UTF8, "text/plain");
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

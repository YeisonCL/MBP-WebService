using MBP_Cross.DTO.DatabaseDTO;
using MBP_Cross.DTO.ProtocolDTO;
using MBP_Logic.Comunication;
using MBP_Logic.Interface.FacadeInterface;
using MBP_Logic.Manager;
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
using System.Windows.Forms;

namespace MBP_WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ShipCatalogController : ApiController
    {
        //GET /shipcatalog
        //Obtiene el ship catalog de la base
        [Authorize]
        public HttpResponseMessage GetOnlineGameShipCatalog()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 0)
                {
                    ResponseObject<IList<ShipDTO>> shipCatalog = onlineGameFacade.getShipCatalog();
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(shipCatalog), Encoding.UTF8, "text/plain");
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

        //GET livegame/shipcatalog
        //Obtiene el ship catalog de la base
        [Authorize]
        public HttpResponseMessage GetLiveGameShipCatalog()
        {
            try
            {
                ILiveGameFacade liveGameFacade = new LiveGameManager();
                FormsAuthenticationTicket authCookie = FormsAuthentication.Decrypt(Request.Headers.GetCookies(".ASPXAUTH").First().Cookies.First().Value);
                if (ExtractorValues.getRoleType(authCookie.Name) == 1)
                {
                    ResponseObject<ShipCatalogDTO> shipCatalog = liveGameFacade.getLiveShipCatalog();
                    HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                    _request.Content = new StringContent(JSONSerialize.serealizeJson(shipCatalog), Encoding.UTF8, "text/plain");
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

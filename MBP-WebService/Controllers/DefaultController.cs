using MBP_Logic.Interface.FacadeInterface;
using MBP_Logic.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MBP_WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    public class DefaultController : ApiController
    {
        //GET /
        //Pagina principal
        public HttpResponseMessage GetPrincipalPage()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                onlineGameFacade.startMBP();
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent("¡Bienvenido a MyBattlePong!", Encoding.UTF8, "text/plain");
                return _request;
            }
            catch
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.Conflict);
                _request.Content = new StringContent("¡Se ha producido un error procesando su petición!", Encoding.UTF8, "text/plain");
                return _request;
            }
        }
    }
}

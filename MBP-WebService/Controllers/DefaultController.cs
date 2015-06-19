﻿using MBP_Logic.Interface.FacadeInterface;
using MBP_Logic.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MBP_WebService.Controllers
{
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
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
            catch(Exception ex)
            {
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.Conflict);
                _request.Content = new StringContent(ex.Message, Encoding.UTF8, "text/plain");
                _request.Headers.Add("Access-Control-Allow-Origin", "*");
                return _request;
            }
        }
    }
}

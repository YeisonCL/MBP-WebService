﻿using MBP_Cross.DTO.DatabaseDTO;
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
    public class ModeratorUserController : ApiController
    {
        //POST onlinegame/moderatoruser/new
        //Crea un nuevo moderator user en la base de datos
        public HttpResponseMessage PostNewModeratorUser()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                string datosPost = Request.Content.ReadAsStringAsync().Result;
                ModeratorUserDTO userData = JSONSerialize.deserealizeJson<ModeratorUserDTO>(datosPost);
                ResponseObject<string> moderatorUserResponse = onlineGameFacade.createNewModUser(userData);

                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(moderatorUserResponse), Encoding.UTF8, "text/plain");
                return _request;
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

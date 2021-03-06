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
    public class AdministratorUserController : ApiController
    {
        //POST onlinegame/moderatoruser/new
        //Crea un nuevo moderator user en la base de datos
        public HttpResponseMessage PostNewAdministratorUser()
        {
            try
            {
                IOnlineGameFacade onlineGameFacade = new OnlineGameManager();
                string datosPost = Request.Content.ReadAsStringAsync().Result;
                AdminUserDTO adminData = JSONSerialize.deserealizeJson<AdminUserDTO>(datosPost);
                ResponseObject<string> administratorUserResponse = onlineGameFacade.createNewAdminUser(adminData);

                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(JSONSerialize.serealizeJson(administratorUserResponse), Encoding.UTF8, "text/plain");
                return _request;
            }
            catch(Exception ex)
            {
                //JSONSerialize.serealizeJson(DefaultErrors.getInternalDefaultError())
                HttpResponseMessage _request = new HttpResponseMessage(HttpStatusCode.OK);
                _request.Content = new StringContent(ex.Message + "  " + ex.StackTrace, Encoding.UTF8, "text/plain");
                return _request;
            }
        }
    }
}

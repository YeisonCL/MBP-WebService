using MBP_Logic.Comunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP_WebService.Models.Errors
{
    public class DefaultErrors
    {
        public static ResponseObject<string> getInternalDefaultError()
        {
            ResponseObject<string> responseObject = new ResponseObject<string>();
            responseObject.setError(true);
            responseObject.setErrorMessage("Se ha producido un error interno en el sistema");
            return responseObject;
        }
    }
}
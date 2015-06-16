using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP_WebService.Models.JsonSerialize
{
    public class JSONSerialize
    {
        public static string serealizeJson(object pData)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(pData);
        }

        public static T deserealizeJson<T>(string pData)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<T>(pData);
        }
    }
}
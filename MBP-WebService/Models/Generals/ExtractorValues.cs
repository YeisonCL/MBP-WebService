using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBP_WebService.Models.Generals
{
    public class ExtractorValues
    {
        public static string getNickname(string pData)
        {
            string[] words = pData.Split(':');
            return words[0];
        }
        
        public static int getRoleType(string pData)
        {
            string[] words = pData.Split(':');
            return Convert.ToInt32(words[2]);
        }
    }
}
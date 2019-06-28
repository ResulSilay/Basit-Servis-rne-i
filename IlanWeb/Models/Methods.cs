using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IlanWeb.Models
{
    public class Methods
    {
        public static String SendRequest(string url, EnumHelper method, string jsonPostData = "")
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = method.ToString();
            String result = null;
            if (method == EnumHelper.POST)
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonPostData);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

                return result;
            }
            else
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                return result;
            }
        }
    }

    public enum EnumHelper
    {
        POST,
        GET,
        DELETE,
        PUT
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Request
{
    public class CMWebRequest:IRequest
    {
        private string requestUri;
        private string requesetMethod;
        private Dictionary<string, string> requesetData;
        private int requesetTimeout = 30;

        public CMWebRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            requestUri = uri;
            requesetData = data;
            requesetMethod = method;
            requesetTimeout = timeout;
        }

        public string Load()
        {
            string result = string.Empty;

            try
            {
                HttpWebRequest hwRequest = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                hwRequest.Timeout = requesetTimeout;
                hwRequest.Method = requesetMethod;
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                Stream myStream = hwResponse.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                result = strBuilder.ToString();
            }
            catch
            {
                //todo
            }

            return result;
        }


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Marsen.Core.Request
{
    public class BaseRequest:IRequest
    {
        private string requestUri;
        private string requesetMethod = "POST";
        private Dictionary<string, string> requesetData;
        private int requesetTimeout = 30;

        public BaseRequest() {

        }

        private BaseRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            requestUri = uri;
            requesetData = data;
            requesetMethod = method;
            requesetTimeout = timeout;
        }

        public static IRequest CreateRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            return new BaseRequest(uri, data, method, timeout);
        }

        internal virtual async Task<string> PostAsync() 
        {
            using (var client = new HttpClient())
            {
                var form = new FormUrlEncodedContent(requesetData);

                var response = await client.PostAsync(requestUri, form);
                //will throw an exception if not successful
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        internal virtual async Task<string> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var q = string.Empty;
                foreach (var data in requesetData)
                {
                    q += data.Key + "=" + data.Value;
                }
                var response = await client.GetAsync(requestUri+q);

                //will throw an exception if not successful
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }

        }

        

        public string Load()
        {
            if (requesetMethod == "GET")
            {
                return GetAsync().Result;
            }
            else 
            {
                return PostAsync().Result;
            }
        }
    }
}

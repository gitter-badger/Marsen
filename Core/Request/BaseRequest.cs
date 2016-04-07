using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marsen.Core.Request
{
    /// <summary>
    /// BaseRequest
    /// </summary>
    public class BaseRequest : IRequest
    {
        /// <summary>
        /// requestUri
        /// </summary>
        private string requestUri;

        /// <summary>
        /// requesetMethod
        /// </summary>
        private string requesetMethod = "POST";

        /// <summary>
        /// requesetData
        /// </summary>
        private Dictionary<string, string> requesetData;

        /// <summary>
        /// requesetTimeout
        /// </summary>
        private int requesetTimeout = 30;

        /// <summary>
        /// Initializes a new instance of the BaseRequest class.
        /// </summary>
        public BaseRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BaseRequest class.
        /// </summary>
        /// <param name="uri">uri</param>
        /// <param name="data">data</param>
        /// <param name="method">method</param>
        /// <param name="timeout">timeout</param>
        private BaseRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            this.requestUri = uri;
            this.requesetData = data;
            this.requesetMethod = method;
            this.requesetTimeout = timeout;
        }

        /// <summary>
        /// CreateRequest
        /// </summary>
        /// <param name="uri">uri</param>
        /// <param name="data">data</param>
        /// <param name="method">method</param>
        /// <param name="timeout">timeout</param>
        /// <returns>IRequest</returns>
        public static IRequest CreateRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            return new BaseRequest(uri, data, method, timeout);
        }

        /// <summary>
        /// 載入,發動Requeset,取得Response
        /// </summary>
        /// <returns>string</returns>
        public string Load()
        {
            if (this.requesetMethod == "GET")
            {
                return this.GetAsync().Result;
            }
            else
            {
                return this.PostAsync().Result;
            }
        }

        /// <summary>
        /// Async Request by Method  Post
        /// </summary>
        /// <returns>Task<string></returns>
        internal virtual async Task<string> PostAsync()
        {
            using (var client = new HttpClient())
            {
                var form = new FormUrlEncodedContent(this.requesetData);

                var response = await client.PostAsync(this.requestUri, form);
                ////will throw an exception if not successful
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        /// <summary>
        /// Async Request by Method Get
        /// </summary>
        /// <returns>Task<string></returns>
        internal virtual async Task<string> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var q = string.Empty;
                foreach (var data in this.requesetData)
                {
                    q += data.Key + "=" + data.Value;
                }

                var response = await client.GetAsync(this.requestUri + q);

                ////will throw an exception if not successful
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}
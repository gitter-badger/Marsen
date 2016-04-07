using System.Collections.Generic;

namespace Marsen.Core.Request
{
    /// <summary>
    /// RequsetFactory
    /// </summary>
    public class RequsetFactory
    {
        /// <summary>
        /// GetRequest
        /// </summary>
        /// <param name="uri">uri</param>
        /// <param name="data">data</param>
        /// <param name="method">method</param>
        /// <param name="timeout">timeout</param>
        /// <returns>IRequest</returns>
        public static IRequest GetRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            //// if some logical
            return BaseRequest.CreateRequest(uri, data, method, timeout);
        }
    }
}
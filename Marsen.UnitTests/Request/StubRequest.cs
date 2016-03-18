using System.Collections.Generic;
using System.Threading.Tasks;
using Marsen.Core.Request;

namespace Marsen.Core.Tests.Request
{
    public class StubRequest : BaseRequest
    {
        public StubRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30) : base(uri, data, method, timeout)
        { }

        internal override async Task<string> PostAsync()
        {
            return null;
        }

        internal override async Task<string> GetAsync()
        {
            return null;
        }
    }
}
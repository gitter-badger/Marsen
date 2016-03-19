using System.Collections.Generic;
using System.Threading.Tasks;
using Marsen.Core.Request;

namespace Marsen.Core.Tests.Request
{
    public class StubRequest : BaseRequest
    {

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
using System.Collections.Generic;
using System.Threading.Tasks;
using Marsen.Core.Request;

namespace Marsen.Core.Tests.Request
{
    public class StubBaseRequest : BaseRequest
    {

        #pragma warning disable CS1998 // Async 方法缺乏 'await' 運算子，將同步執行
        internal override async Task<string> PostAsync()
        #pragma warning restore CS1998 // Async 方法缺乏 'await' 運算子，將同步執行
        {
            return null;
        }

        #pragma warning disable CS1998 // Async 方法缺乏 'await' 運算子，將同步執行
        internal override async Task<string> GetAsync()
        #pragma warning restore CS1998 // Async 方法缺乏 'await' 運算子，將同步執行
        {
            return null;
        }
    }
}
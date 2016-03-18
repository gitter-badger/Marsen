using System;
using Marsen.Core.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;

namespace Marsen.Core.Tests
{
    [TestClass]
    public class RequestTest
    {
        [TestMethod]
        public void 呼叫Request_Load後執行方法為Post的Request()
        {
            ////arrage
            string uri = "http://mockapi.marsen";
            var data = new Dictionary<string, string>();
            StubRequest target = Substitute.For<StubRequest>(uri, data, "POST", 30);
            ////act
            target.Load();
            ////assert
            target.Received().PostAsync();
        }

        [TestMethod]
        public void 呼叫Request_Load後執行方法為Get的Request()


        {
            ////arrage
            string uri = "http://mockapi.marsen";
            var data = new Dictionary<string, string>();
            StubRequest target = Substitute.For<StubRequest>(uri, data,"GET",30);
            ////act
            target.Load();
            ////assert
            target.Received().GetAsync();
        }
    }
    public class StubRequest : BaseRequest
    {
        public StubRequest(string uri ,Dictionary<string,string> data, string method = "POST", int timeout = 30) : base(uri, data , method , timeout)
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

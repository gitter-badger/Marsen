using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Marsen.Core.Tests.Request
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
            StubRequest target = Substitute.For<StubRequest>(uri, data, "GET", 30);
            ////act
            target.Load();
            ////assert
            target.Received().GetAsync();
        }
    }
}
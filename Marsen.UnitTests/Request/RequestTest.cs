using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Marsen.Core.Tests.Request
{
    [TestClass]
    public class RequestTest
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void 呼叫Request_Load後執行方法為Post的Request()
        {
            ////arrage
            var data = new Dictionary<string, string>();
            StubBaseRequest target = Substitute.For<StubBaseRequest>();
            ////act
            target.Load();
            ////assert
            #pragma warning disable CS4014 // 因為未等待此呼叫，所以在完成呼叫之前會繼續執行目前方法
            target.Received().PostAsync();
            #pragma warning restore CS4014 // 因為未等待此呼叫，所以在完成呼叫之前會繼續執行目前方法
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        public void 呼叫Request_Load後執行方法為Get的Request()
        {
            ////arrage
            var data = new Dictionary<string, string>();
            StubBaseRequest target = Substitute.For<StubBaseRequest>();
            ////act
            target.Load();
            ////assert
            #pragma warning disable CS4014 // 因為未等待此呼叫，所以在完成呼叫之前會繼續執行目前方法
            target.Received().GetAsync();
            #pragma warning restore CS4014 // 因為未等待此呼叫，所以在完成呼叫之前會繼續執行目前方法
        }
    }
}
using System;
using Core.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Marsen.Tests.Request
{
    [TestClass]
    public class RequestTest
    {
        private IRequest reqTester;
        [TestMethod]
        public void TestPost()
        {
            var data  = new Dictionary<string, string>();
            //// Bing 僅是為了測用的URI，可以替換為其它的URI
            reqTester = new BaseRequest("http://www.bing.com/", data);
            var resonpse = reqTester.Load();
        }
        [TestMethod]
        public void TestGet()
        {
            var data = new Dictionary<string, string>();
            //// Bing 僅是為了測用的URI，可以替換為其它的URI
            reqTester = new BaseRequest("http://www.bing.com/", data, "GET");
            var resonpse = reqTester.Load();
        }
    }
}

using System;
using Core.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Marsen.UnitTests
{
    [TestClass]
    public class RequestTest
    {
        private IRequest reqTester;
        [TestMethod]
        public void TestPost()
        {
            var data  = new Dictionary<string, string>();

            reqTester = new BaseRequest("http://www.google.com", data);
            var resonpse = reqTester.Load();
        }
        [TestMethod]
        public void TestGet()
        {
            var data = new Dictionary<string, string>();

            reqTester = new BaseRequest("http://www.google.com", data,"GET");
            var resonpse = reqTester.Load();
        }
    }
}

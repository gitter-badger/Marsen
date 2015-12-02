using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marsen.Utility.Core.Log;

namespace Marsen.UnitTests
{
    [TestClass]
    public class LogTest
    {
        private ILog logTester;
        [TestMethod]
        public void TestMethod1()
        {
            logTester = new FileLogger();
            logTester.Log("test");
        }
    }
}

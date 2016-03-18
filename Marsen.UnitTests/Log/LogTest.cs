using System;
using Core.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marsen.Core.Tests
{
    [TestClass]
    public class LogTest
    {
        private ILog logTester;
        [TestMethod]

        public void TestLog()
        {
            logTester = new FileLogger();
            logTester.Log("test");
        }

        [TestMethod]
        public void TestLogWithPath()
        {
            logTester = new FileLogger();
            logTester.Log("test",@"C:\");
        }
    }
}

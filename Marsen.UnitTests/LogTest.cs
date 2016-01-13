using System;
using Core.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Marsen.UnitTests
{
    [TestClass]
    public class LogTest
    {
        private ILog logTester;
        [TestMethod]
        public void TestFileLog()
        {
            logTester = new FileLogger();
            logTester.Log("test");
        }
    }
}

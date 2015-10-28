using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marsen.Utility.Core.Log;

namespace Marsen.UnitTests
{
    [TestClass]
    public class LogTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ILog tester = new Logger();
            tester.Log("test");
        }
    }
}

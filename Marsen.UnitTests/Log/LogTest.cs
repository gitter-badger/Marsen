using System;
using System.IO;
using Core.Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Marsen.Core.Tests
{
    [TestClass]
    public class LogTest
    {
        private string logPath = Environment.CurrentDirectory + "\\logtest";

        [TestInitialize()]
        public void Startup()
        {
            DeleteDirectory();
            Directory.CreateDirectory(logPath);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            DeleteDirectory();
        }

        private void DeleteDirectory()
        {
            if (Directory.Exists(logPath))
            {
                Directory.Delete(logPath,true);
            }
        }

        [TestMethod]
        [TestCategory("整合測試")]
        public void 呼叫FileLogger_Log方法後_檢查產生的LOG是否正確()
        {
            ////arrange
            var target = new StubFileLogger();
            string message = "測試LOG";
            logPath = Environment.CurrentDirectory + "\\logtest";
            var now = DateTime.Now;
            var filePath = string.Format("{0}\\{1}", logPath, now.ToString("yyyyMMddHH"));
            target.SetNow(now);
            var expected = string.Format("[{0}] - {1}", now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            ////act
            target.Log(message, logPath);


            ////assert
            string actual;
            using (StreamReader sr = new StreamReader(filePath))
            {
                actual = sr.ReadToEnd().Replace(Environment.NewLine,string.Empty);
            }
            Assert.AreEqual(expected, actual);
        }

    }

    public class StubFileLogger : FileLogger
    {
        private DateTime now;

        internal void SetNow(DateTime time)
        {
            now = time; 
        }

        protected override DateTime GetNow()
        {
            return now;   
        }
    }
} 
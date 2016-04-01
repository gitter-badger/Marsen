using System;
using System.IO;
using System.Text;

namespace Core.Log
{
    public class FileLogger : ILog
    {    
        private string logPath;
        private string filePath;

        public void Log(string message)
        {
            DateTime now = GetNow();
            var logMessage = string.Format("[{0}] - {1}", now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            filePath = string.Format("{0}\\{1}", logPath, now.ToString("yyyyMMddHH"));
            CheckPath(logPath);
            Write(logMessage);
        }

        protected virtual DateTime GetNow()
        {
            return DateTime.Now;
        }


        public void Log(string message, string savePath)
        {
            logPath = string.Format("{0}", savePath);
            Log(message);
        }

        private void CheckPath(string logPath)
        {
            if (Directory.Exists(logPath) == false)
            {
                Directory.CreateDirectory(logPath);
            }
        }

        private void Write(string message)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(message);
                sw.Flush();
            }
        }
    }
}

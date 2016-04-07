using System;
using System.IO;

namespace Core.Log
{
    /// <summary>
    /// FileLogger
    /// </summary>
    public class FileLogger : ILog
    {
        /// <summary>
        /// 資料夾路徑
        /// </summary>
        private string logPath;

        /// <summary>
        /// 檔案路徑
        /// </summary>
        private string filePath;

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="message">message</param>
        public void Log(string message)
        {
            DateTime now = this.GetNow();
            var logMessage = string.Format("[{0}] - {1}", now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            this.filePath = string.Format("{0}\\{1}", this.logPath, now.ToString("yyyyMMddHH"));
            this.CheckPath(this.logPath);
            this.Write(logMessage);
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="savePath">savePath</param>
        public void Log(string message, string savePath)
        {
            this.logPath = string.Format("{0}", savePath);
            this.Log(message);
        }

        /// <summary>
        /// GetNow
        /// </summary>
        /// <returns>DateTime</returns>
        protected virtual DateTime GetNow()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// CheckPath
        /// </summary>
        /// <param name="logPath">logPath</param>
        private void CheckPath(string logPath)
        {
            if (Directory.Exists(logPath) == false)
            {
                Directory.CreateDirectory(logPath);
            }
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="message">message</param>
        private void Write(string message)
        {
            using (StreamWriter sw = File.AppendText(this.filePath))
            {
                sw.WriteLine(message);
                sw.Flush();
            }
        }
    }
}
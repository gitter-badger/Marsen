using System;
using System.IO;

namespace Core.Log
{
    public class FileLogger : ILog
    {    
        private string logPath = System.Environment.CurrentDirectory + "\\log";
        public bool Log(string message)
        {
            var result = false ;
            try
            {
                if (Directory.Exists(logPath) == false)
                {
                    Directory.CreateDirectory(logPath);
                }
                var filePath = string.Format("{0}\\{1}",logPath,DateTime.Now.ToString("yyyyMMddHH"));
                
                if (File.Exists(filePath) == false)
                {
                    File.Create(filePath);                    
                }
                File.AppendAllLines(filePath, new string[] { string.Format("[{0}] - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message) });

                result = true;
            }
            catch
            {
                
                result = false;
            }
            
            return result;
        }

        public bool Log(string message, string savePath)
        {
 	        throw new NotImplementedException();
        }
    }
}

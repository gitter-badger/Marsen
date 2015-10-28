using System;
using System.IO;

namespace Marsen.Utility.Core.Log
{
    public class Logger :ILog
    {    
        private string logPath = System.Environment.CurrentDirectory;
        public bool Log(string message)
        {
            var result = false ;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(logPath);
                File.AppendAllLines(logPath, new string[] { message });

                result = true;
            }
            catch (Exception)
            {                
                throw;
            }
            
            return result;
        }

        public bool Log(string message, string savePath)
        {
 	        throw new NotImplementedException();
        }
    }
}

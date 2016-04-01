namespace Core.Log
{
    /// <summary>
    /// Log介面
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 記錄Log
        /// </summary>
        /// <param name="message">Log訊息</param>
        /// <returns></returns>
        void Log(string message);
    }
}

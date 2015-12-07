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
        bool Log(string message);
        /// <summary>
        /// 記錄Log至指定路徑
        /// </summary>
        /// <param name="message">Log訊息</param>
        /// <param name="savePath">Log存檔路徑</param>
        /// <returns></returns>
        bool Log(string message,string savePath);
    }
}

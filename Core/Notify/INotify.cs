namespace Marsen.Core.Notify
{
    /// <summary>
    /// INotify interface
    /// </summary>
    public interface INotify
    {
        /// <summary>
        /// Send Notify
        /// </summary>
        /// <param name="message">message</param>
        void Send(string message);
    }
}
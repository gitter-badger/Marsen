using System.Collections.Generic;
using Marsen.Core.Request;

namespace Marsen.Core.Notify
{
    /// <summary>
    /// SlackNotify
    /// </summary>
    public class SlackNotify : INotify
    {
        /// <summary>
        /// slack api
        /// </summary>
        private const string API = "https://slack.com/api/chat.postMessage";

        /// <summary>
        /// Request
        /// </summary>
        private IRequest request;

        /// <summary>
        /// postData
        /// </summary>
        private Dictionary<string, string> postData = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the SlackNotify class.
        /// </summary>
        /// <param name="request">request</param>
        public SlackNotify(IRequest request)
        {
            this.request = request;
        }

        /// <summary>
        /// CreateNotify
        /// </summary>
        /// <param name="token">slack token</param>
        /// <param name="channel">channel</param>
        /// <param name="username">username</param>
        /// <returns>INotify Object</returns>
        public INotify CreateNotify(string token, string channel, string username)
        {
            this.postData.Add("token", token);
            this.postData.Add("channel", "#" + channel);
            this.postData.Add("username", username);
            this.request = RequsetFactory.GetRequest(API, this.postData);
            return new SlackNotify(this.request);
        }

        /// <summary>
        /// Send Messages to Notify
        /// </summary>
        /// <param name="text">text</param>
        public void Send(string text)
        {
            this.postData.Add("text", text);
            this.request.Load();
        }
    }
}
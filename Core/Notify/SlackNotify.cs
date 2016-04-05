using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marsen.Core.Request;

namespace Marsen.Core.Notify
{
    /// <summary>
    /// SlackNotify
    /// </summary>
    public class SlackNotify : INotify
    {
        private IRequest _request;
        private Dictionary<string,string> _postData = new Dictionary<string, string>();
        private const string _api = "https://slack.com/api/chat.postMessage";

        public SlackNotify(IRequest request)
        {
            _request = request;
        }


        public INotify CreateNotify(string token,string channel,string username)
        {
 
            _postData.Add("token", token);
            _postData.Add("channel", "#" + channel);
            _postData.Add("username", username);            
            _request = RequsetFactory.GetRequest(_api,_postData);
            return new SlackNotify(_request);
        }


        /// <summary>
        /// Send
        /// </summary>
        /// <param name="text">text</param>
        public void Send(string text)
        {
            _postData.Add("text", text);
            _request.Load();
        }
    }
}

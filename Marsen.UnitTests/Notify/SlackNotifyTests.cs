using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marsen.Core.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marsen.Core.Request;
using NSubstitute;

namespace Marsen.Core.Notify.Tests
{
    [TestClass()]
    public class SlackNotifyTests
    {
        [TestMethod()]
        [TestCategory("Unit Test")]
        public void 呼叫SlackNotify_Send後應該執行Request_Load()
        {
            ////arrange
            var req = Substitute.For<IRequest>();
            var target = new SlackNotify(req);
            ////act
            target.Send("test notify");
            ////assert
            req.Received().Load();
        }

    }
}
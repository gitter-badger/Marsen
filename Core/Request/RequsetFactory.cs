﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marsen.Core.Request;

namespace Marsen.Core.Request
{
    public class RequsetFactory
    {
        public static IRequest GetRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            //// if some logical
            return BaseRequest.CreateRequest(uri, data, method, timeout);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Core.Request
{
    class BaseRequest:IRequest
    {
        private string requestUri;
        private string requesetMethod;
        private Dictionary<string, string> requesetData;
        private int requesetTimeout = 30;

        public BaseRequest(string uri, Dictionary<string, string> data, string method = "POST", int timeout = 30)
        {
            requestUri = uri;
            requesetData = data;
            requesetMethod = method;
            requesetTimeout = timeout;
        }

        private async Task<string> PostAsync() 
        {
            using (var client = new HttpClient())
            {
                var form = new FormUrlEncodedContent(requesetData);

                var response = await client.PostAsync(requestUri, form);
                                //will throw an exception if not successful
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        private async Task<string> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(requestUri);

                //will throw an exception if not successful
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }

        }

        

        public string Load()
        {
            if (requesetMethod == "GET")
            {
                return GetAsync().Result;
            }
            else 
            {
                return PostAsync().Result;
            }
        }
    }
}
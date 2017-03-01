﻿using System;
using System.Net;
using TrustchainCore.Configuration;
using TrustchainCore.Extensions;

namespace TrustchainCore.Service
{
    public class WebService
    {
        public static TimeSpan Timeout;

        static WebService()
        {
            Timeout = new TimeSpan(0, 0, App.Config["webservicetimeout"].ToInteger(60));
        }

        public string UploadString(Uri url, string data)
        {
            using (var client = new WebClient())
            {
                var task = client.UploadStringTaskAsync(url, data);
                task.Wait(Timeout);
                if (task.IsCompleted)
                    return task.Result;

                if (task.Exception != null)
                    throw task.Exception;

                throw new ApplicationException("Call to " + url.AbsoluteUri + " timed out!");
            }

        }

        public string DownloadString(Uri url)
        {
            using (var client = new WebClient())
            {
                var task = client.DownloadStringTaskAsync(url);
                task.Wait(Timeout);
                if (task.IsCompleted)
                    return task.Result;

                if (task.Exception != null)
                    throw task.Exception;

                throw new ApplicationException("Call to " + url.AbsoluteUri + " timed out!");
            }
        }

    }
}

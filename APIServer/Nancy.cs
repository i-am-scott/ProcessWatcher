using Nancy;
using Nancy.Hosting.Self;
using Nancy.Security;
using ProcessWatcher.Classes;
using System;
using System.Collections.Generic;

namespace ProcessWatcher.APIServer
{
    class Nancy
    {
        public static NancyHost Start()
        {
            HostConfiguration hostconfig = new HostConfiguration()
            {
                RewriteLocalhost = true,
                AllowAuthorityFallback = true,
                UrlReservations = new UrlReservations()
                {
                    CreateAutomatically = true
                }
            };

            StaticConfiguration.DisableErrorTraces = false;
            StaticConfiguration.CaseSensitive = false;

            NancyHost host = new NancyHost(hostconfig, new Uri("http://127.0.0.1:80/"));
            host.Start();

            util.Log("Nancy Self-host started!");
            return host;
        }
    }

    public class RegisteredUser : IUserIdentity
    {
        public string username;
        public string steamid;
        public string ip;
        public string apikey;

        public string UserName => username;
        public IEnumerable<string> Claims => new List<string>() {
            username,
            steamid
        };
    }

}
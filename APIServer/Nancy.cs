using Nancy.Hosting.Self;
using ProcessWatcher.Classes;
using System;

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

            NancyHost host = new NancyHost(hostconfig, new Uri("http://127.0.0.1:6969"));
            host.Start();

            util.Log("Nancy Self-host started!");
            return host;
        }
    }
}
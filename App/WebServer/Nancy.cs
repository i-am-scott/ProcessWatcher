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
                RewriteLocalhost = false,
                AllowAuthorityFallback = true,
                UrlReservations = new UrlReservations()
                {
                    CreateAutomatically = true
                }
            };

            Uri[] uriAddresses = new Uri[] {
                new Uri(App.Cfg.Web.BindAddressHTTP),
                new Uri(App.Cfg.Web.BindAddressHTTPS)
            };

            NancyHost host = new NancyHost(new NancyBoostrap(), hostconfig, uriAddresses);
            host.Start();

            util.Log("Nancy Self-host started!");
            return host;
        }
    }
}
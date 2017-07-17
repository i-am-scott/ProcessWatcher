using Nancy;
using System.Threading.Tasks;
using System.Threading;
using Nancy.Authentication.Stateless;
using Nancy.Security;
using ProcessWatcher.Process;
using Newtonsoft.Json;

namespace ProcessWatcher.APIServer
{
    public class Routing : NancyModule
    {
        public Routing()
        {
            this.RequiresAuthentication();
            StatelessAuthentication.Enable(this, new StatelessAuthenticationConfiguration(ValidateKey));

            // Views
            Get["/"] = MainPage;
            Get["/servers", true] = GetServers;
            Get["server/{serverid:int}", true] = GetServer;
            Get["/stats", true] = GetStats;

            // Stop, Start, Restart and change some settings
            Post["/server/{id}", true] =  ManageServer;
            Post["/settings", true] = ManageSettings;
        }

        private IUserIdentity ValidateKey(NancyContext ctx)
        {
            if (!ctx.Request.Query.api.HasValue)
                return null;

            /*
             *Generated at run time from a json 
             *file when the settings page is complete.
            */
            return new RegisteredUser()
            {
                username = "Temp User",
                steamid = "STEAM_0:1:26675200",
                ip = "127.0.0.1"
            };
        }

        private string MainPage(dynamic parameters)
            => JsonConvert.SerializeObject(ServerFactory.servers);
        private async Task<dynamic> GetServers(dynamic parameters, CancellationToken ct)
            => JsonConvert.SerializeObject(ServerFactory.servers);
        private async Task<dynamic> GetServer(dynamic parameters, CancellationToken ct)
            => "Not Implemented";
        private async Task<dynamic> GetStats(dynamic parameters, CancellationToken ct)
            => "Not Implemented";
        private async Task<dynamic> ManageServer(dynamic parameters, CancellationToken ct)
            => "Not Implemented";
        private async Task<dynamic> ManageSettings(dynamic parameters, CancellationToken ct)
            => "Not Implemented";
    }

}
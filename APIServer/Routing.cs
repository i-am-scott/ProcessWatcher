using Nancy;
using System.Threading.Tasks;
using System.Threading;
using ProcessWatcher.Process;
using Newtonsoft.Json;

namespace ProcessWatcher.APIServer
{
    public class Routing : NancyModule
    {
        public Routing()
        {
            // Views
            Get("/", MainPage);
            Get("/servers", GetServers);
            Get("server/{serverid:int}", GetServer);
            Get("/stats", GetStats);

            Post("/server/{id}", ManageServer);
            Post("/settings", ManageSettings);
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
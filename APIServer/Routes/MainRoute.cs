using Nancy;
using System.Threading.Tasks;
using System.Threading;
using ProcessWatcher.Process;
using Newtonsoft.Json;
using Nancy.Responses.Negotiation;
using ProcessWatcher.APIServer.Models;
using System.ComponentModel;

namespace ProcessWatcher.APIServer
{
    public class JSONResponse
    {
        public SystemInformation SystemInfo = new SystemInformation();
        public BindingList<ProcessContainer> Servers;
    }

    public class JSONContainer
    {
        public bool Status { get => Response != null; protected set { } }
        public string StatusMessage;
        public JSONResponse Response;

        public JSONContainer(JSONResponse obj)
        {
            Response = obj;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Routing : NancyModule
    {
        public Routing()
        {
            Get("/", MainPage);
            Get("/servers", GetServers);
            Get("/server/{serverid:int}", GetServer);
            Get("/stats", GetStats);

            Post("/server/{id}", ManageServer);
            Post("/settings", ManageSettings);
        }

        private Negotiator MainPage(dynamic parameters)
        {
            return View[new ViewModel()];
        }

        private Response GetServers(dynamic parameters)
           => Response.AsJson(new JSONContainer(new JSONResponse{ 
               Servers = ServerFactory.servers
           }));

        private async Task<dynamic> GetServer(dynamic parameters)
           => Response.AsJson(new JSONContainer(new JSONResponse{
               Servers = ServerFactory.servers
           }));

        private async Task<dynamic> GetStats(dynamic parameters, CancellationToken ct)
            => "Not Implemented";

        private async Task<dynamic> ManageServer(dynamic parameters, CancellationToken ct)
            => "Not Implemented";

        private async Task<dynamic> ManageSettings(dynamic parameters, CancellationToken ct)
            => "Not Implemented";
    }

}
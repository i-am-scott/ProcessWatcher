using Nancy;
using Nancy.Cryptography;
using Newtonsoft.Json;
using ProcessWatcher.Process;
using ProcessWatcher.Steam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessWatcher.APIServer
{
    public class JSONResponse
    {
        public SystemInformation SystemInfo = new SystemInformation();
        public SteamUser SteamSession;
        public List<ProcessContainer> Servers;
    }

    public class JSONContainer
    {
        public bool Status { get => Response != null; protected set { } }
        public string StatusMessage;
        public JSONResponse Response;

        public JSONContainer(JSONResponse obj = null)
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
            Get("/login", Login);
            Get("/logout", Logout);
            Get("/servers", GetServers);
            Get("/server/{id}", ManageServer);
        }

        private dynamic MainPage(dynamic parameters)
        {
            if (Session["state"] == null)
                Session["state"] = CryptographyConfiguration.Default.EncryptionProvider.Encrypt(DateTime.Now.ToLongDateString() + (new Random()).Next(1, 123124));

            if (Session["steam"] == null)
                return View["Login.html"];
            else
                return View[new ViewModel() { SteamSession = Session["steam"] as SteamUser }];
        }

        private Response GetServers(dynamic parameters)
        {
            if (Session["steam"] == null)
                return Response.AsJson(new JSONContainer
                {
                    StatusMessage = "You are not logged in or whitelisted."
                });

            return Response.AsJson(new JSONContainer(new JSONResponse
            {
                SteamSession = Session["steam"] as SteamUser,
                Servers = ServerFactory.servers.Where(p => p.Options["UseWeb"] != null).ToList()
            }));
        }

        private async Task<Response> Login(dynamic parameters)
        {
            if (Session["steam"] == null && Request.Query["openid.return_to"] == null)
                return Response.AsRedirect(SteamLogin.BuildLoginQuery(App.Cfg.Steam));

            SteamLogin steam = new SteamLogin(App.Cfg.Steam);
            await steam.ValidateToken(Request);

            SteamUser user = await steam.GetUser();
            if (user != null)
            {
                Session["steam"] = user;
            }

            return Response.AsRedirect("/");
        }

        private Response Logout(dynamic parameters)
        {
            Session.DeleteAll();
            return Response.AsRedirect("/");
        }

        private Response ManageServer(dynamic parameters)
        {
            if (Session["steam"] == null)
                return Response.AsJson(new JSONContainer
                {
                    StatusMessage = "You are not logged in or whitelisted."
                });

            var process = ServerFactory.servers[(int)parameters.id];
            if(process.IsRunning)
                process.CloseProcess();
            else
                process.CreateProcess();

            return Response.AsJson(new JSONContainer()
            {
                StatusMessage = "Completed Action"
            });
        }

    }
}
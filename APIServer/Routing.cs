using Nancy;

namespace ProcessWatcher.APIServer
{
    public class Routing : NancyModule
    {
        // TODO: Don't forget some kind of authentication! (steam somehow?)
        public Routing()
        {
            // Display available routes
            Get["/"] = MainPage;

            // Controls
            Get["/servers"] = GetServers;
            Get["/server"] = GetServer;
            Get["/stats"] = GetStats;

            Post["/server"] = ManageServer;
            Post["/settings"] = ManageSettings;
        }

        public string MainPage(dynamic parameters) => "Not Implemented";
        public string GetServers(dynamic parameters) => "Not Implemented";
        public string GetServer(dynamic parameters) => "Not Implemented";
        public string GetStats(dynamic parameters) => "Not Implemented";
        public string ManageServer(dynamic parameters) => "Not Implemented";
        public string ManageSettings(dynamic parameters) => "Not Implemented";
    }

}
using Nancy;

namespace ProcessWatcher.APIServer
{
    public class Routing : NancyModule
    {
        public Routing()
        {
            Get["/test"] = MainPage;
        }

        public string MainPage(dynamic parameters)
        {
            return "Self hosted webserver!";
        }
    }

}
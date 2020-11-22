using Newtonsoft.Json;
using System.IO;

namespace ProcessWatcher
{
    public class WebServerConfig
    {
        public string BindAddressHTTP;
        public string BindAddressHTTPS;
        public bool DebugMode = false;
        public bool Enabled = true;
    }

    public class SteamConfig
    {
        public string API;
        public string OAuthReturn;
        public string OAuthUri;
    }

    public class Config
    {
        public static string ConfigFile = "config.json";

        public static bool EnabledWebserver = false;
        public static bool EnabledMail = false;

        public WebServerConfig Web = new WebServerConfig();
        public SteamConfig Steam = new SteamConfig();

        public static Config Load()
        {
            Config cfg;

            if (File.Exists(ConfigFile))
            {
                cfg = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFile));
            }
            else
            {
                cfg = new Config();
                File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(cfg, Formatting.Indented));
            }

            return cfg;
        }
    }
}
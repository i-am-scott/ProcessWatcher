using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessWatcher.Process
{
    public static class ServerFactory
    {
        public static List<ProcessContainer> servers = new List<ProcessContainer>();

        public delegate void ProcessContainerEventHandler(ProcessContainer proc);
        public delegate void ProcessContainerIdEventHandler(int id);

        public static event ProcessContainerEventHandler OnServerAdded;
        public static event ProcessContainerIdEventHandler OnServerRemoved;

        public static ProcessContainer Create(string name, string path, Dictionary<string, dynamic> options = null)
        {
            var proc = new ProcessContainer(name, path, options);
            servers.Add(proc);

            OnServerAdded?.Invoke(proc);
            return proc;
        }

        public static void Remove(int id)
        {
            var proc = Get(id);
            if (proc == null)
                return;

            proc.CloseProcess();
            proc = null;

            OnServerRemoved?.Invoke(id);
        }

        public static ProcessContainer Get(int id)
            => servers.Count == 0 ? null :
                servers.Where(p => p.ProcessId == id).First();

        public static void Save()
        {
            try
            {
                var data = JsonConvert.SerializeObject(servers);
                File.WriteAllText("settings.json", data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ServerFactory.Load Error");
            }
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists("servers.json"))
                {
                    File.Create("servers.json").Close();
                    return;
                }

                var data = File.ReadAllText("servers.json");
                if (string.IsNullOrEmpty(data))
                    return;

                servers = JsonConvert.DeserializeObject<List<ProcessContainer>>(data);

                if (OnServerAdded != null)
                {
                    foreach (var server in servers)
                        OnServerAdded(server);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ServerFactory.Load Error");
            }
        }
    }
}

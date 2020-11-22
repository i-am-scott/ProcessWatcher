using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessWatcher.Process
{
    public static class ServerFactory
    {
        public static BindingList<ProcessContainer> servers = new BindingList<ProcessContainer>();

        public delegate void ProcessContainerEventHandler(ProcessContainer proc);
        public delegate void ProcessContainerIdEventHandler(int id);

        public static event ProcessContainerEventHandler OnServerAdded;
        public static event ProcessContainerIdEventHandler OnServerRemoved;

        public static ProcessContainer Create(string name, string path, string pathParams, Dictionary<string, dynamic> options = null)
        {
            var proc = new ProcessContainer(name, path, pathParams, options);
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

            Save();
            OnServerRemoved?.Invoke(id);
        }

        public static void RemoveByName(string name)
        {
            var proc = Get(name);
            if (proc == null)
                return;

            proc.CloseProcess();
            proc = null;

            Save();
        }

        public static ProcessContainer Get(int id)
            => servers.Count == 0 ? null :
                servers.Where(p => p.ProcessId == id).First();
       
        public static ProcessContainer Get(string name)
            => servers.Count == 0 ? null :
                servers.Where(p => p.ProcName == name).First();

        public static void Save()
        {
            try
            {
                var data = JsonConvert.SerializeObject(servers);
                File.WriteAllText("servers.json", data);
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

                servers = JsonConvert.DeserializeObject<BindingList<ProcessContainer>>(data);

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

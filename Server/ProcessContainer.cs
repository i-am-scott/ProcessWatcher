using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProcessWatcher.Process
{

    public class ProcessContainer
    {
        public int id;

        public string name;
        public string path;
        public string target;
        public bool autostart = false;

        public Dictionary<string,dynamic> options;
        public int ProcessId;

        [JsonIgnore]
        public bool watching = false;

        protected System.Diagnostics.Process CurrentProc;
        protected int LastHearbeat;

        public ProcessContainer(string name, string path, Dictionary<string,dynamic> options = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            this.name     = name;
            this.path     = path;
            this.options  = options;

            options.TryGetValue("target", out dynamic _target);
            options.TryGetValue("autostart", out dynamic _autostart);

            target      = _target ?? "";
            autostart   = _autostart ?? false;

            if (autostart)
                CreateProcess();
        }

        public System.Diagnostics.Process CreateProcess()
        {
            CurrentProc = System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName    = path,
                Arguments   = target,
                ErrorDialog = false
            });

            watching  = true;
            ProcessId = CurrentProc.SessionId;
            return CurrentProc;
        }

        public System.Diagnostics.Process GetProcess()
        {
            if (CurrentProc == null || !CurrentProc.Responding)
            {
                ProcessId   = 0;
                CurrentProc = null;
                return null;
            }
            return CurrentProc;
        }

        public void CloseProcess()
        {
            watching = false;
            if (CurrentProc != null)
                CurrentProc.Close();
        }

        ~ProcessContainer()
            => CloseProcess();

        public void CheckStatus( bool restart = false )
        {
            if (watching)
            {
                if(GetProcess() == null && restart)
                {
                    CreateProcess();
                }
            }
        }
    }

    public static class ServerFactory
    {
        public static List<ProcessContainer> servers = new List<ProcessContainer>();

        public delegate void ProcessContainerEventHandler(ProcessContainer proc);
        public delegate void ProcessContainerIdEventHandler(int id);

        public static event ProcessContainerEventHandler OnServerAdded;
        public static event ProcessContainerIdEventHandler OnServerRemoved;

        public static ProcessContainer Create(string name, string path, Dictionary<string,dynamic> options = null)
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
            =>  servers.Count == 0 ? null : 
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
                var data = File.ReadAllText("settings.json");
                if (string.IsNullOrEmpty(data)) return;

                servers = JsonConvert.DeserializeObject<List<ProcessContainer>>(data);

                if (OnServerAdded != null)
                { 
                    foreach (var server in servers)
                        OnServerAdded(server);
                }
            }
            catch ( Exception e )
            {
                MessageBox.Show(e.Message, "ServerFactory.Load Error");
            }
        }
    }

}

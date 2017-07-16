using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

}

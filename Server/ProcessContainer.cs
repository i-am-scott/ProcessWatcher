using Newtonsoft.Json;
using ProcessWatcher.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ProcessWatcher.Process
{
    public class ProcessContainer
    {
        public string name;
        public string path;

        [JsonIgnore]
        public string target;

        [JsonIgnore]
        public bool autostart = false;

        [JsonIgnore]
        public bool staging = false;

        [JsonIgnore]
        public int startcounter = 0;
        public long startdelay = 0;

        [JsonIgnore]
        public bool watching = false;

        public int processid{
            get
            {
                return CurrentProc?.Id ?? 0;
            }
        }

        protected System.Diagnostics.Process CurrentProc;
        protected int LastHearbeat;

        // [JsonIgnore]
        public long MemoryUsage;

        // [JsonIgnore]
        public float CPUUsage;

        public Dictionary<string, dynamic> options;

        public ProcessContainer(string name, string path, Dictionary<string,dynamic> options = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            this.name = name;
            this.path = path;
            this.options = options;

            options.TryGetValue("target", out dynamic _target);
            options.TryGetValue("autostart", out dynamic _autostart);
            options.TryGetValue("startdelay", out dynamic _startdelay);

            target = _target ?? "";
            autostart = _autostart ?? false;
            startdelay = _startdelay ?? 0;

            if (autostart)
                CreateProcess();
        }

        public System.Diagnostics.Process CreateProcess()
        {
            CloseProcess();

            CurrentProc = System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName    = path,
                Arguments   = target,
                ErrorDialog = false
            });

            CurrentProc.Exited += CurrentProc_Exited;
            CurrentProc.ErrorDataReceived += CurrentProc_ErrorDataReceived;

            watching  = true;
            return CurrentProc;
        }

        private void CurrentProc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            util.Log(e.Data);
        }

        private void CurrentProc_Exited(object sender, EventArgs e)
        {
            util.Log("Closed!");
        }

        public System.Diagnostics.Process GetProcess()
        {
            return CurrentProc;
        }

        public void CloseProcess()
        {
            watching = false;

            if (CurrentProc != null)
            {
                CurrentProc.Dispose();
                CurrentProc.Close();
            }

            CurrentProc = null;
        }

        ~ProcessContainer()
            => CloseProcess();

        // TODO: Actually check for crash cases.
        public bool IsUnresponsive()
        {
            bool unresponsive = false;
            try
            {
                if (CurrentProc == null)
                    return true;

                if (CurrentProc?.HasExited == true)
                    return true;

                if (CurrentProc?.Responding != true)
                    return true;
            }
            catch (Exception e)
            {
                watching = false;
                staging = false;
                startcounter = 0;

                util.Log(e.ToString());
            }
            return unresponsive;
        }

        public void PollStatus(bool restart = false)
        {
            if (!watching)
                return;

            if (!restart)
            {
                if(IsUnresponsive())
                {
                    watching = false;
                    CloseProcess();
                }
                return;
            }

            if (IsUnresponsive())
            {
                if(startdelay > 0)
                {
                    if(staging)
                    {
                        startcounter++;
                        if (startcounter >= startdelay)
                        {
                            CreateProcess();
                            startcounter = 0;
                            staging = false;
                        }
                    }
                    else
                    {
                        util.Log($"{name} is not responding!");
                        util.Log($"{name} is being staged for {startdelay} seconds.");
                        staging = true;
                        startcounter++;
                    }
                }
                else
                {
                    util.Log($"{name} is not responding!");
                    util.Log($"{name} is launching!");
                    CreateProcess();
                }
            }
            else
            {
                PollProcessInfo();
            }
        }

        public void PollProcessInfo()
        {
            if (GetProcess() == null || GetProcess().HasExited)
                return;

            try
            {
                PerformanceCounter memcounter = new PerformanceCounter("Process", "Working Set", GetProcess().ProcessName);
                PerformanceCounter cpucounter = new PerformanceCounter("Process", "% Processor Time", GetProcess().ProcessName);

                MemoryUsage = GetProcess().PrivateMemorySize64;
                CPUUsage = cpucounter.NextValue();
            }
            catch (Exception e)
            {
                util.Log(e.Message);
            }
        }
    }
}

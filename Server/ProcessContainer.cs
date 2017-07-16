using Newtonsoft.Json;
using System;
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

        [JsonIgnore]
        public bool staging = false;
        [JsonIgnore]
        public int startcounter = 0;
        public long startdelay = 0;

        public Dictionary<string,dynamic> options;
        public int ProcessId;

        [JsonIgnore]
        public bool watching = false;

        protected System.Diagnostics.Process CurrentProc;
        protected int LastHearbeat;

        [JsonIgnore]
        public long MemoryUsage;

        [JsonIgnore]
        public float CPUUsage;

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
            ProcessId = CurrentProc.SessionId;
            return CurrentProc;
        }

        private void CurrentProc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        private void CurrentProc_Exited(object sender, EventArgs e)
        {
            Console.WriteLine("Closed!");
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

            ProcessId = 0;
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

                Console.WriteLine(e);
            }
            return unresponsive;
        }

        public void PollStatus(bool restart = false)
        {
            Console.WriteLine("Polling...");

            if(!restart)
            {
                if(IsUnresponsive())
                {
                    watching = false;
                    CloseProcess();
                }
                return;
            }

            if (watching && IsUnresponsive())
            {
                Console.WriteLine("No responding!");

                if(startdelay > 0)
                {
                    Console.WriteLine("Waiting for {0} seconds!", startdelay - startcounter);

                    if(staging)
                    {
                        Console.WriteLine("Saged Process, keep counting!");
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
                        Console.WriteLine("Starting staging...");
                        staging = true;
                        startcounter++;
                    }
                }
                else
                {
                    CreateProcess();
                }
            }
        }

        public void PollProcessInfo()
        {
            if (GetProcess() == null)
                return;

            MemoryUsage = GetProcess().WorkingSet64;
            CPUUsage = new PerformanceCounter("Processor", "% Processor Time", GetProcess().ProcessName).NextValue();
        }

    }

}

using Newtonsoft.Json;
using ProcessWatcher.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace ProcessWatcher.Process
{
    public class ProcessContainer : INotifyPropertyChanged
    {
        [DisplayName("Name")]
        public string _ProcName { get; set; }
        public string ProcName { get { return _ProcName; } set { _ProcName = value; NotifyPropertyChanged("ProcName"); } }
        
        [JsonIgnore]
        private string _Path { get; set; }
        public string Path { get { return _Path; } set { _Path = value; NotifyPropertyChanged("Path"); } }

        [JsonIgnore]
        private string _UpTime = "00:00:00:00";
        public string UpTime { get { return _UpTime; }  set{_UpTime = value; NotifyPropertyChanged("UpTime");} }
        
        [JsonIgnore]
        private long _MemoryUsage = 0;
        public long MemoryUsage { get { return _MemoryUsage; } set { _MemoryUsage = value; NotifyPropertyChanged("MemoryUsage"); } }
        
        [JsonIgnore]
        private float _CPUUsage = 0;
        public float CPUUsage { get { return _CPUUsage; } set { _CPUUsage = value; NotifyPropertyChanged("CPUUsage"); } }

        [JsonIgnore]
        public string Target;

        [JsonIgnore] 
        public bool AutoStart = false;

        [JsonIgnore]
        public bool Staging = false;

        [JsonIgnore]
        public int startcounter = 0;
        public long StartDelay = 5;

        [JsonIgnore]
        public bool Watching = false;
        
        [JsonIgnore]
        public bool IsRunning { get => CurrentProc != null && !CurrentProc.HasExited; protected set { } }

        public int processid{
            get
            {
                return CurrentProc?.Id ?? 0;
            }
        }

        protected System.Diagnostics.Process CurrentProc;
        protected int LastHearbeat;
        public Dictionary<string, dynamic> options;

        public ProcessContainer(string name, string path, Dictionary<string,dynamic> options = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            this.ProcName = name;
            this.Path = path;
            this.options = options;

            options.TryGetValue("Target", out dynamic _target);
            options.TryGetValue("AutoStart", out dynamic _autostart);
            options.TryGetValue("StartDelay", out dynamic _startdelay);

            Target = _target ?? "";
            AutoStart = _autostart ?? false;
            StartDelay = _startdelay ?? 0;

            if (AutoStart)
                CreateProcess();
        }

        public System.Diagnostics.Process CreateProcess()
        {
            CloseProcess();

            CurrentProc = System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName    = Path,
                Arguments   = Target,
                ErrorDialog = false
            });

            CurrentProc.Exited += CurrentProc_Exited;
            CurrentProc.ErrorDataReceived += CurrentProc_ErrorDataReceived;

            Watching  = true;
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
            Watching = false;

            if (CurrentProc != null)
            {
                CurrentProc.Kill();
                CurrentProc.Close();
                CurrentProc.Dispose();
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
                Watching = false;
                Staging = false;
                startcounter = 0;

                util.Log(e.ToString());
            }
            return unresponsive;
        }

        public void PollStatus(bool restart = false)
        {
            if (!Watching)
                return;

            if (!restart)
            {
                if(IsUnresponsive())
                {
                    Watching = false;
                    CloseProcess();
                }
                return;
            }

            if (IsUnresponsive())
            {
                if(StartDelay > 0)
                {
                    if(Staging)
                    {
                        startcounter++;
                        if (startcounter >= StartDelay)
                        {
                            CreateProcess();
                            startcounter = 0;
                            Staging = false;
                        }
                    }
                    else
                    {
                        util.Log($"{ProcName} is not responding!");
                        util.Log($"{ProcName} is being staged for {StartDelay} seconds.");
                        Staging = true;
                        startcounter++;
                    }
                }
                else
                {
                    util.Log($"{ProcName} is not responding!");
                    util.Log($"{ProcName} is launching!");
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
            Console.WriteLine("Poll Process Info");

            var proc = GetProcess();
            if (proc == null || proc.HasExited || proc.ProcessName == null)
                return;

            try
            {
                UpTime = CurrentProc.TotalProcessorTime.ToString();

                PerformanceCounter memcounter = new PerformanceCounter("Process", "Working Set", proc.ProcessName);
                PerformanceCounter cpucounter = new PerformanceCounter("Process", "% Processor Time", proc.ProcessName);

                MemoryUsage = GetProcess().PrivateMemorySize64;
                CPUUsage = cpucounter.NextValue();

                Console.WriteLine(MemoryUsage);
                Console.WriteLine(CPUUsage);
            }
            catch (Exception e)
            {
                util.Log(e.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}

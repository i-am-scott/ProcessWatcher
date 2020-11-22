using Newtonsoft.Json;
using ProcessWatcher.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace ProcessWatcher.Process
{
    public class UsageHistory
    {
        public double UnixTime;
        public double cpu;
        public double ram;
    }

    public class ProcessContainer : INotifyPropertyChanged
    {
        [JsonIgnore]
        [DisplayName("Name")]
        public string _ProcName { get; set; }
        public string ProcName { get { return _ProcName; } set { _ProcName = value; NotifyPropertyChanged("ProcName"); } }

        [JsonIgnore]
        private string _Path { get; set; }
        public string Path { get { return _Path; } set { _Path = value; NotifyPropertyChanged("Path"); } }

        [JsonIgnore]
        public string ExecName { get { return System.IO.Path.GetFileName(Path); } set { } }

        [JsonIgnore]
        private string _UpTime = "00";
        public string UpTime { get { return _UpTime; } set { _UpTime = value; NotifyPropertyChanged("UpTime"); } }

        [JsonIgnore]
        private float _MemoryUsage = 0;
        public float MemoryUsage { get { return _MemoryUsage; } set { _MemoryUsage = value; NotifyPropertyChanged("MemoryUsage"); } }

        [JsonIgnore]
        private float _CPUUsage = 0;
        public float CPUUsage { get { return _CPUUsage; } set { _CPUUsage = value; NotifyPropertyChanged("CPUUsage"); } }

        [JsonIgnore]
        public List<UsageHistory> UsageHistory = new List<UsageHistory>();

        public string PathParams;
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

        [JsonIgnore]
        public string _StartStatus { get; set; } = "Start";

        [JsonIgnore]
        public string StartStatus { get { return _StartStatus; } set { _StartStatus = value; NotifyPropertyChanged("StartStatus"); } }

        public int ProcessId
        {
            get
            {
                return CurrentProc?.Id ?? 0;
            }
        }


        protected System.Diagnostics.Process CurrentProc;
        private PerformanceCounter MemCounter;
        private PerformanceCounter CpuCounter;

        protected int LastHearbeat;
        public Dictionary<string, dynamic> Options;

        public ProcessContainer(string name, string path, string pathParams, Dictionary<string, dynamic> options = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(path);

            ProcName = name;
            Path = path;
            PathParams = pathParams;
            Options = options;

            options.TryGetValue("StartDelay", out dynamic _startdelay);
            StartDelay = _startdelay ?? 0;

            if (AutoStart)
                CreateProcess();
        }

        public System.Diagnostics.Process CreateProcess()
        {
            CloseProcess();

            CurrentProc = System.Diagnostics.Process.Start(new ProcessStartInfo()
            {
                FileName = Path,
                Arguments = PathParams,
                ErrorDialog = false
            });

            CurrentProc.Exited += CurrentProc_Exited;
            CurrentProc.ErrorDataReceived += CurrentProc_ErrorDataReceived;

            MemCounter = new PerformanceCounter("Process", "Working Set", CurrentProc.PerformanceCounterInstanceName(), true);
            CpuCounter = new PerformanceCounter("Process", "% Processor Time", CurrentProc.PerformanceCounterInstanceName(), true);

            Watching = true;
            StartStatus = "Stop";
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
            StartStatus = "Start";

            if (CurrentProc != null)
            {
                if(!CurrentProc.HasExited)
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
                if (IsUnresponsive())
                {
                    Watching = false;
                    CloseProcess();
                }
                return;
            }

            if (IsUnresponsive())
            {
                if (StartDelay > 0)
                {
                    if (Staging)
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
            System.Diagnostics.Process proc = GetProcess();
            if (proc == null || proc.HasExited || proc.ProcessName == null)
                return;

            try
            {
                double SecondsSince = DateTime.UtcNow.Subtract(CurrentProc.StartTime).TotalSeconds;
                UpTime = SecondsSince.ToString();

                MemoryUsage = (MemCounter?.NextValue() ?? 0) / 1024 / 1024;
                CPUUsage = CpuCounter?.NextValue() ?? 0;

                double seconds = Math.Round((double)DateTimeOffset.UtcNow.ToUnixTimeSeconds(), 0);
                UsageHistory.Add(new UsageHistory
                {
                    UnixTime = seconds,
                    cpu = CPUUsage,
                    ram = MemoryUsage
                });

                if (UsageHistory.Count > 60)
                {
                    UsageHistory.RemoveAt(0);
                }
            }
            catch (Exception e)
            {
                util.Log(e.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}

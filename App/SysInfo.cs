using System.Runtime.InteropServices;

namespace ProcessWatcher
{
    public class SystemInformation
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        public long AvailableMemory
        {
            get
            {
                GetPhysicallyInstalledSystemMemory(out long totalMemory);
                return totalMemory / 1024;
            }
            private set { }
        }
    }

}

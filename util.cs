using System;
using System.IO;

namespace ProcessWatcher.Classes
{
    public static class util
    {
        public static void Log(dynamic dat)
        {
            dat = dat.ToString();
            DateTime date = DateTime.UtcNow;
            string data = $"[{date}] {dat}{Environment.NewLine}";

            File.AppendAllText("output.txt", data);

            #if DEBUG
                Console.Write(data);
            #endif
        }
    }
}
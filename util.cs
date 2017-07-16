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

            File.AppendAllText("output.txt", $"[{date}] {dat}{Environment.NewLine}");
            #if DEBUG
                Console.WriteLine(dat);
            #endif
        } 

    }
}
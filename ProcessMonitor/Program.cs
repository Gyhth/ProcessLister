using Process_Lister;
using System;
using System.IO;
using System.Threading;

namespace ProcessMonitor
{
    class Program
    {
        private static Writefile writeFile = new Writefile();
        static void Main(string[] args)
        {
            String binaryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProcessesBinary.bin";
            StringManipulation stringManip = new StringManipulation();
            if (File.Exists(binaryPath))
            {
                Boolean monitorProcess = true;
                while (monitorProcess)
                {
                    Monitor monitor = new Monitor();
                    monitor.Start(writeFile, binaryPath);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}

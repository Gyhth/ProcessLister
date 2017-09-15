using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Lister
{
    class Program
    {
        private static Writefile writeFile = new Writefile();
        static void Main(string[] args)
        {
            String binaryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProcessesBinary.bin";
            if (File.Exists(binaryPath))
            {
                File.Delete(binaryPath);
            }
            Process[] processlist = Process.GetProcesses();
            List<SerializedProcess> serializedProcessList = new List<SerializedProcess>();
            foreach (Process process in processlist)
            {
                SerializedProcess newSerializedProcess = new SerializedProcess();
                newSerializedProcess.Name = process.ProcessName;
                serializedProcessList.Add(newSerializedProcess);
            }
            writeFile.WriteToBinaryFile<List<SerializedProcess>>(binaryPath, serializedProcessList, false);
        }
    }
}

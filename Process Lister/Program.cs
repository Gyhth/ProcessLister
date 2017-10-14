using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Process_Lister
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
                File.Delete(binaryPath);
            }
            Process[] processlist = Process.GetProcesses();
            List<SerializedProcess> serializedProcessList = new List<SerializedProcess>();
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            foreach (Process process in processlist)
            {
                result = shaM.ComputeHash(stringManip.ToByteArray(process.ProcessName));
                SerializedProcess newSerializedProcess = new SerializedProcess();
                newSerializedProcess.Name = result.ToString();
                serializedProcessList.Add(newSerializedProcess);
            }
            writeFile.WriteToBinaryFile<List<SerializedProcess>>(binaryPath, serializedProcessList, false);
        }
    }
}




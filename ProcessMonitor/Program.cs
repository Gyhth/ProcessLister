using System;
using System.Collections.Generic;
using Process_Lister;
using System.Diagnostics;
using System.IO;

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
                List<SerializedProcess> readProcesses = new List<SerializedProcess>();
                readProcesses = writeFile.ReadFromBinaryFile<List<SerializedProcess>>(binaryPath);
                Process[] processlist = Process.GetProcesses();
                byte[] result;
                Encryption encryptionManager = new Encryption();
                StringManipulation stringManipulator = new StringManipulation();
                foreach (Process process in processlist)
                {
                    Boolean found = false;
                    result = encryptionManager.generateHash(process.ProcessName);
                    string processName = stringManipulator.ByteArrayToString(result);
                    SerializedProcess serializedProcess = new SerializedProcess();
                    serializedProcess.Name = processName;
                    int index = readProcesses.FindIndex(processList => processList.Name == serializedProcess.Name);
                    if (index > -1) { 
                        found = true;
                    }
                    if (!found)
                    {
                        Console.WriteLine(process.ProcessName);
                        process.Kill();
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
            Encryption encryptionManager = new Encryption();
            StringManipulation stringManipulator = new StringManipulation();
            foreach (Process process in processlist)
            {
                result = encryptionManager.generateHash(process.ProcessName);
                SerializedProcess newSerializedProcess = new SerializedProcess();
                newSerializedProcess.Name = stringManipulator.ByteArrayToString(result);
                serializedProcessList.Add(newSerializedProcess);
            }
            List<String> processList = new List<String>();
            addProcessesToList(processList);
            AddOthersToList(encryptionManager, stringManipulator, serializedProcessList, processList);
            writeFile.WriteToBinaryFile<List<SerializedProcess>>(binaryPath, serializedProcessList, false);
        }

        private static void AddOthersToList(Encryption encryptionManager, StringManipulation stringManipulator, List<SerializedProcess> serializedProcessList, List<String> otherProcesses)
        {
            byte[] result;
            foreach (String process in otherProcesses)
            {
                result = encryptionManager.generateHash("ProcessMonitor");
                SerializedProcess newSerializedProcess = new SerializedProcess();
                newSerializedProcess.Name = stringManipulator.ByteArrayToString(result);
                serializedProcessList.Add(newSerializedProcess);
            }

        }

        private static void addProcessesToList(List<String> processList)
        {
            processList.Add("Task Manager");
            processList.Add("ProcessMonitor");
        }
    }
}




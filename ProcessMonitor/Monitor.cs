using Process_Lister;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProcessMonitor
{
    class Monitor
    {
        public void Start(Writefile writeFile, string binaryPath)
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
                if (index > -1)
                {
                    found = true;
                }
                if (!found)
                {
                    process.Kill();
                }
            }
        }
   
    }
}

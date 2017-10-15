using Microsoft.VisualStudio.TestTools.UnitTesting;
using Process_Lister;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ProcessListerUnitTest
{
    [TestClass]
    public class WriteFileTests
    {
        private static Writefile writeFile = new Writefile();
        /// <summary>
        /// Tests the ability to write to file, and read from said file.
        /// Assets that the contents that come out of the file match the contents that went into the file.
        /// </summary>
        [TestMethod]
        public void Test_ReadAndWriteToBinaryFile()
        {
            SHA256 shaM = new SHA256Managed();
            StringManipulation stringManip = new StringManipulation();
            List<SerializedProcess> processes = new List<SerializedProcess>();
            SerializedProcess sprocess = new SerializedProcess();
            byte[] result;
            result = shaM.ComputeHash(stringManip.ToByteArray("Test 3"));
            Debug.WriteLine(result);
            Debug.WriteLine(stringManip.ByteArrayToString(result));
            sprocess.Name = stringManip.ByteArrayToString(result);
            processes.Add(sprocess);
            sprocess = new SerializedProcess();
            result = shaM.ComputeHash(stringManip.ToByteArray("Test 4"));
            sprocess.Name = stringManip.ByteArrayToString(result);
            processes.Add(sprocess);
            String binaryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProcessesBinary.bin";
            writeFile.WriteToBinaryFile<List<SerializedProcess>>(binaryPath, processes, false);
            List<SerializedProcess> readProcesses = new List<SerializedProcess>();
            readProcesses = writeFile.ReadFromBinaryFile<List<SerializedProcess>>(binaryPath);
            CollectionAssert.AreEqual(processes, readProcesses, new SerializedProcess_Comparer());
        }
    }
}

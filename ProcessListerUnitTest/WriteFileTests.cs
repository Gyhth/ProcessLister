using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Process_Lister;
using System.Collections.Generic;
using System.Linq;

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
            List<SerializedProcess> processes = new List<SerializedProcess>();
            SerializedProcess sprocess = new SerializedProcess();
            sprocess.Name = "Test 1";
            processes.Add(sprocess);
            sprocess = new SerializedProcess();
            sprocess.Name = "Test 2";
            processes.Add(sprocess);
            String binaryPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ProcessesBinary.bin";
            writeFile.WriteToBinaryFile<List<SerializedProcess>>(binaryPath, processes, false);
            List<SerializedProcess> readProcesses = new List<SerializedProcess>();
            readProcesses = writeFile.ReadFromBinaryFile<List<SerializedProcess>>(binaryPath);
            CollectionAssert.AreEqual(processes, readProcesses, new SerializedProcess_Comparer());
        }
    }
}

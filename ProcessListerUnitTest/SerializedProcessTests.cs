using Microsoft.VisualStudio.TestTools.UnitTesting;
using Process_Lister;

namespace ProcessListerUnitTest
{
    [TestClass]
    public class SerializedProcessTests
    {
        [TestMethod]
        public void SetProcessName()
        {
            SerializedProcess process = new SerializedProcess();
            process.Name = "Testing";
            Assert.AreEqual(process.Name, "Testing");
        }
    }
}

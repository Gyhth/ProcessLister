using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Process_Lister;
using System.Linq;

namespace ProcessListerUnitTest
{
    [TestClass]
    public class StringManipulationTests
    {
        [TestMethod]
        public void TestNoChanges()
        {
            String stringToManipulate = "Test";
            StringManipulation StringManipulator = new StringManipulation();
            byte[] s1 = StringManipulator.ToByteArray(stringToManipulate);
            byte[] s2 = StringManipulator.ToByteArray(stringToManipulate);
            ByteArrayComparer compare = new ByteArrayComparer();
            Assert.IsTrue(s1.SequenceEqual(s2));
            String resetString = StringManipulator.ByteArrayToString(s1);
            Assert.AreEqual(stringToManipulate, resetString);
        }
    }
}

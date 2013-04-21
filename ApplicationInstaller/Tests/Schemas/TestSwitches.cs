using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerUpdater.Schemas;
using ComputerUpdater.Classes;

namespace Tests
{
    [TestClass]
    public class TestSwitches
    {
        [TestMethod]
        public void TestToString()
        {
            Switches switches = new Switches("/test -switch");
            Assert.AreEqual(switches.ToString(), "/test -switch");

            Switches newSwitch = new Switches();
            Assert.AreEqual("Instance of ComputerUpdater.Schemas.Switches", newSwitch.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(XmlValidatorException))]
        public void TestInvalidXML()
        {
            Boolean isValid = Switches.XmlFileValid(@"TestFiles\Switches-Invalid.xml");
        }

        [TestMethod]
        public void TestValidXML()
        {
            Boolean isValid = Switches.XmlFileValid(@"TestFiles\Switches-Valid.xml");
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestEmptyFilePath()
        {
            Boolean isValid = App.XmlFileValid("");
            Assert.IsFalse(isValid);
        }
    }
}

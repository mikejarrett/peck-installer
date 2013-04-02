using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationInstaller.Schemas;
using ApplicationInstaller.Classes;

namespace Tests
{
    [TestClass]
    public class TestApp
    {
        [TestMethod]
        public void TestToString()
        {
            App testApp = new App();
            testApp.Name = "Test App";
            testApp.FileSize = 1.566;
            testApp.InstallSwitch = String.Empty;
            Assert.AreEqual("(N) Test App (1.57 MB)", testApp.ToString());

            testApp.InstallSwitch = "/nonsense -switch";
            Assert.AreEqual("(S) Test App (1.57 MB)", testApp.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(XmlValidatorException))]
        public void TestInvalidXML()
        {
            Boolean isValid = App.XmlFileValid(@"TestFiles/App-Invalid.xml");
        }

        [TestMethod]
        public void TestValidXML()
        {
            Boolean isValid = App.XmlFileValid(@"TestFiles/App-Valid.xml");
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TesEmptyFilePath()
        {
            Boolean isValid = App.XmlFileValid("");
            Assert.IsFalse(isValid);
        }
    }
}

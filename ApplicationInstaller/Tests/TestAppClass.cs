using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationInstaller.Schemas;
using ApplicationInstaller.Classes;

namespace Tests
{
    [TestClass]
    public class TestAppClass
    {
        [TestMethod]
        public void TestToString()
        {
            App testApp = new App();
            testApp.Name = "Test App";
            testApp.FileSize = 1.566;
            testApp.InstallSwitch = String.Empty;
            Assert.AreEqual(testApp.ToString(), "(N) Test App (1.57 MB)");

            testApp.InstallSwitch = "/nonsense -switch";
            Assert.AreEqual(testApp.ToString(), "(S) Test App (1.57 MB)");
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
    }
}

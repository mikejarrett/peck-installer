using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerUpdater.Schemas;
using ComputerUpdater.Classes;

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
            Boolean isValid = App.XmlFileValid(@"TestFiles\App-Invalid.xml");
        }

        [TestMethod]
        public void TestValidXML()
        {
            Boolean isValid = App.XmlFileValid(@"TestFiles\App-Valid.xml");
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TestEmptyFilePath()
        {
            Boolean isValid = App.XmlFileValid("");
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestNoArchitecture()
        {
            var app = new App(@"TestFiles\Test.file");
            Assert.AreEqual(String.Empty, app.Architecture);
            Assert.AreEqual("Application Installer", app.Name);
            Assert.AreEqual("Test.file", app.Filename);
            Assert.AreEqual(0.2021484375, app.FileSize);
            Assert.AreEqual("(S) Application Installer (0.20 MB)", app.ToString());
            Assert.AreEqual("1.0.0.0", app.Version);
        }

        [TestMethod]
        public void TestArchitecture()
        {
            var app = new App(@"TestFiles\Test-x64.file");
            Assert.AreEqual("x64", app.Architecture);

            app = new App(@"TestFiles\Test-win64.file");
            Assert.AreEqual("x64", app.Architecture);

            app = new App(@"TestFiles\Test-x86.file");
            Assert.AreEqual("x86", app.Architecture);
        }

        [TestMethod]
        public void TestKnowledgeBase()
        {
            var app = new App(@"TestFiles\Test-KB1234567-x64.file");
            Assert.AreEqual("KB1234567", app.Name);
            Assert.AreEqual("x64", app.Architecture);
        }
    }
}

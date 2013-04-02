using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationInstaller.Classes;

namespace Tests
{
    [TestClass]
    public class TestFileProperties
    {
        [TestMethod]
        public void TestNoArchitecture()
        {
            var app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test.file");
            Assert.AreEqual(app.Architecture, null);
            Assert.AreEqual(app.Name, "Application Installer");
            Assert.AreEqual(app.Filename, "Test.file");
            Assert.AreEqual(app.FileSize, 0.2021484375);
            Assert.AreEqual(app.ToString(), "(S) Application Installer (0.20 MB)");
            Assert.AreEqual(app.Version, "1.0.0.0");
        }

        [TestMethod]
        public void TestArchitecture()
        {
            var app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-x64.file");
            Assert.AreEqual(app.Architecture, "x64");

            app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-win64.file");
            Assert.AreEqual(app.Architecture, "x64");

            app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-x86.file");
            Assert.AreEqual(app.Architecture, "x86"); 
        }

        [TestMethod]
        public void TestKnowledgeBase()
        {
            var app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-KB1234567-x64.file");
            Assert.AreEqual(app.Name, "KB1234567");
            Assert.AreEqual(app.Architecture, "x64");
        }
    }
}

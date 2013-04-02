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
            Assert.AreEqual(null, app.Architecture);
            Assert.AreEqual("Application Installer", app.Name);
            Assert.AreEqual("Test.file", app.Filename);
            Assert.AreEqual(0.2021484375, app.FileSize);
            Assert.AreEqual("(S) Application Installer (0.20 MB)", app.ToString());
            Assert.AreEqual("1.0.0.0", app.Version);
        }

        [TestMethod]
        public void TestArchitecture()
        {
            var app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-x64.file");
            Assert.AreEqual("x64", app.Architecture);

            app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-win64.file");
            Assert.AreEqual("x64", app.Architecture);

            app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-x86.file");
            Assert.AreEqual("x86", app.Architecture); 
        }

        [TestMethod]
        public void TestKnowledgeBase()
        {
            var app = FileProperties.GetApplicationInfoFromFilePath(@"TestFiles\Test-KB1234567-x64.file");
            Assert.AreEqual("KB1234567", app.Name);
            Assert.AreEqual("x64", app.Architecture);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerUpdater.Classes;
using ComputerUpdater.Schemas;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests.Classes
{
    [TestClass]
    public class TestInstallInformationHolder
    {
        [TestMethod]
        public void TestBuildAppsList()
        {
            var holder = new InstallInformationHolder(true, "64");
            Assert.AreEqual(true, holder.installUpdates);
            Assert.AreEqual(0, holder.updateCount);
            Assert.AreEqual(0, holder.applicationCount);
            Assert.AreEqual(0, holder.additionalCount);
            Assert.AreEqual(0, holder.registryCount);
            Assert.AreEqual(0, holder.updatesToInstall.Count);
            Assert.AreEqual(0, holder.appsToInstall.Count);
            Assert.AreEqual(0, holder.additionalToInstall.Count);
            Assert.AreEqual(0, holder.registryToInstall.Count);

            var holder2 = new InstallInformationHolder(false, "64");
            Assert.AreEqual(false, holder2.installUpdates);
            Assert.AreEqual(0, holder2.updateCount);
            Assert.AreEqual(0, holder2.applicationCount);
            Assert.AreEqual(0, holder2.additionalCount);
            Assert.AreEqual(0, holder2.registryCount);
            Assert.AreEqual(0, holder2.updatesToInstall.Count);
            Assert.AreEqual(0, holder2.appsToInstall.Count);
            Assert.AreEqual(0, holder2.additionalToInstall.Count);
            Assert.AreEqual(0, holder2.registryToInstall.Count);
        }

        [TestMethod]
        public void TestHolderBuildAppsList()
        {
            var holder = new InstallInformationHolder(false, "64");
            String appName = "(N) Test App (1.57 MB)";
            List<String> appNames = new List<String> { appName };
            App appInList = new App() { Name = "Test App", FileSize = 1.570000009 };
            App appNotInList = new App() { Name = "Not in List", FileSize = 2.570000009 };
            List<App> appList = new List<App>() { appInList, appNotInList };
            holder.BuildAppsList(appNames, appList);
            Assert.AreEqual(1, holder.appsToInstall.Count);
        }

        [TestMethod]
        public void TestHolderBuildAdditionalList()
        {
            var holder = new InstallInformationHolder(false, "64");
            String appName = "(N) Test App (1.57 MB)";
            List<String> appNames = new List<String> { appName };
            App appInList = new App() { Name = "Test App", FileSize = 1.570000009 };
            App appNotInList = new App() { Name = "Not in List", FileSize = 2.570000009 };
            List<App> appList = new List<App>() { appInList, appNotInList };
            holder.BuildAppsList(appNames, appList);
            Assert.AreEqual(1, holder.appsToInstall.Count);
        }

        [TestMethod]
        public void TestHolderGetTotal()
        {
            var holder = new InstallInformationHolder(false, "64") { updateCount = 0, applicationCount = 2, additionalCount = 5, registryCount = 3 };
            Assert.AreEqual(10, holder.GetTotal());
        }

        [TestMethod]
        public void TestHolderWriteScriptFile()
        {

        }

        [TestMethod]
        public void TestHolderTotalInstallSort()
        {

        }
    }
}

using ApplicationInstaller.Schemas;
using ApplicationInstaller.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Tests.Classes
{
    [TestClass]
    public class TestGenericXmlProcessor
    {
        [TestMethod]
        public void XmlProcWriteToXML()
        {
            App app = new App();
            List<App> listApp = new List<App>() { app };
            String appfilepath = @"TestFiles\TestAppConfig.xml";
            GenericXmlProcessor<App>.WriteToXML(appfilepath, listApp);
            Assert.IsTrue(File.Exists(appfilepath));

            Switches switches = new Switches();
            List<Switches> listSwitches = new List<Switches>() { switches };
            String switchfilepath = @"TestFiles\TestAppConfig.xml";
            GenericXmlProcessor<Switches>.WriteToXML(switchfilepath, listSwitches);
            Assert.IsTrue(File.Exists(switchfilepath));

            File.Delete(appfilepath);
            File.Delete(switchfilepath);
        }

        [TestMethod]
        public void XmlProcDeserializeXMLToList()
        {
            List<App> listApp = GenericXmlProcessor<App>.DeserializeXMLToList(@"TestFiles\App-Valid.xml");
            Assert.AreEqual(2, listApp.Count);
            Assert.AreEqual("Test App 1", listApp[0].Name);

            List<App> invalidlistApp = GenericXmlProcessor<App>.DeserializeXMLToList(@"TestFiles\App-Invalid.xml");
            Assert.AreEqual(0, invalidlistApp.Count);
        }

        [TestMethod]
        public void XmlProcDeserializeXMLToStringList()
        {
            List<List<String>> switchList = new List<List<String>>();
            foreach (var obj in GenericXmlProcessor<Switches>.DeserializeXMLToStringList(@"TestFiles\Switches-Valid.xml"))
            {
                switchList.Add(obj);
            }
            Assert.AreEqual("/passive /norestart", switchList[0][0].ToString());
            Assert.AreEqual("/Q", switchList[1][0].ToString());

            switchList.Clear();
            foreach (var obj in GenericXmlProcessor<Switches>.DeserializeXMLToStringList(@"TestFiles\Switches-Invalid.xml"))
            {
                switchList.Add(obj);
            }
            Assert.AreEqual(0, switchList.Count);
        }

        [TestMethod]
        public void XmlProcGetNameOfType()
        {
            Assert.AreEqual("App", GenericXmlProcessor<App>.GetNameOfType());
            Assert.AreEqual("Switches", GenericXmlProcessor<Switches>.GetNameOfType());
            Assert.AreEqual("String", GenericXmlProcessor<String>.GetNameOfType());
        }

        [TestMethod]
        public void XmlProcTestValidXML()
        {
            Assert.IsTrue(GenericXmlProcessor<Switches>.XmlFileValid(@"TestFiles\Switches-Valid.xml"));
            Assert.IsTrue(GenericXmlProcessor<App>.XmlFileValid(@"TestFiles\App-Valid.xml"));
        }

        [TestMethod]
        public void XmlProcTestInValidXML()
        {
            Assert.IsFalse(GenericXmlProcessor<Switches>.XmlFileValid(""));
            Assert.IsFalse(GenericXmlProcessor<Switches>.XmlFileValid(String.Empty));
            Assert.IsFalse(GenericXmlProcessor<Switches>.XmlFileValid(@"Testfiles\App-Valid.xml"));
            Assert.IsFalse(GenericXmlProcessor<Switches>.XmlFileValid(@"Testfiles\App-Invalid.xml"));
            Assert.IsFalse(GenericXmlProcessor<App>.XmlFileValid(@"Testfiles\Switches-Valid.xml"));
            Assert.IsFalse(GenericXmlProcessor<App>.XmlFileValid(@"Testfiles\Switches-Invalid.xml"));
        }
    }
}

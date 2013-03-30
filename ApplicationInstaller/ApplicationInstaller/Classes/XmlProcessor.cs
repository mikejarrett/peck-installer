using ApplicationInstaller.Schemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ApplicationInstaller.Classes
{
    class XmlProcessor
    {
        public String FilePath
        { get; set; }

        public XmlProcessor(string filepath)
        {
            FilePath = filepath;
        }

        public IEnumerable<List<String>> DeserializeAppXML(Boolean XmlValid)
        {
            if (XmlValid)
            {
                List<App> apps = GetListOfApps();

                foreach (App app in apps)
                {
                    List<String> appValues = new List<String>()
                    {
                        app.Name.ToString(),
                        app.Filename.ToString(),
                        app.AbsolutePath.ToString(),
                        app.RelativePath.ToString(),
                        app.InstallSwitch.ToString(),
                        app.Version.ToString(),
                        app.Architecture.ToString(),
                        app.FileSize.ToString()
                    };
                    yield return appValues;
                }
            }
            else
            {
                yield break;
            }
        }

        public List<App> GetListOfApps()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<App>));
            var XDoc = XDocument.Load(FilePath);
            XmlReader reader = XDoc.CreateReader();
            reader.MoveToContent();
            List<App> apps = (List<App>)deserializer.Deserialize(reader);
            // Sort first on if there are switches associated with the install file
            // then on file size. Larger files are installed first.
            apps.Sort(delegate(App app1, App app2)
                       {
                           return
                             (
                                  app2.InstallSwitch.CompareTo(app1.InstallSwitch) != 0
                                  ? app2.InstallSwitch.CompareTo(app1.InstallSwitch)
                                   : app2.FileSize.CompareTo(app1.FileSize)
                             ); 
                       }
            );
            return apps;
        }

        public static void WriteToXML(string filepath, List<App> apps)
        {
            // Write the apps out to the selected configuration files
            XmlSerializer serializer = new XmlSerializer(typeof(List<App>));
            TextWriter textWriter = new StreamWriter(filepath);
            serializer.Serialize(textWriter, apps);
            textWriter.Close();
        }

        public static void WriteSwitchesToXML(string filepath, List<Switches> switches)
        {
            // Write the apps out to the selected configuration files
            XmlSerializer serializer = new XmlSerializer(typeof(List<Switches>));
            TextWriter textWriter = new StreamWriter(filepath);
            serializer.Serialize(textWriter, switches);
            textWriter.Close();
        }

        public List<Switches> DeserializeSwitchXML(Boolean XmlValid)
        {
            if (XmlValid)
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Switches>));
                var XDoc = XDocument.Load(FilePath);
                XmlReader reader = XDoc.CreateReader();
                reader.MoveToContent();
                List<Switches> switches = (List<Switches>)deserializer.Deserialize(reader);
                reader.Close();
                return switches;
            }
            else
            {
                return new List<Switches>();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Reflection;


namespace ApplicationInstaller.Classes
{
    class XmlProcessor
    {
        public XDocument XdocApps
        { get; set; }

        public String FilePath
        { get; set; }

        public XmlProcessor(string filepath)
        {
            FilePath = filepath;
        }

        private Boolean XmlFileValid()
        {
            if (FilePath.ToString() == String.Empty)
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xsdStream = assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Applications.xsd");
            Boolean valid = true;
            //XDocument xdocApps;
            XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
            XmlReader schemaReader = XmlReader.Create(xsdStream);
            xmlSchemaSet.Add("", schemaReader);
            XdocApps = XDocument.Load(FilePath);

            XdocApps.Validate(xmlSchemaSet, (o, err) =>
            {
                valid = false;
                throw new XmlValidatorException(err.Message, err.Exception);
            });

            if (valid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<List<String>> DeserializeXML()
        {
            if (XmlFileValid())
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<App>));
                XmlReader reader = XdocApps.CreateReader();
                reader.MoveToContent();
                List<App> apps = (List<App>)deserializer.Deserialize(reader);

                foreach (App app in apps)
                {
                    // Something similar to python yield?
                    // Or threading consumer and producer (this is producer)
                    List<String> appValues = new List<String>()
                    {
                        app.ApplicationName.ToString(),
                        app.Filename.ToString(),
                        app.AbsolutePath.ToString(),
                        app.RelativePath.ToString(),
                        app.InstallSwitch.ToString(),
                        app.Version.ToString()
                    };
                    yield return appValues;
                }
            }
            else
            {
                yield break;
            }
        }

        public static void WriteToXML(string filepath, List<App> apps)
        {
            // Write the apps out to the selected configuration files
            XmlSerializer serializer = new XmlSerializer(typeof(List<App>));
            TextWriter textWriter = new StreamWriter(filepath);
            serializer.Serialize(textWriter, apps);
            textWriter.Close();
        }
    }
}

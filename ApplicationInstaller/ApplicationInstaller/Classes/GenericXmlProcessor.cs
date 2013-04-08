using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ApplicationInstaller.Classes
{
    public class GenericXmlProcessor<T>
    {
        public static void WriteToXML(String filepath, List<T> list)
        {
            // Write the apps out to the selected configuration files
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            TextWriter textWriter = new StreamWriter(filepath);
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }

        public static List<T> DeserializeXML(Boolean XmlValid, String filePath)
        {
            if (XmlValid)
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
                var XDoc = XDocument.Load(filePath);
                XmlReader reader = XDoc.CreateReader();
                reader.MoveToContent();
                List<T> list = (List<T>)deserializer.Deserialize(reader);
                reader.Close();
                return list;
            }
            else
            {
                return new List<T>();
            }
        }

        public static String GetNameOfType()
        {
            return typeof(T).Name.ToString();
        }

        public static Boolean XmlFileValid(String FilePath)
        {
            if (FilePath.ToString() == String.Empty)
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xsdStream = null;
            String validator = GetNameOfType();
            if (validator.Equals("App"))
            {
                xsdStream = assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Applications.xsd");
            }
            else if (validator.Equals("Switches"))
            {
                xsdStream = assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Switches.xsd");
            }
            Boolean valid = true;
            XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
            XmlReader schemaReader = XmlReader.Create(xsdStream);
            xmlSchemaSet.Add("", schemaReader);
            var XDoc = XDocument.Load(FilePath);

            XDoc.Validate(xmlSchemaSet, (o, err) =>
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
    }
}

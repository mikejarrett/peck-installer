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
        /// <summary>
        /// Write the apps out to the given filepath configuration file
        /// </summary>
        /// <param name="filepath">File path and filename</param>
        /// <param name="list">List of objects to write out</param>
        public static void WriteToXML(String filepath, List<T> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            TextWriter textWriter = new StreamWriter(filepath);
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }

        /// <summary>
        /// If the filepath is validated, deserialize a configuration file and returns
        /// the files contents. Else, return and empty list of type T
        /// </summary>
        /// <param name="filePath">The filepath and filename of the configuration file</param>
        /// <returns>A list of type T from the XML file</returns>
        public static List<T> DeserializeXMLToList(String filePath)
        {
            List<T> list = new List<T>();
            try
            {
            if (XmlFileValid(filePath))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
                var XDoc = XDocument.Load(filePath);
                XmlReader reader = XDoc.CreateReader();
                reader.MoveToContent();
                list = (List<T>)deserializer.Deserialize(reader);
                reader.Close();
                return list;
            }
            }
            catch (XmlValidatorException)
            { 
                // TODO: Add logging
            }
            return list;
        }

        /// <summary>
        /// Returns the name generic type T
        /// </summary>
        /// <returns>String representation of the generic type T</returns>
        public static String GetNameOfType()
        {
            return typeof(T).Name.ToString();
        }

        /// <summary>
        /// Given a filepath and filename validate it against the known schema of types
        /// that are known to the system.
        /// 
        /// This function can thrown the custom XmlValidatorException exception
        /// </summary>
        /// <param name="FilePath">The filepath and filename of the configuration file</param>
        /// <returns>True, False or throws XmlValidatorException depending if valid</returns>
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
                //throw new XmlValidatorException(err.Message, err.Exception);
            });

            if (valid == true)
            {
                return true;
            }
            return false;
        }


    }
}

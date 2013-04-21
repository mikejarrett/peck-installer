using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ComputerUpdater.Classes
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
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                TextWriter textWriter = new StreamWriter(filepath);
                serializer.Serialize(textWriter, list);
                textWriter.Close();
            }
            catch (Exception)
            {
                // TODO: Log this!! Don't just silently fail it.
            }
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
        /// Deserializes the selected file then loops over each instance that was deserialized
        /// and finds all the properties of the object. It then will loop through each objects
        /// properties and adds their value to the listProperties list.
        /// </summary>
        /// <param name="filePath">The filepath and filename of the configuration file</param>
        /// <returns>Yields a list type string with the value</returns>
        public static IEnumerable<List<String>> DeserializeXMLToStringList(String filePath)
        {
            List<T> objects = DeserializeXMLToList(filePath);

            foreach (var obj in objects)
            {
                List<String> listProperties = new List<String>();

                Type t = obj.GetType();
                PropertyInfo[] propertyInfo = t.GetProperties();
                foreach (PropertyInfo property in propertyInfo)
                {
                    listProperties.Add(property.GetValue(obj).ToString());
                }
                yield return listProperties;
            }
            yield break;
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
                xsdStream = assembly.GetManifestResourceStream("ComputerUpdater.Validation.Applications.xsd");
            }
            else if (validator.Equals("Switches"))
            {
                xsdStream = assembly.GetManifestResourceStream("ComputerUpdater.Validation.Switches.xsd");
            }
            else if (validator.Equals("SwitchMapping"))
            {
                xsdStream = assembly.GetManifestResourceStream("ComputerUpdater.Validation.AppSwitchMappings.xsd");
            }
            else
            {
                return false;
            }
            Boolean valid = true;
            XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
            XmlReader schemaReader = XmlReader.Create(xsdStream);
            xmlSchemaSet.Add("", schemaReader);
            var XDoc = XDocument.Load(FilePath);

            XDoc.Validate(xmlSchemaSet, (o, err) =>
            {
                valid = false;
            });

            if (valid == true)
            {
                return true;
            }
            return false;
        }
    }
}
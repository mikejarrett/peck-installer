using ComputerUpdater.Classes;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ComputerUpdater.Schemas
{
    public class Switches
    {
        public override String ToString()
        {
            if (Switch == null)
            {
                return "Instance of " + typeof(Switches).ToString();
            }
            return Switch.ToString();
        }

        [XmlElement("Switch")]
        public string Switch
        { get; set; }

        public Switches()
        { }

        public Switches(String switchValue)
        {
            Switch = switchValue;
        }

        public static Boolean XmlFileValid(String FilePath)
        {
            if (FilePath.ToString() == String.Empty)
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xsdStream = assembly.GetManifestResourceStream("ComputerUpdater.Validation.Switches.xsd");
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

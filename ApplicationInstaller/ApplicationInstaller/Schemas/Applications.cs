using ApplicationInstaller.Classes;
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ApplicationInstaller.Schemas
{
    public class App
    {
        public override String ToString() 
        {
            return this.Name;
        }

        [XmlElement("AbsolutePath")]
        public string AbsolutePath
        { get; set; }

        [XmlElement("Name")]
        public string Name
        { get; set; }

        [XmlElement("Architecture")]
        public string Architecture
        { get; set; }

        [XmlElement("Filename")]
        public string Filename
        { get; set; }

        [XmlElement("Filesize")]
        public Double FileSize
        { get; set; }

        [XmlElement("InstallSwitch")]
        public string InstallSwitch
        { get; set; }

        [XmlElement("RelativePath")]
        public string RelativePath
        { get; set; }

        [XmlElement("Version")]
        public string Version
        { get; set; }

        public static Boolean XmlFileValid(String FilePath)
        {
            if (FilePath.ToString() == String.Empty)
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xsdStream = assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Applications.xsd");
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

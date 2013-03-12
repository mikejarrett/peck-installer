using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;

namespace ApplicationInstaller.Classes
{
    class XMLValidation
    {
        // Start of the refactoring of XML validation
        public void GetRow()
        {
        }

        public void Something(string filepath)
        {
            bool validation_errors = false;
            XDocument xdocApps;
            XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
            System.IO.Stream xsdStream = this.GetType().Assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Applications.xsd");
            XmlReader schemaReader = XmlReader.Create(xsdStream);
            xmlSchemaSet.Add("", schemaReader);
            try
            {
                xdocApps = XDocument.Load(filepath);

                xdocApps.Validate(xmlSchemaSet, (o, err) =>
                {
                    validation_errors = true;
                    throw new Exception(err.Message);
                });

                if (validation_errors == false)
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<App>));
                    XmlReader reader = xdocApps.CreateReader();
                    reader.MoveToContent();
                    List<App> apps = (List<App>)deserializer.Deserialize(reader);
                 
                    for (int i = 0; i < apps.Count; ++i)
                    {
                        // Something similar to python yield?
                        // Or threading consumer and producer (this is producer)
                        string [] sdf = {
                            apps[i].ApplicationName.ToString(),
                            apps[i].Filename.ToString(),
                            apps[i].AbsolutePath.ToString(),
                            apps[i].RelativePath.ToString(),
                            apps[i].InstallSwitch.ToString(),
                            apps[i].Version.ToString()
                                        };
                    }
                }
            }
            catch (Exception error)
            {
                // TODO: Add logging - don't throw nasty errors at the user!
                throw new Exception(error.ToString());
            }
        }
    }
}

using System.Xml;
using System.Xml.Serialization;

namespace ComputerUpdater.Schemas
{
    public class SwitchMapping
    {
        [XmlElement("Name")]
        public string Name
        { get; set; }

        [XmlElement("Filename")]
        public string Filename
        { get; set; }

        [XmlElement("Switch")]
        public string Switch
        { get; set; }
    }
}

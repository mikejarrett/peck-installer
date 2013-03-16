using System.Xml.Serialization;

namespace ApplicationInstaller.Schemas
{
    public struct SwitchesSchema
    {
        [XmlElement("Switch")]
        public string Switches
        { get; set; }
    }
}

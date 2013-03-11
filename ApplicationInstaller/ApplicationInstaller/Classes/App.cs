using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationInstaller.Classes
{
    public struct App
    {
        [XmlElement("ApplicationName")]
        public string ApplicationName
        { get; set; }

        [XmlElement("Version")]
        public string Version
        { get; set; }

        [XmlElement("InstallSwitch")]
        public string InstallSwitch
        { get; set; }

        [XmlElement("RelativePath")]
        public string RelativePath
        { get; set; }

        [XmlElement("AbsolutePath")]
        public string AbsolutePath
        { get; set; }

        [XmlElement("Filename")]
        public string Filename
        { get; set; }

    }
}

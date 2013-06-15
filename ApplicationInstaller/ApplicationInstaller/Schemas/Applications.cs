using ComputerUpdater.Classes;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ComputerUpdater.Schemas
{
    public class App
    {
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
        {
            get { return _InstallSwitch; }
            set 
            { 
                _InstallSwitch = value;
                Silent = true;
            }
        }

        [XmlElement("RelativePath")]
        public string RelativePath
        { get; set; }

        [XmlElement("Version")]
        public string Version
        { get; set; }

        [XmlElement("Silent")]
        public Boolean Silent
        { get; set; }

        [XmlIgnore]
        private string _InstallSwitch;

        public App()
        { }

        public App(String FilePath)
        {
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(FilePath);

            String directoryPath = Path.GetDirectoryName(FilePath);
            String filename = Path.GetFileName(FilePath);
            String x64Arch = @"x64|win64";
            String x86Arch = @"x86";
            String updateFileNameRegex = @"kb ?\d+|KB ?\d+";
            String kbNumber = Regex.Match(filename, updateFileNameRegex).ToString();

            AbsolutePath = FilePath;
            Name = fileInfo.ProductName;
            Filename = filename;
            RelativePath = Regex.Replace(FilePath, @"[a-zA-Z][:]", "");
            Version = fileInfo.ProductVersion;
            Silent = false;

            FileSize = ConvertToMegabytes(new FileInfo(FilePath).Length);
            Name = GetApplicationNameFromFile(FilePath, x64Arch, x86Arch, kbNumber);
            Architecture = GetFileArchitecture(filename, x64Arch, x86Arch);
            SetVersionFromFile(filename, x64Arch, x86Arch);
        }

        private String GetApplicationNameFromFile(String FilePath, String x64Arch, String x86Arch, String kbNumber)
        {
            String name = "";
            // TODO: My String-Matching-Fu is a little weak as of late
            if (Name == null || Name == String.Empty)
            {
                if (kbNumber == null || kbNumber == String.Empty)
                {
                    var fileNameNoEx = Path.GetFileNameWithoutExtension(FilePath);
                    fileNameNoEx = Regex.Replace(Regex.Replace(fileNameNoEx, x86Arch, ""), x64Arch, "");
                    name = Regex.Replace(fileNameNoEx, @"[^a-zA-Z]", "");
                }
                else
                {
                    name = kbNumber;
                }
            }
            else
            {
                name = Name;
            }
            return name;
        }

        private String GetFileArchitecture(String filename, String x64Arch, String x86Arch)
        {
            String arch = String.Empty;
            if (Regex.IsMatch(filename, x64Arch))
            {
                arch = "x64";
            }
            else if (Regex.IsMatch(filename, x86Arch))
            {
                arch = "x86";
            }
            return arch;
        }

        private void SetVersionFromFile(String filename, String x64Arch, String x86Arch)
        {
            if (Version == String.Empty || Version == null)
            {
                filename = Regex.Replace(Regex.Replace(filename, x86Arch, ""), x64Arch, "");
                Version = Regex.Replace(filename, @"\D", "");
            }
        }

        public override String ToString()
        {
            String silentString = "(N)";
            if (!Silent && InstallSwitch != String.Empty)
            {
                silentString = "(P)";
            }
            else if (Silent && InstallSwitch != String.Empty)
            {
                silentString = "(S)";
            }
            return String.Format("{0} {1} ({2:0.00} MB)", silentString, Name, FileSize);
        }

        public static Boolean XmlFileValid(String FilePath)
        {
            if (FilePath.ToString() == String.Empty)
            {
                return false;
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream xsdStream = assembly.GetManifestResourceStream("ComputerUpdater.Validation.Applications.xsd");
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

        private static float ConvertToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public void Install()
        {
            if (File.Exists(RelativePath))
            {
                Process p = new Process();
                p.StartInfo.FileName = RelativePath;
                p.StartInfo.Arguments = InstallSwitch;
                p.StartInfo.UseShellExecute = true;
                p.Start();
                p.WaitForExit();
            }
            else if (File.Exists(AbsolutePath))
            {
                Process p = new Process();
                p.StartInfo.FileName = RelativePath;
                p.StartInfo.Arguments = InstallSwitch;
                p.Start();
                p.WaitForExit();
            }
        }
    }
}
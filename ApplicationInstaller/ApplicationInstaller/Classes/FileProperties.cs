using ApplicationInstaller.Schemas;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace ApplicationInstaller.Classes
{
    class FileProperties
    {
        public static App GetApplicationInfoFromFilePath(string filepath)
        {
            // Given a filepath attempt to get the information needed to populate
            // the data entry form
            App app = new App();
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(filepath);
            
            String directoryPath = Path.GetDirectoryName(filepath);
            String filename = Path.GetFileName(filepath);
            String arch;
            String x64Arch = @"x64|win64";
            String x86Arch = @"x86";
            String updateRegex = @"kb ?\d+|KB ?\d+";
            String kbNumber = Regex.Match(filename, updateRegex).ToString();

            app.AbsolutePath = filepath;
            app.Name = fileInfo.ProductName;
            app.Filename = filename;
            app.RelativePath= Regex.Replace(filepath, @"[a-zA-Z][:]", "");
            app.Version = fileInfo.ProductVersion;
            app.FileSize = ConvertToMegabytes(new FileInfo(filepath).Length);

            // TODO: My String-Matching-Fu is a little weak as of late
            if (app.Name == null || app.Name == String.Empty)
            {
                if (kbNumber == null || kbNumber == String.Empty)
                {
                    var FileNameNoEx = Path.GetFileNameWithoutExtension(filepath);
                    FileNameNoEx = Regex.Replace(Regex.Replace(FileNameNoEx, x86Arch, ""), x64Arch, "");
                    app.Name = Regex.Replace(FileNameNoEx, @"[^a-zA-Z]", "");
                }
                else
                {
                    app.Name = kbNumber;
                }
            }

            if (Regex.IsMatch(filename, x64Arch))
            {
                arch = "x64";
                app.Architecture = arch;
            }
            else if (Regex.IsMatch(filename, x86Arch))
            {
                arch = "x86";
                app.Architecture = arch;
            }

            if (app.Version == String.Empty || app.Version == null)
            {
                filename = Regex.Replace(Regex.Replace(filename, x86Arch, ""), x64Arch, "");
                app.Version = Regex.Replace(filename, @"\D", "");
            }
    
            return app;
        }

        private static float ConvertToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}

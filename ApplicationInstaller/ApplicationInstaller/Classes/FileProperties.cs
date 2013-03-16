using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using ApplicationInstaller.Schemas;

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

            app.AbsolutePath = filepath;
            app.ApplicationName = fileInfo.ProductName;
            app.Filename = filename;
            app.RelativePath= Regex.Replace(filepath, @"[a-zA-Z][:]", "");
            app.Version = fileInfo.ProductVersion;

            // TODO: My String-Matching-Fu is a little weak as of late
            if (app.ApplicationName == null || app.ApplicationName == String.Empty)
            {
                var FileNameNoEx = Path.GetFileNameWithoutExtension(filepath);
                FileNameNoEx = Regex.Replace(Regex.Replace(FileNameNoEx, x86Arch, ""), x64Arch, "");
                app.ApplicationName = Regex.Replace(FileNameNoEx, @"[^a-zA-Z]", "");
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
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;

namespace ApplicationInstaller.Classes
{
    class FileProperties
    {
        public static List<String> GetApplicationInfoFromFilePath(string filepath)
        {
            // Given a filepath attempt to get the information needed to populate
            // the data entry form
            String appName;
            String fileInfoAppName;
            String fileInfoVersion;
            String arch = String.Empty;
            String x64Arch = @"x64|win64";
            String x86Arch = @"x86";
            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(filepath);
            String directoryPath = Path.GetDirectoryName(filepath);
            String filename = Path.GetFileName(filepath);
            String version = filename;
            try
            {
                fileInfoAppName = fileInfo.ProductName.ToString();
            }
            catch (System.NullReferenceException)
            {
                fileInfoAppName = String.Empty;
            }
            try
            {
                fileInfoVersion = fileInfo.ProductVersion.ToString();
            }
            catch (System.NullReferenceException)
            {
                fileInfoVersion = String.Empty;
            }

            if (fileInfoAppName != String.Empty)
            {
                appName = fileInfoAppName;
            }
            else
            {
                appName = Regex.Replace(Path.GetFileNameWithoutExtension(filepath), @"[^a-zA-Z]", "");
            }

            if (Regex.IsMatch(filename, x64Arch))
            {
                arch = "x64";
                version = Regex.Replace(filename, x64Arch, String.Empty);
            }
            else if (Regex.IsMatch(filename, x86Arch))
            {
                arch = "x86";
                version = Regex.Replace(filename, x86Arch, String.Empty);
            }

            if (fileInfoVersion != String.Empty)
            {
                version = fileInfoVersion;
            }
            else
            {
                version = Regex.Replace(version, @"\D", "");
            }

            String relativePath = Regex.Replace(directoryPath, @"[a-zA-Z][:]", "");
            return new List<String> { appName, filename, directoryPath, relativePath, version, arch };
        }
    }
}

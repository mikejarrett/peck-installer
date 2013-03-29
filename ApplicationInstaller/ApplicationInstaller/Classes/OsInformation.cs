using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInstaller.Classes
{
    static class OsInformation
    {
        public static int getOSArchitecture()
        {
            String environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(environmentVariable) || (String.Compare(environmentVariable, 0, "x86", 0, 3, true) == 0)) ? 0x20 : 0x40);
        }

        private static String OsString(OperatingSystem oSVersion, String versionString)
        {
            if (!(versionString != ""))
            {
                return versionString;
            }
            versionString = "Windows " + versionString;
            if (oSVersion.ServicePack != "")
            {
                versionString = versionString + " " + oSVersion.ServicePack;
            }
            return (versionString + " " + getOSArchitecture().ToString() + "-bit");
        }

        public static String getOSName()
        {
            OperatingSystem oSVersion = Environment.OSVersion;
            Version version = oSVersion.Version;
            String versionString = "";
            if (oSVersion.Platform == PlatformID.Win32Windows)
            {
                switch (version.Minor)
                {
                    case 0:
                        versionString = "95";
                        break;
                    case 10:
                        if (version.Revision.ToString() == "2222A")
                        {
                            versionString = "98SE";
                        }
                        else
                        {
                            versionString = "98";
                        }
                        break;
                    case 90:
                        versionString = "Me";
                        break;
                }
            }
            else if (oSVersion.Platform == PlatformID.Win32NT)
            {
                switch (version.Major)
                {
                    case 3:
                        versionString = "NT 3.51";
                        break;

                    case 4:
                        versionString = "NT 4.0";
                        break;

                    case 5:
                        if (version.Minor != 0)
                        {
                            versionString = "XP";
                        }
                        else
                        {
                            versionString = "2000";
                        }
                        break;

                    case 6:
                        if (version.Minor != 0)
                        {
                            versionString = "7";
                        }
                        else
                        {
                            versionString = "Vista";
                        }
                        break;
                }
            }
            return OsString(oSVersion, versionString);
        }
    }
}


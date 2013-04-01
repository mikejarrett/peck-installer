using ApplicationInstaller.Schemas;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApplicationInstaller.Classes
{
    public class InstallInformationHolder
    {
        public int updateCount
        { get; set; }

        public int applicationCount
        { get; set; }

        public int additionalCount
        { get; set; }

        public int registryCount
        { get; set; }

        public List<App> updatesToInstall
        { get; set; }

        public List<App> appsToInstall
        { get; set; }

        public List<App> additionalToInstall
        { get; set; }

        public List<String> registryToInstall
        { get; set; }

        public Boolean installServicePack
        { get; set; }

        public Boolean installUpdates
        { get; set; }

        public App servicePack
        { get; set; }

        public InstallInformationHolder(Boolean InstallUpdates)
        {
            installUpdates = InstallUpdates;
            updateCount = 0;
            applicationCount = 0;
            additionalCount = 0;
            registryCount = 0;
            updatesToInstall = new List<App>();
            appsToInstall = new List<App>();
            additionalToInstall = new List<App>();
            registryToInstall = new List<String>();
        }

        public void BuildAppsList(List<String> appNames, List<App> appList)
        {
            foreach (String name in appNames)
            {
                appsToInstall.Add(appList.Find(item => item.ToString() == name));
            }
        }

        public void BuildAdditionalList(List<String> appNames, List<App> additionalList)
        {
            foreach (String name in appNames)
            {
                additionalToInstall.Add(additionalList.Find(item => item.ToString() == name));
            }
        }

        public int GetTotal()
        {
            return updateCount + applicationCount + additionalCount + registryCount;
        }

        public void WriteScriptFile(String FilePath)
        {
            List<App> TotalInstall = TotalInstallSort(new List<App>());
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, false))
            {
                WriteHeader(file);
                WriteAppsToFile(TotalInstall, file);
                WriteRegistryToFile(file);
            }
        }

        private void WriteRegistryToFile(System.IO.StreamWriter file)
        {
            if (registryCount > 0)
            {
                file.WriteLine("echo Registering registry files...");
                foreach (var reg in registryToInstall)
                {
                    file.WriteLine(String.Format("regedit.exe /s {0}", reg));
                }
            }
        }

        private static void WriteAppsToFile(List<App> TotalInstall, System.IO.StreamWriter file)
        {
            foreach (var app in TotalInstall)
            {
                String installString = "";

                if (File.Exists(app.RelativePath))
                {
                    installString = String.Format("start /wait \"{0}\" {1}", app.RelativePath, app.InstallSwitch);
                }
                else if (File.Exists(app.AbsolutePath))
                {
                    installString = String.Format("start /wait \"{0}\" {1}", app.AbsolutePath, app.InstallSwitch);
                }

                if (installString != "")
                {
                    String installing = String.Format("echo Installing {0}", app.ToString());
                    file.WriteLine(installing);
                    file.WriteLine(installString);
                }
            }
        }

        private List<App> TotalInstallSort(List<App> TotalInstall)
        {
            var appList = new List<List<App>>();
            if (installUpdates && updateCount > 0) { appList.Add(updatesToInstall); }
            if (applicationCount > 0) { appList.Add(appsToInstall); }
            if (additionalCount > 0) { appList.Add(additionalToInstall); }
            foreach (var toInstall in appList)
            {
                foreach (var app in toInstall)
                {
                    TotalInstall.Add(app);
                }
            }

            TotalInstall.Sort(delegate(App app1, App app2)
            {
                return
                  (
                       app2.InstallSwitch.CompareTo(app1.InstallSwitch) != 0
                       ? app2.InstallSwitch.CompareTo(app1.InstallSwitch)
                        : app2.Name.CompareTo(app1.Name)
                  );
            }
            );
            return TotalInstall;
        }

        private static void WriteHeader(System.IO.StreamWriter file)
        {
            String header = String.Format("@echo off\n" +
                "cls\n" +
                "echo ==============================================================\n" +
                "echo      Script file generated from Application Installer v{0}\n" +
                "echo                 Generated  {1}\n" +
                "echo ==============================================================\n" +
                "echo.", "1", DateTime.Now);
            file.WriteLine(header);
        }
    }
}

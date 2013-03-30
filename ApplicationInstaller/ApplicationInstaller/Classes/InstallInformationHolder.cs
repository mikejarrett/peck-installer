using ApplicationInstaller.Schemas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Boolean installUpdates
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
                appsToInstall.Add(appList.Find(item => item.Name == name));
            }
        }

        public void BuildAdditionalList(List<String> appNames, List<App> additionalList)
        {
            foreach (String name in appNames)
            {
                additionalToInstall.Add(additionalList.Find(item => item.Name == name));
            }
        }

        public int GetTotal()
        {
            return updateCount + applicationCount + additionalCount + registryCount;
        }
    }
}

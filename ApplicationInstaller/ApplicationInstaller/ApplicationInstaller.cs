using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationInstaller.Classes;
using ApplicationInstaller.Schemas;
using System.IO;

namespace ApplicationInstaller
{
    public partial class ApplicationInstaller : Form
    {
        public String OsName
        { get; set; }

        public List<App> listApps
        { get; set; }

        public List<App> listUpdates
        { get; set; }

        public List<App> additionalConfigApps
        { get; set; }

        public List<String> registryFiles
        { get; set; }

        public ApplicationInstaller()
        {
            InitializeComponent();
            this.Width = 373;
            OsName = OsInformation.getOSName();
            gbName.Text = OsName;
            LoadWindowsUpdatesCofig();
            LoadRegistryFiles();
            LoadApplicationConfig(@"Configs\Applications.xml");
        }

        private void LoadWindowsUpdatesCofig()
        {
            String filePath = String.Format(@"Configs\{0}.xml", Slugifier.GenerateSlug(OsName));
            try
            {
                if (App.XmlFileValid(filePath))
                {
                    listUpdates = new XmlProcessor(filePath).GetListOfApps();
                    cbWindowsUpdates.Text = String.Format("{0} ({1})", cbWindowsUpdates.Text, listUpdates.Count);
                }
            }
            catch (Exception err)
            {
                cbWindowsUpdates.Checked = false;
                cbWindowsUpdates.Enabled = false;
            }
        }

        private void LoadApplicationConfig(String filePath = "")
        {
            try
            {
                Boolean xmlValid = App.XmlFileValid(filePath);
                if (String.IsNullOrEmpty(filePath) || !xmlValid)
                {
                    cbAppToggle.Enabled = false;
                    checkedListBoxApps.Enabled = false;
                }
                else
                {
                    
                    listApps = new XmlProcessor(filePath).GetListOfApps();
                    foreach (App app in listApps)
                    {
                        checkedListBoxApps.Items.Add(app.ToString());
                        int idx = checkedListBoxApps.Items.Count - 1;
                        checkedListBoxApps.SetItemCheckState(idx, CheckState.Checked);
                    }
                }
            }
            catch (Exception err)
            {
                cbAppToggle.Enabled = false;
                checkedListBoxApps.Enabled = false;
            }
        }

        private void LoadRegistryFiles()
        {
            var files = Directory.EnumerateFiles(@"Registry\", "*.reg", SearchOption.AllDirectories);
            foreach (String filename in files)
            {
                clbRegistryFiles.Items.Add(filename);
                int idx = clbRegistryFiles.Items.Count - 1;
                clbRegistryFiles.SetItemCheckState(idx, CheckState.Checked);
            }
        }

        private void configBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ConfigBuilder = new ConfigBuilder();
            ConfigBuilder.Show();
        }

        private void cbAppToggle_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxApps.Items.Count; i++)
                checkedListBoxApps.SetItemCheckState(i, (cbAppToggle.Checked ? CheckState.Checked : CheckState.Unchecked));
            if (cbAppToggle.Checked)
            {
                cbAppToggle.Text = "Unselect all applications";
            }
            else
            {
                cbAppToggle.Text = "Select all applications";
            }
        }

        private void linkLabelInstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisableAllItems();
            this.Width = 720;
            WhatIsGoingToBeInstalled();
            SetProgressBarMax();
            InstallUpdates();
            InstallApplications();
            ProcessAdditionalConfigs();
            ProcessReigstryFiles();
        }

        private void WhatIsGoingToBeInstalled()
        {
            rtbInstallationInfo.AppendText("Installing and applying the following:\n");
            rtbInstallationInfo.AppendText(String.Format("Updates: {0}\n", listUpdates.Count.ToString()));
            rtbInstallationInfo.AppendText(String.Format("Applications: {0}\n", checkedListBoxApps.SelectedItems.Count.ToString()));
            rtbInstallationInfo.AppendText(String.Format("Additional Config: {0}\n", clbAdditionalConfigurations.SelectedItems.Count.ToString()));
            rtbInstallationInfo.AppendText(String.Format("Registry: {0}\n", clbRegistryFiles.SelectedItems.Count.ToString()));
            rtbInstallationInfo.AppendText("======================================\n");
        }

        private void InstallUpdates()
        {
            if (cbWindowsUpdates.Checked)
            {
                foreach (App update in listUpdates)
                {
                    rtbInstallationInfo.AppendText(String.Format("{0}...\n", update.ToString()));
                    progressBar1.Value += 1;
                }
            }
        }

        private void InstallApplications()
        {
            foreach (String appName in checkedListBoxApps.CheckedItems)
            {
                var app = listApps.Find(item => item.Name == appName.ToString());
                rtbInstallationInfo.AppendText(String.Format("{0} ({1})...\n", app.ToString(), app.Version));
                progressBar1.Value += 1;
            }
        }

        private void ProcessAdditionalConfigs()
        {
            foreach (String appName in clbAdditionalConfigurations.CheckedItems)
            {
                var app = additionalConfigApps.Find(item => item.Name == appName.ToString());
                rtbInstallationInfo.AppendText(String.Format("{0} ({1})...\n", app.ToString(), app.Version));
                progressBar1.Value += 1;
            }
        }

        private void ProcessReigstryFiles()
        {
            foreach (String filename in clbRegistryFiles.CheckedItems)
            {
                rtbInstallationInfo.AppendText(String.Format("Applying: {0}...\n", filename.ToString()));
                progressBar1.Value += 1;
            }
        }

        private void SetProgressBarMax()
        {
            progressBar1.Value = 0;
            int count = 0;
            if (cbWindowsUpdates.Checked)
            {
                count += listUpdates.Count;
            }
            progressBar1.Maximum = count + checkedListBoxApps.CheckedItems.Count + clbRegistryFiles.CheckedItems.Count
                + clbAdditionalConfigurations.CheckedItems.Count;
        }

        private void DisableAllItems()
        {
            cbWindowsUpdates.Enabled = false;
            cbAppToggle.Enabled = false;
            checkedListBoxApps.Enabled = false;
            clbRegistryFiles.Enabled = false;
            linkAddRegistryFiles.Enabled = false;
            clbAdditionalConfigurations.Enabled = false;
            linkAdditionalConfigs.Enabled = false;
            linkStartInstall.Enabled = false;
        }

        private void EnableAllitems()
        {
            cbWindowsUpdates.Enabled = true;
            cbAppToggle.Enabled = true;
            checkedListBoxApps.Enabled = true;
            clbRegistryFiles.Enabled = true;
            linkAddRegistryFiles.Enabled = true;
            clbAdditionalConfigurations.Enabled = true;
            linkAdditionalConfigs.Enabled = true;
            linkStartInstall.Enabled = true;
        }

        private void linkAddRegistryFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog addRegistryFilesDialog = new OpenFileDialog();
            addRegistryFilesDialog.Filter = "Registry Files (*.REG)|*.REG;";
            addRegistryFilesDialog.Multiselect = true;
            addRegistryFilesDialog.Title = "Select Registry Files";
            if (addRegistryFilesDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String filename in addRegistryFilesDialog.FileNames)
                {
                    clbRegistryFiles.Items.Add(filename);
                    int idx = clbRegistryFiles.Items.Count - 1;
                    clbRegistryFiles.SetItemCheckState(idx, CheckState.Checked);
                }
            }
        }

        private void linkAdditionalConfigs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog addRegistryFilesDialog = new OpenFileDialog();
            addRegistryFilesDialog.Filter = "Registry Files (*.XML)|*.XML;";
            addRegistryFilesDialog.Multiselect = true;
            addRegistryFilesDialog.Title = "Additional Config Files";
            if (addRegistryFilesDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String filename in addRegistryFilesDialog.FileNames)
                {
                    Boolean xmlValid = App.XmlFileValid(filename);
                    if (xmlValid)
                    {
                        additionalConfigApps = new XmlProcessor(filename).GetListOfApps();
                        foreach (App app in additionalConfigApps)
                        {
                            clbAdditionalConfigurations.Items.Add(app.ToString());
                            int idx = clbAdditionalConfigurations.Items.Count - 1;
                            clbAdditionalConfigurations.SetItemCheckState(idx, CheckState.Checked);
                        }
                    }
                }
            }
        }
    }
}

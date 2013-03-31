using ApplicationInstaller.Classes;
using ApplicationInstaller.Schemas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        public String servicePackFilePath
        { get; set; }

        public String servicePackSwitches
        { get; set; }

        public InstallInformationHolder installInformationHolder
        { get; set; }

        public ApplicationInstaller()
        {
            additionalConfigApps = new List<App>();
            InitializeComponent();
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
            {
                checkedListBoxApps.SetItemCheckState(i, (cbAppToggle.Checked ? CheckState.Checked : CheckState.Unchecked));
            }
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
            BuildHolder();
            InstallPrompt();
        }

        private void BuildHolder()
        {
            installInformationHolder = new InstallInformationHolder(cbWindowsUpdates.Checked);

            // Update information
            installInformationHolder.updateCount = (cbWindowsUpdates.Checked) ? listUpdates.Count : 0; 
            installInformationHolder.updatesToInstall = listUpdates;

            // Application information
            installInformationHolder.applicationCount = checkedListBoxApps.CheckedItems.Count;
            installInformationHolder.BuildAppsList(checkedListBoxApps.CheckedItems.Cast<String>().ToList(), listApps);

            // Additional configuration information
            installInformationHolder.additionalCount = clbAdditionalConfigurations.CheckedItems.Count;
            installInformationHolder.BuildAdditionalList(clbAdditionalConfigurations.CheckedItems.Cast<String>().ToList(), additionalConfigApps);

            // Registry information
            installInformationHolder.registryCount = clbRegistryFiles.CheckedItems.Count;
            installInformationHolder.registryToInstall = clbRegistryFiles.CheckedItems.Cast<String>().ToList();
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
                        var additionalApps = new XmlProcessor(filename).GetListOfApps();
                        additionalConfigApps.AddRange(additionalApps);
                        foreach (App app in additionalApps)
                        {
                            clbAdditionalConfigurations.Items.Add(app.ToString());
                            int idx = clbAdditionalConfigurations.Items.Count - 1;
                            clbAdditionalConfigurations.SetItemCheckState(idx, CheckState.Checked);
                        }
                    }
                }
            }
        }

        private void cbServicePack_CheckedChanged(object sender, EventArgs e)
        {
            if (cbServicePack.Checked)
            {
                DisableAllItems();
                OpenFileDialog servicePackDialog = new OpenFileDialog();
                servicePackDialog.Filter = "Executables (*.EXE;*.MSI;*.MSU)|*.EXE;*.MSI;*.MSU|All files (*.*)|*.*";
                servicePackDialog.Multiselect = false;
                servicePackDialog.Title = "Select Service Pack";
                if (servicePackDialog.ShowDialog() == DialogResult.OK)
                {
                    servicePackFilePath = servicePackDialog.FileName;
                    servicePackSwitches = "/unattend /warnrestart";
                    servicePackSwitches = Prompt(servicePackSwitches);
                }
            }
            else
            {
                EnableAllitems();
                servicePackFilePath = String.Empty;
                servicePackSwitches = "/unattend /warnrestart";
            }
        }

        private String Prompt(String defaultSwitch)
        {
            Form prompt = new Form();
            prompt.Width = 373;
            prompt.Height = 100;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = "Service Pack Switches";
            Label textLabel = new Label() { Left = 10, Top = 10, Width = 120, Text = "Service Pack Switches" };
            TextBox textBox = new TextBox() { Left = 130, Top = 8, Width = 220, Text = defaultSwitch};
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 80, Top = 33 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }

        private void InstallPrompt()
        {
            DisableSecurityZones();
            this.Hide();
            InstallInfoform installInfoForm = new InstallInfoform(installInformationHolder);
            installInfoForm.ShowDialog();
            this.Show();
            EnableAllitems();
            EnableSecurityZones();
            linkStartInstall.Enabled = true;
        }

        private void DisableSecurityZones()
        {
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\0").SetValue("1806", 0);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1").SetValue("1806", 0);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2").SetValue("1806", 0);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("1806", 0);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4").SetValue("1806", 0);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("CurrentLevel", 0);
            Registry.CurrentUser.Flush();
        }

        private void EnableSecurityZones()
        {
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2").SetValue("1806", 1);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("1806", 1);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4").SetValue("1806", 3);
            Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("CurrentLevel", 0x11500);
            Registry.CurrentUser.Flush();
        }

        private void linkSingleApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables (*.EXE;*.MSI;*.MSU;*.BAT;*.CMD)|*.EXE;*.MSI;*.MSU;*.BAT;*.CMD";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var app = FileProperties.GetApplicationInfoFromFilePath(openFileDialog.FileName);
                additionalConfigApps.Add(app);
                clbAdditionalConfigurations.Items.Add(app.ToString());
                int idx = clbAdditionalConfigurations.Items.Count - 1;
                clbAdditionalConfigurations.SetItemCheckState(idx, CheckState.Checked);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
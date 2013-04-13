using ApplicationInstaller.Classes;
using ApplicationInstaller.Schemas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public App servicePack
        { get; set; }

        public InstallInformationHolder installInformationHolder
        { get; set; }

        public ApplicationInstaller()
        {
            EnsureDirectoryStructure();
            SaveInternetSettingZones();
            additionalConfigApps = new List<App>();
            InitializeComponent();
            OsName = OsInformation.getOSName();
            gbName.Text = OsName;
            LoadWindowsUpdatesCofig();
            LoadRegistryFiles();
            LoadApplicationConfig();
        }

        private void EnsureDirectoryStructure()
        {
            DirectoryInfo configs = new DirectoryInfo(@"Configs\");
            if (!configs.Exists)
            {
                configs.Create();
            }

            DirectoryInfo registry = new DirectoryInfo(@"Registry\");
            if (!registry.Exists)
            {
                registry.Create();
            }
        }

        /// <summary>
        /// In the in the relative path to the Configs folder, look for an XML file that
        /// matches a slugified version of the current Windows name and service pack version
        /// 
        /// E.g. Windows 7 Service Pack 1 64-bit will look for a file with the name of:
        /// windows-7-service-pack-1-64-bit.xml
        /// </summary>
        private void LoadWindowsUpdatesCofig()
        {
            String filePath = String.Format(@"Configs\{0}.xml", Slugifier.GenerateSlug(OsName));
            List<App> listUpdates = new List<App>();
            if (File.Exists(filePath))
            {
                listUpdates = GenericXmlProcessor<App>.DeserializeXMLToList(filePath);
                cbWindowsUpdates.Text = String.Format("{0} ({1})", cbWindowsUpdates.Text, listUpdates.Count);
            }
            
            if ((listUpdates.Count == 0) || (!File.Exists(filePath)))
            {
                cbWindowsUpdates.Checked = false;
                cbWindowsUpdates.Enabled = false;
            }
        }

        /// <summary>
        /// In the in the relative path to the Configs folder, look for an XML named 
        /// Applications.xml which is the default apps to install
        /// 
        /// If it is not there or there are no apps in the Applications.xml file then
        /// set checkboxes and checked list box to disabled.
        /// </summary>
        private void LoadApplicationConfig()
        {
            String filePath = @"Configs\Applications.xml";
            List<App> listApps = new List<App>();

            if (File.Exists(filePath))
            {
                listApps = GenericXmlProcessor<App>.DeserializeXMLToList(filePath);
                foreach (App app in listApps)
                {
                    checkedListBoxApps.Items.Add(app.ToString());
                    int idx = checkedListBoxApps.Items.Count - 1;
                    checkedListBoxApps.SetItemCheckState(idx, CheckState.Checked);
                }
            }

            if ((listApps.Count == 0) || (!File.Exists(filePath)))
            {
                cbAppToggle.Enabled = false;
                checkedListBoxApps.Enabled = false;
            }
        }

        /// <summary>
        /// Get all of the registry files in the relative Registry folder and add the filename
        /// to the registry checkedlistbox and check the added file.
        /// </summary>
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

        /// <summary>
        /// Hides this current form, instantiates a new instance of the Configuration
        /// Builder form and shows that instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form ConfigBuilder = new ConfigBuilder();
            ConfigBuilder.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// When the "(Un)Select all applications" checkbox is ticked, either select all the
        /// items or unselect all the items in the checkedListBoxApps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Not sure if I really need to write this but -- disables all items on the form.
        /// 
        /// This and EnableAllItems should probably be either refactored or removed
        /// </summary>
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

        /// <summary>
        /// Show a dialog window that allows the user to select an additional registry files
        /// to be processed when the installer is run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkAddRegistryFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog addRegistryFilesDialog = new OpenFileDialog();
            addRegistryFilesDialog.Filter = "Registry Files (*.REG)|*.REG;";
            addRegistryFilesDialog.Multiselect = true;
            addRegistryFilesDialog.Title = "Select Registry Files";
            addRegistryFilesDialog.InitialDirectory = Path.Combine(Application.StartupPath, @"Registry");
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
        
        /// <summary>
        /// Shows a open file dialog box that allows the user to select addition configuration
        /// files that will be added to the list of items to processed when the installer is run
        /// 
        /// The default start location is the relative Configs folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkAdditionalConfigs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog additionalConfigFilesDialog = new OpenFileDialog();
            additionalConfigFilesDialog.Filter = "Config Files (*.XML)|*.XML;";
            additionalConfigFilesDialog.Multiselect = true;
            additionalConfigFilesDialog.Title = "Additional Config Files";
            additionalConfigFilesDialog.InitialDirectory = Path.Combine(Application.StartupPath, @"Configs");
            if (additionalConfigFilesDialog.ShowDialog() == DialogResult.OK)
            {
                cbAdditional.CheckState = CheckState.Checked;
                foreach (var filename in additionalConfigFilesDialog.FileNames)
                {
                    List<App> additionalApps = GenericXmlProcessor<App>.DeserializeXMLToList(filename);
                    additionalConfigApps.AddRange(additionalApps);
                }
                UpdateCheckedListAdditionalConfigApps();
             }
        }

        /// <summary>
        /// First sort the addition config apps list first by whether or not the app has
        /// an installation switch (apps with switches are considered silent and will be
        /// at the top of the list) then by size (largest to smallest).
        /// 
        /// After sorting clear the clbAdditionalConfiguration and add every app in the
        /// additionalConfigApps list to the check box.
        /// </summary>
        private void UpdateCheckedListAdditionalConfigApps()
        {
            additionalConfigApps.Sort(
                delegate(App app1, App app2)
                {
                    return
                        (
                        app2.InstallSwitch.CompareTo(app1.InstallSwitch) != 0
                        ? app2.InstallSwitch.CompareTo(app1.InstallSwitch)
                        : app2.FileSize.CompareTo(app1.FileSize)
                        );
                });

            clbAdditionalConfigurations.Items.Clear();

            foreach (var app in additionalConfigApps)
            {
                clbAdditionalConfigurations.Items.Add(app.ToString());
                int idx = clbAdditionalConfigurations.Items.Count - 1;
                clbAdditionalConfigurations.SetItemCheckState(idx, CheckState.Checked);
            }
        }

        /// <summary>
        /// Shows and open file dialog box that allows the user to install a single executable
        /// file of types exe, msi or msu. After they select a file another dialog window will
        /// show prompting the user to enter any switches they wish to include when installing
        /// the file. The default that is shown to them is "/unattent /warnrestart"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbServicePack_CheckedChanged(object sender, EventArgs e)
        {
            if (cbServicePack.Checked)
            {
                DisableAllItems();
                OpenFileDialog servicePackDialog = new OpenFileDialog();
                servicePackDialog.Filter = "Executables (*.exe;*.msi;*.msu)|*.EXE;*.MSI;*.MSU|All files (*.*)|*.*";
                servicePackDialog.Multiselect = false;
                servicePackDialog.Title = "Select Service Pack";
                if (servicePackDialog.ShowDialog() == DialogResult.OK)
                {
                    servicePack = new App(servicePackDialog.FileName);
                    servicePackSwitches = "/unattend /warnrestart";
                    servicePack.InstallSwitch = SingleFileSwitchesPrompt(servicePackSwitches);
                }
                else
                {
                    cbServicePack.CheckState = CheckState.Unchecked;
                }

            }
            else
            {
                EnableAllitems();
                servicePackFilePath = String.Empty;
                servicePackSwitches = "/unattend /warnrestart";
            }
        }

        /// <summary>
        /// Shows a dialog box that allows the user to manually type in switches
        /// or argument that will be used during the single file installation.
        /// </summary>
        /// <param name="defaultSwitch">The default switch which is shown in the text box to the user</param>
        /// <returns>The switch that is the text box when the user presses return</returns>
        private String SingleFileSwitchesPrompt(String defaultSwitch)
        {
            Form prompt = new Form();
            prompt.Width = 373;
            prompt.Height = 100;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = "Switches / Arguments";
            Label textLabel = new Label() { Left = 10, Top = 10, Width = 120, Text = prompt.Text.ToString() };
            TextBox textBox = new TextBox() { Left = 130, Top = 8, Width = 220, Text = defaultSwitch};
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 80, Top = 33 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }

        /// <summary>
        /// This disables the Internet / Windows Explorer sercurity zones whilst running the installer.
        /// 
        /// The reason for doing this is if the files are downloaded from the internet (which is almost
        /// a guranteed thing) Windows will prompt the user every time a new file installtion is started
        /// warning them that it may be unsafe to install the file which would defeat the purpose of
        /// this silent installer.
        /// 
        /// See http://support.microsoft.com/kb/182569
        /// </summary>
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

        /// <summary>
        /// Reverses the changes of DisableSecurityZones be setting them back to the default levels if the
        /// created registry file is there. If not it reverts to what are believed to be standard settings.
        /// </summary>
        private void EnableSecurityZones()
        {
            String filename = @"Registry\InternetSettingsBackup.reg";
            if (File.Exists(filename))
            {
                Process regeditProcess = Process.Start("regedit.exe", String.Format("/s {0}", filename));
                regeditProcess.WaitForExit();
            }
            else
            {
                String message = String.Format("Couldn't find {0} to restore Internet Settings.\nFalling back to pre-determined defaults", filename);
                MessageBox.Show(message);
                Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\2").SetValue("1806", 1);
                Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("1806", 1);
                Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\4").SetValue("1806", 3);
                Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3").SetValue("CurrentLevel", 0x11500);
                Registry.CurrentUser.Flush();
            }
        }

        /// <summary>
        /// Show open file dialog box that allows a user to select a singal file that will be added
        /// to the additional applications checkedlistbox. After a file is selected show the 
        /// SingleSFileSwitchesPrompt set the app's InstallSwitch to the returned value then
        /// add it to the checkedlistbox in the correct order
        /// 
        /// (see comments on UpdateCheckedListAdditionalConfigApps() for ordering)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkSingleApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables (*.exe;*.msi;*.msu;*.bat;*.cmd)|*.EXE;*.MSI;*.MSU;*.BAT;*.CMD";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                App app = new App(openFileDialog.FileName);
                app.InstallSwitch = SingleFileSwitchesPrompt("");
                additionalConfigApps.Add(app);
                UpdateCheckedListAdditionalConfigApps();
                /*clbAdditionalConfigurations.Items.Add(app.ToString());
                int idx = clbAdditionalConfigurations.Items.Count - 1;
                clbAdditionalConfigurations.SetItemCheckState(idx, CheckState.Checked);*/
            }
        }

        /// <summary>
        /// Close the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LastNameChanged(object sender, EventArgs e)
        {
            updateComputerName();
            updateDescription();
        }

        private void firstNameChanged(object sender, EventArgs e)
        {
            updateComputerName();
            updateDescription();
        }

        private void updateComputerName()
        {
            if (tbFirstName.Text.ToString().Length > 0)
            {
                computerName.Text = "ws" + tbFirstName.Text.ToString()[0] + tbLastName.Text.ToString();
            }
        }

        private void updateDescription()
        {
            tbDescription.Text = tbFirstName.Text.ToString() + " " + tbLastName.Text.ToString() + "'s Computer";
        }

        /// <summary>
        /// Show the EditSwitches form if the Switches.xml file is there else show an exclamation dialog box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String SwitchesConfigFile = @"Configs\Switches.xml";
            if (File.Exists(SwitchesConfigFile))
            {
                this.Hide();
                List<Switches> switches = GenericXmlProcessor<Switches>.DeserializeXMLToList(SwitchesConfigFile);
                EditSwitches SwitchesForm = new EditSwitches(this, switches);
                SwitchesForm.ShowDialog();
            }
            else
            {
                String ErrorMessage = String.Format("Couldn't load the switches config file: {0}", SwitchesConfigFile);
                MessageBox.Show(ErrorMessage, "Couldn't load Switches Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Show();
        }

        /// <summary>
        /// When the "(Un)Select all applications" checkbox is ticked, either select all the
        /// items or unselect all the items in the cbAdditional
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAdditional_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAdditionalConfigurations.Items.Count; i++)
            {
                clbAdditionalConfigurations.SetItemCheckState(i, (cbAdditional.Checked ? CheckState.Checked : CheckState.Unchecked));
            }
            if (cbAdditional.Checked)
            {
                cbAdditional.Text = "Unselect all applications";
            }
            else
            {
                cbAdditional.Text = "Select all applications";
            }
        }

        /// <summary>
        /// Processes the selected installations and configuartions the user selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabelInstall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BuildHolder();
            InstallPrompt();
            installInformationHolder = null;
        }

        /// <summary>
        /// Instantiates an instance of InstallInformationHolder which holds all the
        /// selected applications, updates and registry files to be installed or updated
        /// </summary>
        private void BuildHolder()
        {
            installInformationHolder = new InstallInformationHolder(cbWindowsUpdates.Checked);

            // Service Pack Information
            installInformationHolder.installServicePack = false;
            if (servicePack != null)
            {
                installInformationHolder.installServicePack = true;
                installInformationHolder.servicePack = servicePack;
            }
            else
            {
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
        }

        private void InstallPrompt()
        {
            DisableSecurityZones();
            this.Hide();
            InstallInfoForm installInfoForm = new InstallInfoForm(installInformationHolder);
            installInfoForm.ShowDialog();
            this.Show();
            EnableSecurityZones();
            linkStartInstall.Enabled = true;
        }

        /// <summary>
        /// Collects all selects applications and registry files and writes them to a command / batch
        /// to remove the need for this installer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeCurrentSelectionToBatchFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog scriptFileDialog = new SaveFileDialog();
            scriptFileDialog.Filter = "Command File (*.CMD)|*.cmd;|Batch File (*.BAT)|*.bat";
            scriptFileDialog.Title = "Generate Script File";
            if (scriptFileDialog.ShowDialog() == DialogResult.OK)
            {
                BuildHolder();
                installInformationHolder.WriteScriptFile(scriptFileDialog.FileName);
            }
        }

        /// <summary>
        /// Saves the current Zone Internet Settings to Registry\InternetSEttingsBackup.reg
        /// </summary>
        private static void SaveInternetSettingZones()
        {
            using (StreamWriter internetSettingsFilePath = new StreamWriter(@"Registry\InternetSettingsBackup.reg", false))
            {
                internetSettingsFilePath.Write("Windows Registry Editor Version 5.00\n\n");
                RegistryKey baseRegistryKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones");
                string[] subKeyNames = baseRegistryKey.GetSubKeyNames();
                foreach (var subKeyName in subKeyNames)
                {
                    var subKey = baseRegistryKey.OpenSubKey(subKeyName);
                    var value = subKey.GetValue("1806", null);
                    if (value != null)
                    {
                        String something = String.Format("[{0}]\n", subKey.ToString());
                        String dword = String.Format("\"1086\"=dword:{0:00000000}\n\n", value);
                        internetSettingsFilePath.Write(something);
                        internetSettingsFilePath.Write(dword);
                    }
                }
            }
        }
    }
}
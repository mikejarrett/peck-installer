using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using ApplicationInstaller.Classes;
using System.Xml.Serialization;

namespace ApplicationInstaller
{
    public partial class ApplicationsBuilder : Form
    {
        public int rowId
        { get; set; }

        public ApplicationsBuilder()
        {
            this.rowId = -1;
            InitializeComponent();
        }

        private bool WithErrors()
        {
            if (this.tbApplicationName.Text.Trim() == String.Empty)
                return true; // Returns true if no input or only space is found
            if (this.tbFilename.Text.Trim() == String.Empty)
                return true;
            if (this.tbRelativePath.Text.Trim() == String.Empty)
                return true;
            if (this.tbAbsolutePath.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (WithErrors() == true)
            {
                MessageBox.Show("A application name, filename and relative path are required");
            }
            else if (WithErrors() == false && rowId == -1)
            {
                this.gridviewApplicationList.Rows.Add(
                    this.tbApplicationName.Text,
                    this.tbFilename.Text,
                    this.tbAbsolutePath.Text,
                    Regex.Replace(this.tbRelativePath.Text, @"[a-zA-Z][:]", ""),
                    this.cbSwitches.Text,
                    this.tbVersion.Text
                );
                clearFields();
            }
            else if (WithErrors() == false && rowId != -1)
            {
                DataGridViewRow row = this.gridviewApplicationList.Rows[rowId];
                row.Cells["applicationName"].Value = this.tbApplicationName.Text.ToString();
                row.Cells["filename"].Value = this.tbFilename.Text.ToString();
                row.Cells["relativePath"].Value = Regex.Replace(this.tbRelativePath.Text, @"[a-zA-Z][:]", "").ToString();
                row.Cells["absolutePath"].Value = this.tbAbsolutePath.Text.ToString();
                row.Cells["installSwitches"].Value = this.cbSwitches.Text.ToString();
                row.Cells["version"].Value = this.tbVersion.Text.ToString();
                clearFields();
            }
        }

        private void clearFields()
        {
            this.tbApplicationName.Text = String.Empty;
            this.tbFilename.Text = String.Empty;
            this.tbAbsolutePath.Text = String.Empty;
            this.tbRelativePath.Text = String.Empty;
            this.cbSwitches.Text = String.Empty;
            this.tbVersion.Text = String.Empty;
            this.rowId = -1;
        }

        private void updateFieldsFromSelectedFile()
        {
            // Displays an OpenFileDialog so the user can select a application to install.
            // Parse the file and path and attempt to retrieve filename, version, absolute and
            // relative paths.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable & Scripts|*.exe;*.cmd;*.bat;*.js|All Files|*.*";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                String appName;
                String version;
                FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
                String directoryPath = Path.GetDirectoryName(openFileDialog.FileName);
                String filename = Path.GetFileName(openFileDialog.FileName);
                String fileInfoAppName = fileInfo.ProductName.ToString();
                String fileInfoVersion = fileInfo.ProductVersion.ToString();

                if (fileInfoAppName != String.Empty)
                { appName = fileInfoAppName; }
                else
                { appName = Regex.Replace(Path.GetFileNameWithoutExtension(openFileDialog.FileName), @"[^a-zA-Z]", ""); }

                if (fileInfoVersion != String.Empty)
                { version = fileInfoVersion; }
                else
                { version = Regex.Replace(filename, @"\D", ""); }

                this.tbApplicationName.Text = appName;
                this.tbFilename.Text = filename;
                this.tbAbsolutePath.Text = directoryPath;
                this.tbRelativePath.Text = Regex.Replace(directoryPath, @"[a-zA-Z][:]", "");
                this.tbVersion.Text = version;
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            this.tbApplicationName.Text = String.Empty;
            this.tbFilename.Text = String.Empty;
            this.tbAbsolutePath.Text = String.Empty;
            this.tbRelativePath.Text = String.Empty;
            this.cbSwitches.Text = String.Empty;
            this.tbVersion.Text = String.Empty;
        }

        private void btnWriteConfig_Click(object sender, EventArgs e)
        {
            // Show save to file dialog that will either over-write an existing
            // XML file or create a new one.
            int rowCount = this.gridviewApplicationList.Rows.Count;
            if (rowCount <= 1)
            {
                MessageBox.Show("Nothing to write to configuration file");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Config file|*.xml";
                saveFileDialog.Title = "Save the config file";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    // Go through each row of the DataGridView and serialize the data
                    // to be written our to the newly created XML file.
                    List<App> apps = new List<App>();
                    for (int i = 0; i < this.gridviewApplicationList.Rows.Count - 1; ++i)
                    {
                        DataGridViewRow row = this.gridviewApplicationList.Rows[i];
                        App application = new App();
                        application.ApplicationName = row.Cells["applicationName"].Value.ToString();
                        application.Filename = row.Cells["filename"].Value.ToString();
                        application.RelativePath = row.Cells["relativePath"].Value.ToString();
                        application.AbsolutePath = row.Cells["absolutePath"].Value.ToString();
                        application.InstallSwitch = row.Cells["installSwitches"].Value.ToString();
                        application.Version = row.Cells["version"].Value.ToString();
                        apps.Add(application);
                    }

                    if (apps.Count > 0)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<App>));
                        TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
                        serializer.Serialize(textWriter, apps);
                        textWriter.Close();
                        this.gridviewApplicationList.Rows.Clear();
                        MessageBox.Show("Config written successfully to: " + saveFileDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Nothing to write to configuration file");
                    }
                }
            }
        }

        private void lbAppName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateFieldsFromSelectedFile();
        }

        private void lbFilename_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateFieldsFromSelectedFile();
        }

        private void lbAbsolutePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateFieldsFromSelectedFile();
        }

        private void lbRelativePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateFieldsFromSelectedFile();
        }

        private void gridviewApplicationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.gridviewApplicationList.Rows[e.RowIndex];
            this.tbApplicationName.Text = row.Cells["applicationName"].Value.ToString();
            this.tbFilename.Text = row.Cells["filename"].Value.ToString();
            this.tbRelativePath.Text = row.Cells["relativePath"].Value.ToString();
            this.tbAbsolutePath.Text = row.Cells["absolutePath"].Value.ToString();
            this.cbSwitches.Text = row.Cells["installSwitches"].Value.ToString();
            this.tbVersion.Text = row.Cells["version"].Value.ToString();
            this.rowId = e.RowIndex;
        }
    }

}

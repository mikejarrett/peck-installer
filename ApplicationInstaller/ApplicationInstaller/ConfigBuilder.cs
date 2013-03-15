using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using ApplicationInstaller.Classes;


namespace ApplicationInstaller
{
    public partial class ConfigBuilder : Form
    {
        public ConfigBuilder()
        {
            this.RowId = -1;
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                OpenPreviousConfigFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                UpdateFieldsFromSelectedFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.G))
            {
                GenerateConfigurationFromFolder();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //I am not in love with this. Refactor and make it freaking work!!
        private int rowId = -1;
        public int RowId
        {
            get { return rowId; }
            set
            {
                if (value == 0 || value == -1)
                {
                    rowId = -1;
                }
                else
                {
                    rowId = value;
                }
            }
        }

        private bool WithErrors()
        {
            // TODO: A lot of repeated code here. Clean this up.
            // Returns true if no input or only space is found
            if (this.tbApplicationName.Text.Trim() == String.Empty)
                return true; 
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
                // Poorman's validation. It's bad and I should feel bad.
                MessageBox.Show("A application name, filename, absolute and relative path are required");
            }
            else if (WithErrors() == false && RowId == -1)
            {
                // If a previously filled row isn't selected, add the application
                // info to the datagridview
                AddRowToBottomOfDataGridView();
                clearFields();
            }
            else if (WithErrors() == false && RowId != -1)
            {
                // If we are editing a previous application info, add it back to the datagridview
                AddToSelectRowOfDataGridView();
            }
        }

        private void AddRowToBottomOfDataGridView()
        {
            this.dgvApplicationList.Rows.Add(
                this.tbApplicationName.Text,
                this.tbFilename.Text,
                this.tbAbsolutePath.Text,
                Regex.Replace(this.tbRelativePath.Text, @"[a-zA-Z][:]", ""),
                this.cbSwitches.Text,
                this.tbVersion.Text,
                this.cbArchitecture.Text
            );
        }

        private void AddToSelectRowOfDataGridView()
        {
            DataGridViewRow row = this.dgvApplicationList.Rows[RowId];
            row.Cells["applicationName"].Value = this.tbApplicationName.Text.ToString();
            row.Cells["filename"].Value = this.tbFilename.Text.ToString();
            row.Cells["relativePath"].Value = Regex.Replace(this.tbRelativePath.Text, @"[a-zA-Z][:]", "").ToString();
            row.Cells["absolutePath"].Value = this.tbAbsolutePath.Text.ToString();
            row.Cells["installSwitches"].Value = this.cbSwitches.Text.ToString();
            row.Cells["version"].Value = this.tbVersion.Text.ToString();
            row.Cells["architecture"].Value = this.cbArchitecture.Text.ToString();
            clearFields();
        }

        private void btnWriteConfig_Click(object sender, EventArgs e)
        {
            // Show save to file dialog that will either over-write an existing
            // XML file or create a new one.
            int rowCount = this.dgvApplicationList.Rows.Count;
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
                    List<App> apps = ProcessDataGridViewRows();
                    if (apps.Count > 0)
                    {
                        XmlProcessor.WriteToXML(saveFileDialog.FileName, apps);
                        clearRows();
                        MessageBox.Show("Config written successfully to: " + saveFileDialog.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Nothing to write to configuration file");
                    }
                }
            }
        }

        private List<App> ProcessDataGridViewRows()
        {
            // Go through each row of the DataGridView and serialize the data
            // to be written our to the newly created XML file.
            List<App> apps = new List<App>();
            for (int i = 0; i < this.dgvApplicationList.Rows.Count - 1; ++i)
            {
                DataGridViewRow row = this.dgvApplicationList.Rows[i];
                App application = new App();
                application.ApplicationName = row.Cells["applicationName"].Value.ToString().Trim();
                application.Filename = row.Cells["filename"].Value.ToString().Trim();
                application.RelativePath = row.Cells["relativePath"].Value.ToString();
                application.AbsolutePath = row.Cells["absolutePath"].Value.ToString();
                application.InstallSwitch = row.Cells["installSwitches"].Value.ToString().Trim();
                application.Version = row.Cells["version"].Value.ToString().Trim();
                application.Architecture = row.Cells["architecture"].Selected.ToString();
                apps.Add(application);
            }
            return apps;
        }

        private void lbAppName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void lbFilename_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void lbAbsolutePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void lbRelativePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void selectAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void UpdateFieldsFromSelectedFile()
        {
            // Displays an OpenFileDialog so the user can select a application to install.
            // Parse the file and path and attempt to retrieve filename, version, absolute and
            // relative paths.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables & Scripts|*.exe;*.cmd;*.bat;|All Files|*.*";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<String> appInfo = FileProperties.GetApplicationInfoFromFilePath(openFileDialog.FileName.ToString());
                this.tbApplicationName.Text = appInfo[0];
                this.tbFilename.Text = appInfo[1];
                this.tbAbsolutePath.Text = appInfo[2];
                this.tbRelativePath.Text = appInfo[3];
                this.tbVersion.Text = appInfo[4];
                this.cbArchitecture.Text = appInfo[5];
            }
        }

        private void dgvApplicationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int lastRowIndex = this.dgvApplicationList.Rows.Count - 1;
                if (e.RowIndex != lastRowIndex)
                {
                    this.RowId = e.RowIndex;
                    updateGridDataRowSelected(this.dgvApplicationList.Rows[e.RowIndex]);
                }
                else
                {
                    clearFields();
                }
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateGridDataRowSelected(DataGridViewRow row)
        {
            // Take the info from the select rows and place it in the entry form 
            this.tbApplicationName.Text = row.Cells["applicationName"].Value.ToString();
            this.tbFilename.Text = row.Cells["filename"].Value.ToString();
            this.tbRelativePath.Text = row.Cells["relativePath"].Value.ToString();
            this.tbAbsolutePath.Text = row.Cells["absolutePath"].Value.ToString();
            try
            {
                this.cbSwitches.Text = row.Cells["installSwitches"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                this.cbSwitches.Text = String.Empty;
            }
            try
            {
                this.tbVersion.Text = row.Cells["version"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                this.tbVersion.Text = String.Empty;
            }
            try
            {
                this.cbArchitecture.Text = row.Cells["architecture"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                this.tbVersion.Text = String.Empty;
            }
        }

        private void GenerateConfigFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateConfigurationFromFolder();
        }

        private void GenerateConfigurationFromFolder()
        {
            // Take the selected directory and sub-directories and find all .exe, .bat, 
            // .cmd, .msi, .msu files and adds them DataGridView
            clearRows();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder to process...";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.EnumerateFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories)
                    .Where(s =>
                        s.EndsWith(".exe", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".bat", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".cmd", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".msi", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".msu", StringComparison.OrdinalIgnoreCase)
                    );

                foreach (string file in files)
                {
                    List<String> appInfo = FileProperties.GetApplicationInfoFromFilePath(file.ToString());
                    this.dgvApplicationList.Rows.Add(appInfo[0], appInfo[1], appInfo[2], appInfo[3], String.Empty, appInfo[4], String.Empty);
                }
            }
        }

        private void OpenPreviousConfigFile()
        {
            // Load previously saved configuration file.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Configutration File (*.xml)|*.xml|All Files|*.*";
            openFileDialog.Title = "Select a configuration file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var xmlvalidation = new XmlProcessor(openFileDialog.FileName);
                try
                {
                    foreach (List<String> appValues in xmlvalidation.DeserializeXML())
                    {
                        // Super brittle! I know I know! Looking into solving this
                        this.dgvApplicationList.Rows.Add(appValues[0], appValues[1], appValues[2], appValues[3], appValues[4], appValues[5]);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message.ToString(), "Bad Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPreviousConfigFile();
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnClearDataGridView_Click(object sender, EventArgs e)
        {
            clearRows();
        }

        private void clearRows()
        {
            // Not really needed but maybe a little nicer to read clearRows()
            // instead of the long command below
            this.dgvApplicationList.Rows.Clear();
        }

        private void clearFields()
        {
            this.tbApplicationName.Text = String.Empty;
            this.tbFilename.Text = String.Empty;
            this.tbAbsolutePath.Text = String.Empty;
            this.tbRelativePath.Text = String.Empty;
            this.cbSwitches.Text = String.Empty;
            this.tbVersion.Text = String.Empty;
            this.cbArchitecture.Text = String.Empty;
            this.RowId = -1;
        }


        // Sort out DataGridView stuff
        private void gridviewApplicationList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38 || e.KeyValue == 40)
            {
                DataGridViewRow row = this.dgvApplicationList.SelectedRows[0];
                this.RowId = row.Index;
                int lastRowIndex = this.dgvApplicationList.Rows.Count - 1;
                if (this.RowId != lastRowIndex)
                {
                    updateGridDataRowSelected(row);
                }
                else
                {
                    clearFields();
                }
            }
        }

       private void dgvCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
       {
           // If right mouse click and selected index is not -1 -- clear all selected
           // rows, select the row the mouse if over and show the context menu strip.
           if (e.Button == MouseButtons.Right)
           {
               int rowSelected = e.RowIndex;
               if (e.RowIndex != -1)
               {
                   this.dgvApplicationList.ClearSelection();
                   this.dgvApplicationList.Rows[rowSelected].Selected = true;
                   this.dgvApplicationList.ContextMenuStrip.Show(this.dgvApplicationList, e.Location);
               }
           }
       }

       private void menuDeleteRowDeleteItem_Click(object sender, EventArgs e)
       {
           // Delete application from the DataGridView
           DataGridViewRow row = this.dgvApplicationList.SelectedRows[0];
           this.dgvApplicationList.Rows.Remove(row);
       }
    }
}
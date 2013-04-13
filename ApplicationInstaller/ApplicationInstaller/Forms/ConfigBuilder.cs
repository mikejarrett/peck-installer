using ApplicationInstaller.Classes;
using ApplicationInstaller.Schemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ApplicationInstaller
{
    public partial class ConfigBuilder : Form
    {
        public List<Switches> switches
        { get; set; }

        public int SelectedRowId
        { get; set; }

        public ConfigBuilder()
        {
            SelectedRowId = -1;
            InitializeComponent();
            PopulateSwitches();
        }
        
        /// <summary>
        /// Checks if CTRL + O, CTRL + N or CTRL + G key combinations were pressed
        /// and executes the appropriate functs assocated with the key combos
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Field validation on application name, filename, relative path and absolute path fields
        /// </summary>
        /// <returns>True if required fields are filled in. False if any required field is empty.</returns>
        private bool WithErrors()
        {
            if (tbApplicationName.Text.Trim() == String.Empty)
                return true; 
            if (tbFilename.Text.Trim() == String.Empty)
                return true;
            if (tbRelativePath.Text.Trim() == String.Empty)
                return true;
            if (tbAbsolutePath.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        /// <summary>
        /// Validates form, if valid add the form information to the either the selected row
        /// or to the bottom of the datagridview 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                MessageBox.Show("A application name, filename, absolute and relative path are required");
            }
            else if (!WithErrors() && SelectedRowId == -1)
            {
                AddRowToBottomOfDataGridView();
                clearFields();
            }
            else if (!WithErrors() && SelectedRowId != -1)
            {
                AddToSelectRowOfDataGridView();
            }
        }

        private void AddRowToBottomOfDataGridView()
        {
            dgvApplicationList.Rows.Add(
                tbApplicationName.Text,
                tbFilename.Text,
                tbAbsolutePath.Text,
                Regex.Replace(tbRelativePath.Text, @"[a-zA-Z][:]", ""),
                cbSwitches.Text,
                tbVersion.Text,
                cbArchitecture.Text,
                tbFileSize.Text
            );
        }

        private void AddToSelectRowOfDataGridView()
        {
            DataGridViewRow row = dgvApplicationList.Rows[SelectedRowId];
            row.Cells["applicationName"].Value = tbApplicationName.Text.ToString();
            row.Cells["filename"].Value = tbFilename.Text.ToString();
            row.Cells["relativePath"].Value = Regex.Replace(tbRelativePath.Text, @"[a-zA-Z][:]", "").ToString();
            row.Cells["absolutePath"].Value = tbAbsolutePath.Text.ToString();
            row.Cells["installSwitches"].Value = cbSwitches.Text.ToString();
            row.Cells["version"].Value = tbVersion.Text.ToString();
            row.Cells["architecture"].Value = cbArchitecture.Text.ToString();
            row.Cells["FileSize"].Value = Convert.ToDouble(tbFileSize.Text.ToString());
            clearFields();
        }

        /// <summary>
        /// Show save to file dialog that will either over-write an existing XML file or create a new one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteConfig_Click(object sender, EventArgs e)
        {
            
            int rowCount = dgvApplicationList.Rows.Count;
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
                        GenericXmlProcessor<App>.WriteToXML(saveFileDialog.FileName, apps);
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

        /// <summary>
        /// Go through each row of the DataGridView and serialize the data to be written our 
        /// to the newly created XML file.
        /// </summary>
        /// <returns></returns>
        private List<App> ProcessDataGridViewRows()
        {
            List<App> apps = new List<App>();
            for (int i = 0; i < dgvApplicationList.Rows.Count - 1; ++i)
            {
                DataGridViewRow row = dgvApplicationList.Rows[i];
                App application = new App()
                {
                    Name = row.Cells["applicationName"].Value.ToString().Trim(),
                    Filename = row.Cells["filename"].Value.ToString().Trim(),
                    RelativePath = row.Cells["relativePath"].Value.ToString(),
                    AbsolutePath = row.Cells["absolutePath"].Value.ToString(),
                    InstallSwitch = row.Cells["installSwitches"].Value.ToString().Trim(),
                    Version = row.Cells["version"].Value.ToString().Trim(),
                    Architecture = String.Empty,
                    FileSize = 0.0
                };

                if (row.Cells["architecture"].Value != null)
                {
                    application.Architecture = row.Cells["architecture"].Value.ToString();
                }
                application.FileSize = Convert.ToDouble(row.Cells["FileSize"].Value.ToString());
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

        /// <summary>
        /// Displays an OpenFileDialog so the user can select a application to install. Parse the file 
        /// and path and attempt to retrieve filename, version, absolute and relative paths.
        /// </summary>
        private void UpdateFieldsFromSelectedFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables & Scripts|*.exe;*.cmd;*.bat;*.msu;*.msi|All Files|*.*";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                App app = new App(openFileDialog.FileName.ToString());
                tbApplicationName.Text = app.Name;
                tbFilename.Text = app.Filename;
                tbAbsolutePath.Text = app.AbsolutePath;
                tbRelativePath.Text = app.RelativePath;
                tbVersion.Text = app.Version;
                cbArchitecture.Text = app.Architecture;
                
                tbFileSize.Text = app.FileSize.ToString();
            }
        }

        private void GenerateConfigFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateConfigurationFromFolder();
        }

        /// <summary>
        /// Take the selected directory and sub-directories and find all .exe, .bat, 
        /// .cmd, .msi, .msu files and adds them DataGridView
        /// </summary>
        private void GenerateConfigurationFromFolder()
        {
            clearRows();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select folder to process...";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                clearRows();
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
                    AddAppToDataGridView(new App(file.ToString()));                
                }
            }
        }

        /// <summary>
        /// Load a previously saved configuration file into the DataGridView
        /// </summary>
        private void OpenPreviousConfigFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Configutration File (*.xml)|*.xml|All Files|*.*";
            openFileDialog.Title = "Select a configuration file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                clearRows();
                foreach (var app in GenericXmlProcessor<App>.DeserializeXMLToList(openFileDialog.FileName))
                {
                    AddAppToDataGridView(app);
                }
            }
        }

        /// <summary>
        /// Give an app add it's properties to the DataGridView Application List
        /// </summary>
        /// <param name="app">
        ///     And instance of an app either generated from a filename or loaded
        ///     from a configuration file
        /// </param>
        private void AddAppToDataGridView(App app)
        {
            dgvApplicationList.Rows.Add(app.Name, app.Filename, app.AbsolutePath,
                                        app.RelativePath, app.InstallSwitch,
                                        app.Version, app.Architecture, app.FileSize);
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

        /// <summary>
        /// Clears all the rows in the DataGridView Application List
        /// </summary>
        private void clearRows()
        {
            dgvApplicationList.Rows.Clear();
            SelectedRowId = -1;
        }

        /// <summary>
        /// Clears all form fields and resets the RowId to -1
        /// </summary>
        private void clearFields()
        {
            tbApplicationName.Text = String.Empty;
            tbFilename.Text = String.Empty;
            tbAbsolutePath.Text = String.Empty;
            tbRelativePath.Text = String.Empty;
            cbSwitches.Text = String.Empty;
            tbVersion.Text = String.Empty;
            cbArchitecture.Text = String.Empty;
            tbFileSize.Text = String.Empty;
            SelectedRowId = -1;
        }

        /// <summary>
        /// Given a selected row update the form field to reflect the information
        /// of the selected row
        /// </summary>
        /// <param name="row"></param>
        private void updateGridDataRowSelected(DataGridViewRow row)
        {
            // Take the info from the select rows and place it in the entry form 
            tbApplicationName.Text = row.Cells["applicationName"].Value.ToString();
            tbFilename.Text = row.Cells["filename"].Value.ToString();
            tbRelativePath.Text = row.Cells["relativePath"].Value.ToString();
            tbAbsolutePath.Text = row.Cells["absolutePath"].Value.ToString();
            tbFileSize.Text = row.Cells["FileSize"].Value.ToString();
            try
            {
                cbSwitches.Text = row.Cells["installSwitches"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                cbSwitches.Text = String.Empty;
            }
            try
            {
                tbVersion.Text = row.Cells["version"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                tbVersion.Text = String.Empty;
            }
            try
            {
                cbArchitecture.Text = row.Cells["architecture"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                cbArchitecture.Text = String.Empty;
            }
        }

        /// <summary>
        /// Handle keyboard events on the DataGridViewRow
        /// 
        /// PgUp = 33, PgDn = 34, Home = 35, End = 36, UpArrow = 38, Downarrow = 40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridviewApplicationList_KeyUp(object sender, KeyEventArgs e)
        {
            int[] keyvalues = new int[6] {33, 34, 35, 36, 38, 40};
            if (keyvalues.Contains<int>(e.KeyValue))
            {
                DataGridViewRow row = dgvApplicationList.SelectedRows[0];
                SelectedRowId = row.Index;
                int lastRowIndex = dgvApplicationList.Rows.Count - 1;
                if (SelectedRowId != lastRowIndex)
                {
                    updateGridDataRowSelected(row);
                }
                else 
                {  
                    clearFields();  
                }
            }
        }

        /// <summary>
        /// If right mouse click and selected index is not -1 -- clear all selected rows, 
        /// select the row the mouse if over and show the context menu strip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            { 
                LeftMouseClickDGV(e); 
            }
            else if (e.Button == MouseButtons.Right) 
            { 
                RightMouseClickDGV(e); 
            }
        }

        /// <summary>
        /// Handles left mouse clicking on the DataGridView Application List
        /// </summary>
        /// <param name="e"></param>
        private void LeftMouseClickDGV(DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int lastRowIndex = dgvApplicationList.Rows.Count - 1;
                if (e.RowIndex != lastRowIndex)
                {
                    SelectedRowId = e.RowIndex;
                    updateGridDataRowSelected(dgvApplicationList.Rows[e.RowIndex]);
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

        /// <summary>
        /// Handles right clicking on the DataGridView Application List
        /// 
        /// This will show an context menu that allows the user to delete the selected
        /// row
        /// </summary>
        /// <param name="e"></param>
        private void RightMouseClickDGV(DataGridViewCellMouseEventArgs e)
        {
            int rowSelected = e.RowIndex;
            if (e.RowIndex != -1)
            {
                dgvApplicationList.ClearSelection();
                dgvApplicationList.Rows[rowSelected].Selected = true;
                dgvApplicationList.ContextMenuStrip.Show(dgvApplicationList, e.Location);
            }
        }

        /// <summary>
        /// Deletes the selected row from the DataGridView Application List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDeleteRowDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvApplicationList.SelectedRows[0];
            dgvApplicationList.Rows.Remove(row);
        }

        /// <summary>
        /// Attempts to load the Switches.xml configuration file from the relative
        /// path of Configs. If it can't find it it shows a warning message dialog box
        /// </summary>
        private void PopulateSwitches()
        {
            String SwitchesConfigFile = @"Configs\Switches.xml";
            if (File.Exists(SwitchesConfigFile))
            {
                switches = GenericXmlProcessor<Switches>.DeserializeXMLToList(SwitchesConfigFile);
                cbSwitches.Items.Add(String.Empty);
                AddSwitchToComboBoxSwitches();
            }
            else
            {
                String ErrorMessage = String.Format("Couldn't load the switches config file:\n\n{0}", SwitchesConfigFile);
                MessageBox.Show(ErrorMessage, "Couldn't load Switches Config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Clears all items from the switches combo box then loops through
        /// the switches and adds them to the combo box
        /// </summary>
        private void AddSwitchToComboBoxSwitches()
        {
            cbSwitches.Items.Clear();
            foreach (var s in switches)
            {
                cbSwitches.Items.Add(s.Switch.ToString());
            }
        }

        /// <summary>
        /// Show the Switch Editor form that allows the user to add, remove or update
        /// any of the load switches. The user can also same the switches back out
        /// to the configuration file
        /// </summary>
        private void SwitchEditor()
        {
            EditSwitches SwitchesForm = new EditSwitches(this, switches);
            this.Hide();
            SwitchesForm.ShowDialog();
            this.Show();
            PopulateSwitches();
        }

        private void lblSwitches_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SwitchEditor();
        }

        private void switchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchEditor();
        }

        private void cbSwitches_Click(object sender, MouseEventArgs e)
        {
            cbSwitches.DroppedDown = true;
        }
    }
}
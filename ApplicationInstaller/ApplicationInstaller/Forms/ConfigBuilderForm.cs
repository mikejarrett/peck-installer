using ComputerUpdater.Classes;
using ComputerUpdater.Schemas;
using ComputerUpdater.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ComputerUpdater
{
    public partial class ConfigBuilder : Form
    {
        public List<Switches> switches
        { get; set; }

        public int SelectedRowId
        { get; set; }

        private Boolean IsExpanded
        { get; set; }

        private int originalHeight
        { get; set; }

        private int originalWidth
        { get; set; }

        private List<App> AppDataSource
        { get; set; }

        public ConfigBuilder()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            PopulateSwitches();
            SelectedRowId = -1;
            AppDataSource = new List<App>();
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
            else if (keyData == Keys.Escape)
            {
                this.Close();
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
        private void AddAppToListLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (WithErrors())
            {
                MessageBox.Show("A application name, filename, absolute and relative path are required");
            }
            else if (!WithErrors() && SelectedRowId == -1)
            {
                AddToApplicationsList(false);
                ClearFields();
                UpdateDataGridView();
            }
            else if (!WithErrors() && SelectedRowId != -1)
            {
                AddToApplicationsList(true);
                ClearFields();
                UpdateDataGridView();
            }
        }

        private void AddToApplicationsList(bool RowSelected = false)
        {
            App app = new App()
            {
                Name = tbApplicationName.Text,
                Filename = tbFilename.Text,
                AbsolutePath = tbAbsolutePath.Text,
                RelativePath = Regex.Replace(tbRelativePath.Text, @"[a-zA-Z][:]", ""),
                InstallSwitch = cbSwitches.Text,
                Version = tbVersion.Text,
                Architecture = cbArchitecture.Text,
                FileSize = double.Parse(tbFileSize.Text),
                Silent = cbSilent.Checked
            };
            if (RowSelected)
            {
                AppDataSource[SelectedRowId] = app;
            }
            else
            {
                AppDataSource.Add(app);
            }
        }

        private void UpdateDataGridView()
        {
            if (AppDataSource.Count() > 0)
            {
                dgvApplicationList.ColumnHeadersVisible = true;
                dgvApplicationList.Enabled = true;
                AppDataSource = (from app in AppDataSource
                                 orderby app.Silent descending,
                                 app.FileSize descending
                                 select app).ToList();
                var source = new BindingSource();
                source.DataSource = AppDataSource;
                dgvApplicationList.DataSource = source;
                UpdateDataGridViewHeaders();
            }
        }

        /// <summary>
        /// Show save to file dialog that will either over-write an existing XML file or create a new one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteConfigLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AppDataSource.Count() < 1)
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
                    GenericXmlProcessor<App>.WriteToXML(saveFileDialog.FileName, AppDataSource);
                    ClearRows();
                    MessageBox.Show("Config written successfully to: " + saveFileDialog.FileName);
                }
            }
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
            openFileDialog.Filter = "Executables & Scripts|*.exe;*.cmd;*.bat;*.msu;*.msi;*.msp|All Files|*.*";
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
        /// .cmd, .msi, .msu, .msp files and adds them DataGridView
        /// </summary>
        private void GenerateConfigurationFromFolder()
        {
            ClearFields();
            ClearRows();
            List<SwitchMapping> mappedSwitches = new List<SwitchMapping>();
            int determineSwitch = 0;
            String selectSwitch = String.Empty;

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
                        s.EndsWith(".msp", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".msu", StringComparison.OrdinalIgnoreCase)
                    );

                ShowAppSwitchMappingForm(ref determineSwitch, ref selectSwitch);
                mappedSwitches = GetMappedSwitches(mappedSwitches, determineSwitch);

                AppDataSource.Clear();
                foreach (string file in files)
                {
                    App newApp = new App(file.ToString());
                    newApp = UpdateAppSwitchMappedSwitches(mappedSwitches, determineSwitch, selectSwitch, newApp);
                    AppDataSource.Add(newApp);
                }
                UpdateDataGridView();
            }
        }

        private static App UpdateAppSwitchMappedSwitches(List<SwitchMapping> mappedSwitches, int determineSwitch, String selectSwitch, App newApp)
        {
            if (determineSwitch == 1)
            {
                foreach (var mappedSwitch in mappedSwitches)
                {
                    if (Levenshtein.Check(mappedSwitch.Name, newApp.Name, 70))
                    {
                        newApp.InstallSwitch = mappedSwitch.Switch;
                        newApp.Silent = true;
                        break;
                    }

                    if (Levenshtein.Check(mappedSwitch.Filename, newApp.Filename, 70))
                    {
                        newApp.InstallSwitch = mappedSwitch.Switch;
                        newApp.Silent = true;
                        break;
                    }
                }
            }
            else if (determineSwitch == 2)
            {
                newApp.InstallSwitch = selectSwitch;
            }
            return newApp;
        }

        private static List<SwitchMapping> GetMappedSwitches(List<SwitchMapping> mappedSwitches, int determineSwitch)
        {
            String generalMappingsConfig = @"Configs\AppSwitchMappings.xml";
            if (determineSwitch == 1 && File.Exists(generalMappingsConfig))
            {
                mappedSwitches = GenericXmlProcessor<SwitchMapping>.DeserializeXMLToList(generalMappingsConfig);
            }
            return mappedSwitches;
        }

        private static void ShowAppSwitchMappingForm(ref int determineSwitch, ref String selectSwitch)
        {
            using (var appSwitchMappingForm = new AppSwitchMappingForm())
            {
                var result = appSwitchMappingForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    determineSwitch = appSwitchMappingForm.radioButtonCheckedID;
                    selectSwitch = appSwitchMappingForm.strSwitch;
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
                ClearFields();
                ClearRows();
                AppDataSource = GenericXmlProcessor<App>.DeserializeXMLToList(openFileDialog.FileName);
                UpdateDataGridView();
            }
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPreviousConfigFile();
        }

        private void ClearListLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearRows();
        }

        private void ClearFieldsLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearFields();
        }

        /// <summary>
        /// Clears all the rows in the DataGridView Application List
        /// </summary>
        private void ClearRows()
        {
            AppDataSource.Clear();
            SelectedRowId = -1;
            UpdateDataGridView();
            dgvApplicationList.ColumnHeadersVisible = false;
            dgvApplicationList.Enabled = false;
            cbSilent.Checked = false;
        }

        /// <summary>
        /// Clears all form fields and resets the RowId to -1
        /// </summary>
        private void ClearFields()
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
        /// Given a selected row and update the form fields to reflect the information
        /// of the selected row
        /// </summary>
        /// <param name="row"></param>
        private void UpdateGridDataRowSelected(DataGridViewRow row)
        {
            // Take the info from the select rows and place it in the entry form 
            if (row.Index < AppDataSource.Count())
            {
                App app = AppDataSource[row.Index];
                tbApplicationName.Text = app.Name;
                tbFilename.Text = app.Filename;
                tbRelativePath.Text = app.RelativePath;
                tbAbsolutePath.Text = app.AbsolutePath;
                tbFileSize.Text = app.FileSize.ToString();
                cbSwitches.Text = app.InstallSwitch;
                tbVersion.Text = app.Version;
                cbArchitecture.Text = app.Architecture;
                cbSilent.Checked = app.Silent;
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
                    UpdateGridDataRowSelected(row);
                }
                else 
                {  
                    ClearFields();  
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
            if (e.RowIndex < AppDataSource.Count() && e.RowIndex != -1)
            {
                SelectedRowId = e.RowIndex;
                UpdateGridDataRowSelected(dgvApplicationList.Rows[e.RowIndex]);
            }
            else
            {
                ClearFields();
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
            if (e.RowIndex + 1 != AppDataSource.Count() && e.RowIndex != -1)
            {
                dgvApplicationList.ClearSelection();
                dgvApplicationList.Rows[e.RowIndex].Selected = true;
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
            int rowIndex = dgvApplicationList.SelectedRows[0].Index;
            if (rowIndex < AppDataSource.Count())
            {
                AppDataSource.Remove(AppDataSource[rowIndex]);
                UpdateDataGridView();
            }
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLoadConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenPreviousConfigFile();
        }

        private void UpdateDataGridViewHeaders()
        {
            dgvApplicationList.Columns["Silent"].Width = 50;
            dgvApplicationList.Columns["Silent"].DisplayIndex = 0;

            dgvApplicationList.Columns["AbsolutePath"].Visible = absolutePathToolStripMenuItem.Checked;
            dgvApplicationList.Columns["Architecture"].Visible = architectureToolStripMenuItem.Checked;
            dgvApplicationList.Columns["Filename"].Visible = filenameToolStripMenuItem.Checked;
            dgvApplicationList.Columns["Filesize"].Visible = filesizeToolStripMenuItem.Checked;
            dgvApplicationList.Columns["InstallSwitch"].Visible = switchesToolStripMenuItem1.Checked;
            dgvApplicationList.Columns["RelativePath"].Visible = relativePathToolStripMenuItem.Checked;
            dgvApplicationList.Columns["Version"].Visible = versionToolStripMenuItem.Checked;
            dgvApplicationList.Columns["Silent"].Visible = silentStripMenuItem.Checked;
            dgvApplicationList.Columns["InstallSwitch"].Visible = switchesToolStripMenuItem1.Checked;

            dgvApplicationList.Columns["AbsolutePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["Architecture"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["Filename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["Filesize"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["InstallSwitch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["RelativePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["Version"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvApplicationList.Columns["InstallSwitch"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void switchesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void silentStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void filenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void absolutePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void relativePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void filesizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void architectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridViewHeaders();
        }
    }
}
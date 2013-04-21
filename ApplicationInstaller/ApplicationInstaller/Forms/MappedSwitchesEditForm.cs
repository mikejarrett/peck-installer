using ComputerUpdater.Classes;
using ComputerUpdater.Schemas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ComputerUpdater
{
    public partial class MappedSwitchesEditForm : Form
    {
        public List<SwitchMapping> ListMappedSwitches
        { get; set; }

        public List<Switches> ListSwitches
        { get; set; }

        public int SelectedRowId
        { get; set; }

        public String SwitchMappingConfig = @"Configs\AppSwitchMappings.xml";

        public MappedSwitchesEditForm(List<Switches> switches)
        {
            ListSwitches = switches;
            ListMappedSwitches = new List<SwitchMapping>();
            SelectedRowId = -1;
            InitializeComponent();
            GetListMappedSwitches();
            PopulateMappedSwitchesDataGridView();
            PopulateSwitchesComboBox();
        }

        private void GetListMappedSwitches()
        {
            String mappedSwitchesFile = @"Configs\AppSwitchMappings.xml";
            if (File.Exists(mappedSwitchesFile))
            {
                ListMappedSwitches = GenericXmlProcessor<SwitchMapping>.DeserializeXMLToList(mappedSwitchesFile);
            }

            if (ListMappedSwitches.Count < 1)
            {
                MessageBox.Show("Couldn't find or load " + ListMappedSwitches);
            }
        }

        private void PopulateMappedSwitchesDataGridView()
        {
            dgvMappedSwitches.DataSource = null;
            dgvMappedSwitches.DataSource = ListMappedSwitches;
            dgvMappedSwitches.Columns[dgvMappedSwitches.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void PopulateSwitchesComboBox()
        {
            foreach (var obj in ListSwitches)
            {
                cbSwitches.Items.Add(obj.Switch.ToString());
            }
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
            if (cbSwitches.Text != null && cbSwitches.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        /// <summary>
        /// Clears all form fields and resets the RowId to -1
        /// </summary>
        private void ClearFields(int rowIndex = -1)
        {
            tbApplicationName.Text = String.Empty;
            tbFilename.Text = String.Empty;
            cbSwitches.Text = String.Empty;
            SelectedRowId = rowIndex;
            dgvMappedSwitches.ClearSelection();
            dgvMappedSwitches.CurrentCell = null;
        }

        /// <summary>
        /// Validates form, if valid add the form information to the either the selected row
        /// or to the bottom of the datagridview 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkAddToList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Boolean withErrors = WithErrors();
            if (withErrors)
            {
                MessageBox.Show("A application name, filename and switch are all required");
            }
            else if (!withErrors && SelectedRowId == -1)
            {
                AddSwitchMappingToList();
                ClearFields();
            }
            else if (!withErrors && SelectedRowId != -1)
            {
                AddToSelectRowOfDataGridView();
            }
        }

        private void AddSwitchMappingToList()
        {
            SwitchMapping sdf = new SwitchMapping() { Name = tbApplicationName.Text, Filename = tbFilename.Text, Switch = cbSwitches.Text };
            ListMappedSwitches.Insert(0, sdf);
            PopulateMappedSwitchesDataGridView();
        }

        private void AddToSelectRowOfDataGridView()
        {
            if (ListMappedSwitches[SelectedRowId].Filename == tbFilename.Text && ListMappedSwitches[SelectedRowId].Name == tbApplicationName.Text)
            {
                ListMappedSwitches[SelectedRowId].Switch = cbSwitches.Text.ToString();
                ClearFields();
                PopulateMappedSwitchesDataGridView();
            }
            else
            {
                AddSwitchMappingToList();
            }
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
            }
        }

        private void linkSelectAppName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void linkSelectFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateFieldsFromSelectedFile();
        }

        private void dgvMappedSwitchesMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int lastRowIndex = dgvMappedSwitches.Rows.Count - 1;
            try
            {
                if (e.RowIndex < lastRowIndex)
                {
                    SelectedRowId = e.RowIndex;
                    UpdateGridDataRowSelected(dgvMappedSwitches.Rows[e.RowIndex]);
                }
                else
                {
                    ClearFields(lastRowIndex);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Given a selected row update the form field to reflect the information
        /// of the selected row
        /// </summary>
        /// <param name="row"></param>
        private void UpdateGridDataRowSelected(DataGridViewRow row)
        {
            tbApplicationName.Text = row.Cells["Name"].Value.ToString();
            tbFilename.Text = row.Cells["Filename"].Value.ToString();
            try
            {
                cbSwitches.Text = row.Cells["Switch"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                cbSwitches.Text = String.Empty;
            }
        }

        /// <summary>
        /// Handle keyboard events on the DataGridViewRow
        /// 
        /// PgUp = 33, PgDn = 34, Home = 35, End = 36, UpArrow = 38, Downarrow = 40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMappedSwitchesKeyUpEvent(object sender, KeyEventArgs e)
        {
            int lastRowIndex = dgvMappedSwitches.Rows.Count - 1;

            List<int> keyvalues = new List<int>() { 33, 34, 35, 36, 38, 40 };
            try
            {
                DataGridViewRow row = dgvMappedSwitches.SelectedRows[0];
                SelectedRowId = row.Index;
                if (SelectedRowId < lastRowIndex)
                {
                    if (keyvalues.Contains(e.KeyValue))
                    {
                        UpdateGridDataRowSelected(row);
                    }
                    else if (e.KeyValue == (int)Keys.Delete)
                    {
                        ListMappedSwitches.RemoveAt(SelectedRowId);
                        ClearFields();
                        PopulateMappedSwitchesDataGridView();
                    }
                }
                else
                {
                    ClearFields(lastRowIndex);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ClearFields(lastRowIndex);
            }
        }

        private void SaveSwitchMapping()
        {
            GenericXmlProcessor<SwitchMapping>.WriteToXML(SwitchMappingConfig, ListMappedSwitches);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSwitchMapping();
        }

        private void saveAndExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSwitchMapping();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

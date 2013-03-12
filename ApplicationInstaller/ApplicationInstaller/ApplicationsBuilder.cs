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
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;


namespace ApplicationInstaller
{
    public partial class ApplicationsBuilder : Form
    {
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

        public ApplicationsBuilder()
        {
            this.RowId = -1;
            InitializeComponent();
        }

        private bool WithErrors()
        {
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
            else if (WithErrors() == false && RowId != -1)
            {
                // If we are editing a previous application info, add it back to the datagridview
                DataGridViewRow row = this.gridviewApplicationList.Rows[RowId];
                row.Cells["applicationName"].Value = this.tbApplicationName.Text.ToString();
                row.Cells["filename"].Value = this.tbFilename.Text.ToString();
                row.Cells["relativePath"].Value = Regex.Replace(this.tbRelativePath.Text, @"[a-zA-Z][:]", "").ToString();
                row.Cells["absolutePath"].Value = this.tbAbsolutePath.Text.ToString();
                row.Cells["installSwitches"].Value = this.cbSwitches.Text.ToString();
                row.Cells["version"].Value = this.tbVersion.Text.ToString();
                clearFields();
            }
        }

        private void updateFieldsFromSelectedFile()
        {
            // Displays an OpenFileDialog so the user can select a application to install.
            // Parse the file and path and attempt to retrieve filename, version, absolute and
            // relative paths.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables & Scripts|*.exe;*.cmd;*.bat;|All Files|*.*";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] appInfo = getApplicationInfoFromFilePath(openFileDialog.FileName.ToString());

                this.tbApplicationName.Text = appInfo[0];
                this.tbFilename.Text = appInfo[1];
                this.tbAbsolutePath.Text = appInfo[2];
                this.tbRelativePath.Text = appInfo[3];
                this.tbVersion.Text = appInfo[4];
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            clearFields();
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
                        application.ApplicationName = row.Cells["applicationName"].Value.ToString().Trim();
                        application.Filename = row.Cells["filename"].Value.ToString().Trim();
                        application.RelativePath = row.Cells["relativePath"].Value.ToString();
                        application.AbsolutePath = row.Cells["absolutePath"].Value.ToString();
                        application.InstallSwitch = row.Cells["installSwitches"].Value.ToString().Trim();
                        application.Version = row.Cells["version"].Value.ToString().Trim();
                        apps.Add(application);
                    }

                    if (apps.Count > 0)
                    {
                        // Write the apps out to the selected configuration files
                        XmlSerializer serializer = new XmlSerializer(typeof(List<App>));
                        TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
                        serializer.Serialize(textWriter, apps);
                        textWriter.Close();
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

        private void selectAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateFieldsFromSelectedFile();
        }

        private void gridviewApplicationList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int lastRowIndex = this.gridviewApplicationList.Rows.Count - 1;
                if (e.RowIndex != lastRowIndex)
                {
                    this.RowId = e.RowIndex;
                    updateGridDataRowSelected(this.gridviewApplicationList.Rows[e.RowIndex]);
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
        }

        private void generateConfigurationFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Take the selected directory and sub-directories and find all .exe, .bat, 
            // .cmd, .msi, .msu files and adds them DataGridView
            clearRows();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
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
                    string[] appInfo = getApplicationInfoFromFilePath(file.ToString());
                    this.gridviewApplicationList.Rows.Add(appInfo[0], appInfo[1], appInfo[2], appInfo[3], String.Empty, appInfo[4]);
                }
            }
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Load previously saved configuration file.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Configutration File (*.xml)|*.xml|All Files|*.*";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bool validation_errors = false;
                XDocument xdocApps;
                XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
                Stream xsdStream = this.GetType().Assembly.GetManifestResourceStream("ApplicationInstaller.Validation.Applications.xsd");
                XmlReader schemaReader = XmlReader.Create(xsdStream);
                xmlSchemaSet.Add("", schemaReader);
                try
                {
                    xdocApps = XDocument.Load(openFileDialog.FileName);

                    xdocApps.Validate(xmlSchemaSet, (o, err) =>
                    {
                        MessageBox.Show(err.Message, "Invalid XML File",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        validation_errors = true;
                    });

                    if (validation_errors == false)
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(List<App>));
                        XmlReader reader = xdocApps.CreateReader();
                        reader.MoveToContent();
                        List<App> apps = (List<App>)deserializer.Deserialize(reader);

                        clearRows();
                        for (int i = 0; i < apps.Count; ++i)
                        {
                            this.gridviewApplicationList.Rows.Add(
                                apps[i].ApplicationName.ToString(),
                                apps[i].Filename.ToString(),
                                apps[i].AbsolutePath.ToString(),
                                apps[i].RelativePath.ToString(),
                                apps[i].InstallSwitch.ToString(),
                                apps[i].Version.ToString()
                            );
                        }
                    }
                }
                catch (Exception error)
                {
                    // TODO: Add logging - don't throw nasty errors at the user!
                    MessageBox.Show(error.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearRows();
        }

        private void clearRows()
        {
            // Not really needed but maybe a little nicer to read clearRows()
            // instead of the long command below
            this.gridviewApplicationList.Rows.Clear();
        }

        private void clearFields()
        {
            this.tbApplicationName.Text = String.Empty;
            this.tbFilename.Text = String.Empty;
            this.tbAbsolutePath.Text = String.Empty;
            this.tbRelativePath.Text = String.Empty;
            this.cbSwitches.Text = String.Empty;
            this.tbVersion.Text = String.Empty;
            this.RowId = -1;
        }

       private void gridviewApplicationList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38 || e.KeyValue == 40)
            {
                DataGridViewRow row = this.gridviewApplicationList.SelectedRows[0];
                this.RowId = row.Index;
                int lastRowIndex = this.gridviewApplicationList.Rows.Count - 1;
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

       private string[] getApplicationInfoFromFilePath(String filePath)
       {
           // XXX: Maybe pull this out and add to a helper class?
           // Given a filepath attempt to get the information needed to populate
           // the data entry form
           String appName;
           String version;
           String fileInfoAppName;
           String fileInfoVersion;
           FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(filePath);
           String directoryPath = Path.GetDirectoryName(filePath);
           String filename = Path.GetFileName(filePath);
           try
           {
               fileInfoAppName = fileInfo.ProductName.ToString();
           }
           catch (System.NullReferenceException)
           {
               fileInfoAppName = String.Empty;
           }
           try
           {
               fileInfoVersion = fileInfo.ProductVersion.ToString();
           }
           catch (System.NullReferenceException)
           {
               fileInfoVersion = String.Empty;
           }

           if (fileInfoAppName != String.Empty)
           { appName = fileInfoAppName; }
           else
           { appName = Regex.Replace(Path.GetFileNameWithoutExtension(filePath), @"[^a-zA-Z]", ""); }

           if (fileInfoVersion != String.Empty)
           { version = fileInfoVersion; }
           else
           { version = Regex.Replace(filename, @"\D", ""); }

           String relativePath = Regex.Replace(directoryPath, @"[a-zA-Z][:]", "");
           return new string[] { appName, filename, directoryPath, relativePath, version };
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
                   this.gridviewApplicationList.ClearSelection();
                   this.gridviewApplicationList.Rows[rowSelected].Selected = true;
                   this.gridviewApplicationList.ContextMenuStrip.Show(this.gridviewApplicationList, e.Location);
               }
           }
       }

       private void menuDeleteRowDeleteItem_Click(object sender, EventArgs e)
       {
           // Delete application from the DataGridView
           DataGridViewRow row = this.gridviewApplicationList.SelectedRows[0];
           this.gridviewApplicationList.Rows.Remove(row);
       }
    }
}

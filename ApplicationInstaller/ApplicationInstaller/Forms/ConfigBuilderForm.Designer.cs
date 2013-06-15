namespace ComputerUpdater
{
    partial class ConfigBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigBuilder));
            this.label2 = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.tbRelativePath = new System.Windows.Forms.TextBox();
            this.tbApplicationName = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.dgvApplicationList = new System.Windows.Forms.DataGridView();
            this.dgvDeleteMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silentStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absolutePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relativePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.architectureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteRowDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbFilename = new System.Windows.Forms.LinkLabel();
            this.lbRelativePath = new System.Windows.Forms.LinkLabel();
            this.lbAppName = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAbsolutePath = new System.Windows.Forms.LinkLabel();
            this.tbAbsolutePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSwitches = new System.Windows.Forms.ComboBox();
            this.openConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateConfigurationFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchitectureLabel = new System.Windows.Forms.Label();
            this.cbArchitecture = new System.Windows.Forms.ComboBox();
            this.lblSwitches = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSilent = new System.Windows.Forms.CheckBox();
            this.AddAppToListLink = new System.Windows.Forms.LinkLabel();
            this.ClearFieldsLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            this.ClearListLink = new System.Windows.Forms.LinkLabel();
            this.WriteConfigLink = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.switchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLoadConfig = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).BeginInit();
            this.dgvDeleteMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version";
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(427, 13);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(220, 20);
            this.tbFilename.TabIndex = 2;
            // 
            // tbRelativePath
            // 
            this.tbRelativePath.Location = new System.Drawing.Point(125, 65);
            this.tbRelativePath.Name = "tbRelativePath";
            this.tbRelativePath.Size = new System.Drawing.Size(522, 20);
            this.tbRelativePath.TabIndex = 4;
            // 
            // tbApplicationName
            // 
            this.tbApplicationName.Location = new System.Drawing.Point(125, 13);
            this.tbApplicationName.Name = "tbApplicationName";
            this.tbApplicationName.Size = new System.Drawing.Size(220, 20);
            this.tbApplicationName.TabIndex = 1;
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(265, 118);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(131, 20);
            this.tbVersion.TabIndex = 6;
            // 
            // dgvApplicationList
            // 
            this.dgvApplicationList.AllowUserToOrderColumns = true;
            this.dgvApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationList.ContextMenuStrip = this.dgvDeleteMenu;
            this.dgvApplicationList.Enabled = false;
            this.dgvApplicationList.Location = new System.Drawing.Point(9, 145);
            this.dgvApplicationList.Name = "dgvApplicationList";
            this.dgvApplicationList.RowHeadersVisible = false;
            this.dgvApplicationList.RowHeadersWidth = 49;
            this.dgvApplicationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationList.Size = new System.Drawing.Size(660, 223);
            this.dgvApplicationList.TabIndex = 15;
            this.dgvApplicationList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCellMouseDown);
            this.dgvApplicationList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridviewApplicationList_KeyUp);
            // 
            // dgvDeleteMenu
            // 
            this.dgvDeleteMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsToolStripMenuItem,
            this.menuDeleteRowDeleteItem});
            this.dgvDeleteMenu.Name = "menuDeleteRow";
            this.dgvDeleteMenu.Size = new System.Drawing.Size(191, 48);
            // 
            // columnsToolStripMenuItem
            // 
            this.columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silentStripMenuItem,
            this.switchesToolStripMenuItem1,
            this.filenameToolStripMenuItem,
            this.absolutePathToolStripMenuItem,
            this.relativePathToolStripMenuItem,
            this.filesizeToolStripMenuItem,
            this.architectureToolStripMenuItem,
            this.versionToolStripMenuItem});
            this.columnsToolStripMenuItem.Name = "columnsToolStripMenuItem";
            this.columnsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.columnsToolStripMenuItem.Text = "Show / Hide Columns";
            // 
            // silentStripMenuItem
            // 
            this.silentStripMenuItem.Checked = true;
            this.silentStripMenuItem.CheckOnClick = true;
            this.silentStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.silentStripMenuItem.Name = "silentStripMenuItem";
            this.silentStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.silentStripMenuItem.Text = "Silent";
            this.silentStripMenuItem.Click += new System.EventHandler(this.silentStripMenuItem_Click);
            // 
            // switchesToolStripMenuItem1
            // 
            this.switchesToolStripMenuItem1.Checked = true;
            this.switchesToolStripMenuItem1.CheckOnClick = true;
            this.switchesToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.switchesToolStripMenuItem1.Name = "switchesToolStripMenuItem1";
            this.switchesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.switchesToolStripMenuItem1.Text = "Switches";
            this.switchesToolStripMenuItem1.Click += new System.EventHandler(this.switchesToolStripMenuItem1_Click);
            // 
            // filenameToolStripMenuItem
            // 
            this.filenameToolStripMenuItem.CheckOnClick = true;
            this.filenameToolStripMenuItem.Name = "filenameToolStripMenuItem";
            this.filenameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filenameToolStripMenuItem.Text = "Filename";
            this.filenameToolStripMenuItem.Click += new System.EventHandler(this.filenameToolStripMenuItem_Click);
            // 
            // absolutePathToolStripMenuItem
            // 
            this.absolutePathToolStripMenuItem.CheckOnClick = true;
            this.absolutePathToolStripMenuItem.Name = "absolutePathToolStripMenuItem";
            this.absolutePathToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.absolutePathToolStripMenuItem.Text = "Absolute Path";
            this.absolutePathToolStripMenuItem.Click += new System.EventHandler(this.absolutePathToolStripMenuItem_Click);
            // 
            // relativePathToolStripMenuItem
            // 
            this.relativePathToolStripMenuItem.CheckOnClick = true;
            this.relativePathToolStripMenuItem.Name = "relativePathToolStripMenuItem";
            this.relativePathToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.relativePathToolStripMenuItem.Text = "Relative Path";
            this.relativePathToolStripMenuItem.Click += new System.EventHandler(this.relativePathToolStripMenuItem_Click);
            // 
            // filesizeToolStripMenuItem
            // 
            this.filesizeToolStripMenuItem.CheckOnClick = true;
            this.filesizeToolStripMenuItem.Name = "filesizeToolStripMenuItem";
            this.filesizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filesizeToolStripMenuItem.Text = "Filesize";
            this.filesizeToolStripMenuItem.Click += new System.EventHandler(this.filesizeToolStripMenuItem_Click);
            // 
            // architectureToolStripMenuItem
            // 
            this.architectureToolStripMenuItem.CheckOnClick = true;
            this.architectureToolStripMenuItem.Name = "architectureToolStripMenuItem";
            this.architectureToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.architectureToolStripMenuItem.Text = "Architecture";
            this.architectureToolStripMenuItem.Click += new System.EventHandler(this.architectureToolStripMenuItem_Click);
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.CheckOnClick = true;
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // menuDeleteRowDeleteItem
            // 
            this.menuDeleteRowDeleteItem.Name = "menuDeleteRowDeleteItem";
            this.menuDeleteRowDeleteItem.Size = new System.Drawing.Size(190, 22);
            this.menuDeleteRowDeleteItem.Text = "Delete";
            this.menuDeleteRowDeleteItem.Click += new System.EventHandler(this.menuDeleteRowDeleteItem_Click);
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(372, 16);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(49, 13);
            this.lbFilename.TabIndex = 11;
            this.lbFilename.TabStop = true;
            this.lbFilename.Text = "Filename";
            this.lbFilename.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbFilename_LinkClicked);
            // 
            // lbRelativePath
            // 
            this.lbRelativePath.AutoSize = true;
            this.lbRelativePath.Location = new System.Drawing.Point(6, 68);
            this.lbRelativePath.Name = "lbRelativePath";
            this.lbRelativePath.Size = new System.Drawing.Size(101, 13);
            this.lbRelativePath.TabIndex = 13;
            this.lbRelativePath.TabStop = true;
            this.lbRelativePath.Text = "Relative Install Path";
            this.lbRelativePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRelativePath_LinkClicked);
            // 
            // lbAppName
            // 
            this.lbAppName.AutoSize = true;
            this.lbAppName.Location = new System.Drawing.Point(6, 16);
            this.lbAppName.Name = "lbAppName";
            this.lbAppName.Size = new System.Drawing.Size(90, 13);
            this.lbAppName.TabIndex = 10;
            this.lbAppName.TabStop = true;
            this.lbAppName.Text = "Application Name";
            this.lbAppName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAppName_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(353, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(653, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(653, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "*";
            // 
            // lbAbsolutePath
            // 
            this.lbAbsolutePath.AutoSize = true;
            this.lbAbsolutePath.Location = new System.Drawing.Point(6, 42);
            this.lbAbsolutePath.Name = "lbAbsolutePath";
            this.lbAbsolutePath.Size = new System.Drawing.Size(103, 13);
            this.lbAbsolutePath.TabIndex = 12;
            this.lbAbsolutePath.TabStop = true;
            this.lbAbsolutePath.Text = "Absolute Install Path";
            this.lbAbsolutePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAbsolutePath_LinkClicked);
            // 
            // tbAbsolutePath
            // 
            this.tbAbsolutePath.Location = new System.Drawing.Point(125, 39);
            this.tbAbsolutePath.Name = "tbAbsolutePath";
            this.tbAbsolutePath.Size = new System.Drawing.Size(522, 20);
            this.tbAbsolutePath.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(653, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "*";
            // 
            // cbSwitches
            // 
            this.cbSwitches.FormattingEnabled = true;
            this.cbSwitches.Location = new System.Drawing.Point(125, 91);
            this.cbSwitches.Name = "cbSwitches";
            this.cbSwitches.Size = new System.Drawing.Size(453, 21);
            this.cbSwitches.TabIndex = 5;
            this.cbSwitches.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbSwitches_Click);
            // 
            // openConfigToolStripMenuItem
            // 
            this.openConfigToolStripMenuItem.Name = "openConfigToolStripMenuItem";
            this.openConfigToolStripMenuItem.ShortcutKeyDisplayString = "CTRL-O";
            this.openConfigToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.openConfigToolStripMenuItem.Text = "&Open Configuration File";
            this.openConfigToolStripMenuItem.Click += new System.EventHandler(this.openConfigToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(247, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.exitToolStripMenuItem.Text = "Close";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // selectAppToolStripMenuItem
            // 
            this.selectAppToolStripMenuItem.Name = "selectAppToolStripMenuItem";
            this.selectAppToolStripMenuItem.ShortcutKeyDisplayString = "CTRL-N";
            this.selectAppToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.selectAppToolStripMenuItem.Text = "Add &New File";
            this.selectAppToolStripMenuItem.Click += new System.EventHandler(this.selectAppToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // generateConfigurationFromFolderToolStripMenuItem
            // 
            this.generateConfigurationFromFolderToolStripMenuItem.Name = "generateConfigurationFromFolderToolStripMenuItem";
            this.generateConfigurationFromFolderToolStripMenuItem.ShortcutKeyDisplayString = "CTRL-G";
            this.generateConfigurationFromFolderToolStripMenuItem.Size = new System.Drawing.Size(311, 22);
            this.generateConfigurationFromFolderToolStripMenuItem.Text = "&Generate Configuration from Folder";
            this.generateConfigurationFromFolderToolStripMenuItem.Click += new System.EventHandler(this.GenerateConfigFolderToolStripMenuItem_Click);
            // 
            // ArchitectureLabel
            // 
            this.ArchitectureLabel.AutoSize = true;
            this.ArchitectureLabel.Location = new System.Drawing.Point(402, 121);
            this.ArchitectureLabel.Name = "ArchitectureLabel";
            this.ArchitectureLabel.Size = new System.Drawing.Size(64, 13);
            this.ArchitectureLabel.TabIndex = 29;
            this.ArchitectureLabel.Text = "Architecture";
            // 
            // cbArchitecture
            // 
            this.cbArchitecture.FormattingEnabled = true;
            this.cbArchitecture.Items.AddRange(new object[] {
            "",
            "x86",
            "x64"});
            this.cbArchitecture.Location = new System.Drawing.Point(472, 118);
            this.cbArchitecture.Name = "cbArchitecture";
            this.cbArchitecture.Size = new System.Drawing.Size(42, 21);
            this.cbArchitecture.TabIndex = 7;
            // 
            // lblSwitches
            // 
            this.lblSwitches.AutoSize = true;
            this.lblSwitches.Location = new System.Drawing.Point(6, 94);
            this.lblSwitches.Name = "lblSwitches";
            this.lblSwitches.Size = new System.Drawing.Size(111, 13);
            this.lblSwitches.TabIndex = 14;
            this.lblSwitches.TabStop = true;
            this.lblSwitches.Text = "Switches / Arguments";
            this.lblSwitches.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSwitches_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvApplicationList);
            this.groupBox1.Controls.Add(this.cbSilent);
            this.groupBox1.Controls.Add(this.AddAppToListLink);
            this.groupBox1.Controls.Add(this.ClearFieldsLink);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbFileSize);
            this.groupBox1.Controls.Add(this.lbAppName);
            this.groupBox1.Controls.Add(this.lblSwitches);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbArchitecture);
            this.groupBox1.Controls.Add(this.ArchitectureLabel);
            this.groupBox1.Controls.Add(this.tbFilename);
            this.groupBox1.Controls.Add(this.tbRelativePath);
            this.groupBox1.Controls.Add(this.cbSwitches);
            this.groupBox1.Controls.Add(this.tbApplicationName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbVersion);
            this.groupBox1.Controls.Add(this.tbAbsolutePath);
            this.groupBox1.Controls.Add(this.lbFilename);
            this.groupBox1.Controls.Add(this.lbAbsolutePath);
            this.groupBox1.Controls.Add(this.lbRelativePath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 374);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // cbSilent
            // 
            this.cbSilent.AutoSize = true;
            this.cbSilent.Location = new System.Drawing.Point(584, 93);
            this.cbSilent.Name = "cbSilent";
            this.cbSilent.Size = new System.Drawing.Size(82, 17);
            this.cbSilent.TabIndex = 38;
            this.cbSilent.Text = "Silent Install";
            this.cbSilent.UseVisualStyleBackColor = true;
            // 
            // AddAppToListLink
            // 
            this.AddAppToListLink.AutoSize = true;
            this.AddAppToListLink.Location = new System.Drawing.Point(587, 121);
            this.AddAppToListLink.Name = "AddAppToListLink";
            this.AddAppToListLink.Size = new System.Drawing.Size(79, 13);
            this.AddAppToListLink.TabIndex = 37;
            this.AddAppToListLink.TabStop = true;
            this.AddAppToListLink.Text = "Add App to List";
            this.AddAppToListLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddAppToListLink_LinkClicked);
            // 
            // ClearFieldsLink
            // 
            this.ClearFieldsLink.AutoSize = true;
            this.ClearFieldsLink.Location = new System.Drawing.Point(520, 121);
            this.ClearFieldsLink.Name = "ClearFieldsLink";
            this.ClearFieldsLink.Size = new System.Drawing.Size(61, 13);
            this.ClearFieldsLink.TabIndex = 36;
            this.ClearFieldsLink.TabStop = true;
            this.ClearFieldsLink.Text = "Clear Fields";
            this.ClearFieldsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClearFieldsLink_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "File Size (MB)";
            // 
            // tbFileSize
            // 
            this.tbFileSize.Location = new System.Drawing.Point(125, 118);
            this.tbFileSize.Name = "tbFileSize";
            this.tbFileSize.ReadOnly = true;
            this.tbFileSize.Size = new System.Drawing.Size(86, 20);
            this.tbFileSize.TabIndex = 33;
            // 
            // ClearListLink
            // 
            this.ClearListLink.AutoSize = true;
            this.ClearListLink.Location = new System.Drawing.Point(559, 405);
            this.ClearListLink.Name = "ClearListLink";
            this.ClearListLink.Size = new System.Drawing.Size(50, 13);
            this.ClearListLink.TabIndex = 40;
            this.ClearListLink.TabStop = true;
            this.ClearListLink.Text = "Clear List";
            this.ClearListLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClearListLink_LinkClicked);
            // 
            // WriteConfigLink
            // 
            this.WriteConfigLink.AutoSize = true;
            this.WriteConfigLink.Location = new System.Drawing.Point(615, 405);
            this.WriteConfigLink.Name = "WriteConfigLink";
            this.WriteConfigLink.Size = new System.Drawing.Size(65, 13);
            this.WriteConfigLink.TabIndex = 39;
            this.WriteConfigLink.TabStop = true;
            this.WriteConfigLink.Text = "Write Config";
            this.WriteConfigLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.WriteConfigLink_LinkClicked);
            // 
            // switchesToolStripMenuItem
            // 
            this.switchesToolStripMenuItem.Name = "switchesToolStripMenuItem";
            this.switchesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.switchesToolStripMenuItem.Text = "Switch Editor";
            this.switchesToolStripMenuItem.Click += new System.EventHandler(this.switchesToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAppToolStripMenuItem,
            this.toolStripSeparator1,
            this.generateConfigurationFromFolderToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.buildToolStripMenuItem.Text = "&Build";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.switchesToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(698, 24);
            this.mainMenuStrip.TabIndex = 27;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // linkLoadConfig
            // 
            this.linkLoadConfig.AutoSize = true;
            this.linkLoadConfig.Location = new System.Drawing.Point(18, 405);
            this.linkLoadConfig.Name = "linkLoadConfig";
            this.linkLoadConfig.Size = new System.Drawing.Size(117, 13);
            this.linkLoadConfig.TabIndex = 41;
            this.linkLoadConfig.TabStop = true;
            this.linkLoadConfig.Text = "Open Configuration File";
            this.linkLoadConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLoadConfig_LinkClicked);
            // 
            // ConfigBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 426);
            this.Controls.Add(this.linkLoadConfig);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.ClearListLink);
            this.Controls.Add(this.WriteConfigLink);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(714, 764);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(714, 38);
            this.Name = "ConfigBuilder";
            this.ShowIcon = false;
            this.Text = "Configuration Builder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).EndInit();
            this.dgvDeleteMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.TextBox tbRelativePath;
        private System.Windows.Forms.TextBox tbApplicationName;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.DataGridView dgvApplicationList;
        private System.Windows.Forms.ContextMenuStrip dgvDeleteMenu;
        private System.Windows.Forms.LinkLabel lbFilename;
        private System.Windows.Forms.LinkLabel lbRelativePath;
        private System.Windows.Forms.LinkLabel lbAppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lbAbsolutePath;
        private System.Windows.Forms.TextBox tbAbsolutePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSwitches;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateConfigurationFromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteRowDeleteItem;
        private System.Windows.Forms.Label ArchitectureLabel;
        private System.Windows.Forms.ComboBox cbArchitecture;
        private System.Windows.Forms.ToolStripMenuItem selectAppToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lblSwitches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem switchesToolStripMenuItem;
        private System.Windows.Forms.LinkLabel AddAppToListLink;
        private System.Windows.Forms.LinkLabel ClearFieldsLink;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.LinkLabel WriteConfigLink;
        private System.Windows.Forms.CheckBox cbSilent;
        private System.Windows.Forms.LinkLabel ClearListLink;
        private System.Windows.Forms.ToolStripMenuItem columnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absolutePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relativePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filesizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem architectureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLoadConfig;
        private System.Windows.Forms.ToolStripMenuItem silentStripMenuItem;
    }
}


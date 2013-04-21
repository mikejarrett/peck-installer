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
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.tbRelativePath = new System.Windows.Forms.TextBox();
            this.tbApplicationName = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.dgvApplicationList = new System.Windows.Forms.DataGridView();
            this.applicationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absolutePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.installSwitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.architecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDeleteRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteRowDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbFilename = new System.Windows.Forms.LinkLabel();
            this.lbRelativePath = new System.Windows.Forms.LinkLabel();
            this.lbAppName = new System.Windows.Forms.LinkLabel();
            this.btnWriteConfig = new System.Windows.Forms.Button();
            this.btnClearInput = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAbsolutePath = new System.Windows.Forms.LinkLabel();
            this.tbAbsolutePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSwitches = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateConfigurationFromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearDataGridView = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbArchitecture = new System.Windows.Forms.ComboBox();
            this.lblSwitches = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileSize = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).BeginInit();
            this.menuDeleteRow.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(542, 116);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(105, 23);
            this.btnAddToList.TabIndex = 9;
            this.btnAddToList.Text = "Add App to List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
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
            this.tbVersion.Location = new System.Drawing.Point(242, 118);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(61, 20);
            this.tbVersion.TabIndex = 6;
            // 
            // dgvApplicationList
            // 
            this.dgvApplicationList.AllowUserToOrderColumns = true;
            this.dgvApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.applicationName,
            this.filename,
            this.absolutePath,
            this.relativePath,
            this.installSwitches,
            this.version,
            this.architecture,
            this.FileSize});
            this.dgvApplicationList.ContextMenuStrip = this.menuDeleteRow;
            this.dgvApplicationList.Location = new System.Drawing.Point(6, 144);
            this.dgvApplicationList.Name = "dgvApplicationList";
            this.dgvApplicationList.RowHeadersWidth = 49;
            this.dgvApplicationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationList.Size = new System.Drawing.Size(660, 205);
            this.dgvApplicationList.TabIndex = 15;
            this.dgvApplicationList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCellMouseDown);
            this.dgvApplicationList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridviewApplicationList_KeyUp);
            // 
            // applicationName
            // 
            this.applicationName.HeaderText = "Name";
            this.applicationName.Name = "applicationName";
            this.applicationName.ReadOnly = true;
            this.applicationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // filename
            // 
            this.filename.HeaderText = "Filename";
            this.filename.Name = "filename";
            this.filename.ReadOnly = true;
            this.filename.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // absolutePath
            // 
            this.absolutePath.HeaderText = "AbsolutePath";
            this.absolutePath.Name = "absolutePath";
            this.absolutePath.ReadOnly = true;
            this.absolutePath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // relativePath
            // 
            this.relativePath.HeaderText = "Relative Path";
            this.relativePath.Name = "relativePath";
            this.relativePath.ReadOnly = true;
            this.relativePath.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // installSwitches
            // 
            this.installSwitches.HeaderText = "Switches";
            this.installSwitches.Name = "installSwitches";
            this.installSwitches.ReadOnly = true;
            this.installSwitches.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // version
            // 
            this.version.HeaderText = "Version";
            this.version.Name = "version";
            this.version.ReadOnly = true;
            this.version.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // architecture
            // 
            this.architecture.HeaderText = "Arch";
            this.architecture.Name = "architecture";
            this.architecture.Visible = false;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "File Size (MB)";
            this.FileSize.Name = "FileSize";
            this.FileSize.Visible = false;
            // 
            // menuDeleteRow
            // 
            this.menuDeleteRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteRowDeleteItem});
            this.menuDeleteRow.Name = "menuDeleteRow";
            this.menuDeleteRow.Size = new System.Drawing.Size(108, 26);
            // 
            // menuDeleteRowDeleteItem
            // 
            this.menuDeleteRowDeleteItem.Name = "menuDeleteRowDeleteItem";
            this.menuDeleteRowDeleteItem.Size = new System.Drawing.Size(107, 22);
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
            // btnWriteConfig
            // 
            this.btnWriteConfig.Location = new System.Drawing.Point(586, 355);
            this.btnWriteConfig.Name = "btnWriteConfig";
            this.btnWriteConfig.Size = new System.Drawing.Size(75, 23);
            this.btnWriteConfig.TabIndex = 17;
            this.btnWriteConfig.Text = "Write Config";
            this.btnWriteConfig.UseVisualStyleBackColor = true;
            this.btnWriteConfig.Click += new System.EventHandler(this.btnWriteConfig_Click);
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(461, 116);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(75, 23);
            this.btnClearInput.TabIndex = 8;
            this.btnClearInput.Text = "Clear";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
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
            this.cbSwitches.Size = new System.Drawing.Size(522, 21);
            this.cbSwitches.TabIndex = 5;
            this.cbSwitches.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbSwitches_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.switchesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.exitToolStripMenuItem.Text = "Back to Installer";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            // switchesToolStripMenuItem
            // 
            this.switchesToolStripMenuItem.Name = "switchesToolStripMenuItem";
            this.switchesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.switchesToolStripMenuItem.Text = "Switch Editor";
            this.switchesToolStripMenuItem.Click += new System.EventHandler(this.switchesToolStripMenuItem_Click);
            // 
            // btnClearDataGridView
            // 
            this.btnClearDataGridView.Location = new System.Drawing.Point(9, 355);
            this.btnClearDataGridView.Name = "btnClearDataGridView";
            this.btnClearDataGridView.Size = new System.Drawing.Size(75, 23);
            this.btnClearDataGridView.TabIndex = 16;
            this.btnClearDataGridView.Text = "Clear List";
            this.btnClearDataGridView.UseVisualStyleBackColor = true;
            this.btnClearDataGridView.Click += new System.EventHandler(this.btnClearDataGridView_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Architecture";
            // 
            // cbArchitecture
            // 
            this.cbArchitecture.FormattingEnabled = true;
            this.cbArchitecture.Items.AddRange(new object[] {
            "",
            "x86",
            "x64"});
            this.cbArchitecture.Location = new System.Drawing.Point(379, 117);
            this.cbArchitecture.Name = "cbArchitecture";
            this.cbArchitecture.Size = new System.Drawing.Size(61, 21);
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
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbFileSize);
            this.groupBox1.Controls.Add(this.lbAppName);
            this.groupBox1.Controls.Add(this.btnClearDataGridView);
            this.groupBox1.Controls.Add(this.lblSwitches);
            this.groupBox1.Controls.Add(this.btnWriteConfig);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvApplicationList);
            this.groupBox1.Controls.Add(this.cbArchitecture);
            this.groupBox1.Controls.Add(this.btnAddToList);
            this.groupBox1.Controls.Add(this.label7);
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
            this.groupBox1.Controls.Add(this.btnClearInput);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 388);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
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
            this.tbFileSize.Size = new System.Drawing.Size(61, 20);
            this.tbFileSize.TabIndex = 33;
            // 
            // ConfigBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 426);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ConfigBuilder";
            this.Text = "Application Builder";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationList)).EndInit();
            this.menuDeleteRow.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.TextBox tbRelativePath;
        private System.Windows.Forms.TextBox tbApplicationName;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.DataGridView dgvApplicationList;
        private System.Windows.Forms.ContextMenuStrip menuDeleteRow;
        private System.Windows.Forms.LinkLabel lbFilename;
        private System.Windows.Forms.LinkLabel lbRelativePath;
        private System.Windows.Forms.LinkLabel lbAppName;
        private System.Windows.Forms.Button btnWriteConfig;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lbAbsolutePath;
        private System.Windows.Forms.TextBox tbAbsolutePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSwitches;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateConfigurationFromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button btnClearDataGridView;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteRowDeleteItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbArchitecture;
        private System.Windows.Forms.ToolStripMenuItem selectAppToolStripMenuItem;
        private System.Windows.Forms.LinkLabel lblSwitches;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem switchesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn absolutePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn installSwitches;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn architecture;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
    }
}


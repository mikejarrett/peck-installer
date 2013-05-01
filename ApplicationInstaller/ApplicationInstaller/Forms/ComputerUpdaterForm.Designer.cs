namespace ComputerUpdater
{
    partial class ComputerUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputerUpdateForm));
            this.gbName = new System.Windows.Forms.GroupBox();
            this.cbAdditional = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkSingleApp = new System.Windows.Forms.LinkLabel();
            this.cbServicePack = new System.Windows.Forms.CheckBox();
            this.clbAdditionalConfigurations = new System.Windows.Forms.CheckedListBox();
            this.AddAppsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearAdditionalAppsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkAdditionalConfigs = new System.Windows.Forms.LinkLabel();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.cbAppToggle = new System.Windows.Forms.CheckBox();
            this.cbWindowsUpdates = new System.Windows.Forms.CheckBox();
            this.linkStartInstall = new System.Windows.Forms.LinkLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMappedSwitchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeCurrentSelectionToBatchFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageUpdatesAndApps = new System.Windows.Forms.TabPage();
            this.tabpageSettings = new System.Windows.Forms.TabPage();
            this.gbComputerInfo = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.labelComputerName = new System.Windows.Forms.Label();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLast = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.computerName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbRegistryFiles = new System.Windows.Forms.CheckedListBox();
            this.linkAddRegistryFiles = new System.Windows.Forms.LinkLabel();
            this.gbName.SuspendLayout();
            this.AddAppsContextMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabpageUpdatesAndApps.SuspendLayout();
            this.tabpageSettings.SuspendLayout();
            this.gbComputerInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.cbAdditional);
            this.gbName.Controls.Add(this.label3);
            this.gbName.Controls.Add(this.label2);
            this.gbName.Controls.Add(this.linkSingleApp);
            this.gbName.Controls.Add(this.cbServicePack);
            this.gbName.Controls.Add(this.clbAdditionalConfigurations);
            this.gbName.Controls.Add(this.linkAdditionalConfigs);
            this.gbName.Controls.Add(this.checkedListBoxApps);
            this.gbName.Controls.Add(this.cbAppToggle);
            this.gbName.Controls.Add(this.cbWindowsUpdates);
            this.gbName.Location = new System.Drawing.Point(6, 6);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(318, 324);
            this.gbName.TabIndex = 3;
            this.gbName.TabStop = false;
            this.gbName.Text = "OS Version";
            // 
            // cbAdditional
            // 
            this.cbAdditional.AutoSize = true;
            this.cbAdditional.Enabled = false;
            this.cbAdditional.Location = new System.Drawing.Point(9, 205);
            this.cbAdditional.Name = "cbAdditional";
            this.cbAdditional.Size = new System.Drawing.Size(128, 17);
            this.cbAdditional.TabIndex = 10;
            this.cbAdditional.Text = "Select all applications";
            this.cbAdditional.UseVisualStyleBackColor = true;
            this.cbAdditional.CheckedChanged += new System.EventHandler(this.cbAdditional_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "or an";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Load additional an";
            // 
            // linkSingleApp
            // 
            this.linkSingleApp.AutoSize = true;
            this.linkSingleApp.Location = new System.Drawing.Point(235, 186);
            this.linkSingleApp.Name = "linkSingleApp";
            this.linkSingleApp.Size = new System.Drawing.Size(59, 13);
            this.linkSingleApp.TabIndex = 5;
            this.linkSingleApp.TabStop = true;
            this.linkSingleApp.Text = "Application";
            this.linkSingleApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSingleApp_LinkClicked);
            // 
            // cbServicePack
            // 
            this.cbServicePack.AutoSize = true;
            this.cbServicePack.Location = new System.Drawing.Point(9, 23);
            this.cbServicePack.Name = "cbServicePack";
            this.cbServicePack.Size = new System.Drawing.Size(120, 17);
            this.cbServicePack.TabIndex = 1;
            this.cbServicePack.Text = "Install Service Pack";
            this.cbServicePack.UseVisualStyleBackColor = true;
            this.cbServicePack.CheckedChanged += new System.EventHandler(this.cbServicePack_CheckedChanged);
            // 
            // clbAdditionalConfigurations
            // 
            this.clbAdditionalConfigurations.CheckOnClick = true;
            this.clbAdditionalConfigurations.ContextMenuStrip = this.AddAppsContextMenu;
            this.clbAdditionalConfigurations.FormattingEnabled = true;
            this.clbAdditionalConfigurations.Location = new System.Drawing.Point(6, 224);
            this.clbAdditionalConfigurations.Name = "clbAdditionalConfigurations";
            this.clbAdditionalConfigurations.Size = new System.Drawing.Size(306, 94);
            this.clbAdditionalConfigurations.TabIndex = 7;
            // 
            // AddAppsContextMenu
            // 
            this.AddAppsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAdditionalAppsListToolStripMenuItem});
            this.AddAppsContextMenu.Name = "contextMenuStrip1";
            this.AddAppsContextMenu.Size = new System.Drawing.Size(123, 26);
            // 
            // clearAdditionalAppsListToolStripMenuItem
            // 
            this.clearAdditionalAppsListToolStripMenuItem.Name = "clearAdditionalAppsListToolStripMenuItem";
            this.clearAdditionalAppsListToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearAdditionalAppsListToolStripMenuItem.Text = "Clear List";
            this.clearAdditionalAppsListToolStripMenuItem.Click += new System.EventHandler(this.clearAdditionalAppsListToolStripMenuItem_Click);
            // 
            // linkAdditionalConfigs
            // 
            this.linkAdditionalConfigs.AutoSize = true;
            this.linkAdditionalConfigs.Location = new System.Drawing.Point(97, 186);
            this.linkAdditionalConfigs.Name = "linkAdditionalConfigs";
            this.linkAdditionalConfigs.Size = new System.Drawing.Size(111, 13);
            this.linkAdditionalConfigs.TabIndex = 4;
            this.linkAdditionalConfigs.TabStop = true;
            this.linkAdditionalConfigs.Text = "Application Config File";
            this.linkAdditionalConfigs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdditionalConfigs_LinkClicked);
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.CheckOnClick = true;
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(6, 69);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(306, 109);
            this.checkedListBoxApps.TabIndex = 6;
            // 
            // cbAppToggle
            // 
            this.cbAppToggle.AutoSize = true;
            this.cbAppToggle.Checked = true;
            this.cbAppToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAppToggle.Location = new System.Drawing.Point(9, 46);
            this.cbAppToggle.Name = "cbAppToggle";
            this.cbAppToggle.Size = new System.Drawing.Size(140, 17);
            this.cbAppToggle.TabIndex = 3;
            this.cbAppToggle.Text = "Unselect all applications";
            this.cbAppToggle.UseVisualStyleBackColor = true;
            this.cbAppToggle.CheckedChanged += new System.EventHandler(this.cbAppToggle_CheckedChanged);
            // 
            // cbWindowsUpdates
            // 
            this.cbWindowsUpdates.AutoSize = true;
            this.cbWindowsUpdates.Checked = true;
            this.cbWindowsUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWindowsUpdates.Location = new System.Drawing.Point(135, 23);
            this.cbWindowsUpdates.Name = "cbWindowsUpdates";
            this.cbWindowsUpdates.Size = new System.Drawing.Size(157, 17);
            this.cbWindowsUpdates.TabIndex = 2;
            this.cbWindowsUpdates.Text = "Install All Windows Updates";
            this.cbWindowsUpdates.UseVisualStyleBackColor = true;
            // 
            // linkStartInstall
            // 
            this.linkStartInstall.AutoSize = true;
            this.linkStartInstall.Location = new System.Drawing.Point(264, 392);
            this.linkStartInstall.Name = "linkStartInstall";
            this.linkStartInstall.Size = new System.Drawing.Size(82, 13);
            this.linkStartInstall.TabIndex = 6;
            this.linkStartInstall.TabStop = true;
            this.linkStartInstall.Text = "Start Installation";
            this.linkStartInstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInstall_LinkClicked);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.scriptToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(357, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configBuilderToolStripMenuItem,
            this.switchEditorToolStripMenuItem,
            this.editMappedSwitchesToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // configBuilderToolStripMenuItem
            // 
            this.configBuilderToolStripMenuItem.Name = "configBuilderToolStripMenuItem";
            this.configBuilderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.configBuilderToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.configBuilderToolStripMenuItem.Text = "Config Builder";
            this.configBuilderToolStripMenuItem.Click += new System.EventHandler(this.configBuilderToolStripMenuItem_Click);
            // 
            // switchEditorToolStripMenuItem
            // 
            this.switchEditorToolStripMenuItem.Name = "switchEditorToolStripMenuItem";
            this.switchEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.switchEditorToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.switchEditorToolStripMenuItem.Text = "Switch Editor";
            this.switchEditorToolStripMenuItem.Click += new System.EventHandler(this.switchEditorToolStripMenuItem_Click);
            // 
            // editMappedSwitchesToolStripMenuItem
            // 
            this.editMappedSwitchesToolStripMenuItem.Name = "editMappedSwitchesToolStripMenuItem";
            this.editMappedSwitchesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.editMappedSwitchesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.editMappedSwitchesToolStripMenuItem.Text = "Edit Mapped Switches";
            this.editMappedSwitchesToolStripMenuItem.Click += new System.EventHandler(this.editMappedSwitchesToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeCurrentSelectionToBatchFileToolStripMenuItem});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.scriptToolStripMenuItem.Text = "Scripts";
            // 
            // writeCurrentSelectionToBatchFileToolStripMenuItem
            // 
            this.writeCurrentSelectionToBatchFileToolStripMenuItem.Name = "writeCurrentSelectionToBatchFileToolStripMenuItem";
            this.writeCurrentSelectionToBatchFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.writeCurrentSelectionToBatchFileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.writeCurrentSelectionToBatchFileToolStripMenuItem.Text = "Generate Script File";
            this.writeCurrentSelectionToBatchFileToolStripMenuItem.Click += new System.EventHandler(this.writeCurrentSelectionToBatchFileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageUpdatesAndApps);
            this.tabControl1.Controls.Add(this.tabpageSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(338, 362);
            this.tabControl1.TabIndex = 4;
            // 
            // tabpageUpdatesAndApps
            // 
            this.tabpageUpdatesAndApps.Controls.Add(this.gbName);
            this.tabpageUpdatesAndApps.Location = new System.Drawing.Point(4, 22);
            this.tabpageUpdatesAndApps.Name = "tabpageUpdatesAndApps";
            this.tabpageUpdatesAndApps.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageUpdatesAndApps.Size = new System.Drawing.Size(330, 336);
            this.tabpageUpdatesAndApps.TabIndex = 0;
            this.tabpageUpdatesAndApps.Text = "Updates and Apps";
            this.tabpageUpdatesAndApps.UseVisualStyleBackColor = true;
            // 
            // tabpageSettings
            // 
            this.tabpageSettings.Controls.Add(this.gbComputerInfo);
            this.tabpageSettings.Controls.Add(this.groupBox2);
            this.tabpageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabpageSettings.Name = "tabpageSettings";
            this.tabpageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageSettings.Size = new System.Drawing.Size(330, 336);
            this.tabpageSettings.TabIndex = 1;
            this.tabpageSettings.Text = "Settings";
            this.tabpageSettings.UseVisualStyleBackColor = true;
            // 
            // gbComputerInfo
            // 
            this.gbComputerInfo.Controls.Add(this.tbDescription);
            this.gbComputerInfo.Controls.Add(this.tbLastName);
            this.gbComputerInfo.Controls.Add(this.labelComputerName);
            this.gbComputerInfo.Controls.Add(this.tbFirstName);
            this.gbComputerInfo.Controls.Add(this.label1);
            this.gbComputerInfo.Controls.Add(this.labelLast);
            this.gbComputerInfo.Controls.Add(this.labelFirstName);
            this.gbComputerInfo.Controls.Add(this.computerName);
            this.gbComputerInfo.Location = new System.Drawing.Point(6, 6);
            this.gbComputerInfo.Name = "gbComputerInfo";
            this.gbComputerInfo.Size = new System.Drawing.Size(315, 129);
            this.gbComputerInfo.TabIndex = 1;
            this.gbComputerInfo.TabStop = false;
            this.gbComputerInfo.Text = "Computer Information";
            // 
            // tbDescription
            // 
            this.tbDescription.Enabled = false;
            this.tbDescription.Location = new System.Drawing.Point(95, 97);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(214, 20);
            this.tbDescription.TabIndex = 3;
            // 
            // tbLastName
            // 
            this.tbLastName.Enabled = false;
            this.tbLastName.Location = new System.Drawing.Point(95, 45);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(214, 20);
            this.tbLastName.TabIndex = 1;
            this.tbLastName.TextChanged += new System.EventHandler(this.LastNameChanged);
            // 
            // labelComputerName
            // 
            this.labelComputerName.AutoSize = true;
            this.labelComputerName.Location = new System.Drawing.Point(6, 74);
            this.labelComputerName.Name = "labelComputerName";
            this.labelComputerName.Size = new System.Drawing.Size(83, 13);
            this.labelComputerName.TabIndex = 4;
            this.labelComputerName.Text = "Computer Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Enabled = false;
            this.tbFirstName.Location = new System.Drawing.Point(95, 19);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(214, 20);
            this.tbFirstName.TabIndex = 0;
            this.tbFirstName.TextChanged += new System.EventHandler(this.firstNameChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Description";
            // 
            // labelLast
            // 
            this.labelLast.AutoSize = true;
            this.labelLast.Location = new System.Drawing.Point(6, 48);
            this.labelLast.Name = "labelLast";
            this.labelLast.Size = new System.Drawing.Size(58, 13);
            this.labelLast.TabIndex = 1;
            this.labelLast.Text = "Last Name";
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(6, 22);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First Name";
            // 
            // computerName
            // 
            this.computerName.Enabled = false;
            this.computerName.Location = new System.Drawing.Point(95, 71);
            this.computerName.Name = "computerName";
            this.computerName.Size = new System.Drawing.Size(214, 20);
            this.computerName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbRegistryFiles);
            this.groupBox2.Controls.Add(this.linkAddRegistryFiles);
            this.groupBox2.Location = new System.Drawing.Point(6, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 180);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registry Tweaks";
            // 
            // clbRegistryFiles
            // 
            this.clbRegistryFiles.CheckOnClick = true;
            this.clbRegistryFiles.FormattingEnabled = true;
            this.clbRegistryFiles.Location = new System.Drawing.Point(6, 32);
            this.clbRegistryFiles.Name = "clbRegistryFiles";
            this.clbRegistryFiles.Size = new System.Drawing.Size(300, 139);
            this.clbRegistryFiles.TabIndex = 5;
            // 
            // linkAddRegistryFiles
            // 
            this.linkAddRegistryFiles.AutoSize = true;
            this.linkAddRegistryFiles.Location = new System.Drawing.Point(6, 16);
            this.linkAddRegistryFiles.Name = "linkAddRegistryFiles";
            this.linkAddRegistryFiles.Size = new System.Drawing.Size(91, 13);
            this.linkAddRegistryFiles.TabIndex = 4;
            this.linkAddRegistryFiles.TabStop = true;
            this.linkAddRegistryFiles.Text = "Add Registry Files";
            this.linkAddRegistryFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddRegistryFiles_LinkClicked);
            // 
            // ComputerUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 412);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.linkStartInstall);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 450);
            this.Name = "ComputerUpdateForm";
            this.Text = "Computer Updater";
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.AddAppsContextMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabpageUpdatesAndApps.ResumeLayout(false);
            this.tabpageSettings.ResumeLayout(false);
            this.gbComputerInfo.ResumeLayout(false);
            this.gbComputerInfo.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.CheckBox cbWindowsUpdates;
        private System.Windows.Forms.CheckBox cbAppToggle;
        private System.Windows.Forms.LinkLabel linkStartInstall;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configBuilderToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpageUpdatesAndApps;
        private System.Windows.Forms.TabPage tabpageSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbRegistryFiles;
        private System.Windows.Forms.LinkLabel linkAddRegistryFiles;
        private System.Windows.Forms.LinkLabel linkAdditionalConfigs;
        private System.Windows.Forms.CheckedListBox clbAdditionalConfigurations;
        private System.Windows.Forms.CheckBox cbServicePack;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbComputerInfo;
        private System.Windows.Forms.TextBox computerName;
        private System.Windows.Forms.Label labelComputerName;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label labelLast;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkSingleApp;
        private System.Windows.Forms.CheckBox cbAdditional;
        private System.Windows.Forms.ToolStripMenuItem switchEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeCurrentSelectionToBatchFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMappedSwitchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AddAppsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem clearAdditionalAppsListToolStripMenuItem;

    }
}
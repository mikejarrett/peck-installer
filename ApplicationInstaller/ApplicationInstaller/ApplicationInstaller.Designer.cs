﻿namespace ApplicationInstaller
{
    partial class ApplicationInstaller
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
            this.gbName = new System.Windows.Forms.GroupBox();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.linkStartInstall = new System.Windows.Forms.LinkLabel();
            this.cbAppToggle = new System.Windows.Forms.CheckBox();
            this.cbWindowsUpdates = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbInstallationInfo = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageUpdatesAndApps = new System.Windows.Forms.TabPage();
            this.tabpageSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbRegistryFiles = new System.Windows.Forms.CheckedListBox();
            this.linkAddRegistryFiles = new System.Windows.Forms.LinkLabel();
            this.linkAdditionalConfigs = new System.Windows.Forms.LinkLabel();
            this.clbAdditionalConfigurations = new System.Windows.Forms.CheckedListBox();
            this.gbName.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabpageUpdatesAndApps.SuspendLayout();
            this.tabpageSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.clbAdditionalConfigurations);
            this.gbName.Controls.Add(this.linkAdditionalConfigs);
            this.gbName.Controls.Add(this.checkedListBoxApps);
            this.gbName.Controls.Add(this.linkStartInstall);
            this.gbName.Controls.Add(this.cbAppToggle);
            this.gbName.Controls.Add(this.cbWindowsUpdates);
            this.gbName.Location = new System.Drawing.Point(6, 6);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(318, 337);
            this.gbName.TabIndex = 3;
            this.gbName.TabStop = false;
            this.gbName.Text = "OS Version";
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.CheckOnClick = true;
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(6, 65);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(306, 124);
            this.checkedListBoxApps.TabIndex = 1;
            // 
            // linkStartInstall
            // 
            this.linkStartInstall.AutoSize = true;
            this.linkStartInstall.Location = new System.Drawing.Point(230, 321);
            this.linkStartInstall.Name = "linkStartInstall";
            this.linkStartInstall.Size = new System.Drawing.Size(82, 13);
            this.linkStartInstall.TabIndex = 3;
            this.linkStartInstall.TabStop = true;
            this.linkStartInstall.Text = "Start Installation";
            this.linkStartInstall.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelInstall_LinkClicked);
            // 
            // cbAppToggle
            // 
            this.cbAppToggle.AutoSize = true;
            this.cbAppToggle.Checked = true;
            this.cbAppToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAppToggle.Location = new System.Drawing.Point(9, 42);
            this.cbAppToggle.Name = "cbAppToggle";
            this.cbAppToggle.Size = new System.Drawing.Size(140, 17);
            this.cbAppToggle.TabIndex = 2;
            this.cbAppToggle.Text = "Unselect all applications";
            this.cbAppToggle.UseVisualStyleBackColor = true;
            this.cbAppToggle.CheckedChanged += new System.EventHandler(this.cbAppToggle_CheckedChanged);
            // 
            // cbWindowsUpdates
            // 
            this.cbWindowsUpdates.AutoSize = true;
            this.cbWindowsUpdates.Checked = true;
            this.cbWindowsUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWindowsUpdates.Location = new System.Drawing.Point(9, 19);
            this.cbWindowsUpdates.Name = "cbWindowsUpdates";
            this.cbWindowsUpdates.Size = new System.Drawing.Size(157, 17);
            this.cbWindowsUpdates.TabIndex = 0;
            this.cbWindowsUpdates.Text = "Install All Windows Updates";
            this.cbWindowsUpdates.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configBuilderToolStripMenuItem,
            this.switchEditorToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // configBuilderToolStripMenuItem
            // 
            this.configBuilderToolStripMenuItem.Name = "configBuilderToolStripMenuItem";
            this.configBuilderToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configBuilderToolStripMenuItem.Text = "Config Builder";
            this.configBuilderToolStripMenuItem.Click += new System.EventHandler(this.configBuilderToolStripMenuItem_Click);
            // 
            // switchEditorToolStripMenuItem
            // 
            this.switchEditorToolStripMenuItem.Name = "switchEditorToolStripMenuItem";
            this.switchEditorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.switchEditorToolStripMenuItem.Text = "Switch Editor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbInstallationInfo);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(356, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 378);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installing...";
            // 
            // rtbInstallationInfo
            // 
            this.rtbInstallationInfo.Location = new System.Drawing.Point(6, 19);
            this.rtbInstallationInfo.Name = "rtbInstallationInfo";
            this.rtbInstallationInfo.Size = new System.Drawing.Size(317, 324);
            this.rtbInstallationInfo.TabIndex = 1;
            this.rtbInstallationInfo.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 349);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(317, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageUpdatesAndApps);
            this.tabControl1.Controls.Add(this.tabpageSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(338, 372);
            this.tabControl1.TabIndex = 4;
            // 
            // tabpageUpdatesAndApps
            // 
            this.tabpageUpdatesAndApps.Controls.Add(this.gbName);
            this.tabpageUpdatesAndApps.Location = new System.Drawing.Point(4, 22);
            this.tabpageUpdatesAndApps.Name = "tabpageUpdatesAndApps";
            this.tabpageUpdatesAndApps.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageUpdatesAndApps.Size = new System.Drawing.Size(330, 346);
            this.tabpageUpdatesAndApps.TabIndex = 0;
            this.tabpageUpdatesAndApps.Text = "Updates and Apps";
            this.tabpageUpdatesAndApps.UseVisualStyleBackColor = true;
            // 
            // tabpageSettings
            // 
            this.tabpageSettings.Controls.Add(this.groupBox2);
            this.tabpageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabpageSettings.Name = "tabpageSettings";
            this.tabpageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageSettings.Size = new System.Drawing.Size(330, 346);
            this.tabpageSettings.TabIndex = 1;
            this.tabpageSettings.Text = "Settings";
            this.tabpageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbRegistryFiles);
            this.groupBox2.Controls.Add(this.linkAddRegistryFiles);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 120);
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
            this.clbRegistryFiles.Size = new System.Drawing.Size(306, 79);
            this.clbRegistryFiles.TabIndex = 1;
            // 
            // linkAddRegistryFiles
            // 
            this.linkAddRegistryFiles.AutoSize = true;
            this.linkAddRegistryFiles.Location = new System.Drawing.Point(6, 16);
            this.linkAddRegistryFiles.Name = "linkAddRegistryFiles";
            this.linkAddRegistryFiles.Size = new System.Drawing.Size(91, 13);
            this.linkAddRegistryFiles.TabIndex = 0;
            this.linkAddRegistryFiles.TabStop = true;
            this.linkAddRegistryFiles.Text = "Add Registry Files";
            this.linkAddRegistryFiles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddRegistryFiles_LinkClicked);
            // 
            // linkAdditionalConfigs
            // 
            this.linkAdditionalConfigs.AutoSize = true;
            this.linkAdditionalConfigs.Location = new System.Drawing.Point(6, 197);
            this.linkAdditionalConfigs.Name = "linkAdditionalConfigs";
            this.linkAdditionalConfigs.Size = new System.Drawing.Size(192, 13);
            this.linkAdditionalConfigs.TabIndex = 4;
            this.linkAdditionalConfigs.TabStop = true;
            this.linkAdditionalConfigs.Text = "Load Additional Application Config Files";
            this.linkAdditionalConfigs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAdditionalConfigs_LinkClicked);
            // 
            // clbAdditionalConfigurations
            // 
            this.clbAdditionalConfigurations.CheckOnClick = true;
            this.clbAdditionalConfigurations.FormattingEnabled = true;
            this.clbAdditionalConfigurations.Location = new System.Drawing.Point(6, 218);
            this.clbAdditionalConfigurations.Name = "clbAdditionalConfigurations";
            this.clbAdditionalConfigurations.Size = new System.Drawing.Size(306, 94);
            this.clbAdditionalConfigurations.TabIndex = 5;
            // 
            // ApplicationInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ApplicationInstaller";
            this.Text = "ApplicationInstaller";
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabpageUpdatesAndApps.ResumeLayout(false);
            this.tabpageSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.CheckBox cbWindowsUpdates;
        private System.Windows.Forms.CheckBox cbAppToggle;
        private System.Windows.Forms.LinkLabel linkStartInstall;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchEditorToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbInstallationInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpageUpdatesAndApps;
        private System.Windows.Forms.TabPage tabpageSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbRegistryFiles;
        private System.Windows.Forms.LinkLabel linkAddRegistryFiles;
        private System.Windows.Forms.LinkLabel linkAdditionalConfigs;
        private System.Windows.Forms.CheckedListBox clbAdditionalConfigurations;

    }
}
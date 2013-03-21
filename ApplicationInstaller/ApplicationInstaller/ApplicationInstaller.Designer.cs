namespace ApplicationInstaller
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.checkBoxWindowsUpdates = new System.Windows.Forms.CheckBox();
            this.checkedListBoxApps = new System.Windows.Forms.CheckedListBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.checkBoxAppToggle = new System.Windows.Forms.CheckBox();
            this.linkLabelInstall = new System.Windows.Forms.LinkLabel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 309);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(522, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelInstall);
            this.groupBox1.Controls.Add(this.checkBoxAppToggle);
            this.groupBox1.Controls.Add(this.checkedListBoxApps);
            this.groupBox1.Controls.Add(this.checkBoxWindowsUpdates);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 273);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows 7 64-bit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(522, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // checkBoxWindowsUpdates
            // 
            this.checkBoxWindowsUpdates.AutoSize = true;
            this.checkBoxWindowsUpdates.Location = new System.Drawing.Point(8, 19);
            this.checkBoxWindowsUpdates.Name = "checkBoxWindowsUpdates";
            this.checkBoxWindowsUpdates.Size = new System.Drawing.Size(157, 17);
            this.checkBoxWindowsUpdates.TabIndex = 0;
            this.checkBoxWindowsUpdates.Text = "Install All Windows Updates";
            this.checkBoxWindowsUpdates.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxApps
            // 
            this.checkedListBoxApps.FormattingEnabled = true;
            this.checkedListBoxApps.Location = new System.Drawing.Point(6, 65);
            this.checkedListBoxApps.Name = "checkedListBoxApps";
            this.checkedListBoxApps.Size = new System.Drawing.Size(486, 184);
            this.checkedListBoxApps.TabIndex = 1;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // checkBoxAppToggle
            // 
            this.checkBoxAppToggle.AutoSize = true;
            this.checkBoxAppToggle.Location = new System.Drawing.Point(8, 42);
            this.checkBoxAppToggle.Name = "checkBoxAppToggle";
            this.checkBoxAppToggle.Size = new System.Drawing.Size(97, 17);
            this.checkBoxAppToggle.TabIndex = 2;
            this.checkBoxAppToggle.Text = "Select All Apps";
            this.checkBoxAppToggle.UseVisualStyleBackColor = true;
            // 
            // linkLabelInstall
            // 
            this.linkLabelInstall.AutoSize = true;
            this.linkLabelInstall.Location = new System.Drawing.Point(410, 252);
            this.linkLabelInstall.Name = "linkLabelInstall";
            this.linkLabelInstall.Size = new System.Drawing.Size(82, 13);
            this.linkLabelInstall.TabIndex = 3;
            this.linkLabelInstall.TabStop = true;
            this.linkLabelInstall.Text = "Start Installation";
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
            this.configBuilderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configBuilderToolStripMenuItem.Text = "Config Builder";
            // 
            // switchEditorToolStripMenuItem
            // 
            this.switchEditorToolStripMenuItem.Name = "switchEditorToolStripMenuItem";
            this.switchEditorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.switchEditorToolStripMenuItem.Text = "Switch Editor";
            // 
            // ApplicationInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ApplicationInstaller";
            this.Text = "ApplicationInstaller";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.CheckedListBox checkedListBoxApps;
        private System.Windows.Forms.CheckBox checkBoxWindowsUpdates;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox checkBoxAppToggle;
        private System.Windows.Forms.LinkLabel linkLabelInstall;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchEditorToolStripMenuItem;

    }
}
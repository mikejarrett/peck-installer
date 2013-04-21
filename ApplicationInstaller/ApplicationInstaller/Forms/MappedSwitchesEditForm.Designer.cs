namespace ApplicationInstaller
{
    partial class MappedSwitchesEditForm
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
            this.dgvMappedSwitches = new System.Windows.Forms.DataGridView();
            this.linkSelectAppName = new System.Windows.Forms.LinkLabel();
            this.linkSelectFileName = new System.Windows.Forms.LinkLabel();
            this.tbApplicationName = new System.Windows.Forms.TextBox();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.cbSwitches = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkAddToList = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappedSwitches)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMappedSwitches
            // 
            this.dgvMappedSwitches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMappedSwitches.Location = new System.Drawing.Point(12, 105);
            this.dgvMappedSwitches.Name = "dgvMappedSwitches";
            this.dgvMappedSwitches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMappedSwitches.Size = new System.Drawing.Size(590, 236);
            this.dgvMappedSwitches.TabIndex = 0;
            this.dgvMappedSwitches.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMappedSwitchesMouseDown);
            this.dgvMappedSwitches.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvMappedSwitchesKeyUpEvent);
            // 
            // linkSelectAppName
            // 
            this.linkSelectAppName.AutoSize = true;
            this.linkSelectAppName.Location = new System.Drawing.Point(12, 24);
            this.linkSelectAppName.Name = "linkSelectAppName";
            this.linkSelectAppName.Size = new System.Drawing.Size(90, 13);
            this.linkSelectAppName.TabIndex = 2;
            this.linkSelectAppName.TabStop = true;
            this.linkSelectAppName.Text = "Application Name";
            this.linkSelectAppName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectAppName_LinkClicked);
            // 
            // linkSelectFileName
            // 
            this.linkSelectFileName.AutoSize = true;
            this.linkSelectFileName.Location = new System.Drawing.Point(341, 24);
            this.linkSelectFileName.Name = "linkSelectFileName";
            this.linkSelectFileName.Size = new System.Drawing.Size(49, 13);
            this.linkSelectFileName.TabIndex = 3;
            this.linkSelectFileName.TabStop = true;
            this.linkSelectFileName.Text = "Filename";
            this.linkSelectFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelectFileName_LinkClicked);
            // 
            // tbApplicationName
            // 
            this.tbApplicationName.Location = new System.Drawing.Point(108, 21);
            this.tbApplicationName.Name = "tbApplicationName";
            this.tbApplicationName.Size = new System.Drawing.Size(200, 20);
            this.tbApplicationName.TabIndex = 4;
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(402, 21);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(200, 20);
            this.tbFilename.TabIndex = 5;
            // 
            // cbSwitches
            // 
            this.cbSwitches.FormattingEnabled = true;
            this.cbSwitches.Location = new System.Drawing.Point(73, 47);
            this.cbSwitches.Name = "cbSwitches";
            this.cbSwitches.Size = new System.Drawing.Size(529, 21);
            this.cbSwitches.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Switches";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(614, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAndExitToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAndExitToolStripMenuItem
            // 
            this.saveAndExitToolStripMenuItem.Name = "saveAndExitToolStripMenuItem";
            this.saveAndExitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAndExitToolStripMenuItem.Text = "Save and Exit";
            this.saveAndExitToolStripMenuItem.Click += new System.EventHandler(this.saveAndExitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // linkAddToList
            // 
            this.linkAddToList.AutoSize = true;
            this.linkAddToList.Location = new System.Drawing.Point(539, 80);
            this.linkAddToList.Name = "linkAddToList";
            this.linkAddToList.Size = new System.Drawing.Size(57, 13);
            this.linkAddToList.TabIndex = 9;
            this.linkAddToList.TabStop = true;
            this.linkAddToList.Text = "Add to List";
            this.linkAddToList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddToList_LinkClicked);
            // 
            // MappedSwitchesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 353);
            this.Controls.Add(this.linkAddToList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSwitches);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.tbApplicationName);
            this.Controls.Add(this.linkSelectFileName);
            this.Controls.Add(this.linkSelectAppName);
            this.Controls.Add(this.dgvMappedSwitches);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MappedSwitchesEditForm";
            this.Text = "Edit Mapped Switches";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappedSwitches)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMappedSwitches;
        private System.Windows.Forms.LinkLabel linkSelectAppName;
        private System.Windows.Forms.LinkLabel linkSelectFileName;
        private System.Windows.Forms.TextBox tbApplicationName;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.ComboBox cbSwitches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAndExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkAddToList;
    }
}
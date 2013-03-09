namespace ApplicationInstaller
{
    partial class ApplicationsBuilder
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.tbRelativePath = new System.Windows.Forms.TextBox();
            this.tbApplicationName = new System.Windows.Forms.TextBox();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.gridviewApplicationList = new System.Windows.Forms.DataGridView();
            this.applicationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.absolutePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.installSwitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuDeleteRow = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridviewApplicationList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Switches / Arguments";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(591, 112);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 7;
            this.btnAddToList.Text = "Add App";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(433, 8);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.Size = new System.Drawing.Size(220, 20);
            this.tbFilename.TabIndex = 2;
            // 
            // tbRelativePath
            // 
            this.tbRelativePath.Location = new System.Drawing.Point(131, 60);
            this.tbRelativePath.Name = "tbRelativePath";
            this.tbRelativePath.Size = new System.Drawing.Size(522, 20);
            this.tbRelativePath.TabIndex = 4;
            // 
            // tbApplicationName
            // 
            this.tbApplicationName.Location = new System.Drawing.Point(131, 8);
            this.tbApplicationName.Name = "tbApplicationName";
            this.tbApplicationName.Size = new System.Drawing.Size(220, 20);
            this.tbApplicationName.TabIndex = 1;
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(433, 86);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(220, 20);
            this.tbVersion.TabIndex = 6;
            // 
            // gridviewApplicationList
            // 
            this.gridviewApplicationList.AllowUserToOrderColumns = true;
            this.gridviewApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewApplicationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.applicationName,
            this.filename,
            this.absolutePath,
            this.relativePath,
            this.installSwitches,
            this.version});
            this.gridviewApplicationList.ContextMenuStrip = this.menuDeleteRow;
            this.gridviewApplicationList.Location = new System.Drawing.Point(15, 141);
            this.gridviewApplicationList.Name = "gridviewApplicationList";
            this.gridviewApplicationList.RowHeadersWidth = 49;
            this.gridviewApplicationList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewApplicationList.Size = new System.Drawing.Size(651, 200);
            this.gridviewApplicationList.TabIndex = 9;
            this.gridviewApplicationList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewApplicationList_CellContentClick);
            // 
            // applicationName
            // 
            this.applicationName.HeaderText = "Name";
            this.applicationName.Name = "applicationName";
            this.applicationName.ReadOnly = true;
            // 
            // filename
            // 
            this.filename.HeaderText = "Filename";
            this.filename.Name = "filename";
            this.filename.ReadOnly = true;
            // 
            // absolutePath
            // 
            this.absolutePath.HeaderText = "AbsolutePath";
            this.absolutePath.Name = "absolutePath";
            this.absolutePath.ReadOnly = true;
            // 
            // relativePath
            // 
            this.relativePath.HeaderText = "Relative Path";
            this.relativePath.Name = "relativePath";
            this.relativePath.ReadOnly = true;
            // 
            // installSwitches
            // 
            this.installSwitches.HeaderText = "Switches";
            this.installSwitches.Name = "installSwitches";
            this.installSwitches.ReadOnly = true;
            // 
            // version
            // 
            this.version.HeaderText = "Version";
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // menuDeleteRow
            // 
            this.menuDeleteRow.Name = "menuDeleteRow";
            this.menuDeleteRow.Size = new System.Drawing.Size(61, 4);
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(378, 11);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(49, 13);
            this.lbFilename.TabIndex = 15;
            this.lbFilename.TabStop = true;
            this.lbFilename.Text = "Filename";
            this.lbFilename.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbFilename_LinkClicked);
            // 
            // lbRelativePath
            // 
            this.lbRelativePath.AutoSize = true;
            this.lbRelativePath.Location = new System.Drawing.Point(12, 63);
            this.lbRelativePath.Name = "lbRelativePath";
            this.lbRelativePath.Size = new System.Drawing.Size(101, 13);
            this.lbRelativePath.TabIndex = 16;
            this.lbRelativePath.TabStop = true;
            this.lbRelativePath.Text = "Relative Install Path";
            this.lbRelativePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbRelativePath_LinkClicked);
            // 
            // lbAppName
            // 
            this.lbAppName.AutoSize = true;
            this.lbAppName.Location = new System.Drawing.Point(12, 11);
            this.lbAppName.Name = "lbAppName";
            this.lbAppName.Size = new System.Drawing.Size(90, 13);
            this.lbAppName.TabIndex = 17;
            this.lbAppName.TabStop = true;
            this.lbAppName.Text = "Application Name";
            this.lbAppName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAppName_LinkClicked);
            // 
            // btnWriteConfig
            // 
            this.btnWriteConfig.Location = new System.Drawing.Point(597, 347);
            this.btnWriteConfig.Name = "btnWriteConfig";
            this.btnWriteConfig.Size = new System.Drawing.Size(75, 23);
            this.btnWriteConfig.TabIndex = 8;
            this.btnWriteConfig.Text = "Write Config";
            this.btnWriteConfig.UseVisualStyleBackColor = true;
            this.btnWriteConfig.Click += new System.EventHandler(this.btnWriteConfig_Click);
            // 
            // btnClearInput
            // 
            this.btnClearInput.Location = new System.Drawing.Point(15, 112);
            this.btnClearInput.Name = "btnClearInput";
            this.btnClearInput.Size = new System.Drawing.Size(75, 23);
            this.btnClearInput.TabIndex = 10;
            this.btnClearInput.Text = "Clear";
            this.btnClearInput.UseVisualStyleBackColor = true;
            this.btnClearInput.Click += new System.EventHandler(this.btnClearInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(359, 9);
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
            this.label4.Location = new System.Drawing.Point(659, 9);
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
            this.label5.Location = new System.Drawing.Point(659, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "*";
            // 
            // lbAbsolutePath
            // 
            this.lbAbsolutePath.AutoSize = true;
            this.lbAbsolutePath.Location = new System.Drawing.Point(12, 37);
            this.lbAbsolutePath.Name = "lbAbsolutePath";
            this.lbAbsolutePath.Size = new System.Drawing.Size(103, 13);
            this.lbAbsolutePath.TabIndex = 23;
            this.lbAbsolutePath.TabStop = true;
            this.lbAbsolutePath.Text = "Absolute Install Path";
            this.lbAbsolutePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAbsolutePath_LinkClicked);
            // 
            // tbAbsolutePath
            // 
            this.tbAbsolutePath.Location = new System.Drawing.Point(131, 34);
            this.tbAbsolutePath.Name = "tbAbsolutePath";
            this.tbAbsolutePath.Size = new System.Drawing.Size(522, 20);
            this.tbAbsolutePath.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(659, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "*";
            // 
            // cbSwitches
            // 
            this.cbSwitches.FormattingEnabled = true;
            this.cbSwitches.Location = new System.Drawing.Point(129, 86);
            this.cbSwitches.Name = "cbSwitches";
            this.cbSwitches.Size = new System.Drawing.Size(243, 21);
            this.cbSwitches.TabIndex = 26;
            // 
            // ApplicationsBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 378);
            this.Controls.Add(this.cbSwitches);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAbsolutePath);
            this.Controls.Add(this.lbAbsolutePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearInput);
            this.Controls.Add(this.btnWriteConfig);
            this.Controls.Add(this.lbAppName);
            this.Controls.Add(this.lbRelativePath);
            this.Controls.Add(this.lbFilename);
            this.Controls.Add(this.gridviewApplicationList);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.tbApplicationName);
            this.Controls.Add(this.tbRelativePath);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ApplicationsBuilder";
            this.Text = "Application Builder";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewApplicationList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.TextBox tbRelativePath;
        private System.Windows.Forms.TextBox tbApplicationName;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.DataGridView gridviewApplicationList;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn applicationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn absolutePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn installSwitches;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.ComboBox cbSwitches;
    }
}


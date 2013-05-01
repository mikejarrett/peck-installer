namespace ComputerUpdater
{
    partial class AboutBox
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.linkOK = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(93, 13);
            this.labelProductName.TabIndex = 0;
            this.labelProductName.Text = "Computer Updater";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(111, 9);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 1;
            this.labelVersion.Text = "Version";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(12, 29);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(88, 13);
            this.labelCopyright.TabIndex = 2;
            this.labelCopyright.Text = "Copyright C 9999";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Location = new System.Drawing.Point(111, 29);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(62, 13);
            this.labelCompanyName.TabIndex = 3;
            this.labelCompanyName.Text = "Mike Jarrett";
            // 
            // linkOK
            // 
            this.linkOK.AutoSize = true;
            this.linkOK.Location = new System.Drawing.Point(91, 59);
            this.linkOK.Name = "linkOK";
            this.linkOK.Size = new System.Drawing.Size(22, 13);
            this.linkOK.TabIndex = 4;
            this.linkOK.TabStop = true;
            this.linkOK.Text = "OK";
            this.linkOK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOK_LinkClicked);
            // 
            // AboutBox
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(203, 82);
            this.Controls.Add(this.linkOK);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(219, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(219, 120);
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.LinkLabel linkOK;
    }
}
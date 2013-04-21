namespace ApplicationInstaller.Forms
{
    partial class AppSwitchMappingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSwitchMappingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbDiscoverSwitches = new System.Windows.Forms.RadioButton();
            this.rbNoSwitches = new System.Windows.Forms.RadioButton();
            this.rbApplyTheseSwitches = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSwitches = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 13);
            this.label1.TabIndex = 1000;
            this.label1.Text = "Would you like this program to attempt to determine the switches / parameters of " +
    "the discovered files?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 13);
            this.label3.TabIndex = 1000;
            this.label3.Text = "Autodiscovering will slow processing down";
            // 
            // rbDiscoverSwitches
            // 
            this.rbDiscoverSwitches.AutoSize = true;
            this.rbDiscoverSwitches.Location = new System.Drawing.Point(6, 19);
            this.rbDiscoverSwitches.Name = "rbDiscoverSwitches";
            this.rbDiscoverSwitches.Size = new System.Drawing.Size(204, 17);
            this.rbDiscoverSwitches.TabIndex = 1;
            this.rbDiscoverSwitches.TabStop = true;
            this.rbDiscoverSwitches.Text = "Yes, attempt to autodiscover switches";
            this.rbDiscoverSwitches.UseVisualStyleBackColor = true;
            // 
            // rbNoSwitches
            // 
            this.rbNoSwitches.AutoSize = true;
            this.rbNoSwitches.Location = new System.Drawing.Point(6, 65);
            this.rbNoSwitches.Name = "rbNoSwitches";
            this.rbNoSwitches.Size = new System.Drawing.Size(148, 17);
            this.rbNoSwitches.TabIndex = 4;
            this.rbNoSwitches.TabStop = true;
            this.rbNoSwitches.Text = "No, just process the folder";
            this.rbNoSwitches.UseVisualStyleBackColor = true;
            // 
            // rbApplyTheseSwitches
            // 
            this.rbApplyTheseSwitches.AutoSize = true;
            this.rbApplyTheseSwitches.Location = new System.Drawing.Point(6, 42);
            this.rbApplyTheseSwitches.Name = "rbApplyTheseSwitches";
            this.rbApplyTheseSwitches.Size = new System.Drawing.Size(197, 17);
            this.rbApplyTheseSwitches.TabIndex = 2;
            this.rbApplyTheseSwitches.TabStop = true;
            this.rbApplyTheseSwitches.Text = "No, apply the follow switch to all files";
            this.rbApplyTheseSwitches.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(404, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSwitches
            // 
            this.tbSwitches.Location = new System.Drawing.Point(209, 41);
            this.tbSwitches.Name = "tbSwitches";
            this.tbSwitches.Size = new System.Drawing.Size(273, 20);
            this.tbSwitches.TabIndex = 3;
            this.tbSwitches.Text = "/passive /norestart";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSwitches);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbApplyTheseSwitches);
            this.groupBox1.Controls.Add(this.rbDiscoverSwitches);
            this.groupBox1.Controls.Add(this.rbNoSwitches);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 95);
            this.groupBox1.TabIndex = 1001;
            this.groupBox1.TabStop = false;
            // 
            // AppSwitchMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 160);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppSwitchMapping";
            this.Text = "Attempt to determine switches?";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbDiscoverSwitches;
        private System.Windows.Forms.RadioButton rbNoSwitches;
        private System.Windows.Forms.RadioButton rbApplyTheseSwitches;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSwitches;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
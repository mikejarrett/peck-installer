namespace ApplicationInstaller
{
    partial class EditSwitches
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSwitch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbSwitches = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Switch";
            // 
            // tbSwitch
            // 
            this.tbSwitch.Location = new System.Drawing.Point(57, 19);
            this.tbSwitch.Name = "tbSwitch";
            this.tbSwitch.Size = new System.Drawing.Size(565, 20);
            this.tbSwitch.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(628, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lbSwitches
            // 
            this.lbSwitches.FormattingEnabled = true;
            this.lbSwitches.Location = new System.Drawing.Point(15, 45);
            this.lbSwitches.Name = "lbSwitches";
            this.lbSwitches.Size = new System.Drawing.Size(661, 147);
            this.lbSwitches.TabIndex = 3;
            // 
            // EditSwitches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 201);
            this.Controls.Add(this.lbSwitches);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbSwitch);
            this.Controls.Add(this.label1);
            this.Name = "EditSwitches";
            this.Text = "EditSwitches";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSwitch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbSwitches;
    }
}
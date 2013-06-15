using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerUpdater.Forms
{
    public partial class AppSwitchMappingForm : Form
    {
        public int radioButtonCheckedID
        { get; set; }

        public String strSwitch
        { get; set; }

        public AppSwitchMappingForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbDiscoverSwitches.Checked)
            {
                radioButtonCheckedID = 1;
                strSwitch = String.Empty;
            }
            else if (rbApplyTheseSwitches.Checked)
            {
                radioButtonCheckedID = 2;
                strSwitch = tbSwitches.Text != null ? tbSwitches.Text.ToString() : String.Empty;
            }
            else
            {
                radioButtonCheckedID = 3;
                strSwitch = String.Empty;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

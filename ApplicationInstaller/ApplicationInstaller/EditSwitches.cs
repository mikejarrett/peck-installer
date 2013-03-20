using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationInstaller.Schemas;

namespace ApplicationInstaller
{
    public partial class EditSwitches : Form
    {
        public List<Switches> switches
        { get; set; }

        public EditSwitches(Form parentForm, List<Switches> SwitchesArgs)
        {
            InitializeComponent();

            switches = SwitchesArgs;
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            foreach (var s in switches)
            {
                lbSwitches.Items.Add(s.Switch.ToString());
            }
        }
    }
}

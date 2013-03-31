using ApplicationInstaller.Classes;
using ApplicationInstaller.Schemas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        private void lbSwitched_IndexChanged(object sender, EventArgs e)
        {
            if (lbSwitches.SelectedIndex == -1)
            {
                tbSwitch.Text = String.Empty;
            }
            else
            {
                tbSwitch.Text = lbSwitches.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = lbSwitches.SelectedIndex;
            if (index == -1)
            {
                lbSwitches.Items.Add(tbSwitch.Text.ToString());
            }
            else
            {
                lbSwitches.Items[index] = tbSwitch.Text.ToString();
            }
            lbSwitches.EndUpdate();
            lbSwitches.SelectedIndex = -1;
            tbSwitch.Text = String.Empty;
        }

        private void lbDeletePressed(object sender, KeyEventArgs e)
        {
            int index = lbSwitches.SelectedIndex;
            if (e.KeyData == Keys.Delete && index != -1)
            {
                lbSwitches.Items.RemoveAt(index);
            }
            lbSwitches.EndUpdate();
            lbSwitches.SelectedIndex = -1;
            tbSwitch.Text = String.Empty;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Switches> switches = new List<Switches>();
            foreach (var item in lbSwitches.Items)
            {
                switches.Add(new Switches(item.ToString()));
            }

            if (switches.Count > 0)
            {
                switches.Sort(
                    delegate(Switches sw1, Switches sw2)
                    { 
                        return ( sw1.Switch.CompareTo(sw2.Switch) ); 
                    } 
                );
                String filePath = @"Configs\Switches.xml";
                XmlProcessor.WriteSwitchesToXML(filePath, switches);
                MessageBox.Show("Config written successfully to: " + filePath);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nothing to write to configuration file");
            }
        }
    }
}

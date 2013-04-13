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
            foreach (var obj in switches)
            {
                lbSwitches.Items.Add(obj.Switch.ToString());
            }
        }

        /// <summary>
        /// If the selected index is -1 set the textbox string to empty else set the
        /// textbox to the currently selected string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Add the switch from the textbox into the list and clear the textbox field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// If deleted button is pressed remove the item from list and set textbox to empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbButtonPressed(object sender, KeyEventArgs e)
        {
            int index = lbSwitches.SelectedIndex;
            if (e.KeyData == Keys.Delete && index != -1)
            {
                lbSwitches.Items.RemoveAt(index);
                lbSwitches.EndUpdate();
                lbSwitches.SelectedIndex = -1;
                tbSwitch.Text = String.Empty;
            }

        }

        /// <summary>
        /// Close this form and show the other form that opened this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save everything in the switches list to the relative Configs folder
        /// and to the file Switches.xml and then close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                GenericXmlProcessor<Switches>.WriteToXML(filePath, switches);
                MessageBox.Show("Config written successfully to: " + filePath);
                this.Close();
            }
            else
            {
                MessageBox.Show("Nothing to write to configuration file");
            }
        }

        /// <summary>
        /// Remove item from the switches list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = lbSwitches.SelectedIndex;
            lbSwitches.Items.RemoveAt(index);
            lbSwitches.EndUpdate();
        }
    }
}

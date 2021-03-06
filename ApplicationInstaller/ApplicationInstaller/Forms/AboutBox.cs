﻿using System;
using System.Windows.Forms;
using ComputerUpdater.Classes;

namespace ComputerUpdater
{
    // Code generated by adding an "About" box
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.labelProductName.Text = About.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", About.AssemblyVersion);
            this.labelCopyright.Text = About.AssemblyCopyright;
            this.labelCompanyName.Text = About.AssemblyCompany;
        }

        private void linkOK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
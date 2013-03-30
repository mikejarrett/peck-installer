using ApplicationInstaller.Classes;
using System;
using System.Windows.Forms;

namespace ApplicationInstaller
{
    public partial class InstallInfoform : Form
    {
        InstallInformationHolder installInformationHolder
        { set; get; }

        public InstallInfoform(InstallInformationHolder installInfoHolder)
        {
            installInformationHolder = installInfoHolder;
            InitializeComponent();

            lblUpdates.Text = installInfoHolder.updateCount.ToString();
            lblApplications.Text = installInfoHolder.applicationCount.ToString();
            lblAdditional.Text = installInfoHolder.additionalCount.ToString();
            lblRegistry.Text = installInfoHolder.registryCount.ToString();
            progressBar1.Maximum = installInfoHolder.GetTotal();

            ProcessUpdates();
        }

        private void ProcessUpdates()
        {
            InstallUpdates();
            InstallApplications();
            ProcessAdditionalConfigs();
            ProcessReigstryFiles();
            linkDone.Enabled = true;
        }

        private void InstallUpdates()
        {
            if (installInformationHolder.installUpdates)
            {
                rtbInstallationInfo.AppendText("Installing Update...");
                rtbInstallationInfo.AppendText(Environment.NewLine);
                foreach (var update in installInformationHolder.updatesToInstall)
                {
                    rtbInstallationInfo.AppendText(String.Format(" * {0}...", update.ToString()));
                    rtbInstallationInfo.AppendText(Environment.NewLine);
                    progressBar1.Value += 1;
                }
                rtbInstallationInfo.AppendText(Environment.NewLine);
            }
        }

        private void InstallApplications()
        {
            if (installInformationHolder.applicationCount > 0)
            {
                rtbInstallationInfo.AppendText("Installing Applications...");
                rtbInstallationInfo.AppendText(Environment.NewLine);
                foreach (var app in installInformationHolder.appsToInstall)
                {
                    rtbInstallationInfo.AppendText(String.Format(" * {0} ({1})...", app.ToString(), app.Version));
                    rtbInstallationInfo.AppendText(Environment.NewLine);
                    progressBar1.Value += 1;
                }
                rtbInstallationInfo.AppendText(Environment.NewLine);
            }
        }

        private void ProcessAdditionalConfigs()
        {
            if (installInformationHolder.additionalCount > 0)
            {
                rtbInstallationInfo.AppendText("\nInstalling Additional Applications...");
                rtbInstallationInfo.AppendText(Environment.NewLine);
                foreach (var app in installInformationHolder.additionalToInstall)
                {
                    rtbInstallationInfo.AppendText(String.Format(" * {0} ({1})...", app.ToString(), app.Version));
                    rtbInstallationInfo.AppendText(Environment.NewLine);
                    progressBar1.Value += 1;
                }
                rtbInstallationInfo.AppendText(Environment.NewLine);
            }
        }

        private void ProcessReigstryFiles()
        {
            if (installInformationHolder.registryCount > 0)
            {
                rtbInstallationInfo.AppendText("Processing Registry Files...");
                rtbInstallationInfo.AppendText(Environment.NewLine);
                foreach (String filename in installInformationHolder.registryToInstall)
                {
                    rtbInstallationInfo.AppendText(String.Format(" * Applying: {0}...", filename.ToString()));
                    rtbInstallationInfo.AppendText(Environment.NewLine);
                    progressBar1.Value += 1;
                }
                rtbInstallationInfo.AppendText(Environment.NewLine);
            }
        }

        private void linkDone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}

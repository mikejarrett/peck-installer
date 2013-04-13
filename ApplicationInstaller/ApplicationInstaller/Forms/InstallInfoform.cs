using ApplicationInstaller.Classes;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ApplicationInstaller
{
    public partial class InstallInfoform : Form
    {
        public delegate void ProgressBarDelegate();
        public delegate void RichTextDelegate(String updateRichText);
        public delegate void EnableDoneDelegate();

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

            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessUpdates), null);
        }

        private void ProcessUpdates(object args)
        {
            InstallServicePack();
            InstallUpdates();
            InstallApplications();
            ProcessAdditionalConfigs();
            ProcessReigstryFiles();
            this.Invoke(new EnableDoneDelegate(EnableDoneLink));
        }

        private void EnableDoneLink()
        {
            linkDone.Enabled = true;
        }

        private void InstallServicePack()
        {
            if (installInformationHolder.installServicePack)
            {
                this.Invoke(new RichTextDelegate(UpdateRichText), String.Format("Installing Service Pack..."));
                try
                {
                    installInformationHolder.servicePack.Install();
                    this.Invoke(new ProgressBarDelegate(UpdateProgressBar));
                }
                catch (Exception)
                {
                    this.Invoke(new RichTextDelegate(UpdateRichText), " ! Installation cancelled");
                }
                this.Invoke(new RichTextDelegate(UpdateRichText), "");
            }
        }

        private void InstallUpdates()
        {
            if (installInformationHolder.installUpdates)
            {
                this.Invoke(new RichTextDelegate(UpdateRichText), String.Format("Installing Update..."));
                foreach (var update in installInformationHolder.updatesToInstall)
                {
                    this.Invoke(new RichTextDelegate(UpdateRichText), String.Format(" * {0}...", update.ToString()));
                    try
                    {
                        update.Install();
                        this.Invoke(new ProgressBarDelegate(UpdateProgressBar));
                    }
                    catch (Exception)
                    {
                        this.Invoke(new RichTextDelegate(UpdateRichText), " ! Installation cancelled");
                    }
                }
                this.Invoke(new RichTextDelegate(UpdateRichText), "");
            }
        }
        
        private void InstallApplications()
        {
            if (installInformationHolder.applicationCount > 0)
            {
                this.Invoke(new RichTextDelegate(UpdateRichText), "Installing Applications...");
                foreach (var app in installInformationHolder.appsToInstall)
                {
                    this.Invoke(new RichTextDelegate(UpdateRichText), String.Format(" * {0} ({1})...", app.ToString(), app.Version));
                    try
                    {
                        app.Install();
                        this.Invoke(new ProgressBarDelegate(UpdateProgressBar));
                    }
                    catch (Exception)
                    {
                        
                        this.Invoke(new RichTextDelegate(UpdateRichText), " ! Installation cancelled");
                    }
                }
            }
        }

        private void ProcessAdditionalConfigs()
        {
            if (installInformationHolder.additionalCount > 0)
            {
                this.Invoke(new RichTextDelegate(UpdateRichText), "Installing Additional Applications...");
                foreach (var app in installInformationHolder.additionalToInstall)
                {
                    this.Invoke(new RichTextDelegate(UpdateRichText), String.Format(" * {0} ({1})...", app.ToString(), app.Version));
                    try
                    {
                        app.Install();
                        this.Invoke(new ProgressBarDelegate(UpdateProgressBar));
                    }
                    catch (Exception)
                    {
                        this.Invoke(new RichTextDelegate(UpdateRichText), " ! Installation cancelled");
                    }
                }
                this.Invoke(new RichTextDelegate(UpdateRichText), "");
            }
        }

        private void ProcessReigstryFiles()
        {
            if (installInformationHolder.registryCount > 0)
            {
                this.Invoke(new RichTextDelegate(UpdateRichText), "Processing Registry Files...");
                foreach (String filename in installInformationHolder.registryToInstall)
                {
                    if (File.Exists(filename))
                    {
                        this.Invoke(new RichTextDelegate(UpdateRichText), String.Format(" * Applying: {0}...", filename.ToString()));
                        Process regeditProcess = Process.Start("regedit.exe", String.Format("/s {0}", filename.ToString()));
                        regeditProcess.WaitForExit();
                    }
                    else
                    {
                        this.Invoke(new RichTextDelegate(UpdateRichText), String.Format(" * Couldn't find: {0}...", filename.ToString()));
                    }
                    this.Invoke(new ProgressBarDelegate(UpdateProgressBar));
                }
                this.Invoke(new RichTextDelegate(UpdateRichText), "");
            }
        }

        public void UpdateRichText(String updateString)
        {
            if (updateString != "")
            {
                rtbInstallationInfo.AppendText(updateString);
            }
            rtbInstallationInfo.AppendText(Environment.NewLine);
        }

        private void UpdateProgressBar()
        {
            if (progressBar1.Value != progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
        }

        private void linkDone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}

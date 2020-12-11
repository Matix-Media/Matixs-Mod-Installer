using AutoUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{
    public partial class Options : Form
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();


        private string launcherLocation = Memory.minecraftLauncherLocation;
        public Options()
        {
            InitializeComponent();
        }

        private void btnEditSources_Click(object sender, EventArgs e)
        {
            using (EditSources dialog = new EditSources())
            {
                dialog.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Executable|*.exe";
                dialog.Title = "Select Minecraft Launcher Executable...";
                dialog.DefaultExt = ".exe";
                dialog.Multiselect = false;


                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName))
                    {
                        launcherLocation = dialog.FileName;
                    }
                    else
                    {
                        MessageBox.Show("The selected file was not found on your system.");
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Memory.minecraftLauncherLocation = launcherLocation;
            if (File.Exists(Memory.minecraftLauncherLocation))
            {
                Memory.launcherFound = true;
            } else
            {
                Memory.launcherFound = false;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool updateFound = false;
        private void button2_Click(object sender, EventArgs e)
        {
            Updater.GitHubRepo = Memory.githubRepository;

            if (!updateFound)
            {
                if (Updater.HasUpdate)
                {
                    updateFound = true;
                    _log.Info("Update found.");
                    btnCheckUpdates.Text = "Download";
                    btnCheckUpdates.Tag = 1;
                    lblCheckUpdates.Text = "New Version found!";

                }
                else
                {
                    lblCheckUpdates.Text = "No updates found";
                    btnCheckUpdates.Tag = 0;
                }
            } else
            {
                _log.Info("Starting update through restart and force update...");
                System.Threading.Thread.Sleep(1000);
                restartWithPerms(new string[2] { "--force-update", "--update-initialization" });
            }
            
        }

        private void restartWithPerms(string[] args)
        {
            var psi = new ProcessStartInfo();
            psi.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            psi.Verb = "runas";
            psi.Arguments = String.Join(" ", args);

            _log.Info("Restarting app at \"" + psi.FileName + "\" with parameters \"" + psi.Arguments + "\"...");
            try
            {
                var proc = Process.Start(psi);
            }
            catch (Exception e)
            {
                _log.Fatal("Could not restart app: " + e.ToString());
                MessageBox.Show("Could not restart app.\nIf the error recurs please contact our team.\n" + e.ToString(), "Restart Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
            System.Threading.Thread.CurrentThread.Abort();
        }
    }
}

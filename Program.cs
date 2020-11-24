using AutoUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{
    static class Program
    {

        private static NLog.Logger _log = null;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Utils.initLogger();
            _log = NLog.LogManager.GetCurrentClassLogger();
            _log.Info("Starting App at " + DateTime.Now.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (checkForUpdateInit() == false)
                Application.Run(new MainForm());
        }

        private static bool checkForUpdateInit()
        {
            try
            {
                if (Environment.GetCommandLineArgs().Contains("--update-initialization"))
                {
                    _log.Info("Initializing updates...");
                    if (Utils.IsAdministrator())
                    {
                        _log.Info("IU: Checking for updates...");

                        Updater.GitHubRepo = "/Matix-Media/Matixs-Mod-Installer";

                        if (Environment.GetCommandLineArgs().Contains("--force-update"))
                        {
                            _log.Info("IU: Force Updating (Version " + Updater.LatestVersion + ")...");
                            Updater.ForceUpdate = true;
                            Updater.Update(new string[0]);
                            return true;
                        }
                        else
                        {
                            _log.Info("IU: No force update");
                        }

                        if (Updater.HasUpdate)
                        {
                            _log.Info("IU: Update found. Installing...");
                            Updater.Update(new string[0]);
                            return true;
                        }
                        else
                        {
                            _log.Info("IU: No updates found.");
                        }
                    }
                    else
                    {
                        _log.Error("IU: Could not install updates. Require administrative permissions.");
                        MessageBox.Show("Could not install updates. Administrative permissions are required.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _log.Info("No update initialization");
                }
            } catch (Exception e)
            {
                _log.Fatal("Could not install updates. Unknown error: " + e.ToString());
                MessageBox.Show("Could not install updates. Unknown error: " + e.ToString(), "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return false;
        }
    }
}

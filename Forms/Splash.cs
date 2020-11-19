﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdate;


namespace Matixs_Mod_Installer
{
    public partial class Splash : Form
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Application.ProductVersion;
        }

        private void Splash_Shown(object sender, EventArgs e)
        {

        }

        public bool loadSettings()
        {
            lblStatus.Text = "Checking for Updates...";
            _log.Info("Checking for Updates...");
            Refresh();

            Updater.GitHubRepo = "/Matix-Media/Matixs-Mod-Installer";

            if (Updater.HasUpdate)
            {
                _log.Info("Update found. Restarting to install.");
                lblStatus.Text = "Installing new Version...";
                Refresh();
                System.Threading.Thread.Sleep(1000);
                Updater.Update(new string[0]);
            } else
            {
                _log.Info("No updates found.");
            }


            lblStatus.Text = "Loading Settings...";
            Refresh();

            _log.Info("Checking Minecraft Launcher File...");

            string shortcutLocation = Path.GetFullPath("C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Minecraft\\Minecraft.lnk");

            _log.Info(shortcutLocation);

            if (File.Exists(Memory.minecraftLauncherLocation))
            {
                Memory.launcherFound = true;
            }
            else
            {

                if (File.Exists(shortcutLocation))
                {
                    string shortcutTarget = Utils.GetShortcutTargetFile(shortcutLocation);
                    if (File.Exists(shortcutTarget))
                    {
                        Memory.minecraftLauncherLocation = shortcutTarget;
                        Memory.launcherFound = true;
                    } else
                    {
                        Memory.launcherFound = false;
                    }
                } else
                {
                    Memory.launcherFound = false;
                }
            }

            _log.Info("Loading local Settings file...");

            try
            {
                if (File.Exists(Memory.settingsLocation))
                    using (StreamReader r = new StreamReader(Memory.settingsLocation))
                    {
                        string result = r.ReadToEnd();
                        Settings settings = JsonConvert.DeserializeObject<Settings>(result);
                        Memory.modpackSource = settings.modpackSources;
                        Memory.searchHistory = settings.searchHistory;
                        Memory.mainFormLocation = settings.windowPosition;
                        Memory.mainFormSize = settings.windowSize;
                        
                        Memory.mainFormState = settings.windowState;
                    }
            }
            catch (Exception e)
            {
                _log.Error(e, "Could not load Settings!");
            }

            using (WebClient webClient = new WebClient())
            {
                webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                _log.Info("Downloading Forge Source Infos...");

                string result = webClient.DownloadString(Memory.forgeSourcesFile);
                Memory.forgeSources = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(result);

                _log.Info("Downloading Trusted Modpack Sources...");
                result = webClient.DownloadString(Memory.trustedSourcesFile);
                Memory.trustedSources = JsonConvert.DeserializeObject<List<string>>(result);
            }

            _log.Info("Loaded Settings!");
            lblStatus.Text = "Starting...";
            Refresh();

            return true;
        }
    }
}
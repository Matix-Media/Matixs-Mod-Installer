using Newtonsoft.Json;
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
            lblStatus.Text = "Loading Settings...";

            _log.Info("Checking Minecraft Launcher File...");

            if (File.Exists(Memory.minecraftLauncherLocation))
            {
                Memory.launcherFound = true;
            }
            else
            {
                Memory.launcherFound = false;
            }

            _log.Info("Loading local Settings file...");

            try
            {
                if (File.Exists(Memory.settingsLocation))
                    using (StreamReader r = new StreamReader(Memory.settingsLocation))
                    {
                        string result = r.ReadToEnd();
                        Settings settings = JsonConvert.DeserializeObject<Settings>(result);
                        Memory.modpackSource = settings.ModpackSources;
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
                _log.Info("Downloading Forge Source Infos...");

                string result = webClient.DownloadString(Memory.forgeSourcesFile);
                Memory.forgeSources = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(result);

                _log.Info("Downloading Trusted Modpack Sources...");
                result = webClient.DownloadString(Memory.trustedSourcesFile);
                Memory.trustedSources = JsonConvert.DeserializeObject<List<string>>(result);
            }

            _log.Info("Loaded Settings!");
            lblStatus.Text = "Starting...";

            return true;
        }
    }
}

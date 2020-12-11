using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{
    public static class Memory
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        public static readonly string modpacksLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".matixs_mod_installer", "installations");
        public static readonly string settingsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".matixs_mod_installer", "settings.json");
        public static readonly string logLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".matixs_mod_installer", "matixs_mod_installer__d.log");
        public static readonly string minecraftLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
        public static readonly string jreLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".matixs_mod_installer", "jre");

        public static readonly string otherSourcesFile = "https://raw.githubusercontent.com/Matix-Media/matixs-mod-installer-infos/main/other-sources.json";
        public static readonly string forgeSourcesFile = "https://raw.githubusercontent.com/Matix-Media/matixs-mod-installer-infos/main/forge-sources.json";
        public static readonly string trustedSourcesFile = "https://raw.githubusercontent.com/Matix-Media/matixs-mod-installer-infos/main/trusted-sources.json";
        public static readonly string markdownFile = "https://raw.githubusercontent.com/Matix-Media/matixs-mod-installer-infos/main/markdown-style.css";

        public static readonly string githubRepository = "/Matix-Media/Matixs-Mod-Installer";

        public static readonly int maxDescriptionHeight = 200;

        public static string minecraftLauncherLocation = null;

        public static List<string> modpackSource = new List<string>() {
            "https://raw.githubusercontent.com/Matix-Media/matixs-mod-installer-infos/main/matixs-modpacks.json"
        };
        public static Dictionary<string, List<string>> forgeSources = new Dictionary<string, List<string>>();
        public static Dictionary<string, Bitmap> imageCache = new Dictionary<string, Bitmap>();
        public static List<Modpack> loadedModpacks = new List<Modpack>();
        public static List<string> trustedSources = new List<string>();
        public static List<string> searchHistory = new List<string>();

        public static string markdownStyle = "";

        public static bool launcherFound = false;
        public static Size mainFormSize = new Size(1064, 646);
        public static Point mainFormLocation = new Point(100, 100);
        public static FormWindowState mainFormState;

        public static MainForm mainForm;
    }
}

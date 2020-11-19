using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Matixs_Mod_Installer
{
    public class Settings
    {
        public Settings() { }


        public Size windowSize { get; set; }
        public Point windowPosition { get; set; }
        public FormWindowState windowState { get; set; }

        public List<string> modpackSources { get; set; }
        public List<string> searchHistory { get; set; }
    }
}

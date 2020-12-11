using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matixs_Mod_Installer
{
    public class ModpackInfo
    {
        public ModpackInfo() { }

        public string Version { get; set; }
        public string McVersion { get; set; }
        public string InstalledOn { get; set; }
        public string VersionId { get; set; }
        public string UID { get; set; }
        public List<Mod> Mods { get; set; }
    }
}

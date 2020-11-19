using System.Collections.Generic;

namespace Matixs_Mod_Installer
{
    public class Modpack
    {

        public Modpack()
        {
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public string UID { get; set; }
        public string Version { get; set; }
        public string McVersion { get; set; }
        public string ModpackDownload { get; set; }
        public string ModpackSHA256 { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }

    public class ModpackList 
    {
        public ModpackList()
        {
        }

        public string Provider { get; set; }
        public string Website { get; set; }
        public List<Modpack> Modpacks { get; set; }
    }
}
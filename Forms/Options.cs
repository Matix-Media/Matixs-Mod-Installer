using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

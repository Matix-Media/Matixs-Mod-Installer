using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer.Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((string)((Controls.LinkLabelWT)sender).Tag);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblCopyright.Text = "Copyright © 2020-" + DateTime.Today.Year;
            lblVersion.Text = "v" + Application.ProductVersion;

            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in loadedAssemblies)
            {
                rtbDLLs.AppendText(assembly.GetName().Name + " (v" + assembly.GetName().Version + ")\n");
                rtbDLLs.AppendText(assembly.Location + "\n");
                rtbDLLs.AppendText("_____________________________________________________________________\n\n", Color.Silver);
            }
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://matix-media.net/donate");
        }
    }
}

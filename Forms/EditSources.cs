using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{
    public partial class EditSources : Form
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        public EditSources()
        {
            InitializeComponent();
        }

        private void loadList()
        {
            lbSources.Items.Clear();
            foreach (string source in Memory.modpackSource)
            {
                lbSources.Items.Add(source);
            }
        }
        
        private void saveList()
        {
            Memory.modpackSource.Clear();
            foreach (string source in lbSources.Items)
            {
                Memory.modpackSource.Add(source);
            }
        }

        private void addSource(string sourceUrl = "")
        {
            DialogResult result = Utils.ShowInputDialog(ref sourceUrl, "URL to Source File", 400);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (Utils.validateURL(sourceUrl))
            {
                if (!Memory.trustedSources.Contains(sourceUrl))
                {
                    _log.Info("Trying to add untrusted source: " + sourceUrl);
                    if (MessageBox.Show("The source you are trying to add is not trusted. Do you want to proceed?", "Untrusted source", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                }
                Memory.modpackSource.Add(sourceUrl);
                loadList();
                _log.Debug("Added Source URL: " + sourceUrl);
            }
            else
            {
                MessageBox.Show("Could not add Source. Source is not a valid URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addSource(sourceUrl);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addSource();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditSources_Shown(object sender, EventArgs e)
        {
            loadList();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            saveList();
            this.DialogResult = DialogResult.OK;
            this.Close();
            await Memory.mainForm.loadModpacks();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(lbSources);
            selectedItems = lbSources.SelectedItems;

            if (lbSources.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    lbSources.Items.Remove(selectedItems[i]);
            }
        }

       
    }
}

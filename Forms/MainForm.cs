using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Resources;
using System.IO;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Diagnostics;
using System.Security.Cryptography;
using Newtonsoft.Json.Schema;
using CefSharp.WinForms;
using CefSharp;
using CommonMark;
using Matix.PrettyTime;

namespace Matixs_Mod_Installer
{
    public partial class MainForm : Form
    {

        public bool loadComplete = false;

        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();
        private bool installing = false;
        private string installingUID;


        public ChromiumWebBrowser browser;


        public MainForm()
        {
            InitializeComponent();
            Memory.mainForm = this;

            lblVersion.Text = "v" + Application.ProductVersion;
        }

        private async Task saveSettings()
        {
            lblStatusInfo.Text = "Saving Settings...";
            _log.Info("Saving Settings...");

            Settings settings = new Settings();
            settings.modpackSources = Memory.modpackSource;
            if (this.WindowState != FormWindowState.Maximized)
            {
                settings.windowPosition = this.Location;
                settings.windowSize = this.Size;
            }
            settings.windowState = this.WindowState;
            
            if (Memory.minecraftLauncherLocation != null)
            {
                settings.minecraftLauncher = Memory.minecraftLauncherLocation;
            }

            _log.Info("Writing to local Settings file...");
            try
            {
                using (StreamWriter r = new StreamWriter(Memory.settingsLocation))
                {
                    string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                    await r.WriteAsync(json);
                }
            } catch (Exception e)
            {
                _log.Error(e, "Error saving Settings!");
            }


            _log.Info("Saved Settings!");
            lblStatusInfo.Text = "Successfully saved Settings.";
        }

        

        public async Task loadModpacks()
        {
            lblStatusInfo.Text = "Loading Modpacks...";
            lvModpacks.Items.Clear();
            imglstModpacks.Images.Clear();
            Memory.loadedModpacks.Clear();
            pnlLoadingModpacks.Visible = true;
            int counter = 0;
            List<string> loadedUIDs = new List<string>();
            using (WebClient webClient = new WebClient())
            {
                webClient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                foreach (string source in Memory.modpackSource)
                {
                    _log.Info("Loading Modpacks from Source: " + source);
                    string result = await webClient.DownloadStringTaskAsync(source);

                    ModpackList modpacks = JsonConvert.DeserializeObject<ModpackList>(result);

                    _log.Debug("Modpacks Provider: " + modpacks.Provider + "(" + modpacks.Website + ")");
                    foreach (Modpack modpack in modpacks.Modpacks)
                    {
                        _log.Debug("LOAD: Loading Modpack: " + modpack.Name + " (" + modpack.UID + ")");
                        if (loadedUIDs.Contains(modpack.UID))
                        {
                            _log.Warn("LOAD: UID \"" + modpack.UID + "\" already loaded. Skipping");
                            continue;
                        }
                        loadedUIDs.Add(modpack.UID);
                        Memory.loadedModpacks.Add(modpack);
                        ListViewItem item = new ListViewItem(modpack.Name);
                        item.Tag = modpack;
                        imglstModpacks.Images.Add(Properties.Resources.loading);
                        item.ImageIndex = counter;
                        lvModpacks.Items.Add(item);


                        counter++;
                    }
                }
            }

            pnlLoadingModpacks.Visible = false;
            lblStatusInfo.Text = "Loading Modpack Images...";

            counter = 0;
            foreach (ListViewItem item in lvModpacks.Items)
            {

                Modpack modpack = (Modpack)item.Tag;
                if (Utils.validateURL(modpack.Icon))
                {
                    
                    imglstModpacks.Images.Add(modpack.UID, await Utils.loadBitmapFromUrl(modpack.Icon));
                    
                    _log.Debug("LOAD: Added Modpack Icon: " + modpack.Icon);
                }
                else
                {
                    imglstModpacks.Images.Add(modpack.UID, Utils.emptyBitmap());
                    _log.Debug("LOAD: Could not add Modpack Icon: " + modpack.Icon);
                }
                imglstModpacks.Images[counter].Dispose();
                item.ImageIndex = imglstModpacks.Images.IndexOfKey(modpack.UID);

                lvModpacks.Refresh();
                counter++;
            }
            lblStatusInfo.Text = "Successfully loaded Modpacks.";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            Refresh();
            Application.DoEvents();
            await loadModpacks();
        }

        private async Task resetModpackInstallation(Modpack modpack)
        {
            btnInstallMopack.Enabled = true;
            btnUpdate.Enabled = true;
            lblInstallStatus.Visible = false;
            pgbInstallProgress.Visible = false;
            installing = false;
            await selectModpack(modpack);
        }

        private async Task installModpack(Modpack modpack, bool update = false)
        {
            try
            {


                if (update)
                    lblStatusInfo.Text = "Updating Modpack " + modpack.Name + "...";
                else
                    lblStatusInfo.Text = "Installing " + modpack.Name + "...";

                _log.Info("Installing " + modpack.Name);
                installing = true;
                installingUID = modpack.UID;
                pnlInstall.Height = 103;
                btnInstallMopack.Enabled = false;
                btnUpdate.Enabled = false;
                btnInstallMopack.Text = "Installing...";
                pgbInstallProgress.Visible = true;
                pgbInstallProgress.Value = 0;
                lblInstallStatus.Visible = true;

                lblInstallStatus.Text = "Checking if Minecraft is installed...";
                _log.Info("INSTALLATION: Checking if Minecraft is installed...");

                if (!Directory.Exists(Memory.minecraftLocation)) {
                    _log.Error("INSTALLATION: Can not install Modpacks, if Minecraft is not installed.");
                    MessageBox.Show("Minecraft is not installed on your system. Minecraft is required if you want to install Modpacks.", "Minecraft not installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await resetModpackInstallation(modpack);
                    return;
                }
                    if (Utils.checkMinecraftRunning())
                {
                    if (MessageBox.Show("Minecraft is probably running in the background. Please make sure that Minecraft is closed before continuing the installation.\nClick on Cancel to cancel the installation.", "Minecraft running", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        await resetModpackInstallation(modpack);
                        return;
                    }
                    
                }

                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadProgressChanged += (s, e) =>
                        {
                            pgbInstallProgress.Maximum = (int)e.TotalBytesToReceive;
                            pgbInstallProgress.Value = (int)e.BytesReceived;
                        };

                        lblInstallStatus.Text = "Downloading additional informations...";
                        _log.Info("INSTALLATION: Downloading additional informations...");

                        string result = await webClient.DownloadStringTaskAsync(Memory.otherSourcesFile);

                        Dictionary<string, string> otherSources = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                        pgbInstallProgress.Value = 0;
                        pgbInstallProgress.Maximum = 0;

                        lblInstallStatus.Text = "Downloading Minecraft Forge...";
                        _log.Info("INSTALLATION: Downloading Minecraft Forge...");

                        if (!Memory.forgeSources.ContainsKey(modpack.McVersion))
                        {
                            MessageBox.Show("No Minecraft Forge Version found fitting this Modpack.", "No Version Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _log.Error("INSTALLATION: No Minecraft Forge Version found fitting the Modpack \"" + modpack.Name + "\"(" + modpack.McVersion + ")");
                            await resetModpackInstallation(modpack);
                            return;
                        }

                    _log.Info("INSTALLATION: Checking if Minecraft Forge version already installed...");

                    bool forgeInstalled = false;
                    foreach (string dir in Directory.GetDirectories(Path.Combine(Memory.minecraftLocation, "versions")))
                    {
                        string settingsFileLocation = Path.Combine(dir, Path.GetFileName(dir) + ".json");
                        if (File.Exists(settingsFileLocation))
                        {
                            using (StreamReader r = new StreamReader(settingsFileLocation))
                            {
                                dynamic versionInfo = JsonConvert.DeserializeObject(await r.ReadToEndAsync());
                                if (versionInfo["id"] == Memory.forgeSources[modpack.McVersion][1])
                                {
                                    forgeInstalled = true;
                                    break;
                                }
                            }
                        }
                    }

                    string forgeUrl = Memory.forgeSources[modpack.McVersion][0];
                    string forgeLocation = Path.GetTempFileName();
                    string forgeTarget = Path.Combine(Memory.minecraftLocation);

                    if (!forgeInstalled)
                    {
                        _log.Info("INSTALLATION: Minecraft Forge version not installed");

                        

                        await webClient.DownloadFileTaskAsync(forgeUrl, forgeLocation);
                        pgbInstallProgress.Value = 0;
                        pgbInstallProgress.Maximum = 100;

                        if (Utils.BytesToString(Utils.GetHashSha256(forgeLocation)) != Memory.forgeSources[modpack.McVersion][2])
                        {
                            _log.Error("INSTALLATION: SHA256 for Minecraft Forge not valid.");
                            MessageBox.Show("Installation Canceled:\nMinecraft Forge is not valid.", "Installation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await resetModpackInstallation(modpack);
                        }
                        else
                        {
                            _log.Info("INSTALLATION: Minecraft Forge SHA256 validated with \"" + Memory.forgeSources[modpack.McVersion][2] + "\"");
                        }

                        lblInstallStatus.Text = "Installing Minecraft Forge...";
                        _log.Info("INSTALLATION: Installing Minecraft Forge (" + Memory.forgeSources[modpack.McVersion][1] + ")...");

                        using (FileStream f = new FileStream(forgeLocation, FileMode.Open))
                        {

                            using (ZipArchive archive = new ZipArchive(f))
                            {
                                pgbInstallProgress.Maximum = archive.Entries.Count;

                                foreach (ZipArchiveEntry entry in archive.Entries)
                                {
                                    if (!entry.FullName.EndsWith("/"))
                                    {
                                        string destionationPath = Path.GetFullPath(Path.Combine(forgeTarget, entry.FullName));
                                        string destionationDirectory = Path.GetDirectoryName(destionationPath);


                                        if (destionationPath.StartsWith(forgeTarget, StringComparison.Ordinal))
                                        {
                                            if (!Directory.Exists(destionationDirectory))
                                                Directory.CreateDirectory(destionationDirectory);

                                            pgbInstallProgress.Value++;
                                            Application.DoEvents();
                                            entry.ExtractToFile(destionationPath, true);
                                        }
                                    }
                                }
                            }
                        }
                    } else
                    {
                        _log.Info("INSTALLATION: Minecraft Forge version already installed");
                    }
                    


                        string profileName = "MMI - " + modpack.Name + " (" + modpack.Version + ")";

                        _log.Info("INSTALLATION: Creating Virtual Minecraft Directory...");

                        string modpackDirectory = Path.Combine(Memory.modpacksLocation, Utils.convertIllegalPath(modpack.UID));
                        if (!Directory.Exists(modpackDirectory))
                        {
                            Directory.CreateDirectory(modpackDirectory);
                        }

                        string modpackInfoLocation = Path.Combine(modpackDirectory, "mmi_mpi.json");
                        using (StreamWriter r = new StreamWriter(modpackInfoLocation))
                        {
                            ModpackInfo modpackInfo = new ModpackInfo() {
                                InstalledOn = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                                Version = modpack.Version,
                                McVersion = modpack.McVersion,
                                VersionId = Memory.forgeSources[modpack.McVersion][1],
                                UID = modpack.UID
                            };
                            string json = JsonConvert.SerializeObject(modpackInfo, Formatting.Indented);
                            await r.WriteAsync(json);
                        }

                        string profileLocation = Path.Combine(Memory.minecraftLocation, "launcher_profiles.json");

                        _log.Info("INSTALLATION: Creating Minecraft Profile named \"" + profileName + "\"...");

                        string profileString = "";
                        using (StreamReader r = new StreamReader(profileLocation))
                        {
                            profileString = await r.ReadToEndAsync();
                        }

                        dynamic profiles = JsonConvert.DeserializeObject(profileString);
                        Dictionary<string, string> profileSettings = new Dictionary<string, string>()
                        {
                            { "gameDir", modpackDirectory },
                            { "icon", (string)otherSources["launcherIcon"] },
                            { "javaArgs", (string)otherSources["defaultJavaArgs"] },
                            { "lastUsed", DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'") },
                            { "lastVersionId", Memory.forgeSources[modpack.McVersion][1] },
                            { "name", profileName },
                            { "type", "custom" }
                        };

                        profiles.profiles[modpack.UID] = JObject.FromObject(profileSettings);

                        using (StreamWriter r = new StreamWriter(profileLocation))
                        {
                            string json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
                            await r.WriteAsync(json);
                        }

                        pgbInstallProgress.Value = 0;
                        pgbInstallProgress.Maximum = 100;


                        lblInstallStatus.Text = "Downloading Mods...";
                        _log.Info("INSTALLATION: Downloading Mods...");

                        string modsLocation = Path.GetTempFileName();

                        await webClient.DownloadFileTaskAsync(modpack.ModpackDownload, modsLocation);
                        pgbInstallProgress.Value = 0;
                        pgbInstallProgress.Maximum = 100;

                    if (Utils.BytesToString(Utils.GetHashSha256(modsLocation)) != modpack.ModpackSHA256)
                    {
                        _log.Error("INSTALLATION: SHA256 for Mods not valid.");
                        MessageBox.Show("Installation Canceled:\nMods are not valid.", "Installation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Directory.Delete(modpackDirectory, true);
                        await resetModpackInstallation(modpack);
                    }

                        lblInstallStatus.Text = "Installing Mods...";
                        _log.Info("INSTALLATION: Installing Mods...");

                        using (FileStream f = new FileStream(modsLocation, FileMode.Open))
                        {
                            using (ZipArchive archive = new ZipArchive(f))
                            {
                                pgbInstallProgress.Maximum = archive.Entries.Count;

                                foreach (ZipArchiveEntry entry in archive.Entries)
                                {
                                    if (!entry.FullName.EndsWith("/"))
                                    {
                                        string destionationPath = Path.GetFullPath(Path.Combine(modpackDirectory, entry.FullName));
                                        string destionationDirectory = Path.GetDirectoryName(destionationPath);


                                        if (destionationPath.StartsWith(modpackDirectory, StringComparison.Ordinal))
                                        {
                                            if (!Directory.Exists(destionationDirectory))
                                                Directory.CreateDirectory(destionationDirectory);

                                            pgbInstallProgress.Value++;
                                            Application.DoEvents();
                                            entry.ExtractToFile(destionationPath, true);
                                        }
                                    }
                                }
                            }
                        }

                        await Utils.PutTaskDelay(1000);
                    _log.Info("INSTALLATION: Cleaning up temp files...");
                        File.Delete(modsLocation);
                        File.Delete(forgeLocation);

                        lblInstallStatus.Text = "Modpack successfully installed!";
                        _log.Info("INSTALLATION: Modpack installed.");
                        if (update)
                            lblStatusInfo.Text = "Modpack " + modpack.Name + " successfully updated!";
                        else
                        lblStatusInfo.Text = "Modpack " + modpack.Name + " successfully installed!";

                        await resetModpackInstallation(modpack);
                    }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Error installing Modpack: " + e, "Error installing Modpack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _log.Error(e, "Error installing Modpack!");
                await resetModpackInstallation(modpack);
            }
        }

        private async Task uninstallModpack(Modpack modpack)
        {
            if (Utils.checkMinecraftRunning())
            {
                if (MessageBox.Show("Minecraft is probably running in the background. Please make sure that Minecraft is closed before continuing the installation.\nClick on Cancel to cancel the installation.", "Minecraft running", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    await resetModpackInstallation(modpack);
                    return;
                }

            }


            btnUninstall.Enabled = false;

            
            try
            {
                _log.Info("Uninstalling " + modpack.Name);

                _log.Info("UNINSTALL: Deleting Minecraft Profile...");
                string profileString = "";
                string profileLocation = Path.Combine(Memory.minecraftLocation, "launcher_profiles.json");
                using (StreamReader r = new StreamReader(profileLocation))
                {
                    profileString = await r.ReadToEndAsync();
                }

                dynamic profiles = JsonConvert.DeserializeObject(profileString);
                dynamic profilesCat = profiles.SelectToken("profiles");
                if (profilesCat[modpack.UID] != null)
                {
                    profilesCat.Property(modpack.UID).Remove();
                } else
                {
                    _log.Warn("UNINSTALL: Minecraft Profile not found. Skipping deletion of Minecraft Profile");
                }


                using (StreamWriter r = new StreamWriter(profileLocation))
                {
                    string json = JsonConvert.SerializeObject(profiles, Formatting.Indented);
                    await r.WriteAsync(json);
                }

                _log.Info("UNINSTALL: Deleting Virtual Minecraft Directory...");
                string modpackDirectory = Path.Combine(Memory.modpacksLocation, Utils.convertIllegalPath(modpack.UID));

                if (Directory.Exists(modpackDirectory))
                {
                    Directory.Delete(modpackDirectory, true);
                }

                _log.Info("UNINSTALL: Checking if Forge Version required by other Modpacks...");
                string versionId = Memory.forgeSources[modpack.McVersion][1];

                bool requiredByOtherModpack = false;
                foreach (string dir in Directory.GetDirectories(Memory.modpacksLocation))
                {
                    string settingsFileLocation = Path.Combine(dir, "mmi_mpi.json");
                    if (File.Exists(settingsFileLocation))
                    {
                        using (StreamReader r = new StreamReader(settingsFileLocation))
                        {
                            ModpackInfo modpackInfo = JsonConvert.DeserializeObject<ModpackInfo>(await r.ReadToEndAsync());
                            if (modpackInfo.VersionId == versionId)
                            {
                                requiredByOtherModpack = true;
                                break;
                            }
                        }
                    }
                }
                if (!requiredByOtherModpack)
                {
                    _log.Info("UNINSTALL: Forge Version not required by other Modpacks. Removing...");

                    string forgeDirectory = Path.Combine(Memory.minecraftLocation, "versions", Utils.convertIllegalPath(versionId));
                    if (Directory.Exists(forgeDirectory))
                    {
                        _log.Info("UNINSTALL: Forge Version Directory found. Removing now...");
                        Directory.Delete(forgeDirectory, true);
                    }
                    else
                    {
                        _log.Warn("UNINSTALL: Forge Version Directory not found. Skipping removing");
                    }

                }
                else
                {
                    _log.Info("UNINSTALL: Forge Version required by other Modpacks. Not removing");
                }

                lblInstallStatus.Text = "Modpack uninstalled!";
                _log.Info("UNINSTALL: Modpack uninstalled.");
                lblStatusInfo.Text = "Modpack " + modpack.Name + " successfully uninstalled!";
            } catch (Exception e)
            {
                _log.Error(e, "UNINSTALL: Error uninstalling Modpack");
                MessageBox.Show("Error uninstalling Modpack:\n" + e.ToString(), "Error uninstalling Modpack", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            btnUninstall.Enabled = true;
            await resetModpackInstallation(modpack);
        }

        private async void btnInstallMopack_Click(object sender, EventArgs e)
        {
            Modpack modpack = (Modpack)btnUninstall.Tag;
            if (modpack != null)
            {
                string modpackDirectory = Path.Combine(Memory.modpacksLocation, Utils.convertIllegalPath(modpack.UID));
                if (Directory.Exists(modpackDirectory))
                {
                    if (File.Exists(Memory.minecraftLauncherLocation))
                    {
                        _log.Info("Starting Minecraft Launcher...");
                        Process.Start(Memory.minecraftLauncherLocation);
                    } else
                    {
                        _log.Error("Tried starting Minecraft Launcher, but not found");
                        MessageBox.Show("Minecraft Launcher not found!", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else
                {
                    _log.Info("Started Modpack installation through install button");
                    await installModpack(modpack);
                }
                
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Modpack modpack = (Modpack)btnUninstall.Tag;
            if (modpack != null)
            {
                await installModpack(modpack, true);
            }
        }

        private DataTable modsTable = new DataTable();
        private async Task selectModpack(Modpack modpack)
        {
            // Timestamp Format: yyyy-MM-dd'T'HH:mm:ss.fff'Z'

            // Browser first, because it takes the longest
            browser.LoadHtml("<style>" + Memory.markdownStyle + "</style>" + CommonMarkConverter.Convert(modpack.Description));

            pnlInstalledVersion.Visible = false;

            pnlDetails.Visible = true;
            lblName.Text = modpack.Name;
            lblCreator.Text = modpack.Creator;
            lblLastChanged.Text = DateTime.Parse(modpack.LastChanged).ToString("MM'/'dd'/'yyyy");
            lblLastPlayed.Text = "Never";
            lblMinecraftVersion.Text = modpack.McVersion;
            //rtbDescription.Text = modpack.Description;
            
            llblSourceFile.Text = Path.GetFileName(modpack.ModpackDownload).truncateString(100, "...");
            llblSourceFile.Tag = modpack.ModpackDownload;

            lblModpackVersion.Text = modpack.Version;

            if (Memory.forgeSources.ContainsKey(modpack.McVersion))
            {
                llblForgeSource.Text = Path.GetFileName(Memory.forgeSources[modpack.McVersion][0]).truncateString(50, "...");
                llblForgeSource.Tag = Memory.forgeSources[modpack.McVersion][0];
            } else
            {
                llblForgeSource.Text = "N/A";
                llblForgeSource.Tag = null;
            }

            btnInstallMopack.Width = pnlInstall.Width - 6;
            btnUpdate.Visible = false;
            btnUninstall.Visible = false;
            btnUninstall.Tag = modpack;
            btnInstallMopack.Tag = modpack;
            btnUpdate.Tag = modpack;



            this.Text = "Matix's Mod Installer - " + modpack.Name + " (" + modpack.McVersion + ") by " + modpack.Creator;

            string profileLocation = Path.Combine(Memory.minecraftLocation, "launcher_profiles.json");
            string profileString = "";
            using (StreamReader r = new StreamReader(profileLocation))
            {
                profileString = await r.ReadToEndAsync();
            }


            try
            {
                if (installing == true && installingUID == modpack.UID)
                {
                    pnlInstall.Height = 103;
                    pgbInstallProgress.Visible = true;
                    lblInstallStatus.Visible = true;
                    btnInstallMopack.Text = "Installing...";
                    btnInstallMopack.Enabled = false;
                }
                else
                {
                    pnlInstall.Height = 56;
                    pgbInstallProgress.Visible = false;
                    lblInstallStatus.Visible = false;


                    string modpackDirectory = Path.Combine(Memory.modpacksLocation, Utils.convertIllegalPath(modpack.UID));
                    if (Directory.Exists(modpackDirectory))
                    {
                        btnInstallMopack.Text = "Start Minecraft";
                        if (Memory.launcherFound)
                        {
                            btnInstallMopack.Enabled = true;
                        }
                        else
                        {
                            btnInstallMopack.Enabled = false;
                        }

                        btnUninstall.Visible = true;

                        if (File.Exists(Path.Combine(modpackDirectory, "mmi_mpi.json")))
                        {
                            using (StreamReader r = new StreamReader(Path.Combine(modpackDirectory, "mmi_mpi.json")))
                            {
                                ModpackInfo modpackInfo = JsonConvert.DeserializeObject<ModpackInfo>(await r.ReadToEndAsync());
                                lblForgeInstallation.Text = modpackInfo.VersionId;

                                lblInstalledVersion.Text = modpackInfo.Version;
                                pnlInstalledVersion.Visible = true;

                                if (modpackInfo.Version != modpack.Version)
                                {
                                    btnInstallMopack.Width = pnlInstall.Width - btnUpdate.Width - btnUninstall.Width - 29;
                                    btnUpdate.Visible = true;
                                }
                                else
                                {
                                    btnInstallMopack.Width = pnlInstall.Width - btnUninstall.Width - 16;
                                    btnUpdate.Visible = false;
                                }
                            }
                        } else
                        {
                            _log.Warn("Local Modpack Information is missing.");
                            MessageBox.Show("Seems like some of the local Modpack informations are missing. Updating the Modpack to fix this issue.", "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            await installModpack(modpack);
                            return;
                        }


                        try
                        {
                            dynamic profiles = JsonConvert.DeserializeObject(profileString);
                            DateTime lastPlayed = profiles.profiles[modpack.UID].lastUsed;
                            lblLastPlayed.Text = PrettyTime.GetPrettyElapsedTime(lastPlayed);
                        } catch (Exception e)
                        {
                            _log.Info("Launcher profiles not containing selected modpack (\"" + modpack.UID + "\")");
                            _log.Debug(e);
                        }


                    }
                    else
                    {
                        if (installing == false)
                        {
                            btnInstallMopack.Text = "Download and Install";
                            btnInstallMopack.Width = pnlInstall.Width - 6;
                            btnInstallMopack.Enabled = true;
                        }
                        else
                        {
                            if (installingUID != modpack.UID)
                            {
                                btnInstallMopack.Text = "Installing other Modpack";
                                btnInstallMopack.Enabled = false;
                            }

                        }

                    }
                }


                pcbIcon.Image = Properties.Resources.loading;
                if (Utils.validateURL(modpack.Icon))
                    pcbIcon.Image = await Utils.loadBitmapFromUrl(modpack.Icon);
                else
                    pcbIcon.Image = Utils.emptyBitmap();

            } catch (Exception e)
            {
                _log.Error("Error: Could not load Modpack details.");
                if (Directory.Exists(Path.Combine(Memory.modpacksLocation, Utils.convertIllegalPath(modpack.UID))))
                {
                    _log.Info(e, "Error: Uninstalling Modpack to fix bug.");
                    DialogResult uninstall = MessageBox.Show("Could not load Modpack details. Should the Modpack be uninstalled to fix this issue?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (uninstall == DialogResult.OK)
                    {
                        await uninstallModpack(modpack);
                        return;
                    }
                    else
                    pnlDetails.Visible = false;
                }
            }

            modsTable = Utils.createDataTable(modpack.Mods);

            modsTable.Columns.Add("WebsiteShort");
            modsTable.Columns.Add("WebsiteShortArea", typeof(LinkArea));

            foreach (DataRow row in modsTable.Rows)
            {
                row.SetField("WebsiteShort", row.Field<string>("Website").truncateString(50, "..."));
                LinkArea linkArea = new LinkArea(0, row.Field<string>("Website").truncateString(50, "...").Length);
                row.SetField("WebsiteShortArea", linkArea);
            }

            modName.DataBindings.Clear();
            modWebsite.DataBindings.Clear();
            modVersion.DataBindings.Clear();

            modName.DataBindings.Add("Text", modsTable, "Name");
            modVersion.DataBindings.Add("Text", modsTable, "Version");
            modWebsite.DataBindings.Add("Text", modsTable, "WebsiteShort");
            modWebsite.DataBindings.Add("Tag", modsTable, "Website");
            modWebsite.DataBindings.Add("LinkArea", modsTable, "WebsiteShortArea");

            drMods.DataSource = modsTable;


        }

        private async void lvModpacks_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvModpacks.SelectedItems.Count > 0)
            {
                Modpack modpack = (Modpack)lvModpacks.SelectedItems[0].Tag;
                await selectModpack(modpack);
            } else
            {
                this.Text = "Matix's Mod Installer";
                pnlDetails.Visible = false;
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await saveSettings();
        }

        private void btnStartMinecraftLauncher_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStartMinecraftLauncher_Click_1(object sender, EventArgs e)
        {
            if (File.Exists(Memory.minecraftLauncherLocation))
            {
                Process.Start(Memory.minecraftLauncherLocation);
            }
            else
            {
                _log.Error("Tried to start Minecraft Launcher, but Launcher not found.");
                MessageBox.Show("Minecraft Launcher not found!", "Launcher not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Splash splash = new Splash();
            splash.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(1000);
            Application.DoEvents();

            _log.Info("Registering URL Schema...");
            Utils.RegisterUriScheme();

            Application.DoEvents();
            splash.loadSettings();
            Application.DoEvents();


            _log.Info("Initializing browser...");
            browser = new ChromiumWebBrowser("", null);
            browser.MenuHandler = new Utilities.CefSharp.CustomMenuHandler();

            browser.LoadHtml("<h1>Loading...</h1>");
            tpOverview.Controls.Add(browser);
            browser.Refresh();

            while (browser.IsLoading)
            {
                Application.DoEvents();
            }

            System.Threading.Thread.Sleep(1000);
            splash.Close();

            btnStartMinecraftLauncher.Enabled = Memory.launcherFound;
            this.Location = Memory.mainFormLocation;
            this.Size = Memory.mainFormSize;
            this.WindowState = Memory.mainFormState;

            loadComplete = true;
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = (string)(sender as Controls.LinkLabelWT).Tag;

            Process.Start(url);
        }


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;

            int selectedIndex = -1;
            if (lvModpacks.SelectedItems.Count > 0)
                selectedIndex = lvModpacks.SelectedItems[0].Index;
            await loadModpacks();
            if (selectedIndex != -1)
                lvModpacks.Items[selectedIndex].Selected = true;
            btnRefresh.Enabled = true;
        }

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            Modpack modpack = (Modpack)btnUninstall.Tag;
            if (modpack != null)
            {
                await uninstallModpack(modpack);
            }
        }

        private void lvModpacks_SizeChanged(object sender, EventArgs e)
        {
            int columnWidth = lvModpacks.Width -1;
            if (Utils.GetVisibleScrollbars(lvModpacks) == ScrollBars.Vertical || Utils.GetVisibleScrollbars(lvModpacks) == ScrollBars.Both)
            {
                columnWidth = lvModpacks.Width - SystemInformation.VerticalScrollBarWidth -1;
            }
             
            lvModpacks.Columns[0].Width = columnWidth;
        }

        public void searchModpacks(string search)
        {
            Memory.searchHistory.Add(search);
            AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
            ac.AddRange(Memory.searchHistory.ToArray());
            tbSearch.AutoCompleteCustomSource = ac;
            ListViewItem foundItem = lvModpacks.FindItemWithText(search, false, 0, true);
            if (foundItem != null)
            {
                _log.Info("Search result for \"" + foundItem.Text + "\"");
                lvModpacks.TopItem = foundItem;
                foundItem.EnsureVisible();
                foundItem.Selected = true;
                foundItem.Focused = true;
                lvModpacks.Focus();
            } else
            {
                _log.Info("Search not successfully");
            }

        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                searchModpacks(tbSearch.Text);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchModpacks(tbSearch.Text);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            using (Options dialog = new Options())
            {
                dialog.ShowDialog();
            }
        }

        private void modWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((string)((LinkLabel)sender).Tag);
        }

        private void llblForgeSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llblForgeSource.Tag != null)
                Process.Start((string)llblForgeSource.Tag);
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
            Forms.About dialog = new Forms.About();

            dialog.ShowDialog();

            dialog.Dispose();
        }

        private void lblVersion_MouseEnter(object sender, EventArgs e)
        {
            lblVersion.BackColor = ColorTranslator.FromHtml("#CACECE");
        }

        private void lblVersion_MouseLeave(object sender, EventArgs e)
        {
            lblVersion.BackColor = ColorTranslator.FromHtml("#E1E5E6");
        }
    }
}

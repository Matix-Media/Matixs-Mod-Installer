using NLog;
using Shell32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matixs_Mod_Installer
{


   public static class Utils
    {
        private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

        public static DialogResult ShowInputDialog(ref string input, string title = "Enter Text", int width = 200)
        {
            System.Drawing.Size size = new System.Drawing.Size(width, 90);
            Form inputBox = new Form();

            inputBox.BackColor = Color.White;
            inputBox.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            inputBox.MaximizeBox = false;
            inputBox.MinimizeBox = false;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 16, 23);
            textBox.Location = new System.Drawing.Point(8, 8);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);
            inputBox.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(236, 240, 241);
            panel.Dock = DockStyle.Bottom;
            panel.Height = 47;

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(87, 27);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 96, 10);
            okButton.FlatAppearance.BorderSize = 1;
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.BackColor = Color.FromArgb(236, 240, 241);
            okButton.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            panel.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(87, 27);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 190, 10);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.BackColor = Color.FromArgb(236, 240, 241);
            cancelButton.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            panel.Controls.Add(cancelButton);

            inputBox.Controls.Add(panel);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }


        public static bool validateURL(string URL)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(URL, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        public async static Task<Bitmap> loadBitmapFromUrl(string URL)
        {
            if (Memory.imageCache.ContainsKey(URL))
            {
                return Memory.imageCache[URL];
            } else
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(URL);
                System.Net.WebResponse response = await request.GetResponseAsync();
                System.IO.Stream responseStream = response.GetResponseStream();
                Bitmap responseImg = new Bitmap(responseStream);

                if (!Memory.imageCache.ContainsKey(URL))
                {
                    if (Memory.imageCache.Count > 19)
                    {
                        Memory.imageCache.Remove(Memory.imageCache.First().Key);
                    }
                    Memory.imageCache.Add(URL, responseImg);
                    return responseImg;
                } else
                {
                    return Memory.imageCache[URL];
                }
                
                
            }
            
        }

        public static Bitmap emptyBitmap()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.Clear(Color.FromKnownColor(KnownColor.Window));
            }
            return bmp;
        }

        public static void initLogger()
        {
            var layout = "${longdate}|${level:uppercase=true}|${logger}| ${message}";
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = Memory.logLocation };
            logfile.Layout = layout;
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            logconsole.Layout = layout;

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        public static string truncateString(this string value, int maxLength, string signal)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + signal;
        }

        public static async Task PutTaskDelay(int Miliesconds)
        {
            await Task.Delay(Miliesconds);
        }

        public static string convertIllegalPath(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            path = r.Replace(path, "");

            return path;
        }

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }

        public static byte[] GetHashSha256(string filename)
        {
            using (SHA256 Sha256 = SHA256.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    return Sha256.ComputeHash(stream);
                }
            }
            
        }

        public static ScrollBars GetVisibleScrollbars(Control ctl)
        {
            int wndStyle = Win32.GetWindowLong(ctl.Handle, Win32.GWL_STYLE);
            bool hsVisible = (wndStyle & Win32.WS_HSCROLL) != 0;
            bool vsVisible = (wndStyle & Win32.WS_VSCROLL) != 0;

            if (hsVisible)
                return vsVisible ? ScrollBars.Both : ScrollBars.Horizontal;
            else
                return vsVisible ? ScrollBars.Vertical : ScrollBars.None;
        }

        public static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            try
            {
                if (folderItem != null)
                {
                    Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                    return link.Path;
                }
            } catch (Exception e)
            {
                _log.Error("Could not get the Target file of Shortcut: " + e.ToString());
                return string.Empty;
            }
            

            return string.Empty;
        }

        public static bool checkMinecraftRunning()
        {
            ManagementClass localAll = new ManagementClass("Win32_Process");
            foreach(ManagementObject proc in localAll.GetInstances())
            {
                if ((string)proc["Name"] == "javaw.exe" && ((string)proc["CommandLine"]).Contains(".minecraft"))
                {
                    _log.Info("Minecraft probably running.");
                    return true;
                }
            }
            _log.Info("Minecraft not running.");
            return false;
        }

    }
}

using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            System.Drawing.Size size = new System.Drawing.Size(width, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            inputBox.MaximizeBox = false;
            inputBox.MinimizeBox = false;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

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
    }
}

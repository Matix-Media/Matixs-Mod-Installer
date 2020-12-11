using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutoUpdate
{
	static class Updater
	{

		private static readonly NLog.Logger _log = NLog.LogManager.GetCurrentClassLogger();

		static readonly Lazy<IDictionary<Version, Uri>> _lazyVersionUrls =
			new Lazy<IDictionary<Version, Uri>>(() => _GetVersionUrls());

		public static bool AutoUpdate(string[] args)
		{
			if (HasUpdate)
			{
				Update(args);
				return true;
			}
			else
			{
				// delete the updater files. We scan the resources so we know what they are
				var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
				for (var i = 0; i < names.Length; i++)
				{
					var name = names[i];
					_log.Info("Asset Name: " + name);
					if (name.Contains(".ZZupdater0.") || name.Contains(".Matix.Controls.Progressbar."))
					{
						try
						{
							File.Delete(name.Substring(name.IndexOf('.') + 1));
						}
						catch { }
					}
				}
			}
			return false;
		}
		static IDictionary<Version, Uri> _VersionUrls
		{
			get
			{
				
				return _lazyVersionUrls.Value;
			}
		}
		public static string GitHubRepo { get; set; }
		public static string GitHubRepoName
		{
			get
			{
				var si = GitHubRepo.LastIndexOf('/');
				return GitHubRepo.Substring(si + 1);
			}
		}
		static IDictionary<Version, Uri> _GetVersionUrls()
		{

			string pattern =
					string.Concat(
						Regex.Escape(GitHubRepo),
						@"\/releases\/download\/v[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+.*\.zip");

			Regex urlMatcher = new Regex(pattern, RegexOptions.CultureInvariant | RegexOptions.Compiled);
			var result = new Dictionary<Version, Uri>();
			WebRequest wrq = WebRequest.Create(string.Concat("https://github.com", GitHubRepo, "/releases/latest"));
			WebResponse wrs = null;
			try
			{
				wrs = wrq.GetResponse();
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error fetching repo: " + ex.Message);
				return result;
			}
			using (var sr = new StreamReader(wrs.GetResponseStream()))
			{
				string line;
				while (null != (line = sr.ReadLine()))
				{
					var match = urlMatcher.Match(line);
					if (match.Success)
					{
						var uri = new Uri(string.Concat("https://github.com", match.Value));
						var vs = match.Value.LastIndexOf("/v");
						var sa = match.Value.Substring(vs + 2).Split('.', '/');
						var v = new Version(int.Parse(sa[0]), int.Parse(sa[1]), int.Parse(sa[2]), int.Parse(sa[3]));
						result.Add(v, uri);
					}
				}
			}
			return result;
		}
		public static bool HasUpdate
		{
			get
			{
				var v = Assembly.GetEntryAssembly().GetName().Version;
				foreach (var e in _VersionUrls)
					if (e.Key > v)
						return true;
				return false;
			}
		}

		public static bool ForceUpdate = false;

		public static Version LatestVersion
		{
			get
			{
				var v = Assembly.GetEntryAssembly().GetName().Version;
				var va = new List<Version>(_VersionUrls.Keys);
				if (!ForceUpdate) va.Add(v);
				va.Sort();
				_log.Debug("Latest Version: " + va[va.Count - 1]);
				return va[va.Count - 1];
			}
		}
		public static void Update(string[] args = null)
			=> Update(LatestVersion, args);
		public static void Update(Version version, string[] args = null)
		{
			var ns = typeof(Updater).Namespace;
			var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
			string exename = null;
			for (var i = 0; i < names.Length; i++)
			{
				var name = names[i];

				_log.Info("Asset Name: " + name);
				if (name.Contains(".ZZupdater0.") || name.Contains(".Matix.Controls.Progressbar."))
				{
					var respath = name;
					if (string.IsNullOrEmpty(exename) && name.EndsWith(".exe"))
						exename = name.Substring(name.IndexOf('.') + 1);
					name = name.Substring(name.IndexOf('.') + 1);
					using (var stm = Assembly.GetExecutingAssembly().GetManifestResourceStream(respath))
					using (var stm2 = File.OpenWrite(name))
					{
						stm2.SetLength(0L);
						stm.CopyTo(stm2);
					}


				}
			}
			if (null != exename)
			{
				var psi = new ProcessStartInfo();
				var sb = new StringBuilder();
				sb.Append(_Esc(Assembly.GetEntryAssembly().GetModules()[0].Name));
				sb.Append(' ');
				sb.Append(_Esc(_VersionUrls[version].ToString()));
				if (null != args)
				{
					for (var i = 0; i < args.Length; ++i)
					{
						sb.Append(' ');
						sb.Append(_Esc(args[i]));
					}
				}
				psi.Arguments = sb.ToString();
				psi.FileName = exename;
				psi.Verb = "runas";
				try
                {
					var proc = Process.Start(psi);
				} catch (Exception e)
                {
					_log.Fatal("Could not Launch auto updater: " + e.ToString());
					MessageBox.Show("Could not Launch auto updater. \nPlease restart the program and try updating again. If that does not help, Please consider updating manually.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

				Environment.Exit(0);
			}

		}
		static string _Esc(string arg)
		{
			return string.Concat("\"", arg.Replace("\"", "\"\""), "\"");
		}
	}
}

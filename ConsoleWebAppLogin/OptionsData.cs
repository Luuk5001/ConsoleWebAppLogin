using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace ConsoleWebAppLogin
{
	/// <summary>
	/// Datmodel waarin data uit alle CMD parameters opgeslagen kan worden
	/// </summary>
    public class OptionsData
    {
        public string AppName { get; set; }
		public Uri Url { get; set; }
		public string Username { get; set; }
		private SecureString password;
		public string Password
		{
			get
			{
				return ToUnsecureString(password);
			}
			set
			{
				password = ToSecureString(value);
			}
		}
		public string UserFieldName { get; set; }
		public string PasswordFieldName { get; set; }
		public Icon Icon { get; set; }
		public bool PreserveCache { get; set; }

        public OptionsData(string appName, string url, string username, string password,
            string userFieldName, string passwordFieldName, string iconPath, bool preserveCache)
        {
            AppName = appName;
			Url = GetURL(url);
            Username = username;
            this.password = ToSecureString(password);
            UserFieldName = userFieldName;
            PasswordFieldName = passwordFieldName;
			Icon = GetIcon(iconPath);
			PreserveCache = preserveCache;
        }

		/// <summary>
		/// Convert plain password to secure string
		/// </summary>
		/// <param name="unsecureString">Plain password</param>
		/// <returns>SecureString password</returns>
		private SecureString ToSecureString(string unsecureString)
		{
			SecureString secureString = new SecureString();
			foreach (char c in unsecureString)
			{
				secureString.AppendChar(c);
			}
			return secureString;
		}

		/// <summary>
		/// Convert SecureString password to plain password
		/// </summary>
		/// <param name="secureString">SecureString password</param>
		/// <returns>Plain password</returns>
		private string ToUnsecureString(SecureString secureString)
		{
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
				return Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}
		}

		/// <summary>
		/// Get Icon var from given path
		/// </summary>
		/// <param name="path">Path to icon file</param>
		/// <returns></returns>
		private Icon GetIcon(string path)
		{
			try
			{
				if (path == "")
				{
					return null;
				}
				else if (Path.GetExtension(path) == ".ico")
				{
					Icon icon = Icon.ExtractAssociatedIcon(path);
					return icon;
				}
				throw new ArgumentOutOfRangeException("Fout: gebruik A.u.b. een .ico bestand voor het icoontje");
			}
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException("Fout: kan het icoon bestand niet vinden op het opgegeven pad");
			}
		}

		/// <summary>
		/// Convert and verify the given url
		/// </summary>
		/// <param name="url">String containing a url</param>
		/// <returns>Uri converted from string</returns>
		private static Uri GetURL(string url)
		{
			try
			{
				Uri URL = new Uri(url);
				return URL;
			}
			catch (UriFormatException)
			{
				throw new UriFormatException("Fout: ongeldige url, gebruik altijd http(s)");
			}
		}
	}
}

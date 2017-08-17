using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace ConsoleWebAppLogin
{
	/// <summary>
	/// Datmodel waarin data uit alle CMD parameters opgeslagen kan worden
	/// </summary>
    public class DataModel
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
		public bool ClearCache { get; set; } = true;

        public DataModel(string appName, Uri url, string username, string password,
            string userFieldName, string passwordFieldName)
        {
            AppName = appName;
            Url = url;
            Username = username;
            this.password = ToSecureString(password);
            UserFieldName = userFieldName;
            PasswordFieldName = passwordFieldName;
        }

		/// <summary>
		/// Zet een normale string om naar een "SecureString"
		/// </summary>
		/// <param name="unsecureString">Waarde van de noramle string</param>
		/// <returns>Een "SecureString"</returns>
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
		/// Zet een "SecureString" om naar een normale string
		/// </summary>
		/// <param name="secureString">De "SecureString" die teruggezet moet worden</param>
		/// <returns>Een normale string</returns>
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
	}
}

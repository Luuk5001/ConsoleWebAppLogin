using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

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
		public SecureString Password { get; set; }
		public string UserFieldName { get; set; }
		public string PasswordFieldName { get; set; }
		public Icon Icon { get; set; }
		public bool ClearCache { get; set; } = true;

        public DataModel(string appName, Uri url, string username, SecureString password,
            string userFieldName, string passwordFieldName)
        {
            AppName = appName;
            Url = url;
            Username = username;
            Password = password;
            UserFieldName = userFieldName;
            PasswordFieldName = passwordFieldName;
        }
    }
}

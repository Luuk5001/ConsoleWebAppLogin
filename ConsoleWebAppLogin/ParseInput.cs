using System;
using System.Drawing;
using System.IO;
using System.Security;
using System.Reflection;

namespace ConsoleWebAppLogin
{
	public static class ParseInput
	{
		private static CommandLineOptions options;

		public static DataModel Parse(CommandLineOptions options)
		{
			ParseInput.options = options;
			DataModel data = new DataModel(options.Name, GetURL(), options.Username, options.Password, options.UsernameFieldName, options.PasswordFieldName);
			if (options.IconPath != null)
			{
				data.Icon = GetIcon();
			}
			else
			{
				data.Icon = new Icon(Program.EmbeddedResources.AppIcon);
			}
			if (options.PreserveCache)
			{
				data.ClearCache = false;
			}
			return data;
		}

		private static Uri GetURL()
		{
			try
			{
				Uri URL = new Uri(options.URL);
				return URL;
			}
			catch(UriFormatException)
			{
				throw new UriFormatException("Fout: ongeldige url, gebruik altijd http(s)");
			}
		}

		private static Icon GetIcon()
		{
			try
			{
				if (Path.GetExtension(options.IconPath) == ".ico")
				{
					Icon icon = Icon.ExtractAssociatedIcon(options.IconPath);
					return icon;
				}
				throw new ArgumentOutOfRangeException("Fout: gebruik A.u.b. een .ico bestand voor het icoontje");
			}
			catch (FileNotFoundException)
			{
				throw new FileNotFoundException("Fout: kan het icoon bestand niet vinden op het opgegeven pad");
			}
		}
	}
}

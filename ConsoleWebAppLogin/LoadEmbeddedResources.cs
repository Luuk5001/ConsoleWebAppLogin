using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ConsoleWebAppLogin
{
	class LoadEmbeddedResources
	{
		Assembly assembly;
		public Stream AppIcon { get; }
		public Stream InfoIcon { get; }
		public Stream BackIcon { get; }
		public Stream NextIcon { get; }
		public Stream ListIcon { get; }
		public Stream PrintIcon { get; }

		public LoadEmbeddedResources()
		{
			assembly = Assembly.GetExecutingAssembly();
			try
			{
				AppIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.icon.ico");
				InfoIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.info.png");
				BackIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.back.png");
				NextIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.next.png");
				ListIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.list.png");
				PrintIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.print.png");
			}
			catch
			{
				AppIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.icon.ico");
				InfoIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.info.png");
				BackIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.back.png");
				NextIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.next.png");
				ListIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.list.png");
				PrintIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.print.png");
			}
		}
	}
}

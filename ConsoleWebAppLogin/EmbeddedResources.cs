using System.IO;
using System.Reflection;

namespace ConsoleWebAppLogin
{
	public class EmbeddedResources
	{
		Assembly assembly;
		public Stream AppIcon { get; }
		public Stream InfoIcon { get; }
		public Stream BackIcon { get; }
		public Stream NextIcon { get; }
		public Stream ListIcon { get; }
		public Stream PrintIcon { get; }

		public EmbeddedResources()
		{
			assembly = Assembly.GetExecutingAssembly();
			try
			{
				AppIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.icon.ico");
				InfoIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.info.png");
				BackIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.back.png");
				NextIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.next.png");
				ListIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.list.png");
				PrintIcon = assembly.GetManifestResourceStream("ConsoleWebAppLogin.Images.print.png");
			}
			catch
			{
			}
		}
	}
}

using CommandLine;
using CommandLine.Text;

namespace ConsoleWebAppLogin
{
	public class CommandLineOptions
	{
		[Option('n', Required = true,
		HelpText = "Naam van de web applicatie.")]
		public string Name { get; set; }

		[Option('l', Required = true,
		HelpText = "URL van de inlogpagina.")]
		public string URL { get; set; }

		[Option("off", Required = false,
		HelpText = "Auto login uitzetten")]
		public bool AutoLoginOff { get; set; }

		[Option('u', Required = false,
		HelpText = "Gebruikersnaam")]
		public string Username { get; set; }

		[Option('p', Required = false,
		HelpText = "Wachtwoord")]
		public string Password { get; set; }

		[Option('a', Required = false,
		HelpText = "Gebruikersnaam text input ID HOOFDLETTERGEVOELIG")]
		public string UsernameFieldName { get; set; }

		[Option('b', Required = false,
		HelpText = "Wachtwoord text input ID HOOFDLETTERGEVOELIG")]
		public string PasswordFieldName { get; set; }

		[Option('i', Required = false,
		HelpText = "Pad naar applicatie icoontje, moet een .ico bestand zijn.")]
		public string IconPath { get; set; }

		[Option('c',
		HelpText = "Cache behouden na afsluiten.")]
		public bool PreserveCache { get; set; }

		[ParserState]
		public IParserState LastParserState { get; set; }

		[HelpOption]
		public string GetUsage()
		{
			return HelpText.AutoBuild(this,
			  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
		}
	}
}

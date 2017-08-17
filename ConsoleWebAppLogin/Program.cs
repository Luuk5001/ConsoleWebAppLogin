using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using CommandLine;
using System.Security;
using System.Drawing;

namespace ConsoleWebAppLogin
{
    static class Program
    {		
		//Variabelen worden gebruikt voor het Hiden van het console scherm
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		//Embedded
		public static LoadEmbeddedResources EmbeddedResources = new LoadEmbeddedResources();
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			CommandLineOptions options = new CommandLineOptions();
			if (Parser.Default.ParseArguments(args, options))
			{
				AppDomain.CurrentDomain.UnhandledException += AllUnhandledExceptions;
				//Hide console scherm
				IntPtr handle = GetConsoleWindow();
				//Het applicatie ID instellen om te voorkomen dat verschillende web apps 
				//in de taakbalk worden "gestapeld".
				TaskbarManager.Instance.ApplicationId = options.Name;
				//Start de Browser
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				try
				{
					ShowWindow(handle, SW_HIDE);
					Application.Run(new Browser(ParseInput.Parse(options)));
				}
				catch(Exception e)
				{
					ShowWindow(handle, SW_SHOW);
					Console.WriteLine(e.Message);
				}
			}
		}

		private static void AllUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
		{
			var ex = (Exception)e.ExceptionObject;
			Environment.Exit(Marshal.GetHRForException(ex));
		}
	}
}

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ConsoleWebAppLogin.JS;

namespace ConsoleWebAppLogin
{
    public partial class Browser : Form
    {
		private readonly ChromiumWebBrowser browser;
		private OptionsData data;
		private bool attemtedLogin = false;
		private FindElement findElement;
		private string cachePath;
		private int searchElementsCounter = 0;
		private EmbeddedResources resources;

		public Browser(OptionsData data, EmbeddedResources resources)
        {
            InitializeComponent();
			//Set global variables
			this.resources = resources;
			this.data = data;
			//Create events
			Application.ApplicationExit += OnApplicationExit;
			browser.FrameLoadEnd += OnFrameLoadEnd;
			browser.FrameLoadStart += OnFrameLoadStart;
			browser.LoadError += OnLoadError;
			//Form settings
			Text = data.AppName;
			WindowState = FormWindowState.Maximized;
			LoadIcons();
			//Browser settings
			CefSettings();
			//Start browser
			browser = new ChromiumWebBrowser(data.Url.OriginalString)
			{
				Dock = DockStyle.Fill,
			};
			showStatusIcon.Controls.Add(browser);
			//Register bound JS objects
			RegisterJsObjects();
		}

		/// <summary>
		/// Load icons into form.
		/// </summary>
		private void LoadIcons()
		{
			prevPageButton.Image = Image.FromStream(resources.BackIcon);
			nextPageButton.Image = Image.FromStream(resources.NextIcon);
			infoButton.Image = Image.FromStream(resources.InfoIcon);
			showMessagesButton.Image = Image.FromStream(resources.ListIcon);
			printButton.Image = Image.FromStream(resources.PrintIcon);
			if (data.Icon == null)
			{
				Icon = new Icon(resources.AppIcon);
			}
			else
			{
				Icon = data.Icon;
			}
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			//Close Cef and clear cache if this is PreserverCache is set to false
			Cef.Shutdown();
			if (!data.PreserveCache)
			{
				Directory.Delete(cachePath, true);
			}
		}

		private void CefSettings()
		{
			string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CWALogin");
			string sessionPath = Path.Combine(appPath, data.AppName);
			Directory.CreateDirectory(sessionPath);
			CefSettings settings = new CefSettings()
			{
				CachePath = sessionPath
			};
			Cef.Initialize(settings);
			cachePath = sessionPath;
		}

		private void OnLoadError(object sender, LoadErrorEventArgs e)
		{
			messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "LOAD ERROR\r\nCODE:" + e.ErrorCode + "\r\nTEXT: " + e.ErrorText + "\r\nURL: " + e.FailedUrl + "\r\n"));
		}

		private void OnFrameLoadStart(object sender, FrameLoadStartEventArgs e)
		{
			currentAdress.Text = e.Url;
		}

		private void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
		{
			if (searchElementsCounter >= 5)
			{
				attemtedLogin = true;
				messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Gestopt met zoeken naar inlogvelden."));
			}
			if (!attemtedLogin)
			{
				if (FindElements())
				{
					FillInForm();
				}
				else
				{
					searchElementsCounter++;
				}
			}
		}

		private bool FindElements()
		{
			bool elementsFound = true;
			bool userNameFieldFound = findElement.Find(data.UserFieldName);
			bool passwordFieldFound = findElement.Find(data.PasswordFieldName);
			if (!userNameFieldFound)
			{
				messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Gebruiksernaam veld (ID:" + data.UserFieldName + ") niet gevonden op deze pagina.\r\n"));
				elementsFound = false;
			}
			if (!passwordFieldFound)
			{
				messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Wachtwoord veld (ID:" + data.PasswordFieldName + ") niet gevonden op deze pagina.\r\n"));
				elementsFound = false;
			}
			return elementsFound;
		}

		private void FillInForm()
		{
			messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Velden worden ingevuld.\r\n"));
			string javascript = String.Format(@"
					var form = document.getElementById('{3}').form;
					document.getElementById('{2}').value='{0}';
					document.getElementById('{3}').value='{1}';
					form.submit();",
			data.Username, data.Password, 
			data.UserFieldName, data.PasswordFieldName);
			browser.ExecuteScriptAsync(javascript);
			javascript = "";
			attemtedLogin = true;
			messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Inlogpoging gedaan.\r\n"));
		}

		private void RegisterJsObjects()
		{
			findElement = new FindElement(browser);
			browser.RegisterJsObject("dedf7b4186af42c3882bcd42f4639a5a", findElement);
		}

		private void PrevPageButton_Click(object sender, EventArgs e)
		{
			browser.Back();
		}

		private void NextPageButton_Click(object sender, EventArgs e)
		{
			browser.Forward();
		}

		private void InfoButton_Click(object sender, EventArgs e)
		{
			Info infoForm = new Info();
			infoForm.Show();
		}

		private void ShowMessagesButton_Click(object sender, EventArgs e)
		{
			if (messagePanel.Visible)
			{
				messagePanel.Visible = false;
			}
			else
			{
				messagePanel.Visible = true;
			}
		}

		private void PrintButton_Click(object sender, EventArgs e)
		{
			browser.Print();
		}
	}
}

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
		public DataModel Data { get; }
		private bool attemtedLogin = false;
		private FindElement findElement;
		private string cachePath;
		private int searchElementsCounter = 0;

		public Browser(DataModel data)
        {
            InitializeComponent();
			Data = data;
			CefSettings();
			Application.ApplicationExit += OnApplicationExit;
			Text = data.AppName;
			Icon = data.Icon;
			prevPageButton.Image = Image.FromStream(Program.EmbeddedResources.BackIcon);
			nextPageButton.Image = Image.FromStream(Program.EmbeddedResources.NextIcon);
			infoButton.Image = Image.FromStream(Program.EmbeddedResources.InfoIcon);
			showMessagesButton.Image = Image.FromStream(Program.EmbeddedResources.ListIcon);
			printButton.Image = Image.FromStream(Program.EmbeddedResources.PrintIcon);
			WindowState = FormWindowState.Maximized;
			browser = new ChromiumWebBrowser(data.Url.OriginalString)
			{
				Dock = DockStyle.Fill,
			};
			showStatusIcon.Controls.Add(browser);
			browser.FrameLoadEnd += OnFrameLoadEnd;
			browser.FrameLoadStart += OnFrameLoadStart;
			browser.LoadError += OnLoadError;
			RegisterJsObjects();
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			Cef.Shutdown();
			if (Data.ClearCache)
			{
				Directory.Delete(cachePath, true);
			}
		}

		private void CefSettings()
		{
			string appPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CWALogin");
			string sessionPath = Path.Combine(appPath, Data.AppName);
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
			bool userNameFieldFound = findElement.Find(Data.UserFieldName);
			bool passwordFieldFound = findElement.Find(Data.PasswordFieldName);
			if (!userNameFieldFound)
			{
				messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Gebruiksernaam veld (ID:" + Data.UserFieldName + ") niet gevonden op deze pagina.\r\n"));
				elementsFound = false;
			}
			if (!passwordFieldFound)
			{
				messageTextBox.Invoke((MethodInvoker)(() => messageTextBox.Text += "Wachtwoord veld (ID:" + Data.PasswordFieldName + ") niet gevonden op deze pagina.\r\n"));
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
			Data.Username, Data.Password, 
			Data.UserFieldName, Data.PasswordFieldName);
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

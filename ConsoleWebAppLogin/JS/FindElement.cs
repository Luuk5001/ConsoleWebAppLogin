using System;
using System.Threading;
using CefSharp;
using CefSharp.WinForms;

namespace ConsoleWebAppLogin.JS
{
	class FindElement
	{
		ChromiumWebBrowser browser;
		bool elementFound;
		bool scriptExecuted;

		public FindElement(ChromiumWebBrowser browser)
		{
			this.browser = browser;
		}

		public bool Find(string ID)
		{
			try
			{
				scriptExecuted = false;
				string javascript = String.Format(@"
				var element = document.getElementById('{0}')
				if(element == null)
				{{ 
					dedf7b4186af42c3882bcd42f4639a5a.result(false);
				}}
				else	
				{{
					element.style.border = 'thick solid #00FF00'
					dedf7b4186af42c3882bcd42f4639a5a.result(true);
				}}
				", ID);
				browser.ExecuteScriptAsync(javascript);
				while (!scriptExecuted)
				{
					Thread.Sleep(100);
					continue;
				}
				return elementFound;
			}
			catch
			{
				return false;
			}
		}

		public void Result(bool detected)
		{
			elementFound = detected;
			scriptExecuted = true;
		}
	}
}

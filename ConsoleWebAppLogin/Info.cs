using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleWebAppLogin
{
	public partial class Info : Form
	{
		public Info()
		{
			InitializeComponent();
		}

		private void llblIconsLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.flaticon.com/authors/dave-gandy");
		}

		private void Info_Load(object sender, System.EventArgs e)
		{
			lblCWALoginTitle.Select();
		}
	}
}

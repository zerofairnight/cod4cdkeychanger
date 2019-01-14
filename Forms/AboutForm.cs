using System.Text;
using System.Windows.Forms;

using FormString = global::ZsTemplate.Languages.AboutForm.String;

namespace ZsTemplate
{
	partial class AboutForm : Form
	{
		private void SetLocalLanguage()
		{
			Text = FormString.Title + Application.ProductName;
			Icon = global::ZsTemplate.Properties.Resources.Zs;

			button_OK.Text = FormString.Button_OK;
			linkLabel_WebSite.Text = FormString.VisitWebSite;

			label1.Text = FormString.Licensed + SystemInformation.UserName;

			StringBuilder sb = new StringBuilder();
			sb.Append( Application.ProductName );
			sb.AppendLine( " is a product of :" );
			sb.AppendLine( "" );
			sb.AppendLine( "Zs\' Logic Corporation ©  2012" );

			textBox_Dock.Text = sb.ToString();
		}

		public AboutForm()
		{
			InitializeComponent();
			SetLocalLanguage();

			button_OK.Click += ( _, e ) => Close();
			linkLabel_WebSite.LinkClicked += ( _, e ) => System.Diagnostics.Process.Start( "http://zerofairnight.zs/" );
		}
	}
}

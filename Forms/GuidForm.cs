using System;
using System.Windows.Forms;

using FormString = global::ZsTemplate.Languages.GuidForm.String;

namespace ZsTemplate
{
	partial class GuidForm : Form
	{
		private void SetLocalLanguage()
		{
			this.Text = FormString.Title;
			this.Icon = global::ZsTemplate.Properties.Resources.Zs;

			this.checkBox_TopMost.Text = FormString.TopMost;
			this.linkLabel_ClipCopy.Text = FormString.ClipCopy;
			linkLabel_ClipCopyAndExit.Text = FormString.ClipCopyAndExit;

			this.textBox1.Text = null;
			this.textBox2.Text = null;
		}

		public GuidForm( string cdkey, string guid )
		{
			InitializeComponent();
			SetLocalLanguage();

			Text = string.Concat( FormString.Title, " ( ", System.Security.Cryptography.SecureString.Mask( cdkey ), " )" );

			textBox1.Text = guid.Remove( 32 - 8 );
			textBox2.Text = guid.Substring( 32 - 8 );

			linkLabel_ClipCopyAndExit.Location = new System.Drawing.Point(
				linkLabel_ClipCopy.Location.X + linkLabel_ClipCopy.Size.Width - 2, 
				linkLabel_ClipCopyAndExit.Location.Y
				);

			// event handlers...
			checkBox_TopMost.CheckedChanged += ( _, e ) =>
			{
				TopMost = ((CheckBox)_).Checked;
			};

			linkLabel_ClipCopy.LinkBehavior = LinkBehavior.NeverUnderline;
			linkLabel_ClipCopy.MouseEnter += ( _, e ) =>
			{
				linkLabel_ClipCopy.LinkBehavior = LinkBehavior.AlwaysUnderline;
			};
			linkLabel_ClipCopy.MouseLeave += ( _, e ) =>
			{
				linkLabel_ClipCopy.LinkBehavior = LinkBehavior.NeverUnderline;
			};
			linkLabel_ClipCopy.LinkClicked += ( _, e ) =>
			{
				Clipboard.SetText( textBox1.Text + "-" + textBox2.Text );
				Sound.Asterisk();
			};

			linkLabel_ClipCopyAndExit.LinkBehavior = LinkBehavior.NeverUnderline;
			linkLabel_ClipCopyAndExit.MouseEnter += ( _, e ) =>
			{
				linkLabel_ClipCopyAndExit.LinkBehavior =
				linkLabel_ClipCopy.LinkBehavior = LinkBehavior.AlwaysUnderline;
				
			};
			linkLabel_ClipCopyAndExit.MouseLeave += ( _, e ) =>
			{
				linkLabel_ClipCopyAndExit.LinkBehavior =
				linkLabel_ClipCopy.LinkBehavior = LinkBehavior.NeverUnderline;
			};
			linkLabel_ClipCopyAndExit.LinkClicked += ( _, e ) =>
			{
				Clipboard.SetText( textBox1.Text + "-" + textBox2.Text );
				Sound.Asterisk();
				Close();
			};
		}




		private void textBox_MouseDown( object sender, MouseEventArgs e )
		{
			if( e.Button == MouseButtons.Right )
				((TextBox)sender).SelectAll();
		}
	}
}

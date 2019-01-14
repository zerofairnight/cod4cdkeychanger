using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Security.Cryptography;

using FormString = global::ZsTemplate.Languages.SettingsForm.String;

namespace ZsTemplate
{
	partial class SettingsForm : Form
	{
		private void LoadSettings()
		{

		}

		private void ApplySettings()
		{

		}

		private void SetLocalLanguage()
		{
			Text = FormString.Title;
			Icon = global::ZsTemplate.Properties.Resources.Zs;

			button_OK.Text = FormString.OK;
			button_Cancel.Text = FormString.Cancel;
		}


		
		public SettingsForm()
		{
			//629; 344
			InitializeComponent();
			LoadSettings();
			SetLocalLanguage();

			treeView_Left.SelectedNode = treeView_Left.Nodes[0];
		}



		private void button_OK_Click( object sender, EventArgs e )
		{
			ApplySettings();
			Close();
		}

		private void button_Cancel_Click( object sender, EventArgs e )
		{
			Close();
		}



		private void treeView_Left_AfterSelect( object sender, TreeViewEventArgs e )
		{
		//	panel0.Visible = false;
		//	panel1.Visible = false;
		//
		//	switch( e.Node.Index )
		//	{
		//		case 0: panel0.Visible = true; break;
		//		case 1: panel1.Visible = true; break;
		//		default: break;
		//	}
		}
	}
}



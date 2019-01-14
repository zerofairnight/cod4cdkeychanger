using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

using MessageBoxEx;
using QuakeSocket;

using FormString = global::ZsTemplate.Languages.ZsForm.String;
using GlobalSettings = global::ZsTemplate.Properties.Settings;
using System.ComponentModel;


namespace ZsTemplate
{
	partial class ZsForm : Form
	{
		private enum KeyFlag
		{
			Reg,
			New,
		};

		private bool ListIsShow;

		private bool RegistryKeyIsValid;
		private bool GameIsRunning;
		private int GameID;

		#region Properties

		private static string RegistryKeyPath { get { return GlobalSettings.Default.RegPath; } }

		#endregion


		private void LoadSettings()
		{
			textBox_ActualRegPath.Text = GlobalSettings.Default.RegPath;

			dataGridView_CdKey.Rows.Clear();
			foreach( string key in GlobalSettings.Default.CDKeys )
				dataGridView_CdKey.Rows.Add( SecureString.Mask( key, GlobalSettings.Default.MaskList ), key );
		}

		private void ApplySettings()
		{
			GlobalSettings.Default.RegPath = textBox_ActualRegPath.Text;

			GlobalSettings.Default.CDKeys.Clear();
			foreach( DataGridViewRow row in dataGridView_CdKey.Rows ) if( !row.IsNewRow )
					GlobalSettings.Default.CDKeys.Add( SecureString.Crypt( row.Cells[RealKey.Name].Value.ToString() ) );
		}



		private void SetGlobalLanguage( string language )
		{
			GlobalSettings.Default.Language = language;

			toolStripMenuItem_it.Checked = false;
			toolStripMenuItem_en.Checked = false;
			switch( language )	// CultureInfo.CurrentUICulture.Name;
			{
				case "it-IT": toolStripMenuItem_it.Checked = true; break;
				default: toolStripMenuItem_en.Checked = true; break;
			}

			Thread.CurrentThread.CurrentUICulture = new CultureInfo( language );
			Thread.CurrentThread.CurrentCulture = new CultureInfo( language );

			SetLocalLanguage();
		}

		private void SetLocalLanguage()
		{
			this.Text = Application.ProductName + FormString.Title;
			this.Icon = global::ZsTemplate.Properties.Resources.Zs;

			this.notifyIcon.Text = Application.ProductName;
			this.notifyIcon.Icon = global::ZsTemplate.Properties.Resources.notifyIcon;

			{	/* contextMenu */
				this.menuItem_Validate.Text = FormString.Menu_Validate;
				this.menuItem_FastValidate.Text = FormString.Menu_FastValidate;
				this.menuItem_ServerValidate.Text = FormString.Menu_ServerValidate;

				this.menuItem_Copy.Text = FormString.Menu_Copy;
				this.menuItem_Paste.Text = FormString.Menu_Paste;
				this.menuItem_Delete.Text = FormString.Menu_Delete;

				this.menuItem_Use.Text = FormString.Menu_Use;
				this.menuItem_Save.Text = FormString.Menu_Save;
				this.menuItem_Remove.Text = FormString.Menu_Remove;

				this.menuItem_Fix.Text = FormString.Menu_Fix;
				this.menuItem_GetGuid.Text = FormString.Menu_GetGuid;

			}
			{	/* TabPage 1 */

				this.tabPage1.Text = FormString.TabPage_1;

				this.toolStripMenuItem_File.Text = FormString.File;
				this.toolStripMenuItem_File_Open.Text = FormString.File_Open;
				this.toolStripMenuItem_File_Save.Text = FormString.File_Save;
				this.toolStripMenuItem_File_Exit.Text = FormString.File_Exit;

				this.toolStripMenuItem_Tools.Text = FormString.Tools;
				this.toolStripMenuItem_Tools_Language.Text = FormString.Tools_Language;
				this.toolStripMenuItem_Tools_Settings.Text = FormString.Tools_Settings;

				this.toolStripMenuItem_Qt.Text = FormString.Qt;
				this.toolStripMenuItem_Qt_Help.Text = FormString.Qt_Help;
				this.toolStripMenuItem_Qt_About.Text = FormString.Qt_About;
				this.toolStripMenuItem_Qt_Update.Text = FormString.Qt_Update;

				this.label_RegKey.Text = FormString.Label_RegKey;
				this.label_NewKey.Text = FormString.Label_NewKey;

				this.button_Generate.Text = FormString.Button_Generate;

				this.Column_CdKey.HeaderText = FormString.Column_CdKey;

				this.linkLabel_ToggleKeyList.Text = (this.Size.Height < 204 + 23) ? FormString.ToggleKeyList_Show : FormString.ToggleKeyList_Hide;
			}
			{	/* TabPage 2 */

				this.tabPage2.Text = FormString.TabPage_2;

				this.groupBox_ActualRegPath.Text = FormString.GroupBox_CurrentRegistryPath;


				this.button_OpenRegedit.Text = FormString.Button_RegeditExplore;
				this.button_UseCustomRegPath.Text = FormString.Button_RegeditApply;
				this.button_RebuiltRegPath.Text = FormString.Button_RegeditRebuilt;
			}

			this.SetToolTip();

			this.Update();
		}

		private void SetToolTip()
		{
			toolTip.SetToolTip( button_Refresh_RegKey, FormString.Button_Refresh );
			toolTip.SetToolTip( button_Inject_RegKey, FormString.Button_Inject );

			toolTip.SetToolTip( button_Use_NewKey, FormString.Button_Use );
			toolTip.SetToolTip( button_Inject_NewKey, FormString.Button_Inject );
		}


		#region Monitors

		private readonly Monitor.GameState pState = new Monitor.GameState();
		void pState_GameStateChanged( object sender, Monitor.GameStateEventArgs e )
		{
			if( e.GameId != 0 )
			{
				GameIsRunning = true;
				GameID = e.GameId;

				button_Inject_RegKey.Enabled = CdKey.Key.IsValid( textBox_RegKey.Tag.ToString() );
				button_Inject_NewKey.Enabled = CdKey.Key.IsValid( textBox_NewKey.Text );
			}
			else
			{
				GameIsRunning = false;
				GameID = 0;

				button_Inject_RegKey.Enabled = false;
				button_Inject_NewKey.Enabled = false;
			}
		}

		#endregion


		private static readonly QuakeServer quakeServer = new QuakeServer();
		private readonly FastValidate regFastValidator = new FastValidate( quakeServer );
		private readonly FastValidate newFastValidator = new FastValidate( quakeServer );

		void regFastValidator_ValidationCompleted( object sender, ValidationCompletedEvent e )
		{
			if( textBox_RegKey.Tag.ToString().GetHashCode() == e.Hash )
			{
				textBox_RegKey.Cursor = Cursors.IBeam;
				SetKeyState( e.Status, KeyFlag.Reg );
			}
			else
				Update_RegKey_State();
		}

		void newFastValidator_ValidationCompleted( object sender, ValidationCompletedEvent e )
		{
			if( textBox_NewKey.Text.GetHashCode() == e.Hash )
			{
				textBox_NewKey.Cursor = Cursors.IBeam;
				SetKeyState( e.Status, KeyFlag.New );
			}
			else
				Update_NewKey_State();
		}




		public ZsForm()
		{
			InitializeComponent();
			LoadSettings();

			SetGlobalLanguage( GlobalSettings.Default.Language );

			pState.GameStateChanged += pState_GameStateChanged;
			regFastValidator.ValidationCompleted += regFastValidator_ValidationCompleted;
			newFastValidator.ValidationCompleted += newFastValidator_ValidationCompleted;

			// TODO: remember to add this in Designer

			MinimumSize = new Size( 500, 204 );
			MaximumSize = new Size( 1016, 204 );


			//notifyIcon.Text = Application.ProductName;
			//textBox_RegKey.ContextMenu = contextMenu_RegKey;
			//textBox_NewKey.ContextMenu = contextMenu_NewKey;

			textBox_RegKey.ContextMenu = contextMenu_Global;
			textBox_NewKey.ContextMenu = contextMenu_Global;

			textBox_RegKey.KeyDown += ( _, e ) =>
			{
				if( e.KeyCode == Keys.F5 )
					Update_RegKey_State();
			};
			textBox_NewKey.KeyDown += ( _, e ) =>
			{
				if( e.KeyCode == Keys.F5 )
					Update_NewKey_State();
			};
		}





		private void ZsForm_Load( object sender, EventArgs e )
		{
			button_Generate.PerformClick();
			button_Refresh_RegKey.PerformClick();
		}

		private void ZsForm_Shown( object sender, EventArgs e )
		{
			pState.RunMonitor();

			textBox_NewKey.Focus();
			textBox_NewKey.SelectAll();
		}

		private void ZsForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( GlobalSettings.Default.SaveOnExit )
			{
				ApplySettings();
				Settings.Save();
			}
		}


		#region CdKeyList PopUp

		private void ZsForm_ResizeEnd( object sender, EventArgs e )
		{
			if( tabControl1.SelectedTab == tabPage1 && this.Size.Height < 204 + 23 )
			{
				CdKeyList_Hide();
			}
		}

		private void tabControl1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( ListIsShow )
			{
				if( tabControl1.SelectedTab != tabPage1 )
				{
					CdKeyList_Hide( false );
				}
				else
				{
					CdKeyList_Show( false );
				}
			}
		}

		private void tabControl1_Selecting( object sender, TabControlCancelEventArgs e )
		{
			if( tabControl1.SelectedTab != tabPage2 )
			{
				if( RegistryKeyIsValid )
					MessageBoxExInt.Show( this, "please fix this error" );
			}
		}


		private void linkLabel_ToggleKeyList_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			CdKeyList_Toggle();
		}

		//
		void CdKeyList_Toggle()
		{
			if( this.Size.Height <= 204 )
			{
				CdKeyList_Show();
			}
			else
			{
				CdKeyList_Hide();
			}
		}

		void CdKeyList_Adjust()
		{
			if( this.Size.Height > 204 )
			{
				CdKeyList_Hide();
				CdKeyList_Show();
			}

		}

		void CdKeyList_Show( bool overrideShowStatus = true )
		{
			this.MaximumSize = new Size( 1016, 408 );

			int newheight = 23 + (dataGridView_CdKey.Rows.Count * 22) + this.Size.Height;

			if( newheight > Screen.PrimaryScreen.WorkingArea.Height - this.Location.Y )
				newheight = Screen.PrimaryScreen.WorkingArea.Height - this.Location.Y;

			this.Size = new Size( this.Size.Width, newheight );

			this.linkLabel_ToggleKeyList.Text = FormString.ToggleKeyList_Hide;

			if( overrideShowStatus )
				ListIsShow = true;
		}

		void CdKeyList_Hide( bool overrideShowStatus = true )
		{
			this.MaximumSize = new Size( 1016, 204 );

			this.linkLabel_ToggleKeyList.Text = FormString.ToggleKeyList_Show;

			if( overrideShowStatus )
				ListIsShow = false;
		}

		#endregion


		#region MenuStrip

		#region | MenuStrip | File

		private void toolStripMenuItem_Open_Click( object sender, EventArgs e )
		{
			Settings.Load();
			LoadSettings();
		}

		private void toolStripMenuItem_Save_Click( object sender, EventArgs e )
		{
			ApplySettings();
			Settings.Save();
		}

		private void toolStripMenuItem_Exit_Click( object sender, EventArgs e )
		{
			Close();
		}

		#endregion

		#region | MenuStrip | Tools

		private void toolStripMenuItem_en_Click( object sender, EventArgs e )
		{
			SetGlobalLanguage( "" );
		}
		private void toolStripMenuItem_it_Click( object sender, EventArgs e )
		{
			SetGlobalLanguage( "it-IT" );
		}

		private void toolStripMenuItem_Settings_Click( object sender, EventArgs e )
		{
			using( var form = new SettingsForm() )
				form.ShowDialog();

			textBox_RegKey_Leave( textBox_RegKey, null );
			dataGridView_CdKey_Leave( dataGridView_CdKey, null );
		}

		#endregion

		#region | MenuStrip | Qt

		private void toolStripMenuItem_Help_Click( object sender, EventArgs e )
		{
			// TODO: add help context
			MessageBoxExInt.Show( "HELP ME" );
		}

		private void toolStripMenuItem_About_Click( object sender, EventArgs e )
		{
			using( var form = new AboutForm() )
				form.ShowDialog();
		}

		private void toolStripMenuItem_Update_Click( object sender, EventArgs e )
		{
			// TODO: add update context
			MessageBoxExInt.Show( "UPDATE ME" );
		}

		#endregion

		#endregion



		private void SetInvalidRegGlobally()
		{
			tabControl1.SelectedTab = tabPage2;
			textBox_RegKey.Tag = textBox_RegKey.Text = "-";

			RegistryKeyIsValid = true;

			textBox_CustomRegPath.Enabled =
			button_UseCustomRegPath.Enabled =
			button_RebuiltRegPath.Enabled = true;
		}

		private void SetValidRegGlobally()
		{
			RegistryKeyIsValid = false;

			textBox_CustomRegPath.Enabled =
			button_UseCustomRegPath.Enabled =
			button_RebuiltRegPath.Enabled = false;
		}




		void Update_RegKey_State()
		{
			regFastValidator.Abort();

			string key = textBox_RegKey.Tag.ToString();

			bool isValid = CdKey.Key.IsValid( key );
			if( isValid )
			{
				if( GlobalSettings.Default.MarkAsValid )
				{
					SetKeyState( ReportStatus.OnlineValid, KeyFlag.Reg, true );
				}
				else
				{
					SetKeyState( ReportStatus.OnlineInvalid, KeyFlag.Reg );

					if( GlobalSettings.Default.AutoFastValidate )
					{
						regFastValidator.Validate( key );

						if( GlobalSettings.Default.UseWaitCursor )
							Cursor.Current = Cursors.WaitCursor;
					}
				}
			}
			else
			{
				SetKeyState( ReportStatus.InvalidKey, KeyFlag.Reg );
			}

			button_Inject_RegKey.Enabled = isValid && GameIsRunning;
		}

		void Update_NewKey_State()
		{
			newFastValidator.Abort();

			string key = textBox_NewKey.Text;

			bool isValid = CdKey.Key.IsValid( key );
			if( isValid )
			{
				if( GlobalSettings.Default.MarkAsValid )
				{
					SetKeyState( ReportStatus.OnlineValid, KeyFlag.New, true );
				}
				else
				{
					SetKeyState( ReportStatus.OnlineInvalid, KeyFlag.New );

					if( GlobalSettings.Default.AutoFastValidate )
					{
						newFastValidator.Validate( key );
						if( GlobalSettings.Default.UseWaitCursor )
							textBox_NewKey.Cursor = Cursors.WaitCursor;
					}
				}
			}
			else
			{
				SetKeyState( ReportStatus.InvalidKey, KeyFlag.New );
			}

			button_Use_NewKey.Enabled = isValid && button_Refresh_RegKey.Enabled;
			button_Inject_NewKey.Enabled = isValid && GameIsRunning;
		}

		void SetKeyState( ReportStatus status, KeyFlag flag, bool markAsValid = false )
		{
			Control tx = flag == KeyFlag.Reg ? textBox_RegKey : textBox_NewKey;
			Control pb = flag == KeyFlag.Reg ? pictureBox_RegKey_Glow : pictureBox_NewKey_Glow;

			switch( status )
			{
				case ReportStatus.OnlineValid:
					pb.BackColor = Color.LightGreen;
					toolTip.SetToolTip( tx, markAsValid ? ReportStatus.OnlineInvalid.ToMessage() : status.ToMessage() );
					return;
				case ReportStatus.InvalidKey:
					pb.BackColor = Color.Red;
					break;
				default:
					pb.BackColor = Color.Orange;
					break;
			}
			toolTip.SetToolTip( tx, status.ToMessage() );
		}




		bool Handle_Error( ErrorState state )
		{
			if( state == ErrorState.None )
				return false;

			ErrorContainer c = ErrorHandler.HandleContainer( this, state );
			switch( state )
			{
				case ErrorState.Registry:
				case ErrorState.RegistryEmpty:
				case ErrorState.RegistryRoot:
				case ErrorState.RegistryPeak:
					SetInvalidRegGlobally();
					break;

				case ErrorState.RegistrySecuritySet:
				case ErrorState.RegistrySecurityGet:
				case ErrorState.RegistryUnauthorizedAccess:
				case ErrorState.RegistryIO:
					break;

				default:
					return true;
			}

			toolTip.SetToolTip( textBox_RegKey, c.Tip );
			pictureBox_RegKey_Glow.BackColor = c.Color;

			return true;
		}


		private bool KeyIsSaved( string cdKey )
		{
			foreach( DataGridViewRow row in dataGridView_CdKey.Rows )
				if( !row.IsNewRow && cdKey.Equals( row.Cells[RealKey.Name].Value.ToString() ) )
					return true;

			return false;
		}


		public static void fixStats()
		{
			try
			{
				bool FixStatsAllMods = GlobalSettings.Default.FixStatsAllMods;
				bool FixStatsAllProfiles = GlobalSettings.Default.FixStatsAllProfiles;
				bool FixStatsFixCorrupt = GlobalSettings.Default.FixStatsFixCorrupt;

				string profiles_path = string.Concat( Microsoft.Win32.Registry.GetValue( RegistryKeyPath, "InstallPath", null ), "\\players\\profiles" );
				string profiles = "*";

				if( !FixStatsAllProfiles )
				{
					string active_path = profiles_path + "\\active.txt";
					string active = "";

					if( !File.Exists( active_path ) )
						return;

					using( StreamReader sr = new StreamReader( active_path ) )
						active = sr.ReadLine();

					if( string.IsNullOrEmpty( active ) || !Directory.Exists( Path.Combine( profiles_path, active ) ) )
						return;

					profiles = active;
				}

				string[] dir = Directory.GetDirectories( profiles_path, profiles, SearchOption.TopDirectoryOnly );
				foreach( string s in dir )
				{
					string[] files = Directory.GetFiles( Path.Combine( profiles_path, s ), "mpdata*", FixStatsAllMods ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly );
					foreach( string ss in files )
						if( FixStatsFixCorrupt ? Path.GetFileNameWithoutExtension( ss ) == "mpdata" : Path.GetFileName( ss ) == "mpdata" )
							File.Delete( ss );
				}
			}
			catch { }
		}

		void GetKey()
		{
			string value;
			ErrorState error = CdKey.Key.Get( RegistryKeyPath, out value );
			if( Handle_Error( error ) )
				return;

			SetValidRegGlobally();

			// do not continue incase that i have already that value
			if( textBox_RegKey.Tag.ToString() == value )
				return;

			textBox_RegKey.Tag = value;
			textBox_RegKey.Text = SecureString.Mask( value, GlobalSettings.Default.MaskReg );

			Update_RegKey_State();
		}

		void SetKey( string key )
		{
			ErrorState error = CdKey.Key.Set( RegistryKeyPath, key );
			if( Handle_Error( error ) )
				return;

			SetValidRegGlobally();

			if( GlobalSettings.Default.FixStats )
				new Thread( fixStats ).Start();

			button_Refresh_RegKey.PerformClick();

			Sound.Asterisk();
		}

		void GetGuid( string key )
		{
			string guid;
			ErrorState error = CdGuid.Get( key, out guid );
			if( ErrorHandler.Handle( this, error ) )
				return;

			GuidForm guidForm = new GuidForm( key, guid );
			guidForm.FormClosed += ( sender, e ) =>
			{
				guidForm.Dispose();
				guidForm = null;
			};

			guidForm.Show();
		}


		void InjectKey( string key )
		{
			ErrorState error = CdKey.Inject( GameID, key );
			if( ErrorHandler.Handle( this, error ) )
				return;

			Sound.Asterisk();
		}


		void SaveKey( string key )
		{
			ErrorState error = CdKey.Key.IsValidAsErrorState( key );
			if( ErrorHandler.Handle( this, error ) )
				return;

			string formatKey = SecureString.Mask( key, GlobalSettings.Default.MaskList );

			foreach( DataGridViewRow row in dataGridView_CdKey.Rows )
				if( !row.IsNewRow && key.Equals( row.Cells[RealKey.Name].Value.ToString() ) )
				{
					MessageBoxExInt.ShowExclamation( this, FormString.SaveKey_DuplicateFound );
					return;
				}

			if( MessageBoxExInt.ShowQuestion( this, FormString.SaveKey_Question ) != DialogResult.OK )
				return;

			dataGridView_CdKey.Rows.Add( formatKey, key );

			CdKeyList_Adjust();

			Sound.Asterisk();
		}

		void RemoveKey( string key )
		{
			bool done = false;
			foreach( DataGridViewRow row in dataGridView_CdKey.Rows )
				if( !row.IsNewRow && key.Equals( row.Cells[RealKey.Name].Value.ToString() ) )
				{
					done = true;

					if( MessageBoxExInt.ShowQuestion( this, FormString.RemoveKey_Question ) != DialogResult.OK )
						return;

					dataGridView_CdKey.Rows.Remove( row );
					break;
				}

			if( !done )
			{
				MessageBoxExInt.ShowExclamation( this, FormString.RemoveKey_NotFound );
				return;
			}

			CdKeyList_Adjust();

			Sound.Asterisk();
		}



		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
		///////////////////////////////////////////////////////////////////////////////////
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //
		#region MaskByKey

		private readonly static Keys MaskKey = Keys.ShiftKey;

		private void textBox_RegKey_KeyDown( object sender, KeyEventArgs e )
		{
			TextBox tb = ((TextBox)sender);

			if( e.KeyCode == MaskKey && (GlobalSettings.Default.MaskOnKey && GlobalSettings.Default.MaskReg) )
				tb.Text = tb.Tag.ToString();
		}

		private void textBox_RegKey_KeyUp( object sender, KeyEventArgs e )
		{
			TextBox tb = ((TextBox)sender);

			if( e.KeyCode == MaskKey && (GlobalSettings.Default.MaskOnKey && GlobalSettings.Default.MaskReg) )
				tb.Text = SecureString.Mask( tb.Tag.ToString() );
		}

		private void textBox_RegKey_Leave( object sender, EventArgs e )
		{
			TextBox tb = ((TextBox)sender);

			if( GlobalSettings.Default.MaskOnKey && GlobalSettings.Default.MaskReg )
				tb.Text = SecureString.Mask( tb.Tag.ToString() );
		}

		///////////////

		private void textBox_NewKey_TextChanged( object sender, EventArgs e )
		{
			Update_NewKey_State();
		}

		#endregion


		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
		///////////////////////////////////////////////////////////////////////////////////
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //
		#region MenuItem

		bool contextMenu_IsOpen;
		private string contextMenu_RetriveControlCdKey( Control control, bool selectedText = false )
		{
			if( control == textBox_RegKey )
			{
				return textBox_RegKey.Tag.ToString();
			}
			if( control == textBox_NewKey )
			{
				return selectedText ? textBox_NewKey.SelectedText : textBox_NewKey.Text;
			}
			if( control == dataGridView_CdKey )
			{
				foreach( DataGridViewRow row in dataGridView_CdKey.SelectedRows ) if( !row.IsNewRow )
						return row.Cells[RealKey.Name].Value.ToString();
			}

			return null;
		}


		private void contextMenu_Global_Collapse( object sender, EventArgs e )
		{
			contextMenu_IsOpen = false;
		}

		private void contextMenu_Global_Popup( object sender, EventArgs e )
		{
			contextMenu_IsOpen = true;

			Control control = contextMenu_Global.SourceControl;
			control.Select();
			control.Focus();

			string controlCdKey = contextMenu_RetriveControlCdKey( control );

			bool controlCdKeyIsValid = CdKey.Key.IsValid( controlCdKey );
			bool controlCdKeyIsSaved = KeyIsSaved( controlCdKey );
			bool controlCdKeyIsInReg = controlCdKey == textBox_RegKey.Tag.ToString();

			if( control == textBox_RegKey )
			{
				menuItem_Validate.Enabled = controlCdKeyIsValid;
				//
				menuItem_Copy.Enabled = true;
				menuItem_Paste.Enabled = false;
				menuItem_Delete.Enabled = false;
				//
				menuItem_Use.Enabled = false;
				menuItem_Save.Enabled = controlCdKeyIsValid && !controlCdKeyIsSaved;
				menuItem_Remove.Enabled = false;
				//
				menuItem_Fix.Enabled = controlCdKeyIsValid;
				menuItem_GetGuid.Enabled = controlCdKeyIsValid;

				menuItem_Save.Visible = true;
				menuItem_Remove.Visible = false;

				return;
			}
			if( control == textBox_NewKey )
			{
				menuItem_Validate.Enabled = controlCdKeyIsValid;
				//
				menuItem_Copy.Enabled = textBox_NewKey.SelectedText.Length > 0;
				menuItem_Paste.Enabled = true;
				menuItem_Delete.Enabled = true;
				//
				menuItem_Use.Enabled = controlCdKeyIsValid && !controlCdKeyIsInReg;
				menuItem_Save.Enabled = controlCdKeyIsValid && !controlCdKeyIsSaved;
				menuItem_Remove.Enabled = false;
				//
				menuItem_Fix.Enabled = controlCdKeyIsValid;
				menuItem_GetGuid.Enabled = controlCdKeyIsValid;

				menuItem_Save.Visible = true;
				menuItem_Remove.Visible = false;

				return;
			}
			if( control == dataGridView_CdKey )
			{
				menuItem_Validate.Enabled = false;
				//
				menuItem_Copy.Enabled = true;		//
				menuItem_Paste.Enabled = false;
				menuItem_Delete.Enabled = false;
				//
				menuItem_Use.Enabled = !controlCdKeyIsInReg; ;		//
				menuItem_Save.Enabled = false;
				menuItem_Remove.Enabled = true;		//
				//
				menuItem_Fix.Enabled = true;		//
				menuItem_GetGuid.Enabled = true;	//

				menuItem_Save.Visible = false;
				menuItem_Remove.Visible = true;

				return;
			}
		}



		private void menuItem_FastValidate_Click( object sender, EventArgs e )
		{
			Control control = contextMenu_Global.SourceControl;

			if( control == textBox_RegKey )
			{
				Update_RegKey_State();
			}
			else if( control == textBox_NewKey )
			{
				Update_NewKey_State();
			}
		}

		private void menuItem_ServerValidate_Click( object sender, EventArgs e )
		{
			using( var form = new ServerValidatorForm() )
				form.ShowDialog();
		}



		private void menuItem_Copy_Click( object sender, EventArgs e )
		{
			Clipboard.SetText( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl, true ), TextDataFormat.Text );
		}

		private void menuItem_Paste_Click( object sender, EventArgs e )
		{
			contextMenu_Global.SourceControl.Text = Clipboard.GetText( TextDataFormat.Text );
		}

		private void menuItem_Delete_Click( object sender, EventArgs e )
		{
			contextMenu_Global.SourceControl.Text = null;
		}



		private void menuItem_Use_Click( object sender, EventArgs e )
		{
			SetKey( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl ) );
		}

		private void menuItem_Save_Click( object sender, EventArgs e )
		{
			SaveKey( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl ) );
		}

		private void menuItem_Remove_Click( object sender, EventArgs e )
		{
			RemoveKey( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl ) );
		}



		private void menuItem_Fix_Click( object sender, EventArgs e )
		{
			MessageBoxExInt.ShowError( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl ) );
		}

		private void menuItem_GetGuid_Click( object sender, EventArgs e )
		{
			GetGuid( contextMenu_RetriveControlCdKey( contextMenu_Global.SourceControl ) );
		}

		#endregion


		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
		///////////////////////////////////////////////////////////////////////////////////
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //
		#region DataGridView

		private void dataGridView_CdKey_MouseUp( object sender, MouseEventArgs e )
		{
			if( e.Button != MouseButtons.Right )
				return;

			DataGridView.HitTestInfo hitTestInfo = dataGridView_CdKey.HitTest( e.X, e.Y );
			if( hitTestInfo.Type == DataGridViewHitTestType.Cell )
			{
				dataGridView_CdKey.CurrentCell = dataGridView_CdKey.Rows[hitTestInfo.RowIndex].Cells[0];
				contextMenu_Global.Show( dataGridView_CdKey, e.Location );
			}
		}

		private void dataGridView_CdKey_CellMouseDoubleClick( object sender, DataGridViewCellMouseEventArgs e )
		{
			DataGridView d = ((DataGridView)sender);

			foreach( DataGridViewRow row in d.SelectedRows )
				if( !row.IsNewRow )
				{
					SetKey( row.Cells[RealKey.Name].Value.ToString() );
					break;
				}
		}

		private void dataGridView_CdKey_KeyDown( object sender, KeyEventArgs e )
		{
			DataGridView d = ((DataGridView)sender);

			if( e.KeyCode == MaskKey && (GlobalSettings.Default.MaskOnKey && GlobalSettings.Default.MaskList) )
			{
				foreach( DataGridViewRow row in d.SelectedRows )
					if( !row.IsNewRow )
					{
						row.Cells[Column_CdKey.Name].Value = row.Cells[RealKey.Name].Value;
					}

				return;
			}

			string key = null;
			foreach( DataGridViewRow row in d.SelectedRows )
				if( !row.IsNewRow )
				{
					key = row.Cells[RealKey.Name].Value.ToString();
					break;
				}

			if( key == null )
				return;

			if( e.KeyCode == Keys.Delete )
			{
				RemoveKey( key );
			}
			else if( e.KeyCode == Keys.Enter )
			{
				SetKey( key );
			}
		}

		private void dataGridView_CdKey_KeyUp( object sender, KeyEventArgs e )
		{
			DataGridView d = ((DataGridView)sender);

			if( e.KeyCode == MaskKey && (GlobalSettings.Default.MaskOnKey && GlobalSettings.Default.MaskList) )
				foreach( DataGridViewRow row in d.SelectedRows )
					if( !row.IsNewRow )
					{
						row.Cells[Column_CdKey.Name].Value = SecureString.Mask( row.Cells[RealKey.Name].Value.ToString() );
					}
		}

		private void dataGridView_CdKey_SelectionChanged( object sender, EventArgs e )
		{
			DataGridView d = ((DataGridView)sender);

			foreach( DataGridViewRow row in d.Rows )
				if( !row.IsNewRow )
				{
					row.Cells[Column_CdKey.Name].Value = SecureString.Mask( row.Cells[RealKey.Name].Value.ToString() );
				}
		}

		private void dataGridView_CdKey_Leave( object sender, EventArgs e )
		{
			DataGridView d = ((DataGridView)sender);

			d.CurrentCell = null;
			d.ClearSelection();
			d.Update();

			foreach( DataGridViewRow row in d.Rows )
				if( !row.IsNewRow )
				{
					row.Cells[Column_CdKey.Name].Value = SecureString.Mask( row.Cells[RealKey.Name].Value.ToString() );
				}
		}

		#endregion


		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~//
		///////////////////////////////////////////////////////////////////////////////////
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ //
		#region Button TabPage1

		private void button_Refresh_RegKey_Click( object sender, EventArgs e )
		{
			GetKey();
		}

		private void button_Inject_RegKey_Click( object sender, EventArgs e )
		{
			InjectKey( textBox_RegKey.Tag.ToString() );
		}

		///////////////

		private void button_Use_NewKey_Click( object sender, EventArgs e )
		{
			SetKey( textBox_NewKey.Text );
		}

		private void button_Inject_NewKey_Click( object sender, EventArgs e )
		{
			InjectKey( textBox_NewKey.Text );
		}

		///////////////

		private void button_Generate_Click( object sender, EventArgs e )
		{
			textBox_NewKey.Text = CdKey.GenerateUnique();
			textBox_NewKey.Update();
		}

		#endregion




		private void button_OpenRegedit_Click( object sender, EventArgs e )
		{
			try
			{
				if( !string.IsNullOrEmpty( RegistryKeyPath ) )
				{
					Microsoft.Win32.Registry.SetValue(
						@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit",
						"LastKey",
						RegistryKeyPath.Replace( "Wow6432Node\\", "" )
					);
				}

				System.Diagnostics.Process.Start( "regedit.exe" );
			}
			catch( Win32Exception ) { }
			catch( System.Security.SecurityException ) { }
			catch( UnauthorizedAccessException ) { }
		}

		private void button_RebuiltRegPath_Click( object sender, EventArgs e )
		{

		}

		private void button_UseCustomRegPath_Click( object sender, EventArgs e )
		{

		}
	}
}
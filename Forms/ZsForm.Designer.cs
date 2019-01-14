namespace ZsTemplate
{
	partial class ZsForm
	{
		/// <summary>
		/// Variabile di progettazione necessaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Liberare le risorse in uso.
		/// </summary>
		/// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
				pState.Dispose();
				quakeServer.Dispose();
				regFastValidator.Dispose();
				newFastValidator.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Codice generato da Progettazione Windows Form

		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip_Top = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Tools = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Tools_Language = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_en = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_it = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Tools_Settings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Qt = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Qt_Help = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Qt_About = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem_Qt_Update = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dataGridView_CdKey = new System.Windows.Forms.DataGridView();
			this.Column_CdKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RealKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.linkLabel_ToggleKeyList = new System.Windows.Forms.LinkLabel();
			this.button_Generate = new System.Windows.Forms.Button();
			this.button_Inject_NewKey = new System.Windows.Forms.Button();
			this.button_Inject_RegKey = new System.Windows.Forms.Button();
			this.button_Use_NewKey = new System.Windows.Forms.Button();
			this.button_Refresh_RegKey = new System.Windows.Forms.Button();
			this.label_NewKey = new System.Windows.Forms.Label();
			this.textBox_NewKey = new System.Windows.Forms.TextBox();
			this.label_RegKey = new System.Windows.Forms.Label();
			this.textBox_RegKey = new System.Windows.Forms.TextBox();
			this.pictureBox_NewKey_Glow = new System.Windows.Forms.PictureBox();
			this.pictureBox_RegKey_Glow = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button_RebuiltRegPath = new System.Windows.Forms.Button();
			this.button_UseCustomRegPath = new System.Windows.Forms.Button();
			this.groupBox_ActualRegPath = new System.Windows.Forms.GroupBox();
			this.button_OpenRegedit = new System.Windows.Forms.Button();
			this.textBox_ActualRegPath = new System.Windows.Forms.TextBox();
			this.textBox_CustomRegPath = new System.Windows.Forms.TextBox();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenu_Global = new System.Windows.Forms.ContextMenu();
			this.menuItem_Validate = new System.Windows.Forms.MenuItem();
			this.menuItem_FastValidate = new System.Windows.Forms.MenuItem();
			this.menuItem_ServerValidate = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem_Copy = new System.Windows.Forms.MenuItem();
			this.menuItem_Paste = new System.Windows.Forms.MenuItem();
			this.menuItem_Delete = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem_Use = new System.Windows.Forms.MenuItem();
			this.menuItem_Save = new System.Windows.Forms.MenuItem();
			this.menuItem_Remove = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem_Fix = new System.Windows.Forms.MenuItem();
			this.menuItem_GetGuid = new System.Windows.Forms.MenuItem();
			this.menuStrip_Top.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_CdKey)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewKey_Glow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_RegKey_Glow)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox_ActualRegPath.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip_Top
			// 
			this.menuStrip_Top.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip_Top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Tools,
            this.toolStripMenuItem_Qt});
			this.menuStrip_Top.Location = new System.Drawing.Point(0, 0);
			this.menuStrip_Top.Name = "menuStrip_Top";
			this.menuStrip_Top.Size = new System.Drawing.Size(492, 24);
			this.menuStrip_Top.TabIndex = 0;
			// 
			// toolStripMenuItem_File
			// 
			this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File_Open,
            this.toolStripMenuItem_File_Save,
            this.toolStripSeparator1,
            this.toolStripMenuItem_File_Exit});
			this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
			this.toolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
			this.toolStripMenuItem_File.Text = global::ZsTemplate.Languages.ZsForm.String.File;
			// 
			// toolStripMenuItem_File_Open
			// 
			this.toolStripMenuItem_File_Open.Name = "toolStripMenuItem_File_Open";
			this.toolStripMenuItem_File_Open.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_File_Open.Text = global::ZsTemplate.Languages.ZsForm.String.File_Open;
			this.toolStripMenuItem_File_Open.Click += new System.EventHandler(this.toolStripMenuItem_Open_Click);
			// 
			// toolStripMenuItem_File_Save
			// 
			this.toolStripMenuItem_File_Save.Name = "toolStripMenuItem_File_Save";
			this.toolStripMenuItem_File_Save.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_File_Save.Text = global::ZsTemplate.Languages.ZsForm.String.File_Save;
			this.toolStripMenuItem_File_Save.Click += new System.EventHandler(this.toolStripMenuItem_Save_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
			// 
			// toolStripMenuItem_File_Exit
			// 
			this.toolStripMenuItem_File_Exit.Name = "toolStripMenuItem_File_Exit";
			this.toolStripMenuItem_File_Exit.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_File_Exit.Text = global::ZsTemplate.Languages.ZsForm.String.File_Exit;
			this.toolStripMenuItem_File_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
			// 
			// toolStripMenuItem_Tools
			// 
			this.toolStripMenuItem_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Tools_Language,
            this.toolStripMenuItem_Tools_Settings});
			this.toolStripMenuItem_Tools.Name = "toolStripMenuItem_Tools";
			this.toolStripMenuItem_Tools.Size = new System.Drawing.Size(48, 20);
			this.toolStripMenuItem_Tools.Text = global::ZsTemplate.Languages.ZsForm.String.Tools;
			// 
			// toolStripMenuItem_Tools_Language
			// 
			this.toolStripMenuItem_Tools_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_en,
            this.toolStripMenuItem_it});
			this.toolStripMenuItem_Tools_Language.Name = "toolStripMenuItem_Tools_Language";
			this.toolStripMenuItem_Tools_Language.Size = new System.Drawing.Size(126, 22);
			this.toolStripMenuItem_Tools_Language.Text = global::ZsTemplate.Languages.ZsForm.String.Tools_Language;
			// 
			// toolStripMenuItem_en
			// 
			this.toolStripMenuItem_en.Name = "toolStripMenuItem_en";
			this.toolStripMenuItem_en.Size = new System.Drawing.Size(162, 22);
			this.toolStripMenuItem_en.Text = global::ZsTemplate.Languages.ZsForm.String.Unlocalize_Menu_EN;
			this.toolStripMenuItem_en.Click += new System.EventHandler(this.toolStripMenuItem_en_Click);
			// 
			// toolStripMenuItem_it
			// 
			this.toolStripMenuItem_it.Name = "toolStripMenuItem_it";
			this.toolStripMenuItem_it.Size = new System.Drawing.Size(162, 22);
			this.toolStripMenuItem_it.Text = global::ZsTemplate.Languages.ZsForm.String.Unlocalize_Menu_IT;
			this.toolStripMenuItem_it.Click += new System.EventHandler(this.toolStripMenuItem_it_Click);
			// 
			// toolStripMenuItem_Tools_Settings
			// 
			this.toolStripMenuItem_Tools_Settings.Name = "toolStripMenuItem_Tools_Settings";
			this.toolStripMenuItem_Tools_Settings.Size = new System.Drawing.Size(126, 22);
			this.toolStripMenuItem_Tools_Settings.Text = global::ZsTemplate.Languages.ZsForm.String.Tools_Settings;
			this.toolStripMenuItem_Tools_Settings.Click += new System.EventHandler(this.toolStripMenuItem_Settings_Click);
			// 
			// toolStripMenuItem_Qt
			// 
			this.toolStripMenuItem_Qt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Qt_Help,
            this.toolStripMenuItem_Qt_About,
            this.toolStripMenuItem_Qt_Update});
			this.toolStripMenuItem_Qt.Name = "toolStripMenuItem_Qt";
			this.toolStripMenuItem_Qt.Size = new System.Drawing.Size(24, 20);
			this.toolStripMenuItem_Qt.Text = global::ZsTemplate.Languages.ZsForm.String.Qt;
			// 
			// toolStripMenuItem_Qt_Help
			// 
			this.toolStripMenuItem_Qt_Help.Name = "toolStripMenuItem_Qt_Help";
			this.toolStripMenuItem_Qt_Help.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_Qt_Help.Text = global::ZsTemplate.Languages.ZsForm.String.Qt_Help;
			this.toolStripMenuItem_Qt_Help.Click += new System.EventHandler(this.toolStripMenuItem_Help_Click);
			// 
			// toolStripMenuItem_Qt_About
			// 
			this.toolStripMenuItem_Qt_About.Name = "toolStripMenuItem_Qt_About";
			this.toolStripMenuItem_Qt_About.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_Qt_About.Text = global::ZsTemplate.Languages.ZsForm.String.Qt_About;
			this.toolStripMenuItem_Qt_About.Click += new System.EventHandler(this.toolStripMenuItem_About_Click);
			// 
			// toolStripMenuItem_Qt_Update
			// 
			this.toolStripMenuItem_Qt_Update.Name = "toolStripMenuItem_Qt_Update";
			this.toolStripMenuItem_Qt_Update.Size = new System.Drawing.Size(112, 22);
			this.toolStripMenuItem_Qt_Update.Text = global::ZsTemplate.Languages.ZsForm.String.Qt_Update;
			this.toolStripMenuItem_Qt_Update.Click += new System.EventHandler(this.toolStripMenuItem_Update_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.Visible = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(492, 142);
			this.tabControl1.TabIndex = 1;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dataGridView_CdKey);
			this.tabPage1.Controls.Add(this.linkLabel_ToggleKeyList);
			this.tabPage1.Controls.Add(this.button_Generate);
			this.tabPage1.Controls.Add(this.button_Inject_NewKey);
			this.tabPage1.Controls.Add(this.button_Inject_RegKey);
			this.tabPage1.Controls.Add(this.button_Use_NewKey);
			this.tabPage1.Controls.Add(this.button_Refresh_RegKey);
			this.tabPage1.Controls.Add(this.label_NewKey);
			this.tabPage1.Controls.Add(this.textBox_NewKey);
			this.tabPage1.Controls.Add(this.label_RegKey);
			this.tabPage1.Controls.Add(this.textBox_RegKey);
			this.tabPage1.Controls.Add(this.pictureBox_NewKey_Glow);
			this.tabPage1.Controls.Add(this.pictureBox_RegKey_Glow);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(484, 116);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = global::ZsTemplate.Languages.ZsForm.String.TabPage_1;
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dataGridView_CdKey
			// 
			this.dataGridView_CdKey.AllowUserToAddRows = false;
			this.dataGridView_CdKey.AllowUserToDeleteRows = false;
			this.dataGridView_CdKey.AllowUserToResizeColumns = false;
			this.dataGridView_CdKey.AllowUserToResizeRows = false;
			this.dataGridView_CdKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_CdKey.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView_CdKey.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView_CdKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_CdKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_CdKey,
            this.RealKey});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView_CdKey.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView_CdKey.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dataGridView_CdKey.Location = new System.Drawing.Point(108, 111);
			this.dataGridView_CdKey.MultiSelect = false;
			this.dataGridView_CdKey.Name = "dataGridView_CdKey";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView_CdKey.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView_CdKey.RowHeadersVisible = false;
			this.dataGridView_CdKey.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridView_CdKey.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView_CdKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView_CdKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_CdKey.Size = new System.Drawing.Size(235, 0);
			this.dataGridView_CdKey.TabIndex = 10;
			this.dataGridView_CdKey.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CdKey_CellMouseDoubleClick);
			this.dataGridView_CdKey.SelectionChanged += new System.EventHandler(this.dataGridView_CdKey_SelectionChanged);
			this.dataGridView_CdKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_CdKey_KeyDown);
			this.dataGridView_CdKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_CdKey_KeyUp);
			this.dataGridView_CdKey.Leave += new System.EventHandler(this.dataGridView_CdKey_Leave);
			this.dataGridView_CdKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridView_CdKey_MouseUp);
			// 
			// Column_CdKey
			// 
			this.Column_CdKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Column_CdKey.DefaultCellStyle = dataGridViewCellStyle2;
			this.Column_CdKey.HeaderText = global::ZsTemplate.Languages.ZsForm.String.Column_CdKey;
			this.Column_CdKey.Name = "Column_CdKey";
			this.Column_CdKey.ReadOnly = true;
			this.Column_CdKey.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column_CdKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// RealKey
			// 
			this.RealKey.Name = "RealKey";
			this.RealKey.Visible = false;
			// 
			// linkLabel_ToggleKeyList
			// 
			this.linkLabel_ToggleKeyList.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaption;
			this.linkLabel_ToggleKeyList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel_ToggleKeyList.AutoSize = true;
			this.linkLabel_ToggleKeyList.CausesValidation = false;
			this.linkLabel_ToggleKeyList.LinkColor = System.Drawing.SystemColors.ActiveCaption;
			this.linkLabel_ToggleKeyList.Location = new System.Drawing.Point(8, 96);
			this.linkLabel_ToggleKeyList.Name = "linkLabel_ToggleKeyList";
			this.linkLabel_ToggleKeyList.Size = new System.Drawing.Size(88, 13);
			this.linkLabel_ToggleKeyList.TabIndex = 9;
			this.linkLabel_ToggleKeyList.TabStop = true;
			this.linkLabel_ToggleKeyList.Text = "Show CD Key list";
			this.linkLabel_ToggleKeyList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ToggleKeyList_LinkClicked);
			// 
			// button_Generate
			// 
			this.button_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Generate.CausesValidation = false;
			this.button_Generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button_Generate.Location = new System.Drawing.Point(8, 60);
			this.button_Generate.Name = "button_Generate";
			this.button_Generate.Size = new System.Drawing.Size(468, 33);
			this.button_Generate.TabIndex = 8;
			this.button_Generate.Text = global::ZsTemplate.Languages.ZsForm.String.Button_Generate;
			this.button_Generate.UseVisualStyleBackColor = true;
			this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
			// 
			// button_Inject_NewKey
			// 
			this.button_Inject_NewKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Inject_NewKey.BackgroundImage = global::ZsTemplate.Properties.Resources.button_inject;
			this.button_Inject_NewKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button_Inject_NewKey.Enabled = false;
			this.button_Inject_NewKey.Location = new System.Drawing.Point(419, 33);
			this.button_Inject_NewKey.Name = "button_Inject_NewKey";
			this.button_Inject_NewKey.Size = new System.Drawing.Size(33, 24);
			this.button_Inject_NewKey.TabIndex = 7;
			this.button_Inject_NewKey.UseVisualStyleBackColor = true;
			this.button_Inject_NewKey.Click += new System.EventHandler(this.button_Inject_NewKey_Click);
			// 
			// button_Inject_RegKey
			// 
			this.button_Inject_RegKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Inject_RegKey.BackgroundImage = global::ZsTemplate.Properties.Resources.button_inject;
			this.button_Inject_RegKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button_Inject_RegKey.Enabled = false;
			this.button_Inject_RegKey.Location = new System.Drawing.Point(419, 7);
			this.button_Inject_RegKey.Name = "button_Inject_RegKey";
			this.button_Inject_RegKey.Size = new System.Drawing.Size(33, 24);
			this.button_Inject_RegKey.TabIndex = 3;
			this.button_Inject_RegKey.UseVisualStyleBackColor = true;
			this.button_Inject_RegKey.Click += new System.EventHandler(this.button_Inject_RegKey_Click);
			// 
			// button_Use_NewKey
			// 
			this.button_Use_NewKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Use_NewKey.BackgroundImage = global::ZsTemplate.Properties.Resources.button_use;
			this.button_Use_NewKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button_Use_NewKey.Enabled = false;
			this.button_Use_NewKey.Location = new System.Drawing.Point(383, 33);
			this.button_Use_NewKey.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.button_Use_NewKey.Name = "button_Use_NewKey";
			this.button_Use_NewKey.Size = new System.Drawing.Size(33, 24);
			this.button_Use_NewKey.TabIndex = 6;
			this.button_Use_NewKey.UseVisualStyleBackColor = true;
			this.button_Use_NewKey.Click += new System.EventHandler(this.button_Use_NewKey_Click);
			// 
			// button_Refresh_RegKey
			// 
			this.button_Refresh_RegKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Refresh_RegKey.BackgroundImage = global::ZsTemplate.Properties.Resources.button_refresh;
			this.button_Refresh_RegKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button_Refresh_RegKey.Location = new System.Drawing.Point(383, 7);
			this.button_Refresh_RegKey.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.button_Refresh_RegKey.Name = "button_Refresh_RegKey";
			this.button_Refresh_RegKey.Size = new System.Drawing.Size(33, 24);
			this.button_Refresh_RegKey.TabIndex = 2;
			this.button_Refresh_RegKey.UseVisualStyleBackColor = true;
			this.button_Refresh_RegKey.Click += new System.EventHandler(this.button_Refresh_RegKey_Click);
			// 
			// label_NewKey
			// 
			this.label_NewKey.CausesValidation = false;
			this.label_NewKey.Location = new System.Drawing.Point(10, 36);
			this.label_NewKey.Margin = new System.Windows.Forms.Padding(3, 0, 2, 0);
			this.label_NewKey.Name = "label_NewKey";
			this.label_NewKey.Size = new System.Drawing.Size(90, 14);
			this.label_NewKey.TabIndex = 4;
			this.label_NewKey.Text = "New CD Key";
			this.label_NewKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_NewKey
			// 
			this.textBox_NewKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_NewKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox_NewKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_NewKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_NewKey.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_NewKey.Location = new System.Drawing.Point(102, 35);
			this.textBox_NewKey.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.textBox_NewKey.MaxLength = 28;
			this.textBox_NewKey.Name = "textBox_NewKey";
			this.textBox_NewKey.Size = new System.Drawing.Size(277, 20);
			this.textBox_NewKey.TabIndex = 5;
			this.textBox_NewKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox_NewKey.TextChanged += new System.EventHandler(this.textBox_NewKey_TextChanged);
			// 
			// label_RegKey
			// 
			this.label_RegKey.CausesValidation = false;
			this.label_RegKey.Location = new System.Drawing.Point(10, 10);
			this.label_RegKey.Margin = new System.Windows.Forms.Padding(3, 0, 2, 0);
			this.label_RegKey.Name = "label_RegKey";
			this.label_RegKey.Size = new System.Drawing.Size(90, 14);
			this.label_RegKey.TabIndex = 0;
			this.label_RegKey.Text = "Reg. CD Key";
			this.label_RegKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_RegKey
			// 
			this.textBox_RegKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_RegKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox_RegKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_RegKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_RegKey.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_RegKey.Location = new System.Drawing.Point(102, 9);
			this.textBox_RegKey.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.textBox_RegKey.Name = "textBox_RegKey";
			this.textBox_RegKey.ReadOnly = true;
			this.textBox_RegKey.Size = new System.Drawing.Size(277, 20);
			this.textBox_RegKey.TabIndex = 1;
			this.textBox_RegKey.Tag = "";
			this.textBox_RegKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox_RegKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_RegKey_KeyDown);
			this.textBox_RegKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_RegKey_KeyUp);
			this.textBox_RegKey.Leave += new System.EventHandler(this.textBox_RegKey_Leave);
			// 
			// pictureBox_NewKey_Glow
			// 
			this.pictureBox_NewKey_Glow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox_NewKey_Glow.BackColor = System.Drawing.Color.Red;
			this.pictureBox_NewKey_Glow.Location = new System.Drawing.Point(101, 34);
			this.pictureBox_NewKey_Glow.Name = "pictureBox_NewKey_Glow";
			this.pictureBox_NewKey_Glow.Size = new System.Drawing.Size(279, 22);
			this.pictureBox_NewKey_Glow.TabIndex = 12;
			this.pictureBox_NewKey_Glow.TabStop = false;
			// 
			// pictureBox_RegKey_Glow
			// 
			this.pictureBox_RegKey_Glow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox_RegKey_Glow.BackColor = System.Drawing.Color.OrangeRed;
			this.pictureBox_RegKey_Glow.Location = new System.Drawing.Point(101, 8);
			this.pictureBox_RegKey_Glow.Name = "pictureBox_RegKey_Glow";
			this.pictureBox_RegKey_Glow.Size = new System.Drawing.Size(279, 22);
			this.pictureBox_RegKey_Glow.TabIndex = 13;
			this.pictureBox_RegKey_Glow.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button_RebuiltRegPath);
			this.tabPage2.Controls.Add(this.button_UseCustomRegPath);
			this.tabPage2.Controls.Add(this.groupBox_ActualRegPath);
			this.tabPage2.Controls.Add(this.textBox_CustomRegPath);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(484, 116);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = global::ZsTemplate.Languages.ZsForm.String.TabPage_2;
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button_RebuiltRegPath
			// 
			this.button_RebuiltRegPath.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_RebuiltRegPath.Enabled = false;
			this.button_RebuiltRegPath.Location = new System.Drawing.Point(3, 88);
			this.button_RebuiltRegPath.Name = "button_RebuiltRegPath";
			this.button_RebuiltRegPath.Size = new System.Drawing.Size(478, 25);
			this.button_RebuiltRegPath.TabIndex = 3;
			this.button_RebuiltRegPath.Text = global::ZsTemplate.Languages.ZsForm.String.Button_RegeditRebuilt;
			this.button_RebuiltRegPath.UseVisualStyleBackColor = true;
			this.button_RebuiltRegPath.Click += new System.EventHandler(this.button_RebuiltRegPath_Click);
			// 
			// button_UseCustomRegPath
			// 
			this.button_UseCustomRegPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_UseCustomRegPath.Enabled = false;
			this.button_UseCustomRegPath.Location = new System.Drawing.Point(400, 60);
			this.button_UseCustomRegPath.Name = "button_UseCustomRegPath";
			this.button_UseCustomRegPath.Size = new System.Drawing.Size(70, 23);
			this.button_UseCustomRegPath.TabIndex = 2;
			this.button_UseCustomRegPath.Text = global::ZsTemplate.Languages.ZsForm.String.Button_RegeditApply;
			this.button_UseCustomRegPath.UseVisualStyleBackColor = true;
			this.button_UseCustomRegPath.Click += new System.EventHandler(this.button_UseCustomRegPath_Click);
			// 
			// groupBox_ActualRegPath
			// 
			this.groupBox_ActualRegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_ActualRegPath.Controls.Add(this.button_OpenRegedit);
			this.groupBox_ActualRegPath.Controls.Add(this.textBox_ActualRegPath);
			this.groupBox_ActualRegPath.Location = new System.Drawing.Point(8, 6);
			this.groupBox_ActualRegPath.Name = "groupBox_ActualRegPath";
			this.groupBox_ActualRegPath.Size = new System.Drawing.Size(468, 48);
			this.groupBox_ActualRegPath.TabIndex = 0;
			this.groupBox_ActualRegPath.TabStop = false;
			this.groupBox_ActualRegPath.Text = " System Registry key currently in use ";
			// 
			// button_OpenRegedit
			// 
			this.button_OpenRegedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OpenRegedit.Location = new System.Drawing.Point(392, 17);
			this.button_OpenRegedit.Name = "button_OpenRegedit";
			this.button_OpenRegedit.Size = new System.Drawing.Size(70, 23);
			this.button_OpenRegedit.TabIndex = 1;
			this.button_OpenRegedit.Text = global::ZsTemplate.Languages.ZsForm.String.Button_RegeditExplore;
			this.button_OpenRegedit.UseVisualStyleBackColor = true;
			this.button_OpenRegedit.Click += new System.EventHandler(this.button_OpenRegedit_Click);
			// 
			// textBox_ActualRegPath
			// 
			this.textBox_ActualRegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_ActualRegPath.Location = new System.Drawing.Point(6, 19);
			this.textBox_ActualRegPath.Name = "textBox_ActualRegPath";
			this.textBox_ActualRegPath.ReadOnly = true;
			this.textBox_ActualRegPath.Size = new System.Drawing.Size(380, 20);
			this.textBox_ActualRegPath.TabIndex = 0;
			// 
			// textBox_CustomRegPath
			// 
			this.textBox_CustomRegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_CustomRegPath.Enabled = false;
			this.textBox_CustomRegPath.Location = new System.Drawing.Point(14, 62);
			this.textBox_CustomRegPath.Name = "textBox_CustomRegPath";
			this.textBox_CustomRegPath.Size = new System.Drawing.Size(380, 20);
			this.textBox_CustomRegPath.TabIndex = 1;
			// 
			// toolTip
			// 
			this.toolTip.AutomaticDelay = 100;
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 100;
			this.toolTip.ReshowDelay = 20;
			// 
			// contextMenu_Global
			// 
			this.contextMenu_Global.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Validate,
            this.menuItem4,
            this.menuItem_Copy,
            this.menuItem_Paste,
            this.menuItem_Delete,
            this.menuItem8,
            this.menuItem_Use,
            this.menuItem_Save,
            this.menuItem_Remove,
            this.menuItem10,
            this.menuItem_Fix,
            this.menuItem_GetGuid});
			this.contextMenu_Global.Popup += new System.EventHandler(this.contextMenu_Global_Popup);
			this.contextMenu_Global.Collapse += new System.EventHandler(this.contextMenu_Global_Collapse);
			// 
			// menuItem_Validate
			// 
			this.menuItem_Validate.Index = 0;
			this.menuItem_Validate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_FastValidate,
            this.menuItem_ServerValidate});
			this.menuItem_Validate.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Validate;
			// 
			// menuItem_FastValidate
			// 
			this.menuItem_FastValidate.Index = 0;
			this.menuItem_FastValidate.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_FastValidate;
			this.menuItem_FastValidate.Click += new System.EventHandler(this.menuItem_FastValidate_Click);
			// 
			// menuItem_ServerValidate
			// 
			this.menuItem_ServerValidate.Index = 1;
			this.menuItem_ServerValidate.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_ServerValidate;
			this.menuItem_ServerValidate.Click += new System.EventHandler(this.menuItem_ServerValidate_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = global::ZsTemplate.Languages.ZsForm.String.Unlocalize_Menu_Spacer;
			// 
			// menuItem_Copy
			// 
			this.menuItem_Copy.Index = 2;
			this.menuItem_Copy.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Copy;
			this.menuItem_Copy.Click += new System.EventHandler(this.menuItem_Copy_Click);
			// 
			// menuItem_Paste
			// 
			this.menuItem_Paste.Index = 3;
			this.menuItem_Paste.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Paste;
			this.menuItem_Paste.Click += new System.EventHandler(this.menuItem_Paste_Click);
			// 
			// menuItem_Delete
			// 
			this.menuItem_Delete.Index = 4;
			this.menuItem_Delete.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Delete;
			this.menuItem_Delete.Click += new System.EventHandler(this.menuItem_Delete_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 5;
			this.menuItem8.Text = global::ZsTemplate.Languages.ZsForm.String.Unlocalize_Menu_Spacer;
			// 
			// menuItem_Use
			// 
			this.menuItem_Use.Index = 6;
			this.menuItem_Use.Text = "Use";
			this.menuItem_Use.Click += new System.EventHandler(this.menuItem_Use_Click);
			// 
			// menuItem_Save
			// 
			this.menuItem_Save.Index = 7;
			this.menuItem_Save.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Save;
			this.menuItem_Save.Click += new System.EventHandler(this.menuItem_Save_Click);
			// 
			// menuItem_Remove
			// 
			this.menuItem_Remove.Index = 8;
			this.menuItem_Remove.Text = "Remove";
			this.menuItem_Remove.Click += new System.EventHandler(this.menuItem_Remove_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 9;
			this.menuItem10.Text = global::ZsTemplate.Languages.ZsForm.String.Unlocalize_Menu_Spacer;
			// 
			// menuItem_Fix
			// 
			this.menuItem_Fix.Index = 10;
			this.menuItem_Fix.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_Fix;
			this.menuItem_Fix.Click += new System.EventHandler(this.menuItem_Fix_Click);
			// 
			// menuItem_GetGuid
			// 
			this.menuItem_GetGuid.Index = 11;
			this.menuItem_GetGuid.Text = global::ZsTemplate.Languages.ZsForm.String.Menu_GetGuid;
			this.menuItem_GetGuid.Click += new System.EventHandler(this.menuItem_GetGuid_Click);
			// 
			// ZsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(492, 166);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip_Top);
			this.MainMenuStrip = this.menuStrip_Top;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(508, 204);
			this.Name = "ZsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "english";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZsForm_FormClosing);
			this.Load += new System.EventHandler(this.ZsForm_Load);
			this.Shown += new System.EventHandler(this.ZsForm_Shown);
			this.ResizeEnd += new System.EventHandler(this.ZsForm_ResizeEnd);
			this.menuStrip_Top.ResumeLayout(false);
			this.menuStrip_Top.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_CdKey)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_NewKey_Glow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_RegKey_Glow)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox_ActualRegPath.ResumeLayout(false);
			this.groupBox_ActualRegPath.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip_Top;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Tools;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Qt;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Tools_Settings;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Qt_Help;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Qt_About;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Qt_Update;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_Open;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_Save;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File_Exit;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Tools_Language;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_en;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_it;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBox_RegKey;
		private System.Windows.Forms.Label label_RegKey;
		private System.Windows.Forms.TextBox textBox_NewKey;
		private System.Windows.Forms.Label label_NewKey;
		private System.Windows.Forms.Button button_Inject_NewKey;
		private System.Windows.Forms.Button button_Inject_RegKey;
		private System.Windows.Forms.Button button_Use_NewKey;
		private System.Windows.Forms.Button button_Refresh_RegKey;
		private System.Windows.Forms.Button button_Generate;
		private System.Windows.Forms.LinkLabel linkLabel_ToggleKeyList;
		private System.Windows.Forms.PictureBox pictureBox_NewKey_Glow;
		private System.Windows.Forms.PictureBox pictureBox_RegKey_Glow;
		private System.Windows.Forms.GroupBox groupBox_ActualRegPath;
		private System.Windows.Forms.Button button_OpenRegedit;
		private System.Windows.Forms.TextBox textBox_ActualRegPath;
		private System.Windows.Forms.Button button_RebuiltRegPath;
		private System.Windows.Forms.Button button_UseCustomRegPath;
		private System.Windows.Forms.TextBox textBox_CustomRegPath;
		private System.Windows.Forms.DataGridView dataGridView_CdKey;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_CdKey;
		private System.Windows.Forms.DataGridViewTextBoxColumn RealKey;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenu contextMenu_Global;
		private System.Windows.Forms.MenuItem menuItem_Validate;
		private System.Windows.Forms.MenuItem menuItem_FastValidate;
		private System.Windows.Forms.MenuItem menuItem_ServerValidate;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem_Copy;
		private System.Windows.Forms.MenuItem menuItem_Paste;
		private System.Windows.Forms.MenuItem menuItem_Delete;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem_Save;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem_Fix;
		private System.Windows.Forms.MenuItem menuItem_GetGuid;
		private System.Windows.Forms.MenuItem menuItem_Remove;
		private System.Windows.Forms.MenuItem menuItem_Use;
	}
}


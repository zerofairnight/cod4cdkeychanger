namespace ZsTemplate
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Nodo0");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Nodo1");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Nodo2");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Nodo3");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Nodo4");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Nodo5");
			this.treeView_Left = new System.Windows.Forms.TreeView();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_OK = new System.Windows.Forms.Button();
			this.progressBar_Busy = new System.Windows.Forms.ProgressBar();
			this.label_Busy = new System.Windows.Forms.Label();
			splitContainer_Dock = new System.Windows.Forms.SplitContainer();
			label_Separator_Bot = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(splitContainer_Dock)).BeginInit();
			splitContainer_Dock.Panel1.SuspendLayout();
			splitContainer_Dock.Panel2.SuspendLayout();
			splitContainer_Dock.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView_Left
			// 
			this.treeView_Left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView_Left.Location = new System.Drawing.Point(0, 0);
			this.treeView_Left.Name = "treeView_Left";
			treeNode1.Name = "Nodo0";
			treeNode1.Text = "Nodo0";
			treeNode2.Name = "Nodo1";
			treeNode2.Text = "Nodo1";
			treeNode3.Name = "Nodo2";
			treeNode3.Text = "Nodo2";
			treeNode4.Name = "Nodo3";
			treeNode4.Text = "Nodo3";
			treeNode5.Name = "Nodo4";
			treeNode5.Text = "Nodo4";
			treeNode6.Name = "Nodo5";
			treeNode6.Text = "Nodo5";
			this.treeView_Left.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
			this.treeView_Left.ShowLines = false;
			this.treeView_Left.ShowNodeToolTips = true;
			this.treeView_Left.Size = new System.Drawing.Size(163, 252);
			this.treeView_Left.TabIndex = 0;
			this.treeView_Left.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Left_AfterSelect);
			// 
			// button_Cancel
			// 
			this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Cancel.Location = new System.Drawing.Point(526, 271);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = global::ZsTemplate.Languages.SettingsForm.String.Cancel;
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// button_OK
			// 
			this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OK.Location = new System.Drawing.Point(445, 271);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 3;
			this.button_OK.Text = global::ZsTemplate.Languages.SettingsForm.String.OK;
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// progressBar_Busy
			// 
			this.progressBar_Busy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar_Busy.Location = new System.Drawing.Point(12, 276);
			this.progressBar_Busy.Name = "progressBar_Busy";
			this.progressBar_Busy.Size = new System.Drawing.Size(261, 13);
			this.progressBar_Busy.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressBar_Busy.TabIndex = 1;
			this.progressBar_Busy.Visible = false;
			// 
			// label_Busy
			// 
			this.label_Busy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Busy.AutoSize = true;
			this.label_Busy.Location = new System.Drawing.Point(279, 276);
			this.label_Busy.Name = "label_Busy";
			this.label_Busy.Size = new System.Drawing.Size(81, 13);
			this.label_Busy.TabIndex = 2;
			this.label_Busy.Text = "Apply settings...";
			this.label_Busy.Visible = false;
			// 
			// splitContainer_Dock
			// 
			splitContainer_Dock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			splitContainer_Dock.CausesValidation = false;
			splitContainer_Dock.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			splitContainer_Dock.ImeMode = System.Windows.Forms.ImeMode.Disable;
			splitContainer_Dock.Location = new System.Drawing.Point(12, 12);
			splitContainer_Dock.Name = "splitContainer_Dock";
			// 
			// splitContainer_Dock.Panel1
			// 
			splitContainer_Dock.Panel1.CausesValidation = false;
			splitContainer_Dock.Panel1.Controls.Add(this.treeView_Left);
			splitContainer_Dock.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
			// 
			// splitContainer_Dock.Panel2
			// 
			splitContainer_Dock.Panel2.CausesValidation = false;
			splitContainer_Dock.Panel2.Controls.Add(label_Separator_Bot);
			splitContainer_Dock.Size = new System.Drawing.Size(589, 253);
			splitContainer_Dock.SplitterDistance = 163;
			splitContainer_Dock.TabIndex = 0;
			// 
			// label_Separator_Bot
			// 
			label_Separator_Bot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label_Separator_Bot.CausesValidation = false;
			label_Separator_Bot.Dock = System.Windows.Forms.DockStyle.Bottom;
			label_Separator_Bot.Location = new System.Drawing.Point(0, 251);
			label_Separator_Bot.Name = "label_Separator_Bot";
			label_Separator_Bot.Size = new System.Drawing.Size(422, 2);
			label_Separator_Bot.TabIndex = 1;
			// 
			// SettingsForm
			// 
			this.Text = global::ZsTemplate.Languages.SettingsForm.String.Title;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(613, 306);
			this.Controls.Add(this.label_Busy);
			this.Controls.Add(this.progressBar_Busy);
			this.Controls.Add(splitContainer_Dock);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.button_Cancel);
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(629, 344);
			this.Name = "SettingsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			splitContainer_Dock.Panel1.ResumeLayout(false);
			splitContainer_Dock.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(splitContainer_Dock)).EndInit();
			splitContainer_Dock.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.SplitContainer splitContainer_Dock;
		private System.Windows.Forms.Label label_Separator_Bot;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TreeView treeView_Left;
        private System.Windows.Forms.ProgressBar progressBar_Busy;
		private System.Windows.Forms.Label label_Busy;
	}
}
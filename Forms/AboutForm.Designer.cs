namespace ZsTemplate
{
    partial class AboutForm
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
            if( disposing && ( components != null ) )
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
			this.label_Separator_Top = new System.Windows.Forms.Label();
			this.label_Separator_Bottom = new System.Windows.Forms.Label();
			this.button_OK = new System.Windows.Forms.Button();
			this.pictureBox_Logo = new System.Windows.Forms.PictureBox();
			this.textBox_Dock = new System.Windows.Forms.TextBox();
			this.linkLabel_WebSite = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).BeginInit();
			this.SuspendLayout();
			// 
			// label_Separator_Top
			// 
			this.label_Separator_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Separator_Top.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_Separator_Top.Location = new System.Drawing.Point(12, 9);
			this.label_Separator_Top.Name = "label_Separator_Top";
			this.label_Separator_Top.Size = new System.Drawing.Size(261, 2);
			this.label_Separator_Top.TabIndex = 0;
			// 
			// label_Separator_Bottom
			// 
			this.label_Separator_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_Separator_Bottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_Separator_Bottom.Location = new System.Drawing.Point(14, 121);
			this.label_Separator_Bottom.Name = "label_Separator_Bottom";
			this.label_Separator_Bottom.Size = new System.Drawing.Size(261, 2);
			this.label_Separator_Bottom.TabIndex = 2;
			// 
			// button_OK
			// 
			this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_OK.Location = new System.Drawing.Point(200, 126);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 4;
			this.button_OK.Text = global::ZsTemplate.Languages.AboutForm.String.Button_OK;
			this.button_OK.UseVisualStyleBackColor = true;
			// 
			// pictureBox_Logo
			// 
			this.pictureBox_Logo.BackgroundImage = global::ZsTemplate.Properties.Resources.Zs_Logo;
			this.pictureBox_Logo.Location = new System.Drawing.Point(14, 14);
			this.pictureBox_Logo.Name = "pictureBox_Logo";
			this.pictureBox_Logo.Size = new System.Drawing.Size(64, 64);
			this.pictureBox_Logo.TabIndex = 2;
			this.pictureBox_Logo.TabStop = false;
			// 
			// textBox_Dock
			// 
			this.textBox_Dock.BackColor = System.Drawing.SystemColors.Control;
			this.textBox_Dock.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_Dock.Enabled = false;
			this.textBox_Dock.Location = new System.Drawing.Point(90, 14);
			this.textBox_Dock.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
			this.textBox_Dock.Multiline = true;
			this.textBox_Dock.Name = "textBox_Dock";
			this.textBox_Dock.Size = new System.Drawing.Size(183, 104);
			this.textBox_Dock.TabIndex = 1;
			this.textBox_Dock.TabStop = false;
			this.textBox_Dock.Text = "ZsTemplate is a product of :\r\n\r\nZs\' Logic Corporation ©  2012\r\n\r\nThis product is" +
    " licensed to :";
			// 
			// linkLabel_WebSite
			// 
			this.linkLabel_WebSite.ActiveLinkColor = System.Drawing.SystemColors.ControlDark;
			this.linkLabel_WebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel_WebSite.AutoSize = true;
			this.linkLabel_WebSite.LinkColor = System.Drawing.SystemColors.ActiveCaption;
			this.linkLabel_WebSite.Location = new System.Drawing.Point(12, 131);
			this.linkLabel_WebSite.Name = "linkLabel_WebSite";
			this.linkLabel_WebSite.Size = new System.Drawing.Size(114, 13);
			this.linkLabel_WebSite.TabIndex = 3;
			this.linkLabel_WebSite.TabStop = true;
			this.linkLabel_WebSite.Text = "Visit Zs\' Logic Website";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.label1.Location = new System.Drawing.Point(12, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "This product is licensed to ";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 161);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.linkLabel_WebSite);
			this.Controls.Add(this.textBox_Dock);
			this.Controls.Add(this.pictureBox_Logo);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.label_Separator_Bottom);
			this.Controls.Add(this.label_Separator_Top);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About...";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_Logo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Separator_Top;
        private System.Windows.Forms.Label label_Separator_Bottom;
        private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.PictureBox pictureBox_Logo;
		private System.Windows.Forms.TextBox textBox_Dock;
		private System.Windows.Forms.LinkLabel linkLabel_WebSite;
		private System.Windows.Forms.Label label1;
    }
}
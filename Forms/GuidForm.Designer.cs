namespace ZsTemplate
{
	partial class GuidForm
	{
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.LinkLabel linkLabel_ClipCopy;
		private System.Windows.Forms.CheckBox checkBox_TopMost;

		private System.ComponentModel.IContainer components = null;
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.linkLabel_ClipCopy = new System.Windows.Forms.LinkLabel();
			this.checkBox_TopMost = new System.Windows.Forms.CheckBox();
			this.linkLabel_ClipCopyAndExit = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox1.BackColor = System.Drawing.SystemColors.Window;
			this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(13, 10);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(212, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "#######################";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox2.BackColor = System.Drawing.SystemColors.Window;
			this.textBox2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(228, 10);
			this.textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(84, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "#######";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
			// 
			// linkLabel_ClipCopy
			// 
			this.linkLabel_ClipCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel_ClipCopy.AutoSize = true;
			this.linkLabel_ClipCopy.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel_ClipCopy.Location = new System.Drawing.Point(12, 33);
			this.linkLabel_ClipCopy.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.linkLabel_ClipCopy.Name = "linkLabel_ClipCopy";
			this.linkLabel_ClipCopy.Size = new System.Drawing.Size(89, 13);
			this.linkLabel_ClipCopy.TabIndex = 3;
			this.linkLabel_ClipCopy.TabStop = true;
			this.linkLabel_ClipCopy.Text = "Copy to clipboard";
			
			// 
			// checkBox_TopMost
			// 
			this.checkBox_TopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_TopMost.AutoSize = true;
			this.checkBox_TopMost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_TopMost.Checked = true;
			this.checkBox_TopMost.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_TopMost.Location = new System.Drawing.Point(228, 32);
			this.checkBox_TopMost.Name = "checkBox_TopMost";
			this.checkBox_TopMost.Size = new System.Drawing.Size(84, 17);
			this.checkBox_TopMost.TabIndex = 0;
			this.checkBox_TopMost.Text = global::ZsTemplate.Languages.GuidForm.String.TopMost;
			this.checkBox_TopMost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_TopMost.UseVisualStyleBackColor = true;
			
			// 
			// linkLabel_ClipCopyAndExit
			// 
			this.linkLabel_ClipCopyAndExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.linkLabel_ClipCopyAndExit.AutoSize = true;
			this.linkLabel_ClipCopyAndExit.LinkArea = new System.Windows.Forms.LinkArea(0, 8);
			this.linkLabel_ClipCopyAndExit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel_ClipCopyAndExit.Location = new System.Drawing.Point(98, 33);
			this.linkLabel_ClipCopyAndExit.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.linkLabel_ClipCopyAndExit.Name = "linkLabel_ClipCopyAndExit";
			this.linkLabel_ClipCopyAndExit.Size = new System.Drawing.Size(44, 13);
			this.linkLabel_ClipCopyAndExit.TabIndex = 4;
			this.linkLabel_ClipCopyAndExit.TabStop = true;
			this.linkLabel_ClipCopyAndExit.Text = "and exit";
			this.linkLabel_ClipCopyAndExit.TextAlign = System.Drawing.ContentAlignment.TopRight;
			
			// 
			// GuidForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 54);
			this.Controls.Add(this.linkLabel_ClipCopy);
			this.Controls.Add(this.linkLabel_ClipCopyAndExit);
			this.Controls.Add(this.checkBox_TopMost);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = global::ZsTemplate.Properties.Resources.Zs;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GuidForm";
			this.ShowInTaskbar = false;
			this.Text = "PBGuid of";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.LinkLabel linkLabel_ClipCopyAndExit;
	}
}
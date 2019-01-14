namespace ZsTemplate
{
	partial class ServerValidatorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
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
			this.textBox_Log = new System.Windows.Forms.TextBox();
			this.textBox_Console = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox_Log
			// 
			this.textBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Log.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox_Log.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_Log.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Log.Location = new System.Drawing.Point(12, 60);
			this.textBox_Log.Multiline = true;
			this.textBox_Log.Name = "textBox_Log";
			this.textBox_Log.ReadOnly = true;
			this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox_Log.Size = new System.Drawing.Size(852, 299);
			this.textBox_Log.TabIndex = 9;
			// 
			// textBox_Console
			// 
			this.textBox_Console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Console.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.textBox_Console.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.textBox_Console.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_Console.Location = new System.Drawing.Point(12, 365);
			this.textBox_Console.Name = "textBox_Console";
			this.textBox_Console.Size = new System.Drawing.Size(852, 21);
			this.textBox_Console.TabIndex = 10;
			// 
			// ServerValidatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 398);
			this.Controls.Add(this.textBox_Console);
			this.Controls.Add(this.textBox_Log);
			this.Name = "ServerValidatorForm";
			this.Text = "ServerValidatorForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox_Log;
		private System.Windows.Forms.TextBox textBox_Console;
	}
}
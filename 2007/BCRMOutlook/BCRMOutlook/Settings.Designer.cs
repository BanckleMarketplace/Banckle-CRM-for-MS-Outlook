namespace BCRMOutlook
{
	partial class Settings
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
			this.lblAPIKey = new System.Windows.Forms.Label();
			this.tbAPIKey = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lnkHelp = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lblAPIKey
			// 
			this.lblAPIKey.AutoSize = true;
			this.lblAPIKey.Location = new System.Drawing.Point(12, 7);
			this.lblAPIKey.Name = "lblAPIKey";
			this.lblAPIKey.Size = new System.Drawing.Size(117, 13);
			this.lblAPIKey.TabIndex = 0;
			this.lblAPIKey.Text = "Banckle CRM API Key:";
			// 
			// tbAPIKey
			// 
			this.tbAPIKey.Location = new System.Drawing.Point(12, 23);
			this.tbAPIKey.Name = "tbAPIKey";
			this.tbAPIKey.Size = new System.Drawing.Size(260, 20);
			this.tbAPIKey.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(197, 67);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 77);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 13);
			this.lblStatus.TabIndex = 3;
			// 
			// lnkHelp
			// 
			this.lnkHelp.AutoSize = true;
			this.lnkHelp.Location = new System.Drawing.Point(142, 46);
			this.lnkHelp.Name = "lnkHelp";
			this.lnkHelp.Size = new System.Drawing.Size(130, 13);
			this.lnkHelp.TabIndex = 6;
			this.lnkHelp.TabStop = true;
			this.lnkHelp.Text = "Help about CRM API Key.";
			this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 100);
			this.Controls.Add(this.lnkHelp);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.tbAPIKey);
			this.Controls.Add(this.lblAPIKey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Settings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblAPIKey;
		private System.Windows.Forms.TextBox tbAPIKey;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.LinkLabel lnkHelp;
	}
}
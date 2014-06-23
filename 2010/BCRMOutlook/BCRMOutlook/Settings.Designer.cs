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
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbBanckleId = new System.Windows.Forms.TextBox();
			this.lblBanckleId = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblAPIKey
			// 
			this.lblAPIKey.AutoSize = true;
			this.lblAPIKey.Location = new System.Drawing.Point(12, 84);
			this.lblAPIKey.Name = "lblAPIKey";
			this.lblAPIKey.Size = new System.Drawing.Size(117, 13);
			this.lblAPIKey.TabIndex = 0;
			this.lblAPIKey.Text = "Banckle CRM API Key:";
			this.lblAPIKey.Click += new System.EventHandler(this.lblAPIKey_Click);
			// 
			// tbAPIKey
			// 
			this.tbAPIKey.Location = new System.Drawing.Point(12, 100);
			this.tbAPIKey.Name = "tbAPIKey";
			this.tbAPIKey.Size = new System.Drawing.Size(260, 20);
			this.tbAPIKey.TabIndex = 3;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(197, 144);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 154);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 13);
			this.lblStatus.TabIndex = 3;
			// 
			// lnkHelp
			// 
			this.lnkHelp.AutoSize = true;
			this.lnkHelp.Location = new System.Drawing.Point(142, 123);
			this.lnkHelp.Name = "lnkHelp";
			this.lnkHelp.Size = new System.Drawing.Size(130, 13);
			this.lnkHelp.TabIndex = 6;
			this.lnkHelp.TabStop = true;
			this.lnkHelp.Text = "Help about CRM API Key.";
			this.lnkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHelp_LinkClicked);
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(12, 61);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '*';
			this.tbPassword.Size = new System.Drawing.Size(260, 20);
			this.tbPassword.TabIndex = 2;
			this.tbPassword.UseSystemPasswordChar = true;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(12, 45);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(56, 13);
			this.lblPassword.TabIndex = 7;
			this.lblPassword.Text = "Password:";
			// 
			// tbBanckleId
			// 
			this.tbBanckleId.Location = new System.Drawing.Point(12, 22);
			this.tbBanckleId.Name = "tbBanckleId";
			this.tbBanckleId.Size = new System.Drawing.Size(260, 20);
			this.tbBanckleId.TabIndex = 1;
			this.tbBanckleId.TextChanged += new System.EventHandler(this.tbBanckleId_TextChanged);
			// 
			// lblBanckleId
			// 
			this.lblBanckleId.AutoSize = true;
			this.lblBanckleId.Location = new System.Drawing.Point(12, 6);
			this.lblBanckleId.Name = "lblBanckleId";
			this.lblBanckleId.Size = new System.Drawing.Size(93, 13);
			this.lblBanckleId.TabIndex = 9;
			this.lblBanckleId.Text = "Banckle ID/Email:";
			this.lblBanckleId.Click += new System.EventHandler(this.lblBanckleId_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 192);
			this.Controls.Add(this.tbBanckleId);
			this.Controls.Add(this.lblBanckleId);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.lblPassword);
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
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox tbBanckleId;
		private System.Windows.Forms.Label lblBanckleId;
	}
}
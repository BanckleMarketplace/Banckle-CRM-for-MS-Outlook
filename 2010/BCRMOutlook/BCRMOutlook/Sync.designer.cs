namespace BCRMOutlook
{
	partial class Sync
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sync));
			this.lblSync = new System.Windows.Forms.Label();
			this.tbSync = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblSync
			// 
			this.lblSync.AutoSize = true;
			this.lblSync.Location = new System.Drawing.Point(2, 9);
			this.lblSync.Name = "lblSync";
			this.lblSync.Size = new System.Drawing.Size(63, 13);
			this.lblSync.TabIndex = 0;
			this.lblSync.Text = "Sync Done!";
			this.lblSync.Click += new System.EventHandler(this.lblSync_Click);
			// 
			// tbSync
			// 
			this.tbSync.Location = new System.Drawing.Point(5, 46);
			this.tbSync.Multiline = true;
			this.tbSync.Name = "tbSync";
			this.tbSync.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSync.Size = new System.Drawing.Size(10, 10);
			this.tbSync.TabIndex = 1;
			this.tbSync.TextChanged += new System.EventHandler(this.tbSync_TextChanged);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(136, 4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// Sync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(214, 31);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tbSync);
			this.Controls.Add(this.lblSync);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Sync";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sync";
			this.Load += new System.EventHandler(this.Sync_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label lblSync;
		public System.Windows.Forms.TextBox tbSync;
		private System.Windows.Forms.Button btnOk;



	}
}
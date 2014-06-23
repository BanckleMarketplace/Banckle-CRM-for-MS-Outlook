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
			this.SuspendLayout();
			// 
			// lblSync
			// 
			this.lblSync.AutoSize = true;
			this.lblSync.Location = new System.Drawing.Point(2, 9);
			this.lblSync.Name = "lblSync";
			this.lblSync.Size = new System.Drawing.Size(40, 13);
			this.lblSync.TabIndex = 0;
			this.lblSync.Text = "Sync...";
			// 
			// Sync
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 40);
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



	}
}
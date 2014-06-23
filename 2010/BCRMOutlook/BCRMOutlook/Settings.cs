using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCRMOutlook
{
	public partial class Settings : Form
	{

		//Banckle.AuthDetails 

		public Settings()
		{
			InitializeComponent();
			tbAPIKey.Text = Properties.Settings.Default.APIKey;
			tbBanckleId.Text = Properties.Settings.Default.Id;
			tbPassword.Text = Properties.Settings.Default.Password;

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			Banckle.Auth auth = new Banckle.Auth();
			auth.APIKey = String.IsNullOrEmpty(tbAPIKey.Text) ? "xxxxxx" : tbAPIKey.Text;
			auth.getToken(String.IsNullOrEmpty(tbBanckleId.Text) ? "xxxxxx" : tbBanckleId.Text, String.IsNullOrEmpty(tbPassword.Text) ? "xxxxxx" : tbPassword.Text);
			
			lblStatus.Text = "Connecting to Banckle...";
			if (auth.authenticate(tbBanckleId.Text, tbPassword.Text))
			{
				lblStatus.Text = "Connected!";
				Properties.Settings.Default.APIKey = auth.APIKey;
				Properties.Settings.Default.Id = tbBanckleId.Text;
				Properties.Settings.Default.Password = tbPassword.Text;
				Properties.Settings.Default.Save();
				lblStatus.Text = "Saved!";
			}
			else
			{
				lblStatus.Text = "Authentication faild :(";
				MessageBox.Show("Authentication faild :(", "Authentication");
			}

			this.Dispose();
		}

		private void Settings_Load(object sender, EventArgs e)
		{
			//LinkLabel.Link CRMAPIKeyLink = new LinkLabel.Link();
			//CRMAPIKeyLink.LinkData = "http://banckle.com/wiki/display/crm/how-to-edit-accounts-and-users-settings.html";
			//lnkHelp.Links.Add(CRMAPIKeyLink);
		}

		private void lnkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://banckle.com/wiki/display/crm/how-to-edit-accounts-and-users-settings.html");
		}

		private void btnSave_KeyDown(object sender, KeyEventArgs e)
		{
			lblStatus.Text = "Connecting to Banckle...";
		}

		private void lblAPIKey_Click(object sender, EventArgs e)
		{

		}

		private void lblBanckleId_Click(object sender, EventArgs e)
		{

		}

		private void tbBanckleId_TextChanged(object sender, EventArgs e)
		{

		}
	}
}

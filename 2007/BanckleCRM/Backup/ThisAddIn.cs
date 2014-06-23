using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

using Banckle;

namespace BCRMOutlook
{
    public partial class ThisAddIn
    {
		//private void ThisAddIn_Startup(object sender, System.EventArgs e)
		//{
		//    System.Windows.Forms.MessageBox.Show("Hello");
		//}

		Office.CommandBar newToolBar;
		Office.CommandBarButton firstButton;
		Office.CommandBarButton secondButton;
		Outlook.Explorers selectExplorers;

		Banckle.Contacts contacts = new Banckle.Contacts();

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{

			selectExplorers = this.Application.Explorers;
			selectExplorers.NewExplorer += new Outlook
				.ExplorersEvents_NewExplorerEventHandler(newExplorer_Event);
			AddToolbar();
			
		}


		private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
		{
		}


		private void newExplorer_Event(Outlook.Explorer new_Explorer)
		{
			((Outlook._Explorer)new_Explorer).Activate();
			newToolBar = null;
			AddToolbar();
		}

		private void AddToolbar()
		{

			if (newToolBar == null)
			{
				Office.CommandBars cmdBars =
					this.Application.ActiveExplorer().CommandBars;
				newToolBar = cmdBars.Add("NewToolBar",
					Office.MsoBarPosition.msoBarTop, false, true);
			}
			try
			{
				Office.CommandBarButton btnBanckleContacts =
					(Office.CommandBarButton)newToolBar.Controls
					.Add(1, missing, missing, missing, missing);
				btnBanckleContacts.Style = Office
					.MsoButtonStyle.msoButtonCaption;
				btnBanckleContacts.Caption = "Banckle Contacts";
				btnBanckleContacts.Tag = "BanckleContacts";
				if (this.firstButton == null)
				{
					this.firstButton = btnBanckleContacts;
					firstButton.Click += new Office.
						_CommandBarButtonEvents_ClickEventHandler
						(ButtonClick);
				}

				Office.CommandBarButton OutlookContacts = (Office
					.CommandBarButton)newToolBar.Controls.Add
					(1, missing, missing, missing, missing);
				OutlookContacts.Style = Office
					.MsoButtonStyle.msoButtonCaption;
				OutlookContacts.Caption = "Button 2";
				OutlookContacts.Tag = "Button2";
				newToolBar.Visible = true;
				if (this.secondButton == null)
				{
					this.secondButton = OutlookContacts;
					secondButton.Click += new Office.
						_CommandBarButtonEvents_ClickEventHandler
						(ButtonClick);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonClick(Office.CommandBarButton ctrl,
				ref bool cancel)
		{
			//MessageBox.Show("You clicked: " + ctrl.Caption);
			if (ctrl.Caption == "Banckle Contacts")
			{
				MessageBox.Show(GetBanckleContacts());
			}
			else
			{
				if (ctrl.Caption == "Outlook Contacts")
				{
					MessageBox.Show(AccessContacts());
				}
			}
		}

		private string GetBanckleContacts() 
		{
			string Names = "";

			for (int i = 0; i < contacts.GetContacts().Count; i++)
			{
				Names += contacts.GetContacts()[i].name + "\n";
			}

			return Names;
		}

		private string AccessContacts()
		{
			Outlook.MAPIFolder folderContacts = this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
			Outlook.Items searchFolder = folderContacts.Items;

			//Outlook.AddressLists folders = this.Application.ActiveExplorer().Session.AddressLists;

			String Names = "-----Folders------\n";

			//for (int i = 0; i < folders.Count; i++) {

			//    Names += folders[i].Name + "\n";
			//}

			Names += "-----Contacts------\n";
			
			foreach (Outlook.ContactItem foundContact in searchFolder)
			{
				Names += foundContact.FirstName + " " + foundContact.LastName + "\n";
			}
			return Names;
		}


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

/*
 * for office 2010
 *  
 */

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
		Office.CommandBar newToolBar;
		Microsoft.Office.Core.CommandBarButton btnSync;
		Microsoft.Office.Core.CommandBarButton btnSettings;
		Microsoft.Office.Core.CommandBarButton btnBanckle;
		Microsoft.Office.Core.CommandBarButton btnAbout;

		Outlook.Explorers selectExplorers;

		Banckle.Contacts contacts = new Banckle.Contacts();

		private void ThisAddIn_Startup(object sender, System.EventArgs e)
		{

			selectExplorers = this.Application.Explorers;
			selectExplorers.NewExplorer += new Outlook.ExplorersEvents_NewExplorerEventHandler(newExplorer_Event);

			Banckle.Auth ath = new Banckle.Auth();
			ath.APIKey = Properties.Settings.Default.APIKey;

			contacts.APIKey = Properties.Settings.Default.APIKey;
			contacts.Token = ath.getToken(Properties.Settings.Default.Id, Properties.Settings.Default.Password);

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
				Office.CommandBars cmdBars = this.Application.ActiveExplorer().CommandBars;
				//cmdBars.
				newToolBar = cmdBars.Add("Banckle CRM", Office.MsoBarPosition.msoBarTop, false, true);
			}
			try
			{

				//Office.

				btnBanckle = (Office.CommandBarButton)newToolBar.Controls.Add(1, missing, missing, missing, missing);
				btnBanckle.Style = Office.MsoButtonStyle.msoButtonIcon;
				btnBanckle.Caption = "Banckle CRM";
				btnBanckle.Tag = "Banckle CRM";
				btnBanckle.Picture = getImage(Properties.Resources.crm_16x16);
				btnBanckle.Click += new Office._CommandBarButtonEvents_ClickEventHandler(btnBanckleClick);


				btnSync = (Office.CommandBarButton)newToolBar.Controls.Add(1, missing, missing, missing, missing);
				btnSync.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
				btnSync.Caption = "Sync";
				btnSync.Tag = "Sync";
				btnSync.Picture = getImage(Properties.Resources.sync_16x16);
				btnSync.BeginGroup = true;
				btnSync.Click += new Office._CommandBarButtonEvents_ClickEventHandler(btnSyncClick);


				btnSettings = (Office.CommandBarButton)newToolBar.Controls.Add(1, missing, missing, missing, missing);
				btnSettings.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
				btnSettings.Caption = "Settings";
				btnSettings.Picture = getImage(Properties.Resources.settings_16x16);
				btnSettings.Tag = "Settings";
				newToolBar.Visible = true;
				btnSettings.Click += new Office._CommandBarButtonEvents_ClickEventHandler(btnSettingsClick);

				btnAbout = (Office.CommandBarButton)newToolBar.Controls.Add(1, missing, missing, missing, missing);
				btnAbout.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
				btnAbout.Caption = "About";
				btnAbout.Picture = getImage(Properties.Resources.banckle_16x16);
				btnAbout.BeginGroup = true;
				btnAbout.Tag = "About";
				btnAbout.Visible = true;
				btnAbout.Click += new Office._CommandBarButtonEvents_ClickEventHandler(btnAboutClick);


			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Error:" + ex.Message, "Error");
			}
		}

		private stdole.IPictureDisp getImage(System.Drawing.Image newImage)
		{
			stdole.IPictureDisp tempImage = null;
			try
			{

				System.Windows.Forms.ImageList newImageList = new System.Windows.Forms.ImageList();
				newImageList.Images.Add(newImage);
				tempImage = ConvertImage.Convert(newImageList.Images[0]);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return tempImage;
		}
		private stdole.IPictureDisp getIcon(System.Drawing.Icon newIcon)
		{
			stdole.IPictureDisp tempImage = null;
			try
			{

				System.Windows.Forms.ImageList newImageList = new System.Windows.Forms.ImageList();
				newImageList.Images.Add(newIcon);
				tempImage = ConvertImage.Convert(newImageList.Images[0]);
			}
			catch (Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			return tempImage;
		}

		private bool IsEmailExist(string emailAddress)
		{

			bool found = false;
			Outlook.NameSpace outlookNameSpace = this.Application.GetNamespace("MAPI");
			Outlook.MAPIFolder contactsFolder =
				 outlookNameSpace.GetDefaultFolder(
				 Microsoft.Office.Interop.Outlook.
				 OlDefaultFolders.olFolderContacts);

			Outlook.Items contactItems = contactsFolder.Items;

			try
			{
				Outlook.ContactItem contact =
					 (Outlook.ContactItem)contactItems.
					 Find(String.Format("[Email1Address]='{0}' or " + "[Email2Address]='{0}'or " + "[Email2Address]='{0}'", emailAddress));
				if (contact != null) found = true; else found = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return found;
		}

		private bool IsContactExist(string FullName)
		{

			bool found = false;
			Outlook.NameSpace outlookNameSpace = this.Application.GetNamespace("MAPI");
			Outlook.MAPIFolder contactsFolder =
				 outlookNameSpace.GetDefaultFolder(
				 Microsoft.Office.Interop.Outlook.
				 OlDefaultFolders.olFolderContacts);

			Outlook.Items contactItems = contactsFolder.Items;

			try
			{
				Outlook.ContactItem contact =
					 (Outlook.ContactItem)contactItems.
					 Find(String.Format("[FullName]='{0}'", FullName));
				if (contact != null) found = true; else found = false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return found;
		}

		private void btnSyncClick(Office.CommandBarButton ctrl, ref bool cancel)
		{
			//System.Windows.Forms.MessageBox.Show("Syncing with Outlook plz wait","Banckle Contacts");
			SyncContacts();
		}

		private void btnAddContactClick(Office.CommandBarButton ctrl, ref bool cancel)
		{

		}
		private void btnSettingsClick(Office.CommandBarButton ctrl, ref bool cancel)
		{
			Settings settings = new Settings();
			settings.Show();
		}

		private void btnAboutClick(Office.CommandBarButton ctrl, ref bool cancel)
		{
			About about = new About();
			about.Show();
		}

		private void btnBanckleClick(Office.CommandBarButton ctrl, ref bool cancel)
		{
			System.Diagnostics.Process.Start("https://crm.banckle.com/");
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

		private void SyncBanckleContacts()
		{
			//for (int i = 0; i < contacts.GetContacts().Count; i++)
			//{
			//    AddOutlookContact(contacts.GetContacts()[i].name, "", contacts.GetContacts()[i].emails[0].addresses,"",);
			//}
		}

		private void SyncContacts()
		{

			if (String.IsNullOrEmpty(Properties.Settings.Default.APIKey))
			{
				Settings settings = new Settings();
				settings.Show();
				return;
			}
			Banckle.Auth auth = new Banckle.Auth();
			auth.APIKey = Properties.Settings.Default.APIKey;
			if (!auth.authenticate(Properties.Settings.Default.Id, Properties.Settings.Default.Password))
			{
				Settings settings = new Settings();
				settings.Show();
				return;
			}

			Outlook.MAPIFolder folderContacts = this.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
			Outlook.Items searchFolder = folderContacts.Items;

			Sync sync = new Sync();

			try
			{

				
				//sync.tbSync.Text += "Starting the sync\n";

				//Outlook.AddressLists folders = this.Application.ActiveExplorer().Session.AddressLists;

				foreach (Outlook.ContactItem foundContact in searchFolder)
				{
					sync.tbSync.Text += "Copying " + foundContact.FirstName + " " + foundContact.LastName + "\n";
					//System.Windows.Forms.MessageBox.Show(contacts.CreatePerson(OutlookToBanckleContact(foundContact)),"Contact Status");
					contacts.CreatePerson(OutlookToBanckleContact(foundContact));
					//System.Windows.Forms.MessageBox.Show("Adding the person: " + contacts.CreatePerson(OutlookToBanckleContact(foundContact)) , "Contact Status");
					//OutlookToBanckleContact(foundContact);
				}
			}catch(Exception ex){
				//sync.tbSync.Text += "Error 1 :" + ex.Message + "\n" + ex.StackTrace + "\n";
			}
			try{
				//contacts = new Banckle.Contacts();
				List<ContactDetails> contactDetails = contacts.GetContacts();
				//bool foundEmail = false;
				foreach (ContactDetails foundBCRMContact in contactDetails)
				{
					//sync.tbSync.Text += "Copying " + foundBCRMContact.name + "\n";

					if (IsContactExist(foundBCRMContact.name))
					{
						continue;
					}

					//for (int i = 0; i < foundBCRMContact.emails.Length; i++)
					//{
					//   if (String.IsNullOrEmpty(foundBCRMContact.emails[i].address)) 
					//      continue;
					//   if (IsEmailExist(foundBCRMContact.emails[i].address))
					//   {
					//      foundEmail = true;
					//      //break;
					//   }
					//}
					//if (foundEmail) {
					//   continue; 
					//}
					AddOutlookContact(foundBCRMContact);
				}
			}
			catch (Exception ex)
			{
				sync.tbSync.Text += "Error 2 :" + ex.Message + "\n" + ex.StackTrace + "\n";
			}
			sync.Show();
			//sync.Dispose();
			//sync.Close();
		}
		private void AddOutlookContact(Banckle.ContactDetails contact)
		{
			Outlook.ContactItem newContact = (Outlook.ContactItem)this.Application.CreateItem(Outlook.OlItemType.olContactItem);

			Banckle.Email[] emails = new Email[3];
			Banckle.Phone[] phone = new Banckle.Phone[2];
			Banckle.Address[] address = new Banckle.Address[3];
			try
			{
				newContact.FullName = String.IsNullOrWhiteSpace(contact.name) ? "" : contact.name;

				if (contact.emails.Length > 0)
				{
					if (contact.emails.Length >= 3)
					{
						newContact.Email1AddressType = String.IsNullOrWhiteSpace(contact.emails[0].type) ? "" : contact.emails[0].type;
						newContact.Email1Address = String.IsNullOrWhiteSpace(contact.emails[0].address) ? "" : contact.emails[0].address;

						newContact.Email2AddressType = String.IsNullOrWhiteSpace(contact.emails[1].type) ? "" : contact.emails[1].type;
						newContact.Email2Address = String.IsNullOrWhiteSpace(contact.emails[1].address) ? "" : contact.emails[1].address;

						newContact.Email3AddressType = String.IsNullOrWhiteSpace(contact.emails[2].type) ? "" : contact.emails[2].type;
						newContact.Email3Address = String.IsNullOrWhiteSpace(contact.emails[2].address) ? "" : contact.emails[2].address;

					}
					if (contact.emails.Length == 2)
					{
						newContact.Email1AddressType = String.IsNullOrWhiteSpace(contact.emails[0].type) ? "" : contact.emails[0].type;
						newContact.Email1Address = String.IsNullOrWhiteSpace(contact.emails[0].address) ? "" : contact.emails[0].address;

						newContact.Email2AddressType = String.IsNullOrWhiteSpace(contact.emails[1].type) ? "" : contact.emails[1].type;
						newContact.Email2Address = String.IsNullOrWhiteSpace(contact.emails[1].address) ? "" : contact.emails[1].address;

					}
					if (contact.emails.Length == 1)
					{
						newContact.Email1AddressType = String.IsNullOrWhiteSpace(contact.emails[0].type) ? "" : contact.emails[0].type;
						newContact.Email1Address = String.IsNullOrWhiteSpace(contact.emails[0].address) ? "" : contact.emails[0].address;

					}
				}


				if (contact.phones.Length > 0)
				{
					if (contact.phones.Length >= 2)
					{
						newContact.PrimaryTelephoneNumber = String.IsNullOrWhiteSpace(contact.phones[0].number) ? "" : contact.phones[0].number;
						newContact.OtherTelephoneNumber = String.IsNullOrWhiteSpace(contact.phones[1].number) ? "" : contact.phones[1].number;
					}
					if (contact.phones.Length == 1)
					{
						newContact.PrimaryTelephoneNumber = String.IsNullOrWhiteSpace(contact.phones[0].number) ? "" : contact.phones[0].number;
					}
				}

				if (contact.addresses.Length > 0)
				{
					if (contact.addresses.Length >= 3)
					{
						newContact.MailingAddress = String.IsNullOrWhiteSpace(contact.addresses[0].building) ? "" : contact.addresses[0].building;
						newContact.MailingAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[0].street) ? "" : contact.addresses[0].street;
						newContact.MailingAddressCity = String.IsNullOrWhiteSpace(contact.addresses[0].city) ? "" : contact.addresses[0].city;
						newContact.MailingAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[0].zip) ? "" : contact.addresses[0].zip;
						newContact.MailingAddressState = String.IsNullOrWhiteSpace(contact.addresses[0].state) ? "" : contact.addresses[0].state;
						newContact.MailingAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[0].country) ? "" : contact.addresses[0].country;

						newContact.HomeAddress = String.IsNullOrWhiteSpace(contact.addresses[1].building) ? "" : contact.addresses[1].building;
						newContact.HomeAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[1].street) ? "" : contact.addresses[1].street;
						newContact.HomeAddressCity = String.IsNullOrWhiteSpace(contact.addresses[1].city) ? "" : contact.addresses[1].city;
						newContact.HomeAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[1].zip) ? "" : contact.addresses[1].zip;
						newContact.HomeAddressState = String.IsNullOrWhiteSpace(contact.addresses[1].state) ? "" : contact.addresses[1].state;
						newContact.HomeAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[1].country) ? "" : contact.addresses[1].country;

						newContact.OtherAddress = String.IsNullOrWhiteSpace(contact.addresses[2].building) ? "" : contact.addresses[2].building;
						newContact.OtherAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[2].street) ? "" : contact.addresses[2].street;
						newContact.OtherAddressCity = String.IsNullOrWhiteSpace(contact.addresses[2].city) ? "" : contact.addresses[2].city;
						newContact.OtherAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[2].zip) ? "" : contact.addresses[2].zip;
						newContact.OtherAddressState = String.IsNullOrWhiteSpace(contact.addresses[2].state) ? "" : contact.addresses[2].state;
						newContact.OtherAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[2].country) ? "" : contact.addresses[2].country;
					}
					if (contact.addresses.Length == 2)
					{
						newContact.MailingAddress = String.IsNullOrWhiteSpace(contact.addresses[0].building) ? "" : contact.addresses[0].building;
						newContact.MailingAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[0].street) ? "" : contact.addresses[0].street;
						newContact.MailingAddressCity = String.IsNullOrWhiteSpace(contact.addresses[0].city) ? "" : contact.addresses[0].city;
						newContact.MailingAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[0].zip) ? "" : contact.addresses[0].zip;
						newContact.MailingAddressState = String.IsNullOrWhiteSpace(contact.addresses[0].state) ? "" : contact.addresses[0].state;
						newContact.MailingAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[0].country) ? "" : contact.addresses[0].country;

						newContact.HomeAddress = String.IsNullOrWhiteSpace(contact.addresses[1].building) ? "" : contact.addresses[1].building;
						newContact.HomeAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[1].street) ? "" : contact.addresses[1].street;
						newContact.HomeAddressCity = String.IsNullOrWhiteSpace(contact.addresses[1].city) ? "" : contact.addresses[1].city;
						newContact.HomeAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[1].zip) ? "" : contact.addresses[1].zip;
						newContact.HomeAddressState = String.IsNullOrWhiteSpace(contact.addresses[1].state) ? "" : contact.addresses[1].state;
						newContact.HomeAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[1].country) ? "" : contact.addresses[1].country;
					}
					if (contact.addresses.Length == 1)
					{
						newContact.MailingAddress = String.IsNullOrWhiteSpace(contact.addresses[0].building) ? "" : contact.addresses[0].building;
						newContact.MailingAddressStreet = String.IsNullOrWhiteSpace(contact.addresses[0].street) ? "" : contact.addresses[0].street;
						newContact.MailingAddressCity = String.IsNullOrWhiteSpace(contact.addresses[0].city) ? "" : contact.addresses[0].city;
						newContact.MailingAddressPostalCode = String.IsNullOrWhiteSpace(contact.addresses[0].zip) ? "" : contact.addresses[0].zip;
						newContact.MailingAddressState = String.IsNullOrWhiteSpace(contact.addresses[0].state) ? "" : contact.addresses[0].state;
						newContact.MailingAddressCountry = String.IsNullOrWhiteSpace(contact.addresses[0].country) ? "" : contact.addresses[0].country;
					}
				}

				newContact.Save();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("The new contact was not saved, because \r" + ex.Message + "\r" + ex.StackTrace);
			}

		}

		private Banckle.Person OutlookToBanckleContact(Outlook.ContactItem contact)
		{
			Banckle.Person person = new Banckle.Person();
			Banckle.Email[] emails = new Email[3];
			Banckle.Phone[] phone = new Banckle.Phone[15];
			Banckle.Address[] address = new Banckle.Address[4];

			try
			{
				person.birthDay = String.IsNullOrWhiteSpace(contact.Birthday.ToString("dd:MM:yyyy")) ? "" : contact.Birthday.ToString("dd:MM:yyyy");
				person.firstName = String.IsNullOrWhiteSpace(contact.FirstName) ? "" : contact.FirstName;
				person.lastName = String.IsNullOrEmpty(contact.LastName) ? "" : contact.LastName;
				//person.lastName = "";

				/*
				 * Emails
				 */

				emails[0] = new Email { type = "Primary", address = contact.Email1Address };
				emails[1] = new Email { type = "Secondary", address = contact.Email2Address };
				emails[2] = new Email { type = "Tertiary", address = contact.Email3Address };

				/*
				 * Phone Numbers
				 */

				phone[0] = new Phone { type = "Business2TelephoneNumber", number = contact.Business2TelephoneNumber };
				phone[1] = new Phone { type = "BusinessFaxNumber", number = contact.BusinessFaxNumber };
				phone[2] = new Phone { type = "BusinessTelephoneNumber", number = contact.BusinessTelephoneNumber };
				phone[3] = new Phone { type = "CallbackTelephoneNumber", number = contact.CallbackTelephoneNumber };
				phone[4] = new Phone { type = "CarTelephoneNumber", number = contact.CarTelephoneNumber };
				phone[5] = new Phone { type = "AssistantTelephoneNumber", number = contact.AssistantTelephoneNumber };
				phone[6] = new Phone { type = "CompanyMainTelephoneNumber", number = contact.CompanyMainTelephoneNumber };
				phone[7] = new Phone { type = "Home2TelephoneNumber", number = contact.Home2TelephoneNumber };
				phone[8] = new Phone { type = "HomeFaxNumber", number = contact.HomeFaxNumber };
				phone[9] = new Phone { type = "HomeTelephoneNumber", number = contact.HomeTelephoneNumber };
				phone[10] = new Phone { type = "MobileTelephoneNumber", number = contact.MobileTelephoneNumber };
				phone[11] = new Phone { type = "OtherFaxNumber", number = contact.OtherFaxNumber };
				phone[12] = new Phone { type = "OtherTelephoneNumber", number = contact.OtherTelephoneNumber };
				phone[13] = new Phone { type = "PrimaryTelephoneNumber", number = contact.PrimaryTelephoneNumber };
				phone[14] = new Phone { type = "RadioTelephoneNumber", number = contact.RadioTelephoneNumber };

				/*
				 * addresses
				 */

				address[0] = new Address { type = "Mailing", building = contact.MailingAddress, street = contact.MailingAddressStreet, city = contact.MailingAddressCity, state = contact.MailingAddressState, zip = contact.MailingAddressPostalCode, country = contact.MailingAddressCountry };
				address[1] = new Address { type = "Home", building = contact.HomeAddress, street = contact.HomeAddressStreet, city = contact.HomeAddressCity, state = contact.HomeAddressState, zip = contact.HomeAddressPostalCode, country = contact.HomeAddressCountry };
				address[2] = new Address { type = "Business", building = contact.BusinessAddress, street = contact.BusinessAddressStreet, city = contact.BusinessAddressCity, state = contact.BusinessAddressState, zip = contact.BusinessAddressPostalCode, country = contact.BusinessAddressCountry };
				address[3] = new Address { type = "Other", building = contact.OtherAddress, street = contact.OtherAddressStreet, city = contact.OtherAddressCity, state = contact.OtherAddressState, zip = contact.OtherAddressPostalCode, country = contact.OtherAddressCountry };

				person.emails = emails;
				person.phones = phone;
				person.addresses = address;

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("The new contact was not saved, because \r" + ex.Message + "\r" + ex.StackTrace);
			}
			return person;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace WorkingWithContactsAndTasksInOutlook
{
    public partial class TakeAMessageForm : Form
    {
        ThisApplication parent;
        Outlook.ItemEvents_10_WriteEventHandler contactSavedHandler;
        List<string> contactsList = new List<string>();
        Outlook.ContactItem newContact;
        const string DEFAULT_CONTACT = "<Please select a contact>";

        public TakeAMessageForm( ThisApplication parent )
        {
            InitializeComponent();

            this.parent = parent;

            // Create a resuable event handler for new contacts
            contactSavedHandler =
                new Outlook.ItemEvents_10_WriteEventHandler(newContact_Write);
        }

        /// <summary>
        /// Iterates through all contact items in the Contacts folder.
        /// Each entry is added to a List object for display in the
        /// combo box.
        /// </summary>
        private void ReadContacts()
        {
            // Disconnect data source so it rebinds after changes.
            contactsComboBox.DataSource = null; 
            
            // Clear the list and add a default item
            contactsList.Clear();
            contactsList.Add(DEFAULT_CONTACT);

            // Get the Contacts folder.
            Outlook.MAPIFolder contacts =
                parent.ActiveExplorer().Session.GetDefaultFolder(
                Outlook.OlDefaultFolders.olFolderContacts);

            // Add each contact to a List of strings
            foreach (Outlook.ContactItem contact in contacts.Items)
            {
                contactsList.Add(contact.FullName);
            }

            // Work-around since contact is not yet filed when its
            // save event fires.
            if (newContact != null)
            {
                contactsList.Add(newContact.FullName);
            }

            // Set the data source to force a rebind.
            contactsComboBox.DataSource = contactsList;
            contactsComboBox.Text = DEFAULT_CONTACT;
        }

        /// <summary>
        /// Responds to the Click even of the New Contact button.
        /// Creates a new contact, registers to know when it is
        /// saved, then displays it modally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newContactButton_Click(object sender, EventArgs e)
        {
            newContact = (Outlook.ContactItem)
                Globals.ThisApplication.CreateItem(
                Microsoft.Office.Interop.Outlook.OlItemType.olContactItem);

            newContact.Write += contactSavedHandler;

            newContact.Display(false);
        }

        /// <summary>
        /// Event handler invoked when a new contact is saved.
        /// Updates the ComboBox and auto-selects the new contact.
        /// </summary>
        /// <param name="Cancel"></param>
        void newContact_Write(ref bool Cancel)
        {
            ReadContacts();
            contactsComboBox.Text = newContact.FullName;
            newContact.Write -= contactSavedHandler;
            newContact = null;
        }

        /// <summary>
        /// Hides the form when the Cancel button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Creates a new task using the contact, body, and callback
        /// date entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (contactsComboBox.SelectedIndex > 0)
            {
                // .NET 2.0 supports nullable value types.  This provides
                // a very clean method of determining if a value field
                // has been assigned a value yet.
                DateTime? callbackDate = null;

                try
                {
                    if (callbackDateTextBox.Text.Length > 6)
                    {
                        callbackDate = DateTime.Parse(callbackDateTextBox.Text);
                        if (callbackDate.Value.Year < 1601 || callbackDate.Value.Year > 4499)
                        {
                            throw new Exception("Outlook does not support years before 1601 or beyond 4499");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter a valid callback date between the years 1601 and 4499 (or clear the field)");
                    return;
                }

                Outlook.TaskItem newTask = (Outlook.TaskItem)
                    Globals.ThisApplication.CreateItem(
                    Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem);

                newTask.Subject = string.Format("Message from {0}", contactsComboBox.Text);
                newTask.Body = messageTextBox.Text;
                
                newTask.Contacts = contactsComboBox.Text;

                // Set a due date if specified.  Nullable fields have properties
                // to determine whether or not a value has been assigned, and to
                // retrieve the underlying value object.
                if (callbackDate.HasValue)
                {
                    newTask.DueDate = callbackDate.Value;
                }

                newTask.Save();

                this.Visible = false;
            }
        }

        /// <summary>
        /// Responds to the ComboBox selected index being changed.
        /// If a contact is selected, then Save button is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contactsComboBox.Text == DEFAULT_CONTACT)
            {
                saveButton.Enabled = false;
            }
            else
            {
                saveButton.Enabled = true;
            }
        }

        /// <summary>
        /// Reset the form whenever shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeAMessageForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ReadContacts();
                messageTextBox.Text = "";
                callbackDateTextBox.Text = "";
                newContact = null;
            }
        }
    }
}
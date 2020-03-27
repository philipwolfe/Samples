using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace IntegratingWindowsFormsIntoOutlook
{
    public partial class CustomMailTemplateForm : Form
    {
        ThisApplication parent;
        List<string> customersList = new List<string>();
        const string DEFAULT_CONTACT = "<Please select a customer>";

        public CustomMailTemplateForm(ThisApplication parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        /// <summary>
        /// Iterates through all contact items in the Contacts folder.
        /// Each entry is added to a List object for display in the
        /// combo box.
        /// </summary>
        private void ReadContacts()
        {
            // Disconnect data source so it rebinds after changes.
            customerComboBox.DataSource = null;

            // Clear the list and add a default item
            customersList.Clear();
            customersList.Add(DEFAULT_CONTACT);

            // Get the Contacts folder.
            Outlook.MAPIFolder contacts =
                parent.ActiveExplorer().Session.GetDefaultFolder(
                Outlook.OlDefaultFolders.olFolderContacts);

            // Add each contact to a List of strings
            foreach (Outlook.ContactItem contact in contacts.Items)
            {
                customersList.Add(contact.FullName);
            }

            // Set the data source to force a rebind.
            customerComboBox.DataSource = customersList;
            customerComboBox.Text = DEFAULT_CONTACT;
        }

        /// <summary>
        /// When the user clicks the Send button, a new mail
        /// message and task item are created and populated
        /// based on the entered values.  The task is then
        /// saved, and the mail message is moved to the Outbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendMailButton_Click(object sender, EventArgs e)
        {
            DateTime dueDate;

            if (customerComboBox.SelectedIndex > 0 &&
                dueDateTextBox.Text.Length == 10 &&
                amountTextBox.Text.Length > 0)
            {
                try
                {
                    dueDate = DateTime.Parse(dueDateTextBox.Text);

                    if (dueDate.Year < 1601 || dueDate.Year > 4499)
                    {
                        throw new Exception("Outlook does not support years before 1601 or beyond 4499");
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter a valid due date");
                    return;
                }

                string message = string.Format(
                    "According to our records, you are currently delinquent " +
                    "in the amount of {0:c}.  Please remit the full amount " +
                    "by {1:d} to prevent further collections activity.\n\n{2}",
                    Double.Parse(amountTextBox.Text),
                    dueDate, messageTextBox.Text);

                Outlook.TaskItem newTask = (Outlook.TaskItem)
                    Globals.ThisApplication.CreateItem(
                    Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem);

                newTask.Subject = "Delinquent account followup";
                newTask.Body = string.Format(
                    "Delinquent amount: {0:c}\n\nYou wrote: {1}",
                    Double.Parse(amountTextBox.Text), messageTextBox.Text);

                newTask.Contacts = customerComboBox.Text;

                // Set the due date                
                newTask.DueDate = dueDate;

                newTask.Save();

                Outlook.MailItem newMail = (Outlook.MailItem)
                    Globals.ThisApplication.CreateItem(
                    Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                newMail.To = customerComboBox.Text;
                newMail.Subject = "Delinquent account notice";
                newMail.Body = message;
                newMail.Move(parent.ActiveExplorer().Session.GetDefaultFolder(
                    Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderOutbox));
                
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("All fields are required.");
            }
        }

        /// <summary>
        /// Hides the form when the Cancel button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelMailButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Resets the fields whenever the form is shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMailTemplateForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                ReadContacts();
                dueDateTextBox.Text = "";
                messageTextBox.Text = "";
                amountTextBox.Text = "";
            }
        }
    }
}
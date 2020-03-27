using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace WorkingWithTheInbox
{
    public partial class ThisApplication
    {

        private void ThisApplication_Startup(object sender, System.EventArgs e)
        {
            // The NewMailEx handler was introduced in Outlook 2003 to replace
            // the previous NewMail event.  NewMailEx adds the EntryID
            // parameter to make it easier to take action based on a specific
            // new message.
            this.NewMailEx += new Outlook.ApplicationEvents_11_NewMailExEventHandler(
                ThisApplication_NewMailEx);
        }

        /// <summary>
        /// NewMailEx will fire for each new message.  The EntryID will
        /// need to be looked up as there is no direct link to the new
        /// MailItem object.
        /// </summary>
        /// <param name="EntryIDCollection">The Entry ID of the new message</param>
        void ThisApplication_NewMailEx(string EntryIDCollection)
        {
            // Using the EntryID, you can search for the specific item
            // using the GetItemFromID method of the Session object.
            // Note that this is not mail specific, but rather for any
            // item.  Note also that it is not based on a specific folder,
            // but searches across all folders.
            Outlook.MailItem newMail = Session.GetItemFromID(EntryIDCollection, missing) as Outlook.MailItem;

            // This should not be necessary since the Entry ID was
            // specifically obtained from the NewMailEx event, but
            // it is a good practice to double-check.
            if (newMail != null)
            {
                // The subject is a string so can be compared with any
                // standard string methods.  Many of these actions can
                // be taken using rules, however managed code offers
                // more flexibility.
                if (newMail.Subject.StartsWith("URGENT:"))
                {
                    // Setting the importance makes it easy to prioritize
                    // new messages.  Of course any of these comparisons could
                    // be enhanced using database or other external service
                    // lookups to relate them more directly to business data.
                    newMail.Importance =
                        Outlook.OlImportance.olImportanceHigh;
                    newMail.Save();
                }
                else if (newMail.Subject.StartsWith("FYI:"))
                {
                    newMail.Importance = 
                        Outlook.OlImportance.olImportanceLow;
                    newMail.Save();
                }
                else if (newMail.Subject.StartsWith("OPENME:"))
                {
                    // Any item can be dispalyed using the Display method.
                    // This provides a powerful method to bring attention
                    // to an important item, but should be used sparingly.
                    newMail.Display(null);
                    newMail.Save();
                }
                else if (newMail.Subject.StartsWith("FOLLOWUP:"))
                {
                    // Message flagging can be used in conjunction with
                    // custom views, filters, and rules to provide a 
                    // more streamlined workflow.
                    newMail.FlagStatus = 
                        Outlook.OlFlagStatus.olFlagMarked;
                    newMail.Save();
                }
                else if( newMail.Subject.StartsWith("FLAGME:"))
                {
                    newMail.FlagIcon = 
                        Outlook.OlFlagIcon.olRedFlagIcon;
                    newMail.Save();
                }
                // Scanning the body of each incoming message provides the
                // greatest opportunity to apply heuristics or lookups to
                // manage incoming mail.
                else if (newMail.Body.IndexOf("This is an automated message") > -1)
                {
                    // Deleting a message using the Delete method causes it
                    // to be sent to the Deleted Items folder -- not
                    // permanently deleted.  Another option would be to move a
                    // message to the Junk E-mail folder if applicable.
                    newMail.Delete();
                }
            }
        }

        private void ThisApplication_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisApplication_Startup);
            this.Shutdown += new System.EventHandler(ThisApplication_Shutdown);
        }

        #endregion
    }
}

using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace WorkingWithContactsAndTasksInOutlook
{
    public partial class ThisApplication
    {
        Office.CommandBar mainMenuBar;
        Office.CommandBarPopup newMenuEntry;
        Office.CommandBarButton takeMessageCommand;

        const string MENU_BEFORE = "Help";
        int helpMenuIndex;

        Outlook.MAPIFolder inBoxfolder;

        private TakeAMessageForm messageForm;

        private void ThisApplication_Startup(object sender, System.EventArgs e)
        {
            CreateMenu();
        }

        private void ThisApplication_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void CreateMenu()
        {
            // Obtain a reference to the Inbox.  This will be used
            // later for message counts.
            inBoxfolder = this.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            // Obtain a reference to the menu bar.  This will be the
            // container for the new options.
            mainMenuBar = this.ActiveExplorer().CommandBars.ActiveMenuBar;

            // The helpMenuIndex is used to establish where the new
            // menu will appear (in this instance, before the Help menu.
            helpMenuIndex = mainMenuBar.Controls[MENU_BEFORE].Index;

            // Create the new menu.  It will display as "Outlook Custom Menu"
            newMenuEntry = (Office.CommandBarPopup)mainMenuBar.Controls.Add(
                Office.MsoControlType.msoControlPopup,
                missing, missing, helpMenuIndex, true);
            newMenuEntry.Caption = "Outlook Custom Menu";
            newMenuEntry.Visible = true;

            // Add menu items using the Controls.Add() method of the
            // menu.  The Caption properties control the visible label.
            takeMessageCommand = (Office.CommandBarButton)newMenuEntry.Controls.Add(
                Office.MsoControlType.msoControlButton,
                missing, missing, missing, true);
            takeMessageCommand.Caption = "Take a Message";
            takeMessageCommand.Visible = true;
            takeMessageCommand.Enabled = true;
            
            // Standard event binding is used to perform an action when
            // the menu option is clicked by the user.
            takeMessageCommand.Click +=
                new Office._CommandBarButtonEvents_ClickEventHandler(takeMessageCommand_Click);
                
        }

        void takeMessageCommand_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            if (messageForm == null)
            {
                messageForm = new TakeAMessageForm(this);
            }

            messageForm.Show();
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
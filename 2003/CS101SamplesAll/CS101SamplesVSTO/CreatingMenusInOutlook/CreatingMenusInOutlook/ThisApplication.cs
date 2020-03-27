using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace CreatingMenusInOutlook
{
    public partial class ThisApplication
    {
        Office.CommandBar mainMenuBar;
        Office.CommandBarPopup newMenuEntry;
        Office.CommandBarButton inboxCountCommand, addButtonCommand;
        List<Office.CommandBarButton> newButtonCommands =
            new List<Microsoft.Office.Core.CommandBarButton>();
        Office._CommandBarButtonEvents_ClickEventHandler newButtonClickHandler;

        const string MENU_BEFORE = "Help";
        int helpMenuIndex;

        Outlook.MAPIFolder inBoxfolder;

        private void ThisApplication_Startup(object sender, System.EventArgs e)
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
            inboxCountCommand = (Office.CommandBarButton)newMenuEntry.Controls.Add(
                Office.MsoControlType.msoControlButton,
                missing, missing, missing, true);
            inboxCountCommand.Caption = "Inbox Count";
            inboxCountCommand.Visible = true;
            inboxCountCommand.Enabled = true;
            
            // Standard event binding is used to perform an action when
            // the menu option is clicked by the user.
            inboxCountCommand.Click +=
                new Office._CommandBarButtonEvents_ClickEventHandler(inboxCountCommand_Click);

            // Add a menu command to dynamically add new buttons
            addButtonCommand = (Office.CommandBarButton)newMenuEntry.Controls.Add(
                Office.MsoControlType.msoControlButton,
                missing, missing, missing, true);
            addButtonCommand.Caption = "Add new CommandBarButton";
            addButtonCommand.Visible = true;
            addButtonCommand.Enabled = true;

            // Standard event binding is used to perform an action when
            // the menu option is clicked by the user.
            addButtonCommand.Click +=
                new Office._CommandBarButtonEvents_ClickEventHandler(addButtonCommand_Click);

            // This event handler will be reused between all instances
            // of the dynamically-added menu commands.
            newButtonClickHandler = 
                new Office._CommandBarButtonEvents_ClickEventHandler(newButtonCommand_Click);
        }

        /// <summary>
        /// Handles the click event for the add button command.
        /// This creates a new command bar button in the same menu.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void addButtonCommand_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Office.CommandBarButton newButtonCommand;

            // Add a menu command to dynamically add new buttons
            newButtonCommand = (Office.CommandBarButton)newMenuEntry.Controls.Add(Office.MsoControlType.msoControlButton, missing, missing, missing, true);
            newButtonCommand.Caption = "Button #" + newMenuEntry.Controls.Count;
            newButtonCommand.Visible = true;
            newButtonCommand.Enabled = true;

            // Retain a reference to the control or event binding will not
            // occur once the object goes out of scope.
            newButtonCommands.Add(newButtonCommand);

            // Standard event binding is used to perform an action when
            // the menu option is clicked by the user.
            newButtonCommand.Click += newButtonClickHandler;
        }

        /// <summary>
        /// This is invoked each time a dynamic command bar button is clicked.
        /// It simply displays a message box with the control's name.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void newButtonCommand_Click(Microsoft.Office.Core.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            MessageBox.Show("You clicked " + Ctrl.Caption);
        }

        /// <summary>
        /// The event handler to be invoked when the Inbox Count
        /// menu command is clicked.
        /// </summary>
        /// <param name="Ctrl"></param>
        /// <param name="CancelDefault"></param>
        void inboxCountCommand_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            MessageBox.Show("Inbox currently contains: " + inBoxfolder.Items.Count + " items (" + inBoxfolder.UnReadItemCount + " unread)");
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

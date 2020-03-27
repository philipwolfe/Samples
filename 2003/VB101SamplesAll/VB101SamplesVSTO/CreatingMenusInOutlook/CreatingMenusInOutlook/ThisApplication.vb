Imports System.Collections.Generic
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office.Core

public class ThisApplication

    Dim mainMenuBar As Office.CommandBar
    Dim newMenuEntry As Office.CommandBarPopup
    Dim addButtonCommand, inboxCountCommand As Office.CommandBarButton
    Dim newButtonClickHandler As Office._CommandBarButtonEvents_ClickEventHandler
    Dim newButtonCommands As New List(Of Office.CommandBarButton)

    Dim MENU_BEFORE As String = "Help"
    Dim helpMenuIndex As Integer
    Dim inBoxfolder As Outlook.MAPIFolder

    Private Sub ThisApplication_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' Obtain a reference to the Inbox.  This will be used
        ' later for message counts.
        inBoxfolder = Me.GetNamespace("MAPI").GetDefaultFolder( _
            Outlook.OlDefaultFolders.olFolderInbox)

        ' Obtain a reference to the menu bar.  This will be the
        ' container for the new options.
        mainMenuBar = Me.ActiveExplorer.CommandBars.ActiveMenuBar

        ' The helpMenuIndex is used to establish where the new
        ' menu will appear (in this instance, before the Help menu.
        helpMenuIndex = mainMenuBar.Controls(MENU_BEFORE).Index

        ' Create the new menu.  It will display as "Outlook Custom Menu"
        newMenuEntry = CType(mainMenuBar.Controls.Add( _
            Office.MsoControlType.msoControlPopup, Before:=helpMenuIndex, Temporary:=True), _
            Office.CommandBarPopup)
        newMenuEntry.Caption = "Outlook Custom Menu"
        newMenuEntry.Visible = True

        ' Add menu items using the Controls.Add() method of the
        ' menu.  The Caption properties control the visible label.
        inboxCountCommand = CType(newMenuEntry.Controls.Add( _
            Office.MsoControlType.msoControlButton, Temporary:=True), _
            Office.CommandBarButton)
        inboxCountCommand.Caption = "Inbox Count"
        inboxCountCommand.Visible = True
        inboxCountCommand.Enabled = True

        ' Standard event binding is used to perform an action when
        ' the menu option is clicked by the user.
        AddHandler inboxCountCommand.Click, AddressOf Me.inboxCountCommand_Click

        ' Add a menu command to dynamically add new buttons
        addButtonCommand = CType(newMenuEntry.Controls.Add( _
            Office.MsoControlType.msoControlButton, Temporary:=True), _
            Office.CommandBarButton)
        addButtonCommand.Caption = "Add new CommandBarButton"
        addButtonCommand.Visible = True
        addButtonCommand.Enabled = True

        ' Standard event binding is used to perform an action when
        ' the menu option is clicked by the user.
        AddHandler addButtonCommand.Click, AddressOf Me.addButtonCommand_Click

        ' This event handler will be reused between all instances
        ' of the dynamically-added menu commands.
        newButtonClickHandler = AddressOf Me.newButtonCommand_Click
    End Sub

    ''' <summary>
    ''' Handles the click event for the add button command.
    ''' This creates a new command bar button in the same menu.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub addButtonCommand_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        Dim newButtonCommand As Office.CommandBarButton

        ' Add a menu command to dynamically add new buttons
        newButtonCommand = CType(newMenuEntry.Controls.Add( _
            Office.MsoControlType.msoControlButton, Temporary:=True), _
            Office.CommandBarButton)
        newButtonCommand.Caption = "Button #" & newMenuEntry.Controls.Count
        newButtonCommand.Visible = True
        newButtonCommand.Enabled = True

        ' Retain a reference to the control or event binding will not
        ' occur once the object goes out of scope.
        newButtonCommands.Add(newButtonCommand)

        ' Standard event binding is used to perform an action when
        ' the menu option is clicked by the user.
        AddHandler newButtonCommand.Click, newButtonClickHandler
    End Sub

    ''' <summary>
    ''' This is invoked each time a dynamic command bar button is clicked.
    ''' It simply displays a message box with the control's name.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub newButtonCommand_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        MessageBox.Show("You clicked " & Ctrl.Caption)
    End Sub

    ''' <summary>
    ''' The event handler to be invoked when the Inbox Count
    ''' menu command is clicked.
    ''' </summary>
    ''' <param name="Ctrl"></param>
    ''' <param name="CancelDefault"></param>
    Private Sub inboxCountCommand_Click(ByVal Ctrl As Office.CommandBarButton, ByRef CancelDefault As Boolean)
        MessageBox.Show("Inbox currently contains: " _
                        & inBoxfolder.Items.Count & " items (" _
                        & inBoxfolder.UnReadItemCount & " unread)")
    End Sub

    Private Sub ThisApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
    End Sub

End Class

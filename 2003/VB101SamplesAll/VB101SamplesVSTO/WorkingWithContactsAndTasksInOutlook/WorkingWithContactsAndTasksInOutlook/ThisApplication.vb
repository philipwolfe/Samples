
public class ThisApplication

    Dim mainMenuBar As Office.CommandBar
    Dim newMenuEntry As Office.CommandBarPopup
    Dim takeMessageCommand As Office.CommandBarButton
    Dim MENU_BEFORE As String = "Help"
    Dim helpMenuIndex As Integer
    Dim inBoxfolder As Outlook.MAPIFolder
    Dim messageForm As TakeAMessageForm


    Private Sub ThisApplication_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        CreateMenu()
    End Sub

    Private Sub ThisApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

    Private Sub CreateMenu()
        ' Obtain a reference to the Inbox.  This will be used
        ' later for message counts.
        inBoxfolder = Me.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)

        ' Obtain a reference to the menu bar.  This will be the
        ' container for the new options.
        mainMenuBar = Me.ActiveExplorer.CommandBars.ActiveMenuBar

        ' The helpMenuIndex is used to establish where the new
        ' menu will appear (in this instance, before the Help menu.
        helpMenuIndex = mainMenuBar.Controls(MENU_BEFORE).Index

        ' Create the new menu.  It will display as "Outlook Custom Menu"
        newMenuEntry = CType(mainMenuBar.Controls.Add(Office.MsoControlType.msoControlPopup, Before:=helpMenuIndex, Temporary:=True), Office.CommandBarPopup)
        newMenuEntry.Caption = "Outlook Custom Menu"
        newMenuEntry.Visible = True

        ' Add menu items using the Controls.Add() method of the
        ' menu.  The Caption properties control the visible label.
        takeMessageCommand = CType(newMenuEntry.Controls.Add(Office.MsoControlType.msoControlButton, Temporary:=True), Office.CommandBarButton)
        takeMessageCommand.Caption = "Take a Message"
        takeMessageCommand.Visible = True
        takeMessageCommand.Enabled = True

        ' Standard event binding is used to perform an action when
        ' the menu option is clicked by the user.
        AddHandler takeMessageCommand.Click, AddressOf Me.takeMessageCommand_Click
    End Sub

    Private Sub takeMessageCommand_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        If messageForm Is Nothing Then
            messageForm = New TakeAMessageForm(Me)
        End If

        messageForm.Show()
    End Sub


End class

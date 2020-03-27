Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office.Core

public class ThisApplication

    Dim mainMenuBar As Office.CommandBar
    Dim newMenuEntry As Office.CommandBarPopup
    Dim sendDelinquentMailCommand As Office.CommandBarButton
    Dim MENU_BEFORE As String = "Help"
    Dim helpMenuIndex As Integer
    Dim inBoxfolder As Outlook.MAPIFolder
    Dim mailTemplateForm As CustomMailTemplateForm

    Private Sub ThisApplication_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        CreateMenu()
    End Sub

    ' <summary>
    ' Creates a new top-level menu and menu command
    ' </summary>
    Private Sub CreateMenu()
        ' Obtain a reference to the Inbox.
        inBoxfolder = Me.GetNamespace("MAPI").GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)

        ' Obtain a reference to the menu bar.  This will be the
        ' container for the new options.
        mainMenuBar = Me.ActiveExplorer.CommandBars.ActiveMenuBar

        ' The helpMenuIndex is used to establish where the new
        ' menu will appear (in this instance, before the Help menu.
        helpMenuIndex = mainMenuBar.Controls(MENU_BEFORE).Index

        ' Create the new menu.  It will display as "Outlook Custom Menu"
        newMenuEntry = CType(mainMenuBar.Controls.Add( _
            Office.MsoControlType.msoControlPopup, Before:=helpMenuIndex, Temporary:=True), Office.CommandBarPopup)
        newMenuEntry.Caption = "Outlook Custom Menu"
        newMenuEntry.Visible = True

        ' Add menu items using the Controls.Add() method of the
        ' menu.  The Caption properties control the visible label.
        sendDelinquentMailCommand = CType(newMenuEntry.Controls.Add( _
            Office.MsoControlType.msoControlButton, Temporary:=True), Office.CommandBarButton)
        sendDelinquentMailCommand.Caption = "Send Delinquency Message"
        sendDelinquentMailCommand.Visible = True
        sendDelinquentMailCommand.Enabled = True

        ' Standard event binding is used to perform an action when
        ' the menu option is clicked by the user.
        AddHandler sendDelinquentMailCommand.Click, AddressOf Me.sendDelinquentMailCommand_Click
    End Sub

    ' <summary>
    ' Event handler to respond to user clicking on the menu command.
    ' </summary>
    ' <param name="Ctrl"></param>
    ' <param name="CancelDefault"></param>
    Private Sub sendDelinquentMailCommand_Click(ByVal Ctrl As Microsoft.Office.Core.CommandBarButton, ByRef CancelDefault As Boolean)
        If (mailTemplateForm Is Nothing) Then
            mailTemplateForm = New CustomMailTemplateForm(Me)
        End If

        mailTemplateForm.Show()
    End Sub

    Private Sub ThisApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End class

Imports system.collections.Generic

Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office.Core

Public Class TakeAMessageForm
    Dim currentApplication As ThisApplication
    Dim contactSavedHandler As Outlook.ItemEvents_10_WriteEventHandler
    Dim contactsList As New List(Of String)
    Dim newContact As Outlook.ContactItem
    Const DEFAULT_CONTACT As String = "<Please select a contact>"

    Public Sub New(ByVal currentApplication As ThisApplication)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.currentApplication = currentApplication
        ' Create a resuable event handler for new contacts
        contactSavedHandler = AddressOf Me.newContact_Write
    End Sub

    ''' <summary>
    ''' Iterates through all contact items in the Contacts folder.
    ''' Each entry is added to a List object for display in the
    ''' combo box.
    ''' </summary>
    Private Sub ReadContacts()
        ' Disconnect data source so it rebinds after changes.
        contactsComboBox.DataSource = Nothing

        ' Clear the list and add a default item
        contactsList.Clear()
        contactsList.Add(DEFAULT_CONTACT)

        ' Get the Contacts folder.
        Dim contacts As Outlook.MAPIFolder = _
            currentApplication.ActiveExplorer.Session.GetDefaultFolder( _
            Outlook.OlDefaultFolders.olFolderContacts)

        ' Add each contact to a List of strings
        For Each contact As Outlook.ContactItem In contacts.Items
            contactsList.Add(contact.FullName)
        Next

        ' Work-around since contact is not yet filed when its
        ' save event fires.
        If Not newContact Is Nothing Then
            contactsList.Add(newContact.FullName)
        End If

        ' Set the data source to force a rebind.
        contactsComboBox.DataSource = contactsList
    End Sub

    ''' <summary>
    ''' Responds to the Click even of the New Contact button.
    ''' Creates a new contact, registers to know when it is
    ''' saved, then displays it modally.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub newContactButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newContactButton.Click
        newContact = CType( _
            Globals.ThisApplication.CreateItem( _
            Microsoft.Office.Interop.Outlook.OlItemType.olContactItem), _
            Outlook.ContactItem)

        AddHandler newContact.Write, contactSavedHandler

        newContact.Display(False)
    End Sub

    ''' <summary>
    ''' Event handler invoked when a new contact is saved.
    ''' Updates the ComboBox and auto-selects the new contact.
    ''' </summary>
    ''' <param name="Cancel"></param>
    Private Sub newContact_Write(ByRef Cancel As Boolean)
        ReadContacts()
        contactsComboBox.Text = newContact.FullName
        RemoveHandler newContact.Write, contactSavedHandler
        newContact = Nothing
    End Sub

    ''' <summary>
    ''' Hides the form when the Cancel button is clicked.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cancelMessageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelMessageButton.Click
        Me.Hide()
    End Sub

    ''' <summary>
    ''' Creates a new task using the contact, body, and callback
    ''' date entered.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveButton.Click
        If contactsComboBox.SelectedIndex > 0 Then
            ' .NET 2.0 supports nullable value types.  This provides
            ' a very clean method of determining if a value field
            ' has been assigned a value yet.
            Dim callbackDate As Nullable(Of DateTime)

            Try
                If (callbackDateTextBox.Text.Length > 6) Then
                    callbackDate = DateTime.Parse(callbackDateTextBox.Text)
                    If ((callbackDate.Value.Year < 1601) _
                                OrElse (callbackDate.Value.Year > 4499)) Then
                        Throw New Exception( _
                            "Outlook does not support years before 1601 or beyond 4499")
                    End If
                End If
            Catch
                MessageBox.Show("Please enter a valid callback date between the " & _
                    "years 1601 and 4499 (or clear the field)")
                Return
            End Try

            Dim newTask As Outlook.TaskItem = _
                CType(Globals.ThisApplication.CreateItem( _
                Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem), _
                Outlook.TaskItem)
            newTask.Subject = String.Format("Message from {0}", contactsComboBox.Text)
            newTask.Body = messageTextBox.Text

            newTask.Contacts = contactsComboBox.Text

            ' Set a due date if specified.  Nullable fields have properties
            ' to determine whether or not a value has been assigned, and to
            ' retrieve the underlying value object.
            If callbackDate.HasValue Then
                newTask.DueDate = callbackDate.Value
            End If

            newTask.Save()

            Me.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' Responds to the ComboBox selected index being changed.
    ''' If a contact is selected, then Save button is enabled.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub contactsComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles contactsComboBox.SelectedIndexChanged
        If contactsComboBox.Text = DEFAULT_CONTACT Then
            saveButton.Enabled = False
        Else
            saveButton.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Reset the form whenever shown.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TakeAMessageForm_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            ReadContacts()
            messageTextBox.Text = ""
            callbackDateTextBox.Text = ""
            newContact = Nothing
        End If
    End Sub
End Class
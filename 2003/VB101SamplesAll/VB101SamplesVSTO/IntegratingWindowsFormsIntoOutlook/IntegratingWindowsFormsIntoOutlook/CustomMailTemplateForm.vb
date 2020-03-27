Imports System.Collections.Generic

Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Office = Microsoft.Office.Core

Public Class CustomMailTemplateForm
    Private currentApplication As ThisApplication
    Dim customersList As New List(Of String)()
    Private Const DEFAULT_CONTACT As String = _
        "<Please select a customer>"

    Public Sub New(ByVal currentApplication As ThisApplication)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.currentApplication = currentApplication
    End Sub

    ' <summary>
    ' Iterates through all contact items in the Contacts folder.
    ' Each entry is added to a List object for display in the
    ' combo box.
    ' </summary>
    Private Sub ReadContacts()
        ' Disconnect data source so it rebinds after changes.
        customerComboBox.DataSource = Nothing

        ' Clear the list and add a default item
        customersList.Clear()
        customersList.Add(DEFAULT_CONTACT)

        ' Get the Contacts folder.
        Dim contacts As Outlook.MAPIFolder = _
            currentApplication.ActiveExplorer.Session.GetDefaultFolder( _
            Outlook.OlDefaultFolders.olFolderContacts)

        ' Add each contact to a List of strings
        For Each contact As Outlook.ContactItem In contacts.Items
            customersList.Add(contact.FullName)
        Next

        ' Set the data source to force a rebind.
        customerComboBox.DataSource = customersList
        customerComboBox.Text = DEFAULT_CONTACT
    End Sub

    ' <summary>
    ' When the user clicks the Send button, a new mail
    ' message and task item are created and populated
    ' based on the entered values.  The task is then
    ' saved, and the mail message is moved to the Outbox.
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    Private Sub sendMailButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sendMailButton.Click
        Dim dueDate As DateTime

        If ((customerComboBox.SelectedIndex > 0) _
                    AndAlso ((dueDateTextBox.Text.Length = 10) _
                    AndAlso (amountTextBox.Text.Length > 0))) Then
            Try
                dueDate = DateTime.Parse(dueDateTextBox.Text)

                If (dueDate.Year < 1601) _
                            OrElse (dueDate.Year > 4499) Then
                    Throw New Exception( _
                        "Outlook does not support years before 1601 or beyond 4499")
                End If
            Catch
                MessageBox.Show("Please enter a valid due date")
                Return
            End Try

            Dim mailMessage As String = _
                String.Format("According to our records, you are currently delinquent " & _
                "in the amount of {0:c}.  Please remit the full amount by {1:d} " & _
                "to prevent further collections activity." & vbLf & vbLf & "{2}", _
                CDbl(amountTextBox.Text), dueDate, messageTextBox.Text)

            Dim newTask As Outlook.TaskItem = _
                CType(Globals.ThisApplication.CreateItem( _
                Microsoft.Office.Interop.Outlook.OlItemType.olTaskItem), Outlook.TaskItem)

            newTask.Subject = "Delinquent account followup"
            newTask.Body = String.Format("Delinquent amount: {0:c}" & vbLf & vbLf & _
                "You wrote: {1}", Double.Parse(amountTextBox.Text), messageTextBox.Text)
            newTask.Contacts = customerComboBox.Text

            ' Set a due date if specified                
            newTask.DueDate = DateTime.Parse(dueDate)
            newTask.Save()

            Dim newMail As Outlook.MailItem = _
                CType(Globals.ThisApplication.CreateItem( _
                Microsoft.Office.Interop.Outlook.OlItemType.olMailItem), Outlook.MailItem)

            newMail.To = customerComboBox.Text
            newMail.Subject = "Delinquent account notice"
            newMail.Body = mailMessage
            newMail.Move(currentApplication.ActiveExplorer.Session.GetDefaultFolder( _
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderOutbox))

            Me.Visible = False
        Else
            MessageBox.Show("All fields are required.")
        End If
    End Sub

    ' <summary>
    ' Hides the form when the Cancel button is clicked.
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    Private Sub cancelMailButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelMailButton.Click
        Me.Hide()
    End Sub

    ' <summary>
    ' Resets the fields whenever the form is shown
    ' </summary>
    ' <param name="sender"></param>
    ' <param name="e"></param>
    Private Sub CustomMailTemplateForm_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            ReadContacts()
            dueDateTextBox.Text = ""
            messageTextBox.Text = ""
            amountTextBox.Text = ""
        End If
    End Sub


End Class
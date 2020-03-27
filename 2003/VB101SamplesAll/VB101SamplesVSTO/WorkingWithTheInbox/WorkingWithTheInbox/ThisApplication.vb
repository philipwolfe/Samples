
public class ThisApplication

    Private Sub ThisApplication_Startup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Startup
        ' The NewMailEx handler was introduced in Outlook 2003 to replace
        ' the previous NewMail event.  NewMailEx adds the EntryID
        ' parameter to make it easier to take action based on a specific
        ' new message.
        AddHandler NewMailEx, AddressOf Me.ThisApplication_NewMailEx
    End Sub

    ''' <summary>
    ''' NewMailEx will fire for each new message.  The EntryID will
    ''' need to be looked up as there is no direct link to the new
    ''' MailItem object.
    ''' </summary>
    ''' <param name="EntryIDCollection">The Entry ID of the new message</param>
    Private Sub ThisApplication_NewMailEx(ByVal EntryIDCollection As String)
        ' Using the EntryID, you can search for the specific item
        ' using the GetItemFromID method of the Session object.
        ' Note that this is not mail specific, but rather for any
        ' item.  Note also that it is not based on a specific folder,
        ' but searches across all folders.
        Dim newMail As Outlook.MailItem = _
            CType(Session.GetItemFromID(EntryIDCollection), Outlook.MailItem)

        ' This should not be necessary since the Entry ID was
        ' specifically obtained from the NewMailEx event, but
        ' it is a good practice to double-check.
        If Not (newMail) Is Nothing Then

            ' The subject is a string so can be compared with any
            ' standard string methods.  Many of these actions can
            ' be taken using rules, however managed code offers
            ' more flexibility.
            If newMail.Subject.StartsWith("URGENT:") Then

                ' Setting the importance makes it easy to prioritize
                ' new messages.  Of course any of these comparisons could
                ' be enhanced using database or other external service
                ' lookups to relate them more directly to business data.
                newMail.Importance = Outlook.OlImportance.olImportanceHigh
                newMail.Save()

            ElseIf newMail.Subject.StartsWith("FYI:") Then

                newMail.Importance = Outlook.OlImportance.olImportanceLow
                newMail.Save()

            ElseIf newMail.Subject.StartsWith("OPENME:") Then

                ' Any item can be dispalyed using the Display method.
                ' This provides a powerful method to bring attention
                ' to an important item, but should be used sparingly.
                newMail.Display(Nothing)

            ElseIf newMail.Subject.StartsWith("FOLLOWUP:") Then

                ' Message flagging can be used in conjunction with
                ' custom views, filters, and rules to provide a 
                ' more streamlined workflow.
                newMail.FlagStatus = Outlook.OlFlagStatus.olFlagMarked
                newMail.Save()

            ElseIf newMail.Subject.StartsWith("FLAGME:") Then

                newMail.FlagIcon = Outlook.OlFlagIcon.olRedFlagIcon
                newMail.Save()

            ElseIf (newMail.Body.IndexOf("This is an automated message") > -1) Then

                ' Scanning the body of each incoming message provides the
                ' greatest opportunity to apply heuristics or lookups to
                ' manage incoming mail.

                ' Deleting a message using the Delete method causes it
                ' to be sent to the Deleted Items folder -- not
                ' permanently deleted.  Another option would be to move a
                ' message to the Junk E-mail folder if applicable.
                newMail.Delete()
            End If
        End If
    End Sub

    Private Sub ThisApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

    End Sub

End class

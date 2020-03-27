Option Strict On

Imports System.Security ' For SecureString
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices ' For the Marshal class

Public Class Form1
    Private password As New SecureString

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim myToolTip As New ToolTip()
        ' Set up the ToolTip text for the Button and Checkbox.
        myToolTip.SetToolTip(PasswordTextBox, "Type Password Slowly")
        myToolTip.SetToolTip(LoginButton, "Click to login")
        myToolTip.SetToolTip(VerifyButton, "Click to Verify Password")
    End Sub

    ' KeyUp Event
    ' This sample has a limitation on how fast keys can be accepted.  This is because the KeyUp event
    ' uses the Text property of the control to determine the last key typed.  If more KeyUp events occur before 
    ' the Text value is updated, the password will have multiple '*' values instead of typed characters.  
    ' To remove this limitation, handle each key event and translate the KeyCode into the actual char 
    ' accounting for the shift key and place this char in the password variable.  The intent here is to 
    ' demonstrate how to insert chars securely into a SecureString, not to write production code to 
    ' handle multiple events occurring before the Text property is updated.
    Private Sub PasswordTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyUp
        ' Use the IsReadOnly method to test whether an instance of SecureString is read-only.
        If password.IsReadOnly Then
            ' Dispose of the old instance and create a new instance to basically start 
            ' over because once password is read only (by clicking the Login button) it can not be modified
            password.Dispose() ' zero out the current password in memory
            password = New SecureString
        End If

        ' Get value of char typed into textbox
        If PasswordTextBox.Text <> String.Empty Then
            If e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Delete Then
                ' Get lastchar only char only
                Dim ch As Char = PasswordTextBox.Text.Chars(PasswordTextBox.Text.Length - 1)
                password.AppendChar(ch)
                PasswordTextBox.Text = Regex.Replace(PasswordTextBox.Text, ".", "*")
                PasswordTextBox.SelectionStart = PasswordTextBox.Text.Length
            End If
        End If
    End Sub

    ' There will be situations where the user will type a char and then type the backspace key and continue 
    ' or completely clear out the text and start over, so handle this change here
    Private Sub PasswordTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasswordTextBox.TextChanged
        ' Use the IsReadOnly method to test whether an instance of SecureString is read-only.
        If password.IsReadOnly Then
            ' Dispose of the old instance and create a new instance to basically start 
            ' over because once password is read only (by clicking the Login button) it can not be modified
            password.Dispose() ' zero out the current password in memory
            password = New SecureString
        End If

        ' See if there is a difference in lengths between the TextBox and the password
        If PasswordTextBox.Text.Length <> password.Length Then

            If PasswordTextBox.Text = String.Empty Then
                password.Clear() ' user cleared textbox, so clear password as well
            ElseIf PasswordTextBox.Text.Length < password.Length Then
                password.RemoveAt(password.Length - 1) ' Remove last char...assuming only last char removed with backspace key
            End If
        End If
    End Sub

    Private Sub LoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        ' Use the MakeReadOnly method to make the value of the instance immutable (read-only). 
        ' After the value is marked as read-only, any further attempt to modify it 
        ' throws an InvalidOperationException. 

        ' The effect of invoking MakeReadOnly is permanent because no means is 
        ' provided to make the secure string modifiable again. 

        password.MakeReadOnly()
    End Sub

    Private Sub VerifyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifyButton.Click
        Dim bstr As IntPtr = Marshal.SecureStringToBSTR(password)
        ' Get pointer to secure string.  This is the only way to get a SecureString
        ' value unencrypted and usable
        Try
            ' Get password.  As soon as the password is assigned to the Label's text property the
            ' password is no longer secure because there are now unencrypted copies of the string in memory.
            ' In this sample, we are unsecuring our password by displaying it in order to verify it was 
            ' set correctly.
            PasswordVerifyLabel.Text = Marshal.PtrToStringBSTR(bstr)
        Finally
            ' Zero out memory of bstr for security...don't want any extra copy laying around in memory
            Marshal.ZeroFreeBSTR(bstr)
        End Try
    End Sub
End Class

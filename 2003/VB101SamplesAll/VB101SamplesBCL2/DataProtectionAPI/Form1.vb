Option Strict On

Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Form1
    ' Store the encrypted memory here so it can be decrypted with the Decrypt button
    Private secureData As Byte()

    ' Value stored for efficient binary file read
    Private secureDataByteCount As Integer

    ' Store optional encryption entropy here for use in decryption process
    Private entropy As Byte()

    ' FormLoad...Init entropy and SelectedIndex which forces change event
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Create some random entropy for later use
        entropy = CreateRandomEntropy()
        EncryptedDestinationComboBox.SelectedIndex = 0 ' Init to Memory Type
        DecryptButton.Enabled = False
    End Sub

    ' ProtectData
    ' Call the ProtectedData.Protect method to create an encrypted byte array and 
    ' store the encrpyted result in a file.  Also alert user
    ' to any exception that might be thrown by displaying an error message
    Private Function ProtectData(ByVal data As Byte()) As Byte()
        Dim bytes As Byte() = Nothing
        Try
            ' Get an encrypted copy of the data
            bytes = ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser)

            ' Create and write to file
            Dim stream As New FileStream(WriteFileTextBox.Text, FileMode.OpenOrCreate)

            Try
                ' Write the encrypted data to a stream.
                If stream.CanWrite And (Not bytes Is Nothing) Then
                    stream.Write(bytes, 0, bytes.Length)
                End If
            Finally
                stream.Close()
            End Try
        Catch ex As ArgumentNullException
            MessageBox.Show("The userData parameter is a null reference(Nothing in Visual Basic.")
        Catch ex As CryptographicException
            MessageBox.Show("The cryptographic protection failed.")
        Catch ex As PlatformNotSupportedException
            MessageBox.Show("The operating system does not support this method. This method can be used only with Microsoft Windows 2000 or later operating systems.")
        Catch ex As OutOfMemoryException
            MessageBox.Show("The system ran out of memory while encrypting the data.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return bytes
    End Function

    ' ProtectMemory
    ' Call the ProtectedMemory.Protect method to encrypt a byte array. Also alert user
    ' to any exception that might be thrown by displaying an error message
    Private Function ProtectMemory(ByVal data As Byte()) As Byte()
        Try
            ' Data must be in multiples of 16 bytes so pad with spaces at end that 
            ' can be trimmed during decryption
            Dim i As Integer
            Dim extraBytes As Integer = 0
            Dim len As Integer = data.Length
            If len Mod 16 <> 0 Then : extraBytes = 16 - (len Mod 16) : End If
            If extraBytes <> 0 Then
                ReDim Preserve data(len + extraBytes - 1)
                For i = len To (len + extraBytes - 1)
                    data(i) = 32 ' ascii value for space
                Next i
            End If
            ProtectedMemory.Protect(data, MemoryProtectionScope.SameProcess)
        Catch ex As CryptographicException
            MessageBox.Show("UserData must be 16 bytes in length or in multiples of 16 bytes.")
        Catch ex As PlatformNotSupportedException
            MessageBox.Show("The operating system does not support this method. This method can be used only with Microsoft Windows 2000 or later operating systems.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return data
    End Function

    ' UnprotectData
    ' Call the ProtectedData.Unprotect method to decrypt the class member
    ' variable secureData created by the Protect Method.  Also alert user
    ' to any exception that might be thrown by displaying an error message
    Private Function UnprotectData(ByVal byteCount As Integer) As Byte()
        Dim bytes As Byte() = Nothing
        Dim buffer(byteCount) As Byte
        Try
            ' Read from the stream and decrypt the data.
            ' Open the file.
            Dim stream As FileStream = New FileStream(WriteFileTextBox.Text, FileMode.Open)
            Try
                ' Read the encrypted data from a stream.
                If stream.CanRead Then
                    stream.Read(buffer, 0, byteCount)
                Else
                    Throw New IOException("Could not read the stream.")
                End If
            Finally
                stream.Close()
            End Try

            ' Decrypt the data.
            bytes = ProtectedData.Unprotect(buffer, entropy, DataProtectionScope.CurrentUser)

        Catch ex As ArgumentNullException
            MessageBox.Show("The encryptedData parameter is a null reference(Nothing in Visual Basic).")
        Catch ex As CryptographicException
            MessageBox.Show("The cryptographic protection failed.")
        Catch ex As PlatformNotSupportedException
            MessageBox.Show("The operating system does not support this method. This method can be used only with Microsoft Windows 2000 or later operating systems.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return bytes
    End Function

    ' UnprotectMemory
    ' Call the ProtectedMemory.Unprotect method to decrypt the class member
    ' variable secureData created by the ProtectMemory Method.  Also alert user
    ' to any exception that might be thrown by displaying an error message
    Private Function UnprotectMemory(ByVal bytes As Byte()) As Byte()
        Try
            ' Decrypt the data.
            ProtectedMemory.Unprotect(bytes, MemoryProtectionScope.SameProcess)

        Catch ex As ArgumentNullException
            MessageBox.Show("The encryptedData parameter is a null reference(Nothing in Visual Basic).")
        Catch ex As CryptographicException
            MessageBox.Show("The cryptographic protection failed.")
        Catch ex As PlatformNotSupportedException
            MessageBox.Show("The operating system does not support this method. This method can be used only with Microsoft Windows 2000 or later operating systems.")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return bytes
    End Function

    ' BytesToString
    ' Helper function that converts a byte array into its ascii value equivalent.
    ' Returns a string of ascii character values separated by a spaces
    Private Function BytesToString(ByVal bytes As Byte()) As String
        Dim i As Integer
        Dim builder As New StringBuilder()

        For i = 0 To UBound(bytes)
            builder.Append(bytes(i) & " ")
        Next i

        Return builder.ToString()
    End Function

    Private Function CreateRandomEntropy() As Byte()
        ' Create a byte array to hold the random value.
        Dim entropy(15) As Byte

        ' Create a new instance of the RNGCryptoServiceProvider.
        ' Fill the array with a random value and return
        Dim RNG As New RNGCryptoServiceProvider()
        RNG.GetBytes(entropy)
        Return entropy
    End Function

    Private Sub EncryptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncryptButton.Click
        ' Convert the string value of the DataTextBox to an array of bytes
        Dim encoding As New System.Text.ASCIIEncoding()
        Dim bytes As Byte() = encoding.GetBytes(DataTextBox.Text)

        ' Show raw bytes in text box
        RawBytesTextBox.Text = BytesToString(bytes)

        If EncryptedDestinationComboBox.SelectedIndex = 1 Then
            ' Encrypt to File
            secureData = ProtectData(bytes)
            secureDataByteCount = secureData.Length
        Else
            ' Encrypt to Memory
            secureData = ProtectMemory(bytes)
        End If
        ' Show encrypted bytes in TextBox
        EncryptedBytesTextBox.Text = BytesToString(secureData)
        DecryptButton.Enabled = True ' Enable button for decryption
    End Sub

    Private Sub DecryptButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecryptButton.Click
        ' Unprotect method decrypts the secureData class member and returns original byte array
        Dim bytes As Byte()

        If EncryptedDestinationComboBox.SelectedIndex = 1 Then
            ' Decrypt File
            bytes = UnprotectData(secureDataByteCount)
        Else
            ' Decrypt Memory
            bytes = UnprotectMemory(secureData)
        End If

        ' Show the original text in the textbox after decryption
        Dim encoding As New System.Text.ASCIIEncoding()
        VerifyTextBox.Text = RTrim(encoding.GetString(bytes)) ' Trim padding
        DecryptButton.Enabled = False ' Disable button until encrypted again
    End Sub

    Private Sub EncryptedDestinationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncryptedDestinationComboBox.SelectedIndexChanged
        If EncryptedDestinationComboBox.SelectedIndex = 0 Then
            WriteFileTextBox.Visible = False
            FileNameLabel.Visible = False
        Else
            WriteFileTextBox.Visible = True
            FileNameLabel.Visible = True
        End If
    End Sub

End Class

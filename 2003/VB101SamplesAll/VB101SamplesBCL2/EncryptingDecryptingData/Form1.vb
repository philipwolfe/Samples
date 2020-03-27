Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Security.Cryptography


Partial Public Class Form1
    Inherits Form

    ' The default work location.
    Private workFolder As String = Path.GetFullPath("..\..\DemoData")

    ' The default files to read from and write to.
    Private m_clearFileName As String = "Data.txt"

    ' The files with your public/private key pair. In production, you would guard
    ' your key extremely carefully. Best practice would be to store your key pair
    ' in a key container, not in an XML file.
    Private m_sendersKeyFileName As String = "..\..\SendersKey.xml"

    ' The file with the receiver's public key. You will use this key to encrypt
    ' data that only the receiver can decrypt, using his private key.
    Private m_rsaKeyString As String = String.Empty

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        If File.Exists(m_sendersKeyFileName) Then
            m_rsaKeyString = ReadRSAKeysFromXmlFile(m_sendersKeyFileName)
        Else
            Dim msg As String = "Symmetrical key file not found. Create?"
            If (MessageBox.Show(msg, "Missing File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
                WriteRSAKeysToXmlFile(New RSACryptoServiceProvider, m_sendersKeyFileName)
            End If
        End If
    End Sub

#Region " Event Procedures "

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        workFolderTextBox.Text = workFolder
        clearFileTextBox.Text = m_clearFileName
        SetFileNames()
    End Sub

    Private Sub loadClearDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fileToRead As String = SetFilePath(clearFileTextBox.Text.Trim)
        If File.Exists(fileToRead) Then
            Dim sr As StreamReader = New StreamReader(fileToRead, Encoding.UTF7)
            Dim clearData As String = sr.ReadToEnd
            sr.Close()
            clearDataTextBox.Text = clearData
        Else
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub loadDecryptedDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fileToRead As String = SetFilePath(decryptedFileTextBox.Text.Trim)
        If File.Exists(fileToRead) Then
            Dim sr As StreamReader = New StreamReader(fileToRead, Encoding.UTF7)
            Dim clearData As String = sr.ReadToEnd
            sr.Close()
            clearDataTextBox.Text = clearData
        Else
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub encryptButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fileToRead As String = SetFilePath(clearFileTextBox.Text)
        Dim fileToWrite As String = SetFilePath(encryptedFileTextBox.Text)
        If File.Exists(fileToRead) Then
            If OkToWriteFile(fileToWrite) Then
                EncryptFile(fileToRead, fileToWrite)
                MessageBox.Show("Encryption successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub decryptButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim fileToRead As String = SetFilePath(encryptedFileTextBox.Text)
        Dim fileToWrite As String = SetFilePath(decryptedFileTextBox.Text)
        If File.Exists(fileToRead) Then
            If OkToWriteFile(fileToWrite) Then
                DecryptFile(fileToRead, fileToWrite, (fileToRead + ".keyandiv"))
                MessageBox.Show("Decryption successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub clearFileTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        SetFileNames()
    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

#End Region

#Region " Encryption Procedures "

    Private Function EncryptFile(ByVal inputFile As String, ByVal outputFile As String) As Boolean
        Dim myRijndael As RijndaelManaged = New RijndaelManaged
        myRijndael.KeySize = 192
        myRijndael.GenerateKey()
        myRijndael.GenerateIV()

        ' Prepare file streams and crypto stream.
        Dim fsIn As FileStream = New FileStream(inputFile, FileMode.Open, FileAccess.Read)
        Dim fsOut As FileStream = New FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write)
        Dim myCryptoStream As CryptoStream = New CryptoStream(fsOut, myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV), CryptoStreamMode.Write)

        ' Prepare variables.
        Dim bufferSize As Integer = 4096 ' number of bytes to read at a time.
        Dim buffer() As Byte = New Byte((bufferSize) - 1) {}
        Dim inputFileSize As Long = New FileInfo(inputFile).Length
        Dim bytesRead As Integer = 0
        Dim totalBytesRead As Long = 0

        ' Read a block at a time until end of file.
        While (totalBytesRead < inputFileSize)
            bytesRead = fsIn.Read(buffer, 0, bufferSize)
            myCryptoStream.Write(buffer, 0, bytesRead)
            totalBytesRead = (totalBytesRead + CType(bytesRead, Long))
        End While

        ' Clean up.
        myCryptoStream.FlushFinalBlock()
        myCryptoStream.Close()
        fsIn.Close()
        fsOut.Close()

        ' Encrypt the key and vector asymmetrically, and write them to a file
        ' based on the name of the file being encrypted.
        Dim encryptedKeyAndIV() As Byte = EncryptKeyAndIV(myRijndael.Key, myRijndael.IV)
        fsOut = New FileStream((outputFile + ".keyandiv"), FileMode.Create, FileAccess.Write)
        fsOut.Write(encryptedKeyAndIV, 0, encryptedKeyAndIV.Length)
        fsOut.Close()
        Return True
    End Function

    Private Function DecryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal encryptedKeyFile As String) As Boolean
        Dim sr As FileStream = New FileStream(encryptedKeyFile, FileMode.Open, FileAccess.Read)

        ' Encrypted key and IV are both 128-byte arrays.
        Dim symKey() As Byte = New Byte((128) - 1) {}
        Dim symIV() As Byte = New Byte((128) - 1) {}
        sr.Read(symKey, 0, 128)
        sr.Read(symIV, 0, 128)
        sr.Close()
        DecryptKeyAndIV(symKey, symIV)
        Dim myRijndael As RijndaelManaged = New RijndaelManaged
        myRijndael.Key = symKey
        myRijndael.IV = symIV

        ' Prepare file stream and crypto stream.
        Dim fsIn As FileStream = New FileStream(inputFile, FileMode.Open, FileAccess.Read)
        Dim myCryptoStream As CryptoStream = New CryptoStream(fsIn, myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV), CryptoStreamMode.Read)
        Dim sw As StreamWriter = New StreamWriter(outputFile)
        sw.Write(New StreamReader(myCryptoStream).ReadToEnd)

        ' Clean up.
        sw.Flush()
        sw.Close()
        fsIn.Close()
        myCryptoStream.Close()
        Return True
    End Function

    ' Encrypt the symmetric key and initialization vector. You use asymmetric
    ' encryption to encrypt the symmetric key and vector, since asymmetric
    ' encryption does not require a shared key.
    '
    ' Typically, you encrypt the main document symmetrically, then encrypt the
    ' symmetric key and vector using the recipient's public key. The recipient
    ' can decrypt the key and IV using their private key, which is available
    ' to no-one else.
    '
    ' In this sample, the sender's public and private keys are used for both
    ' encryption and decryption.
    Private Function EncryptKeyAndIV(ByVal key() As Byte, ByVal iv() As Byte) As Byte()
        Dim rsaProv As RSACryptoServiceProvider = New RSACryptoServiceProvider

        ' Get the asymmetric key information from an XML file.
        rsaProv.FromXmlString(m_rsaKeyString)
        Dim ms As MemoryStream = New MemoryStream
        Dim encryptedKey() As Byte = rsaProv.Encrypt(key, False)
        ms.Write(encryptedKey, 0, encryptedKey.Length)
        Dim encryptedIV() As Byte = rsaProv.Encrypt(iv, False)
        ms.Write(encryptedIV, 0, encryptedIV.Length)
        Return ms.ToArray
    End Function

    ' Decrypt the symmetric key and IV. They will then be used to decrypt
    ' the main document.
    Private Function DecryptKeyAndIV(ByRef key() As Byte, ByRef iv() As Byte) As Boolean
        Dim rsaProv As RSACryptoServiceProvider = New RSACryptoServiceProvider

        ' Get the asymmetric key information from an XML file.
        rsaProv.FromXmlString(m_rsaKeyString)
        key = rsaProv.Decrypt(key, False)
        iv = rsaProv.Decrypt(iv, False)
        Return True
    End Function

#End Region

#Region " RSAKeyManagement "

    ' In this region you'll see how you can save and retrieve the keys from an
    ' RSACryptoServiceProvider. This NOT the optimum way to do it, it's done
    ' here simply for convenience. You should use a key container. See the
    ' documentation for more.
    '
    ' There's no user interface in this sample for these functions.
    Private Function WriteRSAKeysToXmlFile(ByVal rsaProv As RSACryptoServiceProvider, ByVal xmlFileToWrite As String) As Boolean
        Dim rsaKeyString As String = rsaProv.ToXmlString(True)
        Dim sw As StreamWriter = New StreamWriter(xmlFileToWrite)
        sw.Write(rsaKeyString)
        sw.Close()
        Return True
    End Function

    Private Function ReadRSAKeysFromXmlFile(ByVal xmlFileToRead As String) As String
        Dim sr As StreamReader = File.OpenText(xmlFileToRead)
        Dim rsaKeyString As String = sr.ReadToEnd
        sr.Close()
        Return rsaKeyString
    End Function

#End Region

#Region " Utility Functions "
    Private Sub SetFileNames()
        Dim fileName As String = Path.GetFileNameWithoutExtension(clearFileTextBox.Text.Trim)
        Dim fileExt As String = Path.GetExtension(clearFileTextBox.Text.Trim)
        encryptedFileTextBox.Text = (fileName + ("_encrypted." + fileExt))
        decryptedFileTextBox.Text = (fileName + ("_decrypted." + fileExt))
    End Sub

    Private Function SetFilePath(ByVal fileName As String) As String
        Return Path.Combine(workFolder, fileName)
    End Function

    Private Function OkToWriteFile(ByVal filePath As String) As Boolean
        If File.Exists(filePath.Trim) Then
            Dim fileName As String = Path.GetFileName(filePath)
            Dim msg As String = ("OK to overwrite " _
                        + (fileName + "?"))
            If (MessageBox.Show(msg, "Replace?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

#End Region

End Class

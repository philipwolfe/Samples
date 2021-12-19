Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits System.Windows.Forms.Form
    Private Shared symkey(8) As Byte
    Private Shared symIV(8) As Byte
    Private Shared passPhrase As String = "YourDog123"
    Private Shared inputFileName As String = "input.txt"
    Private Shared encrypedFileName As String = "encrypted.txt"
    Private Shared deencrypedFileName As String = "decrypted.txt"

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Overrides Public Sub Dispose()
        MyBase.Dispose

    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents btnEncrypt As System.Windows.Forms.Button
    
    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt.Location = New System.Drawing.Point(8, 24)
        Me.btnEncrypt.Size = New System.Drawing.Size(152, 32)
        Me.btnEncrypt.TabIndex = 0
        Me.btnEncrypt.Text = "Encrypt"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(192, 85)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEncrypt})
        Me.Text = "Encrypt"

    End Sub

#End Region
    
    Protected Sub btnEncrypt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEncrypt.click
        MsgBox("Creating Key", , "Encrypt")
        'fills in symKey and symIV arrays
        GenerateKeyFromPassPhrase(passPhrase)

        MsgBox("Encrypting " & inputFileName & " in the \bin directory for Encrypt", , "Encrypt")
        EncryptData(inputFileName, encrypedFileName)
        MsgBox("Decrypting to file " & encrypedFileName, , "Encrypt")
        DecryptData(encrypedFileName, deencrypedFileName)

    End Sub

    '/////////////////////////////////////////////////////////////
    ' Compute DESProvider Key and IV Values
    Public Shared Function GenerateKeyFromPassPhrase(ByVal phrase As String) As Boolean
        Try
            ' change the pass phrase into a form we can use
            Dim i As Integer
            Dim Len As Integer
            Dim CharPhrase() As Char = phrase.ToCharArray()
            Len = CharPhrase.GetLength(0)
            ' convert to byte array -  discard upper byte since is usually 0 in Eng.
            Dim BytePhrase(Len) As Byte
            For i = 0 To Len - 1
                BytePhrase(i) = CByte(AscW(CharPhrase(i)))  ' truncate char value
            Next i

            'do the hash operation 
            Dim SHAProvider As New SHA1CryptoServiceProvider()
            SHAProvider.ComputeHash(BytePhrase)

            ' use the low 64-bits for the key value
            ' Generate key and initialization vector based on passcodce.
            ' In symmetric encryption,
            ' Both users must have the same key in order to 
            ' encrypt/decrypt
            For i = 0 To 7
                symkey(i) = SHAProvider.Hash(i)
            Next i

            For i = 8 To 15
                symIV(i - 8) = SHAProvider.Hash(i)
            Next i

            GenerateKeyFromPassPhrase = True
        Catch e As Exception
            Console.WriteLine(e)
            GenerateKeyFromPassPhrase = False
        End Try
    End Function

    '/////////////////////////////////////////////////////////////
    ' Encrypt/Decrypt Data
    Public Shared Sub EncryptData(ByVal inName As String, ByVal outName As String)
        Try
            Dim i As Integer
            
            ' Open the input and output files
            Dim FileIn As FileStream = New FileStream(inName, FileMode.Open, FileAccess.Read)

            Dim FileOut As FileStream = New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)
            FileOut.SetLength(0)

            ' setup up variable to help with read
            Dim Bin(4096) As Byte
            Dim ReadLen As Long = 8
            Dim Len As Integer

            Dim DESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
            Dim CryptTransform As ICryptoTransform = DESProvider.CreateEncryptor(symkey, symIV)
            Dim DESEncrypt As CryptoStream = New CryptoStream(FileIn, CryptTransform, CryptoStreamMode.Read)

            ' Read data from file. When data moves into CrytptoStream, it is 
            ' automatically encrypted using the algorithm specified by provider
            Do
                Len = DESEncrypt.Read(Bin, 0, 4096)
                ' Write encrypted data to output file
                FileOut.Write(Bin, 0, Len)
                ReadLen = ReadLen + Len
                Console.WriteLine("Processed {0} bytes, {1} bytes total", Len, ReadLen)
            Loop While Len > 0

            FileIn.Close()
            FileOut.Close()

        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub

    Public Shared Sub DecryptData(ByVal inName As String, ByVal outName As String)
        Try
            Dim i As Integer

            ' Open the input and output files
            Dim FileIn As FileStream = New FileStream(inName, FileMode.Open, FileAccess.Read)

            Dim FileOut As FileStream = New FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write)
            FileOut.SetLength(0)

            ' setup up variable to help with read
            Dim Bin(4096) As Byte
            Dim ReadLen As Long = 8
            Dim Len As Integer

            Dim DESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()

            Dim CryptTransform As ICryptoTransform = DESProvider.CreateDecryptor(symkey, symIV)
            Dim DESDecrypt As CryptoStream = New CryptoStream(FileIn, CryptTransform, CryptoStreamMode.Read)

            ' Reverse of encryption. When data is read from file into CryptoStream
            ' it is automatically decrypted.
            Do
                Len = DESDecrypt.Read(Bin, 0, 4096)
                ' Write descrypted code to file
                FileOut.Write(bin, 0, Len)
                ReadLen = ReadLen + Len
                Console.WriteLine("Processed {0} bytes, {1} bytes total", Len, ReadLen)
            Loop While Len > 0

            FileIn.Close()
            FileOut.Close()

        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub
End Class



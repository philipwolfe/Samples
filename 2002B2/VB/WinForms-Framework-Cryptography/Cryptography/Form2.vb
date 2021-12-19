Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Public Class Form2
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overrides Sub Dispose()
        MyBase.Dispose()
        If Not (components Is Nothing) Then
            components.Dispose()
        End If
    End Sub
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents txtoriginal As System.Windows.Forms.TextBox
    Private WithEvents txtpasscode As System.Windows.Forms.TextBox
    Private WithEvents btnGenRdm As System.Windows.Forms.Button
    Private WithEvents Encrypt As System.Windows.Forms.Button
    Private WithEvents txtinputtext As System.Windows.Forms.TextBox
    Private WithEvents Decrypt As System.Windows.Forms.Button
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtencryptedtext As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents statusBar1 As System.Windows.Forms.StatusBar

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Decrypt = New System.Windows.Forms.Button()
        Me.txtpasscode = New System.Windows.Forms.TextBox()
        Me.btnGenRdm = New System.Windows.Forms.Button()
        Me.Encrypt = New System.Windows.Forms.Button()
        Me.txtinputtext = New System.Windows.Forms.TextBox()
        Me.txtoriginal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtencryptedtext = New System.Windows.Forms.TextBox()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(32, 32)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Passcode"
        Me.Decrypt.Location = New System.Drawing.Point(352, 292)
        Me.Decrypt.TabIndex = 3
        Me.Decrypt.Text = "Decrypt"
        Me.txtpasscode.Location = New System.Drawing.Point(160, 32)
        Me.txtpasscode.Size = New System.Drawing.Size(136, 20)
        Me.txtpasscode.TabIndex = 8
        Me.txtpasscode.Text = ""
        Me.btnGenRdm.Location = New System.Drawing.Point(308, 28)
        Me.btnGenRdm.Size = New System.Drawing.Size(132, 24)
        Me.btnGenRdm.TabIndex = 15
        Me.btnGenRdm.Text = "Generate Passcode"
        Me.Encrypt.Location = New System.Drawing.Point(352, 176)
        Me.Encrypt.TabIndex = 1
        Me.Encrypt.Text = "Encrypt"
        Me.txtinputtext.Location = New System.Drawing.Point(160, 88)
        Me.txtinputtext.Multiline = True
        Me.txtinputtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtinputtext.Size = New System.Drawing.Size(512, 68)
        Me.txtinputtext.TabIndex = 0
        Me.txtinputtext.Text = ""
        Me.txtoriginal.Location = New System.Drawing.Point(160, 348)
        Me.txtoriginal.Multiline = True
        Me.txtoriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtoriginal.Size = New System.Drawing.Size(512, 80)
        Me.txtoriginal.TabIndex = 9
        Me.txtoriginal.Text = ""
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(32, 352)
        Me.Label4.Size = New System.Drawing.Size(112, 48)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Original Input Text"
        Me.Label4.Visible = False
        Me.txtencryptedtext.Location = New System.Drawing.Point(160, 216)
        Me.txtencryptedtext.Multiline = True
        Me.txtencryptedtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtencryptedtext.Size = New System.Drawing.Size(512, 68)
        Me.txtencryptedtext.TabIndex = 2
        Me.txtencryptedtext.Text = ""
        Me.statusBar1.BackColor = System.Drawing.SystemColors.Control
        Me.statusBar1.Location = New System.Drawing.Point(0, 456)
        Me.statusBar1.Size = New System.Drawing.Size(683, 20)
        Me.statusBar1.TabIndex = 16
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(32, 216)
        Me.Label1.Size = New System.Drawing.Size(88, 36)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Encrypted Text"
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(32, 92)
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Input Text"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(683, 476)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusBar1, Me.Decrypt, Me.txtpasscode, Me.Label4, Me.btnGenRdm, Me.txtencryptedtext, Me.txtinputtext, Me.Encrypt, Me.Label3, Me.txtoriginal, Me.Label2, Me.Label1})
        Me.Text = "Form2"

    End Sub

#End Region

    

    Private Sub Encrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Encrypt.Click

        'write the contents of the text boxes to a file    
        If txtinputtext().Text = "" Then
            messagebox.Show("You must enter some text in the input text field")
            Return
        End If

        If txtpasscode().Text = "" Then
            messagebox.Show("You must enter some text in the input Passcode field")
            Return
        End If

        txtencryptedtext().Text = ""
        txtoriginal().Text = ""

        Dim StreamWrite As StreamWriter = File.CreateText("input.txt")
        StreamWrite.Write(txtinputtext().Text)
        StreamWrite.Close()

        StreamWrite = file.CreateText("output.txt")
        StreamWrite.Write("")
        StreamWrite.Close()

        statusBar1().Text = "Encrypting Input Text..."
        Dim Encryptor As New Encrypt()
        Encryptor.GenerateKeyFromPassPhrase(txtpasscode().Text)
        Encryptor.EncryptData("input.txt", "output.txt")

        'show the encrypted text
        Dim StreamRead As StreamReader = File.OpenText("output.txt")
        Do While StreamRead.Peek() <> -1
            txtencryptedtext().Text += StreamRead.ReadLine() & Chr(13) & Chr(10)
        Loop
        StreamRead.Close()

    End Sub

    Private Sub Decrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Decrypt.Click
        'Read the contents of the file we just created and output it to the textbox
        If txtencryptedtext().Text = "" Then
            statusBar1().Text = "You have no characters to decrypt"
            messagebox.Show("You have no characters to decrypt")
            Return
        End If

        statusBar1().Text = "Decrypting characters to readable text..."

        Dim Decryptor As New Encrypt()
        Decryptor.GenerateKeyFromPassPhrase(txtpasscode().Text)
        Decryptor.DecryptData("output.txt", "input.txt")

        Dim StreamRead As StreamReader = File.OpenText("input.txt")
        Do While StreamRead.Peek() <> -1
            txtoriginal().Text += StreamRead.ReadLine() & Chr(13) & Chr(10)
        Loop
        StreamRead.Close()
    End Sub

    Private Sub btnGenRdm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenRdm.Click
        Dim RandomNumber As New Random()
        txtpasscode().Text = RandomNumber.Next().ToString
        statusBar1().Text = "You have chosen to Randomly generate a passcode"

    End Sub

    
End Class

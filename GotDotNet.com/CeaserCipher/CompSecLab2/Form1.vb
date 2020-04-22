Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(144, 64)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TextBox2.Location = New System.Drawing.Point(144, 104)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(128, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Location = New System.Drawing.Point(144, 144)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(128, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(144, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Encrypt"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Key"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Plain Text"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cipher Text"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(8, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Decrypt"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Red
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(264, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cryptography and Cryptoanalysis"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "By Waqar Zafar (2002-CE-007)"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))
        Me.ClientSize = New System.Drawing.Size(280, 206)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Computer Security Lab # 2"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim letters(25), plain(), cipher() As Char
    Dim key As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim n, c, p As Integer

        ' filling letters array with a-z alphabets
        For ascii As Integer = 97 To 122
            letters(n) = Chr(ascii)
            n += 1
        Next

        TextBox3.Clear()
        ' filling plain array with user input
        plain = TextBox2.Text.ToCharArray()

        For num1 As Integer = 0 To plain.Length - 1
            For num2 As Integer = 0 To letters.Length - 1
                If plain(num1) = letters(num2) Then
                    p = num2
                End If
            Next
            c = (p + Convert.ToInt32(TextBox1.Text)) Mod 26
            TextBox3.Text += letters(c)

        Next

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Try

        Dim n, c, p, temp As Integer

        ' filling letters array with A-Z alphabets

        For ascii As Integer = 65 To 90
            letters(n) = Chr(ascii)
            n += 1
        Next

        TextBox2.Clear()
        ' filling plain array with user input
        cipher = TextBox3.Text.ToCharArray()

        For num1 As Integer = 0 To plain.Length - 1
            For num2 As Integer = 0 To letters.Length - 1
                If cipher(num1) = letters(num2) Then
                    c = num2
                End If
            Next

            If TextBox1.Text = Nothing Then

                temp = c - key

            Else
                temp = c - Convert.ToInt32(TextBox1.Text)
            End If


            If temp < 0 Then
                temp += 26
            End If

            p = temp Mod 26
            TextBox2.Text += letters(p)

        Next

        key += 1

        catch ex as Exception

            MessageBox.Show("No More decryptions")

        End Try

    End Sub

End Class

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Text

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container




    Private WithEvents Button1 As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button1.Location = New System.Drawing.Point(16, 24)
        Button1.Size = New System.Drawing.Size(120, 40)
        Button1.TabIndex = 0
        Button1.Text = "Manipulating strings"

        Me.Text = "VB.NET String Manipulation"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.Font = New System.Drawing.Font("Arial", 8!)
        Me.ClientSize = New System.Drawing.Size(240, 85)

        Me.Controls.Add(Button1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
        'Strings are immutable in VB.NET
        'So to change the contents of a String, you use the 
        'System.Text.StringBuilder class
        Dim OriginalString As String
        Dim NewString As String

        OriginalString = "VB's Basics"
        Dim Builder As New StringBuilder(OriginalString)
        Builder.Replace("'", "''")
        NewString = Builder.ToString()

        MessageBox.Show("String changed from: " & OriginalString & " to " & NewString, "Orignal and New Strings")

        'using AppendFormat you can format data then append it to a stringbuilder
        Builder.AppendFormat(" Today's date is:  {0,12:dd MMM, yyyy} and the time is {1,10:HH:mm:ss }", Now(), Now())
        'then use 
        MessageBox.Show(Builder.ToString(), "Appended the date/time")

        'use StringBuilder.Remove to remove characters from the string
        '** note that the first character is at position 0 not 1

        'The StringBuilder methods return the modified StringBuilder, so you 
        'can call ToString on the return value directly
        MessageBox.Show(Builder.Remove(0, 12).ToString(), "Removed the first 12 characters")

        'Similary, StringBuilder.Insert inserts characters
        'this inserts the word "now" between "time" and "is"
        MessageBox.Show(Builder.Insert(45, "now ").ToString(), "Inserted 'now'")
    End Sub

End Class

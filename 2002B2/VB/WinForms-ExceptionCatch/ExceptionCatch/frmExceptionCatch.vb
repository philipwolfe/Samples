Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents btnException As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnException = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Label1.Location = New System.Drawing.Point(8, 16)
        Label1.Text = "We're going to divide 10 by 0 and see what happens..."
        Label1.Size = New System.Drawing.Size(336, 32)
        Label1.TabIndex = 1

        btnException.Location = New System.Drawing.Point(104, 56)
        btnException.Size = New System.Drawing.Size(112, 24)
        btnException.TabIndex = 0
        btnException.Text = "Cause Exception"
        Me.Text = "Exception Test"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(320, 85)

        Me.Controls.Add(Label1)
        Me.Controls.Add(btnException)
    End Sub

#End Region

    Protected Sub btnException_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnException.click

        'This code shows how to catch an exception
        Try
            Dim i As Integer
            Dim j As Integer
            Dim k As Double

            'cause a divide by zero exception            
            i = 10
            j = 0
            k = i \ j

        Catch er As Exception

            ' Display the exception information
            MessageBox.Show(er.ToString)

        Finally

            MessageBox.Show(" The error was caught, now we can continue", "ExceptionCatch")

        End Try

    End Sub

End Class

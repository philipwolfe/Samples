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
    Private WithEvents btnException As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnException = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnException.Location = New System.Drawing.Point(48, 40)
        btnException.Size = New System.Drawing.Size(104, 24)
        btnException.TabIndex = 0
        btnException.Text = "Throw Exception"
        Me.Text = "Exception Throw"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(216, 101)

        Me.Controls.Add(btnException)
    End Sub

#End Region

    Protected Sub btnException_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnException.click
        'this code shows how to catch an exception
        Try

            ' Tell the user what we're going to do and cause the exception
            MessageBox.Show("We're going to call our mehod with two args, one valid and one invalid", "Throw Exception")
            MessageBox.Show("Trying to call the method wih an argument of 1", "Throw Exception")

            ' This call will work
            SeeIfIntIsOne(1)

            MessageBox.Show("Trying to call the method with an argument of 2", "Throw Exception")
            ' This call will cause an exception
            SeeIfIntIsOne(2)

        Catch er As Exception
            ' Display the exception message
            MessageBox.Show("The following error occured: " & er.ToString(), "Exception Occured")

        Finally

            MessageBox.Show("Now we can Continue", "Throw Exception")
        End Try


    End Sub

    Public Shared Function SeeIfIntIsOne(ByVal i As Integer) As String

        Dim s As String
        s = "You passed in 1"

        ' If the value passed in is anything other than one, throw the exception
        If i = 1 Then
            Return s
        Else
            Throw New ArgumentException("Your integer was not 1")
            ' it should be noted that this exception does not utilize the Runtime's resource
            ' system which would make the text of the exception easily localizable.
            ' For examples of using resources, see the Resources section of Quickstart.
        End If
    End Function
End Class

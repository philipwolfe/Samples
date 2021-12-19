Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class ExceptionHandlingForm
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New()
        
        ExceptionHandlingForm = Me
        
        'This call is required by the Win Form Designer.
        InitializeComponent()
        
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
    Private WithEvents Label3 As System.Windows.Forms.Label

    Private WithEvents grpExample3 As System.Windows.Forms.GroupBox
    Private WithEvents Label2 As System.Windows.Forms.Label

    Private WithEvents btnExample2 As System.Windows.Forms.Button
    Private WithEvents grpExample2 As System.Windows.Forms.GroupBox





    Private WithEvents btnExample1 As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label






    Private WithEvents grpExample1 As System.Windows.Forms.GroupBox

    Private WithEvents btnExample3 As System.Windows.Forms.Button




    Dim WithEvents ExceptionHandlingForm As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnExample3 = New System.Windows.Forms.Button()
        Me.btnExample2 = New System.Windows.Forms.Button()
        Me.btnExample1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpExample3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpExample2 = New System.Windows.Forms.GroupBox()
        Me.grpExample1 = New System.Windows.Forms.GroupBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnExample3.Location = New System.Drawing.Point(208, 184)
        btnExample3.Size = New System.Drawing.Size(75, 23)
        btnExample3.TabIndex = 2
        btnExample3.Text = "Example 3"

        btnExample2.Location = New System.Drawing.Point(200, 22)
        btnExample2.Size = New System.Drawing.Size(75, 23)
        btnExample2.TabIndex = 1
        btnExample2.Text = "Example 2"

        btnExample1.Location = New System.Drawing.Point(200, 24)
        btnExample1.Size = New System.Drawing.Size(72, 24)
        btnExample1.TabIndex = 5
        btnExample1.Text = "Example 1"

        Label2.Location = New System.Drawing.Point(8, 24)
        Label2.Text = "Try..Catch..Finally block"
        Label2.Size = New System.Drawing.Size(184, 23)
        Label2.TabIndex = 6

        Label1.Location = New System.Drawing.Point(8, 24)
        Label1.Text = "Basic Try..Catch block"
        Label1.Size = New System.Drawing.Size(168, 16)
        Label1.TabIndex = 6

        grpExample3.Location = New System.Drawing.Point(8, 160)
        grpExample3.TabIndex = 6
        grpExample3.TabStop = False
        grpExample3.Size = New System.Drawing.Size(280, 64)

        Label3.Location = New System.Drawing.Point(8, 24)
        Label3.Text = "Catching specific exception types"
        Label3.Size = New System.Drawing.Size(184, 23)
        Label3.TabIndex = 7

        grpExample2.Location = New System.Drawing.Point(8, 88)
        grpExample2.TabIndex = 5
        grpExample2.TabStop = False
        grpExample2.Size = New System.Drawing.Size(280, 64)

        grpExample1.Location = New System.Drawing.Point(8, 16)
        grpExample1.TabIndex = 4
        grpExample1.TabStop = False
        grpExample1.Size = New System.Drawing.Size(280, 64)
        Me.Text = "Exception Handling Sample"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        grpExample3.Controls.Add(Label3)
        grpExample2.Controls.Add(Label2)
        grpExample2.Controls.Add(btnExample2)
        grpExample1.Controls.Add(btnExample1)
        grpExample1.Controls.Add(Label1)
        Me.Controls.Add(grpExample1)
        Me.Controls.Add(btnExample3)
        Me.Controls.Add(grpExample2)
        Me.Controls.Add(grpExample3)
    End Sub

#End Region


    Protected Sub btnExample1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample1.click
        ' This example shows the basic structured exception handling,the try..catch block

        ' Code that might throw an exception is wrapped in a Try block
        Try
            Dim x As Integer = 0
            Dim y As Integer = 10
            Dim z As Integer

            ' This will cause an exception to be thrown
            z = CInt(y / x)

            ' The following line will never execute because the Exception thrown in the line
            ' above transfers execution to the Catch block
            MessageBox.Show("End of Try block")

        Catch exc As Exception
            ' This Catch block will execute when any exception is thrown from the Try block
            MessageBox.Show("Exception Caught")
        End Try

    End Sub

    Protected Sub btnExample2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample2.click
        ' This example expands on basic exception handling by adding the Finally block

        ' Code that might throw an exception is wrapped in a Try block
        Try
            'Manually throw an exception of type ArgumentException
            Throw New ArgumentException()

            ' The following line will never execute because the Exception thrown in the line
            ' above transfers execution to the Catch block
            MessageBox.Show("End of Try block")

        Catch exc As Exception
            ' This Catch block will execute when any exception is thrown from the Try block
            MessageBox.Show("Exception Caught")
        Finally
            ' Code in the Finally block will always execute. It can be used to do cleanup that
            ' is necessary even if an exception is thrown. Like closing a file or socket.
            MessageBox.Show("Finally code always executes")
        End Try

    End Sub

    Protected Sub btnExample3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample3.click
        ' This example adds a Catch block that will only catch a specific type of exception.
        ' In this case it catches an OverflowException, but other Catch blocks can be added
        ' to catch other types of excpetions.

        ' Code that might throw an exception is wrapped in a Try block
        Try
            Dim x As Integer = 0
            Dim y As Integer = 10
            Dim z As Integer

            ' This will cause an OverflowException to be thrown
            z = CInt(y / x)

            ' The following line will never execute because the Exception thrown in the line
            ' above transfers execution to the Catch block
            MessageBox.Show("End of Try block")

        Catch excOverflow As OverflowException
            ' This Catch block will execute when an OverflowException is thrown from the Try block
            ' Any other type of exception will be caught by the Catch block for generic Exception
            '  types below
            MessageBox.Show("Overflow Exception Caught")

        Catch exc As Exception
            ' This catch block will execute when any exception is thrown and not caught in
            ' a previous Catch block
            MessageBox.Show("Generic Exception Caught")
        Finally
            ' Code in the Finally block will always execute. It can be used to do cleanup that
            ' is necessary even if an exception is thrown. Like closing a file or socket.
            MessageBox.Show("Finally code always executes")
        End Try

    End Sub

End Class

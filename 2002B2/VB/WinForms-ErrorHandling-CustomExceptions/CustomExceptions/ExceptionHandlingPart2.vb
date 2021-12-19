Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class ExceptionHandlingPart2
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New()
        
        ExceptionHandlingPart2 = Me
        
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

    Private WithEvents btnExample3 As System.Windows.Forms.Button
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label2 As System.Windows.Forms.Label

    Private WithEvents btnExample2 As System.Windows.Forms.Button
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents Label1 As System.Windows.Forms.Label

    Private WithEvents grpExample1 As System.Windows.Forms.GroupBox


    Private WithEvents btnExample1 As System.Windows.Forms.Button

    Dim WithEvents ExceptionHandlingPart2 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnExample3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExample1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExample2 = New System.Windows.Forms.Button()
        Me.grpExample1 = New System.Windows.Forms.GroupBox()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnExample3.Location = New System.Drawing.Point(200, 24)
        btnExample3.Size = New System.Drawing.Size(75, 23)
        btnExample3.TabIndex = 2
        btnExample3.Text = "Example 3"

        GroupBox1.Location = New System.Drawing.Point(8, 80)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Size = New System.Drawing.Size(280, 64)

        btnExample1.Location = New System.Drawing.Point(208, 32)
        btnExample1.Size = New System.Drawing.Size(75, 23)
        btnExample1.TabIndex = 0
        btnExample1.Text = "Example 1"

        Label2.Location = New System.Drawing.Point(8, 24)
        Label2.Text = "Catch an exception thrown from another object"
        Label2.Size = New System.Drawing.Size(184, 23)
        Label2.TabIndex = 5

        Label1.Location = New System.Drawing.Point(8, 24)
        Label1.Text = "Throw a custom error"
        Label1.Size = New System.Drawing.Size(184, 23)
        Label1.TabIndex = 4

        Label3.Location = New System.Drawing.Point(8, 24)
        Label3.Text = "Nest Try blocks"
        Label3.Size = New System.Drawing.Size(184, 23)
        Label3.TabIndex = 6

        GroupBox2.Location = New System.Drawing.Point(8, 152)
        GroupBox2.TabIndex = 5
        GroupBox2.TabStop = False
        GroupBox2.Size = New System.Drawing.Size(280, 64)

        btnExample2.Location = New System.Drawing.Point(200, 24)
        btnExample2.Size = New System.Drawing.Size(75, 23)
        btnExample2.TabIndex = 1
        btnExample2.Text = "Example 2"

        grpExample1.Location = New System.Drawing.Point(8, 8)
        grpExample1.TabIndex = 3
        grpExample1.TabStop = False
        grpExample1.Size = New System.Drawing.Size(280, 64)
        Me.Text = "Exception Handling Sample - Part 2"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)

        Me.Controls.Add(GroupBox2)
        Me.Controls.Add(GroupBox1)
        Me.Controls.Add(btnExample1)
        Me.Controls.Add(grpExample1)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(btnExample3)
        grpExample1.Controls.Add(Label1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(btnExample2)
    End Sub

#End Region

    Protected Sub btnExample1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample1.click
        'This example shows how you can throw and catch an exception of your own type.
        ' The custom exception is defined as a class called InsufficientFundsException
        ' that inherits from Exception

        Try
            ' Create a new instance of InsufficientFundsException and throw it
            Throw New InsufficientFundsException()

        Catch excInsufficientFunds As InsufficientFundsException
            ' This Catch will only execute if an exception of type InsuficientFundsException is thrown
            ' If this catch was missing, then the generic Catch below would catch the
            '  thrown InsufficientFundsException
            MessageBox.Show("Insufficient Funds Exception Caught: " & Chr(10) & Chr(13) & excInsufficientFunds.ToString())

        Catch exc As Exception
            ' This will catch any excption, not already caught above. In this example this
            ' code will not execute
            MessageBox.Show("Exception Caught: " & Chr(10) & Chr(13) & exc.ToString())

        End Try
    End Sub

    Protected Sub btnExample2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample2.click
        'This example shows how an exception can be thrown from another object and still
        ' be caught locally. 
        Try
            'Create a new instance of MyAccount
            Dim Account As New MyAccount()

            'Try to withdraw more than is available (5 is available). objMyAccount will
            ' throw an InsufficientFundsException
            Account.WithDraw(10)

            'This code will never execute since an exception was thrown above
            MessageBox.Show("Withdraw Successful")

        Catch exc As Exception
            'Catch any exception that was thrown
            MessageBox.Show("Exception Caught in btnExample2_Click: " & Chr(10) & Chr(13) & exc.ToString())

        End Try
    End Sub

    Protected Sub btnExample3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExample3.click
        'This example shows how you can nest Try..Catch blocks within the same function.

        Dim Value As Integer = 0

        'Start the outer Try block
        Try
            'Do some processing
            Value += 4

            'Start the inner Try block
            Try
                'Do some processing
                Value += 30

                'Throw an exception, it will be caught in the inner Try block
                Throw New OverflowException()

            Catch exc As Exception
                'Catch exceptions thrown in the inner Try block
                MessageBox.Show("Exception Caught in Inner Block.  Value = " & Value)
            Finally
                'The Finally code will execute, even if an exception was thrown
                Value += 200
                MessageBox.Show("Inner Block Finally code always executes.  Value = " & Value)
            End Try

            'Do some processing
            Value += 1000

            'Thow an exception, this one is caught in the outer Try block
            Throw New OverflowException()

        Catch exc As Exception
            'Catch exceptions in the Outer Try block
            MessageBox.Show("Exception Caught in Outer Block.  Value = " & Value)
        Finally
            'Just a reminder, Finally code always executes
            MessageBox.Show("Finally code always executes")
        End Try
    End Sub

End Class

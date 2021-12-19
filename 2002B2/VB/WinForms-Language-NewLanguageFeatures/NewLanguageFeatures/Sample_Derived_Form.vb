Imports System.ComponentModel
Imports System.Drawing

Imports System.Windows.Forms



Public Class Sample_Derived_Form
    Inherits New_Language_Features.Sample_Base_Form
    
    Public Sub New()
        MyBase.New()
        
        Sample_Derived_Form = Me
        
        'This call is required by the WinForm Designer.
        InitializeComponent()
        
        'TODO: Add any initialization after the InitializeComponent call
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the WinForm Designer
    Private Shadows components As System.ComponentModel.Container

    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents btnDerivedCallTest As System.Windows.Forms.Button
    Private WithEvents btnDerivedMessage As System.Windows.Forms.Button
    Dim WithEvents Sample_Derived_Form As New_Language_Features.Sample_Base_Form

    'NOTE: The following procedure is required by the WinForm Designer
    'It can be modified using the WinForm Designer.  
    'Do not modify it using the code editor.
    Private Shadows Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnDerivedCallTest = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDerivedMessage = New System.Windows.Forms.Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnDerivedCallTest.Location = New System.Drawing.Point(80, 80)
        btnDerivedCallTest.Size = New System.Drawing.Size(64, 40)
        btnDerivedCallTest.TabIndex = 4
        btnDerivedCallTest.Text = "New Call Test"

        Label1.Location = New System.Drawing.Point(8, 8)
        Label1.Text = "Message button, Call Test Buton, and Load Derived Window link is defined in the base window along with the event handlers for the controls."
        Label1.Size = New System.Drawing.Size(296, 40)
        Label1.TabIndex = 5

        btnDerivedMessage.Location = New System.Drawing.Point(8, 80)
        btnDerivedMessage.Size = New System.Drawing.Size(64, 40)
        btnDerivedMessage.TabIndex = 3
        btnDerivedMessage.Text = "New Message"
        Me.Text = "Derived Form"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(288, 125)

        Me.Controls.Add(Label1)
        Me.Controls.Add(btnDerivedCallTest)
        Me.Controls.Add(btnDerivedMessage)
    End Sub
#End Region



    Protected Sub btnDerivedCallTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDerivedCallTest.Click
        MessageBox.Show(Test())
    End Sub

    Protected Sub btnDerivedMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDerivedMessage.Click
        'The control on the Derived form call the FormMessage on the
        'Base Form
        MessageBox.Show(FormMessage())
    End Sub

    Protected Overrides Function Test() As String
        'Overrides the base forms Test method
        Return "Message from the derived window." & Chr(10) & Chr(13) & _
                 "Plus: " & MyBase.Test 'Calls to the base form implementation of Test
    End Function
End Class

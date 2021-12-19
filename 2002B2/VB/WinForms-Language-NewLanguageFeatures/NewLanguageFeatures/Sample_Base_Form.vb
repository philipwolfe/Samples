Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class Sample_Base_Form
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        Sample_Base_Form = Me

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
    Private WithEvents btnTest As System.Windows.Forms.Button
    Private WithEvents lnkLoadDerivedWindow As System.Windows.Forms.LinkLabel
    Private WithEvents btnMessage As System.Windows.Forms.Button




    Dim WithEvents Sample_Base_Form As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnMessage = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lnkLoadDerivedWindow = New System.Windows.Forms.LinkLabel()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnMessage.Location = New System.Drawing.Point(8, 48)
        btnMessage.Size = New System.Drawing.Size(64, 24)
        btnMessage.TabIndex = 3
        btnMessage.Text = "Message"

        btnTest.Location = New System.Drawing.Point(80, 48)
        btnTest.Size = New System.Drawing.Size(64, 24)
        btnTest.TabIndex = 5
        btnTest.Text = "Call Test"

        lnkLoadDerivedWindow.Text = "Load Derived Window"
        lnkLoadDerivedWindow.Size = New System.Drawing.Size(112, 16)
        lnkLoadDerivedWindow.TabIndex = 4
        lnkLoadDerivedWindow.TabStop = True
        lnkLoadDerivedWindow.Location = New System.Drawing.Point(168, 48)
        Me.Text = "Sample_Derived_Form"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 77)

        Me.Controls.Add(btnTest)
        Me.Controls.Add(lnkLoadDerivedWindow)
        Me.Controls.Add(btnMessage)
    End Sub

#End Region

    Public Sub btnTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTest.Click
        MessageBox.Show(Test())
    End Sub

    Protected Sub lnkLoadDerivedWindow_LinkClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLoadDerivedWindow.Click
        Dim frmDerived As Sample_Derived_Form
        frmDerived = New Sample_Derived_Form()
        frmDerived.ShowDialog()

    End Sub

    Protected Sub btnMessage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMessage.Click

        MessageBox.Show(FormMessage())

    End Sub
    'Protected functions are exposed to derived forms
    Protected Function FormMessage() As String
        Return "Message from the base window."
    End Function

    'The function can be overridden in derived forms.
    Protected Overridable Function Test() As String
        Return "From Test function in base class."
    End Function


End Class

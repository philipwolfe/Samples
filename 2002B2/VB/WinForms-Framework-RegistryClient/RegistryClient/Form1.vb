Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class Form1
    Inherits System.Windows.Forms.Form
    
    Public Sub New()
        MyBase.New

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()
        
        InitializeForm()
        
        'TODO: Add any initialization after the InitializeComponent() call
    End Sub
    
    Private Sub InitializeForm()
        
    End Sub
    
    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()

        MyBase.Dispose()
        components.Dispose()

    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents lblValue As System.Windows.Forms.Label
    Private WithEvents Label7 As System.Windows.Forms.Label

    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents btnGet As System.Windows.Forms.Button
    Private WithEvents txtGetEntry As System.Windows.Forms.TextBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtValue As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents btnSet As System.Windows.Forms.Button
    Private WithEvents txtEntry As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents btnCreate As System.Windows.Forms.Button
    Private WithEvents txtKey As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label











    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.txtEntry = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.btnGet = New System.Windows.Forms.Button()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.txtGetEntry = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        txtValue.Location = New System.Drawing.Point(84, 120)
        txtValue.Text = "My Test Value"
        txtValue.TabIndex = 16
        txtValue.Size = New System.Drawing.Size(172, 20)

        txtEntry.Location = New System.Drawing.Point(84, 92)
        txtEntry.Text = "SampleValue"
        txtEntry.TabIndex = 13
        txtEntry.Size = New System.Drawing.Size(172, 20)

        Label5.Location = New System.Drawing.Point(20, 188)
        Label5.Text = "Entry:"
        Label5.Size = New System.Drawing.Size(68, 16)
        Label5.TabIndex = 18

        Label4.Location = New System.Drawing.Point(12, 72)
        Label4.Text = "Specify the Registry value to set:"
        Label4.Size = New System.Drawing.Size(340, 16)
        Label4.TabIndex = 17

        Label1.Location = New System.Drawing.Point(16, 16)
        Label1.Text = "Specify the HKEY_CURRENT_USER Registry Key to Create:"
        Label1.Size = New System.Drawing.Size(340, 16)
        Label1.TabIndex = 9

        Label2.Location = New System.Drawing.Point(16, 96)
        Label2.Text = "Entry:"
        Label2.Size = New System.Drawing.Size(68, 16)
        Label2.TabIndex = 12

        txtKey.Location = New System.Drawing.Point(16, 36)
        txtKey.Text = "Software\VB Registry Test"
        txtKey.TabIndex = 10
        txtKey.Size = New System.Drawing.Size(240, 20)

        btnGet.Location = New System.Drawing.Point(268, 208)
        btnGet.Size = New System.Drawing.Size(75, 23)
        btnGet.TabIndex = 20
        btnGet.Text = "Get"

        lblValue.Location = New System.Drawing.Point(92, 216)
        lblValue.Size = New System.Drawing.Size(168, 16)
        lblValue.TabIndex = 24

        Label3.Location = New System.Drawing.Point(16, 124)
        Label3.Text = "Value:"
        Label3.Size = New System.Drawing.Size(68, 16)
        Label3.TabIndex = 15

        btnCreate.Location = New System.Drawing.Point(264, 36)
        btnCreate.Size = New System.Drawing.Size(75, 23)
        btnCreate.TabIndex = 11
        btnCreate.Text = "Create"

        Label6.Location = New System.Drawing.Point(20, 216)
        Label6.Text = "Value:"
        Label6.Size = New System.Drawing.Size(68, 16)
        Label6.TabIndex = 21

        btnSet.Location = New System.Drawing.Point(264, 116)
        btnSet.Size = New System.Drawing.Size(75, 23)
        btnSet.TabIndex = 14
        btnSet.Text = "Set"

        txtGetEntry.Location = New System.Drawing.Point(88, 184)
        txtGetEntry.Text = "SampleValue"
        txtGetEntry.TabIndex = 19
        txtGetEntry.Size = New System.Drawing.Size(172, 20)

        Label7.Location = New System.Drawing.Point(16, 164)
        Label7.Text = "Specify the Registry value to read:"
        Label7.Size = New System.Drawing.Size(340, 16)
        Label7.TabIndex = 23
        Me.Text = "Registry Client"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 265)

        Me.Controls.Add(lblValue)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label6)
        Me.Controls.Add(btnGet)
        Me.Controls.Add(txtGetEntry)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(txtValue)
        Me.Controls.Add(Label3)
        Me.Controls.Add(btnSet)
        Me.Controls.Add(txtEntry)
        Me.Controls.Add(Label2)
        Me.Controls.Add(btnCreate)
        Me.Controls.Add(txtKey)
        Me.Controls.Add(Label1)
    End Sub

#End Region

    Protected Sub btnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGet.click
        'get the requested registry value
        Dim Reg As RegistryKey

        'open the registry key
        Reg = Registry.CurrentUser.OpenSubKey(txtKey.Text)

        'get the requested value
        lblValue.Text = Reg.GetValue(txtGetEntry.Text).ToString

        'close the key
        Reg.Close()

    End Sub


    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.click
        'create the requested registry key
        Dim Reg As RegistryKey

        'create the new registry key under HKEY_CURRENT_USER
        Reg = Registry.CurrentUser.CreateSubKey(txtKey.Text)

        'let the user know it's done
        MessageBox.Show("Registry Key " & Reg.Name & " was created.", "Registry Client")

    End Sub

    Protected Sub btnSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSet.click
        'Set the new registry value
        Dim Reg As RegistryKey

        'open the key with write access
        Reg = Registry.CurrentUser.OpenSubKey(txtKey.Text, True)
        'setup the value
        Reg.SetValue(txtEntry.Text, txtValue.Text)

        'let the user know it's done
        MessageBox.Show("Registry Value " & txtEntry.Text & " - " & txtValue.Text & " saved.", "Registry Client")

        'close the key
        Reg.Close()
    End Sub


End Class

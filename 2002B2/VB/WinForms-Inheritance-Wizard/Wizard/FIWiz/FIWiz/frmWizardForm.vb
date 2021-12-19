'*****************************************************************************
'Form Inheritance Example - Parent Form
'Microsoft VB.Net Beta 1 Resource CD
'02/19/2001
'*****************************************************************************
Imports System.Drawing
Imports System.Windows.Forms

Imports System.ComponentModel

Public Class frmWizardForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New

        frmWizardForm = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

       'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Overrides Public Sub Dispose()
        MyBase.Dispose
        components.Dispose
    End Sub 

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    
    Protected WithEvents btnFinish As System.Windows.Forms.Button
    Protected WithEvents btnNext As System.Windows.Forms.Button
    Protected WithEvents btnBack As System.Windows.Forms.Button
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    
    Dim WithEvents frmWizardForm As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWizardForm))
        
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnCancel.Location = New System.Drawing.Point(36, 232)
        btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        btnCancel.Size = New System.Drawing.Size(75, 23)
        btnCancel.TabIndex = 0
        btnCancel.Text = "Cancel"
        
        btnBack.Location = New System.Drawing.Point(120, 232)
        btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        btnBack.Size = New System.Drawing.Size(75, 23)
        btnBack.TabIndex = 1
        btnBack.Text = "<< Back"
        
        btnFinish.Location = New System.Drawing.Point(280, 232)
        btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        btnFinish.Size = New System.Drawing.Size(75, 23)
        btnFinish.TabIndex = 3
        btnFinish.Text = "Finish"
        
        btnNext.Location = New System.Drawing.Point(196, 232)
        btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        btnNext.Size = New System.Drawing.Size(75, 23)
        btnNext.TabIndex = 2
        btnNext.Text = "Next >>"
        Me.Text = "frmWizardForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(376, 273)
        
        Me.Controls.Add(btnFinish)
        Me.Controls.Add(btnNext)
        Me.Controls.Add(btnBack)
        Me.Controls.Add(btnCancel)
    End Sub
    
#End Region
    
    
    'btnFinish_Click is not allowed to be called from an inherited form
    Protected Sub btnFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFinish.click
        Application.Exit()
    End Sub

    'btnBack_Click is allowed to be called from an inherited form because of the Overridable kayword
    Protected Overridable Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.click

    End Sub

    'btnNext_Click is allowed to be called from an inherited form because of the Overridable kayword
    Protected Overridable Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.click

    End Sub

    'btnCancel_Click is not allowed to be called from an inherited form
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.click
        Application.Exit()
    End Sub




End Class

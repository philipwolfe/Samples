'//------------------------------------------------------------------------------
'/// <copyright from='1997' to='2001' company='Microsoft Corporation'>
'///    Copyright (c) Microsoft Corporation. All Rights Reserved.
'///
'///    This source code is intended only as a supplement to Microsoft
'///    Development Tools and/or on-line documentation.  See these other
'///    materials for detailed information regarding Microsoft code samples.
'///
'/// </copyright>
'//------------------------------------------------------------------------------'
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
Imports Microsoft.VisualBasic

Namespace Microsoft.Samples.Windows.Forms.VB.Docking

    Public Class Docking
        Inherits System.Windows.Forms.Form

        Private d As System.Collections.Hashtable

        Public Sub New()

            MyBase.New()

            Docking = Me

            'This call is required by the Win Form Designer.
            InitializeComponent()

            'TODO: Add any initialization after the InitializeComponent call

            'Wire up event handlers
            AddHandler Button1.Click, AddressOf Button1_Click
            AddHandler ToolBar1.ButtonClick, AddressOf ToolBar1_ButtonClick

            'Set up hashtable with DockStyle values
            d = New System.Collections.Hashtable()
            d.Add("Left", DockStyle.Left)
            d.Add("Right", DockStyle.Right)
            d.Add("Top", DockStyle.Top)
            d.Add("Bottom", DockStyle.Bottom)
            d.Add("None", DockStyle.None)
            d.Add("Fill", DockStyle.Fill)

        End Sub

        'Form overrides dispose to clean up the component list.
        Public Overloads Overrides Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub

        'The main entry point for the application
        <STAThread()> Shared Sub Main()
            System.Windows.Forms.Application.Run(New Docking())
        End Sub

#Region " Windows Form Designer generated code "

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.Container
        Private StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
        Private StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
        Private WithEvents StatusBar1 As System.Windows.Forms.StatusBar
        Private ToolBarButton6 As System.Windows.Forms.ToolBarButton
        Private ToolBarButton5 As System.Windows.Forms.ToolBarButton
        Private ToolBarButton4 As System.Windows.Forms.ToolBarButton
        Private ToolBarButton3 As System.Windows.Forms.ToolBarButton
        Private ToolBarButton2 As System.Windows.Forms.ToolBarButton
        Private ToolBarButton1 As System.Windows.Forms.ToolBarButton
        Private WithEvents ToolBar1 As System.Windows.Forms.ToolBar
        Private WithEvents Button1 As System.Windows.Forms.Button

        Dim WithEvents Docking As System.Windows.Forms.Form

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.ToolBarButton6 = New System.Windows.Forms.ToolBarButton()
            Me.StatusBar1 = New System.Windows.Forms.StatusBar()
            Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
            Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
            Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
            Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.ToolBar1 = New System.Windows.Forms.ToolBar()
            Me.ToolBarButton5 = New System.Windows.Forms.ToolBarButton()
            Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
            Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel()

            StatusBarPanel1.BeginInit()
            StatusBarPanel2.BeginInit()

            '@design Me.TrayLargeIcon = False
            '@design Me.TrayAutoArrange = True
            '@design Me.TrayHeight = 90
            Me.Text = "Docking"
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(520, 378)

            ToolBarButton6.Text = "Fill"

            StatusBar1.BackColor = System.Drawing.SystemColors.Control
            StatusBar1.Location = New System.Drawing.Point(0, 358)
            StatusBar1.Size = New System.Drawing.Size(520, 20)
            StatusBar1.TabIndex = 2
            StatusBar1.Text = "Use the ToolBar buttons to change the button1.Dock property and then resize the form"
            StatusBar1.Panels.Add(StatusBarPanel1)
            StatusBar1.Panels.Add(StatusBarPanel2)

            ToolBarButton4.Text = "Bottom"

            ToolBarButton2.Text = "Right"

            ToolBarButton3.Text = "Top"

            ToolBarButton1.Text = "Left"

            Button1.BackColor = System.Drawing.SystemColors.Desktop
            Button1.Size = New System.Drawing.Size(176, 56)
            Button1.TabIndex = 0
            Button1.Anchor = CType(15, System.Windows.Forms.AnchorStyles)
            Button1.Location = New System.Drawing.Point(168, 168)
            Button1.Text = "Button1" & Chr(13) & "(click to set Dock to DockStyle.None)"

            ToolBar1.Size = New System.Drawing.Size(520, 40)
            ToolBar1.TabIndex = 1
            ToolBar1.DropDownArrows = True
            ToolBar1.ShowToolTips = True
            ToolBar1.Buttons.Add(ToolBarButton1)
            ToolBar1.Buttons.Add(ToolBarButton2)
            ToolBar1.Buttons.Add(ToolBarButton3)
            ToolBar1.Buttons.Add(ToolBarButton4)
            ToolBar1.Buttons.Add(ToolBarButton5)
            ToolBar1.Buttons.Add(ToolBarButton6)

            ToolBarButton5.Text = "None"

            '@design StatusBarPanel1.SetLocation(New System.Drawing.Point(7, 7))
            StatusBarPanel1.Text = "Panel1"

            '@design StatusBarPanel2.SetLocation(New System.Drawing.Point(130, 7))
            StatusBarPanel2.Text = "Panel2"
            Me.Controls.Add(StatusBar1)
            Me.Controls.Add(ToolBar1)
            Me.Controls.Add(Button1)

            StatusBarPanel1.EndInit()
            StatusBarPanel2.EndInit()
        End Sub

#End Region

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.click
            Button1.Dock = DockStyle.None
            Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Left
        End Sub

        Private Sub ToolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
            Button1.Dock = CType(d(e.Button.Text), DockStyle)
            If e.Button.Text = "None" Then
                Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Left
            End If
        End Sub

    End Class

End Namespace
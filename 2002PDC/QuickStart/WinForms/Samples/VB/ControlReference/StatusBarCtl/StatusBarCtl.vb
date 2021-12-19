'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------
Option Strict Off
Option Explicit

Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.WinForms

Namespace StatusBarCtl

    ' <doc>
    ' <desc>
    '     This class demonstrates the StatusBar control.
    ' </desc>
    ' </doc>
    '
    Public class StatusBarCtl
		Inherits System.WinForms.Form

        Public Sub New
			MyBase.New()
             	
            ' This call is required for support of the WFC Form Designer.
            InitializeComponent()

            trackBar.Maximum = panel1.Width
            trackBar.Minimum = panel1.Width/2
            comboBox1.SelectedIndex = 0
            comboBox2.SelectedIndex = 1
            trackBar.Value = panel1.Width

            'Set the initial state of the Keyboard Status StatusBarPanel
            Me.sbPnlInsOvr.Text = "OVR" 
        End Sub

        ' <doc>
        ' <desc>
        '     StatusBarCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        OverRides Public Sub Dispose()
            MyBase.Dispose()
            components.Dispose()
        End Sub

        Private Sub chkSizingGrip_Click(Sender As Object, e As EventArgs)
            statusBar.SizingGrip = chkSizingGrip.Checked
        End Sub

        Private Sub chkShowPanels_Click(Sender As Object, e As EventArgs)
            statusBar.ShowPanels = chkShowPanels.Checked
        End Sub

        Private Sub trackBar1_Scroll(Sender As Object, e As EventArgs)
            panel1.Width = trackBar.Value
        End Sub

        Private Sub comboBox1_SelectedIndexChanged(Sender As Object, e As EventArgs)
            Me.statusBarPanel1.BorderStyle = comboBox1.SelectedIndex+1
        End Sub

        Private Sub statusBarSample_KeyUp(Sender As Object, e As KeyEventArgs)
            if e.KeyCode = Keys.Insert Then
                Dim s As String = Me.sbPnlInsOvr.Text
                If s.Equals("INS") Then
                    Me.sbPnlInsOvr.Text = "OVR"
                Else
                    Me.sbPnlInsOvr.Text = "INS"
				End If
            End If
        End Sub

        Private Sub comboBox2_SelectedIndexChanged(Sender As Object, e As EventArgs)
            sbPnlTime.AutoSize = comboBox2.SelectedIndex + 1
        End Sub

        Private Sub timer1_Timer(Sender As Object, e As EventArgs)
            Dim t As DateTime = DateTime.Now
            Dim s As String = t.ToLongTimeString() 
            sbPnlTime.Text = s 
        End Sub


        ' NOTE: The following code is required by the WinForms Form Designer
        ' It can be modified Imports the WinForms Form Designer.  
        ' Do not modify it Imports the code editor.
        Private components As System.ComponentModel.Container
        Private panel1 As System.WinForms.Panel
        Private groupBox1 As System.WinForms.GroupBox
        Private groupBox2 As System.WinForms.GroupBox
        Private statusBar As System.WinForms.StatusBar
        Private  chkSizingGrip As System.WinForms.CheckBox
        Private statusBarPanel1 As System.WinForms.StatusBarPanel
        Private sbPnlTime As System.WinForms.StatusBarPanel
        Private sbPnlInsOvr As System.WinForms.StatusBarPanel
        Private trackBar As System.WinForms.TrackBar
        Private chkShowPanels As System.WinForms.CheckBox
        Private label1 As System.WinForms.Label
        Private label2 As System.WinForms.Label
        Private label4 As System.WinForms.Label
        Private comboBox1 As System.WinForms.ComboBox
        Private groupBox3 As System.WinForms.GroupBox
        Private comboBox2 As System.WinForms.ComboBox
        Private toolTip1 As System.WinForms.ToolTip
        Private timer1 As System.WinForms.Timer
        Private label3 As System.WinForms.Label
        Private label6 As System.WinForms.Label

        Private Sub InitializeComponent()
			'MTM System.Resources.ResourceManager resources = new System.Resources.ResourceManager("StatusBarCtl", typeof(StatusBarCtl), null, true)
		
			Me.components = new System.ComponentModel.Container()
			Me.groupBox3 = new System.WinForms.GroupBox()
			Me.comboBox2 = new System.WinForms.ComboBox()
			Me.groupBox2 = new System.WinForms.GroupBox()
			Me.trackBar = new System.WinForms.TrackBar()
			Me.groupBox1 = new System.WinForms.GroupBox()
			Me.toolTip1 = new System.WinForms.ToolTip(components)
			Me.chkShowPanels = new System.WinForms.CheckBox()
			Me.chkSizingGrip = new System.WinForms.CheckBox()
			Me.comboBox1 = new System.WinForms.ComboBox()
			Me.sbPnlTime = new System.WinForms.StatusBarPanel()
			Me.label3 = new System.WinForms.Label()
			Me.label1 = new System.WinForms.Label()
			Me.timer1 = new System.WinForms.Timer(components)
			Me.label4 = new System.WinForms.Label()
			Me.statusBar = new System.WinForms.StatusBar()
			Me.label6 = new System.WinForms.Label()
			Me.sbPnlInsOvr = new System.WinForms.StatusBarPanel()
			Me.statusBarPanel1 = new System.WinForms.StatusBarPanel()
			Me.label2 = new System.WinForms.Label()
			Me.panel1 = new System.WinForms.Panel()
		
			groupBox3.TabIndex = 2
			groupBox3.Size = new System.Drawing.Size(216, 8)
			groupBox3.TabStop = false
			groupBox3.Location = new System.Drawing.Point(16, 120)
			groupBox3.Text = " "
		
			comboBox2.ForeColor = System.Drawing.SystemColors.WindowText
			comboBox2.Location = new System.Drawing.Point(128, 144)
			comboBox2.Style = System.WinForms.ComboBoxStyle.DropDownList
			comboBox2.TabIndex = 5
			comboBox2.Text = ""
			comboBox2.Size = new System.Drawing.Size(104, 21)
			toolTip1.SetToolTip(comboBox2, "Determines how a panel will resize when the prent changes size.")
			comboBox2.AddOnSelectedIndexChanged(new EventHandler(AddressOf comboBox2_SelectedIndexChanged))
			comboBox2.Items.All = LoadArray("None,Spring,Contents")
		
			groupBox2.TabIndex = 11
			groupBox2.Size = new System.Drawing.Size(216, 8)
			groupBox2.TabStop = false
			groupBox2.Location = new System.Drawing.Point(16, 64)
			groupBox2.Text = " "
		
			trackBar.Location = new System.Drawing.Point(16, 208)
			trackBar.TickFrequency = 10
			trackBar.TabIndex = 10
			trackBar.TabStop = false
			trackBar.SmallChange = 10
			trackBar.Text = "trackBar"
			trackBar.Size = new System.Drawing.Size(216, 42)
			trackBar.AddOnScroll(new EventHandler(AddressOf trackBar1_Scroll))
			trackBar.AddOnKeyUp(new KeyEventHandler(AddressOf statusBarSample_KeyUp))
			trackBar.BackColor = System.Drawing.SystemColors.Control
		
			groupBox1.TabIndex = 1
			groupBox1.Size = new System.Drawing.Size(248, 264)
			groupBox1.Anchor = System.WinForms.AnchorStyles.TopLeft
			groupBox1.TabStop = false
			groupBox1.Location = new System.Drawing.Point(248, 16)
			groupBox1.Text = "StatusBar"
		
			toolTip1.Active = true
			'@design toolTip1.SetLocation(new System.Drawing.Point(20, 10))
		
			chkShowPanels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			chkShowPanels.Location = new System.Drawing.Point(16, 40)
			chkShowPanels.TabIndex = 9
			chkShowPanels.CheckState = System.WinForms.CheckState.Checked
			chkShowPanels.Text = "Show&Panels"
			chkShowPanels.Size = new System.Drawing.Size(96, 16)
			chkShowPanels.Checked = true
			toolTip1.SetToolTip(chkShowPanels, "Determines if a status bar displays panels, or if it displays a single line of text.")
			chkShowPanels.AddOnClick(new EventHandler(AddressOf chkShowPanels_Click))
			chkShowPanels.AddOnKeyUp(new KeyEventHandler(AddressOf statusBarSample_KeyUp))
		
			chkSizingGrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			chkSizingGrip.Location = new System.Drawing.Point(16, 16)
			chkSizingGrip.TabIndex = 8
			chkSizingGrip.CheckState = System.WinForms.CheckState.Checked
			chkSizingGrip.Text = "Sizing&Grip"
			chkSizingGrip.Size = new System.Drawing.Size(80, 16)
			chkSizingGrip.Checked = true
			toolTip1.SetToolTip(chkSizingGrip, "Determines whether a status bar has a sizing grip.")
			chkSizingGrip.AddOnClick(new EventHandler(AddressOf chkSizingGrip_Click))
			chkSizingGrip.AddOnKeyUp(new KeyEventHandler(AddressOf statusBarSample_KeyUp))
		
			comboBox1.ForeColor = System.Drawing.SystemColors.WindowText
			comboBox1.Location = new System.Drawing.Point(128, 88)
			comboBox1.Style = System.WinForms.ComboBoxStyle.DropDownList
			comboBox1.TabIndex = 3
			comboBox1.Text = ""
			comboBox1.Size = new System.Drawing.Size(104, 21)
			toolTip1.SetToolTip(comboBox1, "Determines what type of border a panel has.")
			comboBox1.AddOnKeyUp(new KeyEventHandler(AddressOf statusBarSample_KeyUp))
			comboBox1.AddOnSelectedIndexChanged(new EventHandler(AddressOf comboBox1_SelectedIndexChanged))
			comboBox1.Items.All = LoadArray("None,Raised,Sunken")
		
			sbPnlTime.Alignment = System.WinForms.HorizontalAlignment.Right
			sbPnlTime.Width = 76
			sbPnlTime.Text = "sbPnlTime"
		
			label3.Location = new System.Drawing.Point(26, 64)
			label3.AutoSize = true
			label3.TabIndex = 6
			label3.TabStop = false
			label3.Text = "\""Ready\"" StatusBarPanel "
			label3.Size = new System.Drawing.Size(120, 13)
		
			Me.TabIndex = 0
			Me.Size = new System.Drawing.Size(512, 320)
			Me.Text = "StatusBar"
			Me.AddOnKeyUp(new KeyEventHandler(AddressOf statusBarSample_KeyUp))
		
			label1.Location = new System.Drawing.Point(16, 184)
			label1.TabIndex = 1
			label1.TabStop = false
			label1.Text = "Panel Width:"
			label1.Size = new System.Drawing.Size(72, 16)
		
			timer1.Interval = 1000
			timer1.Enabled = true
			'@design timer1.SetLocation(new System.Drawing.Point(20, 40))
			timer1.AddOnTimer(new EventHandler(AddressOf timer1_Timer))
		
			label4.Location = new System.Drawing.Point(16, 144)
			label4.TabIndex = 7
			label4.TabStop = false
			label4.Text = "&AutoSize"
			label4.Size = new System.Drawing.Size(60, 16)
		
			statusBar.ShowPanels = true
			statusBar.TabIndex = 0
			statusBar.Size = new System.Drawing.Size(212, 20)
			statusBar.Location = new System.Drawing.Point(0, 216)
			statusBar.BackColor = System.Drawing.SystemColors.Control
			statusBar.Text = "StatusBar"
			' MTM statusBar.Panels.All = new StatusBarPanel() As (StatusBarPanel()) (statusBarPanel1, sbPnlTime, sbPnlInsOvr)
			statusBar.Panels.Add(statusBarPanel1)
			statusBar.Panels.Add(sbPnlTime)
			statusBar.Panels.Add(sbPnlInsOvr)
			
			label6.Location = new System.Drawing.Point(26, 120)
			label6.AutoSize = true
			label6.TabIndex = 4
			label6.TabStop = false
			label6.Text = "\""Time\"" StatusBarPanel "
			label6.Size = new System.Drawing.Size(112, 13)
		
			sbPnlInsOvr.AutoSize = StatusBarPanelAutoSize.Contents
			sbPnlInsOvr.Width = 20
		
			statusBarPanel1.BorderStyle = StatusBarPanelBorderStyle.None
			statusBarPanel1.Icon = New System.Drawing.Icon("status.Ico")
			' MTM (System.Drawing.Icon)resources.GetObject("statusBarPanel1.Icon")
			statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Contents
			statusBarPanel1.Width = 70
			statusBarPanel1.Text = "Ready"
		
			label2.Location = new System.Drawing.Point(16, 88)
			label2.TabIndex = 0
			label2.TabStop = false
			label2.Text = "&BorderStyle"
			label2.Size = new System.Drawing.Size(64, 16)
		
			panel1.BorderStyle = System.WinForms.BorderStyle.Fixed3D
			panel1.TabIndex = 0
			panel1.Size = new System.Drawing.Size(216, 240)
			panel1.Location = new System.Drawing.Point(16, 24)
			panel1.BackColor = System.Drawing.SystemColors.Window
			panel1.Text = "Panel1"
		
			Me.Controls.Add(groupBox1)
			Me.Controls.Add(panel1)
			panel1.Controls.Add(statusBar)
			groupBox1.Controls.Add(trackBar)
			groupBox1.Controls.Add(label6)
			groupBox1.Controls.Add(label3)
			groupBox1.Controls.Add(comboBox2)
			groupBox1.Controls.Add(label4)
			groupBox1.Controls.Add(groupBox3)
			groupBox1.Controls.Add(comboBox1)
			groupBox1.Controls.Add(label2)
			groupBox1.Controls.Add(groupBox2)
			groupBox1.Controls.Add(label1)
			groupBox1.Controls.Add(chkShowPanels)
			groupBox1.Controls.Add(chkSizingGrip)
		
		End Sub

		' The main entry point for the application.
		Shared Sub Main()
		    Application.Run(new StatusBarCtl())
		End Sub
		
		Private Function LoadArray(InputString As String) As Array
			LoadArray = InputString.Split(",")
		End Function
		
    End Class

End NameSpace




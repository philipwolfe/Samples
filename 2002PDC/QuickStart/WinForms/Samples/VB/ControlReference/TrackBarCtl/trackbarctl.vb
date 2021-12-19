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

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms

Option Explicit
Option Strict Off

Namespace Microsoft.Samples.WinForms.Vb.TrackBarCtl 

    public class TrackBarCtl
    Inherits System.WinForms.Form 
        public sub New()
            MyBase.New()

            ' Required for WFC Form Designer support
            InitializeComponent()

            InitState()
        end sub

        ' <doc>
        ' <desc>
        '     Sets up the form so that the fields which drive the TrackBar
        '     show up with the correct initial fields.
        ' </desc>
        ' </doc>
        '
        private sub InitState() 
            trackbar.TickFrequency = 5
            cmbTickFreq.SelectedIndex = 2

            trackbar.SmallChange = 5
            cmbSmallChange.SelectedIndex = 2

            trackbar.LargeChange = 25
            cmbLargeChange.SelectedIndex = 1

            trackbar.Minimum = 0
            cmbMinimum.SelectedIndex = 0

            trackbar.Maximum = 100
            cmbMaximum.SelectedIndex = 0

            trackbar.Orientation = Orientation.Horizontal
            cmbOrientation.SelectedIndex = 0

            trackbar.TickStyle = TickStyle.None
            cmbTickStyle.SelectedIndex = 0

            lblValue.Text = System.Single.ToString(trackbar.Value)
        end sub

        ' <doc>
        ' <desc>
        '     TrackBarCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        overrides public sub Dispose() 
            MyBase.Dispose()
            components.Dispose()
        end sub

        private sub CmbTickFreq_selectedIndexChanged(source As Object, e As EventArgs) 
            try 
                Dim newVal1 As String = cmbTickFreq.SelectedItem.ToString()
                Dim newVal As Integer = newVal1.ToInt16()
                trackbar.TickFrequency = newVal
            
            catch ex As FormatException
            end try
        end sub

        private sub CmbLargeChange_selectedIndexChanged(source As Object, e As EventArgs)
            try 
                Dim newVal1 As String = cmbLargeChange.SelectedItem.ToString()
                Dim newVal As Integer = newVal1.ToInt16()
                trackbar.LargeChange = newVal
             
            catch ex As FormatException
            end try
        end sub


        private sub CmbSmallChange_selectedIndexChanged(source As Object, e As EventArgs)
            try 
                Dim newVal1 As String = cmbSmallChange.SelectedItem.ToString()
                Dim newVal As Integer = newVal1.ToInt16()
                trackbar.SmallChange = newVal
            
            catch ex As FormatException
            end try
        end sub


        private sub CmbMinimum_selectedIndexChanged(source As Object, e As EventArgs)
            try 
                Dim newVal1 As String = cmbMinimum.SelectedItem.ToString()
                Dim newVal As Integer = newVal1.ToInt16()
                if (newVal < trackbar.Maximum) Then trackbar.Minimum = newVal
             
            catch ex As FormatException
            end try
        end sub


        private sub CmbMaximum_selectedIndexChanged(source As Object, e As EventArgs)
            try 
                Dim newVal1 As String = cmbMaximum.SelectedItem.ToString()
                Dim newVal As Integer = newVal1.ToInt16()
                if (newVal > trackbar.Minimum) Then trackbar.Maximum = newVal
            
            catch ex As FormatException
            end try
        end sub


        private sub Trackbar_valueChanged(source As Object, e As EventArgs)
            lblValue.Text = System.Single.ToString(trackbar.Value)
        end sub


        private sub CmbTickStyle_selectedIndexChanged(source As Object, e As EventArgs)
            Dim cmb As ComboBox = source
            Dim newSel As String = cmb.SelectedItem
            if (newSel.Equals("Both")) Then
                trackbar.TickStyle = TickStyle.Both
            elseif (newSel.Equals("Bottomright")) 
                trackbar.TickStyle = TickStyle.BottomRight
            elseif (newSel.Equals("Topleft")) 
                trackbar.TickStyle = TickStyle.TopLeft
            else 
                trackbar.TickStyle = TickStyle.None
	    end if            

            if (trackbar.TickStyle = TickStyle.None) then 
                cmbTickFreq.Enabled = false
            else
                cmbTickFreq.Enabled = true
	    end if
        end sub

        private sub CmbOrientation_selectedIndexChanged(source As Object, e As EventArgs)
            Dim cmb As ComboBox = source
            Dim newSel As String = cmb.SelectedItem
            if (newSel.Equals("Horizontal")) Then
                trackbar.Orientation = Orientation.Horizontal
            else 
                trackbar.Orientation = Orientation.Vertical
            end if
        end sub

        ' <doc>
        ' <desc>
        '     All KeyPresses that are not digits are ignored.
        '     Other non-letter keys (such as ENTER) are accepted.
        '     The edit boxes which require numerical input wire up to
        '     this handler.
        ' </desc>
        ' </doc>
        '
        private sub NumberKeyPressFilter(source As Object, e As KeyPressEventArgs) 
            if (System.Char.IsLetterOrDigit(e.KeyChar) AND  Not System.Char.IsDigit(e.KeyChar)) then
                e.Handled = true
            end if
        end sub

        private sub GrpAppearance_enter(source As Object, e As EventArgs)

        end sub

        ' <doc>
        ' <desc>
        '     NOTE: The following code is required by the WFC form
        '     designer.  It can be modified using the form editor.  Do not
        '     modify it using the code editor.
        ' </desc>
        ' </doc>
        '
        private components As System.ComponentModel.Container
        private trackbar As System.WinForms.TrackBar 
        private grpAppearance As System.WinForms.GroupBox 
        private label3 As System.WinForms.Label 
        private label1 As System.WinForms.Label 
        private label8 As System.WinForms.Label 
        private label7 As System.WinForms.Label 
        private label4 As System.WinForms.Label 
        private label5 As System.WinForms.Label 
        private cmbOrientation As System.WinForms.ComboBox 
        private cmbTickStyle As System.WinForms.ComboBox 
        private cmbTickFreq As System.WinForms.ComboBox 
        private label6 As System.WinForms.Label 
        private cmbMaximum As System.WinForms.ComboBox 
        private lblValue As System.WinForms.Label 
        private cmbMinimum As System.WinForms.ComboBox 
        private cmbSmallChange As System.WinForms.ComboBox 
        private label2 As System.WinForms.Label 
        private cmbLargeChange As System.WinForms.ComboBox 
        private toolTip1 As System.WinForms.ToolTip 

        private sub InitializeComponent() 
            Me.components = new System.ComponentModel.Container()
            Me.trackbar = new System.WinForms.TrackBar()
            Me.grpAppearance = new System.WinForms.GroupBox()
            Me.label3 = new System.WinForms.Label()
            Me.label1 = new System.WinForms.Label()
            Me.label8 = new System.WinForms.Label()
            Me.label7 = new System.WinForms.Label()
            Me.label4 = new System.WinForms.Label()
            Me.label5 = new System.WinForms.Label()
            Me.cmbOrientation = new System.WinForms.ComboBox()
            Me.cmbTickStyle = new System.WinForms.ComboBox()
            Me.cmbTickFreq = new System.WinForms.ComboBox()
            Me.label6 = new System.WinForms.Label()
            Me.cmbMaximum = new System.WinForms.ComboBox()
            Me.lblValue = new System.WinForms.Label()
            Me.cmbMinimum = new System.WinForms.ComboBox()
            Me.cmbSmallChange = new System.WinForms.ComboBox()
            Me.label2 = new System.WinForms.Label()
            Me.cmbLargeChange = new System.WinForms.ComboBox()
            Me.toolTip1 = new System.WinForms.ToolTip(components)

            Me.BackColor = System.Drawing.SystemColors.Control
            Me.Size = new System.Drawing.Size(512, 320)
            Me.Text = "TrackBar"

            trackbar.Location = new System.Drawing.Point(8, 24)
            trackbar.Size = new System.Drawing.Size(200, 42)
            trackbar.TabIndex = 1
            trackbar.Text = "trackBar1"
            trackbar.AddOnValueChanged(new EventHandler(AddressOf Me.Trackbar_valueChanged))
            trackbar.BackColor = System.Drawing.SystemColors.Control

            grpAppearance.Location = new System.Drawing.Point(248, 16)
            grpAppearance.Size = new System.Drawing.Size(248, 264)
            grpAppearance.TabIndex = 0
            grpAppearance.TabStop = false
            grpAppearance.Text = "TrackBar"
            grpAppearance.AddOnEnter(new EventHandler(AddressOf Me.GrpAppearance_enter))

            label3.Location = new System.Drawing.Point(16, 96)
            label3.Size = new System.Drawing.Size(88, 16)
            label3.TabIndex = 0
            label3.TabStop = false
            label3.Text = "largeChange:"

            label1.Location = new System.Drawing.Point(16, 24)
            label1.Size = new System.Drawing.Size(88, 17)
            label1.TabIndex = 10
            label1.TabStop = false
            label1.Text = "orientation:"

            label8.Location = new System.Drawing.Point(16, 192)
            label8.Size = new System.Drawing.Size(88, 16)
            label8.TabIndex = 8
            label8.TabStop = false
            label8.Text = "value:"

            label7.Location = new System.Drawing.Point(16, 168)
            label7.Size = new System.Drawing.Size(88, 16)
            label7.TabIndex = 6
            label7.TabStop = false
            label7.Text = "Maximum:"

            label4.Location = new System.Drawing.Point(16, 48)
            label4.Size = new System.Drawing.Size(88, 17)
            label4.TabIndex = 12
            label4.TabStop = false
            label4.Text = "tickFrequency:"

            label5.Location = new System.Drawing.Point(16, 72)
            label5.Size = new System.Drawing.Size(88, 17)
            label5.TabIndex = 14
            label5.TabStop = false
            label5.Text = "tickStyle:"

            cmbOrientation.Location = new System.Drawing.Point(112, 16)
            cmbOrientation.Size = new System.Drawing.Size(120, 21)
            cmbOrientation.TabIndex = 11
            cmbOrientation.Text = ""
            cmbOrientation.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbOrientation.Items.All = new object() { "Horizontal", "Vertical"}
            cmbOrientation.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbOrientation_selectedIndexChanged))

            cmbTickStyle.Location = new System.Drawing.Point(112, 64)
            cmbTickStyle.Size = new System.Drawing.Size(120, 21)
            cmbTickStyle.TabIndex = 15
            cmbTickStyle.Text = ""
            cmbTickStyle.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbTickStyle.Items.All = new object() { "None", "Bottomright", "Topleft", "Both"}
            cmbTickStyle.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbTickStyle_selectedIndexChanged))

            cmbTickFreq.Location = new System.Drawing.Point(112, 40)
            cmbTickFreq.Size = new System.Drawing.Size(120, 21)
            cmbTickFreq.TabIndex = 13
            cmbTickFreq.Text = ""
            cmbTickFreq.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbTickFreq.Items.All = new object() { "1", "2", "5", "10", "20", "25", "50"}
            cmbTickFreq.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbTickFreq_selectedIndexChanged))

            label6.Location = new System.Drawing.Point(16, 144)
            label6.Size = new System.Drawing.Size(88, 16)
            label6.TabIndex = 4
            label6.TabStop = false
            label6.Text = "minimum:"

            cmbMaximum.Location = new System.Drawing.Point(112, 160)
            cmbMaximum.Size = new System.Drawing.Size(121, 21)
            cmbMaximum.TabIndex = 7
            cmbMaximum.Text = ""
            cmbMaximum.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbMaximum.Items.All = new object() { "100", "150", "200"}
            cmbMaximum.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbMaximum_selectedIndexChanged))

            lblValue.Location = new System.Drawing.Point(112, 192)
            lblValue.Size = new System.Drawing.Size(120, 16)
            lblValue.TabIndex = 9
            lblValue.TabStop = false
            lblValue.Text = ""
            lblValue.BorderStyle = System.WinForms.BorderStyle.Fixed3D

            cmbMinimum.Location = new System.Drawing.Point(112, 136)
            cmbMinimum.Size = new System.Drawing.Size(121, 21)
            cmbMinimum.TabIndex = 5
            cmbMinimum.Text = ""
            cmbMinimum.Style = System.WinForms.ComboBoxStyle.DropDownList 
            cmbMinimum.Items.All = new object() { "0", "25", "50"}
            cmbMinimum.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbMinimum_selectedIndexChanged))

            cmbSmallChange.Location = new System.Drawing.Point(112, 112)
            cmbSmallChange.Size = new System.Drawing.Size(121, 21)
            cmbSmallChange.TabIndex = 3
            cmbSmallChange.Text = ""
            cmbSmallChange.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbSmallChange.Items.All = new object() { "1", "2", "5", "10"}
            cmbSmallChange.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbSmallChange_selectedIndexChanged))

            label2.Location = new System.Drawing.Point(16, 120)
            label2.Size = new System.Drawing.Size(88, 16)
            label2.TabIndex = 2
            label2.TabStop = false
            label2.Text = "smallChange:"

            cmbLargeChange.Location = new System.Drawing.Point(112, 88)
            cmbLargeChange.Size = new System.Drawing.Size(121, 21)
            cmbLargeChange.TabIndex = 1
            cmbLargeChange.Text = ""
            cmbLargeChange.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbLargeChange.Items.All = new object() { "10", "20", "50"}
            cmbLargeChange.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.CmbLargeChange_selectedIndexChanged))

            toolTip1.Active = true
            toolTip1.SetToolTip(cmbTickStyle, "The location of the tick marks.")
            toolTip1.SetToolTip(cmbTickFreq, "The number of units betwen tick marks")
            ' @designTimeOnly toolTip1.setLocation(new System.Drawing.Point(48, 152)) 

            Me.Controls.Add(grpAppearance)
            Me.Controls.Add(trackbar)
            grpAppearance.Controls.Add(lblValue)
            grpAppearance.Controls.Add(label8) 
            grpAppearance.Controls.Add(cmbMaximum)
            grpAppearance.Controls.Add(label7)
            grpAppearance.Controls.Add(cmbMinimum)
            grpAppearance.Controls.Add(label6)
            grpAppearance.Controls.Add(cmbSmallChange)
            grpAppearance.Controls.Add(label2)
            grpAppearance.Controls.Add(cmbLargeChange)
            grpAppearance.Controls.Add(label3)
            grpAppearance.Controls.Add(cmbTickFreq)
            grpAppearance.Controls.Add(cmbTickStyle)
            grpAppearance.Controls.Add(cmbOrientation)
            grpAppearance.Controls.Add(label5)
            grpAppearance.Controls.Add(label1)
            grpAppearance.Controls.Add(label4)
        end sub


        ' The main entry point for the application.
        public shared Sub Main() 
            Application.Run(new TrackBarCtl())
        end sub
    End Class
End Namespace



'-----------------------------------------------------------------------------
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
    Imports System.Collections
    Imports System.WinForms
    Imports System.Resources
    Imports System.Drawing
    Imports System.Drawing.Drawing2D

Option Strict Off
Option Explicit

namespace ComboBoxCtlNameSpace

    ' <doc>
    ' <desc>
    '     This sample demonstrates the properties and features
    '     of the ComboBox control.
    '     The sample also shows two different ways to use a ComboBox which does
    '     not contain String data.  The first method uses a Hashtable which maps
    '     strings to the data and the second method uses a wrapper object which
    '     exposes a toString() method used by the ComboBox.
    ' </desc>
    ' </doc>
    '
    public class ComboBoxCtl
	Inherits System.WinForms.Form
        private components as System.ComponentModel.Container
        private comboBegin as System.WinForms.ComboBox
        private chkEnabled as System.WinForms.CheckBox
        private chkSorted as System.WinForms.CheckBox
        private chkIntegralHeight as System.WinForms.CheckBox
        private label1 as System.WinForms.Label
        private label2 as System.WinForms.Label
        private label3 as System.WinForms.Label
        private label4 as System.WinForms.Label
        private cmbMaxDropDownItems as System.WinForms.ComboBox
        private cmbItemHeight as System.WinForms.ComboBox
        private cmbDrawMode as System.WinForms.ComboBox
        private cmbStyle as System.WinForms.ComboBox
        private comboEnd as System.WinForms.ComboBox
        private groupBox1 as System.WinForms.GroupBox
        private panel1 as System.WinForms.Panel
        private label6 as System.WinForms.Label 
        private label7 as System.WinForms.Label 
        private label5 as System.WinForms.Label 
        private label8 as System.WinForms.Label
        private label9 as System.WinForms.Label 
        private toolTip1 as System.WinForms.ToolTip   
        '????????????????????????????????????????????????????? End MTM
	private cmbsize as Size
        private colorMap as New Hashtable()
        private gradientBegin as Color = Color.Red
        private gradientEnd as Color = Color.Blue
	'??????????????????????????????????????????????????????? End MTM
        ' <doc>
        ' <desc>
        '     We speed up ownerdraw operations on the Color ComboBoxes
        '     by caching the Brush objects which represent the Color
        '     to choose.
        ' </desc>
        ' <seealso class='ComboBoxCtl.GetTheBrush()'/>
        ' </doc>
	private brushMap as new Hashtable()

        ' <doc>
        ' <desc>
        '     Public Constructor
        ' </desc>
        ' </doc>
        '
        public Sub New () 
	    
            MyBase.New 	

            ' This call is required for support of the Win Forms Form Designer.
            InitializeComponent()

            InitControlState()
            MakeColorMap()
            FillItems(comboBegin)
            comboBegin.SelectedIndex = 0
            FillItems(comboEnd)
            comboEnd.SelectedIndex = comboEnd.Items.Count-1
            cmbsize = comboBegin.Size

        End Sub

        ' <doc>
        ' <desc>
        '     This class defines the objects in the ComboBoxes that drive
        '     the properties of the color selection ComboBoxes.
        '     Use this object to use erations with ComboBoxes and ListBoxes.
        '     Add the <paramref term='s'/> data member to the eration item's
        '     english description and the <paramref term='i'/> data member to the actual
        '     value of the eration item.
        '     The ToString() method will allow the ComboBox and ListBox controls to 
        '     display the text which represents the eration item.
        ' </desc>
        ' </doc>
        '
        private class StringIntObject

            public s as String
            public i as Integer

            OverRides Public Function ToString() as string
                ToString = s
            End Function

        End Class

        ' <doc>
        ' <desc>
        '     Sets the default states for the controls driving the properties
        '     of the two ComboBoxes.
        ' </desc>
        ' </doc>
        '
        private Sub InitControlState()

            ' Sync the checkboxes
            chkSorted.Checked = comboBegin.Sorted
            chkEnabled.Checked = comboBegin.Enabled
            chkIntegralHeight.Checked = comboBegin.IntegralHeight

            ' Sync ComboBox styles to ComboBoxStyle.DROPDOWN
            Dim aStyle(3) as StringIntObject
	    aStyle(0) = GetStringIntObject("Simple",ComboBoxStyle.Simple)
            aStyle(1) = GetStringIntObject("Dropdown",ComboBoxStyle.DropDown)
            aStyle(2) = GetStringIntObject("Dropdownlist",ComboBoxStyle.DropDownList)
            cmbStyle.Items.All = aStyle
            comboBegin.Style = aStyle(1).i
            comboEnd.Style = aStyle(1).i
            cmbStyle.SelectedIndex = 1

            ' Sync ComboBox draw modes to DrawMode.NORMAL
            Dim aDMO(3) as StringIntObject
	    aDMO(0) = GetStringIntObject("Normal",DrawMode.Normal)
            aDMO(1) = GetStringIntObject("Ownerdrawfixed",DrawMode.OwnerDrawFixed)
	    aDMO(2) = GetStringIntObject("Ownerdrawvariable",DrawMode.OwnerDrawVariable)
            cmbDrawMode.Items.All = aDMO
            comboBegin.DrawMode = aDMO(0).i
            comboEnd.DrawMode = aDMO(0).i
            cmbDrawMode.SelectedIndex = 0
        
	End Sub

        Private Sub FillItems(cmb as ComboBox)

            Dim keys As IEnumerator = colorMap.Keys.GetEnumerator()

            while (keys.MoveNext())
                cmb.Items.Add(keys.Current)
            End While

        End Sub

        Private Sub MakeColorMap()

            colorMap("Aqua") = Color.Aqua
            colorMap("Black") = Color.Black
            colorMap("Blue") = Color.Blue
            colorMap("Brown") = Color.Brown
            colorMap("Cyan") = Color.Cyan
            colorMap("Dark Gray") = Color.DarkGray
            colorMap("Gray") = Color.Gray
            colorMap("Green") = Color.Green
            colorMap("Light Gray") = Color.LightGray
            colorMap("Magenta") = Color.Magenta
            colorMap("Orange") = Color.Orange
            colorMap("Purple") = Color.Purple
            colorMap("Red") = Color.Red
            colorMap("White") = Color.White
            colorMap("Yellow") = Color.Yellow

        End Sub

        ' <doc>
        ' <desc>
        '     ComboBoxCtl overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        Overrides Public Sub Dispose()
            MyBase.Dispose()
            Components.Dispose()
        End Sub

        ' <doc>
        ' <desc>
        '     Returns the int which is currently selected in a ComboBox.
        ' </desc>
        ' <param term='cmb'>
        '     The ComboBox to get the integral value from
        ' </param>
        ' <retvalue>
        '     If the String is in a valid numeric format, the integer
        '     representation of it is returned.  Otherwise, if
        '     no item is selected <it>or</it> the selected item is
        '     not a valid int, -1 is returned.
        ' </retvalue>
        ' </doc>
        '
        Private Function SelectedValue(cmb as ComboBox) as Integer

            Dim ret As Integer
            Dim obj As Object = cmb.SelectedItem

            If obj = Nothing Then
                return -1
            End If

            Try 
                ret = Int32.FromString(obj.ToString())
            Catch Except as FormatException
                return -1
            End Try

            return ret

        End Function

        Private Sub chkEnabled_Click(sender as Object , e as EventArgs)
            comboBegin.Enabled = chkEnabled.Checked
            comboEnd.Enabled = chkEnabled.Checked
        End Sub

        Private Sub chkIntegralHeight_Click(sender as object, e as EventArgs)
            comboBegin.IntegralHeight = chkIntegralHeight.Checked
            comboEnd.IntegralHeight = chkIntegralHeight.Checked
        End Sub

        Private Sub chkSorted_Click(sender as object, e as EventArgs)
            Dim sorted as Boolean  = chkSorted.Checked
            comboBegin.Sorted = sorted
            comboEnd.Sorted = sorted
            if not sorted Then
                RandomShuffle(comboBegin)
                RandomShuffle(comboEnd)
            End If
        End Sub

        ' <doc>
        ' <desc>
        '     Performs a random shuffle on the given ComboBox.
        ' </desc>
        ' <param term='cmb'>
        '     The ComboBox to shuffle
        ' </param>
        ' </doc>
        '

        Private Sub RandomShuffle(cmb as ComboBox)

            Dim items As object()  = cmb.Items.All
            Dim swapItem As Integer
            Dim rand as Random  = new Random()
            Dim i as Integer = 0

	    For i = 0 To items.Length - 1
                swapItem = Math.Abs(rand.Next()) Mod items.Length

                If swapItem <> i Then
                    Dim tempObject As Object = items(swapItem)
                    items(swapItem) = items(i)
                    items(i) = tempObject
                End If

            Next

            cmb.Items.All = items

        End Sub

        Private Sub cmbItemHeight_SelectedIndexChanged(sender As Object, e as EventArgs)

            Dim i as Integer = SelectedValue(cmbItemHeight)

            if i = -1 Then return

            comboBegin.ItemHeight = i
            comboEnd.ItemHeight = i

        End Sub

        Private Sub cmbStyle_SelectedIndexChanged(sender As object, e As EventArgs)
            Dim i As ComboBoxStyle = cmbStyle.SelectedItem.i
            comboBegin.Style = i
            comboEnd.Style = i

            If i = ComboBoxStyle.Simple Then
                comboBegin.SetSize(cmbsize.Width, cmbsize.Height * 3)
                comboEnd.SetSize(cmbsize.Width, cmbsize.Height * 3)
                cmbMaxDropDownItems.Enabled = false
	    Else
		cmbMaxDropDownItems.Enabled = True
            End If
        End Sub

        Private Sub cmbDrawMode_SelectedIndexChanged(sender As object, e As EventArgs)
            Dim i As DrawMode = cmbDrawMode.SelectedItem.i
            comboBegin.DrawMode = i
            comboEnd.DrawMode = i

            If i = DrawMode.OwnerDrawFixed Then
                cmbItemHeight.Enabled = true
            Else
                cmbItemHeight.Enabled = false
            End If
        End Sub

        ' <doc>
        ' <desc>
        '     This DrawItem event handler is invoked to draw an item in a ComboBox if that
        '     ComboBox is in an OwnerDraw DrawMode.
        ' </desc>
        ' </doc>
        '

        Private Sub combo_DrawItem(sender As object, die As DrawItemEventArgs)
            Dim cmb as ComboBox = sender
            If die.Index = -1 Then
                return
            ElseIf sender = Nothing Then
                return
	    End If

            Dim strColor As String = cmb.Items(die.Index)
            Dim clrSelected As Color = colorMap(strColor)
            Dim g As Graphics = die.Graphics

            ' If the item is selected, this draws the correct background color
            die.DrawBackground()
            die.DrawFocusRectangle()

            ' Draw the color's preview box
            Dim rectPreviewBox As Rectangle = die.Bounds
            rectPreviewBox.Offset(2,2)
            rectPreviewBox.Width = 20
            rectPreviewBox.Height -= 4
            g.DrawRectangle(new Pen(die.ForeColor), rectPreviewBox)

            ' Get the appropriate Brush object for the selected color
            ' and fill the preview box.

            Dim coloredBrush As Brush = GetTheBrush(clrSelected)
            rectPreviewBox.Offset(1,1)
            rectPreviewBox.Width -= 2
            rectPreviewBox.Height -= 2
            g.FillRectangle(coloredBrush, rectPreviewBox)

            ' Draw the name of the color selected
            g.DrawString(strColor, Font, new SolidBrush(die.ForeColor), die.Bounds.X+30,die.Bounds.Y+1)

            g.Dispose()
        End Sub

        ' <doc>
        ' <desc>
        '     Retrieves a Brush object which corresponds to <em>clr</em>
        '     Brushes created are cached for performance.
        ' </desc>
        ' <param term='clr'>
        '     The Color which the returned Brush will paint
        ' </param>
        ' <retvalue>
        '     A Brush object which corresponds to <em>clr</em>
        '     Treat this object as read-only.
        ' </retvalue>
        ' </doc>
        '
        Private Function GetTheBrush(clr As Color) As Brush
        
	    If clr.IsEmpty Then throw new ArgumentException()

            Dim ret As Object = brushMap(clr)

            If ret = Nothing Then
                Dim clrBrush As Brush = new SolidBrush(clr)
                brushMap.Add(clr,clrBrush)
                return clrBrush
            Else
                return ret
            End If

        End Function

        Private Sub comboBegin_SelectedIndexChanged(sender As object, e As EventArgs)

            Dim c As Color = colorMap(comboBegin.SelectedItem)
            gradientBegin = c
            panel1.Invalidate()

        End Sub

        Private Sub comboEnd_SelectedIndexChanged(sender As Object, e As EventArgs)

            Dim c As Color = colorMap(comboEnd.SelectedItem)
            gradientEnd = c
            panel1.Invalidate()

        End Sub

        Private Sub cmbMaxDropDownItems_SelectedIndexChanged(sender As Object, e As EventArgs)

            Dim i As Integer = SelectedValue(cmbMaxDropDownItems)
            
	    if i = -1 Then return

            comboBegin.MaxDropDownItems = i
            comboEnd.MaxDropDownItems = i

        End Sub

        Private Sub combo_MeasureItem(sender As object, mie As MeasureItemEventArgs)
            mie.ItemHeight = (mie.Index Mod 6) + 12
        End Sub

        Private Sub panel1_Paint(sender As object, e As PaintEventArgs)

            Dim oBrush As Brush = new LinearGradientBrush (panel1.ClientRectangle, gradientBegin, gradientEnd,LinearGradientMode.ForwardDiagonal) 
            e.Graphics.FillRectangle(oBrush, panel1.ClientRectangle)

        End Sub

        Private Sub combo_KeyPress(sender As Object, e As KeyPressEventArgs)

            if System.Char.IsLetterOrDigit(e.KeyChar) Then e.Handled = true

        End Sub


        ' NOTE: The following code is required by the Win Forms Form Designer
        ' It can be modified using the Win Forms Form Designer.  
        ' Do not modify it using the code editor.

        private Sub InitializeComponent()
	    Const MAX_ITEMS As String = "2,4,6,8,10"
	    Const BOX_HEIGHT As String = "12,14,16,18,24,26"

            Me.components = new System.ComponentModel.Container()
            Me.groupBox1 = new System.WinForms.GroupBox()
            Me.comboBegin = new System.WinForms.ComboBox()
            Me.chkEnabled = new System.WinForms.CheckBox()
            Me.chkSorted = new System.WinForms.CheckBox()
            Me.chkIntegralHeight = new System.WinForms.CheckBox()
            Me.label1 = new System.WinForms.Label()
            Me.label2 = new System.WinForms.Label()
            Me.label3 = new System.WinForms.Label()
            Me.label4 = new System.WinForms.Label()
            Me.cmbMaxDropDownItems = new System.WinForms.ComboBox()
            Me.cmbItemHeight = new System.WinForms.ComboBox()
            Me.cmbDrawMode = new System.WinForms.ComboBox()
            Me.cmbStyle = new System.WinForms.ComboBox()
            Me.comboEnd = new System.WinForms.ComboBox()
            Me.panel1 = new System.WinForms.Panel()
            Me.label6 = new System.WinForms.Label()
            Me.label7 = new System.WinForms.Label()
            Me.label5 = new System.WinForms.Label()
            Me.label8 = new System.WinForms.Label()
            Me.label9 = new System.WinForms.Label()
            Me.toolTip1 = new System.WinForms.ToolTip(components)

            Me.Size = new System.Drawing.Size(512, 320)
            Me.Text = "ComboBox"

            groupBox1.Location = new System.Drawing.Point(248, 16)
            groupBox1.Size = new System.Drawing.Size(248, 264)
            groupBox1.TabIndex = 2
            groupBox1.TabStop = false
            groupBox1.Text = "ComboBox"

            comboBegin.Location = new System.Drawing.Point(24, 32)
            comboBegin.Size = new System.Drawing.Size(208, 21)
            comboBegin.TabIndex = 0
            comboBegin.Text = "comboBegin1"
            comboBegin.Sorted = true
	    comboBegin.AddOnKeyPress(new KeyPressEventHandler(AddressOf combo_KeyPress))
            comboBegin.AddOnDrawItem(new DrawItemEventHandler(AddressOf Me.combo_DrawItem))
            comboBegin.AddOnMeasureItem(new MeasureItemEventHandler(AddressOf Me.combo_MeasureItem))
            comboBegin.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.comboBegin_SelectedIndexChanged))

            chkEnabled.Location = new System.Drawing.Point(16, 24)
            chkEnabled.Size = new System.Drawing.Size(88, 16)
            chkEnabled.TabIndex = 0
            chkEnabled.Text = "enabled"
            chkEnabled.AddOnClick(new EventHandler(AddressOf Me.chkEnabled_Click))

            chkSorted.Location = new System.Drawing.Point(16, 48)
            chkSorted.Size = new System.Drawing.Size(88, 16)
            chkSorted.TabIndex = 1
            chkSorted.Text = "sorted"
            chkSorted.AddOnClick(new EventHandler(AddressOf Me.chkSorted_Click))

            chkIntegralHeight.Location = new System.Drawing.Point(16, 72)
            chkIntegralHeight.Size = new System.Drawing.Size(120, 16)
            chkIntegralHeight.TabIndex = 2
            chkIntegralHeight.Text = "integralHeight"
            chkIntegralHeight.AddOnClick(new EventHandler(AddressOf Me.chkIntegralHeight_Click))

            label1.Location = new System.Drawing.Point(16, 104)
            label1.Size = new System.Drawing.Size(88, 16)
            label1.TabIndex = 8
            label1.TabStop = false
            label1.Text = "style"

            label2.Location = new System.Drawing.Point(16, 128)
            label2.Size = new System.Drawing.Size(88, 16)
            label2.TabIndex = 9
            label2.TabStop = false
            label2.Text = "drawMode"

            label3.Location = new System.Drawing.Point(16, 152)
            label3.Size = new System.Drawing.Size(80, 16)
            label3.TabIndex = 10
            label3.TabStop = false
            label3.Text = "itemHeight"

            label4.Location = new System.Drawing.Point(16, 176)
            label4.Size = new System.Drawing.Size(120, 16)
            label4.TabIndex = 11
            label4.TabStop = false
            label4.Text = "MaxDropdownItems"

            cmbMaxDropDownItems.Location = new System.Drawing.Point(128, 168)
            cmbMaxDropDownItems.Size = new System.Drawing.Size(104, 21)
            cmbMaxDropDownItems.TabIndex = 7
            cmbMaxDropDownItems.Text = ""
            cmbMaxDropDownItems.Style = System.WinForms.ComboBoxStyle.DropDownList
	    cmbMaxDropDownItems.Items.All = GetArray(MAX_ITEMS)
            cmbMaxDropDownItems.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.cmbMaxDropDownItems_SelectedIndexChanged))

            cmbItemHeight.Location = new System.Drawing.Point(128, 144)
            cmbItemHeight.Size = new System.Drawing.Size(104, 21)
            cmbItemHeight.TabIndex = 6
            cmbItemHeight.Text = ""
            cmbItemHeight.Style = System.WinForms.ComboBoxStyle.DropDownList
	    cmbItemHeight.Items.All = GetArray(BOX_HEIGHT)
            cmbItemHeight.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.cmbItemHeight_SelectedIndexChanged))

            cmbDrawMode.Location = new System.Drawing.Point(128, 120)
            cmbDrawMode.Size = new System.Drawing.Size(104, 21)
            cmbDrawMode.TabIndex = 5
            cmbDrawMode.Text = ""
            cmbDrawMode.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbDrawMode.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.cmbDrawMode_SelectedIndexChanged))

            cmbStyle.Location = new System.Drawing.Point(128, 96)
            cmbStyle.Size = new System.Drawing.Size(104, 21)
            cmbStyle.TabIndex = 4
            cmbStyle.Text = ""
            cmbStyle.Style = System.WinForms.ComboBoxStyle.DropDownList
            cmbStyle.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.cmbStyle_SelectedIndexChanged))

            comboEnd.Location = new System.Drawing.Point(24, 120)
            comboEnd.Size = new System.Drawing.Size(208, 21)
            comboEnd.TabIndex = 1
            comboEnd.Text = "comboBegin1"
            comboEnd.Sorted = true
            comboEnd.AddOnKeyPress(new KeyPressEventHandler(AddressOf Me.combo_KeyPress))
            comboEnd.AddOnDrawItem(new DrawItemEventHandler(AddressOf Me.combo_DrawItem))
            comboEnd.AddOnMeasureItem(new MeasureItemEventHandler(AddressOf Me.combo_MeasureItem))
            comboEnd.AddOnSelectedIndexChanged(new EventHandler(AddressOf Me.comboEnd_SelectedIndexChanged))

            panel1.Location = new System.Drawing.Point(16, 224)
            panel1.Size = new System.Drawing.Size(216, 24)
            panel1.TabIndex = 3
            panel1.Text = "panel1"
            panel1.BorderStyle = System.WinForms.BorderStyle.Fixed3D
            panel1.AddOnPaint(new PaintEventHandler(AddressOf Me.panel1_Paint))

            toolTip1.Active = true
            toolTip1.SetToolTip(comboBegin, "Choose color for left end of gradient")
            toolTip1.SetToolTip(chkSorted, "Sets whether the items in the ComboBoxes\nshould be sorted alphabetically")
            toolTip1.SetToolTip(chkIntegralHeight, "Sets a boolean value indicating\nwhether the combo box should resize\nto avoid showing partial items")
            toolTip1.SetToolTip(cmbMaxDropDownItems, "The number of items to display on dropdown")
            toolTip1.SetToolTip(cmbItemHeight, "The height, in pixels, of an item in the combo box")
            toolTip1.SetToolTip(comboEnd, "Choose the color for the right end of gradient")
            'DesignTimeOnly toolTip1.setLocation(new System.Drawing.Point(136, 232))

            label6.Location = new System.Drawing.Point(24, 16)                     
            label6.Size = new System.Drawing.Size(96, 16)
            label6.TabIndex = 5
            label6.TabStop = false
            label6.Text = "Left:"

            label7.Location = new System.Drawing.Point(24, 104)
            label7.Size = new System.Drawing.Size(96, 16)
            label7.TabIndex = 3
            label7.TabStop = false
            label7.Text = "Right:"

            label5.Location = new System.Drawing.Point(16, 208)
            label5.Size = new System.Drawing.Size(64, 16)
            label5.TabIndex = 12
            label5.TabStop = false
            label5.Text = "Left"

            label8.Location = new System.Drawing.Point(136, 208)
            label8.Size = new System.Drawing.Size(64, 0)
            label8.TabIndex = 13
            label8.TabStop = false
            label8.Text = "label8"

            label9.Location = new System.Drawing.Point(200, 208)
            label9.Size = new System.Drawing.Size(32, 16)
            label9.TabIndex = 14
            label9.TabStop = false
            label9.Text = "Right"

            groupBox1.Controls.Add(panel1)
            groupBox1.Controls.Add(label9)
            groupBox1.Controls.Add(label8)
            groupBox1.Controls.Add(label5)
            groupBox1.Controls.Add(cmbStyle)
            groupBox1.Controls.Add(cmbDrawMode)
            groupBox1.Controls.Add(cmbItemHeight)
            groupBox1.Controls.Add(cmbMaxDropDownItems)
            groupBox1.Controls.Add(label4)
            groupBox1.Controls.Add(label3)
            groupBox1.Controls.Add(label2)
            groupBox1.Controls.Add(label1)
            groupBox1.Controls.Add(chkIntegralHeight)
            groupBox1.Controls.Add(chkSorted)
            groupBox1.Controls.Add(chkEnabled)
            Me.Controls.Add(label7)
            Me.Controls.Add(label6)
            Me.Controls.Add(comboEnd)
            Me.Controls.Add(comboBegin)
            Me.Controls.Add(groupBox1)
	End Sub

        public Function GetStringIntObject(sz as String, n as Integer)
	    GetStringIntObject = New StringIntObject
	    GetStringIntObject.s = sz 
            GetStringIntObject.i = n
        End Function

	Private Function GetArray(ItemsList As String) As Object
		GetArray = ItemsList.Split(",")
	End Function

        ' The main entry point for the application.
        Shared Sub Main()
            Application.Run(new ComboBoxCtl())
        End Sub

    End Class

End NameSpace



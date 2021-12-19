Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports System.Collections

Option Strict Off
Option Explicit

Namespace Win32Form1Namespace 

    Public Class Win32Form1
        Inherits System.WinForms.Form

        'Required by the Win Forms Designer   
        Private components As System.ComponentModel.Container
        Private Label11 As System.WinForms.Label
        Private Label10 As System.WinForms.Label
        Private Label9 As System.WinForms.Label
        Private Label8 As System.WinForms.Label
        Private Label6 As System.WinForms.Label
        Private Label5 As System.WinForms.Label
        Private lblVValue As System.WinForms.Label
        Private lblHValue As System.WinForms.Label
        Private Label4 As System.WinForms.Label
        Private Label3 As System.WinForms.Label
        Private Label2 As System.WinForms.Label
        Private Label1 As System.WinForms.Label
        Private cboSmallChange As System.WinForms.ComboBox
        Private CboLargeChange As System.WinForms.ComboBox
        Private GroupBox1 As System.WinForms.GroupBox
        Private imgContainer As System.WinForms.PictureBox
        Private vsVScroll As System.WinForms.VScrollBar
        Private hsHScroll As System.WinForms.HScrollBar
		Private MouseX as Integer
		Private MouseY as Integer
		Private Dragging as Boolean

        Public Sub New()
           MyBase.New
    
           'This call is required by the Win Forms Designer.
           InitializeComponent
    
           ' TODO: Add any constructor code after InitializeComponent call

        End Sub

        'Clean up any resources being used
		Overrides Public Sub Dispose()
            MyBase.Dispose
            components.Dispose
        End Sub 

        'The main entry point for the application
        Shared Sub Main()
            System.WinForms.Application.Run(New Win32Form1())
        End Sub

        'NOTE: The following procedure is required by the Win Forms Designer
        'Do not modify it.
        Private Sub InitializeComponent() 
			Const LARGE_CHANGE As String = "20,10,5"
			Const SMALL_CHANGE As String = "5,2,1"
            Me.components = New System.ComponentModel.Container
            Me.GroupBox1 = New System.WinForms.GroupBox
            Me.cboSmallChange = New System.WinForms.ComboBox
            Me.Label5 = New System.WinForms.Label
            Me.lblVValue = New System.WinForms.Label
            Me.hsHScroll = New System.WinForms.HScrollBar
            Me.CboLargeChange = New System.WinForms.ComboBox
            Me.lblHValue = New System.WinForms.Label
            Me.Label11 = New System.WinForms.Label
            Me.Label10 = New System.WinForms.Label
            Me.Label4 = New System.WinForms.Label
            Me.imgContainer = New System.WinForms.PictureBox
            Me.Label9 = New System.WinForms.Label
            Me.vsVScroll = New System.WinForms.VScrollBar
            Me.Label8 = New System.WinForms.Label
            Me.Label6 = New System.WinForms.Label
            Me.Label3 = New System.WinForms.Label
            Me.Label2 = New System.WinForms.Label
            Me.Label1 = New System.WinForms.Label

            GroupBox1.Location = New System.Drawing.Point(280, 8)
            GroupBox1.TabIndex = 3
            GroupBox1.TabStop = False
            GroupBox1.Text = "HScrollBar And VScrollBar"
            GroupBox1.Size = New System.Drawing.Size(256, 200)

            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.Text = "ScrollBar Sample"
            '@design Me.TrayLargeIcon = True
            '@design Me.TrayHeight = 0
            Me.ClientSize = New System.Drawing.Size(544, 253)
            Me.AddOnClick(New System.EventHandler(AddressOf Me.Win32Form1_Click))

            cboSmallChange.Text = ""
            cboSmallChange.Location = New System.Drawing.Point(104, 48)
            cboSmallChange.Size = New System.Drawing.Size(136, 21)
            cboSmallChange.Style = System.WinForms.ComboBoxStyle.DropDownList
            cboSmallChange.TabIndex = 1
			cboSmallChange.Items.All = GetArray(SMALL_CHANGE)
			cboSmallChange.AddOnSelectedIndexChanged(New System.EventHandler(AddressOf Me.cboSmallChange_SelectedIndexChanged))
			cboSmallChange.SelectedItem = "1"

            Label5.Location = New System.Drawing.Point(112, 232)
            Label5.Text = "0"
            Label5.Size = New System.Drawing.Size(24, 16)
            Label5.TabIndex = 5

            lblVValue.Location = New System.Drawing.Point(128, 120)
            lblVValue.Text = "0"
            lblVValue.Size = New System.Drawing.Size(40, 16)
            lblVValue.TabIndex = 8
            lblVValue.TextAlign = System.WinForms.HorizontalAlignment.Center

            hsHScroll.LargeChange = 5
		    hsHScroll.SmallChange = 1
            hsHScroll.Location = New System.Drawing.Point(16, 208)
            hsHScroll.TabIndex = 0
            hsHScroll.Size = New System.Drawing.Size(200, 16)
			hsHScroll.Minimum = -100
			hsHScroll.Maximum = 100
			hsHScroll.AddOnScroll(New ScrollEventHandler(AddressOf Me.hsHScroll_Scroll))

            CboLargeChange.Location = New System.Drawing.Point(104, 24)
            CboLargeChange.Text = ""
            CboLargeChange.Size = New System.Drawing.Size(136, 21)
            CboLargeChange.Style = System.WinForms.ComboBoxStyle.DropDownList
            CboLargeChange.TabIndex = 0
		    CboLargeChange.Items.All = GetArray(LARGE_CHANGE)
            CboLargeChange.AddOnSelectedIndexChanged(New System.EventHandler(AddressOf Me.CboLargeChange_SelectedIndexChanged))
		    CboLargeChange.SelectedItem = "5"

            lblHValue.Location = New System.Drawing.Point(128, 88)
            lblHValue.Text = "0"
            lblHValue.Size = New System.Drawing.Size(40, 16)
            lblHValue.TabIndex = 7
            lblHValue.TextAlign = System.WinForms.HorizontalAlignment.Center

            Label11.Location = New System.Drawing.Point(16, 232)
            Label11.Text = "-100"
            Label11.Size = New System.Drawing.Size(40, 16)
            Label11.TabIndex = 10

            Label10.Location = New System.Drawing.Point(240, 104)
            Label10.Text = "0"
            Label10.Size = New System.Drawing.Size(24, 16)
            Label10.TabIndex = 9

            Label4.Location = New System.Drawing.Point(8, 120)
            Label4.Text = "VScrollBarValue"
            Label4.Size = New System.Drawing.Size(104, 16)
            Label4.TabIndex = 6

            imgContainer.Location = New System.Drawing.Point(48, 48)
            imgContainer.Size = New System.Drawing.Size(100, 100)
            imgContainer.TabIndex = 2
            imgContainer.TabStop = False
            imgContainer.Text = "imgContainer"
			imgContainer.Image = System.Drawing.Image.FromFile("Water.BMP")
			imgContainer.AddOnMouseDown(New System.Winforms.MouseEventHandler(AddressOf Me.imgContainer_MouseDown))
			imgContainer.AddOnMouseUp(New System.Winforms.MouseEventHandler(AddressOf Me.imgContainer_MouseUp))
			imgContainer.AddOnMouseMove(New System.Winforms.MouseEventHandler(AddressOf Me.imgContainer_MouseMove))

            Label9.Location = New System.Drawing.Point(240, 16)
            Label9.Text = "-100"
            Label9.Size = New System.Drawing.Size(32, 16)
            Label9.TabIndex = 8

            vsVScroll.LargeChange = 5
			vsVScroll.SmallChange = 1
            vsVScroll.Location = New System.Drawing.Point(216, 8)
            vsVScroll.Minimum = -100
			vsVScroll.Maximum = 100
            vsVScroll.TabIndex = 1
            vsVScroll.Size = New System.Drawing.Size(16, 200)
			vsVScroll.AddOnScroll(New ScrollEventHandler(AddressOf Me.vsVScroll_Scroll))

            Label8.Location = New System.Drawing.Point(240, 184)
            Label8.Text = "100"
            Label8.Size = New System.Drawing.Size(24, 16)
            Label8.TabIndex = 7

            Label6.Location = New System.Drawing.Point(192, 232)
            Label6.Text = "100"
            Label6.Size = New System.Drawing.Size(32, 16)
            Label6.TabIndex = 6

            Label3.Location = New System.Drawing.Point(8, 88)
            Label3.Text = "HScrollBarValue"
            Label3.Size = New System.Drawing.Size(104, 16)
            Label3.TabIndex = 5

            Label2.Location = New System.Drawing.Point(8, 48)
            Label2.Text = "SmallChange"
            Label2.Size = New System.Drawing.Size(80, 16)
            Label2.TabIndex = 4

            Label1.Location = New System.Drawing.Point(8, 24)
            Label1.Text = "LargeChange"
            Label1.Size = New System.Drawing.Size(80, 16)
            Label1.TabIndex = 3

            Me.Controls.Add(Label11)
            Me.Controls.Add(Label10)
            Me.Controls.Add(Label9)
            Me.Controls.Add(Label8)
            Me.Controls.Add(Label6)
            Me.Controls.Add(Label5)
            Me.Controls.Add(GroupBox1)
            Me.Controls.Add(imgContainer)
            Me.Controls.Add(vsVScroll)
            Me.Controls.Add(hsHScroll)
            GroupBox1.Controls.Add(lblVValue)
            GroupBox1.Controls.Add(lblHValue)
            GroupBox1.Controls.Add(Label4)
            GroupBox1.Controls.Add(Label3)
            GroupBox1.Controls.Add(Label2)
            GroupBox1.Controls.Add(Label1)
            GroupBox1.Controls.Add(cboSmallChange)
            GroupBox1.Controls.Add(CboLargeChange)
	    
        End Sub

	Private Function GetArray(ItemsList As String) As Object
		GetArray = ItemsList.Split(",")
	End Function

	Protected Sub CboLargeChange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
	    vsVScroll.LargeChange = cInt(cboLargeChange.SelectedItem)
	    hsHScroll.LargeChange = CInt(cboLargeChange.SelectedItem)
    End Sub

	Protected Sub CboSmallChange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    	vsVScroll.SmallChange = cInt(cboSmallChange.SelectedItem)
	    hsHScroll.SmallChange = cInt(cboSmallChange.SelectedItem)
    End Sub

	Protected Sub hsHScroll_Scroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) 
	    lblHValue.Text = cStr(hsHScroll.Value)
	    imgContainer.Left = hsHScroll.Left + ((hsHScroll.Width - imgContainer.Width + hsHScroll.Value) / 2)  	
	End Sub

	Protected Sub vsVScroll_Scroll(ByVal sender As System.Object, ByVal e As ScrollEventArgs) 
	    lblVValue.Text = cStr(vsVScroll.Value)
	    imgContainer.Top = vsVScroll.Top + ((vsVScroll.Height - imgContainer.Height + vsVScroll.Value) / 2)
	End Sub

	Protected Sub imgContainer_MouseDown(ByVal Sender As System.Object, ByVal e As MouseEventArgs)
	    MouseX = e.X
	    MouseY = e.Y
	    Dragging = True
	End Sub

	Protected Sub imgContainer_MouseMove(ByVal Sender As System.Object, ByVal e As MouseEventArgs)
        ' Mouse event handler to effect dragging the pictureBox around.
        If Dragging Then
            Dim MinY As Integer = vsVScroll.Minimum
            Dim maxY As Integer = vsVScroll.Maximum
            Dim minX As Integer = hsHScroll.Minimum
            Dim maxX As Integer = hsHScroll.Maximum

			' move the image with the mouse in Y dimension
            Dim CurrentValue As Integer = imgContainer.Top + (e.Y - MouseY)
            If (CurrentValue < vsVScroll.Top) Then
                CurrentValue = vsVScroll.Top
            Else If (CurrentValue > vsVScroll.Bottom - imgContainer.Height) Then
                CurrentValue = vsVScroll.Bottom - imgContainer.Height
            End If
            imgContainer.Top = CurrentValue

			' and in the X dimension
            CurrentValue = imgContainer.Left + (e.X - MouseX)
            If (CurrentValue < hsHScroll.Left) Then
                CurrentValue = hsHScroll.Left
            Else If (CurrentValue > hsHScroll.Right - imgContainer.Width) Then
                CurrentValue = hsHScroll.Right - imgContainer.Width
            End If
            imgContainer.Left = CurrentValue

			'now set the scroll bar values based on the image location and update the label
		    vsVScroll.Value = ((imgContainer.Top - vsVScroll.Top) + ((imgContainer.Height - vsVScroll.Height) / 2)) * 2
		    lblVValue.Text = cStr(vsVScroll.Value)
			hsHScroll.Value = ((imgContainer.Left - hsHScroll.Left) + ((imgContainer.Width - hsHScroll.Width) / 2)) * 2
			lblHValue.Text = cStr(hsHScroll.Value)
			
        End If
	End Sub	

	Protected Sub imgContainer_MouseUp(ByVal Sender As System.Object, ByVal e As MouseEventArgs)
	    Dragging = False
	End Sub

	Protected Sub Win32Form1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
    
    End Sub
	
    End Class

End Namespace

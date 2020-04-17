 '---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Security.Permissions
Imports System.Globalization


'/ <summary>
'/ Summary description for form.
'/ </summary>

Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer = Nothing


    Public Sub New()
        InitializeComponent()

    End Sub 'New

    Private Sub InitializeTextBoxes()
        ' Set the text property of the respective text boxes to their corresponding SplitContainer property values
        Me.SplitterDistance.Text = GetSplitterDistance(Me.splitContainer1)
        Me.SplitterWidth.Text = GetSplitterWidth(Me.splitContainer1)
        Me.SplitterIncrement.Text = GetSplitterIncrement(Me.splitContainer1)
        Me.Panel1MinSize.Text = GetPanel1MinSize(Me.splitContainer1)
        Me.Panel2MinSize.Text = GetPanel2MinSize(Me.splitContainer1)

    End Sub 'InitializeTextBoxes

    Private Function GetSplitterDistance(ByVal splitter As System.Windows.Forms.SplitContainer) As String
        ' Grab the SplitterDistance property for the current splitter and convert it to text
        ' (cause that's what the text box will need)
        Return splitter.SplitterDistance.ToString(CultureInfo.CurrentUICulture)

    End Function 'GetSplitterDistance


    Private Function GetSplitterWidth(ByVal splitter As System.Windows.Forms.SplitContainer) As String
        ' Grab the SplitterWidth property for the current splitter and convert it to text
        ' (cause that's what the text box will need)
        Return splitter.SplitterWidth.ToString(CultureInfo.CurrentUICulture)

    End Function 'GetSplitterWidth


    Private Function GetSplitterIncrement(ByVal splitter As System.Windows.Forms.SplitContainer) As String
        ' Grab the SplitterIncrement property for the current splitter and convert it to text
        ' (cause that's what the text box will need)
        Return splitter.SplitterIncrement.ToString(CultureInfo.CurrentUICulture)

    End Function 'GetSplitterIncrement

    Private Function GetPanel1MinSize(ByVal splitter As System.Windows.Forms.SplitContainer) As String
        ' Grab the Panel1MinSize property for the current splitter and convert it to text
        ' (cause that's what the text box will need)
        Return splitter.Panel1MinSize.ToString(CultureInfo.CurrentUICulture)
    End Function

    Private Function GetPanel2MinSize(ByVal splitter As System.Windows.Forms.SplitContainer) As String
        ' Grab the Panel2MinSize property for the current splitter and convert it to text
        ' (cause that's what the text box will need)
        Return splitter.Panel2MinSize.ToString(CultureInfo.CurrentUICulture)
    End Function

    Private Sub splitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles splitContainer1.SplitterMoved
        ' This event will be fired every time the splitter is moved
        ' The 'sender' parameter will contain the actual splitter control that raised the event
        ' We need to cast it to a SplitContainer since it comes in as an 'object'
        Dim splitter As System.Windows.Forms.SplitContainer = CType(sender, System.Windows.Forms.SplitContainer)

        ' Populate the 'SplitterDistance' text box with the current value of the SplitterDistance property
        ' of the splitter control.
        Me.SplitterDistance.Text = GetSplitterDistance(splitter)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load, MyBase.Load
        ' On FormLoad we want to initialize our text box controls to have the current values
        ' of the respective SplitContainer properties (SplitterDistance, SplitterWidth and SplitterIncrement)
        InitializeTextBoxes()

        Me.RestorePanel2ToolStripMenuItem.Enabled = False

    End Sub

    Private Sub OrientationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrientationButton.Click
        ' This event fires every time the 'Orientation' button is clicked
        ' The idea is that each time the button is clicked, the orientation of the SplitContainer
        ' will toggle between 'Vertical' and 'Horizontal' orientation
        ' The sender parameter is the button that was clicked.  We need to cast is to Button
        Dim orientationButton As Button = CType(sender, Button)

        ' Decide what the orientation should be based upon the current values
        If Me.splitContainer1.Orientation = Orientation.Vertical Then
            ' Set the actual SplitContainer orientation property
            Me.splitContainer1.Orientation = Orientation.Horizontal
            ' Change the text of the button to reflect the toggle
            orientationButton.Text = "&Horizontal"
            Me.splitContainer1.SplitterDistance = 150
        Else
            ' Set the actual SplitContainer orientation property
            Me.splitContainer1.Orientation = Orientation.Vertical
            ' Change the text of the button to reflect the toggle
            orientationButton.Text = "&Vertical"
        End If

    End Sub

    Private Sub SplitterIncrement_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitterIncrement.Validated
        ' This event will fire when the user changes the Splitter Increment
        ' The sender parameter will be the text box that fired the event
        ' We need to cast it to a TextBox type in order to use it as a TextBox
        Dim splitterIncrement As TextBox = CType(sender, TextBox)


        ' Do the conversion from text to integer
        Me.splitContainer1.SplitterIncrement = Convert.ToInt32(splitterIncrement.Text, CultureInfo.CurrentUICulture)
    End Sub

    Private Sub SplitterIncrement_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SplitterIncrement.Validating

        ' We need to validate the using input to make sure that a valid value was entered for the SplitterIncrement 
        ' property
        Try
            Dim tryValue As Int32 = Int32.Parse(Me.SplitterIncrement.Text)
            If (tryValue > 0) Then
                Me.ErrorProvider1.SetError(Me.SplitterIncrement, "")
            Else
                Me.ErrorProvider1.SetError(Me.SplitterIncrement, "Invalid value for SplitterIncrement, must be a valid integer greater than zero")
                e.Cancel = True
            End If
        Catch ex As Exception
            Me.ErrorProvider1.SetError(Me.SplitterIncrement, "Invalid value for SplitterIncrement, must be a valid integer greater than zero")
            e.Cancel = True

        End Try
    End Sub

    Private Sub SplitterWidth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitterWidth.Validated
        ' This event will fire when the user changes the Splitter Width
        ' The sender parameter will be the text box that fired the event
        ' We need to cast it to a TextBox type in order to use it as a TextBox
        Dim splitterWidth As TextBox = CType(sender, TextBox)


        ' Need to convert the text to an integer
        Me.splitContainer1.SplitterWidth = Convert.ToInt32(splitterWidth.Text, CultureInfo.CurrentUICulture)
    End Sub

    Private Sub SplitterWidth_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SplitterWidth.Validating
        ' We need to validate the using input to make sure that a valid value was entered for the SplitterWidth 
        ' property
        Try
            Dim tryValue As Int32 = Int32.Parse(Me.SplitterWidth.Text)
            If (tryValue > 0) Then
                Me.ErrorProvider1.SetError(Me.SplitterWidth, "")
            Else
                Me.ErrorProvider1.SetError(Me.SplitterWidth, "Invalid value for SplitterWidth, must be a valid integer greater than zero")
                e.Cancel = True
            End If
        Catch ex As Exception
            Me.ErrorProvider1.SetError(Me.SplitterWidth, "Invalid value for SplitterWidth, must be a valid integer greater than zero")
            e.Cancel = True

        End Try
    End Sub

    Private Sub Panel1MinSize_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Panel1MinSize.Validating
        ' We need to validate the using input to make sure that a valid value was entered for the Panel1MinSize 
        ' property
        Try
            Dim tryValue As Int32 = Int32.Parse(Me.Panel1MinSize.Text)
            If (tryValue > 0) Then
                Me.ErrorProvider1.SetError(Me.Panel1MinSize, "")
            Else
                Me.ErrorProvider1.SetError(Me.Panel1MinSize, "Invalid value for Panel1MinSize, must be a valid integer greater than zero")
                e.Cancel = True
            End If
        Catch ex As Exception
            Me.ErrorProvider1.SetError(Me.Panel1MinSize, "Invalid value for Panel1MinSize, must be a valid integer greater than zero")
            e.Cancel = True

        End Try
    End Sub

    Private Sub Panel1MinSize_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1MinSize.Validated
        ' This event will fire when the user changes Panel1MinSize
        ' The sender parameter will be the text box that fired the event
        ' We need to cast it to a TextBox type in order to use it as a TextBox
        Dim panel1MinSize As TextBox = CType(sender, TextBox)


        ' Need to convert the text to an integer
        Me.splitContainer1.Panel1MinSize = Convert.ToInt32(panel1MinSize.Text, CultureInfo.CurrentUICulture)
    End Sub

    Private Sub Panel2MinSize_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Panel2MinSize.Validating
        ' We need to validate the using input to make sure that a valid value was entered for the Panel2MinSize 
        ' property
        Try
            Dim tryValue As Int32 = Int32.Parse(Me.Panel2MinSize.Text)
            If (tryValue > 0) Then
                Me.ErrorProvider1.SetError(Me.Panel2MinSize, "")
            Else
                Me.ErrorProvider1.SetError(Me.Panel2MinSize, "Invalid value for Panel2MinSize, must be a valid integer greater than zero")
                e.Cancel = True
            End If
        Catch ex As Exception
            Me.ErrorProvider1.SetError(Me.Panel2MinSize, "Invalid value for Panel2MinSize, must be a valid integer greater than zero")
            e.Cancel = True

        End Try
    End Sub

    Private Sub Panel2MinSize_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2MinSize.Validated
        ' This event will fire when the user changes Panel2MinSize
        ' The sender parameter will be the text box that fired the event
        ' We need to cast it to a TextBox type in order to use it as a TextBox
        Dim panel2MinSize As TextBox = CType(sender, TextBox)


        ' Need to convert the text to an integer
        Me.splitContainer1.Panel2MinSize = Convert.ToInt32(panel2MinSize.Text, CultureInfo.CurrentUICulture)
    End Sub

    Private Sub Panel1Collapsed_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1Collapsed.CheckStateChanged
        ' Toggle the Panel1Collapsed property based on the value of the check box
        Me.splitContainer1.Panel1Collapsed = Panel1Collapsed.Checked

    End Sub

    Private Sub Panel2Collapsed_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2Collapsed.CheckStateChanged
        ' Toggle the Panel2Collapsed property based on the value of the check box
        Me.splitContainer1.Panel2Collapsed = Panel2Collapsed.Checked

        If (Me.splitContainer1.Panel2Collapsed) Then
            Me.RestorePanel2ToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub RestorePanel2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestorePanel2ToolStripMenuItem.Click
        Me.splitContainer1.Panel2Collapsed = False
        Me.Panel2Collapsed.Checked = False
        Me.RestorePanel2ToolStripMenuItem.Enabled = False
    End Sub

End Class 'Form1 

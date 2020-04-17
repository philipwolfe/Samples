'=====================================================================
'  File:      TaskPaneTest.vb
'
'  Summary:   This is a simple demo form for the TaskPane
'
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

Imports Microsoft.Samples.Windows.Forms.TaskPane



'=---------------------------------------------------------------------------=
' TaskPaneTest
'=---------------------------------------------------------------------------=
''' <summary>
'''   This is a simple demo form for the TaskPane sample.
''' </summary>
''' 
Public Class TaskPaneTest

    '=-----------------------------------------------------------------------=
    ' addAndRemoveButton_Click
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   In this function, we will add and remove a bunch of frames from 
    '''   the TaskPane control, so you can see how it's done.  
    '''   Basically, it's just a collection like any other control with 
    '''   a collection of controls  hanging off it.  We will show you a
    '''   few different ways to do this.
    ''' </summary>
    ''' 
    Private Sub addAndRemoveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addAndRemoveButton.Click

        Dim tf As TaskFrame

        ' Create a new TaskFrame control to add to our parent TaskPane.  
        tf = New TaskFrame
        tf.BackColor = Color.Blue

        tf.CollapseButtonVisible = True
        tf.Text = "Newly Added Frame"

        ' Add it to the parent. 
        Me.TaskPane1.TaskFrames.Add(tf)

        ' now, let's go and delete one of the frames that we don't want
        Me.TaskPane1.TaskFrames.Remove(Me.TaskFrame0)

        ' Did you notice in the designer that there was a hidden TaskFrame
        ' there with its Visible property set to False?  It still shows up
        ' in the Designer, but not at runtime until its Visible property is
        ' set to True.
        Me.hiddenTaskFrame.Visible = True

        ' Add TaskFrame0 back, but this time at the end of the list of frames.
        Me.TaskPane1.Controls.Add(Me.TaskFrame0)

    End Sub ' addAndRemoveButton_Click



    '=-----------------------------------------------------------------------=
    ' expandAndCollapseFramesButton_Click
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Demo expanding and collapsing frames.
    ''' </summary>
    ''' 
    Private Sub expandAndCollapseFramesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles expandAndCollapseFramesButton.Click

        ' Toggle IsExpanded for known TaskFrames
        ' Note: TaskFrames created by clicking 'Add, Remove and Reorder' not included.
        '
        Me.TaskFrame0.IsExpanded = Not Me.TaskFrame0.IsExpanded
        Me.TaskFrame1.IsExpanded = Not Me.TaskFrame1.IsExpanded
        Me.TaskFrame2.IsExpanded = Not Me.TaskFrame2.IsExpanded
        If (Me.hiddenTaskFrame.Visible) Then
            Me.hiddenTaskFrame.IsExpanded = Not Me.hiddenTaskFrame.IsExpanded
        End If

    End Sub ' expandAndCollapseFramesButton_Click


    '=-----------------------------------------------------------------------=
    ' sysDefCornerStyleRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed the corner style.
    ''' </summary>
    ''' 
    Private Sub sysDefCornerStyleRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sysDefCornerStyleRadio.CheckedChanged
        Me.TaskPane1.CornerStyle = TaskFrameCornerStyle.SystemDefault
    End Sub



    '=-----------------------------------------------------------------------=
    ' roundedCornerStyleRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed the corner style.
    ''' </summary>
    ''' 
    Private Sub roundedCornerStyleRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles roundedCornerStyleRadio.CheckedChanged
        Me.TaskPane1.CornerStyle = TaskFrameCornerStyle.Rounded
    End Sub



    '=-----------------------------------------------------------------------=
    ' squaredCornerStyleRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed the corner style.
    ''' </summary>
    ''' 
    Private Sub squaredCornerStyleRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles squaredCornerStyleRadio.CheckedChanged
        Me.TaskPane1.CornerStyle = TaskFrameCornerStyle.Squared
    End Sub


    '=-----------------------------------------------------------------------=
    ' leftDockRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed where the TaskPane will dock.
    ''' </summary>
    ''' 
    Private Sub leftDockRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leftDockRadio.CheckedChanged
        Me.TaskPane1.Dock = DockStyle.Left
        Me.testPanel.Dock = DockStyle.Fill
    End Sub


    '=-----------------------------------------------------------------------=
    ' topDockRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed where the TaskPane will dock.
    ''' </summary>
    ''' 
    Private Sub topDockRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles topDockRadio.CheckedChanged
        Me.TaskPane1.Height = 150
        Me.TaskPane1.Dock = DockStyle.Top
        Me.testPanel.Dock = DockStyle.Fill

    End Sub


    '=-----------------------------------------------------------------------=
    ' bottomDockRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed where the TaskPane will dock.
    ''' </summary>
    ''' 
    Private Sub bottomDockRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bottomDockRadio.CheckedChanged
        Me.TaskPane1.Height = 150
        Me.TaskPane1.Dock = DockStyle.Bottom
        Me.testPanel.Dock = DockStyle.Fill
    End Sub


    '=-----------------------------------------------------------------------=
    ' rightDockRadio_CheckedChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has changed where the TaskPane will dock.
    ''' </summary>
    ''' 
    Private Sub rightDockRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rightDockRadio.CheckedChanged
        Me.TaskPane1.Dock = DockStyle.Right
        Me.testPanel.Dock = DockStyle.Fill
    End Sub



    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MessageBox.Show("Link Clicked")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        MessageBox.Show("Link Clicked")

    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        MessageBox.Show("Link Clicked")

    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        MessageBox.Show("Link Clicked")

    End Sub
End Class ' TaskPaneTest

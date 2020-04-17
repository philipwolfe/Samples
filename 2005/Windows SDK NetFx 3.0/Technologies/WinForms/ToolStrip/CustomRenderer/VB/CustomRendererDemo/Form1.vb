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



'=--------------------------------------------------------------------------=
' Form1
'=--------------------------------------------------------------------------=
''' <summary>
'''   This is a simple little test Form to demonstrate our CustomRenderer
'''   class.  It basically lets the user switch between renderers and 
'''   play with some settings.
''' </summary>
''' 
Public Class Form1

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                      Private types/data/goo/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '''
    ''' <summary>
    '''   This is the CustomRenderer with which we're going to work.  We're
    '''   going to actually keep it around and try not to create too many of
    '''   these as they hold on to a Timer object until cleaned up.
    ''' </summary>
    ''' 
    Private m_customRenderer As CustomRendererClassLibrary.CustomRenderer








    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                Non-Public Methods/Functions/etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=



    '=----------------------------------------------------------------------=
    ' Form_Load
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This sets up any last minute stuff and prepares us for the 
    '''   showing of the form.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   The form from whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty
    ''' </param>
    ''' 
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
                           Handles MyBase.Load

        Me.m_customRenderer = New CustomRendererClassLibrary.CustomRenderer
        Me.DropDownButtonToolStripButton.DropDown = New ToolStripDropDown

        Me.startColorDemoPanel.BackColor = Color.SandyBrown
        Me.endColorDemoPanel.BackColor = Color.Azure

    End Sub ' Form1_Load


    '=----------------------------------------------------------------------=
    ' ExitToolStripMenuItem_Click
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user wants to close the form.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   The ToolStripMenuItem from whence the notification came.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   EventArgs.Empty
    ''' </param>
    ''' 
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub ' ExitToolStripMenuItem_Click


    '=----------------------------------------------------------------------=
    ' normalRendererRadio_CheckedChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user wants to use a normal renderer now.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty.
    ''' </param>
    ''' 
    Private Sub normalRendererRadio_CheckedChanged( _
                                ByVal sender As Object, _
                                ByVal e As EventArgs) _
                                Handles normalRendererRadio.CheckedChanged

        If Me.normalRendererRadio.Checked Then

            Me.ToolStrip1.RenderMode = ToolStripRenderMode.Professional
            Me.MenuStrip1.RenderMode = ToolStripRenderMode.Professional
            Me.StatusStrip1.RenderMode = ToolStripRenderMode.Professional

            For x As Integer = 0 To Me.Controls.Count - 1
                If TypeOf Me.Controls(x) Is ToolStripPanel Then
                    CType(Me.Controls(x), ToolStripPanel).RenderMode _
                                = ToolStripRenderMode.Professional
                End If
            Next

            Me.superCoolSettingsGroupBox.Enabled = False
        End If

    End Sub ' normalRendererRadio_CheckedChanged


    '=----------------------------------------------------------------------=
    ' superCoolRendererRadio_CheckedChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user wants to use our new super cool renderer now.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty.
    ''' </param>
    ''' 
    Private Sub superCoolRendererRadio_CheckedChanged( _
                                ByVal sender As Object, _
                                ByVal e As EventArgs) _
                                Handles superCoolRendererRadio.CheckedChanged

        If Me.superCoolRendererRadio.Checked Then
            Me.m_customRenderer.Color1 = Me.startColorDemoPanel.BackColor
            Me.m_customRenderer.Color2 = Me.endColorDemoPanel.BackColor
            Me.m_customRenderer.DrawToolbarBorder = Me.drawToolbarBorderCheckbox.Checked

            Me.ToolStrip1.Renderer = Me.m_customRenderer
            Me.MenuStrip1.Renderer = Me.m_customRenderer
            Me.StatusStrip1.Renderer = Me.m_customRenderer

            For x As Integer = 0 To Me.Controls.Count - 1
                If TypeOf Me.Controls(x) Is ToolStripPanel Then
                    CType(Me.Controls(x), ToolStripPanel).Renderer = Me.m_customRenderer
                End If
            Next

            Me.superCoolSettingsGroupBox.Enabled = True
        End If

    End Sub ' superCoolRendererRadio_CheckedChanged


    '=----------------------------------------------------------------------=
    ' drawToolbarBorderCheckbox_CheckedChanged
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Controls whether or not the CustomRenderer will draw a toolbar
    '''   border.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty.
    ''' </param>
    ''' 
    Private Sub drawToolbarBorderCheckbox_CheckedChanged( _
                             ByVal sender As System.Object, _
                             ByVal e As System.EventArgs) _
                             Handles drawToolbarBorderCheckbox.CheckedChanged

        superCoolRendererRadio_CheckedChanged(Me.superCoolRendererRadio, _
                                      EventArgs.Empty)

    End Sub ' drawToolbarBorderCheckbox_CheckedChanged


    '=----------------------------------------------------------------------=
    ' startColorButton_Click
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Lets the user pick Color1 on the CustomRenderer.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty.
    ''' </param>
    ''' 
    Private Sub startColorButton_Click(ByVal sender As Object, _
                                        ByVal e As EventArgs) _
                                        Handles startColorButton.Click

        Dim dr As DialogResult

        '
        ' bring up a dialog to let the user pick a color, and update the
        ' demonstration panel.
        '
        dr = Me.chooseColorDialog.ShowDialog(Me)
        If dr = Windows.Forms.DialogResult.OK Then
            Me.startColorDemoPanel.BackColor = Me.chooseColorDialog.Color
        End If

        superCoolRendererRadio_CheckedChanged(Me.superCoolRendererRadio, _
                                      EventArgs.Empty)

    End Sub ' startColorButton_Click


    '=----------------------------------------------------------------------=
    ' endColorButton_Click
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Lets the user modify Color2 on the CustomRenderer
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event.
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   System.EventArgs.Empty.
    ''' </param>
    ''' 
    Private Sub endColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles endColorButton.Click

        Dim dr As DialogResult

        '
        ' bring up a dialog to let the user pick a color, and update the
        ' demonstration panel.
        '
        dr = Me.chooseColorDialog.ShowDialog(Me)
        If dr = Windows.Forms.DialogResult.OK Then
            Me.endColorDemoPanel.BackColor = Me.chooseColorDialog.Color
        End If

        superCoolRendererRadio_CheckedChanged(Me.superCoolRendererRadio, _
                                      EventArgs.Empty)

    End Sub ' endColorButton_Click


End Class ' Form1

'=====================================================================
'  File:      CaptionBar.vb
'
'  Summary:   This is a package private class that actually implements
'             the caption bar across the top of individual TaskFrames
'             within the parent TaskPane container control.
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

Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel
Imports System.Collections
Imports System.Runtime.InteropServices

'=----------------------------------------------------------------------=
' CaptionBar
'=-------------------------------------------------------------------------=
''' <summary>
'''   this is a little private class to draw and manage the caption bars 
'''   across the top of each TaskFrame within our pane control.
''' </summary>
''' 
Friend Class CaptionBar
    Inherits Control

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                   Private Members/Structs/Consts
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    Private Const CAPTIONBAR_PAD As Integer = 8
    Private Const COLLAPSE_BUTTON_DIAMETER As Integer = 16


    ''' 
    ''' <summary>
    '''   The TaskFrame panel to which we are tied
    ''' </summary>
    ''' 
    Private m_buddyFrame As TaskFrame

    ''' 
    ''' <summary>
    '''   Is the user hovering the mouse over our client area?
    ''' </summary>
    ''' 
    Private m_hovering As Boolean

    ''' 
    ''' <summary>
    '''   did the user press the mouse button in our caption area?
    ''' </summary>
    ''' 
    Private m_mousePress As Boolean

    ''' 
    ''' <summary>
    '''   This is the height of our title bar area, excluding any icon/image
    '''   peeking up over the top.
    ''' </summary>
    ''' 
    Private m_captionHeight As Integer






    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods/Properties
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Initializes a new instance of this class.
    ''' </summary>
    ''' 
    ''' <param name="in_buddyFrame">
    '''   The frame to which we are linked.
    ''' </param>
    ''' 
    Public Sub New(ByVal in_buddyFrame As TaskFrame)

        System.Diagnostics.Debug.Assert(Not in_buddyFrame Is Nothing)

        Me.m_buddyFrame = in_buddyFrame
        Me.m_hovering = False
        Me.m_mousePress = False

        '
        ' Set us up for minimal flicker, max perf, and the ability
        ' to draw the rounded corners (we need to be able to be 
        ' transparent for that).
        '
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        '
        ' Make sure we don't bother sending this to the HWND, since it
        ' will never see/use it.
        '
        SetStyle(ControlStyles.CacheText, True)

        '
        ' Other values we just want to have set up properly.
        '
        Me.BackColor = Color.Transparent

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Visible
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   If somebody traipses through the collection of controls, finds
    '''   this one and forces a change on the Visible property, we want to
    '''    be sure that  our buddy TaskFrame goes too.
    ''' </summary>
    ''' 
    Public Shadows Property Visible() As Boolean
        Get
            Return MyBase.Visible
        End Get

        Set(ByVal in_newVisible As Boolean)

            setVisibleInternal(in_newVisible)
            If Not Me.m_buddyFrame.Visible = in_newVisible Then
                Me.m_buddyFrame.Visible = in_newVisible
            End If

        End Set

    End Property ' Visible


    '=----------------------------------------------------------------------=
    ' Enabled
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   If somebody traipses through the collection of controls, finds 
    '''   this one and forces a change on the Enabled property, we want to
    '''   be sure that  our buddy TaskFrame goes too.
    ''' </summary>
    ''' 
    Public Shadows Property Enabled() As Boolean
        Get
            Return MyBase.Enabled
        End Get

        Set(ByVal in_newEnabled As Boolean)

            '
            ' They will call our setEnabledInternal method ...
            '
            If Not Me.m_buddyFrame.Enabled = in_newEnabled Then
                Me.m_buddyFrame.Enabled = in_newEnabled
            End If

        End Set

    End Property ' Enabled


    '=----------------------------------------------------------------------=
    ' Font
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   if somebody sets our font, we have to recompute our height, and
    '''   possibly relayout the entire control.
    ''' </summary>
    ''' 
    Public Shadows Property Font() As Font

        Get
            Return MyBase.Font
        End Get

        '
        ' Set the new font if necessary, and then force a relayout
        '
        Set(ByVal in_newFont As Font)

            '
            ' They will call our setFontInternal method ...
            '
            Me.m_buddyFrame.Font = in_newFont

        End Set

    End Property ' Font






    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '             Private/Protected/Friend Methods/Properties
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Make sure we've got our sizes and all that jazz computed properly.
    ''' </summary>
    ''' 
    Protected Overrides Sub CreateHandle()

        MyBase.CreateHandle()
        recomputeSizes()

    End Sub ' CreateHandle


    '=----------------------------------------------------------------------=
    ' recomputeSizes
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We have had something on us change what our size could possibly be.
    '''   Go and recompute our total size now, and force a relayout on the 
    '''   container if necessary.
    ''' </summary>
    ''' 
    Friend Sub recomputeSizes()

        Dim imageHeight As Integer
        Dim fontHeight As Integer
        Dim tp As TaskPane

        tp = CType(Me.m_buddyFrame.Parent, TaskPane)

        '
        ' Get the font height, and add enough so that it's rounded up for
        ' sure
        '
        fontHeight = CType(Me.Font.GetHeight() + 0.5, Integer)

        '
        ' Get the image height, capping it at 32
        '
        If Not Me.m_buddyFrame.Image Is Nothing Then
            imageHeight = Me.m_buddyFrame.Image.Height
        End If

        If imageHeight > 32 Then imageHeight = 32
        If imageHeight < 0 Then imageHeight = 0

        '
        ' Finally, take the greater of the imageheight or the font height.
        '
        setHeights(fontHeight, imageHeight)

    End Sub ' recomputeSizes


    '=----------------------------------------------------------------------=
    ' setHeights
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Sets our various heights (total height, caption bar height, etc)
    '''   from the given values computed earlier.
    ''' </summary>
    ''' 
    ''' <param name="in_fontHeight">
    '''   height of a line of text
    ''' </param>
    ''' 
    ''' <param name="in_imageHeight">
    '''   height of our associated image
    ''' </param>
    ''' 
    Private Sub setHeights(ByVal in_fontHeight As Integer, _
                           ByVal in_imageHeight As Integer)

        Dim tp As TaskPane

        tp = CType(Me.m_buddyFrame.Parent, TaskPane)

        '
        ' Allow for two pixels of padding on top and on the bottom.
        '
        If in_imageHeight > FontHeight + CAPTIONBAR_PAD Then
            Me.Height = in_imageHeight
        Else
            Me.Height = FontHeight + CAPTIONBAR_PAD
        End If

        '
        ' Save the caption height for later !!!
        '
        Me.m_captionHeight = FontHeight + CAPTIONBAR_PAD

        '
        ' Finally, tell our parent control about this ...
        '
        If Not tp Is Nothing Then
            If tp.IsHandleCreated Then
                tp.layoutAllFrames()
            End If
        End If

    End Sub  ' setHeights


    '=----------------------------------------------------------------------=
    ' setFontInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Somebody has set the Font property on the TaskFrame, so ours
    '''   needs to be updated as well!
    ''' </summary>
    ''' 
    ''' <param name="in_font">
    '''   new value
    ''' </param>
    ''' 
    Friend Sub setFontInternal(ByVal in_font As Font)

        If in_font Is Nothing OrElse Not in_font.Equals(MyBase.Font) Then

            MyBase.Font = in_font
            If Me.IsHandleCreated Then recomputeSizes()
            Me.Refresh()

        End If

    End Sub ' setFontInternal


    '=----------------------------------------------------------------------=
    ' setVisibleInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Internal way to set the Visible bit without causing a stack fault 
    '''   by calling in and out of our buddy frame's Visible property ... 
    ''' </summary>
    ''' 
    ''' <param name="in_newVisible">
    '''   New Value.
    ''' </param>
    ''' 
    Protected Friend Sub setVisibleInternal(ByVal in_newVisible As Boolean)

        If Not (MyBase.Visible = in_newVisible) Then
            MyBase.Visible = in_newVisible
        End If

    End Sub ' setVisibleInternal


    '=----------------------------------------------------------------------=
    ' setEnabledInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Internal way to set the Enabled bit without causing a stack fault 
    '''   by calling in and out of our buddy frame's Visible property ... 
    ''' </summary>
    ''' 
    ''' <param name="in_newEnabled">
    '''   New Value.
    ''' </param>
    ''' 
    Protected Friend Sub setEnabledInternal(ByVal in_newEnabled As Boolean)

        If Not MyBase.Enabled = in_newEnabled Then
            MyBase.Enabled = in_newEnabled
        End If

    End Sub ' setEnabledInternal


    '=----------------------------------------------------------------------=
    ' OnPaint
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Repaint our client area.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about it.
    ''' </param>
    ''' 
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
        Dim tp As TaskPane
        Dim top As Integer
        Dim g As Graphics
        Dim w As Integer

        tp = CType(Me.m_buddyFrame.Parent, TaskPane)
        g = e.Graphics

        lgb = createGradientBrush()

        '
        ' 1. Draw our caption area, which may be rounded or not ...
        '
        top = Me.Height - Me.m_captionHeight
        If getDrawCornersAsRounded(tp.CornerStyle) Then

            g.FillRectangle(lgb, 2, top, Me.Width - 4, 1)
            g.FillRectangle(lgb, 1, top + 1, Me.Width - 2, 1)
            g.FillRectangle(lgb, 0, top + 2, Me.Width, Me.m_captionHeight - 2)

        Else
            g.FillRectangle(lgb, New Rectangle(0, top, _
                                   Me.Width, _
                                   Me.m_captionHeight))
        End If

        lgb.Dispose()


        '
        ' 2. Draw the Focus Rect, if we've got it ...
        '
        drawFocusRect(g)

        '
        ' 3. draw the icon.
        '
        w = drawIcon(g)

        '
        ' 4. Draw the text
        '
        drawText(g, w)

        '
        ' 5. Draw the collapse button
        '
        drawCollapseButton(g)

    End Sub ' OnPaint


    '=----------------------------------------------------------------------=
    ' drawFocusRect
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   If applicable, draws a focus rect for us. 
    ''' </summary>
    ''' 
    ''' <param name="g">
    '''   Graphics device to which we must draw.
    ''' </param>
    ''' 
    Private Sub drawFocusRect(ByVal g As Graphics)

        If Me.Focused = True Then
            Dim p As Pen

            p = New Pen(colorFocusRect(), 1)
            p.DashStyle = Drawing2D.DashStyle.Dot

            g.DrawRectangle(p, 2, Me.Height - Me.m_captionHeight + 1, _
                            Me.Width - 4, Me.m_captionHeight - 4)
        End If

    End Sub ' drawFocusRect

    '=----------------------------------------------------------------------=
    ' createGradientBrush
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Goes to our buddied TaskFrame, gets the appropriate information,
    '''   and creates a System.Drawing.Drawing2D.LinearGradientBrush based
    '''   on the  information there.
    ''' </summary>
    ''' 
    Private Function createGradientBrush() As System.Drawing.Drawing2D.LinearGradientBrush

        Dim reverse As Boolean

        reverse = MiscFunctions.GetRightToLeftValue(Me.m_buddyFrame)

        Return Me.m_buddyFrame.CaptionBlend.GetLinearGradientBrush( _
                        New Rectangle(0, Me.Height - Me.m_captionHeight, Me.Width, Me.m_captionHeight), _
                        reverse)

    End Function ' createGradientBrush


    '=----------------------------------------------------------------------=
    ' getDrawCornersAsRounded
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''    Figures out from the operating system whether or not we should
    '''    draw our corners as rounded or not.
    ''' </summary>
    ''' 
    ''' <param name="in_style">
    '''   What the task pane wants.
    ''' </param>
    ''' 
    ''' <returns>
    '''   True means draw rounded.
    ''' </returns>
    ''' 
    Private Function getDrawCornersAsRounded(ByVal in_style As TaskFrameCornerStyle) As Boolean

        Select Case in_style
            Case TaskFrameCornerStyle.Rounded
                Return True

            Case TaskFrameCornerStyle.Squared
                Return False

            Case TaskFrameCornerStyle.SystemDefault
                Return systemHasRoundedCorners()

            Case Else
                Return True
        End Select

    End Function ' getDrawCornersAsRounded


    '=----------------------------------------------------------------------=
    ' drawIcon
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Draws the Icon/Image for this caption bar, if there is one.
    ''' </summary>
    ''' 
    ''' <param name="g">
    '''   Graphics object to use.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The Width of the image drawn.
    ''' </returns>
    ''' 
    Private Function drawIcon(ByVal g As Graphics) As Integer

        Dim reverse As Boolean
        Dim w, h As Integer
        Dim tp As TaskPane
        Dim img As Image

        '
        ' If there's no image, this is easy!!!
        '
        If Me.m_buddyFrame.Image Is Nothing Then Return 0

        reverse = MiscFunctions.GetRightToLeftValue(Me.m_buddyFrame)

        ' 
        ' Get the Image dimensions so we can see if we need to scale or not
        '
        tp = CType(Me.m_buddyFrame.Parent, TaskPane)
        img = Me.m_buddyFrame.Image
        w = img.Width
        h = img.Height

        If w > 32 Then w = 32
        If h > 32 Then h = 32

        '
        ' now draw the image in the appropriate place.
        '
        If reverse = False Then
            g.DrawImage(img, 0, 0, w, h)
        Else
            g.DrawImage(img, Me.Width - w - 1, 0, w, h)
        End If

        Return w

    End Function ' drawIcon


    '=----------------------------------------------------------------------=
    ' drawText
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Draws the text for this caption bar.
    ''' </summary>
    ''' 
    ''' <param name="g">
    '''   where to draw.
    ''' </param>
    ''' 
    ''' <param name="in_imgWidth">
    '''   width of the image that was drawn.
    ''' </param>
    ''' 
    Private Sub drawText(ByVal g As Graphics, ByVal in_imgWidth As Integer)

        Dim captionTextRect As RectangleF
        Dim textColor As Color
        Dim reverse As Boolean
        Dim sf As StringFormat
        Dim top As Integer

        '
        ' No Text?  E-Z.
        '
        If Me.m_buddyFrame.Text = "" Or Me.m_buddyFrame.Text Is Nothing Then Return

        reverse = MiscFunctions.GetRightToLeftValue(Me.m_buddyFrame)

        top = Me.Height - Me.m_captionHeight

        '
        ' get the bounding rect for the text
        '
        If reverse = False Then
            captionTextRect = New RectangleF(in_imgWidth + 1, _
                                            top, _
                                            Me.Width - 6 - COLLAPSE_BUTTON_DIAMETER - in_imgWidth - 1, _
                                            Me.m_captionHeight)
        Else
            captionTextRect = New RectangleF(6 + COLLAPSE_BUTTON_DIAMETER, _
                                             Me.Height - Me.m_captionHeight, _
                                             Me.Width - in_imgWidth - 6 - COLLAPSE_BUTTON_DIAMETER, _
                                             Me.m_captionHeight)
        End If

        '
        ' align the text vertically centered, and then RTL as appropriate
        '
        sf = New StringFormat
        sf.FormatFlags = StringFormatFlags.NoWrap
        sf.Alignment = StringAlignment.Near
        sf.LineAlignment = StringAlignment.Center
        If MiscFunctions.GetRightToLeftValue(Me.m_buddyFrame) Then
            sf.FormatFlags = sf.FormatFlags Or StringFormatFlags.DirectionRightToLeft
        End If

        If Me.m_hovering = False Then
            textColor = Me.m_buddyFrame.ForeColor
        Else
            textColor = Color.Blue
        End If

        g.DrawString(Me.m_buddyFrame.Text, Me.m_buddyFrame.Font, _
                     New SolidBrush(textColor), _
                     captionTextRect, sf)

    End Sub ' drawText


    '=----------------------------------------------------------------------=
    ' drawCollapseButton
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''    Draws the Collapse button for this caption bar, if appropriate.
    ''' </summary>
    ''' 
    Private Sub drawCollapseButton(ByVal g As Graphics)

        Dim sm As System.Drawing.Drawing2D.SmoothingMode
        Dim buttonRect As Rectangle
        Dim reverse As Boolean
        Dim baseLoc As Point
        Dim top As Integer
        Dim pt As Point
        Dim p As Pen

        reverse = MiscFunctions.GetRightToLeftValue(Me.m_buddyFrame)

        '
        ' No CollapseButton?  Then we're done.
        '
        If Me.m_buddyFrame.CollapseButtonVisible = False Then Return

        '
        ' Set up a nice anti-aliased pen with which we will draw this.
        '
        sm = g.SmoothingMode
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        p = New Pen(colorCollapseButtonBorder(), 1.5)

        '
        ' figure out where to draw the circle.
        ' 
        top = Me.Height - Me.m_captionHeight
        If reverse = False Then

            buttonRect = New Rectangle(Me.Width - COLLAPSE_BUTTON_DIAMETER - 5, _
                                       CType(top + (Me.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1, Integer), _
                                       COLLAPSE_BUTTON_DIAMETER, _
                                       COLLAPSE_BUTTON_DIAMETER)

            baseLoc = New Point(Me.Width - COLLAPSE_BUTTON_DIAMETER - 5, _
                                CType(top + (Me.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1, Integer))

        Else
            buttonRect = New Rectangle(5, _
                                       CType(top + (Me.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1, Integer), _
                                       COLLAPSE_BUTTON_DIAMETER, _
                                       COLLAPSE_BUTTON_DIAMETER)

            baseLoc = New Point(5, CType(top + (Me.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1, Integer))
        End If

        g.FillEllipse(New SolidBrush(Me.m_buddyFrame.CaptionBlend.StartColor), buttonRect)
        g.DrawEllipse(p, buttonRect)
        p.Dispose()

        '
        ' now draw the little chevrons
        '
        If Me.m_buddyFrame.IsExpanded = False Then

            p = New Pen(colorCollapseButtonChevrons(), 1.5)
            pt = New Point(CType(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2), Integer), _
                           CType(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2), Integer))
            g.DrawLine(p, pt, New Point(pt.X - 3, pt.Y - 3))
            g.DrawLine(p, pt, New Point(pt.X + 3, pt.Y - 3))
            pt = New Point(CInt(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2)), _
                           CInt(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2) + 4))
            g.DrawLine(p, pt, New Point(pt.X - 3, pt.Y - 3))
            g.DrawLine(p, pt, New Point(pt.X + 3, pt.Y - 3))

        Else

            p = New Pen(colorCollapseButtonChevrons(), 1.5)
            pt = New Point(CInt(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2)), _
                           CInt(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2) - 4))
            g.DrawLine(p, pt, New Point(pt.X - 3, pt.Y + 3))
            g.DrawLine(p, pt, New Point(pt.X + 3, pt.Y + 3))
            pt = New Point(CInt(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2)), _
                           CInt(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2)))
            g.DrawLine(p, pt, New Point(pt.X - 3, pt.Y + 3))
            g.DrawLine(p, pt, New Point(pt.X + 3, pt.Y + 3))

        End If


        '
        ' Restore this
        '
        g.SmoothingMode = sm


    End Sub ' drawCollapseButton


    '=----------------------------------------------------------------------=
    ' OnGotFocus
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We've got the focus.  Hooray!  Go and draw our focus rectangle now.
    ''' </summary>
    ''' 
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)

        MyBase.OnGotFocus(e)

    End Sub ' OnGotFocus


    '=----------------------------------------------------------------------=
    ' OnLostFocus
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   No more focus for us.  Don't draw the focus rectangle any more    
    ''' </summary>

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)

        MyBase.OnLostFocus(e)
        Me.Refresh()

    End Sub ' OnLostFocus


    '=----------------------------------------------------------------------=
    ' OnKeyPress
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   If the user presses AND RELEASES the Space Bar, and we've got the
    '''   focus, then we will collapse or expand the TaskFrame, reversing
    '''   the current setting.
    ''' </summary>
    ''' 
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)

        '
        ' only for space
        '
        If e.KeyChar = " " Then
            Me.m_buddyFrame.IsExpanded = Not Me.m_buddyFrame.IsExpanded
            e.Handled = True
            Return
        End If

        MyBase.OnKeyPress(e)

    End Sub ' OnKeyPress


    '=----------------------------------------------------------------------=
    ' OnKeyDown
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''  As soon as the user presses Enter or Return, we want to toggle the
    '''  state of the IsExpanded property on this frame.
    ''' </summary>
    ''' 
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            Me.m_buddyFrame.IsExpanded = Not Me.m_buddyFrame.IsExpanded
            e.Handled = True
            Return
        End If

        MyBase.OnKeyDown(e)

    End Sub ' OnKeyDown


    '=----------------------------------------------------------------------=
    ' OnMouseMouse
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user is hovering the mouse over our control, and it's over the 
    '''   caption area of the caption bar.  This will cause us
    '''   to highlight the text as it is drawn, as well as the CollapseButton.
    ''' </summary>
    ''' 
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Y > (Me.Height - Me.m_captionHeight) Then
            If Me.m_hovering = False Then
                Me.m_hovering = True
                Me.Refresh()
            End If
        Else
            If Me.m_hovering = True Then
                Me.m_hovering = False
                Me.Refresh()
            End If
        End If


    End Sub ' OnMouseMove


    '=----------------------------------------------------------------------=
    ' OnMouseLeave
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Make sure that, if we're highlighting due to thinking we're hovering 
    '''   over the control, we stop doing so when the user leaves our client
    '''   area ....
    ''' </summary>
    ''' 
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)

        If Me.m_hovering = True Then
            Me.m_hovering = False
            Me.Refresh()
        End If

    End Sub ' OnMouseLeave


    '=----------------------------------------------------------------------=
    ' OnMouseUp
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has let go of the mouse.  If they let go in the caption bar
    '''   area of our control, then it's a click event!
    ''' </summary>
    ''' 
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

        '
        ' they're not pressing the button any more, so we indicate so and
        ' lose the capture.
        '
        Me.m_mousePress = False
        Me.Capture = False

        '
        ' if they released it in the right place, then toggle the IsExpanded
        ' state of the frame.
        '
        If e.Y >= (Me.Height - Me.m_captionHeight) And e.Y < Me.Height Then
            Me.m_buddyFrame.IsExpanded = Not Me.m_buddyFrame.IsExpanded
        End If

    End Sub ' OnMouseUp


    '=----------------------------------------------------------------------=
    ' OnMouseDown
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has pressed the mouse in our client area.  If it's in our
    '''   caption bar area, then we're interested in turning it into a click 
    '''   ( maybe ).
    ''' </summary>
    ''' 
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)

        '
        ' if it's in our caption bar area, remember this and take the capture.
        ' We'll also snare the focus here too.
        '
        If e.Y >= (Me.Height - Me.m_captionHeight) Then
            Me.m_mousePress = True
            Me.Capture = True
            Me.Focus()
        End If

    End Sub ' OnMouseDown








    '=----------------------------------------------------------------------=
    ' colorCollapseButtonBorder
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the color of the pen for the border of the collapse button
    '''   on the caption bar.
    ''' </summary>
    ''' 
    Private Function colorCollapseButtonBorder() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.NormalGroupHead.Normal)
            Return vsr.GetColor(VisualStyles.ColorProperty.BorderColorHint)
        Else
            Return Color.CadetBlue
        End If


    End Function ' colorCollapseButtonBorder


    '=----------------------------------------------------------------------=
    ' colorCollapseButtonChevrons
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the color of the pen for the chevrons in the collapse button 
    '''   on the caption bar.
    ''' </summary>
    ''' 
    Private Function colorCollapseButtonChevrons() As Color

        Return Me.m_buddyFrame.ForeColor

    End Function ' colorCollapseButtonChevrons


    '=----------------------------------------------------------------------=
    ' colorFocusRect
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''    Returns the color with which the focus rect should be drawn (pen).
    ''' </summary>
    ''' 
    Private Function colorFocusRect() As Color

        Return SystemColors.Highlight

    End Function ' colorFocusRect


    '=----------------------------------------------------------------------=
    ' systemHasRoundedCorners
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns a boolean value saying whether the current theme should use 
    '''   rounded corners for the caption bar.
    ''' </summary>
    ''' 
    Private Function systemHasRoundedCorners() As Boolean

        Return True

    End Function ' systemHasRoundedCorners



End Class ' CaptionBar





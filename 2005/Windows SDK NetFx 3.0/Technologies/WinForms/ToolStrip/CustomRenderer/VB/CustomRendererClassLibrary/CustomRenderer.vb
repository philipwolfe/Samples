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

Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing


'=--------------------------------------------------------------------------=
' CustomRenderer
'=--------------------------------------------------------------------------=
''' <summary>
'''   This is our sample to demonstrate implementing a Renderer for the 
'''   ToolStrips in Microsoft Visual Studio 2005
''' </summary>
''' 
<DefaultProperty("Color1")> _
Public Class CustomRenderer
    Inherits ToolStripRenderer

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                      Private types/data/stuff/etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    ''' 
    ''' <summary>
    '''   This is the set of all ToolStrips about which we're aware and
    '''   painting.
    ''' </summary>
    ''' 
    Private m_toolstrips As ArrayList

    ''' <summary>
    '''   This is the set of all ToolStripPanels about which we're aware and
    '''   painting.
    ''' </summary>
    ''' 
    Private m_ToolStripPanels As ArrayList

    ''' <summary>
    '''   This is the list of all individual ToolStripItems and derived types
    '''   about which we're aware and painting.  Note that this is only for
    '''   individual items who have had their renderer set to us -- items that
    '''   are part of ToolStrips and MenuStrips and StatusStrips (held above
    '''   in the m_toolStrips property) don't require separate storage.
    ''' </summary>
    ''' 
    Private m_toolstripitems As ArrayList

    '''
    '''  <summary>
    '''   We need this timer to know when to repaint and update the flowing
    '''   appearance of the backgrounds.
    ''' </summary>
    ''' 
    Private WithEvents m_timer As Timer

    '''
    ''' <summary>
    '''   Used for the DrawToolbarBorder property -- controls whether or not
    '''   we draw a single pixel border around ToolStrips. 
    ''' </summary>
    ''' 
    Private m_drawToolbarBorder As Boolean

    ''' 
    ''' <summary>
    '''   For the Color1 property -- this is the initial starting color of
    '''   the linear gradient painting.
    ''' </summary>
    ''' 
    Private m_color1 As Color

    ''' <summary>
    '''   For the Color2 property -- this is the initial ending color of the
    '''   linear gradient painting.  
    ''' </summary>
    ''' 
    Private m_color2 As Color

    '''
    '''  <summary>
    '''   This is the actual color that is being used for the left/top edge
    '''   of the linear gradient paint.  These change a few times every 
    '''   second, and we don't want to clobber the underlying Color1 value,
    '''   so we have separate values here.
    ''' </summary>
    ''' 
    Private m_currentc1 As Color

    '''
    '''  <summary>
    '''   This is the actual color that is being used for the right/bottom
    '''   edge of the linear gradient paint.  These change a few times every 
    '''   second, and we don't want to clobber the underlying Color1 value,
    '''   so we have separate values here.
    ''' </summary>
    ''' 
    Private m_currentc2 As Color

    '''
    ''' <summary>
    '''   This is the color to use for item borders.  It's just a heavily
    '''   scaled down (darkened) version of Color1.
    ''' </summary>
    ''' 
    Private m_itemBorderColor As Color

    ''' 
    ''' <summary>
    '''   This is the color we will use to draw arrows.  It is a heavily
    '''   scaled down (darkened) version of Color1.
    ''' </summary>
    ''' 
    Private m_arrowColor As Color

    ''' 
    ''' <summary>
    '''   When we get the first two colors (Color1 and Color2), we compute
    '''   the increments between their individual color components, and use
    '''   those increments to shift/flow between them over time.  This is the
    '''   Red component of that.
    ''' </summary>
    ''' 
    Private m_rinc As Short

    ''' 
    ''' <summary>
    '''   When we get the first two colors (Color1 and Color2), we compute
    '''   the increments between their individual color components, and use
    '''   those increments to shift/flow between them over time.  This is the
    '''   Green component of that.
    ''' </summary>
    ''' 
    Private m_ginc As Short

    ''' 
    ''' <summary>
    '''   When we get the first two colors (Color1 and Color2), we compute
    '''   the increments between their individual color components, and use
    '''   those increments to shift/flow between them over time.  This is the
    '''   Blue component of that.
    ''' </summary>
    ''' 
    Private m_binc As Short

    ''' 
    ''' <summary>
    '''   This is the number of increments we're going to use to flow between
    '''   the two colors.  This, multiplied by the TIMER_SPEED_MS variable,
    '''   gives the full amount of time it will take to shift completely 
    '''   from one color to the other.
    ''' </summary>
    ''' 
    Private Const NUM_INCREMENTS As Short = 30

    ''' 
    ''' <summary>
    '''   This is the current tick count between 0 and NUM_INCREMENTS.  We 
    '''   keep track of this to know when to reverse directions again.
    ''' </summary>
    ''' 
    Private m_currentTick As Integer

    ''' 
    ''' <summary>
    '''   This helps us remember if we're incrementing or decrementing our 
    '''   tick counter as we move through time.
    ''' </summary>
    ''' 
    Private m_positiveDirection As Boolean

    ''' 
    ''' <summary>
    '''   This is the number of ms between timer ticks.  This, multiplied by
    '''   NUM_INCREMENTS, gives the full amount of time it will take shift
    '''   or flow completely from one color to the other.
    ''' </summary>
    ''' 
    Private Const TIMER_SPEED_MS As Integer = 250






    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=
    '               Public Properties/Methods/Functions/etc.
    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=
    '=-----------------------------------------------------------------------=

    '=-----------------------------------------------------------------------=
    ' Constructor
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Iniitalizes a new instance of this class.  We do not, however, 
    '''   create the timer until we actually get some components to paint.
    ''' </summary>
    ''' 
    Public Sub New()
        MyBase.New()

        Me.m_color1 = SystemColors.ActiveCaption
        Me.m_color2 = scaleColorPct(SystemColors.InactiveCaption, 120)
        OnColorChanged()

        Me.m_drawToolbarBorder = True

        Me.m_toolstrips = New ArrayList
        Me.m_toolstripitems = New ArrayList
        Me.m_ToolStripPanels = New ArrayList

    End Sub ' New


    '=-----------------------------------------------------------------------=
    ' Dispose
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Cleans up our instance, including (and most importantly), shutting
    '''   off and deleting the timer.
    ''' </summary>
    ''' 
    ''' <param name="disposing">
    '''   Whether Win32 resources should be deleted as well
    ''' </param>
    ''' 
    Public Sub Dispose(ByVal disposing As Boolean)

        Me.m_timer.Stop()
        Me.m_timer = Nothing

        Me.m_toolstrips.Clear()
        Me.m_toolstripitems.Clear()
        Me.m_ToolStripPanels.Clear()

        Me.m_toolstrips = Nothing
        Me.m_toolstripitems = Nothing
        Me.m_ToolStripPanels = Nothing

    End Sub ' Dispose


    '=-----------------------------------------------------------------------=
    ' Color1
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   This is one of the two colors used in the linear gradient (blended)
    '''   painting for the backgrounds of the various items and strips.
    ''' </summary>
    ''' 
    ''' <value>
    '''   A System.Drawing.Color object with the color to use.
    ''' </value>
    ''' 
    Public Property Color1() As Color

        Get
            Return Me.m_color1
        End Get

        Set(ByVal value As Color)

            If Not value.Equals(Me.m_color1) Then
                Me.m_color1 = value
                OnColorChanged()
            End If

        End Set

    End Property ' Color1



    '=-----------------------------------------------------------------------=
    ' Color2
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   This is the second of the two colors used in the linear gradient 
    '''  (blended) painting for the backgrounds of the various items and
    '''   strips.
    ''' </summary>
    ''' 
    ''' <value>
    '''   A System.Drawing.Color object with the color to use.
    ''' </value>
    ''' 
    Public Property Color2() As Color

        Get
            Return Me.m_color2
        End Get

        Set(ByVal value As Color)

            If Not (value.Equals(Me.m_color2)) Then
                Me.m_color2 = value
                OnColorChanged()
            End If
        End Set

    End Property ' Color2


    '=-----------------------------------------------------------------------=
    ' DrawToolbarBorder
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Controls whether we'll draw a single pixel border around ToolStrips
    '''   or not.  Sometimes they add a nice touch to the appearance.
    ''' </summary>
    ''' 
    ''' <value>
    '''   A simple boolean instructing us whether to draw a border (True) or
    '''   not (False).
    ''' </value>
    ''' 
    Public Property DrawToolbarBorder() As Boolean
        Get
            Return Me.m_drawToolbarBorder
        End Get

        Set(ByVal value As Boolean)
            Me.m_drawToolbarBorder = value

        End Set

    End Property ' DrawToolbarBorder









    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                Non-Public Methods/Functions/etc...
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '=-----------------------------------------------------------------------=
    ' Initialize
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Tells us that we are now responsible for the painting of a given
    '''   ToolStrip component (and its sub-components).
    ''' </summary>
    ''' 
    ''' <param name="toolStrip">
    '''   The component to which we should be paying attention.
    ''' </param>
    ''' 
    Protected Overrides Sub Initialize(ByVal toolStrip As ToolStrip)

        If Not Me.m_toolstrips.Contains(toolStrip) Then
            Me.m_toolstrips.Add(toolStrip)
        End If
        postInitialize()

    End Sub ' Initialize


    '=-----------------------------------------------------------------------=
    ' InitializeContainer
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   We are now responsible for the painting of the given 
    '''   ToolStripPanel.
    ''' </summary>
    ''' 
    ''' <param name="ToolStripPanel">
    '''   The ToolStripPanel to which we should be paying attention.
    ''' </param>
    ''' 

    Protected Overrides Sub InitializePanel(ByVal toolStripPanel As System.Windows.Forms.ToolStripPanel)
        MyBase.InitializePanel(toolStripPanel)
        If Not Me.m_ToolStripPanels.Contains(ToolStripPanel) Then
            Me.m_ToolStripPanels.Add(ToolStripPanel)
        End If
        postInitialize()
    End Sub

    '=-----------------------------------------------------------------------=
    ' InitializeItem
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   We are now responsible for the painting of the given ToolStripItem.
    ''' </summary>
    ''' 
    ''' <param name="item">
    '''   The specified item.
    ''' </param>
    ''' 
    Protected Overrides Sub InitializeItem(ByVal item As ToolStripItem)

        If Not Me.m_toolstripitems.Contains(item) Then
            Me.m_toolstripitems.Add(item)
        End If
        postInitialize()

    End Sub ' InitializeItem




    '=-----------------------------------------------------------------------=
    ' OnRenderButtonBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the given button's background.  We also use this
    '''   routine to paint the backgrounds of a few other item types as well,
    '''   since they will all be so similar.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about which button to paint, which Graphics object to use,
    '''   etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderButtonBackground( _
                                     ByVal e As ToolStripItemRenderEventArgs)

        Dim lgm As LinearGradientMode
        Dim r As Rectangle

        ' 
        ' figure out the rectangle to paint.
        '
        If (TypeOf (e.Item) Is ToolStripButton) Then
            r = e.Item.ContentRectangle
        Else
            r = New Rectangle(1, 1, e.Item.Bounds.Width - 2, _
                              e.Item.Bounds.Height - 2)
        End If

        '
        ' if they left the color as the default value 
        ' (SystemColors.ControlLight), then we will choose the colors for
        ' them.  Otherwise, we will just paint the color they gave us.
        '
        If (e.Item.BackColor = SystemColors.ControlLight) _
           OrElse e.Item.Pressed _
           OrElse e.Item.Selected Then

            Dim c1, c2 As Color

            '
            ' handle various mouse states as well.
            '
            If (e.Item.Pressed) Then
                c1 = scaleColorPct(Me.m_color1, 80)
                c2 = scaleColorPct(Me.m_color2, 80)
            ElseIf (e.Item.Selected) Then
                c1 = scaleColorPct(Me.m_color1, 120)
                c2 = scaleColorPct(Me.m_color2, 120)
            Else
                c1 = Me.m_currentc1
                c2 = Me.m_currentc2
            End If

            '
            ' handle the toolstrip orientation as well
            '
            If e.ToolStrip.Orientation = Orientation.Vertical Then
                lgm = LinearGradientMode.Vertical
            Else
                lgm = LinearGradientMode.Horizontal
            End If

            '
            ' paint and dispose of the brush!
            '
            Using lgb As LinearGradientBrush = New LinearGradientBrush(r, _
                                                        c1, _
                                                        c2, _
                                                        lgm)
                e.Graphics.FillRectangle(lgb, r)
            End Using

        Else

            '
            ' just paint the color they want us to.
            '
            Dim c As Color
            c = e.Item.BackColor
            Using b As SolidBrush = New SolidBrush(c)
                e.Graphics.FillRectangle(b, r)
            End Using

        End If

        '
        ' finally, draw the bounding rect
        '
        Using p As Pen = New Pen(Me.m_itemBorderColor)
            e.Graphics.DrawRectangle(p, r)
        End Using

    End Sub ' OnRenderButtonBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderToolStripBorder
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   If we have been asked to draw the border (by the setting of the
    '''   DrawToolbarBorder), do so now.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which ToolStrip to paint, which
    '''   Graphics object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderToolStripBorder( _
                                        ByVal e As ToolStripRenderEventArgs)

        '
        ' are we being instructed to draw a border around the outside?
        '
        If (Me.m_drawToolbarBorder) Then
            Using p As Pen = New Pen(Me.m_itemBorderColor)


                Dim r As Rectangle
                r = New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
                e.Graphics.DrawRectangle(p, r)
            End Using
        End If

    End Sub ' OnRenderToolStripBorder


    '=-----------------------------------------------------------------------=
    ' OnRenderSeparator
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   We are being asked to paint a separator item.  
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderSeparator( _
                                ByVal e As ToolStripSeparatorRenderEventArgs)
        Dim pt1, pt2 As Point

        Using p As Pen = New Pen(Me.m_itemBorderColor)

            If e.ToolStrip.Orientation = Orientation.Vertical Then
                pt1 = New Point(0, e.Item.Height \ 2)
                pt2 = New Point(e.Item.Width, e.Item.Height \ 2)
            Else
                pt1 = New Point(e.Item.Width \ 2, 0)
                pt2 = New Point(e.Item.Width \ 2, e.Item.Height)
            End If

            e.Graphics.DrawLine(p, pt1, pt2)
        End Using

    End Sub ' OnRenderSeparator


    '=-----------------------------------------------------------------------=
    ' OnRenderDropDownButtonBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the background of a ToolStripDropDownButton.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderDropDownButtonBackground( _
                                ByVal e As ToolStripItemRenderEventArgs)

        OnRenderItemBackground(e)

    End Sub ' OnRenderDropDownButtonBackground



    '=-----------------------------------------------------------------------=
    ' OnRenderGrip
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to draw the grip at the edge of a ToolStrip.  We will just
    '''   draw a dark blended rect.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderGrip(ByVal e As ToolStripGripRenderEventArgs)

        Dim lgm As LinearGradientMode
        Dim r As Rectangle

        If e.GripDisplayStyle = ToolStripGripDisplayStyle.Horizontal Then
            lgm = LinearGradientMode.Vertical
            r = New Rectangle(e.GripBounds.Left + 2, e.GripBounds.Top, _
                              e.GripBounds.Width - 6, _
                              e.GripBounds.Height - 3)
        Else
            lgm = LinearGradientMode.Horizontal
            r = New Rectangle(e.GripBounds.Left, e.GripBounds.Top + 2, _
                              e.GripBounds.Width - 3, _
                              e.GripBounds.Height - 6)
        End If

        '
        ' create the gradient brush and fill the rectangle.
        '
        Using lgb As LinearGradientBrush = New LinearGradientBrush(r, _
                       scaleColorPct(Me.m_color1, 80), _
                       scaleColorPct(Me.m_color2, 80), _
                       lgm)

            e.Graphics.FillRectangle(lgb, r)
        End Using

        '
        ' now draw a nice dark border around it.
        '
        Using p As Pen = New Pen(Me.m_itemBorderColor)
            e.Graphics.DrawRectangle(p, r)
        End Using

    End Sub ' OnRenderGrip


    '=-----------------------------------------------------------------------=
    ' OnRenderToolStripBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to render the background of the entire strip.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderToolStripBackground( _
                                ByVal e As ToolStripRenderEventArgs)

        Dim lgm As LinearGradientMode
        Dim r As Rectangle

        r = New Rectangle(Point.Empty, e.ToolStrip.Size)

        If e.ToolStrip.Orientation = Orientation.Vertical Then
            lgm = LinearGradientMode.Vertical
        Else
            lgm = LinearGradientMode.Horizontal
        End If

        '
        ' create the gradient brush and draw.
        '
        Using lgb As LinearGradientBrush = New LinearGradientBrush(r, _
                                Me.m_currentc1, _
                                Me.m_currentc2, _
                                lgm)
            e.Graphics.FillRectangle(lgb, r)
        End Using

    End Sub ' OnRenderToolStripBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderItemBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the generic item's background.  We'll just use the
    '''   code we have for buttons, because it's the same, except for the 
    '''   border.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderItemBackground( _
                                    ByVal e As ToolStripItemRenderEventArgs)

        OnRenderButtonBackground(e)

    End Sub ' OnRenderItemBackground



    '=-----------------------------------------------------------------------=
    ' OnRenderArrow
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to draw an arrow.  hooray!
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderArrow( _
                                    ByVal e As ToolStripArrowRenderEventArgs)

        drawLittleArrow(e.Graphics, e.ArrowRectangle, e.Direction)

    End Sub ' OnRenderArrow


    '=-----------------------------------------------------------------------=
    ' OnRenderLabelBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to draw the background of a ToolStripLabel.  We will 
    '''   actually <em>not</em> do anything here, because we want to just use
    '''   the background that was already painting for the ToolStrip itself.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderLabelBackground( _
                                    ByVal e As ToolStripItemRenderEventArgs)
        '
        ' we actually won't do ANYTHING here -- by just leaving this blank,
        ' the label gets the default painting that occurs for the whole
        ' ToolStrip, which actually looks quite pleasing!
        '

    End Sub ' OnRenderLabelBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderMenuItemBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the background of an inidivdual menu item.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderMenuItemBackground( _
                                    ByVal e As ToolStripItemRenderEventArgs)

        OnRenderItemBackground(e)

    End Sub ' OnRenderMenuItemBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderToolStripPanelBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the client area of a ToolStripPanel.  We just 
    '''   fill this with a gradient blend as well.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderToolStripPanelBackground( _
                                ByVal e As ToolStripPanelRenderEventArgs)

        Dim lgm As LinearGradientMode
        Dim r As Rectangle

        r = New Rectangle(Point.Empty, e.ToolStripPanel.Size)

        '
        ' if the rafting container has no width or height, then we will do
        ' nothing here (which is just as well, because the LinearGradientBrush
        ' code will throw ...
        '
        If e.ToolStripPanel.Width = 0 OrElse e.ToolStripPanel.Height = 0 Then
            Return
        End If

        If e.ToolStripPanel.Dock = DockStyle.Left _
           OrElse e.ToolStripPanel.Dock = DockStyle.Right Then
            lgm = LinearGradientMode.Vertical
        Else
            lgm = LinearGradientMode.Horizontal
        End If

        Using lgb As LinearGradientBrush = New LinearGradientBrush(r, _
                                Me.m_currentc1, _
                                Me.m_currentc2, _
                                lgm)
            e.Graphics.FillRectangle(lgb, r)
        End Using

    End Sub ' OnRenderToolStripPanelBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderOverflowButtonBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   If a ToolStrip grows too large, an overflow button is created. This
    '''   gives us a chance to paint that item.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderOverflowButtonBackground( _
                                    ByVal e As ToolStripItemRenderEventArgs)

        Dim lgm As LinearGradientMode
        Dim c1, c2 As Color
        Dim r As Rectangle
        Dim d As ArrowDirection

        If e.ToolStrip.Orientation = Orientation.Vertical Then
            lgm = LinearGradientMode.Vertical
            r = New Rectangle(0, 0, _
                              e.Item.Bounds.Width - 2, _
                              e.Item.Bounds.Height - 2)
        Else
            lgm = LinearGradientMode.Horizontal
            r = New Rectangle(0, 0, _
                              e.Item.Bounds.Width - 2, _
                              e.Item.Bounds.Height - 2)
        End If

        '
        ' fill in the background.
        '
        If (e.Item.Pressed) Then
            c1 = scaleColorPct(Me.m_color1, 70)
            c2 = scaleColorPct(Me.m_color2, 70)
        ElseIf (e.Item.Selected) Then
            c1 = scaleColorPct(Me.m_color1, 120)
            c2 = scaleColorPct(Me.m_color2, 120)
        Else
            c1 = scaleColorPct(Me.m_color1, 90)
            c2 = scaleColorPct(Me.m_color2, 90)
        End If

        Using lgb As LinearGradientBrush = New LinearGradientBrush(r, c1, c2, lgm)
            e.Graphics.FillRectangle(lgb, r)
        End Using

        '
        ' now draw a border around it all
        '
        Using p As Pen = New Pen(Me.m_itemBorderColor)
            e.Graphics.DrawRectangle(p, r)
        End Using

        '
        ' finally, draw an arrow.
        '
        r = New Rectangle(Point.Empty, e.Item.Size)
        If e.ToolStrip.Orientation = Orientation.Horizontal Then
            d = ArrowDirection.Down
        Else
            d = ArrowDirection.Right
        End If

        drawLittleArrow(e.Graphics, r, d)

    End Sub ' OnRenderOverflowButtonBackground


    '=-----------------------------------------------------------------------=
    ' OnRenderSplitButtonBackground
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Asks us to paint the background of a button type called a 
    '''   ToolStripSplitButton.
    ''' </summary>
    ''' 
    ''' <param name="e">
    '''   Details about the request, including which item to draw, which 
    '''   Graphics Object to use, etc.
    ''' </param>
    ''' 
    Protected Overrides Sub OnRenderSplitButtonBackground( _
                                     ByVal e As ToolStripItemRenderEventArgs)

        Dim tssb As ToolStripSplitButton
        Dim r As Rectangle

        '
        ' draw a button background, since we want this to look like everybody
        ' else.
        '
        OnRenderButtonBackground(e)

        '
        ' and then figure out what splitter boundaries to draw.
        '
        tssb = CType(e.Item, ToolStripSplitButton)
        r = tssb.SplitterBounds

        Using p As Pen = New Pen(Me.m_itemBorderColor)
            e.Graphics.DrawLine(p, r.Left + r.Width \ 2, r.Top + 2, _
                                r.Left + r.Width \ 2, r.Bottom)
        End Using

        '
        ' finally, draw a little arrow.
        '
        drawLittleArrow(e.Graphics, tssb.DropDownButtonBounds, ArrowDirection.Down)

    End Sub ' OnRenderSplitButtonBackground


    '=-----------------------------------------------------------------------=
    ' m_timer_Tick
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Time OUT!  Time to change colors, refresh, and continue the
    '''   appearance of flowing or changing the colors...
    ''' </summary>
    ''' 
    Private Sub m_timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_timer.Tick

        Dim c1r, c1g, c1b As Byte
        Dim c2r, c2g, c2b As Byte

        '
        ' change directions if we've reached one of the two ends.
        '
        If (Me.m_positiveDirection = True _
            AndAlso Me.m_currentTick = NUM_INCREMENTS) Then

            Me.m_positiveDirection = False

            Me.m_rinc = -(Me.m_rinc)
            Me.m_ginc = -(Me.m_ginc)
            Me.m_binc = -(Me.m_binc)

        ElseIf (Me.m_positiveDirection = False _
                AndAlso Me.m_currentTick = 0) Then

            Me.m_positiveDirection = True

            Me.m_rinc = -(Me.m_rinc)
            Me.m_ginc = -(Me.m_ginc)
            Me.m_binc = -(Me.m_binc)

        End If

        '
        ' increment the counter in the appropriate direction.
        '
        If (Me.m_positiveDirection) Then
            Me.m_currentTick += 1
        Else
            Me.m_currentTick -= 1
        End If

        '
        ' update the colors with the increments.
        '
        c1r = valueInLimitsByte(Me.m_currentc1.R - Me.m_rinc, 0, 255)
        c1g = valueInLimitsByte(Me.m_currentc1.G - Me.m_ginc, 0, 255)
        c1b = valueInLimitsByte(Me.m_currentc1.B - Me.m_binc, 0, 255)
        c2r = valueInLimitsByte(Me.m_currentc2.R + Me.m_rinc, 0, 255)
        c2g = valueInLimitsByte(Me.m_currentc2.G + Me.m_ginc, 0, 255)
        c2b = valueInLimitsByte(Me.m_currentc2.B + Me.m_binc, 0, 255)

        Me.m_currentc1 = Color.FromArgb(255, c1r, c1g, c1b)
        Me.m_currentc2 = Color.FromArgb(255, c2r, c2g, c2b)


        '
        ' now go and tell all of our client items to repaint.
        '
        For Each ts As ToolStrip In Me.m_toolstrips
            ts.Invalidate(True)
        Next
        For Each rc As ToolStripPanel In Me.m_ToolStripPanels
            rc.Invalidate(True)
        Next
        For Each tsi As ToolStripItem In Me.m_toolstripitems
            tsi.Invalidate()
        Next

    End Sub ' m_timer_Tick



    '=-----------------------------------------------------------------------=
    ' computeIncrements
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Given our two colors and the number of increments we want between
    '''   them, this routine computes how much each component in the colors
    '''   will need to change each increment to flow into the other.
    ''' </summary>
    ''' 
    Private Sub computeIncrements()

        Me.m_rinc = (CShort(Me.m_color1.R) - CShort(Me.m_color2.R)) \ NUM_INCREMENTS
        Me.m_ginc = (CShort(Me.m_color1.G) - CShort(Me.m_color2.G)) \ NUM_INCREMENTS
        Me.m_binc = (CShort(Me.m_color1.B) - CShort(Me.m_color2.B)) \ NUM_INCREMENTS

    End Sub ' computeIncrements


    '=-----------------------------------------------------------------------=
    ' valueInLimitsByte
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Quick little routine that takes a short, and then makes sure that
    '''   it fits into a byte between lower and upper.  Values that are too
    '''   small or too large are just truncated.
    ''' </summary>
    ''' 
    ''' <param name="val">
    '''   The value to verify
    ''' </param>
    ''' 
    ''' <param name="lower">
    '''   The permissible lower value.
    ''' </param>
    ''' 
    ''' <param name="upper">
    '''   The maximum value.
    ''' </param>
    ''' 
    ''' <returns>
    '''   A Byte number between lower and upper (inclusive).
    ''' </returns>
    ''' 
    Private Function valueInLimitsByte(ByVal val As Integer, _
                                       ByVal lower As Byte, _
                                       ByVal upper As Byte) _
                                       As Byte
        If (val < lower) Then
            val = lower
        ElseIf (val > upper) Then
            val = upper
        End If

        Return CByte(val)

    End Function ' valueInLimitsByte



    '=-----------------------------------------------------------------------=
    ' scaleColorPct
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Takes a color, and scales its individual component values by a
    '''   given percentage.  A percentage of less than 100% causes it to
    '''   become darker while greater than 100% causes it to become lighter.
    ''' </summary>
    ''' 
    ''' <param name="c">
    '''   The color to scale.
    ''' </param>
    ''' 
    ''' <param name="pct">
    '''   The percentage to scale it by, specified as an actual numerical 
    '''   value between 0.0 and 100.0%.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The scaled color.
    ''' </returns>
    ''' 
    Private Function scaleColorPct(ByVal c As Color, ByVal pct As Integer) As Color

        Dim r, g, b As Byte
        Dim p As Double

        p = CDbl(pct) / 100D

        r = valueInLimitsByte(CInt(CDbl(c.R) * p), 0, 255)
        g = valueInLimitsByte(CInt(CDbl(c.G) * p), 0, 255)
        b = valueInLimitsByte(CInt(CDbl(c.B) * p), 0, 255)

        Return Color.FromArgb(c.A, r, g, b)

    End Function ' scaleColorPct


    '=-----------------------------------------------------------------------=
    ' postInitialize
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Makes sure that our timer is set up correctly and running.
    ''' </summary>
    ''' 
    Private Sub postInitialize()

        If (Me.m_timer Is Nothing) Then

            Me.m_timer = New Timer
            Me.m_currentTick = 1
            Me.m_positiveDirection = True
            Me.m_timer.Interval = TIMER_SPEED_MS
            Me.m_timer.Start()

        End If

    End Sub ' postInitialize


    '=-----------------------------------------------------------------------=
    ' OnColorChanged
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   One (or both) of our two primary colors has changed.   Figure out
    '''   the new increments and recompute any other colors we need.
    ''' </summary>
    ''' 
    ''' <remarks></remarks>
    ''' 
    Private Sub OnColorChanged()

        computeIncrements()
        Me.m_currentc1 = Me.m_color1
        Me.m_currentc2 = Me.m_color2

        Me.m_itemBorderColor = scaleColorPct(Me.m_color1, 20)
        Me.m_arrowColor = scaleColorPct(Me.m_color1, 10)

    End Sub ' OnColorChanged


    '=-----------------------------------------------------------------------=
    ' drawLittleArrow
    '=-----------------------------------------------------------------------=
    ''' <summary>
    '''   Draws a little arrow in the appropriate direction.  It's not 
    '''   terribly fancy, anti-aliased, or anything other than a simple little
    '''   arrow.
    ''' </summary>
    ''' 
    ''' <param name="g">
    '''   Graphics object to use.
    ''' </param>
    ''' 
    ''' <param name="bounds">
    '''   Bounding rectangle in which to draw it, preferably centered.
    ''' </param>
    ''' 
    ''' <param name="dir">
    '''   The direction in which to draw it.
    ''' </param>
    ''' 
    Private Sub drawLittleArrow(ByVal g As Graphics, _
                                ByVal bounds As Rectangle, _
                                ByVal dir As ArrowDirection)

        Dim left, aleft, top, atop As Integer

        aleft = CInt(((bounds.Width + 5) / 2)) - 5
        atop = CInt(((bounds.Height + 5) / 2)) - 5
        left = bounds.Left
        top = bounds.Top

        Select Case dir
            Case ArrowDirection.Down
                Using p As Pen = New Pen(Me.m_arrowColor)

                    For x As Integer = 0 To 2
                        g.DrawLine(p, left + aleft + x, top + atop + x, _
                                   left + aleft + (5 - x), top + atop + x)
                    Next

                End Using

            Case ArrowDirection.Right
                Using p As Pen = New Pen(Me.m_arrowColor)

                    For x As Integer = 0 To 2
                        g.DrawLine(p, left + aleft + x, top + atop + x, _
                                   left + aleft + x, top + atop + (5 - x))
                    Next

                End Using
        End Select

    End Sub ' drawLittleArrow


End Class ' CustomRenderer

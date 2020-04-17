'=====================================================================
'  File:      /vb
'
'  Summary:   These are the frames or "pages" that fit within the 
'             TaskPane control.  
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



'=--------------------------------------------------------------------------=
' TaskFrame
'=--------------------------------------------------------------------------=
''' <summary>
'''   These are the indidivudal frames that show up in the TaskPane control. 
'''   they have a caption bar across the top, which, while closely associated
'''   with this TaskFrame (The properties on this class modify said caption
'''   bar), is not actually part of this control.
''' </summary> 
'''
<LocalisableDescription("TaskFrame"), _
 DefaultProperty("Text"), _
 ToolboxItem(False), _
 DesignTimeVisible(False), _
 DefaultEvent("Click"), _
 Designer(GetType(Design.TaskFrameDesigner))> _
Public Class TaskFrame
    Inherits Panel



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables and the likes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '''  
    ''' <summary>
    '''   Indicates if we're in the process of actually doing some collapsing
    '''   or expanding with this frame.
    ''' </summary>
    ''' 
    Friend Enum ActiveState

        Collapsing
        Collapsed
        Expanding
        Expanded

    End Enum ' ActiveState


    '''
    ''' <summary>
    '''   What's going on with this frame.
    ''' </summary>
    '''  
    Friend m_activeState As ActiveState

    '''  
    ''' <summary>
    '''   a reference to the CaptionBar tied to us.
    ''' </summary>
    '''  
    Friend m_captionBar As CaptionBar

    '''  
    ''' <summary>
    '''   How much we're being shurnk or expanded at a time and what the original
    '''   size was ....
    ''' </summary>
    '''  
    Friend m_changeDelta As Integer
    Friend m_originalSize As Integer

    '''  
    ''' <summary>
    '''   The way the caption bar is painted.
    ''' </summary>
    '''  
    Private m_captionBlend As BlendFill

    '''  
    ''' <summary>
    '''   Do we show our CollapseButton?
    ''' </summary>
    '''  
    Private m_collapseButtonVisible As Boolean

    '''  
    ''' <summary>
    '''   This is the corner image we will display in the captionbar of this
    '''   control.
    ''' </summary>
    '''  
    Private m_image As Image

    '''  
    ''' <summary>
    '''   This is the 'mask' color for the images.
    ''' </summary>
    '''  
    Private m_imageTransparentColor As Color

    '''  
    ''' <summary>
    '''   Are we hidden because the user changed the Visible property, or
    '''   because IsExpanded is False?
    ''' </summary>
    '''  
    Private m_invisibleFromCollapse As Boolean




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                    Public Methods/Properties/etc.
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''    Intializes a new instance of our class
    ''' </summary>
    '''  
    Public Sub New()
        MyBase.New()

        Me.Font = New Font(MyBase.Font, FontStyle.Bold)
        Me.ForeColor = colorDefaultForeground()
        Me.BackColor = colorDefaultBackground()
        Me.CaptionBlend = New BlendFill(BlendStyle.Horizontal, _
                                        colorCaptionBlendStart(), _
                                        colorCaptionBlendFinish())

        '
        ' Set up some reasonable defaults here for the properties.
        '   
        Me.m_collapseButtonVisible = True

        '
        ' Make sure we don't bother sending this to the HWND, since it
        ' will never see/use it.
        '
        setStyle(ControlStyles.CacheText, True)


        '
        ' Setting up our initial collapse/expand state.
        '
        Me.m_activeState = ActiveState.Expanded
        Me.m_invisibleFromCollapse = False

        '
        ' misc goo
        '
        Me.m_imageTransparentColor = Color.Transparent

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Image
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The image we will display in the caption bar area.  The image is
    '''   masked against the ImageTransparentColor on our parent TaskPane
    '''    control.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.Image"), _
     Category("Appearance"), _
     DefaultValue(GetType(Image), Nothing), _
     Localizable(True)> _
    Public Property Image() As Image

        Get
            Return Me.m_image
        End Get

        '
        ' set the new image and tell the caption bar to refresh
        '
        Set(ByVal in_newImage As Image)

            Dim tp As TaskPane
            Dim b As Bitmap

            If Not in_newImage Is Me.m_image Then
                Me.m_image = in_newImage
                b = CType(Me.m_image, Bitmap)
                If Not b Is Nothing Then
                    tp = CType(Me.Parent, TaskPane)
                    If Not tp Is Nothing Then
                        b.MakeTransparent(Me.ImageTransparentColor)
                    End If
                End If
                If Not Me.m_captionBar Is Nothing Then
                    Me.m_captionBar.recomputeSizes()
                    Me.m_captionBar.Refresh()
                End If
            End If

        End Set

    End Property ' Image


    '=----------------------------------------------------------------------=
    ' ImageTransparentColor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is the color that the individual TaskFrames will use to mask the
    '''   background of their Image properties for transparency.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.ImageTransparentColor"), _
     Category("Behavior"), _
     DefaultValue(GetType(Color), "Transparent"), _
     Localizable(True)> _
    Public Property ImageTransparentColor() As Color

        Get
            Return Me.m_imageTransparentColor
        End Get

        '
        ' set the new one, and then force a complete update of all the
        ' child frames in case they are using any of these ...
        '
        Set(ByVal in_newImageTransparentColor As Color)
            If Not in_newImageTransparentColor.Equals(Me.m_imageTransparentColor) Then
                Me.m_imageTransparentColor = in_newImageTransparentColor
                Me.Refresh()
            End If
        End Set

    End Property ' ImageTransparentColor


    '=----------------------------------------------------------------------=
    ' CollapseButtonVisible
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Indicates whether or not we should show a button on our caption bar
    '''   which will allow users to collapse or uncollapse us.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.CollapseButtonVisible"), _
     Category("Behavior"), _
     DefaultValue(True), _
     Localizable(True)> _
    Public Property CollapseButtonVisible() As Boolean

        Get
            Return Me.m_collapseButtonVisible
        End Get

        '
        ' set the new value and tell our caption bar to refresh
        '
        Set(ByVal in_newCollapseButtonVisible As Boolean)

            Me.m_collapseButtonVisible = in_newCollapseButtonVisible
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.Refresh()
            End If

        End Set

    End Property ' CollapseButtonVisible


    '=----------------------------------------------------------------------=
    ' IsExpanded
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''  Controls and/or indicates whether or not we are expanded at this point
    '''   in time. Changing the value will cause the frame to collapse or 
    '''   uncollapse itself.
    ''' </summary> 
    ''' 
    <LocalisableDescription("TaskFrame.IsExpanded"), _
     Category("Behavior"), DefaultValue(True), _
     Localizable(True)> _
    Public Property IsExpanded() As Boolean

        Get

            '
            ' Please note that partially expanded frames will return
            ' True to this property.
            '
            If Me.m_activeState = ActiveState.Collapsed Then
                Return False
            Else
                Return True
            End If

        End Get

        '
        ' go ahead and start the process to collapse or expand the frame
        ' if appropriate.
        '
        Set(ByVal in_newIsExpanded As Boolean)

            Dim tp As TaskPane
            tp = CType(Me.Parent, TaskPane)

            '
            ' if the whole frame is hidden (indicated by our caption bar
            ' not being visible) or we have no HWND yet, then just force
            ' the full visible/invisible now.
            '
            If Me.m_captionBar Is Nothing _
               OrElse Not Me.m_captionBar.Visible _
               OrElse Not Me.m_captionBar.IsHandleCreated Then

                If in_newIsExpanded = True Then

                    '
                    ' If we're not already expanded, go and do this now.
                    '
                    If Not Me.m_activeState = ActiveState.Expanded Then
                        Me.Height = Me.m_originalSize
                    End If

                    Me.m_activeState = ActiveState.Expanded
                    Me.showWithoutCaptionBar()

                Else

                    '
                    ' If we're not already collapsed, just go and do this
                    ' now
                    '
                    If Me.m_activeState = ActiveState.Expanded Then
                        Me.m_originalSize = Me.Height
                    End If

                    Me.m_activeState = ActiveState.Collapsed
                    Me.hideWithoutCaptionBar()

                End If

                If Not tp Is Nothing Then tp.layoutAllFrames()

            Else

                '
                ' Okay, the Frame is supposed to be visible (as indicated
                ' by the caption bar being visible) and we have an HWND,
                ' so go and start the slide open/closed.
                '
                If Me.m_activeState = ActiveState.Collapsed _
                   OrElse Me.m_activeState = ActiveState.Collapsing Then

                    '
                    ' We're already collapsed/ing, so we only have to do
                    ' something if they're asking us to expand ...
                    '
                    If in_newIsExpanded = True Then
                        tp.expandCollapseFrame(Me, False)
                    End If

                Else

                    ' 
                    ' We're expanded/ing, so only do something if they're
                    ' asking us to Collapse
                    '
                    If in_newIsExpanded = False Then
                        tp.expandCollapseFrame(Me, True)
                    End If

                End If

                '
                ' Repaint the caption bar!
                '
                Me.m_captionBar.Refresh()

            End If

        End Set

    End Property ' IsExpanded


    '=----------------------------------------------------------------------=
    ' CaptionBlend
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This controls how the background is drawn.  There's a cool little 
    '''   designer for it and everything.  Wooohoo!
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.CaptionBlend"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Property CaptionBlend() As BlendFill

        Get
            Return Me.m_captionBlend
        End Get

        '
        ' set the new value, refresh, and fire a change event.
        '
        Set(ByVal in_newCaptionBlend As BlendFill)
            Me.m_captionBlend = in_newCaptionBlend
            If Not Me.m_captionBar Is Nothing Then Me.m_captionBar.Refresh()
        End Set

    End Property ' CaptionBlend


    '=----------------------------------------------------------------------=
    ' Size
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Okay, this is a bit strange BUT ... there is a problem by which,
    '''   when we are set to collapsed, we still need to know when our
    '''   size is being changed so that we can set the "m_originalSize"
    '''   property to the proper height.  This permits us to restore the
    '''   control to the proper height,  even if the Size property is set
    '''   when we are not expanded (i.e. collapsed)
    '''  
    '''   Now, the problem is that the Size property isn't marked as
    '''   Overridable, which means we have to Shadow it, which is MOSTLY
    '''   fine, unless people start manipulating this control as a
    '''   Control, in which case  polymorphism breaks.
    '''  
    '''   this control.  To get around it, you can either be sure to always
    '''   set the size of TaskFrames only, or just make sure to set the size
    '''   when the cotnrol is visible.
    ''' </summary> 
    ''' 
    <LocalisableDescription("TaskFrame.Size"), _
     Category("Layout"), _
     Localizable(True)> _
    Public Shadows Property Size() As Size

        Get
            Return MyBase.Size
        End Get

        Set(ByVal value As Size)

            If Me.m_activeState = ActiveState.Collapsed Then
                Me.m_originalSize = value.Height
            End If

            MyBase.Size = value

        End Set
    End Property ' Size


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The text property on this control is very much visible.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.Text"), _
     Category("Appearance"), _
     Browsable(True), EditorBrowsable(EditorBrowsableState.Always), _
     Localizable(True)> _
    Public Overrides Property Text() As String

        Get
            Return MyBase.Text
        End Get

        Set(ByVal in_newText As String)
            MyBase.Text = in_newText
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.Refresh()
            End If
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' Font
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Overridden from our parent, because we need to tell our caption bar 
    '''   when the Font changes ...
    ''' </summary>
    '''  
    <LocalisableDescription("TaskFrame.Font"), _
     Category("Appearance"), _
     Localizable(True)> _
    Public Shadows Property Font() As Font

        Get
            Return MyBase.Font
        End Get

        '
        ' set the new value and tell our caption bar about it.
        '
        Set(ByVal in_newFont As Font)

            MyBase.Font = in_newFont
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.setFontInternal(in_newFont)
            End If

        End Set

    End Property ' Font


    '=----------------------------------------------------------------------=
    ' ForeColor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We override this from our parent to make sure that we repaint
    '''   properly when this is changed.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.ForeColor"), _
     Category("Appearance")> _
    Public Overrides Property ForeColor() As Color
        Get
            Return MyBase.ForeColor
        End Get

        Set(ByVal value As Color)
            MyBase.ForeColor = value
            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.Refresh()
            End If
        End Set

    End Property ' ForeColor



    '=----------------------------------------------------------------------=
    ' Anchor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This property doesn't make sense for us as all sizing is controlled by
    '''   the parent TaskPane
    ''' </summary>
    ''' 
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Anchor() As AnchorStyles

        Get
            Return MyBase.Anchor
        End Get

        Set(ByVal newAnchor As AnchorStyles)
            MyBase.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        End Set

    End Property ' Anchor


    '=----------------------------------------------------------------------=
    ' Dock
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This property doesn't make sense for us as all sizing is
    '''   controlled by the parent TaskPane
    ''' </summary>
    ''' 
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Dock() As DockStyle

        Get
            Return MyBase.Dock
        End Get

        Set(ByVal newDock As DockStyle)
            MyBase.Dock = newDock
        End Set

    End Property ' Dock


    '=----------------------------------------------------------------------=
    ' DockPadding
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This property doesn't make sense for us as all sizing is
    '''   controlled by the parent TaskPane
    ''' </summary>
    '''  
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows ReadOnly Property DockPadding() As DockPaddingEdges

        Get
            Return MyBase.DockPadding
        End Get

    End Property ' DockPadding


    '=----------------------------------------------------------------------=
    ' Visible
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   When we're made visible or invisible, we need to be sure to go and
    '''   hide and/or reshow our associated caption bar control.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskFrame.Visible"), _
     Category("Behavior"), DefaultValue(True)> _
    Public Shadows Property Visible() As Boolean

        Get
            If Not Me.m_captionBar Is Nothing Then
                Return Me.m_captionBar.Visible
            Else
                Return False
            End If
        End Get

        '
        ' If they're giving us a different value, and it's not at design
        ' time, then set the new value.
        ' 
        Set(ByVal in_newVisible As Boolean)

            Try
                If Not Me.Parent Is Nothing Then
                    Me.Parent.SuspendLayout()
                End If

                '
                ' 2. Now go and show/hide us, depending on whether we're
                '    already hidden, and why.
                '
                If Not Me.m_invisibleFromCollapse Then
                    MyBase.Visible = in_newVisible
                End If

                '
                ' 1. Make sure our associated caption bar gets shown/hidden
                '
                Me.m_captionBar.setVisibleInternal(in_newVisible)

            Finally
                Me.Parent.ResumeLayout()
            End Try

        End Set

    End Property ' Visible


    '=----------------------------------------------------------------------=
    ' Enabled
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   When we're made Enabled or disabled, we need to be sure to go and
    '''   enable and/or disable our buddy caption bar
    ''' </summary>
    '''  
    <LocalisableDescription("TaskFrame.Enabled"), _
     Category("Behavior"), DefaultValue(True)> _
    Public Shadows Property Enabled() As Boolean

        Get
            Return MyBase.Enabled
        End Get

        '
        ' If they're giving us a different value, then set it
        '
        Set(ByVal in_newEnabled As Boolean)

            If Not Me.m_captionBar Is Nothing Then
                Me.m_captionBar.setEnabledInternal(in_newEnabled)
            End If
            MyBase.Enabled = in_newEnabled

        End Set

    End Property ' Enabled


    '=----------------------------------------------------------------------=
    ' ImeMode
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   TaskFrames don't have input, so this isn't terribly useful.
    ''' </summary>
    '''  
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Shadows Property ImeMode() As ImeMode

        Get
            Return MyBase.ImeMode
        End Get
        Set(ByVal Value As ImeMode)
            MyBase.ImeMode = Value
        End Set

    End Property ' ImeMode


    '=----------------------------------------------------------------------=
    ' RightToLeft
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Make sure we update our caption bar appropriately.
    ''' </summary>
    ''' 
    Public Overrides Property RightToLeft() As System.Windows.Forms.RightToLeft

        Get
            Return MyBase.RightToLeft
        End Get

        Set(ByVal Value As System.Windows.Forms.RightToLeft)
            MyBase.RightToLeft = Value
            If Not Me.m_captionBar Is Nothing Then Me.m_captionBar.Refresh()
        End Set

    End Property ' RightToLeft









    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                Private/Protected/Friend Subs/Functions
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' hideWithoutCaptionBar
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Hides this TaskFrame without hiding our associated caption bar.  That's
    '''   rather important, since every time we are collapsed, we are hidden to
    '''   keep us out of the tab order, etc ...
    ''' </summary>
    '''  
    '''  
    Protected Friend Sub hideWithoutCaptionBar()

        Me.m_invisibleFromCollapse = True
        MyBase.Visible = False

    End Sub ' hideWithoutCaptionBar


    '=----------------------------------------------------------------------=
    ' showWithoutCaptionBar
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Shows this TaskFrame without affecting our associated caption bar.  
    '''   That's rather important, since every time we are collapsed, we are
    '''   hidden to keep us out of the tab order, etc ...
    ''' </summary>
    '''  
    '''  
    Protected Friend Sub showWithoutCaptionBar()

        Me.m_invisibleFromCollapse = False
        MyBase.Visible = True

    End Sub ' showWithoutCaptionBar


    '=----------------------------------------------------------------------=
    ' getReallyVisible
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns whether or not this actual TaskFrame control is visible, 
    '''   regardless of the reasons it may not be.  Should only be needed by the
    '''   layout code in the parent TaskPane itself.
    ''' </summary>
    '''  
    Friend Function getReallyVisible() As Boolean

        Return MyBase.Visible

    End Function ' getReallyVisible


    '=----------------------------------------------------------------------=
    ' OnResize
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Whenever the control is resized, we need to know about the change in
    '''   height so we can set our original size to reflect this ...
    ''' </summary>
    '''  
    Protected Overrides Sub OnResize(ByVal eventargs As System.EventArgs)

        If Me.m_activeState = ActiveState.Expanded Then
            Me.m_originalSize = Me.Height
        End If

        MyBase.OnResize(eventargs)

    End Sub ' OnResize



    '=----------------------------------------------------------------------=
    ' colorDefaultBackground
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This returns the default background color for our TaskFrame.
    ''' </summary>
    '''  
    Private Function colorDefaultBackground() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.NormalGroupBackground.Normal)

            Return vsr.GetColor(VisualStyles.ColorProperty.GradientColor1)
        Else
            Return Color.CadetBlue
        End If


    End Function ' colorDefaultBackground


    '=----------------------------------------------------------------------=
    ' colorDefaultForeground
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This returns the default background color for our TaskFrame.
    ''' </summary>
    '''  
    Private Function colorDefaultForeground() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.NormalGroupHead.Normal)

            Return vsr.GetColor(VisualStyles.ColorProperty.EdgeDarkShadowColor)
        Else
            Return Color.CadetBlue
        End If

    End Function ' colorDefaultBackground


    '=----------------------------------------------------------------------=
    ' colorCaptionBlendStart
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the start color to be used to blend the caption bar.
    ''' </summary>
    '''  
    Private Function colorCaptionBlendStart() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.HeaderBackground.Normal)

            Return vsr.GetColor(VisualStyles.ColorProperty.EdgeHighlightColor)
        Else
            Return Color.White
        End If


    End Function ' colorCaptionBlendStart


    '=----------------------------------------------------------------------=
    ' colorCaptionBlendFinish
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''    Returns the finish color to be used to blend the caption bar.
    ''' </summary>
    '''  
    Private Function colorCaptionBlendFinish() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.NormalGroupHead.Normal)

            Return vsr.GetColor(VisualStyles.ColorProperty.GradientColor1)
        Else
            Return Color.CadetBlue
        End If


    End Function ' colorCaptionBlendFinish


End Class ' TaskFrame




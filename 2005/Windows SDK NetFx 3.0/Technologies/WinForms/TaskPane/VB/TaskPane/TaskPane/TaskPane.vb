'=====================================================================
'  File:      TaskPane.vb
'
'  Summary:   A component for .NET Managed code applications that mimics
'             the funcionality of the Task Pane in the Windows XP 
'             Explorer.  The pane is composed of one or more frames.
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
' TaskPane
'=--------------------------------------------------------------------------=
''' <summary>
'''   This is the base container class that users add to their forms in
'''   Visual Studio.  Using various Design Time functionality, users can then
'''   go and child frames (in the TaskFrame class) to it, and customise them
'''   as they wish.
''' </summary>
'''
<DefaultProperty("TaskFrames"), DefaultEvent("FrameCollapsed"), _
 Designer(GetType(Design.TaskPaneDesigner))> _
Public Class TaskPane
    Inherits ContainerControl

    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables and the likes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '''
    '''  <summary>
    '''  Amount of space to allow between each Frame.
    ''' </summary>
    '''
    Private Const FRAME_PADDING As Integer = 12

    '''
    '''  <summary>
    '''    How many ms between collapse/expand changes and the total time we
    '''    want the operation to last...
    ''' </summary>
    ''' 
    Private Const TIMER_DELTA As Integer = 50
    Private Const TOTAL_CHANGE_TIME As Integer = 250   ' half a second


    ''' 
    ''' <summary>
    '''   This is the style of corners we will paint for these controls.
    ''' </summary>
    ''' 
    Private m_cornerStyle As TaskFrameCornerStyle

    '''
    '''  <summary>
    '''   This is user configurable
    ''' </summary>
    '''
    Private m_padding As Integer


    '
    ''' <summary>
    '''   This is our collection of TaskFrame objects.  For each frame,
    '''   we also associate a CaptionBar class, which contains the image, 
    '''   caption, and collapse button (if applicable)
    ''' </summary>
    ''' 
    Private m_frameCollection As TaskFrameCollection

    '''
    '''  <summary>
    '''   This timer is used for expanding/collapsing of frames.
    ''' </summary>
    '''
    Private WithEvents m_collapseTimer As Timer



    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Intitializes a new instance of our TaskPane class.  We don't have 
    '''   any frames by default, and they need to be added one by one.
    ''' </summary>
    '''
    Public Sub New()

        ' set up some reasonable default values for the various properties
        ' we've got.
        '
        Me.m_cornerStyle = TaskFrameCornerStyle.SystemDefault
        Me.BackColor = getBackColorFromThemes()

        Me.m_frameCollection = New TaskFrameCollection(Me)

        '
        ' Set up a decent default width, and we'll dock to the left
        '
        Me.Width = 150
        Me.Dock = DockStyle.Left

        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        '
        ' finally, set up the collapse/expand timer we'll use to do a lot
        ' of the work.
        '
        Me.m_collapseTimer = New Timer
        Me.m_collapseTimer.Interval = TIMER_DELTA

        Me.AutoScroll = True
        Me.HScroll = False

        Me.m_padding = FRAME_PADDING

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' CornerStyle
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Controls how the corners are drawn for the caption bars at the top
    '''   of the individual child frames.  By default, they track what the
    '''   current Operating System style is using, but users can force this
    '''   to other  values if they so wish.
    ''' </summary>
    ''' 
    ''' <value>
    '''   The style of corners that should be drawn on the caption bar of the
    '''   individual TaskFrames.
    ''' </value>
    '''
    <LocalisableDescription("TaskPane.CornerStyle"), _
     Category("Appearance"), _
     DefaultValue(TaskFrameCornerStyle.SystemDefault), _
     Localizable(True)> _
    Public Property CornerStyle() As TaskFrameCornerStyle

        Get
            Return Me.m_cornerStyle
        End Get

        '
        ' set the new value and refresh the control to reflect the change.
        '
        Set(ByVal in_newCornerStyle As TaskFrameCornerStyle)

            If in_newCornerStyle < 0 OrElse in_newCornerStyle > 2 Then
                Throw New ArgumentOutOfRangeException("Value", TaskPaneMain.GetResourceManager().GetString("excTaskPaneCornerStyleRange"))
            End If

            If Not in_newCornerStyle = Me.m_cornerStyle Then
                Me.m_cornerStyle = in_newCornerStyle
                Me.Refresh()
            End If
        End Set

    End Property ' CornerStyle


    '=----------------------------------------------------------------------=
    ' Padding
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Specifies just how much space should be left between individual Task
    '''   Frames and between frames and the edges of the TaskPane.
    ''' </summary>
    ''' 
    ''' <value>
    '''   How many pixels should be left between the individual TaskFrames and
    '''   between them and the edge of the parent TaskPane.
    ''' </value>
    ''' 
    <LocalisableDescription("TaskPane.Padding"), _
     Category("Appearance"), _
     DefaultValue(FRAME_PADDING), _
     Localizable(True)> _
    Public Shadows Property Padding() As Integer
        Get
            Return Me.m_padding
        End Get

        '
        ' set the new value if appropriate, and relayout the container.
        '
        Set(ByVal in_newPadding As Integer)
            If in_newPadding < 0 Then
                Throw New ArgumentOutOfRangeException("Value")
            End If

            If Not in_newPadding = Me.m_padding Then
                Me.m_padding = in_newPadding
                layoutAllFrames()
            End If
        End Set

    End Property  ' Padding


    '=----------------------------------------------------------------------=
    ' TaskFrames
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is our collection of TaskFrame child panels.  This collection
    '''   object also manages the CaptionBars for us.
    ''' </summary>
    '''
    ''' <value>
    '''   The collection of TaskFrame objects.
    ''' </value>
    '''
    <LocalisableDescription("TaskPane.TaskFrames"), _
     Category("Misc"), _
     DefaultValue(False), _
     Editor("Design.TaskFrameCollectionEditor", GetType(System.Drawing.Design.UITypeEditor)), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
     MergableProperty(False)> _
    Public ReadOnly Property TaskFrames() As TaskFrameCollection

        Get
            Return Me.m_frameCollection
        End Get

    End Property ' TaskFrames


    '=----------------------------------------------------------------------=
    ' Text
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The text property isn't visible on this control, so we'll go and
    '''   hide it now.
    ''' </summary>
    ''' 
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property Text() As String

        Get
            Return MyBase.Text
        End Get

        Set(ByVal newText As String)
            MyBase.Text = newText
        End Set

    End Property ' Text


    '=----------------------------------------------------------------------=
    ' ExpandAll
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Causes all of our child frames to begin expanding. 
    ''' </summary>
    '''
    <LocalisableDescription("TaskPane.ExpandAll")> _
    Public Sub ExpandAll()

        Dim tf As TaskFrame

        '
        ' Loop through our collection of TaskFrames and then expand each
        ' one at a time ...
        '
        For i As Integer = 0 To Me.TaskFrames.Count - 1

            '
            ' The collection only surfaces Objects, not strongly cast types.  
            ' This means we have to cast ourselves.
            '
            tf = CType(Me.TaskFrames(i), TaskFrame)
            tf.IsExpanded = True
        Next

    End Sub ' ExpandAll


    '=----------------------------------------------------------------------=
    ' CollapseAll
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Causes all of our child frames to begin collapsing.
    ''' </summary>
    '''
    <LocalisableDescription("TaskPane.CollapseAll")> _
    Public Sub CollapseAll()

        Dim tf As TaskFrame

        '
        ' Loop through our collection of TaskFrames and then collapse each
        ' one at a time ...
        '
        For i As Integer = 0 To Me.TaskFrames.Count - 1

            '
            ' The collection only surfaces Objects, not strongly cast types.  
            ' This means we have to cast ourselves.
            '
            tf = CType(Me.TaskFrames(i), TaskFrame)
            tf.IsExpanded = False
        Next

    End Sub ' CollapseAll


    '=----------------------------------------------------------------------=
    ' Refresh
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Redraw and update all our components.
    ''' </summary>
    '''
    Public Overrides Sub Refresh()

        '
        ' Refresh EVERYBODY!!!
        '
        For x As Integer = 0 To Me.Controls.Count - 1
            Me.Controls(x).Refresh()
        Next

        MyBase.Refresh()

    End Sub ' Refresh











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
    ' CreateHandle
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Make sure we're all laid out properly.
    ''' </summary>
    '''
    Protected Overrides Sub CreateHandle()

        MyBase.CreateHandle()

        layoutAllFrames()

    End Sub ' CreateHandle


    '=----------------------------------------------------------------------=
    ' CreateControlsInstance
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Creates the ControlCollection object with which we will work.  Very
    '''   exciting!  Our version will be a bit special in that it will only 
    '''   accept TaskFrames to be added, and will also sneak in the CaptionBar
    '''   for the given frame while it's at it.
    ''' </summary>
    '''
    ''' <returns>
    '''   The ControlCollection for this container (TaskPane)
    ''' </returns>
    ''' 
    Protected Overrides Function CreateControlsInstance() As Control.ControlCollection

        Return New TaskPane.ControlCollection(Me)

    End Function ' CreateControlsInstance


    '=----------------------------------------------------------------------=
    ' OnFrameCollapsed
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The user has collapsed the given frame.  We'll fire an event to this
    '''   effect now.
    ''' </summary>
    ''' 
    ''' <param name="frame">
    '''   The frame that collapsed.
    ''' </param>
    ''' 
    Protected Overridable Sub OnFrameCollapsed(ByVal frame As TaskFrame)

        RaiseEvent FrameCollapsed(Me, New TaskPaneEventArgs(frame))

    End Sub ' OnFrameCollapsed


    '=----------------------------------------------------------------------=
    ' OnFrameExpanded
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The given frame has expanded. We'll fire an event to this effect
    '''   now.
    ''' </summary>
    ''' 
    ''' <param name="frame">
    '''   The frame that expanded.
    ''' </param>
    ''' 
    Protected Sub OnFrameExpanded(ByVal frame As TaskFrame)

        RaiseEvent FrameExpanded(Me, New TaskPaneEventArgs(frame))

    End Sub ' OnFrameExpanded


    '=----------------------------------------------------------------------=
    ' OnFrameCollapsing
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The specified frame is about to collapse.  Fire an event to this
    '''   effect to give people the opportunity to prevent it.
    ''' </summary>
    ''' 
    ''' <param name="frame">
    '''   The frame being collapsed.
    ''' </param>
    ''' 
    ''' <returns>
    '''   A boolean value indicating whether or not to cancel the collapse.
    '''   True means cancel the collapse.
    ''' </returns>
    ''' 
    Protected Function OnFrameCollapsing(ByVal frame As TaskFrame) As Boolean

        Dim ce As TaskPaneCancelEventArgs
        ce = New TaskPaneCancelEventArgs(frame)

        RaiseEvent FrameCollapsing(Me, ce)

        Return ce.Cancel

    End Function ' OnFrameCollapsing


    '=----------------------------------------------------------------------=
    ' OnFrameExpanding
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The specified frame is about to expand.  Go and fire an event to 
    '''   this effect now, giving people the opportunity to cancel it.
    ''' </summary>
    ''' 
    ''' <param name="frame">
    '''   The frame being expanded.
    ''' </param>
    ''' 
    ''' <returns>
    '''   A boolean indicating whether or not the expand should be prevented.
    '''   True means yes.
    ''' </returns>
    '''
    Protected Function OnFrameExpanding(ByVal frame As TaskFrame) As Boolean

        Dim ce As TaskPaneCancelEventArgs
        ce = New TaskPaneCancelEventArgs(frame)

        RaiseEvent FrameExpanding(Me, ce)

        Return ce.Cancel

    End Function ' OnFrameExpanding


    '=----------------------------------------------------------------------=
    ' OnLayout
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We're being asked to lay out all of our components.
    ''' </summary>
    ''' 
    ''' <param name="levent">
    '''   Details about the event.
    ''' </param>
    ''' 
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)

        layoutAllFrames()
        MyBase.OnLayout(levent)

    End Sub ' OnLayout



    '=----------------------------------------------------------------------=
    ' layoutAllFrames
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Given that we now have a bunch of TaskFrames and associated
    '''   CaptionBar controls, go and lay them out now, including doing
    '''   things like making sure our scroll height is correct, etc ...
    ''' </summary>
    ''' 
    Friend Sub layoutAllFrames()
        Static b As Boolean
        Dim h, w As Integer

        '
        ' if we don't have any frames, then this is easy.
        '
        If Me.m_frameCollection Is Nothing Then Return

        '
        ' If we're not created, then this is also easy.
        '
        If Not Me.IsHandleCreated Then Return

        If Not b = False Then Exit Sub
        b = True

        '
        ' okay, we should have a window handle now, which means we can start
        ' figuring out sizes, etc ...
        ' 

        '
        ' 1. Compute the height
        '
        h = computeTotalHeight()

        '
        ' 2. readjust our scrollbars and all tha to reflect this.
        '
        If h > Me.Height Then

            Dim i As Integer
            Me.AutoScrollMinSize = New Size(0, h)

            '
            ' Our width has to have some room for the scrollbar ...
            '
            i = SystemInformation.VerticalScrollBarWidth
            w = Me.Width - i - 1

        Else

            Me.AutoScrollMinSize = New Size(0, 0)
            '            Me.AutoScrollMinSize = New Size(0, Me.Height)
            w = Me.Width

        End If

        '
        ' 3. Now go and adjust all the controls' sizes correctly.
        '
        positionAllFrames(w)

        b = False
    End Sub ' layoutAllFrames


    '=----------------------------------------------------------------------=
    ' computeTotalHeight
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Figures out how tall our TaskPane control needs to be, given the
    '''   number of frames and caption bars we have, as well as appropriate
    '''   padding.
    ''' </summary>
    ''' 
    ''' <returns>
    '''   The total height of the control, so we can figure out if we need
    '''   scrollbars to be visible, etc.
    ''' </returns>
    ''' 
    Private Function computeTotalHeight() As Integer

        Dim tf As TaskFrame
        Dim height As Integer

        '
        ' first, we have to compute the total height of everything, to figure
        ' out if we need to go and set up a scrollbar.
        '
        height = 0

        For i As Integer = 0 To Me.m_frameCollection.Count - 1

            tf = Me.m_frameCollection(i)

            If tf.m_captionBar.Visible Then

                '
                ' every frame adds:
                '
                ' 1. fixed buffer space at the top
                ' 2. the height of the caption bar
                ' 3. the height of the actual frame itself, provided it's
                '    not collapsed.
                '
                height += Me.m_padding
                height += tf.m_captionBar.Height
                If Not tf.IsExpanded = False Then
                    height += tf.Height
                End If

            End If
        Next

        '
        ' finally, add some height for a buffer at the bottom and return
        '
        height += Me.m_padding
        Return height

    End Function ' computeTotalHeight


    '=----------------------------------------------------------------------=
    ' positionAllFrames
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Given that we've figured out our height, and now know our width, we
    '''   now need to go and move all the frames and caption bars to be in the
    '''   correct place.
    ''' </summary>
    ''' 
    ''' <param name="in_width">
    '''   How wide our control is.
    ''' </param>
    '''
    Private Sub positionAllFrames(ByVal in_width As Integer)

        Dim tf As TaskFrame
        Dim realWidth As Integer
        Dim top As Integer
        Dim left As Integer

        '
        ' set up the base width and height
        '
        realWidth = in_width - (2 * Me.m_padding)
        If realWidth < 1 Then
            realWidth = 10
        End If
        top = Me.m_padding

        '
        ' Make sure we show at least SOMETHING if the padding is ridiculously
        ' huge.
        '
        If Me.m_padding > (Me.Width / 2) - 5 Then
            left = CInt((Me.Width / 2) - 5)
        Else
            left = Me.m_padding
        End If

        '
        ' for each item, go and position it appropriately.
        '
        For i As Integer = 0 To Me.m_frameCollection.Count - 1

            Dim hwnd As IntPtr

            tf = Me.m_frameCollection(i)

            '
            ' Make sure that the handle has been created for the 
            ' TaskFrame.
            '
            hwnd = tf.Handle
            If tf.m_captionBar.Visible Then

                '
                ' caption bar
                '
                tf.m_captionBar.Top = top + Me.AutoScrollPosition.Y

                tf.m_captionBar.Left = Me.m_padding
                tf.m_captionBar.Width = realWidth
                top += tf.m_captionBar.Height

            Else
                System.Diagnostics.Debug.Assert(Not tf.Visible, "How can I have an invisible CaptionBar but visible Frame ????")
            End If

            If tf.getReallyVisible() = True Then

                '
                ' frame.
                '
                tf.Top = top + Me.AutoScrollPosition.Y
                tf.Left = Me.m_padding
                tf.Width = realWidth
                top += tf.Height

                tf.Refresh()
            End If

            If tf.m_captionBar.Visible Then
                top += Me.m_padding
            End If
        Next

    End Sub ' positiionAllFrames



    '=----------------------------------------------------------------------=
    ' expandCollapseFrame
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Contains the actual logic to go and expand or collapse the given
    '''   TaskFrame.  To do this from code, you should just set 
    ''' 
    '''   myTaskPane1.IsExpanded = either True or False.
    ''' 
    '''   Please note that there should be nothing here preventing controls
    '''   from having their IsExpanded property changed WHILE they are
    '''   actively collapsing or expanding.  We should simply be able to deal
    '''   with this.
    ''' </summary>
    '''
    ''' <param name="in_frame">
    '''   The frame being expanded or collapsed.
    ''' </param>
    ''' 
    ''' <param name="in_collapse">
    '''   Whether to Collapse (True) or Expand it (False)
    ''' </param>
    ''' 
    Friend Sub expandCollapseFrame(ByVal in_frame As TaskFrame, ByVal in_collapse As Boolean)
        '
        ' If the pane is already collapsed, then this is pretty easy.  
        ' Otherwise, given them the chance to cancel the happening!
        '
        If in_collapse Then
            If in_frame.m_activeState = TaskFrame.ActiveState.Collapsing Then Return
            If Me.OnFrameCollapsing(in_frame) = True Then Return
        Else
            If in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then Return
            If Me.OnFrameExpanding(in_frame) = True Then Return
        End If

        '
        ' Now, suspend the layout on it if we're collapsing it, so any child 
        ' Controls don't freak out that they're being moved around.
        '
        If in_collapse = True Then
            in_frame.SuspendLayout()
        Else
            '
            ' if we're going to expand it, make sure it's visible again.
            '
            in_frame.Height = 0
            in_frame.showWithoutCaptionBar()
        End If

        '
        ' Next, tell the control how much we're going to change it by each
        ' tick, and then start sliding it up to height zero or the original
        ' size.  With the changeDelta, we're targeting a TOTAL_CHANGE_TIME
        ' length collapse.
        '
        If in_collapse = True _
           AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Collapsing _
           AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then

            in_frame.m_changeDelta = CInt(in_frame.Height / (TOTAL_CHANGE_TIME / TIMER_DELTA))
            in_frame.m_originalSize = in_frame.Height

        ElseIf in_collapse = False _
               AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Collapsing _
               AndAlso Not in_frame.m_activeState = TaskFrame.ActiveState.Expanding Then

            in_frame.m_changeDelta = CInt(in_frame.m_originalSize / (TOTAL_CHANGE_TIME / TIMER_DELTA))

        End If

        If in_collapse = True Then
            in_frame.m_activeState = TaskFrame.ActiveState.Collapsing
        Else
            in_frame.m_activeState = TaskFrame.ActiveState.Expanding
        End If

        '
        ' start the timer doing it's thang.
        '
        If Not Me.m_collapseTimer.Enabled Then
            Me.m_collapseTimer.Start()
        End If

    End Sub ' expandCollapsePane


    '=----------------------------------------------------------------------=
    ' m_collapseTimer_Tick
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is the timer that goes along and expands/collapses the various
    '''   taskframes ... very exciting.
    ''' </summary>
    ''' 
    ''' <param name="sender">
    '''   From whence cometh the event
    ''' </param>
    ''' 
    ''' <param name="e">
    '''   EventArgs.Empty
    ''' </param>
    ''' 
    Private Sub m_collapseTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_collapseTimer.Tick

        Dim activelyChangingCount As Integer
        Dim tf As TaskFrame

        activelyChangingCount = 0

        '
        ' for each frame that is expanding or collapsing, go and change its
        ' state just a bit this time ...
        '
        For i As Integer = 0 To Me.m_frameCollection.Count() - 1

            tf = Me.m_frameCollection(i)

            '
            ' what's our current state?
            '
            Select Case tf.m_activeState

                Case TaskFrame.ActiveState.Collapsing

                    tf.Height = tf.Height - tf.m_changeDelta

                    '
                    ' did we completely collapse that dude? if so,
                    ' set some state and fire the event!
                    '
                    If tf.Height <= 0 Then

                        '
                        ' Height is zero, and hide it so that children
                        ' aren't included the z-order any more.
                        '
                        tf.Height = 0
                        tf.hideWithoutCaptionBar()
                        tf.m_activeState = TaskFrame.ActiveState.Collapsed
                        layoutAllFrames()

                        OnFrameCollapsed(tf)
                        tf.m_captionBar.Refresh()
                    Else
                        activelyChangingCount += 1
                    End If


                Case TaskFrame.ActiveState.Expanding

                    tf.Height += tf.m_changeDelta

                    '
                    ' did we completely expand the frame?  if so,
                    ' set some state and fire the event!
                    '
                    If tf.Height >= tf.m_originalSize Then

                        '
                        ' Set it back to its original size, and then
                        ' relayout the container
                        '
                        tf.Height = tf.m_originalSize
                        tf.m_activeState = TaskFrame.ActiveState.Expanded
                        layoutAllFrames()

                        '
                        ' Fire the event and repaint everything
                        '
                        OnFrameExpanded(tf)
                        tf.m_captionBar.Refresh()

                        '
                        ' finally, don't forget to tell it that it can
                        ' reposition controls again.
                        '
                        tf.Refresh()
                        tf.ResumeLayout()
                    Else
                        activelyChangingCount += 1
                    End If
            End Select
        Next

        '
        ' If there are no controls actively changing state, then go and
        ' shut down the timer, so we don't waste any time here ...
        '
        If activelyChangingCount = 0 Then
            Me.m_collapseTimer.Stop()
        End If

    End Sub ' m_collapsibleTimer_Tick


    '=----------------------------------------------------------------------=
    ' GetCompleteRectForFrame
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the rect bounding both a frame as well as its associated 
    '''   captionbar.
    ''' </summary>
    ''' 
    ''' <param name="in_frame">
    '''   The frame whose bounding rectangle we wish to compute.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The computed bounding rectangle (CaptionBar included).
    ''' </returns>
    ''' 
    Friend Function GetCompletRectForFrame(ByVal in_frame As TaskFrame) As Rectangle

        Dim pt As Point
        Dim sz As Size

        System.Diagnostics.Debug.Assert(Not in_frame Is Nothing)
        pt = in_frame.m_captionBar.Location()

        sz = New Size
        sz.Width = in_frame.Width
        sz.Height = in_frame.Bottom - in_frame.m_captionBar.Top

        Return New Rectangle(pt, sz)

    End Function ' GetCompleteRectForFrame



    '=----------------------------------------------------------------------=
    ' getBackColorFromThemes
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the BackColor for this control, attempting to use the 
    '''   theming engines as much as possible.
    ''' </summary>
    ''' 
    ''' <returns>
    '''   The background color to use for this control.
    ''' </returns>
    ''' 
    Private Function getBackColorFromThemes() As Color

        If VisualStyles.VisualStyleRenderer.IsSupported Then
            Dim vsr As VisualStyles.VisualStyleRenderer
            vsr = New VisualStyles.VisualStyleRenderer(VisualStyles.VisualStyleElement.ExplorerBar.NormalGroupBackground.Normal)

            Return vsr.GetColor(VisualStyles.ColorProperty.GradientColor2)
        Else
            Return Color.Beige
        End If

    End Function ' getBackgroundColorFromThemes










    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                                Events
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' FrameCollapsed
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The given frame has been collapsed, either by the user or in code.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskPane.FrameCollapsed"), _
     Category("Behavior")> _
    Public Event FrameCollapsed(ByVal sender As Object, ByVal e As TaskPaneEventArgs)

    '=----------------------------------------------------------------------=
    ' FrameCollapsing
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The given frame is about to be collapsed, either by the user or via
    '''   code.  Programmers can cancel this collapse here.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskPane.FrameCollapsing"), _
     Category("Behavior")> _
    Public Event FrameCollapsing(ByVal sender As Object, ByVal ce As TaskPaneCancelEventArgs)


    '=----------------------------------------------------------------------=
    ' FrameExpanded
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The given frame has been expanded, either by the user or via code.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskPane.FrameExpanded"), _
     Category("Behavior")> _
    Public Event FrameExpanded(ByVal sender As Object, ByVal e As TaskPaneEventArgs)

    '=----------------------------------------------------------------------=
    ' FrameExpanding
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The given frame is about to be expanded, either by the user or via
    '''   code.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskPane.FrameExpanding"), _
     Category("Behavior")> _
    Public Event FrameExpanding(ByVal sender As Object, ByVal ce As TaskPaneCancelEventArgs)







    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                           Nested Classes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' ControlCollection
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   All of the pages in the TaskFrame control are in a collection of
    '''   TaskFrame objects.  However. we also need to implement the 
    '''   ControlCollection off the Control class to make sure that people
    '''   can add new frames via either that or the TaskFrames collection.
    '''   Also, we nee to be able to inject our CaptionBar controls, which
    '''   has to happen via the ControlCollection.
    ''' </summary>
    ''' 
    Public Shadows Class ControlCollection
        Inherits Control.ControlCollection

        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '             Private Member variables, enums, consts
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=


        ''' 
        ''' <summary>
        '''   Our Parent TaskPane
        ''' </summary>
        ''' 
        Private m_parent As TaskPane

        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '             Public Methods/Properties/Functions, etc 
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=
        '=------------------------------------------------------------------=



        '=------------------------------------------------------------------=
        ' Constructor
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Initializes a new instance of this collection with the given
        '''   parent.
        ''' </summary>
        ''' 
        ''' <param name="in_parent">
        '''   The TaskPane in which we are operating.
        ''' </param>
        ''' 
        Public Sub New(ByVal in_parent As TaskPane)

            MyBase.New(in_parent)
            Me.m_parent = in_parent

        End Sub ' ControlCollection.New


        '=------------------------------------------------------------------=
        ' Add
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Adds the given control to our list of Sub controls.  It had
        '''   BETTER be a TaskFrame.  In this case, we need to go and create
        '''   the appropriate CaptionBar for it, and add it as well ...
        ''' </summary>
        ''' 
        ''' <param name="in_control">
        '''   Control to add.
        ''' </param>
        ''' 
        Public Overrides Sub Add(ByVal in_control As Control)

            Dim container As IContainer
            Dim cb As CaptionBar
            Dim tf As TaskFrame
            Dim site As ISite

            '
            ' Double check the arg type first ...
            '
            If Not TypeOf (in_control) Is TaskFrame _
               And Not TypeOf (in_control) Is CaptionBar Then

                Throw New ArgumentException(String.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_control.GetType().ToString()))
            End If


            If Me.Contains(in_control) Then Return

            '
            ' Go and create the CaptionBar for this frame ...
            '
            tf = CType(in_control, TaskFrame)
            cb = New CaptionBar(tf)
            tf.m_captionBar = cb
            cb.setVisibleInternal(True)

            '
            ' Now, add the caption bar to our list of controls.
            '
            MyBase.Add(cb)
            '
            ' And now add the actual frame to our list of controls.
            '
            MyBase.Add(tf)

            '
            ' Next, site the controls if at all necessary.
            '
            site = Me.m_parent.Site
            If Not site Is Nothing Then

                '
                ' Site the TaskFrame here, as controls need to be
                ' sited in order to have code generated for them at
                ' design time.
                ' Please note this means we DON'T want to site the
                ' CaptionBars ...
                '
                If tf.Site Is Nothing Then
                    container = site.Container
                    container.Add(tf)
                End If

            End If

            '
            ' Finally, add the frame to our parent's collection of 
            ' frames, and then tell it to re-layout everything. 
            '
            Me.m_parent.TaskFrames.addFrameInternal(tf)
            Me.m_parent.layoutAllFrames()

        End Sub ' ControlCollection.Add


        '=------------------------------------------------------------------=
        ' Remove
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Removes the given TaskFrame from our list of controls, as well
        '''   as the associated CaptionBar control.
        ''' </summary>
        ''' 
        ''' <param name="in_control">
        '''   The control to remove from our collection.
        ''' </param>
        ''' 
        Public Overrides Sub Remove(ByVal in_control As Control)

            Dim tf As TaskFrame

            If Not TypeOf (in_control) Is TaskFrame Then Return

            If Not Me.Contains(in_control) Then Return

            '
            ' remove this Frame and its CaptionBar
            '
            tf = CType(in_control, TaskFrame)
            MyBase.Remove(tf.m_captionBar)
            MyBase.Remove(tf)

            '
            ' Remove it from the other collection the TaskPane maintains.
            '
            Me.m_parent.TaskFrames.removeFrameInternal(tf)

            '
            ' Finally, tell the parent Pane to layout everything again.
            '
            Me.m_parent.layoutAllFrames()

        End Sub ' ControlCollection.Remove


        '=------------------------------------------------------------------=
        ' Clear
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Removes all the items in this control collection.
        ''' </summary>
        ''' 
        Public Overrides Sub Clear()

            '
            ' For each TaskFrame in the control, go and remove it 
            ' now.  Removing the individual TaskFrames will go and
            ' remove the CaptionBars as well !!
            '
            For x As Integer = 0 To Me.m_parent.m_frameCollection.Count - 1
                Me.Remove(Me.m_parent.m_frameCollection(0))
            Next

            '
            ' Finally, go and clear out the frame collection too.  This keeps
            ' everybody nice and in sync with each other.
            '
            Me.m_parent.m_frameCollection.clearInternal()

        End Sub ' ControlCollection.Clear


        '=------------------------------------------------------------------=
        ' AddRange
        '=------------------------------------------------------------------=
        ''' <summary>
        '''   Adds a range of controls to our collection. 
        ''' </summary>
        ''' 
        ''' <param name="in_array">
        '''   Array of controls to add.
        ''' </param>
        ''' 
        Public Overrides Sub AddRange(ByVal in_array() As Control)

            Dim tf As TaskFrame

            '
            ' Is it really easy?
            '
            If in_array Is Nothing Then Return
            If in_array.GetLength(0) = 0 Then Return

            '
            ' Now, for each item, go and make sure it's a TaskFrame, and
            ' then go and add if it is.
            '
            For x As Integer = 0 To in_array.GetLength(0) - 1

                tf = CType(in_array(x), TaskFrame)
                If tf Is Nothing Then
                    Throw New ArgumentException(String.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_array(x).GetType().ToString()))
                End If

                Me.Add(tf)

            Next

        End Sub ' ControlCollection.AddRange


    End Class ' ControlCollection


End Class ' TaskPane






'=--------------------------------------------------------------------------=
' TaskFrameCollection
'=--------------------------------------------------------------------------=
''' <summary>
'''   All of the pages in the TaskFrame control are in a collection of
'''   TaskFrame objects
''' </summary>
''' 
Public Class TaskFrameCollection
    Implements IList


    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    ' Private member variables and the likes
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=

    '''
    ''' <summary>
    '''   This is our actual list of pages and how many we've got.
    ''' </summary>
    ''' 
    Private m_frames() As TaskFrame
    Private m_cFrames As Integer

    ''' 
    ''' <summary>
    '''   Our parent TaskPane control.
    ''' </summary>
    ''' 
    Private m_parent As TaskPane





    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '                     Public Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   We need to know who our parent is, and then go and set up some
    '''   array space for the frames.  Please note that this constructor is
    '''   declared as "Friend" so that only we can create them and not end
    '''   users.
    ''' </summary>
    ''' 
    ''' <param name="in_parent">
    '''   The parent TaskPane in which we are operating.
    ''' </param>
    ''' 
    Friend Sub New(ByVal in_parent As TaskPane)

        Me.m_parent = in_parent

        System.Diagnostics.Debug.Assert(Not in_parent Is Nothing)

        '
        ' create a base space to hold the frames.  we'll grow it as
        ' necessary
        '
        Me.m_frames = New TaskFrame(3) {}
        Me.m_cFrames = 0

    End Sub ' TaskFrameCollection.New


    '=----------------------------------------------------------------------=
    ' CopyTo                                                     ICollection]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Copy from our collection into the given dest array
    ''' </summary>
    ''' 
    ''' <param name="in_dest">
    '''   The destination array into which to copy.
    ''' </param>
    ''' 
    ''' <param name="in_index">
    '''   The starting offset from which copying should begin.
    ''' </param>
    ''' 
    Public Sub CopyTo(ByVal in_dest As System.Array, ByVal in_index As Integer) Implements System.Collections.ICollection.CopyTo

        Dim frames As TaskFrame()

        frames = CType(in_dest, TaskFrame())

        If Me.m_cFrames <= in_index Then
            Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
        End If

        For i As Integer = in_index To Me.m_cFrames - 1
            frames(i) = Me.m_frames(i)
        Next

    End Sub ' CopyTo


    '=----------------------------------------------------------------------=
    ' Count                                                      ICollection]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   How many do we have so far?
    ''' </summary>
    ''' 
    ''' <value>
    '''   A count of items in our collection.
    ''' </value>
    ''' 
    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return Me.m_cFrames
        End Get
    End Property ' Count


    '=----------------------------------------------------------------------=
    ' IsSynchronized                                             ICollection]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Are we thread-safe?  No, we are not.
    ''' </summary>
    ''' 
    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property ' IsSynchronized


    '=----------------------------------------------------------------------=
    ' SyncRoot                                                   ICollection]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Object with which to synchronize for threading.  We are not thread-
    '''   safe, so this should be ignored.
    ''' </summary>
    ''' 
    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property ' SyncRoot


    '=----------------------------------------------------------------------=
    ' GetEnumerator                                              ICollection]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns an enumerator for the list of our TaskFrame controls
    ''' </summary>
    ''' 
    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

        Dim pages() As TaskFrame

        '
        ' If there's nothing to enumerate return nothing.
        '
        If (Me.m_frames Is Nothing) OrElse Me.m_cFrames = 0 Then
            pages = New TaskFrame() {}
            Return pages.GetEnumerator()
        End If

        '
        ' we have to copy these over since we could have empty slots in our
        ' array of pages that we're not using.
        '
        pages = New TaskFrame(Me.m_cFrames - 1) {}
        For i As Integer = 0 To Me.m_cFrames - 1
            pages(i) = Me.m_frames(i)
        Next
        Return pages.GetEnumerator()

    End Function ' GetEnumerator

    '=----------------------------------------------------------------------=
    ' Add
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is a strongly typed version of the Add method that only takes
    '''  TaskFrames ...
    ''' </summary>
    ''' 
    ''' <param name="in_newFrame">
    '''   Adds the given frame to the collection.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The index at which the item was added.
    ''' </returns>
    ''' 
    Public Function Add(ByVal in_newFrame As TaskFrame) As Integer

        '
        ' Arg Checking
        '
        If in_newFrame Is Nothing Then
            Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If

        '
        ' Please see the comments at the top of this file.  Basically, 
        ' because people don't HAVE to use this collectin to add/remove
        ' items, we initiate all adding and removing of this collection
        ' off the Controls collection on the parent TaskPane.
        '
        Me.m_parent.Controls.Add(in_newFrame)
        Return IndexOf(in_newFrame)

    End Function ' Add (strongly typed)


    '=----------------------------------------------------------------------=
    ' Add                                                             [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Adds a new frame to the end of the list.  This is the IList version
    '''   of this function and is NOT strongly typed for TaskFrames
    ''' </summary>
    ''' 
    ''' <param name="in_newFrame">
    '''   The frame to add.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The index into which it was inserted.
    ''' </returns>
    ''' 
    Public Function Add(ByVal in_newFrame As Object) As Integer Implements System.Collections.IList.Add

        Dim tf As TaskFrame

        '
        ' Arg Checking
        '
        If in_newFrame Is Nothing Then
            Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If
        If Not TypeOf (in_newFrame) Is TaskFrame Then
            Throw New ArgumentException(String.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_newFrame.GetType().ToString()))
        End If

        '
        ' Get in the correct format
        '
        tf = CType(in_newFrame, TaskFrame)

        '
        ' Pass the buck
        '
        Return Me.Add(tf)

    End Function ' Add (IList)


    '=----------------------------------------------------------------------=
    ' Clear                                                           [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Removes all the frames from this control
    ''' </summary>
    ''' 
    Public Sub Clear() Implements System.Collections.IList.Clear

        If Me.m_frames Is Nothing Then Return

        '
        ' First clear out our control collection.  It's vital to do this,
        ' as it keys off us for the list of controls ...
        '
        Me.m_parent.Controls.Clear()

    End Sub ' Clear (IList)


    '=----------------------------------------------------------------------=
    ' Contains                                                        [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Is the given frame one of ours?
    ''' </summary>
    ''' 
    ''' <param name="in_amIFamily">
    '''   Is this one of our frames?
    ''' </param>
    ''' 
    ''' <returns>
    '''   True == yes, False == nope.
    ''' </returns>
    ''' 
    Public Function Contains(ByVal in_amIFamily As Object) As Boolean Implements System.Collections.IList.Contains

        Return Not (IndexOf(in_amIFamily) = -1)

    End Function ' Contains (IList)


    '=----------------------------------------------------------------------=
    ' IndexOf                                                         [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the integer (zero-based) index of the item in our list, or
    '''   returns -1 if we don't have it as a member.
    ''' </summary>
    ''' 
    ''' <param name="in_findMyIndex">
    '''   The frame whose index in our collection we wish to find.
    ''' </param>
    ''' 
    ''' <returns>
    '''   The zero-based integer index of this item in our collection of 
    '''   TaskFrames.
    ''' </returns>
    ''' 
    Public Function IndexOf(ByVal in_findMyIndex As Object) As Integer Implements System.Collections.IList.IndexOf

        For i As Integer = 0 To Me.m_cFrames - 1
            If Me.m_frames(i) Is in_findMyIndex Then
                Return i
            End If
        Next

        Return -1

    End Function ' IndexOf (IList)


    '=----------------------------------------------------------------------=
    ' Insert                                                          [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Inserts the given Frame at the given index.
    ''' </summary>
    ''' 
    ''' <param name="in_index">
    '''   Index at which to insert the given Frame.
    ''' </param>
    ''' 
    ''' <param name="in_newPage">
    '''   The frame to insert into our collection.
    ''' </param>
    ''' 
    Public Sub Insert(ByVal in_index As Integer, ByVal in_newPage As Object) Implements System.Collections.IList.Insert

        Throw New NotSupportedException

    End Sub ' Insert


    '=----------------------------------------------------------------------=
    ' IsFixedSize                                                     [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Are we a fixed size (nope).
    ''' </summary>
    ''' 
    ''' <value>
    '''   False (no, we are not a fixed size).
    ''' </value>
    ''' 
    Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
        Get
            Return False
        End Get
    End Property ' IsFixedSize


    '=----------------------------------------------------------------------=
    ' IsReadOnly                                                      [IList]
    '=----------------------------------------------------------------------=
    ' Are we read-only ?
    ''' <summary>
    '''   Are we read-only ? (nope)
    ''' </summary>
    ''' 
    ''' <value>
    '''   False.  We are not read-only.
    ''' </value>
    ''' 
    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
        Get
            Return False
        End Get
    End Property  ' IsReadOnly


    '=----------------------------------------------------------------------=
    ' Item
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is a strongly typed version of the Item() method that is used
    '''   by indexers and array references, etc ...  This is preferred to the
    '''   IList version, which only supports Object.    '
    ''' </summary>
    ''' 
    ''' <param name="in_index">
    '''   The index at which we'd like to find a TaskFrame.
    ''' </param>
    ''' 
    ''' <value>
    '''   The TaskFrame at the given index.
    ''' </value>
    ''' 
    ''' <remarks>
    '''   We do not support the Set() method on this because we do not yet
    '''   support arbitrary item insertion/replacement (this is also true
    '''   for other controls such as the TabControl, etc).  We may.
    ''' </remarks>
    ''' 
    Default Public Property Item(ByVal in_index As Integer) As TaskFrame

        Get
            ' 
            ' arg checking
            '
            If in_index < 0 Or in_index >= Me.m_cFrames Then
                Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
            End If

            Return Me.m_frames(in_index)

        End Get

        Set(ByVal in_newFrame As TaskFrame)

            Throw New NotSupportedException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"))

        End Set

    End Property ' Item

    '=----------------------------------------------------------------------=
    ' IListItem                                                       [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Returns the TaskFrame object at the given index.  This is the IList
    '''   version of this method that is NOT strongly typed to TaskFrame
    '''   (blech).
    ''' </summary>
    ''' 
    ''' <param name="in_index">
    '''   Index at which we want to find a TaskFrame.
    ''' </param>
    ''' 
    ''' <value>
    '''   The TaskFrame at the given index.
    ''' </value>
    ''' 
    Public Property IListItem(ByVal in_index As Integer) As Object Implements System.Collections.IList.Item

        Get
            ' 
            ' arg checking
            '
            If in_index < 0 Or in_index >= Me.m_cFrames Then
                Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
            End If

            Return Me.m_frames(in_index)

        End Get

        Set(ByVal in_replaceThisItem As Object)

            Throw New NotSupportedException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"))

        End Set

    End Property ' IListItem


    '=----------------------------------------------------------------------=
    ' Remove
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This is an overloaded version of the Remove method that goes and
    '''   removes only those objects that are of type TaskFrame.
    ''' </summary>
    ''' 
    ''' <param name="in_removeMe">
    '''   TaskFrame to remove.
    ''' </param>
    ''' 
    Public Sub Remove(ByVal in_removeMe As TaskFrame)

        If in_removeMe Is Nothing Then
            Throw New ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()")
        End If

        '
        ' Tell our parent's controls collection to remove this.
        ' Part of that operation will be to call removeFrameInternal
        ' on THIS class, which will remove it from our collection ...
        '
        Me.m_parent.Controls.Remove(in_removeMe)

    End Sub ' Remove (strongly typed)

    '=----------------------------------------------------------------------=
    ' Remove                                                          [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Removes the given frame from our collection of frames.
    ''' </summary>
    ''' 
    ''' <param name="in_removeMe">
    '''   TaskFrame to remove.
    ''' </param>
    ''' 
    Public Sub Remove(ByVal in_removeMe As Object) Implements System.Collections.IList.Remove

        Dim tf As TaskFrame

        If in_removeMe Is Nothing Then
            Throw New ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()")
        End If

        tf = CType(in_removeMe, TaskFrame)
        If tf Is Nothing Then
            Throw New ArgumentException("Object passed to TaskFrameCollection is not a TaskFrame.")
        End If

        '
        ' Pass the buck on.
        '
        Me.Remove(in_removeMe)

    End Sub ' Remove (IList)


    '=----------------------------------------------------------------------=
    ' RemoveAt                                                        [IList]
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Removes the TaskFrame at the given index.
    ''' </summary>
    ''' 
    ''' <param name="in_index">
    '''   Index whose TaskFrame we wish removed.
    ''' </param>
    ''' 
    Public Sub RemoveAt(ByVal in_index As Integer) Implements System.Collections.IList.RemoveAt

        '
        ' 0. arg checking
        '
        If in_index < 0 Or in_index >= Me.m_cFrames Then
            Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"))
        End If

        '
        ' 1. Pass the buck.
        '
        Me.Remove(Me.m_frames(in_index))

    End Sub ' RemoveAt




    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '          Private/Protected/Friend    Methods, Members, etc
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=
    '=----------------------------------------------------------------------=


    '=----------------------------------------------------------------------=
    ' addFrameInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The programmer is trying to add the frame to the TaskPane's
    '''   Controls collection instead of adding it to this collection.  The
    '''   ControlCollection will call this to be sure that it gets added to
    '''   this collection anyhow.
    ''' </summary>
    ''' 
    ''' <param name="in_frame">
    '''   TaskFrame being added.
    ''' </param>
    ''' 
    Friend Sub addFrameInternal(ByVal in_frame As TaskFrame)

        '
        ' 1. make sure the array is big enough to hold it.
        '
        If Me.m_cFrames <= 0 And Me.m_frames Is Nothing Then

            Me.m_frames = New TaskFrame(7) {}

        ElseIf Not (Me.m_cFrames + 1) < Me.m_frames.GetLength(0) Then

            Dim rep() As TaskFrame

            rep = New TaskFrame((Me.m_cFrames * 2) - 1) {}
            Array.Copy(Me.m_frames, rep, Me.m_cFrames)

            Me.m_frames = rep

        End If

        '
        ' 2. Add the new Frame to our list, as well as our parent's
        '    control collection.
        '
        Me.m_frames(Me.m_cFrames) = in_frame
        Me.m_cFrames += 1

    End Sub ' addFrameInternal


    '=----------------------------------------------------------------------=
    ' removeFrameInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   This goes and actually removes the frame from our collection of
    '''   frames.  It is factored out from the Remove() methods on IList
    '''   because we also have to be able handle the case where the programmer
    '''   works with the  TaskPane.Controls collection ...
    ''' </summary>
    ''' 
    ''' <param name="in_frame">
    '''   Frame to remove.
    ''' </param>
    ''' 
    Friend Sub removeFrameInternal(ByVal in_frame As TaskFrame)

        If in_frame Is Nothing Then
            Throw New ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"))
        End If

        '
        ' now, go and look for this frame.  if we find it, 
        ' then remove it.
        '
        For i As Integer = 0 To Me.m_cFrames - 1

            '
            ' found it !!!!
            '
            If Me.m_frames(i) Is in_frame Then
                For x As Integer = i To Me.m_cFrames - 1
                    Me.m_frames(x) = Me.m_frames(x + 1)
                Next

                Me.m_cFrames -= 1
                Return
            End If
        Next

        '
        ' Apparently, standard COR behaviour is to NOT throw an exception
        ' if we're asked to remove something that isn't ours ...
        '

    End Sub ' removeFrameInternal


    '=----------------------------------------------------------------------=
    ' clearInternal
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Makes sure that we clear out our list of frames, etc ...
    ''' </summary>
    ''' 
    Friend Sub clearInternal()

        Me.m_frames = Nothing
        Me.m_cFrames = 0

    End Sub ' clearInternal



End Class ' TaskFrameCollection




'=--------------------------------------------------------------------------=
' TaskPaneEventArgs
'=--------------------------------------------------------------------------=
''' <summary>
'''   Provides information about the frame being manipulated in the current
'''   event.
''' </summary>
''' 
Public Class TaskPaneEventArgs
    Inherits System.EventArgs

    '''
    ''' <summary>
    '''   The frame being manipulated by this event.
    ''' </summary>
    ''' 
    Private m_taskFrame As TaskFrame



    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Initialize a new instance of this class.
    ''' </summary>
    ''' 
    ''' <param name="in_frame">
    '''   Frame referred to in his event.
    ''' </param>
    ''' 
    Public Sub New(ByVal in_frame As TaskFrame)

        Me.m_taskFrame = in_frame

    End Sub  ' New


    '=----------------------------------------------------------------------=
    ' TaskFrame
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   The frame to which this event refers.
    ''' </summary>
    ''' 
    <LocalisableDescription("TaskPaneEA.TaskFrame")> _
    Public ReadOnly Property TaskFrame() As TaskFrame

        Get
            Return Me.m_taskFrame
        End Get

    End Property ' TaskFrame


End Class ' TaskPaneEventArgs


'=--------------------------------------------------------------------------=
' TaskPaneCancelEventArgs
'=--------------------------------------------------------------------------=
''' <summary>
'''   Allows a TaskPaneEvent to be cancelled
''' </summary>
''' 
''' 
Public Class TaskPaneCancelEventArgs
    Inherits TaskPaneEventArgs

    ''' 
    ''' <summary>
    '''    Should this event be cancelled?
    ''' </summary>
    ''' 
    Private m_cancel As Boolean


    '=----------------------------------------------------------------------=
    ' Constructor
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Initialize a new instance of this class
    ''' </summary>
    ''' 
    ''' <param name="in_taskFrame">
    '''   Frame the generated this event.
    ''' </param>
    ''' 
    Public Sub New(ByVal in_taskFrame As TaskFrame)

        MyBase.New(in_taskFrame)

    End Sub ' New


    '=----------------------------------------------------------------------=
    ' Cancel
    '=----------------------------------------------------------------------=
    ''' <summary>
    '''   Should the event be cancelled?
    ''' </summary>
    ''' 
    ''' <value>
    '''   A boolean indicating whether the event should be cancelled or
    '''   not (True = cancel, false == permit).
    ''' </value>
    ''' 
    <LocalisableDescription("TaskPaneCEA.Cancel")> _
    Public Property Cancel() As Boolean

        Get
            Return Me.m_cancel
        End Get

        Set(ByVal Value As Boolean)
            Me.m_cancel = Value
        End Set

    End Property ' Cancel


End Class ' TaskPaneCancelEventArgs


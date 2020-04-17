' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
' THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'
' Copyright (c) Microsoft Corporation. All rights reserved.

Option Strict On
Option Explicit On


Partial Public Class MainWindow
    Inherits Window

    Private m_OrbHandler As OrbHandler
    Private m_CurrentOrbling As ILocalOrbling
    Private m_Timer As Timers.Timer

    'Store a reference to the display information in case it is needed later
    Private m_CurrentInformation As OrbDisplay
    Private m_OlderInformation As OrbDisplay

    'Is the Mood Orb running, i.e. is it NOT in Lava Orbling Mode
    Private m_Running As Boolean = False

    'How many ticks do we have on the counter until we update the Orbling again
    Private m_Counter As Integer

    'Cloud rotation animation
    Private m_CloudRotator As Animation.Storyboard

    'Make sure to not allow animation when closing
    Private m_IsClosing As Boolean = False

    Delegate Sub UpdateDisplayHandler()


    'The current step in displaying animation
    Private m_AnimationStep As AnimationStep
    Private m_OrbController As Animation.ClockController
    Private m_CurrentColor As Color

    'Animation Step enumeration for m_AnimationStep
    Private Enum AnimationStep
        None 
        Ready 
        Running 
        ColorChanged 
        ReadyForSecondary 
        SecondaryReady 
        SecondaryRunning 
        ReadyForTertiary 
        TertiaryReady 
        TertiaryRunning 
    End Enum


    Public Sub New()
        InitializeComponent()

        'Begin the cloud rotation
        m_CloudRotator = CType(Me.FindResource("CloudRotator"), Animation.Storyboard)
        m_CloudRotator.Begin(Me, Animation.HandoffBehavior.SnapshotAndReplace, True)

        'Create a new handler
        m_OrbHandler = New OrbHandler

        'Create a default current display
        m_CurrentInformation = New OrbDisplay
        m_CurrentInformation.DisplayColor = New OrbColor(Colors.Blue)
        m_CurrentInformation.DisplayMessage = ""

        m_CurrentColor = Colors.Blue

        'Load the orbling from preferences
        If (m_OrbHandler.OrblingExists(My.Settings.Orb)) Then
            m_CurrentOrbling = m_OrbHandler.GetOrbling(My.Settings.Orb)
        Else
            m_CurrentOrbling = m_OrbHandler.GetOrbling("StockOrbling")
        End If

        m_Timer = New Timers.Timer()

        m_OrbHandler.SetOrbling(m_CurrentOrbling)

        'Start the Mood Orb
        StartOrStop()
    End Sub

    Private Sub HandleMouseLeftButtonDown(ByVal sender As Object, ByVal e As Input.MouseButtonEventArgs)
        MyBase.DragMove()
    End Sub
    Private Sub OptionsButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)


        Dim optionsWindow As New OptionsWindow(m_OrbHandler)

        optionsWindow.ShowDialog()

        If Not m_CurrentOrbling Is m_OrbHandler.CurrentOrbling Then
            m_CurrentOrbling = m_OrbHandler.CurrentOrbling

            m_Running = False

            'Refresh the handler
            m_OrbHandler.Refresh()

            StartOrStop()

        End If

    End Sub

    Private Sub StartButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

        StartOrStop()

    End Sub

    Private Sub StartOrStop()

        If m_Running Then
            StartButtonText.Text = "Start"

            m_Running = False

            m_OrbHandler.SetOrbling("LavaOrbling")
        Else
            StartButtonText.Text = "Stop"

            m_Running = True

            m_OrbHandler.SetOrbling(m_CurrentOrbling)
        End If

        m_OrbHandler.Refresh()

        'We can only go to the options screen when we are running
        OptionsButton.IsEnabled = m_Running

        ModuleNameBlock.Text = m_OrbHandler.OrblingName

        m_Counter = 0

        m_Timer.Close()

        'Create a new timer
        m_Timer = New Timers.Timer(1000)
        AddHandler m_Timer.Elapsed, AddressOf TimerElapsed

        m_Timer.Enabled = True

    End Sub

    Private Sub CloseButtonClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

        'Make sure to set we are closing
        m_IsClosing = True

        'Clear the template so the close animation isn't run on the non-existant window
        'This is due to the gadget window not sending correct close messages to WPF
        'therefore, it would null reference on the trigger in the control's template
        CloseButton.Template = Nothing

        'Stop the timer
        m_Timer.Enabled = False

        'Stop the cloud rotation
        m_CloudRotator.Stop(Me)

        m_OrbHandler.Dispose()

        Application.Current.Shutdown(0)

    End Sub

    Private Sub StartUpdate()

        'Set the mini-clock to "pulse", to show we are updating
        Dim fadeAnimation As New Animation.ColorAnimation
        fadeAnimation.Duration = New Duration(TimeSpan.FromSeconds(1))
        fadeAnimation.From = Colors.LightBlue
        fadeAnimation.To = Colors.Black
        fadeAnimation.AutoReverse = True
        fadeAnimation.RepeatBehavior = Animation.RepeatBehavior.Forever

        Dim backBrush As New SolidColorBrush(Colors.LightBlue)

        backBrush.ApplyAnimationClock(SolidColorBrush.ColorProperty, fadeAnimation.CreateClock())

        ProgressEllipse.Clip = Nothing

        ProgressEllipse.Fill = backBrush

        ProgressEllipse.UpdateLayout()

    End Sub

    Private Sub UpdateDisplay()

        'Update the text information
        If m_CurrentInformation.DisplayMessage Is Nothing Then
            m_CurrentInformation.DisplayMessage = ""
        End If
        Me.Caption.Text = m_CurrentInformation.DisplayMessage

        'Create the proper animation type here, based on the m_CurrentInformation display information
        If Not m_OrbController Is Nothing Then
            If Not m_OrbController.Clock.CurrentState = Animation.ClockState.Stopped Then
                m_OrbController.Stop()
            End If
        End If

        'Create the new animation
        Dim fadeAnimation As New Animation.ColorAnimation

        fadeAnimation = New Animation.ColorAnimation
        fadeAnimation.Duration = New Duration(TimeSpan.FromSeconds(5))
        fadeAnimation.To = m_CurrentInformation.DisplayColor.GetColor()
        fadeAnimation.RepeatBehavior = New Animation.RepeatBehavior(1)
        fadeAnimation.BeginTime = Nothing

        Dim myClock As Animation.AnimationClock = fadeAnimation.CreateClock()

        Dim myBrush As New SolidColorBrush(m_CurrentColor)
        myBrush.ApplyAnimationClock(SolidColorBrush.ColorProperty, myClock)
        m_CurrentColor = m_OlderInformation.DisplayColor.GetColor()

        Me.Orb.Fill = myBrush

        m_OrbController = myClock.Controller

        m_AnimationStep = AnimationStep.Ready

        'if it is the same color, don't run the fade animation
        If (m_CurrentColor.Equals(m_CurrentInformation.DisplayColor.GetColor())) Then
            m_AnimationStep = AnimationStep.ReadyForSecondary
        End If

        m_Counter = 0

        SetProgress()

        m_Timer.Enabled = True
    End Sub

    Private Sub SetProgress()

        'Set the mini-clock on the options bar so we know when the next update is
        ProgressEllipse.Fill = Brushes.LightBlue

        Dim currentPercentage As Double = m_Counter / (m_OrbHandler.OrblingTime / 1000)

        ProgressEllipse.Clip = GetClipGeometry(currentPercentage)

        HandleAnimation()

    End Sub

    'Makes sure a color's byte does not exceed 255
    Private Function BoundCheckColor(ByVal Part As Short, ByVal Addition As Short) As Byte

        Dim newValue As Short = Addition + Part

        If (Addition + Part) > 255 Then
            newValue = 255
        End If

        Return CByte(newValue)

    End Function

    'Creates a similar color from a base color, used for the "Range" animation type
    Private Function GetRangeColor(ByVal BaseColor As Color) As Color

        Dim rand As New Random()

        Dim randRMod As Short = CShort(rand.Next(0, 80))
        Dim randGMod As Short = CShort(rand.Next(0, 80))
        Dim randBMod As Short = CShort(rand.Next(0, 80))

        Dim rColor As Byte = BoundCheckColor(BaseColor.R, randRMod)
        Dim gColor As Byte = BoundCheckColor(BaseColor.G, randGMod)
        Dim bColor As Byte = BoundCheckColor(BaseColor.B, randBMod)

        Dim NewColor As Color = Color.FromRgb(rColor, gColor, bColor)

        Return NewColor

    End Function

    'Handles all Orb Animation
    Private Sub HandleAnimation()

        'Tertiary Animations: Range colors
        If m_AnimationStep = AnimationStep.ReadyForTertiary Then
            m_AnimationStep = AnimationStep.None

            If m_CurrentInformation.DisplayType = OrbAnimationType.Range Then
                m_AnimationStep = AnimationStep.TertiaryReady

                Dim fadeAnimation As New Animation.ColorAnimation

                Dim myBrush As New SolidColorBrush(m_CurrentColor)

                m_CurrentColor = GetRangeColor(m_CurrentInformation.DisplayColor.GetColor())

                fadeAnimation = New Animation.ColorAnimation
                fadeAnimation.Duration = New Duration(TimeSpan.FromSeconds(2))
                fadeAnimation.To = m_CurrentColor
                fadeAnimation.BeginTime = Nothing

                Dim myClock As Animation.AnimationClock = fadeAnimation.CreateClock()

                myBrush.ApplyAnimationClock(SolidColorBrush.ColorProperty, myClock)

                Me.Orb.Fill = myBrush

                m_OrbController = myClock.Controller
            End If
        End If

        'Secondary Animations: Pulsing
        If m_AnimationStep = AnimationStep.ReadyForSecondary Then
            m_AnimationStep = AnimationStep.None

            If m_CurrentInformation.DisplayType = OrbAnimationType.Pulse Then
                m_AnimationStep = AnimationStep.SecondaryReady

                Dim fadeAnimation As New Animation.ColorAnimation

                fadeAnimation = New Animation.ColorAnimation
                fadeAnimation.Duration = New Duration(TimeSpan.FromSeconds(2))
                fadeAnimation.To = m_CurrentInformation.PulseInformation.PulseColor.GetColor()
                fadeAnimation.AutoReverse = True

                If m_CurrentInformation.PulseInformation.IsForever Then
                    fadeAnimation.RepeatBehavior = Animation.RepeatBehavior.Forever
                Else
                    fadeAnimation.RepeatBehavior = New Animation.RepeatBehavior(m_CurrentInformation.PulseInformation.PulseCount)
                End If

                fadeAnimation.BeginTime = Nothing

                Dim myClock As Animation.AnimationClock = fadeAnimation.CreateClock()

                Dim myBrush As New SolidColorBrush(m_CurrentInformation.DisplayColor.GetColor())
                myBrush.ApplyAnimationClock(SolidColorBrush.ColorProperty, myClock)

                Me.Orb.Fill = myBrush

                m_OrbController = myClock.Controller
            End If

            If m_CurrentInformation.DisplayType = OrbAnimationType.Range Then
                m_AnimationStep = AnimationStep.ReadyForTertiary
            End If
        End If

        'Clock Control
        If m_AnimationStep = AnimationStep.TertiaryRunning Then 'Tertiary animations loop
            If (Not m_OrbController.Clock.CurrentState = Animation.ClockState.Active) Then
                m_AnimationStep = AnimationStep.ReadyForTertiary
            End If
        End If

        If m_AnimationStep = AnimationStep.SecondaryRunning Then
            If (Not m_OrbController.Clock.CurrentState = Animation.ClockState.Active) Then
                m_AnimationStep = AnimationStep.ReadyForTertiary
            End If
        End If

        If m_AnimationStep = AnimationStep.Running Then
            If (Not m_OrbController.Clock.CurrentState = Animation.ClockState.Active) Then
                m_CurrentColor = m_CurrentInformation.DisplayColor.GetColor()
                m_AnimationStep = AnimationStep.ReadyForSecondary
            End If
        End If

        If m_AnimationStep = AnimationStep.TertiaryReady Then
            m_OrbController.Begin()

            m_AnimationStep = AnimationStep.TertiaryRunning
        End If

        If m_AnimationStep = AnimationStep.SecondaryReady Then
            m_OrbController.Begin()

            m_AnimationStep = AnimationStep.SecondaryRunning
        End If

        'Primary Animation: Color Change (initiated from UpdateDisplay())
        If m_AnimationStep = AnimationStep.Ready Then
            m_OrbController.Begin()

            m_AnimationStep = AnimationStep.Running
        End If

    End Sub

    'What portion of the "pie" of the mini-clock do we display?
    Private Function GetClipGeometry(ByVal percentage As Double) As PathGeometry

        Dim ellWidth As Int16 = 30

        Dim ellRadius As Double = ellWidth / 2

        Dim degree As Double = (percentage * 2 * Math.PI * (-1)) + (Math.PI / 2)

        Dim piePath As New PathGeometry

        Dim pieFigure As New PathFigure

        pieFigure.StartPoint = New Point(ellWidth / 2, 0)

        Dim xCoord As Double = Math.Cos(degree) * ellRadius + ellRadius - 0.01 'modifier so that the shape doesn't disappear
        Dim yCoord As Double = Math.Sin(degree) * ellRadius * (-1) + ellRadius

        pieFigure.Segments.Add(New ArcSegment(New Point(xCoord, yCoord), New Size(ellWidth, ellWidth), 0, True, SweepDirection.Clockwise, True))

        pieFigure.Segments.Add(New LineSegment(New Point(ellWidth / 2, ellWidth / 2), False))

        piePath.Figures.Add(pieFigure)

        Return piePath

    End Function

    'Tick, tock on our timer until the next update
    Private Sub TimerElapsed(ByVal sender As Object, ByVal e As Timers.ElapsedEventArgs)

        Dim timer As Timers.Timer = CType(sender, Timers.Timer)

        If (m_Counter = (m_OrbHandler.OrblingTime / 1000)) Then

            timer.Enabled = False

            Me.Dispatcher.BeginInvoke(Windows.Threading.DispatcherPriority.Background, New UpdateDisplayHandler(AddressOf StartUpdate))

            m_OlderInformation = m_CurrentInformation
            m_CurrentInformation = m_OrbHandler.GetInformation()

            Me.Dispatcher.BeginInvoke(Windows.Threading.DispatcherPriority.Background, New UpdateDisplayHandler(AddressOf UpdateDisplay))

        Else

            m_Counter = m_Counter + 1

            Me.Dispatcher.BeginInvoke(Windows.Threading.DispatcherPriority.Background, New UpdateDisplayHandler(AddressOf SetProgress))

        End If

    End Sub

    'Show the buttons on the bottom of the Orb
    Private Sub ShowButtons(ByVal sender As Object, ByVal e As Input.MouseEventArgs)

        If Not m_IsClosing Then

            Dim fadeBarIn As Animation.Storyboard = CType(Me.FindResource("FadeControlBarIn"), Animation.Storyboard)
            Dim fadeCaptionBarIn As Animation.Storyboard = CType(Me.FindResource("FadeCaptionBarIn"), Animation.Storyboard)

            fadeBarIn.Begin(Me)

            If m_CurrentInformation.DisplayMessage.Length > 0 Then
                fadeCaptionBarIn.Begin(Me)
            End If

        End If

    End Sub

    Private Sub HideButtons(ByVal sender As Object, ByVal e As Input.MouseEventArgs)

        If Not m_IsClosing Then
            Dim fadeBarOut As Animation.Storyboard = CType(Me.FindResource("FadeControlBarOut"), Animation.Storyboard)
            Dim fadeCaptionBarOut As Animation.Storyboard = CType(Me.FindResource("FadeCaptionBarOut"), Animation.Storyboard)

            fadeBarOut.Begin(Me)

            If CaptionStack.Opacity > 0 Then
                fadeCaptionBarOut.Begin(Me)
            End If
        End If

    End Sub

End Class

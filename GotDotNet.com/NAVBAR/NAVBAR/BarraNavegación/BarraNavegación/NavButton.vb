'***********************************************************************************************************
' From Spain: November 2002
'
' All code has been developed by:
' Jesús López is MCP SQL Server and Microsoft .NET MVP
' You can contact with Jesús in his web site (SqlRanger - http://www.sqlranger.com/)
'
' With a little contribution of:
' Jorge Serrano is Microsoft .NET MVP
' You can contact with Jorge in his web site (PortalVB.com - http://www.portalvb.com/)
'***********************************************************************************************************

Imports System.Drawing

Public Class NavButton
    Inherits System.Windows.Forms.Control

    Private Enum MouseStateEnum
        Up
        Down
    End Enum

    Private Enum ButtonStateEnum
        Normal
        Pushed
        Hilighted
        Disabled
    End Enum

    Private Enum CursorPosEnum
        OutSide
        InSide
    End Enum


    Private mCursorPos As CursorPosEnum
    Private mMouseState As MouseStateEnum
    Private mRepeater As Boolean
    Private mButtonState As ButtonStateEnum

    Private Property ButtonState() As ButtonStateEnum
        Get
            Return Me.mButtonState
        End Get
        Set(ByVal Value As ButtonStateEnum)
            If Value <> Me.mButtonState Then
                Me.mButtonState = Value
                Me.Invalidate()
            End If
        End Set
    End Property

    Private mTooltipText As String
    Public Property TooltipText() As String
        Get
            Return Me.mTooltipText
        End Get
        Set(ByVal Value As String)
            Me.mTooltipText = Value
            Me.ToolTip1.SetToolTip(Me, Me.mTooltipText)
        End Set
    End Property

    Private Sub RefreshButtonState()
        If Me.Enabled Then
            If Me.mCursorPos = CursorPosEnum.OutSide Then
                Me.ButtonState = ButtonStateEnum.Normal
            ElseIf Me.mMouseState = MouseStateEnum.Down Then
                Me.ButtonState = ButtonStateEnum.Pushed
            Else
                Me.ButtonState = ButtonStateEnum.Hilighted
            End If
        Else
            Me.ButtonState = ButtonStateEnum.Disabled
        End If
    End Sub


    Public Property Repeater() As Boolean
        Get
            Return Me.mRepeater
        End Get
        Set(ByVal Value As Boolean)
            Me.mRepeater = Value
        End Set
    End Property

    Private mNormalImage As Bitmap
    Public Property NormalImage() As Bitmap
        Get
            Return Me.mNormalImage
        End Get
        Set(ByVal Value As Bitmap)
            Me.mNormalImage = Value
            If Not Value Is Nothing Then
                Value.MakeTransparent(Color.White)
            End If
            Me.Invalidate()
        End Set
    End Property

    Private mPushedImage As Bitmap
    Public Property PushedImage() As Bitmap
        Get
            Return Me.mPushedImage
        End Get
        Set(ByVal Value As Bitmap)
            Me.mPushedImage = Value
            If Not Value Is Nothing Then
                Value.MakeTransparent(Color.White)
            End If
            Me.Invalidate()
        End Set
    End Property

    Private mHilightedImage As Bitmap
    Public Property HilightedImage() As Bitmap
        Get
            Return Me.mHilightedImage
        End Get
        Set(ByVal Value As Bitmap)
            Me.mHilightedImage = Value
            If Not Value Is Nothing Then
                Value.MakeTransparent(Color.White)
            End If
            Me.Invalidate()
        End Set
    End Property

    Private mDisabledImage As Bitmap
    Public Property DisabledImage() As Bitmap
        Get
            Return Me.mDisabledImage
        End Get
        Set(ByVal Value As Bitmap)
            Me.mDisabledImage = Value
            If Not Value Is Nothing Then
                Value.MakeTransparent(Color.White)
            End If
            Me.Invalidate()
        End Set
    End Property

#Region " Código generado por el Diseñador de componentes "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Me.mCursorPos = CursorPosEnum.OutSide
        Me.mMouseState = MouseStateEnum.Up
        Me.mButtonState = ButtonStateEnum.Normal
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents Timer1 As System.Timers.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Timers.Timer
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.SynchronizingObject = Me
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)
        'Add your own graphics code here
        Dim rect As RectangleF
        With rect
            .X = 0
            .Y = 0
            .Width = Me.Width
            .Height = Me.Height
        End With
        Select Case Me.mButtonState
            Case ButtonStateEnum.Disabled
                If Not Me.mDisabledImage Is Nothing Then
                    pe.Graphics.DrawImage(Me.mDisabledImage, rect)
                ElseIf Not Me.mNormalImage Is Nothing Then
                End If
            Case ButtonStateEnum.Hilighted
                If Not Me.mHilightedImage Is Nothing Then
                    pe.Graphics.DrawImage(Me.mHilightedImage, rect)
                ElseIf Not Me.NormalImage Is Nothing Then
                    pe.Graphics.DrawImage(Me.mNormalImage, rect)
                    Dim pen As New Pen(Color.DarkBlue, 2)
                    pe.Graphics.DrawRectangle(pen, 1, 1, Me.Width - 2, Me.Height - 2)
                End If
            Case ButtonStateEnum.Normal
                If Not Me.NormalImage Is Nothing Then
                    pe.Graphics.DrawImage(Me.mNormalImage, rect)
                End If
            Case ButtonStateEnum.Pushed
                If Not Me.mPushedImage Is Nothing Then
                    pe.Graphics.DrawImage(Me.mPushedImage, rect)
                ElseIf Not Me.NormalImage Is Nothing Then
                    rect.X += 1 : rect.Y += 1
                    pe.Graphics.DrawImage(Me.mNormalImage, rect)
                    Dim pen As New Pen(Color.DarkBlue, 2)
                    pe.Graphics.DrawRectangle(pen, 1, 1, Me.Width - 2, Me.Height - 2)
                End If
        End Select
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
        MyBase.OnEnabledChanged(e)
        Me.RefreshButtonState()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        Me.mCursorPos = CursorPosEnum.OutSide
        Me.RefreshButtonState()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If (e.X > Me.Width Or e.X < 0 Or e.Y > Me.Height Or e.Y < 0) Then
            If Me.mCursorPos = CursorPosEnum.InSide Then
                Me.mCursorPos = CursorPosEnum.OutSide
                Me.RefreshButtonState()
            End If
        Else
            If Me.mCursorPos = CursorPosEnum.OutSide Then
                Me.mCursorPos = CursorPosEnum.InSide
                Me.RefreshButtonState()
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        Me.mMouseState = MouseStateEnum.Down
        Me.RefreshButtonState()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        Me.mMouseState = MouseStateEnum.Up
        Me.RefreshButtonState()
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        If Not Me.mRepeater Then
            MyBase.OnClick(e)
        End If
    End Sub

    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        OnClick(e)
    End Sub
End Class
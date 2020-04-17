 '=====================================================================
'  File:      Scrib.cs
'
'  Summary:   Simple scribbling pad
'
'  ---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'  This source code is intended only as a supplement to Microsoft
'  Development Tools and/or on-line documentation.  See these other
'  materials for detailed information regarding Microsoft code samples.
'
'  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'  PARTICULAR PURPOSE.
'=====================================================================

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections

Namespace Microsoft.Samples.Scribbler

' Color swatch tray
Public Class Tray
    Inherits Control

    Public Delegate Sub OnCmdEventHandler()

    ' Swatch

    Private Class Swatch
        Private Const MarginSize As Integer = 4

        Private colorValue As Color
        Private boundsValue As Rectangle
        Private caption As String
        Private cmdEventHandler As OnCmdEventHandler
        Private isCmdValue As Boolean
        Private font As Font


        Public Sub New(ByVal colorValue As Color, ByVal bounds As Rectangle)
            Me.colorValue = colorValue
            Me.boundsValue = bounds
            Me.caption = ""
            Me.font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

            Me.isCmdValue = False

        End Sub 'New


        Public Sub New(ByVal caption As String, ByVal bounds As Rectangle, ByVal cmdEventHandler As OnCmdEventHandler)
            If caption Is Nothing Then
                Throw New ArgumentException("'caption' should not be null.")
            End If
            If cmdEventHandler Is Nothing Then
                Throw New ArgumentException("Event handler must not be empty.")
            End If
            Me.colorValue = System.Drawing.Color.White
            Me.caption = caption
            Me.boundsValue = bounds
            Me.cmdEventHandler = cmdEventHandler
            Me.font = New Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold)

            Me.isCmdValue = True

        End Sub 'New


        Public Sub Display(ByVal drawingSurface As Graphics, ByVal isSelected As Boolean)
            Dim frame As Rectangle
            Dim left, top As Integer
            Dim textWidth, textHeight As Integer
            Dim frameColor As Color

            frame = Me.boundsValue
            frame.Inflate(-Swatch.MarginSize, -Swatch.MarginSize)

            drawingSurface.FillRectangle(New SolidBrush(Me.colorValue), frame)

            ' Caption
            textWidth = Convert.ToInt32(drawingSurface.MeasureString(Me.caption, Me.font).Width)
            textHeight = Convert.ToInt32(drawingSurface.MeasureString(Me.caption, Me.font).Height)

            left = Convert.ToInt32(frame.X + (frame.Width - textWidth) / 2)
            top = Convert.ToInt32(frame.Y + (frame.Height - textHeight) / 2)

            drawingSurface.DrawString(Me.caption, Me.font, New SolidBrush(System.Drawing.Color.Black), left, top)

            ' Frame

            frameColor = System.Drawing.Color.Black

            drawingSurface.DrawRectangle(New Pen(frameColor), frame)
            If isSelected Then
                ' We'll draw an outer rectangle (2 pixels wide) to show
                ' the selected color.
                frame.Inflate(2, 2)
                drawingSurface.DrawRectangle(New Pen(frameColor), frame)

                frame.Inflate(1, 1)
                drawingSurface.DrawRectangle(New Pen(frameColor), frame)
            End If

        End Sub 'Display


        Public ReadOnly Property Color() As Color
            Get
                Return Me.colorValue
            End Get
        End Property

        Public ReadOnly Property Bounds() As Rectangle
            Get
                Return Me.boundsValue
            End Get
        End Property

        Public Sub DoCmd()
            If (Me.isCmdValue AndAlso Not (Me.cmdEventHandler Is Nothing)) Then
                Me.cmdEventHandler()
            End If

        End Sub 'DoCmd 

        Public ReadOnly Property IsCmd() As Boolean
            Get
                Return Me.isCmdValue
            End Get
        End Property
    End Class 'Swatch 
    Private Const SwatchWidth As Integer = 26
    Private Const CommandWidth As Integer = 48
    Private heightValue As Integer
    Private swatchList As New ArrayList()
    Private selectedSwatch As Integer
    Private offscreenBitmap As Bitmap
    Private offscreenDrawingSurface As Graphics
    Private isInitialized As Boolean


    Public Sub New(ByVal parentForm As Form, ByVal width As Integer, ByVal height As Integer)
        Me.isInitialized = False

        Me.BackColor = Color.SlateGray
        Me.Parent = parentForm
        Me.Left = 0
        Me.Top = 0
        Me.ClientSize = New Size(width, height)
        Me.Visible = True

        Me.heightValue = height
        Me.selectedSwatch = 0
        Me.offscreenBitmap = New Bitmap(width, height)
        If Not (Me.offscreenBitmap Is Nothing) Then
            Me.offscreenDrawingSurface = Graphics.FromImage(Me.offscreenBitmap)
        End If
        Me.isInitialized = Not (Me.offscreenBitmap Is Nothing) AndAlso Not (Me.offscreenDrawingSurface Is Nothing)

    End Sub 'New


    Public ReadOnly Property Initialized() As Boolean
        Get
            Return Me.isInitialized
        End Get
    End Property


    Public Sub AddColorSwatch(ByVal colorValue As Color)
        Dim x, y As Integer
        Dim width, height As Integer

        ' Calculate horizontal extent of current swatches
        x = 0
        Dim swatch As Swatch
        For Each swatch In Me.swatchList
            x += swatch.Bounds.Width
        Next swatch
        y = 0
        width = Tray.SwatchWidth
        height = Me.heightValue

        Me.swatchList.Add(New Swatch(colorValue, New Rectangle(x, y, width, height)))
        Me.Invalidate()

    End Sub 'AddColorSwatch


    Public Sub AddCmd(ByVal caption As String, ByVal cmdEventHandler As OnCmdEventHandler)
        Dim left, top As Integer
        Dim width, height As Integer

        ' Calculate horizontal extent of current swatches
        left = 0
        Dim swatch As Swatch
        For Each swatch In Me.swatchList
            left += swatch.Bounds.Width
        Next swatch
        top = 0
        width = Tray.CommandWidth
        height = Me.heightValue

        Me.swatchList.Add(New Swatch(caption, New Rectangle(left, top, width, height), cmdEventHandler))
        Me.Invalidate()

    End Sub 'AddCmd


    Public ReadOnly Property CurrentColor() As Color
        Get
            Return CType(Me.swatchList(Me.selectedSwatch), Swatch).Color
        End Get
    End Property


    Protected Overrides Sub OnPaint(ByVal paintArgs As PaintEventArgs)
        Dim drawingSurface As Graphics
        Dim i As Integer
        Dim swatch As Swatch
        Dim isSelected As Boolean

        If Not (Me.offscreenDrawingSurface Is Nothing) Then
            Dim brush As New SolidBrush(Me.BackColor)
            If Not (brush Is Nothing) Then
                Me.offscreenDrawingSurface.FillRectangle(brush, 0, 0, ClientSize.Width, ClientSize.Height)
            End If
        End If

        drawingSurface = Me.offscreenDrawingSurface

        If Not (drawingSurface Is Nothing) Then
            For i = 0 To (Me.swatchList.Count - 1)
                swatch = CType(Me.swatchList(i), Swatch)

                isSelected = (i = Me.selectedSwatch)

                swatch.Display(drawingSurface, isSelected)
            Next i
        End If

        paintArgs.Graphics.DrawImage(Me.offscreenBitmap, 0, 0)

    End Sub 'OnPaint


    Protected Overrides Sub OnPaintBackground(ByVal paintArgs As PaintEventArgs)

    End Sub 'OnPaintBackground

    ' Do nothing, don't paint background

    Protected Overrides Sub OnMouseDown(ByVal mouseArgs As MouseEventArgs)
        Dim i As Integer
        Dim swatch As Swatch

        For i = 0 To (Me.swatchList.Count - 1)
            swatch = CType(Me.swatchList(i), Swatch)

            If swatch.Bounds.Contains(mouseArgs.X, mouseArgs.Y) Then
                If swatch.IsCmd Then
                    swatch.DoCmd()

                    Me.Invalidate()
                Else
                    Me.Invalidate(CType(Me.swatchList(Me.selectedSwatch), Swatch).Bounds)
                    Me.selectedSwatch = i
                    Me.Invalidate(CType(Me.swatchList(Me.selectedSwatch), Swatch).Bounds)
                End If

                Exit For
            End If
        Next i

    End Sub 'OnMouseDown
End Class 'Tray


' Scribbler application window

Public Class ScribblerForm
    Inherits Form
    Private Const TrayHeight As Integer = 20

    Private maxWidth As Integer
    Private maxHeight As Integer
    Private drawingSurface As Graphics
    Private bitmap As Bitmap
    Private hasCapture As Boolean
    Private oldX, oldY As Integer
    Private tray As Tray
    Private isInitialized As Boolean

    Private scribblerMenu As MainMenu
    Friend WithEvents fileMenu As MenuItem
    Friend WithEvents exitMenuItem As MenuItem



    Public Sub New()
        Me.isInitialized = False

        Me.maxWidth = Me.ClientSize.Width
        Me.maxHeight = Me.ClientSize.Height

        Me.BackColor = System.Drawing.Color.White
        Me.hasCapture = False
        Me.Text = "Scribbler"
        Me.scribblerMenu = New MainMenu
        Me.fileMenu = New MenuItem
        Me.fileMenu.Text = "&File"
        Me.exitMenuItem = New MenuItem
        Me.exitMenuItem.Text = "E&xit"
        AddHandler Me.exitMenuItem.Click, AddressOf Me.ExitMenuItem_Click
        Me.fileMenu.MenuItems.Add(Me.exitMenuItem)
        Me.scribblerMenu.MenuItems.Add(Me.fileMenu)
        Me.Menu = Me.scribblerMenu

        ' Create offscreen drawing surface
        Me.bitmap = New Bitmap(Me.maxWidth, Me.maxHeight)
        If Not (Me.bitmap Is Nothing) Then
            Me.drawingSurface = System.Drawing.Graphics.FromImage(Me.bitmap)

            If Not (Me.drawingSurface Is Nothing) Then
                Me.drawingSurface.FillRectangle(New SolidBrush(System.Drawing.Color.White), 0, 0, maxWidth, maxHeight)
            End If
        End If

        ' Create tray
        Me.tray = New Tray(Me, Me.maxWidth, TrayHeight)

        If Not (Me.tray Is Nothing) AndAlso Me.tray.Initialized Then
            ' Add color swatches to tray
            Me.tray.AddColorSwatch(System.Drawing.Color.Black)
            Me.tray.AddColorSwatch(System.Drawing.Color.Red)
            Me.tray.AddColorSwatch(System.Drawing.Color.Tomato)
            Me.tray.AddColorSwatch(System.Drawing.Color.Yellow)
            Me.tray.AddColorSwatch(System.Drawing.Color.Magenta)
            Me.tray.AddColorSwatch(System.Drawing.Color.Blue)
            Me.tray.AddColorSwatch(System.Drawing.Color.Green)

            ' Add "Clear" command to tray
            Me.tray.AddCmd("Clear", New Tray.OnCmdEventHandler(AddressOf Me.OnErase))
        End If

        Me.isInitialized = Not (Me.bitmap Is Nothing) AndAlso Not (Me.drawingSurface Is Nothing) AndAlso Not (Me.tray Is Nothing) AndAlso Me.tray.Initialized

    End Sub 'New

    Private Sub ExitMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Application.Exit()
    End Sub 'ExitMenuItem_Click

    Public ReadOnly Property Initialized() As Boolean
        Get
            Return Me.isInitialized
        End Get
    End Property


    Public Sub OnErase()
        If Not (Me.drawingSurface Is Nothing) Then
            Me.drawingSurface.FillRectangle(New SolidBrush(System.Drawing.Color.White), 0, 0, Me.maxWidth, Me.maxHeight)
        End If

        Me.Invalidate()

    End Sub 'OnErase


    Protected Overrides Sub OnMouseDown(ByVal mouseArgs As MouseEventArgs)
        ' Note mouse capture (in internal flag as well)
        Me.hasCapture = True
        Me.Capture = True

        Me.oldX = mouseArgs.X
        Me.oldY = mouseArgs.Y

    End Sub 'OnMouseDown


    Protected Overrides Sub OnMouseMove(ByVal mouseArgs As MouseEventArgs)
        Dim x, y As Integer

        If Me.hasCapture Then
            ' Pull out coordinates for easier reference
            x = mouseArgs.X
            y = mouseArgs.Y

            ' Draw line from last hit point to current hit point
            If Not (Me.drawingSurface Is Nothing) Then
                Dim pen As New Pen(Me.tray.CurrentColor)
                If Not (pen Is Nothing) Then
                    Me.drawingSurface.DrawLine(pen, Me.oldX, Me.oldY, x, y)
                End If
            End If
            ' The update rectangle needs to be normalized (i.e. left and
            ' top actually on the left and top and width and height >= 0).
            Me.Invalidate(New Rectangle(Math.Min(x, Me.oldX), Math.Min(y, Me.oldY), Math.Abs(Me.oldX - x) + 1, Math.Abs(Me.oldY - y) + 1))

            Me.oldX = x
            Me.oldY = y
        End If

    End Sub 'OnMouseMove


    Protected Overrides Sub OnMouseUp(ByVal mouseArgs As MouseEventArgs)
        ' Release mouse capture (including internal flag)
        Me.hasCapture = False
        Me.Capture = False

    End Sub 'OnMouseUp


    Protected Overrides Sub OnPaint(ByVal paintArgs As PaintEventArgs)
        If Not (Me.bitmap Is Nothing) Then
            paintArgs.Graphics.DrawImage(Me.bitmap, 0, 0)
        End If

    End Sub 'OnPaint

    Protected Overrides Sub OnPaintBackground(ByVal paintArgs As PaintEventArgs)

    End Sub 'OnPaintBackground
End Class 'ScribblerForm ' Do nothing, OnPaint will redraw the entire area

' Application

Public Class App

    Private Sub New()
    End Sub
    
    Public Shared Sub Main() 
        Dim scribbler As ScribblerForm
        
        scribbler = New ScribblerForm()
        
        If scribbler.Initialized Then
            Application.Run(scribbler)
        End If
    
    End Sub 'Main
End Class 'App

End Namespace


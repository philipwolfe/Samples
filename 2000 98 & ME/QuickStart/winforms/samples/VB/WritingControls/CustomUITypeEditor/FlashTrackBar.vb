'------------------------------------------------------------------------------
'/ <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'/    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'/       
'/    This source code is intended only as a supplement to Microsoft
'/    Development Tools and/or on-line documentation.  See these other
'/    materials for detailed information regarding Microsoft code samples.
'/
'/ </copyright>                                                                
'------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.WinForms
Imports System.Diagnostics

Namespace Microsoft.Samples.WinForms.VB.FlashTrackBar 

    Public Class FlashTrackBar 
        Inherits RichControl 
        
        Private LeftRightBorder As Integer = 10
        Private myValue As Integer  = 0
        Private myMin As Integer = 0
        Private myMax As Integer = 100
        Private myShowPercentage As Boolean = false
        Private myShowValue As Boolean = false
        Private myAllowUserEdit As Boolean = true
        Private myShowGradient As Boolean = true
        Private dragValue As Integer  = 0
        Private dragging As Boolean = false
        Private myStartColor As Color = Color.Red
        Private myEndColor As Color = Color.LimeGreen
        Private baseBackground As Brush
        Private backgroundDim as Brush
        Private myDarkenBy As Byte = 200

        Public Sub New() 
            MyBase.New
            SetStyle(ControlStyles.Opaque, true)
            SetStyle(ControlStyles.ResizeRedraw, true)
            Debug.Assert(GetStyle(ControlStyles.ResizeRedraw), "Should be redraw!")
            ForeColor = Color.White
            BackColor = Color.Black
            Size = new Size(100, 23)
            Me.Text = "FlashTrackBar"
        End Sub

        Public Property <Category("Flash"), DefaultValue(true)> AllowUserEdit As Boolean
            Get 
                return myAllowUserEdit
            End Get
            
            Set 
                If (value <> myAllowUserEdit) Then
                    myAllowUserEdit = value
                    If Not (myAllowUserEdit) Then
                        Capture = false
                        dragging = false
                    End If
                End If
            End Set
            
        End Property
 
        
        Public Property <Category("Flash")> EndColor As Color
            Get 
                return myEndColor
            End Get
            
            Set 
                myEndColor = value
                if (baseBackground <> Nothing AND myShowGradient) Then
                    baseBackground.Dispose
                    baseBackground = Nothing
                End If
                Invalidate
            End Set
        End Property
 
       Public Function ShouldPersistEndColor() As Boolean
           return Not (myEndColor.Equals(Color.LimeGreen))
       End Function
 
 
        Public Property _
            <Category("Flash"), _
            Editor(GetType(FlashTrackBarDarkenByEditor), GetType(UITypeEditor)), _
            DefaultValue(200)> _
        DarkenBy As Byte
            Get 
                return myDarkenBy
            End Get
            Set 
                If (value <> myDarkenBy) Then
                    myDarkenBy = value
                    If (backgroundDim <> Nothing) Then
                        backgroundDim.Dispose()
                        backgroundDim = Nothing
                    End If
                    OptimizedInvalidate(Value, max)
                End If
            End Set
        End Property
        
        
        Public Property _
            <Category("Flash"),DefaultValue(100)> _
        Max  As Integer
            Get 
                return myMax
            End Get
            Set 
                If (myMax <> value) 
                    myMax = value
                    Invalidate
                End If
            End Set
        End Property
 
        Public Property _
            <Category("Flash"),DefaultValue(0)> _
        Min As Integer
            Get 
                return myMin
            End Get
            Set 
                If (min <> value) Then
                    min = value
                    Invalidate
                End If
            End Set
        End Property
 
        
        Public Property <Category("Flash")> StartColor As Color
            Get 
                return myStartColor
            End Get
            Set 
                myStartColor = value
                If (baseBackground <> Nothing AND myShowGradient) Then
                    baseBackground.Dispose()
                    baseBackground = Nothing
                End If
                Invalidate
            End Set
        End Property
 
        Public Function ShouldPersistStartColor() As Boolean
            return Not (startColor.Equals(Color.Red))
        End Function
 
        Public Property _
            <Category("Flash"), _
                RefreshProperties(RefreshProperties.Repaint), _
                DefaultValue(false)> _
        ShowPercentage As Boolean  
            Get 
                return myShowPercentage
            End Get
            Set 
                If (value <> myShowPercentage) Then
                    myShowPercentage = value
                    If (myShowPercentage) Then
                        myShowValue = false
                    End If
                    Invalidate
                End If
            End Set
        End Property
 
        Public Property _
            <Category("Flash"), _
                RefreshProperties(RefreshProperties.Repaint), _
                DefaultValue(false)> _
        ShowValue As Boolean
            Get 
                return myShowValue
            End Get
            Set 
                if (value <> myShowValue) Then
                    myShowValue = value
                    if (myShowValue) Then
                        myShowPercentage = false
                    End If
                    Invalidate
                End If
            End Set
        End Property
 
        
        Public Property _
            <Category("Flash"),DefaultValue(true)> _
        ShowGradient As Boolean
            get 
                return myShowGradient
            End Get
            set 
                if (value <> myShowGradient) Then
                    myShowGradient = value
                    if (baseBackground <> Nothing) Then
                        baseBackground.Dispose()
                        baseBackground = Nothing
                    End If
                    Invalidate
                End If
            End Set
        End Property

 
        Public Property _
            <Category("Flash"), _
             Editor(GetType(FlashTrackBarValueEditor), GetType(UITypeEditor)), _
             DefaultValue(0)> _
        Value As Integer 
            get 
                if (dragging) Then
                    return dragValue
                End If
                return myValue
            end get
            set 
                if (value <> myValue) Then
                    Dim old As Integer = myValue
                    myValue = value
                    OnValueChanged(EventArgs.Empty)
                    OptimizedInvalidate(old, myValue)
                End If
            end set
        end Property

        ' ValueChanged Event
        Public Event _
            <Description("Raised when the Value displayed changes")> _
        ValueChanged (sender As object, ev As EventArgs) 'As EventHandler

        
        Private Sub OptimizedInvalidate(oldValue As Integer, newValue As Integer) 
            Dim client As Rectangle = ClientRectangle
 
            Dim oldPercentValue As Single = CSng(oldValue) / (CSng(Max) - CSng(Min))
            Dim oldNonDimLength As Integer = CInt(oldPercentValue * CSng(client.Width))
 
            Dim newPercentValue As Single = (CSng(newValue) / (CSng(Max) - CSng(Min)))
            Dim newNonDimLength As Integer = CInt(newPercentValue * CSng(client.Width))
 
            Dim lmin As Integer = Math.Min(oldNonDimLength, newNonDimLength)
            Dim lmax As Integer = Math.Max(oldNonDimLength, newNonDimLength)
 
            Dim invalid As Rectangle = new Rectangle(client.X + lmin, client.Y, lmax - lmin, client.Height)
            Invalidate(invalid)
 
            Dim oldToDisplay As string
            Dim newToDisplay As string
 
            If (ShowPercentage) Then
                oldToDisplay = Convert.ToString(CInt(oldPercentValue * 100f)) + "%"
                newToDisplay = Convert.ToString(CInt(newPercentValue * 100f)) + "%"
            Else If (ShowValue) 
                oldToDisplay = Convert.ToString(oldValue)
                newToDisplay = Convert.ToString(newValue)
            Else 
                oldToDisplay = Nothing
                newToDisplay = Nothing
            End If
 
            If (oldToDisplay <> Nothing AND newToDisplay <> Nothing) 
                Dim g As Graphics = CreateGraphics()
                Dim oldFontSize As SizeF = g.MeasureString(oldToDisplay, Font)
                Dim newFontSize As SizeF = g.MeasureString(newToDisplay, Font)
                Dim oldFontRectF As RectangleF = new RectangleF(new PointF(0, 0), oldFontSize)
                Dim newFontRectF As RectangleF = new RectangleF(new PointF(0, 0), newFontSize)
                oldFontRectF.X = (client.Width - oldFontRectF.Width) / 2
                oldFontRectF.Y = (client.Height - oldFontRectF.Height) / 2
                newFontRectF.X = (client.Width - newFontRectF.Width) / 2
                newFontRectF.Y = (client.Height - newFontRectF.Height) / 2
                
                Dim oldFontRect As Rectangle = new Rectangle(CInt(oldFontRectF.X),CInt(oldFontRectF.Y),CInt(oldFontRectF.Width),CInt(oldFontRectF.Height))
                Dim newFontRect As Rectangle = new Rectangle(CInt(newFontRectF.X),CInt(newFontRectF.Y),CInt(newFontRectF.Width),CInt(newFontRectF.Height))
                                 
                Invalidate(oldFontRect)
                Invalidate(newFontRect)
            End If
        End Sub
        
 
 
        Overrides Protected Sub OnMouseDown(e As MouseEventArgs) 
            MyBase.OnMouseDown(e)
            if Not (myAllowUserEdit) Then
                return
            End If
            Capture = true
            dragging = true
            SetDragValue(new Point(e.X, e.Y))
        End Sub
 
        Overrides Protected Sub OnMouseMove(e As MouseEventArgs) 
            MyBase.OnMouseMove(e)
            if (Not myAllowUserEdit OR Not dragging) Then
                return
            End If
            SetDragValue(new Point(e.X, e.Y))
        End Sub
 
        Overrides Protected Sub OnMouseUp(e As MouseEventArgs) 
            MyBase.OnMouseUp(e)
            if ( Not myAllowUserEdit OR Not dragging) Then
                return
            End If
            Capture = false
            dragging = false
            value = dragValue
            OnValueChanged(EventArgs.Empty)
        End Sub
 
        Overrides Protected Sub OnPaint(e As PaintEventArgs) 
            MyBase.OnPaint(e)
            
            if (baseBackground Is Nothing) Then
                
                if (myShowGradient) Then
                    baseBackground = new LinearGradientBrush(new Point(0, 0), _
                                                             new Point(ClientSize.Width, 0), _
                                                             StartColor, _
                                                             EndColor)
                else if (BackgroundImage <> Nothing) Then
                    baseBackground = new TextureBrush(BackgroundImage)
                else 
                    baseBackground = new SolidBrush(BackColor)
                End If
                
            End If
 
            if (backgroundDim Is Nothing) Then
                backgroundDim = new SolidBrush(Color.FromARGB(DarkenBy, Color.Black))
            End If
 
            Dim toDim As Rectangle = ClientRectangle
            Dim percentValue As Single = (CSng(Value) / (CSng(Max) - CSng(Min)))
            Dim nonDimLength As Integer = CInt(percentValue * CSng(toDim.Width))
            toDim.X = toDim.X + nonDimLength
            toDim.Width = toDim.Width - nonDimLength
 
            Dim ltext As string = Me.Text
            Dim toDisplay As string 
            Dim textRect As RectangleF = New RectangleF(0,0,0,0)
 
            If (ShowPercentage OR ShowValue OR ltext.Length > 0) Then
 
                if (ShowPercentage) Then
                    toDisplay = Convert.ToString(CInt(percentValue * 100f)) + "%"
                else if (ShowValue) Then
                    toDisplay = Convert.ToString(Value)
                else 
                    toDisplay = ltext
                End If
 
                Dim textSize As SizeF = e.Graphics.MeasureString(toDisplay, Font)
                textRect.Width = textSize.Width
                textRect.Height = textSize.Height
                textRect.X = (ClientRectangle.Width - textRect.Width) / 2
                textRect.Y = (ClientRectangle.Height - textRect.Height) / 2
            End If
 
            e.Graphics.FillRectangle(baseBackground, ClientRectangle)
            e.Graphics.FillRectangle(backgroundDim, toDim)
            e.Graphics.Flush()
            if (toDisplay <> Nothing AND toDisplay.Length > 0) Then
                e.Graphics.DrawString(toDisplay, Font, new SolidBrush(ForeColor), textRect)
            End If
        End Sub
 
        Overrides Protected Sub OnPropertyChanged(e As PropertyChangedEventArgs) 
            MyBase.OnPropertyChanged(e)
            if (e.PropertyName = "Text") Then
                Invalidate
            else if Not(myShowGradient) Then
                if (e.PropertyName = "BackColor" OR e.PropertyName = "BackgroundImage") Then
                    if (baseBackground <> Nothing) Then
                        baseBackground.Dispose()
                        baseBackground = Nothing
                    End If
                End If
            End If
        End Sub
 
        Overrides Protected Sub OnResize(e As EventArgs) 
            MyBase.OnResize(e)
            if (baseBackground <> Nothing) Then
                baseBackground.Dispose()
                baseBackground = Nothing
            End If
        End Sub
 
        Overridable Protected Sub OnValueChanged(e As EventArgs) 
            RaiseEvent ValueChanged(Me, e)
        End Sub
        
        Private Sub SetDragValue(mouseLocation As Point) 
 
            Dim client As Rectangle = ClientRectangle
 
            if (client.Contains(mouseLocation)) Then
                
                Dim percentage As Single = CSng(mouseLocation.X) / CSng(ClientRectangle.Width)
                Dim newDragValue As Integer = CInt(percentage * CSng(max - min))
                
                if (newDragValue <> dragValue) Then
                    Dim old As Integer = dragValue
                    dragValue = newDragValue
                    OptimizedInvalidate(old, dragValue)
                End If
                
            Else 
            
                if (client.Y <= mouseLocation.Y AND mouseLocation.Y <= client.Y + client.Height) Then
                    if (mouseLocation.X <= client.X AND mouseLocation.X > client.X - LeftRightBorder) Then
                        Dim newDragValue As Integer = min
                        if (newDragValue <> dragValue) Then
                            Dim old As Integer = dragValue
                            dragValue = newDragValue
                            OptimizedInvalidate(old, dragValue)
                        End If
                    
                    else if (mouseLocation.X >= client.X + client.Width AND mouseLocation.X < client.X + client.Width + LeftRightBorder) Then
                        Dim newDragValue As Integer = max
                        if (newDragValue <> dragValue) Then
                            Dim old As Integer = dragValue
                            dragValue = newDragValue
                            OptimizedInvalidate(old, dragValue)
                        End If
                    End If
                    
                else 
                    if (dragValue <> value) Then
                        Dim old As Integer = dragValue
                        dragValue = value
                        OptimizedInvalidate(old, dragValue)
                    End If
                    
                End If
                
            End If
            
        End Sub

    End Class
    
End Namespace

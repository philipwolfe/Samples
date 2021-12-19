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
Imports System.WinForms
Imports System.Drawing

Namespace Microsoft.Samples.WinForms.VB.SimpleControl 

    Public Class _
        <DefaultProperty("DrawingMode"), DefaultEvent("DrawingModeChanged")> _
        SimpleControl 
        
        Inherits RichControl 

        Private myDrawingMode As DrawingModeStyle

        '*** Constructors

        Public Sub New() 
            MyBase.New
                         
            'Initialise drawingMode
            myDrawingMode = DrawingModeStyle.Happy
            
            'Initialise BackColor and ForeColor based on DrawingMode
            SetColors

            'Make sure the control repaints as it is resized
            SetStyle(ControlStyles.ResizeRedraw, True)
            
        End Sub


        '*** Properties

        'Remove the BackColor property from the property browser
        Overrides Public Property <Browsable(false)> BackColor As Color 
            Get
                return MyBase.BackColor
            End Get
            
            Set
                'No Action
            End Set
            
        End Property 


        'DrawingMode - controls how the control paints
        Public Property _
        <Category("Appearance"), _
         Description("Controls how the control paints"), _
         DefaultValue(DrawingModeStyle.Happy), _
         Bindable(true)> _
        DrawingMode As DrawingModeStyle
            
            Get 
                return myDrawingMode
            End Get
            
            Set
                myDrawingMode=value
 
                'Set BackColor and ForeColor based on DrawingMode
                SetColors
 
                'Raise property changed event for DrawingMode
                RaisePropertyChangedEvent("DrawingMode")
                
            End Set 
            
        End Property

                                                                
        'Remove the ForeColor property from the property browser 
        Overrides Public Property <Browsable(false)> ForeColor As Color 
            Get
                return MyBase.ForeColor
            End Get
            
            Set
                'No Action
            End Set
            
        End Property 
 
 
 
        '*** Events
 
        'Handle the paint event
        Overrides Protected Sub OnPaint(e As PaintEventArgs) 
 
            e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle)
 
            Dim textSize As SizeF = e.Graphics.MeasureString(Me.Text, Font)
 
            Dim xPos As Single = CSng((ClientRectangle.Width/2) - (textSize.Width/2))
            Dim yPos As Single = CSng((ClientRectangle.Height/2) - (textSize.Height/2))
 
            e.Graphics.DrawString(Me.Text, Font,new SolidBrush(ForeColor),xPos, yPos)
 
        End Sub
 
 
        'Catch property changed event for DrawingMode to fire DrawingMoe changed 
        'and repaint the control
        Overrides Protected Sub OnPropertyChanged(e As PropertyChangedEventArgs) 
            MyBase.OnPropertyChanged(e)
            Dim d as string = e.PropertyName
 
            If (d.Equals("DrawingMode")) Then
                OnDrawingModeChanged(EventArgs.Empty)
            End If 
            
        End Sub 
 
       'DrawingModeChanged Event
        Public Event _
            <Description("Raised when the DrawingMode changes")> _
        DrawingModeChanged(sender As Object, ev As EventArgs) 'As EventHandler
 
        Overridable Protected Sub OnDrawingModeChanged(e As EventArgs) 
            Invalidate
            RaiseEvent DrawingModeChanged(Me, e)
        End Sub
 
        'Set the ForeColor and BackColor based on the value of DrawingMode
        Private Sub SetColors() 
 
            Select Case myDrawingMode
 
               Case DrawingModeStyle.Happy
                   MyBase.BackColor = Color.Yellow 
                   MyBase.ForeColor = Color.Green 
                    
               Case DrawingModeStyle.Sad
                   MyBase.BackColor = Color.LightSlateGray 
                   MyBase.ForeColor = Color.White 
 
              Case DrawingModeStyle.Angry
                  MyBase.BackColor = Color.Red 
                  MyBase.ForeColor = Color.Teal 
 
              Case Else
                   MyBase.BackColor = Color.Black 
                   MyBase.ForeColor = Color.White 
                   
           End Select
 
        End Sub
        
    End Class
    
End Namespace

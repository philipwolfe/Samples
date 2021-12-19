'=====================================================================
'  File:      OwnerDrawListBox.vb
'
'  Summary:   This sample demonstrates the properties and features
'             of the ListBox control.
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.
'
'  Copyright (C) 1999 Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================*/

Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.WinForms

Option Explicit
Option Strict Off

Namespace OwnerDrawListBox 

    ' <doc>
    ' <desc>
    '     This sample control demonstrates various properties and
    '     methods for the ListBox control.  
    ' </desc>
    ' </doc>
    '
    Public Class OwnerDrawListBox
    Inherits Form 
        
        'Used to paint the list box
        Private listBoxBrushes() As Brush
        Private listBoxHeights() As Integer = {50, 25, 33, 15} 

        ' <doc>
        ' <desc>
        '     Public Constructor
        ' </desc>
        ' </doc>
        '
        Public Sub New()
	    MyBase.New()

            ' This call is required for support of the Win Forms Form Designer.
            InitializeComponent()

            'Set up the brushes we are going to use
                        
            'Load the image to be used for the background from the exe's resource fork
            'Dim backgroundImage As Image = new Bitmap(OwnerDrawListBox.GetType, "colorbars.jpg")
            Dim backgroundImage As Image = new Bitmap("colorbars.jpg")

            'Now create the brush we are going to use to paint the background
            Dim backgroundBrush As Brush = new TextureBrush(backgroundImage)
            'Dim r As Rectangle = new Rectangle { 0, 0, listBox1.Width, 100 }
	    Dim r As Rectangle
	    r.x = 0
            r.y = 0
            r.Width = listBox1.Width
	    r.Height = 100
            Dim lb As new LinearGradientBrush(r, Color.Red, Color.Yellow,LinearGradientMode.Horizontal)


            listBoxBrushes = new Brush() { backgroundBrush, Brushes.LemonChiffon, lb, Brushes.PeachPuff }

        End Sub

        ' <doc>
        ' <desc>
        '     OwnerDrawListBox overrides dispose so it can clean up the
        '     component list.
        ' </desc>
        ' </doc>
        '
        Overrides Public Sub Dispose() 
            myBase.Dispose()
            components.Dispose()
        End Sub

        Private Sub listBox1_DrawItem(sender As Object, e As DrawItemEventArgs)
            
            ' The following method should generally be called before drawing.
            ' It is actually superfluous here, since the subsequent drawing
            ' will completely cover the area of interest.
            e.DrawBackground()
            
            'The system provides the context
            'into which the owner custom-draws the required graphics.
            'The context into which to draw is e.graphics.
            'The index of the item to be painted is e.Index.
            'The painting should be done into the area described by e.Bounds.
            Dim brush As Brush = listBoxBrushes(e.Index)
            e.Graphics.FillRectangle(brush, e.Bounds)
            e.Graphics.DrawRectangle(SystemPens.WindowText, e.Bounds)
            
            Dim selected As Boolean = (e.State BitAnd DrawItemState.Selected) 
               
            Dim displayText As String = "ITEM #" & e.Index
	    If selected Then
            	displayText = displayText & " SELECTED"
	    End If

	    Dim r As RectangleF ' this is needed because e.Bound is of type Rectangle
	    r.x = e.Bounds.x
	    r.y = e.Bounds.y
	    r.Width = e.Bounds.Width
	    r.Height = e.Bounds.Height
            e.Graphics.DrawString(displayText, Me.Font, Brushes.Black, r)

            e.DrawFocusRectangle()
        End Sub

        'Return the height of the item to be drawn
        Private Sub listBox1_MeasureItem(sender As Object, e As MeasureItemEventArgs)
            
            'Work out what the text will be
            Dim displayText As String = "ITEM #" & e.Index

            'Get widht & height of string
            Dim stringSize As SizeF = e.Graphics.MeasureString(displayText, Me.Font)

            'Now set height to taller of default and text height
            If (listBoxHeights(e.Index) > stringSize.Height) Then
                e.ItemHeight = listBoxHeights(e.Index)
            Else 
                e.ItemHeight = stringSize.Height
	    End If

        End Sub

        ' NOTE: The following code is required by the Win Forms Form Designer
        ' It can be modified using the Win Forms Form Designer.  
        ' Do not modify it using the code editor.
        Private components As System.ComponentModel.Container 
        Private listBox1 As ListBox

        Private Sub InitializeComponent() 
		Me.components = new System.ComponentModel.Container()
		Me.listBox1 = new ListBox()
		
		Me.TabIndex = 0
		Me.Size = new System.Drawing.Size(300, 320)
		Me.Text = "ListBox"
        	Me.Font = new Font("Lucida Sans Unicode", 12)
		
		listBox1.ForeColor = SystemColors.WindowText
		listBox1.Location = new System.Drawing.Point(8, 24)
		listBox1.IntegralHeight = false
		listBox1.TabIndex = 0
		listBox1.UseTabStops = true
        	listBox1.Size = new System.Drawing.Size(232, 200)
		listBox1.ColumnWidth = 144
		listBox1.AddOnMeasureItem(new MeasureItemEventHandler(AddressOf listBox1_MeasureItem))
		listBox1.AddOnDrawItem(new DrawItemEventHandler(AddressOf listBox1_DrawItem))
        	listBox1.DrawMode=DrawMode.OwnerDrawVariable
		listBox1.Items.All = new object() {"First", "Second", "Third", "Fourth"}
		
		Me.Controls.Add(listBox1)
	End Sub

        ' The main entry point for the application.
        Public Shared Sub Main() 
            Application.Run(new OwnerDrawListBox())
        End Sub
    End Class

End Namespace






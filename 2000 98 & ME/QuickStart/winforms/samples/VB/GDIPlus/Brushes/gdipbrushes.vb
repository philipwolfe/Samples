'//------------------------------------------------------------------------------
'/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'///       
'///    This source code is intended only as a supplement to Microsoft
'///    Development Tools and/or on-line documentation.  See these other
'///    materials for detailed information regarding Microsoft code samples.
'///
'/// </copyright>                                                                
'//------------------------------------------------------------------------------
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.WinForms
Imports System.Drawing.Drawing2D

Namespace Microsoft.Samples.WinForms.VB.GDIPlus.GDIPBrushes 

Public Class BrushesSample 
    Inherits System.WinForms.Form 

    Shared Sub Main() 
        System.WinForms.Application.Run(new BrushesSample())
    End Sub
    
    
    Private backgroundBrush As System.Drawing.Brush
    
    Public Sub New()
        MyBase.New 
        SetStyle(ControlStyles.Opaque, true)
        Me.Size = new Size(450, 400)
        Me.Text = "GDI+ Brush Samples"
        
        '//Load the image to be used for the background from the exe's resource fork
        Dim backgroundImage As Image = new Bitmap(gettype(BrushesSample), "colorbars.jpg")
        
        '//Now create the brush we are going to use to paint the background
        backgroundBrush = new TextureBrush(backgroundImage)
    End Sub
    
    overrides protected Sub OnPaint(e as PaintEventArgs) 
        
        Dim g as Graphics = e.Graphics
        
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        
        '//Fill the background use the texture brush 
        '//and then apply a white wash 
        g.FillRectangle(backgroundBrush, ClientRectangle)
        g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle)
        
        '//Add a Red rectangle and a yellow one that overlaps it
        g.FillRectangle(new SolidBrush(Color.Red), 20, 20, 50, 50)
        g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.Yellow)), 40, 40, 50, 50)
        
        '//Add a circle that is filled with a translucent hatch 
        Dim hb as HatchBrush = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Green, Color.FromARGB(100, Color.Yellow))
        g.FillEllipse(hb, 250, 10, 100, 100)
        
        
        '//Now create a rectangle filled with a gradient brush
        Dim r as Rectangle = new Rectangle(300, 250, 100, 100)
        Dim lb as LinearGradientBrush = new LinearGradientBrush(r, Color.Red, Color.Yellow,LinearGradientMode.BackwardDiagonal)
        g.FillRectangle(lb, r)
        
        '//Now add a shape drawn with a path gradient brush
        
        
        Dim  path as GraphicsPath
        
        path= new GraphicsPath(new Point(){new Point(40, 140), new Point(275, 200), new Point(105, 225), _
        new Point(190, 300), new Point(50, 350), new Point(20, 180)}, _
        new byte(){ CType(PathPointType.Start,Byte), CType(PathPointType.Bezier,Byte), CType(PathPointType.Bezier,Byte), _
        CType(PathPointType.Bezier,Byte), CType(PathPointType.Line,Byte), CType(PathPointType.Line,Byte)})
        
        
        Dim pgb as PathGradientBrush = new PathGradientBrush(path)
        pgb.SurroundColors = new Color() {Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Orange, Color.White}  
        
        g.FillPath(pgb, path)
        
        '//Now add a simple rectangle that has been rotated 
        g.RotateTransform(-30)
        g.FillRectangle(new SolidBrush(Color.SlateBlue), 100, 250, 75, 100)
        g.ResetTransform()
        
    End Sub

End Class

End Namespace

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
Imports System.WinForms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D

namespace Microsoft.Samples.WinForms.VB.GDIPlus.GDIPPens 
    public class PensSample
        Inherits System.WinForms.Form

        private backgroundBrush As Brush
        private penTextureBrush As Brush

        shared Sub Main()
            System.Winforms.Application.Run(new PensSample())
        End Sub
        
        public Sub New() 
            MyBase.New()
            SetStyle(ControlStyles.Opaque, true)
            Me.Size = new Size(750, 500)
            Me.Text = "GDI+ Brush Samples"

            '//Load the image to be used for the background from the exe's resource fork
            Dim backgroundImage As Image = new Bitmap(GetType(PensSample), "colorbars.jpg")

            '//Now create the brush we are going to use to paint the background
            backgroundBrush = new TextureBrush(backgroundImage)

            '//Load the image to be used for the textured pen from the exe's resource fork
            Dim penImage As Image = new Bitmap(GetType(PensSample), "BoilingPoint.jpg")
            penTextureBrush = new TextureBrush(penImage)
        End Sub

        protected overrides Sub OnPaint(e as PaintEventArgs) 
            
            dim g as Graphics = e.Graphics

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            '//Fill the background use the texture brush 
            '//and then apply a white wash 
            g.FillRectangle(backgroundBrush, ClientRectangle)
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle)

            '//Create a pen 20 pixels wide that is and purple and partially transparent 
            Dim penExample1 As Pen = new Pen(Color.FromARGB(150, Color.Purple), 20)
            
            '//Make it a dashed pen
            penExample1.DashStyle = DashStyle.Dash
            
            '//Make the ends round
            penExample1.StartCap = LineCap.Round
            penExample1.EndCap = LineCap.Round

            '//Now draw a curve Imports the pen 
            g.DrawCurve(penExample1, New Point(){new Point(200, 140),new Point(700, 240),new Point(500, 340),new Point(140, 140),new Point(40, 340)})

            '//Now draw a line Imports a bitmap as the fill 
            Dim penExample2 As Pen = new Pen(penTextureBrush, 25)
            penExample2.DashStyle = DashStyle.DashDotDot
            penExample2.StartCap = LineCap.Triangle
            penExample2.EndCap = LineCap.Round
            g.DrawLine(penExample2, 10,450,550,400)

        End Sub

    End Class
End Namespace
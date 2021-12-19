//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.GDIPlus.GDIPPens {
    using System;
    using System.WinForms;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class PensSample : Form {

        private Brush backgroundBrush;
        private Brush penTextureBrush;

        public PensSample() {
            SetStyle(ControlStyles.Opaque, true);
            Size = new Size(750, 500);
            Text = "GDI+ Brush Samples";

            //Load the image to be used for the background from the exe's resource fork
            Image backgroundImage = new Bitmap(typeof(PensSample), "colorbars.jpg");

            //Now create the brush we are going to use to paint the background
            backgroundBrush = new TextureBrush(backgroundImage);

            //Load the image to be used for the textured pen from the exe's resource fork
            Image penImage = new Bitmap(typeof(PensSample), "BoilingPoint.jpg");
            penTextureBrush = new TextureBrush(penImage);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //Fill the background use the texture brush 
            //and then apply a white wash 
            g.FillRectangle(backgroundBrush, ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle);

            //Create a pen 20 pixels wide that is and purple and partially transparent 
            Pen penExample1 = new Pen(Color.FromARGB(150, Color.Purple), 20);
            //Make it a dashed pen
            penExample1.DashStyle = DashStyle.Dash;
            //Make the ends round
            penExample1.StartCap = LineCap.Round;
            penExample1.EndCap = LineCap.Round;

            //Now draw a curve using the pen 
            g.DrawCurve(penExample1, new Point[] {
                                                 new Point(200, 140),
                                                 new Point(700, 240),
                                                 new Point(500, 340),
                                                 new Point(140, 140),
                                                 new Point(40, 340),
                                                 });


            //Now draw a line using a bitmap as the fill 
            Pen penExample2 = new Pen(penTextureBrush, 25);
            penExample2.DashStyle = DashStyle.DashDotDot;
            penExample2.StartCap = LineCap.Triangle;
            penExample2.EndCap = LineCap.Round;
            g.DrawLine(penExample2, 10,450,550,400);

        }

        public static void Main() {
            Application.Run(new PensSample());
        }
    }
}

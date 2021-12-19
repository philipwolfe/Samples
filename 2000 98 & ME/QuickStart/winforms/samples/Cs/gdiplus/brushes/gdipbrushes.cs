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
namespace Microsoft.Samples.WinForms.Cs.GDIPlus.GDIPBrushes {
    using System;
    using System.WinForms;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class BrushesSample : Form {

        private Brush backgroundBrush;

        public BrushesSample() {
            SetStyle(ControlStyles.Opaque, true);
            Size = new Size(450, 400);
            Text = "GDI+ Brush Samples";

            //Load the image to be used for the background from the exe's resource fork
            Image backgroundImage = new Bitmap(typeof(BrushesSample), "colorbars.jpg");

            //Now create the brush we are going to use to paint the background
            backgroundBrush = new TextureBrush(backgroundImage);
        }

        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //Fill the background use the texture brush 
            //and then apply a white wash 
            g.FillRectangle(backgroundBrush, ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle);

            //Add a Red rectangle and a yellow one that overlaps it
            g.FillRectangle(new SolidBrush(Color.Red), 20, 20, 50, 50);
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.Yellow)), 40, 40, 50, 50);
                
            //Add a circle that is filled with a translucent hatch 
            HatchBrush hb = new HatchBrush(HatchStyle.ForwardDiagonal, Color.Green, Color.FromARGB(100, Color.Yellow));
            g.FillEllipse(hb, 250, 10, 100, 100);

            //Now create a rectangle filled with a gradient brush
            Rectangle r = new Rectangle(300, 250, 100, 100);
            LinearGradientBrush lb = new LinearGradientBrush(r, Color.Red, Color.Yellow,LinearGradientMode.BackwardDiagonal);
            g.FillRectangle(lb, r);

            //Now add a shape drawn with a path gradient brush
            GraphicsPath path = new GraphicsPath(new Point[] {
                new Point(40, 140),
                new Point(275, 200),
                new Point(105, 225),
                new Point(190, 300),
                new Point(50, 350),
                new Point(20, 180),
                }, new byte[] {
                    (byte)PathPointType.Start,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Bezier,
                    (byte)PathPointType.Line,
                    (byte)PathPointType.Line,
                    });

            PathGradientBrush pgb = new PathGradientBrush(path);
            pgb.SurroundColors = new Color[] {
                Color.Green,
                Color.Yellow,
                Color.Red,
                Color.Blue,
                Color.Orange,
                Color.White,
            };  

            g.FillPath(pgb, path);


            //Now add a simple rectangle that has been rotated 
            g.RotateTransform(-30);
            g.FillRectangle(new SolidBrush(Color.SlateBlue), 100, 250, 75, 100);
            g.ResetTransform();
        }

        public static void Main() {
            Application.Run(new BrushesSample());
        }
    }
}

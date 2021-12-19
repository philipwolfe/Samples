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
namespace Microsoft.Samples.WinForms.Cs.GDIPlus.GDIPImages {
    using System;
    using System.WinForms;
    using System.IO;
    using System.Net;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public class ImagesSample : Form {

        private Brush backgroundBrush;
        private Image sample1;
        private Image webLogo;
        private Image createdImage;

        public ImagesSample() {
            SetStyle(ControlStyles.Opaque, true);
            Size = new Size(750, 500);
            Text = "GDI+ Brush Samples";

            //Load the image to be used for the background from the exe's resource fork
            Image backgroundImage = new Bitmap(typeof(ImagesSample), "colorbars.jpg");

            //Now create the brush we are going to use to paint the background
            backgroundBrush = new TextureBrush(backgroundImage);

            //Now load the other images we are going to use
            sample1 = new Bitmap("sample.jpg");

            //Load an image from the web and display that - if it fails load one from a local resource
            try {
                WebRequest request = WebRequestFactory.Create("http://localhost/quickstart/winforms/images/winforms.gif");
                request.Credentials = CredentialCache.DefaultCredentials;

                Stream source = request.GetResponse().GetResponseStream();
                MemoryStream ms = new MemoryStream();

                byte[] data = new byte[256];
                int c = source.Read(data, 0, data.Length);

                while (c > 0) {
                    ms.Write(data, 0, c);
                    c = source.Read(data, 0, data.Length);
                }

                source.Close();
                ms.Position = 0;
                webLogo = new Bitmap(ms);

            } catch(Exception ex) {
                MessageBox.Show("Failed to load Image from the Web- using default image\n\n " + ex.Message + " \n\n" + ex.StackTrace, "Error");
                webLogo = sample1;
            }

            //Finally add a button so that we can render to a bitmap
            Button button1 = new Button();
            button1.Size=new Size(100,50);
            button1.Location=new Point(600,20);
            button1.Text="Draw a bitmap to a file";
            button1.Click += new EventHandler(DrawImage);
            this.Controls.Add(button1);

        }

        //Fired when the button is pressed
        private void DrawImage(object sender, EventArgs e) {
            
            Bitmap newBitmap = null;
            Graphics g = null ;
            
            try {
                newBitmap = new Bitmap(800,600,PixelFormat.Format32bppARGB);
                g = Graphics.FromImage(newBitmap);
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0,0,800,600));

                Font textFont = new Font("Times New Roman", 12);
                RectangleF rectangle = new RectangleF(100, 100, 250, 350); 
                string flowedText="I went down to the St James Infirmary,\nSaw my baby there,\nStretched out on a long white table,\nSo sweet,so cold,so fair,\nLet her go,let her go,God bless her,\nWherever she may be,\nShe can look this wide world over,\nBut she'll never find a sweet man like me,\nWhen I die want you to dress me in straight lace shoes,\nI wanna a boxback coat and a Stetson hat,\nPut a twenty dollar gold piece on my watch chain,\nSo the boys'll know that I died standing up.";

                g.FillRectangle(new SolidBrush(Color.Gainsboro), rectangle);
                g.DrawString(flowedText, textFont, new SolidBrush(Color.Blue), rectangle);
                Pen penExample = new Pen(Color.FromARGB(150, Color.Purple), 20);
                penExample.DashStyle = DashStyle.Dash;
                penExample.StartCap = LineCap.Round;
                penExample.EndCap = LineCap.Round;
                g.DrawCurve(penExample, new Point[] {
                            new Point(200, 140),
                            new Point(700, 240),
                            new Point(500, 340),
                            new Point(140, 140),
                            new Point(40, 340),
                            });

                newBitmap.Save("TestImage.png", ImageFormat.PNG) ;
    
                MessageBox.Show("Done - image written to TestImage.png");

                //Add image to paint and repaint
                createdImage = newBitmap;
                this.Invalidate();
            
            } finally {

                //Note well: Must dispose of graphics object
                //before disposing of the bitmap

                //Dispose of the graphics object we created
                //as its no longer needed
                if (null != g) {
                    g.Dispose();
                }

                //Typically we'd dispose of the bitmap here
                //but as we're going to display it on the 
                //form don't dispose of it
                // if (null != newBitmap) {
                //     newBitmap.Dispose();
                // }
            }

        }


        protected override void OnPaint(PaintEventArgs e) {
            Graphics g = e.Graphics;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //Fill the background use the texture brush 
            //and then apply a white wash 
            g.FillRectangle(backgroundBrush, ClientRectangle);
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle);

            //Simply render an image
            g.DrawImage(sample1, 29, 20, 283, 212);

            //Now rotate and image and display it
            g.RotateTransform(-30);
            g.DrawImage(webLogo, 175, 420);
            g.ResetTransform();

            //Finally draw the image we created if there is one
            if (createdImage != null) {
                g.DrawImage(createdImage, 50, 200, 200, 200);
            }
        }

        public static void Main() {
            Application.Run(new ImagesSample());
        }
    }
}

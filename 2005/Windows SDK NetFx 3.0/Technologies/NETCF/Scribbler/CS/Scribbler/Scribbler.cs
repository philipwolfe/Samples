/*=====================================================================
  File:      Scribbler.cs

  Summary:   Simple scribbling pad

  ---------------------------------------------------------------------
  This file is part of the Microsoft .NET Framework SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

  This source code is intended only as a supplement to Microsoft
  Development Tools and/or on-line documentation.  See these other
  materials for detailed information regarding Microsoft code samples.

  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Microsoft.Samples.Scribbler
{
    // Color swatch tray
    
    public class Tray: Control
    {
        public delegate void OnCmdEventHandler();
        
        // Swatch
        
        private class Swatch
        {
            private const int MarginSize = 4;
            
            private Color colorValue;
            private Rectangle boundsValue;
            private string caption;
            private OnCmdEventHandler cmdEventHandler;
            private bool isCmdValue;
            private Font font;
            
            public Swatch(Color colorValue, Rectangle boundsValue)
            {
                this.colorValue = colorValue;
                this.boundsValue = boundsValue;
                this.caption = "";
                this.font = new Font(FontFamily.GenericSansSerif, 8,
                                     FontStyle.Bold);
                
                this.isCmdValue = false;
            }
            
            public Swatch(string caption, Rectangle boundsValue,
                          OnCmdEventHandler cmdEventHandler)
            {
                if (caption == null)
                    throw(new ArgumentException("'caption' should not be null."));

                if (cmdEventHandler == null)
                    throw(new ArgumentException("Event handler must not be empty."));

                this.colorValue = System.Drawing.Color.White;
                this.caption = caption;
                this.boundsValue = boundsValue;
                this.cmdEventHandler = cmdEventHandler;
                this.font = new Font(FontFamily.GenericSansSerif, 8,
                                     FontStyle.Bold);
                
                this.isCmdValue = true;
            }
            
            public void Display(Graphics drawingSurface, bool isSelected)
            {   
                Rectangle frame;
                int left, top;
                int textWidth, textHeight;
                Color frameColor;
                
                frame = this.boundsValue;
                frame.Inflate(-Swatch.MarginSize, -Swatch.MarginSize);
                
                drawingSurface.FillRectangle(new SolidBrush(this.colorValue), frame);
    
                // Caption
                
                textWidth = (int)drawingSurface.MeasureString(this.caption, this.font).Width;
                textHeight = (int)drawingSurface.MeasureString(this.caption, this.font).Height;
                
                left = frame.X + (frame.Width - textWidth) / 2;
                top = frame.Y + (frame.Height - textHeight) / 2;
                
                drawingSurface.DrawString(this.caption, this.font,
                              new SolidBrush(System.Drawing.Color.Black), left, top);
                
                // Frame
                
                
                frameColor = System.Drawing.Color.Black;
                
                drawingSurface.DrawRectangle(new Pen(frameColor), frame);
                if (isSelected)
                {
                    // We'll draw an outer rectangle (2 pixels wide) to show
                    // the selected color.
                    frame.Inflate(2, 2);
                    drawingSurface.DrawRectangle(new Pen(frameColor), frame);
                    
                    frame.Inflate(1, 1);
                    drawingSurface.DrawRectangle(new Pen(frameColor), frame);
                }
            }
            
            public Color Color
            {
                get { return(this.colorValue); }
            }
            
            public Rectangle Bounds
            {
                get { return(this.boundsValue); }
            }
            
            public void DoCmd()
            {
                if (this.isCmdValue && this.cmdEventHandler != null)
                    this.cmdEventHandler();
            }
            
            public bool IsCmd
            {
                get { return(this.isCmdValue); }
            }
        }
        
        private const int SwatchWidth = 26;
        private const int CommandWidth = 48;
        private int height;
        private ArrayList swatchList = new ArrayList();
        private int selectedSwatch;
        private Bitmap offscreenBitmap;         
        private Graphics offscreenDrawingSurface;     
        private bool isInitialized;
    
        public Tray(Form parentForm, int width, int height)
        {
            isInitialized = false;

            this.BackColor = System.Drawing.Color.SlateGray;
            this.Parent = parentForm;
            this.Left = 0;
            this.Top = 0;
            this.ClientSize = new Size(width, height);
            this.Visible = true;
            
            this.height = height;
            this.selectedSwatch = 0;
            this.offscreenBitmap = new Bitmap(width, height);
            if (this.offscreenBitmap != null)
                this.offscreenDrawingSurface = Graphics.FromImage(offscreenBitmap);

            isInitialized = ((offscreenBitmap != null) &&
                            (offscreenDrawingSurface != null));
        }

        public bool Initialized
        {
            get
            {
                return(this.isInitialized);
            }
        }
        
        public void AddColorSwatch(Color colorValue)
        {
            int x, y;
            int width, height;
            
            // Calculate horizontal extent of current swatches
            x = 0;
            foreach (Swatch swatch in this.swatchList)
                x += swatch.Bounds.Width;
            y = 0;
            width = Tray.SwatchWidth;
            height = this.height;
            
            this.swatchList.Add(new Swatch(colorValue,
                                           new Rectangle(x,
                                                         y,
                                                         width,
                                                         height)));
            this.Invalidate();
        }
        
        public void AddCmd(string caption, OnCmdEventHandler cmdEventHandler)
        {
            int left, top;
            int width, height;
    
            // Calculate horizontal extent of current swatches
            left = 0;      
            foreach (Swatch swatch in this.swatchList)
                left += swatch.Bounds.Width;
            top = 0;
            width = Tray.CommandWidth;
            height = this.height;
            
            this.swatchList.Add(new Swatch(caption,
                                           new Rectangle(left,
                                                         top,
                                                         width,
                                                         height),
                                           cmdEventHandler));
            this.Invalidate();
        }
        
        public Color CurrentColor
        {
            get
            {
                return(((Swatch)this.swatchList[this.selectedSwatch]).Color);
            }
        }
        
        protected override void OnPaint(PaintEventArgs paintArgs)
        {
            Graphics drawingSurface;
            int i;
            Swatch swatch;
            bool isSelected;
            
            if (this.offscreenDrawingSurface != null)
            {
                Brush brush = new SolidBrush(this.BackColor);
                if (brush != null)
                    this.offscreenDrawingSurface.FillRectangle(brush,
                                                         0,
                                                         0,
                                                         ClientSize.Width,
                                                         ClientSize.Height);
            }
            
            drawingSurface = this.offscreenDrawingSurface;
    
            if (drawingSurface != null)
            {
                for (i = 0; i < this.swatchList.Count; i++)
                {
                    swatch = (Swatch)this.swatchList[i];

                    isSelected = (i == this.selectedSwatch);

                    swatch.Display(drawingSurface, isSelected);
                }
            }
            
            paintArgs.Graphics.DrawImage(this.offscreenBitmap, 0, 0);
        }
    
        protected override void OnPaintBackground(PaintEventArgs paintArgs)
        {
            // Do nothing, don't paint background
        }
    
        protected override void OnMouseDown(MouseEventArgs mouseArgs)
        {
            int i;
            Swatch swatch;
                    
            for (i = 0; i < this.swatchList.Count; i++)
            {
                swatch = (Swatch)this.swatchList[i];
                
                if (swatch.Bounds.Contains(mouseArgs.X, mouseArgs.Y))
                {
                    if (swatch.IsCmd)
                    {
                        swatch.DoCmd();
                        this.Invalidate();
                    }
                    else
                    {
                        Invalidate(((Swatch)this.swatchList[this.selectedSwatch]).Bounds);
                        this.selectedSwatch = i;
                        Invalidate(((Swatch)this.swatchList[this.selectedSwatch]).Bounds);
                    }
                    
                    break;
                }
            }
        }
    }
    
    // Scribbler application window
    
    public class ScribblerForm: Form
    {
        private const int TrayHeight = 20;
        
        private int maxWidth;
        private int maxHeight;
        private Graphics drawingSurface;
        private Bitmap bitmap;
        private bool hasCapture;
        private int oldX, oldY;
        private Tray tray;
        private bool isInitialized;

        private MainMenu scribblerMenu;
        private MenuItem fileMenu;
        private MenuItem exitMenuItem;

        public ScribblerForm()
        {
            this.isInitialized = false;

            this.maxWidth = this.ClientSize.Width;
            this.maxHeight = this.ClientSize.Height;
            
            this.BackColor = System.Drawing.Color.White;
            this.hasCapture = false;
            this.Text = "Scribbler";
            this.scribblerMenu = new MainMenu();
            this.fileMenu = new MenuItem();
            this.fileMenu.Text = "&File";
            this.exitMenuItem = new MenuItem();
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += ExitMenuItem_Click;
            this.fileMenu.MenuItems.Add(this.exitMenuItem);
            this.scribblerMenu.MenuItems.Add(this.fileMenu);
            this.Menu = this.scribblerMenu;
            
            // Create offscreen drawing surface
            
            this.bitmap = new Bitmap(this.maxWidth, this.maxHeight);
            if (this.bitmap != null)
            {
                this.drawingSurface = Graphics.FromImage(this.bitmap);

                if (this.drawingSurface != null)
                    this.drawingSurface.FillRectangle(new SolidBrush(System.Drawing.Color.White),
                                                0,
                                                0,
                                                this.maxWidth,
                                                this.maxHeight);
            }
            
            // Create tray
            
            this.tray = new Tray(this, this.maxWidth, ScribblerForm.TrayHeight);
            
            if ((this.tray != null) && (this.tray.Initialized))
            {
                // Add color swatches to tray

                this.tray.AddColorSwatch(System.Drawing.Color.Black);
                this.tray.AddColorSwatch(System.Drawing.Color.Red);
                this.tray.AddColorSwatch(System.Drawing.Color.Tomato);
                this.tray.AddColorSwatch(System.Drawing.Color.Yellow);
                this.tray.AddColorSwatch(System.Drawing.Color.Magenta);
                this.tray.AddColorSwatch(System.Drawing.Color.Blue);
                this.tray.AddColorSwatch(System.Drawing.Color.Green);

                // Add "Clear" command to tray

                this.tray.AddCmd("Clear", new Tray.OnCmdEventHandler(OnErase));
            }

            this.isInitialized = ((this.bitmap != null) &&
                                 (this.drawingSurface != null) &&
                                 (this.tray != null) &&
                                 this.tray.Initialized);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool Initialized
        {
            get
            {
                return this.isInitialized;
            }
        }
    
        public void OnErase()
        {
            if (this.drawingSurface != null)
                this.drawingSurface.FillRectangle(new SolidBrush(System.Drawing.Color.White),
                                            0,
                                            0,
                                            this.maxWidth,
                                            this.maxHeight);

            this.Invalidate();
        }
        
        protected override void OnMouseDown(MouseEventArgs mouseArgs)
        {
            // Note mouse capture (in internal flag as well)
            this.hasCapture = true;
            this.Capture = true;
            
            this.oldX = mouseArgs.X;
            this.oldY = mouseArgs.Y;
        }
    
        protected override void OnMouseMove(MouseEventArgs mouseArgs)
        {
            int x, y;
                    
            if (this.hasCapture)
            {
                // Pull out coordinates for easier reference
                x = mouseArgs.X;
                y = mouseArgs.Y;
                
                // Draw line from last hit point to current hit point
                
                if (this.drawingSurface != null)
                {
                    Pen pen = new Pen(this.tray.CurrentColor);
                    if (pen != null)
                        this.drawingSurface.DrawLine(pen, this.oldX, this.oldY, x, y);
                }
    
                // The update rectangle needs to be normalized (i.e. left and
                // top actually on the left and top and width and height >= 0).
                this.Invalidate(new Rectangle(Math.Min(x, this.oldX),
                                              Math.Min(y, this.oldY),
                                              Math.Abs(this.oldX - x) + 1,
                                              Math.Abs(this.oldY - y) + 1));
                
                this.oldX = x;
                this.oldY = y;
            }
        }
        
        protected override void OnMouseUp(MouseEventArgs mouseArgs)
        {
            // Release mouse capture (including internal flag)
            this.hasCapture = false;
            this.Capture = false;
        }
        
        protected override void OnPaint(PaintEventArgs paintArgs)
        {
            if (this.bitmap != null)
                paintArgs.Graphics.DrawImage(this.bitmap, 0, 0);
        }
    
        protected override void OnPaintBackground(PaintEventArgs paintArgs)
        {
            // Do nothing, OnPaint will redraw the entire area
        }
    }
    
    // Application
    
    public class App
    {
        private App() {}

        public static void Main()
        {
            ScribblerForm scribbler;
            
            scribbler = new ScribblerForm();
            
            if (scribbler.Initialized)
                Application.Run(scribbler);
        }
    }
}

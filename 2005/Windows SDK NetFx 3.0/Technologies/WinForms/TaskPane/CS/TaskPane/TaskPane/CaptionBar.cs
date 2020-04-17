//=====================================================================
//  File:      CaptionBar.cs
//
//  Summary:   This is a package private class that actually implements
//             the caption bar across the top of individual TaskFrames
//             within the parent TaskPane container control.
//
//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;


namespace Microsoft.Samples.Windows.Forms.TaskPane
{


    //=------------------------------------------------------------------=
    // CaptionBar
    //=------------------------------------------------------------------=
    /// <summary>
    ///  this is a little private class to draw and manage the caption bars 
    ///   across the top of each TaskFrame within our pane control.
    /// </summary>
    /// //
    internal class CaptionBar : Control
    {

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Private Members/Structs/Consts
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        private const int CAPTIONBAR_PAD = 8;
        private const int COLLAPSE_BUTTON_DIAMETER = 16;

        /// 
        /// <summary>
        /// The TaskFrame panel to which we are tied
        /// </summary>
        private TaskFrame m_buddyFrame;

        /// 
        /// <summary>
        /// Is the user hovering the mouse over our client area?
        /// </summary>
        /// 
        private bool m_hovering;

        ///
        /// <summary>
        /// This is the height of our title bar area, excluding any icon/image
        /// peeking up over the top.
        /// </summary>
        /// 
        private int m_captionHeight;






        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                     Public Methods/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Initializes a new instance of this class.
        /// </summary>
        /// 
        /// <param name="in_buddyFrame">
        ///   the frame to which we are tied.
        /// </param>
        /// 
        public CaptionBar(TaskFrame in_buddyFrame)
        {
            System.Diagnostics.Debug.Assert(in_buddyFrame != null);

            this.m_buddyFrame = in_buddyFrame;
            this.m_hovering = false;
            
            //
            // Set us up for minimal flicker, max perf, and the ability
            // to draw the rounded corners (we need to be able to be 
            // transparent for that).
            //
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //
            // Make sure we don't bother sending this to the HWND, since it
            // will never see/use it.
            //
            SetStyle(ControlStyles.CacheText, true);

            //
            // Other values we just want to have set up properly.
            //
            this.BackColor = Color.Transparent;
        } 


        //=------------------------------------------------------------------=
        // Visible
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If somebody traipses through the collection of controls, finds
        ///   this one and forces a change on the Visible property, we want to
        ///   be sure that  our buddy TaskFrame goes too.
        /// </summary>
        ///
        public new bool Visible
        {
            get
            {
                return base.Visible;
            }

            set
            {
                setVisibleInternal(value);
                if (this.m_buddyFrame.Visible != value)
                {
                    this.m_buddyFrame.Visible = value;
                }
            }
        }


        //=------------------------------------------------------------------=
        // Enabled
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If somebody traipses through the collection of controls, 
        ///   finds this one and forces a change on the Enabled property,
        ///   we want to be sure that our buddy TaskFrame goes too.
        /// </summary>
        /// 
        /// <value>
        ///   are we enabled or not?
        /// </value>
        /// 
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            set
            {
                //
                // They will call our setEnabledInternal method ...
                //
                if (this.m_buddyFrame.Enabled != value)
                {
                    this.m_buddyFrame.Enabled = value;
                }
            }
        }


        //=------------------------------------------------------------------=
        // Font
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If somebody sets our font, we have to recompute our height, and
        ///   possibly relayout the entire control.
        /// </summary>
        /// 
        public new Font Font
        {
            get
            {
                return base.Font;
            }

            //
            // Set the new font if necessary, and then force a relayout
            //
            set
            {

                //
                // They will call our setFontInternal method ...
                //
                this.m_buddyFrame.Font = value;

            }
        }



        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //             Private/Protected/Friend Methods/Properties
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // CreateHandle
        //=------------------------------------------------------------------=
        /// <summary>
        /// Make sure we've got our sizes and all that jazz computed properly.
        /// </summary>
        /// 
        protected override void CreateHandle()
        {
            base.CreateHandle();
            recomputeSizes();
        }


        //=------------------------------------------------------------------=
        // recomputeSizes
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We have had something on us change what our size could 
        ///   possibly be. Go and recompute our total size now, and force
        ///   a relayout on the  container if necessary.
        /// </summary>
        /// 
        internal void recomputeSizes()
        {
            int imageHeight = 0;
            int fontHeight = 0;
            TaskPane tp;

            tp = (TaskPane)this.m_buddyFrame.Parent;

            //
            // Get the font height, and add enough so that it's rounded up for
            // sure
            //
            fontHeight = (int)(this.Font.GetHeight() + 0.5);

            //
            // Get the image height, capping it at 32
            //
            if (this.m_buddyFrame.Image != null)
            {
                imageHeight = this.m_buddyFrame.Image.Height;
            }

            if (imageHeight > 32)
            {
                imageHeight = 32;
            }
            if (imageHeight < 0)
            {
                imageHeight = 0;
            }

            //
            // Finally, take the greater of the imageheight or the font height.
            //
            setHeights(fontHeight, imageHeight);
        }


        //=------------------------------------------------------------------=
        // setHeights
        //=------------------------------------------------------------------=
        /// <summary>
        ///    Sets our various heights (total height, caption bar height, 
        ///    etc) from the given values computed earlier. 
        /// </summary>
        /// 
        /// <param name="in_fontHeight">
        ///   height of a line of text
        /// </param>
        /// 
        /// <param name="in_imageHeight">
        ///   height of our associated image
        /// </param>
        /// 
        private void setHeights(int in_fontHeight, int in_imageHeight)
        {
            TaskPane tp;

            tp = (TaskPane)this.m_buddyFrame.Parent;

            //
            // Allow for two pixels of padding on top and on the bottom.
            //
            if (in_imageHeight > this.FontHeight + CAPTIONBAR_PAD)
            {
                this.Height = in_imageHeight;
            }
            else
            {
                this.Height = this.FontHeight + CAPTIONBAR_PAD;
            }

            //
            // Save the caption height for later !!!
            //
            this.m_captionHeight = this.FontHeight + CAPTIONBAR_PAD;

            //
            // Finally, tell our parent control about this ...
            //
            if (tp != null)
            {
                if (tp.IsHandleCreated)
                {
                    tp.layoutAllFrames();
                }
            }
        }


        //=------------------------------------------------------------------=
        // setFontInternal
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Somebody has set the Font property on the TaskFrame, so ours
        ///   needs to be updated as well!
        /// </summary>
        /// 
        /// <param name="in_font">
        ///   New Value
        /// </param>
        /// 
        internal void setFontInternal(Font in_font)
        {
            if (in_font == null || !in_font.Equals(base.Font))
            {
                base.Font = in_font;
                if (this.IsHandleCreated) { recomputeSizes(); }
                this.Refresh();

            }
        }


        //=------------------------------------------------------------------=
        // setVisibleInternal
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Internal way to set the Visible bit without causing a
        ///   stack fault  by calling in and out of our buddy frame's
        ///   Visible property ...
        /// </summary>
        /// 
        /// <param name="in_newVisible">
        ///   New Value
        /// </param>
        /// 
        protected internal void setVisibleInternal(bool in_newVisible)
        {
            if (base.Visible != in_newVisible)
            {
                base.Visible = in_newVisible;
            }
        }


        //=------------------------------------------------------------------=
        // setEnabledInternal
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Internal way to set the Enabled bit without causing a
        ///   stack fault  by calling in and out of our buddy frame's
        ///   Enabled property ...
        /// </summary>
        /// 
        /// <param name="in_newVisible">
        ///   New Value
        /// </param>
        /// 
        protected internal void setEnabledInternal(bool in_newEnabled)
        {
            if (base.Enabled != in_newEnabled)
            {
                base.Enabled = in_newEnabled;
            }
        }


        //=------------------------------------------------------------------=
        // OnPaint
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Repaint our client area.
        /// </summary>
        /// 
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            System.Drawing.Drawing2D.LinearGradientBrush lgb;
            TaskPane tp;
            int top;
            Graphics g;
            int w;

            tp = (TaskPane)this.m_buddyFrame.Parent;
            g = e.Graphics;

            lgb = createGradientBrush();

            //
            // 1. Draw our caption area, which may be rounded or not ...
            //
            top = this.Height - this.m_captionHeight;
            if (getDrawCornersAsRounded(tp.CornerStyle))
            {
                g.FillRectangle(lgb, 2, top, this.Width - 4, 1);
                g.FillRectangle(lgb, 1, top + 1, this.Width - 2, 1);
                g.FillRectangle(lgb, 0, top + 2, this.Width, this.m_captionHeight - 2);

            }
            else
            {
                g.FillRectangle(lgb, new Rectangle(0, top, this.Width, 
                                                   this.m_captionHeight));
            }

            lgb.Dispose();


            //
            // 2. Draw the Focus Rect, if we've got it ...
            //
            drawFocusRect(g);

            //
            // 3. draw the icon.
            //
            w = drawIcon(g);

            //
            // 4. Draw the text
            //
            drawText(g, w);

            //
            // 5. Draw the collapse button
            //
            drawCollapseButton(g);
        }


        //=------------------------------------------------------------------=
        // drawFocusRect
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If applicable, draws a focus rect for us. 
        /// </summary>
        /// 
        private void drawFocusRect(Graphics g)
        {

            if (this.Focused == true)
            {
                Pen p;

                p = new Pen(colorFocusRect(), 1);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                g.DrawRectangle(p, 2, this.Height - this.m_captionHeight + 1, 
                                this.Width - 4, this.m_captionHeight - 4);
            }

        }


        //=------------------------------------------------------------------=
        // createGradientBrush
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Goes to our buddied TaskFrame, gets the appropriate
        ///   information, and creates a 
        ///   System.Drawing.Drawing2D.LinearGradientBrush based on the
        ///   information there.
        /// </summary>
        /// 
        private System.Drawing.Drawing2D.LinearGradientBrush 
            createGradientBrush()
        {
            bool reverse;

            reverse = MiscFunctions.GetRightToLeftValue(this.m_buddyFrame);

            return this.m_buddyFrame.CaptionBlend.GetLinearGradientBrush(new Rectangle(0, this.Height - this.m_captionHeight, this.Width, this.m_captionHeight), reverse);
        }


        //=------------------------------------------------------------------=
        // getDrawCornersAsRounded
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Figures out from the operating system whether or not we
        ///   should draw our corners as rounded or not.
        /// </summary>
        /// 
        /// <param name="in_style">
        ///   What the TaskPane's instructions here are
        /// </param>
        /// 
        /// <returns>
        ///   True means draw rounded corners.
        /// </returns>
        /// 
        private bool getDrawCornersAsRounded(TaskFrameCornerStyle in_style)
        {
            switch (in_style)
            {
                case TaskFrameCornerStyle.Rounded:
                    return true;

                case TaskFrameCornerStyle.Squared:
                    return false;

                case TaskFrameCornerStyle.SystemDefault:
                    return systemHasRoundedCorners();

                default:
                    return true;
            }
        }


        //=------------------------------------------------------------------=
        // drawIcon
        //=------------------------------------------------------------------=
        // 
        //
        // Parameters:
        //       Graphics        - [in]  Graphics Object with which to draw.
        //
        // Returns:
        //       Integer         - width of the image drawn.
        /// <summary>
        ///    Draws the Icon/Image for this CaptionBar, provided there 
        ///   is one to draw. 
        /// </summary>
        /// 
        /// <param name="g">
        ///     Where to draw.
        /// </param>
        /// 
        /// <returns>
        ///   Width of the image drawn.
        /// </returns>
        /// 
        private int drawIcon(Graphics g)
        {
            bool reverse;
            int w, h;
            TaskPane tp;
            Image img;

            //
            // If there's no image, this is easy!!!
            //
            if (this.m_buddyFrame.Image == null)
            {
                return 0;
            }

            reverse = MiscFunctions.GetRightToLeftValue(this.m_buddyFrame);

            // 
            // Get the Image dimensions so we can see if we need to scale or not
            //
            tp = (TaskPane)this.m_buddyFrame.Parent;
            img = this.m_buddyFrame.Image;
            w = img.Width;
            h = img.Height;

            if (w > 32) { w = 32; }
            if (h > 32) { h = 32; }

            //
            // now draw the image in the appropriate place.
            //
            if (reverse == false)
            {
                g.DrawImage(img, 0, 0, w, h);
            }
            else
            {
                g.DrawImage(img, this.Width - w - 1, 0, w, h);
            }

            return w;
        }


        //=------------------------------------------------------------------=
        // drawText
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Draws teh text for the caption bar.
        /// </summary>
        /// 
        /// <param name="g">
        ///   Where to draw.
        /// </param>
        /// 
        /// <param name="in_imgWidth">
        ///   Width of the image in the caption bar (or zero).
        /// </param>
        /// 
        private void drawText(Graphics g, int in_imgWidth)
        {
            RectangleF captionTextRect;
            Color textColor;
            bool reverse;
            StringFormat sf;
            int top;

            //
            // No Text?  E-Z.
            //
            if (string.IsNullOrEmpty(this.m_buddyFrame.Text))
            {
                return;
            }

            reverse = MiscFunctions.GetRightToLeftValue(this.m_buddyFrame);

            top = this.Height - this.m_captionHeight;

            //
            // get the bounding rect for the text
            //
            if (reverse == false)
            {
                captionTextRect = new RectangleF(in_imgWidth + 1, top, this.Width - 6 - COLLAPSE_BUTTON_DIAMETER - in_imgWidth - 1, this.m_captionHeight);
            }
            else
            {
                captionTextRect = new RectangleF(6 + COLLAPSE_BUTTON_DIAMETER, this.Height - this.m_captionHeight, this.Width - in_imgWidth - 6 - COLLAPSE_BUTTON_DIAMETER, this.m_captionHeight);
            }

            //
            // align the text vertically centered, and then RTL as appropriate
            //
            sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.NoWrap;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            if (MiscFunctions.GetRightToLeftValue(this.m_buddyFrame))
            {
                sf.FormatFlags = sf.FormatFlags | StringFormatFlags.DirectionRightToLeft;
            }

            if (this.m_hovering == false)
            {
                textColor = this.m_buddyFrame.ForeColor;
            }
            else
            {
                textColor = Color.Blue;
            }

            g.DrawString(this.m_buddyFrame.Text, this.m_buddyFrame.Font, new SolidBrush(textColor), captionTextRect, sf);
        }


        //=------------------------------------------------------------------=
        // drawCollapseButton
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Draws the Collapse button for this caption bar, if appropriate.
        /// </summary>
        /// 
        private void drawCollapseButton(Graphics g)
        {
            System.Drawing.Drawing2D.SmoothingMode sm;
            Rectangle buttonRect;
            bool reverse;
            Point baseLoc;
            int top;
            Point pt;
            Pen p;

            reverse = MiscFunctions.GetRightToLeftValue(this.m_buddyFrame);

            //
            // No CollapseButton?  Then we're done.
            //
            if (this.m_buddyFrame.CollapseButtonVisible == false) { return; }

            //
            // Set up a nice anti-aliased pen with which we will draw this.
            //
            sm = g.SmoothingMode;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            p = new Pen(colorCollapseButtonBorder(), 1.5f);

            //
            // figure out where to draw the circle.
            // 
            top = this.Height - this.m_captionHeight;
            if (reverse == false)
            {
                buttonRect = new Rectangle(this.Width - COLLAPSE_BUTTON_DIAMETER - 5, ((int)(top + (this.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1)), COLLAPSE_BUTTON_DIAMETER, COLLAPSE_BUTTON_DIAMETER);

                baseLoc = new Point(this.Width - COLLAPSE_BUTTON_DIAMETER - 5, ((int)(top + (this.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1)));

            }
            else
            {
                buttonRect = new Rectangle(5, ((int)(top + (this.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1)), COLLAPSE_BUTTON_DIAMETER, COLLAPSE_BUTTON_DIAMETER);

                baseLoc = new Point(5, ((int)(top + (this.m_captionHeight - COLLAPSE_BUTTON_DIAMETER) / 2 - 1)));
            }

            g.FillEllipse(new SolidBrush(this.m_buddyFrame.CaptionBlend.StartColor), buttonRect);
            g.DrawEllipse(p, buttonRect);
            p.Dispose();

            //
            // now draw the little chevrons
            //
            if (this.m_buddyFrame.IsExpanded == false)
            {
                p = new Pen(colorCollapseButtonChevrons(), 1.5f);
                pt = new Point(((int)(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2))), ((int)(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2))));
                g.DrawLine(p, pt, new Point(pt.X - 3, pt.Y - 3));
                g.DrawLine(p, pt, new Point(pt.X + 3, pt.Y - 3));
                pt = new Point(((int)(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2))), ((int)(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2) + 4)));
                g.DrawLine(p, pt, new Point(pt.X - 3, pt.Y - 3));
                g.DrawLine(p, pt, new Point(pt.X + 3, pt.Y - 3));

            }
            else
            {

                p = new Pen(colorCollapseButtonChevrons(), 1.5f);
                pt = new Point(((int)(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2))), ((int)(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2) - 4)));
                g.DrawLine(p, pt, new Point(pt.X - 3, pt.Y + 3));
                g.DrawLine(p, pt, new Point(pt.X + 3, pt.Y + 3));
                pt = new Point(((int)(baseLoc.X + (COLLAPSE_BUTTON_DIAMETER / 2))), ((int)(baseLoc.Y + (COLLAPSE_BUTTON_DIAMETER / 2))));
                g.DrawLine(p, pt, new Point(pt.X - 3, pt.Y + 3));
                g.DrawLine(p, pt, new Point(pt.X + 3, pt.Y + 3));

            }

            //
            // Restore this
            //
            g.SmoothingMode = sm;
        }


        //=------------------------------------------------------------------=
        // OnGotFocus
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We've got the focus.  Hooray!  Go and draw our focus
        ///   rectangle now.
        /// </summary>
        /// 
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
        }


        //=------------------------------------------------------------------=
        // OnLostFocus
        //=------------------------------------------------------------------=
        /// <summary>
        ///   No more focus for us.  Don't draw the focus rectangle any more
        /// </summary>
        /// 
        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Refresh();
        }


        //=------------------------------------------------------------------=
        // OnKeyPress
        //=------------------------------------------------------------------=
        /// <summary>
        ///   If the user presses AND RELEASES the Space Bar, and we've got
        ///   the focus, then we will collapse or expand the TaskFrame,
        ///   reversing the current setting.
        /// </summary>
        /// 
        protected override void OnKeyPress
        (
            System.Windows.Forms.KeyPressEventArgs e
        )
        {
            //
            // only for space
            //
            if (e.KeyChar == ' ')
            {
                this.m_buddyFrame.IsExpanded = !this.m_buddyFrame.IsExpanded;
                e.Handled = true;
                return;
            }

            base.OnKeyPress(e);
        }


        //=------------------------------------------------------------------=
        // OnKeyDown
        //=------------------------------------------------------------------=
        /// <summary>
        ///   As soon as the user presses Enter or Return, we want to
        ///   toggle the state of the IsExpanded property on this frame.
        /// </summary>
        /// 
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                this.m_buddyFrame.IsExpanded = !this.m_buddyFrame.IsExpanded;
                e.Handled = true;
                return;
            }

            base.OnKeyDown(e);
        }


        //=------------------------------------------------------------------=
        // OnMouseMouse
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user is hovering the mouse over our control, and it's
        ///   over the  caption area of the caption bar.  This will cause us
        ///   to highlight the text as it is drawn, as well 
        ///    as the CollapseButton.
        /// </summary>
        /// 
        protected override void OnMouseMove
        (
            System.Windows.Forms.MouseEventArgs e
        )
        {
            if (e.Y > (this.Height - this.m_captionHeight))
            {
                if (this.m_hovering == false)
                {
                    this.m_hovering = true;
                    this.Refresh();
                }
            }
            else
            {
                if (this.m_hovering == true)
                {
                    this.m_hovering = false;
                    this.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // OnMouseLeave
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Make sure that, if we're highlighting due to thinking
        ///   we're hovering  over the control, we stop doing so when the
        ///   user leaves our client area .... 
        /// </summary>
        /// 
        protected override void OnMouseLeave(System.EventArgs e)
        {
            if (this.m_hovering == true)
            {
                this.m_hovering = false;
                this.Refresh();
            }
        } 


        //=------------------------------------------------------------------=
        // OnMouseUp
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has let go of the mouse.  If they let go in the
        ///   caption bar area of our control, then it's a click event! 
        /// </summary>
        /// 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //
            // they're not pressing the button any more, so we indicate so and
            // lose the capture.
            //
            this.Capture = false;

            //
            // if they released it in the right place, then toggle the IsExpanded
            // state of the frame.
            //
            if (e.Y >= (this.Height - this.m_captionHeight) && e.Y < this.Height)
            {
                this.m_buddyFrame.IsExpanded = !this.m_buddyFrame.IsExpanded;
            }
        }


        //=------------------------------------------------------------------=
        // OnMouseDown
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has pressed the mouse in our client area.  If it's 
        ///   in our caption bar area, then we're interested in turning it 
        ///   into a click  ( maybe ). 
        /// </summary>
        /// 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            //
            // if it's in our caption bar area, remember this and take the capture.
            // We'll also snare the focus here too.
            //
            if (e.Y >= (this.Height - this.m_captionHeight))
            {
                this.Capture = true;
                this.Focus();
            }
        }



        //=------------------------------------------------------------------=
        // colorCollapseButtonBorder
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the color of the pen for the border of the collaps
        ///   button on  the caption bar.
        /// </summary>
        /// 
        private Color colorCollapseButtonBorder()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;
                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.NormalGroupHead.Normal);
                return vsr.GetColor(ColorProperty.BorderColorHint);
            }
            else
                return Color.CadetBlue;
        }


        //=------------------------------------------------------------------=
        // colorCollapseButtonChevrons
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the color of the pen for the chevrons in the
        ///   collapse button  on the caption bar.
        /// </summary>
        /// 
        private Color colorCollapseButtonChevrons()
        {
            return this.m_buddyFrame.ForeColor;
        }


        //=------------------------------------------------------------------=
        // colorFocusRect
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the color with which the focus rect should be drawn (pen).
        /// </summary>
        /// 
        private Color colorFocusRect()
        {
            return SystemColors.Highlight;
        }


        //=------------------------------------------------------------------=
        // systemHasRoundedCorners
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns a boolean value saying whether the current theme
        ///   should use  rounded corners for the caption bar.
        /// </summary>
        /// 
        private bool systemHasRoundedCorners()
        {
            return true;
        }

    }


}


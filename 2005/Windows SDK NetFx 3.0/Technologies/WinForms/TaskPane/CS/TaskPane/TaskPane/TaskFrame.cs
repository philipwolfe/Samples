//=====================================================================
//  File:      TaskFrame.cs
//
//  Summary:   These are the frames or "pages" that fit within the 
//             TaskPane control.  
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
    //=----------------------------------------------------------------------=
    // TaskFrame
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   These are the indidivudal frames that show up in the TaskPane
    ///   control.  They have a caption bar across the top, which, while
    ///   closely associated  with this TaskFrame (The properties on this
    ///   class modify said caption bar), is not actually part of this
    ///   control.
    /// </summary>
    /// 
    [LocalisableDescription("TaskFrame"),
     DefaultProperty("Text"),
     ToolboxItem(false),
     DesignTimeVisible(false),
     DefaultEvent("Click"),
     Designer(typeof(Design.TaskFrameDesigner))]
    public class TaskFrame : Panel
    {
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        // Private member variables and the likes
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary>
        /// Indicates if we're in the process of actually doing some collapsing or
        /// expanding with this frame.
        /// </summary>
        ///
        internal enum ActiveState
        {
            Collapsing,
            Collapsed,
            Expanding,
            Expanded
        };

        ///
        /// <summary>
        /// What's going on with this frame.
        /// </summary>
        ///
        internal ActiveState m_activeState;

        ///
        /// <summary>
        /// a reference to the CaptionBar tied to us.
        /// </summary>
        ///
        internal CaptionBar m_captionBar;

        ///
        /// How much we're being shurnk or expanded at a time and what
        /// the original size was ....
        ///
        internal int m_changeDelta;
        internal int m_originalSize;

        ///
        /// <summary>
        /// The way the caption bar is painted.
        /// </summary>
        ///
        private BlendFill m_captionBlend;

        ///
        /// <summary>
        /// Do we show our CollapseButton?
        /// </summary>
        ///
        private bool m_collapseButtonVisible;

        ///
        /// <summary>
        /// This is the corner image we will display in the captionbar of this
        /// control.
        /// </summary>
        ///
        private Image m_image;

        ///
        /// <summary>
        /// This is the 'mask' color for the images.
        /// </summary>
        ///
        private Color m_imageTransparentColor;

        ///
        /// <summary>
        /// Are we hidden because the user changed the Visible property, or
        /// because IsExpanded is False?
        /// </summary>
        ///
        private bool m_invisibleFromCollapse;




        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                    Public Methods/Properties/etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        /// <summary>
        ///  Intializes a new instance of our class
        /// </summary>
        ///
        public TaskFrame() : base()
        {

            this.Font = new Font(base.Font, FontStyle.Bold);
            this.ForeColor = colorDefaultForeground();
            this.BackColor = colorDefaultBackground();
            this.CaptionBlend = new BlendFill(BlendStyle.Horizontal, 
                                              colorCaptionBlendStart(), 
                                              colorCaptionBlendFinish());

            //
            // Set up some reasonable defaults here for the properties.
            //   
            this.m_collapseButtonVisible = true;

            //
            // Make sure we don't bother sending this to the HWND, since it
            // will never see/use it.
            //
            SetStyle(ControlStyles.CacheText, true);


            //
            // Setting up our initial collapse/expand state.
            //
            this.m_activeState = ActiveState.Expanded;
            this.m_invisibleFromCollapse = false;

            //
            // misc goo
            //
            this.m_imageTransparentColor = Color.Transparent;
        }


        //=------------------------------------------------------------------=
        // Image
        //=------------------------------------------------------------------=
        /// <summary>
        ///  The image we will display in the caption bar area.  The image is
        ///  masked against the ImageTransparentColor on our parent TaskPane
        ///  control.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Image"), 
         Category("Appearance"), 
         DefaultValue(typeof(Image), null),
         Localizable(true)]
        public Image Image
        {
            get
            {
                return this.m_image;
            }

            //
            // set the new image and tell the caption bar to refresh
            //
            set
            {
                TaskPane tp;
                Bitmap b;

                if (value != this.m_image)
                {
                    this.m_image = value;
                    b = (Bitmap)this.m_image;
                    if (b != null)
                    {
                        tp = (TaskPane)this.Parent;
                        if (tp != null)
                        {
                            b.MakeTransparent(this.ImageTransparentColor);
                        }
                    }
                    if (this.m_captionBar != null)
                    {
                        this.m_captionBar.recomputeSizes();
                        this.m_captionBar.Refresh();
                    }
                }
            }
        }


        //=------------------------------------------------------------------=
        // ImageTransparentColor
        //=------------------------------------------------------------------=
        /// <summary>
        /// This is the color that the individual TaskFrames will use to mask
        /// the background of their Image properties for transparency.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.ImageTransparentColor"), 
         Category("Behavior"), 
         DefaultValue(typeof(Color), "Transparent"), 
         Localizable(true)]
        public Color ImageTransparentColor
        {
            get
            {
                return this.m_imageTransparentColor;
            }

            //
            // set the new one, and then force a complete update of all the
            // child frames in case they are using any of these ...
            //
            set
            {
                if (!value.Equals(this.m_imageTransparentColor))
                {
                    this.m_imageTransparentColor = value;
                    this.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // CollapseButtonVisible
        //=------------------------------------------------------------------=
        /// <summary>
        /// Indicates whether or not we should show a button on our caption bar
        /// which will allow users to collapse or uncollapse us.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.CollapseButtonVisible"), 
         Category("Behavior"),
         DefaultValue(true),
         Localizable(true)]
        public bool CollapseButtonVisible
        {
            get
            {
                return this.m_collapseButtonVisible;
            }

            //
            // set the new value and tell our caption bar to refresh
            //
            set
            {
                this.m_collapseButtonVisible = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // IsExpanded
        //=------------------------------------------------------------------=
        /// <summary>
        /// Controls and/or indicates whether or not we are expanded at this point
        /// in time. Changing the value will cause the frame to collapse or 
        /// uncollapse itself.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.IsExpanded"),
         Category("Behavior"),
         DefaultValue(true),
         Localizable(true)]
        public bool IsExpanded
        {
            get
            {
                //
                // Please note that partially expanded frames will return
                // True to this property.
                //
                if (this.m_activeState == ActiveState.Collapsed)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            //
            // go ahead and start the process to collapse or expand the frame
            // if appropriate.
            //
            set
            {
                TaskPane tp;
                tp = (TaskPane)this.Parent;

                //
                // if the whole frame is hidden (indicated by our caption bar
                // not being visible) or we have no HWND yet, then just force
                // the full visible/invisible now.
                //
                if (this.m_captionBar == null || !this.m_captionBar.Visible || !this.m_captionBar.IsHandleCreated)
                {
                    if (value == true)
                    {
                        //
                        // If we're not already expanded, go and do this now.
                        //
                        if (this.m_activeState != ActiveState.Expanded)
                        {
                            this.Height = this.m_originalSize;
                        }

                        this.m_activeState = ActiveState.Expanded;
                        this.showWithoutCaptionBar();
                    }
                    else
                    {
                        //
                        // If we're not already collapsed, just go and do this
                        // now
                        //
                        if (this.m_activeState == ActiveState.Expanded)
                        {
                            this.m_originalSize = this.Height;
                        }

                        this.m_activeState = ActiveState.Collapsed;
                        this.hideWithoutCaptionBar();
                    }

                    if (tp != null)
                    {
                        tp.layoutAllFrames();
                    }
                }
                else
                {
                    //
                    // Okay, the Frame is supposed to be visible (as indicated
                    // by the caption bar being visible) and we have an HWND,
                    // so go and start the slide open/closed.
                    //
                    if (this.m_activeState == ActiveState.Collapsed || this.m_activeState == ActiveState.Collapsing)
                    {
                        //
                        // We're already collapsed/ing, so we only have to do
                        // something if they're asking us to expand ...
                        //
                        if (value == true)
                        {
                            tp.expandCollapseFrame(this, false);
                        }
                    }
                    else
                    {
                        // 
                        // We're expanded/ing, so only do something if they're
                        // asking us to Collapse
                        //
                        if (value == false)
                        {
                            tp.expandCollapseFrame(this, true);
                        }
                    }

                    //
                    // Repaint the caption bar!
                    //
                    this.m_captionBar.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // CaptionBlend
        //=------------------------------------------------------------------=
        /// <summary>
        /// This controls how the background is drawn.  There's a cool little 
        /// designer for it and everything.  Wooohoo!
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.CaptionBlend"), 
         Category("Appearance"),
         Localizable(true)]
        public BlendFill CaptionBlend
        {
            get
            {
                return this.m_captionBlend;
            }

            //
            // set the new value, refresh, and fire a change event.
            //
            set
            {
                this.m_captionBlend = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.Refresh();
                }
            }

        }


        //=------------------------------------------------------------------=
        // Size
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Okay, this is a bit strange BUT ... there is a problem by
        ///   which, when we are set to collapsed, we still need to know
        ///   when our size is being changed so that we can set the
        ///   "m_originalSize" property to the proper height.  This permits
        ///   us to restore the control to the proper height,  even if the
        ///   Size property is set when we are not expanded (i.e. collapsed)
        ///
        ///   Now, the problem is that the Size property isn't marked as 
        ///   Overridable, which means we have to Shadow it, which is
        ///   MOSTLY fine, unless people start manipulating this control
        ///   as a Control, in which case  polymorphism breaks.
        ///
        ///   This just becomes an unfortunate (but not problematic)
        ///   limitation of this control.  To get around it, you can either
        ///   be sure to always set the size of TaskFrames only, or just
        ///   make sure to set the size when the control is visible.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Size"),
         Category("Layout"),
         Localizable(true)]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            set
            {
                if (this.m_activeState == ActiveState.Collapsed)
                {
                    this.m_originalSize = value.Height;
                }

                base.Size = value;
            }
        }


        //=------------------------------------------------------------------=
        // Text
        //=------------------------------------------------------------------=
        /// <summary>
        ///    The text property on this control is very much visible.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Text"),
         Category("Appearance"),
         Browsable(true),
         EditorBrowsable(EditorBrowsableState.Always),
         Localizable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // Font
        //=------------------------------------------------------------------=
        /// <summary>
        ///  Overridden from our parent, because we need to tell our
        ///  caption bar when the Font changes ...
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Font"),
         Category("Appearance"),
         Localizable(true)]
        public new Font Font
        {
            get
            {
                return base.Font;
            }

            //
            // set the new value and tell our caption bar about it.
            //
            set
            {
                base.Font = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.setFontInternal(value);
                }
            }
        }


        //=------------------------------------------------------------------=
        // ForeColor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We override this from our parent to make sure that we repaint
        ///   properly when this is changed.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.ForeColor"),
         Category("Appearance")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.Refresh();
                }
            }
        }



        ///=-----------------------------------------------------------------=
        // Anchor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This property doesn't make sense for us as all sizing 
        ///   is controlled by the parent TaskPane
        /// </summary>
        ///
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override AnchorStyles Anchor
        {
            get
            {
                return base.Anchor;
            }

            set
            {
                base.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            }
        }


        //=------------------------------------------------------------------=
        // Dock
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This property doesn't make sense for us as all sizing
        ///   is controlled by the parent TaskPane
        /// </summary>
        ///
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            set
            {
                base.Dock = value;
            }
        }


        //=------------------------------------------------------------------=
        // DockPadding
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This property doesn't make sense for us as all sizing
        ///   is controlled by the parent TaskPane
        /// </summary>
        ///
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new DockPaddingEdges DockPadding
        {
            get
            {
                return base.DockPadding;
            }
        }


        //=------------------------------------------------------------------=
        // Visible
        //=------------------------------------------------------------------=
        /// <summary>
        ///   When we're made visible or invisible, we need to be sure to
        ///   go and hide and/or reshow our associated caption bar control.
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Visible"), 
         Category("Behavior"),
         DefaultValue(true)]
        public new bool Visible
        {
            get
            {
                if (this.m_captionBar != null)
                {
                    return this.m_captionBar.Visible;
                }
                else
                {
                    return false;
                }
            }

            //
            // If they're giving us a different value, and it's not at design
            // time, then set the new value.
            // 
            set
            {
                try
                {
                    if (this.Parent != null)
                    {
                        this.Parent.SuspendLayout();
                    }

                    //
                    // 2. Now go and show/hide us, depending on whether we're
                    //    already hidden, and why.
                    //
                    if (!this.m_invisibleFromCollapse)
                    {
                        base.Visible = value;
                    }

                    //
                    // 1. Make sure our associated caption bar gets shown/hidden
                    //
                    this.m_captionBar.setVisibleInternal(value);

                }
                finally
                {
                    this.Parent.ResumeLayout();
                }
            }
        }


        //=------------------------------------------------------------------=
        // Enabled
        //=------------------------------------------------------------------=
        /// <summary>
        /// When we're made Enabled or disabled, we need to be sure to go and
        /// enable and/or disable our buddy caption bar
        /// </summary>
        ///
        [LocalisableDescription("TaskFrame.Enabled"),
         Category("Behavior"),
         DefaultValue(true)]
        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }

            //
            // If they're giving us a different value, then set it
            //
            set
            {
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.setEnabledInternal(value);
                }
                base.Enabled = value;
            }
        }


        //=------------------------------------------------------------------=
        // ImeMode
        //=------------------------------------------------------------------=
        /// <summary>
        /// TaskFrames don't have input, so this isn't terribly useful.
        /// </summary>
        ///
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode
        {
            get
            {
                return base.ImeMode;
            }
            set
            {
                base.ImeMode = value;
            }
        }


        //=------------------------------------------------------------------=
        // RightToLeft
        //=------------------------------------------------------------------=
        /// <summary>
        ///    Make sure we update our caption bar appropriately.
        /// </summary>
        ///
        public override System.Windows.Forms.RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }

            set
            {
                base.RightToLeft = value;
                if (this.m_captionBar != null)
                {
                    this.m_captionBar.Refresh();
                }
            }
        }









        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                Private/Protected/Friend Subs/Functions
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // hideWithoutCaptionBar
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Hides this TaskFrame without hiding our associated caption
        ///   bar.  That's  rather important, since every time we are
        ///   collapsed, we are hidden to keep us out of the tab order, etc.
        /// </summary>
        ///
        protected internal void hideWithoutCaptionBar()
        {
            this.m_invisibleFromCollapse = true;
            base.Visible = false;
        }


        //=------------------------------------------------------------------=
        // showWithoutCaptionBar
        //=------------------------------------------------------------------=
        /// <summary>
        /// Shows this TaskFrame without affecting our associated caption bar.  
        /// That's rather important, since every time we are collapsed, we are
        /// hidden to keep us out of the tab order, etc ...
        /// </summary>
        ///
        protected internal void showWithoutCaptionBar()
        {
            this.m_invisibleFromCollapse = false;
            base.Visible = true;
        }


        //=------------------------------------------------------------------=
        // getReallyVisible
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns whether or not this actual TaskFrame control is visible, 
        ///   regardless of the reasons it may not be.  Should only be
        ///   needed by the layout code in the parent TaskPane itself.
        /// </summary>
        ///
        internal bool getReallyVisible()
        {
            return base.Visible;
        }


        //=------------------------------------------------------------------=
        // OnResize
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Whenever the control is resized, we need to know about the
        ///   change in height so we can set our original size to 
        ///   reflect this ...
        /// </summary>
        ///
        protected override void OnResize(System.EventArgs eventargs)
        {
            if (this.m_activeState == ActiveState.Expanded)
            {
                this.m_originalSize = this.Height;
            }

            base.OnResize(eventargs);
        }



        //=------------------------------------------------------------------=
        // colorDefaultBackground
        //=------------------------------------------------------------------=
        /// <summary>
        /// This returns the default background color for our TaskFrame.
        /// </summary>
        ///
        private Color colorDefaultBackground()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;
                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.NormalGroupBackground.Normal);

                return vsr.GetColor(ColorProperty.GradientColor1);
            }
            else
                return Color.CadetBlue;
        }


        //=------------------------------------------------------------------=
        // colorDefaultForeground
        //=------------------------------------------------------------------=
        /// <summary>
        /// This returns the default background color for our TaskFrame.
        /// </summary>
        ///
        private Color colorDefaultForeground()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;

                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.NormalGroupHead.Normal);
                return vsr.GetColor(ColorProperty.EdgeDarkShadowColor);
            }
            else
                return Color.CadetBlue;
        }


        //=------------------------------------------------------------------=
        // colorCaptionBlendStart
        //=------------------------------------------------------------------=
        /// <summary>
        /// Returns the start color to be used to blend the caption bar.
        /// </summary>
        ///
        private Color colorCaptionBlendStart()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;
                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.HeaderBackground.Normal);

                return vsr.GetColor(ColorProperty.EdgeHighlightColor);
            }
            else
                return Color.White;
        }


        //=------------------------------------------------------------------=
        // colorCaptionBlendFinish
        //=------------------------------------------------------------------=
        /// <summary>
        /// Returns the finish color to be used to blend the caption bar.
        /// </summary>
        ///
        private Color colorCaptionBlendFinish()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;
                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.NormalGroupHead.Normal);

                return vsr.GetColor(ColorProperty.GradientColor1);
            }
            else
                return Color.CadetBlue;
        }

    }

}


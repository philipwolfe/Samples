//=====================================================================
//  File:      TaskPane.cs
//
//  Summary:   A component for .NET Managed code applications that mimics
//             the funcionality of the Task Pane in the Windows XP 
//             Explorer.  The pane is composed of one or more frames.
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

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;


namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    /// <summary>
    ///   For the FrameCollapsed event.
    /// </summary>
    /// 
    /// <param name="sender">
    ///   The TaskPane that sent the event.
    /// </param>
    /// <param name="e">
    ///   Details about it, including the TaskFrame that was collapsed.
    /// </param>
    /// 
    public delegate void FrameCollapsedEventHandler(object sender, TaskPaneEventArgs e);

    /// <summary>
    ///   For the FrameCollapsing event.
    /// </summary>
    /// 
    /// <param name="sender">
    ///   The TaskPane that sent the event.
    /// </param>
    /// <param name="e">
    ///   Details about it, including the TaskFrame that is collapsing. It
    ///   can be cancelled.
    /// </param>
    /// 
    public delegate void FrameCollapsingEventHandler(object sender, TaskPaneCancelEventArgs ce);

    /// <summary>
    ///   For the FrameExpanded event.
    /// </summary>
    /// 
    /// <param name="sender">
    ///   The TaskPane that sent the event.
    /// </param>
    /// <param name="e">
    ///   Details about it, including the TaskFrame that was expanded
    /// </param>
    /// 
    public delegate void FrameExpandedEventHandler(object sender, TaskPaneEventArgs e);

    /// <summary>
    ///   For the FrameCollapsing event.
    /// </summary>
    /// 
    /// <param name="sender">
    ///   The TaskPane that sent the event.
    /// </param>
    /// <param name="e">
    ///   Details about it, including the TaskFrame that is collapsing.  It
    ///   can be cancelled
    /// </param>
    /// 
    public delegate void FrameExpandingEventHandler(object sender, TaskPaneCancelEventArgs ce);



    //=----------------------------------------------------------------------=
    // TaskPane
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   This is the base container class that users add to their forms in
    ///   Visual Studio.  Using various Design Time functionality, users can then
    ///   go and child frames (in the TaskFrame class) to it, and customise them
    ///   as they wish.
    /// </summary>
    ///
    [DefaultProperty("TaskFrames")]
    [DefaultEvent("FrameCollapsed")]
    [Designer(typeof(Design.TaskPaneDesigner))]
    public class TaskPane : ContainerControl
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
        ///  Amount of space to allow between each Frame.
        /// </summary>
        ///
        private const int FRAME_PADDING = 12;

        //
        // How many ms between collapse/expand changes and the total time we
        // want the operation to last...
        // 
        private const int TIMER_DELTA = 50;
        private const int TOTAL_CHANGE_TIME = 250; // half a second

        /// 
        /// <summary>
        ///   This is the style of corners we will paint for these controls.
        /// </summary>
        /// 
        private TaskFrameCornerStyle m_cornerStyle;

        ///
        /// <summary>
        ///   This is user configurable
        /// </summary>
        ///
        private int m_padding;


        //
        /// <summary>
        ///   This is our collection of TaskFrame objects.  For each frame,
        ///   we also associate a CaptionBar class, which contains the image, 
        ///   caption, and collapse button (if applicable)
        /// </summary>
        /// 
        private TaskFrameCollection m_frameCollection;

        ///
        /// <summary>
        ///   This timer is used for expanding/collapsing of frames.
        /// </summary>
        ///
        private Timer m_collapseTimer;

        private bool m_lockLayout = false;



        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                     Public Methods, Members, etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Constructor
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Intitializes a new instance of our TaskPane class.  We don't
        ///   have  any frames by default, and they need to be added one by
        ///   one.
        /// </summary>
        ///
        public TaskPane()
        {
            //
            // set up some reasonable default values for the various
            // properties we've got.
            //
            this.m_cornerStyle = TaskFrameCornerStyle.SystemDefault;
            this.BackColor = getBackColorFromThemes();

            this.m_frameCollection = new TaskFrameCollection(this);

            //
            // Set up a decent default width, and we'll dock to the left
            //
            this.Width = 150;
            this.Dock = DockStyle.Left;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //
            // finally, set up the collapse/expand timer we'll use to do a lot
            // of the work.
            //
            this.m_collapseTimer = new Timer();
            this.m_collapseTimer.Interval = TIMER_DELTA;
            this.m_collapseTimer.Tick += new EventHandler(m_collapseTimer_Tick);

            this.AutoScroll = true;
            this.HScroll = false;

            this.m_padding = FRAME_PADDING;
        }


        //=------------------------------------------------------------------=
        // CornerStyle
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Controls how the corners are drawn for the caption bars at 
        ///   the top of the individual child frames.  By default, they
        ///   track what the current Operating System style is using, but
        ///   users can force this to other  values if they so wish.
        /// </summary>
        /// 
        /// <value>
        ///   The style of corners that should be drawn on the caption bar
        ///   of the individual TaskFrames.
        /// </value>
        ///
        [LocalisableDescription("TaskPane.CornerStyle"), 
         Category("Appearance"),
         DefaultValue(TaskFrameCornerStyle.SystemDefault),
         Localizable(true)]
        public TaskFrameCornerStyle CornerStyle
        {
            get
            {
                return this.m_cornerStyle;
            }

            //
            // set the new value and refresh the control to reflect the change.
            //
            set
            {
                if ((int)value < 0 || (int)value > 2)
                {
                    throw new ArgumentOutOfRangeException("Value",
                        TaskPaneMain.GetResourceManager().GetString("excTaskPaneCornerStyleRange"));
                }

                if (value != this.m_cornerStyle)
                {
                    this.m_cornerStyle = value;
                    this.Refresh();
                }
            }
        }


        //=------------------------------------------------------------------=
        // Padding
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Specifies just how much space should be left between
        ///   individual Task Frames and between frames and the edges of the
        ///   TaskPane.
        /// </summary>
        /// 
        /// <value>
        ///   How many pixels should be left between the individual
        ///   TaskFrames and between them and the edge of the parent
        ///   TaskPane.
        /// </value>
        /// 
        [LocalisableDescription("TaskPane.Padding"),
         Category("Appearance"),
         DefaultValue(FRAME_PADDING),
         Localizable(true)]
        public new int Padding
        {
            get
            {
                return this.m_padding;
            }

            //
            // set the new value if appropriate, and relayout the container.
            //
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value");
                }

                if (value != this.m_padding)
                {
                    this.m_padding = value;
                    layoutAllFrames();
                }
            }
        }


        //=------------------------------------------------------------------=
        // TaskFrames
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This is our collection of TaskFrame child panels.  This
        ///   collection object also manages the CaptionBars for us.
        /// </summary>
        ///
        /// <value>
        ///   The collection of TaskFrame objects.
        /// </value>
        ///
        [LocalisableDescription("TaskPane.TaskFrames"),
         Category("Misc"),
         DefaultValue(false),
         Editor("Design.TaskFrameCollectionEditor",
                typeof(System.Drawing.Design.UITypeEditor)),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         MergableProperty(false)]
        public TaskFrameCollection TaskFrames
        {
            get
            {
                return this.m_frameCollection;
            }
        }


        //=------------------------------------------------------------------=
        // Text
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The text property isn't visible on this control, so we'll go and
        ///   hide it now.
        /// </summary>
        /// 
        [Browsable(false), 
         EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }


        //=------------------------------------------------------------------=
        // ExpandAll
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Causes all of our child frames to begin expanding. 
        /// </summary>
        ///
        [LocalisableDescription("TaskPane.ExpandAll")]
        public void ExpandAll()
        {
            TaskFrame tf;

            //
            // Loop through our collection of TaskFrames and then expand each
            // one at a time ...
            //
            for (int i = 0; i < this.TaskFrames.Count; i++)
            {
                tf = this.TaskFrames[i];
                tf.IsExpanded = true;
            }
        }


        //=------------------------------------------------------------------=
        // CollapseAll
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Causes all of our child frames to begin collapsing.
        /// </summary>
        ///
        [LocalisableDescription("TaskPane.CollapseAll")]
        public void CollapseAll()
        {
            TaskFrame tf;

            //
            // Loop through our collection of TaskFrames and then collapse each
            // one at a time ...
            //
            for (int i = 0; i < this.TaskFrames.Count; i++)
            {
                tf = this.TaskFrames[i];
                tf.IsExpanded = false;
            }
        }


        //=------------------------------------------------------------------=
        // Refresh
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Redraw and update all our components.
        /// </summary>
        ///
        public override void Refresh()
        {
            //
            // Refresh EVERYBODY!!!
            //
            for (int x = 0; x < this.Controls.Count; x++)
            {
                this.Controls[x].Refresh();
            }

            base.Refresh();
        }

        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                                Events
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=


        //=------------------------------------------------------------------=
        // FrameCollapsed
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given frame has been collapsed, either by the user
        ///   or in code.
        /// </summary>
        /// 
        public event FrameCollapsedEventHandler FrameCollapsed;

        //=------------------------------------------------------------------=
        // FrameCollapsing
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given frame is about to be collapsed, either by the user
        ///   or via code.  Programmers can cancel this collapse here.
        /// </summary>
        /// 
        public event FrameCollapsingEventHandler FrameCollapsing;

        //=------------------------------------------------------------------=
        // FrameExpanded
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given frame has been expanded, either by the user o
        ///   via code.
        /// </summary>
        /// 
        public event FrameExpandedEventHandler FrameExpanded;

        //=------------------------------------------------------------------=
        // FrameExpanding
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given frame is about to be expanded, either by
        ///   the user or via code.
        /// </summary>
        /// 
        public event FrameExpandingEventHandler FrameExpanding;









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
        // CreateHandle
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Make sure we're all laid out properly.
        /// </summary>
        ///
        protected override void CreateHandle()
        {
            base.CreateHandle();

            layoutAllFrames();
        }


        //=------------------------------------------------------------------=
        // Dispose
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Make sure we clean everything up properly, including our 
        ///   hosted Timer object.
        /// </summary>
        /// 
        /// <param name="disposing">
        ///  
        /// </param>
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.m_collapseTimer.Tick -= new EventHandler(m_collapseTimer_Tick);
                this.m_collapseTimer.Dispose();
            }

            base.Dispose(disposing);
        }


        //=------------------------------------------------------------------=
        // CreateControlsInstance
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Creates the ControlCollection object with which we will
        ///   work.  Our version will only accept TaskFrames to be added, 
        ///   and will also sneak in the CaptionBar for the given frame 
        ///   while it's at it.
        /// </summary>
        ///
        /// <returns>
        ///   The ControlCollection for this container (TaskPane)
        /// </returns>
        /// 
        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TaskPane.ControlCollection(this);
        }


        //=------------------------------------------------------------------=
        // OnFrameCollapsed
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The user has collapsed the given frame.  We'll fire an event
        ///   to this effect now.
        /// </summary>
        /// 
        /// <param name="frame">
        ///   The frame that collapsed.
        /// </param>
        /// 
        protected virtual void OnFrameCollapsed(TaskFrame frame)
        {
            if (this.FrameCollapsed != null)
            {
                this.FrameCollapsed(this, new TaskPaneEventArgs(frame));
            }
        }


        //=------------------------------------------------------------------=
        // OnFrameExpanded
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The given frame has expanded. We'll fire an event to this effect
        ///   now.
        /// </summary>
        /// 
        /// <param name="frame">
        ///   The frame that expanded.
        /// </param>
        /// 
        protected void OnFrameExpanded(TaskFrame frame)
        {
            if (this.FrameExpanded != null)
            {
                this.FrameExpanded(this, new TaskPaneEventArgs(frame));
            }
        }


        //=------------------------------------------------------------------=
        // OnFrameCollapsing
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The specified frame is about to collapse.  Fire an event to this
        ///   effect to give people the opportunity to prevent it.
        /// </summary>
        /// 
        /// <param name="frame">
        ///   The frame being collapsed.
        /// </param>
        /// 
        /// <returns>
        ///   A boolean value indicating whether or not to cancel the collapse.
        ///   True means cancel the collapse.
        /// </returns>
        /// 
        protected bool OnFrameCollapsing(TaskFrame frame)
        {
            TaskPaneCancelEventArgs ce;
            ce = new TaskPaneCancelEventArgs(frame);

            if (this.FrameCollapsing != null)
            {
                this.FrameCollapsing(this, ce);
            }

            return ce.Cancel;
        }


        //=------------------------------------------------------------------=
        // OnFrameExpanding
        //=------------------------------------------------------------------=
        /// <summary>
        ///   The specified frame is about to expand.  Go and fire an event to 
        ///   this effect now, giving people the opportunity to cancel it.
        /// </summary>
        /// 
        /// <param name="frame">
        ///   The frame being expanded.
        /// </param>
        /// 
        /// <returns>
        ///   A boolean indicating whether or not the expand should
        ///   be prevented.
        ///   True means yes.
        /// </returns>
        ///
        protected bool OnFrameExpanding(TaskFrame frame)
        {
            TaskPaneCancelEventArgs ce;
            ce = new TaskPaneCancelEventArgs(frame);

            if (this.FrameExpanding != null)
            {
                this.FrameExpanding(this, ce);
            }

            return ce.Cancel;
        }


        //=------------------------------------------------------------------=
        // OnLayout
        //=------------------------------------------------------------------=
        /// <summary>
        ///   We're being asked to lay out all of our components.
        /// </summary>
        /// 
        /// <param name="levent">
        ///   Details about the event.
        /// </param>
        /// 
        protected override void OnLayout
        (
            System.Windows.Forms.LayoutEventArgs levent
        )
        {
            layoutAllFrames();
            base.OnLayout(levent);
        }



        //=------------------------------------------------------------------=
        // layoutAllFrames
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Given that we now have a bunch of TaskFrames and associated
        ///   CaptionBar controls, go and lay them out now, including doing
        ///   things like making sure our scroll height is correct, etc ...
        /// </summary>
        /// 
        internal void layoutAllFrames()
        {
            int h, w;

            //
            // if we don't have any frames, then this is easy.
            //
            if (this.m_frameCollection == null)
            {
                return;
            }

            //
            // If we're not created, then this is also easy.
            //
            if (!this.IsHandleCreated)
            {
                return;
            }

            if (this.m_lockLayout)
            {
                return;
            }

            this.m_lockLayout = true;

            try
            {
                //
                // okay, we should have a window handle now, which means we can 
                // start figuring out sizes, etc ...
                // 

                //
                // 1. Compute the height
                //
                h = computeTotalHeight();

                //
                // 2. readjust our scrollbars and all tha to reflect this.
                //
                if (h > this.Height)
                {
                    int i;
                    this.AutoScrollMinSize = new Size(0, h);

                    //
                    // Our width has to have some room for the scrollbar ...
                    //
                    i = SystemInformation.VerticalScrollBarWidth;
                    w = this.Width - i - 1;
                }
                else
                {
                    this.AutoScrollMinSize = new Size(0, 0);
                    w = this.Width;
                }

                //
                // 3. Now go and adjust all the controls' sizes correctly.
                //
                positionAllFrames(w);
            }
            finally
            {
                this.m_lockLayout = false;
            }
        }


        //=------------------------------------------------------------------=
        // computeTotalHeight
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Figures out how tall our TaskPane control needs to be,
        ///   given the number of frames and caption bars we have, as well
        ///   as appropriate padding.
        /// </summary>
        /// 
        /// <returns>
        ///   The total height of the control, so we can figure out if we need
        ///   scrollbars to be visible, etc.
        /// </returns>
        /// 
        private int computeTotalHeight()
        {
            TaskFrame tf;
            int height;

            //
            // first, we have to compute the total height of everything,
            // to figure out if we need to go and set up a scrollbar.
            //
            height = 0;

            for (int i = 0; i < this.m_frameCollection.Count; i++)
            {
                tf = this.m_frameCollection[i];

                if (tf.m_captionBar.Visible)
                {
                    //
                    // every frame adds:
                    //
                    // 1. fixed buffer space at the top
                    // 2. the height of the caption bar
                    // 3. the height of the actual frame itself, provided it's
                    //    not collapsed.
                    //
                    height += this.m_padding;
                    height += tf.m_captionBar.Height;
                    if (tf.IsExpanded)
                    {
                        height += tf.Height;
                    }
                }
            }

            //
            // finally, add some height for a buffer at the bottom and return
            //
            height += this.m_padding;
            return height;
        }


        //=------------------------------------------------------------------=
        // positionAllFrames
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Given that we've figured out our height, and now know our 
        ///   width, we now need to go and move all the frames and caption
        ///   bars to be in the correct place.
        /// </summary>
        /// 
        /// <param name="in_width">
        ///   How wide our control is.
        /// </param>
        ///
        private void positionAllFrames(int in_width)
        {
            TaskFrame tf;
            int realWidth;
            int top;
            int left;

            //
            // set up the base width and height
            //
            realWidth = in_width - (2 * this.m_padding);
            if (realWidth < 1)
            {
                realWidth = 10;
            }
            top = this.m_padding;

            //
            // Make sure we show at least SOMETHING if the padding is ridiculously
            // huge.
            //
            if (this.m_padding > (this.Width / 2) - 5)
            {
                left = (int)((this.Width / 2) - 5);
            }
            else
            {
                left = this.m_padding;
            }

            //
            // for each item, go and position it appropriately.
            //
            for (int i = 0; i < this.m_frameCollection.Count; i++)
            {
                IntPtr hwnd;

                tf = this.m_frameCollection[i];

                //
                // Make sure that the handle has been created for the 
                // TaskFrame.
                //
                hwnd = tf.Handle;
                if (tf.m_captionBar.Visible)
                {
                    //
                    // caption bar
                    //
                    tf.m_captionBar.Top = top + this.AutoScrollPosition.Y;

                    tf.m_captionBar.Left = this.m_padding;
                    tf.m_captionBar.Width = realWidth;
                    top += tf.m_captionBar.Height;
                }
                else
                {
                    System.Diagnostics.Debug.Assert(!tf.Visible, "How can I have an invisible CaptionBar but visible Frame ????");
                }

                if (tf.getReallyVisible() == true)
                {
                    //
                    // frame.
                    //
                    tf.Top = top + this.AutoScrollPosition.Y;
                    tf.Left = this.m_padding;
                    tf.Width = realWidth;
                    top += tf.Height;

                    tf.Refresh();
                }

                if (tf.m_captionBar.Visible)
                {
                    top += this.m_padding;
                }
            }
        }


        //=------------------------------------------------------------------=
        // expandCollapseFrame
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Contains the actual logic to go and expand or collapse the given
        ///   TaskFrame.  To do this from code, you should just set 
        /// 
        ///   myTaskPane1.IsExpanded = either True or False.
        /// 
        ///   Please note that there should be nothing here preventing
        ///   controls from having their IsExpanded property changed WHILE
        ///   they are actively collapsing or expanding.  We should simply
        ///   be able to deal with this.
        /// </summary>
        ///
        /// <param name="in_frame">
        ///   The frame being expanded or collapsed.
        /// </param>
        /// 
        /// <param name="in_collapse">
        ///   Whether to Collapse (True) or Expand it (False)
        /// </param>
        /// 
        internal void expandCollapseFrame(TaskFrame in_frame, bool in_collapse)
        {
            //
            // If the pane is already collapsed, then this is pretty easy.  
            // Otherwise, given them the chance to cancel the happening!
            //
            if (in_collapse)
            {
                if (in_frame.m_activeState == TaskFrame.ActiveState.Collapsing)
                {
                    return; 
                }
                if (this.OnFrameCollapsing(in_frame) == true)
                {
                    return; 
                }
            }
            else
            {
                if (in_frame.m_activeState == TaskFrame.ActiveState.Expanding)
                {
                    return; 
                }
                if (this.OnFrameExpanding(in_frame) == true)
                {
                    return;
                }
            }

            //
            // Now, suspend the layout on it if we're collapsing it, so 
            // any child  Controls don't freak out that they're being
            // moved around.
            //
            if (in_collapse == true)
            {
                in_frame.SuspendLayout();
            }
            else
            {
                //
                // if we're going to expand it, make sure it's visible again.
                //
                in_frame.Height = 0;
                in_frame.showWithoutCaptionBar();
            }

            //
            // Next, tell the control how much we're going to change it by
            // each tick, and then start sliding it up to height zero or
            // the original size.  With the changeDelta, we're targeting
            // a TOTAL_CHANGE_TIME length collapse.
            //
            if (in_collapse == true
                && in_frame.m_activeState != TaskFrame.ActiveState.Collapsing
                && in_frame.m_activeState != TaskFrame.ActiveState.Expanding)
            {
                in_frame.m_changeDelta = (int)(in_frame.Height / (TOTAL_CHANGE_TIME / TIMER_DELTA));
                in_frame.m_originalSize = in_frame.Height;

            }
            else if (in_collapse == false
                     && in_frame.m_activeState != TaskFrame.ActiveState.Collapsing
                     && in_frame.m_activeState != TaskFrame.ActiveState.Expanding)
            {
                in_frame.m_changeDelta = (int)(in_frame.m_originalSize / (TOTAL_CHANGE_TIME / TIMER_DELTA));
            }

            if (in_collapse)
            {
                in_frame.m_activeState = TaskFrame.ActiveState.Collapsing;
            }
            else
            {
                in_frame.m_activeState = TaskFrame.ActiveState.Expanding;
            }

            //
            // start the timer doing it's thang.
            //
            if (!this.m_collapseTimer.Enabled)
            {
                this.m_collapseTimer.Start();
            }
        }


        //=------------------------------------------------------------------=
        // m_collapseTimer_Tick
        //=------------------------------------------------------------------=
        /// <summary>
        ///   This is the timer that goes along and expands/collapse
        ///   the various taskframes ... very exciting.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event
        /// </param>
        /// 
        /// <param name="e">
        ///   EventArgs.Empty
        /// </param>
        /// 
        private void m_collapseTimer_Tick(object sender, System.EventArgs e)
        {
            int activelyChangingCount;
            TaskFrame tf;

            activelyChangingCount = 0;

            //
            // for each frame that is expanding or collapsing, go and
            // change its state just a bit this time ...
            //
            for (int i = 0; i < this.m_frameCollection.Count; i++)
            {
                tf = this.m_frameCollection[i];

                //
                // what's our current state?
                //
                switch (tf.m_activeState)
                {

                    case TaskFrame.ActiveState.Collapsing:

                        tf.Height = tf.Height - tf.m_changeDelta;

                        //
                        // did we completely collapse that frame? 
                        // if so, set some state and fire the event!
                        //
                        if (tf.Height <= 0)
                        {
                            //
                            // Height is zero, and hide it so that children
                            // aren't included the z-order any more.
                            //
                            tf.Height = 0;
                            tf.hideWithoutCaptionBar();
                            tf.m_activeState = TaskFrame.ActiveState.Collapsed;
                            layoutAllFrames();

                            OnFrameCollapsed(tf);
                            tf.m_captionBar.Refresh();
                        }
                        else
                        {
                            activelyChangingCount += 1;
                        }
                        break;

                    case TaskFrame.ActiveState.Expanding:

                        tf.Height += tf.m_changeDelta;

                        //
                        // did we completely expand the frame?  if so,
                        // set some state and fire the event!
                        //
                        if (tf.Height >= tf.m_originalSize)
                        {
                            //
                            // Set it back to its original size, and then
                            // relayout the container
                            //
                            tf.Height = tf.m_originalSize;
                            tf.m_activeState = TaskFrame.ActiveState.Expanded;
                            layoutAllFrames();

                            //
                            // Fire the event and repaint everything
                            //
                            OnFrameExpanded(tf);
                            tf.m_captionBar.Refresh();

                            //
                            // finally, don't forget to tell it that it can
                            // reposition controls again.
                            //
                            tf.Refresh();
                            tf.ResumeLayout();
                        }
                        else
                        {
                            activelyChangingCount += 1;
                        }
                        break;
                }
            }

            //
            // If there are no controls actively changing state, then go and
            // shut down the timer, so we don't waste any time here ...
            //
            if (activelyChangingCount == 0)
            {
                this.m_collapseTimer.Stop();
            }
        }


        //=------------------------------------------------------------------=
        // GetCompleteRectForFrame
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the rect bounding both a frame as well as its associated 
        ///   captionbar.
        /// </summary>
        /// 
        /// <param name="in_frame">
        ///   The frame whose bounding rectangle we wish to compute.
        /// </param>
        /// 
        /// <returns>
        ///   The computed bounding rectangle (CaptionBar included).
        /// </returns>
        /// 
        internal Rectangle GetCompletRectForFrame(TaskFrame in_frame)
        {
            Point pt;
            Size sz;

            System.Diagnostics.Debug.Assert(in_frame != null);
            pt = in_frame.m_captionBar.Location;

            sz = new Size();
            sz.Width = in_frame.Width;
            sz.Height = in_frame.Bottom - in_frame.m_captionBar.Top;

            return new Rectangle(pt, sz);
        }


        //=------------------------------------------------------------------=
        // getBackColorFromThemes
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns the BackColor for this control, attempting to use the 
        ///   theming engines as much as possible.
        /// </summary>
        /// 
        /// <returns>
        ///   The background color to use for this control.
        /// </returns>
        /// 
        private Color getBackColorFromThemes()
        {
            if (VisualStyleRenderer.IsSupported)
            {
                VisualStyleRenderer vsr;

                vsr = new VisualStyleRenderer(VisualStyleElement.ExplorerBar.NormalGroupBackground.Normal);
                return vsr.GetColor(ColorProperty.GradientColor2);
            }
            else
                return Color.Beige;

        }






        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                           Nested Classes
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // ControlCollection
        //=------------------------------------------------------------------=
        /// <summary>
        ///   All of the pages in the TaskFrame control are in a collection of
        ///   TaskFrame objects.  However. we also need to implement the 
        ///   ControlCollection off the Control class to make sure that people
        ///   can add new frames via either that or the TaskFrames collection.
        ///   Also, we nee to be able to inject our CaptionBar controls, which
        ///   has to happen via the ControlCollection.
        /// </summary>
        /// 
        public new class ControlCollection : Control.ControlCollection
        {
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=
            //             Private Member variables, enums, consts
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=
            //=------------------------------------------------------------------=

            /// 
            /// <summary>
            ///   Our Parent TaskPane
            /// </summary>
            /// 
            private TaskPane m_parent;



            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=
            //             Public Methods/Properties/Functions, etc 
            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=
            //=--------------------------------------------------------------=

            //=--------------------------------------------------------------=
            // Constructor
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Initializes a new instance of this collection with the given
            ///   parent.
            /// </summary>
            /// 
            /// <param name="in_parent">
            ///   The TaskPane in which we are operating.
            /// </param>
            /// 
            public ControlCollection(TaskPane in_parent) : base(in_parent)
            {
                this.m_parent = in_parent;
            } 


            //=--------------------------------------------------------------=
            // Add
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Adds the given control to our list of Sub controls.  It had
            ///   BETTER be a TaskFrame.  In this case, we need to go and
            ///   create the appropriate CaptionBar for it, and add it
            ///   as well ...
            /// </summary>
            /// 
            /// <param name="in_control">
            ///   Control to add.
            /// </param>
            /// 
            public override void Add(Control in_control)
            {

                IContainer container;
                CaptionBar cb;
                TaskFrame tf;
                ISite site;

                //
                // Double check the arg type first ...
                //
                if (!(in_control is TaskFrame)
                    && !(in_control is CaptionBar))
                {
                    throw new ArgumentException(string.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_control.GetType().ToString()));
                }

                if (this.Contains(in_control))
                {
                    return;
                }

                //
                // Go and create the CaptionBar for this frame ...
                //
                tf = (TaskFrame)in_control;
                cb = new CaptionBar(tf);
                tf.m_captionBar = cb;
                cb.setVisibleInternal(true);

                //
                // Now, add the caption bar to our list of controls.
                //
                base.Add(cb);
                //
                // And now add the actual frame to our list of controls.
                //
                base.Add(tf);

                //
                // Next, site the controls if at all necessary.
                //
                site = this.m_parent.Site;
                if (site != null)
                {
                    //
                    // Site the TaskFrame here, as controls need to be
                    // sited in order to have code generated for them at
                    // design time.
                    // Please note this means we DON'T want to site the
                    // CaptionBars ...
                    //
                    if (tf.Site == null)
                    {
                        container = site.Container;
                        container.Add(tf);
                    }
                }

                //
                // Finally, add the frame to our parent's collection of 
                // frames, and then tell it to re-layout everything. 
                //
                this.m_parent.TaskFrames.addFrameInternal(tf);
                this.m_parent.layoutAllFrames();

            }


            //=--------------------------------------------------------------=
            // Remove
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Removes the given TaskFrame from our list of controls, 
            ///   as well  as the associated CaptionBar control.
            /// </summary>
            /// 
            /// <param name="in_control">
            ///   The control to remove from our collection.
            /// </param>
            /// 
            public override void Remove(Control in_control)
            {
                TaskFrame tf;

                if (!(in_control is TaskFrame))
                {
                    return;
                }

                if (!this.Contains(in_control))
                {
                    return;
                }

                //
                // remove this Frame and its CaptionBar
                //
                tf = (TaskFrame)in_control;
                base.Remove(tf.m_captionBar);
                base.Remove(tf);

                //
                // Remove it from the other collection the TaskPane maintains
                //
                this.m_parent.TaskFrames.removeFrameInternal(tf);

                //
                // Finally, tell the parent Pane to layout everything again.
                //
                this.m_parent.layoutAllFrames();
            }


            //=--------------------------------------------------------------=
            // Clear
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Removes all the items in this control collection.
            /// </summary>
            /// 
            public override void Clear()
            {
                //
                // For each TaskFrame in the control, go and remove it 
                // now.  Removing the individual TaskFrames will go and
                // remove the CaptionBars as well !!
                //
                for (int x = 0; x < this.m_parent.m_frameCollection.Count; x++)
                {
                    this.Remove(this.m_parent.m_frameCollection[0]);
                }

                //
                // Finally, go and clear out the frame collection too.
                // This keeps everybody nice and in sync with each other.
                //
                this.m_parent.m_frameCollection.clearInternal();
            }


            //=--------------------------------------------------------------=
            // AddRange
            //=--------------------------------------------------------------=
            /// <summary>
            ///   Adds a range of controls to our collection. 
            /// </summary>
            /// 
            /// <param name="in_array">
            ///   Array of controls to add.
            /// </param>
            /// 
            public override void AddRange(Control[] in_array)
            {
                TaskFrame tf;

                if (in_array == null)
                {
                    return;
                }
                if (in_array.Length == 0)
                {
                    return;
                }

                //
                // Now, for each item, go and make sure it's a TaskFrame, and
                // then go and add if it is.
                //
                for (int x = 0; x < in_array.GetLength(0); x++)
                {
                    tf = (TaskFrame)in_array[x];
                    if (tf == null)
                    {
                        throw new ArgumentException(string.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_array[x].GetType().ToString()));
                    }

                    this.Add(tf);
                }
            }
        }

    }






    //=----------------------------------------------------------------------=
    // TaskFrameCollection
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   All of the pages in the TaskFrame control are in a collection of
    ///   TaskFrame objects
    /// </summary>
    /// 
    public class TaskFrameCollection : IList
    {
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        // Private member variables and the likes
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=

        ///
        /// <summary>
        ///   This is our actual list of pages and how many we've got.
        /// </summary>
        /// 
        private TaskFrame[] m_frames;
        private int m_cFrames;

        /// 
        /// <summary>
        ///   Our parent TaskPane control.
        /// </summary>
        /// 
        private TaskPane m_parent;





        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //                     Public Methods, Members, etc
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=

        //=--------------------------------------------------------------=
        // Constructor
        //=--------------------------------------------------------------=
        /// <summary>
        ///   We need to know who our parent is, and then go and set up
        ///   some array space for the frames.  Please note that this
        ///   constructor is declared as "Friend" so that only we can
        ///   create them and not end users.
        /// </summary>
        /// 
        /// <param name="in_parent">
        ///   The parent TaskPane in which we are operating.
        /// </param>
        /// 
        internal TaskFrameCollection(TaskPane in_parent)
        {
            this.m_parent = in_parent;

            System.Diagnostics.Debug.Assert(in_parent != null);

            //
            // create a base space to hold the frames.  we'll grow it as
            // necessary
            //
            this.m_frames = new TaskFrame[3];
            this.m_cFrames = 0;
        }


        //=--------------------------------------------------------------=
        // CopyTo                                            [ICollection]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Copy from our collection into the given dest array
        /// </summary>
        /// 
        /// <param name="in_dest">
        ///   The destination array into which to copy.
        /// </param>
        /// 
        /// <param name="in_index">
        ///   The starting offset from which copying should begin.
        /// </param>
        /// 
        public void CopyTo(System.Array in_dest, int in_index)
        {
            TaskFrame[] frames;

            frames = (TaskFrame[])in_dest;

            if (this.m_cFrames <= in_index)
            {
                throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"));
            }

            for (int i = in_index; i < this.m_cFrames; i++)
            {
                frames[i] = this.m_frames[i];
            }
        }


        //=--------------------------------------------------------------=
        // Count                                             [ICollection]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   How many do we have so far?
        /// </summary>
        /// 
        /// <value>
        ///   A count of items in our collection.
        /// </value>
        /// 
        public int Count
        {
            get
            {
                return this.m_cFrames;
            }
        }


        //=--------------------------------------------------------------=
        // IsSynchronized                                    [ICollection]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Are we thread-safe?  No, we are not.
        /// </summary>
        /// 
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }


        //=--------------------------------------------------------------=
        // SyncRoot                                          [ICollection]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Object with which to synchronize for threading.  We are
        ///   not thread-safe, so this should be ignored.
        /// </summary>
        /// 
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }


        //=--------------------------------------------------------------=
        // GetEnumerator                                     [ICollection]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Returns an enumerator for the list of our TaskFrame controls
        /// </summary>
        /// 
        public System.Collections.IEnumerator GetEnumerator()
        {
            TaskFrame[] pages;

            //
            // If there's nothing to enumerate return nothing.
            //
            if ((this.m_frames == null) || this.m_cFrames == 0)
            {
                pages = new TaskFrame[]{};
                return pages.GetEnumerator();
            }

            //
            // we have to copy these over since we could have empty
            // slots in our array of pages that we're not using.
            //
            pages = new TaskFrame[this.m_cFrames]; // removed -1
            for (int i = 0; i < this.m_cFrames; i++)
            {
                pages[i] = this.m_frames[i];
            }

            return pages.GetEnumerator();
        }


        //=--------------------------------------------------------------=
        // Add
        //=--------------------------------------------------------------=
        /// <summary>
        ///   This is a strongly typed version of the Add method that
        ///   only takes TaskFrames ...
        /// </summary>
        /// 
        /// <param name="in_newFrame">
        ///   Adds the given frame to the collection.
        /// </param>
        /// 
        /// <returns>
        ///   The index at which the item was added.
        /// </returns>
        /// 
        public int Add(TaskFrame in_newFrame)
        {
            //
            // Arg Checking
            //
            if (in_newFrame == null)
            {
                throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"));
            }

            //
            // Please see the comments at the top of this file.  Basically, 
            // because people don't HAVE to use this collectin to add/remove
            // items, we initiate all adding and removing of this collection
            // off the Controls collection on the parent TaskPane.
            //
            this.m_parent.Controls.Add(in_newFrame);
            return IndexOf(in_newFrame);
        }


        //=--------------------------------------------------------------=
        // Add                                                     [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Adds a new frame to the end of the list.  This is the IList
        ///   version of this function and is NOT strongly typed for
        ///   TaskFrames.
        /// </summary>
        /// 
        /// <param name="in_newFrame">
        ///   The frame to add.
        /// </param>
        /// 
        /// <returns>
        ///   The index into which it was inserted.
        /// </returns>
        /// 
        public int Add(object in_newFrame)
        {
            TaskFrame tf;

            //
            // Arg Checking
            //
            if (in_newFrame == null)
            {
                throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"));
            }
            if (!(in_newFrame is TaskFrame))
            {
                throw new ArgumentException(string.Format(TaskPaneMain.GetResourceManager().GetString("excTaskPaneTaskFramesOnly"), in_newFrame.GetType().ToString()));
            }

            //
            // Get in the correct format
            //
            tf = (TaskFrame)in_newFrame;

            //
            // Pass the buck
            //
            return this.Add(tf);
        }


        //=--------------------------------------------------------------=
        // Clear                                                   [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Removes all the frames from this control
        /// </summary>
        /// 
        public void Clear()
        {
            if (this.m_frames == null)
            {
                return;
            }

            //
            // First clear out our control collection.  It's vital to
            // do this, as it keys off us for the list of controls ...
            //
            this.m_parent.Controls.Clear();
        }


        //=--------------------------------------------------------------=
        // Contains                                                [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Is the given frame one of ours?
        /// </summary>
        /// 
        /// <param name="in_amIFamily">
        ///   Is this one of our frames?
        /// </param>
        /// 
        /// <returns>
        ///   True == yes, False == nope.
        /// </returns>
        /// 
        public bool Contains(object in_amIFamily)
        {
            return !(IndexOf(in_amIFamily) == -1);
        }


        //=--------------------------------------------------------------=
        // IndexOf                                                 [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Returns the integer (zero-based) index of the item in 
        ///   our list, or returns -1 if we don't have it as a member.
        /// </summary>
        /// 
        /// <param name="in_findMyIndex">
        ///   The frame whose index in our collection we wish to find.
        /// </param>
        /// 
        /// <returns>
        ///   The zero-based integer index of this item in our collection of 
        ///   TaskFrames.
        /// </returns>
        /// 
        public int IndexOf(object in_findMyIndex)
        {
            for (int i = 0; i < this.m_cFrames; i++)
            {
                if (this.m_frames[i] == in_findMyIndex)
                {
                    return i;
                }
            }

            return -1;
        }


        //=--------------------------------------------------------------=
        // Insert                                                  [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Inserts the given Frame at the given index.
        /// </summary>
        /// 
        /// <param name="in_index">
        ///   Index at which to insert the given Frame.
        /// </param>
        /// 
        /// <param name="in_newPage">
        ///   The frame to insert into our collection.
        /// </param>
        /// 
        public void Insert(int in_index, object in_newPage)
        {
            throw new NotSupportedException();
        }


        //=--------------------------------------------------------------=
        // IsFixedSize                                             [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Are we a fixed size (nope).
        /// </summary>
        /// 
        /// <value>
        ///   False (no, we are not a fixed size).
        /// </value>
        /// 
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }


        //=--------------------------------------------------------------=
        // IsReadOnly                                              [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Are we read-only ? (nope)
        /// </summary>
        /// 
        /// <value>
        ///   False.  We are not read-only.
        /// </value>
        /// 
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }


        //=--------------------------------------------------------------=
        // Item
        //=--------------------------------------------------------------=
        /// <summary>
        ///   This is a strongly typed version of the Item() method
        ///   that is used by indexers and array references, etc ...  
        ///   This is preferred to the IList version, which only
        ///   supports Object.
        /// </summary>
        /// 
        /// <param name="in_index">
        ///   The index at which we'd like to find a TaskFrame.
        /// </param>
        /// 
        /// <value>
        ///   The TaskFrame at the given index.
        /// </value>
        /// 
        /// <remarks>
        ///   We do not support the Set() method on this because we do
        ///   not yet support arbitrary item insertion/replacement (this
        ///   is also true for other controls such as the TabControl,
        ///   etc).  We may.
        /// </remarks>
        /// 
        public TaskFrame this[int in_index]
        {
            get
            {
                // 
                // arg checking
                //
                if (in_index < 0 || in_index >= this.m_cFrames)
                {
                    throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"));
                }
                return this.m_frames[in_index];
            }

            set
            {
                throw new NotSupportedException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"));
            }
        }


        //=--------------------------------------------------------------=
        // IListItem                                               [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Returns the TaskFrame object at the given index.  This is
        ///   the IList version of this method that is NOT strongly typed
        ///   to TaskFrame (blech).
        /// </summary>
        /// 
        /// <param name="in_index">
        ///   Index at which we want to find a TaskFrame.
        /// </param>
        /// 
        /// <value>
        ///   The TaskFrame at the given index.
        /// </value>
        /// 
        object IList.this[int in_index]
        {
            get
            {
                // 
                // arg checking
                //
                if (in_index < 0 || in_index >= this.m_cFrames)
                {
                    throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"));
                }

                return this.m_frames[in_index];
            }

            set
            {
                throw new NotSupportedException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneInsertNotImpl"));
            }
        }

        //=--------------------------------------------------------------=
        // Remove
        //=--------------------------------------------------------------=
        /// <summary>
        ///   This is an overloaded version of the Remove method that
        ///   goes and removes only those objects that are of type TaskFrame.
        /// </summary>
        /// 
        /// <param name="in_removeMe">
        ///   TaskFrame to remove.
        /// </param>
        /// 
        public void Remove(TaskFrame in_removeMe)
        {
            if (in_removeMe == null)
            {
                throw new ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()");
            }

            //
            // Tell our parent's controls collection to remove this.
            // Part of that operation will be to call removeFrameInternal
            // on THIS class, which will remove it from our collection ...
            //
            this.m_parent.Controls.Remove(in_removeMe);

        }


        //=--------------------------------------------------------------=
        // Remove                                                  [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Removes the given frame from our collection of frames.
        /// </summary>
        /// 
        /// <param name="in_removeMe">
        ///   TaskFrame to remove.
        /// </param>
        /// 
        public void Remove(object in_removeMe)
        {

           TaskFrame tf;

            if (in_removeMe == null)
            {
                throw new ArgumentNullException("in_removeMe", "In TaskFrameCollection.Remove()");
            }

            tf = (TaskFrame)in_removeMe;
            if (tf == null)
            {
                throw new ArgumentException("Object passed to TaskFrameCollection is not a TaskFrame.");
            }

            //
            // Pass the buck on.
            //
            this.Remove(in_removeMe);
        }


        //=--------------------------------------------------------------=
        // RemoveAt                                                [IList]
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Removes the TaskFrame at the given index.
        /// </summary>
        /// 
        /// <param name="in_index">
        ///   Index whose TaskFrame we wish removed.
        /// </param>
        /// 
        public void RemoveAt(int in_index)
        {
            //
            // 0. arg checking
            //
            if (in_index < 0 || in_index >= this.m_cFrames)
            {
                throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneBogusIdx"));
            }

            //
            // 1. Pass the buck.
            //
            this.Remove(this.m_frames[in_index]);
        }




        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //          Private/Protected/Friend    Methods, Members, etc
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=
        //=--------------------------------------------------------------=

        //=--------------------------------------------------------------=
        // addFrameInternal
        //=--------------------------------------------------------------=
        /// <summary>
        ///   The programmer is trying to add the frame to the TaskPane's
        ///   Controls collection instead of adding it to this collection.
        ///   The ControlCollection will call this to be sure that it
        ///   gets added to this collection anyhow.
        /// </summary>
        /// 
        /// <param name="in_frame">
        ///   TaskFrame being added.
        /// </param>
        /// 
        internal void addFrameInternal(TaskFrame in_frame)
        {
            //
            // 1. make sure the array is big enough to hold it.
            //
            if (this.m_cFrames <= 0 && this.m_frames == null)
            {
                this.m_frames = new TaskFrame[7];

            }
            else if (this.m_cFrames + 1 >= this.m_frames.Length)
            {
                TaskFrame[] rep;

                rep = new TaskFrame[(this.m_cFrames * 2) - 1];
                Array.Copy(this.m_frames, rep, this.m_cFrames);

                this.m_frames = rep;

            }

            //
            // 2. Add the new Frame to our list, as well as our parent's
            //    control collection.
            //
            this.m_frames[this.m_cFrames] = in_frame;
            this.m_cFrames += 1;
        }


        //=--------------------------------------------------------------=
        // removeFrameInternal
        //=--------------------------------------------------------------=
        /// <summary>
        ///   This goes and actually removes the frame from our collection of
        ///   frames.  It is factored out from the Remove() methods on IList
        ///   because we also have to be able handle the case where the programmer
        ///   works with the  TaskPane.Controls collection ...
        /// </summary>
        /// 
        /// <param name="in_frame">
        ///   Frame to remove.
        /// </param>
        /// 
        internal void removeFrameInternal(TaskFrame in_frame)
        {
            if (in_frame == null)
            {
                throw new ArgumentException(TaskPaneMain.GetResourceManager().GetString("excTaskPaneNullFrame"));
            }

            //
            // now, go and look for this frame.  if we find it, 
            // then remove it.
            //
            for (int i = 0; i < this.m_cFrames; i++)
            {
                //
                // found it !!!!
                //
                if (this.m_frames[i] == in_frame)
                {
                    for (int x = i; x < this.m_cFrames; x++)
                    {
                        this.m_frames[x] = this.m_frames[x + 1];
                    }

                    this.m_cFrames -= 1;
                    return;
                }
            }

            //
            // Apparently, standard COR behaviour is to NOT throw an exception
            // if we're asked to remove something that isn't ours ...
            //
        } 


        //=--------------------------------------------------------------=
        // clearInternal
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Makes sure that we clear out our list of frames, etc ...
        /// </summary>
        /// 
        internal void clearInternal()
        {
            this.m_frames = null;
            this.m_cFrames = 0;
        }


    } 




    //=----------------------------------------------------------------------=
    // TaskPaneEventArgs
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   Provides information about the frame being manipulated in the current
    ///   event.
    /// </summary>
    /// 
    public class TaskPaneEventArgs : System.EventArgs
    {
        ///
        /// <summary>
        ///   The frame being manipulated by this event.
        /// </summary>
        /// 
        private TaskFrame m_taskFrame;



        //=--------------------------------------------------------------=
        // Constructor
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Initialize a new instance of this class.
        /// </summary>
        /// 
        /// <param name="in_frame">
        ///   Frame referred to in his event.
        /// </param>
        /// 
        public TaskPaneEventArgs(TaskFrame in_frame)
        {
            this.m_taskFrame = in_frame;
        }

        //=--------------------------------------------------------------=
        // TaskFrame
        //=--------------------------------------------------------------=
        /// <summary>
        ///   The frame to which this event refers.
        /// </summary>
        /// 
        [LocalisableDescription("TaskPaneEA.TaskFrame")]
        public TaskFrame TaskFrame
        {
            get
            {
                return this.m_taskFrame;
            }
        } 

    }


    //=----------------------------------------------------------------------=
    // TaskPaneCancelEventArgs
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   Allows a TaskPaneEvent to be cancelled
    /// </summary>
    /// 
    public class TaskPaneCancelEventArgs : TaskPaneEventArgs
    {
        /// 
        /// <summary>
        ///    Should this event be cancelled?
        /// </summary>
        /// 
        private bool m_cancel;


        //=--------------------------------------------------------------=
        // Constructor
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Initialize a new instance of this class
        /// </summary>
        /// 
        /// <param name="in_taskFrame">
        ///   Frame the generated this event.
        /// </param>
        /// 
        public TaskPaneCancelEventArgs(TaskFrame in_taskFrame)
            : base(in_taskFrame)
        {
        }


        //=--------------------------------------------------------------=
        // Cancel
        //=--------------------------------------------------------------=
        /// <summary>
        ///   Should the event be cancelled?
        /// </summary>
        /// 
        /// <value>
        ///   A boolean indicating whether the event should be cancelled or
        ///   not (True = cancel, false == permit).
        /// </value>
        /// 
        [LocalisableDescription("TaskPaneCEA.Cancel")]
        public bool Cancel
        {
            get
            {
                return this.m_cancel;
            }

            set
            {
                this.m_cancel = value;
            }
        } 
    }
}

//=====================================================================
//  File:      TaskPaneDesigner.cs
//
//  Summary:   This provides a lot of the advanced design time 
//             functionality desired/seen in our TaskPane control.
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

using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System;

namespace Microsoft.Samples.Windows.Forms.TaskPane.Design
{
    //=------------------------------------------------------------------=
    // TaskPaneDesigner
    //=------------------------------------------------------------------=
    /// <summary> 
    ///   This is the designer for the TaskPane control. 
    /// </summary>
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    public class TaskPaneDesigner : ScrollableControlDesigner
    {
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //              Private Member Variables, Enums, etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary> 
        /// We'll need this for some hit testing we'll do ...
        /// </summary>
        ///
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        extern static int SendMessage(System.IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        private const int WM_NCHITTEST = 0x84;
        private const int WM_VSCROLL = 0x115;
        private const int HTVSCROLL = 0x7;

        ///
        /// This is our collection of design-time verbs.
        ///
        private DesignerVerbCollection m_verbCollection;
        private DesignerVerb m_removeVerb;

        private bool m_disableDrawGrid;

        ///
        /// <summary>
        /// This helps us track the last selected TaskFrame, so we can provide
        /// clues to the user for the "Remove" verb, etc ...
        /// </summary>
        ///
        private TaskFrame m_lastFrameSelected;





        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                   Public Methods/Functions/Etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // Initialize
        //=------------------------------------------------------------------=
        /// <summary>
        /// We're a new designer. Initialize ourselves, set up some host pointers
        /// and listen to some events ...
        /// </summary>
        ///
        public override void Initialize(IComponent in_component)
        {
            IComponentChangeService iccs;
            ISelectionService selsvc;

            base.Initialize(in_component);

            System.Diagnostics.Debug.Assert((this.Control) is TaskPane);

            //
            // Add A selection change handler.
            //
            selsvc = (ISelectionService) GetService(typeof(ISelectionService));
            if (selsvc != null)
            {
                selsvc.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            }

            //
            // Hook up the ComponentChanging and ComponentChanged events
            //
            iccs = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
            if (iccs != null)
            {
                iccs.ComponentChanging += new ComponentChangingEventHandler(ComponentChanging);
                iccs.ComponentChanged += new ComponentChangedEventHandler(ComponentChanged);
            }

            this.m_disableDrawGrid = false;
        }


        //=------------------------------------------------------------------=
        // Dispose
        //=------------------------------------------------------------------=
        /// <summary>
        /// Allows us to clean up some of our state.
        /// </summary>
        ///
        protected override void Dispose(bool in_disposing)
        {
            IComponentChangeService iccs;
            ISelectionService selsvc;

            if (in_disposing)
            {
                //
                // Unhook the Selection changing service.
                //
                selsvc = (ISelectionService) GetService(typeof(ISelectionService));
                if (selsvc != null)
                {
                    selsvc.SelectionChanged -= new EventHandler(this.OnSelectionChanged);
                }

                //
                // Now, unhook the ComponentChanging and ComponentChanged events
                //
                iccs = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                if (iccs != null)
                {
                    iccs.ComponentChanging -= new ComponentChangingEventHandler(ComponentChanging);
                    iccs.ComponentChanged -= new ComponentChangedEventHandler(ComponentChanged);
                }
            }

            base.Dispose(in_disposing);
        }


        //=------------------------------------------------------------------=
        // AssociatedComponents
        //=------------------------------------------------------------------=
        /// <summary>
        /// Indicates with which components we are associated so that various
        /// cut/copy/paste/undo/redo operation type things will work fine.
        /// </summary>
        ///
        public override System.Collections.ICollection AssociatedComponents        
        {
            get
            {
                TaskPane tp;
                tp = (TaskPane) Control;
                if (tp != null)
                {
                    return tp.TaskFrames;
                }
                else
                {
                    return base.AssociatedComponents;
                }
            }
        }


        //=------------------------------------------------------------------=
        // Verbs
        //=------------------------------------------------------------------=
        /// <summary>
        /// Returns the list of verbs we support at DesignTime ...
        /// </summary>
        ///
        public override DesignerVerbCollection Verbs        
        {
            get
            {
                if (this.m_verbCollection==null)
                {
                    string s;
                    s = TaskPaneMain.GetResourceManager().GetString("TaskPaneMiscRemove");
                    this.m_verbCollection = new DesignerVerbCollection();
                    this.m_removeVerb = new DesignerVerb(TaskPaneMain.GetResourceManager().GetString("TaskPaneMiscRemove"), this.OnRemove);
                    this.m_removeVerb.Enabled = false;
                    this.m_verbCollection.Add(new DesignerVerb(TaskPaneMain.GetResourceManager().GetString("TaskPaneMiscAddNew"), new EventHandler(this.OnAdd)));
                    this.m_verbCollection.Add(this.m_removeVerb);
                }

                return this.m_verbCollection;
            }
        }


        //=------------------------------------------------------------------=
        // CanParent
        //=------------------------------------------------------------------=
        /// <summary>
        ///   TO what type of objects can we host?  TaskFrames.
        /// </summary>
        /// 
        public override bool CanParent(Control in_control)
        {
            if ((in_control) is TaskFrame)
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //         Private/Protected/Friend Methods/Functions/Etc.
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // DrawGrid
        //=------------------------------------------------------------------=
        /// <summary>
        /// We never support drawing a grid on this control at design time.
        /// </summary>
        /// 
        protected override bool DrawGrid
        {
            get
            {
                if (this.m_disableDrawGrid)
                {
                    return false;
                }
                return base.DrawGrid;
            }

            set
            {

                base.DrawGrid = value;
            }
        }


        //=------------------------------------------------------------------=
        // OnRemove
        //=------------------------------------------------------------------=
        /// <summary>
        /// The user has selected the "Remove" verb in the designer. 
        /// Remove the active TaskFrame.
        /// </summary>
        ///
        private void OnRemove(object sender, EventArgs e)
        {
            DesignerTransaction dt = null;
            MemberDescriptor md;
            IDesignerHost idh;
            TaskPane tp;

            //
            // Make sure we have a task pane with some valid frames !!!
            //
            tp = (TaskPane)this.Component;
            if (tp == null || this.m_lastFrameSelected == null || !tp.TaskFrames.Contains(this.m_lastFrameSelected))
            {
                return;
            }

            md = TypeDescriptor.GetProperties(this.Component)["Controls"];

            //
            // Get last selection taskframe.
            //
            //
            // get the designer host
            //
            idh = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (idh != null)
            {
                try
                {
                    try
                    {
                        dt = idh.CreateTransaction(TaskPaneMain.GetResourceManager().GetString("TaskPaneMiscTransR"));
                        RaiseComponentChanging(md);
                    }
                    catch (CheckoutException ex)
                    {
                        //
                        // If this was cancelled, then that's cool.
                        //
                        if (ex == CheckoutException.Canceled)
                        {
                            return;
                        }
                        throw ex;
                    }

                    idh.DestroyComponent(this.m_lastFrameSelected);
                    RaiseComponentChanged(md, null, null);
                    tp.Refresh();
                }
                finally
                {
                    if (dt != null) { dt.Commit(); }
                }
            }
        }


        //=------------------------------------------------------------------=
        // OnAdd
        //=------------------------------------------------------------------=
        /// <summary>
        /// The user has selected the 'Add' verb in the designer.  Go and 
        /// add a new TaskFrame to the TaskPane.  This is surprisingly 
        /// complicated ...
        /// </summary>
        ///
        private void OnAdd(object sender, EventArgs e)
        {
            DesignerTransaction dt = null;
            PropertyDescriptor pd;
            MemberDescriptor md;
            IDesignerHost idh;
            TaskFrame tf;
            TaskPane tp;

            tp = (TaskPane) this.Component;
            md = TypeDescriptor.GetProperties(this.Component)["Controls"];
            idh = (IDesignerHost) this.GetService(typeof(IDesignerHost));

            if (idh != null)
            {
                try
                {
                    try
                    {
                        dt = idh.CreateTransaction(TaskPaneMain.GetResourceManager().GetString("TaskPaneMiscTransA"));
                        RaiseComponentChanging(md);
                    }
                    catch(CheckoutException ex)
                    {
                        //
                        // if it was cancelled, then we have no problem.
                        //
                        if (ex==CheckoutException.Canceled)
                        {
                            return;
                        }

                        //
                        // otherwise, rethrow the exception.
                        //
                        throw ex;
                    }

                    //
                    // create the new component, name it, and then add it.
                    //
                    tf = (TaskFrame) idh.CreateComponent(typeof(TaskFrame));

                    pd = TypeDescriptor.GetProperties(tf)["Name"];
                    if (pd != null && pd.PropertyType == typeof(string))
                    {
                        tf.Text = (string) pd.GetValue(tf);
                    }

                    tp.Controls.Add(tf);

                    //
                    // Finally, fire some more events...
                    //
                    RaiseComponentChanged(md, null, null);
                }
                finally
                {
                    if (dt != null)
                    {
                        dt.Commit();
                    }
                }
            }
       }


        //=------------------------------------------------------------------=
        // ComponentChanging
        //=------------------------------------------------------------------=
        /// <summary>
        ///   A compnent is changing.  If it's the TaskFrames collection on a
        ///   TaskPane that's changing, make sure everybody knwos about it.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometht the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about the event.
        /// </param>
        /// 
        private void ComponentChanging(object sender, ComponentChangingEventArgs e)
        {
            if (e.Component==this.Component)
            {
                if (e.Member != null)
                {
                    if (e.Member.Name=="TaskFrames")
                    {
                        PropertyDescriptor pd;
                        pd = TypeDescriptor.GetProperties(this.Control)["Controls"];

                        RaiseComponentChanging(pd);
                    }
                }
            }
        } 


        //=------------------------------------------------------------------=
        // ComponentChanged
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Whenever our component changes, and it's the TaskFrames 
        ///   collection, we want to be sure the parent form knows about it.
        ///   We'll also take the chance to update our verb status.
        /// </summary>
        /// 
        /// <param name="sender">
        ///   From whence cometh the event.
        /// </param>
        /// 
        /// <param name="e">
        ///   Details about it.
        /// </param>
        /// 
        private void ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            if (e.Component == this.Component)
            {
                if (e.Member != null)
                {
                    if (e.Member.Name.Equals("TaskFrames"))
                    {
                        PropertyDescriptor pd;

                        pd = TypeDescriptor.GetProperties(this.Control)["Controls"];
                        RaiseComponentChanging(pd);
                    }
                }
            }

            checkVerbStatus();
        }


        //=------------------------------------------------------------------=
        // OnSelectionChanged
        //=------------------------------------------------------------------=
        /// <summary>
        /// The ISelectionService tells us when the selection has changed. 
        /// We'll use this to help us track which TaskFrame was last selected
        /// by the user.
        /// </summary>
        ///
        private void OnSelectionChanged(object sender, System.EventArgs e)
        {
            ISelectionService selsvc;
            TaskFrame tf;
            object c;

            selsvc = (ISelectionService)GetService(typeof(ISelectionService));
            if (selsvc != null)
            {
                c = selsvc.PrimarySelection;
                if (c != null)
                {
                    if (c is TaskFrame)
                    {
                        tf = (TaskFrame)c;
                        this.m_lastFrameSelected = tf;
                        tf.Parent.Refresh();
                    }
                }
            }

            checkVerbStatus();
        }


        //=------------------------------------------------------------------=
        // OnPaintAdornments
        //=------------------------------------------------------------------=
        /// <summary>
        /// Be sure that our child TaskFrames get their grid drawn correctly
        /// </summary>
        ///
        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            Pen p = null;
            TaskPane tp;
            Rectangle r;
            Color c;

            ///
            // Paint a highlight rect around the active  task frame, if there is one.
            //
            tp = (TaskPane) this.Control;
            if (this.m_lastFrameSelected != null
                && tp.TaskFrames.Contains(this.m_lastFrameSelected))
            {
                c = MiscFunctions.FlipColor(tp.BackColor);
                r = tp.GetCompletRectForFrame(this.m_lastFrameSelected);
                r.Inflate(2, 2);

                try
                {
                    p = new Pen(c, 2);
                    pe.Graphics.DrawRectangle(p, r);
                }
                finally
                {
                    if (p != null)
                    {
                        p.Dispose();
                    }
                }
            }

            //
            // get our child taskFrame  controls to draw their grid.
            try
            {
                this.m_disableDrawGrid = true;
                base.OnPaintAdornments(pe);
            }
            finally
            {
                this.m_disableDrawGrid = false;
            }
        }


        //=------------------------------------------------------------------=
        // getTaskFrameOfComponent
        //=------------------------------------------------------------------=
        /// <summary>
        /// Given some component, return the TaskFrame in which it lives, or
        /// null if it's not in a TaskFrame.
        /// </summary>
        ///
        private TaskFrame getTaskFrameOfComponent(Component in_comp)
        {
            Control c;

            if (!(in_comp is Control))
            {
                return null;
            }

            //
            // Walk up the parent chain until we find the TaskFrame or run out of parents
            //
            c = (Control) in_comp;
            while ((c != null) && (!(c is TaskFrame)))
            {
                c = c.Parent;
            }

            return ((TaskFrame) c);
        }


        //=------------------------------------------------------------------=
        // checkVerbStatus
        //=------------------------------------------------------------------=
        /// <summary>
        /// Figures out whether we should enable/disable the Remove TaskFrame
        /// verb.
        /// </summary>
        ///
        private void checkVerbStatus()
        {
            TaskPane tp;

            if (this.m_removeVerb==null) {return;}

            //
            // If there's a last frame active, make sure it's still valid.
            //
            if (this.m_lastFrameSelected != null)
            {
                tp = (TaskPane) this.Control;
                if (tp != null)
                {
                    if (!tp.TaskFrames.Contains(this.m_lastFrameSelected))
                    {
                        this.m_lastFrameSelected = null;
                    }
                }
            }

            //
            // Okay, if we've still got it, then go and enable the remove verb
            //
            if (this.m_lastFrameSelected != null)
            {
                this.m_removeVerb.Enabled = true;
            }
            else
            {
                this.m_removeVerb.Enabled = false;
            }
        } 

    }

}



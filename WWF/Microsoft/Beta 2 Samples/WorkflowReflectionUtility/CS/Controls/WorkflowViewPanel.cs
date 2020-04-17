//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel;
using System.Collections.Generic;

namespace Microsoft.Samples.Workflow.WorkflowReflectionUtility.Components
{
    /// <summary>
    /// Panel for displaying a WorkflowView.
    /// </summary>
    public class WorkflowViewPanel : Panel
    {
        private DesignSurface surface;
        private WorkflowView workflowView;
        private IDesignerHost host;

        /// <summary>
        /// Display the specified workflow type.
        /// </summary>
        /// <param name="root">Type of the workflow.</param>
        public void DisplayType(Type root)
        {
            if (!typeof(Activity).IsAssignableFrom(root))
            {
                throw new ArgumentException("WorkflowViewPanel only supports displaying Activity objects.", "root");
            }

            this.surface = new DesignSurface();
            this.host = this.surface.GetService(typeof(IDesignerHost)) as IDesignerHost;

            TypeProvider provider = new TypeProvider(this.surface);
            provider.AddAssembly(typeof(string).Assembly);
            IServiceContainer container = this.surface.GetService(typeof(IServiceContainer)) as IServiceContainer;
            container.AddService(typeof(ITypeProvider), provider);

            if (this.host == null)
            {
                throw new ApplicationException("Cannot work with a null host.");
            }

            Queue<Activity> toProcess = new Queue<Activity>();

            try
            {
                toProcess.Enqueue((Activity)root.InvokeMember(string.Empty, System.Reflection.BindingFlags.CreateInstance, null, null, null));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Could not load workflow type: " + exc.ToString());
                this.surface = null;
                this.host = null;
                return;
            }

            // Do a non-recursive walk of the activity
            // tree to display all activities.
            while (toProcess.Count > 0)
            {
                Activity activity = toProcess.Dequeue();
                host.Container.Add(activity, activity.QualifiedName);

                if (activity is CompositeActivity)
                {
                    // TODO: Consider making more efficient by
                    // only adding CompositeActivity objects to 
                    // the toProcess Queue.  Will require special
                    // casing for the root activity since non-
                    // Composite roots are possible.
                    foreach (Activity child in ((CompositeActivity)activity).Activities)
                    {
                        toProcess.Enqueue(child);
                    }
                }
            }

            workflowView = new MouseDisabledWorkflowView(host as IServiceProvider);
            workflowView.Dock = DockStyle.Fill;

            this.Controls.Add(workflowView);
        }
    }

    /// <summary>
    /// A subclass of WorkflowView which disables some of the 
    /// capabilities.
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class MouseDisabledWorkflowView : WorkflowView
    {
        /// <summary>
        /// Create a new one and pass the provider down.
        /// </summary>
        /// <param name="provider"></param>
        public MouseDisabledWorkflowView(IServiceProvider provider)
            : base(provider)
        {
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            try
            {
                base.OnMouseMove(e);
            }
            catch
            {
                // Swallow exceptions.
                // There is a bug where rule containing
                // activities cause an exception unless a
                // full ISite is configured.
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Don't allow selecting objects
            // because we don't support drag drop.
        }
    }
}

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
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.WorkflowMonitor
{
    //ViewHost "hosts" the workflow designer and graphically displays the workflow definition
    public class ViewHost : Control, IMemberCreationService
    {
        public void SaveWorkflowImage(Stream s, ImageFormat format)
        {

            this._view.SaveWorkflowImage(s, format);
        }
        private Loader _loader = null;
        private WorkflowDesignSurface _surface = null;
       

        private WorkflowView _view = null;

        internal event EventHandler<ZoomChangedEventArgs> ZoomChanged;

        public ViewHost()
        {
           
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Dock = DockStyle.Fill;
            this.Name = "viewHost";

            Initialize();

            SuspendLayout();
            ResumeLayout(true);

            this.BackColor = SystemColors.Control;
            //WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
            this.workflowStatusList = new Dictionary<string, WorkflowStatusInfo>();
            this.activityStatusListValue = new Dictionary<string, ActivityStatusInfo>();
        }

        



        //Expand or collapse all composite activities
        internal void Expand(bool expand)
        {
            IDesignerHost host = GetService(typeof(IDesignerHost)) as IDesignerHost;
            if (host == null)
                return;

            this.SuspendLayout();

            CompositeActivity root = host.RootComponent as CompositeActivity;
            foreach (Activity activity in root.Activities)
            {
                CompositeActivityDesigner compositeActivityDesigner = host.GetDesigner((IComponent)activity) as CompositeActivityDesigner;
                if (compositeActivityDesigner != null)
                {
                    compositeActivityDesigner.Expanded = expand;
                }
            }

            this.ResumeLayout(true);
        }

        internal WorkflowView WorkflowView
        {
            get
            {
                return this._view;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                Clear();

            base.Dispose(disposing);
        }

        protected override object GetService(Type serviceType)
        {
            if (this._surface != null)
                return this._surface.GetService(serviceType);
            else
                return null;
        }


        internal Activity GetRoot(Activity child)
        {
            Activity temp = child;
            while (temp.Parent != null)
            {
                temp = temp.Parent;
            }
            return temp;


        }
        internal Activity[] GetStateParentActivity(Activity child)
        {
            if (child.Parent == null)
                return new Activity[] { null, null };
            Activity activity1 = child;
            Activity temp = null;
            while (activity1.GetType() != typeof(StateActivity) || activity1.Parent == null)
            {
                temp = activity1;
                activity1 = activity1.Parent;

            }
            return new Activity[] { activity1, temp };

        }
        public void HighlightActivity(string activityName)
        {
            ISelectionService selectionService = (ISelectionService)_surface.GetService(typeof(ISelectionService));
            IReferenceService referenceService = (IReferenceService)_surface.GetService(typeof(IReferenceService));
            if (selectionService != null && referenceService != null)
            {
                Activity activityComponent = (Activity)referenceService.GetReference(activityName);

                if (activityComponent != null)
                {

                    IDesignerHost designerHost = _surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (designerHost != null)
                    {

                        Activity root = GetRoot(activityComponent);
                        bool statemachine = root is StateMachineWorkflowActivity;
                        if (statemachine)
                        {
                            Activity[] parents = GetStateParentActivity(activityComponent);
                            Activity state = parents[1];
                            Activity pstate = parents[0];
                            if (state != null && pstate != null)
                            {
                                ActivityDesigner sd = designerHost.GetDesigner(state) as ActivityDesigner;
                                FreeformActivityDesigner parentd = designerHost.GetDesigner(pstate) as FreeformActivityDesigner;
                                parentd.EnsureVisibleContainedDesigner(sd);
                            }
                        }
                        ActivityDesigner ad = designerHost.GetDesigner(activityComponent) as ActivityDesigner;

                        //ad.DesignerTheme.BackColorEnd = Color.OrangeRed;
                        //ad.DesignerTheme.BackColorStart = Color.OrangeRed;
                        selectionService.SetSelectedComponents(new IComponent[] { activityComponent as IComponent }, SelectionTypes.Primary);
                        _view.PerformLayout(true);

                    }
                }
            }
        }


        //Loads the workflow definition into the designer 
        public void OpenWorkflow(Activity workflowDefinition)
        {
            Initialize();

            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (host == null)
                return;

            Controls.Remove(this._view);

            _loader.WorkflowDefinition = workflowDefinition;
            this._surface.BeginLoad(this._loader);

            this._view = new WorkflowView(this._surface as IServiceProvider);
            _view.ZoomChanged += new EventHandler(workflowViewValue_ZoomChanged);
            IDesignerGlyphProviderService glyphService = this._surface.GetService(typeof(IDesignerGlyphProviderService)) as IDesignerGlyphProviderService;
            WorkflowMonitorDesignerGlyphProvider glyphProvider = new WorkflowMonitorDesignerGlyphProvider(ActivityStatusList);
            glyphService.AddGlyphProvider(glyphProvider);

            _view.Dock = DockStyle.Fill;
            Controls.Add(_view);

            ((IDesignerLoaderHost)host).EndLoad(host.RootComponent.Site.Name, true, null);
        }
        internal Dictionary<string, ActivityStatusInfo> ActivityStatusList
        {
            get { return activityStatusListValue; }
        }
        private Dictionary<string, WorkflowStatusInfo> workflowStatusList = null;
        private Dictionary<string, ActivityStatusInfo> activityStatusListValue = null;
        public void SetTrackingInstance(SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance)
        {
            for (int index = sqlTrackingWorkflowInstance.ActivityEvents.Count; index >= 1; index--)
            {
                ActivityTrackingRecord activityTrackingRecord = sqlTrackingWorkflowInstance.ActivityEvents[index - 1];
                if (!activityStatusListValue.ContainsKey(activityTrackingRecord.QualifiedName))
                {
                    ActivityStatusInfo latestActivityStatus = new ActivityStatusInfo(activityTrackingRecord.QualifiedName, activityTrackingRecord.ExecutionStatus.ToString());
                    activityStatusListValue.Add(activityTrackingRecord.QualifiedName, latestActivityStatus);

                    string[] activitiesListViewItems = new string[] {
                        activityTrackingRecord.EventOrder.ToString(),
                        activityTrackingRecord.QualifiedName, 
                        activityTrackingRecord.ExecutionStatus.ToString()};
                   
                }
            }
            this.Refresh();
        }
        //Initializes the designer setting up the services, surface, and loader
        private void Initialize()
        {
            this._loader = new Loader();
            this._surface = new WorkflowDesignSurface(this);
        }

        private void Clear()
        {
            if (this._surface == null)
                return;

            this.Controls.Clear();
            this._surface.Dispose();
            this._surface = null;
            this._loader = null;
        }

        void workflowViewValue_ZoomChanged(object sender, EventArgs e)
        {
            ZoomChanged(null, new ZoomChangedEventArgs(_view.Zoom));
        }

   

        #region IMemberCreationService Members
        // Designer host requires an IMemberCreationService - we don't need this functionality
        // so all of the methods are blank

		void IMemberCreationService.CreateField(string className, string fieldName, Type fieldType, Type[] genericParameterTypes, MemberAttributes attributes, CodeSnippetExpression initializationExpression, bool overwriteExisting) { }
		void IMemberCreationService.CreateProperty(string className, string propertyName, Type propertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty, bool isAttached, Type ownerType, bool isReadOnly) { }
		void IMemberCreationService.CreateEvent(string className, string eventName, Type eventType, AttributeInfo[] attributes, bool emitDependencyProperty) { }
		
        void IMemberCreationService.UpdateTypeName(string oldClassName, string newClassName) { }
		void IMemberCreationService.UpdateProperty(string className, string oldPropertyName, Type oldPropertyType, string newPropertyName, Type newPropertyType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty) { }
		void IMemberCreationService.UpdateEvent(string className, string oldEventName, Type oldEventType, string newEventName, Type newEventType, AttributeInfo[] attributes, bool emitDependencyProperty, bool isMetaProperty) { }
		void IMemberCreationService.UpdateBaseType(string className, Type baseType) { }
		
		void IMemberCreationService.RemoveProperty(string className, string propertyName, Type propertyType) { }
		void IMemberCreationService.RemoveEvent(string className, string eventName, Type eventType) { }

		void IMemberCreationService.ShowCode(Activity activity, string methodName, Type delegateType) { }
		void IMemberCreationService.ShowCode() { }

        #endregion

        internal class ZoomChangedEventArgs : EventArgs
        {
            private Int32 zoomValue;

            public Int32 Zoom
            {
                get { return zoomValue; }
                set { zoomValue = value; }
            }
            public ZoomChangedEventArgs(Int32 zoom)
            {
                zoomValue = zoom;
            }
        }
    }
}

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

namespace Microsoft.Samples.Workflow.WorkflowMonitor
{
    //ViewHost "hosts" the workflow designer and graphically displays the workflow definition
    public class ViewHost : Control, IMemberCreationService
    {
        public void SaveWorkflowImage(Stream s, ImageFormat format)
        {

            this.workflowViewValue.SaveWorkflowImage(s, format);
        }
        private Loader loader = null;
        private WorkflowDesignSurface surface = null;
       

        private WorkflowView workflowViewValue = null;

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
            WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = false;
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
                return this.workflowViewValue;
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
            if (this.surface != null)
                return this.surface.GetService(serviceType);
            else
                return null;
        }

        //Loads the workflow definition into the designer 
        public void OpenWorkflow(Activity workflowDefinition)
        {
            Initialize();

            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (host == null)
                return;

            Controls.Remove(this.workflowViewValue);

            loader.WorkflowDefinition = workflowDefinition;
            this.surface.BeginLoad(this.loader);

            this.workflowViewValue = new WorkflowView(this.surface as IServiceProvider);
            workflowViewValue.ZoomChanged += new EventHandler(workflowViewValue_ZoomChanged);
            IDesignerGlyphProviderService glyphService = this.surface.GetService(typeof(IDesignerGlyphProviderService)) as IDesignerGlyphProviderService;
            WorkflowMonitorDesignerGlyphProvider glyphProvider = new WorkflowMonitorDesignerGlyphProvider(ActivityStatusList);
            glyphService.AddGlyphProvider(glyphProvider);

            workflowViewValue.Dock = DockStyle.Fill;
            Controls.Add(workflowViewValue);

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
            this.loader = new Loader();
            this.surface = new WorkflowDesignSurface(this);
        }

        private void Clear()
        {
            if (this.surface == null)
                return;

            this.Controls.Clear();
            this.surface.Dispose();
            this.surface = null;
            this.loader = null;
        }

        void workflowViewValue_ZoomChanged(object sender, EventArgs e)
        {
            ZoomChanged(null, new ZoomChangedEventArgs(workflowViewValue.Zoom));
        }

        internal void HighlightActivity(String activityName)
        {
            ISelectionService selectionService = (ISelectionService)surface.GetService(typeof(ISelectionService));
            IReferenceService referenceService = (IReferenceService)surface.GetService(typeof(IReferenceService));
            if (selectionService != null && referenceService != null)
            {
                Activity activityComponent = (Activity)referenceService.GetReference(activityName);
                if (activityComponent != null)
                    selectionService.SetSelectedComponents(new IComponent[] { activityComponent as IComponent });
            }
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

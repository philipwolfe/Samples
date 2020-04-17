using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    public class XomlDesignViewControl : UserControl
    {
        private ViewHost viewHost = null;
        public event OnPrepareContextMenu OnPrepareContextMenu;

        public XomlDesignViewControl()
        {
            //Now initialize the contained components
            this.viewHost = new ViewHost();
            this.viewHost.OnPrepareContextMenu += new OnPrepareContextMenu(viewHost_OnPrepareContextMenu);
            this.viewHost.Dock = DockStyle.Fill;
            this.Controls.Add(this.viewHost);
        }

        public void Open(string xoml, bool readOnly)
        {
            if (xoml != null)
                this.viewHost.Open(xoml, readOnly);
        }

        public void PopulateActivityStateProvider(ActivityStateProvider activityStateProvider)
        {
            if (this.viewHost != null)
            {
                this.viewHost.ProfferService(typeof(IActivityStateProvider), activityStateProvider);
                this.viewHost.WorkflowView.Invalidate();
            }
        }

        public IServiceProvider GetServiceProvider()
        {
            return this.viewHost;
        }
        public Activity GetRootActivity()
        {
            return this.viewHost.GetRootActivity();
        }

        public void UpdTrackedEventateSelection(object[] selectedEvents)
        {
            WorkflowView workflowView = this.viewHost.WorkflowView;
            if (workflowView != null)
            {
                Hashtable trackedActivities = new Hashtable();
                foreach (TrackedActivity trackedActivity in selectedEvents)
                {
                    //see if there is already a later event for the id
                    if (trackedActivities.Contains(trackedActivity.QualifiedName))
                    {
                        TrackedActivity otherTrackedActivity = trackedActivities[trackedActivity.QualifiedName] as TrackedActivity;
                        if (trackedActivity.EventDateTime > otherTrackedActivity.EventDateTime)
                            trackedActivities.Remove(trackedActivity.QualifiedName);
                    }
                    if (!trackedActivities.Contains(trackedActivity.QualifiedName))
                        trackedActivities.Add(trackedActivity.QualifiedName, trackedActivity);
                }

                //now lets walk the activity tree and see if we got an event for any activity
                Walker walker = new Walker();
                walker.FoundActivity += delegate(Walker skedWalker, WalkerEventArgs eventArgs)
                {
                    Activity activity = eventArgs.CurrentActivity;
                    TrackedActivity trackedActivity = trackedActivities[activity.QualifiedName] as TrackedActivity;
                    if (trackedActivity != null)
                    {
                        UpdateCurrentSelectedActivity(activity);
                    }
                };
                walker.Walk(workflowView.RootDesigner.Activity);
                workflowView.Invalidate();
            }
        }

        private void UpdateCurrentSelectedActivity(Activity activity)
        {
            WorkflowView workflowView = this.viewHost.WorkflowView;
            ISelectionService selectionService = ((IServiceProvider)this.viewHost).GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SetSelectedComponents(new IComponent[] { activity }, SelectionTypes.Replace);

            workflowView.EnsureVisible(activity);
        }

        void viewHost_OnPrepareContextMenu(Activity[] selectedActivities, ArrayList menuItems)
        {
            if (this.OnPrepareContextMenu != null)
                this.OnPrepareContextMenu.DynamicInvoke(new object[] { selectedActivities, menuItems });
        }
    }
}
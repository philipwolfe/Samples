using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using Microsoft.Workflow.Samples.Administration;
using Microsoft.Workflow.Samples.WorkflowManager.Design;
using Microsoft.Workflow.Samples.WorkflowManager.DesignerHosting;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    partial class WorkflowDetailsControl : UserControl, IDisposable
    {
        private IWorkflowInstance instance;
        private LiveInstanceProxy liveInstance;
        private Nullable<bool> inEditMode = null;

        private ExtendedDocumentOutline extendedDocumentOutline = null;
        private XomlDesignViewControl xomlDesignView = null;
        private Toolbox toolbox = null;
        private ActivityStateProvider activityStateProvider = null;
        private DynamicUpdateDriver dynamicUpdateDriver = null;

        public event EventHandler InstanceStateChanged;

        public WorkflowDetailsControl(IWorkflowInstance instance)
        {
            this.instance = instance;
            if (this.instance is LiveInstanceProxy)
                this.liveInstance = this.instance as LiveInstanceProxy;

            InitializeComponent();

            PopulateInstanceView();
            PopulateStateView();

            if (this.liveInstance != null)
                this.liveInstance.OnInstanceStateChanged += new EventHandler(liveInstance_OnInstanceStateChanged);
        }

        void IDisposable.Dispose()
        {
            if (this.liveInstance != null)
                this.liveInstance.OnInstanceStateChanged -= new EventHandler(liveInstance_OnInstanceStateChanged);

            if (this.xomlDesignView != null)
            {
                // Get an ISelectionService service
                IServiceProvider serviceProvider = this.xomlDesignView.GetServiceProvider();
                ISelectionService selectionService = serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
                if (selectionService != null)
                    selectionService.SelectionChanged -= new System.EventHandler(OnSelectionChanged);
            }

            if (this.xomlDesignView != null)
            {
                this.xomlDesignView.OnPrepareContextMenu -= new OnPrepareContextMenu(PrepareContextMenu);
            }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (base.BackColor == value)
                    return;

                base.BackColor = value;

                this.workflow_toolboxSpliContainer.BackColor = base.BackColor;
                this.rootSplitContainer.BackColor = base.BackColor;
                this.toolbox_PropGridSplitContainer.BackColor = base.BackColor;
            }
        }

        //ui specific function only - toolbox ui control state update, no real work here
        public bool InEditMode
        {
            get
            {
                if (this.inEditMode == null || this.inEditMode == false)
                    return false;
                else
                    return true;
            }
            set
            {
                if (this.inEditMode == value)
                    return;

                this.inEditMode = value;

                if (this.toolbox != null)
                {
                    this.toolbox.Enabled = InEditMode;
                    this.toolbox.BackColor = InEditMode ? SystemColors.Window : SystemColors.Control;
                }
            }
        }

        public void Suspend()
        {
            if (this.liveInstance != null)
                this.liveInstance.Suspend();
        }
        public void Resume()
        {
            if (this.liveInstance != null)
                this.liveInstance.Resume();
        }
        public void Terminate()
        {
            if (this.liveInstance != null)
                this.liveInstance.Terminate();
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            IServiceProvider serviceProvider = this.xomlDesignView.GetServiceProvider();
            ISelectionService selectionService = serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
            {
                IComponent selectedComponent = selectionService.PrimarySelection as IComponent;

                if (selectedComponent != null)
                {
                    this.propertyGrid.Site = selectedComponent.Site;
                    this.propertyGrid.SelectedObject = selectionService.PrimarySelection;
                }
                else
                {
                    this.propertyGrid.SelectedObject = null;
                    this.propertyGrid.Site = null;
                }
            }
        }

        void liveInstance_OnInstanceStateChanged(object sender, EventArgs e)
        {
            if (e is ActivityStateChangeEventArgs)
            {
                PopulateStateView();
            }
            else if (e is WorkflowStateChangeEventArgs)
            {
            }
            else if (e is DynamicUpdateEventArgs)
            {
                PopulateInstanceView();
                PopulateStateView();
            }
            else if (e is InstanceStateChangeEventArgs)
            {
                if (InstanceStateChanged != null)
                    InstanceStateChanged(this, e);
            }
        }

        private void PopulateInstanceView()
        {
            if (this.xomlDesignView != null)
            {
                // Get an ISelectionService service
                IServiceProvider provider = this.xomlDesignView.GetServiceProvider();
                ISelectionService selectionSvs = provider.GetService(typeof(ISelectionService)) as ISelectionService;
                if (selectionSvs != null)
                    selectionSvs.SelectionChanged -= new System.EventHandler(OnSelectionChanged);
            }
            else
            {
                //create the xoml view from the scratch
                this.xomlDesignView = new XomlDesignViewControl();
                this.xomlDesignView.Dock = DockStyle.Fill;
                this.workflow_toolboxSpliContainer.Panel1.Controls.Add(this.xomlDesignView);
                this.xomlDesignView.OnPrepareContextMenu += new OnPrepareContextMenu(PrepareContextMenu);
            }

            //reload the xoml
            this.xomlDesignView.Open(this.instance.Xoml, this.readOnlyMode);
            IServiceProvider serviceProvider = this.xomlDesignView.GetServiceProvider();

            this.toolbox = serviceProvider.GetService(typeof(IToolboxService)) as Toolbox;
            if (this.toolbox != null)
            {
                this.toolbox_PropGridSplitContainer.Panel1.Controls.Clear();
                this.toolbox.Visible = true;
                this.toolbox.Enabled = false;
                this.toolbox.BorderStyle = BorderStyle.FixedSingle;
                this.toolbox.Dock = DockStyle.Fill;
                this.toolbox_PropGridSplitContainer.Panel1.Controls.Add(this.toolbox);
            }

            //create and populate the doc outline
            if (this.extendedDocumentOutline == null)
            {
                this.extendedDocumentOutline = new ExtendedDocumentOutline(serviceProvider);
                this.extendedDocumentOutline.Dock = DockStyle.Fill;
                this.rootSplitContainer.Panel1.Controls.Add(this.extendedDocumentOutline);
            }
            else
            {
                this.extendedDocumentOutline.ResetServiceProvider(serviceProvider);
            }

            // Get an ISelectionService service
            ISelectionService selectionService = serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SelectionChanged += new System.EventHandler(OnSelectionChanged);
        }

        private void PopulateStateView()
        {
            this.activityStateProvider = new ActivityStateProvider(this.instance.ActivityStateList);
            this.xomlDesignView.PopulateActivityStateProvider(this.activityStateProvider);

            IServiceProvider serviceProvider = this.xomlDesignView.GetServiceProvider();
            this.extendedDocumentOutline.ResetServiceProvider(serviceProvider);
        }

        private void PrepareContextMenu(Activity[] selectedActivities, ArrayList menuItems)
        {
            //no action allowed on tracked activities
            if (this.liveInstance == null)
                return;

            MenuItem deleteActivityMenuItem = new SelectedItemsActivityMenuItem("Delete Activity in this Instance", new EventHandler(OnDeleteActivity), selectedActivities);
            menuItems.Add(deleteActivityMenuItem);
        }

        private class SelectedItemsActivityMenuItem : MenuItem
        {
            private Activity[] selectedActivities;
            public SelectedItemsActivityMenuItem(string text, EventHandler eventHandler, Activity[] selectedActivities)
                : base(text, eventHandler)
            {
                this.selectedActivities = selectedActivities;
            }
            public Activity[] SelectedActivities
            {
                get { return this.selectedActivities; }
            }
        }

        private class ActivityStatusMenuItem : SelectedItemsActivityMenuItem
        {
            private int trackingContext;

            public ActivityStatusMenuItem(string text, EventHandler eventHandler, Activity[] selectedActivities, int trackingContext)
                : base(text, eventHandler, selectedActivities)
            {
                this.trackingContext = trackingContext;
            }

            public int TrackingContext
            {
                get { return this.trackingContext; }
            }
        }

        #region Dynamic updates

        #region little self contained deletion of single activities
        //a little self contained deletion of a singe activity
        private void OnDeleteActivity(object sender, EventArgs args)
        {
            SelectedItemsActivityMenuItem item = sender as SelectedItemsActivityMenuItem;
            foreach (Activity activity in item.SelectedActivities)
                this.liveInstance.DeleteActivity(activity.QualifiedName);
        }
        #endregion

        #region full blown ui-driven dynamic update
        private bool readOnlyMode = true;//when loaded it will be read-only

        public void OnDynamicUpdateEnabled()
        {
            //get a proxy, sink up the component changed events
            this.readOnlyMode = false;//enable changes

            PopulateInstanceView();//reload the wf design surface
            PopulateStateView();

            this.dynamicUpdateDriver = new DynamicUpdateDriver(this.xomlDesignView.GetServiceProvider(), this.liveInstance, this.xomlDesignView.GetRootActivity());
        }

        public void OnDynamicUpdateCanceled()
        {
            //cancel on a proxy, un-sink up the component changed events
            this.readOnlyMode = true;//enable changes

            //do not talk to the runtime, simply dispose the driver (runtime gets called only when we do commit)
            this.dynamicUpdateDriver.Dispose();
            this.dynamicUpdateDriver = null;

            PopulateInstanceView();
            PopulateStateView();
        }

        public void OnDynamicUpdateCommit()
        {
            this.readOnlyMode = true;//enable changes

            //commit on a proxy, un-sink up the component changed events
            this.dynamicUpdateDriver.Commit();
            this.dynamicUpdateDriver.Dispose();
            this.dynamicUpdateDriver = null;

            PopulateInstanceView();
            PopulateStateView();
        }

        #region Dynamic update driver
        private class DynamicUpdateDriver : IDisposable
        {
            private LiveInstanceProxy liveInstance;
            private IServiceProvider serviceProvider;

            //when loading up, we will populate the originalActivities with all existing activities
            private Dictionary<string, Activity> originalActivities = new Dictionary<string, Activity>();

            //for every change wi'll add an entry in the list below
            //the admin service will simply apply the changes in the same order
            private List<ActivityDynamicChangeLog> dynamicUpdates = new List<ActivityDynamicChangeLog>();

            public DynamicUpdateDriver(IServiceProvider serviceProvider, LiveInstanceProxy liveInstance, Activity rootActivity)
            {
                this.serviceProvider = serviceProvider;
                this.liveInstance = liveInstance;

                IComponentChangeService componentChangeService = this.serviceProvider.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                if (componentChangeService != null)
                    componentChangeService.ComponentChanged += new ComponentChangedEventHandler(componentChangeService_ComponentChanged);

                //build the hashtable of activityIds to activities
                Walker walker = new Walker();
                walker.FoundActivity += delegate(Walker skedWalker, WalkerEventArgs eventArgs)
                {
                    Activity activity = eventArgs.CurrentActivity;
                    this.originalActivities.Add(activity.QualifiedName, activity);
                };
                walker.Walk(rootActivity);
            }

            public void Dispose()
            {
                IComponentChangeService componentChangeService = this.serviceProvider.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                if (componentChangeService != null)
                    componentChangeService.ComponentChanged -= new ComponentChangedEventHandler(componentChangeService_ComponentChanged);
            }

            public void Commit()
            {
                DynamicUpdateCommitData dynamicUpdateCommitData = new DynamicUpdateCommitData(dynamicUpdates.ToArray() /*deletedActivitiesList.ToArray(), addedActivitiesList.ToArray(), modifiedActivitiesList.ToArray()*/);
                string result = this.liveInstance.ApplyDynamicUpdateBatch(dynamicUpdateCommitData);
                if (result != null && result.Length > 0)
                    MessageBox.Show("error while trying to apply the update to the running instance:\n" + result);
            }

            void componentChangeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
            {
                Activity modifiedActivity = e.Component as Activity;
                if (modifiedActivity != null)
                {
                    if (e.NewValue == null && e.OldValue != null)
                    {
                        ActivityCollectionChangeEventArgs collectionChangedArgs = e.OldValue as ActivityCollectionChangeEventArgs;
                        CompositeActivity owner = collectionChangedArgs.Owner as CompositeActivity;

                        if (collectionChangedArgs.RemovedItems.Count != 0 && collectionChangedArgs.AddedItems.Count == 0)
                        {
                            //deletion
                            IList<Activity> deletedActivities = collectionChangedArgs.RemovedItems;
                            foreach (Activity deletedActivity in deletedActivities)
                                this.dynamicUpdates.Add(new ActivityDynamicChangeLog(ActivityDynamicUpdateType.Remove, deletedActivity.Name, 0, owner.QualifiedName, null));
                        }
                        else if (collectionChangedArgs.RemovedItems.Count == 0 && collectionChangedArgs.AddedItems.Count != 0)
                        {
                            //addition
                            IList<Activity> addedActivities = collectionChangedArgs.AddedItems;
                            Loader loader = this.serviceProvider.GetService(typeof(Loader)) as Loader;
                            if (loader != null)
                                loader.UpdateCanModifyFlag(addedActivities);
                            foreach (Activity addedActivity in addedActivities)
                                this.dynamicUpdates.Add(new ActivityDynamicChangeLog(ActivityDynamicUpdateType.Add, addedActivity.QualifiedName, owner.Activities.IndexOf(addedActivity), owner.QualifiedName, DynamicUpdateCommitData.SerializeActivity(addedActivity)));
                        }
                        else
                        {
                            Debug.Assert(false, "strange addition/removal");
                        }
                    }
                    else if (e.NewValue != null && e.OldValue != null)
                    {
                        //modification
                        //the index is requied for changes of id.
                        if (modifiedActivity.Parent != null)
                        {
                            this.dynamicUpdates.Add(new ActivityDynamicChangeLog(ActivityDynamicUpdateType.Modify, modifiedActivity.QualifiedName, modifiedActivity.Parent.Activities.IndexOf(modifiedActivity), modifiedActivity.Parent.QualifiedName, DynamicUpdateCommitData.SerializeActivity(modifiedActivity)));
                        }
                        else
                        {
                            Debug.Assert(false, "we cant really change properties on the root activity since it cant be replaced");
                        }
                    }
                }
            }
        }
        #endregion

        #endregion

        #endregion

        public void InvokeStandardCommand(CommandID cmd)
        {
            try
            {
                if (this.xomlDesignView != null)
                {
                    IServiceProvider serviceProvider = this.xomlDesignView.GetServiceProvider();

                    IMenuCommandService menuService = serviceProvider.GetService(typeof(IMenuCommandService)) as IMenuCommandService;
                    if (menuService != null)
                        menuService.GlobalInvoke(cmd);
                }
            }
            catch
            {
                //We eat exceptions as some of the operations are not supported in samples
            }
        }
    }
}
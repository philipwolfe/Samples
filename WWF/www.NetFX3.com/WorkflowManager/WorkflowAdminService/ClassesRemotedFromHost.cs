using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using System.Xml;

namespace Microsoft.Workflow.Samples.Administration
{
    internal interface IUpdateRootActivity
    {
        void UpdateRootActivity(Guid instanceId, Activity root);
    }

    public sealed class AdministrationService : MarshalByRefObject, IStateChangeEventCallback, IUpdateRootActivity
    {
        #region Data members

        private WorkflowRuntime serviceContainer;
        private Dictionary<Guid, LiveWorkflowInstance> localInstances = new Dictionary<Guid, LiveWorkflowInstance>();
        private AdministrationServiceProxy eventProxy = null;
        private static AdministrationService administrationService = null;

        #endregion

        public static AdministrationService ConnectToRemoteService()
        {
            return AdministrationService.administrationService;
        }

        private static void RegisterAdministrationInstance(AdministrationService administrationService)
        {
            AdministrationService.administrationService = administrationService;
        }

        #region Constructor and Lifetime methods

        public AdministrationService(WorkflowRuntime serviceContainer)
        {
            this.serviceContainer = serviceContainer;
            this.serviceContainer.AddService(new TrackingEventsHelper(this));

            WorkflowRuntime instanceService = this.serviceContainer;
            instanceService.WorkflowStarted += new EventHandler<WorkflowEventArgs>(OnWorkflowStarted);
            instanceService.WorkflowSuspended += new EventHandler<WorkflowSuspendedEventArgs>(OnWorkflowSuspended);
            instanceService.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(OnWorkflowCompleted);
            instanceService.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(OnWorkflowTerminated);
            AdministrationService.RegisterAdministrationInstance(this);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void SetRemoteCallback()
        {
            this.eventProxy = AdministrationServiceProxy.ConnectToRemoteService();
        }

        #endregion

        #region interface and event handler implementations

        void IStateChangeEventCallback.OnStateChange(InstanceChangeEventArgs args)
        {
            LiveWorkflowInstance proxy = GetInstanceTableEntry(args.InstanceId);

            if (args is ActivityStateChangeEventArgs)
            {
                //this might get called when client makes a dynamic update
                TrackingRecord record = (args as ActivityStateChangeEventArgs).Record;
                if (record != null)
                    proxy.AddActivityStateChangeEntry(record);

                proxy.Suspended = false;//if it was suspended before, it will fire an event that it is running again
                proxy.Touch();
            }
            else if (args is WorkflowStateChangeEventArgs)
            {
            }
            else if (args is DynamicUpdateEventArgs)
            {
                proxy.Change();
            }
            else if (args is InstanceStateChangeEventArgs)
            {
                proxy.Change();
            }
            else if (args is TitleSetEventArgs)
            {
                TitleSetEventArgs titleSetEventArgs = args as TitleSetEventArgs;
                proxy.SetTitle(titleSetEventArgs.Title);
            }
        }

        private class CachedRootActivityInfo
        {
            private Guid instanceId;
            private Activity root;
            public CachedRootActivityInfo(Guid instanceId, Activity root)
            {
                this.instanceId = instanceId;
                this.root = root;
            }
            public Guid InstanceId
            {
                get { return this.instanceId; }
            }
            public Activity Root
            {
                get { return this.root; }
            }
        }

        private CachedRootActivityInfo cachedRootActivityInfo = null;
        void IUpdateRootActivity.UpdateRootActivity(Guid instanceId, Activity root)
        {
            if (this.localInstances.ContainsKey(instanceId))
            {
                LiveWorkflowInstance proxy = this.localInstances[instanceId];
                proxy.UpdateRootActivity(root);
            }
            else
            {
                //we will optimize the case when we first get info about the root activity
                this.cachedRootActivityInfo = new CachedRootActivityInfo(instanceId, root);
            }
        }

        private void OnWorkflowStarted(object sender, WorkflowEventArgs instanceArgs)
        {
            LiveWorkflowInstance instance = GetInstanceTableEntry(instanceArgs.WorkflowInstance);
            if (this.cachedRootActivityInfo != null && instance != null && this.cachedRootActivityInfo.InstanceId == instance.InstanceId)
            {
                instance.UpdateRootActivity(this.cachedRootActivityInfo.Root);
                this.cachedRootActivityInfo = null;
            }

            //signal the client so that it would update the list
            if (this.eventProxy != null)
                this.eventProxy.FireOnInstanceStateChanged(instanceArgs.WorkflowInstance.InstanceId, InstanceStateChangeType.Created);
        }

        private void OnWorkflowCompleted(object sender, WorkflowCompletedEventArgs instanceArgs)
        {
            LiveWorkflowInstance proxy = GetInstanceTableEntry(instanceArgs.WorkflowInstance);
            proxy.Completed = true;
            if (!proxy.InChange && this.eventProxy != null)
                this.eventProxy.FireOnInstanceStateChanged(instanceArgs.WorkflowInstance.InstanceId, InstanceStateChangeType.Completed);

            RemoveInstanceTableEntry(proxy);
        }
        private void OnWorkflowTerminated(object sender, WorkflowTerminatedEventArgs instanceArgs)
        {
            LiveWorkflowInstance proxy = GetInstanceTableEntry(instanceArgs.WorkflowInstance);
            proxy.Completed = true;
            if (!proxy.InChange && this.eventProxy != null)
                this.eventProxy.FireOnInstanceStateChanged(instanceArgs.WorkflowInstance.InstanceId, InstanceStateChangeType.Terminated);

            RemoveInstanceTableEntry(proxy);
        }

        private void OnWorkflowSuspended(object sender, WorkflowSuspendedEventArgs instanceArgs)
        {
            LiveWorkflowInstance proxy = GetInstanceTableEntry(instanceArgs.WorkflowInstance);
            proxy.Suspended = true;
            if (!proxy.InChange && this.eventProxy != null)
                this.eventProxy.FireOnInstanceStateChanged(instanceArgs.WorkflowInstance.InstanceId, InstanceStateChangeType.Suspended);
        }

        #region instance table management
        private LiveWorkflowInstance GetInstanceTableEntry(WorkflowInstance instance)
        {
            Guid instanceId = instance.InstanceId;
            //create instance in the local list in case it is not there yet
            LiveWorkflowInstance proxy = null;
            if (this.localInstances.ContainsKey(instanceId))
            {
                proxy = this.localInstances[instanceId];
            }
            else
            {
                proxy = new LiveWorkflowInstance(instance, this.serviceContainer);
                this.localInstances.Add(instanceId, proxy);
            }

            Debug.Assert(proxy != null);
            return proxy;
        }

        private LiveWorkflowInstance GetInstanceTableEntry(Guid instanceId)
        {
            //create instance in the local list in case it is not there yet
            LiveWorkflowInstance proxy = null;
            if (this.localInstances.ContainsKey(instanceId))
                proxy = this.localInstances[instanceId];
            else
            {
                WorkflowRuntime instanceService = this.serviceContainer;
                foreach (WorkflowInstance instance in instanceService.GetLoadedWorkflows())
                {
                    if (instance.InstanceId == instanceId)
                    {
                        proxy = new LiveWorkflowInstance(instance, this.serviceContainer);
                        this.localInstances.Add(instanceId, proxy);
                        break;
                    }
                }
            }

            Debug.Assert(proxy != null);
            return proxy;
        }

        private void RemoveInstanceTableEntry(LiveWorkflowInstance proxy)
        {
            if (this.localInstances.ContainsKey(proxy.InstanceId))
                this.localInstances.Remove(proxy.InstanceId);
        }
        #endregion

        #region tracking service to sink the execution events
        private class TrackingEventsHelper : TrackingService
        {
            private IStateChangeEventCallback callback = null;

            public TrackingEventsHelper(IStateChangeEventCallback callback)
            {
                this.callback = callback;
            }

            protected override TrackingProfile GetProfile(Guid workflowInstanceId)
            {
                return null;
            }

            protected override TrackingProfile GetProfile(Type scheduleType, Version profileVersionId)
            {
                return GetDefaultProfile(scheduleType);
            }

            protected override bool TryGetProfile(Type scheduleType, out TrackingProfile profile)
            {
                profile = GetDefaultProfile(scheduleType);
                return true;
            }

            protected override bool TryReloadProfile(Type workflowType, Guid workflowInstanceId, out TrackingProfile profile)
            {
                profile = null;
                return false;
            }

            private TrackingProfile GetDefaultProfile(Type scheduleType)
            {
                TrackingProfile profile = new TrackingProfile();
                profile.Version = new Version("1.0.0");

                {
                    //all activities, all state changes
                    ActivityTrackPoint atp = new ActivityTrackPoint();
                    ActivityTrackingLocation location = new ActivityTrackingLocation(typeof(Activity));
                    location.MatchDerivedTypes = true;
                    foreach (ActivityExecutionStatus s in Enum.GetValues(typeof(ActivityExecutionStatus)))
                        location.ExecutionStatusEvents.Add(s);
                    atp.MatchingLocations.Add(location);
                    profile.ActivityTrackPoints.Add(atp);
                }

                //root activity only, started, get the description which would be the title
                Activity rootActivity = null;
                MemberInfo titleMember = null;
                try
                {
                    rootActivity = Activator.CreateInstance(scheduleType) as Activity;
                    MemberInfo[] members = scheduleType.GetMember("Title", BindingFlags.Public | BindingFlags.Instance);
                    titleMember = (members != null && members.Length > 0) ? members[0] : null;
                }
                catch
                {
                }

                if (rootActivity != null && titleMember != null)
                {
                    ActivityTrackPoint atp = new ActivityTrackPoint();
                    ActivityTrackingLocation location = new ActivityTrackingLocation(scheduleType, new ActivityExecutionStatus[] { ActivityExecutionStatus.Executing });
                    atp.MatchingLocations.Add(location);

                    ActivityTrackingCondition matchingActivityTrackingCondition = new ActivityTrackingCondition("Name", rootActivity.Name);
                    matchingActivityTrackingCondition.Operator = ComparisonOperator.Equals;
                    location.Conditions.Add(matchingActivityTrackingCondition);

                    WorkflowDataTrackingExtract workflowDataTrackingExtract = new WorkflowDataTrackingExtract();
                    workflowDataTrackingExtract.Member = "Title";
                    atp.Extracts.Add(workflowDataTrackingExtract);

                    profile.ActivityTrackPoints.Add(atp);
                }

                // Add a TrackPoint to receive all workflow status events
                WorkflowTrackPoint workflowTrackPoint = new WorkflowTrackPoint();
                workflowTrackPoint.MatchingLocation = new WorkflowTrackingLocation();
                foreach (TrackingWorkflowEvent workflowEvent in Enum.GetValues(typeof(TrackingWorkflowEvent)))
                    workflowTrackPoint.MatchingLocation.Events.Add(workflowEvent);
                profile.WorkflowTrackPoints.Add(workflowTrackPoint);

                return profile;
            }

            protected override TrackingChannel GetTrackingChannel(TrackingParameters parameters)
            {
                IUpdateRootActivity iUpdateRootActivity = this.callback as IUpdateRootActivity;
                if (iUpdateRootActivity != null)
                    iUpdateRootActivity.UpdateRootActivity(parameters.InstanceId, parameters.RootActivity);

                return new TrackingEventsChannel(parameters, this);
            }

            public void Track(Guid instanceId, TrackingRecord record)
            {
                WorkflowTrackingRecord workflowTrackingRecord = record as WorkflowTrackingRecord;
                if (workflowTrackingRecord != null)
                    if (workflowTrackingRecord.TrackingWorkflowEvent == TrackingWorkflowEvent.Changed)
                        this.callback.OnStateChange(new DynamicUpdateEventArgs(instanceId));
                    else
                        this.callback.OnStateChange(new WorkflowStateChangeEventArgs(instanceId, workflowTrackingRecord.TrackingWorkflowEvent));
                else
                    this.callback.OnStateChange(new ActivityStateChangeEventArgs(instanceId, record));

                ActivityTrackingRecord activityTrackingRecord = record as ActivityTrackingRecord;
                if (activityTrackingRecord != null)
                {
                    if (activityTrackingRecord.Body != null && activityTrackingRecord.Body.Count > 0)
                    {
                        TrackingDataItem trackedItem = activityTrackingRecord.Body[0];
                        if (trackedItem.FieldName.Equals("Title", StringComparison.Ordinal))
                        {
                            string title = trackedItem.Data as string;
                            if (!string.IsNullOrEmpty(title))
                                this.callback.OnStateChange(new TitleSetEventArgs(instanceId, title));
                        }
                    }
                }
            }

            private class TrackingEventsChannel : TrackingChannel
            {
                private TrackingEventsHelper service = null;
                protected TrackingParameters parameters = null;

                public TrackingEventsChannel(TrackingParameters parameters, TrackingEventsHelper service)
                {
                    this.service = service;
                    this.parameters = parameters;
                }

                protected override void InstanceCompletedOrTerminated()
                { }

                protected override void Send(TrackingRecord record)
                {
                    this.service.Track(this.parameters.InstanceId, record);
                }
            }

        }
        #endregion

        #endregion

        public string[] GetLoadedAssemblies()
        {
            List<string> assemblies = new List<string>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.GlobalAssemblyCache && assembly.Location != String.Empty)
                    assemblies.Add(assembly.Location);
            }
            return assemblies.ToArray();
        }

        public ICollection GetWorkflowInstances()
        {
            LiveWorkflowInstance[] liveInstances = new LiveWorkflowInstance[this.localInstances.Values.Count];
            this.localInstances.Values.CopyTo(liveInstances, 0);

            ArrayList instances = new ArrayList();
            foreach (LiveWorkflowInstance liveInstance in liveInstances)
            {
                liveInstance.OnInstanceChanged += new EventHandler(OnInstanceChanged);
                liveInstance.OnInstanceUpdated += new EventHandler(OnInstanceUpdated);
                instances.Add(liveInstance);
            }

            return instances;
        }

        public LiveWorkflowInstance GetWorkflowInstance(Guid instanceId)
        {
            if (!this.localInstances.ContainsKey(instanceId))
                return null;

            LiveWorkflowInstance liveInstance = this.localInstances[instanceId];

            liveInstance.OnInstanceChanged += new EventHandler(OnInstanceChanged);
            liveInstance.OnInstanceUpdated += new EventHandler(OnInstanceUpdated);
            liveInstance.OnInstanceStateChanged += new EventHandler(OnInstanceStateChanged);

            return liveInstance;
        }

        private void OnInstanceChanged(object sender, EventArgs e)
        {
            try
            {
                LiveWorkflowInstance liveInst = sender as LiveWorkflowInstance;
                this.eventProxy.FireOnInstanceChanged(liveInst.InstanceId);
            }
            catch
            {
            }
        }
        private void OnInstanceUpdated(object sender, EventArgs e)
        {
            try
            {
                LiveWorkflowInstance liveInst = sender as LiveWorkflowInstance;
                this.eventProxy.FireOnInstanceUpdated(liveInst.InstanceId);
            }
            catch
            {
            }
        }

        private void OnInstanceStateChanged(object sender, EventArgs e)
        {
            try
            {
                LiveWorkflowInstance liveInst = sender as LiveWorkflowInstance;
                this.eventProxy.FireOnInstanceStateChanged(liveInst.InstanceId, InstanceStateChangeType.Resumed);
            }
            catch
            {
            }
        }
    }

    [Serializable]
    public class LiveWorkflowInstance : MarshalByRefObject
    {
        private WorkflowRuntime serviceContainer = null;
        private WorkflowInstance instance = null;
        private Activity root = null;
        private Type rootType = null;
        private Guid instanceId = Guid.Empty;
        private List<LiveActivityStatus> activityStates = null;
        private string title = string.Empty;
        private bool completed = false;
        private bool suspended = false;

        private DateTime creationTime;
        private DateTime lastUpdated;
        private Nullable<DateTime> completionTime = null;

        private LockingBool callingChangeAPIs = LockingBool.False;

        #region LockingBool
        private class LockingBool
        {
            private static LockingBool _true = null;
            public static LockingBool True
            {
                get
                {
                    if (LockingBool._true == null)
                        LockingBool._true = new LockingBool(true);
                    return LockingBool._true;
                }
            }
            private static LockingBool _false = null;
            public static LockingBool False
            {
                get
                {
                    if (LockingBool._false == null)
                        LockingBool._false = new LockingBool(false);
                    return LockingBool._false;
                }
            }

            public LockingBool(bool value)
            {
                this.Value = value;
            }

            public bool Value;
        }
        #endregion

        public LiveWorkflowInstance(WorkflowInstance instance, WorkflowRuntime serviceContainer)
        {
            this.serviceContainer = serviceContainer;
            this.instance = instance;
            this.instanceId = this.instance.InstanceId;
            this.creationTime = DateTime.Now;
            this.activityStates = new List<LiveActivityStatus>();
            Touch();
        }

        public event EventHandler OnInstanceChanged;
        public event EventHandler OnInstanceUpdated;
        public event EventHandler OnInstanceStateChanged;

        internal void AddActivityStateChangeEntry(TrackingRecord record)
        {
            ActivityTrackingRecord activityTrackingRecord = record as ActivityTrackingRecord;
            if (activityTrackingRecord != null)
                this.activityStates.Add(new LiveActivityStatus(activityTrackingRecord.QualifiedName, activityTrackingRecord.ExecutionStatus, activityTrackingRecord.ContextGuid, activityTrackingRecord.ParentContextGuid));
        }

        public void Touch()
        {
            this.lastUpdated = DateTime.Now;
            FireInstanceUpdated();
        }

        public void Change()
        {
            this.lastUpdated = DateTime.Now;
            FireInstanceChanged();
        }

        private void BeginChange()
        {
            lock (this.callingChangeAPIs)
            {
                this.callingChangeAPIs = LockingBool.True;
            }
        }
        private void EndChange()
        {
            lock (this.callingChangeAPIs)
            {
                this.callingChangeAPIs = LockingBool.False;
            }
        }
        internal bool InChange
        {
            get
            {
                bool inChange;
                lock (this.callingChangeAPIs)
                {
                    inChange = this.callingChangeAPIs.Value;
                }
                return inChange;
            }
        }

        private void FireInstanceChanged()
        {
            if (!InChange && OnInstanceChanged != null)
                OnInstanceChanged(this, EventArgs.Empty);
        }

        private void FireInstanceUpdated()
        {
            if (!InChange && OnInstanceUpdated != null)
                OnInstanceUpdated(this, EventArgs.Empty);
        }

        private void FireInstanceStateChanged()
        {
            if (!InChange && OnInstanceStateChanged != null)
                OnInstanceStateChanged(this, EventArgs.Empty);
        }

        internal void UpdateRootActivity(Activity root)
        {
            this.root = root;
            this.rootType = root.GetType();
        }

        private void EnsureType()
        {
            if (this.root == null)
            {
                this.root = this.instance.GetWorkflowDefinition();
                this.rootType = root.GetType();
            }
        }

        public void Terminate()
        {
            BeginChange();
            try
            {
                if (this.instance != null && !Completed)
                    this.instance.Terminate("user requested to terminate");
                this.instance = null;
            }
            finally
            {
                EndChange();
            }
        }

        public void Suspend()
        {
            BeginChange();
            try
            {
                if (this.instance != null && !Completed)
                    this.instance.Suspend("user requested suspend");
            }
            finally
            {
                EndChange();
            }
        }
        public void Resume()
        {
            BeginChange();
            try
            {
                if (this.instance != null && !Completed)
                    this.instance.Resume();
            }
            finally
            {
                EndChange();
            }
        }

        public ActivityExecutionStatus State
        {
            get
            {
                if (this.instance != null && this.root != null)
                {
                    return ((Activity)this.root).ExecutionStatus;
                }
                else if (this.instance != null && !Completed)
                {
                    Activity root = this.instance.GetWorkflowDefinition();
                    Activity activity = root as Activity;
                    return activity.ExecutionStatus;
                }

                return ActivityExecutionStatus.Closed;
            }
        }

        public DateTime ActivationTime
        {
            get { return this.creationTime; }
        }

        public string Xoml
        {
            get
            {
                if (Completed)
                    return string.Empty;

                Activity rootActivity = (this.instance != null && this.root != null) ? this.root : this.instance.GetWorkflowDefinition();
                WorkflowChangeAction[] changes = new WorkflowChangeAction[0];

                if (IsCustomActivity(rootActivity))
                {
                    // get the original activity
                    FieldInfo definitionField = typeof(Activity).GetField("WorkflowDefinitionProperty", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    DependencyProperty definitionDP = (DependencyProperty)definitionField.GetValue(rootActivity);
                    Activity originalRootActivity = (Activity)((Activity)rootActivity).GetValue(definitionDP);

                    //this activity would have the WorkflowChangeActionsProperty set on it
                    rootActivity = (originalRootActivity != null) ? originalRootActivity : rootActivity;

                    FieldInfo changesField = typeof(WorkflowChanges).GetField("WorkflowChangeActionsProperty", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                    DependencyProperty changesDP = (DependencyProperty)changesField.GetValue(new WorkflowChanges(rootActivity));
                    ArrayList workflowChanges = (ArrayList)rootActivity.GetValue(changesDP);

                    if (workflowChanges != null && workflowChanges.Count > 0)
                        changes = workflowChanges.ToArray(typeof(WorkflowChangeAction)) as WorkflowChangeAction[];
                }

                ActivityMarkupWithChanges xomlchanges = new ActivityMarkupWithChanges(rootActivity, changes);
                return GetMarkupDocument(xomlchanges);
            }
        }

        private string GetMarkupDocument(object obj)
        {
            string xomlText = null;
            using (StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture))
            {
                using (XmlWriter xmlWriter = new XmlTextWriter(stringWriter))
                {
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    serializer.Serialize(xmlWriter, obj);
                    xomlText = stringWriter.ToString(); ;
                }
            }
            return xomlText;
        }

        private static readonly Guid CustomActivityKey = new Guid("298CF3E0-E9E0-4d41-A11B-506E9132EB27");
        private bool IsCustomActivity(Activity activity)
        {
            CompositeActivity compositeActivity = activity as CompositeActivity;
            if (compositeActivity == null)
                return false;

            if (compositeActivity.UserData.Contains(CustomActivityKey))
                return (bool)(compositeActivity.UserData[CustomActivityKey]);
            else
                return false;
        }

        internal void SetTitle(string title)
        {
            this.title = title;
        }

        public string Title
        {
            get
            {
                if (this.title.Length == 0)
                {
                    Activity myRoot = (this.root != null) ? this.root : this.instance.GetWorkflowDefinition();
                    if (this.title == null || this.title.Length == 0)
                        this.title = "Instance of " + myRoot.GetType().Name + ", activated on " + this.creationTime.ToShortDateString();
                }

                return this.title;
            }
        }

        public Guid InstanceId
        {
            get { return this.instanceId; }
        }

        public string FullTypeName
        {
            get
            {
                if (this.rootType == null && !Completed)
                    EnsureType();

                return (this.rootType != null) ? this.rootType.FullName : "FullWorkflowName";
            }
        }

        public string ShortTypeName
        {
            get
            {
                if (this.rootType == null && !Completed)
                    EnsureType();

                return (this.rootType != null) ? this.rootType.Name : "Workflow";
            }
        }

        public string FullAssemblyName
        {
            get
            {
                if (this.rootType == null && !Completed)
                    EnsureType();

                return this.rootType.Assembly.FullName;
            }
        }

        public bool Completed
        {
            get { return this.completed; }
            set
            {
                if (this.completed == value)
                    return;

                this.completed = value;

                if (this.completed)
                    this.completionTime = DateTime.Now;
                else
                    this.completionTime = null;

                //if (this.completed)
                //    this.activityStates.Clear();

                Touch();
            }
        }

        public bool Suspended
        {
            get { return this.suspended; }
            set
            {
                if (this.suspended == value)
                    return;

                this.suspended = value;
                Touch();

                //if it's a resume, need to fire event to the client
                if (!Suspended)
                {
                }
            }
        }

        public Nullable<DateTime> CompletionTime
        {
            get { return this.completionTime; }
        }

        public string ApplyDynamicUpdateBatch(DynamicUpdateCommitData dynamicUpdateCommitData)
        {
            //get a batch with all the changes (additions and deletions), apply them and commit
            //we will create the actual change object only when the user requested the update
            //if it got reverted, then she may simply continue making changes and we will
            //create a new change every times she would try to apply it

            string retVal = null;
            WorkflowChanges workflowChanges = null;

            this.root = null;
            this.rootType = null;

            try
            {
                Activity currentRoot = this.instance.GetWorkflowDefinition();
                workflowChanges = new WorkflowChanges(currentRoot);
                CompositeActivity root = workflowChanges.TransientWorkflow;

                //build the hashtable of activityIds to activities
                Dictionary<string, Activity> activityIdToActivity = new Dictionary<string, Activity>();
                Walker walker = new Walker();
                walker.FoundActivity += delegate(Walker skedWalker, WalkerEventArgs eventArgs)
                {
                    Activity activity = eventArgs.CurrentActivity;
                    activityIdToActivity.Add(activity.QualifiedName, activity);
                };
                walker.Walk(root);

                foreach (ActivityDynamicChangeLog change in dynamicUpdateCommitData.ChangeLog)
                {
                    if (change.ChangeType == ActivityDynamicUpdateType.Add)
                    {
                        Activity addedActivity = DynamicUpdateCommitData.DeserializeActivity(change.ActivityXoml);
                        CompositeActivity parent = activityIdToActivity[change.ParentActivityId] as CompositeActivity;

                        parent.Activities.Insert(change.ActivityIndex, addedActivity);
                        foreach (Activity activity in GetNestedActivities(addedActivity))
                            activityIdToActivity.Add(activity.QualifiedName, activity);
                    }
                    else if (change.ChangeType == ActivityDynamicUpdateType.Modify)
                    {
                        Activity modifiedActivity = DynamicUpdateCommitData.DeserializeActivity(change.ActivityXoml);

                        CompositeActivity parent = null;
                        parent = activityIdToActivity[change.ParentActivityId] as CompositeActivity;

                        Activity oldModifiedActivity = null;
                        if (change.ActivityIndex != -1)
                            oldModifiedActivity = parent.Activities[change.ActivityIndex];
                        else
                            throw new Exception("can't change properties of the root activity");
                        Debug.Assert(modifiedActivity.GetType() == oldModifiedActivity.GetType());//the ids may change

                        foreach (Activity activity in GetNestedActivities(oldModifiedActivity))
                            activityIdToActivity.Remove(activity.QualifiedName);

                        int index = parent.Activities.IndexOf(oldModifiedActivity);
                        parent.Activities.RemoveAt(index);

                        parent.Activities.Insert(index, modifiedActivity);

                        foreach (Activity activity in GetNestedActivities(modifiedActivity))
                            activityIdToActivity.Add(activity.QualifiedName, activity);
                    }
                    else if (change.ChangeType == ActivityDynamicUpdateType.Remove)
                    {
                        CompositeActivity parent = activityIdToActivity[change.ParentActivityId] as CompositeActivity;
                        CompositeActivity deletetingActivityParent = activityIdToActivity[change.ParentActivityId] as CompositeActivity;
                        Activity deletedActivity = deletetingActivityParent.Activities[change.ActivityId];
                        int index = parent.Activities.IndexOf(deletedActivity);
                        Debug.Assert(deletedActivity.Name == change.ActivityId);

                        foreach (Activity activity in GetNestedActivities(deletedActivity))
                            activityIdToActivity.Remove(activity.QualifiedName);

                        deletetingActivityParent.Activities.RemoveAt(index);
                    }
                }

                this.BeginChange();
                this.instance.ApplyWorkflowChanges(workflowChanges);
                this.EndChange();

                this.root = this.instance.GetWorkflowDefinition();
                this.rootType = this.root.GetType();
            }
            catch (Exception ex)
            {
                retVal = ex.Message;
            }

            workflowChanges = null;
            return retVal;
        }

        private static Activity[] GetNestedActivities(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");

            ArrayList nestedActivities = new ArrayList();
            nestedActivities.Add(activity);

            Queue compositeActivities = new Queue();
            if (activity is CompositeActivity)
                compositeActivities.Enqueue(activity);

            while (compositeActivities.Count > 0)
            {
                CompositeActivity compositeActivity2 = (CompositeActivity)compositeActivities.Dequeue();
                IList<Activity> childActivities = compositeActivity2.Activities;

                foreach (Activity childActivity in childActivities)
                {
                    nestedActivities.Add(childActivity);
                    if (childActivity is CompositeActivity)
                        compositeActivities.Enqueue(childActivity);
                }
            }

            return (Activity[])nestedActivities.ToArray(typeof(Activity));
        }

        public void DeleteActivity(string qId)
        {
            //simple case of a dynamic update - just delete an activity
            if (this.instance == null || Completed)
                return;

            BeginChange();
            try
            {
                WorkflowChanges changes = new WorkflowChanges(this.instance.GetWorkflowDefinition());
                CompositeActivity root = changes.TransientWorkflow;

                //build the hashtable of activityIds to activities
                Dictionary<string, Activity> activityIdToActivity = new Dictionary<string, Activity>();
                Walker walker = new Walker();
                walker.FoundActivity += delegate(Walker skedWalker, WalkerEventArgs eventArgs)
                {
                    Activity activity = eventArgs.CurrentActivity;
                    activityIdToActivity.Add(activity.QualifiedName, activity);
                };
                walker.Walk(root);

                if (activityIdToActivity.ContainsKey(qId))
                {
                    Activity deletetingActivity = activityIdToActivity[qId];
                    deletetingActivity.Parent.Activities.Remove(deletetingActivity);
                    this.instance.ApplyWorkflowChanges(changes);
                }
            }
            finally
            {
                EndChange();
            }
        }

        public ICollection GetActivityStatusList()
        {
            return this.activityStates.ToArray();
        }
    }
}
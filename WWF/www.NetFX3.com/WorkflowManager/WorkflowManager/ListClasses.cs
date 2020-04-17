using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Xml;
using Microsoft.Workflow.Samples.Administration;


namespace Microsoft.Workflow.Samples.WorkflowManager
{
    public abstract class TrackedEntity
    {
        protected IDataProvider provider = null;

        public TrackedEntity(IDataProvider provider)
        {
            this.provider = provider;
        }

        public abstract void Initialize(SqlDataReader reader);
    }

    [GetInstanceSqlStatement("dbo.GetTypeInstance")]
    public class WorkflowServicesType : TrackedEntity
    {
        long typeId;
        string typeName;
        string assemblyName;

        public WorkflowServicesType(IDataProvider provider)
            : base(provider)
        {
        }

        public override void Initialize(SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                throw new ArgumentException("Reader should not be null or in closed state.");

            this.typeId = reader.GetInt32(0);
            this.typeName = reader.GetString(1);
            this.assemblyName = reader.GetString(2);
        }
    }

    [GetInstanceSqlStatement("dbo.GetWorkflowTypeInstance")]
    public class WorkflowType : WorkflowServicesType
    {
        private string xoml = null;
        public string XomlDocument
        {
            get
            {
                return this.xoml;
            }
        }

        public WorkflowType(IDataProvider provider)
            : base(provider)
        {
        }

        public override void Initialize(SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                throw new ArgumentException("Reader should not be null or in closed state.");

            base.Initialize(reader);
            this.xoml = reader.GetString(3);
        }
    }

    [EnumerationForWorkflowInstanceSqlStatement("GetTrackedEventsForWorkflowInstance")]
    public class TrackedActivity : TrackedEntity
    {
        public TrackedActivity(IDataProvider provider, TrackedWorkflowInstance workflowInstance)
            : base(provider)
        {
            this.workflowInstance = workflowInstance;
        }

        public TrackedActivity(IDataProvider provider, TrackedWorkflowInstance workflowInstance, string qualifiedID, uint status, Guid context, Guid parentContext)
            : this(provider, workflowInstance)
        {
            this.qualifiedId = qualifiedID;
            this.status = (ActivityExecutionStatus)status;
            this.context = context;
            this.parentContext = parentContext;
        }

        private TrackedWorkflowInstance workflowInstance;//WorkflowInstanceInternalId
        public TrackedWorkflowInstance WorkflowInstance
        {
            get
            {
                return this.workflowInstance;
            }
        }

        private long activityInstanceId;
        public long ActivityInstanceId
        {
            get
            {
                return this.activityInstanceId;
            }
        }

        private string qualifiedId;
        public string QualifiedName
        {
            get
            {
                return this.qualifiedId;
            }
        }

        private ActivityExecutionStatus status;
        public ActivityExecutionStatus Status
        {
            get
            {
                return this.status;
            }
        }

        private DateTime eventDateTime;
        public DateTime EventDateTime
        {
            get
            {
                return this.eventDateTime;
            }
        }

        private Guid context;
        public Guid Context
        {
            get
            {
                return this.context;
            }
        }

        private Guid parentContext;
        public Guid ParentContext
        {
            get
            {
                return this.parentContext;
            }
        }

        public override void Initialize(SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                throw new ArgumentException("Reader should not be null or in closed state.");

            this.activityInstanceId = reader.GetInt64(0);
            this.qualifiedId = reader.GetString(1);
            this.context = reader.GetGuid(2);
            this.parentContext = reader.GetGuid(3);
            this.status = (ActivityExecutionStatus)reader.GetByte(4);
            this.eventDateTime = reader.GetDateTime(5);
        }
    }


    ////////////////////////////////////////////////////////////////////////////////////////

    public abstract class TrackedChangeAction : TrackedEntity
    {//get data from WorkflowChangeAction
        public TrackedChangeAction(IDataProvider provider, TrackedWorkflowInstance workflowInstance)
            : base(provider)
        {
            this.workflowInstance = workflowInstance;
        }

        private TrackedWorkflowInstance workflowInstance = null;//WorkflowInstanceInternalId
        public TrackedWorkflowInstance WorkflowInstance
        {
            get
            {
                return this.workflowInstance;
            }
        }

        private long workflowInstanceEventId = -1;
        public long WorkflowInstanceEventId
        {
            get
            {
                return this.workflowInstanceEventId;
            }
        }

        private string qualifiedName = null;
        public string QualifiedName
        {
            get
            {
                return this.qualifiedName;
            }
        }

        private string parentQualifiedName = null;
        public string ParentQualifiedName
        {
            get
            {
                return this.parentQualifiedName;
            }
        }

        private string activityAction = null;//added or removed action
        public string ActivityAction
        {
            get
            {
                return this.activityAction;
            }
        }

        private int order = -1;//order of the action in the same workflow event
        public int Order
        {
            get { return this.order; }
        }

        public override void Initialize(SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                throw new ArgumentException("Reader should not be null or in closed state.");

            this.workflowInstanceEventId = reader.GetInt64(0);
            this.qualifiedName = reader.GetString(1);
            if (!reader.IsDBNull(2))
                this.parentQualifiedName = reader.GetString(2);
            if (!reader.IsDBNull(3))
                this.activityAction = reader.GetString(3);
            if (!reader.IsDBNull(4))
                this.order = reader.GetInt32(4);
        }
    }

    [EnumerationForWorkflowInstanceSqlStatement("GetAddActivityActionsForWorkflowInstance")]
    public class TrackedAddAction : TrackedChangeAction
    {
        public TrackedAddAction(IDataProvider provider, TrackedWorkflowInstance workflowInstance)
            : base(provider, workflowInstance)
        {
        }
    }

    [EnumerationForWorkflowInstanceSqlStatement("GetRemovedActivityActionsForWorkflowInstance")]
    public class TrackedRemoveAction : TrackedChangeAction
    {
        public TrackedRemoveAction(IDataProvider provider, TrackedWorkflowInstance workflowInstance)
            : base(provider, workflowInstance)
        {
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    public class EnumerationForWorkflowInstanceSqlStatementAttribute : Attribute
    {
        private string sql = null;
        public string SQL
        {
            get
            {
                return this.sql;
            }
        }

        public EnumerationForWorkflowInstanceSqlStatementAttribute(string sql)
        {
            this.sql = sql;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    public class EnumerationSqlStatementAttribute : Attribute
    {
        private string sql = null;
        public string SQL
        {
            get
            {
                return this.sql;
            }
        }

        public EnumerationSqlStatementAttribute(string sql)
        {
            this.sql = sql;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////

    public class GetInstanceSqlStatementAttribute : Attribute
    {
        private string sql = null;
        public string SQL
        {
            get
            {
                return this.sql;
            }
        }

        public GetInstanceSqlStatementAttribute(string sql)
        {
            this.sql = sql;
        }
    }

    public class LiveProxyInstanceCreator : IStateUpdatableInstanceCreator
    {
        IStateChangeEventCallback IStateUpdatableInstanceCreator.CreateLiveProxyInstance(LiveWorkflowInstance instance)
        {
            return new LiveInstanceProxy(instance);
        }
    }

    public class LiveInstanceProxy : IStateChangeEventCallback, IWorkflowInstance
    {
        public event EventHandler OnInstanceStateChanged;

        private Guid instanceId = Guid.Empty;
        private DateTime activationTime = DateTime.MinValue;

        private LiveWorkflowInstance instance = null;

        public LiveInstanceProxy(LiveWorkflowInstance instance)
        {
            this.instance = instance;
        }

        public string ApplyDynamicUpdateBatch(DynamicUpdateCommitData dynamicUpdatebatch)
        {
            return this.instance.ApplyDynamicUpdateBatch(dynamicUpdatebatch);
        }

        public void Terminate()
        {
            this.instance.Terminate();
            //the remote side will not fire events on this action (to avoid problems with multiple reentrance)
            //so we have to manually do that after the call returns
            ((IStateChangeEventCallback)this).OnStateChange(new InstanceStateChangeEventArgs(InstanceId, InstanceStateChangeType.Terminated));
        }

        public void Suspend()
        {
            this.instance.Suspend();
            //the remote side will not fire events on this action (to avoid problems with multiple reentrance)
            //so we have to manually do that after the call returns
            ((IStateChangeEventCallback)this).OnStateChange(new InstanceStateChangeEventArgs(InstanceId, InstanceStateChangeType.Suspended));
        }

        public void Resume()
        {
            this.instance.Resume();
            //the remote side will not fire events on this action (to avoid problems with multiple reentrance)
            //so we have to manually do that after the call returns
            ((IStateChangeEventCallback)this).OnStateChange(new InstanceStateChangeEventArgs(InstanceId, InstanceStateChangeType.Resumed));
        }

        public void DeleteActivity(string qId)
        {
            this.instance.DeleteActivity(qId);
            //the remote side will not fire events on this action (to avoid problems with multiple reentrance)
            //so we have to manually do that after the call returns
            ((IStateChangeEventCallback)this).OnStateChange(new DynamicUpdateEventArgs(InstanceId));
        }

        public string Xoml
        {
            get { return this.instance.Xoml; }
        }

        public string Title
        {
            get { return this.instance.Title; }
        }

        public string FullTypeName
        {
            get { return this.instance.FullTypeName; }
        }

        public DateTime ActivationTime
        {
            get
            {
                if (this.activationTime == DateTime.MinValue)
                    this.activationTime = this.instance.ActivationTime;
                return this.activationTime;
            }
        }

        public bool Completed
        {
            get { return this.instance.Completed; }
        }

        public string CompletionTime
        {
            get
            {
                Nullable<DateTime> completion = this.instance.CompletionTime;
                if (completion != null)
                    return completion.ToString();
                else
                    return string.Empty;
            }
        }

        public Guid InstanceId
        {
            get
            {
                //cache the instance id (it's not going to change)
                if (this.instanceId == Guid.Empty)
                    this.instanceId = this.instance.InstanceId;
                return this.instanceId;
            }
        }

        public string FullAssemblyName
        {
            get { return this.instance.FullAssemblyName; }
        }

        public ICollection GetActivityStatusList()
        {
            return this.instance.GetActivityStatusList();
        }

        #region IStateChangeEventCallback Members
        void IStateChangeEventCallback.OnStateChange(InstanceChangeEventArgs args)
        {
            if (OnInstanceStateChanged != null)
                OnInstanceStateChanged(this, args);
        }
        #endregion

        #region IWorkflowInstance Members

        Guid IWorkflowInstance.InstanceId
        {
            get { return this.InstanceId; }
        }

        DateTime IWorkflowInstance.ActivationTime
        {
            get { return this.ActivationTime; }
        }

        string IWorkflowInstance.Type
        {
            get { return this.instance.ShortTypeName; }
        }

        string IWorkflowInstance.Title
        {
            get { return this.Title; }
        }

        string IWorkflowInstance.Xoml
        {
            get { return this.Xoml; }
        }

        List<TrackedActivity> IWorkflowInstance.ActivityStateList
        {
            get
            {
                List<TrackedActivity> activityStatuses = new List<TrackedActivity>();
                foreach (LiveActivityStatus activityStatus in this.GetActivityStatusList())
                    activityStatuses.Add(new TrackedActivity(null, null, activityStatus.QualifiedName, (uint)activityStatus.Status, activityStatus.Context, activityStatus.ParentContext));

                return activityStatuses;
            }
        }

        ActivityExecutionStatus IWorkflowInstance.State
        {
            get { return this.instance.State; }
        }

        bool IWorkflowInstance.Completed
        {
            get
            {
                ActivityExecutionStatus status = ((IWorkflowInstance)this).State;
                return status == ActivityExecutionStatus.Closed;
            }
        }
        bool IWorkflowInstance.Suspended
        {
            get { return this.instance.Suspended; }
        }

        #endregion
    }

    [EnumerationSqlStatement("dbo.EnumerateTrackedWorkflowInstances")]
    public class TrackedWorkflowInstance : TrackedEntity, IWorkflowInstance
    {
        private int workflowTypeId;
        private string workflowTypeName = null;
        public string WorkflowTypeName
        {
            get { return this.workflowTypeName; }
        }

        private WorkflowType workflowType = null;
        public WorkflowType WorkflowType//int WorkflowTypeId
        {
            get
            {
                if (this.workflowType == null)
                {
                    Hashtable key = new Hashtable();
                    key.Add("@identity", this.workflowTypeId);
                    this.workflowType = provider.GetInstance(typeof(WorkflowType), key) as WorkflowType;
                }

                return this.workflowType;
            }
        }

        private long workflowInstanceInternalId;
        public long WorkflowInstanceInternalId
        {
            get { return this.workflowInstanceInternalId; }
        }

        private Guid workflowInstanceId;
        public Guid Id
        {
            get { return this.workflowInstanceId; }
        }

        private string qualifiedId;
        public string QualifiedName
        {
            get { return this.qualifiedId; }
        }

        private string callPath;
        public string CallPath
        {
            get { return this.callPath; }
        }

        private DateTime createdDateTime;
        public DateTime Created
        {
            get { return this.createdDateTime; }
        }

        public TrackedActivity[] TrackedActivities
        {
            //we will read the collection every time - it changes frequently
            get
            {
                ArrayList instanceActivities = new ArrayList();
                instanceActivities.AddRange(this.provider.GetCollectionForWorkflowInstance(typeof(TrackedActivity), this));

                List<TrackedActivity> activities = new List<TrackedActivity>();
                foreach (TrackedActivity activity in instanceActivities)
                    activities.Add(activity);

                return activities.ToArray();
            }
        }

        public List<TrackedChangeAction> TrackedWorkflowChanges
        {
            //we will read the collection every time - it could change
            get
            {
                ArrayList unfilteredChangeList = new ArrayList();
                unfilteredChangeList.AddRange(this.provider.GetCollectionForWorkflowInstance(typeof(TrackedAddAction), this));
                unfilteredChangeList.AddRange(this.provider.GetCollectionForWorkflowInstance(typeof(TrackedRemoveAction), this));

                //filter out actions with empty activity action xmls
                List<TrackedChangeAction> realChangeActions = new List<TrackedChangeAction>();
                foreach (TrackedChangeAction changeAction in unfilteredChangeList)
                {
                    if (!string.IsNullOrEmpty(changeAction.ActivityAction))
                        realChangeActions.Add(changeAction);
                }

                //sort all actions based on time
                if (realChangeActions.Count > 1)
                    TrackedChangeActionSorter.Sort(realChangeActions);

                return realChangeActions;
            }
        }

        #region IWorkflowInstance Sorter
        private sealed class TrackedChangeActionSorter : IComparer<TrackedChangeAction>
        {
            private TrackedChangeActionSorter()
            {
            }

            public static void Sort(List<TrackedChangeAction> actions)
            {
                TrackedChangeActionSorter sorter = new TrackedChangeActionSorter();
                actions.Sort(sorter);
            }

            int IComparer<TrackedChangeAction>.Compare(TrackedChangeAction lhs, TrackedChangeAction rhs)
            {
                if (lhs.WorkflowInstanceEventId < rhs.WorkflowInstanceEventId)
                    return -1;
                else if (lhs.WorkflowInstanceEventId == rhs.WorkflowInstanceEventId)
                {
                    if (lhs.Order < rhs.Order)
                        return -1;
                    else if (lhs.Order == rhs.Order)
                        return 0;
                    else
                        return +1;
                }
                else
                    return +1;
            }
        }
        #endregion


        public TrackedWorkflowInstance(IDataProvider provider)
            : base(provider)
        {
        }

        public override void Initialize(SqlDataReader reader)
        {
            if (reader == null || reader.IsClosed)
                throw new ArgumentException("Reader should not be null or in closed state.");

            this.workflowInstanceInternalId = reader.GetInt64(0);
            this.workflowInstanceId = reader.GetGuid(1);
            this.workflowTypeId = reader.GetInt32(2);
            this.workflowTypeName = reader.GetString(3);
            this.qualifiedId = reader.GetString(4);
            if (reader[5] != DBNull.Value)
                this.callPath = reader.GetString(5);
            this.createdDateTime = reader.GetDateTime(6).ToLocalTime();
        }

        #region IWorkflowInstance Members

        Guid IWorkflowInstance.InstanceId
        {
            get { return this.Id; }
        }

        DateTime IWorkflowInstance.ActivationTime
        {
            get { return this.createdDateTime; }
        }

        string IWorkflowInstance.Type
        {
            get { return this.workflowTypeName; }
        }

        string IWorkflowInstance.Title
        {
            get { return this.workflowTypeName + " activated on " + this.createdDateTime.ToShortDateString() + " " + this.createdDateTime.ToShortTimeString(); }
        }

        string IWorkflowInstance.Xoml
        {
            get
            {
                string originalXoml = this.WorkflowType.XomlDocument;
                List<TrackedChangeAction> trackedWorkflowChanges = this.TrackedWorkflowChanges;
                if (trackedWorkflowChanges == null || trackedWorkflowChanges.Count == 0)
                    return originalXoml;

                Activity rootActivity = GetObjectFromMarkupDocument(originalXoml) as Activity;
                List<WorkflowChangeAction> workflowChanges = new List<WorkflowChangeAction>(trackedWorkflowChanges.Count);
                foreach (TrackedChangeAction trackedWorkflowChange in trackedWorkflowChanges)
                {
                    WorkflowChangeAction action = GetObjectFromMarkupDocument(trackedWorkflowChange.ActivityAction) as WorkflowChangeAction;
                    if (action != null)
                        workflowChanges.Add(action);
                }

                ActivityMarkupWithChanges ActivityMarkupWithChanges = new ActivityMarkupWithChanges(rootActivity, workflowChanges.ToArray());
                return GetMarkupDocument(ActivityMarkupWithChanges);
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

        private object GetObjectFromMarkupDocument(string xoml)
        {
            object deserialized = null;
            using (StringReader stringReader = new StringReader(xoml))
            {
                using (XmlReader xmlReader = new XmlTextReader(stringReader))
                {
                    WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                    deserialized = serializer.Deserialize(xmlReader);
                }
            }
            return deserialized;
        }

        List<TrackedActivity> IWorkflowInstance.ActivityStateList
        {
            get { return new List<TrackedActivity>(TrackedActivities); }
        }

        ActivityExecutionStatus IWorkflowInstance.State
        {
            get
            {
                ActivityExecutionStatus state = ActivityExecutionStatus.Initialized;
                foreach (TrackedActivity trackedActivity in TrackedActivities)
                {
                    if (trackedActivity.QualifiedName == this.workflowTypeName || this.workflowTypeName.EndsWith(trackedActivity.QualifiedName))
                        state = trackedActivity.Status;
                }
                return state;
            }
        }

        bool IWorkflowInstance.Completed
        {
            get
            {
                ActivityExecutionStatus status = ((IWorkflowInstance)this).State;
                return status == ActivityExecutionStatus.Closed;
            }
        }
        bool IWorkflowInstance.Suspended
        {
            get
            {
                //todo - how does tracking store the suspended state now????
                ActivityExecutionStatus status = ((IWorkflowInstance)this).State;
                return false;
            }
        }

        #endregion
    }
}
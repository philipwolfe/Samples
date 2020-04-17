using System;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime.Tracking;
using System.Xml;

namespace Microsoft.Workflow.Samples.Administration
{
	public abstract class InstanceChangeEventArgs : EventArgs
	{
		private Guid instanceId;
		public InstanceChangeEventArgs(Guid instanceId)
		{
			this.instanceId = instanceId;
		}
		public Guid InstanceId
		{
			get { return this.instanceId; }
		}
	}

	public interface IStateChangeEventCallback
	{
		void OnStateChange(InstanceChangeEventArgs args);
	}
	
	public class InstanceStateChangeEventArgs : InstanceChangeEventArgs
	{
		private InstanceStateChangeType changeType;
		public InstanceStateChangeEventArgs(Guid instanceId, InstanceStateChangeType changeType)
			: base(instanceId)
		{
			this.changeType = changeType;
		}
		public InstanceStateChangeType ChangeType
		{
			get { return this.changeType; }
		}
	}
	public class DynamicUpdateEventArgs : InstanceChangeEventArgs
	{
		public DynamicUpdateEventArgs(Guid instanceId) : base(instanceId) { }
	}
	public class WorkflowStateChangeEventArgs : InstanceChangeEventArgs
	{
		private TrackingWorkflowEvent workflowEvent;
		public WorkflowStateChangeEventArgs(Guid instanceId, TrackingWorkflowEvent workflowEvent)
			: base(instanceId)
		{
			this.workflowEvent = workflowEvent;
		}
		public TrackingWorkflowEvent WorkflowEvent
		{
			get { return this.workflowEvent; }
		}
	}
	public class ActivityStateChangeEventArgs : InstanceChangeEventArgs
	{
		private TrackingRecord record;
		public ActivityStateChangeEventArgs(Guid instanceId, TrackingRecord record) : base(instanceId)
		{
			this.record = record;
		}
		public TrackingRecord Record
		{
			get { return this.record; }
		}
	}
	public class TitleSetEventArgs : InstanceChangeEventArgs
	{
		private string title;
		public TitleSetEventArgs(Guid instanceId, string title)
			: base(instanceId)
		{
			this.title = title;
		}
		public string Title
		{
			get { return this.title; }
		}
	}

	public interface IStateUpdatableInstanceCreator
	{
		IStateChangeEventCallback CreateLiveProxyInstance(LiveWorkflowInstance instance);
	}

	public enum InstanceStateChangeType { Created, Suspended, Resumed, Completed, Terminated};

	public enum ActivityDynamicUpdateType { Add, Modify, Remove };
	
	[Serializable]
	public class ActivityDynamicChangeLog
	{
		private ActivityDynamicUpdateType changeType;
		private string activityId;
		private int activityIndex;
		private string parentActivityId;
		private string activityXoml;

		public ActivityDynamicChangeLog(ActivityDynamicUpdateType changeType, string activityId, int activityIndex, string parentActivityId, string activityXoml)
		{
			this.changeType = changeType;
			this.activityId = activityId;
			this.activityIndex = activityIndex;
			this.parentActivityId = parentActivityId;
			this.activityXoml = activityXoml;
		}
		public ActivityDynamicUpdateType ChangeType
		{
			get { return this.changeType; }
		}
		public string ActivityId
		{
			get { return this.activityId; }
		}
		public int ActivityIndex
		{
			get { return this.activityIndex; }
		}
		public string ParentActivityId
		{
			get { return this.parentActivityId; }
		}
		public string ActivityXoml
		{
			get { return this.activityXoml; }
		}
	}

	[Serializable]
	public class ParameterItem
	{
		private string name;
		private string value;

		public ParameterItem(string name, string value)
		{
			this.name = name;
			this.value = value;
		}

		public string Name
		{
			get { return this.name; }
		}
		public string Value
		{
			get { return this.value; }
		}
	}

	[Serializable]
	public class ActivityMarkupWithChanges
	{
		private Activity root = null;
		private WorkflowChangeAction[] changes = null;

		public ActivityMarkupWithChanges()
		{
		}

		public ActivityMarkupWithChanges(Activity root, WorkflowChangeAction[] changes)
		{
			this.root = root;
			this.changes = changes;
		}

		public Activity Root
		{
			get { return this.root; }
			set { this.root = value; }
		}
		public WorkflowChangeAction[] Changes
		{
			get { return this.changes; }
			set { this.changes = value; }
		}
	}

	public class ActivityDynamicUpdate : MarshalByRefObject
	{
		private string activityId;
		private int activityIndex;
		private string parentId;
		private string xoml;

		public ActivityDynamicUpdate(string activityId, int activityIndex, string parentId, string xoml)
		{
			this.activityId = activityId;
			this.activityIndex = activityIndex;
			this.parentId = parentId;
			this.xoml = xoml;
		}
		public string ActivityId
		{
			get { return this.activityId; }
		}
		public int ActivityIndex
		{
			get { return this.activityIndex; }
		}
		public string ParentId
		{
			get { return this.parentId; }
		}
		public string Xoml
		{
			get { return this.xoml; }
		}
	}

	public class DynamicUpdateCommitData : MarshalByRefObject
	{
		private ActivityDynamicChangeLog[] changeLog;

		public DynamicUpdateCommitData(ActivityDynamicChangeLog[] changeLog)//ActivityDynamicUpdate[] deletedActivites, ActivityDynamicUpdate[] addedActivities, ActivityDynamicUpdate[] modifiedActivities)
		{
			this.changeLog = changeLog;
		}

		public ActivityDynamicChangeLog[] ChangeLog
		{
			get { return this.changeLog; }
		}

		#region xoml serialization helpers
		public static Activity DeserializeActivity(string xoml)
		{
			DesignerSerializationManager serializationManager = new DesignerSerializationManager();
			using (serializationManager.CreateSession())
			{
				Activity activity = (new WorkflowMarkupSerializer()).Deserialize(serializationManager, new XmlTextReader(new StringReader(xoml))) as Activity;
				if (serializationManager.Errors.Count != 0)
				{
					string assertMessage = "Deserialization failed for activity\n";
					foreach (object error in serializationManager.Errors)
					{
						assertMessage += error.ToString();
					}
					//Debug.Assert(false, assertMessage);
				}

				return activity;
			}
		}
		public static string SerializeActivity(Activity activity)
		{
			DesignerSerializationManager serializationManager = new DesignerSerializationManager();
			using (serializationManager.CreateSession())
			{
				StringWriter writer = new StringWriter();
				(new WorkflowMarkupSerializer()).Serialize(new XmlTextWriter(writer), activity);
				if (serializationManager.Errors.Count != 0)
				{
					string assertMessage = "Serialization failed for activity:\n";
					foreach (object error in serializationManager.Errors)
					{
						assertMessage += error.ToString();
					}
					Debug.Assert(false, assertMessage);
				}
				return writer.ToString();
			}
		}
		#endregion
	}

	public class LiveActivityStatus : MarshalByRefObject
	{
		private string qualifiedName;
		private ActivityExecutionStatus status;
		private Guid context;
		private Guid parentContext;

		public LiveActivityStatus(string qualifiedName, ActivityExecutionStatus status, Guid context, Guid parentContext)
		{
			this.qualifiedName = qualifiedName;
			this.status = status;
			this.context = context;
			this.parentContext = parentContext;
		}

		public string QualifiedName
		{
			get { return this.qualifiedName; }
		}

		public ActivityExecutionStatus Status
		{
			get { return this.status; }
		}

		public Guid Context
		{
			get { return this.context; }
		}

		public Guid ParentContext
		{
			get { return this.parentContext; }
		}
	}
}

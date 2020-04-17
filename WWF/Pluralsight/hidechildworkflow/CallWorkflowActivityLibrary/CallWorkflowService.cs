using System.Workflow.Runtime.Hosting;
using System.Workflow.ComponentModel;
using System;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Runtime.Remoting.Messaging;
namespace CallWorkflowActivityLibrary
{
    public class CallWorkflowService : WorkflowRuntimeService
    {
        protected override void OnStarted()
        {
            base.OnStarted();
            this.Runtime.WorkflowCompleted += WorkflowCompleted;
            this.Runtime.WorkflowTerminated += WorkflowTerminated;
            this.Runtime.WorkflowLoaded += WorkflowLoaded;
        }
        void WorkflowCompleted(object o, WorkflowCompletedEventArgs e)
        {
            if (_childWorkflows.ContainsKey(e.WorkflowInstance.InstanceId))
            {
                Enqueue(e.WorkflowInstance.InstanceId, _childWorkflows[e.WorkflowInstance.InstanceId], e.OutputParameters);
            }
        }
        void WorkflowTerminated(object o, WorkflowTerminatedEventArgs e)
        {
            if (_childWorkflows.ContainsKey(e.WorkflowInstance.InstanceId))
            {
                Enqueue(e.WorkflowInstance.InstanceId, _childWorkflows[e.WorkflowInstance.InstanceId], new Exception("Called Workflow Terminated", e.Exception));
            }
        }
        void Enqueue(Guid callee, ChildData cd, object prms)
        {
            Guid caller = cd.Parent;
            WorkflowInstance c = this.Runtime.GetWorkflow(caller);
            IComparable qn = cd.QueueName;
            c.EnqueueItem(qn, prms, null, null);
            _childWorkflows.Remove(callee);

        }
        void WorkflowLoaded(object o, WorkflowEventArgs e)
        {
            Guid callee = e.WorkflowInstance.InstanceId;
            //avoids having to query metadata if already loaded
            if (!_childWorkflows.ContainsKey(callee))
            {
                Activity a = e.WorkflowInstance.GetWorkflowDefinition();
                Guid caller = GetCaller(a);
                if (caller != Guid.Empty)
                    _childWorkflows.Add(callee, new ChildData(caller, GetQueueName(a)));
            }

        }
        IComparable GetQueueName(Activity a)
        {
            IComparable qn = a.GetValue(CallingWorkflowQueueNameProperty) as IComparable;
            return qn;

        }
        Guid GetCaller(Activity a)
        {
            Guid ret = Guid.Empty;
            object caller = a.GetValue(CallingWorkflowIDProperty);
            if (caller != null)
                ret = (Guid)caller;
            return ret;
        }
        class ChildData
        {
            public ChildData(Guid p,IComparable qn)
            {
                this.Parent = p;
                this.QueueName = qn;
            }
            internal Guid Parent;
            internal IComparable QueueName;
        }
        Dictionary<Guid, ChildData> _childWorkflows = new Dictionary<Guid, ChildData>();
        public static DependencyProperty CallingWorkflowIDProperty = System.Workflow.ComponentModel.DependencyProperty.RegisterAttached("CallingWorkflowID", typeof(Guid) , typeof(CallWorkflowService));
        public static DependencyProperty CallingWorkflowQueueNameProperty = System.Workflow.ComponentModel.DependencyProperty.RegisterAttached("CallingWorkflowQueueName", typeof(IComparable) , typeof(CallWorkflowService));

        public void StartWorkflow(Type workflowType, Dictionary<string, object> inparms, Guid caller, IComparable qn)
        {
            WorkflowRuntime wr = this.Runtime;
            CallContext.SetData(CallingWorkflowIDProperty.Name, caller);
            CallContext.SetData(CallingWorkflowQueueNameProperty.Name, qn);
            WorkflowInstance wi = wr.CreateWorkflow(workflowType, inparms);
            _childWorkflows.Add(wi.InstanceId,new ChildData(caller,qn));
            wi.Start();
            ManualWorkflowSchedulerService ss = wr.GetService<ManualWorkflowSchedulerService>();
            if (ss != null)
                ss.RunWorkflow(wi.InstanceId);

        }

    }


}
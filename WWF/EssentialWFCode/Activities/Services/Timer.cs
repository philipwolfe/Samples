using System;
using System.Threading;
using System.Workflow.Runtime;
using System.Collections.Generic;
using System.Workflow.ComponentModel;

namespace EssentialWF.Services {
    public sealed class TimerService {
        WorkflowRuntime runtime;
        Dictionary<Guid, Timer> timers = new Dictionary<Guid, Timer>();
        public TimerService(WorkflowRuntime runtime) {
            this.runtime = runtime;
        }

        public void SetTimer(TimeSpan duration, Guid timerId, Guid workflowInstanceId) {
            Timer timer = new Timer(delegate(object o) {
                WorkflowInstance instance = this.runtime.GetWorkflow(workflowInstanceId);
                instance.EnqueueItem(timerId, null, null, null);
            }, timerId, duration, new TimeSpan(Timeout.Infinite));

            this.timers.Add(timerId, timer);
        }
        public void CancelTimer(Guid timerId) {
            ((IDisposable)this.timers[timerId]).Dispose();
            this.timers.Remove(timerId);
        }
    }
}
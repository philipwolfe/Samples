using System;
using System.Threading;
using System.Workflow.Runtime.Hosting;
using System.Collections.Generic;

namespace EssentialWF.Services {
    public sealed class SynchronizationContextSchedulerService : WorkflowSchedulerService {
    bool synchronousDispatch = true;
    Dictionary<Guid, Timer> timers = new Dictionary<Guid, Timer>();
    SynchronizationContext originalContext = null;

    public SynchronizationContextSchedulerService() : this(true)  {
    }
    public SynchronizationContextSchedulerService(bool synchronousDispatch) {
      this.originalContext = SynchronizationContext.Current;
      this.synchronousDispatch = synchronousDispatch;
    }
    public bool SynchronousDispatch { 
      get { return this.synchronousDispatch; } 
    }

    protected override void Schedule(WaitCallback callback, Guid workflowInstanceId) {
      //if the captured context on the thread that created the WF runtime
      //is null, try obtaining the Synch Context of the current thread
      SynchronizationContext ctx = this.originalContext != null ? this.originalContext : SynchronizationContext.Current;
      if (ctx != null) {
        if (this.SynchronousDispatch)
          ctx.Send(delegate {
                    callback(workflowInstanceId);
                }, null);
        else
          ctx.Post(delegate {
                    callback(workflowInstanceId);
                }, null);
      }
      else //oh well, run the scheduler's dispatch loop w/o a synch context
        callback(workflowInstanceId);
    }
    protected override void Schedule(WaitCallback callback, Guid workflowInstanceId, DateTime whenUtc, Guid timerId) {
      DateTime now = DateTime.UtcNow;
      TimeSpan span = (whenUtc > now) ? whenUtc - now : TimeSpan.Zero;
      this.timers.Add(timerId, new Timer(delegate {this.Schedule(callback, workflowInstanceId);}, 
          timerId, span, new TimeSpan(Timeout.Infinite)));
    }

    protected override void Cancel(Guid timerGuid) {
      ((IDisposable)this.timers[timerGuid]).Dispose();
      this.timers.Remove(timerGuid);
    }

    protected override void OnStopped() {
      foreach (Timer timer in this.timers.Values)
        ((IDisposable)timer).Dispose();

      this.timers.Clear();
      base.OnStopped();
    }
  }
}

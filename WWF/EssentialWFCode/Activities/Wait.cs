using System;
using System.Threading;
using System.Workflow.Runtime;
using System.Collections.Generic;
using System.Workflow.ComponentModel;
using EssentialWF.Services;

namespace EssentialWF.Activities {
    public class Wait : Activity {
        private Guid timerId;
        public static readonly DependencyProperty DurationProperty
           = DependencyProperty.Register("Duration",
            typeof(TimeSpan), typeof(Wait));

        public TimeSpan Duration {
            get { return (TimeSpan)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext context) {

            timerId = Guid.NewGuid();

            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

            WorkflowQueue queue = qService.CreateWorkflowQueue(timerId, false);
            queue.QueueItemAvailable += this.ContinueAt;

            TimerService timerService = context.GetService<TimerService>();
            timerService.SetTimer(this.Duration,
                timerId, base.WorkflowInstanceId);

            return ActivityExecutionStatus.Executing;
        }

        void ContinueAt(object sender, QueueEventArgs e) {
            ActivityExecutionContext context = sender as ActivityExecutionContext;

            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

            WorkflowQueue queue = qService.GetWorkflowQueue(timerId);
            qService.DeleteWorkflowQueue(timerId);

            context.CloseActivity();
        }
        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext context) {
            WorkflowQueuingService qService = context.GetService<WorkflowQueuingService>();

            if (qService.Exists(timerId)) {
                TimerService timerService = context.GetService<TimerService>();

                timerService.CancelTimer(timerId);
                qService.DeleteWorkflowQueue(timerId);
            }
            return ActivityExecutionStatus.Closed;
        }
    }
}

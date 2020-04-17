using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activities;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    class SHExceptionOutput : DurableServiceHostExtension
    {
        protected override void ExceptionUnhandled(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, DurableServiceUnhandledExceptionEventArgs args)
        {
            Console.WriteLine("WFSH Exception: " + args.UnhandledException.ToString());
            base.ExceptionUnhandled(instanceContext, args);
        }

        protected override void InstanceCompleted(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, Exception completionException)
        {
            Console.WriteLine("Approval Workflow Completed...");
            if (completionException != null)
            {
                Console.WriteLine("... With the exception: " + completionException.ToString());
            }
            base.InstanceCompleted(instanceContext, completionException);
        }

        protected override void InstanceAborted(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, Exception reason)
        {
            Console.WriteLine("WFSH Instance Aborted: " + reason.ToString());
            base.InstanceAborted(instanceContext, reason);
        }
    }
}

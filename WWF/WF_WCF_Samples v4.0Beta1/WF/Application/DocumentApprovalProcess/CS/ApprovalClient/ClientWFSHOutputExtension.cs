using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activities;
using System.IO;


namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    class ClientWFSHOutputExtension : DurableServiceHostExtension
    {
        TextWriter statusWriter;
        public ClientWFSHOutputExtension()
        {
            statusWriter = ExternalToMainComm.GetStatusWriter();
        }

        protected override void ExceptionUnhandled(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, DurableServiceUnhandledExceptionEventArgs args)
        {
            statusWriter.WriteLine(args.UnhandledException.ToString());
            base.ExceptionUnhandled(instanceContext, args);
        }

        protected override void InstanceCompleted(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, Exception completionException)
        {
            statusWriter.WriteLine("Approval Workflow Completed...");
            if (completionException != null)
            {
                statusWriter.WriteLine("... With the exception: " + completionException.ToString());
            }
            base.InstanceCompleted(instanceContext, completionException);
        }

        protected override void InstanceAborted(System.ServiceModel.Activities.Dispatcher.DurableInstanceContext instanceContext, Exception reason)
        {
            statusWriter.WriteLine(reason.ToString());
            base.InstanceAborted(instanceContext, reason);
        }
    }
}

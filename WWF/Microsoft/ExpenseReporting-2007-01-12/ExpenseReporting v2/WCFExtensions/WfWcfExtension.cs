//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Workflow.Activities;
using System.Workflow.Runtime;

namespace WcfExtensions
{
    /// <summary>
    /// This is an extension applied to ServiceHostBase which will instantiate an
    /// instance of our Workflow container and start the runtime. This provides
    /// a single instance of the Workflow runtime per service instance.
    /// </summary>
    public class WfWcfExtension : IExtension<ServiceHostBase>, IDisposable
    {
        private WorkflowRuntime workflowRuntime;
        private string workflowServicesConfig;

        public WfWcfExtension(string WorkflowServicesConfig)
        {
            workflowServicesConfig = WorkflowServicesConfig;
        }

        void IExtension<ServiceHostBase>.Attach(ServiceHostBase owner)
        {
            // When this Extension is attached within the Service Host, create a
            // new instance of the WorkflowServiceContainer
            workflowRuntime = new WorkflowRuntime(workflowServicesConfig);
            workflowRuntime.ServicesExceptionNotHandled +=
                new EventHandler<ServicesExceptionNotHandledEventArgs>(
                    workflowRuntime_ServicesExceptionNotHandled);

            ExternalDataExchangeService exSvc = new ExternalDataExchangeService();
            workflowRuntime.AddService(exSvc);

            // Start the services associated with the container
            workflowRuntime.StartRuntime();
        }

        private void workflowRuntime_ServicesExceptionNotHandled(object sender, ServicesExceptionNotHandledEventArgs e)
        {
            Console.WriteLine("ServicesExceptionNotHandled");
        }

        void IExtension<ServiceHostBase>.Detach(ServiceHostBase owner)
        {
            // When this WCF Extension is detached, then just stop the Workflow Container
            workflowRuntime.StopRuntime();
        }

        public WorkflowRuntime WorkflowRuntime
        {
            get { return workflowRuntime; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            workflowRuntime.Dispose();
        }

        #endregion
    }
}
//---------------------------------------------------------------------
//  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Reflection;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using Microsoft.Workflow.Bpel.Activities;
using System.Workflow.ComponentModel.Compiler;
using Microsoft.Samples.Workflow.Bpel.QuickStart.HelloWorld;

namespace Microsoft.Samples.Workflow.Bpel.QuickStart.SalutationService
{
    [WebService(Namespace = "http://tempuri.org/")]
    public class SalutationService : System.Web.Services.WebService
    {
        public SalutationService()
        {
            if (Application["WorkflowRuntime"] == null)
            {
                WorkflowRuntime workflowRuntime = new WorkflowRuntime();

                Application["WorkflowRuntime"] = workflowRuntime;
                Type workflowType = typeof(HelloWorldWorkflow);

                TypeProvider typeProvider = new TypeProvider(workflowRuntime);
                typeProvider.AddAssembly(workflowType.Assembly);
                workflowRuntime.AddService(typeProvider);

                BpelInMemoryMessagingService messagingService = new BpelInMemoryMessagingService();
                messagingService.Runtime = workflowRuntime;
                workflowRuntime.AddService(messagingService);

                WorkflowDeploymentService deplomentService = new WorkflowDeploymentService(workflowType, workflowRuntime);
                deplomentService.Deploy();

                messagingService.RegisterProxy("FileServiceSoap", workflowType.Assembly.Location);

                workflowRuntime.StartRuntime();
            }
        }

        [WebMethod]
        public void SendSalutation(string message)
        {
            WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as WorkflowRuntime;
            BpelMessagingService messagingService = workflowRuntime.GetService<BpelMessagingService>();

            object salutation = BpelInMemoryMessagingService.PackParameters(new object[] { message }, typeof(ns0.SendSalutationSoapIn));

            object retVal = messagingService.InvokeWorkflow("SalutationLinkType", "SalutationServiceSoap", "SendSalutation", typeof(HelloWorldWorkflow).FullName, salutation);

            if (retVal is Exception)
            {
                throw (Exception)retVal;
            }
        }
    }
}

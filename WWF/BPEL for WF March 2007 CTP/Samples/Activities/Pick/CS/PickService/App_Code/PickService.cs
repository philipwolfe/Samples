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
using System.Web.Services;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.Runtime;
using Microsoft.Workflow.Bpel.Activities;
using Microsoft.Samples.Workflow.Bpel.Activities.Pick;

namespace PickService
{
    [WebService(Namespace = "http://tempuri.org/")]
    public class PickService : System.Web.Services.WebService
    {                
        public PickService()
        {
            if (Application["WorkflowRuntime"] == null)
            {
                WorkflowRuntime workflowRuntime = new WorkflowRuntime();

                Application["WorkflowRuntime"] = workflowRuntime;
                Type workflowType = typeof(PickWorkflow);

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
        public void SendString(string message)
        {
            WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as WorkflowRuntime;
            BpelMessagingService messagingService = workflowRuntime.GetService<BpelMessagingService>();

            object parameters = BpelInMemoryMessagingService.PackParameters(new object[] { message }, typeof(ns0.SendStringSoapIn));
            object retVal = messagingService.InvokeWorkflow("pickLinkType", "PickServiceSoap", "SendString", "Microsoft.Samples.Workflow.Bpel.Activities.Pick.PickWorkflow", parameters);

            if (retVal is Exception)
            {
                throw (Exception)retVal;
            }
        }
    }
}

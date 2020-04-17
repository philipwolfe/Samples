using System;
using System.Web.Services;
using System.Reflection;
using System.Configuration;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel.Compiler;
using Microsoft.Workflow.Bpel.Activities;
using ns0;


[WebService(Namespace = "http://tempuri.org/")]
public class BankWebService : System.Web.Services.WebService
{
    private string assemblyName = "BankWorkflow.xoml, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
    private string WorkflowRuntimeKey = "WorkflowRuntime";

    public BankWebService()
    {
        if (Application[WorkflowRuntimeKey] == null)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();

            Application[WorkflowRuntimeKey] = workflowRuntime;
            Assembly workflowAssembly = Assembly.Load(assemblyName);

            TypeProvider typeProvider = new TypeProvider(workflowRuntime);
            typeProvider.AddAssembly(workflowAssembly);
            workflowRuntime.AddService(typeProvider);

            BpelInMemoryMessagingService messagingService = new BpelInMemoryMessagingService(workflowRuntime);
            workflowRuntime.AddService(messagingService);

            WorkflowDeploymentService deplomentService = new WorkflowDeploymentService(assemblyName, workflowRuntime);
            deplomentService.Deploy();            

            WorkflowRoutingSection workflowSection = ConfigurationManager.GetSection("RoutingMetadata") as WorkflowRoutingSection;        

            foreach (ProxyMapElement proxyElement in workflowSection.ProxyMap)
            {
                messagingService.RegisterProxy(proxyElement.PortType, workflowAssembly.Location);
            }

            workflowRuntime.StartRuntime();
        }                
    }

    [WebMethod]
    public int GetLoanQuote(string RequestId, int CreditReportId) 
    {
        WorkflowRuntime workflowRuntime = Application[WorkflowRuntimeKey] as WorkflowRuntime;
        BpelInMemoryMessagingService messagingService = workflowRuntime.GetService<BpelInMemoryMessagingService>();
        Assembly workflowAssembly = Assembly.Load(assemblyName);

        object inputMsg = BpelInMemoryMessagingService.PackParameters(new object[] { RequestId, CreditReportId }, workflowAssembly.GetType("ns0.GetLoanQuoteSoapIn"));

        object retVal = messagingService.InvokeWorkflow(
            "InternationalBankLink", 
            "BankWebServiceSoap", 
            "GetLoanQuote",
            "BpelWorkflow1.InternationalBankProcess"
            , inputMsg);

        if (retVal is Exception)
        {
            throw (Exception)retVal;
        }

        object[] retValues = BpelInMemoryMessagingService.UnpackParameters(retVal);

        if (retValues == null)
        {
            return 0;
        }
        else
        {
            return (int)retValues[0];
        }
    }
}
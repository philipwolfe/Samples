using System.ServiceModel;
using System.Activities;
using System;
using System.Collections.Generic;
using System.ServiceModel.Activities.Description;


namespace Microsoft.Samples.WF.ManagementEndpoint
{

    [WorkflowContractBehaviorAttribute]
    [ServiceContract(Name = Constants.ContractName, Namespace = Constants.Namespace)]
    interface IWorkflowControlService
    {
        // Non-Transacted operations
        [OperationContract(Name = Constants.Abandon)]
        void Abandon(Guid instanceId, string reason);

        [OperationContract(Name = Constants.Abandon, AsyncPattern = true)]
        IAsyncResult BeginAbandon(Guid instanceId, string reason, AsyncCallback callback, object state);
        void EndAbandon(IAsyncResult result);

        [OperationContract(Name = Constants.Cancel)]
        void Cancel(Guid instanceId);

        [OperationContract(Name = Constants.Cancel, AsyncPattern = true)]
        IAsyncResult BeginCancel(Guid instanceId, AsyncCallback callback, object state);
        void EndCancel(IAsyncResult result);

        [OperationContract(Name = Constants.Create)]
        Guid Create(IDictionary<string, object> inputs);

        [OperationContract(Name = Constants.Create, AsyncPattern = true)]
        IAsyncResult BeginCreate(IDictionary<string, object> inputs, AsyncCallback callback, object state);
        Guid EndCreate(IAsyncResult result);

        [OperationContract(Name = Constants.CreateWithInstanceId)]
        void CreateWithInstanceId(IDictionary<string, object> inputs, Guid instanceId);

        [OperationContract(Name = Constants.CreateWithInstanceId, AsyncPattern = true)]
        IAsyncResult BeginCreateWithInstanceId(IDictionary<string, object> inputs, Guid instanceId, AsyncCallback callback, object state);
        void EndCreateWithInstanceId(IAsyncResult result);

        [OperationContract(Name = Constants.Run)]
        void Run(Guid instanceId);

        [OperationContract(Name = Constants.Run, AsyncPattern = true)]
        IAsyncResult BeginRun(Guid instanceId, AsyncCallback callback, object state);
        void EndRun(IAsyncResult result);

        [OperationContract(Name = Constants.Suspend)]
        void Suspend(Guid instanceId, string reason);

        [OperationContract(Name = Constants.Suspend, AsyncPattern = true)]
        IAsyncResult BeginSuspend(Guid instanceId, string reason, AsyncCallback callback, object state);
        void EndSuspend(IAsyncResult result);

        [OperationContract(Name = Constants.Terminate)]
        void Terminate(Guid instanceId, string reason);

        [OperationContract(Name = Constants.Terminate, AsyncPattern = true)]
        IAsyncResult BeginTerminate(Guid instanceId, string reason, AsyncCallback callback, object state);
        void EndTerminate(IAsyncResult result);

        [OperationContract(Name = Constants.Unsuspend)]
        void Unsuspend(Guid instanceId);

        [OperationContract(Name = Constants.Unsuspend, AsyncPattern = true)]
        IAsyncResult BeginUnsuspend(Guid instanceId, AsyncCallback callback, object state);
        void EndUnsuspend(IAsyncResult result);

        //Transacted operations
        [OperationContract(Name = Constants.TransactedCancel)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedCancel(Guid instanceId);

        [OperationContract(Name = Constants.TransactedCancel, AsyncPattern = true)]
        IAsyncResult BeginTransactedCancel(Guid instanceId, AsyncCallback callback, object state);
        void EndTransactedCancel(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedCreate)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Guid TransactedCreate(IDictionary<string, object> inputs);

        [OperationContract(Name = Constants.TransactedCreate, AsyncPattern = true)]
        IAsyncResult BeginTransactedCreate(IDictionary<string, object> inputs, AsyncCallback callback, object state);
        Guid EndTransactedCreate(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedCreateWithInstanceId)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedCreateWithInstanceId(IDictionary<string, object> inputs, Guid instanceId);

        [OperationContract(Name = Constants.TransactedCreateWithInstanceId, AsyncPattern = true)]
        IAsyncResult BeginTransactedCreateWithInstanceId(IDictionary<string, object> inputs, Guid instanceId, AsyncCallback callback, object state);
        void EndTransactedCreateWithInstanceId(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedRun)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedRun(Guid instanceId);

        [OperationContract(Name = Constants.TransactedRun, AsyncPattern = true)]
        IAsyncResult BeginTransactedRun(Guid instanceId, AsyncCallback callback, object state);
        void EndTransactedRun(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedSuspend)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedSuspend(Guid instanceId, string reason);

        [OperationContract(AsyncPattern = true, Name = Constants.TransactedSuspend)]
        IAsyncResult BeginTransactedSuspend(Guid instanceId, string reason, AsyncCallback callback, object state);
        void EndTransactedSuspend(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedTerminate)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedTerminate(Guid instanceId, string reason);

        [OperationContract(AsyncPattern = true, Name = Constants.TransactedTerminate)]
        IAsyncResult BeginTransactedTerminate(Guid instanceId, string reason, AsyncCallback callback, object state);
        void EndTransactedTerminate(IAsyncResult result);

        [OperationContract(Name = Constants.TransactedUnsuspend)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void TransactedUnsuspend(Guid instanceId);

        [OperationContract(AsyncPattern = true, Name = Constants.TransactedUnsuspend)]
        IAsyncResult BeginTransactedUnsuspend(Guid instanceId, AsyncCallback callback, object state);
        void EndTransactedUnsuspend(IAsyncResult result);
    }
    public static class Constants
    {
        public const string ContractName = "IWorkflowControlService";
        public const string Namespace = "http://schemas.datacontract.org/2008/10/WorkflowServices";

        public const string Abandon = "Abandon";
        public const string Cancel = "Cancel";
        public const string Create = "Create";
        public const string CreateWithInstanceId = "CreateWithInstanceId";
        public const string Run = "Run";
        public const string Suspend = "Suspend";
        public const string Terminate = "Terminate";
        public const string Unsuspend = "Unsuspend";
        public const string TransactedCancel = "TransactedCancel";
        public const string TransactedCreate = "TransactedCreate";
        public const string TransactedCreateWithInstanceId = "TransactedCreateWithInstanceId";
        public const string TransactedRun = "TransactedRun";
        public const string TransactedSuspend = "TransactedSuspend";
        public const string TransactedTerminate = "TransactedTerminate";
        public const string TransactedUnsuspend = "TransactedUnsuspend";
    }
}
//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;
using Microsoft.Samples.Faults.SharedTypes;

namespace Microsoft.Samples.Faults.FaultService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowServiceHost host = new WorkflowServiceHost(GetServiceWorkflow(), new Uri(Constants.ServiceAddress)))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                host.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                host.AddServiceEndpoint(Constants.POContractName, Constants.Binding, Constants.ServiceAddress);

                host.Open();
                Console.WriteLine("FaultService waiting at: " + Constants.ServiceAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }

        }

        static WorkflowElement GetServiceWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            Variable<CorrelationHandle> handle = new Variable<CorrelationHandle>();
            Variable<Exception> exception = new Variable<Exception> { Name = "UnexpectedException" };

            Receive submitPO = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                CorrelatesWith = handle,
                Value = new OutArgument<PurchaseOrder>(po)
            };

            return new TryCatch
            {
                Variables = { po, handle },
                Try = new Sequence
                {
                    Activities =
                    {
                        submitPO,
                        new If 
                        {
                            Condition = new InArgument<bool>( (e) => po.Get(e).PartName.Equals("Widget") ),
                            Then = new If
                            {
                                Condition = new InArgument<bool>( (e) => po.Get(e).Quantity < 100 ),
                                Then = new SendReply
                                {
                                    DisplayName = "Successful response",
                                    Request = submitPO,                                        
                                    CorrelatesWith = handle,
                                    Value = new InArgument<string>( (e) => string.Format("Success: {0} Widgets have been ordered!", po.Get(e).Quantity) )
                                },
                                Else = new Throw
                                {
                                    Exception = new InArgument<Exception>((e) => new Exception("We don't have that many Widgets."))
                                }
                            },                        
                            Else = new SendReply
                            {
                                DisplayName = "Expected fault",
                                Request = submitPO,
                                CorrelatesWith = handle,
                                Value = new InArgument<FaultException<POFault>>( (e) => new FaultException<POFault>(
                                    new POFault
                                    {
                                        Problem = string.Format("This company does not carry {0}s.", po.Get(e).PartName),
                                        Solution = "Try your local hardware store."
                                    },
                                    new FaultReason("This is an expected fault.")
                                    ))
                            }
                        }
                    }
                },
                Catches =
                {
                    new Catch<Exception>
                    {
                        Action = new ActivityAction<Exception>
                        {
                            Argument = exception,
                            Handler = new SendReply
                            {
                                DisplayName = "Unexpected fault",
                                Request = submitPO,
                                CorrelatesWith = handle,
                                Value = new InArgument<Exception>(exception)
                            }
                        }
                    }
                }
            };

        }
    }

}

//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Threading;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using Microsoft.Samples.Faults.SharedTypes;

namespace Microsoft.Samples.Faults.FaultClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent syncEvent = new AutoResetEvent(false);

            WorkflowInstance myInstance = new WorkflowInstance(GetClientWorkflow());
            myInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            myInstance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e)
            {
                Console.WriteLine(e.UnhandledException.Message);
                return UnhandledExceptionAction.Terminate;
            };
            myInstance.Run();

            syncEvent.WaitOne();

            Console.WriteLine("Press [ENTER] to exit");
            Console.ReadLine();

        }

        static WorkflowElement GetClientWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>() { Default = new PurchaseOrder() { PartName = "Gizmo", Quantity = 155 } };
            Variable<CorrelationHandle> handle = new Variable<CorrelationHandle>();
            Variable<bool> invalidorder = new Variable<bool>() { Default = true };
            Variable<string> replytext = new Variable<string>();
            Variable<FaultException<POFault>> poFault = new Variable<FaultException<POFault>>();
            Variable<FaultException<ExceptionDetail>> unexpectedFault = new Variable<FaultException<ExceptionDetail>>();

            Send submitPO = new Send
            {
                Endpoint = new Endpoint
                {
                    Binding = Constants.Binding,
                    Uri = new Uri(Constants.ServiceAddress)
                },
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                CorrelatesWith = handle,
                KnownTypes = { typeof(POFault) },
                Value = new InArgument<PurchaseOrder>(po)
            };

            return new Sequence
            {
                Variables = { invalidorder },
                Activities = 
                {
                    new While 
                    {
                        Variables = { po, handle, replytext },
                        Condition = invalidorder,
                        Body = new Sequence
                        {
                            Activities = 
                            {
                                submitPO,
                                new TryCatch
                                {
                                    Try = new Sequence
                                    {
                                        Activities = 
                                        {
                                            new ReceiveReply
                                            {
                                                Request = submitPO,
                                                CorrelatesWith = handle,
                                                Value = new OutArgument<string>(replytext)
                                            },
                                            new WriteLine { Text = replytext },
                                            new Assign<bool> 
                                            {
                                                To = invalidorder,
                                                Value = false
                                            }
                                        }
                                    },
                                    Catches =                         
                                    {
                                        new Catch<FaultException<POFault>>
                                        {
                                            Action = new ActivityAction<FaultException<POFault>>
                                            {
                                                Argument = poFault,
                                                Handler = new Sequence
                                                {
                                                    Activities = 
                                                    {
                                                        new WriteLine { Text = new InArgument<string>((env) => string.Format("Received POFault: {0}", poFault.Get(env).Reason.ToString())) },
                                                        new WriteLine { Text = new InArgument<string>((env) => string.Format("POFault Problem: {0}", poFault.Get(env).Detail.Problem)) },
                                                        new WriteLine { Text = new InArgument<string>((env) => string.Format("POFault Solution: {0}", poFault.Get(env).Detail.Solution)) },
                                                        new Assign<string> 
                                                        {
                                                            To = new OutArgument<string>( (e) => po.Get(e).PartName ),
                                                            Value = "Widget"
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        new Catch<FaultException<ExceptionDetail>>
                                        {
                                            Action = new ActivityAction<FaultException<ExceptionDetail>>
                                            {
                                                Argument = unexpectedFault,
                                                Handler = new Sequence
                                                {
                                                    Activities = 
                                                    {
                                                        new WriteLine
                                                        {
                                                            Text = new InArgument<string>((e) => string.Format("Received Fault: {0}",
                                                                unexpectedFault.Get(e).Message
                                                                ))
                                                        },
                                                        new Assign<int> 
                                                        {
                                                            To = new OutArgument<int>( (e) => po.Get(e).Quantity ),
                                                            Value = new InArgument<int>( (e) => po.Get(e).Quantity - 10 )
                                                        }
                                                    }
                                                }
                                            }
                                        },

                                    }
                                }
                            }
                        }

                    },
                    new WriteLine { Text = "Client completed." }
                }


            };
        }
    }
}

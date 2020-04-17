//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.ServiceModel;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.Xaml;
    using System.Xml;
    using Microsoft.Samples.WorkflowServicesSamples.Common;
    using System.Xml.Linq;

    class Program
    {
        static WorkflowElement workflow;

        static void Main(string[] args)
        {
            CreateClientWorkflow();
            WorkflowInstance instance = new WorkflowInstance(workflow);
            instance.OnCompleted = OnCompleteInstanceExecution;
            instance.Run();
            Console.WriteLine("To exit press ENTER.");
            Console.ReadLine();
        }
        private static Sequence ExpenseRequest(Endpoint endpoint)
        {
            Variable<Expense> mealExpense = new Variable<Expense>
            {
                Name = "mealExpense",
                Default = new Meal { Amount = 50, Location = "Redmond", Vendor = "KFC" }
            };
            Variable<bool> result = new Variable<bool>
            {
                Name = "result"
            };
            Variable<CorrelationHandle> approveHandle = new Variable<CorrelationHandle>
            {
                Name = "approveHandle"
            };

            Send approveExpense = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApproveExpense",
                CorrelatesWith = approveHandle,
                ValueType = typeof(Expense),
                Value = new InArgument<Expense>(mealExpense)
            };
            approveExpense.KnownTypes.Add(typeof(Travel));
            approveExpense.KnownTypes.Add(typeof(Meal));

            Sequence workflow = new Sequence
            {
                Variables = { mealExpense, result, approveHandle },
                Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        approveExpense,
                        new ReceiveReply
                        {
                            Request = approveExpense,
                            CorrelatesWith = approveHandle,
                            ValueType = typeof(bool),
                            Value = new OutArgument<bool>(result)
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (result),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Expense Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Expense Cannot be Approved")
                                },
                        },

                    }
            };
            return workflow;
        }
        private static Sequence PurchaseOrderRequest(Endpoint endpoint)
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>
            {
                Name = "po",
                Default = new PurchaseOrder { RequestedAmount = 500, Description="New PC" }
            };
            Variable<bool> result = new Variable<bool>
            {
                Name = "result"
            };
            Variable<CorrelationHandle> approveHandle = new Variable<CorrelationHandle>
            {
                Name = "approveHandle"
            };

            Send approveExpense = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApprovePurchaseOrder",
                CorrelatesWith = approveHandle,
                ValueType = typeof(PurchaseOrder),
                Value = new InArgument<PurchaseOrder>(po),
                SerializerOption = SerializerOption.XmlSerializer
            };

            Sequence workflow = new Sequence
            {
                Variables = { po, result, approveHandle },
                Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        approveExpense,
                        new ReceiveReply
                        {
                            Request = approveExpense,
                            CorrelatesWith = approveHandle,
                            ValueType = typeof(bool),
                            Value = new OutArgument<bool>(result)
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (result),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase order Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase order Cannot be Approved")
                                },
                        },

                    }
            };
            return workflow;
        }
        private static Sequence VendorApprovalRequest(Endpoint endpoint)
        {
            Variable<VendorRequest> vendor = new Variable<VendorRequest>
            {
                Name = "vendor",
                Default = new VendorRequest { Name="Vendor1",requestingDepartment="HR" }
            };
            Variable<VendorResponse> result = new Variable<VendorResponse>
            {
                Name = "result"
            };
            Variable<CorrelationHandle> approveHandle = new Variable<CorrelationHandle>
            {
                Name = "approveHandle"
            };

            Send approvedVendor = new Send
            {
                ServiceContractName = XName.Get("FinanceService", "http://tempuri.org/"),
                Endpoint = endpoint,
                OperationName = "ApprovedVendor",
                CorrelatesWith = approveHandle,
                ValueType = typeof(VendorRequest),
                Value = new InArgument<VendorRequest>(vendor),
            };

            Sequence workflow = new Sequence
            {
                Variables = { vendor, result, approveHandle },
                Activities =
                    {
                        new WriteLine {
                            Text = new InArgument<string>("Hello")
                        },
                        approvedVendor,
                        new ReceiveReply
                        {
                            Request = approvedVendor,
                            CorrelatesWith = approveHandle,
                            ValueType = typeof(VendorResponse),
                            Value = new OutArgument<VendorResponse>(result)
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (env => result.Get(env).isPreApproved),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor is not Approved")
                                },
                        },

                    }
            };
            return workflow;
        }
        private static void CreateClientWorkflow()
        {

            Endpoint endpoint = new Endpoint
            {
                Uri = new Uri(Microsoft.Samples.WorkflowServicesSamples.Common.Constants.EchoServiceAddress),
                Binding = new BasicHttpBinding(),
            };
            workflow = new Sequence
            {
                Activities = 
                {
                    ExpenseRequest(endpoint),
                    PurchaseOrderRequest(endpoint),
                    VendorApprovalRequest(endpoint)
                }
            };
        }


        private static void OnCompleteInstanceExecution(WorkflowCompletedEventArgs e)
        {
            if (e.TerminationException != null)
            {
                Console.WriteLine("Workflow completed with {0}: {1}.", e.TerminationException.GetType().FullName, e.TerminationException.Message);
            }
            else
            {
                Console.WriteLine("Workflow completed successfully.");
            }
        }

    }
}

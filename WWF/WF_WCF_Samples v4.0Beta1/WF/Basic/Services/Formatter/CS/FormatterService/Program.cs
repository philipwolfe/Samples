//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.WorkflowServicesSamples.EchoWorkflowService
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel.Activities;
    using System.ServiceModel.Activities.Description;
    using System.Text;
    using System.Xml;
    using System.Xaml;
    using Microsoft.Samples.WorkflowServicesSamples.Common;
    


    class Program
    {
        static Service service;

        private static Sequence GetApproveExpense(Variable<Expense> expense, Variable<bool> reply, Variable<CorrelationHandle> approveExpenseHandle)
        {
            Receive approveExpense = new Receive
            {
                OperationName = "ApproveExpense",
                CanCreateInstance = true,
                ServiceContractName = "FinanceService",
                SerializerOption = SerializerOption.DataContractSerializer,
                ValueType = typeof(Expense),
                CorrelatesWith = approveExpenseHandle,
                Value = new OutArgument<Expense>(expense)
            };
            approveExpense.KnownTypes.Add(typeof(Travel));
            approveExpense.KnownTypes.Add(typeof(Meal));

            Sequence workflow = new Sequence()
            {
                Variables = { expense, reply, approveExpenseHandle },
                Activities =
                    {
                        approveExpense,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Expense approval request received"))
                        },
                        new If
                        {
                           Condition = new InArgument<bool> (env => (expense.Get(env).Amount <= 100)),
                           Then =                         
                               new Assign<bool>
                               {
                                   Value = true,
                                   To = new OutArgument<bool>(reply)
                               },
                           Else =                         
                               new Assign<bool>
                               {
                                   Value = false,
                                   To = new OutArgument<bool>(reply)
                               },                                                       
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (reply),
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
                        new SendReply
                        {                           
                            Request = approveExpense,
                            CorrelatesWith = approveExpenseHandle,
                            Value = new InArgument<bool>(reply),
                            ValueType = typeof(bool)
                        },
                    },
            };
            return workflow;
        }
        private static Sequence GetApprovePO(Variable<PurchaseOrder> po, Variable<bool> replyPO, Variable<CorrelationHandle> approvePOHandle)
        {
            Receive approvePO = new Receive
            {
                OperationName = "ApprovePurchaseOrder",
                CanCreateInstance = true,
                ServiceContractName = "FinanceService",
                SerializerOption = SerializerOption.XmlSerializer,
                ValueType = typeof(PurchaseOrder),
                CorrelatesWith = approvePOHandle,
                Value = new OutArgument<PurchaseOrder>(po)
            };

            Sequence workflow = new Sequence()
            {
                Variables = { po, replyPO, approvePOHandle },
                Activities =
                    {
                        approvePO,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Purchase order approval request received"))
                        },
                        new If
                        {
                           Condition = new InArgument<bool> (env => (po.Get(env).RequestedAmount <= 100)),
                           Then =                         
                               new Assign<bool>
                               {
                                   Value = true,
                                   To = new OutArgument<bool>(replyPO)
                               },
                           Else =                         
                               new Assign<bool>
                               {
                                   Value = false,
                                   To = new OutArgument<bool>(replyPO)
                               },                                                       
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (replyPO),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase Order Approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Purchase Order Cannot be Approved")
                                },
                        },
                        new SendReply
                        {                           
                            Request = approvePO,
                            CorrelatesWith = approvePOHandle,
                            Value = new InArgument<bool>(replyPO),
                            ValueType = typeof(bool)
                        },
                    },
            };
            return workflow;
        }
        private static Sequence GetApprovedVendor(Variable<VendorRequest> vendor, Variable<VendorResponse> replyVendor, Variable<CorrelationHandle> approvedVendorHandle)
        {
            Receive approvedVendor = new Receive
            {
                OperationName = "ApprovedVendor",
                CanCreateInstance = true,
                ServiceContractName = "FinanceService",
                ValueType = typeof(VendorRequest),
                CorrelatesWith = approvedVendorHandle,
                Value = new OutArgument<VendorRequest>(vendor)
            };

            Sequence workflow = new Sequence()
            {
                Variables = { vendor, replyVendor, approvedVendorHandle },
                Activities =
                    {
                        approvedVendor,
                        new WriteLine
                        {
                            Text = new InArgument<string>(env =>("Query for approved vendor received"))
                        },
                        new If
                        {
                           Condition = new InArgument<bool> (env => ((vendor.Get(env).requestingDepartment == "Finance"))||Constants.vendors.Contains(vendor.Get(env).Name)),
                           Then =                         
                               new Assign<VendorResponse>
                               {
                                   Value = new VendorResponse{isPreApproved = true},
                                   To = new OutArgument<VendorResponse>(replyVendor)
                               },
                           Else =                         
                               new Assign<VendorResponse>
                               {
                                   Value = new VendorResponse{isPreApproved = false},
                                   To = new OutArgument<VendorResponse>(replyVendor)
                               },                                                       
                        },

                        new If
                        {
                           Condition = new InArgument<bool> (env => replyVendor.Get(env).isPreApproved),
                           Then =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor is pre-approved")
                                },
                           Else =                         
                                new WriteLine
                                {
                                    Text = new InArgument<string>("Vendor is not pre-approved")
                                },
                        },
                        new SendReply
                        {                           
                            Request = approvedVendor,
                            CorrelatesWith = approvedVendorHandle,
                            Value = new InArgument<VendorResponse>(replyVendor),
                            ValueType = typeof(VendorResponse)
                        },
                    },
            };
            return workflow;
        }


        private static void CreateService()
        {
            Variable<Expense> expense = new Variable<Expense> { Name = "expense" };
            Variable<VendorRequest> vendor = new Variable<VendorRequest> { Name = "vendor" };
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder> { Name = "po" };
            Variable<bool> reply = new Variable<bool> { Name = "reply" };
            Variable<bool> replyPO = new Variable<bool> { Name = "reply" };
            Variable<VendorResponse> replyVendor = new Variable<VendorResponse> { Name = "reply" };
            Variable<CorrelationHandle> approveExpenseHandle = new Variable<CorrelationHandle> { Name = "ApproveExpenseHandle" };            
            Variable<CorrelationHandle> approvePOHandle = new Variable<CorrelationHandle> { Name = "ApprovePOHandle" };
            Variable<CorrelationHandle> approvedVendorHandle = new Variable<CorrelationHandle> { Name = "ApprovedVendorHandle" };

            Parallel workflow = new Parallel
            {
                Branches =
                {
                    GetApproveExpense(expense, reply, approveExpenseHandle),
                    GetApprovePO(po, replyPO, approvePOHandle),
                    GetApprovedVendor(vendor, replyVendor, approvedVendorHandle),
                }
            };
            service = new Service
                {                    
                    Implementation = new WorkflowServiceImplementation
                    {                        
                        Name = "FinanceService",
                        Body = workflow
                    },
                    Endpoints =
                    {
                        new Endpoint
                        {
                            ServiceContractName="FinanceService",
                            Uri = new Uri(Constants.EchoServiceAddress),
                            Binding = new BasicHttpBinding(),
                        }
                    }
                };
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Starting up...");
            CreateService();

            Uri address = new Uri(Constants.ServiceBaseAddress);
            System.ServiceModel.Activities.WorkflowServiceHost host = new System.ServiceModel.Activities.WorkflowServiceHost(service, address);

            try
            {
                Console.WriteLine("Opening service...");
                host.Open();

                Console.WriteLine("Service is listening on {0}...", address);
                Console.WriteLine("To terminate press ENTER");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service treminated with exception {0}", ex.ToString());
            }
            finally
            {
                host.Close();
            }
        }


        private static void OnCompleteInstanceExecution(object sender, WorkflowCompletedEventArgs e)
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


//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Activities;
using System.Activities.Statements;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceModel.Description;
using System.Xml.Linq;
using Microsoft.Samples.CascadingCorrelation.SharedTypes;

namespace Microsoft.Samples.CascadingCorrelation.FaultService
{    
    class Program
    {
        static void Main(string[] args)
        {
            using (WorkflowServiceHost host = new WorkflowServiceHost(GetServiceWorkflow(), new Uri(Constants.ServiceAddress)))
            {
                host.AddServiceEndpoint(Constants.POContractName, Constants.Binding, Constants.ServiceAddress);

                host.Open();
                Console.WriteLine("Service waiting at: " + Constants.ServiceAddress);
                Console.WriteLine("Press [ENTER] to exit");
                Console.ReadLine();
                host.Close();
            }

        }

        static WorkflowElement GetServiceWorkflow()
        {
            Variable<PurchaseOrder> po = new Variable<PurchaseOrder>();
            Variable<Customer> customer = new Variable<Customer>();
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle>();
            Variable<CorrelationHandle> poidHandle = new Variable<CorrelationHandle>();
            Variable<CorrelationHandle> custidHandle = new Variable<CorrelationHandle>();

            Receive submitPO = new Receive
            {
                CanCreateInstance = true,
                ServiceContractName = Constants.POContractName,
                OperationName = Constants.SubmitPOName,
                CorrelatesWith = requestReplyHandle,
                Value = new OutArgument<PurchaseOrder>(po)
            };
            
            MessageQuerySet poidAdditionalQuery = new MessageQuerySet
            {
                // int is the name of the parameter being sent in the outgoing response
                { "PoId", new XPathMessageQuery("//ser:int", Constants.XPathMessageContext) }
            };
            poidAdditionalQuery.Name = "PoIdQuery";

            MessageQuerySet poidQuery = new MessageQuerySet
            {
                // Id is the name of the incoming parameter within the PurchaseOrder
                { "PoId", new XPathMessageQuery("//defns:PurchaseOrder/defns:Id", Constants.XPathMessageContext) } 
            };

            MessageQuerySet custIdAdditionalQuery = new MessageQuerySet
            {
                // CustomerId is the name of the incoming parameter within the PurchaseOrder    
                { "CustId", new XPathMessageQuery("//defns:PurchaseOrder/defns:CustomerId", Constants.XPathMessageContext) } 
            };
            custIdAdditionalQuery.Name = "CustIdQuery";

            MessageQuerySet custIdQuery = new MessageQuerySet
            {
                // Id is the name of the incoming parameter within the Customer
                { "CustId", new XPathMessageQuery("//defns:Customer/defns:Id", Constants.XPathMessageContext) } 
            };            

            return new Sequence
            {
                Variables = { po, customer, requestReplyHandle, poidHandle, custidHandle },
                Activities =
                {
                    submitPO,
                    new WriteLine { Text = "Received PurchaseOrder" },
                    new Assign<int>
                    {
                        To = new OutArgument<int>( (e) => po.Get(e).Id ),
                        Value = new InArgument<int>( (e) => new Random().Next() )
                    },                    
                    new SendReply
                    {
                        Request = submitPO,
                        CorrelatesWith = requestReplyHandle,
                        AdditionalCorrelations = { { "PoIdQuery", poidHandle } },
                        CorrelationQuery = new CorrelationQuery
                        {                            
                            SelectAdditional = { poidAdditionalQuery }
                        },
                        Value = new InArgument<int>( (e) => po.Get(e).Id)
                    },                    
                    new Parallel 
                    {
                        Branches =
                        {
                            new Receive
                            {
                                ServiceContractName = Constants.POContractName,
                                OperationName = Constants.UpdatePOName,
                                CorrelatesWith = poidHandle,
                                CorrelationQuery = new CorrelationQuery
                                {                                    
                                    Select = poidQuery 
                                },
                                Value = new OutArgument<PurchaseOrder>(po)
                            },
                            new Sequence
                            {
                                Activities = 
                                {
                                    new Receive
                                    {
                                        ServiceContractName = Constants.POContractName,
                                        OperationName = Constants.AddCustomerInfoName,
                                        CorrelatesWith = poidHandle,
                                        AdditionalCorrelations = { { "CustIdQuery", custidHandle } }, 
                                        CorrelationQuery = new CorrelationQuery
                                        {                                         
                                            Select = poidQuery, 
                                            SelectAdditional = { custIdAdditionalQuery } 
                                        },
                                        Value = new OutArgument<PurchaseOrder>(po)
                                    },
                                    new WriteLine { Text = "Got CustomerId" },
                                    new Receive
                                    {
                                        ServiceContractName = Constants.POContractName,
                                        OperationName = Constants.UpdateCustomerName,
                                        CorrelatesWith = custidHandle,
                                        CorrelationQuery = new CorrelationQuery
                                        {                                            
                                            Select = custIdQuery, 
                                        },
                                        Value = new OutArgument<Customer>(customer)
                                    }
                                }
                            }
                        }
                    },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Workflow completed for PurchaseOrder {0}: {1} {2}s", po.Get(e).Id, po.Get(e).Quantity, po.Get(e).PartName) ) },
                    new WriteLine { Text = new InArgument<string>( (e) => string.Format("Order will be shipped to {0} as soon as possible", customer.Get(e).Name) ) }
                }
            };

        }
    }

}

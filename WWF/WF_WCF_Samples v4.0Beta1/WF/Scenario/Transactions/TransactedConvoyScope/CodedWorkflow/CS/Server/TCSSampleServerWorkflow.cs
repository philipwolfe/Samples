//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Server
{
    using Microsoft.Sample.Transaction.TransactedParallelConvoy.Common;
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel;
    using System.ServiceModel.Dispatcher;
    using System.ServiceModel.Activities;
    using System.Xml.Linq;

    sealed class TCSSampleServerWorkflow : Activity
    {
        static XName serviceContractName;

        public XName ServiceContractName
        {
            get
            {
                if (serviceContractName == null)
                {
                    throw new NullReferenceException();
                }
                return serviceContractName;
            }
            set
            {
                serviceContractName = value;
            }
        }

        static CorrelationQuery BuildCorrelationQuery(string contractName, string operationName)
        {
            XPathMessageContext context = new XPathMessageContext();

            return new CorrelationQuery
            {
                Where = new CorrelationActionMessageFilter
                {
                    Action = serviceContractName.Namespace.NamespaceName + contractName + "/" + operationName,
                },
                Select = new MessageQuerySet()
                {
                    { "CorrH", new XPathMessageQuery("//ser:string", context) },
                }
            };
        }

        protected override WorkflowElement CreateBody()
        {
            Variable<CorrelationHandle> trsCorrelation = new Variable<CorrelationHandle>() { Name = "CorrH" };
            Variable<string> correlationValue = new Variable<string>() { Name = "correlationID" };

            return new Sequence
            {
                Variables = { trsCorrelation, correlationValue },
                Activities =
                {
                    new WriteLine { Text = "Server: Workflow begins." },
                    
                    new Receive
                    {
                        OperationName = "bootstrap",
                        ServiceContractName = serviceContractName,
                        CanCreateInstance = true,
                        CorrelatesWith = trsCorrelation,
                        Value = new OutArgument<string>(correlationValue),
                        CorrelationQuery = BuildCorrelationQuery(serviceContractName.LocalName, "bootstrap"),
                    },

                    new WriteLine { Text = "Server: Starting TransactedConvoyScope." },
                        
                    new TransactedConvoyScope
                    {
                        Convoy = { trsFactory(1, trsCorrelation), 
                            trsFactory(2, trsCorrelation), 
                            trsFactory(3, trsCorrelation),
                        },
                        ConvoyBody = new Sequence
                        {
                            Activities = 
                            {
                                new WriteLine { Text = "Server: TCS body begins" },

                                new PrintTxDistributedID { Source = "Server: " },
                                
                                new WriteLine { Text = "Server: TCS body ends." },
                            }
                        },
                        //All three branches must finish
                        CompletionCondition = false,
                    },

                    new WriteLine { Text = "Server: Workflow ends" },
                },
            };
        }

        static TransactedReceiveScope trsFactory(int id, Variable<CorrelationHandle> ch)
        {
            Variable<string> request = new Variable<string>();
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle>();

            Receive r = new Receive
            {
                OperationName = "DoRequestReply" + id,
                ServiceContractName = serviceContractName,
                CanCreateInstance = false,
                CorrelatesWith = ch,
                Value = new OutArgument<string>(request),
                AdditionalCorrelations = { { CorrelationHandle.ChannelHandleName, requestReplyHandle } } ,
                CorrelationQuery = BuildCorrelationQuery(serviceContractName.LocalName, "DoRequestReply" + id),
            };
            return new TransactedReceiveScope
            {
                AbortInstanceOnTransactionFailure = true,
                Variables = { request, requestReplyHandle },
                ReceiveActivity = r,
                Body = new Sequence
                {
                    Activities =
                    {
                        new WriteLine { Text = "Server: TRS " + id + " receive complete." },
                        
                        new WriteLine { Text = "Server: TRS " + id + " begin reply." },

                        new PrintTxDistributedID { Source = "Server: " },

                        new SendReply
                        {
                            Request = r,
                            CorrelatesWith = requestReplyHandle
                        },

                        new WriteLine { Text = "Server: TRS " + id + " reply sent." },
                    }
                }
            };
        }
    }
}

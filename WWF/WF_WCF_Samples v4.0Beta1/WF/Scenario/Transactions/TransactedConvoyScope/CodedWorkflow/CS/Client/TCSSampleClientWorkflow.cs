//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Sample.Transaction.TransactedParallelConvoy.Client
{
    using Microsoft.Sample.Transaction.TransactedParallelConvoy.Common;
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.ServiceModel;
    using System.ServiceModel.Activities;
    using System.Xml.Linq;

    sealed class TCSSampleClientWorkflow :  Activity
    {
        Endpoint serverEndpoint;
        XName serviceContractName;

        public Endpoint ServerEndpoint
        {
            get
            {
                if (serverEndpoint == null)
                {
                    throw new NullReferenceException();
                }
                return this.serverEndpoint;
            }
            set
            {
                this.serverEndpoint = value;
            }
        }

        public XName ServiceContractName
        {
            get
            {
                if (serviceContractName == null)
                {
                    throw new NullReferenceException();
                } 
                return this.serviceContractName;
            }
            set
            {
                this.serviceContractName = value;
            }
        }

        protected override WorkflowElement CreateBody()
        {
            string correlationKey = Guid.NewGuid().ToString();

            return new Sequence()
            {
                Activities =
                {
                    new WriteLine { Text = "Client: Workflow begins." },

                    //Bootstrap - This send 
                    new Send
                    {
                        OperationName = "bootstrap",
                        Endpoint = serverEndpoint,
                        Value = new InArgument<string>(correlationKey),
                        ServiceContractName = serviceContractName,
                    },

                    new TransactionScopeActivity
                    {
                        Body = new Sequence
                        {
                            Activities =
                            {                       
                                new PrintTxDistributedID { Source = "Client: " },
                                
                                new WriteLine { Text = "Client: Beginning sends." },

                                new Parallel()
                                {
                                    CompletionCondition = false,
                                    Branches = 
                                    {
                                        requestReplyFactory(1, correlationKey),                             
                                        requestReplyFactory(2, correlationKey), 
                                        requestReplyFactory(3, correlationKey),
                                    },
                                },
                                
                                new PrintTxDistributedID { Source = "Client: " },

                                new WriteLine { Text = "Client: All sends complete." },

                                new WriteLine { Text = "Client: Workflow ends." },
                            },
                        },
                    },
                },
            };           
        }

        WorkflowElement requestReplyFactory(int id, string correlationKey)
        {
            Variable<CorrelationHandle> requestReplyHandle = new Variable<CorrelationHandle>();
            
            Send send = new Send
            {
                OperationName = "DoRequestReply" + id,
                Endpoint = ServerEndpoint,
                Value = new InArgument<string>(correlationKey),
                CorrelatesWith = requestReplyHandle,
                ServiceContractName = ServiceContractName,
            };

            return new Sequence
            {
                Variables = { requestReplyHandle },
                Activities = 
                 {
                     new Sequence
                     {
                         Activities =                                 
                         {
                            new WriteLine { Text = "Client: Beginning branch " + id + " send." },

                            send,

                            new WriteLine { Text = "Client: Branch " + id + " send complete." },

                            new ReceiveReply
                            {
                                Request = send,
                                CorrelatesWith = requestReplyHandle
                            },

                            new WriteLine { Text = "Client: Branch " + id + " reply received" },

                            new WriteLine { Text = "Client: Branch " + id + " ends." },
                         },
                     },
                 },
            };
        }
    }
}

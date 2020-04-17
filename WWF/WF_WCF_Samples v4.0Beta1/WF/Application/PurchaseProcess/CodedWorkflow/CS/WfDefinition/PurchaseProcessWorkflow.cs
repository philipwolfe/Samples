//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.WF.PurchaseProcess
{
    using System;
    using System.Activities;
    using System.Activities.Statements;
    using System.Collections.Generic;

    /// <summary>
    /// Definition of the Purchase Process workflow
    /// </summary>
    public sealed class PurchaseProcessWorkflow : Activity<VendorProposal>
    {
        public InArgument<RequestForProposal> Rfp { get; set; }
		
        public PurchaseProcessWorkflow()
        {
            // variables declaration. The variables with Modifiers = VariableModifiers.Mapped can participate in schematized persistence
            var requestForProposal = new Variable<RequestForProposal> { Modifiers = VariableModifiers.Mapped }; 
            var iterationVariableVendor = new Variable<Vendor>();
            var iterationVariableVendorProposal = new Variable<VendorProposal>();
            var bestProposal = new Variable<VendorProposal>() { Default = new VendorProposal { Value = double.MaxValue } };
            var proposalAdjustedValue = new Variable<double>();            
            var tmpValue = new Variable<double>();            
            
            this.Body = () => new Sequence
            {
                Variables = { bestProposal, proposalAdjustedValue, requestForProposal },
                Activities =
                {             
                    // assign the Request for Proposal in argument to a variable visible during the schematized persistence setp
                    new Assign<RequestForProposal>
                    {
                        DisplayName = "Assign the Rpf argument to a variable that is visible in persistence",
                        To = new OutArgument<RequestForProposal>(requestForProposal),
                        Value = new InArgument<RequestForProposal>(env => Rfp.Get(env))
                    },                    

                    // invite all vendors and wait for their proposals
                    new ParallelForEach<Vendor>
                    {
                        DisplayName = "Get vendor proposals",
                        Values = new InArgument<IEnumerable<Vendor>>(env => this.Rfp.Get(env).InvitedVendors),
                        Body = new ActivityAction<Vendor>()
                        {                                    
                            Argument = iterationVariableVendor,
                            Handler = new Sequence
                            {
                                Variables = { tmpValue },
                                Activities =
                                {
                                    // waits for a vendor proposal (creates a bookmark for a vendor)
                                    new WaitForVendorProposal 
                                    { 
                                        VendorId = new InArgument<int>(env => iterationVariableVendor.Get(env).Id) ,
                                        Result = new OutArgument<double>(tmpValue)
                                    },

                                    // after the vendor proposal is received, it is registered in the Request for Proposals
                                    new InvokeMethod
                                    {
                                        TargetObject = new InArgument<RequestForProposal>(env => this.Rfp.Get(env)),
                                        MethodName = "RegisterProposal",
                                        Parameters = 
                                        {
                                            new InArgument<Vendor>(iterationVariableVendor),
                                            new InArgument<double>(tmpValue)
                                        }
                                    },
                                }
                            }                        
                        }
                    },

                    // select the best vendor proposal of all received proposals. The best offer is selected
                    // using a calculation that adjusts the proposal submitted by the vendor using his reputation 
                    new ForEach<VendorProposal>
                    {
                        DisplayName = "Select best proposal",
                        Values = new InArgument<IEnumerable<VendorProposal>>(env => Rfp.Get(env).VendorProposals.Values),
                        Body = new ActivityAction<VendorProposal>()
                        {
                            Argument = iterationVariableVendorProposal,
                            Handler = new Sequence
                            {
                                Activities =
                                {
                                    // adjust the value of the proposal using the vendor's reputation
                                    new Assign<double>
                                    {
                                        To = new OutArgument<double>(proposalAdjustedValue),
                                        Value = new InArgument<double>(env => iterationVariableVendorProposal.Get(env).Value * (1 - (iterationVariableVendorProposal.Get(env).Vendor.Reliablity / 100)))
                                    },

                                    // check if the adjusted value is the best proposal
                                    new If
                                    {                                        
                                        Condition = new InArgument<bool>(env => proposalAdjustedValue.Get(env) < bestProposal.Get(env).Value),
                                        Then = new Assign<VendorProposal>
                                        {
                                            To = bestProposal,
                                            Value = iterationVariableVendorProposal
                                        }
                                    }
                                }
                            }                        
                        }
                    },
                    // set the Request for Proposals best proposal
                    new Assign<VendorProposal> 
                    { 
                        To = new OutArgument<VendorProposal>(env => this.Rfp.Get(env).BestProposal),
                        Value = new InArgument<VendorProposal>(bestProposal)
                    },            
                    // set the Request for Proposals completion date
                    new Assign<DateTime> 
                    { 
                        To = new OutArgument<DateTime>(env => this.Rfp.Get(env).CompletionDate),
                        Value = new InArgument<DateTime>(DateTime.Now)
                    },
                    // save to persistent storage
                    new Persist(),

                    // return value of the workflow: best proposal
                    new Assign<VendorProposal> 
                    { 
                        To = new OutArgument<VendorProposal>(env => this.Result.Get(env)),
                        Value = new InArgument<VendorProposal>(bestProposal)
                    }
                }
            };
        }    
    }
}
//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Collections.Generic;
using System.Activities;
using System.Activities.Statements;
using System.Activities.Validation;

namespace Microsoft.Samples.ContainmentValidation
{
    
    public sealed class ActivityCity : CodeActivity
    {
        public string Name { get; set; }  

        protected override void OnGetConstraints(IList<Constraint> constraints)
        {
            constraints.Add(CheckParent());      
        }

        static Constraint CheckParent()
        {
            Variable<ActivityCity> element = new Variable<ActivityCity>();
            Variable<ValidationContext> context = new Variable<ValidationContext>();
            Variable<bool> result = new Variable<bool>();
            Variable<WorkflowElement> parent = new Variable<WorkflowElement>();
            
            
            return new Constraint<ActivityCity>
            {                   
                Body = new ActivityAction<ActivityCity,ValidationContext>
                {                    
                    Argument1 = element,
                    Argument2 = context,
                    Handler = new Sequence
                    {
                        Variables =
                        {
                            result 
                        },
                        Activities =
                        {
                            new ForEach<WorkflowElement>
                            {                                
                                Values = new GetParentChain
                                {
                                    ValidationContext = context                                    
                                },
                                Body = new ActivityAction<WorkflowElement>
                                {                                    
                                    Argument = parent, 
                                    Handler = new If()
                                    {                                          
                                        Condition = new InArgument<bool>((env) => object.Equals(parent.Get(env).GetType(),typeof(ActivityCountry))),
                                        Then = new Assign<bool>
                                        {
                                            Value = true,
                                            To = result
                                        }
                                    }
                                }                                
                            },
                            new AssertValidation
                            {
                                Assertion = new InArgument<bool>(result),
                                Message = new InArgument<string> ("ActivityCity has to be inside an ActivityCountry"),
                                ErrorCode = new InArgument<string> ("Build-1002"),
                                PropertyName = new InArgument<string>((env) => element.Get(env).Name)
                            }
                        }
                    }
                }
            };
        }

        protected override void Execute(CodeActivityContext context)
        {
            // not needed for the sample
        }
    }
    
}

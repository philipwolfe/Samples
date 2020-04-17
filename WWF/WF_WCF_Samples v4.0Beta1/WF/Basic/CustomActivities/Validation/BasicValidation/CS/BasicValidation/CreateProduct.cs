//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Collections.Generic;
using System.Activities;
using System.Activities.Validation;

namespace Microsoft.Samples.BasicValidation
{
    public sealed class CreateProduct : CodeActivity
    {
        public double Price { get; set; }
        public double Cost { get; set; }

        protected override void OnGetConstraints(IList<Constraint> constraints)
        {
            constraints.Add(PriceGreaterThanCost());                
        }

        static Constraint PriceGreaterThanCost()
        {
            Variable<CreateProduct> element = new Variable<CreateProduct>();
            Variable<ValidationContext> context = new Variable<ValidationContext>();

            return new Constraint<CreateProduct>
            {
                Body = new ActivityAction<CreateProduct, ValidationContext>
                {
                    Argument1 = element,
                    Argument2 = context,
                    Handler = new AssertValidation
                    {
                        Assertion = new InArgument<bool>((env) => element.Get(env).Cost <= element.Get(env).Price),
                        Message = new InArgument<string>("The Cost must be less than or equal to the Price"),
                        ErrorCode = new InArgument<string>("1001")
                    }
                }            
            };
        }

        protected override void  Execute(CodeActivityContext context)
        {
         	// not needed for the sample
        }
    }
}

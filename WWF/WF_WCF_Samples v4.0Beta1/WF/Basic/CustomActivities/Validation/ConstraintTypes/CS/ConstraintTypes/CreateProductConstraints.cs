//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System.Activities;
using System.Activities.Validation;

namespace Microsoft.Samples.ConstraintTypes
{
    class CreateProductConstraints
    {
        public static Constraint MaxPrice() //Policy Constraint
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
                        IsWarning = true,
                        Assertion = new InArgument<bool>(env => element.Get(env).Price <= 9.99),
                        Message = new InArgument<string>("The majority of products should be $9.99 or less"),
                        ErrorCode = new InArgument<string>("2001")                        
                    }
                }
            };
        }
    }
}

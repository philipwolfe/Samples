//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.LinqToObjects
{
    using System;
    using System.Activities;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This activity finds items in a collection using Linq To Objects 
    /// It receives a collection an a predicate and return all the elements in the collection 
    /// that satisfy that predicate
    /// </summary>
    /// <typeparam name="TResult">Type of the items of the collection</typeparam>
    public sealed class FindInCollection<TResult> : CodeActivity<IList<TResult>> where TResult : class
    {
        [IsRequired]
        public InArgument<IEnumerable<TResult>> Collections { get; set; }

        [IsRequired]
        public InArgument<Func<TResult, bool>> Predicate { get; set; }       

        public FindInCollection()
        {
        }

        protected override void Execute(CodeActivityContext context)
        {            
            IEnumerable<TResult> q = 
                    from row in this.Collections.Get(context) 
                    where this.Predicate.Get(context)(row)
                    select row;

            this.Result.Set(context, new List<TResult>(q));
        }
    }
}
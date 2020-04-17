//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.SwitchRange
{
    using System;
    using System.Activities;
   
    /// <summary>
    /// Representation of a range of values. 
    /// </summary>
    /// <typeparam name="T">Type of the values in the range</typeparam>
    public class CaseRange<T> where T : IComparable
    {
        public T From { get; set; }
        public T To { get; set; }
        public WorkflowElement Action { get; set; }

        public bool IsInRange(T value)
        {
            return ((value.CompareTo(From) == 1 || value.CompareTo(From) == 0) &&
                    (value.CompareTo(To) == -1 || value.CompareTo(To) == 0));
        }
    }
}

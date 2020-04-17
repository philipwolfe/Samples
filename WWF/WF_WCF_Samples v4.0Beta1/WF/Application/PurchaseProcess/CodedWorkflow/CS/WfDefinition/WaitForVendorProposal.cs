//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.WF.PurchaseProcess
{
    using System;
    using System.Activities;
    using System.Globalization;
    
    /// <summary>
    /// This custom activity creates a named bookmark that
    /// must be resumed later by a vendor when 
    /// submitting the proposal
    /// </summary>
    public sealed class WaitForVendorProposal: NativeActivity<double>
    {
        public InArgument<int> VendorId { get; set; }

        protected override void Execute(ActivityExecutionContext context)
        {
            string name = "waitingFor_" + this.VendorId.Get(context).ToString();

            if (VendorId.Get(context) == 0)
            {
                throw new Exception("Vendor identifier is required");
            }

            context.CreateNamedBookmark(name, new BookmarkCallback(OnReadComplete));
        }

        void OnReadComplete(ActivityExecutionContext context, Bookmark bookmark, object state)
        {          
            double input = Convert.ToDouble(state, new CultureInfo("EN-us"));
            context.SetValue(this.Result, input);
        }
    }
}

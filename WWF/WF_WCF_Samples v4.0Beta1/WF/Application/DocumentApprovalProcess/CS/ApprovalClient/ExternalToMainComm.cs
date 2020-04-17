//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalClient
{
    public static class ExternalToMainComm
    {
        public static Main Context { get; set; }

        public static void NewApprovalRequest(ApprovalRequest request)
        {
            if (Context != null)
                Context.AddApprovalItem(request);
        }

        public static void ApprovalRequestResponse(ApprovalResponse response)
        {
            if (Context != null)
                Context.ProcessResponse(response);
        }

        public static TextWriter GetStatusWriter()
        {
            if (Context != null)
                return new WindowTextWriter(Context.GetStatusTextBox());
            else
                return null;
        }

        public static void WriteStatusLine(String status)
        {
            if (Context != null)
            {
                GetStatusWriter().WriteLine(status);
            }
        }
    }
}

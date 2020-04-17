//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------ 

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalManager
{
    using System;
    using System.Activities.Tracking;
    using System.Reflection;
    using System.IO;
    using System.Collections.Specialized;

    public class ConsoleParticipant : TrackingParticipant
    {
        public ConsoleParticipant()
        {
            if (Writer == null)
            {
                Writer = Console.Out;
            }
            Writer.WriteLine("ConsoleParticipant Created");
        }

        public ConsoleParticipant(NameValueCollection parameters)
            : this()
        {
            if (parameters != null)
            {
                foreach (string name in parameters)
                {
                    if (string.Compare(name, "connectionString", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        Writer.WriteLine("ConnectionString: " + parameters[name]);
                    }
                    else if (string.Compare(name, "trackingStore", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        Writer.WriteLine("TrackingStore: " + parameters[name]);
                    }
                }
            }
        }

        internal static TextWriter Writer{ get; set; }
        public override void Track(TrackingRecord record, TimeSpan timeout)
        {
            Writer.WriteLine(record.GetType().FullName);
            Writer.WriteLine("\tLevel: " + record.Level + ", RecordNumber: " + record.RecordNumber);
            if (record.Annotations.Count > 0)
            {
                foreach (string key in record.Annotations.Keys)
                {
                    Writer.WriteLine("\t" + key + "\t" + record.Annotations[key]);
                }
            }
        }
    }
}

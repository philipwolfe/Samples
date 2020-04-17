//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------ 

namespace Microsoft.Samples.CustomTrackingSample
{
    using System;
    using System.Activities.Tracking;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;

    // A custom tracking participant that emits tracking records to the console
    public class ConsoleTrackingParticipant : TrackingParticipant
    {
        private const String participantName = "ConsoleTrackingParticipant";

        public ConsoleTrackingParticipant()
        {
            Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                "{0} Created", participantName));
        }


        public override void Track(TrackingRecord record, TimeSpan timeout)
        {
            Console.Write(String.Format(CultureInfo.InvariantCulture, 
                "{0} emitted trackRecord: {1}  Level: {2}, RecordNumber: {3}",
                  participantName, record.GetType().FullName, 
                  record.Level, record.RecordNumber));

            WorkflowInstanceRecord workflowInstanceRecord = record as WorkflowInstanceRecord;
            if (workflowInstanceRecord != null)
            {
                Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                    " Workflow InstanceID: {0} Workflow instance state: {1}",
                    record.InstanceId, workflowInstanceRecord.State));
            }

            ActivityTrackingRecord activityTrackingRecord = record as ActivityTrackingRecord;
            if (activityTrackingRecord != null)
            {
                IDictionary<String, object> variables = activityTrackingRecord.Variables;
                StringBuilder vars = new StringBuilder();

                if (variables.Count > 0)
                {
                    vars.AppendLine("\n\tVariables:");
                    foreach (KeyValuePair<string, object> variable in variables)
                    {   
                        vars.AppendLine(String.Format(
                            "\t\tName: {0} Value: {1}", variable.Key, variable.Value));
                    }
                }
                Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                    " :Activity DisplayName: {0} :ActivityInstanceState: {1} {2}",
                       activityTrackingRecord.Name, activityTrackingRecord.State,
                    ((variables.Count > 0) ? vars.ToString() : String.Empty)));
            }

            UserTrackingRecord userTrackingRecord = record as UserTrackingRecord;

            if ((userTrackingRecord != null) && (userTrackingRecord.Data.Count > 0))
            {
                Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                    "\n\tUser Data:"));
                foreach (string data in userTrackingRecord.Data.Keys)
                {
                    Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                        " \t\t {0} : {1}", data, userTrackingRecord.Data[data]));
                }
            }
            Console.WriteLine();

        }
    }
}

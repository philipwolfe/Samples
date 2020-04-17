//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities.Tracking;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    class TextWriterTrackingParticipant : TrackingParticipant
    {
        TextWriter writer;

        public TextWriterTrackingParticipant(TextWriter textWriter)
        {
            this.writer = textWriter;
        }

        public override void Track(TrackingRecord record, TimeSpan timeout)
        {
            StringBuilder trackingContents = new StringBuilder();

            trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                "{0}:  Level: {1}, RecordNumber: {2}",
                  record.GetType().Name, record.Level, record.RecordNumber);

            if (record is WorkflowInstanceRecord)
            {
                trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                    " Workflow InstanceID: {0} Workflow instance state: {1}\n",
                    record.InstanceId, ((WorkflowInstanceRecord)record).State);
            }
            else if (record is ActivityTrackingRecord)
            {
                ActivityTrackingRecord activityTrackingRecord = (ActivityTrackingRecord)record;

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
                trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                    " :Activity DisplayName: {0} :ActivityInstanceState: {1} {2}\n",
                       activityTrackingRecord.Name, activityTrackingRecord.State,
                    ((variables.Count > 0) ? vars.ToString() : String.Empty));

                if (activityTrackingRecord is ActivityScheduledRecord)
                {
                    trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                        " :ChildActivity DisplayName: {0}\n",
                           ((ActivityScheduledRecord)activityTrackingRecord).ChildActivityName);                    
                }
            }
            else if (record is UserTrackingRecord)
            {
                UserTrackingRecord userTrackingRecord = (UserTrackingRecord)record;

                if (userTrackingRecord.Data.Count > 0)
                {
                    trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                        "\n\tUser Data:\n");
                    foreach (string data in userTrackingRecord.Data.Keys)
                    {
                        trackingContents.AppendFormat(CultureInfo.InvariantCulture,
                            " \t\t {0} : {1}\n", data, userTrackingRecord.Data[data]);
                    }
                }
            }

            this.writer.WriteLine(trackingContents);
        }

    }
}

//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.IO;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Tracking;
using System.Workflow.ComponentModel;
using System.Workflow.Runtime.Hosting;

namespace ConsoleTrackingServiceSample
{
    public class ConsoleTrackingChannel : TrackingChannel
    {
        private TrackingParameters parameters = null;

        protected ConsoleTrackingChannel()
        {
        }

        public ConsoleTrackingChannel(TrackingParameters parameters)
        {
            this.parameters = parameters;
        }

        protected override void Send(TrackingRecord record)
        {
            // filter on record type
            if (record is WorkflowTrackingRecord)
            {
                WriteWorkflowTrackingRecord((WorkflowTrackingRecord)record);
            }
            if (record is ActivityTrackingRecord)
            {
                WriteActivityTrackingRecord((ActivityTrackingRecord)record);
            }
            if (record is UserTrackingRecord)
            {
                WriteUserTrackingRecord((UserTrackingRecord)record);
            }
        }

        #region support-code
        private static void WriteTitle(string title)
        {
            Console.WriteLine("\n******************************************");
            Console.WriteLine("\t" + title);
            Console.WriteLine("******************************************");
        }
        private static void WriteWorkflowTrackingRecord(WorkflowTrackingRecord workflowTrackingRecord)
        {
            WriteTitle("Workflow Tracking Record");
            Console.WriteLine("EventDateTime: " + workflowTrackingRecord.EventDateTime.ToString());
            Console.WriteLine("Status: " + workflowTrackingRecord.TrackingWorkflowEvent.ToString());
        }
        private static void WriteActivityTrackingRecord(ActivityTrackingRecord activityTrackingRecord)
        {
            WriteTitle("Activity Tracking Record");
            Console.WriteLine("EventDateTime: " + activityTrackingRecord.EventDateTime.ToString());
            Console.WriteLine("QualifiedName: " + activityTrackingRecord.QualifiedName.ToString());
            Console.WriteLine("Type: " + activityTrackingRecord.ActivityType);
            Console.WriteLine("Status: " + activityTrackingRecord.ExecutionStatus.ToString());
        }
        private static void WriteUserTrackingRecord(UserTrackingRecord userTrackingRecord)
        {
            WriteTitle("User Activity Record");
            Console.WriteLine("EventDateTime: " + userTrackingRecord.EventDateTime.ToString());
            Console.WriteLine("QualifiedName: " + userTrackingRecord.QualifiedName.ToString());
            Console.WriteLine("ActivityType: " + userTrackingRecord.ActivityType.FullName.ToString());
            Console.WriteLine("Args: " + userTrackingRecord.UserData.ToString());
        }
        #endregion

        protected override void InstanceCompletedOrTerminated()
        {
            WriteTitle("Workflow Instance Completed or Terminated");
        }
    }
}

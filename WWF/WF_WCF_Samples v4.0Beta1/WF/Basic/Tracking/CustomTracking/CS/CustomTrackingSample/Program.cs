//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Samples.CustomTrackingSample
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Activities;
    using System.Activities.Statements;
    using System.Activities.Tracking;


    class Program
    {
        // Custom workflow activity demonstrates usage of user tracking record
        // The custom activity creates a user tracking record and emits the record
        // A custom tracking participant can subscribe for user tracking records
        sealed class CustomActivity : CodeActivity
        {

            protected override void Execute(CodeActivityContext context)
            {

                Console.WriteLine("In CustomActivity.Execute");
                UserTrackingRecord userRecord = new UserTrackingRecord("OrderIn")
                {
                    Data = 
                            {
                                {"OrderId", 200},
                                {"OrderDate", "20 Aug 2001"}
                            }
                };

                // Emit user tracking record
                context.Track(userRecord);
            }
        }

        static WorkflowElement BuildSampleWorkflow()
        {
            return new Sequence()
            {
                Activities =
                    {
                        new WriteLine() { Text = "Begin Workflow" },
                        new CustomActivity(),
                        new WriteLine() { Text = "End Workflow" },
                    }
            };
        }

        static void Main(string[] args)
        {
            const String all = "*"; 
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            ConsoleTrackingParticipant customTrackingParticipant = new ConsoleTrackingParticipant()
            {
                // Create a tracking profile to subscribe for tracking records
                // In this sample the profile subscribes for user tracking records,
                // workflow instance records and activity records
                TrackingProfile = new TrackingProfile()
                {
                    Name = "CustomTrackingProfile",
                    Queries = 
                    {
                        new UserTrackingQuery() 
                        {
                         Name = all,
                         ActivityName = all
                        },
                        new WorkflowInstanceQuery()
                        {
                            // Limit workflow instance tracking records for started and completed workflow states
                            States = { WorkflowInstanceRecord.StartedEvent, WorkflowInstanceRecord.CompletedEvent },
                        },
                        new ActivityQuery()
                        {
                            // Subscribe for track records from all activities for all states
                            ActivityName = all,
                            States = { all },

                            // Extract workflow variables and arguments as a part of the activity tracking record
                            // VariableName = "*" allows for extraction of all variables in the scope
                            // of the activity
                            VariableQueries = 
                            {
                                new VariableQuery()
                                {
                                    VariableName = all
                                }   
                            }
                        }   
                    }
                }
            };


            WorkflowInstance wfInstance = new WorkflowInstance(BuildSampleWorkflow());

            wfInstance.Extensions.Add(customTrackingParticipant);

            wfInstance.OnCompleted = delegate(WorkflowCompletedEventArgs e) { syncEvent.Set(); };
            wfInstance.Run();

            syncEvent.WaitOne();

        }
    }
}

//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Diagnostics;


namespace FileWatcherActivities
{
    public class FileSystemEventService : Microsoft.Samples.Workflow.CustomActivityFramework.EventService<FileSystemEventSubscription>
    {

        public Guid RegisterListener(Guid workflowInstanceId, IComparable queueName, 
            string path, string filter, NotifyFilters notifyFilter, bool includeSubdirectories)
		{
            // Initialize a new FileSystemWatcher for listening to the file system
			FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
			fileSystemWatcher.Filter = filter;
            fileSystemWatcher.NotifyFilter = notifyFilter;
            fileSystemWatcher.IncludeSubdirectories = includeSubdirectories;
            

            // Attach to the events exposed by the FileSystemWatcher
			fileSystemWatcher.Changed += new FileSystemEventHandler(FileSystemWatcher_Handler);
			fileSystemWatcher.Created += new FileSystemEventHandler(FileSystemWatcher_Handler);
			fileSystemWatcher.Deleted += new FileSystemEventHandler(FileSystemWatcher_Handler);
			fileSystemWatcher.Error += new ErrorEventHandler(FileSystemWatcher_Error);
            
            // Create a new subscription so we can Enque data back to the activity
            FileSystemEventSubscription subscription =
				new FileSystemEventSubscription(queueName, workflowInstanceId, fileSystemWatcher);

            this.Subscriptions.Add(subscription.SubscriptionId, subscription);

            // Turn the file system watcher on
            fileSystemWatcher.EnableRaisingEvents = true;

            // Write out the subscription information to the Trace
            Trace.TraceInformation("FileWatcherEventService subscription created.  InstanceId={0}, QueueName={1}'",
                workflowInstanceId.ToString(), queueName);

            return subscription.SubscriptionId;
		}



        public override void UnregisterListener(Guid subscriptionId)
        {

            if (this.Subscriptions.ContainsKey(subscriptionId))
            {
                FileSystemEventSubscription subscription = this.Subscriptions[subscriptionId];

                // Turn the file system watcher off
                subscription.FileSystemWatcher.EnableRaisingEvents = false;
                subscription.FileSystemWatcher.Dispose();

                this.Subscriptions.Remove(subscriptionId);


                // Write out the subscription information to the Trace
                Trace.TraceInformation("FileWatcherEventService subscription deleted.  InstanceId={0}, QueueName={1}'",
                    subscription.WorkflowInstanceId.ToString(), subscription.QueueName);
            }
		}


		void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
		{
			
		}

		void FileSystemWatcher_Handler(object sender, System.IO.FileSystemEventArgs e)
		{
			// Sender is the FileSystemWatcher that raised this event
			FileSystemWatcher fileSystemWatcher = (FileSystemWatcher) sender;

			foreach (FileSystemEventSubscription subscription in this.Subscriptions.Values)
			{
				if (subscription.FileSystemWatcher.Equals(fileSystemWatcher))
				{
                    // We can't just use the FileSystemEventArgs because it's not serializable
                    FileSystemEventArgs eventArgs = new FileSystemEventArgs(e);

                    base.DeliverToWorkflow(subscription.WorkflowInstanceId, subscription.QueueName, eventArgs);
                    return;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Runtime.Tracking;
using TrackingDataSetTableAdapters;
using System.Workflow.ComponentModel;

namespace Workflows.Tracking
{
    class UserActivityTrackingChannel : TrackingChannel
    {
        private string workflowGuid;

        /// <summary>
        /// Captures the workflow instance id and records a tracking entry for the workflow starting.
        /// </summary>
        public UserActivityTrackingChannel(TrackingParameters parameters)
        {
            this.workflowGuid = parameters.InstanceId.ToString();

            using (WorkflowTrackingTableAdapter workflowTableAdapter = new WorkflowTrackingTableAdapter())
                workflowTableAdapter.Insert(workflowGuid, DateTime.Now, null);
        }

        /// <summary>
        /// Records the completion of the workflow.
        /// </summary>
        protected override void InstanceCompletedOrTerminated()
        {
            using (WorkflowTrackingTableAdapter workflowTableAdapter = new WorkflowTrackingTableAdapter())
                workflowTableAdapter.Finish(DateTime.Now, workflowGuid);
        }

        protected override void Send(TrackingRecord record)
        {
            SendUserTrackingRecord(record as UserTrackingRecord);
        }

        private void SendUserTrackingRecord(UserTrackingRecord userTrackingRecord)
        {
            if (userTrackingRecord == null)
                return;

            AddTrackingRecord(userTrackingRecord.UserData as UserActivity);
        }

        /// <summary>
        /// Checks for other tracking records for the <see cref="UserActivity"/> with the same status and, if none are found,
        /// writes a new tracking record.
        /// </summary>
        /// <param name="userActivity">The user activity being tracked.</param>
        private void AddTrackingRecord(UserActivity userActivity)
        {
            if (userActivity == null)
                return;

            string activityGuid = userActivity.ActivityGuid.ToString();
            string status = userActivity.CurrentStatus.ToString();

            using (UserActivityWorkItemTrackingTableAdapter trackingAdapter = new UserActivityWorkItemTrackingTableAdapter())

                if ((int)trackingAdapter.CountActivityRecordWithStatus(activityGuid, status) == 0)
                    AddTrackingRecord(
                        activityGuid,
                        userActivity.Name,
                        userActivity.Description,
                        userActivity.ActivityType.ToString(),
                        userActivity.RequiredRole.ToString(),
                        status,
                        GetWorkItem(userActivity.DataSet as WorkItemsDataSet),
                        trackingAdapter);
        }

        private WorkItemsDataSet.WorkItemsRow GetWorkItem(WorkItemsDataSet workItemsDataSet)
        {
            if (workItemsDataSet == null || workItemsDataSet.WorkItems.Rows.Count < 1)
                return null;

            else
                return workItemsDataSet.WorkItems[0];
        }

        /// <summary>
        /// Creates a tracking record based on whether data has been supplied to the activity by the user yet.
        /// </summary>
        private void AddTrackingRecord(string activityGuid, string activityName, string activityDescription, string activityType, string requiredRole,
            string status, WorkItemsDataSet.WorkItemsRow workItem, UserActivityWorkItemTrackingTableAdapter trackingAdapter)
        {
            if (workItem == null)
                trackingAdapter.AddTrackingRecord(activityGuid, activityName, workflowGuid, activityDescription, activityType, requiredRole, status,
                    null, null, null, null, null, null, null, null, null);

            else
                trackingAdapter.AddTrackingRecord(activityGuid, activityName, workflowGuid, activityDescription, activityType, requiredRole, status,
                    workItem.WorkItemName, workItem.WorkItemType, workItem.Description, workItem.Reason, workItem.DateRequested,
                    workItem.FundingCostCenter, workItem.AreaAffected, workItem.IsApprovedNull() ? null : (bool?)workItem.Approved, workItem.Result);
        }
    }
}

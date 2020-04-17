using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TrackingDataSetTableAdapters;

public class TrackingHelper
{
    /// <summary>
    /// Gets a DataView containing all of the current executing workflows applying the given sort and filter.
    /// </summary>
    /// <param name="sort">The sort.</param>
    /// <param name="filter">The filter.</param>
    /// <returns>a DataView containg all of the Currently Executing workflows</returns>
    public static DataView GetCurrentWorkflows(string sort, string filter)
    {
        return new DataView(GetCurrentWorkflows(),
                filter,
                sort,
                DataViewRowState.CurrentRows);
    }

    /// <summary>
    /// Gets the current workflows.
    /// </summary>
    /// <returns></returns>
    public static TrackingDataSet.WorkflowInformationDataTable GetCurrentWorkflows()
    {
        using (WorkflowInformationTableAdapter adapter = new WorkflowInformationTableAdapter())
            return adapter.GetRunning();
    }

    /// <summary>
    /// Gets a DataView containing all of the completed workflows applying the given sort and filter.
    /// </summary>
    /// <param name="sort">The sort.</param>
    /// <param name="filter">The filter.</param>
    /// <returns>a DataView containg all of the completed workflows</returns>
    public static DataView GetCompletedWorkflows(string sort, string filter)
    {
        return new DataView(GetCompletedWorkflows(),
                filter,
                sort,
                DataViewRowState.CurrentRows);
    }

    /// <summary>
    /// Gets the completed workflows.
    /// </summary>
    /// <returns></returns>
    public static TrackingDataSet.WorkflowInformationDataTable GetCompletedWorkflows()
    {
        using (WorkflowInformationTableAdapter adapter = new WorkflowInformationTableAdapter())
            return adapter.GetFinished();
    }

    /// <summary>
    /// Gets a DataView containing the Tracking Detail for the given workflow guid, applying the given sort and filter.
    /// </summary>
    /// <param name="workflowGuid">The workflow GUID.</param>
    /// <param name="sort">The sort.</param>
    /// <param name="filter">The filter.</param>
    /// <returns>a DataView containg the tracking detail for the given workflow guid</returns>
    public static DataView GetCurrentWorkflowTrackingDetail(Guid workflowGuid, string sort, string filter)
    {
        return new DataView(GetCurrentWorkflowTrackingDetail(workflowGuid),
                filter,
                sort,
                DataViewRowState.CurrentRows);
    }

    /// <summary>
    /// Gets the current workflow tracking detail.
    /// </summary>
    /// <param name="workflowGuid">The workflow GUID.</param>
    /// <returns></returns>
    public static TrackingDataSet.UserActivityTrackingRecordDataTable GetCurrentWorkflowTrackingDetail(Guid workflowGuid)
    {
        using (UserActivityTrackingRecordTableAdapter adapter = new UserActivityTrackingRecordTableAdapter())
            return adapter.GetTrackingRecordsForWorkflow(workflowGuid.ToString());
    }

    /// <summary>
    /// Returns the youngest (latest) workflow event for a given workflow, used to determine what portion of the workflow image to highlight
    /// </summary>
    /// <param name="workflowGuid">The GUID of the workflow in question</param>
    /// <returns>A Strongly Typed datarow representing the youngest tracking event</returns>
    public static TrackingDataSet.UserActivityWorkItemTrackingRow GetYoungestTrackingRecordForWorkflow(Guid workflowGuid)
    {
        using (UserActivityWorkItemTrackingTableAdapter adapter = new UserActivityWorkItemTrackingTableAdapter())
            return adapter.GetLatestFor(workflowGuid.ToString())[0];
    }
}

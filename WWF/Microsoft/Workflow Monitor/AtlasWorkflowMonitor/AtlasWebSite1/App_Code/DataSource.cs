using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime;
using System.Collections.Generic;

/// <summary>
/// Summary description for DataSource
/// </summary>
public class DataSource 
{
    public DataSource()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    DateTime statusFromDateTime = new DateTime(2000, 1, 1);
    DateTime statusUntilDateTime = DateTime.Now.AddDays(1);
    static string connectionString
    {
        get { return WebConfigurationManager.ConnectionStrings["WFTracking"].ConnectionString; }
    }
    public static void SetInstance(Guid id)
    {
        SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
        SqlTrackingWorkflowInstance wi = null;
        bool success =  sqlTrackingQuery.TryGetWorkflow(id, out wi);
        if (success)
        {
            HttpContext.Current.Session["CurrentWF"] = wi;
            HttpContext.Current.Session["CurrentAct"] = null;
        }
    }
    public static void SetInstance(Guid id, string act)
    {
        SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
        SqlTrackingWorkflowInstance wi = null;
        bool success = sqlTrackingQuery.TryGetWorkflow(id, out wi);
        if (success)
        {
            HttpContext.Current.Session["CurrentWF"] = wi;
            HttpContext.Current.Session["CurrentAct"] = act;

        }
    }
    public IList<ActivityTrackingRecord> GetWorkflowActivities(Guid id)
    {
        List<SqlTrackingWorkflowInstance> queriedWorkflows = new List<SqlTrackingWorkflowInstance>();
        SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
        SqlTrackingWorkflowInstance twi = null;
        sqlTrackingQuery.TryGetWorkflow(id, out twi);
        if (twi != null)
            return twi.ActivityEvents;
        else
            return new List<ActivityTrackingRecord>();
        
       
    }
    public List<SqlTrackingWorkflowInstance> GetWorkflows()
    {
        List<SqlTrackingWorkflowInstance> queriedWorkflows = new List<SqlTrackingWorkflowInstance>();
        SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery(connectionString);
        SqlTrackingQueryOptions sqlTrackingQueryOptions = new SqlTrackingQueryOptions();
        sqlTrackingQueryOptions.StatusMinDateTime = statusFromDateTime.ToUniversalTime();
        sqlTrackingQueryOptions.StatusMaxDateTime = statusUntilDateTime.ToUniversalTime();
        sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Created;
        queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

        sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Completed;
        queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

        sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Running;
        queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

        sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Suspended;
        queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));

        sqlTrackingQueryOptions.WorkflowStatus = WorkflowStatus.Terminated;
        queriedWorkflows.AddRange(sqlTrackingQuery.GetWorkflows(sqlTrackingQueryOptions));
     
        return queriedWorkflows;

    }

}

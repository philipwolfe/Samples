using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflows;
using System.Workflow.Activities;
using System.Collections.Generic;
using System.Workflow.ComponentModel;
using UserActivitiesDataSetTableAdapters;

/// <summary>
/// Provides information about workflows that contain instances of <see cref="UserActivity"/>.
/// </summary>
public class WorkflowUserActivityInvestigator
{
    #region Singleton

    private static WorkflowUserActivityInvestigator singleton;

    public static WorkflowUserActivityInvestigator Singleton
    {
        get 
        {
            if (singleton == null)
                singleton = new WorkflowUserActivityInvestigator();

            return singleton; 
        }
    }

    #endregion

    private Dictionary<Type, UserActivityPrototype> prototypes;

    private WorkflowUserActivityInvestigator()
    {
        Type[] workflowTypes = new Type[] { typeof(ApprovedWorkItemWorkflow) };

        prototypes = new Dictionary<Type,UserActivityPrototype>();

        foreach (Type workflowType in workflowTypes)
                prototypes[workflowType] = GetPrototypeForFirstUserActivity(workflowType);
    }

    private UserActivityPrototype GetPrototypeForFirstUserActivity(Type sequentialWorkflowType)
    {
        if (!(sequentialWorkflowType == typeof(SequentialWorkflowActivity) || sequentialWorkflowType.IsSubclassOf(typeof(SequentialWorkflowActivity))))
            throw new ApplicationException(string.Format("Types must derive from SequentialWorkflowActivity; {0} does not.", sequentialWorkflowType.ToString()));


        UserActivity userActivityMatch;
        CompositeActivity currentCompositeActivity = (SequentialWorkflowActivity)Activator.CreateInstance(sequentialWorkflowType);

        TypeMatcher<Activity> userActivityMatcher = new TypeMatcher<Activity>(true, typeof(UserActivity), typeof(CompositeActivity));
        Predicate<Activity> typeMatch = new Predicate<Activity>(userActivityMatcher.Match);

        do
        {
            Activity firstActivityFound = currentCompositeActivity.Activities.Find(typeMatch);
            userActivityMatch = firstActivityFound as UserActivity;
            currentCompositeActivity = firstActivityFound as CompositeActivity;
        }
        while (currentCompositeActivity != null && userActivityMatch == null);

        if (userActivityMatch == null)
            return null;

        else
            return new UserActivityPrototype(userActivityMatch);
    }

    public bool CanCurrentUserWorkOnFirstUserActivityForWorkflow(Type workflowType)
    {
        if (workflowType == null)
            throw new ArgumentNullException("workflowType");

        else if (!prototypes.ContainsKey(workflowType))
            throw new ApplicationException(string.Format("Workflow type {0} has not been processed by this investigator.", workflowType));

        else
        {
            UserActivityPrototype prototype = prototypes[workflowType];
            if (prototype == null)
                throw new ApplicationException(string.Format("The workflow ({0}) does not have any user activities.", workflowType.ToString()));

            else
                return prototype.CanCurrentUserWorkOnActivity();
        }
    }
}

/// <summary>
/// Represents the occurrence of a <see cref="UserActivity"/> within a workflow design.
/// </summary>
public class UserActivityPrototype
{
    private UserActivityType activityType;
    private UserRole requiredRole;

    public UserActivityPrototype(UserActivity userActivity)
    {
        this.activityType = userActivity.ActivityType;
        this.requiredRole = userActivity.RequiredRole;
    }

    public UserActivityType ActivityType
    {
        get { return activityType; }
    }

    public UserRole RequiredRole
    {
        get { return requiredRole; }
    }

    public bool CanCurrentUserWorkOnActivity()
    {
        return Roles.IsUserInRole(requiredRole.ToString());
    }
}

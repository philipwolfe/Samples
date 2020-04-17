<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        System.Workflow.Runtime.WorkflowRuntime workflowRuntime = new System.Workflow.Runtime.WorkflowRuntime("WorkflowRuntime");
        Application["WorkflowRuntime"] = workflowRuntime;

        System.Workflow.ComponentModel.Compiler.TypeProvider typeProvider = new System.Workflow.ComponentModel.Compiler.TypeProvider(workflowRuntime);
        typeProvider.AddAssembly(typeof(WorkflowLibrary1.BaseOrderWorkflow).Assembly);
        workflowRuntime.AddService(typeProvider);

        //  Should only be run when changes are made to the tracking profile.
        CreateAndInsertTrackingProfile();
        
        workflowRuntime.StartRuntime();
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        System.Workflow.Runtime.WorkflowRuntime workflowRuntime = Application["WorkflowRuntime"] as System.Workflow.Runtime.WorkflowRuntime;
        workflowRuntime.StopRuntime();
    }

    void CreateAndInsertTrackingProfile()
    {
        System.Workflow.Runtime.Tracking.TrackingProfile trackingProfile = new System.Workflow.Runtime.Tracking.TrackingProfile();
        System.Workflow.Runtime.Tracking.ActivityTrackPoint activityTrackPoint = new System.Workflow.Runtime.Tracking.ActivityTrackPoint();
        System.Workflow.Runtime.Tracking.ActivityTrackingLocation activityTrackingLocation = new System.Workflow.Runtime.Tracking.ActivityTrackingLocation(typeof(System.Workflow.ComponentModel.Activity));
        activityTrackingLocation.MatchDerivedTypes = true;

        foreach (System.Workflow.ComponentModel.ActivityExecutionStatus activityExecutionStatus in Enum.GetValues(typeof(System.Workflow.ComponentModel.ActivityExecutionStatus)))
        {
            activityTrackingLocation.ExecutionStatusEvents.Add(activityExecutionStatus);
        }

        activityTrackPoint.MatchingLocations.Add(activityTrackingLocation);

        System.Workflow.Runtime.Tracking.WorkflowDataTrackingExtract workflowDataTrackingExtract = new System.Workflow.Runtime.Tracking.WorkflowDataTrackingExtract();
        workflowDataTrackingExtract.Member = "OrderEvtArgs";

        activityTrackPoint.Extracts.Add(workflowDataTrackingExtract);
        
        trackingProfile.ActivityTrackPoints.Add(activityTrackPoint);
        trackingProfile.Version = new Version("3.0.0.0");

        System.Workflow.Runtime.Tracking.WorkflowTrackPoint workflowTrackPoint = new System.Workflow.Runtime.Tracking.WorkflowTrackPoint();
        System.Workflow.Runtime.Tracking.WorkflowTrackingLocation workflowTrackingLocation = new System.Workflow.Runtime.Tracking.WorkflowTrackingLocation();

        foreach (System.Workflow.Runtime.Tracking.TrackingWorkflowEvent trackingWorkflowEvent in Enum.GetValues(typeof(System.Workflow.Runtime.Tracking.TrackingWorkflowEvent)))
        {
            workflowTrackingLocation.Events.Add(trackingWorkflowEvent);
        }

        workflowTrackPoint.MatchingLocation = workflowTrackingLocation;
        trackingProfile.WorkflowTrackPoints.Add(workflowTrackPoint);

        InsertTrackingProfile(trackingProfile);     
    }

    void InsertTrackingProfile(System.Workflow.Runtime.Tracking.TrackingProfile trackingProfile)
    {
        string profile = SerializeTrackingProfile(trackingProfile);
        
        using (System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand())
        {
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.UpdateTrackingProfile";
            sqlCommand.Connection = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["TrackingStoreConnectionString"].ConnectionString);
            System.Data.SqlClient.SqlParameter typeFullName = new System.Data.SqlClient.SqlParameter();
            typeFullName.ParameterName = "@TypeFullName";
            typeFullName.SqlDbType = System.Data.SqlDbType.NVarChar;
            typeFullName.SqlValue = typeof(WorkflowLibrary1.BaseOrderWorkflow).ToString();
            sqlCommand.Parameters.Add(typeFullName);

            System.Data.SqlClient.SqlParameter assemblyFullName = new System.Data.SqlClient.SqlParameter();
            assemblyFullName.ParameterName = "@AssemblyFullName";
            assemblyFullName.SqlDbType = System.Data.SqlDbType.NVarChar;
            assemblyFullName.SqlValue = typeof(WorkflowLibrary1.BaseOrderWorkflow).Assembly.FullName;
            sqlCommand.Parameters.Add(assemblyFullName);

            System.Data.SqlClient.SqlParameter versionId = new System.Data.SqlClient.SqlParameter();
            versionId.ParameterName = "@Version";
            versionId.SqlDbType = System.Data.SqlDbType.VarChar;
            versionId.SqlValue = trackingProfile.Version.ToString();
            sqlCommand.Parameters.Add(versionId);

            System.Data.SqlClient.SqlParameter trackingProfileXml = new System.Data.SqlClient.SqlParameter();
            trackingProfileXml.ParameterName = "@TrackingProfileXml";
            trackingProfileXml.SqlDbType = System.Data.SqlDbType.NVarChar;
            trackingProfileXml.SqlValue = profile;
            sqlCommand.Parameters.Add(trackingProfileXml);

            sqlCommand.Connection.Open();
            
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
            }
        }
    }

    string SerializeTrackingProfile(System.Workflow.Runtime.Tracking.TrackingProfile trackingProfile)
    {
        System.Workflow.Runtime.Tracking.TrackingProfileSerializer trackingProfileSerializer = new System.Workflow.Runtime.Tracking.TrackingProfileSerializer();
        System.IO.StringWriter stringWriter = new System.IO.StringWriter(new StringBuilder(), System.Globalization.CultureInfo.InvariantCulture);
        trackingProfileSerializer.Serialize(stringWriter, trackingProfile);
        return stringWriter.ToString();
    }
       
</script>

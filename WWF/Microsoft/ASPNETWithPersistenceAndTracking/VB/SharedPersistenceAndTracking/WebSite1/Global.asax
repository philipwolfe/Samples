<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim workflowRuntime As System.Workflow.Runtime.WorkflowRuntime = New System.Workflow.Runtime.WorkflowRuntime("WorkflowRuntime")
        Application("WorkflowRuntime") = workflowRuntime

        Dim typeProvider As System.Workflow.ComponentModel.Compiler.TypeProvider = New System.Workflow.ComponentModel.Compiler.TypeProvider(workflowRuntime)
        typeProvider.AddAssembly(GetType(WorkflowLibrary1.BaseOrderWorkflow).Assembly)
        workflowRuntime.AddService(typeProvider)
        
        '  Should only be run when changes are made to the tracking profile.
        CreateAndInsertTrackingProfile()

        workflowRuntime.StartRuntime()
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        Dim workflowRuntime As System.Workflow.Runtime.WorkflowRuntime = Application("WorkflowRuntime")
        workflowRuntime.StopRuntime()
    End Sub

    Sub CreateAndInsertTrackingProfile()
        Dim trackingProfile As Workflow.Runtime.Tracking.TrackingProfile = New Workflow.Runtime.Tracking.TrackingProfile()

        Dim activityTrackPoint As Workflow.Runtime.Tracking.ActivityTrackPoint = New Workflow.Runtime.Tracking.ActivityTrackPoint()
        Dim activityTrackingLocation As Workflow.Runtime.Tracking.ActivityTrackingLocation = New Workflow.Runtime.Tracking.ActivityTrackingLocation(GetType(Workflow.ComponentModel.Activity))
        activityTrackingLocation.MatchDerivedTypes = True
        
        Dim activityExecutionStatuses As Collections.Generic.IEnumerable(Of Workflow.ComponentModel.ActivityExecutionStatus) = CType(System.Enum.GetValues(GetType(Workflow.ComponentModel.ActivityExecutionStatus)), Collections.Generic.IEnumerable(Of Workflow.ComponentModel.ActivityExecutionStatus))
        For Each activityExecutionStatus As Workflow.ComponentModel.ActivityExecutionStatus In activityExecutionStatuses
            activityTrackingLocation.ExecutionStatusEvents.Add(activityExecutionStatus)
        Next

        activityTrackPoint.MatchingLocations.Add(activityTrackingLocation)
        
        Dim workflowDataTrackingExtract As System.Workflow.Runtime.Tracking.WorkflowDataTrackingExtract = New System.Workflow.Runtime.Tracking.WorkflowDataTrackingExtract()
        workflowDataTrackingExtract.Member = "OrderEvtArgs"

        activityTrackPoint.Extracts.Add(workflowDataTrackingExtract)
        
        trackingProfile.ActivityTrackPoints.Add(activityTrackPoint)
        trackingProfile.Version = New Version("3.0.0.0")

        Dim workflowTrackPoint As Workflow.Runtime.Tracking.WorkflowTrackPoint = New Workflow.Runtime.Tracking.WorkflowTrackPoint()
        Dim workflowTrackingLocation As Workflow.Runtime.Tracking.WorkflowTrackingLocation = New Workflow.Runtime.Tracking.WorkflowTrackingLocation()
        
        Dim trackingWorkflowEvents As Collections.Generic.IEnumerable(Of Workflow.Runtime.Tracking.TrackingWorkflowEvent) = CType(System.Enum.GetValues(GetType(Workflow.Runtime.Tracking.TrackingWorkflowEvent)), Collections.Generic.IEnumerable(Of Workflow.Runtime.Tracking.TrackingWorkflowEvent))
        For Each trackingWorkflowEvent As Workflow.Runtime.Tracking.TrackingWorkflowEvent In trackingWorkflowEvents
            workflowTrackingLocation.Events.Add(trackingWorkflowEvent)
        Next

        workflowTrackPoint.MatchingLocation = workflowTrackingLocation
        trackingProfile.WorkflowTrackPoints.Add(workflowTrackPoint)
        
        InsertTrackingProfile(trackingProfile)
    End Sub

    Sub InsertTrackingProfile(ByVal trackingProfile As Workflow.Runtime.Tracking.TrackingProfile)
        Dim profile As String = SerializeTrackingProfile(trackingProfile)
        
        Using sqlCommand As New Data.SqlClient.SqlCommand()
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure
            sqlCommand.CommandText = "dbo.UpdateTrackingProfile"
            sqlCommand.Connection = New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings.Item("SharedStoreConnectionString").ConnectionString)

            Dim typeFullName As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter()
            typeFullName.ParameterName = "@TypeFullName"
            typeFullName.SqlDbType = System.Data.SqlDbType.NVarChar
            typeFullName.SqlValue = GetType(WorkflowLibrary1.BaseOrderWorkflow).ToString()
            sqlCommand.Parameters.Add(typeFullName)

            Dim assemblyFullName As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter()
            assemblyFullName.ParameterName = "@AssemblyFullName"
            assemblyFullName.SqlDbType = System.Data.SqlDbType.NVarChar
            assemblyFullName.SqlValue = GetType(WorkflowLibrary1.BaseOrderWorkflow).Assembly.FullName
            sqlCommand.Parameters.Add(assemblyFullName)

            Dim versionId As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter()
            versionId.ParameterName = "@Version"
            versionId.SqlDbType = System.Data.SqlDbType.VarChar
            versionId.SqlValue = trackingProfile.Version.ToString()
            sqlCommand.Parameters.Add(versionId)

            Dim trackingProfileXml As Data.SqlClient.SqlParameter = New Data.SqlClient.SqlParameter()
            trackingProfileXml.ParameterName = "@TrackingProfileXml"
            trackingProfileXml.SqlDbType = System.Data.SqlDbType.NVarChar
            trackingProfileXml.SqlValue = profile
            sqlCommand.Parameters.Add(trackingProfileXml)

            sqlCommand.Connection.Open()
            Try
                sqlCommand.ExecuteNonQuery()
            Catch e As Data.SqlClient.SqlException
            End Try
        End Using
    End Sub

    Function SerializeTrackingProfile(ByVal trackingProfile As Workflow.Runtime.Tracking.TrackingProfile) As String
        Dim trackingProfileSerializer As Workflow.Runtime.Tracking.TrackingProfileSerializer = New Workflow.Runtime.Tracking.TrackingProfileSerializer()
        Dim stringWriter As IO.StringWriter = New IO.StringWriter(New StringBuilder(), Globalization.CultureInfo.InvariantCulture)
        trackingProfileSerializer.Serialize(stringWriter, trackingProfile)
        Return stringWriter.ToString()
    End Function
       
</script>
'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Tracking
Imports System.Workflow.Runtime.Hosting
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Globalization
Imports System.Workflow.ComponentModel
Imports System.Workflow.Activities

Namespace Microsoft.Samples.Workflow.Tutorials.Hosting
    Class Program
        Private Shared waitHandle As AutoResetEvent = New AutoResetEvent(False)
        Private Shared parameters As Dictionary(Of String, Object) = _
                  New Dictionary(Of String, Object)()

        Public Shared connectionString As String = _
                  "Initial Catalog=WorkflowTrackingStore;Data Source=localhost;" & _
                  "Integrated Security=SSPI;"

        Shared Sub Main(ByVal args As String())
            CreateTrackingProfile()

            Dim workflowRuntime As WorkflowRuntime = _
                New WorkflowRuntime("HostingWorkflowRuntime")

            ' workflow runtime events
            AddHandler workflowRuntime.Started, AddressOf workflowRuntime_Started
            AddHandler workflowRuntime.Stopped, AddressOf workflowRuntime_Stopped

            ' workflow events
            AddHandler workflowRuntime.WorkflowSuspended, _
                AddressOf workflowRuntime_WorkflowSuspended
            AddHandler workflowRuntime.WorkflowResumed, _
                AddressOf workflowRuntime_WorkflowResumed
            AddHandler workflowRuntime.WorkflowTerminated, _
                AddressOf workflowRuntime_WorkflowTerminated
            AddHandler workflowRuntime.WorkflowCompleted, _
                AddressOf workflowRuntime_WorkflowCompleted

            AddHandler workflowRuntime.WorkflowLoaded, _
                AddressOf workflowRuntime_WorkflowLoaded
            AddHandler workflowRuntime.WorkflowIdled, _
                AddressOf workflowRuntime_WorkflowIdled
            AddHandler workflowRuntime.WorkflowPersisted, _
                AddressOf workflowRuntime_WorkflowPersisted
            AddHandler workflowRuntime.WorkflowUnloaded, _
                AddressOf workflowRuntime_WorkflowUnloaded

            workflowRuntime.StartRuntime()

            ' retrieve workflow parameters
            Do
                Try
                    Console.Write("Enter a value for operand1: ")
                    parameters("Operand1") = Int32.Parse(Console.ReadLine())
                Catch ex As Exception
                    Console.WriteLine(ex.Message + Environment.NewLine)
                End Try
            Loop While parameters.ContainsKey("Operand1") = False

            Do
                Try
                    Console.Write("Enter a value for operand2: ")
                    parameters("Operand2") = Int32.Parse(Console.ReadLine())
                Catch ex As Exception
                    Console.WriteLine(ex.Message + Environment.NewLine)
                End Try
            Loop While parameters.ContainsKey("Operand2") = False

            Dim type As Type = GetType(HostingWorkflows)
            Dim workflowInstance As WorkflowInstance = _
                         workflowRuntime.CreateWorkflow(type, parameters)

            workflowInstance.Start()

            waitHandle.WaitOne()

            workflowRuntime.StopRuntime()

            GetInstanceTrackingEvents(workflowInstance.InstanceId)
            GetActivityTrackingEvents(workflowInstance.InstanceId)
        End Sub

        Private Shared Sub workflowRuntime_Started _
                  (ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Console.WriteLine("Workflow runtime started")
        End Sub

        Private Shared Sub workflowRuntime_Stopped _
                  (ByVal sender As Object, ByVal e As WorkflowRuntimeEventArgs)
            Console.WriteLine("Workflow runtime stopped")
        End Sub

        Private Shared Sub workflowRuntime_WorkflowSuspended _
                  (ByVal sender As Object, ByVal e As WorkflowSuspendedEventArgs)
            Console.WriteLine("Workflow suspended: {0}", e.Error)
            e.WorkflowInstance.Resume()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowResumed _
                  (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow resumed")
        End Sub

        Private Shared Sub workflowRuntime_WorkflowTerminated _
                  (ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine("Workflow Terminated : {0}", e.Exception.Message)
            waitHandle.Set()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowCompleted _
                  (ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            Console.WriteLine("Result: {0}", e.OutputParameters("Result"))
            waitHandle.Set()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowLoaded _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} loaded", e.WorkflowInstance.InstanceId)
        End Sub

        Private Shared Sub workflowRuntime_WorkflowIdled _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} idled", e.WorkflowInstance.InstanceId)
            e.WorkflowInstance.Unload()
        End Sub

        Private Shared Sub workflowRuntime_WorkflowPersisted _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} persisted", e.WorkflowInstance.InstanceId)
        End Sub

        Private Shared Sub workflowRuntime_WorkflowUnloaded _
            (ByVal sender As Object, ByVal e As WorkflowEventArgs)
            Console.WriteLine("Workflow {0} unloaded", e.WorkflowInstance.InstanceId)
        End Sub

        Private Shared Sub GetInstanceTrackingEvents(ByVal instanceId As Guid)
            Dim sqlTrackingQuery As SqlTrackingQuery = _
                New SqlTrackingQuery(connectionString)

            Dim sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance = Nothing
            If sqlTrackingQuery.TryGetWorkflow(instanceId, sqlTrackingWorkflowInstance) = False Then
                Console.WriteLine("Could not retrieve SqlTrackingWorkflowInstance")
            Else
                Console.WriteLine(Constants.vbLf & "Instance Level Events:" & Constants.vbLf)

                For Each workflowTrackingRecord As WorkflowTrackingRecord In _
                    sqlTrackingWorkflowInstance.WorkflowEvents
                    Console.WriteLine("EventDescription : {0}  DateTime : {1}", _
                        workflowTrackingRecord.TrackingWorkflowEvent, _
                        workflowTrackingRecord.EventDateTime)
                Next workflowTrackingRecord
            End If
        End Sub

        Private Shared Sub GetActivityTrackingEvents(ByVal instanceId As Guid)

            Dim sqlTrackingQuery As SqlTrackingQuery = _
                New SqlTrackingQuery(connectionString)

            Dim sqlTrackingWorkflowInstance As SqlTrackingWorkflowInstance = Nothing
            If sqlTrackingQuery.TryGetWorkflow(instanceId, sqlTrackingWorkflowInstance) = False Then
                Console.WriteLine("Could not retrieve SqlTrackingWorkflowInstance")
            Else
                Console.WriteLine(Constants.vbLf & "Activity Tracking Events:" & _
                    Constants.vbLf)

                For Each activityTrackingRecord As ActivityTrackingRecord In _
                    sqlTrackingWorkflowInstance.ActivityEvents
                    Console.WriteLine( _
                        "StatusDescription: {0}  DateTime: {1} Activity Qualified ID: {2}", _
                        activityTrackingRecord.ExecutionStatus, _
                        activityTrackingRecord.EventDateTime, _
                        activityTrackingRecord.QualifiedName)
                Next activityTrackingRecord
            End If
        End Sub

        Private Shared Sub CreateTrackingProfile()
            Dim profile As TrackingProfile = New TrackingProfile()
            Dim trackPoint As ActivityTrackPoint = New ActivityTrackPoint()
            profile.Version = New Version("1.0.0.0")

            ' track CodeActivity activities only
            Dim location As ActivityTrackingLocation = _
                New ActivityTrackingLocation(GetType(CodeActivity))

            ' add all activity tracking events
            For Each s As ActivityExecutionStatus In System.Enum.GetValues _
                (GetType(ActivityExecutionStatus))
                location.ExecutionStatusEvents.Add(s)
            Next s

            trackPoint.MatchingLocations.Add(location)
            profile.ActivityTrackPoints.Add(trackPoint)

            Dim wtp As WorkflowTrackPoint = New WorkflowTrackPoint()
            Dim wtl As WorkflowTrackingLocation = New WorkflowTrackingLocation()

            ' add all workflow tracking events
            For Each s As TrackingWorkflowEvent In System.Enum.GetValues( _
                GetType(TrackingWorkflowEvent))
                wtl.Events.Add(s)
            Next s

            wtp.MatchingLocation = wtl
            profile.WorkflowTrackPoints.Add(wtp)

            ' serialize tracking profile and save to SQL
            Dim serializer As TrackingProfileSerializer = New TrackingProfileSerializer()
            Dim writer As StringWriter = New StringWriter(New StringBuilder(), _
                CultureInfo.InvariantCulture)
            serializer.Serialize(writer, profile)
            InsertTrackingProfile(writer.ToString())
        End Sub

        Private Shared Sub InsertTrackingProfile(ByVal profile As String)
            Dim cmd As SqlCommand = New SqlCommand()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "dbo.UpdateTrackingProfile"
            cmd.Connection = New SqlConnection(Program.connectionString)
            Try
                Dim typFullName As SqlParameter = New SqlParameter()
                typFullName.ParameterName = "@TypeFullName"
                typFullName.SqlDbType = SqlDbType.NVarChar
                typFullName.SqlValue = GetType(HostingWorkflows).ToString()
                cmd.Parameters.Add(typFullName)

                Dim assemblyFullName As SqlParameter = New SqlParameter()
                assemblyFullName.ParameterName = "@AssemblyFullName"
                assemblyFullName.SqlDbType = SqlDbType.NVarChar
                assemblyFullName.SqlValue = GetType(HostingWorkflows).Assembly.FullName
                cmd.Parameters.Add(assemblyFullName)

                Dim versionId As SqlParameter = New SqlParameter()
                versionId.ParameterName = "@Version"
                versionId.SqlDbType = SqlDbType.VarChar
                versionId.SqlValue = "1.0.0.0"
                cmd.Parameters.Add(versionId)

                Dim trackingProfile As SqlParameter = New SqlParameter()
                trackingProfile.ParameterName = "@TrackingProfileXml"
                trackingProfile.SqlDbType = SqlDbType.NVarChar
                trackingProfile.SqlValue = profile
                cmd.Parameters.Add(trackingProfile)

                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
            Catch e As SqlException
                Console.WriteLine(e.Message)
                Console.WriteLine( _
                "The Tracking Profile was not inserted. " & _
                    "If you want to add a new Tracking Profile, modify the version " & _
                    "string in the profile by specifying a higher version number.")
                Return
            Finally
                If (Not Nothing Is cmd) AndAlso (Not Nothing Is cmd.Connection) _
                    AndAlso (ConnectionState.Closed <> cmd.Connection.State) Then
                    cmd.Connection.Close()
                    cmd.Connection.Dispose()
                End If
            End Try
        End Sub
    End Class
End Namespace

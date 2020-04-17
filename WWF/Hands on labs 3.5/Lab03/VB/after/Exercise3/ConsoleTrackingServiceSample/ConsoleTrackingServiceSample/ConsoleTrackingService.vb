'--------------------------------------------------------------------------------
' This file is a "Sample" as from Windows Workflow Foundation
' Hands on Labs RC
'
' Copyright (c) Microsoft Corporation. All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information regarding Microsoft code samples.
' 
' THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'--------------------------------------------------------------------------------

Imports System
Imports System.IO
Imports System.Workflow.Runtime
Imports System.Workflow.Runtime.Tracking
Imports System.Workflow.ComponentModel
Imports System.Workflow.Runtime.Hosting


Public Class ConsoleTrackingService
    Inherits TrackingService

    Protected Overloads Overrides Function GetProfile(ByVal workflowInstanceId As System.Guid) As System.Workflow.Runtime.Tracking.TrackingProfile
        Throw New NotImplementedException("The method or operation is not implemented.")
    End Function

    Protected Overloads Overrides Function GetProfile(ByVal workflowType As System.Type, ByVal profileVersionId As System.Version) As System.Workflow.Runtime.Tracking.TrackingProfile
        Return GetProfile()
    End Function

    Protected Overrides Function GetTrackingChannel(ByVal parameters As System.Workflow.Runtime.Tracking.TrackingParameters) As System.Workflow.Runtime.Tracking.TrackingChannel
        Return New ConsoleTrackingChannel(parameters)
    End Function

    Protected Overrides Function TryGetProfile(ByVal workflowType As System.Type, ByRef profile As System.Workflow.Runtime.Tracking.TrackingProfile) As Boolean
        profile = GetProfile()
        Return True
    End Function

    Protected Overrides Function TryReloadProfile(ByVal workflowType As System.Type, ByVal workflowInstanceId As System.Guid, ByRef profile As System.Workflow.Runtime.Tracking.TrackingProfile) As Boolean
        profile = Nothing
        Return False
    End Function

    Private Overloads Shared Function GetProfile() As TrackingProfile
        ' Create a Tracking Profile
        Dim profile As TrackingProfile = New TrackingProfile
        profile.Version = New Version("3.0.0")

        ' Add a TrackPoint to cover all activity status events
        Dim activityTrackPoint As ActivityTrackPoint = New ActivityTrackPoint
        Dim activityLocation As ActivityTrackingLocation = New ActivityTrackingLocation(GetType(Activity))
        activityLocation.MatchDerivedTypes = True
        For Each status As ActivityExecutionStatus In System.Enum.GetValues(GetType(ActivityExecutionStatus))
            activityLocation.ExecutionStatusEvents.Add(status)
        Next
        activityTrackPoint.MatchingLocations.Add(activityLocation)
        profile.ActivityTrackPoints.Add(activityTrackPoint)

        ' Add a TrackPoint to cover all workflow status events
        Dim workflowTrackPoint As WorkflowTrackPoint = New WorkflowTrackPoint
        workflowTrackPoint.MatchingLocation = New WorkflowTrackingLocation
        For Each workflowEvent As TrackingWorkflowEvent In System.Enum.GetValues(GetType(TrackingWorkflowEvent))
            workflowTrackPoint.MatchingLocation.Events.Add(workflowEvent)
        Next
        profile.WorkflowTrackPoints.Add(workflowTrackPoint)

        ' Add a TrackPoint to cover all user track points
        Dim userTrackPoint As UserTrackPoint = New UserTrackPoint
        Dim userLocation As UserTrackingLocation = New UserTrackingLocation
        userLocation.ActivityType = GetType(Activity)
        userLocation.MatchDerivedActivityTypes = True
        userLocation.ArgumentType = GetType(System.Object)
        userLocation.MatchDerivedArgumentTypes = True
        userTrackPoint.MatchingLocations.Add(userLocation)
        profile.UserTrackPoints.Add(userTrackPoint)

        Return profile
    End Function


End Class

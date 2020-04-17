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

Imports System
Imports System.Collections
Imports System.Workflow.Activities

Public Enum TravelNeedType
    None = 0
    Car = 1
    Airline = 2
End Enum

Public Class SimpleConditionedActivityGroupWorkflow
    Inherits SequentialWorkflowActivity

    Private travelNeeds As ArrayList = New ArrayList()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        travelNeeds.Add(TravelNeedType.Airline)
        travelNeeds.Add(TravelNeedType.Car)
    End Sub

    Private Sub Car_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("Booking car reservation")
        travelNeeds.Remove(TravelNeedType.Car)
    End Sub

    Private Sub Airline_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine("Booking airline reservation")
        travelNeeds.Remove(TravelNeedType.Airline)
    End Sub

    Private Sub CarCondition(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ConditionalEventArgs)
        e.Result = travelNeeds.Contains(TravelNeedType.Car)
    End Sub

    Private Sub AirlineCondition(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ConditionalEventArgs)
        e.Result = travelNeeds.Contains(TravelNeedType.Airline)
    End Sub
End Class

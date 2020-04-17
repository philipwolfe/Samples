'--------------------------------------------------------------------------------
' This file is a "Sample" from Windows Workflow Foundation
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
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Workflow.Activities
Imports System.Workflow.Runtime
Imports System.Workflow.ComponentModel

Namespace LongRunningWorkflow
	'
	' This is the service class which is added to the workflow runtime and
	' run on the workflow host thread
	'
	Public Class FactoringService
		Private runtime As WorkflowRuntime

		Public Sub New(ByVal runtime As WorkflowRuntime)
			Me.runtime = runtime
		End Sub

		'
		' A class to hold the state required for the factoring service. This
		' is required since the QueueUserWorkfItem delegate only accepts
		' a single parameter
		' 
		Private Class FactoringState
			Public instanceId As Guid
			Public resultQueueName As IComparable

			Public Sub New(ByVal instanceId As Guid, ByVal resultQueueName As IComparable)
				Me.instanceId = instanceId
				Me.resultQueueName = resultQueueName
			End Sub
		End Class

		'
		' This is called in the activity thread to start the prime factoring
		'
		Public Sub FactorPrimes(ByVal resultQueueName As IComparable)
			ThreadPool.QueueUserWorkItem(AddressOf FactorPrimes, New FactoringState(WorkflowEnvironment.WorkflowInstanceId, resultQueueName))
		End Sub

		'
		' This runs in the new thread created by QueueUserWorkItem
		'
		Private Sub FactorPrimes(ByVal state As Object)
			Dim factState As FactoringState = TryCast(state, FactoringState)

			Console.WriteLine("Beginning Factoring Prime Numbers")

			Dim start As DateTime = DateTime.Now

			Dim topNumber As Integer = 100000000
			Dim numbers As BitArray = New BitArray(topNumber, True)

			For i As Integer = 2 To topNumber - 1
				If numbers(i) Then
					For j As Integer = i * 2 To topNumber - 1 Step i
						numbers(j) = False
					Next j
				End If
			Next i

			Dim primes As Integer = 0

			For i As Integer = 1 To topNumber - 1
				If numbers(i) Then
					primes += 1
				End If
			Next i

			Console.WriteLine("Finished Factoring Prime Numbers (" & Math.Round(DateTime.Now.Subtract(start).TotalSeconds, 0) & " seconds)")

			Dim wi As WorkflowInstance = runtime.GetWorkflow(factState.instanceId)

			'
			' Send the message back to the activity and pass the result
			'
			wi.EnqueueItem(factState.resultQueueName, primes, Nothing, Nothing)
		End Sub
	End Class

	'
	' This is the activity class as dragged onto the workflow
	'
	Public Class FactorPrimesActivity
		Inherits Activity
		Private result_Renamed As Integer

		Public ReadOnly Property Result() As Integer
			Get
				Return result_Renamed
			End Get
		End Property

		'
		' This is called when the activity is first executed on the workflow thread
		'
		Protected Overrides Function Execute(ByVal context As ActivityExecutionContext) As ActivityExecutionStatus
			Dim qName As String = Me.QualifiedName & "ResultQueue"
			Dim qServ As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()
			Dim q As WorkflowQueue = qServ.CreateWorkflowQueue(qName, False)
			AddHandler q.QueueItemAvailable, AddressOf OnItemAvailable

			Dim factServ As FactoringService = context.GetService(Of FactoringService)()
			factServ.FactorPrimes(qName)

			Return ActivityExecutionStatus.Executing
		End Function

		'
		' This is called on the workflow thread when the prime factoring is complete
		' and the queue message is received
		'
		Private Sub OnItemAvailable(ByVal sender As Object, ByVal e As QueueEventArgs)
			Dim context As ActivityExecutionContext = TryCast(sender, ActivityExecutionContext)

			Dim qServ As WorkflowQueuingService = context.GetService(Of WorkflowQueuingService)()
			Dim q As WorkflowQueue = qServ.GetWorkflowQueue(e.QueueName)

			result_Renamed = CInt(Fix(q.Dequeue()))
			qServ.DeleteWorkflowQueue(e.QueueName)

			context.CloseActivity()
		End Sub
	End Class
End Namespace


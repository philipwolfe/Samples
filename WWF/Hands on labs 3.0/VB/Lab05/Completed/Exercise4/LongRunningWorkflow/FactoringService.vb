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
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading
Imports System.Workflow.Activities
Imports System.Workflow.Runtime


<Serializable()> _
Public Class PrimeFactoringEventArgs
    Inherits ExternalDataEventArgs

    Public Sub New(ByVal instanceId As Guid, ByVal primeCount As Integer)
        MyBase.New(instanceId)
        Me._primeCount = primeCount
    End Sub


    Public ReadOnly Property PrimeCount() As Integer
        Get
            Return Me._primeCount
        End Get
    End Property

    Private _primeCount As Integer


End Class

<ExternalDataExchange()> _
Public Interface IPrimeFactoring

    Event FactoredPrimes As EventHandler(Of PrimeFactoringEventArgs)
    Sub FactorPrimes()

End Interface




<Serializable()> _
Public Class FactoringService
    Implements IPrimeFactoring



    ' Events
    Public Event FactoredPrimes As EventHandler(Of PrimeFactoringEventArgs) _
 Implements IPrimeFactoring.FactoredPrimes


    Public Sub FactorPrimes() Implements IPrimeFactoring.FactorPrimes

        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf _
 Me.FactorPrimes), WorkflowEnvironment.WorkflowInstanceId)
    End Sub


    Private Sub FactorPrimes(ByVal instanceId As Object)

        Console.WriteLine("Beginning Factoring Prime Numbers")
        Dim time1 As DateTime = DateTime.Now
        Dim num1 As Integer = 100000000
        Dim array1 As New BitArray(num1, True)
        Dim num2 As Integer = 2
        Do While (num2 < num1)
            If array1.Item(num2) Then
                Dim num3 As Integer = (num2 * 2)
                Do While (num3 < num1)
                    array1.Item(num3) = False
                    num3 = (num3 + num2)
                Loop
            End If
            num2 += 1
        Loop
        Dim num4 As Integer = 0
        num2 = 1
        Do While (num2 < num1)
            If array1.Item(num2) Then
                num4 += 1
            End If
            num2 += 1
        Loop
        Dim span1 As TimeSpan = DateTime.Now.Subtract(time1)
        Console.WriteLine(("Finished Factoring Prime Numbers (" & _
         Math.Round(span1.TotalSeconds, 0) & " seconds)"))
        If (Not Me.FactoredPrimesEvent Is Nothing) Then
            Me.FactoredPrimesEvent.Invoke(Me, _
         New PrimeFactoringEventArgs(DirectCast(instanceId, Guid), num4))
        End If

    End Sub
End Class
















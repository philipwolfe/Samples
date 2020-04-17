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

Public Class processPOWorkflow
    Inherits SequentialWorkflowActivity
    Public newPO As POSchema.PO = POSchema.PO.GeneratePOInstance()
    Public outgoingPOforFabrikam As New ContosoWorkflows.Fabrikam.PO
    Public POResponsefromFabrikam As  New ContosoWorkflows.Fabrikam.PO

    Public outgoingPOforNorthwind As New ContosoWorkflows.Northwind.PO
    Public POResponsefromNorthwind As New ContosoWorkflows.Northwind.PO

    Private Sub invokePOSubmissionWSFabrikam_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.InvokeWebServiceEventArgs)

    End Sub

    Private Sub invokePOSubmissionWSFabrikam_Invoking(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.InvokeWebServiceEventArgs)



        POHelpers.CopyPOHeader(newPO, outgoingPOforFabrikam)
        POHelpers.CopyPOHistory(newPO, outgoingPOforFabrikam)
        POHelpers.CopyPOItems(newPO, outgoingPOforFabrikam)



    End Sub


    
    Private Sub invokePOSubmissionWSNorthwind_Invoked(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.InvokeWebServiceEventArgs)

    End Sub
    Private Sub invokePOSubmissionWSNorthwind_Invoking(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.InvokeWebServiceEventArgs)




        POHelpers.CopyPOHeader(newPO, outgoingPOforNorthwind)
        POHelpers.CopyPOHistory(newPO, outgoingPOforNorthwind)
        POHelpers.CopyPOItems(newPO, outgoingPOforNorthwind)



    End Sub

    Private Sub afterWSFabrikamInvoke_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)



        'Initialize it to a time where electronic PO processing was not invented.
        Dim statusDate As New DateTime(1900, 1, 1)
        Dim lastStatus As Fabrikam.POStatus = Nothing

        'Find the last status by looping over the history items
        For Each stat As Fabrikam.POStatus In POResponsefromFabrikam.History

            If (stat.Timestamp > statusDate) Then

                statusDate = stat.Timestamp
                lastStatus = stat
            End If

        Next
        System.Console.WriteLine("Your PO has been {0} on {1} by Fabrikam", lastStatus.PoStatus, lastStatus.Timestamp)



    End Sub

    Private Sub afterWSNorthwindInvoke_ExecuteCode(ByVal sender As System.Object, ByVal e As System.EventArgs)



        'Initialize it to a time where electronic PO processing was not invented.
        Dim statusDate As New DateTime(1900, 1, 1)
        Dim lastStatus As Northwind.POStatus = Nothing

        'Find the last status by looping over the history items
        For Each stat As Northwind.POStatus In POResponsefromNorthwind.History

            If (stat.Timestamp > statusDate) Then

                statusDate = stat.Timestamp
                lastStatus = stat
            End If

        Next
        System.Console.WriteLine("Your PO has been {0} on {1} by Northwind", lastStatus.PoStatus, lastStatus.Timestamp)



    End Sub
End Class

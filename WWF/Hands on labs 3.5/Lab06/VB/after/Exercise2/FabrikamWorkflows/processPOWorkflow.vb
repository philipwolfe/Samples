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



    'Webservice interface definition for the workflow
    Public Interface IProcessReceivedPO

        Function ReceiveAndProcessPO(ByVal aPO As POSchema.PO) As POSchema.PO

    End Interface


    Public receivedPO As New POSchema.PO
    Public returnedPO As New POSchema.PO

    Private Sub webServiceResponsePO_SendingOutput(ByVal sender As System.Object, ByVal e As System.EventArgs)

        POSchema.PO.GenerateResponseHeader(receivedPO, returnedPO, "Fabrikam_")
        POSchema.PO.CopyHistoryAndChangeStatus(receivedPO, returnedPO, "Accepted")
        POSchema.PO.CopyPOItems(receivedPO, returnedPO)

    End Sub
End Class

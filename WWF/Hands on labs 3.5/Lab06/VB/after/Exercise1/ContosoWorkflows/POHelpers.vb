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

Imports POSchema

Public Class POHelpers


    

    Public Shared Sub CopyPOHeader(ByVal sourcePO As PO, ByVal destinationPO As Northwind.PO)

        destinationPO.PONumber = sourcePO.PONumber
        destinationPO.OrderTotal = sourcePO.OrderTotal

    End Sub


 
 
    Public Shared Sub CopyPOHistory(ByVal sourcePO As PO, ByVal destinationPO As Northwind.PO)

        If (Not sourcePO.History Is Nothing) Then
            destinationPO.History = New Northwind.POStatus(sourcePO.History.Length - 1) {}
            Dim num1 As Integer = 0
            Do While (num1 < sourcePO.History.Length)
                destinationPO.History(num1) = New Northwind.POStatus
                destinationPO.History(num1).Contact = sourcePO.History(num1).Contact
                destinationPO.History(num1).PoStatus = sourcePO.History(num1).PoStatus
                destinationPO.History(num1).Timestamp = sourcePO.History(num1).Timestamp
                num1 += 1
            Loop
        End If

    End Sub


 
    Public Shared Sub CopyPOItems(ByVal sourcePO As PO, ByVal destinationPO As Northwind.PO)
        If (Not sourcePO.Items Is Nothing) Then
            destinationPO.Items = New Northwind.POItem(sourcePO.Items.Length - 1) {}
            Dim num1 As Integer = 0
            Do While (num1 < sourcePO.Items.Length)
                destinationPO.Items(num1) = New Northwind.POItem
                destinationPO.Items(num1).Sku = sourcePO.Items(num1).Sku
                destinationPO.Items(num1).Price = sourcePO.Items(num1).Price
                destinationPO.Items(num1).Amount = sourcePO.Items(num1).Amount
                num1 += 1
            Loop
        End If
    End Sub


    Public Shared Sub CopyPOHeader(ByVal sourcePO As PO, ByVal destinationPO As Fabrikam.PO)

        destinationPO.PONumber = sourcePO.PONumber
        destinationPO.OrderTotal = sourcePO.OrderTotal

    End Sub




    Public Shared Sub CopyPOHistory(ByVal sourcePO As PO, ByVal destinationPO As Fabrikam.PO)

        If (Not sourcePO.History Is Nothing) Then
            destinationPO.History = New Fabrikam.POStatus(sourcePO.History.Length - 1) {}
            Dim num1 As Integer = 0
            Do While (num1 < sourcePO.History.Length)
                destinationPO.History(num1) = New Fabrikam.POStatus
                destinationPO.History(num1).Contact = sourcePO.History(num1).Contact
                destinationPO.History(num1).PoStatus = sourcePO.History(num1).PoStatus
                destinationPO.History(num1).Timestamp = sourcePO.History(num1).Timestamp
                num1 += 1
            Loop
        End If

    End Sub



    Public Shared Sub CopyPOItems(ByVal sourcePO As PO, ByVal destinationPO As Fabrikam.PO)
        If (Not sourcePO.Items Is Nothing) Then
            destinationPO.Items = New Fabrikam.POItem(sourcePO.Items.Length - 1) {}
            Dim num1 As Integer = 0
            Do While (num1 < sourcePO.Items.Length)
                destinationPO.Items(num1) = New Fabrikam.POItem
                destinationPO.Items(num1).Sku = sourcePO.Items(num1).Sku
                destinationPO.Items(num1).Price = sourcePO.Items(num1).Price
                destinationPO.Items(num1).Amount = sourcePO.Items(num1).Amount
                num1 += 1
            Loop
        End If
    End Sub


End Class




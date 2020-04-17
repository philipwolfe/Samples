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

Imports Microsoft.ApplicationBlocks.Data

Public Class Workflow1
    Inherits SequentialWorkflowActivity
    Dim sqlConnection As String = System.Configuration.ConfigurationManager.AppSettings("connectionString")
    Public exception As Exception = New System.Exception()
    Private Sub DebitCodeHandler(ByVal sender As Object, ByVal e As EventArgs)

        SqlHelper.ExecuteNonQuery(sqlConnection, _
                         System.Data.CommandType.Text, _
                         "use bank update ChequeAccount set Balance = Balance - 100")

        Console.WriteLine(SqlHelper.ExecuteScalar(sqlConnection, _
                          System.Data.CommandType.Text, _
                          "use bank select Balance from ChequeAccount"))
    End Sub

    Private Sub CreditCodeHandler(ByVal sender As Object, ByVal e As EventArgs)

        SqlHelper.ExecuteNonQuery(sqlConnection, _
                                  System.Data.CommandType.Text, _
                                  "use bank update SavingsAccount set Balance = Balance + 100")

        Console.WriteLine(SqlHelper.ExecuteScalar(sqlConnection, _
                          System.Data.CommandType.Text, _
                          "use bank select Balance from SavingsAccount"))
    End Sub



    Private Sub OnFinishWorkflow(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Workflow completed")
    End Sub


    Private Sub OnException(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("Handling Application Exception and Rollback")
    End Sub

    Private Sub OnCompensation(ByVal sender As Object, ByVal e As EventArgs)

        SqlHelper.ExecuteNonQuery(sqlConnection, _
                                  System.Data.CommandType.Text, _
                                  "use bank update SavingsAccount set Balance = Balance - 100")

        SqlHelper.ExecuteNonQuery(sqlConnection, _
                                      System.Data.CommandType.Text, _
                                      "use bank update ChequeAccount set Balance = Balance + 100")

        Console.WriteLine("Compensated the transaction")
    End Sub

End Class

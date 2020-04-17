' Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System
Imports System.ServiceModel
Imports System.Transactions
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Microsoft.ServiceModel.Samples

    ' Define a service contract.
    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator

        <OperationContract()> _
        <TransactionFlow(TransactionFlowOption.Mandatory)> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        <TransactionFlow(TransactionFlowOption.Mandatory)> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        <TransactionFlow(TransactionFlowOption.Mandatory)> _
        Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
        <OperationContract()> _
        <TransactionFlow(TransactionFlowOption.Mandatory)> _
        Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double

    End Interface

    <ServiceContract([Namespace]:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculatorLog

        Inherits ICalculator
        <OperationContract()> _
        Sub ClearLog()
        <OperationContract()> _
        Function ReadLog() As String()

    End Interface

    ' Service class which implements the service contract.
    <ServiceBehavior(TransactionIsolationLevel:=System.Transactions.IsolationLevel.ReadCommitted)> _
    Public Class CalculatorService
        Inherits System.ServiceModel.WSHttpBinding
        Implements ICalculatorLog

        Private Sub recordToLog(ByVal recordText As String)

            Using conn As New SqlConnection(ConfigurationManager.AppSettings("connectionString"))

                Dim cmd As New SqlCommand("INSERT into Log (Entry) Values (@Entry)", conn)
                cmd.Parameters.AddWithValue("@Entry", recordText)
                conn.Open()
                Dim rowsEffected As Integer = cmd.ExecuteNonQuery()
                Console.WriteLine("writing {0} rows to db", rowsEffected)

            End Using

        End Sub

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorLog.Add

            recordToLog([String].Format("Adding {0} to {1}", n1, n2))
            Return n1 + n2

        End Function

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorLog.Subtract

            recordToLog([String].Format("Subtracting {0} from {1}", n1, n2))
            Return n1 - n2

        End Function

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorLog.Multiply

            recordToLog([String].Format("Multiplying {0} by {1}", n1, n2))
            Return n1 * n2

        End Function

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculatorLog.Divide

            recordToLog([String].Format("Dividing {0} by {1}", n1, n2))
            Return n1 / n2

        End Function

        <OperationBehavior(TransactionScopeRequired:=True, TransactionAutoComplete:=True)> _
        Public Sub ClearLog() Implements ICalculatorLog.ClearLog

            'this is a local transaction, it is not flowed from the client 
            'because the TransactionFlow was not used on this operation in the service contract
            Using conn As New SqlConnection(ConfigurationManager.AppSettings("connectionString"))

                Dim cmd As New SqlCommand("DELETE FROM Log", conn)
                conn.Open()
                Dim rowsEffected As Integer = cmd.ExecuteNonQuery()
                Console.WriteLine("Deleting {0} rows from db", rowsEffected)

            End Using

        End Sub

        Public Function ReadLog() As String() Implements ICalculatorLog.ReadLog

            Using conn As New SqlConnection(ConfigurationManager.AppSettings("connectionString"))

                Dim cmd As New SqlCommand("SELECT Entry from Log", conn)

                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()

                Dim entries As New List(Of String)()

                While reader.Read()
                    entries.Add(DirectCast(reader("Entry"), String))
                End While

                Return entries.ToArray()

            End Using

        End Function

    End Class

End Namespace

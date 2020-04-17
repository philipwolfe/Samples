'=====================================================================
'  File:      TxObj.vb
'
'  Summary:   Server Code for .NET COM+ Transactions Sample
'
'---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'=====================================================================

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Forms
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization


' the ApplicationName attribute specifies the name of the
' COM+ Application that will hold assembly components
<Assembly: ApplicationName("TXDemoServer")> 

' the ApplicationActivation.ActivationOption attribute specifies 
' where assembly components are loaded on activation
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe
<Assembly: ApplicationActivation(ActivationOption.Library)> 

Namespace Microsoft.Samples.Technologies.ComponentServices.Transactions

    'This TXDemoServer class is going to be hosted within COM+
    'The transaction attributes enables us to do transactions within the class.
    <Transaction(TransactionOption.Required), _
    ComVisible(True), _
    CLSCompliant(False)> _
    Public Class TXDemoServer
        Inherits ServicedComponent

        Private sqlConnection As SqlConnection


        'First the SQLConnection needs to be setup.
        Private ReadOnly Property Database() As SqlConnection
            Get
                If sqlConnection Is Nothing Then _
                    sqlConnection = New SqlConnection("Integrated Security=SSPI;server=(local)\SQLExpress;database=TxDemoDB")
                Database = sqlConnection
            End Get
        End Property

        'This method returns the "current value" 
        Public Function RetrieveCurrentValue() As Integer
            Dim currentValue As Integer = 0
            Dim sqlCommand As SqlCommand
            Try
                Database.Open()
                sqlCommand = New SqlCommand("select * from currentValue", Database)
                Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
                sqlDataReader.Read()
                currentValue = CInt(sqlDataReader("currentValue"))
            Catch ex As Exception
                Throw New CurrentValueNotReadException(ex)
            Finally
                If Not sqlConnection Is Nothing Then
                    sqlConnection.Close()
                End If
                Database.Close()
            End Try
            RetrieveCurrentValue = currentValue
        End Function

        'This method tries to update the "current value", first it updates the
        'database, then it checks if the value is allowed, if not it throws an 
        'COMException so the <AutoComplete()> Attribute automatically does a 
        'rollback of the transaction.
        <AutoComplete()> _
        Public Sub AutoCompletePost(ByVal newValue As Integer)
            Try
                Database.Open()
                Dim sqlCommand As New SqlCommand("UPDATE currentValue SET " & _
                 "currentValue=@currentValue", Database)
                sqlCommand.Parameters.Add("@currentValue", SqlDbType.Int, 4)
                sqlCommand.Parameters("@currentValue").Value = newValue
                Try
                    sqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    Throw New DatabaseExecutionException(ex)
                End Try

                If newValue < 0 Or newValue > 10 Then
                    MessageBox.Show(("About to abort the transaction because " & _
                     "the new value (" & newValue & ") is either <0 or >10"))
                    Throw New ValueOutOfRangeException(newValue)
                Else
                    MessageBox.Show("About to commit the transaction")
                End If
            Finally
                Database.Close()
            End Try
        End Sub


        'This method tries to update the "current value", first it updates the 
        'database, then it checks if the value is allowed, if not it calls 
        'ContextUtil.SetAbort to rollback the transaction.
        Public Sub Post(ByVal newValue As Integer)
            Try
                Database.Open()
                Dim sqlCommand As New SqlCommand("UPDATE currentValue SET " & _
                 "currentValue=@currentValue", Database)
                sqlCommand.Parameters.Add("@currentValue", SqlDbType.Int, 4)
                sqlCommand.Parameters("@currentValue").Value = newValue
                Try
                    sqlCommand.ExecuteNonQuery()
                Catch ex As Exception
                    Throw New DatabaseExecutionException(ex)
                End Try
                If newValue < 0 Or newValue > 10 Then
                    MessageBox.Show(("About to abort the transaction because " & _
                     "the new value (" & newValue & ") is either <0 or >10"))
                    ContextUtil.SetAbort()
                Else
                    MessageBox.Show("About to commit the transaction")
                    ContextUtil.SetComplete()
                End If
            Finally
                Database.Close()
            End Try
        End Sub
    End Class

    'These are the specialized exceptions this server can throw. 
    'The constructor with the SerializationInfo and the StreamingContext 
    'are to support serialization of the thread as it goes from COM+ to the 
    'client.

    'CurrentValueNotReadException occurs when there is an error while reading 
    'the current value from the database

    <Serializable()> _
    Public Class CurrentValueNotReadException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal value as String)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal value as String, ByVal ex As Exception)
            MyBase.New(value, ex)
        End Sub

        Public Sub New(ByVal ex As Exception)
            MyBase.New("Unable to get the current value from the database", ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class

    'DatabaseExecutionException occurs when there is an error while updating 
    'the database	
    <Serializable()> _
    Public Class DatabaseExecutionException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal value as String)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal value as String, ByVal ex As Exception)
            MyBase.New(value, ex)
        End Sub

        Public Sub New(ByVal ex As Exception)
            MyBase.New("Error while executing database commands", ex)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class

    'AbortTransactionException occurs when an AutoComplete attribute is used and 
    'the transaction needs to be aborted
    <Serializable()> _
    Public Class ValueOutOfRangeException
        Inherits Exception
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal value as String)
            MyBase.New(value)
        End Sub

        Public Sub New(ByVal value as String, ByVal ex As Exception)
            MyBase.New(value, ex)
        End Sub

        Public Sub New(ByVal newValue As Integer)
            MyBase.New("the new value (" & newValue & ") is either <0 or >10")
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class

End Namespace
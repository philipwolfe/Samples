'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.

'Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

Option Strict On
Imports System.Data.SqlClient
Imports System.EnterpriseServices

' These attributes set the component up for its interaction with COM+.
'
' SecurityRoleAttribute("XXXXX")
'     Allows user accounts in the indicated role to access this component.
'     Only Managers have access to this component.
'
' Transaction(TransactionOption.Required)
'     This component requires a Transaction.
'
' JustInTimeActivation(True)
'     COM+ will activate and deactivate the object as needed,
'     conserving resources when the object is not actively in use.
'
' ObjectPooling(Enabled:=True, MinPoolSize:=2, MaxPoolSize:=10)
'     The component uses Object Pooling, which lets you create a pool
'     of objects that won't be destroyed when they're released. Object
'     pooling increases performance for objects that are expensive to
'     create. This component will hold at least 2 objects and a maximum
'     of 10 in its pool at any given time.
'
' ConstructionEnabledAttribute(Default:="Server=localhost;
' DataBase=Northwind;Integrated Security=SSPI"
'     The component's Object Construction string. See the Construct
'     method below for more.

<SecurityRoleAttribute("Managers"), _
Transaction(TransactionOption.Required), _
JustInTimeActivation(True), _
ObjectPooling(Enabled:=True, MinPoolSize:=2, MaxPoolSize:=10), _
ConstructionEnabledAttribute(Default:="Server=localhost;DataBase=Northwind;Integrated Security=SSPI")> _
Public Class Supplier
    Inherits ServicedComponent

    Private m_strConnectionString As String

#Region " Constants for Database connections "
    ' Database connection constants.
    Protected Const SQL_CONNECTION_STRING As String = _
        "Server=localhost;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"

    Protected Const MSDE_CONNECTION_STRING As String = _
        "Server=(local)\NetSDK;" & _
        "DataBase=Northwind;" & _
        "Integrated Security=SSPI"
#End Region


    ' Default constructor.
    Public Sub New()
        MyBase.New()
        ' Set the default connection string. If we're using the component in
        ' COM+, this value will get overriden later in the Construct method.
        m_strConnectionString = SQL_CONNECTION_STRING
        DoTracing("Supplier instantiated at " & DateTime.Now.ToLongTimeString)
    End Sub

    ' Construct method applies only when the component is part of a
    ' COM+ application.
    Protected Overrides Sub Construct(ByVal constructString As String)
        ' This method gets called right after the constructor. The
        ' constructString parameter contains the class's default
        ' property, which was set above in the
        ' ConstructionEnabledAttribute. The default string appears in
        ' the COM+ Explorer, in the Object construction section of the
        ' Activation Tab of your component's properties. So a System
        ' Administrator can adjust its value without your having to
        ' recompile your class.
        ' In this example, we've set it to a connection string, but it
        ' could contain any string value you choose.
        If constructString.Length > 0 Then
            m_strConnectionString = constructString
        End If
    End Sub 'Construct



    ' Simulates a call to a stored procedure to add a supplier to the
    ' Suppliers table.
    '
    ' AutoComplete attribute means if the procedure exits with no
    ' exception, then SetComplete is automatically called, otherwise
    ' SetAbort is called.
    <AutoCompleteAttribute(True)> _
    Public Sub AddSupplier(ByVal CompanyName As String, ByVal Phone As String)
        '...
        Try
            'cmd = New SqlCommand("AddSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.AddSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub

    ' Simulates a call to a stored procedure to delete a supplier.
    <AutoCompleteAttribute(True)> _
    Public Sub DeleteSupplier(ByVal SupplierID As Integer)
        '...
        Try
            'cmd = New SqlCommand("DeleteSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.DeleteSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub

    ' Simulates a call to a stored procedure to get a list of all
    ' suppliers in Suppliers table.
    <AutoCompleteAttribute(True)> _
    Public Function GetSuppliers() As DataTable
        '...
        Try
            '...
            'da.Fill(dt)
            DoTracing("Supplier.GetSuppliers called at " & DateTime.Now.ToLongTimeString)
            'Return dt
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Function

    ' Simulates a call to a stored procedure to update a supplier.
    <AutoCompleteAttribute(True)> _
    Public Sub UpdateSupplier(ByVal SupplierID As Integer, ByVal CompanyName As String, ByVal Phone As String)
        '...
        Try
            'cmd = New SqlCommand("UpdateSupplier", cnn)
            '...
            'cmd.ExecuteNonQuery()
            DoTracing("Supplier.UpdateSupplier called at " & DateTime.Now.ToLongTimeString)
        Catch exp As Exception
            Throw New Exception(exp.Message, exp.InnerException)
        End Try
    End Sub



    ' Initialize the object for the current user
    Protected Overrides Sub Activate()
        ' Put code here such as opening a connection, creating
        ' temp files, etc.
        DoTracing("Supplier activated at " & DateTime.Now.ToLongTimeString)
    End Sub

    ' Indicate to COM+ whether the object can be pooled.
    ' Put code here to indicate whether or not you want the object to
    ' be pooled at this time.
    Protected Overrides Function CanBePooled() As Boolean
        DoTracing("Supplier.CanBePooled called at " & DateTime.Now.ToLongTimeString)
        Return True
    End Function

    ' Reset the object for the next user
    Protected Overrides Sub Deactivate()
        DoTracing("Supplier deactivated at " & DateTime.Now.ToLongTimeString)
    End Sub



    ' Writes to Application Log.
    Private Sub WriteToLog(ByVal strMsg As String)
        Dim oEventLog As New EventLog("Application")
        oEventLog.Source = "VBNET.HowTo.RoleBasedSecurity--EnterpriseServices"
        oEventLog.WriteEntry(strMsg)
    End Sub

    ' Reports on current object status in various ways.
    Private Sub DoTracing(ByVal strMsg As String)
        ' Create a trace listener for the event log.
        'Dim logTraceListener As New EventLogTraceListener("Supplier--VB.NET How-To: RoleBasedSecurity")

        ' Add the trace listener to the collection.
        'Trace.Listeners.Add(logTraceListener)

        ' Create a trace listener that will send send trace output to the console
        ' It could have written to a file or stream instead.
        Dim consoleTraceListener As New TextWriterTraceListener(System.Console.Out)

        ' Add the trace listener to the collection.
        Trace.Listeners.Add(consoleTraceListener)

        ' Write output.
        Trace.WriteLine(strMsg)
    End Sub


End Class

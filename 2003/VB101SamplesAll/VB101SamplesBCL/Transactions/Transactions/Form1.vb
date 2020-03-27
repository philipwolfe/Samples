Imports System.IO
Imports System.Data.SqlClient

Imports System.Transactions

Public Class Form1

    Dim tfile As TransFile

    Public Sub New()
        InitializeComponent()
        tFile = New TransFile(New Guid("{67891A5C-3FE9-48af-AC8F-26B11D8DB035}"))
        Directory.SetCurrentDirectory(Application.StartupPath + "\..\..\")
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        'first delete the test file
        If File.Exists("ReadMeCopy.htm") Then
            File.Delete("ReadMeCopy.htm")
        End If
        ' Then we start the transaction
        StartImplicitLocalTransaction()
    End Sub

    Sub StartImplicitLocalTransaction()

        Dim info As TransactionInformation
        Dim transOptions As TransactionOptions = New TransactionOptions

        transOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
        transOptions.Timeout = New TimeSpan(0, 1, 0)

        ' Create a transaction scope inside a using statement to protect it against unforseen actions
        ' an "ambient" transaction is placed in the current call context
        ' Everything inside the using block is in the transaction
        Me.transDetails.Text += vbCrLf & vbCrLf
        Me.transDetails.Text += "-- Creation Transaction" & Microsoft.VisualBasic.vbCrLf

        Using transScope As TransactionScope = New TransactionScope(TransactionScopeOption.RequiresNew, transOptions)

            Me.transDetails.Text += "-- Inside Transaction Scope" & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "-- Transaction Details" & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "" & Microsoft.VisualBasic.Chr(9) & "Isolation Level: " & Transaction.Current.IsolationLevel & Microsoft.VisualBasic.vbCrLf
            info = Transaction.Current.TransactionInformation
            Me.transDetails.Text += "" & Microsoft.VisualBasic.Chr(9) & "Creation Time: " & info.CreationTime.ToString & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "" & Microsoft.VisualBasic.Chr(9) & "Distrubuted ID: " & info.DistributedIdentifier.ToString & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "" & Microsoft.VisualBasic.Chr(9) & "Local ID: " & info.LocalIdentifier & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "" & Microsoft.VisualBasic.Chr(9) & "Status: " & info.Status.ToString & Microsoft.VisualBasic.vbCrLf
            Me.transDetails.Text += "-- Create SQL Connection" & Microsoft.VisualBasic.vbCrLf

            ' the data provider will detect the transaction and automatically enlist into it
            Using connection As SqlConnection = New SqlConnection(_connectionString1)
                Dim command As SqlCommand = New SqlCommand(_sqlString, connection)
                Me.transDetails.Text += "-- Open SQL Connection" & Microsoft.VisualBasic.vbCrLf
                connection.Open()
                Me.transDetails.Text += "-- Run Query SQL" & Microsoft.VisualBasic.vbCrLf
                command.ExecuteNonQuery()
                Me.transDetails.Text += "-- Close SQL Connection" & Microsoft.VisualBasic.vbCrLf
                connection.Close()
            End Using

            ' Now you could use a COM+ component or use MSMQ in a transactional context
            ' By creating a transaction file you can also copy some files in a transactional context
            tfile.Copy("ReadMe.htm", "ReadMeCopy.htm")

            ' If the previous statements all completed without exceptions then
            ' the transaction is in a consitent state and can be comitted
            If Me.IsTransactionSuccess.Checked Then
                transScope.Complete()
                Me.transDetails.Text += "-- Set Transaction as Complete" & Microsoft.VisualBasic.vbCrLf
            Else
                Me.transDetails.Text += "-- Rollback Transaction" & Microsoft.VisualBasic.vbCrLf
            End If

        End Using

        ' after leaving the using block Dispose will be called 
        ' on the transaction and the transaction will be comitted if it was set to complete

        System.Threading.Thread.Sleep(1000)

        Me.transDetails.Text += "Has the file been copied? " & File.Exists("ReadMeCopy.htm")

    End Sub

    Private Sub ClearDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDetails.Click
        Me.transDetails.Text = ""
    End Sub

    Private _connectionString1 As String = "Server=.\SQLExpress;Database=AdventureWorks;Integrated Security=True"
    Private _sqlString As String = "select * from HumanResources.Employee"

End Class

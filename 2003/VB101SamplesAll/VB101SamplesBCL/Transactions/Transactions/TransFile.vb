Imports System.IO
Imports System.Transactions
Imports System.Collections.Generic

'The operations requested are logged using a write-ahead algorithm.
' While this resource has a sufficiently simple set of operations that
' we could simplify, however we record both the redo and undo operations
' in order to show a more general recovery style.

' The RedoOperation will replay the Copy operation if asked.
<Serializable()> _
Public Class RedoOperation
    Inherits RecoveryOperation

    Public Sub New()
        fromLocation = Nothing
        toLocation = Nothing
    End Sub

    Public Sub New(ByVal fromLocation As String, ByVal toLocation As String)
        Me.fromLocation = fromLocation
        Me.toLocation = toLocation
    End Sub

    Public Overloads Overrides Sub Execute()
        File.Copy(Me.fromLocation, Me.toLocation, True)
    End Sub

    Public fromLocation As String
    Public toLocation As String

End Class

' The UndoOperation will delete the destination file, if asked.
<Serializable()> _
Public Class UndoOperation
    Inherits RecoveryOperation

    Public Sub New()
        toLocation = Nothing
    End Sub

    Public Sub New(ByVal toLocation As String)
        Me.toLocation = toLocation
    End Sub

    Public Overloads Overrides Sub Execute()
        If File.Exists(Me.toLocation) Then
            File.Delete(Me.toLocation)
        End If
    End Sub

    Public toLocation As String

End Class

' This is the transactional file class.  It provides a single function:
' Copy, which copies a file to a designated target iff the enclosing
' transaction commits.
'
' There are a number of restrictions for this class:
' -- The class is a singleton.  For any given resource manager ID, there
'    can only be one process that has the class instantiated.  This is
'    due to both a restriction that MSDTC has for durable resources, and
'    due to how the logging and recovery for the resource works.
'
' -- There is no inter-thread locking done by this class, so it assumes
'    no multithreaded activity.
'
' -- The source file for the Copy operation must not disappear until after
'    the transaction has been completed.
'
' -- The target file must should not be present.  The class assumes that
'    it is creating a new file, rather than overwriting an existing one.
'
' These last two are a result of attempting to simplify the example.  The
' Copy operation could have saved the source file to a temporary file,
' and saved the original destination file to a temporary file, and then
' renamed appropriately at Commit or Abort.  However, that would have
' made the TransFile class much more complicated without demonstrating
' anything further about building a durable resource manager.  Therefore,
' this extension is left as an exercise for the reader.

Public Class TransFile
    ' This is the recovery log instance.  Information about transactions
    ' in flight is recorded in it, and replayed for recovery when the
    ' class is instantiated.
    Private m_log As RecoveryLog

    ' This contains the enlistments for all active transactions.  It is
    ' used to avoid duplicating enlistments when multiple Copy operations
    ' are called within a single transaction.
    Private m_enlistments As Dictionary(Of Transaction, TransFileEnlistment)

    ' Constructor: get our identity, open the log, and drive recovery.
    Public Sub New(ByVal resourceManagerID As Guid)
        Me.m_resourceManagerIdentifier = resourceManagerID
        Me.m_log = New RecoveryLog(resourceManagerID)
        Me.m_enlistments = New Dictionary(Of Transaction, TransFileEnlistment)

        DoRecovery()
    End Sub

    ' Copy: This is the external function.  It obtains the enlistment
    ' information, logs the operation to be done, and then issues the
    ' real Copy.  This allows issues such as access control restrictions
    ' to surface now, while the transaction is active, rather than during
    ' the commit processing, where the caller would have relatively little
    ' context.
    Public Sub Copy(ByVal fromLocation As String, ByVal toLocation As String)

        If Transaction.Current Is Nothing Then
            Throw New InvalidOperationException("Copy must be called inside a transaction")
        End If

        Dim txEnlist As TransFileEnlistment = EnlistIfNecessary()

        Me.m_log.Undo(txEnlist.enlistment, New UndoOperation(toLocation))
        Me.m_log.Redo(txEnlist.enlistment, New RedoOperation(fromLocation, toLocation))

        File.Copy(fromLocation, toLocation)

    End Sub

    ' This is a helper routine that is used to remove an enlistment from
    ' the active transaction set.  An individual enlistment calls it when
    ' the enlistment get a prepare or rollback notification.
    Friend Sub MakeEntryInactive(ByVal entry As TxEntry)
        If Me.m_enlistments.ContainsKey(entry.Transaction) Then
            Me.m_enlistments.Remove(entry.Transaction)
        End If
    End Sub

    ' This is the main recovery handler.  It is called during the class
    ' construction, and gets the files into a consistent state before
    ' opening for work.
    '
    ' Basically, it gets all the known transactions from the log --
    ' these would be transactions that were not fully forgotten in a
    ' previous run.  It then performs redo/undo recovery on any that
    ' have known outcomes, and reenlists for those that are in doubt.
    '
    ' Finally, it tells System.Transactions that it has completed all
    ' planned recovery, so that the transaction manager may reclaim its
    ' log space.
    '
    ' Note that recovery is also the reason why the resource manager
    ' identifier is important.  All recovery entries in the transaction
    ' manager logs are keyed by their relevant resource manager
    ' identifiers.  If the same resource manager identifier is not used
    ' in a later run, then a rollback outcome will be delivered for any
    ' in doubt transactions, and the transaction manager will not be able
    ' to reclaim log space used to record outcomes under the original
    ' resource manager identifier.
    Private Sub DoRecovery()
        Dim transactions As List(Of TxEntry) = Me.m_log.KnownTransactions

        For Each entry As TxEntry In transactions
            Select Case entry.State
                Case LogState.Aborted
                    entry.ExecuteUndoList()
                    Me.m_log.Forget(entry)
                    ' break
                Case LogState.Prepared
                    entry.ExecuteRedoList()
                    Dim tempTransFileEnlistment As New TransFileEnlistment(Me, m_log, entry)
                    ' break
                Case Else
                    ' break
            End Select
        Next

        TransactionManager.RecoveryComplete(Me.m_resourceManagerIdentifier)
    End Sub

    ' Get our enlistment information, either creating a new one if this
    ' is the first time we've seen this transaction, or reusing the one
    ' that we'd previously created.
    Private Function EnlistIfNecessary() As TransFileEnlistment
        Dim enlist As TransFileEnlistment

        If m_enlistments.ContainsKey(Transaction.Current) Then
            enlist = Me.m_enlistments(Transaction.Current)
        Else
            enlist = New TransFileEnlistment(Me, m_log)
            Me.m_enlistments.Add(Transaction.Current, enlist)
        End If

        Return enlist
    End Function

    Private m_resourceManagerIdentifier As Guid
    Public ReadOnly Property ResourceManagerID() As Guid
        Get
            Return Me.m_resourceManagerIdentifier
        End Get
    End Property

End Class

Friend Class TransFileEnlistment
    Implements ISinglePhaseNotification
    Public enlistment As TxEntry
    Private resource As TransFile
    Private log As RecoveryLog

    Public Sub New(ByVal resource As TransFile, ByVal log As RecoveryLog, ByVal entry As TxEntry)
        Me.enlistment = entry
        Me.resource = resource
        Me.log = log
        TransactionManager.Reenlist(resource.ResourceManagerID, entry.RecoveryInformation, Me)
    End Sub

    Public Sub New(ByVal resource As TransFile, ByVal log As RecoveryLog)
        Me.enlistment = New TxEntry(Transaction.Current)
        Me.resource = resource
        Me.log = log
        Transaction.Current.EnlistDurable(resource.ResourceManagerID, Me, EnlistmentOptions.None)
    End Sub

    Public Sub Commit(ByVal enlistment As Enlistment) Implements IEnlistmentNotification.Commit
        Me.log.Forget(Me.enlistment)
        enlistment.Done()
    End Sub

    Public Sub InDoubt(ByVal enlistment As Enlistment) Implements IEnlistmentNotification.InDoubt
        Throw New Exception("The method or operation is not implemented.")
    End Sub

    Public Sub Prepare(ByVal preparingEnlistment As PreparingEnlistment) Implements IEnlistmentNotification.Prepare
        Try
            Me.log.Prepare(Me.enlistment, preparingEnlistment.RecoveryInformation)
            preparingEnlistment.Prepared()
            Me.resource.MakeEntryInactive(Me.enlistment)
        Catch e As Exception
            Console.WriteLine("Unexpected error during Prepare: " + e.Message)
            preparingEnlistment.ForceRollback()
        End Try
    End Sub

    Public Sub Rollback(ByVal enlistment As Enlistment) Implements IEnlistmentNotification.Rollback
        Me.enlistment.ExecuteUndoList()
        Me.log.Forget(Me.enlistment)
        enlistment.Done()
        Me.resource.MakeEntryInactive(Me.enlistment)
    End Sub

    Public Sub SinglePhaseCommit(ByVal singlePhaseEnlistment As SinglePhaseEnlistment) Implements ISinglePhaseNotification.SinglePhaseCommit
        Commit(singlePhaseEnlistment)
        Me.resource.MakeEntryInactive(Me.enlistment)
    End Sub
End Class
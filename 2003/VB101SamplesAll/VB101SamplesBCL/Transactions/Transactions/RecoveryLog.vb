Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Transactions

' Supporting enumerations and classes for the recovery log handlers

' The transaction states represented by entries in the log file, with
' Aborted as the presumed state at the start.
Enum LogState
    Aborted
    Prepared
    Forgotten
End Enum

' Operation types for entries in the recovery log.
Enum LogOpType
    Redo
    Undo
    Prepare
    Forget
End Enum

<Serializable()> _
Public MustInherit Class RecoveryOperation
    Public MustOverride Sub Execute()
End Class

' Log Entries are either operations, such as undo or redo, or they are
' transaction state changes, such as Prepare or Forget.  The following
' three classes represent those structures.
<Serializable()> _
MustInherit Class LogEntryBase
    Friend MustOverride Sub Process(ByVal log As RecoveryLog)
    Public optype As LogOpType
    Public LogIdentifier As Guid
End Class


<Serializable()> _
Class LogOpEntry
    Inherits LogEntryBase

    Public Sub New()
        op = Nothing
        optype = LogOpType.Redo
        LogIdentifier = Guid.Empty
    End Sub

    Public op As RecoveryOperation

    Friend Overloads Overrides Sub Process(ByVal log As RecoveryLog)
        Dim entry As TxEntry = log.GetEntryFor(LogIdentifier)

        Select Case optype
            Case LogOpType.Redo
                entry.RedoList.Add(op)
                ' break
            Case LogOpType.Undo
                entry.UndoList.Insert(0, op)
                ' break
            Case Else
                Throw New Exception("The method or operation is not implemented.")
        End Select

    End Sub

End Class

<Serializable()> _
Class LogTxState
    Inherits LogEntryBase

    Public recoveryInformation As Byte()

    Friend Overloads Overrides Sub Process(ByVal log As RecoveryLog)
        Dim entry As TxEntry = log.GetEntryFor(LogIdentifier)

        Select Case optype
            Case LogOpType.Forget
                entry.State = LogState.Forgotten
            Case LogOpType.Prepare
                entry.State = LogState.Prepared
                entry.RecoveryInformation = recoveryInformation
            Case Else
                Throw New Exception("The method or operation is not implemented.")
        End Select
    End Sub

End Class

' Instances of this class represent the known recovery state of any given
' transaction.
Friend Class TxEntry

    Public Sub New(ByVal logIdentifier As Guid, ByVal state As LogState, ByVal recoveryInformation As Byte())
        Me.m_transaction = Nothing
        Me.m_logIdentifier = logIdentifier
        Me.m_state = state
        Me.m_recoveryInformation = recoveryInformation
    End Sub

    Public Sub New(ByVal transaction As Transaction)
        Me.m_transaction = transaction
        Me.m_logIdentifier = Guid.NewGuid
        Me.m_state = LogState.Aborted
        Me.m_recoveryInformation = Nothing
    End Sub

    Private m_transaction As Transaction
    Public ReadOnly Property Transaction() As Transaction
        Get
            Return m_transaction
        End Get
    End Property


    Private m_logIdentifier As Guid
    Public ReadOnly Property LogIdentifier() As Guid
        Get
            Return m_logIdentifier
        End Get
    End Property


    Private m_state As LogState
    Public Property State() As LogState
        Get
            Return m_state
        End Get
        Set(ByVal value As LogState)
            m_state = value
        End Set
    End Property

    Private m_recoveryInformation As Byte()
    Public Property RecoveryInformation() As Byte()
        Get
            Return m_recoveryInformation
        End Get
        Set(ByVal value As Byte())
            m_recoveryInformation = value
        End Set
    End Property

    Dim m_redoList As New List(Of RecoveryOperation)
    Public ReadOnly Property RedoList() As List(Of RecoveryOperation)
        Get
            Return m_redoList
        End Get
    End Property

    Public Sub ExecuteRedoList()
        For Each op As RecoveryOperation In m_redoList
            op.Execute()
        Next
    End Sub

    Dim m_undoList As New List(Of RecoveryOperation)
    Public ReadOnly Property UndoList() As List(Of RecoveryOperation)
        Get
            Return m_undoList
        End Get
    End Property

    Public Sub ExecuteUndoList()
        For Each op As RecoveryOperation In m_undoList
            op.Execute()
        Next
    End Sub

End Class

' This is the actual recovery log management class.
Class RecoveryLog

    Private forgetCount As Integer = 0
    Private Const CHECKPOINT_LIMIT As Integer = 100
    Private logStream As FileStream
    Private logName As String

    Public Sub New(ByVal logIdentifier As Guid)
        ' Construct log file name from identifier
        Me.logName = "TransFile-" + logIdentifier.ToString
        OpenLogFile()

        ' Initialize the known transaction list and read all the
        ' entries in the log
        Me.m_knownTransactions = New Dictionary(Of Guid, TxEntry)
        Dim o As LogEntryBase = ReadLogEntry
        While Not (o Is Nothing)
            o.Process(Me)
            o = ReadLogEntry
        End While
    End Sub

    Public Sub Redo(ByVal entry As TxEntry, ByVal operation As RecoveryOperation)
        If Not m_knownTransactions.ContainsKey(entry.LogIdentifier) Then
            m_knownTransactions.Add(entry.LogIdentifier, entry)
        End If
        entry.RedoList.Add(operation)
        Dim logEntry As LogOpEntry = New LogOpEntry
        logEntry.LogIdentifier = entry.LogIdentifier
        logEntry.optype = LogOpType.Redo
        logEntry.op = operation
        WriteLogEntry(logEntry)
    End Sub

    Public Sub Undo(ByVal entry As TxEntry, ByVal operation As RecoveryOperation)
        If Not m_knownTransactions.ContainsKey(entry.LogIdentifier) Then
            m_knownTransactions.Add(entry.LogIdentifier, entry)
        End If
        entry.UndoList.Insert(0, operation)
        Dim logEntry As LogOpEntry = New LogOpEntry
        logEntry.LogIdentifier = entry.LogIdentifier
        logEntry.optype = LogOpType.Undo
        logEntry.op = operation
        WriteLogEntry(logEntry)
    End Sub

    Public Sub Prepare(ByVal entry As TxEntry, ByVal recoveryInformation As Byte())
        entry.State = LogState.Prepared
        entry.RecoveryInformation = recoveryInformation
        Dim logEntry As LogTxState = New LogTxState
        logEntry.LogIdentifier = entry.LogIdentifier
        logEntry.optype = LogOpType.Prepare
        logEntry.recoveryInformation = recoveryInformation
        WriteLogEntry(logEntry)
    End Sub

    Public Sub Forget(ByVal entry As TxEntry)
        m_knownTransactions.Remove(entry.LogIdentifier)
        Dim logEntry As LogTxState = New LogTxState
        logEntry.LogIdentifier = entry.LogIdentifier
        logEntry.optype = LogOpType.Forget
        WriteLogEntry(logEntry)
        forgetCount = forgetCount + 1
        If forgetCount > CHECKPOINT_LIMIT Then
            DoCheckpoint()
        End If
    End Sub

    ' This method opens or creates the recovery log file, handling the
    ' various states that may exist if a failure occured during recovery
    ' checkpointing.
    Private Sub OpenLogFile()
        If Not File.Exists(Me.logName + ".log") Then
            If File.Exists(Me.logName + ".new") Then
                File.Move(Me.logName + ".new", Me.logName + ".log")
            Else
                If File.Exists(Me.logName + ".bck") Then
                    File.Move(Me.logName + ".bck", Me.logName + ".log")
                End If
            End If
        End If
        Me.logStream = New FileStream(Me.logName + ".log", FileMode.OpenOrCreate)
    End Sub

    ' This method performs a sharp checkpoint.  It creates a new log file,
    ' copies all the entries in the current log file that are for known
    ' (unforgotten) transactions into it, and then swaps the new file over
    ' the old file (saving the old file just in case of failure).
    '
    ' This is a fairly simple approach that is used to keep from building
    ' up too much data for completely processed transactions in the log
    ' file.
    Private Sub DoCheckpoint()

        Using newLogStream As New FileStream(Me.logName + ".new", FileMode.CreateNew)

            Me.logStream.Seek(0, SeekOrigin.Begin)

            Dim formatter As New BinaryFormatter()
            Dim o As LogEntryBase = ReadLogEntry()

            While Not (o Is Nothing)
                o = ReadLogEntry()

                If m_knownTransactions.ContainsKey(o.LogIdentifier) Then
                    Try
                        formatter.Serialize(newLogStream, o)
                    Catch ex As Exception
                        Console.WriteLine("Failed to serialize. Reason: " + ex.Message)
                        Throw
                    End Try

                End If

            End While

            logStream.Close()
            Me.logStream = Nothing

        End Using

        File.Replace(Me.logName + ".new", Me.logName + ".log", Me.logName + ".bck")

        OpenLogFile()
        forgetCount = 0
    End Sub

    ' This is a very simple method that uses serialization to get the log
    ' record into the log file.  It is somewhat space inefficient, but very
    ' simple to write.
    Private Sub WriteLogEntry(ByVal o As LogEntryBase)

        Dim formatter As New BinaryFormatter()

        Try
            formatter.Serialize(logStream, o)
            logStream.Flush()
        Catch ex As Exception
            Console.WriteLine("Failed to serialize. Reason: " + ex.Message)
            Throw
        End Try

    End Sub

    ' Likewise, this is a very simple method that retrieves the serialized
    ' object from the log file.
    Private Function ReadLogEntry() As LogEntryBase
        Dim o As LogEntryBase = Nothing
        Try
            Dim formatter As BinaryFormatter = New BinaryFormatter
            o = CType(formatter.Deserialize(logStream), LogEntryBase)
        Catch generatedExceptionVariable0 As SerializationException
        End Try
        Return o
    End Function


    ' Get the known transaction list.  This is what drives recovery
    ' processing in TransFile.  Forgotten transactions are pruned while
    ' forming the recovery list, and may prompt an immediate checkpoint
    ' in some cases.
    Dim m_knownTransactions As Dictionary(Of Guid, TxEntry)
    Public ReadOnly Property KnownTransactions() As List(Of TxEntry)
        Get
            Dim entries As New List(Of TxEntry)
            Dim forgottenKeys As New List(Of Guid)

            For Each entry As KeyValuePair(Of Guid, TxEntry) In m_knownTransactions

                If entry.Value.State = LogState.Forgotten Then
                    entries.Add(entry.Value)
                Else
                    forgottenKeys.Add(entry.Key)
                    forgetCount = forgetCount + 1
                End If

            Next

            For Each key As Guid In forgottenKeys
                m_knownTransactions.Remove(key)
            Next

            If forgetCount > CHECKPOINT_LIMIT Then
                DoCheckpoint()
            End If

            Return entries

        End Get

    End Property

    ' Either return the TxEntry for a known transaction, or create one for
    ' a transaction we've not previously seen.
    Public Function GetEntryFor(ByVal logEntryGuid As Guid) As TxEntry

        If m_knownTransactions.ContainsKey(logEntryGuid) Then
            Return m_knownTransactions(logEntryGuid)
        Else
            Dim entry As New TxEntry(logEntryGuid, LogState.Aborted, Nothing)
            m_knownTransactions.Add(logEntryGuid, entry)
            Return entry
        End If

    End Function

End Class


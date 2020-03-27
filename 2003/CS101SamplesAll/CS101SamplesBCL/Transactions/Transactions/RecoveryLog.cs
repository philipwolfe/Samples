using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Transactions;

namespace Transactions
{
    // Supporting enumerations and classes for the recovery log handlers

    // The transaction states represented by entries in the log file, with
    // Aborted as the presumed state at the start.
    internal enum LogState
    {
        Aborted, Prepared, Forgotten
    }

    // Operation types for entries in the recovery log.
    public enum LogOpType
    {
        Redo, Undo, Prepare, Forget
    }


    [Serializable]
    public abstract class RecoveryOperation
    {
        public abstract void Execute ();
    }


    // Log Entries are either operations, such as undo or redo, or they are
    // transaction state changes, such as Prepare or Forget.  The following
    // three classes represent those structures.
    [Serializable]
    abstract class LogEntryBase
    {
        internal abstract void Process(RecoveryLog log);
        public LogOpType optype;
        public Guid LogIdentifier;
    }

    [Serializable]
    class LogOpEntry : LogEntryBase
    {
        public LogOpEntry ()
        {
            op = null;
            optype = LogOpType.Redo;
            LogIdentifier = Guid.Empty;
        }

        public RecoveryOperation op;

        internal override void Process(RecoveryLog log)
        {
            TxEntry entry = log.GetEntryFor(LogIdentifier);

            switch (optype)
            {
                case LogOpType.Redo:
                    entry.RedoList.Add(op);
                    break;
                case LogOpType.Undo:
                    entry.UndoList.Insert(0, op);
                    break;
                default:
                    throw new Exception("The method or operation is not implemented.");
            }
        }
    }

    [Serializable]
    class LogTxState : LogEntryBase
    {
        public byte[] recoveryInformation;

        internal override void Process(RecoveryLog log)
        {
            TxEntry entry = log.GetEntryFor(LogIdentifier);

            switch (optype)
            {
                case LogOpType.Forget:
                    entry.State = LogState.Forgotten;
                    break;

                case LogOpType.Prepare:
                    entry.State = LogState.Prepared;
                    entry.RecoveryInformation = recoveryInformation;
                    break;

                default:
                    throw new Exception("The method or operation is not implemented.");
            }
        }
    }

    // Instances of this class represent the known recovery state of any given
    // transaction.
    internal class TxEntry
    {
        public TxEntry (Guid logIdentifier, LogState state, byte [] recoveryInformation)
        {
            this.transaction = null;
            this.logIdentifier = logIdentifier;
            this.state = state;
            this.recoveryInformation = recoveryInformation;
        }

        public TxEntry (Transaction transaction)
        {
            this.transaction = transaction;
            this.logIdentifier = Guid.NewGuid ();
            this.state = LogState.Aborted;
            this.recoveryInformation = null;
        }

        Transaction transaction;
        public Transaction Transaction { get { return transaction; } }

        Guid logIdentifier;
        public Guid LogIdentifier { get { return logIdentifier; } }

        LogState state;
        public LogState State
        {
            get {return state; }
            set {state = value; }
        }

        byte [] recoveryInformation;
        public byte [] RecoveryInformation
        {
            get { return recoveryInformation; }
            set { recoveryInformation = value; }
        }

        List<RecoveryOperation> redoList = new List<RecoveryOperation> ();
        public List<RecoveryOperation> RedoList {get {return redoList; } }

        public void ExecuteRedoList ()
        {
            foreach (RecoveryOperation op in RedoList)
            {
                op.Execute ();
            }
        }

        List<RecoveryOperation> undoList = new List<RecoveryOperation> ();
        public List<RecoveryOperation> UndoList {get {return undoList; } }

        public void ExecuteUndoList ()
        {
            foreach (RecoveryOperation op in UndoList)
            {
                op.Execute ();
            }
        }
    }

    // This is the actual recovery log management class.
    class RecoveryLog
    {
        private int forgetCount = 0;
        private const int CHECKPOINT_LIMIT = 100;

        private FileStream logStream;
        private string logName;

        public RecoveryLog(Guid logIdentifier)
        {
            // Construct log file name from identifier
            this.logName = "TransFile-" + logIdentifier.ToString();
            OpenLogFile();

            // Initialize the known transaction list and read all the
            // entries in the log
            this.knownTransactions = new Dictionary<Guid,TxEntry> ();

            for (LogEntryBase o = ReadLogEntry(); o != null; o = ReadLogEntry())
            {
                o.Process(this);
            }
        }

        public void Redo(TxEntry entry, RecoveryOperation operation)
        {
            if (!knownTransactions.ContainsKey (entry.LogIdentifier))
            {
                knownTransactions.Add (entry.LogIdentifier, entry);
            }

            entry.RedoList.Add (operation);

            LogOpEntry logEntry = new LogOpEntry ();
            logEntry.LogIdentifier = entry.LogIdentifier;
            logEntry.optype = LogOpType.Redo;
            logEntry.op = operation;

            WriteLogEntry(logEntry);
        }

        public void Undo (TxEntry entry, RecoveryOperation operation)
        {
            if (!knownTransactions.ContainsKey (entry.LogIdentifier))
            {
                knownTransactions.Add (entry.LogIdentifier, entry);
            }

            entry.UndoList.Insert (0, operation);

            LogOpEntry logEntry = new LogOpEntry ();
            logEntry.LogIdentifier = entry.LogIdentifier;
            logEntry.optype = LogOpType.Undo;
            logEntry.op = operation;

            WriteLogEntry(logEntry);
        }

        public void Prepare (TxEntry entry, byte [] recoveryInformation)
        {
            entry.State = LogState.Prepared;
            entry.RecoveryInformation = recoveryInformation;

            LogTxState logEntry = new LogTxState ();
            logEntry.LogIdentifier = entry.LogIdentifier;
            logEntry.optype = LogOpType.Prepare;
            logEntry.recoveryInformation = recoveryInformation;

            WriteLogEntry(logEntry);
        }

        public void Forget (TxEntry entry)
        {
            knownTransactions.Remove (entry.LogIdentifier);

            // Write forget record to the log file
            LogTxState logEntry = new LogTxState ();
            logEntry.LogIdentifier = entry.LogIdentifier;
            logEntry.optype = LogOpType.Forget;

            WriteLogEntry(logEntry);

            forgetCount++;

            if (forgetCount > CHECKPOINT_LIMIT)
            {
                DoCheckpoint();
            }

        }

        // This method opens or creates the recovery log file, handling the
        // various states that may exist if a failure occured during recovery
        // checkpointing.
        private void OpenLogFile()
        {
            if (!File.Exists (this.logName + ".log"))
            {
                // We don't have a log file -- this is either just starting up
                // for the first time, or we died in the middle of a
                // File.Replace during a checkpoint.  Look for the best possible
                // backup filename to work with.
                if (File.Exists(this.logName + ".new"))
                {
                    File.Move(this.logName + ".new", this.logName + ".log");
                }
                else if (File.Exists(this.logName + ".bck"))
                {
                    File.Move(this.logName + ".bck", this.logName + ".log");
                }
            }

            this.logStream = new FileStream(this.logName + ".log", FileMode.OpenOrCreate);
        }

        // This method performs a sharp checkpoint.  It creates a new log file,
        // copies all the entries in the current log file that are for known
        // (unforgotten) transactions into it, and then swaps the new file over
        // the old file (saving the old file just in case of failure).
        //
        // This is a fairly simple approach that is used to keep from building
        // up too much data for completely processed transactions in the log
        // file.
        private void DoCheckpoint()
        {
            using (FileStream newLogStream = new FileStream(this.logName + ".new", FileMode.CreateNew))
            {
                this.logStream.Seek(0, SeekOrigin.Begin);

                for (LogEntryBase o = ReadLogEntry(); o != null; o = ReadLogEntry())
                {
                    if (knownTransactions.ContainsKey(o.LogIdentifier))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        try
                        {
                            formatter.Serialize(newLogStream, o);
                        }
                        catch (SerializationException e)
                        {
                            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                            throw;
                        }
                    }
                }

                logStream.Close();
                this.logStream = null;
            }

            File.Replace(this.logName + ".new", this.logName + ".log", this.logName + ".bck");

            OpenLogFile();
            forgetCount = 0;
        }

        // This is a very simple method that uses serialization to get the log
        // record into the log file.  It is somewhat space inefficient, but very
        // simple to write.
        private void WriteLogEntry(LogEntryBase o)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(logStream, o);
                logStream.Flush();
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }

        }

        // Likewise, this is a very simple method that retrieves the serialized
        // object from the log file.
        private LogEntryBase ReadLogEntry()
        {
            LogEntryBase o = null;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                o = (LogEntryBase) formatter.Deserialize(logStream);
            }
            catch (SerializationException)
            {
                // This is highly unfortunate, but is needed to catch the
                // expected case of running into the end of the file.
            }

            return o;
        }

        // Get the known transaction list.  This is what drives recovery
        // processing in TransFile.  Forgotten transactions are pruned while
        // forming the recovery list, and may prompt an immediate checkpoint
        // in some cases.
        private Dictionary<Guid, TxEntry> knownTransactions;
        public List<TxEntry> KnownTransactions
        {
            get
            {
                List<TxEntry> entries = new List<TxEntry> ();
                List<Guid> forgottenKeys = new List<Guid>();

                foreach (KeyValuePair<Guid, TxEntry> entry in knownTransactions)
                {
                    if (entry.Value.State != LogState.Forgotten)
                    {
                        entries.Add(entry.Value);
                    }
                    else
                    {
                        forgottenKeys.Add(entry.Key);
                        forgetCount++;
                    }
                }

                foreach (Guid key in forgottenKeys)
                {
                    knownTransactions.Remove(key);
                }

                if (forgetCount > CHECKPOINT_LIMIT)
                {
                    DoCheckpoint();
                }

                return entries;
            }
        }

        // Either return the TxEntry for a known transaction, or create one for
        // a transaction we've not previously seen.
        public TxEntry GetEntryFor(Guid logEntryGuid)
        {
            if (knownTransactions.ContainsKey (logEntryGuid))
            {
                return knownTransactions [logEntryGuid];
            }
            else
            {
                TxEntry entry = new TxEntry (logEntryGuid, LogState.Aborted, null);
                knownTransactions.Add (logEntryGuid, entry);
                return entry;
            }

        }
    }
}

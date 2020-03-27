using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;

namespace Transactions
{
    // The operations requested are logged using a write-ahead algorithm.
    // While this resource has a sufficiently simple set of operations that
    // we could simplify, however we record both the redo and undo operations
    // in order to show a more general recovery style.

    // The RedoOperation will replay the Copy operation if asked.
    [Serializable]
    public class RedoOperation : RecoveryOperation
    {
        public RedoOperation ()
        {
            from = null;
            to = null;
        }

        public RedoOperation (string from, string to)
        {
            this.from = from;
            this.to = to;
        }

        public override void Execute ()
        {
            File.Copy (this.from, this.to, true);
        }

        public string from;
        public string to;
    }

    // The UndoOperation will delete the destination file, if asked.
    [Serializable]
    public class UndoOperation : RecoveryOperation
    {
        public UndoOperation ()
        {
            to = null;
        }

        public UndoOperation (string to)
        {
            this.to = to;
        }

        public override void Execute ()
        {
            if (File.Exists(this.to))
            {
                File.Delete(this.to);
            }
        }

        public string to;
    }

    // This is the transactional file class.  It provides a single function:
    // Copy, which copies a file to a designated target iff the enclosing
    // transaction commits.
    //
    // There are a number of restrictions for this class:
    // -- The class is a singleton.  For any given resource manager ID, there
    //    can only be one process that has the class instantiated.  This is
    //    due to both a restriction that MSDTC has for durable resources, and
    //    due to how the logging and recovery for the resource works.
    //
    // -- There is no inter-thread locking done by this class, so it assumes
    //    no multithreaded activity.
    //
    // -- The source file for the Copy operation must not disappear until after
    //    the transaction has been completed.
    //
    // -- The target file must should not be present.  The class assumes that
    //    it is creating a new file, rather than overwriting an existing one.
    //
    // These last two are a result of attempting to simplify the example.  The
    // Copy operation could have saved the source file to a temporary file,
    // and saved the original destination file to a temporary file, and then
    // renamed appropriately at Commit or Abort.  However, that would have
    // made the TransFile class much more complicated without demonstrating
    // anything further about building a durable resource manager.  Therefore,
    // this extension is left as an exercise for the reader.
    //
    public class TransFile
    {
        // This is the recovery log instance.  Information about transactions
        // in flight is recorded in it, and replayed for recovery when the
        // class is instantiated.
        private RecoveryLog log;

        // This contains the enlistments for all active transactions.  It is
        // used to avoid duplicating enlistments when multiple Copy operations
        // are called within a single transaction.
        private Dictionary<Transaction, TransFileEnlistment> enlistments;

        // Constructor: get our identity, open the log, and drive recovery.
        public TransFile (Guid resourceManagerID)
        {
            this.resourceManagerIdentifier = resourceManagerID;
            this.log = new RecoveryLog (resourceManagerID);
            this.enlistments = new Dictionary<Transaction, TransFileEnlistment>();

            DoRecovery();
        }

        // Copy: This is the external function.  It obtains the enlistment
        // information, logs the operation to be done, and then issues the
        // real Copy.  This allows issues such as access control restrictions
        // to surface now, while the transaction is active, rather than during
        // the commit processing, where the caller would have relatively little
        // context.
        public void Copy (string from, string to)
        {
            if (Transaction.Current == null)
            {
                throw new InvalidOperationException("Copy must be called inside a transaction");
            }

            TransFileEnlistment txEnlist = EnlistIfNecessary ();

            this.log.Undo(txEnlist.enlistment, new UndoOperation(to));
            this.log.Redo(txEnlist.enlistment, new RedoOperation(from, to));

            File.Copy (from, to);
        }

        // This is a helper routine that is used to remove an enlistment from
        // the active transaction set.  An individual enlistment calls it when
        // the enlistment get a prepare or rollback notification.
        internal void MakeEntryInactive (TxEntry entry)
        {
            if (this.enlistments.ContainsKey (entry.Transaction))
            {
                this.enlistments.Remove (entry.Transaction);
            }
        }

        // This is the main recovery handler.  It is called during the class
        // construction, and gets the files into a consistent state before
        // opening for work.
        //
        // Basically, it gets all the known transactions from the log --
        // these would be transactions that were not fully forgotten in a
        // previous run.  It then performs redo/undo recovery on any that
        // have known outcomes, and reenlists for those that are in doubt.
        //
        // Finally, it tells System.Transactions that it has completed all
        // planned recovery, so that the transaction manager may reclaim its
        // log space.
        //
        // Note that recovery is also the reason why the resource manager
        // identifier is important.  All recovery entries in the transaction
        // manager logs are keyed by their relevant resource manager
        // identifiers.  If the same resource manager identifier is not used
        // in a later run, then a rollback outcome will be delivered for any
        // in doubt transactions, and the transaction manager will not be able
        // to reclaim log space used to record outcomes under the original
        // resource manager identifier.
        private void DoRecovery ()
        {
            List<TxEntry> transactions = this.log.KnownTransactions;

            foreach (TxEntry entry in transactions)
            {
                switch (entry.State)
                {
                case LogState.Aborted:
                    entry.ExecuteUndoList ();
                    this.log.Forget (entry);
                    break;

                case LogState.Prepared:
                    entry.ExecuteRedoList ();
                    new TransFileEnlistment (this, log, entry);
                    break;

                default:
                    break;
                }
            }

            TransactionManager.RecoveryComplete (this.resourceManagerIdentifier);
        }

        // Get our enlistment information, either creating a new one if this
        // is the first time we've seen this transaction, or reusing the one
        // that we'd previously created.
        private TransFileEnlistment EnlistIfNecessary ()
        {
            TransFileEnlistment enlist;

            if (enlistments.ContainsKey (Transaction.Current))
            {
                enlist = this.enlistments [Transaction.Current];
            }
            else
            {
                enlist = new TransFileEnlistment (this,log);
                this.enlistments.Add (Transaction.Current, enlist);
            }

            return enlist;
        }

        private Guid resourceManagerIdentifier;
        public Guid ResourceManagerID { get { return this.resourceManagerIdentifier; } }
    }

    // This class represents an active enlistment controlled by the TransFile
    // class.  This may be created either due to an in doubt transaction on
    // recovery, or because a Copy operation was called with a new transaction.
    internal class TransFileEnlistment  : ISinglePhaseNotification
    {
        public TxEntry enlistment;
        private TransFile resource;
        private RecoveryLog log;

        // Constructor for a recovery enlistment.  In this case, we have an
        // existing transaction entry from the log, which is used to drive
        // the reenlistment.
        public TransFileEnlistment (TransFile resource, RecoveryLog log, TxEntry entry)
        {
            this.enlistment = entry;
            this.resource = resource;
            this.log = log;
            TransactionManager.Reenlist (resource.ResourceManagerID, entry.RecoveryInformation, this);
        }

        // Constructor for an active enlistemnt.  In this case, we do not have
        // an existing transaction entry, and need to create it as well as
        // actually enlist in the ambient transaction.
        public TransFileEnlistment (TransFile resource, RecoveryLog log)
        {
            this.enlistment = new TxEntry (Transaction.Current);

            this.resource = resource;
            this.log = log;

            Transaction.Current.EnlistDurable (resource.ResourceManagerID, this, EnlistmentOptions.None);
        }

        #region ISinglePhaseNotification Members

        // Process an order to commit.  We are completely done, so we just need
        // to forget about the transaction in our log and tell the transaction
        // manager.
        public void Commit(Enlistment enlistment)
        {
            this.log.Forget(this.enlistment);
            enlistment.Done();
        }

        // This class always uses EnlistDurable, so it should not get an
        // InDoubt outcome, except in extremis.
        public void InDoubt(Enlistment enlistment)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        // Process a request to prepare -- save the recoveryinformation away
        // for later recovery.  If anything goes wrong, veto the commit.
        //
        // Note as well that the transaction may no longer be considered
        // active, so it has been removed from the active enlistment table
        // in the main resource class.
        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            try
            {
                this.log.Prepare (this.enlistment, preparingEnlistment.RecoveryInformation ());
                preparingEnlistment.Prepared ();
                this.resource.MakeEntryInactive (this.enlistment);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error during Prepare: " + e.Message);
                preparingEnlistment.ForceRollback ();
            }
        }

        // Process an order to abort.  Undo the attempted operation, and forget
        // the record in the log.  Again, make sure that the transaction
        // is not considered active, as this may either be the first
        // notification, or may arrive after Prepare.
        public void Rollback(Enlistment enlistment)
        {
            this.enlistment.ExecuteUndoList ();
            this.log.Forget (this.enlistment);
            enlistment.Done ();
            this.resource.MakeEntryInactive (this.enlistment);
        }

        // This is a simple optimization where we perform our phase 2 directly
        // and notify the transation manager of the outcome.
        public void SinglePhaseCommit (SinglePhaseEnlistment singlePhaseEnlistment)
        {
            Commit (singlePhaseEnlistment);
            this.resource.MakeEntryInactive(this.enlistment);
        }

        #endregion
    }
}

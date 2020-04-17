//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities.Persistence;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Runtime.Persistence;
    using System.ComponentModel;
    using System.Activities;

    class WorkflowDefinitionExtension : IPersistenceParticipant, IExtension
    {
        const string associateDefinitionSql = "DECLARE @countExisting int SELECT @countExisting = COUNT(*) FROM dbo.WorkflowDefinition WHERE id = @id IF @countExisting = 1 BEGIN UPDATE dbo.WorkflowDefinition SET workflowDefinitionPath = @workflowDefinitionPath WHERE id = @id END ELSE INSERT INTO dbo.WorkflowDefinition (id, workflowDefinitionPath) VALUES(@id, @workflowDefinitionPath)";
        const string deleteDefinitionSql = "DELETE FROM dbo.WorkflowDefinition WHERE id = @id";

        IWorkflowHost host;
        WorkflowDefinitionInfo definitionInfo;
        string connectionString;

        public WorkflowDefinitionExtension(string definitionPath, string connectionString)
            : this(connectionString)
        {
            this.definitionInfo = new WorkflowDefinitionInfo { Path = definitionPath };
        }

        public WorkflowDefinitionExtension(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public WorkflowDefinitionInfo DefinitionInfo
        {
            get
            {
                return this.definitionInfo;
            }
        }

        public void OnDelete(ICollection<object> extensions, TimeSpan timeout)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand deleteDefinition = BuildDeleteDefinitionCommand(sqlConnection, host.Id);
            try
            {
                sqlConnection.Open();
                deleteDefinition.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public IAsyncResult BeginOnDelete(ICollection<object> extensions, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new DeleteAsyncResult(this.host.Id, this.connectionString, timeout, callback, state);
        }

        public void EndOnDelete(IAsyncResult result)
        {
            DeleteAsyncResult.End(result);
        }

        public object OnSave(ICollection<object> extensions, TimeSpan timeout)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand associateDefinition = BuildAssociateDefinitionCommand(sqlConnection, host.Id, this.definitionInfo.Path);
            try
            {
                sqlConnection.Open();
                associateDefinition.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }
            return this.definitionInfo;
        }

        public IAsyncResult BeginOnSave(ICollection<object> extensions, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return new SaveAsyncResult(this.host.Id, this.definitionInfo, this.connectionString, timeout, callback, state);
        }

        public object EndOnSave(IAsyncResult result)
        {
            return SaveAsyncResult.End(result);
        }

        public void OnLoad(object loadedObject, ICollection<object> extensions)
        {
            if (loadedObject != null)
            {
                this.definitionInfo = (WorkflowDefinitionInfo)loadedObject;
            }
        }

        public void Attach(object host)
        {
            this.host = host as IWorkflowHost;
            if (host == null)
            {
                throw new ArgumentException("host must be an IWorkflowHost", "host");
            }
        }

        public void Detach(object host)
        {
            this.host = null;
        }

        static SqlCommand BuildAssociateDefinitionCommand(SqlConnection sqlConnection, Guid id, string definitionPath)
        {
            SqlCommand command = new SqlCommand(associateDefinitionSql, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@workflowDefinitionPath", definitionPath);
            return command;
        }

        static SqlCommand BuildDeleteDefinitionCommand(SqlConnection sqlConnection, Guid id)
        {
            SqlCommand command = new SqlCommand(deleteDefinitionSql, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            return command;
        }

        class SaveAsyncResult : AsyncResult
        {
            SqlConnection connection;
            SqlCommand associateDefinitionCommand;
            WorkflowDefinitionInfo definitionInfo;
            static AsyncCompletion handleEndInsertDefinition;

            public SaveAsyncResult(Guid id, WorkflowDefinitionInfo definitionInfo, string connectionString, TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                this.definitionInfo = definitionInfo;

                if (handleEndInsertDefinition == null)
                {
                    handleEndInsertDefinition = new AsyncCompletion(HandleEndInsertDefinition);
                }

                this.connection = new SqlConnection(connectionString);
                this.associateDefinitionCommand = BuildAssociateDefinitionCommand(this.connection, id, this.definitionInfo.Path);
                this.connection.Open();

                IAsyncResult result = associateDefinitionCommand.BeginExecuteNonQuery(PrepareAsyncCompletion(handleEndInsertDefinition), this);

                if (result.CompletedSynchronously)
                {
                    if (HandleEndInsertDefinition(result))
                    {
                        Complete(true);
                    }
                }
            }

            static bool HandleEndInsertDefinition(IAsyncResult result)
            {
                SaveAsyncResult thisPtr = (SaveAsyncResult)result.AsyncState;

                try
                {
                    thisPtr.associateDefinitionCommand.EndExecuteNonQuery(result);
                }
                finally
                {
                    thisPtr.connection.Close();
                }

                return true;
            }

            public static object End(IAsyncResult result)
            {
                SaveAsyncResult thisPtr = AsyncResult.End<SaveAsyncResult>(result);
                return thisPtr.definitionInfo;
            }
        }

        class DeleteAsyncResult : AsyncResult
        {
            SqlConnection connection;
            SqlCommand deleteDefinitionCommand;
            static AsyncCompletion handleEndDeleteDefinition;

            public DeleteAsyncResult(Guid id, string connectionString, TimeSpan timeout, AsyncCallback callback, object state)
                : base(callback, state)
            {
                if (handleEndDeleteDefinition == null)
                {
                    handleEndDeleteDefinition = new AsyncCompletion(HandleEndDeleteDefinition);
                }

                this.connection = new SqlConnection(connectionString);

                this.deleteDefinitionCommand = BuildDeleteDefinitionCommand(this.connection, id);

                this.connection.Open();

                IAsyncResult result = deleteDefinitionCommand.BeginExecuteNonQuery(PrepareAsyncCompletion(handleEndDeleteDefinition), this);

                if (result.CompletedSynchronously)
                {
                    if (HandleEndDeleteDefinition(result))
                    {
                        Complete(true);
                    }
                }
            }

            static bool HandleEndDeleteDefinition(IAsyncResult result)
            {
                DeleteAsyncResult thsPtr = result.AsyncState as DeleteAsyncResult;

                try
                {
                    thsPtr.deleteDefinitionCommand.EndExecuteNonQuery(result);
                }
                finally
                {
                    thsPtr.connection.Close();
                }

                return true;
            }

            public static void End(IAsyncResult result)
            {
                DeleteAsyncResult thisPtr = AsyncResult.End<DeleteAsyncResult>(result);
            }
        }
    }
}

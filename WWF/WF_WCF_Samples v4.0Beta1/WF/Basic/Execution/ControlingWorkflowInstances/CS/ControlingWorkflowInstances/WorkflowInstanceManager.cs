//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities;
    using System.Activities.Validation;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.ServiceModel.Persistence;
    using System.Activities.Tracking;

    public class WorkflowInstanceManager : IWorkflowInstanceHandler
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\SampleInstanceStore.mdf;Integrated Security=True;Asynchronous Processing=True";
        const string findExistingInstancesSql = "SELECT wfdef.id, workflowDefinitionPath FROM dbo.WorkflowDefinition AS wfdef INNER JOIN dbo.InstanceData AS instance ON wfdef.id = instance.id";

        IHostView hostView;
        Dictionary<Guid, WorkflowInstanceState> instanceStates;
        object instanceStatesLock;
        PersistenceProviderFactory persistenceProviderFactory;
        bool closed;
        object closedLock;

        public WorkflowInstanceManager(IHostView hostView)
        {
            this.hostView = hostView;
            this.hostView.Initialize(this);
            this.instanceStates = new Dictionary<Guid, WorkflowInstanceState>();
            this.instanceStatesLock = new object();
            this.closedLock = new object();
        }

        public void Run(string xamlPath)
        {
            EnsureNotClosed();

            Guid id = Guid.NewGuid();
            WorkflowElement program = null;

            if (!TryLoadAndValidateProgram(xamlPath, out program))
            {
                return;
            }

            //create a new instance from this definition
            WorkflowInstance instance = new WorkflowInstance(program, id);

            if (this.hostView.UsePersistence)
            {
                PersistenceProvider persistenceProvider = null;

                try
                {
                    persistenceProvider = CreatePersistenceProvider(id);
                }
                catch (Exception e)
                {
                    WriteException(e, "An error has occured creating the PersistenceProvider");
                    return;
                }

                instance.Extensions.Add(persistenceProvider);
                instance.Extensions.Add(new WorkflowDefinitionExtension(xamlPath, connectionString));
            }

            ConfigureExtensions(instance);
            AddInstance(new WorkflowInstanceState(instance, this));

            try
            {
                instance.BeginRun(new AsyncCallback(OnEndRun), instance);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured Resuming the instance: ", e);
            }
        }

        void OnEndRun(IAsyncResult ar)
        {
            WorkflowInstance instance = ar.AsyncState as WorkflowInstance;

            try
            {
                instance.EndRun(ar);
                hostView.SelectInstance(instance.Id);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured Resuming the instance: ", e);
            }
        }

        public void LoadExistingInstances()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(findExistingInstancesSql, connection);
            try
            {
                connection.Open();
                command.BeginExecuteReader(new AsyncCallback(OnEndFindExistingInstances), command);
            }
            catch (SqlException exception)
            {
                this.hostView.ErrorWriter.WriteLine("Could not load existing instances due to a Sql Exception: " + exception.ToString());
            }
        }

        void OnEndFindExistingInstances(IAsyncResult result)
        {
            SqlCommand command = result.AsyncState as SqlCommand;
            try
            {
                SqlDataReader dataReader = command.EndExecuteReader(result);
                while (dataReader.Read())
                {
                    WorkflowElement program;
                    if (TryLoadAndValidateProgram(dataReader.GetString(dataReader.GetOrdinal("workflowDefinitionPath")), out program))
                    {
                        PersistenceProvider persistenceProvider = null;

                        try
                        {
                            persistenceProvider = CreatePersistenceProvider(dataReader.GetGuid(dataReader.GetOrdinal("id")));
                        }
                        catch (Exception e)
                        {
                            WriteException(e, "An error has occured creating the PersistenceProvider");
                            break;
                        }
                        WorkflowInstance.BeginLoad(program, persistenceProvider, new AsyncCallback(OnEndLoad), persistenceProvider);
                    }
                }
            }
            catch (SqlException exception)
            {
                this.hostView.ErrorWriter.WriteLine("Could not load existing instances due to a Sql Exception: " + exception.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        void OnEndLoad(IAsyncResult result)
        {
            WorkflowInstance instance = null;

            try
            {
                instance = WorkflowInstance.EndLoad(result);
                instance.Extensions.Add(new WorkflowDefinitionExtension(connectionString));
                ConfigureExtensions(instance);
                AddInstance(new WorkflowInstanceState(instance, this));
                instance.BeginRun(new AsyncCallback(OnEndRunAfterLoad), instance);
            }
            catch (InstanceLockException)
            {
                //don't load any instances for which we cannot aquire the lock
                this.hostView.ErrorWriter.WriteLine("Could not load existing instance because it was Locked.");
                return;
            }
            catch (Exception e)
            {
                this.hostView.ErrorWriter.WriteLine("Could not load existing instance due to an Exception: " + e.ToString());
            }
        }

        void OnEndRunAfterLoad(IAsyncResult ar)
        {
            WorkflowInstance instance = ar.AsyncState as WorkflowInstance;

            try
            {
                instance.EndRun(ar);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured Resuming the instance after load: ", e);
            }
        }

        public void Close()
        {
            try
            {
                lock (closedLock)
                {
                    if (this.closed)
                    {
                        return;
                    }
                    else
                    {
                        this.closed = true;
                    }
                }

                List<WorkflowInstance> instances;

                lock (instanceStatesLock)
                {
                    instances = new List<WorkflowInstance>();
                    Guid[] keys = this.instanceStates.Keys.ToArray();
                    for (int index = 0; index < keys.Length; index++)
                    {
                        WorkflowInstanceState instanceState = this.instanceStates[keys[index]];
                        if (instanceState.IsLoaded)
                        {
                            instances.Add(instanceState.Instance);
                        }                        
                        instanceState.Close();
                        this.instanceStates.Remove(keys[index]);
                    }
                }

                Collection<IAsyncResult> unloadCalls = new Collection<IAsyncResult>();
                foreach (WorkflowInstance instance in instances)
                {

                    if (this.hostView.UsePersistence)
                    {
                        try
                        {
                            IAsyncResult ar = instance.BeginUnload(null, instance);
                            unloadCalls.Add(ar);
                        }
                        catch (Exception)
                        {
                            //swallow any exception - this is a best effort Close
                        }
                    }
                    else
                    {
                        instance.Abort();
                    }
                }

                //can't wait on multiple handles under an STA thread
                foreach (IAsyncResult ar in unloadCalls)
                {
                    ar.AsyncWaitHandle.WaitOne();
                    WorkflowInstance instance = ar.AsyncState as WorkflowInstance;
                    try
                    {
                        instance.EndUnload(ar);
                    }
                    catch (Exception)
                    {
                        //swallow any exception - this is a best effort Close
                    }
                }
                try
                {
                    if (this.persistenceProviderFactory != null)
                    {
                        this.persistenceProviderFactory.Close();
                    }
                }
                catch (Exception)
                {
                    //swallow any exception - this is a best effort Close
                }
            }
            catch (Exception e)
            {
                Debug.Assert(true, "Caught exception during Close: " + e.ToString());
            }
        }

        public void ResumeBookmark(Guid id, string bookmarkName, string value)
        {
            EnsureNotClosed();

            WorkflowInstanceState instanceState = null;

            lock (this.instanceStatesLock)
            {
                this.instanceStates.TryGetValue(id, out instanceState);
            }

            if (instanceState == null)
            {
                InstanceNoLongerPresent(id);
                return;
            }

            instanceState.CanResumeBookmarks = false;

            try
            {
                instanceState.Instance.BeginResumeBookmark(bookmarkName, value, new AsyncCallback(OnEndResumeBookmark), new object[] { instanceState.Instance, bookmarkName });
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(id, "An error occured Resuming Bookmark: " + bookmarkName, e);
            }
        }

        void OnEndResumeBookmark(IAsyncResult ar)
        {
            object[] asyncState = ar.AsyncState as object[];
            WorkflowInstance instance = asyncState[0] as WorkflowInstance;
            string bookmarkName = asyncState[1] as string;

            try
            {
                //it is possible the bookmark has been removed by some other event in the workflow
                //but that event will update the host - no need to do it here
                instance.EndResumeBookmark(ar);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured Resuming Bookmark: " + bookmarkName, e);
            }
        }

        public void Abort(Guid id, string reason)
        {
            EnsureNotClosed();
            WorkflowInstanceState instanceState = null;

            lock (this.instanceStatesLock)
            {
                this.instanceStates.TryGetValue(id, out instanceState);
            }

            if (instanceState == null)
            {
                //it is possible this instance has been removed by some other event in the workflow
                //nothing to do
                return;
            }

            instanceState.Instance.Abort(reason);
        }

        public void Cancel(Guid id)
        {
            EnsureNotClosed();
            WorkflowInstanceState instanceState = null;

            lock (this.instanceStatesLock)
            {
                this.instanceStates.TryGetValue(id, out instanceState);
            }

            if (instanceState == null)
            {
                InstanceNoLongerPresent(id);
                return;
            }

            instanceState.CanResumeBookmarks = false;

            try
            {
                instanceState.Instance.BeginCancel(new AsyncCallback(OnEndCancel), instanceState.Instance);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instanceState.Instance.Id, "An error occured during Cancelation", e);
            }
        }

        void OnEndCancel(IAsyncResult ar)
        {
            WorkflowInstance instance = ar.AsyncState as WorkflowInstance;

            try
            {
                instance.EndCancel(ar);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured during Cancelation", e);
            }
        }

        public void Terminate(Guid id, string reason)
        {
            EnsureNotClosed();
            WorkflowInstanceState instanceState = null;

            lock (this.instanceStatesLock)
            {
                this.instanceStates.TryGetValue(id, out instanceState);
            }

            if (instanceState == null)
            {
                InstanceNoLongerPresent(id);
                return;
            }

            instanceState.CanResumeBookmarks = false;

            try
            {
                instanceState.Instance.BeginTerminate(reason, new AsyncCallback(OnEndTerminate), instanceState.Instance);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instanceState.Instance.Id, "An error occured during Termination", e);
            }
        }

        void OnEndTerminate(IAsyncResult ar)
        {
            WorkflowInstance instance = ar.AsyncState as WorkflowInstance;

            try
            {
                instance.EndTerminate(ar);
            }
            catch (Exception e)
            {
                RemoveInstanceWithException(instance.Id, "An error occured during Termination", e);
            }
        }

        //handle events from the WorkflowInstance
        void IWorkflowInstanceHandler.OnAborted(WorkflowAbortedEventArgs e)
        {
            lock (closedLock)
            {
                if (!this.closed)
                {
                    this.hostView.Dispatch(() => RemoveInstance(e.InstanceId, "Instance was Aborted: " + e.Reason));
                }
            }
        }

        void IWorkflowInstanceHandler.OnCompleted(WorkflowCompletedEventArgs e)
        {
            lock (closedLock)
            {
                if (!this.closed)
                {
                    this.hostView.Dispatch(() => CompleteInstance(e.InstanceId, "Completed in the " + e.CompletionState.ToString() + " state"));
                }
            }
        }

        UnhandledExceptionAction IWorkflowInstanceHandler.OnUnhandledException(WorkflowUnhandledExceptionEventArgs e)
        {
            lock (closedLock)
            {
                if (!this.closed)
                {
                    WriteException(e.UnhandledException, string.Format("Exception encountered in activity {0}", e.ExceptionSource.DisplayName));
                }
            }

            return UnhandledExceptionAction.Terminate;
        }

        IdleAction IWorkflowInstanceHandler.OnIdle(Guid instanceId)
        {
            lock (closedLock)
            {
                if (!this.closed)
                {
                    this.hostView.Dispatch(() => UpdateInstanceState(instanceId, true));

                    return IdleAction.Persist;
                }
                else
                {
                    return IdleAction.Nothing;
                }
            }
        }

        bool TryLoadAndValidateProgram(string xamlPath, out WorkflowElement program)
        {
            program = null;

            try
            {
                program = LoadProgram(xamlPath);
            }
            catch (Exception e)
            {
                WriteException(e, "An error has occured loading the specified file: " + xamlPath);
                return false;
            }

            ValidationResults results = ActivityValidationServices.Validate(program);

            foreach (ConstraintViolation constraintViolation in results.AllViolations)
            {
                hostView.ErrorWriter.WriteLine("{0}: {1} Activity: {2}",
                    constraintViolation.IsWarning ? "warning" : "error",
                    constraintViolation.Message,
                    constraintViolation.ConstraintViolationSource.DisplayName);
            }

            if (results.GetErrors().Count > 0)
            {
                this.hostView.ErrorWriter.WriteLine("Could not run Workflow: " + xamlPath);
                this.hostView.ErrorWriter.WriteLine("There are validation errors");
                return false;
            }
            return true;
        }

        List<WorkflowInstanceInfo> BuildInstanceInfoList()
        {
            var instanceInfos = from instanceState in this.instanceStates.Values
                                select instanceState.AsWorkflowInstanceInfo();

            return new List<WorkflowInstanceInfo>(instanceInfos);
        }

        void RemoveInstance(Guid id, string message)
        {
            List<WorkflowInstanceInfo> instanceInfos = null;

            lock (instanceStatesLock)
            {
                this.instanceStates.Remove(id);
                instanceInfos = BuildInstanceInfoList();
            }

            this.hostView.UpdateInstances(instanceInfos);
        }

        void CompleteInstance(Guid id, string message)
        {
            List<WorkflowInstanceInfo> instanceInfos = null;

            lock (instanceStatesLock)
            {
                this.instanceStates[id].Close();
                instanceInfos = BuildInstanceInfoList();
            }

            this.hostView.UpdateInstances(instanceInfos);
        }

        void AddInstance(WorkflowInstanceState instanceState)
        {
            List<WorkflowInstanceInfo> instanceInfos = null;

            lock (instanceStatesLock)
            {
                this.instanceStates.Add(instanceState.Instance.Id, instanceState);
                instanceInfos = BuildInstanceInfoList();
            }

            this.hostView.UpdateInstances(instanceInfos);
        }

        void UpdateInstanceState(Guid id, bool isAvailable)
        {
            WorkflowInstanceState instanceState = null;

            lock (this.instanceStatesLock)
            {
                this.instanceStates.TryGetValue(id, out instanceState);
            }

            if (instanceState == null)
            {
                //any event that would result in the removal of the instance will have output the reason to the hostView
                return;
            }

            try
            {
                instanceState.AvailableBookmarks = instanceState.Instance.GetAllBookmarks();
            }
            catch (TimeoutException timeoutException)
            {
                RemoveInstanceWithException(id, "The request for available bookmarks timed out.", timeoutException);
            }
            catch (WorkflowInstanceException workflowInstanceException)
            {
                RemoveInstanceWithException(id, "The request for available bookmarks encountered an exception.", workflowInstanceException);
            }

            instanceState.CanResumeBookmarks = isAvailable;

            List<WorkflowInstanceInfo> instanceInfos = null;

            lock (this.instanceStatesLock)
            {
                instanceInfos = BuildInstanceInfoList();
            }

            this.hostView.UpdateInstances(instanceInfos);
        }

        PersistenceProvider CreatePersistenceProvider(Guid id)
        {
            if (this.persistenceProviderFactory == null)
            {
                try
                {
                    this.persistenceProviderFactory = new SqlPersistenceProviderFactory(connectionString, false, false, TimeSpan.FromSeconds(3600));
                    this.persistenceProviderFactory.Open();
                }
                catch
                {
                    this.persistenceProviderFactory = null;
                    throw;
                }
            }

            return this.persistenceProviderFactory.CreateProvider(id);
        }

        void ConfigureExtensions(WorkflowInstance instance)
        {
            instance.Extensions.Add(this.hostView.CreateInstanceWriter());

            TrackingParticipant participant = new TextWriterTrackingParticipant(this.hostView.OutputWriter);
            participant.TrackingProfile = CreateTrackingProfile();
            instance.Extensions.Add(participant);
        }

        TrackingProfile CreateTrackingProfile()
        {
            TrackingProfile trackingProfile = new TrackingProfile()
                {
                    Name = "CustomTrackingProfile",
                    Queries = 
                    {
                        new UserTrackingQuery() 
                        {
                         Name = "*",
                         ActivityName = "*"
                        },
                        new WorkflowInstanceQuery()
                        {
                            States = { "*" }
                        } 
                    }
                };

            if (this.hostView.UseActivityTracking)
            {
                trackingProfile.Queries.Add(
                    new ActivityQuery()
                        {

                            ActivityName = "*",
                            States = { "*" },

                            VariableQueries = 
                            {
                                new VariableQuery()
                                {
                                    VariableName = "*"
                                }   
                            }
                        });
                trackingProfile.Queries.Add(
                    new ActivityScheduledQuery() { ChildActivityName = "*" });
            }

            return trackingProfile;
        }

        WorkflowElement LoadProgram(string xamlPath)
        {
            FileStream stream = null;
            WorkflowElement workflowElement = null;

            try
            {
                stream = File.OpenRead(xamlPath);
                workflowElement = WorkflowXamlServices.Load(stream);
            }
            finally
            {
                stream.Close();
            }

            return workflowElement;
        }

        void EnsureNotClosed()
        {
            lock (this.closedLock)
            {
                if (this.closed)
                {
                    throw new InvalidOperationException("This WorkflowInstanceHost is Closed.");
                }
            }
        }

        void WriteException(Exception e)
        {
            WriteException(e, null);
        }

        void WriteException(Exception e, string preamble)
        {
            this.hostView.ErrorWriter.WriteLine(preamble + " " + e.Message);
        }

        void RemoveInstanceWithException(Guid id, string message, Exception e)
        {
            RemoveInstance(id, "Encountered an Exception");
            WriteException(e, message);
        }

        void InstanceNoLongerPresent(Guid id)
        {
            this.hostView.OutputWriter.WriteLine("The instance: " + id.ToString() + " is no longer available");
        }
    }
}

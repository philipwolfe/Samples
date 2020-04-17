//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Samples.WF.WorkflowInstances
{
    using System;
    using System.Activities;
    using System.Collections.ObjectModel;
    using System.IO;

    //Wraps a WorkflowInstance, used by WorkflowInstanceHost
    class WorkflowInstanceState
    {
        IWorkflowInstanceHandler instanceHandler;
        WorkflowInstance instance;
        ReadOnlyCollection<BookmarkInfo> availableBookmarks;
        TextWriter instanceWriter;
        bool isLoaded;

        public WorkflowInstanceState(WorkflowInstance instance, IWorkflowInstanceHandler instanceHandler)
        {
            this.instance = instance;
            this.instanceHandler = instanceHandler;
            this.isLoaded = true;

            this.instanceWriter = this.instance.GetExtension<TextWriter>();
            this.availableBookmarks = this.instance.GetAllBookmarks();

            instance.OnAborted = new Action<WorkflowAbortedEventArgs>(instanceHandler.OnAborted);
            instance.OnCompleted = new Action<WorkflowCompletedEventArgs>(instanceHandler.OnCompleted);
            instance.OnIdle = new Func<IdleAction>(OnIdle);
            instance.OnUnhandledException = new Func<WorkflowUnhandledExceptionEventArgs, UnhandledExceptionAction>(instanceHandler.OnUnhandledException);
            instance.OnUnloaded = new Action(OnUnloaded);
        }

        public WorkflowInstance Instance
        {
            get
            {
                return this.instance;
            }
        }

        public TextWriter InstanceWriter
        {
            get
            {
                return this.instanceWriter;
            }
        }

        public ReadOnlyCollection<BookmarkInfo> AvailableBookmarks
        {
            get
            {
                return this.availableBookmarks;
            }
            set
            {
                this.availableBookmarks = value;
            }
        }

        public bool CanResumeBookmarks { get; set; }

        public bool IsLoaded
        {
            get
            {
                return this.isLoaded;
            }
        }

        public WorkflowInstanceInfo AsWorkflowInstanceInfo()
        {
            return new WorkflowInstanceInfo
                {
                    Id = this.Instance.Id,
                    AvailableBookmarks = this.AvailableBookmarks,
                    CanResumeBookmarks = this.CanResumeBookmarks,
                    IsLoaded = this.IsLoaded,
                    InstanceWriter = this.InstanceWriter
                };
        }

        public void Close()
        {
            this.availableBookmarks = null;
            this.CanResumeBookmarks = false;
            this.instance.OnAborted = null;
            this.instance.OnCompleted = null;
            this.instance.OnIdle = null;
            this.instance.OnUnhandledException = null;
            this.instance.OnUnloaded = null;
            this.instanceHandler = null;
            this.isLoaded = false;
        }

        IdleAction OnIdle()
        {
            return this.instanceHandler.OnIdle(this.Instance.Id);
        }

        void OnUnloaded()
        {
            this.isLoaded = false;
        }
    }
}

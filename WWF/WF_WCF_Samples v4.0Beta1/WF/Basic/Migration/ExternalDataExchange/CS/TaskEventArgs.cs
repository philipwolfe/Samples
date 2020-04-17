//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.Interop
{
    using System;
    using System.Workflow.Activities;

    [Serializable]
    public class TaskEventArgs : ExternalDataEventArgs
    {
        string idValue;
        string assigneeValue;
        string textValue;

        public TaskEventArgs(Guid instanceId, string id, string assignee, string text)
            : base(instanceId)
        {
            this.idValue = id;
            this.assigneeValue = assignee;
            this.textValue = text;
        }

        public string Id
        {
            get { return this.idValue; }
            set { this.idValue = value; }
        }

        public string Assignee
        {
            get { return this.assigneeValue; }
            set { this.assigneeValue = value; }
        }

        public string Text
        {
            get { return this.textValue; }
            set { this.textValue = value; }
        }
    }
}

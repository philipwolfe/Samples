//---------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
namespace Microsoft.Samples.Workflow.Applications.DocumentReview
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;
    using System.Workflow.Runtime;
    using System.Workflow.Runtime.Messaging;

    /// <summary>
    /// This interface will be implemented by host
    /// to comminicate between host and workflow 
    /// </summary>
    [DataExchangeService]
    [CorrelationParameter("documentInfo")]
    public interface IDocumentReview
    {
        [CorrelationInitializer()]
        [CorrelationAlias("documentInfo", "e.DocumentInfo")]
        event EventHandler<DocumentInfoArgs> ReviewStarted;

        [CorrelationAlias("documentInfo", "e.DocumentInfo")]
        event EventHandler<DocumentInfoArgs> ParticipantsAdded;

        void ReviewCompleted(DocumentInfo documentInfo, Dictionary<string, string> reviewResults);
    }

    [Serializable]
    public class DocumentInfoArgs : WorkflowMessageEventArgs
    {
        private DocumentInfo documentInfo;
        private string[] participants;

        public DocumentInfoArgs(Guid instanceId, DocumentInfo documentInfo, string[] participants)
            : base(instanceId)
        {
            this.documentInfo = documentInfo;
            this.participants = participants;
        }

        public DocumentInfo DocumentInfo
        {
            get
            {
                return this.documentInfo;
            }
            set
            {
                this.documentInfo = value;
            }
        }

        public string[] Participants
        {
            get
            {
                return this.participants;
            }
            set
            {
                this.participants = value;
            }
        }
    }

    [Serializable]
    public class DocumentInfo
    {
        private string ownerName;
        private string documentUrl;

        public DocumentInfo(string ownerName, string documentUrl)
        {
            this.ownerName = ownerName;
            this.documentUrl = documentUrl;
        }

        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
            set
            {
                this.ownerName = value;
            }
        }

        public string DocumentUrl
        {
            get
            {
                return this.documentUrl;
            }
            set
            {
                this.documentUrl = value;
            }
        }

        /// <summary>
        /// This method is needed to make message based correlation work
        /// This object should be comparable by value, not an instance
        /// </summary>
        public override bool Equals(object obj)
        {
            DocumentInfo di = obj as DocumentInfo;

            if (di == null)
            {
                return false;
            }

            return (this.documentUrl == di.documentUrl) &&
                   (this.ownerName == di.ownerName);
        }

        /// <summary>
        /// This method is needed to make message based correlation work
        /// This object should be comparable by value, not an instance
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 0;

            if (this.ownerName != null)
                hash ^= this.ownerName.GetHashCode();

            if (this.documentUrl != null)
                hash ^= this.documentUrl.GetHashCode();

            if (hash == 0)
                hash = base.GetHashCode();

            return hash;
        }
    }

    public class DocumentReviewInterfaceImpl :  IDocumentReview
    {
        SubscriptionService subscriptionService;

        public DocumentReviewInterfaceImpl(SubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        public void ReviewCompleted(DocumentInfo documentInfo, Dictionary<string, string> reviewResults)
        {
            Console.WriteLine(
                "ReviewCompleted message received by host {0} {1}",
                documentInfo.OwnerName,
                documentInfo.DocumentUrl);

            StringBuilder resultMessage = new StringBuilder();

            resultMessage.AppendFormat(
                "Review for the document {0}, intiated by {1}, has completed. Click Ok to continue\n", 
                documentInfo.DocumentUrl, 
                documentInfo.OwnerName);

            foreach (string name in reviewResults.Keys)
            {
                resultMessage.AppendFormat(
                    "Reviewer name {0}, review result {1}\n", 
                    name, 
                    reviewResults[name]);
            }

            MessageBox.Show(resultMessage.ToString(), "Document review completed");
        }

        public event EventHandler<DocumentInfoArgs> ReviewStarted;
        public event EventHandler<DocumentInfoArgs> ParticipantsAdded;

        public void SubmitParticipantsAdded(DocumentInfo documentInfo, string[] participants)
        {
            try
            {
                if (this.ParticipantsAdded != null)
                {
                    Guid workflowInstanceId = this.subscriptionService.FindInstanceIdBySubscription(
                        typeof(IDocumentReview),
                        "ParticipantsAdded",
                        new string[] { "documentInfo" },
                        new object[] { documentInfo });

                    DocumentInfoArgs args = new DocumentInfoArgs(workflowInstanceId, documentInfo, participants);

                    this.ParticipantsAdded(null, args);
                }
            }
            catch (SubscriptionNotFoundException)
            {
                MessageBox.Show(
                    "The deadline for review responses has expired.",
                    "Message was not submitted");
            }
        }

        public void SubmitReviewStarted(Guid workflowInstanceId, DocumentInfo documentInfo, string[] participants)
        {
            // Check subscription exists
            this.subscriptionService.FindInstanceIdBySubscription(
                typeof(IDocumentReview),
                "ReviewStarted",
                new string[] { "documentInfo" },
                new object[] { documentInfo });

            DocumentInfoArgs args = new DocumentInfoArgs(
                workflowInstanceId,
                documentInfo,
                participants);

            if (ReviewStarted != null)
                ReviewStarted(null, args);
        }
    }
}

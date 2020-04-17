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
    using System.ComponentModel;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;
    using System.Workflow.Runtime;
    using System.Workflow.Runtime.Messaging;

    /// <summary>
    /// This interface will be implemented by host
    /// to communicate between host and workflow 
    /// </summary>
    [DataExchangeService]
    [CorrelationParameter("documentReviewInfo")]
    public interface IDocumentReviewTask
    {
        [CorrelationInitializer]
        void CreateDocumentReviewTask(DocumentReviewInfo documentReviewInfo);

        [CorrelationAlias("documentReviewInfo", "e.DocumentReviewInfo")]
        event EventHandler<DocumentReviewInfoArgs> DocumentReviewTaskCompleted;
    }

    [Serializable]
    public class DocumentReviewInfoArgs : WorkflowMessageEventArgs
    {
        DocumentReviewInfo documentInfo;
        string reviewOutcome;

        public DocumentReviewInfoArgs(Guid instanceId, DocumentReviewInfo documentInfo, string reviewOutcome)
            : base(instanceId)
        {
            this.documentInfo = documentInfo;
            this.reviewOutcome = reviewOutcome;
        }

        public DocumentReviewInfo DocumentReviewInfo
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

        public string ReviewOutcome
        {
            get
            {
                return this.reviewOutcome;
            }
            set
            {
                this.reviewOutcome = value;
            }
        }
    }
    
    [Serializable]
    public class DocumentReviewInfo
    {
        private string owner;
        private string documentUrl;
        private string reviewer;

        public DocumentReviewInfo(string owner, string documentUrl, string reviewer)
        {
            this.owner = owner;
            this.documentUrl = documentUrl;
            this.reviewer = reviewer;
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
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

        public string Reviewer
        {
            get
            {
                return this.reviewer;
            }
            set
            {
                this.reviewer = value;
            }
        }

        /// <summary>
        /// This method is needed to make message based correlation work
        /// This object should be comparable by value, not an instance
        /// </summary>
        public override bool Equals(object obj)
        {
            DocumentReviewInfo dri = obj as DocumentReviewInfo;

            if (dri == null)
            {
                return false;
            }

            return (this.owner == dri.owner) &&
                   (this.documentUrl == dri.documentUrl) &&
                   (this.reviewer == dri.reviewer);
        }

        /// <summary>
        /// This method is needed to make message based correlation work
        /// This object should be comparable by value, not an instance
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 0;

            if (this.owner != null)
                hash ^= this.owner.GetHashCode();

            if (this.documentUrl != null)
                hash ^= this.documentUrl.GetHashCode();

            if (this.reviewer != null)
                hash ^= this.reviewer.GetHashCode();

            if (hash == 0)
                hash = base.GetHashCode();

            return hash;
        }
    }

    public class DocumentReviewTaskImpl : IDocumentReviewTask
    {
        SubscriptionService subscriptionService;
        DocumentReviewInterfaceImpl docReviewImpl;

        public DocumentReviewTaskImpl(SubscriptionService subscriptionService, DocumentReviewInterfaceImpl docReviewImpl)
        {
            this.subscriptionService = subscriptionService;
            this.docReviewImpl = docReviewImpl;
        }

        public event EventHandler<DocumentReviewInfoArgs> DocumentReviewTaskCompleted;

        public void CreateDocumentReviewTask(DocumentReviewInfo documentReviewInfo)
        {
            Console.WriteLine(
                "CreateDocumentReviewTask received by host {0}, {1}, {2}",
                documentReviewInfo.Owner,
                documentReviewInfo.DocumentUrl,
                documentReviewInfo.Reviewer);

            // Display dialog and submit document signoff message
            //
            // Create a new thread for this method call, since the workflow 
            // should not be called back on it's own instance thread
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(PerformDocumentReview),
                documentReviewInfo);
        }

        public void PerformDocumentReview(object documentReviewInfoObject)
        {
            DocumentReviewInfo documentReviewInfo = (DocumentReviewInfo)documentReviewInfoObject;

            DialogResult result = MessageBox.Show(
                String.Format(
                    "Workflow created the document review task for {0}\nDocument {1} was submitted by {2}.\nSign off the document?",
                    documentReviewInfo.Reviewer,
                    documentReviewInfo.DocumentUrl,
                    documentReviewInfo.Owner),
                "Document sign off",
                MessageBoxButtons.YesNo);

            string reviewOutcome;

            if (result == DialogResult.Yes)
            {
                reviewOutcome = "Sign off";
            }
            else
            {
                reviewOutcome = "Reject";
            }

            // Add adhoc participants if reviewer is Mark
            if (documentReviewInfo.Reviewer == "Mark")
            {
                MessageBox.Show(
                    "Mark is adding additional reviewers Mary and Frank. Click Ok to proceed",
                    "Adding ad hoc participants");

                this.docReviewImpl.SubmitParticipantsAdded(
                    new DocumentInfo(documentReviewInfo.Owner, documentReviewInfo.DocumentUrl),
                    new string[] { "Mary", "Frank" });
            }

            try
            {
                // Submit review completed message
                if (this.DocumentReviewTaskCompleted != null)
                {
                    Guid workflowInstanceId = this.subscriptionService.FindInstanceIdBySubscription(
                        typeof(IDocumentReviewTask),
                        "DocumentReviewTaskCompleted",
                        new string[] { "documentReviewInfo" },
                        new object[] { documentReviewInfo });

                    DocumentReviewInfoArgs args = new DocumentReviewInfoArgs(
                        workflowInstanceId,
                        documentReviewInfo,
                        reviewOutcome);

                    this.DocumentReviewTaskCompleted(null, args);
                }
            }
            catch (SubscriptionNotFoundException)
            {
                MessageBox.Show(
                    "The deadline for review responses has expired.",
                    "Message was not submitted");
            }
        }
    }
}

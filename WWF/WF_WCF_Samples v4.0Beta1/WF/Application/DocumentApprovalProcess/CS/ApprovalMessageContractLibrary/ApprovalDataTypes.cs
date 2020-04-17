//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Microsoft.Samples.DocumentApprovalProcess.ApprovalMessageContractLibrary
{
    [MessageContract(IsWrapped=false)]
    public class ApprovalRequest
    {
        private String documentTitle;
        private String document;
        private String approvalType;
        private Guid id;
        private User requester;
        private int concurrentIndex;

        [MessageBodyMember]
        public String DocumentTitle
        {
            get { return documentTitle; }
            set { documentTitle = value; }
        }

        [MessageBodyMember]
        public String Document
        {
            get { return document; }
            set { document = value; }
        }

        [MessageBodyMember]
        public String ApprovalType
        {
            get { return approvalType; }
            set { approvalType = value; }
        }

        [MessageBodyMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        [MessageBodyMember]
        public User Requester
        {
            get { return requester; }
            set { requester = value; }
        }

        [MessageBodyMember]
        public int ConcurrentIndex
        {
            get { return concurrentIndex; }
            set { concurrentIndex = value; }
        }

        public ApprovalRequest(String dt, String d, String at, User re)
        {
            documentTitle = dt;
            document = d;
            approvalType = at;
            requester = re;
            concurrentIndex = 0;
            id = Guid.NewGuid();
        }

        public ApprovalRequest(ApprovalRequest old, int index)
        {
            documentTitle = old.documentTitle;
            document = old.document;
            approvalType = old.approvalType;
            requester = old.requester;
            concurrentIndex = index;
            id = old.id;
        }

        // Need default constructor to be serializable
        public ApprovalRequest()
        {

        }

        public override string ToString()
        {
            return "(Pending) " + documentTitle;
        }
    }

    [MessageContract(IsWrapped = false)]
    public class ApprovalResponse
    {
        private bool approved;
        private String documentTitle;
        private Guid id;
        private int concurrentIndex;

        [MessageBodyMember]
        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        [MessageBodyMember]
        public String DocumentTitle
        {
            get { return documentTitle; }
            set { documentTitle = value; }
        }

        [MessageBodyMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        [MessageBodyMember]
        public int ConcurrentIndex
        {
            get { return concurrentIndex; }
            set { concurrentIndex = value; }
        }

        public ApprovalResponse(ApprovalRequest request, bool ap)
        {
            id = request.Id;
            documentTitle = request.DocumentTitle;
            approved = ap;
            concurrentIndex = request.ConcurrentIndex;
        }

        // Need default constructor to be serializable
        public ApprovalResponse()
        {

        }

        public override string ToString()
        {
            if (approved)
            {
                return "(Approved)" + documentTitle;
            }
            else
            {
                return "(Rejected)" + documentTitle;
            }
        }
    }
}

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
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.Runtime;
    using System.Workflow.ComponentModel.Compiler;

    #region ReviewStarted
    /// <summary>
    /// Summary description for ReviewStarted.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public sealed class ReviewStarted : EventSinkActivity
    {
        public ReviewStarted()
        {
            this.InterfaceType = typeof(IDocumentReview);
            this.EventName = "ReviewStarted";
        }

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public override ActivityBind CorrelationReference
        {
            get
            {
                return base.CorrelationReference;
            }
            set
            {
                base.CorrelationReference = value;
            }
        }
        
        public static DependencyProperty OwnerNameProperty = DependencyProperty.Register("OwnerName", typeof(String), typeof(ReviewStarted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String OwnerName
        {
            get
            {
                return ((String)(base.GetValue(ReviewStarted.OwnerNameProperty)));
            }
            set
            {
                base.SetValue(ReviewStarted.OwnerNameProperty, value);
            }
        }

        public static DependencyProperty DocumentUrlProperty = DependencyProperty.Register("DocumentUrl", typeof(String), typeof(ReviewStarted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String DocumentUrl
        {
            get
            {
                return ((String)(base.GetValue(ReviewStarted.DocumentUrlProperty)));
            }
            set
            {
                base.SetValue(ReviewStarted.DocumentUrlProperty, value);
            }
        }

        public static DependencyProperty ParticipantsProperty = DependencyProperty.Register("Participants", typeof(String[]), typeof(ReviewStarted));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String[] Participants
        {
            get
            {
                return ((String[])(base.GetValue(ReviewStarted.ParticipantsProperty)));
            }
            set
            {
                base.SetValue(ReviewStarted.ParticipantsProperty, value);
            }
        }     
        protected override void Initialize(IServiceProvider provider)
        {
            IDocumentReview hostInterface = provider.GetService(typeof(IDocumentReview)) as IDocumentReview;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
            hostInterface.ReviewStarted += new EventHandler<DocumentInfoArgs>(this.OnReviewStarted);
        }

        private void OnReviewStarted(object sender, DocumentInfoArgs args)
        {
            this.OwnerName = args.DocumentInfo.OwnerName;
            this.DocumentUrl = args.DocumentInfo.DocumentUrl;
            this.Participants = args.Participants;
        }
    }
    #endregion // ReviewStarted

    #region ParticipantsAdded
    /// <summary>
    /// Summary description for ParticipantsAdded.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    public sealed class ParticipantsAdded : EventSinkActivity
    {
        public ParticipantsAdded()
        {
            this.EventName = "ParticipantsAdded";
            this.InterfaceType = typeof(IDocumentReview);
        }

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public override ActivityBind CorrelationReference
        {
            get
            {
                return base.CorrelationReference;
            }
            set
            {
                base.CorrelationReference = value;
            }
        }

        public static DependencyProperty OwnerNameProperty = System.Workflow.ComponentModel.DependencyProperty.Register("OwnerName", typeof(String), typeof(ParticipantsAdded));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String OwnerName
        {
            get
            {
                return ((String)(base.GetValue(ParticipantsAdded.OwnerNameProperty)));
            }
            set
            {
                base.SetValue(ParticipantsAdded.OwnerNameProperty, value);
            }
        }


        public static DependencyProperty DocumentUrlProperty = System.Workflow.ComponentModel.DependencyProperty.Register("DocumentUrl", typeof(String), typeof(ParticipantsAdded));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String DocumentUrl
        {
            get
            {
                return ((String)(base.GetValue(ParticipantsAdded.DocumentUrlProperty)));
            }
            set
            {
                base.SetValue(ParticipantsAdded.DocumentUrlProperty, value);
            }
        }

        public static DependencyProperty ParticipantsProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Participants", typeof(String[]), typeof(ParticipantsAdded));

        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public String[] Participants
        {
            get
            {
                return ((String[])(base.GetValue(ParticipantsAdded.ParticipantsProperty)));
            }
            set
            {
                base.SetValue(ParticipantsAdded.ParticipantsProperty, value);
            }
        }

        protected override void Initialize(IServiceProvider provider)
        {
            IDocumentReview hostInterface = provider.GetService(typeof(IDocumentReview)) as IDocumentReview;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
            hostInterface.ParticipantsAdded += new EventHandler<DocumentInfoArgs>(this.OnParticipantsAdded);
        }

        private void OnParticipantsAdded(object sender, DocumentInfoArgs args)
        {
            this.OwnerName = args.DocumentInfo.OwnerName;
            this.DocumentUrl = args.DocumentInfo.DocumentUrl;
            this.Participants = args.Participants;
        }
    }
    #endregion // ParticipantsAdded
}

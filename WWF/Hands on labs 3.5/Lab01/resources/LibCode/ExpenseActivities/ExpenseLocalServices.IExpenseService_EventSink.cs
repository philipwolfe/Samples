//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

namespace ExpenseActivities
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Collections;
    using System.Drawing;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.Activities;
    using System.Workflow.Runtime;
    using ExpenseLocalServices;
    
    
    /// <summary>
    /// Summary description for ExpenseReportSubmitted.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [ExecutorAttribute(typeof(ExpenseReportSubmittedExecutor))]
	[DesignerAttribute(typeof(ExpenseReportSubmittedDesigner), typeof(IDesigner))]
	[ToolboxBitmap(typeof(ExpenseReportSubmitted), "Resources.Created.bmp")]
    public sealed class ExpenseReportSubmitted : EventSinkActivity
    {
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override System.Type InterfaceType
        {
            get
            {
                return typeof(IExpenseService);
            }
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string EventName
        {
            get
            {
                return "ExpenseReportSubmitted";
            }
        }
        
        public static DependencyProperty SenderProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Sender", typeof(Object), typeof(ExpenseReportSubmitted));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public Object Sender
        {
            get
            {
                return ((Object)(base.GetValue(ExpenseReportSubmitted.SenderProperty)));
            }
            set
            {
                base.SetValue(ExpenseReportSubmitted.SenderProperty, value);
            }
        }
        
        public static DependencyProperty EProperty = System.Workflow.ComponentModel.DependencyProperty.Register("E", typeof(ExpenseReportSubmittedEventArgs), typeof(ExpenseReportSubmitted));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public ExpenseReportSubmittedEventArgs E
        {
            get
            {
                return ((ExpenseReportSubmittedEventArgs)(base.GetValue(ExpenseReportSubmitted.EProperty)));
            }
            set
            {
                base.SetValue(ExpenseReportSubmitted.EProperty, value);
            }
        }
    }
    
    /// <summary>
    /// Summary description for ExpenseReportSubmittedExecutor.
    /// This is the runtime activity executor class. It must support a default ctor.
    /// A single instance of the executor is shared across multiple instances of the workflow running within a single host application.
    /// </summary>
    public sealed class ExpenseReportSubmittedExecutor : EventSinkActivityExecutor<ExpenseReportSubmitted>
    {
        
        protected override void Initialize(ExpenseReportSubmitted activity, System.Workflow.ComponentModel.ActivityExecutionContext provider)
        {
            base.Initialize(activity, provider);
			IExpenseService hostInterface = provider.GetService(typeof(IExpenseService)) as IExpenseService;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
            hostInterface.ExpenseReportSubmitted += new EventHandler<ExpenseLocalServices.ExpenseReportSubmittedEventArgs>(this.OnExpenseReportSubmitted);
        }
        
        private void OnExpenseReportSubmitted(object sender, ExpenseLocalServices.ExpenseReportSubmittedEventArgs e)
        {
            System.Workflow.ComponentModel.ActivityExecutionContext context = WorkflowServiceContext.ActivityExecutionContext;
            if ((context == null))
            {
                throw new System.InvalidOperationException();
            } 
            ExpenseReportSubmitted activity = ((ExpenseReportSubmitted)(context.Activity));
            activity.Sender = sender;
            activity.E = e;
        }
    }

	[Theme(typeof(ActivityDesignerTheme),
	   Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
							"<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
				" ApplyTo=\"OrderServiceLibrary.OrderCreatedDesigner\"" +
				" ForeColor=\"0xFF000000\"" +
				" BorderColor=\"0xFF128BE7\" BorderStyle=\"Solid\"" +
				" BackColorStart=\"0xFFFFFFFF\" BackColorEnd=\"0xFFB8CAEF\" BackgroundStyle=\"Vertical\"" +
				 " />")]
	public sealed class ExpenseReportSubmittedDesigner : ActivityDesigner
	{
	}

    
    /// <summary>
    /// Summary description for ExpenseReportReviewed.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
    [ExecutorAttribute(typeof(ExpenseReportReviewedExecutor))]
	[DesignerAttribute(typeof(ExpenseReportReviewedDesigner), typeof(IDesigner))]
	[ToolboxBitmap(typeof(ExpenseReportReviewed), "Resources.Reviewed.bmp")]
	public sealed class ExpenseReportReviewed : EventSinkActivity
    {
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override System.Type InterfaceType
        {
            get
            {
                return typeof(IExpenseService);
            }
        }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string EventName
        {
            get
            {
                return "ExpenseReportReviewed";
            }
        }
        
        public static DependencyProperty SenderProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Sender", typeof(Object), typeof(ExpenseReportReviewed));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public Object Sender
        {
            get
            {
                return ((Object)(base.GetValue(ExpenseReportReviewed.SenderProperty)));
            }
            set
            {
                base.SetValue(ExpenseReportReviewed.SenderProperty, value);
            }
        }
        
        public static DependencyProperty EProperty = System.Workflow.ComponentModel.DependencyProperty.Register("E", typeof(ExpenseReportReviewedEventArgs), typeof(ExpenseReportReviewed));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public ExpenseReportReviewedEventArgs E
        {
            get
            {
                return ((ExpenseReportReviewedEventArgs)(base.GetValue(ExpenseReportReviewed.EProperty)));
            }
            set
            {
                base.SetValue(ExpenseReportReviewed.EProperty, value);
            }
        }
    }
    
    /// <summary>
    /// Summary description for ExpenseReportReviewedExecutor.
    /// This is the runtime activity executor class. It must support a default ctor.
    /// A single instance of the executor is shared across multiple instances of the workflow running within a single host application.
    /// </summary>
	public sealed class ExpenseReportReviewedExecutor : EventSinkActivityExecutor<ExpenseReportReviewed>
    {
        
        protected override void Initialize(ExpenseReportReviewed activity, System.Workflow.ComponentModel.ActivityExecutionContext provider)
        {
            base.Initialize(activity, provider);
			IExpenseService hostInterface = provider.GetService(typeof(IExpenseService)) as IExpenseService;
            if ((hostInterface == null))
            {
                throw new System.InvalidOperationException();
            }
			hostInterface.ExpenseReportReviewed += new EventHandler<ExpenseLocalServices.ExpenseReportReviewedEventArgs>(this.OnExpenseReportReviewed);
        }
        
        private void OnExpenseReportReviewed(object sender, ExpenseLocalServices.ExpenseReportReviewedEventArgs e)
        {
            System.Workflow.ComponentModel.ActivityExecutionContext context = WorkflowServiceContext.ActivityExecutionContext;
            if ((context == null))
            {
                throw new System.InvalidOperationException();
            }
            ExpenseReportReviewed activity = ((ExpenseReportReviewed)(context.Activity));
            activity.Sender = sender;
            activity.E = e;
        }
    }



	[Theme(typeof(ActivityDesignerTheme),
	  Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
						   "<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
			   " ApplyTo=\"OrderServiceLibrary.OrderCreatedDesigner\"" +
			   " ForeColor=\"0xFF000000\"" +
			   " BorderColor=\"0xFF128BE7\" BorderStyle=\"Solid\"" +
			   " BackColorStart=\"0xFFFFFFFF\" BackColorEnd=\"0xFFB8CAEF\" BackgroundStyle=\"Vertical\"" +
				" />")]
	public sealed class ExpenseReportReviewedDesigner : ActivityDesigner
	{
	}

}

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
    /// Summary description for ApproveExpenseReport.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
	[DesignerAttribute(typeof(ApproveExpenseReportDesigner), typeof(IDesigner))]
	[ToolboxBitmap(typeof(ApproveExpenseReport), "Resources.Approved.bmp")]
	public sealed class ApproveExpenseReport : InvokeMethodActivity
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
        public override string MethodName
        {
            get
            {
                return "ApproveExpenseReport";
            }
        }
        
        public static DependencyProperty ReportProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Report", typeof(ExpenseReport), typeof(ApproveExpenseReport));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public ExpenseReport Report
        {
            get
            {
                return ((ExpenseReport)(base.GetValue(ApproveExpenseReport.ReportProperty)));
            }
            set
            {
                base.SetValue(ApproveExpenseReport.ReportProperty, value);
            }
        }


		protected override Status Execute(ActivityExecutionContext context)
		{
			IExpenseService hostInterface = context.GetService(typeof(IExpenseService)) as IExpenseService;
			if ((hostInterface == null))
			{
				throw new System.InvalidOperationException();
			}
			hostInterface.ApproveExpenseReport(this.Report);
			return System.Workflow.ComponentModel.Status.Closed;
		}
	}
    
	///// <summary>
	///// Summary description for ApproveExpenseReportExecutor.
	///// This is the runtime activity executor class. It must support a default ctor.
	///// A single instance of the executor is shared across multiple instances of the workflow running within a single host application.
	///// </summary>
	//public sealed class ApproveExpenseReportExecutor : InvokeBaseExecutor<ApproveExpenseReport>
	//{
        
	//    protected override System.Workflow.ComponentModel.Status Execute(ApproveExpenseReport activity, System.Workflow.ComponentModel.ActivityExecutionContext provider)
	//    {
	//        base.Execute(activity, provider);
	//        IExpenseService hostInterface = provider.GetService(typeof(IExpenseService)) as IExpenseService;
	//        if ((hostInterface == null))
	//        {
	//            throw new System.InvalidOperationException();
	//        }
	//        hostInterface.ApproveExpenseReport(activity.Report);
	//        return System.Workflow.ComponentModel.Status.Closed;
	//    }
	//}


	[Theme(typeof(ActivityDesignerTheme), 
		Xml="<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
				"<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
				 " ApplyTo=\"OrderActivities.ApproveOrderDesigner\"" +
				 " ForeColor=\"0xFF000000\"" +
				 " BorderColor=\"0xFF4B9515\" BorderStyle=\"Solid\"" +
				 " BackColorStart=\"0xFFFFFFFF\" BackColorEnd=\"0xFFB4EE88\" BackgroundStyle=\"Vertical\"" +
				  " />")]
	public sealed class ApproveExpenseReportDesigner : ActivityDesigner
	{
	}



	/// <summary>
	/// Summary description for RejectExpenseReport.
	/// This is a designtime activity class.
	/// </summary>
	[ToolboxItemAttribute(typeof(ActivityToolboxItem))]
	[DesignerAttribute(typeof(RejectExpenseReportDesigner), typeof(IDesigner))]
	[ToolboxBitmap(typeof(RejectExpenseReport), "Resources.Rejected.bmp")]
	public sealed class RejectExpenseReport : InvokeMethodActivity
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
		public override string MethodName
		{
			get
			{
				return "RejectExpenseReport";
			}
		}

		public static DependencyProperty ReportProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Report", typeof(ExpenseReport), typeof(RejectExpenseReport));

		[ValidationVisibilityAttribute(ValidationVisibility.Required)]
		public ExpenseReport Report
		{
			get
			{
				return ((ExpenseReport)(base.GetValue(RejectExpenseReport.ReportProperty)));
			}
			set
			{
				base.SetValue(RejectExpenseReport.ReportProperty, value);
			}
		}

		protected override Status Execute(ActivityExecutionContext context)
		{
			IExpenseService hostInterface = context.GetService(typeof(IExpenseService)) as IExpenseService;
			if ((hostInterface == null))
			{
				throw new System.InvalidOperationException();
			}
			hostInterface.RejectExpenseReport(this.Report);
			return System.Workflow.ComponentModel.Status.Closed;
		}
	}

	///// <summary>
	///// Summary description for RejectExpenseReportExecutor.
	///// This is the runtime activity executor class. It must support a default ctor.
	///// A single instance of the executor is shared across multiple instances of the workflow running within a single host application.
	///// </summary>
	//public sealed class RejectExpenseReportExecutor : InvokeBaseExecutor<RejectExpenseReport>
	//{

	//    protected override System.Workflow.ComponentModel.Status Execute(RejectExpenseReport activity, System.Workflow.ComponentModel.ActivityExecutionContext provider)
	//    {
	//        base.Execute(activity, provider);
	//        IExpenseService hostInterface = provider.GetService(typeof(IExpenseService)) as IExpenseService;
	//        if ((hostInterface == null))
	//        {
	//            throw new System.InvalidOperationException();
	//        }
	//        hostInterface.RejectExpenseReport(activity.Report);
	//        return System.Workflow.ComponentModel.Status.Closed;
	//    }
	//}


	[Theme(typeof(ActivityDesignerTheme),
		Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
				"<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
				 " ApplyTo=\"OrderActivities.RejectOrderDesigner\"" +
				 " ForeColor=\"0xFF000000\"" +
				 " BorderColor=\"0xFF4B9515\" BorderStyle=\"Solid\"" +
				 " BackColorStart=\"0xFFFFFFFF\" BackColorEnd=\"0xFFB4EE88\" BackgroundStyle=\"Vertical\"" +
				  " />")]
	public sealed class RejectExpenseReportDesigner : ActivityDesigner
	{
	}

    /// <summary>
    /// Summary description for RequestManagerApproval.
    /// This is a designtime activity class.
    /// </summary>
    [ToolboxItemAttribute(typeof(ActivityToolboxItem))]
	[DesignerAttribute(typeof(RequestManagerApprovalDesigner), typeof(IDesigner))]
	[ToolboxBitmap(typeof(RequestManagerApproval), "Resources.AskForManagerApproval.bmp")]
    public sealed class RequestManagerApproval : InvokeMethodActivity
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
        public override string MethodName
        {
            get
            {
                return "RequestManagerApproval";
            }
        }
        
        public static DependencyProperty ReportProperty = System.Workflow.ComponentModel.DependencyProperty.Register("Report", typeof(ExpenseReport), typeof(RequestManagerApproval));
        
        [ValidationVisibilityAttribute(ValidationVisibility.Required)]
        public ExpenseReport Report
        {
            get
            {
                return ((ExpenseReport)(base.GetValue(RequestManagerApproval.ReportProperty)));
            }
            set
            {
                base.SetValue(RequestManagerApproval.ReportProperty, value);
            }
        }

		public static DependencyProperty ManagerEmployeeIdProperty = DependencyProperty.Register("ManagerEmployeeId", typeof(System.String), typeof(ExpenseActivities.RequestManagerApproval));

		[DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
		[ValidationVisibilityAttribute(ValidationVisibility.Required)]
		[BrowsableAttribute(true)]
		public String ManagerEmployeeId
		{
			get
			{
				return ((string)(base.GetValue(ExpenseActivities.RequestManagerApproval.ManagerEmployeeIdProperty)));
			}
			set
			{
				base.SetValue(ExpenseActivities.RequestManagerApproval.ManagerEmployeeIdProperty, value);
			}
		}


		protected override Status Execute(ActivityExecutionContext context)
		{
			IExpenseService hostInterface = context.GetService(typeof(IExpenseService)) as IExpenseService;
			if ((hostInterface == null))
			{
				throw new System.InvalidOperationException();
			}
			hostInterface.RequestManagerApproval(this.Report, this.ManagerEmployeeId);
			return System.Workflow.ComponentModel.Status.Closed;
		}
	}
    
	///// <summary>
	///// Summary description for RequestManagerApprovalExecutor.
	///// This is the runtime activity executor class. It must support a default ctor.
	///// A single instance of the executor is shared across multiple instances of the workflow running within a single host application.
	///// </summary>
	//public sealed class RequestManagerApprovalExecutor : InvokeBaseExecutor<RequestManagerApproval>
	//{
        
	//    protected override System.Workflow.ComponentModel.Status Execute(RequestManagerApproval activity, System.Workflow.ComponentModel.ActivityExecutionContext provider)
	//    {
	//        base.Execute(activity, provider);
	//        IExpenseService hostInterface = provider.GetService(typeof(IExpenseService)) as IExpenseService;
	//        if ((hostInterface == null))
	//        {
	//            throw new System.InvalidOperationException();
	//        }
	//        hostInterface.RequestManagerApproval(activity.Report, activity.ManagerEmployeeId);
	//        return System.Workflow.ComponentModel.Status.Closed;
	//    }
	//}


	[Theme(typeof(ActivityDesignerTheme),
	   Xml = "<?Mapping XmlNamespace=\"ComponentModel\" ClrNamespace=\"System.Workflow.ComponentModel.Design\" Assembly=\"System.Workflow.ComponentModel\" ?>" +
							"<ActivityDesignerTheme xmlns=\"ComponentModel\"" +
				" ApplyTo=\"OrderServiceLibrary.AskForManagerApprovalDesigner\"" +
				" ForeColor=\"0xFF000000\"" +
				" BorderColor=\"0xFF4D9FE1\" BorderStyle=\"Solid\"" +
				" BackColorStart=\"0xFFFFFFFF\" BackColorEnd=\"0xFFD2ECFF\" BackgroundStyle=\"Vertical\"" +
				 " />")]
	public sealed class RequestManagerApprovalDesigner : ActivityDesigner
	{
	}

}

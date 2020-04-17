using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace ExpenseWorkflows
{
    public partial class Workflow1 : SequentialWorkflowActivity
    {
        public ExpenseLocalServices.ExpenseReportSubmittedEventArgs reportArgs = default(ExpenseLocalServices.ExpenseReportSubmittedEventArgs);
        public ExpenseLocalServices.ExpenseReportReviewedEventArgs reviewArgs = default(ExpenseLocalServices.ExpenseReportReviewedEventArgs);
        
        public int amount = default(System.Int32);
        public string ReportEmployeeId = default(System.String);
        public string ManagerEmployeeId = default(System.String);
        
        private void ReportSubmitted_Invoked(object sender, ExternalDataEventArgs e)
        {
            Console.WriteLine("ReportSubmitted_Invoked");
            this.amount = this.reportArgs.Report.Amount;
            this.ReportEmployeeId = this.reportArgs.Report.EmployeeId;
        }

        private void IfReportApproved_Condition(object sender, ConditionalEventArgs e)
        {
            e.Result = this.reviewArgs.Review.Approved;
        }
    }
}

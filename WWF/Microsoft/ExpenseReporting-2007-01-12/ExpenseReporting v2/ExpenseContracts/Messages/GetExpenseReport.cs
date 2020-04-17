using System;
using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class GetExpenseReportRequest
    {
        private Guid expenseReportId;

        public GetExpenseReportRequest(Guid expenseReportId)
        {
            this.expenseReportId = expenseReportId;
        }

        [DataMember]
        public Guid ExpenseReportId
        {
            get
            {
                return expenseReportId;
            }
            set
            {
                expenseReportId = value;
            }
        }
    }

    [DataContract]
    public class GetExpenseReportResponse
    {
        private ExpenseReport report;

        public GetExpenseReportResponse(ExpenseReport report)
        {
            this.report = report;
        }

        [DataMember]
        public ExpenseReport Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class SubmitExpenseReportRequest
    {
        private ExpenseReport report;

        public SubmitExpenseReportRequest(ExpenseReport report)
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

    [DataContract]
    public class SubmitExpenseReportResponse
    {
        private Guid id;

        public SubmitExpenseReportResponse(Guid id)
        {
            this.id = id;
        }

        [DataMember]
        public Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}

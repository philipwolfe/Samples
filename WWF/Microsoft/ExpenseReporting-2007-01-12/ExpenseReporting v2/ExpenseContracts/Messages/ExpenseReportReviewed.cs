using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class ExpenseReportReviewedRequest
    {
        private ExpenseReport report;

        public ExpenseReportReviewedRequest(ExpenseReport report)
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

using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class ExpenseReportSubmittedRequest
    {
        private ExpenseReport report;

        public ExpenseReportSubmittedRequest(ExpenseReport report)
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

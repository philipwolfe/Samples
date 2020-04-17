using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class GetExpenseReportsResponse
    {
        private List<ExpenseReport> reports;

        public GetExpenseReportsResponse(List<ExpenseReport> reports)
        {
            this.reports = reports;
        }

        [DataMember]
        public List<ExpenseReport> Reports
        {
            get
            {
                return reports;
            }
            set
            {
                reports = value;
            }
        }
    }
}

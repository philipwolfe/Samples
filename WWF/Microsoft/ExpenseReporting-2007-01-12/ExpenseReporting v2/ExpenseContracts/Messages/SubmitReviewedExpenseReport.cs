using System;
using System.Runtime.Serialization;

namespace ExpenseContracts
{
    [DataContract]
    public class SubmitReviewedExpenseReportRequest
    {
        private ExpenseReport report;
        private ExpenseReportReview review;

        public SubmitReviewedExpenseReportRequest(ExpenseReport report, ExpenseReportReview review)
        {
            this.report = report;
            this.review = review;
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

        [DataMember]
        public ExpenseReportReview Review
        {
            get
            {
                return review;
            }
            set
            {
                review = value;
            }
        }
    }

    [DataContract]
    public class SubmitReviewedExpenseReportResponse
    {
        private Guid id;

        public SubmitReviewedExpenseReportResponse(Guid id)
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

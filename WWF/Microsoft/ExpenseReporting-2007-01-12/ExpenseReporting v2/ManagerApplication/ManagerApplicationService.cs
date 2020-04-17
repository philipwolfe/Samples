using ExpenseContracts;

namespace ManagerApplication
{
    public class ManagerApplicationService : IExpenseServiceManagerApplication
    {
        #region IExpenseServiceManagerApplication Members

        public void ExpenseReportSubmitted(ExpenseReportSubmittedRequest expenseReportSubmittedRequest)
        {
            ManagerForm.Form.CreateListViewItem(expenseReportSubmittedRequest.Report);
        }
       
        public void ExpenseReportReviewed(ExpenseReportReviewedRequest expenseReportReviewedRequest)
        {
            ManagerForm.Form.CreateListViewItem(expenseReportReviewedRequest.Report);
        }

        #endregion
    }
}

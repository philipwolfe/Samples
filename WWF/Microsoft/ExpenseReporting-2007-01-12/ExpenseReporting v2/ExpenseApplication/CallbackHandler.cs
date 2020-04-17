using ExpenseContracts;

namespace ExpenseApplication
{
    class CallbackHandler : IExpenseServiceClientCallback
    {
        #region IExpenseServiceClientCallback Members

        /// <summary>
        /// Updates the client view with the updated report data following a review having
        /// been done on this expense report
        /// </summary>
        /// <remarks>This function will be called back through a ClientCallback channel by the host</remarks>
        public void ExpenseReportReviewed(ExpenseReportReviewedRequest expenseReportReviewedRequest)
        {
            Program.ClientForm.CreateListViewItem(expenseReportReviewedRequest.Report);
        }

        #endregion
    }
}

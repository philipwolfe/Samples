using System;

namespace ExpenseApproval
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ExpenseApproval
	{
		public ExpenseApproval()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public string ApproveExpense(double ExpenseAmount,string ExpenseType)
		{
			double MaxNonApprovalAmount = 250.01;
			//*** Version 2 code
			//double MaxTrainingNonApprovalAmount = 2500.01;
			//*** End Version 2 code

			//*** Version 1 Code
			if ((ExpenseAmount > MaxNonApprovalAmount))
			{
				return "Expense Sent to Management for Approval.";
			}
			else
			{
				return "Expense Approved.";
			}
            //*** End Version 1 Code


			//***Version 2 Code
//			if ((ExpenseAmount < MaxTrainingNonApprovalAmount) && (ExpenseType == "Training"))
//			{
//				return "Expense Approved";
//			}
//			else if (((ExpenseAmount >= MaxTrainingNonApprovalAmount) && (ExpenseType == "Training Class")) || (ExpenseAmount >= MaxNonApprovalAmount))
//			{
//				return "Expense sent to Management for Approval.";
//			}
//			else
//			{
//				return "Expense Approved.";
//			}
           //***End Version 2 Code


		}

	}
}

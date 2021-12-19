Visual Basic.NET - Versioning


To install and run the Versioning sample:

1.  Open the ExpenseApproval.sln file

2.  Press F5 to run ExpenseClientVersion1

	Note:  If you receive build errors, you will have to remove and re-add the ExpenseApproval component references for both client projects. 
	- ExpenseClientVersion1 should reference ExpenseApproval\bin\Version1\ExpenseApproval.dll
	- ExpenseClientVersion2 should reference ExpenseApproval\bin\Version2\ExpenseApproval.dll

3.  Enter an expense amount over $250 for any category and you will see a message box stating that the expense was sent to management for approval.

4.  Right click on the ExpenseclientVersion2 project in the Solution Explorer and choose Set as Startup Project

5.  Press F5 to run ExpenseClientVersion2

6.  Enter an expense amount over $250 but less than $2500 for the training category and you will see a message box stating that the expense was approved.


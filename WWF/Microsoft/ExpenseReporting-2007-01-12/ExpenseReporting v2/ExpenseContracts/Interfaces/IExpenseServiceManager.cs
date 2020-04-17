//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System.ServiceModel;

namespace ExpenseContracts
{
    [ServiceContract(/*CallbackContract = typeof(IExpenseServiceManagerApplication)*/)]
    public interface IExpenseServiceManager : IExpenseService
    {
        [OperationContract]
        SubmitReviewedExpenseReportResponse SubmitReviewedExpenseReport(
            SubmitReviewedExpenseReportRequest submitReviewedExpenseReportRequest);
    }
}
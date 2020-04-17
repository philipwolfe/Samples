//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

using Microsoft.ApplicationBlocks.Data;

namespace AtomicTransactionWorkflow
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        string sqlConnection = System.Configuration.ConfigurationManager.AppSettings["connectionString"];

        public Workflow1()
        {
            InitializeComponent();
        }

        private void DebitCodeHandler(object sender, EventArgs e)
        {
            SqlHelper.ExecuteNonQuery(sqlConnection,
                             System.Data.CommandType.Text,
                             "use bank update ChequeAccount set Balance = Balance - 100");

            Console.WriteLine(SqlHelper.ExecuteScalar(sqlConnection,
                              System.Data.CommandType.Text,
                              "use bank select Balance from ChequeAccount"));
        }

        private void CreditCodeHandler(object sender, EventArgs e)
        {
            SqlHelper.ExecuteNonQuery(sqlConnection,
                                      System.Data.CommandType.Text,
                                      "use bank update SavingsAccount set Balance = Balance + 100");

            Console.WriteLine(SqlHelper.ExecuteScalar(sqlConnection,
                              System.Data.CommandType.Text,
                              "use bank select Balance from SavingsAccount"));
        }

        public Exception exception = new System.Exception();

        private void OnFinishWorkflow(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow completed");
        }


        private void OnException(object sender, EventArgs e)
        {
            Console.WriteLine("Handling Application Exception and Rollback");
        }

        private void OnCompensation(object sender, EventArgs e)
        {
            SqlHelper.ExecuteNonQuery(sqlConnection,
                                      System.Data.CommandType.Text,
                                      "use bank update SavingsAccount set Balance = Balance - 100");

            SqlHelper.ExecuteNonQuery(sqlConnection,
                                      System.Data.CommandType.Text,
                                      "use bank update ChequeAccount set Balance = Balance + 100");

            Console.WriteLine("Compensated the transaction");
        }
    }
}



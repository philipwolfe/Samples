//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Transactions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", SessionMode = SessionMode.Required)]
    public interface ICalculator
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        double Add(double n);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        double Subtract(double n);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        double Multiply(double n);
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        double Divide(double n);
    }

    // Service class which implements the service contract.
    [ServiceBehavior(
        TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
        TransactionTimeout = "0:00:30",
        ReleaseServiceInstanceOnTransactionComplete = false,
        TransactionAutoCompleteOnSessionClose = false)]
    public class CalculatorService : ICalculator
    {
        private double runningTotal;

        public CalculatorService()
        {
            Console.WriteLine("Creating new service instance...");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public double Add(double n)
        {
            recordToLog(String.Format("Adding {0} to {1}", n, runningTotal));
            runningTotal = runningTotal + n;
            return runningTotal;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public double Subtract(double n)
        {
            recordToLog(String.Format("Subtracting {0} from {1}", n, runningTotal));
            runningTotal = runningTotal - n;
            return runningTotal;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public double Multiply(double n)
        {
            recordToLog(String.Format("Multiplying {0} by {1}", runningTotal, n));
            runningTotal = runningTotal * n;
            return runningTotal;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public double Divide(double n)
        {
            recordToLog(String.Format("Dividing {0} by {1}", runningTotal, n));
            runningTotal = runningTotal / n;
            OperationContext.Current.SetTransactionComplete();
            return runningTotal;
        }

        private void recordToLog(string recordText)
        {
            if (ConfigurationManager.AppSettings["usingSql"] == "true")
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["connectionString"]))
                {
                    SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Log", conn);
                    SqlCommand cmdLog = new SqlCommand("INSERT into Log (Entry) Values (@Entry)", conn);
                    cmdLog.Parameters.AddWithValue("@Entry", recordText);

                    conn.Open();
                    cmdLog.ExecuteNonQuery();
                    string rowCount = cmdCount.ExecuteScalar().ToString();
                    Console.WriteLine("  Writing row {0} to database: {1}", rowCount, recordText);
                    conn.Close();
                }
            }
        }
    }
}
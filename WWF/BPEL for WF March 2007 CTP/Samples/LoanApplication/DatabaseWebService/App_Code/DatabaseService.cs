//---------------------------------------------------------------------
//  This file is part of the  BPEL for Windows Workflow Foundation Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Microsoft.Workflow.Bpel.Activities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
public class DatabaseService : System.Web.Services.WebService
{
    [WebMethod]
    public void UpdateLoanStatus(string RequestId, string Status)
    {
        if (string.IsNullOrEmpty(RequestId))
        {
            throw new ArgumentException("RequestId is null or Empty");
        }

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_UpdateLoanRequestStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", RequestId);
            command.Parameters.AddWithValue("@Status", Status);
            command.ExecuteNonQuery();
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public class CreditDetail
    {
        public string RiskProfile;
        public string CreditStatus;
        public int Amount;
    }

    [WebMethod]
    public CreditDetail GetCreditDetails(string RequestId)
    {
        if (string.IsNullOrEmpty(RequestId))
        {
            throw new ArgumentException("RequestId is null or Empty");
        }

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_GetUserCreditDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", RequestId);
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            CreditDetail creditDetails = new CreditDetail();
            if (reader.Read())
            {
                creditDetails.RiskProfile = reader.GetString(reader.GetOrdinal("RiskProfile"));
                creditDetails.CreditStatus = reader.GetString(reader.GetOrdinal("CreditStatus"));
                creditDetails.Amount = reader.GetInt32(reader.GetOrdinal("Amount"));
            }
            return creditDetails;
        }
    }

    [WebMethod]
    public int GenerateCreditReport(string RequestId, string CreditRating)
    {
        if (string.IsNullOrEmpty(RequestId))
        {
            throw new ArgumentException("RequestId is null or Empty");
        }

        if (string.IsNullOrEmpty(CreditRating))
        {
            throw new ArgumentException("CreditRating is null or Empty");
        }

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_GenerateCreditReport", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", RequestId);
            command.Parameters.AddWithValue("@CreditRating", CreditRating);
            return Convert.ToInt32(command.ExecuteScalar());
        }
    }

    [WebMethod]
    public int GenerateLoanQuote(string RequestId, int CreditReportId)
    {
        if (string.IsNullOrEmpty(RequestId))
        {
            throw new ArgumentException("RequestId is null or Empty");
        }

        if (CreditReportId == 0)
        {
            throw new ArgumentException("CreditReportId must be greater than 0");
        }

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand commandInsert = new SqlCommand("usp_InsertLoanQuote", connection);
            commandInsert.CommandType = CommandType.StoredProcedure;

            // Get Credit Report Details
            SqlCommand commandGetCR = new SqlCommand("usp_GetCreditReportDetails", connection);
            commandGetCR.CommandType = CommandType.StoredProcedure;
            commandGetCR.Parameters.AddWithValue("@RequestId", RequestId);
            commandGetCR.Parameters.AddWithValue("@CreditReportId", CreditReportId);

            SqlDataReader reader = commandGetCR.ExecuteReader(CommandBehavior.SingleRow);
            if (!reader.Read())
            {
                return 0;
            }
            string creditRating = reader.GetString(reader.GetOrdinal("CreditRating"));
            int ammount = reader.GetInt32(reader.GetOrdinal("Amount"));

            reader.Close();

            // Insert Loan
            commandInsert.Parameters.AddWithValue("@RequestId", RequestId);
            commandInsert.Parameters.AddWithValue("@InterestRate", 5.5F);
            commandInsert.Parameters.AddWithValue("@TimePeriod", 60);
            commandInsert.Parameters.AddWithValue("@AmountSanctioned", ammount);
            commandInsert.Parameters.AddWithValue("@StartDate", DateTime.Now.AddMonths(3));

            if (creditRating != "REJECT" && ammount <= 50000)
            {
                return Convert.ToInt32(commandInsert.ExecuteScalar());
            }
            return 0;
        }
    }
}


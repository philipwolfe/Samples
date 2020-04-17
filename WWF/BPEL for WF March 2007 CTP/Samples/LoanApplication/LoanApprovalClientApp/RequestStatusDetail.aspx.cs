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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LoanApprovalProcessClient;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class RequestStatusDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Guid requestId = Guid.Empty;
            string loanStatus = string.Empty;

            if (Session["RequestId"] == null)
                Response.Redirect("~/Default.aspx", true);
            
            requestId = (Guid)Session["RequestId"];
            loanStatus = GetLoanRequestStatus(requestId);
           
            // If the loan request has just been submitted the Status is "PROCESSING"
            if (loanStatus != string.Empty && loanStatus == "PROCESSING")
            {
                lblReqId.Text = requestId.ToString();
                lblReqStatus.Text = loanStatus;
                lblLoanQuotes.Text = "Your Loan Request is under process.";
                return;
            }
            
            if (loanStatus == string.Empty)
            {
                lblReqStatus.Text = "NOT FOUND";
                lblReqId.Text = requestId.ToString();
                lblLoanQuotes.Text = "No Quotes found.";
            }
            else
            {
                lblReqId.Text = requestId.ToString();
                lblReqStatus.Text = loanStatus;
            }

            if (requestId != null)
            {
                // Get the loan quotes if present
                gridViewLoanQuote.Visible = true;
                List<LoanQuote> listLoanQuotes = GetLoanQuotes(requestId);

                if (listLoanQuotes != null && listLoanQuotes.Count > 0)
                {
                    gridViewLoanQuote.DataSource = listLoanQuotes;
                    gridViewLoanQuote.DataBind();
                }
                else
                {
                    gridViewLoanQuote.Visible = false;
                    gridViewLoanQuote.DataSource = null;
                    lblLoanQuotes.Text = "No Quotes found. Your loan may not have been approved.";
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }


    private string GetLoanRequestStatus(Guid requestId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_GetLoanRequestStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", requestId);
            return Convert.ToString(command.ExecuteScalar());
        }
    }

    public List<LoanQuote> GetLoanQuotes(Guid requestId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_GetLoanQuotes", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", requestId);
            SqlDataReader reader = command.ExecuteReader();

            List<LoanQuote> quoteList = new List<LoanQuote>();

            while (reader.Read())
            {
                LoanQuote loanQuote = new LoanQuote(requestId);
                loanQuote.AmountSanctioned = reader.GetInt32(reader.GetOrdinal("AmountSanctioned"));
                loanQuote.InterestRate = reader.GetDouble(reader.GetOrdinal("InterestRate"));
                loanQuote.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                loanQuote.TimePeriod = reader.GetInt32(reader.GetOrdinal("TimePeriod"));
                
                quoteList.Add(loanQuote);
            }
            return quoteList;
        }
    }

}

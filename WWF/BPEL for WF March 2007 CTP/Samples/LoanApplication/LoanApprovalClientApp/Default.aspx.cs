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
using System.Data.SqlClient;
using LoanApprovalProcessClient;
using localhost;

public partial class LoanRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove("RequestId");
            Session.Remove("DisplayRequestStatus");
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Guid newRequestId = Guid.NewGuid();

        SaveLoanRequestDetails(
            newRequestId, 
            txtUserName.Text,
            txtAreaAddress.Value, 
            txtSSN.Text, 
            Convert.ToInt32(txtLoanAmount.Text));

        // Call the web service asynchronously
        BrokerWebService broker = new BrokerWebService();                

        IAsyncResult ar = broker.BeginStartLoanProcessing(newRequestId.ToString(), new AsyncCallback(this.BrokerCallBack), null);

        Session["RequestId"] = newRequestId;
        Session["DisplayRequestStatus"] = "PROCESSING";
        Response.Redirect("~/RequestStatusDetail.aspx", true);
    }


    // Call back function for the Asynchronous call to web service
    private void BrokerCallBack(IAsyncResult ar)
    {
    }

    private void SaveLoanRequestDetails(Guid requestId, string userName, string address, string SSN, int loanAmount)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["LoanApprovalDBConString"].ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("usp_InsertLoanRequestDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@RequestId", requestId);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@SSN", SSN);
            command.Parameters.AddWithValue("@Amount", loanAmount);
            command.Parameters.AddWithValue("@Status", "PROCESSING");
            command.ExecuteNonQuery();
        }        
    }
}

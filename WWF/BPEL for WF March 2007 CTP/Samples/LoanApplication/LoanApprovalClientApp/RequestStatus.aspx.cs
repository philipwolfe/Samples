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

public partial class RequestStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Remove("RequestId");
            Session.Remove("DisplayRequestStatus");
        }
    }

    protected void btnLoanRequestStatus_Click(object sender, EventArgs e)
    {
        Guid requestId = Guid.Empty;
        try
        {
            requestId = new Guid(txtRequestId.Text);
        }
        catch (System.FormatException)
        {
            return;
        }

        if (requestId != Guid.Empty)
        {
            Session["RequestId"] = requestId;
            Response.Redirect("~/RequestStatusDetail.aspx", true);
        }

    }

}

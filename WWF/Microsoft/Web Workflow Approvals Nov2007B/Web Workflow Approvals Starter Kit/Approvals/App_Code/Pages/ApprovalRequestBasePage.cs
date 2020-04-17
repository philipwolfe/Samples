//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflows;

public abstract class ApprovalRequestBasePage : Page
{
    protected WorkItemsDataSet GetData()
    {
        DataSet dataSet = ((IBaseWorkflowTaskMasterPage)this.Master).TaskDataSet;

        if (dataSet == null)
        {
            throw new NullReferenceException("The WorkItemsDataSet cannot be null");
        }

        if (!(dataSet is WorkItemsDataSet))
        {
            throw new ArgumentException("The dataset must be of type 'WorkItemsDataSet'");
        }

        return (WorkItemsDataSet)dataSet;
    }

    protected void ClearData()
    {
        ((IBaseWorkflowTaskMasterPage)this.Master).TaskDataSet = null;
    }
}

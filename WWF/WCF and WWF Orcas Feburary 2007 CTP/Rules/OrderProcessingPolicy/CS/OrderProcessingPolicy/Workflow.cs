//--------------------------------------------------------------------------
//  This file is part of the Windows Workflow Foundation SDK Code Samples.
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
//--------------------------------------------------------------------------

using PolicyFromFile;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;

namespace Microsoft.Rules.Samples
{
    public sealed partial class Workflow : SequentialWorkflowActivity
    {
        private string customerName;                // ie. "John Customer"
        private int itemNum;                        // ie. 1 => for Vista Ultimate DVD
        private string zipCode;                     // ie. "00999"
        private OrderError invalidOrder;
        private OrderErrorCollection invalidZipCodeErrorCollection;
        private OrderErrorCollection invalidItemNumErrorCollection;
        private OrderErrorCollection invalidOrdersCollection;

        public string CustomerName
        {
            get
            {
                return this.customerName;
            }
            set
            {
                this.customerName = value;
            }
        }

        public int ItemNum
        {
            get
            {
                return this.itemNum;
            }
            set
            {
                this.itemNum = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return this.zipCode;
            }
            set
            {
                this.zipCode = value;
            }
        }

        public Workflow()
        {
            InitializeComponent();
        }
    }
}

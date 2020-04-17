//---------------------------------------------------------------------
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
//---------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.Runtime;
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.Tutorials.Hosting
{
    public sealed class HostingWorkflows : SequentialWorkflowActivity
    {
        private DelayActivity delayActivity1;
        private CodeActivity codeActivity2;
        private CodeActivity codeActivity1;

        private int op1;
        private int op2;
        private int opResult;

        public HostingWorkflows()
        {
            InitializeComponent();
        }

        public int Operand1
        {
            set
            {
                this.op1 = value;
            }
        }

        public int Operand2
        {
            set
            {
                this.op2 = value;
            }
        }

        public int Result
        {
            get
            {
                return this.opResult;
            }
        }

        private void InitializeComponent()
        {
            this.CanModifyActivities = true;

            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new 
                System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new 
                System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // HostingWorkflows
            // 
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.delayActivity1);
            this.Activities.Add(this.codeActivity2);
            this.Name = "HostingWorkflows";

            this.CanModifyActivities = false;
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("In codeActivity1_ExecuteCode. Adding operands");
            this.opResult = this.op1 + this.op2;
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("In codeActivity2_ExecuteCode ");
        }
    }
}

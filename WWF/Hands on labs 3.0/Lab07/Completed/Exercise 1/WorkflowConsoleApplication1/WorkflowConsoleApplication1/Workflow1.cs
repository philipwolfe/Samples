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

namespace WorkflowConsoleApplication1
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}


        public enum NumberIs { Odd = 0, Even = 1 }
        private NumberIs currentNumber = NumberIs.Even;
        private bool userRequestsExit;

        //number entered is odd
        public void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("the number is odd");
            GetNextNumber();
        }

        //number entered is even
        public void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("the number is even");
            GetNextNumber();
        }


        //evaluate number entered by user and set currentNumber variable
        private void GetNextNumber()
        {
            int numIn;

            Console.WriteLine("enter a number.");
            string charIn = Console.ReadLine();

            if (Int32.TryParse(charIn, out numIn))
            {
                if ((numIn % 2) == 0)
                {
                    currentNumber = NumberIs.Even;
                }
                else
                {
                    currentNumber = NumberIs.Odd;
                }
            }
            else if (charIn.Contains("x"))
            {
                userRequestsExit = true;
            }
            else
            {
                GetNextNumber();
            }
        }

        //used to control execution of codeActivity1_ExecuteCode1
        public void oddCondition(object sender, ConditionalEventArgs args)
        {
            args.Result = ((currentNumber == NumberIs.Odd));
        }

        //used to control execution of codeActivity2_ExecuteCode1
        public void evenCondition(object sender, ConditionalEventArgs args)
        {
            args.Result = ((currentNumber == NumberIs.Even));
        }

        //used to control execution of the ConditionedActivityGroup
        public void timeToExit(object sender, ConditionalEventArgs args)
        {
            args.Result = userRequestsExit;
        }

	}
}

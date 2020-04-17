//--------------------------------------------------------------------------------
// This file is a Windows Workflow Foundation "Sample" built by
// Customer Support & Services
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

namespace NumberGuessWorkflowLibrary
{
    public sealed partial class StateMachineNumbersWorkflow : StateMachineWorkflowActivity
    {
        int Number;
        int Guess;
        public string Msg;

        private int maxRange;
        public int MaxRange
        {
            get { return maxRange; }
            set { maxRange = value; }
        }

        private int turns;
        public int Turns
        {
            get { return turns; }
            set { turns = value; }
        }

        public StateMachineNumbersWorkflow()
        {
            InitializeComponent();
        }

        private void GetStarted(object sender, EventArgs e)
        {
            Number = new Random().Next(1, MaxRange + 1);
            Guess = 0;
            Turns = 0;
        }

        private void GuessEnteredInvoked(object sender, ExternalDataEventArgs e)
        {
            MyExternalDataEventArgs args = e as MyExternalDataEventArgs;
            Guess = args.Guess;
            Msg = string.Format("Guess entered: {0}\r\n", Guess);
            Turns++;
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Msg += "That number is too low.";
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            Msg += "That number is too high.";
        }

        private void codeActivity4_ExecuteCode(object sender, EventArgs e)
        {
            Msg += "That number is correct.";
        }

        private void SendingMessage(object sender, EventArgs e)
        {
            this.TrackData("Message", Msg);
        }

        private void SetInitialMessage(object sender, EventArgs e)
        {
            Msg = string.Format("Range: 1 - {0}", this.MaxRange);
            this.TrackData("Message", Msg);
        }
    }
}

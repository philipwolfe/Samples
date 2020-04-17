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
using System.Collections;
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.SimpleConditionedActivityGroup
{
    public sealed partial class SimpleConditionedActivityGroupWorkflow
    {
    [System.Diagnostics.DebuggerNonUserCode()]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            this.BookingCag = new System.Workflow.Activities.ConditionedActivityGroup();
            this.Car = new System.Workflow.Activities.CodeActivity();
            this.Airline = new System.Workflow.Activities.CodeActivity();
            // 
            // BookingCag
            // 
            this.BookingCag.Activities.Add(this.Car);
            this.BookingCag.Activities.Add(this.Airline);
            this.BookingCag.Name = "BookingCag";
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CarCondition);
            // 
            // Car
            // 
            this.Car.Name = "Car";
            this.Car.ExecuteCode += new System.EventHandler(this.Car_ExecuteCode);
            this.Car.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition1);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.AirlineCondition);
            // 
            // Airline
            // 
            this.Airline.Name = "Airline";
            this.Airline.ExecuteCode += new System.EventHandler(this.Airline_ExecuteCode);
            this.Airline.SetValue(System.Workflow.Activities.ConditionedActivityGroup.WhenConditionProperty, codecondition2);
            // 
            // SimpleConditionedActivityGroupWorkflow
            // 
            this.Activities.Add(this.BookingCag);
            this.Name = "SimpleConditionedActivityGroupWorkflow";
            this.CanModifyActivities = false;

        }

        private ConditionedActivityGroup BookingCag;
        private CodeActivity Car;
        private CodeActivity Airline;
    }
}

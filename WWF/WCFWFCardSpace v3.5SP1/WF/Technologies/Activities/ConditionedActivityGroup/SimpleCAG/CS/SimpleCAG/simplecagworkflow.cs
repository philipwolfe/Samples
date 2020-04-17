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
    public sealed partial class SimpleConditionedActivityGroupWorkflow : SequentialWorkflowActivity
    {
        private ArrayList travelNeeds = new ArrayList();
        public SimpleConditionedActivityGroupWorkflow()
        {
            InitializeComponent();
            travelNeeds.Add(TravelNeed.Airline);
            travelNeeds.Add(TravelNeed.Car);
        }

        private void Car_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Booking car reservation");
            travelNeeds.Remove(TravelNeed.Car);
        }

        private void Airline_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Booking airline reservation");
            travelNeeds.Remove(TravelNeed.Airline);
        }

        private void CarCondition(object sender, ConditionalEventArgs e)
        {
            e.Result = travelNeeds.Contains(TravelNeed.Car);
        }

        private void AirlineCondition(object sender, ConditionalEventArgs e)
        {
            e.Result = travelNeeds.Contains(TravelNeed.Airline);
        }
    }

    public enum TravelNeed
    {
        None = 0,
        Car = 1,
        Airline = 2
    }
}

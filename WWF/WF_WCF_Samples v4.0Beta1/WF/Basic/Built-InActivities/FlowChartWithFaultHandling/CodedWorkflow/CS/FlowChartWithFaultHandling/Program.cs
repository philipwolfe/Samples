//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;

namespace Microsoft.Samples.FlowChartWithFaultHandling
{
    // Show how to create a FlowChart that handles faults using a TryCatch activity
    // To demonstrate this issue, a flowchart workflow to handle promotions is created
    // in CreateFlowchartWithFaults method. The following Promotion Codes are used 
    //      Single: Single
    //      MNK:    Married (No Kids)
    //      MWK:    Married (With Kids)
    class Program
    {
        static void Main(string[] args)
        {   
            // no fault expected
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "Single", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("Single", 0));

            // no fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MNK", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MNK", 0));

            // no fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 2);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MWK", 2));

            // fault expected
            Console.WriteLine();
            Console.WriteLine("Invoke with Promo Code {0}, number of kids {1}", "MWK", 0);
            WorkflowInvoker.Invoke(CreateFlowchartWithFaults("MWK", 0));

            // wait for user input
            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }

        private static WorkflowElement CreateFlowchartWithFaults(string promoCode, int numKids)
        {
            Variable<string> promo = new Variable<string> { Default = promoCode };
            Variable<int> numberOfKids = new Variable<int> { Default = numKids };
            Variable<double> discount = new Variable<double>();

            FlowStep discountNotApplied = new FlowStep
            {
                Action = new WriteLine 
                { 
                    DisplayName = "WriteLine: Discount not applied", 
                    Text = "Discount not applied" 
                },
                Next = null
            };

            FlowStep discountApplied = new FlowStep
            {
                Action = new WriteLine 
                {
                    DisplayName = "WriteLine: Discount applied",
                    Text = "Discount applied " 
                },
                Next = null
            };

            FlowDecision flowDecision = new FlowDecision
            {
                Condition = ValueExpression.Create((env) => discount.Get(env) > 0),
                True = discountApplied,
                False = discountNotApplied
            };

            FlowStep singleStep = new FlowStep
            {
                Action = new Assign
                {
                    DisplayName = "discount = 10.0",
                    To = new OutArgument<double> (discount),
                    Value = new InArgument<double> (10.0)
                },
                Next = flowDecision
            };

            FlowStep mnkStep = new FlowStep
            {
                Action = new Assign
                {
                    DisplayName = "discount = 15.0",
                    To = new OutArgument<double> (discount),
                    Value = new InArgument<double> (15.0)
                },
                Next = flowDecision
            };

            FlowStep mwkStep = new FlowStep
            {
                Action = new TryCatch
                {
                    DisplayName = "Try/Catch for Divide By Zero Exception",
                    Try = new Assign
                    {
                        DisplayName = "discount = 15 + (1 - 1/numberOfKids)*10",
                        To = new OutArgument<double>(discount),
                        Value = new InArgument<double>((env)=>(15 + (1 - 1/numberOfKids.Get(env))*10))
                    },
                    Catches = 
                    {
                         new Catch<System.DivideByZeroException>
                         {
                             Action = new ActivityAction<System.DivideByZeroException>
                             {
                                 DisplayName = "ActivityAction - DivideByZeroException",
                                 Handler =
                                 new Sequence
                                 {
                                     DisplayName = "Divide by Zero Exception Workflow",
                                     Activities =
                                     {
                                        new WriteLine() 
                                        { 
                                            DisplayName = "WriteLine: DivideByZeroException",
                                            Text = "DivideByZeroException: Promo code is MWK - but number of kids = 0" 
                                        },
                                        new Assign<double>
                                        {
                                            DisplayName = "Exception - discount = 0", 
                                            To = discount,
                                            Value = new InArgument<double>(0)
                                        }
                                     }
                                 }
                             }
                         }
                    }
                },
                Next = flowDecision
            };

            FlowStep discountDefault = new FlowStep
            {
                Action = new Assign<double>
                {
                    DisplayName = "Default discount assignment: discount = 0",
                    To = discount,
                    Value = new InArgument<double>(0)
                },
                Next = flowDecision
            };

            FlowSwitch promoCodeSwitch = new FlowSwitch
            {
                Expression = promo,
                Cases =
                {
                   { "Single", singleStep },
                   { "MNK", mnkStep },
                   { "MWK", mwkStep }
                },
                Default = discountDefault
            };

            Flowchart flowChart = new Flowchart
            {
                DisplayName = "Promotional Discount Calculation",
                Variables = {discount, promo, numberOfKids},
                StartNode = promoCodeSwitch,
                Nodes = 
                { 
                    promoCodeSwitch, 
                    singleStep, 
                    mnkStep, 
                    mwkStep, 
                    discountDefault, 
                    flowDecision, 
                    discountApplied, 
                    discountNotApplied
                }
            };
            return flowChart;
        }
    }
}

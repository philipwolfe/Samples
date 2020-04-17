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

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

#endregion

using System.Workflow.ComponentModel;
using System.Workflow.Activities.Rules;
using System.CodeDom;


namespace DynamicUpdateChangingRules
{
    class Program
    {
			static bool rulesChanged = false;

      static void Main(string[] args)
      {
          using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
          {
              AutoResetEvent waitHandle = new AutoResetEvent(false);
              workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
              workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
              {
                  Console.WriteLine(e.Exception.Message);
                  waitHandle.Set();
              };
							workflowRuntime.WorkflowIdled +=
								delegate(object sender, WorkflowEventArgs e)
								{
									//idling this workflow so we can modify it
									e.WorkflowInstance.Suspend("suspending to modify IfElse1");
									changeRulesForWorkflow(e.WorkflowInstance);
									e.WorkflowInstance.Resume();
								};
							workflowRuntime.WorkflowSuspended +=
								delegate(object sender, WorkflowSuspendedEventArgs e)
								{
									string reason = e.Error;
									string workflowID = e.WorkflowInstance.InstanceId.ToString();

									Console.WriteLine("\tWorkflow \'{0}\' Suspended, reason \'{1}\'", workflowID, reason);
								};
							workflowRuntime.WorkflowResumed +=
								delegate(object sender, WorkflowEventArgs e)
								{
									string workflowID = e.WorkflowInstance.InstanceId.ToString();

									Console.WriteLine("\tWorkflow \'{0}\' Resumed", workflowID);
								};

							// The "Amount" parameter is used to determine which branch of the IfElse should be executed
							// a value less than 10,000 will execute branch 1 - Get Manager Approval; any other value will execute branch 2 - Get VP Approval
							int workflowAmount = 9000;
							Dictionary<string, object> workflowNamedValues = new Dictionary<string, object>();
							workflowNamedValues.Add("Amount", workflowAmount);
							WorkflowInstance workflowInstance = workflowRuntime.CreateWorkflow(typeof(DynamicUpdateChangingRules.DynamicRulesWorkflow), workflowNamedValues);
							workflowInstance.Start();
							waitHandle.WaitOne();

							Console.Write("\r\n\r\n");
							Console.WriteLine("press ENTER to continue");
							Console.ReadLine();

          }
      }
			static void changeRulesForWorkflow(WorkflowInstance workflowInstance)
			{
				if (!rulesChanged)
				{
					rulesChanged = true;

					// our new validation amount
					Int32 newAmount = 8000;
					Console.WriteLine("\tDynamically change approved amount to {0}", newAmount);

					// Dynamic update of order rule
					WorkflowChanges workflowchanges = new WorkflowChanges(workflowInstance.GetWorkflowDefinition());
					CompositeActivity transient = workflowchanges.TransientWorkflow;
					RuleDefinitions ruleDefinitions = (RuleDefinitions)transient.GetValue(RuleDefinitions.RuleDefinitionsProperty);
					RuleConditionCollection conditions = ruleDefinitions.Conditions;
					RuleExpressionCondition condition1 = (RuleExpressionCondition)conditions["Condition1"];
					(condition1.Expression as CodeBinaryOperatorExpression).Right = new CodePrimitiveExpression(newAmount);

					// Apply our changes to the workflow
					workflowInstance.ApplyWorkflowChanges(workflowchanges);

				}
				else
				{
					Console.WriteLine("\tRules for Workflow already changed");
				}
			}

    }
}

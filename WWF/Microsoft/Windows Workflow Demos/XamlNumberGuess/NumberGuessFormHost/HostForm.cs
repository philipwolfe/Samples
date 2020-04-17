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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Workflow.Runtime.Tracking;
using System.IO;
using System.Data.SqlClient;

using NumberGuessWorkflowLibrary;
using System.Configuration;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Xml;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;

namespace NumberGuessFormHost
{
	public partial class HostForm: Form, ILocalService
	{
        WorkflowRuntime workflowRuntime;

        string Files = @"..\..\..\Files\";

        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NumberGuess"].ConnectionString;
            }
        }

        public Guid WorkflowInstanceId
        {
            get { return (Guid)cboInstanceId.SelectedItem; }
        }

        private delegate void SetMsgDelegate(string msg);
        private delegate void SetGuessButtonsDelegate(bool value);
        private delegate void GameOverDelegate();

		public HostForm()
		{
			InitializeComponent();
		}


        private void SetGuessButtons(bool value)
        {
            if (txtGuess.InvokeRequired)
            {
                BeginInvoke(new SetGuessButtonsDelegate(SetGuessButtons), value);
            }
            else
            {
                btnGuess.Enabled = value;
                txtGuess.Enabled = value;
                btnQuit.Enabled = value;
                if (value)
                {
                    txtGuess.Clear();
                }
            }
        }

        private void GameOver()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new GameOverDelegate(GameOver));
            }
            else
            {
                SqlTrackingQuery query = new SqlTrackingQuery(ConnectionString);
                SqlTrackingWorkflowInstance instance;
                query.TryGetWorkflow(WorkflowInstanceId, out instance);
                if (instance != null)
                {
                    Console.WriteLine("Workflow Tracking");
                    foreach (WorkflowTrackingRecord r in instance.WorkflowEvents)
                    {
                        Console.WriteLine("{2} : {0} : {1}", r.TrackingWorkflowEvent, r.EventDateTime, r.EventOrder);
                    }

                    Console.WriteLine("Activity Tracking");
                    foreach (ActivityTrackingRecord r in instance.ActivityEvents)
                    {
                        Console.WriteLine("{0} : {1} : {2}", r.QualifiedName, r.ExecutionStatus, r.EventDateTime);
                    }

                    Console.WriteLine("UserTrackPoint Tracking");
                    foreach (UserTrackingRecord r in instance.UserEvents)
                    {
                        Console.WriteLine("{0} : {1} : {2}", r.UserData, r.QualifiedName, r.EventDateTime);
                    }
                }

                // End the current game
                cboInstanceId.Items.Remove(cboInstanceId.SelectedItem);
                cboInstanceId.SelectedItem = null;
                //txtInstanceId.Clear();
                btnNew.Enabled = true;
                SetGuessButtons(false);



            }
        }

        public event EventHandler<MyExternalDataEventArgs> GuessEntered;

        public void SetMessage(string msg)
        {
            // We may be on a different thread so we need to
            // make this call using BeginInvoke
            if (txtMsg.InvokeRequired)
            {
                BeginInvoke(new SetMsgDelegate(SetMessage), msg);
            }
            else
            {
                txtMsg.Text += msg + "\r\n";
                txtMsg.SelectionStart = txtMsg.Text.Length;
                txtMsg.ScrollToCaret();
            }
        }

        private void Form1_Load(object FormLoadSender, EventArgs e)
        {
            // Start the Workflow Runtime Here
            workflowRuntime = new WorkflowRuntime();
            ExternalDataExchangeService dataService = new ExternalDataExchangeService();
            workflowRuntime.AddService(dataService);
            dataService.AddService(this);

            NameValueCollection parms = new NameValueCollection();
            parms.Add("ConnectionString", ConnectionString);
            parms.Add("UnloadOnIdle", "true");
            workflowRuntime.AddService(new SqlWorkflowPersistenceService(parms));
            workflowRuntime.AddService(new SqlTrackingService(ConnectionString));
            workflowRuntime.AddService(new SharedConnectionWorkflowCommitWorkBatchService(ConnectionString));

            SetGuessButtons(false);
            cboRange.SelectedIndex = 0;

            // Explicitly start the Runtime
            workflowRuntime.StartRuntime();

            // Way to get running instances from Persistence
            // OK if all are guaranteed to be my type
            SqlWorkflowPersistenceService service = workflowRuntime.GetService<SqlWorkflowPersistenceService>();
            foreach (SqlPersistenceWorkflowInstanceDescription desc in service.GetAllWorkflows())
            {
                cboInstanceId.Items.Add(desc.WorkflowInstanceId);
            }

            //// SqlTrackingQuery - get only running instances of my types
            //SqlTrackingQuery query = new SqlTrackingQuery(ConnectionString);
            //SqlTrackingQueryOptions options = new SqlTrackingQueryOptions();
            //options.WorkflowStatus = WorkflowStatus.Running;

            //// In this example the Sequential Workflows are Xaml
            //// to query for them, specify the custom base type
            //options.WorkflowType = typeof(SequentialNumbersWorkflowBase);

            //IList<SqlTrackingWorkflowInstance> list = query.GetWorkflows(options);

            //foreach(SqlTrackingWorkflowInstance i in list)
            //{
            //    cboInstanceId.Items.Add(i.WorkflowInstanceId);
            //}

            //// This queries for the State Machine Workflows
            //// which are code based
            //query = new SqlTrackingQuery(ConnectionString);
            //options = new SqlTrackingQueryOptions();
            //options.WorkflowStatus = WorkflowStatus.Running;
            //options.WorkflowType = typeof(StateMachineNumbersWorkflow);

            //list = query.GetWorkflows(options);

            //foreach(SqlTrackingWorkflowInstance i in list)
            //{
            //    cboInstanceId.Items.Add(i.WorkflowInstanceId);
            //}

            workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs args)
            {
                Console.WriteLine("Workflow {0} Completed.", args.WorkflowInstance.InstanceId);

                // Get the number of Turns from the output parameters
                int turns = Convert.ToInt32(args.OutputParameters["Turns"]);

                // Configure the UI for end game
                SetMessage(string.Format("You won in {0} turn(s)", turns));
                GameOver();
            };

            workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs args)
            {
                Console.WriteLine("Workflow {0} Terminated.", args.WorkflowInstance.InstanceId);

                // Configure UI to reflect Workflow Termination
                SetMessage(string.Format("Exception: {0}", args.Exception.Message));
                GameOver();
            };

            workflowRuntime.WorkflowIdled += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Idled.", args.WorkflowInstance.InstanceId);
                // args.WorkflowInstance.Unload();
            };

            workflowRuntime.WorkflowCreated += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Created.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.WorkflowStarted += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Started.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.WorkflowUnloaded += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Unloaded.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.WorkflowLoaded += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Loaded.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.WorkflowPersisted += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Persisted.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.WorkflowResumed += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Resumed.", args.WorkflowInstance.InstanceId);
            };

            workflowRuntime.ServicesExceptionNotHandled += delegate(object sender, ServicesExceptionNotHandledEventArgs args)
            {
                Console.WriteLine("Workflow {0} ServicesExceptionNotHandled");
                Console.WriteLine("Exception: {0}", args.Exception.Message);
            };

            workflowRuntime.WorkflowAborted += delegate(object sender, WorkflowEventArgs args)
            {
                Console.WriteLine("Workflow {0} Aborted.", args.WorkflowInstance.InstanceId);
            };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Build the input parameters to the workflow
            // (Max number of guessing range)
            Dictionary<string, object> inputs = new Dictionary<string, object>();
            inputs.Add("MaxRange", Convert.ToInt32(cboRange.SelectedItem));

            // Create Workflow instance and add in input parameters
            if (radioButton2.Checked) // Code based State Machine Workflow
            {
                Type WorkflowType;
                WorkflowType = typeof(StateMachineNumbersWorkflow);

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(WorkflowType, inputs);

                // Cache the InstanceId
                //WorkflowInstanceId = instance.InstanceId;
                //txtInstanceId.Text = WorkflowInstanceId.ToString();
                int pos = cboInstanceId.Items.Add(instance.InstanceId);
                cboInstanceId.SelectedIndex = pos;

                // Start the Workflow
                instance.Start();
            }
            else // Xaml Based Workflow
            {

                StreamReader sRules = File.OpenText(Path.Combine(Files, "SequentialNumbersWorkflow.rules"));
                XmlReader rulesReader = XmlReader.Create(sRules);

                // Use Xaml Activation
                //*
                StreamReader s = File.OpenText(Path.Combine(Files, "SequentialNumbersWorkflow.xoml"));
                XmlReader reader = XmlReader.Create(s);
                /*/ This is helper code I used to build the Xoml file for the Sequential Workflow
                SequentialNumbersWorkflowBase wf = new SequentialNumbersWorkflowBase();

                AddActivities(wf);

                StringBuilder sb = new StringBuilder();
                XmlWriter wr = XmlTextWriter.Create(sb);
                WorkflowMarkupSerializer wms = new WorkflowMarkupSerializer();
                wms.Serialize(wr, wf);
                wr.Close();

                StreamWriter sw = File.CreateText(Path.Combine(Files, "SequentialNumbersWorkflow2.xoml"));
                XmlWriter wr2 = XmlTextWriter.Create(sw);
                wms.Serialize(wr2, wf);
                wr2.Close();

                Console.WriteLine(sb);
             
                // Create the XmlReader that holds the Xaml
                XmlReader reader = XmlReader.Create(new StringReader(sb.ToString()));
                //*/

                try
                {
                    WorkflowInstance instance = workflowRuntime.CreateWorkflow(reader, rulesReader, inputs);
                    instance.Start();
                    int pos = cboInstanceId.Items.Add(instance.InstanceId);
                    cboInstanceId.SelectedIndex = pos;
                }
                catch (WorkflowValidationFailedException ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    Console.WriteLine("Errors collection: {0} errors", ex.Errors.Count);
                    foreach (ValidationError error in ex.Errors)
                    {
                        Console.WriteLine(error.ToString());
                    }
                }
            }

            // Configure the UI for a game running
            SetGuessButtons(true);
            //btnNew.Enabled = false;
            txtMsg.Clear();
        }

        void AddActivities(SequentialNumbersWorkflowBase wf)
        {
            WriteLineActivity writeLineActivity1;
            CallExternalMethodActivity callExternalMethodActivity2;
            FaultHandlersActivity faultHandlersActivity1;
            FaultHandlersActivity faultHandlersActivity2;
            CodeActivity codeActivity4;
            IfElseBranchActivity ifElseBranchActivity3;
            CodeActivity codeActivity3;
            CodeActivity codeActivity2;
            WhileActivity whileActivity1;
            IfElseBranchActivity ifElseBranchActivity2;
            IfElseBranchActivity ifElseBranchActivity1;
            IfElseActivity ifElseActivity1;
            HandleExternalEventActivity handleExternalEventActivity1;
            SequenceActivity sequenceActivity1;
            CallExternalMethodActivity callExternalMethodActivity1;

            //CanModifyActivities = true;
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            codeActivity4 = new System.Workflow.Activities.CodeActivity();
            codeActivity3 = new System.Workflow.Activities.CodeActivity();
            codeActivity2 = new System.Workflow.Activities.CodeActivity();
            ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            writeLineActivity1 = new NumberGuessWorkflowLibrary.WriteLineActivity();
            callExternalMethodActivity1 = new System.Workflow.Activities.CallExternalMethodActivity();
            ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            handleExternalEventActivity1 = new System.Workflow.Activities.HandleExternalEventActivity();
            faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            whileActivity1 = new System.Workflow.Activities.WhileActivity();
            callExternalMethodActivity2 = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // codeActivity4
            // 
            codeActivity4.Name = "codeActivity4";
            codeActivity4.ExecuteCode += new System.EventHandler(wf.codeActivity4_ExecuteCode);
            // 
            // codeActivity3
            // 
            codeActivity3.Name = "codeActivity3";
            codeActivity3.ExecuteCode += new System.EventHandler(wf.codeActivity3_ExecuteCode);
            // 
            // codeActivity2
            // 
            codeActivity2.Name = "codeActivity2";
            codeActivity2.ExecuteCode += new System.EventHandler(wf.codeActivity2_ExecuteCode);
            // 
            // ifElseBranchActivity3
            // 
            ifElseBranchActivity3.Activities.Add(codeActivity4);
            ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // ifElseBranchActivity2
            // 
            ifElseBranchActivity2.Activities.Add(codeActivity3);
            ruleconditionreference1.ConditionName = "TooHighCondition";
            ifElseBranchActivity2.Condition = ruleconditionreference1;
            ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            ifElseBranchActivity1.Activities.Add(codeActivity2);
            ruleconditionreference2.ConditionName = "TooLowCondition";
            ifElseBranchActivity1.Condition = ruleconditionreference2;
            ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // writeLineActivity1
            // 
            writeLineActivity1.Msg = "Turn Over";
            writeLineActivity1.Name = "writeLineActivity1";
            // 
            // callExternalMethodActivity1
            // 
            callExternalMethodActivity1.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            callExternalMethodActivity1.MethodName = "SetMessage";
            callExternalMethodActivity1.Name = "callExternalMethodActivity1";
            activitybind1.Name = "SequentialNumbersWorkflow";
            activitybind1.Path = "Msg";
            workflowparameterbinding1.ParameterName = "msg";
            workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            callExternalMethodActivity1.ParameterBindings.Add(workflowparameterbinding1);
            callExternalMethodActivity1.MethodInvoking += new System.EventHandler(wf.SendingMessage);
            // 
            // ifElseActivity1
            // 
            ifElseActivity1.Activities.Add(ifElseBranchActivity1);
            ifElseActivity1.Activities.Add(ifElseBranchActivity2);
            ifElseActivity1.Activities.Add(ifElseBranchActivity3);
            ifElseActivity1.Name = "ifElseActivity1";
            // 
            // handleExternalEventActivity1
            // 
            handleExternalEventActivity1.EventName = "GuessEntered";
            handleExternalEventActivity1.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            handleExternalEventActivity1.Name = "handleExternalEventActivity1";
            handleExternalEventActivity1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(wf.GuessEnteredInvoked);
            // 
            // faultHandlersActivity1
            // 
            faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // sequenceActivity1
            // 
            sequenceActivity1.Activities.Add(handleExternalEventActivity1);
            sequenceActivity1.Activities.Add(ifElseActivity1);
            sequenceActivity1.Activities.Add(callExternalMethodActivity1);
            // SAD add this to add a MessageWriteLine to the workflow
            //sequenceActivity1.Activities.Add(writeLineActivity1);
            sequenceActivity1.Name = "sequenceActivity1";
            // 
            // faultHandlersActivity2
            // 
            faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // whileActivity1
            // 
            whileActivity1.Activities.Add(sequenceActivity1);
            whileActivity1.Activities.Add(faultHandlersActivity1);
            ruleconditionreference3.ConditionName = "Condition1";
            whileActivity1.Condition = ruleconditionreference3;
            whileActivity1.Name = "whileActivity1";
            // 
            // callExternalMethodActivity2
            // 
            callExternalMethodActivity2.InterfaceType = typeof(NumberGuessWorkflowLibrary.ILocalService);
            callExternalMethodActivity2.MethodName = "SetMessage";
            callExternalMethodActivity2.Name = "callExternalMethodActivity2";
            activitybind2.Name = "SequentialNumbersWorkflow";
            activitybind2.Path = "Msg";
            workflowparameterbinding2.ParameterName = "msg";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            callExternalMethodActivity2.ParameterBindings.Add(workflowparameterbinding2);
            callExternalMethodActivity2.MethodInvoking += new System.EventHandler(wf.SetInitialMessage);
            // 
            // SequentialNumbersWorkflow
            // 
            wf.Activities.Add(callExternalMethodActivity2);
            wf.Activities.Add(whileActivity1);
            wf.Activities.Add(faultHandlersActivity2);
            wf.Name = "SequentialNumbersWorkflow";
            wf.Initialized += new System.EventHandler(wf.GetStarted);
            //CanModifyActivities = false;

		}
        private void btnGuess_Click(object sender, EventArgs e)
        {
            int Guess;
            if (!Int32.TryParse(txtGuess.Text, out Guess))
            {
                MessageBox.Show("Please enter an integer");
                txtGuess.SelectAll();
                txtGuess.Focus();
                return;
            }

            MyExternalDataEventArgs args = new MyExternalDataEventArgs(WorkflowInstanceId, Guess);
            if (GuessEntered != null)
            {
                GuessEntered(null, args);
            }

            txtGuess.Clear();
            txtGuess.Focus();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            WorkflowInstance instance = workflowRuntime.GetWorkflow(WorkflowInstanceId);
            instance.Terminate("User resigns");
        }

        private void cboInstanceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboInstanceId.SelectedItem == null)
            {
                return;
            }

            // We have a running game
            SetGuessButtons(true);
            txtMsg.Clear();

            SqlTrackingQuery query = new SqlTrackingQuery(ConnectionString);
            SqlTrackingWorkflowInstance instance;
            query.TryGetWorkflow(WorkflowInstanceId, out instance);
            if (instance != null)
            {
                foreach (UserTrackingRecord r in instance.UserEvents)
                {
                    if (r.UserDataKey == "Message")
                    {
                        SetMessage(r.UserData.ToString());
                    }
                }
            }
        }

        void InsertTrackingProfile(string profile)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.UpdateTrackingProfile";
            cmd.Connection = new SqlConnection(ConnectionString);
            try
            {
                cmd.Parameters.Clear();

                SqlParameter typFullName = new SqlParameter();
                typFullName.ParameterName = "@TypeFullName";
                typFullName.SqlDbType = SqlDbType.NVarChar;
                typFullName.SqlValue = typeof(SequentialNumbersWorkflowBase).ToString();
                cmd.Parameters.Add(typFullName);

                SqlParameter assemblyFullName = new SqlParameter();
                assemblyFullName.ParameterName = "@AssemblyFullName";
                assemblyFullName.SqlDbType = SqlDbType.NVarChar;
                assemblyFullName.SqlValue = typeof(SequentialNumbersWorkflowBase).Assembly.FullName;
                cmd.Parameters.Add(assemblyFullName);

                SqlParameter versionId = new SqlParameter();
                versionId.ParameterName = "@Version";
                versionId.SqlDbType = SqlDbType.VarChar;

                // The version ID must match the tracking profile version 
                // number.
                versionId.SqlValue = "1.0.0.0";

                cmd.Parameters.Add(versionId);

                SqlParameter trackingProfile = new SqlParameter();
                trackingProfile.ParameterName = "@TrackingProfileXml";
                trackingProfile.SqlDbType = SqlDbType.NVarChar;
                trackingProfile.SqlValue = profile;
                cmd.Parameters.Add(trackingProfile);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The Tracking Profile was not inserted. \r\n" +
                    "If you want to add a new Tracking Profile, modify the version \r\n" +
                    "string in the profile by specifying a higher version number.");
                return;
            }
            finally
            {
                if ((null != cmd) && (null != cmd.Connection) &&
                    (ConnectionState.Closed != cmd.Connection.State))
                    cmd.Connection.Close();
            }
        }
    }


}
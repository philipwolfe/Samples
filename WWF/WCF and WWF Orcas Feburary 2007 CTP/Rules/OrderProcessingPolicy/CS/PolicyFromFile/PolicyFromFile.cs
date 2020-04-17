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

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Workflow.Activities.Rules.Design;
using System.Windows.Forms;
using System.Xml;

namespace PolicyFromFile
{
    [Designer(typeof(MyCustomPolicyDesigner))]
    public partial class PolicyFromFile : SequenceActivity
    {
        public PolicyFromFile()
        {
            InitializeComponent();
        }

        // RulesFileName property where the path of the .rules can be set by the user
        public static DependencyProperty RulesFileNameProperty = DependencyProperty.Register("RulesFileName",
            typeof(string), typeof(PolicyFromFile), new PropertyMetadata(DependencyPropertyOptions.Metadata));

        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        public string RulesFileName
        {
            get
            {
                return (string)base.GetValue(PolicyFromFile.RulesFileNameProperty);
            }
            set
            {
                base.SetValue(PolicyFromFile.RulesFileNameProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            try
            {
                // Load RuleSet from the .rules file
                RuleSet ruleSet = RulesHelper.LoadRuleSetFromFile(this.RulesFileName);
                
                Activity targetActivity = GetRootWorkflow(this.Parent);

                RuleValidation validation = new RuleValidation(targetActivity.GetType(), null);
                RuleExecution execution = new RuleExecution(validation, targetActivity, executionContext);
                ruleSet.Execute(execution);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error: No .rules file found. Please create a .rules file or specify one in the RulesFileName property \n" + e.Message);
            }
            catch (RuleSetValidationException e)
            {
                Console.WriteLine(e.ToString());
                foreach (ValidationError error in e.Errors)
                {
                    Console.WriteLine(error.ToString());
                }
            }

            return base.Execute(executionContext);
        }

        // A recursive helper function that gets the root of the workflow
        private CompositeActivity GetRootWorkflow(CompositeActivity activity)
        {
            if (activity.Parent != null)
            {
                CompositeActivity workflow = GetRootWorkflow(activity.Parent);
                return workflow;
            }
            else
            {
                return activity;
            }
        }
    }

    public class MyCustomPolicyDesigner : CompositeActivityDesigner
    {
        protected override void DoDefaultAction()
        {
            RuleSet ruleSet = null;

            // Get the value from the RulesFileName property
            string rulesFileName = GetRulesFileNameProperty();
            
            if (!File.Exists(rulesFileName))
            {
                // If the file does not already exist, create a RuleSet for it
                ruleSet = new RuleSet();
            }
            else
            {
                // Otherwise load the RuleSet from file
                try
                {
                    ruleSet = RulesHelper.LoadRuleSetFromFile(rulesFileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error deserializing file: " + rulesFileName + "\n" + e.Message);
                }
            }

            // Enable the Rule Set Editor dialog when double click on the PolicyFromFile
            RuleSetDialog ruleSetDialog = new RuleSetDialog(this.Activity, ruleSet);
            DialogResult result = ruleSetDialog.ShowDialog();
            string currentDirectory = Environment.CurrentDirectory;

            // Only update the .rules file if the OK is pressed
            if (result == DialogResult.OK) 
            {
                ruleSet = ruleSetDialog.RuleSet;
                
                try
                {
                    Console.WriteLine(rulesFileName);
                    RulesHelper.SaveRuleSetToFile(rulesFileName, ruleSet);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                
                // Set the RulesFileName property
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.Activity);
                properties[PolicyFromFile.RulesFileNameProperty.Name].SetValue(this.Activity, rulesFileName);   
            }

            base.DoDefaultAction();
        }

        private string GetRulesFileNameProperty()
        {
            // Get the RulesFileName from the property field
            string rulesFileName = ((PolicyFromFile)this.Activity).RulesFileName;
                                  
            if (string.IsNullOrEmpty(rulesFileName))
            {
                // No property was specified, a default value is assigned (ie.  Workflow.cs => Workflow.rules)
                WorkflowDesignerLoader loader = (WorkflowDesignerLoader)this.GetService(typeof(WorkflowDesignerLoader));
                rulesFileName = Path.Combine(Path.GetDirectoryName(loader.FileName),Path.GetFileNameWithoutExtension(loader.FileName));
                rulesFileName += ".rules";
            }            
            
            return rulesFileName;            
        }
    }
}

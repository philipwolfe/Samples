//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

using System;
using System.Activities;
using System.Windows;
using System.Windows.Forms;
using System.Workflow.Activities.Rules;
using System.Workflow.Activities.Rules.Design;

namespace Microsoft.Samples.Rules
{
    // Interaction logic for PolicyDesigner.xaml
    public partial class PolicyDesigner
    {
        public PolicyDesigner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {            
            // verifiy that TargetObject property has been configured
            object targetObject = ModelItem.Properties["TargetObject"].ComputedValue;
            if (targetObject == null)
            {
                System.Windows.MessageBox.Show("TargetObject needs to be configured before adding the rules");
                return;
            }

            // verify that target object is correctly configured
            InOutArgument arg = targetObject as InOutArgument;
            if (arg == null)
            {
                System.Windows.MessageBox.Show("Invalid target object");
                return;
            }

            // open the ruleset editor
            Type targetObjectType = arg.ArgumentType;
            RuleSet ruleSet = ModelItem.Properties["RuleSet"].ComputedValue as RuleSet;
            if (ruleSet == null)
                ruleSet = new RuleSet();

            // popup the dialog for editing the rules            
            RuleSetDialog ruleSetDialog = new RuleSetDialog(targetObjectType, null, ruleSet);
            DialogResult result = ruleSetDialog.ShowDialog();

            // update the model item
            if (result == DialogResult.OK) //check if they cancelled
            {                
                ModelItem.Properties["RuleSet"].SetValue(ruleSetDialog.RuleSet);
            }   
        }
    }
}
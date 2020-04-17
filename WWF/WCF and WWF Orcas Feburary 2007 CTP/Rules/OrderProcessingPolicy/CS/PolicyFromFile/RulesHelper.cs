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
    internal class RulesHelper
    {
        internal static void SaveRuleSetToFile(string fileName, RuleSet ruleSet)
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileName, null))
            {
                WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                serializer.Serialize(writer, ruleSet);
            }
        }

        // Load RuleSet from supplied .rules file
        internal static RuleSet LoadRuleSetFromFile(string fileName)
        {
            object objectRuleSet = null; ;

            // Deserialize the .rules file that contains one RuleSet
            using (XmlTextReader reader = new XmlTextReader(fileName))
            {
                WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                objectRuleSet = serializer.Deserialize(reader);
            }

            RuleSet ruleSet = objectRuleSet as RuleSet;
                        
            if (ruleSet == null)
            {
                // Throw an exeception if file does not contain any RuleSet
                throw new InvalidOperationException("RuleSet is null, objectRuleSet.Type: " + objectRuleSet.GetType().FullName);
            }

            return ruleSet;
        }
    }
}
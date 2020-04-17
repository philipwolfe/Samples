//--------------------------------------------------------------------------------
// This file is part of the Windows Workflow Foundation Sample Code
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
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities.Rules;
using System.Collections;
using System.Collections.Generic;
using System.Workflow.Activities;

namespace CustomTypeSerialization.ActivityWithCustomType
{
    public partial class CustomActivityWithCustomType : System.Workflow.ComponentModel.Activity
    {
        private MyType myPropField = null;

        [Category("Activity")]
        [Description("Property that is a custom type for serialization")]
        public MyType MyNormalProperty
        {
            get{ return this.myPropField; }
            set{ this.myPropField = value; }
        }

        public static DependencyProperty MyDependencyPropertyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyDependencyProperty", typeof(MyType), typeof(CustomActivityWithCustomType));

        [Description("Property that is a custom type for serialization")]
        [Category("Activity")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public MyType MyDependencyProperty
        {
            get
            {
                return ((MyType)(base.GetValue(CustomActivityWithCustomType.MyDependencyPropertyProperty)));
            }
            set
            {
                base.SetValue(CustomActivityWithCustomType.MyDependencyPropertyProperty, value);
            }
        }
    }
}

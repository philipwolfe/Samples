﻿//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.Samples.TravelRuleLibrary
{
    public partial class TravelRuleSet : SequenceActivity
    {
        public TravelRuleSet()
        {
            InitializeComponent();
        }

        public static DependencyProperty DiscountLevelProperty = DependencyProperty.Register("DiscountLevel", typeof(int), typeof(TravelRuleSet));

        [DescriptionAttribute("DiscountLevel")]
        [CategoryAttribute("DiscountLevel Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public int DiscountLevel
        {
            get
            {
                return ((int)(base.GetValue(TravelRuleSet.DiscountLevelProperty)));
            }
            set
            {
                base.SetValue(TravelRuleSet.DiscountLevelProperty, value);
            }
        }

        public static DependencyProperty DiscountPointsProperty = DependencyProperty.Register("DiscountPoints", typeof(double), typeof(TravelRuleSet));

        [DescriptionAttribute("DiscountPoints")]
        [CategoryAttribute("DiscountPoints Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public double DiscountPoints
        {
            get
            {
                return ((double)(base.GetValue(TravelRuleSet.DiscountPointsProperty)));
            }
            set
            {
                base.SetValue(TravelRuleSet.DiscountPointsProperty, value);
            }
        }

        public static DependencyProperty DestinationProperty = DependencyProperty.Register("Destination", typeof(string), typeof(TravelRuleSet));

        [DescriptionAttribute("Destination")]
        [CategoryAttribute("Destination Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public string Destination
        {
            get
            {
                return ((string)(base.GetValue(TravelRuleSet.DestinationProperty)));
            }
            set
            {
                base.SetValue(TravelRuleSet.DestinationProperty, value);
            }
        }

        public static DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(double), typeof(TravelRuleSet));

        [DescriptionAttribute("Price")]
        [CategoryAttribute("Price Category")]
        [BrowsableAttribute(true)]
        [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
        public double Price
        {
            get
            {
                return ((double)(base.GetValue(TravelRuleSet.PriceProperty)));
            }
            set
            {
                base.SetValue(TravelRuleSet.PriceProperty, value);
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Price calculated by Rules = " + this.Price);
        }
    }
}

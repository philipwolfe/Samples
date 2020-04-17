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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Microsoft.Samples.Workflow.Tutorials.RulesAndConditions
{
    public sealed class DiscountWorkflow : SequentialWorkflowActivity
    {
        private Queue<Coupon> cartCoupons = new Queue<Coupon>();
        private List<ItemData> cartItems = new List<ItemData>();

        private double cartDiscount = 0.0;
        private double cartTotal = 0.0;
        private double cartSubTotal = 0.0;

        private string noItemsError = "You must add items to the shopping cart";
        public string NoItemsErrorMessage
        {
            get { return noItemsError; }
            set { noItemsError = value; }
        }
        private IfElseActivity checkNumItems;
        private IfElseBranchActivity ifNoItems;
        private IfElseBranchActivity elseHasItems;
        private TerminateActivity terminateNoItems;

        public enum CouponType
        {
            PercentageOffTotal,
            PercentageOffLowest,
            PercentageOffHighest,
            FreeItem
        }

        public struct ItemData
        {
            public string name;
            public double price;

            public ItemData(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        };

        public struct Coupon
        {
            public CouponType type;
            public int couponData;

            public Coupon(CouponType type, int couponData)
            {
                this.type = type;
                this.couponData = couponData;
            }
        };

        public Queue<Coupon> Coupons
        {
            get
            {
                return this.cartCoupons;
            }
            set
            {
                this.cartCoupons = value;
            }
        }

        public List<ItemData> Items
        {
            get
            {
                return this.cartItems;
            }
            set
            {
                this.cartItems = value;
            }
        }

        public double Discount
        {
            get
            {
                return this.cartDiscount;
            }
            private set
            {
                this.cartDiscount = value;
            }
        }

        public double Total
        {
            get
            {
                return this.cartTotal;
            }
            private set
            {
                this.cartTotal = value;
            }
        }

        private double SubTotal
        {
            get { return cartSubTotal; }
            set { cartSubTotal = value; }
        }

        public DiscountWorkflow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.checkNumItems = new System.Workflow.Activities.IfElseActivity();
            this.ifNoItems = new System.Workflow.Activities.IfElseBranchActivity();
            this.elseHasItems = new System.Workflow.Activities.IfElseBranchActivity();
            CodeCondition codecondition1 = new CodeCondition();

            this.terminateNoItems = new TerminateActivity();
            ActivityBind activitybind1 = new ActivityBind();

            // 
            // checkNumItems
            // 
            this.checkNumItems.Activities.Add(this.ifNoItems);
            this.checkNumItems.Activities.Add(this.elseHasItems);
            this.checkNumItems.Name = "checkNumItems";
            // 
            // ifNoItems
            // 
            this.ifNoItems.Activities.Add(this.terminateNoItems);
            codecondition1.Condition += new System.EventHandler<ConditionalEventArgs>
                (this.ifNoItems_Condition);
            this.ifNoItems.Condition = codecondition1;
            this.ifNoItems.Name = "ifNoItems";
            // 
            // elseHasItems
            // 
            this.elseHasItems.Name = "elseHasItems";
            // 
            // terminateNoItems
            // 
            activitybind1.Name = "DiscountWorkflow";
            activitybind1.Path = "NoItemsErrorMessage";
            this.terminateNoItems.Name = "terminateNoItems";
            this.terminateNoItems.SetBinding(TerminateActivity.ErrorProperty,
                ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // DiscountWorkflow
            // 
            this.Name = "DiscountWorkflow";
            this.Activities.Add(this.checkNumItems);
            this.CanModifyActivities = false;
        }

        private void ifNoItems_Condition(object sender, ConditionalEventArgs e)
        {
            if (this.Items.Count == 0)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }
    }
}

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
            this.Name = "DiscountWorkflow";
        }
    }
}

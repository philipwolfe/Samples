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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;

namespace Microsoft.Samples.Workflow.Tutorials.RulesAndConditions
{
    public class PointOfSaleSimulator : Form
    {
        private double cartSubTotal = 0;
        private double cartDiscount = 0;
        private double cartTotal = 0;
        private Dictionary<string, object> workflowArgs;
        WorkflowRuntime workflowRuntime = new WorkflowRuntime();

        #region UI Controls
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMoveToCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.ListView lvAvailableItems;
        private System.Windows.Forms.ListView lvCartItems;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvAvailableCoupons;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView lvUsedCoupons;
        private System.Windows.Forms.Button btnMoveFromCoupons;
        private System.Windows.Forms.Button btnMoveToCoupons;
        private System.Windows.Forms.ColumnHeader chItemName;
        private System.Windows.Forms.ColumnHeader chItemPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        #endregion

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] {
            "Apples",
            "1.00"}, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] {
            "Oranges",
            "1.00"}, -1);
            ListViewItem listViewItem3 = new ListViewItem(new string[] {
            "Cheese",
            "5.00"}, -1);
            ListViewItem listViewItem4 = new ListViewItem(new string[] {
            "Magazine",
            "3.00"}, -1);
            ListViewItem listViewItem5 = new ListViewItem(new string[] {
            "Toy Car",
            "2.00"}, -1);
            ListViewItem listViewItem6 = new ListViewItem(new string[] {
            "Game",
            "50.00"}, -1);
            ListViewItem listViewItem7 = new ListViewItem(new string[] {
            "Lettuce",
            "0.60"}, -1);
            ListViewItem listViewItem8 = new ListViewItem(new string[] {
            "20% Off Total Price",
            "Total",
            "20"}, -1);
            ListViewItem listViewItem9 = new ListViewItem(new string[] {
            "15% Off Lowest Item",
            "Lowest",
            "15"}, -1);
            ListViewItem listViewItem10 = new ListViewItem(new string[] {
            "Buy Any 5 Get Lowest Free",
            "FreeItem",
            "5"}, -1);
            ListViewItem listViewItem11 = new ListViewItem(new string[] {
            "10% Off Highest Item",
            "Highest",
            "10"}, -1);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvAvailableItems = new System.Windows.Forms.ListView();
            this.chItemName = new System.Windows.Forms.ColumnHeader();
            this.chItemPrice = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvCartItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnMoveToCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvAvailableCoupons = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvUsedCoupons = new System.Windows.Forms.ListView();
            this.btnMoveFromCoupons = new System.Windows.Forms.Button();
            this.btnMoveToCoupons = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvAvailableItems);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Store Items";
            // 
            // lvAvailableItems
            // 
            this.lvAvailableItems.Columns.AddRange(new ColumnHeader[] {
            this.chItemName,
            this.chItemPrice});
            this.lvAvailableItems.FullRowSelect = true;
            this.lvAvailableItems.HideSelection = false;
            this.lvAvailableItems.Items.AddRange(new ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lvAvailableItems.Location = new System.Drawing.Point(7, 20);
            this.lvAvailableItems.Name = "lvAvailableItems";
            this.lvAvailableItems.Size = new System.Drawing.Size(233, 141);
            this.lvAvailableItems.TabIndex = 0;
            this.lvAvailableItems.UseCompatibleStateImageBehavior = false;
            this.lvAvailableItems.View = System.Windows.Forms.View.Details;
            // 
            // chItemName
            // 
            this.chItemName.Name = "chItemName";
            this.chItemName.Text = "Item";
            // 
            // chItemPrice
            // 
            this.chItemPrice.Name = "chItemPrice";
            this.chItemPrice.Text = "Price";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvCartItems);
            this.groupBox2.Location = new System.Drawing.Point(307, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shopping Cart";
            // 
            // lvCartItems
            // 
            this.lvCartItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCartItems.FullRowSelect = true;
            this.lvCartItems.HideSelection = false;
            this.lvCartItems.Location = new System.Drawing.Point(6, 19);
            this.lvCartItems.Name = "lvCartItems";
            this.lvCartItems.Size = new System.Drawing.Size(233, 141);
            this.lvCartItems.TabIndex = 1;
            this.lvCartItems.UseCompatibleStateImageBehavior = false;
            this.lvCartItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Item";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Price";
            // 
            // btnMoveToCart
            // 
            this.btnMoveToCart.Location = new System.Drawing.Point(265, 63);
            this.btnMoveToCart.Name = "btnMoveToCart";
            this.btnMoveToCart.Size = new System.Drawing.Size(36, 23);
            this.btnMoveToCart.TabIndex = 2;
            this.btnMoveToCart.Text = ">>";
            this.btnMoveToCart.UseVisualStyleBackColor = true;
            this.btnMoveToCart.Click += new 
                System.EventHandler(this.btnMoveToCart_Click);
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.Location = new System.Drawing.Point(265, 101);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(36, 23);
            this.btnRemoveFromCart.TabIndex = 3;
            this.btnRemoveFromCart.Text = "<<";
            this.btnRemoveFromCart.UseVisualStyleBackColor = true;
            this.btnRemoveFromCart.Click += new 
                System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvAvailableCoupons);
            this.groupBox3.Location = new System.Drawing.Point(13, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 130);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available Coupons";
            // 
            // lvAvailableCoupons
            // 
            this.lvAvailableCoupons.HideSelection = false;
            this.lvAvailableCoupons.Items.AddRange(new ListViewItem[] {
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
            this.lvAvailableCoupons.Location = new System.Drawing.Point(6, 19);
            this.lvAvailableCoupons.Name = "lvAvailableCoupons";
            this.lvAvailableCoupons.Size = new System.Drawing.Size(233, 101);
            this.lvAvailableCoupons.TabIndex = 2;
            this.lvAvailableCoupons.UseCompatibleStateImageBehavior = false;
            this.lvAvailableCoupons.View = System.Windows.Forms.View.List;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvUsedCoupons);
            this.groupBox4.Location = new System.Drawing.Point(307, 185);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(246, 130);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Used Coupons";
            // 
            // lvUsedCoupons
            // 
            this.lvUsedCoupons.HideSelection = false;
            this.lvUsedCoupons.Location = new System.Drawing.Point(6, 19);
            this.lvUsedCoupons.Name = "lvUsedCoupons";
            this.lvUsedCoupons.Size = new System.Drawing.Size(233, 101);
            this.lvUsedCoupons.TabIndex = 3;
            this.lvUsedCoupons.UseCompatibleStateImageBehavior = false;
            this.lvUsedCoupons.View = System.Windows.Forms.View.List;
            // 
            // btnMoveFromCoupons
            // 
            this.btnMoveFromCoupons.Location = new System.Drawing.Point(265, 260);
            this.btnMoveFromCoupons.Name = "btnMoveFromCoupons";
            this.btnMoveFromCoupons.Size = new System.Drawing.Size(36, 23);
            this.btnMoveFromCoupons.TabIndex = 5;
            this.btnMoveFromCoupons.Text = "<<";
            this.btnMoveFromCoupons.UseVisualStyleBackColor = true;
            this.btnMoveFromCoupons.Click += new 
                System.EventHandler(this.btnMoveFromCoupons_Click);
            // 
            // btnMoveToCoupons
            // 
            this.btnMoveToCoupons.Location = new System.Drawing.Point(265, 221);
            this.btnMoveToCoupons.Name = "btnMoveToCoupons";
            this.btnMoveToCoupons.Size = new System.Drawing.Size(36, 23);
            this.btnMoveToCoupons.TabIndex = 4;
            this.btnMoveToCoupons.Text = ">>";
            this.btnMoveToCoupons.UseVisualStyleBackColor = true;
            this.btnMoveToCoupons.Click += new 
                System.EventHandler(this.btnMoveToCoupons_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Subtotal";
            // 
            // tbSubTotal
            // 
            this.tbSubTotal.Location = new System.Drawing.Point(258, 329);
            this.tbSubTotal.Name = "tbSubTotal";
            this.tbSubTotal.ReadOnly = true;
            this.tbSubTotal.Size = new System.Drawing.Size(100, 20);
            this.tbSubTotal.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Discount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "____________________________";
            // 
            // tbDiscount
            // 
            this.tbDiscount.Location = new System.Drawing.Point(258, 357);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.ReadOnly = true;
            this.tbDiscount.Size = new System.Drawing.Size(100, 20);
            this.tbDiscount.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(258, 395);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(100, 20);
            this.tbTotal.TabIndex = 12;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(113, 333);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(75, 23);
            this.btnCheckout.TabIndex = 13;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // PointOfSaleSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 425);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSubTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoveFromCoupons);
            this.Controls.Add(this.btnMoveToCoupons);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.btnMoveToCart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PointOfSaleSimulator";
            this.Text = "Point of Sale Simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        
        public PointOfSaleSimulator()
        {
            InitializeComponent();

            workflowRuntime.StartRuntime();

            workflowRuntime.WorkflowCompleted += new 
                EventHandler<WorkflowCompletedEventArgs>
                (workflowRuntime_WorkflowCompleted);
            workflowRuntime.WorkflowTerminated += new 
                EventHandler<WorkflowTerminatedEventArgs>
                (workflowRuntime_WorkflowTerminated);
        }

        public double SubTotal
        {
            get
            {
                return this.cartSubTotal;
            }
            set
            {
                this.cartSubTotal = value;
                this.tbSubTotal.Text = this.cartSubTotal.ToString("C");
            }
        }

        public double Discount
        {
            get
            {
                return this.cartDiscount;
            }
            set
            {
                this.cartDiscount = value;
                this.tbDiscount.Text = this.cartDiscount.ToString("C");
            }
        }

        public double Total
        {
            get
            {
                return this.cartTotal;
            }
            set
            {
                this.cartTotal = value;
                this.tbTotal.Text = this.cartTotal.ToString("C");
            }
        }

        private void btnMoveToCart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAvailableItems.SelectedItems)
            {
                ListViewItem newItem = (ListViewItem)item.Clone();
                this.lvCartItems.Items.Add(newItem);

                this.SubTotal += Double.Parse(item.SubItems[1].Text);
            }
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCartItems.SelectedItems)
            {
                lvCartItems.Items.Remove(item);
                this.SubTotal -= Double.Parse(item.SubItems[1].Text);
            }
        }

        private void btnMoveToCoupons_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvAvailableCoupons.SelectedItems)
            {
                this.lvAvailableCoupons.Items.Remove(item);
                this.lvUsedCoupons.Items.Add(item);
            }
        }

        private void btnMoveFromCoupons_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvUsedCoupons.SelectedItems)
            {
                this.lvUsedCoupons.Items.Remove(item);
                this.lvAvailableCoupons.Items.Add(item);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            BuildWorkflowArgs();

            Type type = typeof(DiscountWorkflow);
            workflowRuntime.CreateWorkflow(type, workflowArgs).Start();
        }

        private void BuildWorkflowArgs()
        {
            Queue<DiscountWorkflow.Coupon> coupons = new 
                Queue<DiscountWorkflow.Coupon>();
            List<DiscountWorkflow.ItemData> items = new 
                List<DiscountWorkflow.ItemData>();

            foreach (ListViewItem item in lvCartItems.Items)
            {
                items.Add(new DiscountWorkflow.ItemData(item.Text, 
                    Double.Parse(item.SubItems[1].Text)));
            }

            foreach (ListViewItem item in lvUsedCoupons.Items)
            {
                switch (item.SubItems[1].Text)
                {
                    case "Highest":
                        coupons.Enqueue(new DiscountWorkflow.Coupon(
                            DiscountWorkflow.CouponType.PercentageOffHighest,
                            Int32.Parse(item.SubItems[2].Text)));
                        break;
                    case "Lowest":
                        coupons.Enqueue(new DiscountWorkflow.Coupon(
                            DiscountWorkflow.CouponType.PercentageOffLowest,
                            Int32.Parse(item.SubItems[2].Text)));
                        break;
                    case "FreeItem":
                        coupons.Enqueue(new DiscountWorkflow.Coupon(
                            DiscountWorkflow.CouponType.FreeItem,
                            Int32.Parse(item.SubItems[2].Text)));
                        break;
                    case "Total":
                        coupons.Enqueue(new DiscountWorkflow.Coupon(
                            DiscountWorkflow.CouponType.PercentageOffTotal,
                            Int32.Parse(item.SubItems[2].Text)));
                        break;
                }
            }

            this.workflowArgs = new Dictionary<string, object>();
            this.workflowArgs["Coupons"] = coupons;
            this.workflowArgs["Items"] = items;

            return;
        }

        void workflowRuntime_WorkflowTerminated(object sender, 
            WorkflowTerminatedEventArgs e)
        {
            MessageBox.Show("Workflow terminated: " + e.Exception.Message);
        }

        void UpdateDiscountAndTotal( object sender, DiscountUpdateEventArgs e )
        {
            this.Discount = e.Discount;
            this.Total = e.Total;
        }

        void workflowRuntime_WorkflowCompleted(object sender, 
            WorkflowCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                double discount = Double.Parse
                    (e.OutputParameters["Discount"].ToString());
                double total = Double.Parse(e.OutputParameters["Total"].ToString());
                
                DiscountUpdateEventArgs values = new 
                    DiscountUpdateEventArgs(discount, total);

                this.Invoke(new EventHandler<DiscountUpdateEventArgs>
                    (UpdateDiscountAndTotal), new object[] { sender, values });
            }
            else
            {
            this.Discount = Double.Parse(e.OutputParameters["Discount"].ToString());
            this.Total = Double.Parse(e.OutputParameters["Total"].ToString());
        }
    }
}

    public class DiscountUpdateEventArgs : EventArgs
    {
        private double cartDiscount;
        private double cartTotal;

        public DiscountUpdateEventArgs(double discount, double total)
        {
            this.cartDiscount = discount;
            this.cartTotal = total;
        }

        public double Discount
        {
            get { return this.cartDiscount; }
        }

        public double Total
        {
            get { return this.cartTotal; }
        }
    }
}

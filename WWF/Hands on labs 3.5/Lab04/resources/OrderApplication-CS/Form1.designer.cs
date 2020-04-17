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

namespace OrderApplication
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btnOrderCreated = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.lstvwOrders = new System.Windows.Forms.ListView();
            this.colWorkflowInstanceID = new System.Windows.Forms.ColumnHeader();
            this.colOrderID = new System.Windows.Forms.ColumnHeader();
            this.colOrderState = new System.Windows.Forms.ColumnHeader();
            this.colWorkflowStatus = new System.Windows.Forms.ColumnHeader();
            this.btnOrderShipped = new System.Windows.Forms.Button();
            this.btnOrderUpdated = new System.Windows.Forms.Button();
            this.btnOrderCanceled = new System.Windows.Forms.Button();
            this.btnOrderProcessed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrderCreated
            // 
            this.btnOrderCreated.Location = new System.Drawing.Point(140, 32);
            this.btnOrderCreated.Name = "btnOrderCreated";
            this.btnOrderCreated.Size = new System.Drawing.Size(99, 23);
            this.btnOrderCreated.TabIndex = 0;
            this.btnOrderCreated.Text = "Order Created";
            this.btnOrderCreated.Click += new System.EventHandler(this.btnOrderCreated_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "OrderID";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(11, 34);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(122, 20);
            this.txtOrderID.TabIndex = 3;
            // 
            // lstvwOrders
            // 
            this.lstvwOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colWorkflowInstanceID,
            this.colOrderID,
            this.colOrderState,
            this.colWorkflowStatus});
            this.lstvwOrders.FullRowSelect = true;
            this.lstvwOrders.GridLines = true;
            this.lstvwOrders.Location = new System.Drawing.Point(2, 72);
            this.lstvwOrders.MultiSelect = false;
            this.lstvwOrders.Name = "lstvwOrders";
            this.lstvwOrders.Size = new System.Drawing.Size(571, 109);
            this.lstvwOrders.TabIndex = 4;
            this.lstvwOrders.View = System.Windows.Forms.View.Details;
            this.lstvwOrders.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstvwOrders_ItemSelectionChanged);
            // 
            // colWorkflowInstanceID
            // 
            this.colWorkflowInstanceID.Text = "Workflow InstanceID";
            this.colWorkflowInstanceID.Width = 186;
            // 
            // colOrderID
            // 
            this.colOrderID.Text = "OrderID";
            this.colOrderID.Width = 100;
            // 
            // colOrderState
            // 
            this.colOrderState.Text = "Order State";
            this.colOrderState.Width = 160;
            // 
            // colWorkflowStatus
            // 
            this.colWorkflowStatus.Text = "Workflow Status";
            this.colWorkflowStatus.Width = 101;
            // 
            // btnOrderShipped
            // 
            this.btnOrderShipped.Location = new System.Drawing.Point(474, 187);
            this.btnOrderShipped.Name = "btnOrderShipped";
            this.btnOrderShipped.Size = new System.Drawing.Size(99, 23);
            this.btnOrderShipped.TabIndex = 5;
            this.btnOrderShipped.Text = "Order Shipped";
            this.btnOrderShipped.Click += new System.EventHandler(this.btnOrderEvent_Click);
            // 
            // btnOrderUpdated
            // 
            this.btnOrderUpdated.Location = new System.Drawing.Point(123, 187);
            this.btnOrderUpdated.Name = "btnOrderUpdated";
            this.btnOrderUpdated.Size = new System.Drawing.Size(99, 23);
            this.btnOrderUpdated.TabIndex = 7;
            this.btnOrderUpdated.Text = "Order Updated";
            this.btnOrderUpdated.Click += new System.EventHandler(this.btnOrderEvent_Click);
            // 
            // btnOrderCanceled
            // 
            this.btnOrderCanceled.Location = new System.Drawing.Point(240, 187);
            this.btnOrderCanceled.Name = "btnOrderCanceled";
            this.btnOrderCanceled.Size = new System.Drawing.Size(99, 23);
            this.btnOrderCanceled.TabIndex = 8;
            this.btnOrderCanceled.Text = "Order Canceled";
            this.btnOrderCanceled.Click += new System.EventHandler(this.btnOrderEvent_Click);
            // 
            // btnOrderProcessed
            // 
            this.btnOrderProcessed.Location = new System.Drawing.Point(357, 187);
            this.btnOrderProcessed.Name = "btnOrderProcessed";
            this.btnOrderProcessed.Size = new System.Drawing.Size(99, 23);
            this.btnOrderProcessed.TabIndex = 9;
            this.btnOrderProcessed.Text = "Order Processed";
            this.btnOrderProcessed.Click += new System.EventHandler(this.btnOrderEvent_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 220);
            this.Controls.Add(this.btnOrderProcessed);
            this.Controls.Add(this.btnOrderCanceled);
            this.Controls.Add(this.btnOrderUpdated);
            this.Controls.Add(this.btnOrderShipped);
            this.Controls.Add(this.lstvwOrders);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOrderCreated);
            this.Name = "Form1";
            this.Text = "Order Application - State Machine Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOrderID;
		private System.Windows.Forms.ListView lstvwOrders;
		private System.Windows.Forms.ColumnHeader colOrderID;
		private System.Windows.Forms.ColumnHeader colWorkflowInstanceID;
        private System.Windows.Forms.Button btnOrderShipped;
		private System.Windows.Forms.Button btnOrderUpdated;
		private System.Windows.Forms.Button btnOrderCanceled;
		private System.Windows.Forms.Button btnOrderProcessed;
        private System.Windows.Forms.ColumnHeader colOrderState;
        private System.Windows.Forms.Button btnOrderCreated;
		private System.Windows.Forms.ColumnHeader colWorkflowStatus;
	}
}


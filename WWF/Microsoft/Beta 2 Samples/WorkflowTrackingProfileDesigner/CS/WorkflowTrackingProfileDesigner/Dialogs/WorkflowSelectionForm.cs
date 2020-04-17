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
using System.Reflection;
using Microsoft.Samples.Workflow.WorkflowDesignerControl;

namespace WorkflowChooser
{
    public partial class WorkflowSelectionForm : Form
    {
		private WorkflowDesignerControl workflowView = new WorkflowDesignerControl();
        public WorkflowSelectionForm()
        {
            InitializeComponent();
            workflowView.AutoSize = true;
            workflowView.Dock = DockStyle.Fill;            
        }

        private List<Type> workflowTypes;

		/// <summary>
		/// The list of workflow types that need to be displayed
		/// </summary>
        public List<Type> WorkflowTypes
        {
            get { return workflowTypes; }
            set { workflowTypes = value; }
        }

        private Type selectedWorkflow=null;
       
		/// <summary>
		/// Holds selected workflow after the dialog is closed
		/// </summary>
        public Type SelectedWorkflow
        {
            get { return selectedWorkflow; }
        }

        Dictionary<ListViewItem, Type> listViewWorkflowMap = new Dictionary<ListViewItem, Type>();

        private void WorkflowSelectionForm_Load(object sender, EventArgs e)
        {
            if (WorkflowTypes.Count == 1)
            {
                this.workflowListView.Visible = false;
                this.descriptionHeader.Location = this.workflowListView.Location;
                this.workflowDescription.Location = new Point(this.workflowDescription.Location.X, this.workflowDescription.Location.Y + this.workflowDescription.Height + 10);
                selectedWorkflow = workflowTypes[0];
                this.workflowDescription.Text = selectedWorkflow.FullName;
            }
            else
            {
                foreach (Type t in WorkflowTypes)
                {
                    ListViewItem item = new ListViewItem(t.Name);
                    listViewWorkflowMap.Add(item, t);
                    workflowListView.Items.Add(item);
                }
                workflowListView.Items[0].Selected = true;
            }
            
            this.workflowViewPanel.Controls.Add(workflowView);
			this.workflowView.WorkflowType = SelectedWorkflow;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.selectedWorkflow = null;
            this.Close();
        }

        private void workflowListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (workflowListView.SelectedItems.Count == 0) return;

            selectedWorkflow = listViewWorkflowMap[workflowListView.SelectedItems[0]];
            this.workflowDescription.Text = selectedWorkflow.FullName;
            this.workflowDescription.Visible = true;
			workflowView.WorkflowType = SelectedWorkflow;
        }
    }
}
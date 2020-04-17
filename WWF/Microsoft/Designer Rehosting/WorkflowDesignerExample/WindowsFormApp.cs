//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using WorkflowDesignerControl;
using System.Drawing.Design;
using System.Workflow.ComponentModel.Design;

namespace WorkflowDesignerExample
{
	public partial class WindowsFormApp : Form
	{
		public WindowsFormApp()
		{
			InitializeComponent();
		}

      
        #region event handlers

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.Save(null);
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.ShowDefaultWorkflow();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.workflowDesignerControl1.Dock = DockStyle.Fill;
                this.workflowDesignerControl1.LoadWorkflow(openFileDialog.FileName);

                ToolboxService toolbox = ((IServiceProvider)this.workflowDesignerControl1).GetService(typeof(IToolboxService)) as ToolboxService;
                if (toolbox != null)
                {
                    toolbox.BorderStyle = BorderStyle.FixedSingle;
                    toolbox.Dock = DockStyle.Fill;
                    this.toolBoxSplitContainer.Panel1.Controls.Add(toolbox);
                }
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.workflowDesignerControl1.Save(saveFileDialog.FileName);
            }
        }

        private void PageSetupMenuItem_Click(object sender, EventArgs e)
        {
            WorkflowView workflowView = this.workflowDesignerControl1.WorkflowView;
            if (null != workflowView)
            {
                WorkflowPageSetupDialog pageSetupDialog = new WorkflowPageSetupDialog(this.workflowDesignerControl1.WorkflowView as IServiceProvider);
                if (DialogResult.OK == pageSetupDialog.ShowDialog())
                    workflowView.PerformLayout();
            }
        }

        private void PrintPreviewMenuItem_Click(object sender, EventArgs e)
        {
            WorkflowView workflowView = this.workflowDesignerControl1.WorkflowView;
            if (workflowView != null)
            {
                this.workflowDesignerControl1.SuspendLayout();
                workflowView.PrintPreviewMode = !workflowView.PrintPreviewMode;
                PrintPreviewMenuItem.Checked = workflowView.PrintPreviewMode;
                workflowView.ClientSize = this.workflowDesignerControl1.ClientSize;
                this.workflowDesignerControl1.ResumeLayout(true);
            }
        }
        
        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            WorkflowView workflowView = this.workflowDesignerControl1.WorkflowView;
            if (null != workflowView)
            {
                //select printer
                PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.AllowPrintToFile = false;
                printDialog.Document = workflowView.PrintDocument;

                try
                {
                    printDialog.ShowDialog();
                }
                catch
                {
                    string errorString = "Error selecting new printer";
                    MessageBox.Show(this, errorString, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(StandardCommands.Cut);
        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(StandardCommands.Copy);
        }

        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(StandardCommands.Paste);
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(StandardCommands.Delete);
        }

        private void zoom400MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom400Mode);
        }

        private void zoom300MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom300Mode);
        }

        private void zoom200MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom200Mode);
        }

        private void zoom150MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom150Mode);
        }

        private void zoom100MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom100Mode);
        }

        private void zoom75MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom75Mode);
        }

        private void zoom50MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Zoom50Mode);
        }

        private void zoom10MenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.WorkflowView.Zoom = 10;
        }

        private void zoomShowAllMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.ShowAll);
        }

        private void zoomInNavigationMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.ZoomIn);
            this.zoomInToolButton.Checked = true;
        }

        private void zoomOutNavigationMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.ZoomOut);
            this.zoomOut.Checked = true;
        }

        private void panNavigationMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Pan);
        }

        private void defaultNavigationMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.DefaultFilter);
        }

        private void expandMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Expand);
        }

        private void collapseMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.InvokeStandardCommand(WorkflowMenuCommands.Collapse);
        }

        
        //zoom level combo box handling
        private bool zoomLevelDirty = false;

        private void zoomLevelToolStripButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseZoomLevelValue();
        }

        private void zoomLevelToolStripButton_Leave(object sender, EventArgs e)
        {
            if (this.zoomLevelDirty)
            {
                ParseZoomLevelValue();
                this.zoomLevelDirty = false;
            }
        }

        private void ParseZoomLevelValue()
        {
            //parse the value
            string newZoom = zoomLevelToolStripButton.Text.Trim();
            if (newZoom.EndsWith("%"))
                newZoom = newZoom.Substring(0, newZoom.Length - 1);

            if (newZoom.Length > 0)
            {
                string errorMessage = null;

                try
                {
                    this.workflowDesignerControl1.WorkflowView.Zoom = Convert.ToInt32(newZoom);
                }
                catch (FormatException)
                {
                    errorMessage = "Invalid Zoom Measurement";
                }
                catch
                {
                    errorMessage = "Invalid Zoom Range";
                }

                if (errorMessage != null)
                    MessageBox.Show(this, errorMessage);
            }
        }

        private void zoomLevelToolStripButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Escape)
            {
                zoomLevelDirty = true;
            }
        }

        private void zoomLevelToolStripButton_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ParseZoomLevelValue();
                zoomLevelDirty = false;
                this.workflowDesignerControl1.WorkflowView.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //revert the changes back to the zoom level from the workflow
                zoomLevelToolStripButton.Text = this.workflowDesignerControl1.WorkflowView.Zoom + "%";
                zoomLevelDirty = false;
                this.workflowDesignerControl1.WorkflowView.Focus();
            }
            else
            {
                zoomLevelDirty = true;
            }
        }

        
        private void CompileWorkflow(object sender, EventArgs e)
        {
            this.workflowDesignerControl1.CompileWorkflow();

        }
        #endregion

    }
}
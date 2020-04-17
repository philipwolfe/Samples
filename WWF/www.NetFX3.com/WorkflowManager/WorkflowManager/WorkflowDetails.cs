using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Workflow.Samples.Administration;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    partial class WorkflowDetailsForm : Form
    {
        private IWorkflowInstance instance;
        private WorkflowDetailsControl workflowDetailsControl;

        public WorkflowDetailsForm(IWorkflowInstance instance)
        {
            this.instance = instance;

            InitializeComponent();

            this.typeRichTextBox.Text = this.instance.Type;
            this.activatedRichTextBox.Text = this.instance.ActivationTime.ToLongDateString() + " " + this.instance.ActivationTime.ToShortTimeString();
            this.titleRichTextBox.Text = this.instance.Title;

            this.workflowDetailsControl = new WorkflowDetailsControl(instance);
            this.workflowDetailsControl.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.workflowDetailsControl);

            this.workflowDetailsControl.InstanceStateChanged += new EventHandler(workflowDetailsControl_InstanceStateChanged);

            UpdateLiveCommandsState();
            SwitchToReadMode();

            InstanceStateChangeType changeType = this.instance.Completed ? InstanceStateChangeType.Completed : this.instance.Suspended ? InstanceStateChangeType.Suspended : InstanceStateChangeType.Resumed;
            if (!(this.instance is LiveInstanceProxy))
                changeType = InstanceStateChangeType.Completed;

            StateChangeUIEventFirer(this, new InstanceStateChangeEventArgs(this.instance.InstanceId, changeType));
        }

        protected override void OnClosed(EventArgs e)
        {
            ((IDisposable)this.workflowDetailsControl).Dispose();
            base.OnClosed(e);
        }

        private void SwitchToEditMode()
        {
            this.workflowDetailsControl.InEditMode = true;
            this.mainPanel.BackColor = SystemColors.Window;

            Color lightBlueBackgroundColor = Color.FromArgb(191, 215, 249);//by a dropper tool
            this.titlePanel.BackColor = lightBlueBackgroundColor;
            this.typeLabel.BackColor = lightBlueBackgroundColor;
            this.typeRichTextBox.BackColor = lightBlueBackgroundColor;
            this.activatedLabel.BackColor = lightBlueBackgroundColor;
            this.activatedRichTextBox.BackColor = lightBlueBackgroundColor;
            this.titleLabel.BackColor = lightBlueBackgroundColor;
            this.titleRichTextBox.BackColor = lightBlueBackgroundColor;

            this.contentPanel.BorderStyle = BorderStyle.None;
            this.contentPanel.BackColor = SystemColors.Window;
        }

        private void SwitchToReadMode()
        {
            this.workflowDetailsControl.InEditMode = false;
            this.titlePanel.BackColor = SystemColors.Control;
            this.mainPanel.BackColor = SystemColors.Control;
            this.typeLabel.BackColor = SystemColors.Control;
            this.typeRichTextBox.BackColor = SystemColors.Control;
            this.activatedLabel.BackColor = SystemColors.Control;
            this.activatedRichTextBox.BackColor = SystemColors.Control;
            this.titleLabel.BackColor = SystemColors.Control;
            this.titleRichTextBox.BackColor = SystemColors.Control;
            this.contentPanel.BorderStyle = BorderStyle.FixedSingle;
            this.contentPanel.BackColor = SystemColors.Control;
        }

        private void UpdateLiveCommandsState()
        {
            if (!(this.instance is LiveInstanceProxy))
            {
                this.acceptChangeToolButton.Enabled = false;
                this.cancelChangesToolButton.Enabled = false;
                this.changeToolButton.Enabled = false;

                this.suspendToolButton.Enabled = false;
                this.resumeToolButton.Enabled = false;
                this.terminateToolButton.Enabled = false;
            }
        }

        private void changeToolButton_Click(object sender, EventArgs e)
        {
            this.changeToolButton.Visible = false;
            this.acceptChangeToolButton.Visible = true;
            this.cancelChangesToolButton.Visible = true;

            this.workflowDetailsControl.OnDynamicUpdateEnabled();

            SwitchToEditMode();
        }

        private void acceptChangeToolButton_Click(object sender, EventArgs e)
        {
            this.acceptChangeToolButton.Visible = false;
            this.cancelChangesToolButton.Visible = false;
            this.changeToolButton.Visible = true;

            this.workflowDetailsControl.OnDynamicUpdateCommit();

            SwitchToReadMode();
        }

        private void cancelChangesToolButton_Click(object sender, EventArgs e)
        {
            this.acceptChangeToolButton.Visible = false;
            this.cancelChangesToolButton.Visible = false;
            this.changeToolButton.Visible = true;

            this.workflowDetailsControl.OnDynamicUpdateCanceled();

            SwitchToReadMode();
        }

        private void expandOutlineToolButton_Click(object sender, EventArgs e)
        {
            this.expandOutlineToolButton.Visible = false;
            this.aggreagateOutlineToolButton.Visible = true;
        }

        private void aggreagateOutlineToolButton_Click(object sender, EventArgs e)
        {
            this.aggreagateOutlineToolButton.Visible = false;
            this.expandOutlineToolButton.Visible = true;
        }

        private void suspendToolButton_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.Suspend();
        }

        private void resumeToolButton_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.Resume();
        }

        private void terminateToolButton_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.Terminate();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.InvokeStandardCommand(StandardCommands.Cut);
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.InvokeStandardCommand(StandardCommands.Copy);
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.InvokeStandardCommand(StandardCommands.Paste);
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            this.workflowDetailsControl.InvokeStandardCommand(StandardCommands.Delete);

        }

        void workflowDetailsControl_InstanceStateChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new EventHandler(StateChangeUIEventFirer), new object[] { sender, e });
        }
        private void StateChangeUIEventFirer(object sender, EventArgs e)
        {
            InstanceStateChangeEventArgs args = e as InstanceStateChangeEventArgs;
            if (args.ChangeType == InstanceStateChangeType.Completed || args.ChangeType == InstanceStateChangeType.Terminated)
            {
                //instance completed
                this.acceptChangeToolButton.Enabled = false;
                this.acceptChangeToolButton.Visible = false;
                this.cancelChangesToolButton.Enabled = false;
                this.cancelChangesToolButton.Visible = false;
                this.changeToolButton.Enabled = false;
                this.changeToolButton.Visible = true;

                this.suspendToolButton.Enabled = false;
                this.resumeToolButton.Enabled = false;
                this.terminateToolButton.Enabled = false;
            }
            else if (args.ChangeType == InstanceStateChangeType.Suspended)
            {
                this.suspendToolButton.Enabled = false;
                this.resumeToolButton.Enabled = true;
                this.terminateToolButton.Enabled = true;
            }
            else if (args.ChangeType == InstanceStateChangeType.Resumed)
            {
                this.suspendToolButton.Enabled = true;
                this.resumeToolButton.Enabled = false;
                this.terminateToolButton.Enabled = true;
            }
        }
    }
}
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    public delegate void OnPrepareContextMenu(Activity[] selectedActivities, ArrayList menuItems);

    public class WFPreviewControl : UserControl
    {
        private Panel previewPanel;
        private RichTextBox titleTextBox;
        private RichTextBox typeTextBox;
        private Panel previewContentPanel;
        private ViewHost viewHost = null;
        public event OnPrepareContextMenu OnPrepareContextMenu;

        private IWorkflowInstance selectedInstance = null;
        public IWorkflowInstance SelectedInstance
        {
            get { return this.selectedInstance; }
            set
            {
                if (this.selectedInstance == value)
                    return;

                this.selectedInstance = value;
                if (this.selectedInstance != null)
                {
                    if (!this.previewContentPanel.Controls.Contains(this.viewHost))
                        this.previewContentPanel.Controls.Add(this.viewHost);

                    this.viewHost.Open(this.selectedInstance.Xoml, true);
                    this.titleTextBox.Text = this.selectedInstance.Title;
                    this.typeTextBox.Text = this.selectedInstance.Type;
                }
                else
                {
                    if (this.previewContentPanel.Controls.Contains(this.viewHost))
                        this.previewContentPanel.Controls.Remove(this.viewHost);

                    this.titleTextBox.Text = string.Empty;
                    this.typeTextBox.Text = string.Empty;
                }
            }
        }

        public WFPreviewControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            InitializeComponent();

            this.previewPanel.Paint += new PaintEventHandler(previewPanel_Paint);

            InitializeWorkflowView();
        }

        void previewPanel_Paint(object sender, PaintEventArgs e)
        {
            Point begin = new Point(this.previewContentPanel.Location.X, (this.previewContentPanel.Location.Y + this.typeTextBox.Bounds.Bottom) / 2);
            Point end = new Point(this.previewContentPanel.Bounds.Right, begin.Y);
            e.Graphics.DrawLine(SystemPens.ControlDark, begin, end);
        }

        private void InitializeWorkflowView()
        {
            //Now initialize the contained components
            this.viewHost = new ViewHost();
            this.viewHost.OnPrepareContextMenu += new OnPrepareContextMenu(viewHost_OnPrepareContextMenu);
            this.viewHost.Dock = DockStyle.Fill;
        }

        public void Initialize(string xoml)
        {
            if (xoml != null)
                this.viewHost.Open(xoml, true);
        }

        public void PopulateActivityStateProvider(ActivityStateProvider activityStateProvider)
        {
            if (this.viewHost != null)
                this.viewHost.ProfferService(typeof(IActivityStateProvider), activityStateProvider);
        }

        public IServiceProvider GetServiceProvider()
        {
            return this.viewHost;
        }

        public void UpdTrackedEventateSelection(object[] selectedEvents)
        {
            WorkflowView workflowView = this.viewHost.WorkflowView;
            if (workflowView != null)
            {
                Hashtable trackedActivities = new Hashtable();
                foreach (TrackedActivity trackedActivity in selectedEvents)
                {
                    //see if there is already a later event for the id
                    if (trackedActivities.Contains(trackedActivity.QualifiedName))
                    {
                        TrackedActivity otherTrackedActivity = trackedActivities[trackedActivity.QualifiedName] as TrackedActivity;
                        if (trackedActivity.EventDateTime > otherTrackedActivity.EventDateTime)
                            trackedActivities.Remove(trackedActivity.QualifiedName);
                    }
                    if (!trackedActivities.Contains(trackedActivity.QualifiedName))
                        trackedActivities.Add(trackedActivity.QualifiedName, trackedActivity);
                }

                //now lets walk the activity tree and see if we got an event for any activity
                Walker walker = new Walker();
                walker.FoundActivity += delegate(Walker skedWalker, WalkerEventArgs eventArgs)
                {
                    Activity activity = eventArgs.CurrentActivity;
                    TrackedActivity trackedActivity = trackedActivities[activity.QualifiedName] as TrackedActivity;
                    if (trackedActivity != null)
                    {
                        UpdateCurrentSelectedActivity(activity);
                    }
                };
                walker.Walk(workflowView.RootDesigner.Activity);
                workflowView.Invalidate();
            }
        }

        private void UpdateCurrentSelectedActivity(Activity activity)
        {
            WorkflowView workflowView = this.viewHost.WorkflowView;
            ISelectionService selectionService = ((IServiceProvider)this.viewHost).GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SetSelectedComponents(new IComponent[] { activity }, SelectionTypes.Replace);

            workflowView.EnsureVisible(activity);
        }

        void viewHost_OnPrepareContextMenu(Activity[] selectedActivities, ArrayList menuItems)
        {
            if (this.OnPrepareContextMenu != null)
            {
                this.OnPrepareContextMenu.DynamicInvoke(new object[] { selectedActivities, menuItems });
            }
        }

        private void InitializeComponent()
        {
            this.previewPanel = new System.Windows.Forms.Panel();
            this.previewContentPanel = new System.Windows.Forms.Panel();
            this.typeTextBox = new System.Windows.Forms.RichTextBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.previewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewPanel.BackColor = System.Drawing.SystemColors.Window;
            this.previewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPanel.Controls.Add(this.previewContentPanel);
            this.previewPanel.Controls.Add(this.typeTextBox);
            this.previewPanel.Controls.Add(this.titleTextBox);
            this.previewPanel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.previewPanel.Location = new System.Drawing.Point(6, 6);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(500, 600);
            this.previewPanel.TabIndex = 0;
            // 
            // previewContentPanel
            // 
            this.previewContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.previewContentPanel.Location = new System.Drawing.Point(10, 80);
            this.previewContentPanel.Name = "previewContentPanel";
            this.previewContentPanel.Size = new System.Drawing.Size(480, 506);
            this.previewContentPanel.TabIndex = 2;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.typeTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.typeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.typeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeTextBox.Location = new System.Drawing.Point(10, 53);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(480, 20);
            this.typeTextBox.TabIndex = 1;
            this.typeTextBox.Text = "";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.DetectUrls = false;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(10, 10);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(480, 36);
            this.titleTextBox.TabIndex = 0;
            this.titleTextBox.Text = "";
            // 
            // WFPreviewControl
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.previewPanel);
            this.Name = "WFPreviewControl";
            this.Size = new System.Drawing.Size(512, 612);
            this.previewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
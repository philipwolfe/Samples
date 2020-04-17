using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Microsoft.Workflow.Samples.WorkflowManager
{
    partial class WorkflowManager : Form
    {
        private WorkflowInstanceManager instManager = null;

        public WorkflowManager()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            this.imageList1.TransparentColor = Color.FromArgb(255, 0, 255);
            this.wfStateImageList.TransparentColor = Color.FromArgb(255, 0, 255);

            this.dataGridViewExplore1.StateImageList = this.wfStateImageList;

            this.instManager = WorkflowInstanceManager.GetWorkflowInstanceManager(this.dataGridViewExplore1);

            InitializeWorkflowListViewControl();
            InitializeDataSourceTree();

            this.list_preview.BorderStyle = BorderStyle.FixedSingle;
            this.sources_MainViews.BorderStyle = BorderStyle.FixedSingle;
            this.list_preview.ForeColor = SystemColors.HighlightText;
            this.sources_MainViews.ForeColor = SystemColors.HighlightText;

            this.wfPreviewControl1.SelectedInstance = null;
        }

        #region workflow list management
        private void InitializeWorkflowListViewControl()
        {
            this.dataGridViewExplore1.RowHeadersVisible = false;
            this.dataGridViewExplore1.ReadOnly = true;

            this.dataGridViewExplore1.DataSource = this.instManager;

            this.dataGridViewExplore1.Columns.Clear();
            AddDefaultColumn(this.dataGridViewExplore1);

            this.dataGridViewExplore1.SelectionChanged += new EventHandler(dataGridViewExplore1_SelectionChanged);
            this.dataGridViewExplore1.MouseDoubleClick += new MouseEventHandler(dataGridViewExplore1_MouseDoubleClick);
            this.dataGridViewExplore1.EnterKeyDown += new KeyEventHandler(dataGridViewExplore1_KeyDown);
        }

        private void AddDefaultColumn(DataGridViewExplore dataGridViewExplore)
        {
            string headerText = "Sorted By Activation Date";
            int width = dataGridViewExplore.ClientSize.Width;

            DataGridViewColumn column = new TwoLineColumn();
            column.HeaderText = headerText;
            column.Width = width;
            column.MinimumWidth = width;
            column.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            column.SortMode = DataGridViewColumnSortMode.NotSortable;

            int columnIndex = dataGridViewExplore.Columns.Add(column);
            column.Resizable = DataGridViewTriState.False;
        }
        #endregion

        #region data source management
        private void InitializeDataSourceTree()
        {
            this.workflowDataSources.ImageList = this.imageList1;
            this.workflowDataSources.Nodes.Add(new TreeNode("Workflows", 0, 0));

            TreeNode liveNode = new TreeNode("Live", 1, 1);
            liveNode.Tag = DataSelectionType.Live;
            this.workflowDataSources.Nodes[0].Nodes.Add(liveNode);

            TreeNode trackedNode = new TreeNode("Tracked", 2, 2);
            trackedNode.Tag = DataSelectionType.Tracked;

            this.workflowDataSources.Nodes[0].Nodes.Add(trackedNode);
            this.workflowDataSources.ExpandAll();

            this.workflowDataSources.AfterSelect += new TreeViewEventHandler(workflowDataSources_AfterSelect);
            this.workflowDataSources.SelectedNode = liveNode;
        }

        private Timer timer = new Timer();

        private void workflowDataSources_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = this.workflowDataSources.SelectedNode;

            this.wfPreviewControl1.SelectedInstance = null;

            if (selectedNode == null || selectedNode.Tag == null)
                this.instManager.SelectionType = DataSelectionType.None;
            else
                this.instManager.SelectionType = (DataSelectionType)selectedNode.Tag;

            this.sectionHeader2.HeaderText = this.instManager.SelectionDescription;

            this.dataGridViewExplore1.Focus();

            this.timer.Interval = 100;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.timer.Tick -= new EventHandler(timer_Tick);
            this.Refresh();
        }
        #endregion

        void dataGridViewExplore1_SelectionChanged(object sender, EventArgs e)
        {
            //pass the selection to the preview pane
            if (this.dataGridViewExplore1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridViewExplore1.SelectedRows[0];
                TwoLineGridRowItem twoLineGridRowItem = row.DataBoundItem as TwoLineGridRowItem;
                if (twoLineGridRowItem != null)
                {
                    IWorkflowInstance instance = twoLineGridRowItem.Instance;
                    this.wfPreviewControl1.SelectedInstance = instance;
                }
            }
            else
            {
                this.wfPreviewControl1.SelectedInstance = null;
            }
        }

        void dataGridViewExplore1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //open details view for the workflow
            OpenDetailsView();
        }

        void dataGridViewExplore1_KeyDown(object sender, KeyEventArgs e)
        {
            //on "enter" key down open the details view
            if (e.KeyValue == (int)Keys.Enter)
                OpenDetailsView();
        }

        private void OpenDetailsView()
        {
            //pass the selection to the preview pane
            if (this.dataGridViewExplore1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dataGridViewExplore1.SelectedRows[0];
                TwoLineGridRowItem twoLineGridRowItem = row.DataBoundItem as TwoLineGridRowItem;
                IWorkflowInstance instance = twoLineGridRowItem.Instance;

                WorkflowDetailsForm workflowDetailsForm = new WorkflowDetailsForm(instance);
                workflowDetailsForm.Show();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
        }
    }

    internal class SectionHeader : Panel
    {
        // const values
        private class Consts
        {
            public static Pen PenTop = new Pen(Color.FromArgb(180, 210, 245));
            public static Pen PenBottom = new Pen(SystemColors.InactiveCaption);
            public const int PosOffset = 4;
        }

        private LinearGradientBrush brush = null;
        private string text = string.Empty;

        public string HeaderText
        {
            get { return this.text; }

            set
            {
                this.text = value;
                Invalidate();
            }
        }

        public SectionHeader()
        {
            this.ForeColor = SystemColors.Highlight;
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        // the caption needs to be drawn
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
            base.OnPaint(e);
        }

        // draw the caption
        private void Draw(Graphics g)
        {
            if (Width != 0 && Height != 0)
            {
                // background
                if (this.brush != null)
                    g.FillRectangle(this.brush, DisplayRectangle);

                // header text
                Font font = new Font(this.Font.FontFamily, this.Font.Size + 1, FontStyle.Bold);
                g.DrawString(this.text, font, SystemBrushes.HighlightText, Consts.PosOffset, ((Height - font.Height) / 2));

                // top and bottom lines
                g.DrawLine(Consts.PenTop, 0, 0, Width - 1, 0);
                g.DrawLine(Consts.PenBottom, 0, Height - 1, Width - 1, Height - 1);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (Width > 0 && Height > 0)
            {
                Color ColorLow = SystemColors.Highlight;
                Color ColorHigh = TwoThirds(ColorLow);
                this.brush = new LinearGradientBrush(DisplayRectangle, ColorHigh, ColorLow, LinearGradientMode.Vertical);
            }
        }

        private Color TwoThirds(Color color)
        {
            return Color.FromArgb(TwoThirds(color.R), TwoThirds(color.G), TwoThirds(color.B));
        }

        private int TwoThirds(int value)
        {
            float twoThirds = (float)value + (256.0f - (float)value) / 3.0f;
            return (int)twoThirds;
        }
    }
}
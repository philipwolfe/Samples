using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace Microsoft.Workflow.Samples.WorkflowManager.Design
{
    public class ExtendedDocumentOutline : UserControl
    {
        private Hashtable componentToNodeMapping = new Hashtable();

        private TreeView treeView;
        private IServiceProvider serviceProvider;

        private Font executedActivityFont;
        private Font executingActivityFont;

        public ExtendedDocumentOutline(IServiceProvider serviceProvider)
        {
            Debug.Assert(serviceProvider != null, "Creating ExtendedDocumentOutline without service host");

            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            SetServiceProvider(serviceProvider);

            // Set up treeview
            this.treeView = new TreeView();
            this.treeView.Dock = DockStyle.Fill;
            this.treeView.HideSelection = false;
            this.treeView.AfterSelect += new TreeViewEventHandler(this.OnTreeViewAfterSelect);
            this.treeView.MouseDown += new MouseEventHandler(this.OnTreeViewMouseDown);
            this.treeView.ItemHeight = Math.Max(this.treeView.ItemHeight, 18);
            this.Controls.Add(this.treeView);
            UpdateTreeView();
        }

        private void SetServiceProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            // Get an ISelectionService service
            ISelectionService selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
        }

        public void ResetServiceProvider(IServiceProvider serviceProvider)
        {
            // Get an ISelectionService service
            ISelectionService selectionService = null;
            if (this.serviceProvider != null)
                selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null)
                selectionService.SelectionChanged -= new System.EventHandler(this.OnSelectionChanged);

            SetServiceProvider(serviceProvider);
            ReloadDocOutline();
        }

        public void ReloadDocOutline()
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }

            //clear the items collection
            Invoke((MethodInvoker)delegate()
            {
                // This runs on the UI thread!
                UpdateTreeView();
            });
        }

        private void InsertDocOutlineNode(ExtendedTreeNode node, IComponent component, int childIndex, bool addNestedActivities)
        {
            if (this.componentToNodeMapping.Contains(component))
                return;

            Activity activity = component as Activity;
            ExtendedTreeNode newNode = new ExtendedTreeNode(activity.Name);
            newNode.Tag = activity;
            UpdateTreeNodeProperties(newNode);
            this.componentToNodeMapping.Add(activity, newNode);

            if (addNestedActivities && activity is CompositeActivity)
            {
                foreach (Activity childActivity in ((CompositeActivity)activity).Activities)
                    InsertDocOutlineNode(newNode, childActivity, newNode.Nodes.Count, addNestedActivities);
            }

            if (node != null)
                node.Nodes.Insert(childIndex, newNode);
            else
                this.treeView.Nodes.Add(newNode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.serviceProvider != null)
                {
                    ISelectionService selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
                    if (selectionService != null)
                        selectionService.SelectionChanged -= new System.EventHandler(OnSelectionChanged);

                    this.serviceProvider = null;
                }

                if (this.executingActivityFont != null)
                {
                    this.executingActivityFont.Dispose();
                    this.executingActivityFont = null;
                }

                if (this.executedActivityFont != null)
                {
                    this.executedActivityFont.Dispose();
                    this.executedActivityFont = null;
                }
            }
            base.Dispose(disposing);
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null && selectionService.PrimarySelection != null)
            {
                this.treeView.SelectedNode = (ExtendedTreeNode)this.componentToNodeMapping[selectionService.PrimarySelection];
                if (this.treeView.SelectedNode != null)
                    this.treeView.SelectedNode.EnsureVisible();
            }
        }

        private void OnTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            // Change the primary selection of the selection service
            ISelectionService selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null && selectionService.PrimarySelection != e.Node.Tag)
            {
                // make the selected shape visible (note - the order is important, EnsureVisible will 
                // expand appropiate branches and set CAG into edit mode, which is crucial for 
                // SetSelectedComponents to perform well)
                WorkflowView designerService = this.serviceProvider.GetService(typeof(WorkflowView)) as WorkflowView;
                if (designerService != null)
                    designerService.EnsureVisible(e.Node.Tag);

                // select it
                selectionService.SetSelectedComponents(new object[] { e.Node.Tag }, SelectionTypes.Replace);
            }
        }

        private void OnTreeViewMouseDown(object sender, MouseEventArgs e)
        {
            if (this.treeView.GetNodeAt(e.Location) != null)
                this.treeView.SelectedNode = this.treeView.GetNodeAt(e.Location);
        }

        private void UpdateTreeView()
        {
            this.treeView.BeginUpdate();
            try
            {
                this.treeView.Nodes.Clear();
                this.componentToNodeMapping.Clear();

                IRootDesigner rootDesigner = GetRootDesigner(this.serviceProvider) as IRootDesigner;
                if (rootDesigner != null && rootDesigner.Component != null)
                    InsertDocOutlineNode(null, rootDesigner.Component, 0, true);

                this.treeView.ExpandAll();
            }
            finally
            {
                this.treeView.EndUpdate();
            }

            ISelectionService selectionService = this.serviceProvider.GetService(typeof(ISelectionService)) as ISelectionService;
            if (selectionService != null && selectionService.PrimarySelection != null)
            {
                this.treeView.SelectedNode = (ExtendedTreeNode)this.componentToNodeMapping[selectionService.PrimarySelection];
                if (this.treeView.SelectedNode != null)
                    this.treeView.SelectedNode.EnsureVisible();
            }
        }

        internal static IRootDesigner GetRootDesigner(IServiceProvider serviceProvider)
        {
            ActivityDesigner rootDesigner = null;
            if (serviceProvider != null)
            {
                IDesignerHost designerHost = serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                    rootDesigner = GetDesigner(serviceProvider, designerHost.RootComponent as Activity) as ActivityDesigner;
            }
            return rootDesigner;
        }
        internal static ActivityDesigner GetDesigner(IServiceProvider serviceProvider, Activity activity)
        {
            ActivityDesigner designer = null;

            if (activity != null && activity.Site != null)
            {
                IDesignerHost designerHost = serviceProvider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost != null)
                    designer = designerHost.GetDesigner(activity) as ActivityDesigner;
            }
            return designer;
        }

        private void UpdateTreeNodeProperties(ExtendedTreeNode nodeToUpdate)
        {
            this.treeView.BeginUpdate();

            Queue<ExtendedTreeNode> treeNodeQ = new Queue<ExtendedTreeNode>();
            treeNodeQ.Enqueue(nodeToUpdate);
            while (treeNodeQ.Count > 0)
            {
                ExtendedTreeNode treeNode = treeNodeQ.Dequeue();

                Activity activity = treeNode.Tag as Activity;
                if (activity != null)
                {
                    treeNode.ForeColor = SystemColors.WindowText;

                    //Update the designer image
                    int imageIndex = (this.treeView.ImageList != null) ? this.treeView.ImageList.Images.IndexOfKey(activity.GetType().FullName) : -1;
                    if (imageIndex == -1)
                    {
                        ActivityDesigner activityDesigner = GetDesigner(serviceProvider, activity);
                        if (activityDesigner != null)
                        {
                            Bitmap activityImage = GetStockImage(activityDesigner) as Bitmap;
                            if (activityImage != null)
                            {
                                if (this.treeView.ImageList == null)
                                {
                                    this.treeView.ImageList = new ImageList();
                                    this.treeView.ImageList.ColorDepth = ColorDepth.Depth32Bit;
                                }
                                this.treeView.ImageList.Images.Add(activity.GetType().FullName, activityImage);
                                imageIndex = this.treeView.ImageList.Images.Count - 1;
                            }
                        }
                    }
                    treeNode.ImageIndex = treeNode.SelectedImageIndex = imageIndex;

                    treeNode.NodeFont = null;

                    //Update the state information
                    IActivityStateProvider activityStateProvider = this.serviceProvider.GetService(typeof(IActivityStateProvider)) as IActivityStateProvider;
                    if (activityStateProvider != null)
                    {
                        ActivityStatus[] state = activityStateProvider.GetActivityState(activity.QualifiedName);
                        int iterations = 0;
                        if (state != null && state.Length > 0)
                        {
                            iterations = state.Length;

                            ActivityExecutionStatus activityStatus = GetAggregatedStatus(state);
                            if (activityStatus == ActivityExecutionStatus.Closed)
                            {
                                if (this.executedActivityFont == null)
                                    this.executedActivityFont = new Font(Font, FontStyle.Italic);
                                treeNode.NodeFont = this.executedActivityFont;
                            }
                            else if (activityStatus == ActivityExecutionStatus.Executing)
                            {
                                if (this.executingActivityFont == null)
                                    this.executingActivityFont = new Font(Font, FontStyle.Bold);
                                treeNode.NodeFont = this.executingActivityFont;
                            }
                        }
                        treeNode.Iterations = iterations;
                    }
                }

                foreach (ExtendedTreeNode childNode in treeNode.Nodes)
                {
                    Activity childActivity = childNode.Tag as Activity;
                    if (childActivity != null)
                        treeNodeQ.Enqueue(childNode);
                }
                this.treeView.EndUpdate();
            }
        }

        internal Image GetStockImage(ActivityDesigner activityDesigner)
        {
            if (activityDesigner.Activity == null || activityDesigner.Activity.Site == null)
                return null;

            ActivityDesignerTheme theme = WorkflowTheme.CurrentTheme.GetDesignerTheme(activityDesigner);
            Image designerImage = theme.DesignerImage;
            if (designerImage == null)
                designerImage = GetToolboxImage(activityDesigner.Activity.GetType());

            return designerImage;
        }
        internal static Image GetToolboxImage(Type activityType)
        {
            if (activityType == null)
                return null;

            object[] attribs = activityType.GetCustomAttributes(typeof(ToolboxBitmapAttribute), false);
            if (attribs != null && attribs.GetLength(0) == 0)
                attribs = activityType.GetCustomAttributes(typeof(ToolboxBitmapAttribute), true);

            ToolboxBitmapAttribute toolboxBitmapAttribute = (attribs != null && attribs.GetLength(0) > 0) ? attribs[0] as ToolboxBitmapAttribute : null;
            return (toolboxBitmapAttribute != null) ? toolboxBitmapAttribute.GetImage(activityType) : null;
        }

        private ActivityExecutionStatus GetAggregatedStatus(ActivityStatus[] state)
        {
            ActivityExecutionStatus aggregatedStatus = ActivityExecutionStatus.Initialized;
            foreach (ActivityStatus status in state)
            {
                if (status.Status > aggregatedStatus)
                    aggregatedStatus = status.Status;
            }
            return aggregatedStatus;
        }

        private class ExtendedTreeNode : TreeNode
        {
            private string activityId;
            private int iterations;

            public ExtendedTreeNode(string id)
            {
                this.activityId = id;
                Iterations = 0;
            }

            public int Iterations
            {
                get { return this.iterations; }
                set
                {
                    this.iterations = value;
                    string format = (this.iterations > 0) ? "{0} ({1})" : "{0}";
                    base.Text = string.Format(format, this.activityId, this.iterations);
                }
            }
        }
    }
}
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using System.Diagnostics;
using System.Collections;

#endregion

namespace TrackingShell
{
	//public delegate void ListSelectionChanged(object sender);

	//partial class AggregateDocOutline : UserControl
	//{
	//    private TreeView treeView = null;
	//    private Dictionary<UniqueExecutingActivity, UniqueActivityStatusTreeNode> uniqueTreeNodes = null;
	//    public event ListSelectionChanged SelectionChanged;

	//    public AggregateDocOutline()
	//    {
	//        InitializeComponent();
	//    }

	//    public object[] SelectedItems
	//    {
	//        get
	//        {
	//            ArrayList selection = new ArrayList();
	//            if (this.treeView.SelectedNode != null)
	//            {
	//                ExecutingContextTreeNode executingContextTreeNode = this.treeView.SelectedNode as ExecutingContextTreeNode;
	//                UniqueActivityStatusTreeNode uniqueActivityStatusTreeNode = this.treeView.SelectedNode as UniqueActivityStatusTreeNode;
	//                TrackedActivity activity = null;
	//                if (executingContextTreeNode != null)
	//                    activity = executingContextTreeNode.TrackedActivity;
	//                else
	//                    if (uniqueActivityStatusTreeNode != null)
	//                        activity = uniqueActivityStatusTreeNode.TrackedActivity;
	//                selection.Add(activity);
	//            }

	//            return selection.ToArray();
	//        }
	//    }

	//    public void SetExecutionTree(ActivityStep tree)
	//    {
	//        //Invoke((MethodInvoker)delegate()
	//        //{
	//            //this will run on the ui thread
	//            if (this.treeView != null)
	//                this.treeView.Nodes.Clear();

	//            //todo apply minimal custom theme with no connector drop areas - needs to take very little space
	//            //Activity activity = ActivityExecutionPath.ExpandExecution(tree, false);
	//            string treeStr = (tree != null) ? tree.GetString() : "";

	//            if (this.treeView == null)
	//            {
	//                this.treeView = new TreeView();
	//                this.treeView.AfterSelect += new TreeViewEventHandler(treeView_AfterSelect);
	//            }

	//            this.treeView.Dock = DockStyle.Fill;
	//            this.Controls.Add(this.treeView);

	//            this.uniqueTreeNodes = new Dictionary<UniqueExecutingActivity, UniqueActivityStatusTreeNode>();
	//            if (tree != null)
	//                this.treeView.Nodes.Add(CreateTreeNode(tree));
	//            this.treeView.ExpandAll();
	//        //});
	//    }

	//    private TreeNode CreateTreeNode(ActivityStep tree)
	//    {
	//        //todo: add icons for the known activity instances...
	//        TreeNode node = null;
	//        ExecutionContext context = tree as ExecutionContext;
	//        if (context != null)
	//        {
	//            //it's a new context start node
	//            node = new ExecutingContextTreeNode(context.Context, context.TrackedActivity);
	//        }
	//        else
	//        {
	//            UniqueExecutingActivity uniqueActivity = new UniqueExecutingActivity(tree.QualifiedName, FindParentContext(tree));
	//            if (this.uniqueTreeNodes.ContainsKey(uniqueActivity))
	//            {
	//                node = this.uniqueTreeNodes[uniqueActivity];
	//                ((UniqueActivityStatusTreeNode)node).Status = tree.Status;
	//                Debug.Assert(tree.ActivitySteps.Count == 0, "activity with changed status is getting children");
	//                node = null;
	//            }
	//            else
	//            {
	//                node = new UniqueActivityStatusTreeNode(tree.QualifiedName, uniqueActivity.TrackingContext, tree.Status, tree.TrackedActivity);
	//                this.uniqueTreeNodes.Add(uniqueActivity, node as UniqueActivityStatusTreeNode);
	//            }
	//        }

	//        if (node != null)
	//        {
	//            foreach (ActivityStep childStep in tree.ActivitySteps)
	//            {
	//                TreeNode childNode = CreateTreeNode(childStep);
	//                if(childNode != null)
	//                    node.Nodes.Add(childNode);
	//            }
	//        }

	//        return node;
	//    }

	//    private Guid FindParentContext(ActivityStep child)
	//    {
	//        ActivityStep parent = child.Parent;
	//        while (parent != null && !(parent is ExecutionContext))
	//        {
	//            parent = parent.Parent;
	//        }

	//        ExecutionContext parentContext = parent as ExecutionContext;
	//        if (parentContext == null)
	//            return Guid.Empty;

	//        return parentContext.Context;
	//    }

	//    private class ExecutingContextTreeNode : TreeNode
	//    {
	//        private Guid context;
	//        private TrackedActivity trackedActivity;

	//        public ExecutingContextTreeNode(Guid context, TrackedActivity trackedActivity)
	//        {
	//            this.context = context;
	//            this.trackedActivity = trackedActivity;
	//            this.Text = "Executing Context N" + this.context;
	//        }
	//        public TrackedActivity TrackedActivity
	//        {
	//            get
	//            {
	//                return this.trackedActivity;
	//            }
	//        }
	//    }

	//    private class UniqueActivityStatusTreeNode : TreeNode
	//    {
	//        private string qualifiedActivityId;
	//        private Guid context;
	//        private ActivityExecutionStatus status;
	//        private TrackedActivity trackedActivity;

	//        public UniqueActivityStatusTreeNode(string qualifiedActivityId, Guid context, ActivityExecutionStatus status, TrackedActivity trackedActivity)
	//        {
	//            this.qualifiedActivityId = qualifiedActivityId;
	//            this.context = context;
	//            this.status = status;
	//            this.trackedActivity = trackedActivity;
	//            UpdateText();
	//        }

	//        private void UpdateText()
	//        {
	//            this.Text = qualifiedActivityId + " " + status;
	//        }

	//        public string QualifiedActivityId
	//        {
	//            get
	//            {
	//                return this.qualifiedActivityId;
	//            }
	//        }
	//        public Guid Context
	//        {
	//            get
	//            {
	//                return this.context;
	//            }
	//        }
	//        public ActivityExecutionStatus Status
	//        {
	//            get
	//            {
	//                return this.status;
	//            }
	//            set
	//            {
	//                this.status = value;
	//                UpdateText();
	//            }
	//        }

	//        public TrackedActivity TrackedActivity
	//        {
	//            get
	//            {
	//                return this.trackedActivity;
	//            }
	//        }
	//    }

	//    private class UniqueExecutingActivity
	//    {
	//        private string qualifiedActivityId;
	//        private Guid trackingContext;

	//        public UniqueExecutingActivity(string qualifiedActivityId, Guid trackingContext)
	//        {
	//            this.qualifiedActivityId = qualifiedActivityId;
	//            this.trackingContext = trackingContext;
	//        }

	//        public string QualifiedActivityId
	//        {
	//            get
	//            {
	//                return this.qualifiedActivityId;
	//            }
	//        }

	//        public Guid TrackingContext
	//        {
	//            get
	//            {
	//                return this.trackingContext;
	//            }
	//        }

	//        public override int GetHashCode()
	//        {
	//            return qualifiedActivityId.GetHashCode() ^ this.trackingContext.GetHashCode();
	//        }

	//        public override bool Equals(object obj)
	//        {
	//            UniqueExecutingActivity other = obj as UniqueExecutingActivity;
	//            if(other == null)
	//                return false;

	//            return this.qualifiedActivityId.Equals(other.qualifiedActivityId) && this.trackingContext.Equals(other.trackingContext);
	//        }
	//    }

	//    void treeView_AfterSelect(object sender, TreeViewEventArgs e)
	//    {
	//        //our selection has changed - notify all interested parties
	//        if (SelectionChanged != null)
	//        {
	//            SelectionChanged.DynamicInvoke(new object[] { this });
	//        }
	//    }
	//}
}

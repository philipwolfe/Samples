// ©2001 Microsoft Corporation.
using System;

namespace DocExplorerCtrl
{
	/// <summary>
	/// DocExplorerTreeView subclasses the TreeView control and overrides two event handlers.
	/// </summary>
	public class DocExplorerTreeView: System.Windows.Forms.TreeView
	{
		private bool userDoubleClicked;

		public DocExplorerTreeView(): base()
		{
			userDoubleClicked = false;
		}

		/// <summary>
		/// if the user double clicks on a node and the element is a ProjectItem or a CodeElement with children
		/// then we set the userDoubleClicked flag to true so that we can cancel the OnBeforeExpand event and 
		/// navigate to the ProjectItem or CodeElement instead.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnDoubleClick(EventArgs e)
		{
			DocExplorerTreeNode treeNode = SelectedNode as DocExplorerTreeNode;
			if (treeNode != null)
			{
				treeNode.TryToShow();
			}
			if (((treeNode.Type == TreeNodeType.ProjectItem) || (treeNode.Type == TreeNodeType.CodeElement)) && (treeNode.Nodes.Count != 0))
			{
				//we set the flag so that the expand event is canceled, we are navigating instead.
				userDoubleClicked = true;
			}
			//we are not calling the base.OnDoubleClick
		}

		/// <summary>
		/// If the expand event is a result of a double click then cancel if the node was ProjectItem
		/// or a CodeElement.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBeforeExpand(System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			if (userDoubleClicked)
			{
				e.Cancel = true;
				userDoubleClicked = false;
			}
		}
	}
}

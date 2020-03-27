// ©2001 Microsoft Corporation.
using System;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.VCCodeModel;

namespace DocExplorerCtrl
{
	public enum TreeNodeType
	{
		CodeElement,
		Group,
		ProjectItem,
		Folder,
		Project
	}
	/// <summary>
	/// This class derives from TreeNode. The item member holds a reference to the object model object that 
	/// the node refers to.
	/// </summary>
	public class DocExplorerTreeNode: TreeNode
	{
		private object item;
		private TreeNodeType type; 

		public DocExplorerTreeNode(object item, TreeNodeType type, string name, int imageNumber, DocExplorerTreeNode[] subTree) : base(name, imageNumber, imageNumber, subTree)
		{
			this.item = item;
			this.type = type;
		}

		public DocExplorerTreeNode(object item, TreeNodeType type, string name, int imageNumber) : base(name, imageNumber, imageNumber)
		{
			this.item = item;
			this.type = type;
		}

		public TreeNodeType Type
		{
			get
			{
				return type;
			}
		}

		public object Object
		{
			get
			{
				return item;
			}
		}

		public void TryToShow()
		{
			try
			{
				switch (this.type)
				{
					case TreeNodeType.CodeElement:
						VCCodeElement codeElement = item as VCCodeElement;
						if ((codeElement != null) && (!codeElement.IsZombie) && (!codeElement.IsInjected))
						{
							codeElement.ProjectItem.Open("{00000000-0000-0000-0000-000000000000}");
							TextPoint textPoint = codeElement.StartPoint;
							textPoint.TryToShow(vsPaneShowHow.vsPaneShowTop, 1);
						}
						break;
					case TreeNodeType.ProjectItem:
						((ProjectItem)item).Open("{00000000-0000-0000-0000-000000000000}");
						break;
					case TreeNodeType.Folder:
						break;
					case TreeNodeType.Project:
						break;
				}
			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
		}
	}
}

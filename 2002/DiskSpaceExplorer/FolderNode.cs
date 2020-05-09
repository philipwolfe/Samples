using System;
using System.Windows.Forms;

namespace MinhNguyen.DiskSpaceExplorer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class FolderNode : TreeNode
	{

		public long totalFiles = 0;
		public long thisFiles = 0;
		public long totalFolders = 0;
		public long thisFolders = 0;
		public long totalBytes = 0;
		public long thisBytes = 0;

		public string FullName 
		{
			get 
			{
				if (this.Parent == null)
					return this.Text;
				else
					return ((FolderNode) this.Parent).FullName + this.Text;
			}
		}

		public FolderNode(string name)
		{
			this.Text = name;
		}
	}
}

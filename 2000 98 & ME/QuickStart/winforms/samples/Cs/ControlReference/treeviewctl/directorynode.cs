//------------------------------------------------------------------------------
/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
///       
///    This source code is intended only as a supplement to Microsoft
///    Development Tools and/or on-line documentation.  See these other
///    materials for detailed information regarding Microsoft code samples.
///
/// </copyright>                                                                
//------------------------------------------------------------------------------
namespace Microsoft.Samples.WinForms.Cs.TreeViewCtl {

	using System;
	using System.Drawing;
	using System.WinForms;

	public class DirectoryNode : TreeNode { 
		
		public bool SubDirectoriesAdded;

		public DirectoryNode(String text) : base(text) {
		}
	}
}


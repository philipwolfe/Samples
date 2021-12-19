'------------------------------------------------------------------------------
' <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'       
'    This source code is intended only as a supplement to Microsoft
'    Development Tools and/or on-line documentation.  See these other
'    materials for detailed information regarding Microsoft code samples.
'
' </copyright>                                                                
'------------------------------------------------------------------------------

Imports System
Imports System.Drawing
Imports System.WinForms

Option Explicit

Namespace Microsoft.Samples.WinForms.Vb.TreeViewCtl 


	public class DirectoryNode
		Inherits TreeNode  
		
		public SubDirectoriesAdded As Boolean

		public Sub New(txt As String)
			MyBase.New(txt) 
		End Sub
	End Class
End Namespace



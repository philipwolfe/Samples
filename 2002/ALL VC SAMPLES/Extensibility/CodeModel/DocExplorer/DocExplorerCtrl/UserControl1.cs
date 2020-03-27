// ©2001 Microsoft Corporation.
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.VCCodeModel;
using System.Runtime.InteropServices;

namespace DocExplorerCtrl
{
	/// <summary>
	/// Enum used to index the imageList1
	/// </summary>
	enum DocExplorerIcons
	{
		Attribute,
		Attributes,
		Base,
		Bases,
		Class,
		Classes,
		CppFile,
		Delegate,
		DocExplorer,
		Enum,
		EnumItem,
		Enums,
		File,
		Folder,
		Function,
		Functions,
		Groups,
		HFile,
		IdlFile,
		Interface,
		Interfaces,
		Library,
		Macro,
		Macros,
		Map,
		MapItem,
		MapItems,
		Maps,
		Namespace,
		Namespaces,
		OpenFolder,
		Other,
		Others,
		Parameter,
		Parameters,
		Project,
		Refresh,
		Struct,
		Structs,
		TextFile,
		Typedef,
		Typedefs,
		Union,
		Unions,
		Variable,
		Variables,
	}

	/// <summary>
	/// This is the main class for the DocExplorer.
	/// </summary>
	[GuidAttribute("BB1AC0E8-0DA8-46EF-A41E-098407999F2E"), ProgId("DocExplorerCtrl.DocExplorerCtrl")]
	public class UserControl1 : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ToolBar toolBar;
		private DocExplorerTreeView docExplorerTree;
		private System.Windows.Forms.ImageList imageList;
		private EnvDTE._DTE dte;
		private System.Windows.Forms.ToolBarButton refreshBtn;
		private System.Windows.Forms.ToolBarButton groupBtn;
		private System.Windows.Forms.ToolBarButton separator;
		private System.Windows.Forms.ContextMenu treeContextMenu;
		private System.Windows.Forms.ToolBarButton aboutBtn;
		private System.Windows.Forms.ToolBarButton separator2;

		public UserControl1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(UserControl1));
			this.aboutBtn = new System.Windows.Forms.ToolBarButton();
			this.treeContextMenu = new System.Windows.Forms.ContextMenu();
			this.toolBar = new System.Windows.Forms.ToolBar();
			this.refreshBtn = new System.Windows.Forms.ToolBarButton();
			this.separator2 = new System.Windows.Forms.ToolBarButton();
			this.separator = new System.Windows.Forms.ToolBarButton();
			this.groupBtn = new System.Windows.Forms.ToolBarButton();
			this.imageList = new System.Windows.Forms.ImageList();
			this.docExplorerTree = new DocExplorerTreeView();
			this.SuspendLayout();
			// 
			// aboutBtn
			// 
			this.aboutBtn.ImageIndex = 8;
			this.aboutBtn.ToolTipText = "About DocExplorer";
			// 
			// treeContextMenu
			// 
			this.treeContextMenu.Popup += new System.EventHandler(this.PopupContextMenu);
			// 
			// toolBar
			// 
			this.toolBar.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {this.groupBtn,
																					   this.separator,
																					   this.refreshBtn,
																					   this.separator2,
																					   this.aboutBtn});
			this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.toolBar.DropDownArrows = true;
			this.toolBar.ImageList = this.imageList;
			this.toolBar.Name = "toolBar";
			this.toolBar.ShowToolTips = true;
			this.toolBar.Size = new System.Drawing.Size(150, 25);
			this.toolBar.TabIndex = 0;
			this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
			// 
			// refreshBtn
			// 
			this.refreshBtn.ImageIndex = 36;
			this.refreshBtn.ToolTipText = "Refresh";
			// 
			// separator2
			// 
			this.separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// separator
			// 
			this.separator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// groupBtn
			// 
			this.groupBtn.ImageIndex = 16;
			this.groupBtn.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.groupBtn.ToolTipText = "Group By Type";
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// docExplorerTree
			// 
			this.docExplorerTree.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.docExplorerTree.ContextMenu = this.treeContextMenu;
			this.docExplorerTree.ImageList = this.imageList;
			this.docExplorerTree.Location = new System.Drawing.Point(8, 40);
			this.docExplorerTree.Name = "docExplorerTree";
			this.docExplorerTree.TabIndex = 1;
			this.docExplorerTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ExpandTree);
			this.docExplorerTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.CollapseTree);
			this.docExplorerTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownTree);
			// 
			// DocExplorerCtrl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.docExplorerTree,
																		  this.toolBar});
			this.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.Name = "DocExplorerCtrl";
			this.ResumeLayout(false);

		}

		/// <summary>
		/// This method must be executed from the Add-In to load the wizard.
		/// </summary>
		/// <param name="DTE">A pointer to the current DTE</param>
		public void LoadDocExplorer(EnvDTE._DTE DTE)
		{
			dte = DTE;
			toolBar.Location = new System.Drawing.Point(0, 0);
			toolBar.Width = this.Width * 2;
			docExplorerTree.Width = this.Width;
			docExplorerTree.Height = this.Height - toolBar.Height - 6;
			docExplorerTree.Location = new System.Drawing.Point(0, toolBar.Height + 6);
			PopulateTree();
		}

		/// <summary>
		/// Starts loading the Tree with the project nodes.
		/// </summary>
		private void PopulateTree()
		{
			docExplorerTree.Nodes.Clear();
			foreach (Project project in dte.Solution)
			{
				if (project.Kind == "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}")
				{
					if (project.ProjectItems.Count != 0)
					{
						docExplorerTree.Nodes.Add(new DocExplorerTreeNode(project, TreeNodeType.Project, project.Name, (int)DocExplorerIcons.Project, ProjectTree(project.ProjectItems)));
					}
					else
					{
						docExplorerTree.Nodes.Add(new DocExplorerTreeNode(project, TreeNodeType.Project, project.Name, (int)DocExplorerIcons.Project));
					}
				}
			}
		}

		/// <summary>
		/// This method adds the first level of project items to the tree and then calls
		/// ProjectItemsTree to generate the tree for all the other levels.
		/// We have to special case the first level because for VC projects the ProjectItems
		/// collection returns all the project items regardless of their location in the 
		/// tree
		/// </summary>
		/// <param name="projectItems">The ProjectItems collection that will be added at this level of the tree</param>
		/// <returns>An array of DocExplorerTreeNodes</returns>
		private DocExplorerTreeNode[] ProjectTree(ProjectItems projectItems)
		{
			ArrayList treeList = new ArrayList();
			ArrayList files = new ArrayList();
			ArrayList folders = new ArrayList();
			//Get all the folders and files into different arrays.
			foreach (ProjectItem projectItem in projectItems)
			{
				ProjectItems folderItems = projectItem.ProjectItems;
				if (folderItems != null)
				{
					folders.Add(projectItem);
				}
				else
				{
					files.Add(projectItem);
				}
			}
			//Add each folder and all its children to the tree.
			foreach (ProjectItem folder in folders)
			{
				if (folder.ProjectItems.Count != 0)
				{
					treeList.Add(new DocExplorerTreeNode(folder, TreeNodeType.Folder, folder.Name, (int)DocExplorerIcons.Folder, ProjectItemsTree(folder, ref files)));
				}
				else
				{
					treeList.Add(new DocExplorerTreeNode(folder, TreeNodeType.Folder, folder.Name, (int)DocExplorerIcons.Folder));
				}
			}
			//Add all the remaining files to the tree.
			foreach (ProjectItem file in files)
			{
				VCFileCodeModel codeModel = file.FileCodeModel as VCFileCodeModel;
				if ((codeModel != null) && (codeModel.CodeElements.Count != 0))
				{
					if (groupBtn.Pushed)
					{
						treeList.Add(new DocExplorerTreeNode(file, TreeNodeType.ProjectItem, file.Name, ProjectItemPicture(file), GroupedCodeElementsTree((VCCodeElements)codeModel)));
					}
					else
					{
						treeList.Add(new DocExplorerTreeNode(file, TreeNodeType.ProjectItem, file.Name, ProjectItemPicture(file), CodeElementsTree((VCCodeElements)codeModel.CodeElements)));
					}
				}
				else
				{
					treeList.Add(new DocExplorerTreeNode(file, TreeNodeType.ProjectItem, file.Name, ProjectItemPicture(file)));
				}			
			}
			DocExplorerTreeNode[] tree = new DocExplorerTreeNode[treeList.Count];
			for (int i = 0; i < treeList.Count; i++)
			{
				tree[i] = (DocExplorerTreeNode)treeList[i];
			}
			return tree;
		}

		/// <summary>
		/// This function generates an array of DocExplorerTreeNode for each member of the folder
		/// ProjectItem. It removes all the folder elements from the files ArrayList.
		/// </summary>
		/// <param name="folder">The ProjectItem that contains other ProjectItems</param>
		/// <param name="files">An ArrayList that contains all the ProjectItems</param>
		/// <returns>An array of DocExplorerTreeNode, one for each ProjectItem in folder</returns>
		private DocExplorerTreeNode[] ProjectItemsTree(ProjectItem folder, ref ArrayList files)
		{
			int fileCount = folder.ProjectItems.Count;
			ProjectItem projectItem;
			DocExplorerTreeNode[] subTree = new DocExplorerTreeNode[fileCount];
			for (int i = 1; i <= fileCount; i++)
			{
				projectItem = folder.ProjectItems.Item(i);
				ProjectItems subfolderItems = projectItem.ProjectItems;
				if (subfolderItems != null)
				{
					if (subfolderItems.Count != 0)
					{
						subTree[i - 1] = new DocExplorerTreeNode(projectItem, TreeNodeType.Folder, projectItem.Name, ProjectItemPicture(projectItem), ProjectItemsTree(projectItem, ref files));
					}
					else
					{
						subTree[i - 1] = new DocExplorerTreeNode(projectItem, TreeNodeType.Folder, projectItem.Name, ProjectItemPicture(projectItem));
					}
				}
				else
				{
					string foo = projectItem.Name;
					RemoveFile(ref files, projectItem);
					VCFileCodeModel codeModel = projectItem.FileCodeModel as VCFileCodeModel;
					if ((codeModel != null) && (codeModel.CodeElements.Count != 0))
					{
						if (groupBtn.Pushed)
						{
							subTree[i - 1] = new DocExplorerTreeNode(projectItem, TreeNodeType.ProjectItem, projectItem.Name, ProjectItemPicture(projectItem), GroupedCodeElementsTree(codeModel));
						}
						else
						{
							subTree[i - 1] = new DocExplorerTreeNode(projectItem, TreeNodeType.ProjectItem, projectItem.Name, ProjectItemPicture(projectItem), CodeElementsTree((VCCodeElements)codeModel.CodeElements));
						}
					}
					else
					{
						subTree[i - 1] = new DocExplorerTreeNode(projectItem, TreeNodeType.ProjectItem, projectItem.Name, ProjectItemPicture(projectItem));
					}
				}
			}
			return subTree;
		}

		/// <summary>
		/// removes projectItem from files
		/// </summary>
		/// <param name="files">an ArrayList with all the ProjectItems</param>
		/// <param name="projectItem">the ProjectItem to be removed.</param>
		private void RemoveFile(ref ArrayList files, ProjectItem projectItem)
		{
			string name = projectItem.Name;
			int fileCount = files.Count;
			for(int i = 0; i < fileCount; i++)
			{
				if (((ProjectItem)files[i]).Name == name)
				{
					files.RemoveAt(i);
					return;
				}
			}
		}

		/// <summary>
		/// returns the code element name, for functions it returns the signature.
		/// </summary>
		string CodeElementName(VCCodeElement codeElement)
		{
			VCCodeFunction codeFunction = codeElement as VCCodeFunction;
			if (codeFunction != null)
			{
				try
				{
					return codeFunction.get_Prototype((int)vsCMPrototype.vsCMPrototypeParamTypes);
				}
				catch
				{
					return codeFunction.Name;
				}
			}
			else
			{
				return codeElement.Name;
			}
		}

		/// <summary>
		/// When the code elements are being grouped by kind, this function is called to add the 
		/// code element groups.
		/// </summary>
		private void AddGroupNode(ref ArrayList ceList, DocExplorerIcons icon, string groupName, CodeElements group)
		{
			int groupCount = group.Count;
			if (groupCount != 0)
			{
				DocExplorerTreeNode[] subTree = new DocExplorerTreeNode[groupCount];
				VCCodeElement codeElement;
				for (int i = 1; i <= groupCount; i++)
				{
					codeElement = group.Item(i) as VCCodeElement;
					if (codeElement.Children.Count != 0)
					{
						subTree[i - 1] = new DocExplorerTreeNode(codeElement, TreeNodeType.CodeElement, codeElement.Name, CodeElementPicture(codeElement), GroupedCodeElementsTree(codeElement));
					}
					else
					{
						subTree[i - 1] = new DocExplorerTreeNode(codeElement, TreeNodeType.CodeElement, codeElement.Name, CodeElementPicture(codeElement));
					}
				}
				ceList.Add(new DocExplorerTreeNode(null, TreeNodeType.Group, groupName, (int)icon, subTree));
			}
		}

		/// <summary>
		/// It is called whenever the elements are being grouped by kind.
		/// This method calls AddGroupNode per collection depending on the type of the groupParent
		/// </summary>
		private DocExplorerTreeNode[] GroupedCodeElementsTree(object groupParent)
		{
			ArrayList ceList = new ArrayList();
			VCFileCodeModel codeModel = groupParent as VCFileCodeModel;
			if (codeModel != null)
			{
				AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeModel.Attributes);
				AddGroupNode(ref ceList, DocExplorerIcons.Classes, "Classes", codeModel.Classes);
				AddGroupNode(ref ceList, DocExplorerIcons.Delegate, "Delegates", codeModel.Delegates);
				AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeModel.Enums);
				AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeModel.Functions);
				AddGroupNode(ref ceList, DocExplorerIcons.Other, "IDLImports", codeModel.IDLImports);
				AddGroupNode(ref ceList, DocExplorerIcons.Other, "IDLLibraries", codeModel.IDLLibraries);
				AddGroupNode(ref ceList, DocExplorerIcons.Other, "Imports", codeModel.Imports);
				AddGroupNode(ref ceList, DocExplorerIcons.Other, "Includes", codeModel.Includes);
				AddGroupNode(ref ceList, DocExplorerIcons.Interfaces, "Interfaces", codeModel.Interfaces);
				AddGroupNode(ref ceList, DocExplorerIcons.Macros, "Macros", codeModel.Macros);
				AddGroupNode(ref ceList, DocExplorerIcons.Maps, "Maps", codeModel.Maps);
				AddGroupNode(ref ceList, DocExplorerIcons.Namespaces, "Namespaces", codeModel.Namespaces);
				AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeModel.Structs);
				AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeModel.Typedefs);
				AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeModel.Unions);
				AddGroupNode(ref ceList, DocExplorerIcons.Other, "Usings", codeModel.Usings);
				AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeModel.Variables);
			}
			else
			{
				VCCodeElement codeElement = groupParent as VCCodeElement;
				if (codeElement != null)
				{
					switch (codeElement.Kind)
					{
						case vsCMElement.vsCMElementAttribute:
							VCCodeAttribute codeAttribute = codeElement as VCCodeAttribute;
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeAttribute.Parameters);
							break;
						case vsCMElement.vsCMElementClass:
							VCCodeClass codeClass = codeElement as VCCodeClass;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeClass.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeClass.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.Classes, "Classes", codeClass.Classes);
							AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeClass.Enums);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "", codeClass.Events);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeClass.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Maps, "Maps", codeClass.Maps);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "", codeClass.Properties);
							AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeClass.Structs);
							AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeClass.Typedefs);
							AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeClass.Unions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeClass.Variables);
							break;
						case vsCMElement.vsCMElementDelegate:
							VCCodeDelegate codeDelegate = codeElement as VCCodeDelegate;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeDelegate.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeDelegate.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeDelegate.Parameters);
							break;
						case vsCMElement.vsCMElementEnum:
							VCCodeEnum codeEnum = codeElement as VCCodeEnum;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeEnum.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeEnum.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.EnumItem, "Members", codeEnum.Members);
							break;
						case vsCMElement.vsCMElementEvent:
							VCCodeEvent codeEvent = codeElement as VCCodeEvent;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeEvent.Attributes);
							break;
						case vsCMElement.vsCMElementFunction:
							VCCodeFunction codeFunction = codeElement as VCCodeFunction;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeFunction.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeFunction.Parameters);
							break;
						case vsCMElement.vsCMElementIDLCoClass:
							VCCodeIDLCoClass codeIDLCoClass = codeElement as VCCodeIDLCoClass;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeIDLCoClass.Attributes);
							break;
						case vsCMElement.vsCMElementIDLLibrary:
							VCCodeIDLLibrary codeIDLLibrary = codeElement as VCCodeIDLLibrary;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeIDLLibrary.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeIDLLibrary.Enums);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeIDLLibrary.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "IDLCoClasses", codeIDLLibrary.IDLCoClasses);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "IDLImportLibs", codeIDLLibrary.IDLImportLibs);
							AddGroupNode(ref ceList, DocExplorerIcons.Interfaces, "Interfaces", codeIDLLibrary.Interfaces);
							AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeIDLLibrary.Structs);
							AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeIDLLibrary.Typedefs);
							AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeIDLLibrary.Unions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeIDLLibrary.Variables);
							break;
						case vsCMElement.vsCMElementInterface:
							VCCodeInterface codeInterface = codeElement as VCCodeInterface;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeInterface.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeInterface.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeInterface.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeInterface.Variables);
							break;
						case vsCMElement.vsCMElementMacro:
							VCCodeMacro codeMacro = codeElement as VCCodeMacro;
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeMacro.Parameters);
							break;
						case vsCMElement.vsCMElementMap:
							VCCodeMap codeMap = codeElement as VCCodeMap;
							AddGroupNode(ref ceList, DocExplorerIcons.MapItems, "Entries", codeMap.Entries);
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeMap.Parameters);
							break;
						case vsCMElement.vsCMElementMapEntry:
							VCCodeMapEntry codeMapEntry = codeElement as VCCodeMapEntry;
							AddGroupNode(ref ceList, DocExplorerIcons.Parameters, "Parameters", codeMapEntry.Parameters);
							break;
						case vsCMElement.vsCMElementNamespace:
							VCCodeNamespace codeNamespace = codeElement as VCCodeNamespace;
							AddGroupNode(ref ceList, DocExplorerIcons.Classes, "Classes", codeNamespace.Classes);
							AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeNamespace.Enums);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeNamespace.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Interfaces, "Interfaces", codeNamespace.Interfaces);
							AddGroupNode(ref ceList, DocExplorerIcons.Macros, "Macros", codeNamespace.Macros);
							AddGroupNode(ref ceList, DocExplorerIcons.Maps, "Maps", codeNamespace.Maps);
							AddGroupNode(ref ceList, DocExplorerIcons.Namespaces, "Namespaces", codeNamespace.Namespaces);
							AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeNamespace.Structs);
							AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeNamespace.Typedefs);
							AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeNamespace.Unions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeNamespace.Variables);
							break;
						case vsCMElement.vsCMElementParameter:
							VCCodeParameter codeParameter = codeElement as VCCodeParameter;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeParameter.Attributes);
							break;
						case vsCMElement.vsCMElementProperty:
							VCCodeProperty codeProperty = codeElement as VCCodeProperty;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeProperty.Attributes);
							break;
						case vsCMElement.vsCMElementStruct:
							VCCodeStruct codeStruct = codeElement as VCCodeStruct;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeStruct.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeStruct.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.Classes, "Classes", codeStruct.Classes);
							AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeStruct.Enums);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "Events", codeStruct.Events);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeStruct.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Other, "Properties", codeStruct.Properties);
							AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeStruct.Structs);
							AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeStruct.Typedefs);
							AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeStruct.Unions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeStruct.Variables);				
							break;
						case vsCMElement.vsCMElementTypeDef:
							VCCodeTypedef codeTypedef = codeElement as VCCodeTypedef;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeTypedef.Attributes);
							break;
						case vsCMElement.vsCMElementUnion:
							VCCodeUnion codeUnion = codeElement as VCCodeUnion;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeUnion.Attributes);
							AddGroupNode(ref ceList, DocExplorerIcons.Bases, "Bases", codeUnion.Bases);
							AddGroupNode(ref ceList, DocExplorerIcons.Classes, "Classes", codeUnion.Classes);
							AddGroupNode(ref ceList, DocExplorerIcons.Enums, "Enums", codeUnion.Enums);
							AddGroupNode(ref ceList, DocExplorerIcons.Functions, "Functions", codeUnion.Functions);
							AddGroupNode(ref ceList, DocExplorerIcons.Structs, "Structs", codeUnion.Structs);
							AddGroupNode(ref ceList, DocExplorerIcons.Typedefs, "Typedefs", codeUnion.Typedefs);
							AddGroupNode(ref ceList, DocExplorerIcons.Unions, "Unions", codeUnion.Unions);
							AddGroupNode(ref ceList, DocExplorerIcons.Variables, "Variables", codeUnion.Variables);
							break;
						case vsCMElement.vsCMElementVariable:
							VCCodeVariable codeVariable = codeElement as VCCodeVariable;
							AddGroupNode(ref ceList, DocExplorerIcons.Attributes, "Attributes", codeVariable.Attributes);
							break;
					}
				}
			}			
			DocExplorerTreeNode[] ceArray;
			int ceListCount = ceList.Count;
			ceArray = new DocExplorerTreeNode[ceListCount];
			for (int i = 0; i < ceListCount; i++)
			{
				ceArray[i] = (DocExplorerTreeNode)ceList[i];
			}
			return ceArray;
		}

		/// <summary>
		/// Returns an array of DocExplorerTreeNodes for all the elements of the codeElements collection.
		/// </summary>
		private DocExplorerTreeNode[] CodeElementsTree(VCCodeElements codeElements)
		{
			DocExplorerTreeNode[] ceArray;
			int ceCount = codeElements.Count;
			ceArray = new DocExplorerTreeNode[ceCount];
			for (int i = 1; i <= ceCount; i++)
			{
				VCCodeElement codeElement = (VCCodeElement)codeElements.Item(i);
				string codeElementName;
				codeElementName = CodeElementName(codeElement);
				if (codeElement.Children.Count != 0)
				{
					ceArray[i - 1] = new DocExplorerTreeNode(codeElement, TreeNodeType.CodeElement, codeElementName, CodeElementPicture(codeElement), CodeElementsTree((VCCodeElements)codeElement.Children));		
				}
				else 
				{
					ceArray[i - 1] = new DocExplorerTreeNode(codeElement, TreeNodeType.CodeElement, codeElementName, CodeElementPicture(codeElement));
				}
			}
			return ceArray;
		}

		/// <summary>
		/// returns the picture index for each type of file.
		/// </summary>
		private int ProjectItemPicture(ProjectItem projectItem)
		{
			string name = projectItem.Name;
			string extension = name.Substring(name.LastIndexOf("."));
			if (extension == ".cpp")
				return (int)DocExplorerIcons.CppFile;
			if (extension == ".idl")
				return (int)DocExplorerIcons.IdlFile;
			if (extension == ".h")
				return (int)DocExplorerIcons.HFile;
			if (extension == ".txt")
				return (int)DocExplorerIcons.TextFile;
			return (int)DocExplorerIcons.File;
		}

		/// <summary>
		/// returns the image index for each type of code element.
		/// </summary>
		private int CodeElementPicture(VCCodeElement codeElement)
		{
			switch(codeElement.Kind)
			{
				case vsCMElement.vsCMElementAttribute:
					return (int)DocExplorerIcons.Attribute;
				case vsCMElement.vsCMElementVCBase:
					return (int)DocExplorerIcons.Base;
				case vsCMElement.vsCMElementClass:
					return (int)DocExplorerIcons.Class;
				case vsCMElement.vsCMElementDelegate:
					return (int)DocExplorerIcons.Delegate;
				case vsCMElement.vsCMElementEnum:
					return (int)DocExplorerIcons.Enum;
				case vsCMElement.vsCMElementFunction:
					return (int)DocExplorerIcons.Function;
				case vsCMElement.vsCMElementIDLCoClass:
					return (int)DocExplorerIcons.Class;
				case vsCMElement.vsCMElementInterface:
					return (int)DocExplorerIcons.Interface;
				case vsCMElement.vsCMElementIDLLibrary:
					return (int)DocExplorerIcons.Library;
				case vsCMElement.vsCMElementMacro:
					return (int)DocExplorerIcons.Macro;
				case vsCMElement.vsCMElementMap:
					return (int)DocExplorerIcons.Map;
				case vsCMElement.vsCMElementMapEntry:
					return (int)DocExplorerIcons.MapItem;
				case vsCMElement.vsCMElementNamespace:
					return (int)DocExplorerIcons.Namespace;
				case vsCMElement.vsCMElementParameter:
					return (int)DocExplorerIcons.Parameter;
				case vsCMElement.vsCMElementStruct:
					return (int)DocExplorerIcons.Struct;
				case vsCMElement.vsCMElementTypeDef:
					return (int)DocExplorerIcons.Typedef;
				case vsCMElement.vsCMElementUnion:
					return (int)DocExplorerIcons.Union;
				case vsCMElement.vsCMElementVariable:
					VCCodeElement parent = codeElement.Parent as VCCodeElement;
					if ((parent != null) && (parent.Kind == vsCMElement.vsCMElementEnum))
						return (int)DocExplorerIcons.EnumItem;
					else
						return (int)DocExplorerIcons.Variable;
				default:
					return (int)DocExplorerIcons.Other;
			}
		}

		/// <summary>
		/// This is the toolbar button click event handler.
		/// </summary>
		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if ((e.Button == refreshBtn) || (e.Button == groupBtn))
			{
				PopulateTree();
			}
			if (e.Button == aboutBtn)
			{
				AboutForm aboutForm = new AboutForm();
				aboutForm.ShowDialog();
			}
		}

		/// <summary>
		/// This function is called when the PopupContextMenu event is fired.
		/// </summary>
		private void PopupContextMenu(object sender, System.EventArgs e)
		{
			treeContextMenu.MenuItems.Clear();
			switch (((DocExplorerTreeNode)docExplorerTree.SelectedNode).Type)
			{
				case TreeNodeType.CodeElement:
					vsCMElement kind = ((VCCodeElement)(((DocExplorerTreeNode)docExplorerTree.SelectedNode).Object)).Kind;
				switch (kind)
				{
					case vsCMElement.vsCMElementClass:
						treeContextMenu.MenuItems.Add("&Browse", new System.EventHandler(this.BrowseContextMenu));
						treeContextMenu.MenuItems.Add("Add &Function...", new System.EventHandler(this.AddFunctionContextMenu));
						treeContextMenu.MenuItems.Add("Add &Variable...", new System.EventHandler(this.AddVariableContextMenu));
						break;
					case vsCMElement.vsCMElementInterface:
						treeContextMenu.MenuItems.Add("&Browse", new System.EventHandler(this.BrowseContextMenu));
						treeContextMenu.MenuItems.Add("Add &Method...", new System.EventHandler(this.AddMethodContextMenu));
						treeContextMenu.MenuItems.Add("Add &Property...", new System.EventHandler(this.AddPropertyContextMenu));
						break;
					default:
						treeContextMenu.MenuItems.Add("&Browse", new System.EventHandler(this.BrowseContextMenu));
					break;
				}
					break;
				case TreeNodeType.ProjectItem:
					treeContextMenu.MenuItems.Add("&Open", new System.EventHandler(this.BrowseContextMenu));
					break;
				case TreeNodeType.Folder:
					break;
				case TreeNodeType.Project:
					treeContextMenu.MenuItems.Add("&Add Class...", new System.EventHandler(this.AddClassContextMenu));
					break;
			}
		}

		/// <summary>
		/// This function returns the path where VS is installed.
		/// </summary>
		private string VSPath()
		{
			string path;
			try
			{
				Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\VisualStudio\\7.0\\Setup\\VS");
				path = regKey.GetValue("ProductDir").ToString();
				regKey.Close();
			}
			catch
			{
				path = "";
			}
			return path;
		}

		/// <summary>
		/// Opens the Add Class wizard
		/// </summary>
		private void AddClassContextMenu(object sender, System.EventArgs e)
		{
			DocExplorerTreeNode treeNode = docExplorerTree.SelectedNode as DocExplorerTreeNode;
			if (treeNode != null)
			{
				Project project = treeNode.Object as Project;
				if (project != null)
				{
					LaunchWizard("vc7\\vcaddclass\\simple.vsz", project.CodeModel);
					treeNode.TryToShow();
				}
			}
		}

		/// <summary>
		/// Navigates to the code element location
		/// </summary>
		private void BrowseContextMenu(object sender, System.EventArgs e)
		{
			((DocExplorerTreeNode)docExplorerTree.SelectedNode).TryToShow();
		}

		/// <summary>
		/// Opens the wizard specified by the path parameter
		/// </summary>
		private void LaunchWizard(string path, object parent)
		{			
			VCCodeModel codeModel = parent as VCCodeModel;
			Project project;
			string parentName;
			if (codeModel != null)
			{
				project = codeModel.Parent;
				parentName = "";
			}
			else
			{
				VCCodeElement codeElement = parent as VCCodeElement;
				project = codeElement.Project;
				parentName = codeElement.Name;
			}
			object[] parameters = new object[7];
			//type of wizard
			parameters[0] = "{0F90E1D1-4999-11D1-B6D1-00A0C90F2744}";
			//project name
			parameters[1] = project.Name;
			//project items collection
			parameters[2] = parent;
			//project path
			string projectPath = project.FullName;
			parameters[3] = projectPath.Substring(0, projectPath.LastIndexOf("\\"));
			//item name
			parameters[4] = parentName;
			//full path to sln file
			string solutionPath = dte.Solution.FullName;
			parameters[5] = solutionPath.Substring(0, solutionPath.LastIndexOf("\\"));
			//vs installation dir
			parameters[6] = VSPath();
			//launch wizard
			try
			{
				dte.LaunchWizard(VSPath() + path, ref parameters);
			}
			catch
			{
			}
		}

		/// <summary>
		/// Calls upon LaunchWizard to open the wizard specified by path
		/// </summary>
		private void AddContextItemContextMenu(string path)
		{
			DocExplorerTreeNode treeNode = docExplorerTree.SelectedNode as DocExplorerTreeNode;
			if (treeNode != null)
			{
				VCCodeElement codeElement = treeNode.Object as VCCodeElement;
				if (codeElement != null)
				{
					LaunchWizard(path, codeElement);
					treeNode.TryToShow();
				}
			}
		}

		/// <summary>
		/// Opens the Add Function wizard
		/// </summary>
		private void AddFunctionContextMenu(object sender, System.EventArgs e)
		{
			AddContextItemContextMenu("vc7\\VCContextItems\\MemFunctionWiz.vsz");
		}

		/// <summary>
		/// Opens the add variable wizard
		/// </summary>
		private void AddVariableContextMenu(object sender, System.EventArgs e)
		{
			AddContextItemContextMenu("vc7\\VCContextItems\\MemVariableWiz.vsz");
		}

		/// <summary>
		/// Opens the Add Method wizard
		/// </summary>
		private void AddMethodContextMenu(object sender, System.EventArgs e)
		{
			AddContextItemContextMenu("vc7\\VCContextItems\\MethodWiz.vsz");
		}

		/// <summary>
		/// Opens the Add Property wizard
		/// </summary>
		private void AddPropertyContextMenu(object sender, System.EventArgs e)
		{
			AddContextItemContextMenu("vc7\\VCContextItems\\PropWiz.vsz");
		}

		/// <summary>
		/// Changes the picture of the folder when it's collapsed.
		/// </summary>
		private void CollapseTree(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node.ImageIndex == (int)DocExplorerIcons.OpenFolder)
			{
				e.Node.ImageIndex = (int)DocExplorerIcons.Folder;
			}
		}

		/// <summary>
		/// Changes the picture of the folder when it's expanded.
		/// </summary>
		private void ExpandTree(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Node.ImageIndex == (int)DocExplorerIcons.Folder)
			{
				e.Node.ImageIndex = (int)DocExplorerIcons.OpenFolder;
			}
		}

		/// <summary>
		/// selects the node where the user right clicked.
		/// </summary>
		private void MouseDownTree(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				TreeNode treeNode = docExplorerTree.GetNodeAt(e.X, e.Y);
				if (treeNode != null)
				{
					docExplorerTree.SelectedNode = treeNode;
				}
			}
		}
	}
}

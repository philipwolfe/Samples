/*=====================================================================
  File:     TreeViewCtl.cpp

  Summary:  This sample demonstrates how to use the Treeview control

---------------------------------------------------------------------
  This file is part of the Microsoft VC++ Code Samples.

  Copyright (C) 2001 Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation->  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

#define null 0L
#define DRIVE_FIXED       3

#using <mscorlib.dll>
#using <System.DLL>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.DLL>

using namespace System;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Windows::Forms;

__gc class DirectoryNode : public TreeNode { 
	
	public:
		bool SubDirectoriesAdded;

	DirectoryNode(String* text) : TreeNode(text) {
	}
};

namespace TreeViewCtl {
	
	__gc class TreeViewCtl : public Form {

	[System::Runtime::InteropServices::DllImport(S"kernel32", EntryPoint = S"GetDriveType")]
	static int GetDriveType(String* lpRootPathName);  
	public:
		TreeViewCtl() {
            
            // This call is required for support of the WFC Form Designer
            InitForm();		

            FillDirectoryTree();
            imageListComboBox->SelectedIndex = 0;
            indentUpDown->Value = directoryTree->Indent;
        }

        // <doc>
        // <desc>
        //     For a given root directory (or drive), add the directories to the
        //     directoryTree.
        // </desc>
        // </doc>
        //
	private:
		void AddDirectories(TreeNode* node)
		{
			try
			{
				DirectoryInfo* di = new DirectoryInfo(GetPathFromNode(node));
				DirectoryInfo* endir[] = di->GetDirectories();

				for(int n = 0; n < endir->Length;n++)
				{
					if(endir[n]->Name->CompareTo(S".") && endir[n]->Name->CompareTo(S".."))
						node->Nodes->Add(new DirectoryNode(endir[n]->Name));
				}
			}
			catch (Exception* e)
			{
				(e);
			}

        }

        // <doc>
        // <desc>
        //     For a given node, add the sub-directories for node's children in the
        //     directoryTree.
        // </desc>
        // </doc>
        //
        void AddSubDirectories(DirectoryNode* node) {
            for (int i = 0; i < node->Nodes->Count; i++) {
                AddDirectories(node->Nodes->Item[i]);
            }
            node->SubDirectoriesAdded = true;
        }


        // <doc>
        // <desc>
        //     Event handler for the afterSelect event on the directoryTree. Change the
        //     title bar to show the path of the selected directoryNode.
        // </desc>
        // </doc>
        //
        void directoryTree_AfterSelect(Object* source, TreeViewEventArgs* e) {
			Text = String::Concat(S"WFC File Explorer - ", e->Node->Text);
        }

        // <doc>
        // <desc>
        //     Event handler for the beforeExpand event on the directoryTree. If the
        //     node is not already expanded, expand it.
        // </desc>
        // </doc>
        //
        void directoryTree_BeforeExpand(Object* source, TreeViewCancelEventArgs* e) {
            DirectoryNode* nodeExpanding = dynamic_cast<DirectoryNode*>(e->Node);
            if (!nodeExpanding->SubDirectoriesAdded)
                AddSubDirectories(nodeExpanding);
        }


        // <doc>
        // <desc>
        //      For initializing the directoryTree upon creation of the TreeViewCtl form.
        // </desc>
        // </doc>
        //
        void FillDirectoryTree() {
			String* drives[] = Directory::GetLogicalDrives();
            for (int i = 0; i < drives->Length; i++)
			{
				if (GetDriveType(drives[i]) == DRIVE_FIXED)
				{
                    DirectoryNode* cRoot = new DirectoryNode(drives[i]);
                    directoryTree->Nodes->Add(cRoot);
                    AddDirectories(cRoot);
				}
            }
        }

        // <doc>
        // <desc>
        //        Returns the directory path of the node->
        // </desc>
        // <retvalue>
        //        Directory path of node->
        // </retvalue>
        // </doc>
        //
        String* GetPathFromNode(TreeNode* node) {
            if (node->Parent == null) {
                return node->Text;
            }
			String* strPath = GetPathFromNode(node->Parent);
			if( String::Concat( strPath, S"\\", node->Text )->IndexOf(S"\\\\") != -1 )
				return String::Concat( strPath, node->Text );
			else
				return String::Concat( strPath, S"\\", node->Text );
        }


        // <doc>
        // <desc>
        //        Refresh helper functions to get all expanded nodes under the given
        //        node-> 
        // </desc>
        // <param term='expandedNodes'>
        //        Reference to an array of paths containing all nodes which were in the 
        //        expanded state when Refresh was requested->
        // </param>
        // <param term='startIndex'>
        //        Array index of ExpandedNodes to start adding entries to->
        // </param>
        // <retvalue>
        //        New StartIndex, i.e. given value of StartIndex + number of entries 
        //        added to ExpandedNodes.
        // </retvalue>
        // </doc>
        //
        int Refresh_GetExpanded(TreeNode* Node, String* ExpandedNodes[], int StartIndex) {
            
            if (StartIndex < ExpandedNodes->Length) {
                if (Node->IsExpanded) {
                    ExpandedNodes[StartIndex] = Node->Text;
                    StartIndex++;
                    for (int i = 0; i < Node->Nodes->Count; i++) {
                        StartIndex = Refresh_GetExpanded(Node->Nodes->Item[i], 
                                                         ExpandedNodes,
                                                         StartIndex);
                    }
                }
                return StartIndex;
            } 
            return -1;
        }

        // <doc>
        // <desc>
        //        Refresh helper function to expand all nodes whose paths are in parameter
        //        ExpandedNodes->
        // </desc>
        // <param term='node'>
        //        Node from which to start expanding.
        // </param>
        // <param term='expandedNodes'>
        //        Array of strings with the path names of all nodes to expand->
        // </param>
        // </doc>
        //
        void Refresh_Expand(TreeNode* Node, String* ExpandedNodes[]) {
            
            for (int i = ExpandedNodes->Length - 1; i >= 0; i--) {
                if (ExpandedNodes[i] == Node->Text) {
                    /*
                    * For the expand button to show properly, one level of 
                    * invisible children have to be added to the tree-> 
                    */
                    AddSubDirectories(dynamic_cast<DirectoryNode*>(Node));
                    Node->Expand();

                    /* If the node is expanded, expand any children that were 
                    * expanded before the refresh-> 
                    */
                    for (int j = 0; j < Node->Nodes->Count; j++) {
                        Refresh_Expand(Node->Nodes->Item[j], ExpandedNodes);
                    }

                    return;
                }
            }
        }

        // <doc>
        // <desc>
        //     Refreshes the view by deleting all the nodes and restoring them by
        //     reading the disk(s)-> Any expanded nodes in the directoryView will be
        //     expanded after the refresh.
        // </desc>
        // <param term='node'>
        //     - Node from which the refresh begins-> Generally, this is
        //     the root.
        // </param>
        // </doc>
        //
        void Refresh(TreeNode* node) {
            // Update the directoryTree
            if (node->Nodes->Count > 0) {
                if (node->IsExpanded) {
                    // Save all expanded nodes rooted at node, even those that are
                    // indirectly rooted->
                    String* tooBigExpandedNodes[] = new String*[node->GetNodeCount(true)];
                    int iExpandedNodes = Refresh_GetExpanded( node, tooBigExpandedNodes, 0 );
                    
                    String* expandedNodes[] = new String*[iExpandedNodes];
                    Array::Copy(tooBigExpandedNodes, 0, expandedNodes, 0,
                        iExpandedNodes);

                    node->Nodes->Clear();
                    AddDirectories(node);

                    // so children with subdirectories show up with expand/collapse
                    //button->
                    AddSubDirectories(dynamic_cast<DirectoryNode*>(node));
                    node->Expand();

                    /*
                     * check all children-> Some might have had sub-directories added
                     * from an external application so previous childless nodes
                     * might now have children->
                     */
                    for (int j = 0; j < node->Nodes->Count ; j++) {
                        if (node->Nodes->Item[j]->Nodes->Count > 0) {
                            // If the child has subdirectories-> If it was expanded
                            // before the refresh, then expand after the refresh.
                            Refresh_Expand(node->Nodes->Item[j], expandedNodes);
                        }
                    }
                } else {
                    /*
                     * If the node is not expanded, then there is no need to check
                     * if any of the children were expanded-> However, we should
                     * update the tree by reading the drive in case an external
                     * application add/removed any directories.
                     */
                    node->Nodes->Clear();
                    AddDirectories(node);
                }
            } else {
                /*
                 * Again, if there are no children, then there is no need to
                 * worry about expanded nodes but if an external application
                 * add/removed any directories we should reflect that.
                 */
                node->Nodes->Clear();
                AddDirectories(node);
            }
        }

        void checkBox1_Click(Object* source, EventArgs* e) {
            directoryTree->Sorted = checkBox1->Checked;
            for (int i = 0; i < directoryTree->Nodes->Count; i++) {
                Refresh(directoryTree->Nodes->Item[i]);
            }

        }

        void imageListComboBox_SelectedIndexChanged(Object* source, EventArgs* e) {
            int index = imageListComboBox->SelectedIndex;
            if (index == 0) {
                directoryTree->ImageList = null;
            } else if (index == 1) {
                directoryTree->ImageList = imageList1;
            } else {
                directoryTree->ImageList = imageList2;
            }

        }

        void indentUpDown_ValueChanged(Object* source, EventArgs* e) {
            directoryTree->Indent = (int)indentUpDown->Value;
        }

        void CheckBox2_click(Object* source, EventArgs* e) {
            directoryTree->HotTracking = checkBox2->Checked;
        }

        void CheckBox3_click(Object* source, EventArgs* e) {
            directoryTree->ShowLines = checkBox3->Checked;
        }

        void CheckBox4_click(Object* source, EventArgs* e) {
            directoryTree->ShowRootLines = checkBox4->Checked;

        }
        void CheckBox5_click(Object* source, EventArgs* e) {
            directoryTree->ShowPlusMinus = checkBox5->Checked;
        }


        void CheckBox6_click(Object* source, EventArgs* e) {
            directoryTree->CheckBoxes = checkBox6->Checked;
        }


        void CheckBox7_click(Object* source, EventArgs* e) {
            directoryTree->HideSelection = checkBox7->Checked;
        }

    	ComboBox* imageListComboBox;
    	System::ComponentModel::Container* components;
    	TreeView* directoryTree;
    	ImageList* imageList1;
    	ImageList* imageList2;
    	GroupBox* grpTreeView;
    	CheckBox* checkBox1;
		
    	Label* label1;
    	NumericUpDown* indentUpDown;
    	Label* label4;
    	CheckBox* checkBox2;
    	CheckBox* checkBox3;
    	CheckBox* checkBox4;
    	CheckBox* checkBox5;
    	CheckBox* checkBox6;
    	CheckBox* checkBox7;
	ToolTip* toolTip1;

    	void InitForm() {
			components = new System::ComponentModel::Container;
			checkBox7 = new CheckBox();
			directoryTree = new TreeView();
			checkBox5 = new CheckBox();
			label4 = new Label();
			indentUpDown = new NumericUpDown();
			imageList2 = new ImageList();
			toolTip1 = new ToolTip(components);
			checkBox6 = new CheckBox();
			checkBox1 = new CheckBox();
			checkBox3 = new CheckBox();
			imageList1 = new ImageList();
			imageListComboBox = new ComboBox();
			checkBox4 = new CheckBox();
			grpTreeView = new GroupBox();
			checkBox2 = new CheckBox();
			label1 = new Label();
			
			checkBox7->TextAlign = ContentAlignment::MiddleLeft;
			checkBox7->Location = Point(16, 160);
			checkBox7->TabIndex = 6;
			checkBox7->CheckState = CheckState::Checked;
			checkBox7->Text = S"Hide selected";
			checkBox7->Size = System::Drawing::Size(100, 23);
			checkBox7->Checked = true;
			toolTip1->SetToolTip(checkBox7, S"Removes highlight from selected node when the control doesn\'t have focus.");
			checkBox7->add_Click( new EventHandler(this, CheckBox7_click) );
			
			directoryTree->ImageList = dynamic_cast<ImageList*>(imageList1);
			directoryTree->ForeColor = (Color)SystemColors::WindowText;
			directoryTree->Location = Point(24, 16);
			directoryTree->AllowDrop = true;
			directoryTree->TabIndex = 0;
			directoryTree->Indent = 19;
			directoryTree->Text = S"TreeView1";
			directoryTree->SelectedImageIndex = 1;
			directoryTree->Size = System::Drawing::Size(200, 264);
			toolTip1->SetToolTip(directoryTree, S"Indicates whether lines are shown between sibling nodes and between parent and children nodes");
			directoryTree->add_AfterSelect( new TreeViewEventHandler(this, directoryTree_AfterSelect) );
			directoryTree->add_BeforeExpand( new TreeViewCancelEventHandler(this, directoryTree_BeforeExpand) );
			
			checkBox5->TextAlign = ContentAlignment::MiddleLeft;
			checkBox5->Location = Point(16, 112);
			checkBox5->TabIndex = 4;
			checkBox5->CheckState = CheckState::Checked;
			checkBox5->Text = S"Show plus-minus";
			checkBox5->Size = System::Drawing::Size(120, 23);
			checkBox5->Checked = true;
			toolTip1->SetToolTip(checkBox5, S"Indicates if plus/minus button are shown next to parents.");
			checkBox5->add_Click( new EventHandler(this, CheckBox5_click) );
			
			label4->Location = Point(16, 224);
			label4->TabIndex = 9;
			label4->TabStop = false;
			label4->Text = S"Indent:";
			label4->Size = System::Drawing::Size(48, 16);
			
			indentUpDown->Location = Point(88, 224);
			indentUpDown->Maximum = Decimal(150);
			indentUpDown->Minimum = Decimal(18);
			indentUpDown->TabIndex = 10;
			indentUpDown->Text = S"18";
			indentUpDown->DecimalPlaces = 0;
			indentUpDown->Size = System::Drawing::Size(120, 20);
			toolTip1->SetToolTip(indentUpDown, S"The indentation width of a child node in pixels.");
			indentUpDown->add_ValueChanged( new EventHandler(this, indentUpDown_ValueChanged) );
			
			
            imageList1->ImageSize = System::Drawing::Size(16, 16);
			imageList1->TransparentColor = Color::Transparent;
			imageList1->Images->Add(Image::FromFile(S"clsdfold.bmp"));
			imageList1->Images->Add(Image::FromFile(S"openfold.bmp"));

            imageList2->ImageSize = System::Drawing::Size(16, 16);
			imageList2->TransparentColor = Color::Transparent;
			imageList2->Images->Add(Image::FromFile(S"diamond.bmp"));
			imageList2->Images->Add(Image::FromFile(S"club.bmp"));
			
			AutoScaleBaseSize = System::Drawing::Size(5, 13);
			ClientSize = System::Drawing::Size(502, 293);
			Text = S"TreeView";
			
			toolTip1->Active = true;
			//@design toolTip1->SetLocation(Point(20, 70));
			
			checkBox6->TextAlign = ContentAlignment::MiddleLeft;
			checkBox6->Location = Point(16, 136);
			checkBox6->TabIndex = 5;
			checkBox6->Text = S"Check boxes";
			checkBox6->Size = System::Drawing::Size(100, 23);
			toolTip1->SetToolTip(checkBox6, S"Indicates wheter checkboxes are displayed beside nodes");
			checkBox6->add_Click( new EventHandler(this, CheckBox6_click) );
			
			checkBox1->TextAlign = ContentAlignment::MiddleLeft;
			checkBox1->Location = Point(16, 16);
			checkBox1->TabIndex = 0;
			checkBox1->Text = S"Sorted";
			checkBox1->Size = System::Drawing::Size(100, 23);
			toolTip1->SetToolTip(checkBox1, S"Indicates whether nodes are sorted.");
			checkBox1->add_Click( new EventHandler(this, checkBox1_Click) );
			
			checkBox3->TextAlign = ContentAlignment::MiddleLeft;
			checkBox3->Location = Point(16, 64);
			checkBox3->TabIndex = 2;
			checkBox3->CheckState = CheckState::Checked;
			checkBox3->Text = S"Show lines";
			checkBox3->Size = System::Drawing::Size(100, 23);
			checkBox3->Checked = true;
			toolTip1->SetToolTip(checkBox3, S"Indicates whether lines are displayed between sibling nodes and between parent and children nodes.");
			checkBox3->add_Click( new EventHandler(this, CheckBox3_click) );
			
			imageList1->TransparentColor = Color::Transparent;
			//@design imageList1->SetLocation(Point(20, 10));
			
			imageListComboBox->ForeColor = (Color)SystemColors::WindowText;
			imageListComboBox->Location = Point(88, 192);
			imageListComboBox->TabIndex = 8;
			imageListComboBox->Text = S"";
			imageListComboBox->Size = System::Drawing::Size(120, 21);
			imageListComboBox->add_SelectedIndexChanged( new EventHandler(this, imageListComboBox_SelectedIndexChanged) );
			
			String* tempObjarr[] = new String*[3];
			tempObjarr[0] = S"(none)";
			tempObjarr[1] = S"System images";
			tempObjarr[2] = S"Bitmaps";
			imageListComboBox->Items->AddRange(tempObjarr);
			
			checkBox4->TextAlign = ContentAlignment::MiddleLeft;
			checkBox4->Location = Point(16, 88);
			checkBox4->TabIndex = 3;
			checkBox4->CheckState = CheckState::Checked;
			checkBox4->Text = S"Show root lines";
			checkBox4->Size = System::Drawing::Size(100, 23);
			checkBox4->Checked = true;
			toolTip1->SetToolTip(checkBox4, S"Indicates whether lines are displayed between root nodes.");
			checkBox4->add_Click( new EventHandler(this, CheckBox4_click) );
			
			grpTreeView->Location = Point(248, 16);
			grpTreeView->TabIndex = 1;
			grpTreeView->TabStop = false;
			grpTreeView->Text = S"TreeView";
			grpTreeView->Size = System::Drawing::Size(248, 264);
			
			checkBox2->TextAlign = ContentAlignment::MiddleLeft;
			checkBox2->Location = Point(16, 40);
			checkBox2->TabIndex = 1;
			checkBox2->Text = S"Hot tracking";
			checkBox2->Size = System::Drawing::Size(100, 23);
			toolTip1->SetToolTip(checkBox2, S"Indicates whether nodes give feedback when the mouse is moved over them.");
			checkBox2->add_Click( new EventHandler(this, CheckBox2_click) );
			
			label1->Location = Point(16, 194);
			label1->TabIndex = 7;
			label1->TabStop = false;
			label1->Text = S"Image list:";
			label1->Size = System::Drawing::Size(56, 16);
			
			grpTreeView->Controls->Add(checkBox7);
			grpTreeView->Controls->Add(checkBox6);
			grpTreeView->Controls->Add(checkBox5);
			grpTreeView->Controls->Add(checkBox4);
			grpTreeView->Controls->Add(checkBox3);
			grpTreeView->Controls->Add(checkBox2);
			grpTreeView->Controls->Add(label4);
			grpTreeView->Controls->Add(indentUpDown);
			grpTreeView->Controls->Add(label1);
			grpTreeView->Controls->Add(imageListComboBox);
			grpTreeView->Controls->Add(checkBox1);
			Controls->Add(grpTreeView);
			Controls->Add(directoryTree);
			
		}
	};
};

void main() { 
	System::Threading::Thread::CurrentThread->ApartmentState = System::Threading::ApartmentState::STA;
	Application::Run(new TreeViewCtl::TreeViewCtl());
}

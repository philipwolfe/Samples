/*=====================================================================
  File:     BDayPicker.cpp

  Summary:  The BirthdayPicker sample shows some basic user
            interface techniques, including tree views with
            tree nodes and menus.
---------------------------------------------------------------------
  This file is part of the Microsoft VC++ Code Samples.

  Copyright (C) 2001 Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

#include "resource.h"

#define null 0L

#using <mscorlib.dll>
#using <System.DLL>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.DLL>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace BDayPicker
{

__gc class BDayPicker : public Form
{
public:
	
	// constructor
	BDayPicker() : DTPIsDirty(false)
	{
		// This call is required for support of the WFC Form Designer.
		InitForm();
		pInfoDTP->Value = DateTime::Today;
	}

	// destructor
	virtual ~BDayPicker()
	{
	}

private:
	
	// Event handler for exit menu item.
	void MenuItem2_Click(Object * /* pSender */, EventArgs * /* pEventArgs */)
	{
		Close();
	}

	// Deletes selected node in tree.
	void DeleteNode(Object * /* pSender */, EventArgs * /* pEventArgs */)
	{
		TreeNode * pSelNode = pDateInfoTreeView->SelectedNode;
		if (pSelNode)
		{
			if (pSelNode->GetNodeCount(true) < 1)
			{
				pSelNode = pSelNode->Parent;
            }

            pSelNode->Remove();
        }
	}

	// Deletes all nodes in tree.
	void ClearAllNodes(Object * /* pSender */, EventArgs * /* pEventArgs */)
	{ 
		pDateInfoTreeView->Nodes->Clear();           
	}

	// Populates the tree view control with information.
	void AddDateInfo(Object * /* pSender */, EventArgs * /* pEventArgs */)
	{
		if (DTPIsDirty)
		{
			DateTime TmpTime = pInfoDTP->Value.Date;
			DateTime StartTime = pStartDTP->Value.Date;

			//create the new root node and all its children
			TreeNode * pNewNode = new TreeNode(TmpTime.ToString(), 0, 0);
			TimeSpan TheTimeSpan = TmpTime - StartTime;
			
			
			long TotalDays = TheTimeSpan.Days;
			pNewNode->Nodes->Insert(1, new TreeNode(
				String::Format(S"days alive is {0} ",
				__box(TotalDays)), 1, 1));

			double TotalYears = TotalDays / 365.25;
			pNewNode->Nodes->Insert(2, new TreeNode(
				String::Format(S" you are {0:F4} years old",
				__box(TotalYears)), 2, 2));

			
			double TotalDogYears = TotalDays / (365.25 / 7);
			pNewNode->Nodes->Insert(3, new TreeNode(
				String::Format(S"in Dog years you are {0:F4}",
				__box(TotalDogYears)), 3, 3));
			
			long TotalMoons = TotalDays / 28;
			pNewNode->Nodes->Insert(4, new TreeNode(
				String::Format(S"you have been alive for {0} new moons",
				__box(TotalMoons)), 4, 4));
			
			long TotalFlyGenerations = TotalDays / 27;
			pNewNode->Nodes->Insert(5, new TreeNode(
				String::Format(S"in fruit fly lives you are {0} generations old",
				__box(TotalFlyGenerations)), 5, 5));
			
			pDateInfoTreeView->Nodes->Insert(1, pNewNode);
			pNewNode->Expand();
			DTPIsDirty = false;
		}
	}

	// KeyUp event handler for tree view control.
	void DateInfoTreeView_KeyUp(Object * pSender, KeyEventArgs * pEvent)
	{
		if (pEvent->KeyCode == Keys::Delete)
		{
			DeleteNode(pSender, pEvent);
        }
	}

	// Event handler for datetimepicker control.
	void DateEntry_ValueChanged(Object * /* pSender */, EventArgs * /* pEventArgs */)
	{
		DTPIsDirty = true;
	}

	// Event handler for datetimepicker control.
	void DateEntry_KeyPress(Object * pSender, KeyPressEventArgs * pEvent)
	{
		if (pEvent->KeyChar ==Keys::Return)
		{
			DTPIsDirty = true;
			AddDateInfo(pSender, pEvent);
			pEvent->Handled = true;
		}
	}

	void InitForm()
	{
		Resources::ResourceManager * pResources =
			new Resources::ResourceManager(S"birthdaypicker", Reflection::Assembly::GetExecutingAssembly());

		Icon = dynamic_cast<System::Drawing::Icon*>(
			pResources->GetObject(S"$this.Icon"));

	
		pComponents = new System::ComponentModel::Container();
		pInfoDTP = new DateTimePicker();
		pDateInfoImageList = new ImageList();
		pPanel1 = new Panel();
		pMyToolTip = new ToolTip(pComponents);
		pLabel1 = new Label();
		pMyMainMenu = new MainMenu();
		pMenuItem2 = new MenuItem();
		pStartDTP = new DateTimePicker();
		pStartDateLbl = new Label();
		pClearAllContextMenu = new MenuItem();
		pMenuItem1 = new MenuItem();
		pDateInfoTreeView = new TreeView();
		pContextMenu1 = new Windows::Forms::ContextMenu();
		pDeleteNodeContextMenu = new MenuItem();

		pInfoDTP->Location = Point(80, 48);
		pInfoDTP->TabIndex = 3;
//		pInfoDTP->ValueSet = true;
		pInfoDTP->Format = DateTimePickerFormat::Short;
		pInfoDTP->Size = System::Drawing::Size(88, 21);
		pInfoDTP->add_KeyPress( new KeyPressEventHandler(this, DateEntry_KeyPress) );
		pInfoDTP->add_ValueChanged( new EventHandler(this, DateEntry_ValueChanged) );
		pInfoDTP->add_Leave( new EventHandler(this, AddDateInfo) );
		pInfoDTP->add_CloseUp( new EventHandler(this, AddDateInfo) );
		
		pMyToolTip->SetToolTip(pInfoDTP, S"Date for which you want information");

		pDateInfoImageList->ImageStream = 
			dynamic_cast<ImageListStreamer *>(
			pResources->GetObject(S"imageList1.ImageStream"));

		pPanel1->Dock = DockStyle::Top;
		pPanel1->TabIndex = 1;
		pPanel1->Text = S"panel1";
		pPanel1->Size = System::Drawing::Size(403, 80);
		
		pMyToolTip->Active = true;
		
		Menu = pMyMainMenu;
		AutoScaleBaseSize = System::Drawing::Size(5, 13);
		ClientSize = System::Drawing::Size(403, 329);
		Text = S"Birthday Picker";

		pLabel1->Location = Point(8, 48);
		pLabel1->TabIndex = 2;
		pLabel1->TabStop = false;
		pLabel1->Text = S"&Info Date:";
		pLabel1->Size = System::Drawing::Size(56, 16);
		
		MenuItem* pMenuItems[] = new MenuItem *[1];
		pMenuItems[0] = pMenuItem1;
		pMyMainMenu->MenuItems->AddRange( pMenuItems );
		
		pMenuItem2->MergeType = MenuMerge::Remove;
		pMenuItem2->Text = S"E&xit";
		pMenuItem2->add_Click( new EventHandler(this, MenuItem2_Click) );
		
		pStartDTP->Location = Point(80, 16);
		pStartDTP->TabIndex = 1;
//		pStartDTP->ValueSet = true;
		pStartDTP->Format = DateTimePickerFormat::Short;
		pStartDTP->Value = DateTime::Parse(S"10/6/1963 12:00:00 AM");
		pStartDTP->Size = System::Drawing::Size(88, 21);
		pStartDTP->add_KeyPress( new KeyPressEventHandler(this, DateEntry_KeyPress) );
		pStartDTP->add_ValueChanged( new EventHandler(this, DateEntry_ValueChanged) );
		pStartDTP->add_Leave( new EventHandler(this, AddDateInfo) );
		pStartDTP->add_CloseUp( new EventHandler(this, AddDateInfo) );
		
		pMyToolTip->SetToolTip(pStartDTP, S"Start date for the calculations");
		
		pStartDateLbl->Location = Point(8, 15);
		pStartDateLbl->TabIndex = 0;
		pStartDateLbl->TabStop = false;
		pStartDateLbl->Text = S"&Date of Birth:";
		pStartDateLbl->Size = System::Drawing::Size(62, 25);
		
		pClearAllContextMenu->Text = S"Delete &All Dates";
		pClearAllContextMenu->add_Click( new EventHandler(this, ClearAllNodes) );
		
		pMenuItem1->MergeType = MenuMerge::Replace;
		pMenuItem1->Text = S"&File";
		pMenuItems[0] = pMenuItem2;
		pMenuItem1->MenuItems->AddRange(pMenuItems);
		
		pDateInfoTreeView->Dock = DockStyle::Top;
		pDateInfoTreeView->ImageList = pDateInfoImageList;
		pDateInfoTreeView->ForeColor = SystemColors::WindowText;
		pDateInfoTreeView->Location = Point(10, 50);
		pDateInfoTreeView->TabIndex = 0;
		pDateInfoTreeView->Indent = 19;
		pDateInfoTreeView->Text = S"treeView1";
		pDateInfoTreeView->Size = System::Drawing::Size(400, 250);
		pDateInfoTreeView->ContextMenu = pContextMenu1;
		pDateInfoTreeView->add_KeyUp( new KeyEventHandler(this, DateInfoTreeView_KeyUp) );
		
		pMenuItems = new MenuItem *[2];
		pMenuItems[0] = pClearAllContextMenu;
		pMenuItems[1] = pDeleteNodeContextMenu;
		pContextMenu1->MenuItems->AddRange( pMenuItems );
		
		pDeleteNodeContextMenu->Text = S"&Delete Date";
		pDeleteNodeContextMenu->add_Click( new EventHandler(this, DeleteNode) );
		
		pPanel1->Controls->Add(pInfoDTP);
		pPanel1->Controls->Add(pStartDTP);
		pPanel1->Controls->Add(pLabel1);
		pPanel1->Controls->Add(pStartDateLbl);
		Controls->Add(pPanel1);
		Controls->Add(pDateInfoTreeView);
	}

private:
	System::ComponentModel::Container * pComponents;
	MainMenu * pMyMainMenu;
	MenuItem * pClearAllContextMenu;
	MenuItem * pDeleteNodeContextMenu;
	MenuItem * pMenuItem1;
	MenuItem * pMenuItem2;
	Windows::Forms::ContextMenu * pContextMenu1;
	Panel * pPanel1;
	Label * pStartDateLbl;
	Label * pLabel1;
	DateTimePicker * pStartDTP;
	DateTimePicker * pInfoDTP;
	TreeView * pDateInfoTreeView;
	ImageList * pDateInfoImageList;
	ToolTip * pMyToolTip;
	bool DTPIsDirty;
};

}

int main()
{
	Application::Run(new BDayPicker::BDayPicker());
	return 0;
}
/*=====================================================================
  File:      CheckedListBoxCtl.cpp

  Summary:   This sample demonstrates the properties and features
             of the CheckedListBox control.

---------------------------------------------------------------------
  This file is part of the Microsoft COM+ 2.0 SDK Code Samples.

  Copyright (C) 1999 Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/
#using <mscorlib.dll>
#using <System.DLL>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.DLL>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace CheckedListBoxCtl
{
	__gc class CheckedListBoxCtl : public Form
	{
	private:
		String* fruits[];
        
	public:
		CheckedListBoxCtl () : Form()
		{
			fruits = new String*[13];

			fruits[0] = S"Spruce";
			fruits[1] = S"Ash";
			fruits[2] = S"Koa";
			fruits[3] = S"Elm";
			fruits[4] = S"Oak";
			fruits[5] = S"Cherry";
			fruits[6] = S"Ironwood";
			fruits[7] = S"Cedar";
			fruits[8] = S"Sequoia";
			fruits[9] = S"Walnut";
			fruits[10] = S"Maple";
			fruits[11] = S"Balsa";
			fruits[12] = S"Pine";

			InitForm();

			// Add all but the last five fruits to the checkedListBox1
			for (int i = 0; i < fruits->Length - 5; i++) {
				checkedListBox1->Items->Add(fruits[i], false);
			}
		}

	private:
		void chkThreeDCheckBoxes_Click(Object* sender, EventArgs* e)
		{
			checkedListBox1->ThreeDCheckBoxes = chkThreeDCheckBoxes->Checked;
		}

		void chkIntegralHeight_Click(Object* sender, EventArgs* e)
		{
			checkedListBox1->IntegralHeight = chkIntegralHeight->Checked;
			if(chkIntegralHeight->Checked)
				checkedListBox1->Height = 94;
			else
				checkedListBox1->Height = ckListBoxdefaultHeight;
		}

		void chkMultiColumn_Click(Object* sender, EventArgs* e)
		{
			checkedListBox1->MultiColumn = chkMultiColumn->Checked;
		}

		void chkSorted_Click(Object* sender, EventArgs* e)
		{
			checkedListBox1->Sorted = chkSorted->Checked;
			cmdReset->Enabled = !chkSorted->Checked;
		}

		void chkOnClick_Click(Object* sender, EventArgs* e)
		{
			checkedListBox1->CheckOnClick = chkOnClick->Checked;
		}

		void cmdAdd_Click(Object* sender, EventArgs* e)
		{
			// If we still have some fruit that have not been
			// added to the checkedListBox1, run through the list
			// and add the first fruit that has not been added.
			int ckListItemCount = checkedListBox1->Items->Count;
			if(ckListItemCount < fruits->Length)
			{
				bool fruitExists = false;
				int idxNewFruit = 0;
				while(true)
				{
					fruitExists = false;
					for(int j = 0; j < ckListItemCount; j++)
					{
						if( 0 == String::Compare(fruits[idxNewFruit], checkedListBox1->Items->Item[j]->ToString()) )
						{
							fruitExists = true;
							break;
						}
					}
					if(fruitExists)
						++idxNewFruit;
					else
						break;
				}
				checkedListBox1->Items->Add(fruits[idxNewFruit], false);
				checkedListBox1->Sorted = chkSorted->Checked;
			}

			if(checkedListBox1->Items->Count == fruits->Length)
				cmdAdd->Enabled = false;

			if(checkedListBox1->Items->Count > 0)
				cmdRemove->Enabled = true;
		}

		//     Event that gets fired when the user clicks on the Remove button.
		//     This handler removes the selected fruit from the list.
		void cmdRemove_Click(Object* sender, EventArgs* e)
		{
			if (checkedListBox1->SelectedIndex >= 0)
			{
				int index = checkedListBox1->SelectedIndex;
				checkedListBox1->Items->RemoveAt(index);

				if (index > 0)
					checkedListBox1->SelectedIndex = index - 1;
				else if (checkedListBox1->Items->Count != 0)
					checkedListBox1->SelectedIndex = 0;
			}

			if (checkedListBox1->Items->Count== 0)
				cmdRemove->Enabled = false;

			if(checkedListBox1->Items->Count < fruits->Length)
				cmdAdd->Enabled = true;
		}

		//     Event that gets fired when the user clicks on the Reset button.
		void cmdReset_Click(Object* sender, EventArgs* e )
		{
			int nListItems = checkedListBox1->Items->Count;
			bool new_checked __gc[] = new bool __gc[fruits.Length];
			String* item = S"";

			for (int k = 0; k < fruits->Length; k++)
				new_checked[k] = false;

			int m = 0;
			for (int k = 0; k < nListItems; k++) {
				if (checkedListBox1->GetItemChecked(k)) {
					item = checkedListBox1->Items->Item[k]->ToString();
					for (m = 0; m < fruits->Length; m++)
					if (fruits[m]->Equals(item))
					new_checked[m] = true;
				}
			}

			checkedListBox1->Items->Clear();

			for (int j = 0; j < nListItems; j++)
			{
				checkedListBox1->Items->Add(fruits[j],new_checked[j]);
			}

			cmdReset->Enabled = false;
		}

		System::ComponentModel::Container* components;
		ToolTip* toolTip1;
		GroupBox* groupBox1;
		CheckBox* chkOnClick;
		CheckBox* chkIntegralHeight;
		CheckBox* chkMultiColumn;
		Button* cmdAdd;
		CheckBox* chkSorted;
		Button* cmdRemove;
		Button* cmdReset;
		CheckBox* chkThreeDCheckBoxes;
		CheckedListBox* checkedListBox1;
		Int32 ckListBoxdefaultHeight;

		void InitForm()
		{
			components = new System::ComponentModel::Container;
			chkMultiColumn = new CheckBox();
			cmdRemove = new Button();
			chkSorted = new CheckBox();
			cmdReset = new Button();
			chkThreeDCheckBoxes = new CheckBox();
			groupBox1 = new GroupBox();
			chkOnClick = new CheckBox();
			chkIntegralHeight = new CheckBox();
			cmdAdd = new Button();
			checkedListBox1 = new CheckedListBox();
			toolTip1 = new ToolTip(components);

			chkMultiColumn->Location = Point(16, 72);
			chkMultiColumn->TabIndex = 2;
			chkMultiColumn->CheckState = CheckState::Checked;
			chkMultiColumn->Text = S"&Multi column";
			chkMultiColumn->Size = System::Drawing::Size(104, 25);
			chkMultiColumn->Checked = true;
			toolTip1->SetToolTip(chkMultiColumn, S"Indicates if the list should spawn on more than one column or not.");
			chkMultiColumn->add_Click( new EventHandler(this, chkMultiColumn_Click) );

			cmdRemove->Location = Point(96, 168);
			cmdRemove->TabIndex = 3;
			cmdRemove->Text = S"&Remove";
			cmdRemove->Size = System::Drawing::Size(75, 23);
			cmdRemove->add_Click( new EventHandler(this, cmdRemove_Click) );

			chkSorted->Location = Point(16, 96);
			chkSorted->TabIndex = 3;
			chkSorted->Text = S"&Sorted";
			chkSorted->Size = System::Drawing::Size(136, 25);
			toolTip1->SetToolTip(chkSorted, S"Controls whether the list is sorted.");
			chkSorted->add_Click( new EventHandler(this, chkSorted_Click) );

			cmdReset->Location = Point(16, 200);
			cmdReset->TabIndex = 4;
			cmdReset->Enabled = false;
			cmdReset->Text = S"&Reset";
			cmdReset->Size = System::Drawing::Size(75, 23);
			cmdReset->add_Click( new EventHandler(this, cmdReset_Click) );

			chkThreeDCheckBoxes->Location = Point(16, 24);
			chkThreeDCheckBoxes->TabIndex = 0;
			chkThreeDCheckBoxes->CheckState = CheckState::Checked;
			chkThreeDCheckBoxes->Text = S"&3D check boxes";
			chkThreeDCheckBoxes->Size = System::Drawing::Size(136, 25);
			chkThreeDCheckBoxes->Checked = true;
			toolTip1->SetToolTip(chkThreeDCheckBoxes, S"Indicates if the check values should be shown as flat or 3D checkmarks.");
			chkThreeDCheckBoxes->add_Click( new EventHandler(this, chkThreeDCheckBoxes_Click) );

			groupBox1->Location = Point(248, 16);
			groupBox1->TabIndex = 0;
			groupBox1->TabStop = false;
			groupBox1->Text = S"CheckedListBox";
			groupBox1->Size = System::Drawing::Size(248, 264);

			chkOnClick->Location = Point(16, 120);
			chkOnClick->TabIndex = 4;
			chkOnClick->CheckState = CheckState::Checked;
			chkOnClick->Text = S"&Check on click";
			chkOnClick->Size = System::Drawing::Size(136, 25);
			chkOnClick->Checked = true;
			toolTip1->SetToolTip(chkOnClick, S"Indicates whether the check box should be toggled on the first click on an item.");
			chkOnClick->add_Click( new EventHandler(this, chkOnClick_Click) );

			chkIntegralHeight->Location = Point(16, 48);
			chkIntegralHeight->TabIndex = 1;
			chkIntegralHeight->CheckState = CheckState::Checked;
			chkIntegralHeight->Text = S"&Integral height";
			chkIntegralHeight->Size = System::Drawing::Size(120, 25);
			chkIntegralHeight->Checked = true;
			toolTip1->SetToolTip(chkIntegralHeight, S"Indicates if the list items should have integral heights or not.");
			chkIntegralHeight->add_Click( new EventHandler(this, chkIntegralHeight_Click) );

			cmdAdd->Location = Point(16, 168);
			cmdAdd->TabIndex = 2;
			cmdAdd->Text = S"&Add";
			cmdAdd->Size = System::Drawing::Size(75, 23);
			cmdAdd->add_Click( new EventHandler(this, cmdAdd_Click) );

			checkedListBox1->ThreeDCheckBoxes = true;
			checkedListBox1->IntegralHeight = false;
			checkedListBox1->TabIndex = 1;
			checkedListBox1->CheckOnClick = true;
			checkedListBox1->ColumnWidth = 100;
			checkedListBox1->MultiColumn = true;
			checkedListBox1->Size = System::Drawing::Size(232, 84);
			checkedListBox1->Location = Point(8, 24);
			checkedListBox1->Text = S"checkedListBox1";
			ckListBoxdefaultHeight = checkedListBox1->Height;

			toolTip1->Active = true;
			//@design toolTip1.SetLocation(Point(10, 10));

			Text = S"Checked ListBox";
			TabIndex = 0;
			Size = System::Drawing::Size(512, 320);

			Controls->Add(groupBox1);
			Controls->Add(cmdAdd);
			Controls->Add(cmdRemove);
			Controls->Add(cmdReset);
			Controls->Add(checkedListBox1);
			groupBox1->Controls->Add(chkOnClick);
			groupBox1->Controls->Add(chkIntegralHeight);
			groupBox1->Controls->Add(chkMultiColumn);
			groupBox1->Controls->Add(chkThreeDCheckBoxes);
			groupBox1->Controls->Add(chkSorted);
		}
	};
};

// The main entry point for the application.
void main()
{
	Application::Run(new CheckedListBoxCtl::CheckedListBoxCtl());
}
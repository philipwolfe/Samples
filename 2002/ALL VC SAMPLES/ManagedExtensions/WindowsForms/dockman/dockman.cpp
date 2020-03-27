/*=====================================================================
  File:      DockMan.cpp

  Summary:   This class demonstrates the interaction of the Dock and
             Anchor properties on a CommandButton.

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
#define null 0L

#using <mscorlib.dll>
#using <System.DLL>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.DLL>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace DockMan
{
    __gc class DockMan : public Form
	{
	public:
		
		// Constructor
        DockMan()
		{
            // This call is required for support of the WFC Form Designer.
            InitForm();

            // Complete intialization of the form
            pRdbSet = pRdbNone;
            pRdbAnchSet = pRdbAnchNone;
            ApplyChanges(); 
        }

	private:
        
		// Update control with new anchor and dock settings.
        // Note that anchor == NONE is the same as (TOP && LEFT).
        void ApplyChanges()
		{
            //Apply Anchoring Settings - one only

            if( (pRdbAnchSet == null) || (pRdbAnchSet == pRdbAnchNone) )
				pBtnDemo->Anchor = AnchorStyles::None;
            else if (pRdbAnchSet == pRdbAnchTop)
				pBtnDemo->Anchor = AnchorStyles::Top;
            else if (pRdbAnchSet == pRdbAnchLeft)
				pBtnDemo->Anchor = AnchorStyles::Left;
            else if (pRdbAnchSet == pRdbAnchBottom)
				pBtnDemo->Anchor = AnchorStyles::Bottom;
            else if (pRdbAnchSet == pRdbAnchRight) 
				pBtnDemo->Anchor = AnchorStyles::Right;

			//Apply Docking settings - one only
            if( (pRdbSet == null) || (pRdbSet == pRdbNone) )
				pBtnDemo->Dock = DockStyle::None;
            else if (pRdbSet == pRdbTop)
				pBtnDemo->Dock = DockStyle::Top;
            else if (pRdbSet == pRdbLeft)
				pBtnDemo->Dock = DockStyle::Left;
            else if (pRdbSet == pRdbBottom)
				pBtnDemo->Dock = DockStyle::Bottom;
            else if (pRdbSet == pRdbRight) 
				pBtnDemo->Dock = DockStyle::Right;
            else // The default is: if (pRdbSet is rbFill)
				pBtnDemo->Dock = DockStyle::Fill;
        }

        //  Save the radio button that was clicked so we know which one is
        //  checked when we apply the changes.  Note, all radio buttons use
        //  this same click handler.
        void anchRadioBtn_Click(Object * pSender, EventArgs * pE )
		{
			pRdbAnchSet = dynamic_cast<RadioButton *>(pSender);
            ApplyChanges();
        }

        //  Save the radio button that was clicked so we know which one is
        //  checked when we apply the changes.  Note, all radio buttons use
        //  this same click handler.
        void dockRadioBtn_Click(Object * pSender, EventArgs * /* pE */) {
			pRdbSet = dynamic_cast<RadioButton *>(pSender);
            ApplyChanges();
        }

        void InitForm()
		{
			pComponents = new System::ComponentModel::Container();
			pGroupBox1 = new GroupBox();
			pGroupBox2 = new GroupBox();
			pSplitter1 = new Splitter();
			pBtnDemo = new Button();
			pRdbFill = new RadioButton();
			pToolTip1 = new ToolTip(pComponents);
			pRdbSet = new RadioButton();
			pRdbNone = new RadioButton();
			pRdbTop = new RadioButton();
			pRdbBottom = new RadioButton();
			pRdbLeft = new RadioButton();
			pRdbRight = new RadioButton();

			pRdbAnchNone = new RadioButton();
			pRdbAnchTop = new RadioButton();
			pRdbAnchLeft = new RadioButton();
			pPanel1 = new Panel();
			pRdbAnchRight = new RadioButton();
			pRdbAnchBottom = new RadioButton();
			pPanel2 = new Panel();
		
			pGroupBox1->Location = Point(16, 8);
			pGroupBox1->TabIndex = 0;
			pGroupBox1->TabStop = false;
			pGroupBox1->Text = S"A&nchor";
			pGroupBox1->Size = System::Drawing::Size(88, 136);
		
			pGroupBox2->Location = Point(16, 152);
			pGroupBox2->TabIndex = 1;
			pGroupBox2->TabStop = false;
			pGroupBox2->Text = S"&Dock";
			pGroupBox2->Size = System::Drawing::Size(88, 176);
		
			pRdbSet->Text = S"pRdbSet";
			pRdbSet->Size = System::Drawing::Size(100, 23);
		
			pSplitter1->BackColor = Color::Blue;
			pSplitter1->Dock = DockStyle::Right;
			pSplitter1->Location = Point(325, 0);
			pSplitter1->TabIndex = 2;
			pSplitter1->Anchor = AnchorStyles::None;
			pSplitter1->TabStop = false;
			pSplitter1->Size = System::Drawing::Size(3, 400);
			
			pBtnDemo->Location = Point(98, 142);
			pBtnDemo->BackColor = SystemColors::Control;
			pBtnDemo->FlatStyle = FlatStyle::Popup;
			pBtnDemo->TabIndex = 0;
			pBtnDemo->Anchor = AnchorStyles::None;
			pBtnDemo->Text = S"Demo Button";
			pBtnDemo->Size = System::Drawing::Size(120, 24);
			pToolTip1->SetToolTip(pBtnDemo, S"Nothing happens if you click this button.");
			
			pRdbFill->Location = Point(8, 144);
			pRdbFill->TabIndex = 2;
			pRdbFill->Text = S"&Fill";
			pRdbFill->Size = System::Drawing::Size(72, 24);
			pRdbFill->add_Click( new EventHandler(this, dockRadioBtn_Click) );
		
			pToolTip1->Active = true;
			
			pRdbTop->Location = Point(8, 48);
			pRdbTop->TabIndex = 0;
			pRdbTop->Text = S"&Top";
			pRdbTop->Size = System::Drawing::Size(72, 24);
			pRdbTop->add_Click( new EventHandler(this, dockRadioBtn_Click) );

			pRdbBottom->Location = Point(8, 96);
			pRdbBottom->TabIndex = 1;
			pRdbBottom->Text = S"&Bottom";
			pRdbBottom->Size = System::Drawing::Size(72, 24);
			pRdbBottom->add_Click( new EventHandler(this, dockRadioBtn_Click) );
			
			pRdbNone->Location = Point(8, 24);
			pRdbNone->TabIndex = 5;
			pRdbNone->TabStop = true;
			pRdbNone->Text = S"&None";
			pRdbNone->Size = System::Drawing::Size(72, 24);
			pRdbNone->Checked = true;
			pRdbNone->add_Click( new EventHandler(this, dockRadioBtn_Click) );
			
			pRdbLeft->Location = Point(8, 72);
			pRdbLeft->TabIndex = 3;
			pRdbLeft->Text = S"&Left";
			pRdbLeft->Size = System::Drawing::Size(72, 24);
			pRdbLeft->add_Click( new EventHandler(this, dockRadioBtn_Click) );
			
			pRdbRight->Location = Point(8, 120);
			pRdbRight->TabIndex = 4;
			pRdbRight->Text = S"&Right";
			pRdbRight->Size = System::Drawing::Size(72, 24);
			pRdbRight->add_Click( new EventHandler(this, dockRadioBtn_Click) );
		
			Location = Point(100, 100);
			AutoScaleBaseSize = System::Drawing::Size(5, 13);
			ClientSize = System::Drawing::Size(448, 400);
			SizeGripStyle = SizeGripStyle::Show;
			Text = S"Docking and Anchoring Example";
			add_Click( new EventHandler(this, anchRadioBtn_Click) );
			
			pPanel1->BorderStyle = BorderStyle::Fixed3D;
			pPanel1->Dock = DockStyle::Fill;
			pPanel1->BackColor = Color::Green;
			pPanel1->TabIndex = 1;
			pPanel1->Text = S"ButtonPanel";
			pPanel1->Size = System::Drawing::Size(325, 400);
			
			pRdbAnchNone->Location = Point(8, 11);
			pRdbAnchNone->TabIndex = 0;
			pRdbAnchNone->Text = S"&None";
			pRdbAnchNone->Size = System::Drawing::Size(72, 24);
			pRdbAnchNone->add_Click( new EventHandler(this, anchRadioBtn_Click) );

			pRdbAnchTop->Location = Point(8, 35);
			pRdbAnchTop->TabIndex = 0;
			pRdbAnchTop->Text = S"&Top";
			pRdbAnchTop->Size = System::Drawing::Size(72, 24);
			pRdbAnchTop->add_Click( new EventHandler(this, anchRadioBtn_Click) );

			pRdbAnchLeft->Location = Point(8, 59);
			pRdbAnchLeft->TabIndex = 2;
			pRdbAnchLeft->Text = S"&Left";
			pRdbAnchLeft->Size = System::Drawing::Size(72, 24);
			pRdbAnchLeft->add_Click( new EventHandler(this, anchRadioBtn_Click) );
			
			pRdbAnchBottom->Location = Point(8, 83);
			pRdbAnchBottom->TabIndex = 3;
			pRdbAnchBottom->Text = S"&Bottom";
			pRdbAnchBottom->Size = System::Drawing::Size(72, 24);
			
			pRdbAnchRight->Location = Point(8, 107);
			pRdbAnchRight->TabIndex = 1;
			pRdbAnchRight->Text = S"&Right";
			pRdbAnchRight->Size = System::Drawing::Size(72, 24);
			pRdbAnchRight->add_Click( new EventHandler(this, anchRadioBtn_Click) );
			
			pPanel2->BorderStyle = BorderStyle::Fixed3D;
			pPanel2->Dock = DockStyle::Right;
			pPanel2->Location = Point(328, 0);
			pPanel2->TabIndex = 0;
			pPanel2->Text = S"ControlsPanel";
			pPanel2->Size = System::Drawing::Size(120, 400);
			pToolTip1->SetToolTip(pPanel2, S"Resize the form to see the layout effects.");
			
			Controls->Add(pPanel1);
			Controls->Add(pPanel2);
			Controls->Add(pSplitter1);
			pPanel1->Controls->Add(pBtnDemo);
			pPanel2->Controls->Add(pGroupBox1);
			pPanel2->Controls->Add(pGroupBox2);
			pGroupBox1->Controls->Add(pRdbAnchNone);
			pGroupBox1->Controls->Add(pRdbAnchRight);
			pGroupBox1->Controls->Add(pRdbAnchBottom);
			pGroupBox1->Controls->Add(pRdbAnchLeft);
			pGroupBox1->Controls->Add(pRdbAnchTop);
			pGroupBox2->Controls->Add(pRdbBottom);
			pGroupBox2->Controls->Add(pRdbLeft);
			pGroupBox2->Controls->Add(pRdbNone);
			pGroupBox2->Controls->Add(pRdbRight);
			pGroupBox2->Controls->Add(pRdbFill);
			pGroupBox2->Controls->Add(pRdbTop);
		}

	private:
			
		// pRdbSet keeps track of which docking radio button is checked
		RadioButton * pRdbSet;

		// pRdbAnchSet keeps track of which anchoring radio button is checked
		RadioButton * pRdbAnchSet;

		// NOTE: The following code is required by the WFC Form Designer
		// It can be modified using the WFC Form Designer.  
		// Do not modify it using the code editor.
		System::ComponentModel::Container * pComponents;
		Panel * pPanel1;
		Panel * pPanel2;
		GroupBox * pGroupBox1;
		GroupBox * pGroupBox2;
		ToolTip * pToolTip1;
		Button * pBtnDemo;
		RadioButton * pRdbNone;   
		RadioButton * pRdbTop;    
		RadioButton * pRdbLeft;   
		RadioButton * pRdbBottom; 
		RadioButton * pRdbRight;  
		RadioButton * pRdbFill;    

		RadioButton * pRdbAnchNone;   
		RadioButton * pRdbAnchTop;    
		RadioButton * pRdbAnchLeft;   
		RadioButton * pRdbAnchBottom; 
		RadioButton * pRdbAnchRight;  
		Splitter * pSplitter1;
	};
}

int main ()
{
	Application::Run(new DockMan::DockMan());
	return 0;
}
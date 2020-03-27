/*=====================================================================
  File:      TrackBarCtl.cpp

  Summary:   This sample demonstrates the properties and features
             of the TrackBar control. 
             
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

namespace TrackBarCtl {

	__gc class TrackBarCtl : public Form
    {
    public:
    	TrackBarCtl() : Form()
    	{

            // Required for WFC Form Designer support
            InitForm();

            InitState();
        }

        // <doc>
        // <desc>
        //     Sets up the form so that the fields which drive the TrackBar
        //     show up with the correct initial fields.
        // </desc>
        // </doc>
        //
	private:
		void InitState()
		{
            trackbar->TickFrequency = 5;
            cmbTickFreq->SelectedIndex = 2;

            trackbar->SmallChange = 5;
            cmbSmallChange->SelectedIndex = 2;

            trackbar->LargeChange = 25;
            cmbLargeChange->SelectedIndex = 1;

            trackbar->Minimum = 0;
            cmbMinimum->SelectedIndex = 0;

            trackbar->Maximum = 100;
            cmbMaximum->SelectedIndex = 0;

            trackbar->Orientation = Orientation::Horizontal;
            cmbOrientation->SelectedIndex = 0;

            trackbar->TickStyle = TickStyle::None;
            cmbTickStyle->SelectedIndex = 0;

			lblValue->Text = trackbar->Value.ToString();
        }

	private:
		void CmbTickFreq_selectedIndexChanged(Object* source, EventArgs* e)
		{
            try
            {
                int newVal = Int32::Parse(cmbTickFreq->SelectedItem->ToString());
                trackbar->TickFrequency = newVal;
            }
            catch (FormatException* ex)
            {
				(ex);
            }
        }

		void CmbLargeChange_selectedIndexChanged(Object* source, EventArgs* e)
        {
            try
            {
                int newVal = Int32::Parse(cmbLargeChange->SelectedItem->ToString());
                trackbar->LargeChange = newVal;
            }
            catch (FormatException* ex)
            {
				(ex);
            }
        }

        void CmbSmallChange_selectedIndexChanged(Object* source, EventArgs* e)
        {
            try
            {
                int newVal = Int32::Parse(cmbSmallChange->SelectedItem->ToString());
                trackbar->SmallChange = newVal;
            }
            catch (FormatException* ex)
            {
				(ex);
            }
        }

		void CmbMinimum_selectedIndexChanged(Object* source, EventArgs* e)
		{
            try
            {
                int newVal = Int32::Parse(cmbMinimum->SelectedItem->ToString());
                if (newVal < trackbar->Maximum)
                    trackbar->Minimum = newVal;
                if (newVal > trackbar->Value)
				{
					trackbar->Value = newVal;
					lblValue->Text = newVal.ToString();
				}
            }
            catch (FormatException* ex)
            {
				(ex);
            }
        }

        void CmbMaximum_selectedIndexChanged(Object* source, EventArgs* e)
        {
            try
            {
                int newVal = Int32::Parse(cmbMaximum->SelectedItem->ToString());
                if (newVal > trackbar->Minimum)
                    trackbar->Maximum = newVal;
                if (newVal < trackbar->Value)
				{
					trackbar->Value = newVal;
					lblValue->Text = newVal.ToString();
				}

            }
            catch (FormatException* ex)
            {
				(ex);
            }
        }

        void Trackbar_valueChanged(Object* source, EventArgs* e)
        {
            lblValue->Text = trackbar->Value.ToString();
        }

        void CmbTickStyle_selectedIndexChanged(Object* source, EventArgs* e)
        {
            ComboBox* cmb = dynamic_cast<ComboBox*>(source);
            String* newSel = cmb->SelectedItem->ToString();
            
            if (newSel->CompareTo(S"Both") == 0)
            {
                trackbar->TickStyle = TickStyle::Both;
            }
            else if (newSel->CompareTo(S"Bottom-right") == 0)
            {
                trackbar->TickStyle = TickStyle::BottomRight;
            }
            else if (newSel->CompareTo(S"Top-left") == 0)
            {
                trackbar->TickStyle = TickStyle::TopLeft;
            }
            else
            {
                trackbar->TickStyle = TickStyle::None;
            }

            if (trackbar->TickStyle == TickStyle::None)
                cmbTickFreq->Enabled = false;
            else
                cmbTickFreq->Enabled = true;
        }

        void CmbOrientation_selectedIndexChanged(Object* source, EventArgs* e)
        {
            ComboBox* cmb = dynamic_cast<ComboBox*>(source);
            String* newSel = cmb->SelectedItem->ToString();
            if(0 == newSel->CompareTo(S"Horizontal"))
            {
                trackbar->Orientation = Orientation::Horizontal;
            }
            else
            {
                trackbar->Orientation = Orientation::Vertical;
            }
        }

        // <doc>
        // <desc>
        //     All KeyPresses that are not digits are ignored.
        //     Other non-letter keys (such as ENTER) are accepted.
        //     The edit boxes which require numerical input wire up to
        //     this handler.
        // </desc>
        // </doc>
        //
        void combo_KeyPress(Object* source, KeyPressEventArgs* e)
        {
            if (Char::IsLetterOrDigit(e->KeyChar)
                && !Char::IsDigit(e->KeyChar))
            {
                e->Handled = true;
            }
        }

		void GrpAppearance_enter(Object* source, EventArgs* e)
		{
		}

        // <doc>
        // <desc>
        //     NOTE: The following code is required by the WFC form
        //     designer.  It can be modified using the form editor.  Do not
        //     modify it using the code editor.
        // </desc>
        // </doc>
        //
        System::ComponentModel::Container* components;
        TrackBar* trackbar;
        GroupBox* grpAppearance;
        Label* label3;
        Label* label1;
        Label* label8;
        Label* label7;
        Label* label4;
        Label* label5;
        ComboBox* cmbOrientation;
        ComboBox* cmbTickStyle;
        ComboBox* cmbTickFreq;
        Label* label6;
        ComboBox* cmbMaximum;
        Label* lblValue;
        ComboBox* cmbMinimum;
        ComboBox* cmbSmallChange;
        Label* label2;
        ComboBox* cmbLargeChange;
        ToolTip* toolTip1;

        void InitForm()
        {
            components = new System::ComponentModel::Container();
            trackbar = new TrackBar();
            grpAppearance = new GroupBox();
            label3 = new Label();
            label1 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbOrientation = new ComboBox();
            cmbTickStyle = new ComboBox();
            cmbTickFreq = new ComboBox();
            label6 = new Label();
            cmbMaximum = new ComboBox();
            lblValue = new Label();
            cmbMinimum = new ComboBox();
            cmbSmallChange = new ComboBox();
            label2 = new Label();
            cmbLargeChange = new ComboBox();
            toolTip1 = new ToolTip(components);

            BackColor = SystemColors::Control;
            Size = System::Drawing::Size(512, 320);
            Text = S"TrackBar";

            trackbar->Location = Point(8, 24);
            trackbar->Size = System::Drawing::Size(200, 42);
            trackbar->TabIndex = 1;
            trackbar->Text = S"trackBar1";
            trackbar->add_ValueChanged( new EventHandler(this, Trackbar_valueChanged) );

            grpAppearance->Location = Point(248, 16);
            grpAppearance->Size = System::Drawing::Size(248, 264);
            grpAppearance->TabIndex = 0;
            grpAppearance->TabStop = false;
            grpAppearance->Text = S"TrackBar";
            grpAppearance->add_Enter( new EventHandler(this, GrpAppearance_enter) );

            label3->Location = Point(16, 96);
            label3->Size = System::Drawing::Size(88, 16);
            label3->TabIndex = 0;
            label3->TabStop = false;
            label3->Text = S"Large change:";

            label1->Location = Point(16, 24);
            label1->Size = System::Drawing::Size(88, 17);
            label1->TabIndex = 10;
            label1->TabStop = false;
            label1->Text = S"Orientation:";

            label8->Location = Point(16, 192);
            label8->Size = System::Drawing::Size(88, 16);
            label8->TabIndex = 8;
            label8->TabStop = false;
            label8->Text = S"Value:";

            label7->Location = Point(16, 168);
            label7->Size = System::Drawing::Size(88, 16);
            label7->TabIndex = 6;
            label7->TabStop = false;
            label7->Text = "Maximum:";

            label4->Location = Point(16, 48);
            label4->Size = System::Drawing::Size(88, 17);
            label4->TabIndex = 12;
            label4->TabStop = false;
            label4->Text = S"Tick frequency:";

            label5->Location = Point(16, 72);
            label5->Size = System::Drawing::Size(88, 17);
            label5->TabIndex = 14;
            label5->TabStop = false;
            label5->Text = S"Tick style:";

            cmbOrientation->Location = Point(112, 16);
            cmbOrientation->Size = System::Drawing::Size(120, 21);
            cmbOrientation->TabIndex = 11;
            cmbOrientation->Text = S"";
			cmbOrientation->DropDownStyle = ComboBoxStyle::DropDownList;
			String* arrStrgs[] = new String*[2];
			arrStrgs[0] = S"Horizontal";
			arrStrgs[1] = S"Vertical";
            cmbOrientation->Items->AddRange(arrStrgs);
            cmbOrientation->add_SelectedIndexChanged( new EventHandler(this, CmbOrientation_selectedIndexChanged) );

            cmbTickStyle->Location = Point(112, 64);
            cmbTickStyle->Size = System::Drawing::Size(120, 21);
            cmbTickStyle->TabIndex = 15;
            cmbTickStyle->Text = "";
            cmbTickStyle->DropDownStyle = ComboBoxStyle::DropDownList;

			arrStrgs = new String*[4];
			arrStrgs[0] = S"None";
			arrStrgs[1] = S"Bottom-right";
			arrStrgs[2] = S"Top-left";
			arrStrgs[3] = S"Both";
            cmbTickStyle->Items->AddRange(arrStrgs);

            cmbTickStyle->add_SelectedIndexChanged( new EventHandler(this, CmbTickStyle_selectedIndexChanged) );

            cmbTickFreq->Location = Point(112, 40);
            cmbTickFreq->Size = System::Drawing::Size(120, 21);
            cmbTickFreq->TabIndex = 13;
            cmbTickFreq->Text = "";
            cmbTickFreq->DropDownStyle = ComboBoxStyle::DropDownList;

			arrStrgs = new String*[7];
			arrStrgs[0] = S"1";
			arrStrgs[1] = S"2";
			arrStrgs[2] = S"5";
			arrStrgs[3] = S"10";
			arrStrgs[4] = S"20";
			arrStrgs[5] = S"25";
			arrStrgs[6] = S"50";
            cmbTickFreq->Items->AddRange(arrStrgs);

            cmbTickFreq->add_SelectedIndexChanged( new EventHandler(this, CmbTickFreq_selectedIndexChanged) );
            cmbTickFreq->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );

            label6->Location = Point(16, 144);
            label6->Size = System::Drawing::Size(88, 16);
            label6->TabIndex = 4;
            label6->TabStop = false;
            label6->Text = S"Minimum:";

            cmbMaximum->Location = Point(112, 160);
            cmbMaximum->Size = System::Drawing::Size(121, 21);
            cmbMaximum->TabIndex = 7;
            cmbMaximum->Text = S"";
            cmbMaximum->DropDownStyle = ComboBoxStyle::DropDownList;

			arrStrgs = new String*[3];
			arrStrgs[0] = S"100";
			arrStrgs[1] = S"150";
			arrStrgs[2] = S"200";
            cmbMaximum->Items->AddRange(arrStrgs);

            cmbMaximum->add_SelectedIndexChanged( new EventHandler(this, CmbMaximum_selectedIndexChanged) );
            cmbMaximum->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );

            lblValue->Location = Point(112, 192);
            lblValue->Size = System::Drawing::Size(120, 16);
            lblValue->TabIndex = 9;
            lblValue->TabStop = false;
            lblValue->Text = S"";
            lblValue->BorderStyle = BorderStyle::Fixed3D;

            cmbMinimum->Location = Point(112, 136);
            cmbMinimum->Size = System::Drawing::Size(121, 21);
            cmbMinimum->TabIndex = 5;
            cmbMinimum->Text = "";
            cmbMinimum->DropDownStyle = ComboBoxStyle::DropDownList;

			arrStrgs[0] = S"0";
			arrStrgs[1] = S"25";
			arrStrgs[2] = S"50";
            cmbMinimum->Items->AddRange(arrStrgs);

            cmbMinimum->add_SelectedIndexChanged( new EventHandler(this, CmbMinimum_selectedIndexChanged) );
            cmbMinimum->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );

            cmbSmallChange->Location = Point(112, 112);
            cmbSmallChange->Size = System::Drawing::Size(121, 21);
            cmbSmallChange->TabIndex = 3;
            cmbSmallChange->Text = "";
            cmbSmallChange->DropDownStyle = ComboBoxStyle::DropDownList;

			arrStrgs = new String*[4];
			arrStrgs[0] = S"1";
			arrStrgs[1] = S"2";
			arrStrgs[2] = S"5";
			arrStrgs[3] = S"10";
            cmbSmallChange->Items->AddRange(arrStrgs);

            cmbSmallChange->add_SelectedIndexChanged( new EventHandler(this, CmbSmallChange_selectedIndexChanged) );
            cmbSmallChange->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );

            label2->Location = Point(16, 120);
            label2->Size = System::Drawing::Size(88, 16);
            label2->TabIndex = 2;
            label2->TabStop = false;
            label2->Text = S"Small change:";

            cmbLargeChange->Location = Point(112, 88);
            cmbLargeChange->Size = System::Drawing::Size(121, 21);
            cmbLargeChange->TabIndex = 1;
            cmbLargeChange->Text = "";
            cmbLargeChange->DropDownStyle = ComboBoxStyle::DropDownList;
			arrStrgs = new String*[3];
			arrStrgs[0] = S"10";
			arrStrgs[1] = S"20";
			arrStrgs[2] = S"50";
            cmbLargeChange->Items->AddRange(arrStrgs);
            cmbLargeChange->add_SelectedIndexChanged( new EventHandler(this, CmbLargeChange_selectedIndexChanged) );
            cmbLargeChange->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );

            toolTip1->Active = true;
            toolTip1->SetToolTip(cmbTickStyle, "The location of the tick marks.");
            toolTip1->SetToolTip(cmbTickFreq, "The number of units betwen tick marks.");
            /* @designTimeOnly toolTip1->setLocation(Point(48, 152)); */

            Controls->Add(grpAppearance);
            Controls->Add(trackbar);
            grpAppearance->Controls->Add(lblValue);
            grpAppearance->Controls->Add(label8); 
            grpAppearance->Controls->Add(cmbMaximum);
            grpAppearance->Controls->Add(label7);
            grpAppearance->Controls->Add(cmbMinimum);
            grpAppearance->Controls->Add(label6);
            grpAppearance->Controls->Add(cmbSmallChange);
            grpAppearance->Controls->Add(label2);
            grpAppearance->Controls->Add(cmbLargeChange);
            grpAppearance->Controls->Add(label3);
            grpAppearance->Controls->Add(cmbTickFreq);
            grpAppearance->Controls->Add(cmbTickStyle);
            grpAppearance->Controls->Add(cmbOrientation);
            grpAppearance->Controls->Add(label5);
            grpAppearance->Controls->Add(label1);
            grpAppearance->Controls->Add(label4);
        }
    };
};

// The main entry point for the application.
void main()
{
	Application::Run(new TrackBarCtl::TrackBarCtl());
}



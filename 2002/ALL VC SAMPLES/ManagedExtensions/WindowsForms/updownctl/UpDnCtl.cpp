/*=====================================================================
  Sample:     UpDnCtl

  Summary:   This sample demonstrates the basic functionality of the
             NumericUpDown and DomainUpDown controls.

---------------------------------------------------------------------
  This file is part of the Microsoft VC++ Code Samples.

  Copyright (C) 2001 Microsoft Corporation. All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation. See these other
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

namespace UpDnCtl {

	__gc class StringIntObject
	{
	public:
		String* s;
		int i;

		StringIntObject(String* sz, int n)
		{
			s=sz;
			i=n;
		}

		String* ToString()
		{
			return s;
		}
	};

    __gc class UpDnCtl : public Form
	{
	public:
		UpDnCtl() : Form() {
            
            // This call is required for support of the WFC Form Designer
            InitForm();		

            //Complete intialization of the Form
			updnTextAlign->Items->Add(new StringIntObject(S"Center",(int)HorizontalAlignment::Center));
			updnTextAlign->Items->Add(new StringIntObject(S"Left",(int)HorizontalAlignment::Left));
			updnTextAlign->Items->Add(new StringIntObject(S"Right",(int)HorizontalAlignment::Right));
            updnTextAlign->SelectedIndex = 1;
            
			updnUpDownAlignment->Items->Add(new StringIntObject(S"Left",(int)LeftRightAlignment::Left));
			updnUpDownAlignment->Items->Add(new StringIntObject(S"Right",(int)LeftRightAlignment::Right));
            updnUpDownAlignment->SelectedIndex = 1;
            
            domainUpDown1->Items->Add(S"King Kong");
            domainUpDown1->Items->Add(S"The Creature from the Black Lagoon");
            domainUpDown1->Items->Add(S"Dracula");
            domainUpDown1->Items->Add(S"Frankenstein's Monster");
            domainUpDown1->Items->Add(S"Godzilla");
            domainUpDown1->SelectedIndex = 0;

            updnDecimalPlaces->DecimalPlaces = 0;
        }

	private:
		void updnUpDownAlignment_SelectedItemChanged(Object* sender, EventArgs* e) {
            StringIntObject* sio = dynamic_cast<StringIntObject*>(updnUpDownAlignment->Items->Item[updnUpDownAlignment->SelectedIndex]);
            numericUpDown1->UpDownAlign = (sio->i)?LeftRightAlignment::Right : LeftRightAlignment::Left;
            domainUpDown1->UpDownAlign = numericUpDown1->UpDownAlign;
        }

        void updnTextAlign_SelectedItemChanged(Object* sender, EventArgs* e) {
            StringIntObject* sio = dynamic_cast<StringIntObject*>(updnTextAlign->Items->Item[updnTextAlign->SelectedIndex]);
            numericUpDown1->TextAlign = (sio->i)?((sio->i==1)? HorizontalAlignment::Right : HorizontalAlignment::Center) : HorizontalAlignment::Left;
            domainUpDown1->TextAlign = numericUpDown1->TextAlign;
        }

        void chkInterceptArrowKeys_CheckedChanged(Object* sender, EventArgs* e) {
            numericUpDown1->InterceptArrowKeys = chkInterceptArrowKeys->Checked;
            domainUpDown1->InterceptArrowKeys = chkInterceptArrowKeys->Checked;
        }

        void chkSorted_CheckedChanged(Object* sender, EventArgs* e) {
            domainUpDown1->Sorted = chkSorted->Checked;
        }

        void chkWrap_CheckedChanged(Object* sender, EventArgs* e) {
            domainUpDown1->Wrap = chkWrap->Checked;
        }

        void updnIncrement_ValueChanged(Object* sender, EventArgs* e) {
           numericUpDown1->Increment = updnIncrement->Value;
        }

        void updnDecimalPlaces_ValueChanged(Object* sender, EventArgs* e) {
            numericUpDown1->DecimalPlaces = (int)updnDecimalPlaces->Value;
            updnIncrement->Value = (int)updnIncrement->Value ; // Just so we don't increment by amounts we can't see.
            updnIncrement->DecimalPlaces = (int)updnDecimalPlaces->Value;
        }


        // NOTE: The following code is required by the WFC Form Designer.
        // It can be modified using the WFC Form Designer. 
        // Do not modify it using the code editor.
    	System::ComponentModel::Container* components;
        DomainUpDown* updnUpDownAlignment; 
        DomainUpDown* updnTextAlign;
        Label* lblIncrement;
        NumericUpDown* updnIncrement;
        Label* lblDecimalPlaces;
        NumericUpDown* updnDecimalPlaces;
        CheckBox* chkSorted;
        Label* lblUpDownAlignment;
        Label* lblTextAlign;

        CheckBox* chkInterceptArrowKeys;
        CheckBox* chkWrap;
        GroupBox* grpCommonProperties;
        NumericUpDown* numericUpDown1;
        DomainUpDown* domainUpDown1;
        GroupBox* grpDomainUpDown;
        GroupBox* grpNumericUpDown;

    	void InitForm() {
            components = new System::ComponentModel::Container();
            grpDomainUpDown = new GroupBox();
            updnDecimalPlaces = new NumericUpDown();
            chkWrap = new CheckBox();
            grpNumericUpDown = new GroupBox();
            chkSorted = new CheckBox();
            lblUpDownAlignment = new Label();
            lblIncrement = new Label();
            chkInterceptArrowKeys = new CheckBox();
            grpCommonProperties = new GroupBox();
            lblTextAlign = new Label();
            domainUpDown1 = new DomainUpDown();
            updnTextAlign = new DomainUpDown();
            updnIncrement = new NumericUpDown();
            lblDecimalPlaces = new Label();
            updnUpDownAlignment = new DomainUpDown();
            numericUpDown1 = new NumericUpDown();

            grpDomainUpDown->Location = Point(280, 24);
            grpDomainUpDown->TabIndex = 1;
            grpDomainUpDown->TabStop = false;
            grpDomainUpDown->Text = S"Domain Up-Down";
            grpDomainUpDown->Size = System::Drawing::Size(208, 176);

            updnDecimalPlaces->Location = Point(152, 80);
            updnDecimalPlaces->Maximum = Decimal(10);
            updnDecimalPlaces->Minimum = Decimal(0);
            updnDecimalPlaces->DecimalPlaces = 0;
            updnDecimalPlaces->TabIndex = 1;
            updnDecimalPlaces->Text = S"2";
            updnDecimalPlaces->Size = System::Drawing::Size(56, 23);
            updnDecimalPlaces->add_ValueChanged( new EventHandler(this, updnDecimalPlaces_ValueChanged) );

			chkWrap->TextAlign = ContentAlignment::MiddleLeft;
            chkWrap->Location = Point(32, 80);
            chkWrap->TabIndex = 1;
            chkWrap->Text = S"Wrap";
            chkWrap->Size = System::Drawing::Size(104, 24);
            chkWrap->add_CheckedChanged( new EventHandler(this, chkWrap_CheckedChanged) );

            grpNumericUpDown->Location = Point(16, 24);
            grpNumericUpDown->TabIndex = 0;
            grpNumericUpDown->TabStop = false;
            grpNumericUpDown->Text = S"Numeric Up-Down";
            grpNumericUpDown->Size = System::Drawing::Size(232, 176);

			chkSorted->TextAlign = ContentAlignment::MiddleLeft;
            chkSorted->Location = Point(32, 120);
            chkSorted->TabIndex = 2;
            chkSorted->Text = S"Sorted";
            chkSorted->Size = System::Drawing::Size(104, 24);
            chkSorted->add_CheckedChanged( new EventHandler(this, chkSorted_CheckedChanged) );

            lblUpDownAlignment->Location = Point(16, 64);
            lblUpDownAlignment->TabIndex = 2;
            lblUpDownAlignment->TabStop = false;
			lblUpDownAlignment->Text = S"Up-Down alignment:";
            lblUpDownAlignment->Size = System::Drawing::Size(120, 24);

            lblIncrement->Location = Point(32, 120);
            lblIncrement->TabIndex = 4;
            lblIncrement->TabStop = false;
			lblIncrement->Text = S"Increment:";
            lblIncrement->Size = System::Drawing::Size(72, 24);

			chkInterceptArrowKeys->TextAlign = ContentAlignment::MiddleLeft;
            chkInterceptArrowKeys->Location = Point(304, 32);
            chkInterceptArrowKeys->TabIndex = 0;
			chkInterceptArrowKeys->CheckState = CheckState::Checked;
            chkInterceptArrowKeys->Text = S"Intercept arrow keys";
            chkInterceptArrowKeys->Size = System::Drawing::Size(144, 24);
            chkInterceptArrowKeys->Checked = true;
            chkInterceptArrowKeys->add_CheckedChanged( new EventHandler(this, chkInterceptArrowKeys_CheckedChanged) );

            grpCommonProperties->Location = Point(16, 224);
            grpCommonProperties->TabIndex = 2;
            grpCommonProperties->TabStop = false;
			grpCommonProperties->Text = S"Common properties:";
            grpCommonProperties->Size = System::Drawing::Size(472, 112);

            lblTextAlign->Location = Point(16, 32);
            lblTextAlign->TabIndex = 1;
            lblTextAlign->TabStop = false;
			lblTextAlign->Text = S"Text alignment:";
            lblTextAlign->Size = System::Drawing::Size(120, 24);

            domainUpDown1->Location = Point(32, 32);
            domainUpDown1->TabIndex = 0;
            domainUpDown1->Size = System::Drawing::Size(96, 23);

            updnTextAlign->Location = Point(152, 32);
            updnTextAlign->TabIndex = 3;
            updnTextAlign->Size = System::Drawing::Size(120, 23);
            updnTextAlign->add_SelectedItemChanged( new EventHandler(this,updnTextAlign_SelectedItemChanged) );

            updnIncrement->Location = Point(152, 120);
            updnIncrement->Maximum = Decimal(100);
            updnIncrement->Minimum = Decimal(1);
            updnIncrement->TabIndex = 2;
            updnIncrement->DecimalPlaces = 0;
            updnIncrement->Text = S"1";
            updnIncrement->Size = System::Drawing::Size(56, 23);
            updnIncrement->add_ValueChanged( new EventHandler(this,updnIncrement_ValueChanged) );

            this->AutoScaleBaseSize = System::Drawing::Size(6, 16);
            this->ClientSize = System::Drawing::Size(504, 352);
            this->Text = S"Up-Down form";

            lblDecimalPlaces->Location = Point(32, 80);
            lblDecimalPlaces->TabIndex = 3;
            lblDecimalPlaces->TabStop = false;
			lblDecimalPlaces->Text = S"Decimal places:";
            lblDecimalPlaces->Size = System::Drawing::Size(96, 24);

            updnUpDownAlignment->Location = Point(152, 64);
            updnUpDownAlignment->TabIndex = 4;
            updnUpDownAlignment->Size = System::Drawing::Size(120, 23);
            updnUpDownAlignment->add_SelectedItemChanged( new EventHandler(this, updnUpDownAlignment_SelectedItemChanged) );

            numericUpDown1->Location = Point(32, 32);
            numericUpDown1->Maximum = Decimal(100);
            numericUpDown1->Minimum = Decimal(0);
            numericUpDown1->TabIndex = 0;
            numericUpDown1->DecimalPlaces = 2;
            numericUpDown1->Text = S"0->00";
            numericUpDown1->Size = System::Drawing::Size(104, 23);

            this->Controls->Add(grpCommonProperties);
            this->Controls->Add(grpDomainUpDown);
            this->Controls->Add(grpNumericUpDown);
            grpCommonProperties->Controls->Add(updnUpDownAlignment);
            grpCommonProperties->Controls->Add(updnTextAlign);
            grpCommonProperties->Controls->Add(lblUpDownAlignment);
            grpCommonProperties->Controls->Add(lblTextAlign);
            grpCommonProperties->Controls->Add(chkInterceptArrowKeys);
            grpNumericUpDown->Controls->Add(lblIncrement);
            grpNumericUpDown->Controls->Add(updnIncrement);
            grpNumericUpDown->Controls->Add(lblDecimalPlaces);
            grpNumericUpDown->Controls->Add(updnDecimalPlaces);
            grpNumericUpDown->Controls->Add(numericUpDown1);
            grpDomainUpDown->Controls->Add(chkSorted);
            grpDomainUpDown->Controls->Add(chkWrap);
            grpDomainUpDown->Controls->Add(domainUpDown1);
        }
    };
};

// Application's entry point.
void main() { 
	Application::Run(new UpDnCtl::UpDnCtl());
}
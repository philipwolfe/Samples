/*=====================================================================
  File:      ButtonCtl.cpp

  Summary:   This sample demonstrates the properties and features
             of the Button control.

---------------------------------------------------------------------
  This file is part of the Microsoft VC++ Code Samples.

  Copyright (C) 1999 Microsoft Corporation.  All rights reserved.

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
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Windows::Forms;

__gc class StringIntObject
{
public:
	String* s;
    int i;

    StringIntObject(String* sz, int n) {
        s=sz;
        i=n;
    }

    virtual String* ToString() {
        return s;
    }
};
	
__gc class ButtonCtl : public Form
{
public:
	ButtonCtl() : Form()
	{
		InitForm();
	}
    
private:
	void button1_Click(Object* sender, EventArgs* e) {
		MessageBox::Show(S"You pressed the test button");
        }

	void cmbImageAlign_SelectedIndexChanged(Object* sender, EventArgs* e) {
		int i = dynamic_cast<StringIntObject*>(cmbImageAlign->SelectedItem)->i;
		m_button->ImageAlign = (ContentAlignment)i;
	}

    void cmbTextAlign_SelectedIndexChanged(Object* sender, EventArgs* e) {
		int i = dynamic_cast<StringIntObject*>(cmbTextAlign->SelectedItem)->i;
		m_button->TextAlign = (ContentAlignment)i;
	}

    void cmbFlatStyle_SelectedIndexChanged(Object* sender, EventArgs* e) {
		FlatStyle i = (FlatStyle)(dynamic_cast<StringIntObject*>(cmbFlatStyle->SelectedItem)->i);
		m_button->FlatStyle = i;
	}

    void chkImage_Click(Object* sender, EventArgs* e) {
		if (chkImage->Checked) {
			m_button->Image = m_btnImg;
			cmbImageAlign->Enabled=true;
		} else {
			m_button->Image = null;
			cmbImageAlign->Enabled=false;
		}
	}

	void chkBGImage_Click(Object* sender, EventArgs* e) {
		if (chkBGImage->Checked) {
			m_button->BackgroundImage = m_bkImg;
		} else {
			m_button->BackgroundImage = null ;
		}
	}

	System::ComponentModel::Container* components;
	CheckBox* chkImage;
	ComboBox* cmbImageAlign;
	Label* label3;
	
	ComboBox* cmbTextAlign;
	
	Label* label2;
	ComboBox* cmbFlatStyle;
	Label* label1;
	CheckBox* chkBGImage;
	Button* m_button;
	Panel* panel1;
    GroupBox* grpBehavior; 
	Bitmap* m_bkImg, *m_btnImg;
    
    void InitForm()
    {
		m_btnImg = new Bitmap(S"exe.bmp");
		m_bkImg = new Bitmap(S"Hiking Boot.bmp");
		components = new System::ComponentModel::Container();
		chkImage = new CheckBox();
		grpBehavior = new GroupBox();
		cmbImageAlign = new ComboBox();
		label3 = new Label();
		label2 = new Label();
		label1 = new Label();
		chkBGImage = new CheckBox();
		panel1 = new Panel();
		m_button = new Button();
		panel1->BackgroundImage = m_bkImg;

		cmbTextAlign = new ComboBox();
		cmbFlatStyle = new ComboBox();

		StringIntObject* tempStyleArray[] = new StringIntObject*[3];
		tempStyleArray[0] = new StringIntObject(S"Flat",(int)FlatStyle::Flat);
		tempStyleArray[1] = new StringIntObject(S"Popup",(int)FlatStyle::Popup);
		tempStyleArray[2] = new StringIntObject(S"Standard",(int)FlatStyle::Standard);
		// Set up combo-boxes
		cmbFlatStyle->Items->AddRange(tempStyleArray);
		cmbFlatStyle->SelectedIndex = 1;


		StringIntObject* tempAlignArray[] = new StringIntObject*[9];
		tempAlignArray[0] = new StringIntObject(S"TopLeft",(int)ContentAlignment::TopLeft);
		tempAlignArray[1] = new StringIntObject(S"TopCenter",(int)ContentAlignment::TopCenter);
		tempAlignArray[2] = new StringIntObject(S"TopRight",(int)ContentAlignment::TopRight);
		tempAlignArray[3] = new StringIntObject(S"MiddleLeft",(int)ContentAlignment::MiddleLeft);
		tempAlignArray[4] = new StringIntObject(S"MiddleCenter",(int)ContentAlignment::MiddleCenter);
		tempAlignArray[5] = new StringIntObject(S"MiddleRight",(int)ContentAlignment::MiddleRight);
		tempAlignArray[6] = new StringIntObject(S"BottomLeft",(int)ContentAlignment::BottomLeft);
		tempAlignArray[7] = new StringIntObject(S"BottomCenter",(int)ContentAlignment::BottomCenter);
		tempAlignArray[8] = new StringIntObject(S"BottomRight",(int)ContentAlignment::BottomRight);


		cmbTextAlign->Items->AddRange(tempAlignArray);
		cmbTextAlign->SelectedIndex = 1 ;

		Object* temp[] = new Object*[cmbTextAlign->Items->Count];
		cmbTextAlign->Items->CopyTo(temp, 0);
		cmbImageAlign->Items->AddRange(temp);
		cmbImageAlign->SelectedIndex = 0 ;

		chkImage->TextAlign = ContentAlignment::MiddleLeft;
		chkImage->Location = Point(16, 64);
		chkImage->TabIndex = 7;
		chkImage->Text = S"Display image";
		chkImage->Size = System::Drawing::Size(160, 24);
		chkImage->add_Click( new EventHandler(this, chkImage_Click) );

		grpBehavior->Location = Point(248, 16);
		grpBehavior->TabIndex = 0;
		grpBehavior->TabStop = false;
		grpBehavior->Text = S"Button Properties";
		grpBehavior->Size = System::Drawing::Size(248, 352);

		cmbImageAlign->ForeColor = SystemColors::WindowText;
		cmbImageAlign->Location = Point(88, 216);
		cmbImageAlign->TabIndex = 6;
		cmbImageAlign->Text = S"comboBox1";
		cmbImageAlign->Size = System::Drawing::Size(144, 21);
		cmbImageAlign->add_SelectedIndexChanged( new EventHandler(this, cmbImageAlign_SelectedIndexChanged) );
		cmbImageAlign->Enabled=false;
		cmbImageAlign->DropDownStyle = ComboBoxStyle::DropDownList;

		label3->Location = Point(16, 216);
		label3->TabIndex = 5;
		label3->TabStop = false;
		label3->Text = S"Image align:";
		label3->Size = System::Drawing::Size(74, 24);

		label2->Location = Point(16, 168);
		label2->TabIndex = 3;
		label2->TabStop = false;
		label2->Text = S"Text align:";
		label2->Size = System::Drawing::Size(64, 32);

		label1->Location = Point(16, 120);
		label1->TabIndex = 1;
		label1->TabStop = false;
		label1->Text = S"Flat style:";
		label1->Size = System::Drawing::Size(64, 16);

		AutoScaleBaseSize = System::Drawing::Size(5, 13);
		ClientSize = System::Drawing::Size(504, 381);
		Text = S"Button";

		cmbTextAlign->ForeColor = SystemColors::WindowText;
		cmbTextAlign->Location = Point(88, 168);
		cmbTextAlign->TabIndex = 4;
		cmbTextAlign->Text = S"comboBox1";
		cmbTextAlign->Size = System::Drawing::Size(144, 21);
		cmbTextAlign->DropDownStyle = ComboBoxStyle::DropDownList;
		cmbTextAlign->add_SelectedIndexChanged( new EventHandler(this, cmbTextAlign_SelectedIndexChanged) );

		cmbFlatStyle->ForeColor = SystemColors::WindowText;
		cmbFlatStyle->Location = Point(88, 120);
		cmbFlatStyle->TabIndex = 2;
		cmbFlatStyle->Text = S"cmbFlatStyle";
		cmbFlatStyle->Size = System::Drawing::Size(144, 21);
		cmbFlatStyle->add_SelectedIndexChanged( new EventHandler(this, cmbFlatStyle_SelectedIndexChanged) );
		cmbFlatStyle->DropDownStyle = ComboBoxStyle::DropDownList;

		chkBGImage->TextAlign = ContentAlignment::MiddleLeft;
		chkBGImage->Location = Point(16, 33);
		chkBGImage->TabIndex = 0;
		chkBGImage->Text = S"Display background image";
		chkBGImage->Size = System::Drawing::Size(182, 24);
		chkBGImage->add_Click( new EventHandler(this, chkBGImage_Click) );

		panel1->Location = Point(24, 40);
		panel1->BackColor = Color::DarkGoldenrod;
		panel1->TabIndex = 1;
		panel1->Text = S"panel1";
		panel1->Size = System::Drawing::Size(200, 320);

		m_button->ImageAlign = ContentAlignment::MiddleLeft;
		m_button->Location = Point(32, 112);
		m_button->FlatStyle = FlatStyle::Flat;
		m_button->TabIndex = 0;
		m_button->Text = S"TestButton";
		m_button->Size = System::Drawing::Size(136, 56);
		m_button->add_Click( new EventHandler(this, button1_Click) );

		Controls->Add(panel1);
		Controls->Add(grpBehavior);
		panel1->Controls->Add(m_button);
		grpBehavior->Controls->Add(chkImage);
		grpBehavior->Controls->Add(cmbImageAlign);
		grpBehavior->Controls->Add(cmbTextAlign);
		grpBehavior->Controls->Add(label2);
		grpBehavior->Controls->Add(cmbFlatStyle);
		grpBehavior->Controls->Add(label1);
		grpBehavior->Controls->Add(chkBGImage);
		grpBehavior->Controls->Add(label3);
	}
};

// The main entry point for the application.
void main() {
	Application::Run(new ButtonCtl());
}


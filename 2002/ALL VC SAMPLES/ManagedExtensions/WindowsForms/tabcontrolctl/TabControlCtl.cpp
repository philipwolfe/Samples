/*=====================================================================
  File:     TabControlCtl.cpp

  Summary:  The TabControlCtl sample shows some basic user
            interface techniques focused on tab controls.
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

namespace TabControlCtl {

    __gc class TabControlCtl : public Form
	{
        
	public:
		TabControlCtl() {

            // This call is required for support of the WFC Form Designer.
            initForm();

            appearanceComboBox->SelectedIndex = 0 ;
            alignmentComboBox->SelectedIndex = 0 ;
            sizeModeComboBox->SelectedIndex = 0 ;
            tabControl1->ImageList = null;
        }

	private:
		void appearanceComboBox_SelectedIndexChanged(Object* sender, EventArgs* e) {
            int index = appearanceComboBox->SelectedIndex;
            if (index == 0) {
				tabControl1->Appearance = TabAppearance::Normal;
            }
            else if (index == 1) {
				tabControl1->Appearance = TabAppearance::Buttons;
            }
            else {
				tabControl1->Appearance = TabAppearance::FlatButtons;
            }
            tabControl1->PerformLayout();


        }

        void checkBox1_Click(Object* sender, EventArgs* e) {
            tabControl1->Multiline = checkBox1->Checked;
        }

        void alignmentComboBox_SelectedIndexChanged(Object* sender, EventArgs* e) {
            int index = alignmentComboBox->SelectedIndex;
            if (index == 0) {
				tabControl1->Alignment = TabAlignment::Top;
            }
            else if (index == 1) {
				tabControl1->Alignment = TabAlignment::Bottom;
            }
            else if (index == 2) {
				tabControl1->Alignment = TabAlignment::Left;
            }
            else
				tabControl1->Alignment = TabAlignment::Right;
        }

        void checkBox2_Click(Object* sender, EventArgs* e) {
            tabControl1->HotTrack = checkBox2->Checked;
        }

        void sizeModeComboBox_SelectedIndexChanged(Object* sender, EventArgs* e) {
            int index = sizeModeComboBox->SelectedIndex;
            if (index == 0) {
				tabControl1->SizeMode = TabSizeMode::Normal;
            }
            else if (index == 1) {
				tabControl1->SizeMode = TabSizeMode::FillToRight;
            }
            else
				tabControl1->SizeMode = TabSizeMode::Fixed;

        }

        void trackBar_Scroll(Object* sender, EventArgs* e) {
            tabControl1->Width = trackBar->Value;
        }

        void tabControl1_SelectedIndexChanged(Object* sender, EventArgs* e) {

        }

        void checkBox3_Click(Object* sender, EventArgs* e) {
            if (checkBox3->Checked)
                tabControl1->ImageList = imageList1;
            else
                tabControl1->ImageList = null;
        }

        // NOTE: The following code is required by the WFC Form Designer
        // It can be modified using the WFC Form Designer.  
        // Do not modify it using the code editor.
        System::ComponentModel::Container* components;
		DomainUpDown* tp5DomainUpDown1;
		GroupBox* tp5GroupBox1;
		ComboBox* tp4ComboBox1;
		NumericUpDown* tp4UpDown1;
		GroupBox* tp4GroupBox1;
		ComboBox* tp3ComboBox1;
		RadioButton* tp3RadioButton1;
		RadioButton* tp3RadioButton2;
		ComboBox* tp3ComboBox2;
		Label* tp3Label1;
		Button* tp3Button1;
		GroupBox* tp3GroupBox1;
		TabPage* tabPage5;
		TabPage* tabPage4;
		TabPage* tabPage3;
		ComboBox* tp2ComboBox1;
		RadioButton* tp2RadioButton1;
		RadioButton* tp2RadioButton2;
		GroupBox* tp2GroupBox1;
		TabPage* tabPage2;
		TabPage* tabPage1; 
		GroupBox* groupBox1; 
		ComboBox* appearanceComboBox;
		
		CheckBox* checkBox1; 
		CheckBox* checkBox2;
		CheckBox* checkBox3; 
		
		TabControl* tabControl1; 
		ComboBox* alignmentComboBox; 
		ComboBox* sizeModeComboBox; 
		Label* label1; 
		Label* label2; 
		Label* label3; 
		TrackBar* trackBar; 
		Label* label4; 
		PictureBox* pictureBox1; 
		ToolTip* toolTip1;
		ImageList* imageList1; 
		ComboBox* tp1ComboBox1;
		Label* tp1Label1;
		Label* tp1Label2;
		Button* tp1Button1;
		GroupBox* tp1GroupBox1;
		

        void initForm() {
			components = new System::ComponentModel::Container();
			
			tp3Button1 = new Button();
			tp1Button1 = new Button();
			
			
			tp5DomainUpDown1 = new DomainUpDown();
			alignmentComboBox = new ComboBox();
			tp2ComboBox1 = new ComboBox();
			sizeModeComboBox = new ComboBox();
			checkBox1 = new CheckBox();
			tp3RadioButton1 = new RadioButton();
			trackBar = new TrackBar();
			tp1GroupBox1 = new GroupBox();
			tp3RadioButton2 = new RadioButton();
			tp3Label1 = new Label();
			label1 = new Label();
			tp1ComboBox1 = new ComboBox();
			label2 = new Label();
			groupBox1 = new GroupBox();
			toolTip1 = new ToolTip(components);
			checkBox2 = new CheckBox();
			tp4ComboBox1 = new ComboBox();
			tp1Label2 = new Label();
			tp1Label1 = new Label();
			label4 = new Label();
			appearanceComboBox = new ComboBox();
			pictureBox1 = new PictureBox();
			tp2RadioButton2 = new RadioButton();
			tabPage4 = new TabPage();
			tp2RadioButton1 = new RadioButton();
			tp4GroupBox1 = new GroupBox();
			checkBox3 = new CheckBox();
			label3 = new Label();
			tp3ComboBox1 = new ComboBox();
			tp4UpDown1 = new NumericUpDown();
			tp3ComboBox2 = new ComboBox();
			tp5GroupBox1 = new GroupBox();
			tabControl1 = new TabControl();
			imageList1 = new ImageList();
			tp2GroupBox1 = new GroupBox();
			tabPage2 = new TabPage();
			tabPage5 = new TabPage();
			tabPage3 = new TabPage();
			tp3GroupBox1 = new GroupBox();
			tabPage1 = new TabPage();
			
			tp5DomainUpDown1->Location = Point(24, 32);
			tp5DomainUpDown1->TabIndex = 0;
			tp5DomainUpDown1->Enabled = true;
			tp5DomainUpDown1->Text = S"11:01:35 AM";
			tp5DomainUpDown1->Size = System::Drawing::Size(112, 20);
			
			alignmentComboBox->ForeColor = (Color)SystemColors::WindowText;
			alignmentComboBox->Location = Point(128, 48);
			alignmentComboBox->TabIndex = 4;
			alignmentComboBox->Text = S"";
			alignmentComboBox->Size = System::Drawing::Size(104, 21);
			alignmentComboBox->DropDownStyle = ComboBoxStyle::DropDownList;
			toolTip1->SetToolTip(alignmentComboBox, S"Determines whether the tabs appear on the top, bottom,left or, right side of the control.");
			alignmentComboBox->add_SelectedIndexChanged( new EventHandler(this, alignmentComboBox_SelectedIndexChanged) );
			
			String* temp[] = new String*[4];
			temp[0] = S"Top";
			temp[1] = S"Bottom";
			temp[2] = S"Left";
			temp[3] = S"Right";
			alignmentComboBox->Items->AddRange(temp);
			
			tp2ComboBox1->ForeColor = (Color)SystemColors::WindowText;
			tp2ComboBox1->Location = Point(32, 80);
			tp2ComboBox1->TabIndex = 2;
			tp2ComboBox1->Enabled = true;
			tp2ComboBox1->Text = S"Original Size";
			tp2ComboBox1->Size = System::Drawing::Size(160, 21);
			
			sizeModeComboBox->ForeColor = (Color)SystemColors::WindowText;
			sizeModeComboBox->Location = Point(128, 80);
			sizeModeComboBox->TabIndex = 6;
			sizeModeComboBox->Text = S"";
			sizeModeComboBox->Size = System::Drawing::Size(104, 21);
			sizeModeComboBox->DropDownStyle = ComboBoxStyle::DropDownList;
			toolTip1->SetToolTip(sizeModeComboBox, S"Indicates how tabs are sized.");
			sizeModeComboBox->add_SelectedIndexChanged( new EventHandler(this, sizeModeComboBox_SelectedIndexChanged) );
			
			temp = new String*[3];
			temp[0] = S"Normal";
			temp[1] = S"Fill to right";
			temp[2] = S"Fixed";
			
			sizeModeComboBox->Items->AddRange(temp);

			checkBox1->TextAlign = ContentAlignment::MiddleLeft;
			checkBox1->Location = Point(16, 112);
			checkBox1->TabIndex = 0;
			checkBox1->Text = S"Multi-line";
			checkBox1->Size = System::Drawing::Size(88, 16);
			toolTip1->SetToolTip(checkBox1, S"Indicates if more than one row of tabs is allowed.");
			checkBox1->add_Click( new EventHandler(this, checkBox1_Click) );

			tp3RadioButton1->Location = Point(8, 26);
			tp3RadioButton1->TabIndex = 4;
			tp3RadioButton1->Enabled = true;
			tp3RadioButton1->Text = S"&Single instrument";
			tp3RadioButton1->Size = System::Drawing::Size(120, 23);
			
			trackBar->Location = Point(16, 192);
			trackBar->TickFrequency = 10;
			trackBar->TabIndex = 2;
			trackBar->TabStop = false;
			trackBar->Maximum = 220;
			trackBar->Value = 220;
			trackBar->Text = S"trackBar1";
			trackBar->Size = System::Drawing::Size(216, 42);
			trackBar->add_Scroll( new EventHandler(this, trackBar_Scroll) );
			
			tp1GroupBox1->Location = Point(12, 16);
			tp1GroupBox1->TabIndex = 0;
			tp1GroupBox1->TabStop = false;
			tp1GroupBox1->Text = S"Playback";
			tp1GroupBox1->Size = System::Drawing::Size(202, 144);
			
			tp3RadioButton2->Location = Point(8, 80);
			tp3RadioButton2->TabIndex = 3;
			tp3RadioButton2->Enabled = true;
			tp3RadioButton2->Text = S"&Custom Configuration";
			tp3RadioButton2->Size = System::Drawing::Size(168, 23);
			
			tp3Label1->Location = Point(24, 104);
			tp3Label1->TabIndex = 1;
			tp3Label1->TabStop = false;
			tp3Label1->Text = S"Midi Scheme:";
			tp3Label1->Size = System::Drawing::Size(100, 16);
			
			label1->Location = Point(16, 16);
			label1->TabIndex = 7;
			label1->TabStop = false;
			label1->Text = S"Appearance";
			label1->Size = System::Drawing::Size(72, 16);
			
			tp1ComboBox1->ForeColor = (Color)SystemColors::WindowText;
			tp1ComboBox1->Location = Point(24, 48);
			tp1ComboBox1->TabIndex = 3;
			tp1ComboBox1->Enabled = true;
			tp1ComboBox1->Text = S"(Use any available device)";
			tp1ComboBox1->Size = System::Drawing::Size(160, 21);
			              
			this->TabIndex = 0;
			this->Text = S"TabControl";
			this->Size = System::Drawing::Size(554, 320);
			
			label2->Location = Point(16, 48);
			label2->TabIndex = 8;
			label2->TabStop = false;
			label2->Text = S"alignment";
			label2->Size = System::Drawing::Size(64, 16);
			
			groupBox1->Location = Point(280, 16);
			groupBox1->TabIndex = 1;
			groupBox1->TabStop = false;
			groupBox1->Text = S"TabControl";
			groupBox1->Size = System::Drawing::Size(248, 264);
			
			toolTip1->Active = true;
			//@design toolTip1->SetLocation(Point(20, 10));

			checkBox2->TextAlign = ContentAlignment::MiddleLeft;
			checkBox2->Location = Point(16, 136);
			checkBox2->TabIndex = 5;
			checkBox2->Text = S"Hot track";
			checkBox2->Size = System::Drawing::Size(100, 23);
			toolTip1->SetToolTip(checkBox2, S"Indicates whether the tabs visually change as the mouse passes");
			checkBox2->add_Click( new EventHandler(this, checkBox2_Click) );

			tp4ComboBox1->ForeColor = SystemColors::WindowText;
			tp4ComboBox1->Location = Point(16, 32);
			tp4ComboBox1->TabIndex = 1;
			tp4ComboBox1->Enabled = true;
			tp4ComboBox1->Text = S"June";
			tp4ComboBox1->Size = System::Drawing::Size(56, 21);
			
			tp1Label2->Location = Point(24, 88);
			tp1Label2->TabIndex = 1;
			tp1Label2->TabStop = false;
			tp1Label2->Text = S"To select advanced options, click:";
			tp1Label2->Size = System::Drawing::Size(176, 16);
			
			tp1Label1->Location = Point(24, 24);
			tp1Label1->TabIndex = 2;
			tp1Label1->TabStop = false;
			tp1Label1->Text = S"Preferred device:";
			tp1Label1->Size = System::Drawing::Size(100, 16);
			
			label4->Location = Point(16, 168);
			label4->TabIndex = 3;
			label4->TabStop = false;
			label4->Text = S"Tab Control Width:";
			label4->Size = System::Drawing::Size(120, 16);
			
			appearanceComboBox->ForeColor = SystemColors::WindowText;
			appearanceComboBox->Location = Point(128, 16);
			appearanceComboBox->TabIndex = 1;
			appearanceComboBox->Text = S"";
			appearanceComboBox->Size = System::Drawing::Size(104, 21);
			appearanceComboBox->DropDownStyle = ComboBoxStyle::DropDownList;
			toolTip1->SetToolTip(appearanceComboBox, S"Indicates whether the tabs are painted as buttons or regular tabs.");
			appearanceComboBox->add_SelectedIndexChanged( new EventHandler(this, appearanceComboBox_SelectedIndexChanged) );
			
			temp[0] = S"Normal";
			temp[1] = S"Buttons";
			temp[2] = S"Flat buttons";
			appearanceComboBox->Items->AddRange(temp);
			
			pictureBox1->BorderStyle = BorderStyle::Fixed3D;
			pictureBox1->Location = Point(8, 24);
			pictureBox1->BackColor = SystemColors::ControlLightLight;
			pictureBox1->TabIndex = 2;
			pictureBox1->TabStop = false;
			pictureBox1->Text = S"pictureBox1";
			pictureBox1->Size = System::Drawing::Size(264, 256);
			
			tp2RadioButton2->Location = Point(32, 48);
			tp2RadioButton2->TabIndex = 0;
			tp2RadioButton2->Enabled = true;
			tp2RadioButton2->Text = S"&Full Screen";
			tp2RadioButton2->Size = System::Drawing::Size(100, 23);
			
			tabPage4->ImageIndex = 3;
			tabPage4->TabIndex = 3;
			tabPage4->Text = S"Date";
			tabPage4->Size = System::Drawing::Size(224, 191);
			tabPage4->Location = Point(4, 25);
			
			tp2RadioButton1->Location = Point(32, 24);
			tp2RadioButton1->TabIndex = 1;
			tp2RadioButton1->Enabled = true;
			tp2RadioButton1->Text = S"&Window";
			tp2RadioButton1->Size = System::Drawing::Size(100, 23);
			
			tp4GroupBox1->Location = Point(12, 16);
			tp4GroupBox1->TabIndex = 0;
			tp4GroupBox1->TabStop = false;
			tp4GroupBox1->Text = S"Date";
			tp4GroupBox1->Size = System::Drawing::Size(202, 88);

			checkBox3->TextAlign = ContentAlignment::MiddleLeft;
			checkBox3->Location = Point(128, 112);
			checkBox3->TabIndex = 10;
			checkBox3->CheckState = CheckState::Checked;
			checkBox3->Text = S"Images";
			checkBox3->Size = System::Drawing::Size(72, 16);
			checkBox3->Checked = false;
			checkBox3->add_Click( new EventHandler(this, checkBox3_Click) );

			label3->Location = Point(16, 80);
			label3->TabIndex = 9;
			label3->TabStop = false;
			label3->Text = S"Size mode";
			label3->Size = System::Drawing::Size(80, 16);
			
			tp3ComboBox1->ForeColor = (Color)SystemColors::WindowText;
			tp3ComboBox1->Location = Point(24, 48);
			tp3ComboBox1->TabIndex = 5;
			tp3ComboBox1->Enabled = true;
			tp3ComboBox1->Text = S"Creative Music Synth [220]";
			tp3ComboBox1->Size = System::Drawing::Size(160, 21);
			
			tp4UpDown1->TextAlign = HorizontalAlignment::Right;
			tp4UpDown1->Location = Point(88, 32);
			tp4UpDown1->Maximum = Decimal(0);
			tp4UpDown1->Minimum = Decimal(0);
			tp4UpDown1->TabIndex = 0;
			tp4UpDown1->DecimalPlaces = 2;
			tp4UpDown1->Enabled = true;
			tp4UpDown1->Text = S"0.00";
			tp4UpDown1->Size = System::Drawing::Size(64, 20);
			
			tp3ComboBox2->ForeColor = (Color)SystemColors::WindowText;
			tp3ComboBox2->Location = Point(24, 120);
			tp3ComboBox2->TabIndex = 2;
			tp3ComboBox2->Enabled = true;
			tp3ComboBox2->Text = S"Default";
			tp3ComboBox2->Size = System::Drawing::Size(96, 21);
			
			tp3Button1->Location = Point(122, 120);
			tp3Button1->TabIndex = 0;
			tp3Button1->Enabled = true;
			tp3Button1->Text = S"&Configure";
			tp3Button1->Size = System::Drawing::Size(74, 24);
			
			tp5GroupBox1->Location = Point(12, 16);
			tp5GroupBox1->TabIndex = 0;
			tp5GroupBox1->TabStop = false;
			tp5GroupBox1->Text = S"Time";
			tp5GroupBox1->Size = System::Drawing::Size(202, 88);
			
//			tabControl1->ImageList = imageList1;
			tabControl1->Location = Point(24, 32);
			tabControl1->SelectedIndex = 0;
			tabControl1->TabIndex = 0;
			tabControl1->Text = S"tabControl1";
			tabControl1->Size = System::Drawing::Size(232, 220);
			tabControl1->add_SelectedIndexChanged( new EventHandler(this, tabControl1_SelectedIndexChanged) );
			
            imageList1->ImageSize = System::Drawing::Size(16, 16);
//			imageList1->ImageStream = (ImageListStreamer*)resources->GetObject("imageList1->ImageStream");
			imageList1->TransparentColor = Color::Transparent;
			imageList1->Images->Add(Image::FromFile(S"speaker.bmp"));
			imageList1->Images->Add(Image::FromFile(S"camcord.bmp"));
			imageList1->Images->Add(Image::FromFile(S"note.bmp"));
			imageList1->Images->Add(Image::FromFile(S"calendar.bmp"));
			imageList1->Images->Add(Image::FromFile(S"time.bmp"));
			//@design imageList1->SetLocation(Point(20, 40));
			
			tp1Button1->Location = Point(24, 112);
			tp1Button1->TabIndex = 0;
			tp1Button1->Enabled = true;
			tp1Button1->Text = S"Advanced &Properties";
			tp1Button1->Size = System::Drawing::Size(160, 23);
			
			tp2GroupBox1->Location = Point(12, 16);
			tp2GroupBox1->TabIndex = 0;
			tp2GroupBox1->TabStop = false;
			tp2GroupBox1->Text = S"Show video in:";
			tp2GroupBox1->Size = System::Drawing::Size(202, 128);
			
			tabPage2->ImageIndex = 1;
			tabPage2->TabIndex = 1;
			tabPage2->Text = S"Video";
			tabPage2->Size = System::Drawing::Size(224, 191);
			tabPage2->Location = Point(4, 25);
			
			tabPage5->ImageIndex = 4;
			tabPage5->TabIndex = 4;
			tabPage5->Text = S"Time";
			tabPage5->Size = System::Drawing::Size(224, 191);
			tabPage5->Location = Point(4, 25);
			
			tabPage3->ImageIndex = 2;
			tabPage3->TabIndex = 2;
			tabPage3->Text = S"Midi";
			tabPage3->Size = System::Drawing::Size(224, 191);
			tabPage3->Location = Point(4, 25);
			
			tp3GroupBox1->Location = Point(12, 16);
			tp3GroupBox1->TabIndex = 0;
			tp3GroupBox1->TabStop = false;
			tp3GroupBox1->Text = S"Midi output";
			tp3GroupBox1->Size = System::Drawing::Size(202, 160);
			
			tabPage1->ImageIndex = 0;
			tabPage1->TabIndex = 0;
			tabPage1->Text = S"Audio";
			tabPage1->Size = System::Drawing::Size(224, 191);
			tabPage1->Location = Point(4, 25);
			
			tp4GroupBox1->Controls->Add(tp4ComboBox1);
			tp4GroupBox1->Controls->Add(tp4UpDown1);
			tabPage4->Controls->Add(tp4GroupBox1);
			tabPage5->Controls->Add(tp5GroupBox1);
			tabPage2->Controls->Add(tp2GroupBox1);
			tabPage3->Controls->Add(tp3GroupBox1);
			tabPage1->Controls->Add(tp1GroupBox1);
			tp3GroupBox1->Controls->Add(tp3ComboBox2);
			tp3GroupBox1->Controls->Add(tp3Label1);
			tp3GroupBox1->Controls->Add(tp3RadioButton2);
			tp3GroupBox1->Controls->Add(tp3Button1);
			tp3GroupBox1->Controls->Add(tp3ComboBox1);
			tp3GroupBox1->Controls->Add(tp3RadioButton1);
			tp2GroupBox1->Controls->Add(tp2ComboBox1);
			tp2GroupBox1->Controls->Add(tp2RadioButton1);
			tp2GroupBox1->Controls->Add(tp2RadioButton2);
			tp5GroupBox1->Controls->Add(tp5DomainUpDown1);
			tabControl1->Controls->Add(tabPage1);
			tabControl1->Controls->Add(tabPage2);
			tabControl1->Controls->Add(tabPage4);
			tabControl1->Controls->Add(tabPage3);
			tabControl1->Controls->Add(tabPage5);
			tp1GroupBox1->Controls->Add(tp1Label1);
			tp1GroupBox1->Controls->Add(tp1Label2);
			tp1GroupBox1->Controls->Add(tp1Button1);
			tp1GroupBox1->Controls->Add(tp1ComboBox1);
			Controls->Add(tabControl1);
			Controls->Add(pictureBox1);
			Controls->Add(groupBox1);
			groupBox1->Controls->Add(checkBox3);
			groupBox1->Controls->Add(label4);
			groupBox1->Controls->Add(trackBar);
			groupBox1->Controls->Add(label3);
			groupBox1->Controls->Add(label2);
			groupBox1->Controls->Add(label1);
			groupBox1->Controls->Add(sizeModeComboBox);
			groupBox1->Controls->Add(checkBox2);
			groupBox1->Controls->Add(alignmentComboBox);
			groupBox1->Controls->Add(appearanceComboBox);
			groupBox1->Controls->Add(checkBox1);
		}         
    };
};

// The main entry point for the application.
void main()
{
	Application::Run(new TabControlCtl::TabControlCtl());
}
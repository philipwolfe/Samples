/*=====================================================================
  File:      ComboBoxCtl.Cool

  Summary:   This sample demonstrates the properties and features
             of the ComboBox control.

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
using namespace System::Collections;
using namespace System::Drawing;
using namespace System::Drawing::Drawing2D;
using namespace System::Windows::Forms;

namespace ComboBoxCtl
{
	// <doc>
	// <desc>
	//     This class defines the objects in the ComboBoxes that drive
	//     the properties of the color selection ComboBoxes.
	//     Use this object to use Enumerations with ComboBoxes and ListBoxes.
	//     Add the <paramref term='s'/> data member to the Enumeration item's
	//     english description and the <paramref term='i'/> data member to the actual
	//     value of the Enumeration item.
	//     The ToString() method will allow the ComboBox and ListBox controls to 
	//     display the text which represents the Enumeration item.
	// </desc>
	// </doc>
	//
	__gc class StringIntObject
	{
	public:
		String* s;
		int i;

    	StringIntObject(String* sz, int n)
    	{
			s = sz;
            i = n;
		}

		virtual String* ToString()
		{
			return s;
		}
	};

    // <doc>
    // <desc>
    //     This sample demonstrates the properties and features
    //     of the ComboBox control.
    //     The sample also shows two different ways to use a ComboBox which does
    //     not contain String data.  The first method uses a Hashtable which maps
    //     strings to the data and the second method uses a wrapper object which
    //     exposes a toString() method used by the ComboBox.
    // </desc>
    // </doc>
    //
	__gc class ComboBoxCtl : public Form
	{
	private:
		System::Drawing::Size cmbsize;
		Hashtable* colorMap;
		Color gradientBegin;
		Color gradientEnd;
		
        // <doc>
        // <desc>
        //     We speed up ownerdraw operations on the Color ComboBoxes
        //     by caching the Brush objects which represent the colors
        //     to choose.
        // </desc>
        // <seealso class='ComboBoxCtl.GetTheBrush()'/>
        // </doc>
        //
		Hashtable* brushMap;

        // <doc>
        // <desc>
        //     Public Constructor
        // </desc>
        // </doc>
        //
	public:
		ComboBoxCtl () : Form()
        {
             	
			colorMap = new Hashtable();
			brushMap = new Hashtable();
			gradientBegin = Color::Red;
			gradientEnd = Color::Blue;
            // This call is required for support of the WFC Form Designer.
            InitForm();

            InitControlState();
            MakeColorMap();
            FillItems(comboBegin);
            comboBegin->SelectedIndex = 0;
            FillItems(comboEnd);
            comboEnd->SelectedIndex = comboEnd->Items->Count-1;
            cmbsize = comboBegin->Size;
        }


        // <doc>
        // <desc>
        //     Sets the default states for the controls driving the properties
        //     of the two ComboBoxes.
        // </desc>
        // </doc>
        //
	private:
		void InitControlState()
		{
            // Sync the checkboxes
            chkSorted->Checked = comboBegin->Sorted;
            chkEnabled->Checked = comboBegin->Enabled;
            chkIntegralHeight->Checked = comboBegin->IntegralHeight;

            // Sync ComboBox styles to ComboBoxStyle.DROPDOWN
            StringIntObject* aStyle[] = new StringIntObject*[3];
            aStyle[0] = new StringIntObject(S"Simple",(int)ComboBoxStyle::Simple);
            aStyle[1] = new StringIntObject(S"Dropdown",(int)ComboBoxStyle::DropDown);
            aStyle[2] = new StringIntObject(S"Dropdown list",(int)ComboBoxStyle::DropDownList);
            
            cmbStyle->Items->AddRange(aStyle);
            comboBegin->DropDownStyle = static_cast<ComboBoxStyle>(aStyle[1]->i);
            comboEnd->DropDownStyle = comboBegin->DropDownStyle /*aStyle[1]->i*/;
            cmbStyle->SelectedIndex = 1;

            // Sync ComboBox draw modes to DrawMode.NORMAL
            StringIntObject* aDMO[] = new StringIntObject*[3];
            aDMO[0] = new StringIntObject(S"Normal", DrawMode::Normal);
            aDMO[1] = new StringIntObject(S"Owner draw fixed", DrawMode::OwnerDrawFixed);
            aDMO[2] = new StringIntObject(S"Owner draw variable", DrawMode::OwnerDrawVariable);
            cmbDrawMode->Items->AddRange(aDMO);
            comboBegin->DrawMode = static_cast<DrawMode>(aDMO[0]->i);
            comboEnd->DrawMode = comboBegin->DrawMode;
            cmbDrawMode->SelectedIndex = 0;
        }

		void FillItems(ComboBox* cmb)
		{
			Object* temp[] = new Object*[colorMap->Keys->Count];
			colorMap->Keys->CopyTo(temp,0);
            cmb->Items->AddRange(temp);
        }

		void MakeColorMap()
		{
            colorMap->Item[S"Aqua"] = __box(Color::Aqua);
            colorMap->Item[S"Black"] = __box(Color::Black);
            colorMap->Item[S"Blue"] = __box(Color::Blue);
            colorMap->Item[S"Brown"] = __box(Color::Brown);
            colorMap->Item[S"Cyan"] = __box(Color::Cyan);
            colorMap->Item[S"Dark Gray"] = __box(Color::DarkGray);
            colorMap->Item[S"Gray"] = __box(Color::Gray);
            colorMap->Item[S"Green"] = __box(Color::Green);
            colorMap->Item[S"Light Gray"] = __box(Color::LightGray);
            colorMap->Item[S"Magenta"] = __box(Color::Magenta);
            colorMap->Item[S"Orange"] = __box(Color::Orange);
            colorMap->Item[S"Purple"] = __box(Color::Purple);
            colorMap->Item[S"Red"] = __box(Color::Red);
            colorMap->Item[S"White"] = __box(Color::White);
            colorMap->Item[S"Yellow"] = __box(Color::Yellow);
        }

        // <doc>
        // <desc>
        //     Returns the int which is currently selected in a ComboBox.
        // </desc>
        // <param term='cmb'>
        //     The ComboBox to get the integral value from
        // </param>
        // <retvalue>
        //     If the String is in a valid numeric format, the integer
        //     representation of it is returned.  Otherwise, if
        //     no item is selected <it>or</it> the selected item is
        //     not a valid int, -1 is returned.
        // </retvalue>
        // </doc>
        //
	private:
		int SelectedValue(ComboBox* cmb)
		{
            int ret;
            Object* obj = cmb->SelectedItem;
            if (obj == null)
            {
                return -1;
            }
            try
            {
                ret = Int32::Parse(obj->ToString());
            }
            catch (FormatException* e)
            {
				MessageBox::Show(e->ToString());
                return -1;
            }
            return ret;
        }

        void chkEnabled_Click(Object* sender, EventArgs* e)
        {
            comboBegin->Enabled = chkEnabled->Checked;
            comboEnd->Enabled = chkEnabled->Checked;
        }

        void chkIntegralHeight_Click(Object* sender, EventArgs* e)
        {
            comboBegin->IntegralHeight = chkIntegralHeight->Checked;
            comboEnd->IntegralHeight = chkIntegralHeight->Checked;
        }

        void chkSorted_Click(Object* sender, EventArgs* e)
        {
            bool sorted = chkSorted->Checked;
            comboBegin->Sorted = sorted;
            comboEnd->Sorted = sorted;
            if (!sorted)
            {
                RandomShuffle(comboBegin);
                RandomShuffle(comboEnd);
            }
        }

        // <doc>
        // <desc>
        //     Performs a random shuffle on the given ComboBox.
        // </desc>
        // <param term='cmb'>
        //     The ComboBox to shuffle
        // </param>
        // </doc>
        //
        void RandomShuffle(ComboBox* cmb)
        {
			cmb->SelectedItem = 0;
            Object* items[] = new Object*[cmb->Items->Count];
			cmb->Items->CopyTo(items, 0);
            int swapItem;
            Random* rand = new Random();
            for (int i = 0; i < items->Length; ++i)
            {
                swapItem = Math::Abs(rand->Next()) % items->Length;
                if (swapItem != i)
                {
                    Object* tempObject = items[swapItem];
                    items[swapItem] = items[i];
                    items[i] = tempObject;
                }
            }
			cmb->Items->Clear();
            cmb->Items->AddRange(items);
        }

        void cmbItemHeight_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            int i = SelectedValue(cmbItemHeight);
            if (i == -1)
                return;
            comboBegin->ItemHeight = i;
            comboEnd->ItemHeight = i;
        }

        void cmbStyle_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            ComboBoxStyle i = static_cast<ComboBoxStyle>(dynamic_cast<StringIntObject*>(cmbStyle->SelectedItem)->i);
            comboBegin->DropDownStyle = i;
            comboEnd->DropDownStyle = i;

            if(!(cmbsize.IsEmpty))
            {
                if (i == ComboBoxStyle::Simple)
                {
                    comboBegin->Size = System::Drawing::Size(cmbsize.Width, cmbsize.Height * 3);
                    comboEnd->Size = System::Drawing::Size(cmbsize.Width, cmbsize.Height * 3);
                    cmbMaxDropDownItems->Enabled = false;
                }
                else
                {
                    comboBegin->Size = cmbsize;
                    comboEnd->Size = cmbsize;
                    cmbMaxDropDownItems->Enabled = true;
                }
            }
        }

        void cmbDrawMode_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            DrawMode i = static_cast<DrawMode>(dynamic_cast<StringIntObject*>(cmbDrawMode->SelectedItem)->i);
            comboBegin->DrawMode = i;
            comboEnd->DrawMode = i;

            if (i == DrawMode::OwnerDrawFixed)
            {
                cmbItemHeight->Enabled = true;
            }
            else
            {
                cmbItemHeight->Enabled = false;
            }
        }

        // <doc>
        // <desc>
        //     This DrawItem event handler is invoked to draw an item in a ComboBox if that
        //     ComboBox is in an OwnerDraw DrawMode.
        // </desc>
        // </doc>
        //
        void combo_DrawItem(Object* sender, DrawItemEventArgs* args)
        {
            ComboBox* cmb = dynamic_cast<ComboBox*>(sender);
            if (args->Index == -1)
                return;
            if (sender == null)
                return;

            String* strColor = dynamic_cast<String*>(cmb->Items->Item[args->Index]);
            Color clrSelected = *(dynamic_cast<Color*>(colorMap->Item[strColor]));
            Graphics* g = args->Graphics;

            // If the item is selected, this draws the correct background color
            args->DrawBackground();
            args->DrawFocusRectangle();

            // Draw the color's preview box
            Rectangle rectPreviewBox(args->Bounds);
            rectPreviewBox.Offset(2,2);
            rectPreviewBox.Width = 20;
            rectPreviewBox.Height -= 4;
            g->DrawRectangle(new Pen(args->ForeColor), rectPreviewBox);

            /*
             * Get the appropriate Brush object for the selected color
             * and fill the preview box.
             */
            Brush* coloredBrush = GetTheBrush(clrSelected);
            rectPreviewBox.Offset(1,1);
            rectPreviewBox.Width -= 2;
            rectPreviewBox.Height -= 2;
            g->FillRectangle(coloredBrush, rectPreviewBox);

            // Draw the name of the color selected
            g->DrawString(strColor, Font, coloredBrush, (float)(args->Bounds.X + 30), (float)(args->Bounds.Y + 1));
            g->Dispose();
        }

        // <doc>
        // <desc>
        //     Retrieves a Brush object which corresponds to <em>clr</em>
        //     Brushes created are cached for performance.
        // </desc>
        // <param term='clr'>
        //     The Color which the returned Brush will paint
        // </param>
        // <retvalue>
        //     A Brush object which corresponds to <em>clr</em>
        //     Treat this object as read-only.
        // </retvalue>
        // </doc>
        //
        Brush* GetTheBrush(Color clr)
        {
            if (clr.IsEmpty)
                throw new ArgumentException();
            Object* ret = brushMap->Item[__box(clr)];
            if (ret == null) {
                Brush* clrBrush = new SolidBrush(clr);
                brushMap->Item[__box(clr)] = clrBrush;
                return clrBrush;
            }
            else
            {
                return dynamic_cast<Brush*>(ret);
            }
        }

        void comboBegin_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
			if(!(comboBegin->SelectedItem)) return;
            Color c = *(dynamic_cast<Color*>(colorMap->Item[comboBegin->SelectedItem]));
            gradientBegin = c;
            panel1->Invalidate(panel1->Region);
        }

		void comboEnd_SelectedIndexChanged(Object* sender, EventArgs* e)
		{
			if(!comboEnd->SelectedItem) return;
            Color c = *(dynamic_cast<Color*>(colorMap->Item[comboEnd->SelectedItem]));
            gradientEnd = c;
            panel1->Invalidate(panel1->Region);
        }

        void cmbMaxDropDownItems_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            int i = SelectedValue(cmbMaxDropDownItems);
            if (i == -1)
                return;
            comboBegin->MaxDropDownItems = i;
            comboEnd->MaxDropDownItems = i;
        }

        void combo_MeasureItem(Object* sender, MeasureItemEventArgs* mie)
        {
            mie->ItemHeight = (mie->Index % 6) + 12;
        }

        void panel1_Paint(Object* sender, PaintEventArgs* e)
        {
            Brush* brush = new LinearGradientBrush(panel1->ClientRectangle, gradientBegin, gradientEnd, LinearGradientMode::ForwardDiagonal );
            e->Graphics->FillRectangle(brush, panel1->ClientRectangle);
        }

        void combo_KeyPress(Object* sender, KeyPressEventArgs* e)
        {
			if (Char::IsLetterOrDigit(e->KeyChar))
                e->Handled = true;
        }

        // NOTE: The following code is required by the WFC Form Designer
        // It can be modified using the WFC Form Designer.  
        // Do not modify it using the code editor.
        System::ComponentModel::Container* components;
        GroupBox* groupBox1;
        ComboBox* comboBegin;
        CheckBox* chkEnabled;
        CheckBox* chkSorted;
        CheckBox* chkIntegralHeight;
        Label* label1;
        Label* label2;
        Label* label3;
        Label* label4;
        ComboBox* cmbMaxDropDownItems;
        ComboBox* cmbItemHeight;
        ComboBox* cmbDrawMode;
        ComboBox* cmbStyle;
        ComboBox* comboEnd;
        Panel* panel1;
        Label* label6; 
        Label* label7; 
        Label* label5; 
        Label* label8; 
        Label* label9; 
        ToolTip* toolTip1;
        
        void InitForm()
        {
            components = new System::ComponentModel::Container();
            groupBox1 = new GroupBox();
            comboBegin = new ComboBox();
            chkEnabled = new CheckBox();
            chkSorted = new CheckBox();
            chkIntegralHeight = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbMaxDropDownItems = new ComboBox();
            cmbItemHeight = new ComboBox();
            cmbDrawMode = new ComboBox();
            cmbStyle = new ComboBox();
            comboEnd = new ComboBox();
            panel1 = new Panel();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            toolTip1 = new ToolTip(components);

			Size = System::Drawing::Size(512, 320);
            Text = S"ComboBox";

            groupBox1->Location = Point(248, 16);
            groupBox1->Size = System::Drawing::Size(248, 264);
            groupBox1->TabIndex = 2;
            groupBox1->TabStop = false;
            groupBox1->Text = S"ComboBox";

            comboBegin->Location = Point(24, 32);
            comboBegin->Size = System::Drawing::Size(208, 21);
            comboBegin->TabIndex = 0;
            comboBegin->Text = S"comboBegin1";
            comboBegin->Sorted = true;
            comboBegin->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );
            comboBegin->add_DrawItem( new DrawItemEventHandler(this, combo_DrawItem) );
            comboBegin->add_MeasureItem( new MeasureItemEventHandler(this, combo_MeasureItem) );
            comboBegin->add_SelectedIndexChanged( new EventHandler(this, comboBegin_SelectedIndexChanged) );

            chkEnabled->Location = Point(16, 24);
            chkEnabled->Size = System::Drawing::Size(88, 16);
            chkEnabled->TabIndex = 0;
            chkEnabled->Text = S"Enabled";
            chkEnabled->add_Click( new EventHandler(this, chkEnabled_Click) );

            chkSorted->Location = Point(16, 48);
            chkSorted->Size =System::Drawing::Size(88, 16);
            chkSorted->TabIndex = 1;
            chkSorted->Text = S"Sorted";
            chkSorted->add_Click( new EventHandler(this, chkSorted_Click) );

            chkIntegralHeight->Location = Point(16, 72);
            chkIntegralHeight->Size =System::Drawing::Size(98, 16);
            chkIntegralHeight->TabIndex = 2;
            chkIntegralHeight->Text = S"Integral height";
            chkIntegralHeight->add_Click( new EventHandler(this, chkIntegralHeight_Click) );

            label1->Location = Point(16, 104);
            label1->Size =System::Drawing::Size(88, 16);
            label1->TabIndex = 8;
            label1->TabStop = false;
            label1->Text = S"Style";

            label2->Location = Point(16, 128);
            label2->Size = System::Drawing::Size(88, 16);
            label2->TabIndex = 9;
            label2->TabStop = false;
            label2->Text = S"Draw mode";

            label3->Location = Point(16, 150);
            label3->Size = System::Drawing::Size(80, 16);
            label3->TabIndex = 10;
            label3->TabStop = false;
            label3->Text = S"Item height";

            label4->Location = Point(16, 173);
            label4->Size = System::Drawing::Size(108, 16);
            label4->TabIndex = 11;
            label4->TabStop = false;
            label4->Text = S"Max dropdown items";

            cmbMaxDropDownItems->Location = Point(128, 168);
            cmbMaxDropDownItems->Size = System::Drawing::Size(104, 21);
            cmbMaxDropDownItems->TabIndex = 7;
            cmbMaxDropDownItems->Text = S"";
            cmbMaxDropDownItems->DropDownStyle = ComboBoxStyle::DropDownList;
			String* itemsAll[] = new String*[5];
			itemsAll[0] = S"2";
			itemsAll[1] = S"4";
			itemsAll[2] = S"6";
			itemsAll[3] = S"8";
			itemsAll[4] = S"10";
            cmbMaxDropDownItems->Items->AddRange(itemsAll);
            cmbMaxDropDownItems->add_SelectedIndexChanged( new EventHandler(this, cmbMaxDropDownItems_SelectedIndexChanged) );

            cmbItemHeight->Location = Point(128, 144);
            cmbItemHeight->Size = System::Drawing::Size(104, 21);
            cmbItemHeight->TabIndex = 6;
            cmbItemHeight->Text = S"";
            cmbItemHeight->DropDownStyle = ComboBoxStyle::DropDownList;
			itemsAll = new String*[6];
			itemsAll[0] = S"12";
			itemsAll[1] = S"14";
			itemsAll[2] = S"16";
			itemsAll[3] = S"18";
			itemsAll[4] = S"24";
			itemsAll[5] = S"26";
            cmbItemHeight->Items->AddRange(itemsAll);
            cmbItemHeight->add_SelectedIndexChanged( new EventHandler(this, cmbItemHeight_SelectedIndexChanged) );

            cmbDrawMode->Location = Point(128, 120);
            cmbDrawMode->Size = System::Drawing::Size(104, 21);
            cmbDrawMode->TabIndex = 5;
            cmbDrawMode->Text = S"";
            cmbDrawMode->DropDownStyle = ComboBoxStyle::DropDownList;
            cmbDrawMode->add_SelectedIndexChanged( new EventHandler(this, cmbDrawMode_SelectedIndexChanged) );

            cmbStyle->Location = Point(128, 96);
            cmbStyle->Size = System::Drawing::Size(104, 21);
            cmbStyle->TabIndex = 4;
            cmbStyle->Text = S"";
            cmbStyle->DropDownStyle = ComboBoxStyle::DropDownList;
            cmbStyle->add_SelectedIndexChanged( new EventHandler(this, cmbStyle_SelectedIndexChanged) );

            comboEnd->Location = Point(24, 120);
            comboEnd->Size = System::Drawing::Size(208, 21);
            comboEnd->TabIndex = 1;
            comboEnd->Text = S"comboBegin1";
            comboEnd->Sorted = true;
            comboEnd->add_KeyPress( new KeyPressEventHandler(this, combo_KeyPress) );
            comboEnd->add_DrawItem( new DrawItemEventHandler(this, combo_DrawItem) );
            comboEnd->add_MeasureItem( new MeasureItemEventHandler(this, combo_MeasureItem) );
            comboEnd->add_SelectedIndexChanged( new EventHandler(this, comboEnd_SelectedIndexChanged) );

            panel1->Location = Point(16, 224);
            panel1->Size = System::Drawing::Size(216, 24);
            panel1->TabIndex = 3;
            panel1->Text = S"panel1";
            panel1->BorderStyle = BorderStyle::Fixed3D;
            panel1->add_Paint( new PaintEventHandler(this, panel1_Paint) );

            toolTip1->Active = true;
            toolTip1->SetToolTip(comboBegin, S"Choose color for left end of gradient");
            toolTip1->SetToolTip(chkSorted, S"Sets whether the items in the ComboBoxes\nshould be sorted alphabetically");
            toolTip1->SetToolTip(chkIntegralHeight, S"Sets a boolean value indicating\nwhether the combo box should resize\nto avoid showing partial items");
            toolTip1->SetToolTip(cmbMaxDropDownItems, S"The number of items to display on dropdown");
            toolTip1->SetToolTip(cmbItemHeight, S"The height, in pixels, of an item in the combo box");
            toolTip1->SetToolTip(comboEnd, S"Choose the color for the right end of gradient");
            /* @designTimeOnly toolTip1->setLocation(Point(136, 232)); */

            label6->Location = Point(24, 16);
            label6->Size = System::Drawing::Size(96, 16);
            label6->TabIndex = 5;
            label6->TabStop = false;
            label6->Text = S"Left:";

            label7->Location = Point(24, 104);
            label7->Size = System::Drawing::Size(96, 16);
            label7->TabIndex = 3;
            label7->TabStop = false;
            label7->Text = S"Right:";

            label5->Location = Point(16, 208);
            label5->Size = System::Drawing::Size(64, 16);
            label5->TabIndex = 12;
            label5->TabStop = false;
            label5->Text = S"Left";

            label8->Location = Point(136, 208);
            label8->Size = System::Drawing::Size(64, 0);
            label8->TabIndex = 13;
            label8->TabStop = false;
            label8->Text = S"label8";

            label9->Location = Point(200, 208);
            label9->Size = System::Drawing::Size(32, 16);
            label9->TabIndex = 14;
            label9->TabStop = false;
            label9->Text = S"Right";

            groupBox1->Controls->Add(panel1);
            groupBox1->Controls->Add(label9);
            groupBox1->Controls->Add(label8);
            groupBox1->Controls->Add(label5);
            groupBox1->Controls->Add(cmbStyle);
            groupBox1->Controls->Add(cmbDrawMode);
            groupBox1->Controls->Add(cmbItemHeight);
            groupBox1->Controls->Add(cmbMaxDropDownItems);
            groupBox1->Controls->Add(label4);
            groupBox1->Controls->Add(label3);
            groupBox1->Controls->Add(label2);
            groupBox1->Controls->Add(label1);
            groupBox1->Controls->Add(chkIntegralHeight);
            groupBox1->Controls->Add(chkSorted);
            groupBox1->Controls->Add(chkEnabled);
            Controls->Add(label7);
            Controls->Add(label6);
            Controls->Add(comboEnd);
            Controls->Add(comboBegin);
            Controls->Add(groupBox1);
		}
    };
};


// The main entry point for the application.
void main(void)
{
	Application::Run(new ComboBoxCtl::ComboBoxCtl());
}





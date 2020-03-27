/*=====================================================================
  File:      ProgressBarCtl.cpp

  Summary:   This sample demonstrates the properties and features
             of the ProgressBar control.

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
using namespace System::Threading;

namespace ProgressBarCtl
{
    //
	__gc class ProgressBarCtl : public Form
    {
    private:
		int     iSleepTime;
		Thread*  timedProgress;

    public:
    	ProgressBarCtl() : Form()
        {
             	
            // This call is required for support of the WFC Form Designer.
            InitForm();

            iSleepTime = 100 ;
            cmbMinimum->SelectedIndex = 0 ;
            progbar->Minimum = 0 ;
            cmbMaximum->SelectedIndex = 0 ;
            progbar->Maximum = 50 ;
            cmbStep->SelectedIndex = 0 ;
            progbar->Step = 1 ;
    
            // Spin off a new thread to update the ProgressBar control
            timedProgress = new Thread(new ThreadStart(this, TimedProgressProc));
			timedProgress->Start();
		}
    
	private:
		void UpdateProgress()
		{
            int min ;
            double numerator, denominator, completed ;
    
            //Reset to start if required
            if (progbar->Value == progbar->Maximum)
            {
                progbar->Value = progbar->Minimum ;
            }

            progbar->PerformStep();
			lblValue->Text = progbar->Value.ToString();
    
            min         = progbar->Minimum ;
            numerator   = progbar->Value - min ;
            denominator = progbar->Maximum - min ;
            completed   = (numerator / denominator) * 100.0 ;
    
			lblCompleted->Text = String::Concat(Math::Round(completed).ToString(),S"%");
        }
    
        void TimedProgressProc()
        {
            try {
                MethodInvoker* mi = new MethodInvoker(this,UpdateProgress);
                while(true)
                {
					if(this->IsHandleCreated)
						Invoke(mi);
                    int iSleepTime = this->SleepTime;
					Thread::Sleep(iSleepTime);
                }
            }
            //Thrown when the thread is interupted by the main thread - exiting the loop
            catch (ThreadInterruptedException* e)
            {
				(e);
                //Simply exit....
            }
			catch (Exception* we) // to exit when something unexpected occurs
            {
				(we);
//				MessageBox::Show(we->ToString(),S"Timer function caught an exception:");
            }
        }
    
        __property int get_SleepTime(void)
        {
			return iSleepTime;
		}

        __property void set_SleepTime(int n)
        {
		    iSleepTime = n;
        }
    
        // <doc>
        // <desc>
        //     ProgressBarCtl overrides the destructor so it can clean up the
        //     component list.
        // </desc>
        // </doc>
        //
	public:
        virtual ~ProgressBarCtl()
        {
            /*
             * We have to make sure that our thread doesn't attempt
             * to access our controls after we dispose them.
             */
            if (timedProgress != null)
            {
                timedProgress->Interrupt();
                timedProgress = null;
            }
        }
    
	private:
        void sldrSpeed_Scroll(Object* sender, EventArgs* e)
        {
            TrackBar* tb = dynamic_cast<TrackBar*>(sender);
            int time = 110 - tb->Value;
            SleepTime = time;
        }
    
        void cmbMinimum_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            try
            {
				int newMinValue = 0;
				if(cmbMinimum->SelectedItem)
					newMinValue = Int32::Parse(cmbMinimum->SelectedItem->ToString());
				if(cmbMaximum->SelectedItem)
					if(newMinValue < Int32::Parse(cmbMaximum->SelectedItem->ToString()))
						progbar->Minimum = newMinValue;
            }
            catch (FormatException* ex)
            {
				MessageBox::Show(ex->ToString(), S"Exception thrown:");
                // thrown if Value.toInt can't convert
            }
        }
    
        void cmbMaximum_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            try
            {
				int newMaxValue = 0;
				if(cmbMinimum->SelectedItem)
					newMaxValue = Int32::Parse(cmbMaximum->SelectedItem->ToString());
				if(cmbMaximum->SelectedItem)
	                if (newMaxValue > Int32::Parse(cmbMinimum->SelectedItem->ToString()))
		                progbar->Maximum = newMaxValue;
            }
            catch (FormatException* ex)
            {
				MessageBox::Show(ex->ToString(),S"Exception thrown:");
                // thrown if Value.toInt can't convert
            }
        }
    
        void cmbStep_SelectedIndexChanged(Object* sender, EventArgs* e)
        {
            try
            {
				progbar->Step = Int32::Parse((cmbStep->SelectedItem->ToString()));
            }
            catch (FormatException* ex)
            {
				MessageBox::Show(ex->ToString(),S"Exception thrown:");
                // thrown if Value.toInt can't convert
            }
        }
    
        // NOTE: The following code is required by the WFC Form Designer
        // It can be modified using the WFC Form Designer.  
        // Do not modify it using the code editor.
        System::ComponentModel::Container* components;
        Label* label3; 
        Label* lblCompleted; 
        TrackBar* sldrSpeed; 
        ProgressBar* progbar; 
        Label* label1; 
        ComboBox* cmbMinimum; 
        Label* label2; 
        Label* label5; 
        ComboBox* cmbMaximum; 
        GroupBox* grpBehavior; 
        Label* label4; 
        Label* label6; 
        Label* lblValue; 
        ComboBox* cmbStep; 
    
		void InitForm()
		{
            components = new System::ComponentModel::Container();
            label3 = new Label();
            lblCompleted = new Label();
            sldrSpeed = new TrackBar();
            progbar = new ProgressBar();
            label1 = new Label();
            cmbMinimum = new ComboBox();
            label2 = new Label();
            label5 = new Label();
            cmbMaximum = new ComboBox();
            grpBehavior = new GroupBox();
            label4 = new Label();
            label6 = new Label();
            lblValue = new Label();
            cmbStep = new ComboBox();

			Size = System::Drawing::Size(512, 300);
            Text = S"ProgressBar";
    
            label3->Location = Point(16, 72);
            label3->Size = System::Drawing::Size(48, 16);
            label3->TabIndex = 6;
            label3->TabStop = false;
            label3->Text = S"Step:";
    
            sldrSpeed->Location = Point(16, 216);
            sldrSpeed->Size = System::Drawing::Size(216, 42);
            sldrSpeed->TabIndex = 1;
            sldrSpeed->TabStop = false;
            sldrSpeed->Text = S"trackBar1";
            sldrSpeed->Minimum = 10;
            sldrSpeed->Maximum = 100;
            sldrSpeed->Value = 10;
            sldrSpeed->TickFrequency = 10;
            sldrSpeed->add_Scroll( new EventHandler(this, sldrSpeed_Scroll) );
    
            progbar->BackColor = SystemColors::Control;
            progbar->Location = Point(24, 24);
            progbar->Size = System::Drawing::Size(192, 16);
            progbar->TabIndex = 0;
            progbar->Text = S"progbar";
            progbar->Step = 1;
    
            label1->Location = Point(16, 48);
            label1->Size = System::Drawing::Size(56, 16);
            label1->TabIndex = 4;
            label1->TabStop = false;
            label1->Text = S"Maximum:";
    
            cmbMinimum->Location = Point(136, 24);
            cmbMinimum->Size = System::Drawing::Size(96, 21);
            cmbMinimum->TabIndex = 3;
            cmbMinimum->Text = "";
            cmbMinimum->DropDownStyle = ComboBoxStyle::DropDownList;
			String* arrStrgs[] = new String*[3];
			arrStrgs[0] = S"0";
			arrStrgs[1] = S"10";
			arrStrgs[2] = S"40";
            cmbMinimum->Items->AddRange(arrStrgs);
            cmbMinimum->add_SelectedIndexChanged( new EventHandler(this, cmbMinimum_SelectedIndexChanged) );
    
            label2->Location = Point(16, 24);
            label2->Size = System::Drawing::Size(56, 16);
            label2->TabIndex = 2;
            label2->TabStop = false;
            label2->Text = S"Minimum:";
    
            label5->Location = Point(24, 56);
            label5->Size = System::Drawing::Size(150, 16);
            label5->TabIndex = 1;
            label5->TabStop = false;
            label5->Text = S"Percent completed:";

            lblCompleted->Location = Point(128, 56);
            lblCompleted->Size = System::Drawing::Size(56, 16);
            lblCompleted->TabIndex = 2;
            lblCompleted->TabStop = false;
            lblCompleted->Text = S"";
    
            label6->Location = Point(24, 80);
            label6->Size = System::Drawing::Size(100, 16);
            label6->TabIndex = 3;
            label6->TabStop = false;
            label6->Text = S"Value:";

            lblValue->Location = Point(128, 80);
            lblValue->Size = System::Drawing::Size(56, 16);
            lblValue->TabIndex = 4;
            lblValue->TabStop = false;
            lblValue->Text = S"";
    
			cmbMaximum->Location = Point(136, 48);
            cmbMaximum->Size = System::Drawing::Size(96, 21);
            cmbMaximum->TabIndex = 5;
            cmbMaximum->Text = S"";
            cmbMaximum->DropDownStyle = ComboBoxStyle::DropDownList;
			arrStrgs[0] = S"50";
			arrStrgs[1] = S"100";
			arrStrgs[2] = S"200";
            cmbMaximum->Items->AddRange(arrStrgs);
            cmbMaximum->add_SelectedIndexChanged( new EventHandler(this, cmbMaximum_SelectedIndexChanged) );
    
            grpBehavior->Location = Point(248, 16);
            grpBehavior->Size = System::Drawing::Size(248, 264);
            grpBehavior->TabIndex = 5;
            grpBehavior->TabStop = false;
            grpBehavior->Text = S"ProgressBar";
    
            label4->Location = Point(16, 192);
            label4->Size = System::Drawing::Size(120, 16);
            label4->TabIndex = 0;
            label4->TabStop = false;
            label4->Text = S"Completion speed:";
    
            cmbStep->Location = Point(136, 72);
            cmbStep->Size = System::Drawing::Size(96, 21);
            cmbStep->TabIndex = 7;
            cmbStep->Text = S"";
			cmbStep->DropDownStyle = ComboBoxStyle::DropDownList;
			arrStrgs = new String*[4];
			arrStrgs[0] = S"1";
			arrStrgs[1] = S"5";
			arrStrgs[2] = S"10";
			arrStrgs[3] = S"20";
            cmbStep->Items->AddRange(arrStrgs);
            cmbStep->add_SelectedIndexChanged( new EventHandler(this, cmbStep_SelectedIndexChanged) );
    
            Controls->Add(grpBehavior);
            Controls->Add(lblValue);
            Controls->Add(label6);
            Controls->Add(lblCompleted);
            Controls->Add(label5);
            Controls->Add(progbar);
            grpBehavior->Controls->Add(cmbStep);
            grpBehavior->Controls->Add(cmbMaximum);
            grpBehavior->Controls->Add(cmbMinimum);
            grpBehavior->Controls->Add(label3);
            grpBehavior->Controls->Add(label1);
            grpBehavior->Controls->Add(label2);
            grpBehavior->Controls->Add(sldrSpeed);
            grpBehavior->Controls->Add(label4);
        }
    };
};


// The main entry point for the application.
void main()
{
	Application::Run(new ProgressBarCtl::ProgressBarCtl());
}



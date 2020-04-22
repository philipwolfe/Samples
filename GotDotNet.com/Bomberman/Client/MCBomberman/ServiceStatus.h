#pragma once

#using <mscorlib.dll>
#using <system.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>
#using <System.Web.Services.dll>



#define null 0L

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;


namespace Query {
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
public __gc class CreateGame : public System::Windows::Forms::Form {
public:

	System::Windows::Forms::TextBox __gc* textBox1;
	System::Windows::Forms::Label __gc* label1;
	System::Windows::Forms::Label __gc* label2;
	System::Windows::Forms::Button __gc* button1;
	System::Windows::Forms::Label __gc* label3;
	System::Windows::Forms::Label __gc* label4;
	System::Windows::Forms::TextBox __gc* GameName;
	System::Windows::Forms::TextBox __gc* nHuman;
	System::Windows::Forms::TextBox __gc* nAI;

	/// <summary>
	/// Required designer variable.
	/// </summary>
private:
	System::ComponentModel::Container __gc* components; // = null;

public:

	CreateGame() {
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		//
		// TODO: Add any constructor code after InitializeComponent call
		//
	}

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
protected:
	void Dispose(Boolean disposing ) {
		if (disposing) {
			if (components != null) {
				components->Dispose();
			}
		}
		__super::Dispose(disposing);
	}

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
private:

	void InitializeComponent() {
		components = null;
		textBox1 = new System::Windows::Forms::TextBox();
		GameName = new System::Windows::Forms::TextBox();
		label1 = new System::Windows::Forms::Label();
		label2 = new System::Windows::Forms::Label();
		button1 = new System::Windows::Forms::Button();
		nHuman = new System::Windows::Forms::TextBox();
		nAI = new System::Windows::Forms::TextBox();
		label3 = new System::Windows::Forms::Label();
		label4 = new System::Windows::Forms::Label();
		SuspendLayout();
		// 
		// textBox1
		// 
		textBox1->Location = System::Drawing::Point(24, 48);
		textBox1->Name = S"textBox1";
		textBox1->ReadOnly = true;
		textBox1->Size = System::Drawing::Size(56, 20);
		textBox1->TabIndex = 1;
		textBox1->Text = S"1";
		// 
		// GameName
		// 
		GameName->Location = System::Drawing::Point(112, 48);
		GameName->Name = S"GameName";
		GameName->Size = System::Drawing::Size(56, 20);
		GameName->TabIndex = 1;
		GameName->Text = S"BomberBunny";
		// 
		// label1
		// 
		label1->Location = System::Drawing::Point(24, 24);
		label1->Name = "label1";
		label1->Size = System::Drawing::Size(64, 16);
		label1->TabIndex = 4;
		label1->Text = S"GameID";
		// 
		// label2
		// 
		label2->Location = System::Drawing::Point(112, 24);
		label2->Name = S"label2";
		label2->Size = System::Drawing::Size(48, 16);
		label2->TabIndex = 5;
		label2->Text = S"Name";
		// 
		// button1
		// 
		button1->DialogResult = System::Windows::Forms::DialogResult::OK;
		button1->Location = System::Drawing::Point(48, 88);
		button1->Name = S"button1";
		button1->Size = System::Drawing::Size(192, 24);
		button1->TabIndex = 6;
		button1->Text = S"OK";
		// 
		// nHuman
		// 
		nHuman->Location = System::Drawing::Point(192, 48);
		nHuman->Name = S"nHuman";
		nHuman->Size = System::Drawing::Size(24, 20);
		nHuman->TabIndex = 2;
		nHuman->Text = S"2";
		// 
		// nAI
		//
		//nAI->Enabled = false;
		nAI->Location = System::Drawing::Point(240, 48);
		nAI->Name = S"nAI";
		nAI->Size = System::Drawing::Size(32, 20);
		nAI->TabIndex = 3;
		nAI->Text = S"0";
		// 
		// label3
		// 
		label3->Location = System::Drawing::Point(184, 24);
		label3->Name = S"label3";
		label3->Size = System::Drawing::Size(48, 16);
		label3->TabIndex = 9;
		label3->Text = S"Human";
		// 
		// label4
		// 
		label4->Location = System::Drawing::Point(240, 24);
		label4->Name = S"label4";
		label4->Size = System::Drawing::Size(32, 16);
		label4->TabIndex = 10;
		label4->Text = S"AI";
		// 
		// Form2
		// 
		AutoScaleBaseSize = System::Drawing::Size(5, 13);
		ClientSize = System::Drawing::Size(304, 134);
		System::Windows::Forms::Control __gc* controlArray __gc[] = {label4,
			label3,
			nAI,
			nHuman,
			button1,
			label2,
			label1,
			GameName,
			textBox1};
		Controls->AddRange(controlArray);
		Name = S"Form2";
		Text = S"Form1";
		ResumeLayout(false);

	}
};

public __gc class JoinGame : public System::Windows::Forms::Form
{
private:
	System::Windows::Forms::Button __gc* button1;
	System::Windows::Forms::Button __gc* button2;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	System::ComponentModel::Container __gc* components;// = null;
	System::Windows::Forms::Button __gc* Create;
	System::Windows::Forms::ListView __gc* listView1;
	BombermanService __gc* svr; // = new BombermanService();
	



public:
	JoinGame()
	{
		svr = new BombermanService();
		components = null;
		//
		// Required for Windows Form Designer support
		//
		InitializeComponent();

		//
		// TODO: Add any constructor code after InitializeComponent call
		//

		UpdateListView();
	}

	__property Boolean get_Joined(){
		return _joined;
	}

	__property Int32 get_GameID(){
		return _gameID;
	}

	__property Int32 get_UserID(){
		return _userID;
	}

private:
	void UpdateListView()
	{
		_joined = false;
		_userID = -1;
		_gameID = -1;

		if(listView1->Items->Count != 0)
		{
			listView1->Clear();
		}

		for (int i = 1; i <= 5; i++) 
		{
			listView1->Columns->Add(S"Game#", listView1->Size.Width /5,	HorizontalAlignment::Left);
			listView1->Columns->Add(S"Name", listView1->Size.Width /5,	HorizontalAlignment::Left);
			listView1->Columns->Add(S"# Human", listView1->Size.Width /5,	HorizontalAlignment::Left);
			listView1->Columns->Add(S"# AI", listView1->Size.Width /5,	HorizontalAlignment::Left);
			listView1->Columns->Add(S"Status", listView1->Size.Width /5,HorizontalAlignment::Left);

			SessionStatus __gc* s;
			
			try{
				s= svr->QueryStatus(i);
			}catch(Exception __gc*){
				// TODO: soap exception handling
			}

			ListViewItem __gc* item;
			if(s->status == BMSTATUS::OPENED){
				String __gc* str __gc[] = {i.ToString(),
					S" ----- ",
					S" ----- ",
					S" ----- ",
					__box(s->status)->ToString()
				};

				item = new ListViewItem(str,i);
			}

			else
			{
				String __gc* str __gc[] = {
					i.ToString(),
					s->szGameName,
					s->nHumans.ToString(),
					s->nRobots.ToString(),
					__box(s->status)->ToString()
				};

				item = new ListViewItem(str,i);
			};
			listView1->Items->Add(item);
		}
	}

	Boolean _joined;
	Int32 _userID;
	Int32 _gameID;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
protected:
	void Dispose( bool disposing )
	{
		if( disposing )
		{
			if (components != null) 
			{
				components->Dispose();
			}
		}
		System::Windows::Forms::Form::Dispose( disposing );
	}

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
private:
	void InitializeComponent()
	{
		button1 = new System::Windows::Forms::Button();
		button2 = new System::Windows::Forms::Button();
		Create = new System::Windows::Forms::Button();
		listView1 = new System::Windows::Forms::ListView();
		SuspendLayout();
		// 
		// button1
		// 
		button1->DialogResult = System::Windows::Forms::DialogResult::OK;
		button1->Location = System::Drawing::Point(264, 288);
		button1->Name = S"button1";
		button1->Size =  System::Drawing::Size(112, 32);
		button1->TabIndex = 1;
		button1->Text = S"Join";
		button1->Click += new System::EventHandler(this,&JoinGame::button1_Click);
		// 
		// button2
		// 
		button2->DialogResult = System::Windows::Forms::DialogResult::Cancel;
		button2->Location =  System::Drawing::Point(384, 288);
		button2->Name = S"button2";
		button2->Size = System::Drawing::Size(112, 32);
		button2->TabIndex = 2;
		button2->Text = S"Cancel";
		// 
		// Create
		// 
		Create->Location = System::Drawing::Point(152, 288);
		Create->Name = S"Create";
		Create->Size =  System::Drawing::Size(104, 32);
		Create->TabIndex = 3;
		Create->Text = S"Create";
		Create->Click += new System::EventHandler(this,&JoinGame::Create_Click);
		// 
		// listView1
		// 
		listView1->FullRowSelect = true;
		listView1->HeaderStyle = System::Windows::Forms::ColumnHeaderStyle::Nonclickable;
		listView1->LabelEdit = true;
		listView1->Location = System::Drawing::Point(16, 24);
		listView1->MultiSelect = false;
		listView1->Name = S"listView1";
		listView1->Size = System::Drawing::Size(472, 248);
		listView1->TabIndex = 4;
		listView1->Text = S"listView1";
		listView1->View = System::Windows::Forms::View::Details;
		// 
		// JoinGame
		// 
		AutoScaleBaseSize =  System::Drawing::Size(5, 13);
		ClientSize = System::Drawing::Size(504, 334);
		System::Windows::Forms::Control __gc* ctrl __gc[] = {
			listView1,
				Create,
				button2,
				button1};

			Controls->AddRange(ctrl);
			Name = S"JoinGame";
			Text = S"Join Game";
			ResumeLayout(false);

	}



private:
	void Create_Click(Object __gc* sender, System::EventArgs __gc* e)
	{
		int index;
		if(listView1->SelectedItems->Count >0)
		{
			index = listView1->Items->IndexOf(listView1->SelectedItems->Item[0]);

			SessionStatus  __gc* ss = svr->QueryStatus(index + 1);

#ifdef MessageBox
#undef MessageBox
#endif
			if(ss->status == BMSTATUS::RUNNING)
				MessageBox::Show(S"You cannot stop running game !!");
			else
			{
				CreateGame __gc* f = new CreateGame();
				f->textBox1->Text = (index+1).ToString();
				if(DialogResult::OK == f->ShowDialog()){
					try{
						svr->CreateGame(index+1,Int32::Parse(f->nHuman->Text),Int32::Parse(f->nAI->Text),f->GameName->Text,0);
					}catch(Exception*){
						// soap exception
					}
				}
			}
		}
		UpdateListView();
	}

	void button1_Click(Object __gc* sender, System::EventArgs __gc* e)
	{
		int index;
		if(listView1->SelectedItems->Count >0)
		{
			index = listView1->Items->IndexOf(listView1->SelectedItems->Item[0]);
			SessionStatus __gc* ss;

			try{
				ss = svr->QueryStatus(index + 1);
			}catch(Exception __gc*){
				// soap exception	
			}
			_gameID = index + 1;
			_userID = ss->nPlayers - ss->nRobots+1;
		}
	}


};
}

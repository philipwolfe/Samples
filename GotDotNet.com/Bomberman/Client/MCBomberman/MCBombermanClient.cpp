// This is the main project file for VC++ application project 
// generated using an Application Wizard.

//#include "stdafx.h"

#using <mscorlib.dll>
#using <system.dll>
#using <system.xml.dll>
#using <system.data.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>
#using <System.Web.Services.dll>
// You must create the BombermanService.dll by using the command line tool
// wsdl
// Use "wsdl http://<servername>/bombermanws/bombermanws.asmx" to create the proxy
// Then use "csc /t:library BombermanService.cs" at the command line to build the dll
// It needs to be in the directory with your Bomberman client

#using "BombermanService.dll"


#include <iostream>
#include "udpclient.h"
#include "streamobjs.h"
#include "objdispatcher.h"
#include "process.h"

#include <windows.h>
#include  "ServiceStatus.h"

// Global Constants
#define NUM_BITMAPS 9
#define NUM_BITMASKS 10

using namespace std;
using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Web::Services;

void ProcessMapUpdates(PVOID pvoid);
UINT UMap[MAP_ROWS][MAP_COLS];

__value enum bitmaskEnum {
	BITMASK_BLANK			= 0x001,
	BITMASK_BOMBERMAN1		= 0x002,
	BITMASK_BOMBERMAN2		= 0x004,
	BITMASK_BOMBERMAN3		= 0x008,
	BITMASK_BOMBERMAN4		= 0x010,
	BITMASK_BOMB			= 0x020,
	BITMASK_SOFTWALL		= 0x040,
	BITMASK_EXPLOSION		= 0x080,
	BITMASK_HARDWALL		= 0x100,
	BITMASK_SPECIAL			= 0x200,
};

public __gc class BMForm;

public __gc struct GData {

	// Pointer to invoke Invalidate from outside the BMForm.
	static BMForm __gc* pBMForm;

	// the map that each game is started with.
	static UInt32 StartMap __gc[,];

	// the map that keeps track of the game.
	static UInt32 Map __gc[,];

	static int GData::port;

	static void Init() {

		StartMap = new UInt32 __gc[MAP_ROWS, MAP_COLS];
		StartMap[0,0] = 0x002; StartMap[0,1] = 0x040; StartMap[0,2] = 0x040; StartMap[0,3] = 0x040; StartMap[0,4] = 0x040; StartMap[0,5] = 0x040; StartMap[0,6] = 0x040; StartMap[0,7] = 0x040; StartMap[0,8] = 0x040; StartMap[0,9] = 0x040; StartMap[0,10] = 0x040; StartMap[0,11] = 0x040; StartMap[0,12] = 0x008;
		StartMap[1,0] = 0x040; StartMap[1,1] = 0x100; StartMap[1,2] = 0x040; StartMap[1,3] = 0x100; StartMap[1,4] = 0x040; StartMap[1,5] = 0x100; StartMap[1,6] = 0x040; StartMap[1,7] = 0x100; StartMap[1,8] = 0x040; StartMap[1,9] = 0x100; StartMap[1,10] = 0x040; StartMap[1,11] = 0x100; StartMap[1,12] = 0x040;
		StartMap[2,0] = 0x040; StartMap[2,1] = 0x040; StartMap[2,2] = 0x040; StartMap[2,3] = 0x040; StartMap[2,4] = 0x040; StartMap[2,5] = 0x040; StartMap[2,6] = 0x040; StartMap[2,7] = 0x040; StartMap[2,8] = 0x040; StartMap[2,9] = 0x040; StartMap[2,10] = 0x040; StartMap[2,11] = 0x040; StartMap[2,12] = 0x040;
		StartMap[3,0] = 0x040; StartMap[3,1] = 0x100; StartMap[3,2] = 0x040; StartMap[3,3] = 0x100; StartMap[3,4] = 0x040; StartMap[3,5] = 0x100; StartMap[3,6] = 0x040; StartMap[3,7] = 0x100; StartMap[3,8] = 0x040; StartMap[3,9] = 0x100; StartMap[3,10] = 0x040; StartMap[3,11] = 0x100; StartMap[3,12] = 0x040;
		StartMap[4,0] = 0x040; StartMap[4,1] = 0x040; StartMap[4,2] = 0x040; StartMap[4,3] = 0x040; StartMap[4,4] = 0x040; StartMap[4,5] = 0x040; StartMap[4,6] = 0x040; StartMap[4,7] = 0x040; StartMap[4,8] = 0x040; StartMap[4,9] = 0x040; StartMap[4,10] = 0x040; StartMap[4,11] = 0x040; StartMap[4,12] = 0x040;
		StartMap[5,0] = 0x040; StartMap[5,1] = 0x100; StartMap[5,2] = 0x040; StartMap[5,3] = 0x100; StartMap[5,4] = 0x040; StartMap[5,5] = 0x100; StartMap[5,6] = 0x040; StartMap[5,7] = 0x100; StartMap[5,8] = 0x040; StartMap[5,9] = 0x100; StartMap[5,10] = 0x040; StartMap[5,11] = 0x100; StartMap[5,12] = 0x040;
		StartMap[6,0] = 0x040; StartMap[6,1] = 0x040; StartMap[6,2] = 0x040; StartMap[6,3] = 0x040; StartMap[6,4] = 0x040; StartMap[6,5] = 0x040; StartMap[6,6] = 0x040; StartMap[6,7] = 0x040; StartMap[6,8] = 0x040; StartMap[6,9] = 0x040; StartMap[6,10] = 0x040; StartMap[6,11] = 0x040; StartMap[6,12] = 0x040;
		StartMap[7,0] = 0x040; StartMap[7,1] = 0x100; StartMap[7,2] = 0x040; StartMap[7,3] = 0x100; StartMap[7,4] = 0x040; StartMap[7,5] = 0x100; StartMap[7,6] = 0x040; StartMap[7,7] = 0x100; StartMap[7,8] = 0x040; StartMap[7,9] = 0x100; StartMap[7,10] = 0x040; StartMap[7,11] = 0x100; StartMap[7,12] = 0x040;
		StartMap[8,0] = 0x040; StartMap[8,1] = 0x040; StartMap[8,2] = 0x040; StartMap[8,3] = 0x040; StartMap[8,4] = 0x040; StartMap[8,5] = 0x040; StartMap[8,6] = 0x040; StartMap[8,7] = 0x040; StartMap[8,8] = 0x040; StartMap[8,9] = 0x040; StartMap[8,10] = 0x040; StartMap[8,11] = 0x040; StartMap[8,12] = 0x040;
		StartMap[9,0] = 0x040; StartMap[9,1] = 0x100; StartMap[9,2] = 0x040; StartMap[9,3] = 0x100; StartMap[9,4] = 0x040; StartMap[9,5] = 0x100; StartMap[9,6] = 0x040; StartMap[9,7] = 0x100; StartMap[9,8] = 0x040; StartMap[9,9] = 0x100; StartMap[9,10] = 0x040; StartMap[9,11] = 0x100; StartMap[9,12] = 0x040;
		StartMap[10,0]= 0x004; StartMap[10,1]= 0x040; StartMap[10,2]= 0x040; StartMap[10,3]= 0x040; StartMap[10,4]= 0x040; StartMap[10,5]= 0x040; StartMap[10,6]= 0x040; StartMap[10,7]= 0x040; StartMap[10,8]= 0x040; StartMap[10,9]= 0x040; StartMap[10,10]= 0x040; StartMap[10,11]= 0x040; StartMap[10,12] = 0x010;
		Map = new UInt32 __gc[MAP_ROWS, MAP_COLS];
		//Initialize Map to StartMap
		for (Int32 row = 0; row < MAP_ROWS; row++)
			for (Int32 col = 0; col < MAP_COLS; col++)
				UMap[row][col] = StartMap[row, col];
	}
}; //GData

public __gc class BMForm : public System::Windows::Forms::Form {
private:

	System::Windows::Forms::ImageList __gc* imageList;
	System::Windows::Forms::MainMenu __gc* menuMain;
	System::Windows::Forms::MenuItem __gc* menuFile;
	System::Windows::Forms::MenuItem __gc* menuGameQuery;
	System::Windows::Forms::MenuItem __gc* menuExit;
	System::Windows::Forms::MenuItem __gc* menuHelp;
	System::Windows::Forms::MenuItem __gc* menuMore;
	System::ComponentModel::IContainer __gc* components;
public:

	System::Windows::Forms::Panel __gc* panel;
private:

	System::Windows::Forms::ToolBar __gc* toolBar;
	System::Windows::Forms::ToolBarButton __gc* toolBarButtonGameQuery;
	System::Windows::Forms::ToolBarButton __gc* toolBarButtonEndGame;
	BombermanService __gc* bmService;
	Int32 gameID;
	Int32 userID;
	uintptr_t _threadID;
public:

	BMForm() {
		InitializeComponent();
		bmService = new BombermanService;
		_threadID = -1;

	};
private:

	void InitializeComponent() {

		PlaySound(TEXT("Explosion.wav"), NULL, SND_FILENAME | SND_ASYNC);

		// Initializing the Map.
		GData::Init();
		components = new System::ComponentModel::Container();
		menuMain = new System::Windows::Forms::MainMenu();
		menuFile = new System::Windows::Forms::MenuItem();
		menuGameQuery = new System::Windows::Forms::MenuItem();
		menuExit = new System::Windows::Forms::MenuItem();
		menuHelp = new System::Windows::Forms::MenuItem();
		menuMore = new System::Windows::Forms::MenuItem();
		panel = new System::Windows::Forms::Panel();
		toolBar = new System::Windows::Forms::ToolBar();
		toolBarButtonGameQuery = new System::Windows::Forms::ToolBarButton();
		toolBarButtonEndGame = new System::Windows::Forms::ToolBarButton();

		System::Resources::ResourceManager __gc* resources = new System::Resources::ResourceManager(__typeof(BMForm));
		imageList = new System::Windows::Forms::ImageList(components);
		// 
		// imageList
		// 
#ifdef GetObject
#undef GetObject
#endif
		imageList->ColorDepth = System::Windows::Forms::ColorDepth::Depth32Bit;
		imageList->ImageSize = System::Drawing::Size(32, 32);
		imageList->ImageStream = dynamic_cast<System::Windows::Forms::ImageListStreamer __gc*>(resources->GetObject(S"imageList.ImageStream"));
		imageList->TransparentColor = System::Drawing::Color::Lime;
		// 
		// menuMain
		// 
		System::Windows::Forms::MenuItem __gc* itemArray0 __gc[] = {menuFile, menuHelp};
		menuMain->MenuItems->AddRange(itemArray0);
		// 
		// menuFile
		// 
		menuFile->Index = 0;
		System::Windows::Forms::MenuItem __gc* itemArray1 __gc[] = {menuGameQuery, menuExit};
		menuFile->MenuItems->AddRange(itemArray1);
		menuFile->Text = S"File";
		// 
		// menuGameQuery
		// 
		menuGameQuery->Index = 0;
		menuGameQuery->Text = S"Game Query";
		menuGameQuery->Click += new System::EventHandler(this, &BMForm::menuGameQuery_Click);
		// 
		// menuExit
		// 
		menuExit->Index = 1;
		menuExit->Text = S"Exit";
		menuExit->Click += new System::EventHandler(this, &BMForm::menuExit_Click);
		// 
		// menuHelp
		// 
		menuHelp->Index = 1;
		System::Windows::Forms::MenuItem __gc* itemArray6 __gc[] = {menuMore};
		menuHelp->MenuItems->AddRange(itemArray6);
		menuHelp->Text = S"Help";
		// 
		// menuMore
		// 
		menuMore->Index = 0;
		menuMore->Text = S"More...";
		menuMore->Click += new System::EventHandler(this, &BMForm::menuMore_Click);
		// 
		// panel
		// 
		panel->Location = System::Drawing::Point(0, 39);
		panel->Name = "panel";
		panel->Size = System::Drawing::Size(415, 350);
		panel->TabIndex = 1;
		panel->Paint += new System::Windows::Forms::PaintEventHandler(this, &BMForm::panel_Paint);
		// 
		// toolBar
		//
		System::Windows::Forms::ToolBarButton __gc* toolBarButtonArray __gc[] = {toolBarButtonGameQuery, toolBarButtonEndGame};
		toolBar->Buttons->AddRange(toolBarButtonArray);
		toolBar->DropDownArrows = true;
		toolBar->Name = S"toolBar";
		toolBar->ShowToolTips = true;
		toolBar->Size = System::Drawing::Size(415, 40);
		toolBar->TabIndex = 2;
		toolBar->ButtonClick += new System::Windows::Forms::ToolBarButtonClickEventHandler(this, &BMForm::toolBar_ButtonClick);
		// 
		// toolBarButtonGameQuery
		// 
		toolBarButtonGameQuery->Text = S"Game Query";
		// 
		// toolBarButtonEndGameB
		// 
		toolBarButtonEndGame->Text = S"End Game";
		// 
		// BMForm
		// 
		AutoScaleBaseSize = System::Drawing::Size(5, 13);
		ClientSize = System::Drawing::Size(415, 390);
		Menu = menuMain;
		Name = S"MCBomberMan";
		Text = S"MCBomberMan";
		System::Windows::Forms::Control __gc* controlArray __gc[] = {toolBar, panel};
		Controls->AddRange(controlArray);
		toolBar->KeyDown += new System::Windows::Forms::KeyEventHandler(this, &BMForm::BMForm_KeyDown);
		KeyDown += new System::Windows::Forms::KeyEventHandler(this, &BMForm::BMForm_KeyDown);
		Paint += new System::Windows::Forms::PaintEventHandler(this, &BMForm::panel_Paint);
		Closing += new System::ComponentModel::CancelEventHandler(this, &BMForm::BMForm_Closing);
	}

	void BMForm_KeyDown(Object __gc* sender, System::Windows::Forms::KeyEventArgs __gc* e) {
		if((e->KeyValue >= 37) && (e->KeyValue <= VK_DOWN)) {
			try{
				bmService->MoveBunny(gameID, userID, e->KeyValue - 37);
			}catch(Exception*){
				//SOAP Exception
			}
		}
		// the space bar drops a bomb.
		else if(e->KeyValue == 32) {
			try{
				bmService->DropBomb(gameID, userID);
			}catch(Exception*){
				// SOAP Exception
			}
		}
	}

	void menuGameQuery_Click(Object __gc *sender, System::EventArgs __gc* e) {

		Query::JoinGame * f2 = new Query::JoinGame();
		Windows::Forms::DialogResult res = f2->ShowDialog();
		Boolean flag = true;

		while(flag) {
			if(res == DialogResult::OK){
			
				if(!bmService->JoinGame(gameID = f2->GameID,userID = f2->UserID)){
					MessageBox::Show(S"Cannot join");
					res = f2->ShowDialog();
				}
				else{
					//	MessageBox::Show(S"Joined !!");
					//Creating Thread...
					GData::port = gameID + 1019;
					_threadID = _beginthread(ProcessMapUpdates, 0, NULL);
					flag = false;
				}
			}
			else
				flag = false;
		}
	}

	void menuExit_Click(Object __gc *sender, System::EventArgs __gc* e) {
		Close();
	}

	void menuMore_Click(Object __gc *sender, System::EventArgs __gc* e) {
		//Documentation.
	}

	void panel_Paint(Object __gc* sender, System::Windows::Forms::PaintEventArgs __gc* e) {

		System::Drawing::Bitmap __gc* bitmap = new System::Drawing::Bitmap(32 * MAP_COLS, 32 * MAP_ROWS);
		System::Drawing::Graphics __gc* g = System::Drawing::Graphics::FromImage(dynamic_cast<System::Drawing::Image __gc*>(bitmap));
		panel->SetStyle((System::Windows::Forms::ControlStyles)(System::Windows::Forms::ControlStyles::DoubleBuffer | System::Windows::Forms::ControlStyles::Opaque), true);
		UInt32 bitmask;

		for(Int32 row = 0; row < MAP_ROWS; row++) {
			for(Int32 col = 0; col < MAP_COLS; col++) {
				for (Int32 i = 0; i < NUM_BITMASKS; i++) {
					bitmask = 1;
					for (Int32 j = 0; j < i; j++) 
						bitmask *= 2;
					if (::UMap[row][col] & bitmask) {
						if (bitmask == BITMASK_SPECIAL) {
							switch(::UMap[row][col] >> 10) {
							case 0:
								g->DrawImage(imageList->Images->Item[5], col * 32, row * 32, 32, 32);
								break;
							case 1:
								g->DrawImage(imageList->Images->Item[7], col * 32, row * 32, 32, 32);
								break;
							}
						} else {
							if ((::UMap[row][col] & BITMASK_EXPLOSION) == BITMASK_EXPLOSION)
								PlaySound(TEXT("Explosion.wav"), NULL, SND_FILENAME | SND_ASYNC);
							g->DrawImage(imageList->Images->Item[i], col * 32, row * 32, 32, 32);
						}
					}
				}
			}
		}
		e->Graphics->DrawImage(dynamic_cast<System::Drawing::Image __gc*>(bitmap), 0, 0);
		g->Dispose();
		bitmap->Dispose();
		e->Graphics->Dispose();
	}

	void toolBar_ButtonClick(Object __gc* sender, System::Windows::Forms::ToolBarButtonClickEventArgs __gc* e) {

		if (e->Button->Equals(toolBarButtonGameQuery))
			menuGameQuery_Click(sender, 0);
		else if (e->Button->Equals(toolBarButtonEndGame))
			menuExit_Click(sender, 0);
	}

	void BMForm_Closing(Object __gc* sender, System::ComponentModel::CancelEventArgs __gc* e) {
		//_endthread();	
	}
}; //BMFrom class

#pragma unmanaged
void MapConverter(const WholeMap* wm, int row, int col) {
	::UMap[row][col] = (*wm)(row, col);
};
#pragma managed

class EventPrinter : public EventSubscriber {
public:
	virtual void onWholeMap(const WholeMap* wm) {
		for (int row = 0; row < MAP_ROWS; row++) {
			for (int col = 0; col < MAP_COLS; col++) {
				::MapConverter(wm, row, col);
			}
		}

		GData::pBMForm->panel->Invalidate(false);
	}

	virtual void onGameOver(const GameOver* go) {
		MessageBox::Show(S"GameOver");
	}

	virtual void onUserJoined() {
		MessageBox::Show(S"User Joined");
	}

};

// Callback function for the thread.
void ProcessMapUpdates(PVOID pvoid) {
	EventPrinter ep; // callback object
	StreamRecord rec;
	ObjectDispatcher::instance()->subscribe(&ep); // register callback
	UDPClient stream(GData::port); // create client

	for(;;){
		try{
			stream >> rec; // get record
		}catch(Exception*){
		}
	}
	
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPTSTR lszCmdLine, int nCmdShow) {
	GData::pBMForm = new BMForm();
	Application::Run(GData::pBMForm);
	return 0;
}


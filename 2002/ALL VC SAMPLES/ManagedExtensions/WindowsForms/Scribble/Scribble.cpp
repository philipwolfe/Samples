#include "Scribble.h"
#include "ScribbleView.h"

 MainWindow::MainWindow()
    {        
		parentWindow = this;
		//
        // Required for Win Form Designer support
        //
        InitializeComponent();	
		documentCount=0;  
		CreateDocument();

        //
        // TODO: Add any constructor code after InitializeComponent call
        //
    }

	MainWindow::~MainWindow()
	{
		//components->Dispose();
	}

	void MainWindow::InitializeComponent()
	{
		components = new System::ComponentModel::Container();
		
		//menuItem12 = new MenuItem();
		printDoc = new Printing::PrintDocument();		
		printDoc->PrintPage += new PrintPageEventHandler(this, ScribblePrintPage);
			
		this->AutoScaleBaseSize =  System::Drawing::Size(5, 13);
		this->Text = "Scribble";
		//@design this.TrayLargeIcon = true;
		this->IsMdiContainer = true;
		//@design this.TrayHeight = 106;
		this->Menu = mainMenu;
		this->ClientSize =  System::Drawing::Size(600, 400);

		this->helpProvider1 = new System::Windows::Forms::HelpProvider();
		this->helpProvider1->HelpNamespace = S"Help\\scribble.chm";
		this->helpProvider1->SetShowHelp(this, true);		

//File
		newMenuItem		= new Windows::Forms::MenuItem(S"&New",new EventHandler(this, &MainWindow::MenuItemHandler));
		openMenuItem	= new Windows::Forms::MenuItem(S"&Open",	new EventHandler(this, &MainWindow::MenuItemHandler));
		closeMenuItem	= new Windows::Forms::MenuItem(S"&Close",	new EventHandler(this, &MainWindow::MenuItemHandler));
		saveMenuItem	= new Windows::Forms::MenuItem(S"&Save", 	new EventHandler(this, &MainWindow::MenuItemHandler));
		saveAsMenuItem	= new Windows::Forms::MenuItem(S"Save &As", new EventHandler(this, &MainWindow::MenuItemHandler));
		line1MenuItem	= new Windows::Forms::MenuItem(S"-");
		printMenuItem	= new Windows::Forms::MenuItem(S"&Print",new EventHandler(this, &MainWindow::MenuItemHandler));
		printPreviewMenuItem	= new Windows::Forms::MenuItem(S"P&rintPreview",new EventHandler(this, &MainWindow::MenuItemHandler));
		line2MenuItem	= new Windows::Forms::MenuItem(S"-");
		line3MenuItem	= new Windows::Forms::MenuItem(S"-");		
		exitMenuItem	= new Windows::Forms::MenuItem(S"E&xit",new EventHandler(this, &MainWindow::MenuItemHandler));

		Windows::Forms::MenuItem *rFileItems[] =
			new Windows::Forms::MenuItem *[10];

		rFileItems[0] = newMenuItem;
		rFileItems[1] = openMenuItem;
		rFileItems[2] = closeMenuItem;
		rFileItems[3] = saveMenuItem;
		rFileItems[4] = saveAsMenuItem;
		rFileItems[5] = line1MenuItem;
		rFileItems[6] = printMenuItem;
		rFileItems[7] = printPreviewMenuItem;
		rFileItems[8] = line2MenuItem;
		rFileItems[9] = exitMenuItem;

		
		fileMenuItem = new Windows::Forms::MenuItem(S"&File", rFileItems);
		

		//EDIT
		clearAllMenuItem = new Windows::Forms::MenuItem(S"Clear &All",new EventHandler(this, &MainWindow::MenuItemHandler));

		Windows::Forms::MenuItem *rEditItems[] =
			new Windows::Forms::MenuItem *[2];

		rEditItems[0] = clearAllMenuItem;
		rEditItems[1] = line3MenuItem;
		
		editMenuItem = new Windows::Forms::MenuItem(S"&Edit", rEditItems);

		//Pen
		thickLineMenuItem = new Windows::Forms::MenuItem(S"Thick Line",new EventHandler(this, &MainWindow::MenuItemHandler));
		penWidthMenuItem = new Windows::Forms::MenuItem(S"Pen Width",new EventHandler(this, &MainWindow::MenuItemHandler));

		Windows::Forms::MenuItem *rPenItems[] =
			new Windows::Forms::MenuItem *[2];

		rPenItems[0] = thickLineMenuItem;
		rPenItems[1] = penWidthMenuItem;

		penMenuItem = new Windows::Forms::MenuItem(S"Pen", rPenItems);

		//View
		
		toolbarMenuItem = new Windows::Forms::MenuItem(S"Toolbar",new EventHandler(this, &MainWindow::MenuItemHandler));
		toolbarMenuItem->Checked = true;
		statusbarMenuItem = new Windows::Forms::MenuItem(S"Statusbar",new EventHandler(this, &MainWindow::MenuItemHandler));
		statusbarMenuItem->Checked = true;
		Windows::Forms::MenuItem *rviewItems[] =
			new Windows::Forms::MenuItem *[2];

		rviewItems[0] = toolbarMenuItem;
		rviewItems[1] = statusbarMenuItem;

		viewMenuItem = new Windows::Forms::MenuItem(S"View", rviewItems);

		//Windows

		newWindowMenuItem = new Windows::Forms::MenuItem(S"New Window",new EventHandler(this, &MainWindow::MenuItemHandler));
		cascadeMenuItem = new Windows::Forms::MenuItem(S"Cascade",new EventHandler(this, &MainWindow::MenuItemHandler));
		tileMenuItem = new Windows::Forms::MenuItem(S"Tile",new EventHandler(this, &MainWindow::MenuItemHandler));

		Windows::Forms::MenuItem *rwindowItems[] =
			new Windows::Forms::MenuItem *[3];

		rwindowItems[0] = newWindowMenuItem;
		rwindowItems[1] = cascadeMenuItem;
		rwindowItems[2] = tileMenuItem;

		windowMenuItem = new Windows::Forms::MenuItem(S"Window", rwindowItems);


		//Help
		
		helpTopicsMenuItem = new Windows::Forms::MenuItem(S"Help Topics",new EventHandler(this, &MainWindow::MenuItemHandler));
		helpAboutMenuItem = new Windows::Forms::MenuItem(S"About Scribble",new EventHandler(this, &MainWindow::MenuItemHandler));

		Windows::Forms::MenuItem *rhelpItems[] =
			new Windows::Forms::MenuItem *[2];

		rhelpItems[0] = helpTopicsMenuItem;
		rhelpItems[1] = helpAboutMenuItem;

		helpMenuItem = new Windows::Forms::MenuItem(S"Help", rhelpItems);

		//MainMenu

		Windows::Forms::MenuItem *rMainItems[] = new Windows::Forms::MenuItem *[6];

		rMainItems[0] = fileMenuItem;
		rMainItems[1] = editMenuItem;
		rMainItems[2] = penMenuItem;
		rMainItems[3] = viewMenuItem;
		rMainItems[4] = windowMenuItem;
		rMainItems[5] = helpMenuItem;

		mainMenu = new MainMenu(rMainItems);
		Menu		= mainMenu;


		//toolbar and status bar
		statusBar1 = new Windows::Forms::StatusBar();
		statusBar1->TabIndex = 2;
		statusBar1->Text = "For Help,  press F1";

		helpButton	= new Windows::Forms::ToolBarButton();
		helpButton->ImageIndex = 5;
		helpButton->ToolTipText = "Help";

		printButton = new Windows::Forms::ToolBarButton();
		printButton->ImageIndex = 4;
		printButton->ToolTipText = "Print";

		previewButton = new Windows::Forms::ToolBarButton();
		previewButton->ImageIndex = 3;
		previewButton->ToolTipText = "Print Preview";
		
		saveButton = new Windows::Forms::ToolBarButton();
		saveButton->ImageIndex = 2;
		saveButton->ToolTipText = "Save";

	    openButton = new Windows::Forms::ToolBarButton();
		openButton->ImageIndex = 1;
		openButton->ToolTipText = "Open";

		newButton = new Windows::Forms::ToolBarButton();
		newButton->ImageIndex = 0;
		newButton->ToolTipText = "New";

		//System::Resources::ResourceManager* resources = new System::Resources::ResourceManager(Type::GetTypeFromHandle(Type::GetTypeHandle(parentWindow)));
		imageList1 = new Windows::Forms::ImageList();
		imageList1->ImageSize =  System::Drawing::Size(16, 16);
		imageList1->TransparentColor = System::Drawing::Color::Transparent;
		//imageList1->ImageStream = (System::Windows::Forms::ImageListStreamer*)resources->GetObject("imageList1.ImageStream");
		imageList1->Images->Add(Image::FromFile(S"Images\\new.bmp"));
		imageList1->Images->Add(Image::FromFile(S"Images\\open.bmp"));
		imageList1->Images->Add(Image::FromFile(S"Images\\save.bmp"));
		imageList1->Images->Add(Image::FromFile(S"Images\\preview.bmp"));
		imageList1->Images->Add(Image::FromFile(S"Images\\print.bmp"));
		imageList1->Images->Add(Image::FromFile(S"Images\\help.bmp"));
	
		toolBar1= new Windows::Forms::ToolBar();
		toolBar1->ImageList = imageList1;
		toolBar1->DropDownArrows = true;
		toolBar1->ShowToolTips = true;
		System::Windows::Forms::ToolBarButton* rToolbarButtons[]=new System::Windows::Forms::ToolBarButton*[6];
		rToolbarButtons[0]=newButton;
		rToolbarButtons[1]=openButton;
		rToolbarButtons[2]=saveButton;
		rToolbarButtons[3]=previewButton;
		rToolbarButtons[4]=printButton;
		rToolbarButtons[5]=helpButton;

		toolBar1->Buttons->AddRange(rToolbarButtons);	
		toolBar1->ButtonClick += new System::Windows::Forms::ToolBarButtonClickEventHandler(this,&MainWindow::ToolbarHandler);

		Control *rControls[] = new Control *[2];

		rControls[0] = statusBar1;
		rControls[1] = toolBar1;
		//SetNewControls(rControls);
		this->Controls->AddRange(rControls);
		

	}
	
	void MainWindow::MenuItemHandler(Object* sender, EventArgs* e)
	{
		if(sender->Equals(newMenuItem))
		{
			New();
		}
		else if(sender->Equals(openMenuItem))
		{
			Open();
		}
		else if(sender->Equals(saveMenuItem))
		{
			Save();
		}
		else if(sender->Equals( printPreviewMenuItem))
		{
			PrintPreview();
		}
		else if(sender->Equals( printMenuItem))
		{
			Print();
		}
		else if(sender->Equals( helpAboutMenuItem))
		{
			AboutHelp();
		}
		else if(sender->Equals( exitMenuItem))
		{
			Exit();
		}
		else if(sender->Equals( closeMenuItem))
		{
			CloseView();
		}
		else if(sender->Equals( tileMenuItem))
		{
			Tile();
		}
		else if(sender->Equals( cascadeMenuItem))
		{
			Cascade();
		}
		else if(sender->Equals( clearAllMenuItem))
		{
			ClearAll();
		}
		else if(sender->Equals( saveAsMenuItem))
		{
			Save();
		}
		else if(sender->Equals( newWindowMenuItem))
		{
			NewWindow();
		}
		else if(sender->Equals( penWidthMenuItem))
		{
			PenWidthsDlg();
		}
		else if(sender->Equals( thickLineMenuItem))
		{
			ThickLine();			
		}
		else if(sender->Equals( helpTopicsMenuItem))
		{
			HelpTopics();			
		}
		else if(sender->Equals( toolbarMenuItem))
		{
			toolBar1->Visible  =  !toolBar1->Visible ;
			toolbarMenuItem->Checked  = toolBar1->Visible;
		}
		else if(sender->Equals( statusbarMenuItem))
		{
			statusBar1->Visible = !statusBar1->Visible;			
			statusbarMenuItem->Checked = statusBar1->Visible;
		}
	}


	void MainWindow::ToolbarHandler(Object* sender, ToolBarButtonClickEventArgs* e)
	{
		// Evaluate the Button property to determine which button was clicked.
		switch (this->toolBar1->Buttons->IndexOf(e->Button))
		{
        case 0:
            New();
            break;
        case 1:
            Open();
            break;
        case 2:
            Save();
            break;
		case 3:
            PrintPreview();
            break;
		case 4:
            Print();
            break;
		case 5:
            HelpTopics();
            break;
		default:
			break;		
		}
	}
	//About Scribble
	void MainWindow::AboutHelp()
	{
		MessageBox::Show(S"Scribble Version 1.0", S"About Scribble");
	}

	//Help Topics
	void MainWindow::HelpTopics()
	{
		Help::ShowHelp(this,S"help\\scribble.chm");
	}

	//Print
	void MainWindow::Print()
	{		
		try 
		{			
			printDoc->Print();
		} 
		catch(Exception* e)
		{
			MessageBox::Show(e->ToString());
		}
	}

	//PrintPage 
	void MainWindow::ScribblePrintPage(Object* sender, PrintPageEventArgs* printEv)
	{
		try{
			ScribbleView* activeView = dynamic_cast<ScribbleView*>(this->ActiveMdiChild);
			ScribbleDoc* activeDoc = activeView->GetDocument();	

			for(int i=0; i < activeDoc->strokeList->Count; i++)
			{
				Stroke* st = dynamic_cast<Stroke*>(activeDoc->strokeList->Item[i]);
				st->DrawStroke(printEv->Graphics) ;
			}
			printEv->HasMorePages = false;
		}

		catch (Exception* ex)
		{
			MessageBox::Show(ex->ToString());
		}
	}

	//PrintPreview
	void MainWindow::PrintPreview()
{
	try {
		PrintPreviewDialog* prevDlg = new PrintPreviewDialog();
		prevDlg->Document = printDoc;
		prevDlg->Size = System::Drawing::Size(600, 329);
		prevDlg->ShowDialog();
	}
	catch(Exception* ex)
	{
		MessageBox::Show(ex->ToString());
	}
}


//Exit
void MainWindow::Exit()
{
	Form* childForm[] = this->MdiChildren ;
	//Make sure to ask for saving the doc before exiting the app
	for(int i=0; i < childForm->Length ; i++)
		childForm[i]->Close();

		Application::Exit();
}

//Close
void MainWindow::CloseView()
{
	ScribbleView* activeView = dynamic_cast<ScribbleView*> (this->ActiveMdiChild);
	activeView->Close();	
}

//Tile_Click
void MainWindow::Tile()
{
	this->LayoutMdi(MdiLayout::TileHorizontal);	
}

//Cascade_Click
void MainWindow::Cascade()
{
	this->LayoutMdi(MdiLayout::Cascade);	
}

//ClearAll
void MainWindow::ClearAll()
{
	ScribbleView* activeView = dynamic_cast<ScribbleView*> (this->ActiveMdiChild);
	if(activeView)
	{
		ScribbleDoc* activeDoc = activeView->GetDocument();
		activeDoc->DeleteContents();
	}
}

//Open
void MainWindow::Open()
{
	OpenFileDialog* openDlg = new OpenFileDialog();
	openDlg->Filter = "Scribble Files (*.scb)|*.scb|All Files (*.*)|*.*";
	openDlg->FileName = "" ;
	openDlg->DefaultExt = ".scb";
	openDlg->CheckFileExists = true;
	openDlg->CheckPathExists = true;
		
	int res = openDlg->ShowDialog ();
	
	if(res == DialogResult::OK)
	{
		if( !(openDlg->FileName)->EndsWith(".scb") && !(openDlg->FileName)->EndsWith(".SCB")) 
			MessageBox::Show("Unexpected file format","Scribble",MessageBoxButtons::OK );
		else
		{
			ScribbleDoc* newDoc = CreateDocument();
			newDoc->OpenDocument(openDlg->FileName);
		}
	}		

}

//Save
void MainWindow::Save()
{
	try {
		ScribbleView* selectedView = dynamic_cast<ScribbleView*>(this->ActiveMdiChild);
		SaveFileDialog* saveDlg = new SaveFileDialog();
		saveDlg->Filter = "Scribble Files (*.scb)|*.scb|All Files (*.*)|*.*";
		saveDlg->DefaultExt = ".scb";
		saveDlg->FileName = "Scribb1.scb";
		int res = saveDlg->ShowDialog ();
		
		if(res == DialogResult::OK)
		{
			if(selectedView)
			{
				ScribbleDoc* doc = selectedView->GetDocument();
				doc->SaveDocument(saveDlg->FileName);	
			}			
		}
	}
	catch(Exception* ex)
	{
		MessageBox::Show(ex->ToString());
	}
}

//New
void MainWindow::New()
{
	//If this is the first child window, enable the Menu and Toolbar items
	if(!this->ActiveMdiChild)
		EnableItems();
	CreateDocument();
}

//NewWindow
void MainWindow::NewWindow()
{
	ScribbleView* activeView = dynamic_cast<ScribbleView*>(this->ActiveMdiChild);
	ScribbleView* newView = new ScribbleView(activeView->GetDocument(),parentWindow);
	newView->GetDocument()->viewList->Add(newView);
	newView->Show();	
}

	//ThickLine
	void MainWindow::ThickLine()
	{		 
		ScribbleView* activeView = dynamic_cast<ScribbleView*> (this->ActiveMdiChild);
		ScribbleDoc* activeDoc = activeView->GetDocument();
		activeDoc->thickPen = !activeDoc->thickPen;
		activeDoc->ReplacePen();
		this->thickLineMenuItem->Checked = activeDoc->thickPen;
	}

	 //PenWidthDlg
	 void MainWindow::PenWidthsDlg()
	 {
		 Form* f = new Form();

		//Get the document of active view
		ScribbleView* activeView = dynamic_cast<ScribbleView*> (this->ActiveMdiChild);
		ScribbleDoc* activeDoc = activeView->GetDocument();

		f->AutoScaleBaseSize =  System::Drawing::Size(5, 13);
		f->Text = "Pen Widths";
		
		f->ClientSize =  System::Drawing::Size(352, 125);
		
		Button* button1 = new Button();
		button1->Location =  System::Drawing::Point(264, 20);
		button1->Size =  System::Drawing::Size(75, 23);
		button1->TabIndex = 1;
		button1->Text = "OK";
		button1->DialogResult  = System::Windows::Forms::DialogResult::OK ;//Make this "OK" button

		Button* button2 = new Button();
		button2->Location =  System::Drawing::Point(264, 52);
		button2->Size =  System::Drawing::Size(75, 23);
		button2->TabIndex = 6;
		button2->Text = "Cancel";
		
		TextBox* textBox1 = new TextBox();		
		textBox1->Location =  System::Drawing::Point(120, 36);
		textBox1->Text = activeDoc->thinWidth.ToString();
		textBox1->TabIndex = 1;
		textBox1->Size =  System::Drawing::Size(64, 20);

		TextBox* textBox2 = new TextBox();		
		textBox2->Location =  System::Drawing::Point(120, 76);
		textBox2->Text = activeDoc->thickWidth.ToString();
		textBox2->TabIndex = 2;
		textBox2->Size =  System::Drawing::Size(64, 20);
		
		
		Label* label1 = new Label();
		label1->Location =  System::Drawing::Point(16, 36);
		label1->Text = "Thin Pen Width:";
		label1->Size =  System::Drawing::Size(88, 16);
		label1->TabIndex = 3;
		
		Label* label2 = new Label();
		label2->Location =  System::Drawing::Point(16, 76);
		label2->Text = "Thick Pen Width:";
		label2->Size =  System::Drawing::Size(88, 16);
		label2->TabIndex = 4;		
		

		f->FormBorderStyle = FormBorderStyle::FixedDialog;
		// Set the MaximizeBox to false to remove the maximize box.
		f->MaximizeBox = false;
		// Set the MinimizeBox to false to remove the minimize box.
		f->MinimizeBox = false;
		// Set the accept button of the form to button1.
		f->AcceptButton = button1;
		// Set the cancel button of the form to button2.
		f->CancelButton = button2;
		
		f->StartPosition = FormStartPosition::CenterScreen;		
		
		f->Controls->Add(button1);
		f->Controls->Add(button2);
		f->Controls->Add(label1);
		f->Controls->Add(label2);
		f->Controls->Add(textBox1);  
		f->Controls->Add(textBox2);			
			
		System::Windows::Forms::DialogResult res = f->ShowDialog();
				
		if(res == System::Windows::Forms::DialogResult::OK )
		{			
			activeDoc->thinWidth = UInt32::Parse(textBox1->Text);
			activeDoc->thickWidth = UInt32::Parse(textBox2->Text);
			activeDoc->ReplacePen();
			f->Close();
		}			
	 }

	 //Disable the menu and toolbar items when there is no active child form
	 void MainWindow::DisableItems()
	{
		this->editMenuItem->Visible=false;
		this->penMenuItem->Visible=false;
		this->windowMenuItem->Visible=false;
		this->closeMenuItem->Visible=false;
		this->saveAsMenuItem->Visible=false;
		this->saveAsMenuItem->Visible=false;
		this->printMenuItem->Visible=false;
		this->printPreviewMenuItem->Visible=false;
		this->saveButton->Enabled = false;
		this->previewButton->Enabled=false;
		this->printButton->Enabled=false;
					
	}

	//Enable the menu and toolbar items when the first child form is created
	void MainWindow::EnableItems()
	{
		this->editMenuItem->Visible=true;
		this->penMenuItem->Visible=true;
		this->windowMenuItem->Visible=true;
		this->closeMenuItem->Visible=true;
		this->saveAsMenuItem->Visible=true;
		this->saveAsMenuItem->Visible=true;
		this->printMenuItem->Visible=true;
		this->printPreviewMenuItem->Visible=true;
		this->saveButton->Enabled = true;
		this->previewButton->Enabled=true;
		this->printButton->Enabled=true;
					
	}
	 
	
	 //Creates a new document
	 ScribbleDoc* MainWindow::CreateDocument()
	{
		ScribbleDoc* newDoc = new ScribbleDoc (parentWindow);
		documentCount++;
		return newDoc;
	}


void main()
{
	Application::Run(new MainWindow());
}


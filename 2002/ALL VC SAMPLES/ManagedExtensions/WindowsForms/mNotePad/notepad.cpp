//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.

#pragma warning(disable:4100 4101)


#using<mscorlib.dll>
using namespace System;

#using <System.DLL>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.DLL>

using namespace System::IO;
using namespace System::Drawing;
using namespace System::Windows::Forms;

#define null 0L

__gc class mNotepad : public Form
{
	static String* s_strAppName = S"Managed C++ Notepad";
public:
	// constructor
	mNotepad() : m_bFileOpen(false)
	{
		InitForm(); 	
	}
	
	// destructor
	virtual ~mNotepad()
	{
	}

private:
	bool OnResetModifedBuffer()
	{
		if(!(m_pTextBox->Modified)) // nothing to save
			return true;

		String* strFile = m_pFileName ? m_pFileName : S"Untitled";
		
		switch( MessageBox::Show(String::Concat( S"The text in the ", strFile, S" file has changed.\n\nDo you want to save the changes?"), s_strAppName, MessageBoxButtons::YesNoCancel ) )
		{
			case DialogResult::Cancel: return false;
			case DialogResult::Yes: FileMenuSave(null, null);
			case DialogResult::No: return true;
			default : return false;
		};
	};

	void HelpMenuAbout(Object * pSender, EventArgs * pArgs)
	{
		MessageBox::Show(S"Version 1.0", s_strAppName);
	}

	void FileMenuNew(Object * pSender, EventArgs * pArgs)
	{
		if( !OnResetModifedBuffer() )
			return;

		m_pTextBox->Text = S"";
		m_pTextBox->Select(0,0);
			
		m_bFileOpen = false;

		//
		// Set the application's caption  
		//
		Text = String::Concat(S"Untitled - ", s_strAppName );
		m_pTextBox->Modified = false;

	}

	void FileMenuOpen(Object * pSender, EventArgs * pArgs)
	{
		if( !OnResetModifedBuffer() )
			return;
		//
		// Create an Open File dialog box	
		//
		OpenFileDialog * pOFD = new OpenFileDialog();

		//
		// Set up filters and options
		//
		pOFD->Filter = S"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		pOFD->DefaultExt = S"txt";

		//
		// Run the Open File dialog box
		//
		int nResult = pOFD->ShowDialog();

		//
		// Check result of dialog box after it closes
		//
		if (nResult == DialogResult::OK)
		{
			//
			// Retrieve the filename(s) entered 
			//
			String* rNames[] = pOFD->FileNames;

			if (rNames->Length != 1)
			{
				MessageBox::Show( S"You can only select one file", s_strAppName );
				return;
			}

			m_pFileName = rNames[0];

			//
			// Open a File stream on that filename 
			//
			m_pFileStream = new FileStream(m_pFileName,FileMode::Open, FileAccess::Read); 
			StreamReader *pReader = new StreamReader(m_pFileStream);

			//
			// Retrieve length of file
			//
			if( m_pFileStream->Length > 0x100000000 )
			{
				MessageBox::Show( S"File is too big for this app!", s_strAppName );
				FileMenuNew(pSender,pArgs);
				return;
			}


			//
			// Read in ANSI characters to edit buffer
			//
			m_pTextBox->Text = pReader->ReadToEnd();
			// Reset the selection
			m_pTextBox->Select(0,0);
				
			//
			// Close the file handle
			//
			pReader->Close();
			m_pFileStream->Close();

			m_bFileOpen = true;

			//
			// Set the application's caption  
			//
			Text = String::Concat(m_pFileName, S" - ", s_strAppName );
			m_pTextBox->Modified = false;
		}
	}

	void FileMenuSave(Object *pSender, EventArgs *pArgs)
	{
		//
		// If there has been a file opened or saved
		//
		try
		{
		if (m_bFileOpen)
		{
			//
			// Open the current file again
			//
			m_pFileStream = new FileStream(m_pFileName, FileMode::Create, FileAccess::Write); 

			WriteToFile();

			m_pFileStream->Close();
			m_pTextBox->Modified = false;

		}
		else
		{
			FileMenuSaveAs(pSender, pArgs);
		}
		}
		catch(Exception* pE)
		{
			MessageBox::Show(String::Concat(pE->ToString(),S"\nFile won\'t be saved!"),
				String::Concat(S"Following exception was thrown trying to save ",m_pFileName), MessageBoxButtons::OK);			
		}
	}

	void FileMenuSaveAs(Object *pSender, EventArgs *pArgs)
	{
		//
		// Create a SaveFileDialog
		//
		SaveFileDialog *pSFD = new SaveFileDialog();

		//
		// Set the options	
		//
		pSFD->FileName = m_pFileName;
		pSFD->Title = S"Save Text File";
		pSFD->Filter = S"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
		pSFD->DefaultExt = S"cpp";

		//
		// Run the dialog box	  
		//
		int nResult = pSFD->ShowDialog();

		if (nResult == DialogResult::OK) {
			//
			// Retrieve the filename entered in the dialog box
			//
			m_pFileName = pSFD->FileName;

			//
			// Open a File stream with ability to create a file if needed
			//
			try {
				m_pFileStream = new FileStream(m_pFileName, FileMode::CreateNew, FileAccess::Write);
			}
			catch (FileNotFoundException *pE) {
				MessageBox::Show(S"Error: Can\'t save file!", m_pFileName);
			}

			//
			// Write the TextBoxBox contents to the file
			//
			WriteToFile();

			m_bFileOpen = true;

			//
			// Set the app's caption using the filename minus its path 
			//
			Text = String::Concat(m_pFileName, S" - ", s_strAppName );
			m_pTextBox->Modified = false;
		}
	}

	void FileMenuExit(Object *pSender, EventArgs *pArgs)
	{
		//
		// Call the new file handler to invoke NewDialog
		// to ask if user wants to save current data 
		//
		if( !OnResetModifedBuffer() )
			return;
		Application::Exit();
	}

	void EditMenuUndo(Object *pSender, EventArgs *pArgs)
	{
		m_pTextBox->Undo();
	};

	void EditMenuCut(Object *pSender, EventArgs *pArgs)
	{
		m_pTextBox->Cut();
	};

	void EditMenuCopy(Object *pSender, EventArgs *pArgs)
	{
		m_pTextBox->Copy();
	};

	void EditMenuPaste(Object *pSender, EventArgs *pArgs)
	{
		m_pTextBox->Paste();
	};

	void EditMenuSelectAll(Object *pSender, EventArgs *pArgs)
	{
		m_pTextBox->SelectAll();
	};

	void WriteToFile() {
		//
		// Create a Stream Writer
		//
		StreamWriter *	pWriter	= new StreamWriter(m_pFileStream);

		//
		// How many characters do we need to write?
		//
		int nLength = m_pTextBox->Text->Length;

		//
		// Write edit control contents to file
		//
		pWriter->Write(m_pTextBox->Text->ToCharArray(), 0, nLength);

		//
		// Close the stream
		//
		pWriter->Close();
	}

	void InitForm()
	{
		m_pFileMenuNew = new MenuItem(S"&New",
			new EventHandler(this, &mNotepad::FileMenuNew));
		m_pFileMenuOpen = new MenuItem(S"&Open",
			new EventHandler(this, &mNotepad::FileMenuOpen));
		m_pFileMenuSave	= new MenuItem(S"&Save", 
			new EventHandler(this, &mNotepad::FileMenuSave));
		m_pFileMenuSaveAs = new MenuItem(S"Save &As", 
			new EventHandler(this, &mNotepad::FileMenuSaveAs));
		m_pFileMenuExit	= new MenuItem(S"E&xit", 
			new EventHandler(this, &mNotepad::FileMenuExit));

		MenuItem *rFileItems[] =
			new MenuItem *[5];

		rFileItems[0] = m_pFileMenuNew;
		rFileItems[1] = m_pFileMenuOpen;
		rFileItems[2] = m_pFileMenuSave;
		rFileItems[3] = m_pFileMenuSaveAs;
		rFileItems[4] = m_pFileMenuExit;

		m_pEditMenuUndo = new MenuItem(S"Undo\tCtrl-Z",
			new EventHandler(this, &mNotepad::EditMenuUndo));
		m_pEditMenuCut = new MenuItem(S"Cut\tCtrl-X",
			new EventHandler(this, &mNotepad::EditMenuCut));
		m_pEditMenuCopy = new MenuItem(S"&Copy\tCtrl-C",
			new EventHandler(this, &mNotepad::EditMenuCopy));
		m_pEditMenuPaste = new MenuItem(S"Paste\tCtrl-V",
			new EventHandler(this, &mNotepad::EditMenuPaste));
		m_pEditMenuSelectAll = new MenuItem(S"Select &All",
			new EventHandler(this, &mNotepad::EditMenuSelectAll));

		MenuItem *rEditItems[] =
			new MenuItem *[5];

		rEditItems[0] = m_pEditMenuUndo;
		rEditItems[1] = m_pEditMenuCut;
		rEditItems[2] = m_pEditMenuCopy;
		rEditItems[3] = m_pEditMenuPaste;
		rEditItems[4] = m_pEditMenuSelectAll;

		m_pHelpMenuAbout = new MenuItem(S"&About ...",
			new EventHandler(this, &mNotepad::HelpMenuAbout));

		MenuItem *rHelpItems[] = new MenuItem *[1];

		rHelpItems[0] = m_pHelpMenuAbout;

		m_pFileMenu = new MenuItem(S"&File", rFileItems);
		m_pEditMenu = new MenuItem(S"&Edit", rEditItems);
		m_pHelpMenu = new MenuItem(S"&Help", rHelpItems);

		MenuItem *rMainItems[] = new MenuItem *[3];

		rMainItems[0] = m_pFileMenu;
		rMainItems[1] = m_pEditMenu;
		rMainItems[2] = m_pHelpMenu;

		m_pMenu = new MainMenu(rMainItems);

		Bounds		= Rectangle(100, 100, 300, 300);
		Visible		= false;
		ClientSize	= System::Drawing::Size(400, 600);

		Menu		= m_pMenu;

		m_pTextBox = new TextBox();

		m_pTextBox->Dock = DockStyle::Fill;
		m_pTextBox->Font = new System::Drawing::Font( new FontFamily( S"Times New Roman"), 10.0f );
		m_pTextBox->Size = System::Drawing::Size(300, 600);
		m_pTextBox->TabIndex = 1;
		m_pTextBox->Multiline = true;
		m_pTextBox->ScrollBars = ScrollBars::Both;
		FileMenuNew(null, null);

		Control *rControls[] = new Control *[1];

		rControls[0] = m_pTextBox;

		this->Controls->AddRange(rControls);
	}

private:
	MainMenu * m_pMenu;
	MenuItem * m_pFileMenu;
	MenuItem * m_pFileMenuNew;
	MenuItem * m_pFileMenuOpen;
	MenuItem * m_pFileMenuSave;
	MenuItem * m_pFileMenuSaveAs;
	MenuItem * m_pFileMenuExit;
	MenuItem * m_pHelpMenu;
	MenuItem * m_pHelpMenuAbout;
	MenuItem * m_pEditMenu;
	MenuItem * m_pEditMenuUndo;
	MenuItem * m_pEditMenuCut;
	MenuItem * m_pEditMenuCopy;
	MenuItem * m_pEditMenuPaste;
	MenuItem * m_pEditMenuSelectAll;
	TextBox * m_pTextBox;

	FileStream * m_pFileStream;	// The I/O file stream	
	String * m_pFileName;		// The most recently-used file name
	bool m_bFileOpen;			// Set true after file opened
};

int main()
{
	System::Threading::Thread::CurrentThread->ApartmentState = System::Threading::ApartmentState::STA;
	Application::Run(new mNotepad());
	return 0;
}

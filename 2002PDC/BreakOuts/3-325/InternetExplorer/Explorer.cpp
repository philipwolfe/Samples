//===========================================================================
//	File:		Explorer.cpp
//
//	Summary:	Automate Internet Explorer from managed code
//				Sinking events fired by Internet Explorer.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================


#using <mscorlib.dll>
#using "SHDOCVW.dll"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace SHDocVw;

#define null 0

__gc public class Explorer
{
public:
	void Run()
	{
		Object * pO = null;
		String * pS;

		try
		{
			// start the browser
			m_pIExplorer = new SHDocVw::InternetExplorer();
		}
		catch(Exception * pe)
		{
			Console::WriteLine("Exception when creating IE object {0}", pe->ToString());
			return;
		}

		// Set the events
		SetAllEvents();
		Console::WriteLine("Created the object");

		try
		{	
			// go to home page
			m_pWebBrowser = dynamic_cast<IWebBrowserApp *>(m_pIExplorer);
			m_pWebBrowser->Visible = true;
			m_pWebBrowser->GoHome();


			// start navigating to different urls
			Console::Write("Enter URL (or enter to quit): ");		
			pS = Console::ReadLine();
			while (!pS->Equals("") && m_pIExplorer != null && m_pWebBrowser != null)
			{
				m_pWebBrowser->Navigate(pS, pO, pO, pO, pO);
				Console::WriteLine("Enter URL (or enter to quit): ");
				Console::WriteLine("Enter URL (or enter to quit): ");
				pS = Console::ReadLine();
			}

			m_pWebBrowser->Quit();
		}
		catch(Exception * pE)
		{
			if (m_pIExplorer == null && m_pWebBrowser == null)
			{
				Console::WriteLine("IE has gone away");
			}
			else
			{
				Console::WriteLine("Exception happens {0}", pE->ToString());
			}
		}

	}

	void SetAllEvents()
	{
		if (m_pIExplorer != null)
		{
			//1.Navigate Complete event
			DWebBrowserEvents2_NavigateComplete2EventHandler * pNcd
				= new DWebBrowserEvents2_NavigateComplete2EventHandler(null, &Explorer::OnNavigateComplete);
			m_pIExplorer->AddEventNavigateComplete2(pNcd);
	
			//2.Quit Event
			DWebBrowserEvents2_OnQuitEventHandler * pDQuitE 
				= new DWebBrowserEvents2_OnQuitEventHandler(null, &Explorer::OnQuit);
			m_pIExplorer->AddEventOnQuit(pDQuitE);

			//3.Statusbar text changed event
			DWebBrowserEvents2_StatusTextChangeEventHandler * pDStatusE
				= new DWebBrowserEvents2_StatusTextChangeEventHandler(null, &Explorer::OnStatusTextChange);
			m_pIExplorer->AddEventStatusTextChange(pDStatusE);

			//4.Fired when download progress is updated.
			DWebBrowserEvents2_ProgressChangeEventHandler * pDProgressE
				= new DWebBrowserEvents2_ProgressChangeEventHandler(null, &Explorer::OnProgressChange);
			m_pIExplorer->AddEventProgressChange(pDProgressE);

			//5.Command State change event
			DWebBrowserEvents2_CommandStateChangeEventHandler * pDCommandE
				= new DWebBrowserEvents2_CommandStateChangeEventHandler(null, &Explorer::OnCommandStateChange);
			m_pIExplorer->AddEventCommandStateChange(pDCommandE);

			//6.DownLoad begin
			DWebBrowserEvents2_DownloadBeginEventHandler * pDDownLoadStartE
				= new DWebBrowserEvents2_DownloadBeginEventHandler(null, &Explorer::OnDownloadBegin);
			m_pIExplorer->AddEventDownloadBegin(pDDownLoadStartE);

			//7.DownLoad begin
			DWebBrowserEvents2_DownloadCompleteEventHandler * pDDownLoadEndE
				= new DWebBrowserEvents2_DownloadCompleteEventHandler(null, &Explorer::OnDownloadComplete);
			m_pIExplorer->AddEventDownloadComplete(pDDownLoadEndE);

			//8.Title Change
			DWebBrowserEvents2_TitleChangeEventHandler * pDTitleChangeE
				= new DWebBrowserEvents2_TitleChangeEventHandler(null, &Explorer::OnTitleChange);
			m_pIExplorer->AddEventTitleChange(pDTitleChangeE);

			//9.Property change
			DWebBrowserEvents2_PropertyChangeEventHandler * pDPropertyChangeE
				= new DWebBrowserEvents2_PropertyChangeEventHandler(null, &Explorer::OnPropertyChange);
			m_pIExplorer->AddEventPropertyChange(pDPropertyChangeE);

			//10.Before navigate
			DWebBrowserEvents2_BeforeNavigate2EventHandler * pDBeforeNavigateE
				= new DWebBrowserEvents2_BeforeNavigate2EventHandler(null, &Explorer::OnBeforeNavigate2);
			m_pIExplorer->AddEventBeforeNavigate2(pDBeforeNavigateE);

			//11.Document complete
			DWebBrowserEvents2_DocumentCompleteEventHandler * pDDocumentCompleteE
				= new DWebBrowserEvents2_DocumentCompleteEventHandler(null, &Explorer::OnDocumentComplete);
			m_pIExplorer->AddEventDocumentComplete(pDDocumentCompleteE);

			//12.Creating a new window
			DWebBrowserEvents2_NewWindow2EventHandler * pDNewWindowE
				= new DWebBrowserEvents2_NewWindow2EventHandler(null, &Explorer::OnNewWindow2);
			m_pIExplorer->AddEventNewWindow2(pDNewWindowE);

			//13.Full Screen
			DWebBrowserEvents2_OnFullScreenEventHandler * pDFullScreenE
				= new DWebBrowserEvents2_OnFullScreenEventHandler(null, &Explorer::OnFullScreen);
			m_pIExplorer->AddEventOnFullScreen(pDFullScreenE);

			//14.Menubar change
			DWebBrowserEvents2_OnMenuBarEventHandler * pDMenuBarE
				= new DWebBrowserEvents2_OnMenuBarEventHandler(null, &Explorer::OnMenuBar);
			m_pIExplorer->AddEventOnMenuBar(pDMenuBarE);

			//15.Toolbar change
			DWebBrowserEvents2_OnToolBarEventHandler * pDToolBarE
				= new DWebBrowserEvents2_OnToolBarEventHandler(null, &Explorer::OnToolBar);
			m_pIExplorer->AddEventOnToolBar(pDToolBarE);

			//16.Visibility change
			DWebBrowserEvents2_OnVisibleEventHandler * pDOnVisibleE
				= new DWebBrowserEvents2_OnVisibleEventHandler(null, &Explorer::OnVisible);
			m_pIExplorer->AddEventOnVisible(pDOnVisibleE);

			//17.Threat Mode
			DWebBrowserEvents2_OnTheaterModeEventHandler * pDTheaterE
				= new DWebBrowserEvents2_OnTheaterModeEventHandler(null, &Explorer::OnTheaterMode);
			m_pIExplorer->AddEventOnTheaterMode(pDTheaterE);

		 }

		}

		///////////////////////////////////////////////////////////////////////////////////////
		//event handlers are below
		//1.NavigateComplete Event
		static void OnNavigateComplete(Object __gc * po1, Object __gc * & po2)
		{
			Console::WriteLine("Navigate complete");
		}

		//2.Quit event
		static void OnQuit()
		{
			Console::WriteLine("Internet explorer is quiting");
			m_pIExplorer = null;
			m_pWebBrowser = null;
		}

		//3.Statusbar text changed
		static void OnStatusTextChange(String * pSIn)
		{
			Console::WriteLine("Status text changed with {0}", pSIn);
		}

		//4.Fired when download progress is updated.
		static void OnProgressChange(int Progress, int ProgressMax)
		{
			Console::WriteLine("Progress change");
			Console::WriteLine(Progress);
			Console::WriteLine(ProgressMax);
		}

		//5.The enabled state of a command changed.
		static void OnCommandStateChange(int Command, bool Enable)
		{
			//Console::WriteLine("Command State change : Command = {0}, Enable = {1}", Command, Enable);
		}

        //6.Download of a page started
		static void OnDownloadBegin()
		{
			Console::WriteLine("Download begins now");
		}

        //7.Download of page complete
		static void OnDownloadComplete()
		{
			Console::WriteLine("Download completes");
		}

        //8.Document title changed
		static void OnTitleChange(String * pText)
		{
			Console::WriteLine("Title changes to {0}", pText);
		}

		//9.Fired when the PutProperty method has been called.
		static void OnPropertyChange(String * pszProperty)
		{
			Console::WriteLine("Property {0} changed", pszProperty);
		}
	
		//10.Fired before navigate occurs in the given WebBrowser (window or
		//   frameset element). The processing of this navigation may be modified
        static void OnBeforeNavigate2(Object __gc * ob1, Object __gc * & URL, Object __gc * &Flags, Object __gc * &TargetFrameName, 
									  Object __gc * &PostData, Object __gc * &Headers, bool & Cancel)
		{
			Console::WriteLine("Before Navigate2");
			m_nCounter += 1;
			if (m_nCounter >= 10)
			{
				//Console::WriteLine("Counter is {0}. Refuse to navigate to the site", m_nCounter);
				Cancel = true;
				m_nCounter = 0;
			}
			else
			{
				//Console::WriteLine("Counter is {0}. Permit to navigate to the site", m_nCounter);
				Cancel = false;
			}			

		}
			
		//11.Fired when document complete
		static void OnDocumentComplete(Object __gc * o, Object __gc * & ro)
		{
			Console::WriteLine("Document complete");
		}

		//12.Fired when creating new window
		static void OnNewWindow2(Object __gc * & o, bool & rb)
		{
			Console::WriteLine("New window");
		}
		
		//13.Fired when Fullscreen
		static void OnFullScreen(bool b)
		{
			if (b)
				Console::WriteLine("Full Screen");
			else
				Console::WriteLine("Not full screen");
		}

		//14.Fired when menubar change
		static void OnMenuBar(bool b)
		{
			if (b)
				Console::WriteLine("Menu bar visible");
			else
				Console::WriteLine("MenuBar invisible");
		}

		//15.Fired when Toolbar change
		static void OnToolBar(bool b)
		{
			if (b)
				Console::WriteLine("Toolbar visible");
			else
				Console::WriteLine("ToolBar invisible");
		}

		//16.Fired when Visible
		static void OnVisible(bool b)
		{
			if (b)
				Console::WriteLine("Visible");
			else
				Console::WriteLine("Invisible");
		}

		//17.Theater Mode
		static void OnTheaterMode(bool b)
		{
			if (b)
				Console::WriteLine("Theater Mode");
			else
				Console::WriteLine("Not Threater mode");
		}

		///////////////////////////////////////////////////////////////////////////////////////

		//These are class data members
	private:
		static SHDocVw::InternetExplorer * m_pIExplorer = null;
		static IWebBrowserApp * m_pWebBrowser = null;
		static int m_nCounter = 0;

	
};



void main()
{
	Explorer * pExplorer = null;

	try
	{
		pExplorer = new Explorer();
	}
	catch(Exception * pE)
	{
		Console::WriteLine("Exception", pE->ToString());
		return;
	}

	pExplorer->Run();
}
		


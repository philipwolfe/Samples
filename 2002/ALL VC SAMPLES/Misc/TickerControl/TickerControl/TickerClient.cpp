// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

// Add it to get an access to .NET Fframework classes.
#using <mscorlib.dll>
#using <System.dll>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.dll>

// Import Ticker control information.
#using "TickerControl.dll"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// Class that implements simple windows form.
__gc class CTickerClientForm : public Form
{
	// Constructor.
public:
	CTickerClientForm()
	{
		// Create ticker control.
		ctrlTicker = new CTickerControl();

		InitForm();
	}

	// Initialises a form.
protected:
	void InitForm()
	{
		// Set window title and size.
		this->set_Text(S"Ticker");
		this->set_Size(System::Drawing::Size(400, 300));

		// Set control location and size on the form.
		ctrlTicker->set_Location(System::Drawing::Point(30, 100));
		ctrlTicker->set_Size(System::Drawing::Size(300, 100));

		// Set ticker properties and start ticker to move.
		ctrlTicker->set_TimerInterval(10);
//		ctrlTicker->set_TickerText(S"This is very very ... long string.");
		ctrlTicker->set_ScrollSmoothness(1);
		ctrlTicker->StartTicker();
	
		// Add ticker to form controls collection.
		this->get_Controls()->Add(this->ctrlTicker);
	}

	// Members.
private:
	CTickerControl* ctrlTicker;		// Ticker control.
};

int main(void)
{
	try
	{
		// Create Form.
		Application::Run(new CTickerClientForm());
	}
	catch(Exception* e)
	{
		Console::Write("Error occured: ");
		Console::WriteLine(e->get_Message());
	}

    return 0;
}
#using <mscorlib.dll>
using namespace System;

// required dlls for WinForms
#using "System.dll"
#using "System.Windows.Forms.dll"
#using "System.Drawing.dll"

// required namespaces for WinForms
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

__gc class WinForm: public Form 
{
public:
	WinForm() 
	{
		InitForm();
	}

	void ~WinForm()
	{
		// Form is being destroyed.  Do any necessary clean-up here.

		Form::Dispose();
	}

	void InitForm()
	{
		// Setup controls here
	}
};

void main()
{
	// This line creates an instance of WinForm, and 
	// uses it as the Main Window of the application. 
	Application::Run(new WinForm());
}


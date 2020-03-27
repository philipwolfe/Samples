// TickerControl.h

#pragma once

#define NULL 0

#using <mscorlib.dll>

// Add it to get access to the .NET Framework classes.
#using <System.dll>
#using <System.Drawing.DLL>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// Class that demonstrates using basic drawing techniques
// and memory mapped device context with GDI+.
public __gc class CTickerControl : public Control
{
	// Constructor.
public:
	CTickerControl();
	~CTickerControl();

	// Overrides
protected:
	// To avoid flickering we override this function and do nothing in it.
	virtual void OnPaintBackground(PaintEventArgs* pe);

	//******************************************************************
	//	OnPaint
	//
	//		Paint procedure.
	//
	//	PARAMS:	pe - PaintEventArgs specifies the Graphics
	//			to use to paint the control
	//			and the ClipRectangle in which to paint.
	//******************************************************************
	virtual void OnPaint(PaintEventArgs* pe);

	virtual void OnResize(EventArgs* e);

	// Control methods.
public:
	//******************************************************************
	//	StartTicker
	//
	//		Starts moving a ticker.
	//******************************************************************
	void StartTicker();

	//******************************************************************
	//	StopTicker
	//
	//		Starts moving a ticker.
	//******************************************************************
	void StopTicker();

	//******************************************************************
	//	OnTimer
	//
	//		Timer event handler.
	//******************************************************************
	void OnTimer( Object* myObject, EventArgs* myEventArgs );

	// Class members.
protected:
	//******************************************************************
	//	CreateBitmap
	//
	//		Creates control face image bitmap.
	//
	//	RETURNS:Pointer to created bitmap.
	//
	//	REMARKS:For the strings that shorter than client part of the
	//			control, it creates bitmap that twice wider than
	//			control width, if string longer than bitmap twice
	//			longer than string. We will scroll this bitmap in
	//			control window to move a ticker.
	//******************************************************************
	Bitmap* CreateBitmap();

	//-------------------------------------------------
	// Control Properties
public:
	// Sets ticker scroll speed (period of refreshing the screen).
	__property int get_TimerInterval();
	__property void set_TimerInterval(int nTimerInterval);

	// Defines for how many pixels to move ticker on each refresh.
	__property int get_ScrollSmoothness();
    __property void set_ScrollSmoothness(int nScrollSmoothness);

	// Text to show in the ticker.
	__property String* get_TickerText();
	__property void set_TickerText(String *strTickerText);

	//-------------------------------------------------
	// Control Members
private:
	int m_nScrollSmoothness;	// Used by ScrollSmoothness property.
	String* m_strTickerText;	// Used by TickerText property
	Bitmap* m_bmpTicker;		// Keeps control image.
	int m_nOffset;				// Keeps position of bitmap relative to control window.
	int m_nTickerWidth;			// Width of the control image bitmap.
	Timer* m_tmTicker;			// Timer used by ticker to move image.
};
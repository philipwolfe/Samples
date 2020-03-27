// This is the main DLL file.

#include "stdafx.h"

#include "TickerControl.h"

CTickerControl::CTickerControl() :	
		m_nScrollSmoothness(1),
		m_strTickerText(S"Ticker"),
		m_nOffset(0),
		m_nTickerWidth(0),
		m_bmpTicker(NULL)
{
	// Create timer and set interval.
	m_tmTicker = new Timer();
	m_tmTicker->set_Interval(10);

	// Subscribe for timer events.
	m_tmTicker->add_Tick(new EventHandler(this, &CTickerControl::OnTimer));
}

// Destructor.
CTickerControl::~CTickerControl()
{
	// Unsubscribe from timer event.
	m_tmTicker->remove_Tick(new EventHandler(this, &CTickerControl::OnTimer));
}


// To avoid flickering we override this function and do nothing in it.
void CTickerControl::OnPaintBackground(PaintEventArgs* pe)
{
}

//******************************************************************
//	OnPaint
//
//		Paint procedure.
//
//	PARAMS:	pe - PaintEventArgs specifies the Graphics
//			to use to paint the control
//			and the ClipRectangle in which to paint.
//******************************************************************
void CTickerControl::OnPaint(PaintEventArgs* pe)
{
	Rectangle rect;
	Graphics* graph;

	// Get the control's client area dimensions.
	rect = this->get_ClientRectangle();

	// Get a Graphics object that is used to draw.
	graph = pe->get_Graphics();

	// If face image bitmap is not exist, create it.
	if(m_bmpTicker == NULL)
		m_bmpTicker = CreateBitmap();

	// Draw the face image bitmap.
	graph->DrawImageUnscaled(m_bmpTicker, Point((m_nOffset - m_nTickerWidth), 0));
}

void CTickerControl::OnResize(EventArgs* e)
{
	Control::OnResize(e);

	// Recreate face image bitmap for the new size. 
	m_bmpTicker = CreateBitmap();
}

//******************************************************************
//	StartTicker
//
//		Starts moving a ticker.
//******************************************************************
void CTickerControl::StartTicker()
{
	// Start timer.
	m_tmTicker->Start();
}

//******************************************************************
//	StopTicker
//
//		Starts moving a ticker.
//******************************************************************
void CTickerControl::StopTicker()
{
	// Stop timer.
	m_tmTicker->Stop();
}

//******************************************************************
//	OnTimer
//
//		Timer event handler.
//******************************************************************
void CTickerControl::OnTimer( Object* myObject, EventArgs* myEventArgs )
{
	// Adjust bitmap offset.
	m_nOffset -= m_nScrollSmoothness;

	// If we finish to scroll bitmap, recreate it.
	if(m_nOffset < 0)
		m_nOffset = m_nTickerWidth - m_nScrollSmoothness;

	// Redraw control.
	Invalidate();
	Update();
}

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
Bitmap* CTickerControl::CreateBitmap()
{
	Bitmap* bmpTicker;				// Result bitmap.
	Graphics* graphImage;			// Graphics used to draw to bitmap.
	Graphics* graphMeasure;			// Graphics used to measure string.
	SizeF sizeString;				// Size of Ticker text string.
	System::Drawing::Font* font;	// Font used to draw string.
	SolidBrush* brush;				// Brush to fill background.
	Rectangle rect;					// Control client part rectangle.

	int nBmpWidth;					// Bitmap width.
	int nBmpHeight;					// Bitmap height.
	int nRepeat;					// How many time we should draw ticker
	// text string in the image.

	// Get a graphic object used by control window.
	graphMeasure = Graphics::FromHwnd(this->get_Handle());

	// Create a font and brush to draw.
	font = new System::Drawing::Font("Courier", 10);
	brush = new SolidBrush(get_BackColor());

	// Get a size that  ticker text string occupies on the string. 
	sizeString = graphMeasure->MeasureString(m_strTickerText, font);

	m_nTickerWidth = (int)sizeString.get_Width();

	rect = this->get_ClientRectangle();

	// If ticker text wider than control size, create bitmap twice
	// wider than control size.
	// Otherwise bitmap should be twice wider than the ticker text size.
	nBmpWidth = rect.get_Width() + m_nTickerWidth;

	nRepeat = (int)(nBmpWidth/m_nTickerWidth + 1);

	nBmpHeight = rect.get_Height();

	// Create a bitmap to draw off screen.
	bmpTicker = new Bitmap(	nBmpWidth, 
		nBmpHeight, 
		graphMeasure);

	// Get a graphic object to draw to bitmap.
	graphImage = Graphics::FromImage(bmpTicker);

	// Fill the background.
	graphImage->FillRectangle(brush, 0, 0, nBmpWidth, nBmpHeight);

	// Draw string, if it is short, draw it several times.
	for(int nCounter = 0; nCounter < nRepeat; nCounter++)
		graphImage->DrawString(m_strTickerText, font, Brushes::Black, nCounter * m_nTickerWidth, 0);

	return bmpTicker;
}


// Sets ticker scroll speed (period of refreshing the screen).
int CTickerControl::get_TimerInterval()
{
	return m_tmTicker->get_Interval();
}

void CTickerControl::set_TimerInterval(int nTimerInterval)
{
	m_tmTicker->set_Interval(nTimerInterval);
}

// Defines for how many pixels to move ticker on each refresh.
int CTickerControl::get_ScrollSmoothness()
{
	return m_nScrollSmoothness;
}

void CTickerControl::set_ScrollSmoothness(int nScrollSmoothness)
{
	m_nScrollSmoothness = nScrollSmoothness;
}

// Text to show in the ticker.
String* CTickerControl::get_TickerText()
{
	return m_strTickerText;
}

void CTickerControl::set_TickerText(String *strTickerText)
{
	m_strTickerText = strTickerText;

	// Recreate face image bitmap for the new Ticker text.
	// But we shouldn't do it before the first OnPaint call,
	// otherwise both of the bitmap dimensions will be 0
	// and Bitmap constructor will throw the exception.
	if(m_bmpTicker != NULL)
		m_bmpTicker = CreateBitmap();
}


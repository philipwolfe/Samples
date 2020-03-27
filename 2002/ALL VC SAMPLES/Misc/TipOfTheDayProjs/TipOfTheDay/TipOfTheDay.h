// TipOfTheDay.h : Defines the ATL Server request handler class
//
#pragma once

[ request_handler("Default") ]
class CTipOfTheDayHandler
{
private:
	// Put private members here

protected:
	// Put protected members here

	_bstr_t m_bsCategoryMajor;		// category major: company, product, heading
	_bstr_t m_bsCategoryMinor;		// category minor: division, technology, {optional}
	_bstr_t m_bsTipOfTheDay;		// Tip Of The Day: Text but could be substituted with quote of the day
	_bstr_t m_bsSource;				// Source: Who added the tip or came up with the quote

	bool m_bInited;

	inline bool IsInited(bool bShowInstructions = false)
	{
		if (!m_bInited && bShowInstructions)
		{
			m_HttpResponse << "Call RandomTip before accessing any Tip* Methods";
		}
		return m_bInited;
	}

public:
	// Put public members here
	HTTP_CODE ValidateAndExchange();

	// Our tag handlers for our DLL
	[ tag_name(name="DisplayVersion") ]
	HTTP_CODE OnDisplayVersion(void);

	[ tag_name(name="RandomTip") ]
	HTTP_CODE OnRandomTip(void);

	[ tag_name(name="TipCategoryMajor") ]
	HTTP_CODE OnTipCategoryMajor(void);

	[ tag_name(name="TipCategoryMinor") ]
	HTTP_CODE OnTipCategoryMinor(void);

	[ tag_name(name="TipOfTheDay") ]
	HTTP_CODE OnTipInfo(void);

	[ tag_name(name="TipSource") ]
	HTTP_CODE OnTipSource(void);

}; // class CTipOfTheDayHandler

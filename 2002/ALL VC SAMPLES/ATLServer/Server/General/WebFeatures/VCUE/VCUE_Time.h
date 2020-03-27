// VCUE_Time.h
// (c) 2000 Microsoft Corporation
//
//////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#if !defined(_VCUE_TIME_H___31F7B71E_866E_11D3_BAB7_00C04F8EC847___INCLUDED_)
#define _VCUE_TIME_H___31F7B71E_866E_11D3_BAB7_00C04F8EC847___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#include "VCUE_Conversion.h"
#include <time.h>
#include <atlcomtime.h>

namespace VCUE
{

	// HTTP dates come in 3 formats
	enum HttpDateFormat { rfc1123_date, rfc850_date, asctime_date };

	// Straightforward data type conversion of tm to SYSTEMTIME
	// No time zone conversion involved!
	inline bool TmToSystemTime(const tm& rtm, SYSTEMTIME& st) throw()
	{
		st.wYear = static_cast<WORD>(1900 + rtm.tm_year);
		st.wMonth = static_cast<WORD>(1 + rtm.tm_mon);
		st.wDayOfWeek = static_cast<WORD>(rtm.tm_wday);
		st.wDay = static_cast<WORD>(rtm.tm_mday);
		st.wHour = static_cast<WORD>(rtm.tm_hour);
		st.wMinute = static_cast<WORD>(rtm.tm_min);
		st.wSecond = static_cast<WORD>(rtm.tm_sec);
		st.wMilliseconds = 0;

		return true;
	}

	// Straightforward data type conversion of SYSTEMTIME to tm
	// No time zone conversion involved!
	inline bool SystemTimeToTm(const SYSTEMTIME& st, tm& rtm) throw()
	{
		if (st.wYear < 1900)
			return false;

		rtm.tm_year = st.wYear - 1900;
		rtm.tm_mon = st.wMonth - 1;
		rtm.tm_wday = st.wDayOfWeek;
		rtm.tm_mday = st.wDay;
		rtm.tm_hour = st.wHour;
		rtm.tm_min = st.wMinute;
		rtm.tm_sec = st.wSecond;

		return true;
	}

	inline bool SystemTimeToDbTimeStamp(const SYSTEMTIME& st, DBTIMESTAMP& dbt) throw()
	{
		dbt.year = st.wYear;
		dbt.month = st.wMonth;
		dbt.day = st.wDay;
		dbt.hour = st.wHour;
		dbt.minute = st.wMinute;
		dbt.second = st.wSecond;
		dbt.fraction = 0;
		return true;
	}
		
	inline COleDateTime DbTimeStampToCOleDateTime(const DBTIMESTAMP& dbt) throw()
	{
		return COleDateTime(dbt.year, dbt.month, dbt.day, dbt.hour, dbt.minute, dbt.second);
	}

	inline bool DbTimeStampToSystemTime(const DBTIMESTAMP& dbt, SYSTEMTIME& st) throw()
	{
		bool bSuccess = false;
		if (DbTimeStampToCOleDateTime(dbt).GetAsSystemTime(st))
			bSuccess =  true;
		return bSuccess;
	}
	
	inline bool TmToSystemTime(const tm* ptm, SYSTEMTIME& st) throw()
	{
		if (!ptm)
			return false;

		return TmToSystemTime(*ptm, st);
	}


	inline bool DbTimeStampToHttpDate(const DBTIMESTAMP& dbt, CStringA& str) throw()
	{
		bool bSuccess = false;
		SYSTEMTIME st = {0};
		if (DbTimeStampToSystemTime(dbt, st))
		{
			SystemTimeToHttpDate(st, str);
			bSuccess = true;
		}

		return bSuccess;
	}

	inline CStringA DbTimeStampToHttpDate(const DBTIMESTAMP& dbt) throw()
	{
		CStringA str;
		return DbTimeStampToHttpDate(dbt, str) ? str : "";
	}

	inline bool COleDateTimeToHttpDate(COleDateTime t, CStringA& str) throw()
	{
		bool bSuccess = false;
		SYSTEMTIME st = {0};
		if (t.GetAsSystemTime(st))
		{
			SystemTimeToHttpDate(st, str);
			bSuccess = true;
		}

		return bSuccess;
	}

	inline CStringA COleDateTimeToHttpDate(COleDateTime t) throw()
	{
		CStringA str;
		return COleDateTimeToHttpDate(t, str) ? str : "";
	}


	// 0-based index starting with Jan
	inline bool GetMonthIndex(const char* szMonth, int nLength, int& nIndex)
	{
		// This function is designed to be fast, safe and weed out the worst offenders only.
		// It can give false positives.
		if (!szMonth || nLength < 3)
			return false;

		switch (szMonth[0])
		{
		case 'J':
			{
				if (szMonth[1] == 'u')
				{
					if (szMonth[2] == 'n')
						nIndex = 5;
					else
					{
						ATLASSERT(szMonth[2] == 'l');
						nIndex = 6;
					}
				}
				else
				{
					ATLASSERT(szMonth[1] == 'a' && szMonth[2] == 'n');
					nIndex = 0;
				}
				break;
			}
		case 'F':
			{
				ATLASSERT(szMonth[1] == 'e' && szMonth[2] == 'b');
				nIndex = 1;
				break;
			}
		case 'M':
			{
				if (szMonth[1] == 'a')
				{
					if (szMonth[2] == 'r')
						nIndex = 2;
					else
					{
						ATLASSERT(szMonth[2] == 'y');
						nIndex = 4;
					}
				}
				else
					return false;
				break;
			}
		case 'A':
			{
				if (szMonth[1] == 'p')
				{
					ATLASSERT(szMonth[2] == 'r');
					nIndex = 3;
				}
				else
				{
					ATLASSERT(szMonth[1] == 'u' && szMonth[2] == 'g');
					nIndex = 7;
				}
				break;
			}
		case 'S':
			{
				ATLASSERT(szMonth[1] == 'e' && szMonth[2] == 'p');
				nIndex = 8;
				break;
			}
		case 'O':
			{
				ATLASSERT(szMonth[1] == 'c' && szMonth[2] == 't');
				nIndex = 9;
				break;
			}
		case 'N':
			{
				ATLASSERT(szMonth[1] == 'o' && szMonth[2] == 'v');
				nIndex = 10;
				break;
			}
		case 'D':
			{
				ATLASSERT(szMonth[1] == 'e' && szMonth[2] == 'c');
				nIndex = 11;
				break;
			}
		default:
			return false;
		}

		return true;
	}

	// 0-based index starting with Monday
	inline bool GetWeekdayIndex(const char* szWeekday, int nLength, int& nIndex)
	{
		// This function is designed to be fast, safe and weed out the worst offenders only.
		// In retail builds it can give false positives, since it checks as few characters as possible.
		// ASSERTs in debug builds help track down problems.
		if (!szWeekday || nLength < 3 || (nLength > 3 && nLength < 6) || nLength > 8)
			return false;

		if (nLength != 3 && szWeekday[nLength - 1] != 'y')
			return false;

		switch (szWeekday[0])
		{
		case 'M':
			{
				ATLASSERT(szWeekday[1] == 'o' && szWeekday[2] == 'n');
				nIndex = 0;
				break;
			}
		case 'T':
			{
				if (szWeekday[1] == 'u')
				{
					ATLASSERT(szWeekday[2] == 'e');
					nIndex = 1;
				}
				else
				{
					ATLASSERT(szWeekday[1] == 'h' && szWeekday[2] == 'u');
					nIndex = 3;
				}
				break;
			}
		case 'W':
			{
				ATLASSERT(szWeekday[1] == 'e' && szWeekday[2] == 'd');
				nIndex = 2;
				break;
			}
		case 'F':
			{
				ATLASSERT(szWeekday[1] == 'r' && szWeekday[2] == 'i');
				nIndex = 4;
				break;
			}
		case 'S':
			{
				if (szWeekday[1] == 'a')
				{
					ATLASSERT(szWeekday[2] == 't');
					nIndex = 5;
				}
				else
				{
					ATLASSERT(szWeekday[1] == 'u' && szWeekday[2] == 'n');
					nIndex = 6;
				}
				break;
			}
		default:
			return false;
		}

		return true;
	}

	// Call this function to parse an HTTP-style date string into a SYSTEMTIME structure.
	// Returns true on success, false on failure.
	// Note that this function is designed to be tolerant of slightly misformatted dates in release builds.
	// ASSERTs in debug builds should help you spot badly formatted dates.
	inline bool ParseHttpDate(const char* szDate, SYSTEMTIME& st)
	{
	#if defined(DEBUG)
		// Zero the system time for debugging
		ZeroMemory(&st, sizeof(SYSTEMTIME));
	#endif

		if (!szDate)
			return false;

		HttpDateFormat theFormat = rfc1123_date;

		const char* p = szDate;

		// Skip whitespace
		while (isspace(*p))
			++p;

		char* p2 = strchr(p, ',');

		if (!p2)
		{
			p2 = strchr(p, ' ');
			if (!p2)
				return false;

			theFormat = asctime_date;
		}

		// The current position disambiguates the format of the date
		int nPosition = (int)(p2 - p);
		
		if (nPosition > 5 && nPosition < 9) // rfc850_date uses weekday names of 6, 7, or 8 characters 
			theFormat = rfc850_date;
		else if (nPosition != 3)			// rfc1123_date or asctime_date both use 3 character weekdays
			return false;

		// Get weekday
		int nDayIndex = 0;
		bool bSuccess = GetWeekdayIndex(p, (int)(p2 - p), nDayIndex);
		if (!bSuccess)
			return false;

		st.wDayOfWeek = (WORD)(((nDayIndex + 1) == 7) ? 0 : nDayIndex + 1);

		// Skip next character
		ATLASSERT(*p2 == ',' || *p2 == ' ');
		p = ++p2;

		char chSeparator = (theFormat == rfc850_date) ? '-' : ' ';

		if (theFormat != asctime_date)
		{
			if (*p != ' ')
				return false;

			ATLASSERT(*p == ' ');
			++p; // skip space

			st.wDay = StringToWord(p, &p2);
			if (!(*p2) || p == p2)
				return false;

			ATLASSERT(*p2 == chSeparator);
			p = ++p2;
		}

		// Next characters should be the month
		p2 = strchr(p, chSeparator);
		if (!p2 || p == p2)
			return false;

		int nMonthIndex = 0;
		bSuccess = GetMonthIndex(p, (int)(p2 - p), nMonthIndex);
		if (!bSuccess)
			return false;

		st.wMonth = static_cast<WORD>(nMonthIndex + 1);

		ATLASSERT(*p2 == chSeparator);
		p = ++p2;

		if (theFormat == asctime_date)
		{
			st.wDay = StringToWord(p, &p2);
			if (!(*p2) || p == p2)
				return false;

			ATLASSERT(*p2 == chSeparator);
			p = ++p2;
		}
		else
		{
			st.wYear = StringToWord(p, &p2);
			if (!(*p2) || p == p2)
				return false;

			// Fix 2-digit date
			if (p2 - p < 4)
			{
				ATLASSERT(theFormat == rfc850_date);

				// Values between 0 and 29, inclusive, are interpreted as the years 2000-2029.
				// Values between 30 and 99, inclusive, are interpreted as the years 1930-1999. 
				if (st.wYear < 30)
					st.wYear += 2000;
				else if (st.wYear < 100)
					st.wYear += 1900;
			}

			ATLASSERT(*p2 == ' ');
			p = ++p2;
		}

		st.wHour = StringToWord(p, &p2);
		if (!(*p2) || p == p2)
			return false;

		ATLASSERT(*p2 == ':');
		p = ++p2;

		st.wMinute = StringToWord(p, &p2);
		if (!(*p2) || p == p2)
			return false;

		ATLASSERT(*p2 == ':');
		p = ++p2;

		st.wSecond = StringToWord(p, &p2);
		if (!(*p2) || p == p2)
			return false;

		ATLASSERT(*p2 == ' ');
		p = ++p2;

		st.wMilliseconds = 0;

		if (theFormat == asctime_date)
		{
			st.wYear = StringToWord(p, &p2);
			if (!(*p2) || p == p2)
				return false;

			ATLASSERT((p2 - p) == 4); // expect 4 digit year
		}

		return true;
	}

	// This class can be used to set
	// the expiry of a cookie in terms of the number
	// of minutes from the time the object is constructed
	// Create a temporary instance of this class just like calling a function.
	// e.g. cookie.SetExpires(GmtTime(240));
	class GmtTime : public SYSTEMTIME
	{
	public:
		GmtTime(unsigned int nMinutes = 0) throw()
		{
			if (nMinutes)
			{
				// Create a time variable and get the current UTC (aka GMT) time
				__time64_t theTime = _time64(NULL);

				// Increment current time by number of seconds
				theTime += (nMinutes * 60);

				// Convert to a SYSTEMTIME via a tm structure
				TmToSystemTime(_gmtime64(&theTime), *this);
			}
			else
				GetSystemTime(this);
		}

	};

	class HttpTime
		: public GmtTime
	{
	private:
		CStringA m_str;
	
	public:
		HttpTime(unsigned int nMinutes = 0) throw()
			: GmtTime(nMinutes)
		{
			SystemTimeToHttpDate(*this, m_str);
		}

		operator const char*() const throw()
		{
			return m_str;
		}
	};

} // namespace VCUE

#endif // !defined(_VCUE_TIME_H___31F7B71E_866E_11D3_BAB7_00C04F8EC847___INCLUDED_)

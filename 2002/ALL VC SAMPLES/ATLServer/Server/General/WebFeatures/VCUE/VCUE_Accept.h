// VCUE_Accept.h
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

#if !defined(_VCUE_ACCEPT_H___97EB7FEB_C2F6_4891_807D_4F44BE93E448___INCLUDED_)
#define _VCUE_ACCEPT_H___97EB7FEB_C2F6_4891_807D_4F44BE93E448___INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

namespace VCUE
{
	// This class represents a prioritized item such as those found in
	// HTTP accept headers, such as Accept-Charset, Accept-Language, etc.
	// The priority is an integer value between 0 and 1000 inclusive.
	// This is just a scaled version of an HTTP qvalue (0-1 with at most 3 dps).
	// The class ensures that the value of the item is always trimmed and lowercase.
	class CAcceptItem
	{
	private:
		CStringA m_strValue;
		unsigned int m_nPriority; // Valid range 0-1000 inclusive

	public:	
		CAcceptItem(const CStringA& strValue = "", unsigned int nPriority = 1000) throw() : m_strValue(strValue), m_nPriority(nPriority)
		{
			m_strValue.TrimLeft();
			m_strValue.TrimRight();
			m_strValue.MakeLower();
		}

		unsigned int GetPriority() const throw()
		{
			return m_nPriority;
		}

		const CStringA& GetValue() const throw()
		{
			return m_strValue;
		}

		bool IsValid() const throw()
		{
			return (m_nPriority <= 1000);
		}
	};

	// This class represents an ordered list of accept items.
	// The list is ordered based on priority. Where priorities are
	// equal, items appear in the order in which they were added to the collection.
	// The Parse method builds up the collection from the contents of an HTTP header.
	class CAcceptCollection : public CAtlList<CAcceptItem>
	{
	private:
		unsigned int m_nLowestPriority;

	public:
		CAcceptCollection() : m_nLowestPriority(0) {}

		bool Add(const CStringA& str, unsigned int nPriority = 1000) throw()
		{
			if (nPriority > 1000)
				return false;

			// We mostly expect to be called with high priority items first
			if (nPriority > m_nLowestPriority)
			{
				// Loop through elements
				POSITION pos = GetTailPosition();
				while (pos)
				{
					const CAcceptItem& item = GetPrev(pos);
					if (nPriority > item.GetPriority())
					{
						InsertAfter(pos, CAcceptItem(str, nPriority));
						return true;
					}
				}
			}

			AddTail(CAcceptItem(str, nPriority));
			m_nLowestPriority = nPriority;

			return true;
		}

		bool Parse(const char* p) throw()
		{
			ATLASSERT(p != NULL);
			const char* pStart = p;
			const char* pEnd = p;

			while (*pEnd)
			{
				pStart = pEnd;

				while (*pEnd && *pEnd != ',')
					++pEnd;

				ATLASSERT(*pEnd == ',' || *pEnd == '\0');

				if (!ParseItem(pStart, pEnd))
					return false;

				if (*pEnd)
					++pEnd;
			};

			return true;
		}

	protected:
		bool ParseItem(const char* pStart, const char* pEnd) throw()
		{
			ATLASSERT(pStart != NULL);
			ATLASSERT(pEnd != NULL);
			ATLASSERT(*pStart);

			bool bSuccess = true;

			const char* pMiddle = pStart;
			while (pMiddle < pEnd && *pMiddle != ';')
				++pMiddle;

			CStringA strItem((pStart), (int)(pMiddle - pStart));

			int nPriority = 1000;
			if (pMiddle < pEnd)
			{
				bSuccess = false;

				ATLASSERT(*pMiddle == ';');
				ATLASSERT(pMiddle[1] == 'q');

				while (pMiddle < pEnd && *pMiddle != '=')
					++pMiddle;

				ATLASSERT(pMiddle < pEnd);
				ATLASSERT(*pMiddle == '=');
				if (*pMiddle == '=')
					++pMiddle;

				if (pMiddle < pEnd)
				{
					if (*pMiddle == '0')
					{
						++pMiddle;

						if (pMiddle < pEnd)
						{
							if (*(pMiddle) == '.')
							{
								++pMiddle;

								if (pMiddle < pEnd)
								{								
									UINT nCurrentDigit = 0;
									const size_t nMaxQualityDigits = min(3, pEnd - pMiddle); // Up to 3 digits
									char szTemp[4] = {'0', '0', '0', 0};
									while (pMiddle < pEnd)
									{
										if (!isdigit(*pMiddle))
											break;

										szTemp[nCurrentDigit] = *pMiddle;
										
										++pMiddle;

										if (++nCurrentDigit == nMaxQualityDigits)
											break;
									}

									if (nCurrentDigit)
									{
										nPriority = atoi(szTemp);
										bSuccess = true;
									}
								}
							}
							else
							{
								nPriority = 0;
								bSuccess = true;
							}
						}
					}
					else if (*pMiddle == '1')
					{
						nPriority = 1000;
						bSuccess = true;
					}
				}
			}
			
			if (bSuccess)
				Add(strItem, nPriority);

			return bSuccess;
		}
	};


}; // namespace VCUE

#endif // !defined(_VCUE_ACCEPT_H___97EB7FEB_C2F6_4891_807D_4F44BE93E448___INCLUDED_)

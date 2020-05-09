#ifndef SPEECHRECOENV_H_INCLUDED
#define SPEECHRECOENV_H_INCLUDED

#pragma once

#pragma warning( push )
#pragma warning( disable : 4267 )

#include <sphelper.h>                           // Contains definitions of SAPI functions
#include <spddkhlp.h>                           // Contains definitions
#include <objbase.h>
#pragma warning( pop )


#define _GRAMMAR_ID 101
struct VOICEMSG_ENTRY;


enum eVOICE_CMD_PARAM
{
	eNO_PARAM,
	eSINGLE_PARAM,
	eSINGLE_NBR_PARAM,
	eALL,
};


__interface IHandleVoiceCmd
{
	virtual BOOL HandleVoiceCmd(SPPHRASE *pPhrase);
};

template<class TBase>
class CVoiceCmdTargetT : public IHandleVoiceCmd
{

public:
	virtual BOOL HandleVoiceCmd(SPPHRASE *pPhrase)
	{
		BOOL			bRet = FALSE;
		VOICEMSG_ENTRY	msgEntry;
		TBase			*pThis	=	static_cast<TBase*>(this);
		
		memset(&msgEntry, 0, sizeof(msgEntry));

		if( !pPhrase )
			return FALSE;

		const VOICEMSG_ENTRY*	pMsgMap = pThis->GetVoiceMessageMap();

		if( pMsgMap == NULL)
			return FALSE;

		int iIter = 0;
		bool bFound = false;
		do
		{
			if( pMsgMap[iIter].ulRuleID == 0 )
			// end of map		
				break;
			if( pMsgMap[iIter].ulRuleID  == pPhrase->Rule.ulId )
			{
				bFound = true;
				msgEntry = pMsgMap[iIter];
			}
			iIter++;
		}while(!bFound);
		
		if( bFound )
		{
			VoiceMessageMapFunctions	fnSet;

			fnSet.pfnBase = msgEntry.memberFn;
			
			ULONG			ulCountOfElements = 0;
			ulCountOfElements = pPhrase->Rule.ulCountOfElements;
			switch( msgEntry.type )
			{
			case eNO_PARAM:
				{
					VOICECMD_PROC	pfn = fnSet.pfnBase;
					bRet = (pThis->*pfn)();
				}
				break;
			case eSINGLE_PARAM:
				{
					VOICECMD_PROC_PARAM	pfn = NULL;
					pfn = fnSet.pfnParam;
					if( msgEntry.nParam < ulCountOfElements )
					{
						CW2T	szParam( pPhrase->pElements[msgEntry.nParam].pszDisplayText );
						bRet = (pThis->*pfn)(szParam);
					}
					else
					{
						bRet = (pThis->*pfn)(NULL);
					}
				}
				break;
			case eSINGLE_NBR_PARAM:
				{
					VOICECMD_PROC_NBR_PARAM	pfn = NULL;
					pfn = fnSet.pfnNbrParam;
					int iValue = 0;
					if( msgEntry.nParam < ulCountOfElements )
					{
						iValue = SAPI_ParseNumberHelper(pPhrase, msgEntry.nParam);
					}
					bRet = (pThis->*pfn)(iValue);
				}
				break;
			case eALL:
				{
					VOICECMD_PROC_EX	pfn = NULL;
					pfn = fnSet.pfnEx;
					bRet = (pThis->*pfn)(pPhrase);
				}
				break;
			default:
				bRet = FALSE;
			}
		}

		return bRet;
		
	}

public:
	typedef BOOL (TBase::*VOICECMD_PROC)(void);
	typedef BOOL (TBase::*VOICECMD_PROC_PARAM)(LPCTSTR);
	typedef BOOL (TBase::*VOICECMD_PROC_NBR_PARAM)(int);
	typedef BOOL (TBase::*VOICECMD_PROC_EX)(SPPHRASE*);

	struct VOICEMSG_ENTRY
	{
		// the rule tobe handled
		ULONG ulRuleID;
		// the index of the param that matters if eSINGLE_PARAM, or anything else
		unsigned int nParam;
		// handling routine
		VOICECMD_PROC		memberFn;
		// the type of handling
		eVOICE_CMD_PARAM type;

	};

	union VoiceMessageMapFunctions
	{
		VOICECMD_PROC			pfnBase;
		VOICECMD_PROC_PARAM		pfnParam;
		VOICECMD_PROC_NBR_PARAM	pfnNbrParam;
		VOICECMD_PROC_EX		pfnEx;
	};

protected:
	HRESULT	GetPhraseProperty(const SPPHRASEPROPERTY	*pProperty, LPCWSTR	wszName, CComVariant&	ret, int& iFirstChild)
	{
		HRESULT	hRet	=	E_FAIL;
		if( !pProperty )
			return E_FAIL;
		
		if( wcsicmp(pProperty->pszName, wszName) == 0 )
		{
			ret	=	pProperty->vValue;
			iFirstChild = pProperty->ulFirstElement;
			hRet	=	S_OK;
		}
		else
		{
			// Look for property in child
			hRet	=	GetPhraseProperty( pProperty->pFirstChild, wszName, ret, iFirstChild);

			if( FAILED(hRet) )
			{
				// not found, look in sibling
				hRet	=	GetPhraseProperty( pProperty->pNextSibling, wszName, ret, iFirstChild);
			}
		}

		return hRet;
	}
};



/*
	The whole purpose of this wrapper class is to allow a simple model for subscribing 
	for voice cmd notifications.
	There should be a single SpeechRecoEnv object per app
	It initializes the environment with the most common options for command recognition
	It contains only one grammar, that has o be specified at initialization time
*/

class CSAPIWrapper_SpeechRecoEnv : public ISpNotifyCallback
{
public:
	CSAPIWrapper_SpeechRecoEnv()
	{
		m_bGrammarEnabled = false;
	}
	~CSAPIWrapper_SpeechRecoEnv()
	{
		CloseSAPI();
	}


public:
	CComPtr<ISpRecognizer>		    m_cpEngine;		// Wraps the instance of the recognition engine
	CComPtr<ISpRecoContext>         m_cpRecoCtxt;   // Wraps the instance of the recognition context
	
	CComPtr<ISpRecoGrammar>         m_cpCmdGrammar; // Wraps the grammar

	CArray<IHandleVoiceCmd*>		m_arSubscribers;

	bool							m_bGrammarEnabled;

public:
	virtual HRESULT STDMETHODCALLTYPE NotifyCallback(WPARAM   /*wParam*/, LPARAM   /*lParam*/)
	{
		CSpEvent event;  // Event helper class

		// Loop processing events while there are any in the queue
		while (event.GetFrom(m_cpRecoCtxt) == S_OK)
		{
			// Look at recognition event only
			switch (event.eEventId)
			{
				case SPEI_RECOGNITION:
					ExecuteCommand(event.RecoResult());
					break;
				case SPEI_FALSE_RECOGNITION:
					//HandleFalseReco(event.RecoResult(), hWnd);
					break;

			}
		}

		return S_OK;
	}

	HRESULT	InitializeSAPI(UINT nGrammarID/*, LPCTSTR	szGrammarFile*/)
	{
		HRESULT	hr	=	S_OK;
		while(1)
		{
			// create a recognition engine
			hr = m_cpEngine.CoCreateInstance(CLSID_SpSharedRecognizer);
			if ( FAILED( hr ) )
			{
				break;
			}

			// create the command recognition context
			hr = m_cpEngine->CreateRecoContext( &m_cpRecoCtxt );
			if ( FAILED( hr ) )
			{
				break;
			}

			// Let SR know the callback object
			hr = m_cpRecoCtxt->SetNotifyCallbackInterface(this, 0, 0);
			if ( FAILED( hr ) )
			{
				break;
			}

			// Tell SR what types of events interest us.  Here we only care about command
			// recognition.
			hr = m_cpRecoCtxt->SetInterest( SPFEI(SPEI_RECOGNITION), SPFEI(SPEI_RECOGNITION) );
			if ( FAILED( hr ) )
			{
				break;
			}

			// Load the grammar, which is the compiled form of simple.xml bound
			hr = m_cpRecoCtxt->CreateGrammar(_GRAMMAR_ID, &m_cpCmdGrammar);
			if (FAILED(hr))
			{
				break;
			}


			//CT2W	wszGrammarFile(szGrammarFile);
			//hr	=	m_cpCmdGrammar->LoadCmdFromFile(wszGrammarFile, SPLO_DYNAMIC);
			hr = m_cpCmdGrammar->LoadCmdFromResource(NULL, MAKEINTRESOURCEW(nGrammarID),
													L"SRGRAMMAR", MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL),
													SPLO_DYNAMIC);
			if ( FAILED( hr ) )
			{
				break;
			}

			break;
		}
		
		if( !SUCCEEDED(hr) )
		{
			CloseSAPI();
		}
		else
		{
			m_bGrammarEnabled = true;
		}
	
			
		return hr;
	}

	void CloseSAPI()
	{
		// Release grammar, if loaded
		if ( m_cpCmdGrammar )
		{
			m_cpCmdGrammar.Release();
		}
		// Release recognition context, if created
		if ( m_cpRecoCtxt )
		{
			m_cpRecoCtxt->SetNotifySink(NULL);
			m_cpRecoCtxt.Release();
		}
		// Release recognition engine instance, if created
		if ( m_cpEngine )
		{
			m_cpEngine.Release();
		}
/*		// Release voice, if created
		if ( m_cpVoice )
		{
			m_cpVoice.Release();
		}*/

		m_bGrammarEnabled = false;
	}



	// Grammar Helpers
	HRESULT	EnableGrammar(bool bEnabled = true)
	{
		HRESULT hr = S_FALSE;
		if( m_bGrammarEnabled != bEnabled )
		{
			hr = m_cpCmdGrammar->SetGrammarState(bEnabled ? SPGS_ENABLED : SPGS_DISABLED);
			m_bGrammarEnabled = bEnabled;
		}
		return hr;
	}


	HRESULT	EnableRule(ULONG	dwRuleId, bool bEnabled = true)
	{
		HRESULT hr = m_cpCmdGrammar->SetRuleIdState( dwRuleId, (bEnabled ? SPRS_ACTIVE: SPRS_INACTIVE));
		return hr;
	}


	HRESULT	AddSingleWordTerminalTransition(LPCTSTR szRuleName, DWORD	dwRuleID, LPCTSTR szWord)
	{
		HRESULT	hr = S_OK;
		SPSTATEHANDLE hRule;
		if( ! szWord )
			return E_POINTER;
		if( szRuleName )
		{
			CT2W	wszRuleName(szRuleName);
			// retrieve the rule by name
			hr = m_cpCmdGrammar->GetRule(wszRuleName, NULL, SPRAF_Dynamic, FALSE, &hRule);
		}
		else
		{
			// retrieve the rule by id
			hr = m_cpCmdGrammar->GetRule(NULL, dwRuleID, SPRAF_Dynamic, FALSE, &hRule);
		}
		if( !SUCCEEDED(hr))
			return hr;
		CT2W	wszWord( szWord );

		hr = m_cpCmdGrammar->AddWordTransition(hRule, NULL/*terminal*/, wszWord, NULL, SPWT_LEXICAL, 1, NULL);

		return hr;
	}

	HRESULT	ClearRule( LPCTSTR szRuleName, DWORD	dwRuleID )
	{
		HRESULT	hr = S_OK;
		SPSTATEHANDLE hRule;
		if( szRuleName )
		{
			CT2W	wszRuleName(szRuleName);
			// retrieve the rule by name
			hr = m_cpCmdGrammar->GetRule(wszRuleName, NULL, SPRAF_Dynamic, FALSE, &hRule);
		}
		else
		{
			// retrieve the rule by id
			hr = m_cpCmdGrammar->GetRule(NULL, dwRuleID, SPRAF_Dynamic, FALSE, &hRule);
		}
		if( !SUCCEEDED(hr))
			return hr;
		
		hr = m_cpCmdGrammar->ClearRule(hRule);

		return hr;
	}

	HRESULT	CommitGrammar()
	{
		HRESULT hr = m_cpCmdGrammar->Commit(NULL);
		return hr;
	}



	// Subscription routines
	HRESULT	AddSubscriber( IHandleVoiceCmd* pAdd)
	{
		size_t iIndex, iSize;
		if( !pAdd )
			return E_POINTER;
		iSize = m_arSubscribers.GetCount();

		for( iIndex = 0; iIndex < iSize; iIndex ++)
		{
			if( m_arSubscribers[iIndex] == pAdd )
				return S_FALSE; // already in
		}
		m_arSubscribers.Add(pAdd);
		return S_OK;
	}

	HRESULT	RemoveSubscriber( IHandleVoiceCmd* pAdd)
	{
		size_t iIndex, iSize;
		if( !pAdd )
			return E_POINTER;
		iSize = m_arSubscribers.GetCount();

		for( iIndex = 0; iIndex < iSize; iIndex ++)
		{
			if( m_arSubscribers[iIndex] == pAdd )
			{
				m_arSubscribers.RemoveAt(iIndex);
				return S_OK;
			}
		}
		return E_FAIL;
	}


protected:
	void ExecuteCommand(ISpRecoResult *pRecoResult)
	{
		BOOL	bHandled = FALSE;
		size_t iIndex, iSize;
		SPPHRASE	*pPhrase = NULL;

		// Get the phrase elements, one of which is the rule id we specified in
		// the grammar.  Switch on it to figure out which command was recognized.
		if (!SUCCEEDED(pRecoResult->GetPhrase(&pPhrase)))
			return;


		EnableGrammar(false);
		iSize = m_arSubscribers.GetCount();

		for( iIndex = 0; !bHandled && (iIndex < iSize); iIndex ++)
		{
			IHandleVoiceCmd	*pCmdTarget = m_arSubscribers[iIndex];
			bHandled = pCmdTarget->HandleVoiceCmd( pPhrase );
		}
		EnableGrammar(true);
		::CoTaskMemFree( pPhrase);
	}

};





// Helper class and enum for parsing numbers
struct PN_Val
{
	LPCWSTR		wszVal;
	int			iVal;
};



// It assumes that the phrase is correct, matching the grammar description in the XML file
inline int	SAPI_ParseNumberHelper(SPPHRASE *pPhrase, ULONG iStart)
{
	static PN_Val	arTokens[] = 
	{
		{L"zero", 0},	{L"one", 1},	{L"two", 2},	{L"three", 3},	{L"four", 4},
		{L"five", 5},	{L"six", 6},	{L"seven", 7},	{L"eight", 8},	{L"nine", 9},
		{L"ten", 10},	{L"eleven", 11},{L"twelve", 12},{L"thirteen", 13},
		{L"fourteen", 14},{L"fifteen", 15},{L"sixteen", 16},	{L"seventeen", 17},
		{L"eighteen", 18},{L"nineteen", 19},
		{L"twenty", 20},	{L"thirty", 30},	{L"fourty", 40},	{L"fifty", 50},	
		{L"sixty", 60},	{L"seventy", 70},	{L"eighty", 80},	{L"ninety", 90},
		{L"hundred", 100},//...
	};

	CArray<int>	arValues;
	CArray<int> arMultipliers;
	
	int iVal = 0;
	bool bErrFlag = false;
	ULONG iCurrIndex = iStart;
	
	while( iCurrIndex < pPhrase->Rule.ulCountOfElements )
	{
		const WCHAR*	szDisplayText = pPhrase->pElements[iCurrIndex].pszDisplayText;
		size_t	index, size;
		bool	bFound = false;
		int		iTokenVal = 0;

		size = sizeof(arTokens)/sizeof(PN_Val);
		for( index = 0; !bFound && index < size; index ++)
		{
			if( wcsicmp(szDisplayText, arTokens[index].wszVal) == 0 )
			{
				iTokenVal = arTokens[index].iVal;
				bFound = true;
			}
		}

		if( !bFound )
		{
			bErrFlag  =true;
			iVal = 0;
			break;
		}

		if( iTokenVal == 100 )
		{
			iVal = 100*iVal;
		}
		else
		{
			iVal += iTokenVal;
		}
		iCurrIndex++;
	}
	
	return iVal;

}

#define DECLARE_VCOMMAND_MAP()\
public:\
	const VOICEMSG_ENTRY*	GetVoiceMessageMap();


#define BEGIN_VCOMMAND_MAP(ClassName)\
	const CVoiceCmdTargetT<ClassName>::VOICEMSG_ENTRY*	ClassName::GetVoiceMessageMap()\
	{\
		static VOICEMSG_ENTRY	m_entryMap[] = \
		{\

#define ON_VCOMMAND_SIMPLE(id, memberFn)\
		{id, 0, static_cast<VOICECMD_PROC>(memberFn), eNO_PARAM},\

#define ON_VCOMMAND_PARAM(id, paramIndex, memberFn)\
		{id, paramIndex, (VOICECMD_PROC)memberFn, eSINGLE_PARAM},\

#define ON_VCOMMAND_NBR_PARAM(id, paramIndex, memberFn)\
		{id, paramIndex, (VOICECMD_PROC)memberFn, eSINGLE_NBR_PARAM},\

#define ON_VCOMMAND_EX(id, memberFn)\
		{id, 0, (VOICECMD_PROC)memberFn, eALL},\

#define END_VCOMMAND_MAP()\
			{0, 0, NULL, eALL}\
		};\
		return m_entryMap;\
	}


#endif SPEECHRECOENV_H_INCLUDED
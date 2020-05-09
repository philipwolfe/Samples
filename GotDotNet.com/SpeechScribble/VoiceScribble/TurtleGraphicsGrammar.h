#ifndef LDNGRAMMAR_H_INCLUDED
#define LDNGRAMMAR_H_INCLUDED
#pragma once

#include "stdafx.h"
#include "TurtleGraphicsErr.h"
#include "Turtle.h"
#include "TurtleGraphicsDefs.h"




#ifdef  TurtleGraphicsTRACE
	#define _TurtleGraphics_TRACE	TRACE
#else
	#define _TurtleGraphics_TRACE	 __noop;
#endif







// standard variables
#define		VAR_COLOR	_T("COLOR")
#define		VAR_PEN	_T("PEN")
#define		VAR_SLEEP_TIME	_T("SLEEP_TIME")
#define		VAR_DELTA	_T("DELTA")
#define		VAR_STEP	_T("STEP")


// for semantic issues
enum eVarFlags
{
	eINITIALIZED = 0x0001,
	eUSED = 0x0002,
	ePREDEFINED = 0x0004,
};

enum eStateFlags
{
	eNO_FLAG =	0,
	eIF_HAS_ELSE = 0x0001,
	eCONDITION_WAS_TRUE= 0x0002,
};


#define MAKEINDENT(x)	\
{\
	_TurtleGraphics_TRACE("%3d: ", m_iCurrLine);\
	for(int __itmp = 0; __itmp < x; __itmp++)\
		_TurtleGraphics_TRACE("    ");\
}
class CTurtleGraphicsParser
{
public:
	CDC	*m_pDC;	// pDC to draw to
	CTurtle	m_turtle;
	bool	m_bExecuting;

protected:
	// runtime variables 
	bool	m_bIgnoreSleep;
	arTurtleGraphicsCmds *m_pArrTokens;
	int m_iCurrToken;
	int m_iCurrLine;
	bool m_bPreserveSemanticInfo;
	int m_iCurrIndent;
	bool m_bInFunction;
	
public:
	// generic vars
	bool	m_bErrorsOccured;
	CString	m_strErrorDescription;
	int m_iErrLine;
	bool	m_bWarningsOccured;
	CArray<stWarn>	m_arrWarns;

protected:
	struct stVar
	{
		CString strName;
		int iVal;
		int iDeclarationLine;
		DWORD dwFlags;
	};
	typedef CMap<CString, LPCSTR, stVar, stVar&>	SymTable;
	SymTable						m_globalSymTable;
	CArray<SymTable*, SymTable*&>	m_symTables;
	


	struct stState
	{
		stState()
		{
			flag = eNO_FLAG;
			iGotoLineNbr1 = 0;
			iToken1 = -1;
		}
		eTurtleGraphicsInstr cmd;
		int flag;
		
		int iGotoLineNbr1;
		int iToken1;
	};
	CArray<stState*>	m_stackStates;


	struct stJmpDesc
	{
		int jeLine;
		int jeToken;
		int jneLine;
		int jneToken;
		int flag;
	};


	struct stProcDecl
	{
		CString		strProcName;
		int			iGotoLineNbr;
		int			iToken;
		DWORD		flags;
	};
	CArray<stProcDecl>	m_arrProcs;


	CStringArray		m_arrCodeLines;
	CString				m_strCurrCodeLine;

	// this will hold the pointer to the editor
	ITurtleGraphicsEditorHandler* m_pEditorHandler;

public:
	CTurtleGraphicsParser()
	{
		// add the	predefined variables
		SymTable*	pAdd = &m_globalSymTable;
		m_symTables.Add(pAdd);
		
		m_pArrTokens = NULL;
		m_bPreserveSemanticInfo = false;
		m_pEditorHandler	=	NULL;

	}
	
	~CTurtleGraphicsParser()
	{
		Cleanup();
	}
	

	void	SetTurtleGraphicsEditorHandler(ITurtleGraphicsEditorHandler* pHandler)
	{
		m_pEditorHandler	=	pHandler;
	}

	bool	check(arTurtleGraphicsCmds*	pTokens)
	{

		InitializeParser();
		
		ASSERT( pTokens );
		m_pArrTokens = pTokens;

		if (pTokens->GetSize() == 0 )
			return true;
		
		InternalTurtleGraphicsInterpret();

		if( !m_bErrorsOccured )
		{
			if( m_pEditorHandler)
				m_pEditorHandler->SetFormattedCode(&m_arrCodeLines);
		}
		Cleanup();
		return !m_bErrorsOccured;
	}
	
	LPCTSTR	getCompileError()
	{
		return NULL;
	}

	bool	run(arTurtleGraphicsCmds*	pTokens, CDC*pDC, bool bIgnoreSleep = false)
	{
		bool bContinue = false;
		m_bIgnoreSleep = bIgnoreSleep;
		
		m_bPreserveSemanticInfo = true;
		bContinue = check(pTokens);

		m_bPreserveSemanticInfo = false;
		if( bContinue )
		{
			// compile before running
			ASSERT( pDC );
			ASSERT( pTokens );

			InitializeParser();

			m_pArrTokens = pTokens;
			m_bExecuting = true;
			m_pDC = pDC;

			InternalTurtleGraphicsInterpret();

			Cleanup();
			
			return !m_bErrorsOccured;
		}
		else
			return false;
	}

protected:
	void ClearSemanticInfo()
	{
		INT_PTR iSize = m_pArrTokens->GetSize() ;

		for(INT_PTR iIndex = 0; iIndex < iSize; iIndex ++ )
		{
			stState* pState = (stState*)m_pArrTokens->GetAt( iIndex).ptrSemanticData;
			if( pState )
				delete pState;
			m_pArrTokens->GetAt( iIndex).ptrSemanticData = NULL;

		}

	}

	void    VerifySymTableForUnusedSymbols( SymTable* pTable)
	{
		SymTable &table = *pTable;
		POSITION pos = table.GetStartPosition();

		while( pos != NULL )
		{
			CString	strName;
			stVar var;
			table.GetNextAssoc( pos, strName, var);
			if( !(var.dwFlags & eUSED) )
			{
				GenerateWarningEx( ewVARIABLE_NOTUSED, var.strName, var.iDeclarationLine);
			}
		}


	}


	bool	ProcLookup(LPCTSTR szName, stProcDecl& ppRet)
	{
		bool	bRet	=	false;
		INT_PTR iIndex, iLookupEnd;
		iLookupEnd = m_arrProcs.GetCount();
		for( iIndex = 0; !bRet && iIndex < iLookupEnd; iIndex ++ )
		{
			stProcDecl&	pCurr  = m_arrProcs.GetAt( iIndex );
			if( pCurr.strProcName.CompareNoCase( szName ) == 0 )
			{
				ppRet = pCurr;
				bRet = true;
			}
		}
		return bRet;
	}

	bool	ProcSetAt(LPCTSTR szName, stProcDecl& ppRet)
	{
		bool	bRet	=	false;
		INT_PTR iLookupEnd;
		iLookupEnd = m_arrProcs.GetCount();
		for( INT_PTR iIndex = 0; !bRet && iIndex < iLookupEnd; iIndex ++ )
		{
			if( m_arrProcs[iIndex].strProcName.CompareNoCase( szName ) == 0 )
			{
				m_arrProcs[iIndex] = ppRet;
				bRet = true;
			}
		}
		return bRet;
	}



	bool	SymLookup(LPCTSTR szName, stVar& ret, int iOnlyTop = 0)
	{
		bool	bRet	=	false;
		INT_PTR iLookupStart, iLookupEnd;
		iLookupStart = (m_symTables.GetSize() - 1);
		iLookupEnd = (iOnlyTop == 1)?(m_symTables.GetSize() - 1):0;
		for( INT_PTR iIndex = iLookupStart; !bRet && iIndex >= iLookupEnd; iIndex -- )
		{
			if(	m_symTables.GetAt(iIndex)->Lookup( szName, ret) )
				bRet = true;
		}
		return bRet;
	}

	bool	SymSetAt(LPCTSTR szName, stVar& ret)
	{
		bool	bRet	=	false;
		stVar	tmpRet;
		INT_PTR iTop = m_symTables.GetSize() - 1;
		ASSERT( iTop >= 0 );
		for( INT_PTR iIndex = iTop; !bRet && iIndex >= 0; iIndex -- )
		{
			if(m_symTables.GetAt(iIndex)->Lookup( szName, tmpRet))
			{
				// Symbol found in this map
				m_symTables.GetAt(iIndex)->SetAt( szName, ret);
				bRet = true;
			}
		}
		
		if( !bRet )
		{
			m_symTables.GetAt(iTop)->SetAt( szName, ret);
		}
		return bRet;
	}

	bool	SymDeclareVar(LPCTSTR szName, stVar& ret)
	{
		bool	bRet	=	true;
		stVar	tmpRet;
		INT_PTR iTop = m_symTables.GetSize() - 1;
		ASSERT( iTop >= 0 );
		if(m_symTables.GetAt(iTop)->Lookup( szName, tmpRet))
		{
			// Symbol found in this map
			bRet = false;
		}

		if( bRet )
		{
			m_symTables.GetAt(iTop)->SetAt( szName, ret);
		}
		return bRet;
	}

	void InitializeParser()
	{
		m_iCurrToken=0;
		m_iCurrLine = 0;
		m_bErrorsOccured = false;
		m_strErrorDescription.Empty();
		m_bWarningsOccured = false;
		m_arrWarns.RemoveAll();
		m_bExecuting = false;
		m_pDC = NULL;
		m_pArrTokens = NULL;
		m_iCurrIndent = 0;
		m_arrCodeLines.RemoveAll();
		m_turtle.SetStartPoint(TURTLE_START_X, TURTLE_START_Y);
		m_turtle.m_dAngle = 0.0;
		m_turtle.m_i360Angle  = 0;
		m_bInFunction = false;

		SetStandardVariable(VAR_COLOR, 0);
		SetStandardVariable(VAR_PEN, 1);
		SetStandardVariable(VAR_DELTA, 10);
		SetStandardVariable(VAR_STEP, 10);
		SetStandardVariable(VAR_SLEEP_TIME, 500);

	}

	bool GetVarValue(LPCTSTR szName, int& iRet)
	{
		stVar	var;
		iRet = 0;

		if( SymLookup( szName, var) )
		{
			iRet = var.iVal;
			if( !(var.dwFlags & eINITIALIZED) )
			{
				GenerateWarning( ewUNINIT_VAR);
			}
			return true;
		}
		return false;
	}

	void	SetStandardVariable(LPCTSTR szName, int iVal = 0)
	{
		stVar	varAdd;
		DWORD	dwPredefined = eINITIALIZED | eUSED | ePREDEFINED;

		varAdd.strName = szName;
		varAdd.dwFlags = dwPredefined;
		varAdd.iVal = iVal;
		varAdd.iDeclarationLine=0;
		m_globalSymTable.SetAt( varAdd.strName, varAdd);
	}

	void	Cleanup()
	{
		// Clear SymTables
		for( int iIndex = 0; iIndex  < m_symTables.GetSize(); iIndex ++ )
		{
			SymTable *pTable = m_symTables[iIndex];
			SymTable &table = *pTable;

			POSITION	pos = table.GetStartPosition();

			while( pos != NULL )
			{
				stVar var;
				CString	strKey;
				table.GetNextAssoc(pos, strKey, var);
				if( ! (var.dwFlags & ePREDEFINED) )
					table.RemoveKey( strKey );
			}
			
			if( iIndex > 0 )
			{
				// this is already an error
				delete pTable;
				m_symTables.RemoveAt( iIndex );
			}
		}
		m_symTables.RemoveAll();
		
		SymTable*	pAdd = &m_globalSymTable;
		m_symTables.Add(pAdd);

		m_pArrTokens = NULL;

		m_stackStates.RemoveAll();

		if( !m_bPreserveSemanticInfo )
			m_arrProcs.RemoveAll();

		m_iCurrIndent = 0;
	}


	void	TraceMemory()
	{
	
	#ifdef DEBUG
	#ifdef TurtleGraphicsTRACE_MEMORY
		_TurtleGraphics_TRACE("\n### Memory State ###\n");
		// Clear SymTables
		for( int iIndex = 0; iIndex  < m_symTables.GetSize(); iIndex ++ )
		{
			SymTable *pTable = m_symTables[iIndex];
			SymTable &table = *pTable;

			_TurtleGraphics_TRACE("## Map - %d\n", iIndex);

			POSITION	pos = table.GetStartPosition();

			while( pos != NULL )
			{
				stVar var;
				CString	strKey;
				table.GetNextAssoc(pos, strKey, var);
				_TurtleGraphics_TRACE(" %s   ---  %d\n", var.strName, var.iVal);
			}
		}
		_TurtleGraphics_TRACE("######\n\n");
	#endif
	#endif
	}

	void	InternalTurtleGraphicsInterpret()
	{
		ASSERT( m_pArrTokens != NULL );
		m_iCurrToken = 0;

		while( !m_bErrorsOccured && m_iCurrToken < m_pArrTokens->GetSize())
		{
			if( m_bExecuting )
				TraceMemory();
			TurtleGraphicsInterpretHelper();
		}


		// Check for stack state
		if( m_stackStates.GetSize() > 0 )
		{
			for( int iIndex = 0; iIndex < m_stackStates.GetSize(); iIndex ++ )
			{
				switch( m_stackStates.GetAt(iIndex)->cmd )
				{
					case eDO:
						GenerateError(eDO_WITHOUT_UNTIL);
						break;
					case eIF:
						GenerateError(eIF_WITHOUT_ENDIF);
						break;
					default:
						GenerateError(eINTERNAL_ERROR_1);
						break;
				}
			}
		}
		
		// Check for corrupted stack
		if( m_symTables.GetSize() != 1 )
		{
			// corrupted stack
			GenerateError(eINTERNAL_ERROR_2);
		}

		// check unused vars
		VerifySymTableForUnusedSymbols(m_symTables.GetAt(0));

		// erase Semantic Symbols
		if( !m_bPreserveSemanticInfo || m_bErrorsOccured )
			ClearSemanticInfo();
	}

	void TurtleGraphicsInterpretHelper()
	{
		// main switch block
		if( m_iCurrToken >= m_pArrTokens->GetSize() )
		{
			GenerateError(eUNEXPECTED_EOF);
			return;
		}

		stTurtleGraphicsCmd &cmd	=	(*m_pArrTokens)[m_iCurrToken];
		switch( cmd.cmd )
		{
			// commands that work in both modes :
			case eCLS:
			case eFORWARD:
			case eLEFT:
			case eRIGHT:
			case ePENUP:
			case ePENDOWN:
			case eSLEEP:
				SimpleTurtleGraphicsCommand(cmd);
				break;
			case eDECLARE:
				DeclareHandler(cmd);
				break;
			case ePROCEDURE:
				DeclareProcedureHandler(cmd);
				break;
			case eSTART:
				StartProcedureHandler(cmd);
				break;
			case eCALL:
				CallProcedureHandler(cmd);
				break;
			case eEND:
				EndProcedureHandler(cmd);
				break;
			case eSET:
				AssignHandler(cmd);
				break;
			case eDO:
				DoHandler(cmd);
				break;
			case eUNTIL:
				UntilHandler(cmd);
				break;
			case eIF:
				IfHandler(cmd);
				break;
			case eELSE:
				ElseHandler(cmd);
				break;
			case eENDIF:
				EndIfHandler(cmd);
				break;
			case eINCREMENT:
			case eDECREMENT:
			case eDIVIDE:
			case eMULTIPLY:
				ArithmeticHandler(cmd);
				break;

			default:;
				GenerateError(eEXPECTING_INSTRUCTION);
		}
	}

	void DeclareHandler(stTurtleGraphicsCmd& cmd)
	{
		stVar	var;
		var.strName = cmd.strLVal;
		if(var.strName.IsEmpty())
		{
			GenerateError(eVAR_NAME_MISSING);
			return;
		}

		if( SymLookup(var.strName, var, 1) )
		{
			GenerateError(eDUPLICATE_IDENTIFIER);
			return;
		}

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		var.dwFlags	=	0;
		var.iDeclarationLine = m_iCurrLine;
		SymDeclareVar(var.strName, var);
		m_iCurrToken++;
		m_iCurrLine++;
	}



	void DeclareProcedureHandler(stTurtleGraphicsCmd& cmd)
	{
		stProcDecl	procDecl;
		
		if(cmd.strLVal .IsEmpty())
		{
			GenerateError(eVAR_NAME_MISSING);
			return;
		}

		if( m_bExecuting )
		{
			// already declared. Assert it is there
			if( !ProcLookup(cmd.strLVal, procDecl) )
			{
				GenerateError(ePROC_UNKNOWN_IDENTIFIER);
				return;
			}
		}
		else
		{
			// Declare it
			if( ProcLookup(cmd.strLVal, procDecl) )
			{
				GenerateError(eDUPLICATE_IDENTIFIER);
				return;
			}
			procDecl.strProcName = cmd.strLVal;
			procDecl.iGotoLineNbr = -1;
			procDecl.iToken = -1;
			procDecl.flags = 0;

			m_arrProcs.Add( procDecl );

		}


		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		m_iCurrToken++;
		m_iCurrLine++;
	}

	void CallProcedureHandler(stTurtleGraphicsCmd& cmd)
	{
		stProcDecl	procDecl;

		if( !ProcLookup(cmd.strLVal, procDecl) )
		{
			GenerateError(ePROC_UNKNOWN_IDENTIFIER);
			return;
		}

		if( m_bExecuting )
		{
			stState	*pState = NULL;
			pState = new stState();
			pState->cmd	=	cmd.cmd;
			// set the return address to the next location
			pState->iGotoLineNbr1 = m_iCurrLine + 1;
			pState->iToken1 = m_iCurrToken + 1;

			// jump to the function start
			m_iCurrLine = procDecl.iGotoLineNbr;
			m_iCurrToken = procDecl.iToken;
			m_stackStates.Add( pState );
		}
		else
		{
			procDecl.flags |= eUSED;
			ProcSetAt( procDecl.strProcName, procDecl);

			// if compiling, just move to the next line
			m_iCurrToken++;
			m_iCurrLine++;
		}

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

	}

	
	void StartProcedureHandler(stTurtleGraphicsCmd& cmd)
	{
		stProcDecl	procDecl;

		if( !ProcLookup(cmd.strLVal, procDecl) )
		{
			GenerateError(ePROC_UNKNOWN_IDENTIFIER);
			return;
		}

		if( !m_bExecuting )
		{
			if( m_bInFunction )
			{
				GenerateError(eSUBPROCS_NOT_SUPPORTED);
			}
			m_bInFunction = true;
			procDecl.iGotoLineNbr = m_iCurrLine;
			procDecl.iToken = m_iCurrToken;
			procDecl.flags |= eINITIALIZED;
			ProcSetAt( procDecl.strProcName, procDecl);
		}
		else
		{
			// if the top of the stack IS NOT a function call, 
			// then the main program is over and a proc starts
			// stop executing
			stState	*pState	= NULL;
			INT_PTR iTop = m_stackStates.GetCount();

			if( iTop > 128 )
			{
				GenerateError( eRUNTIME_STACK_OVERFLOW );
				return;
			}

			if( iTop > 0 )
			{
				pState	=	m_stackStates.GetAt( iTop-1 );
			}
			if( !pState || pState->cmd != eCALL )
			{
				// The stack is empty. Therefore, this is not an invocation, but
				// the end of the main program
				// Forcing exit
				m_iCurrToken = (int)m_pArrTokens->GetSize();
				m_bInFunction = false;
				return;
			}
		}

		
		// Adding a new symbol table for the variables inside this procedure
		SymTable	*pProcMap = new SymTable();
		m_symTables.Add( pProcMap );

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		m_iCurrIndent++;

		m_iCurrToken++;
		m_iCurrLine++;
	}

	void EndProcedureHandler(stTurtleGraphicsCmd& cmd)
	{
		// remove the top map
		INT_PTR	iTop;

		// make sure we are in a function
		if( !m_bExecuting )
		{
			if( !m_bInFunction )
			{
				GenerateError( eEND_WITHOUT_START);
				return;
			}
			m_bInFunction  = false;
		}

		iTop = m_symTables.GetCount();

		if( iTop <= 1 )
		{
			GenerateError( eINTERNAL_ERROR_3);
			return;
		}

		// Adding a new symbol table for the variables inside this procedure
		SymTable	*pProcMap = m_symTables.GetAt( iTop-1 );
		m_symTables.RemoveAt( iTop-1 );
		ASSERT(pProcMap);
		delete pProcMap;

		m_iCurrIndent--;
		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		if( m_bExecuting )
		{
			// if the top of the stack IS NOT a function call, 
			// then this is an error (stop executing). It should not get  there anyway
			// else, take the return address from here
			stState	*pState	= NULL;
			INT_PTR iTop = m_stackStates.GetCount();
			if( iTop > 0 )
			{
				pState	=	m_stackStates.GetAt( iTop-1 );
			}
			if( !pState || pState->cmd != eCALL )
			{
				
				GenerateError(eINTERNAL_ERROR_3);
				return;
			}

			m_iCurrToken = pState->iToken1;
			m_iCurrLine = pState->iGotoLineNbr1;

			// pop the state
			m_stackStates.RemoveAt( iTop-1);
			delete pState;

			if( m_iCurrLine < 0 || m_iCurrToken < 0  )
			{
				// corruption of the stack?
				GenerateError(eINTERNAL_ERROR_3);
				return;
			}
		}
		else
		{
			m_iCurrToken++;
			m_iCurrLine++;
		}
	}


	void AssignHandler(stTurtleGraphicsCmd& cmd)
	{
		stVar	var;
		int     iParamValue;
		if(cmd.strLVal.GetLength() == 0)
		{
			GenerateError(eVAR_NAME_MISSING);
			return;
		}

		if( !SymLookup(cmd.strLVal, var) )
		{
			GenerateError(eUNKNOWN_IDENTIFIER);
			return;
		}

		// if the param is a string
		if( !cmd.strRVal.IsEmpty() )
		{
			if( !GetVarValue(cmd.strRVal, iParamValue) )
			{
				GenerateError(eUNKNOWN_IDENTIFIER);
				return;
			}
			
		}
		else
			iParamValue = cmd.iNumParam1;


		var.iVal = iParamValue;
		var.dwFlags |= eINITIALIZED;

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		SymSetAt(var.strName, var);
		m_iCurrToken++;
		m_iCurrLine++;
	}

	void DoHandler(stTurtleGraphicsCmd& cmd)
	{
		
		stState	*pState = NULL;
		
		pState = new stState();
		
		pState->cmd=	cmd.cmd;
		pState->iGotoLineNbr1 = m_iCurrLine;
		pState->iToken1 = m_iCurrToken;

		m_stackStates.Add( pState );
		
		// Adding a new symbol table for the variables inside this block
		SymTable	*pDoBlockMap = new SymTable();
		m_symTables.Add( pDoBlockMap );

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();
		m_iCurrIndent++;


		m_iCurrToken++;
		m_iCurrLine++;
	}

	void UntilHandler(stTurtleGraphicsCmd& cmd)
	{
		int iStackSize = (int)m_stackStates.GetSize();
		if( iStackSize == 0 )
		{
			GenerateError(eUNTIL_WITHOUT_DO);
			return;
		}
		
		stState *pState = m_stackStates[iStackSize - 1];
		stState	state = *pState;
		if( state.cmd  != eDO )
		{
			GenerateError(eUNTIL_WITHOUT_DO);
			return;
		}
		
		m_iCurrIndent--;

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		
		// parse the simple boolean expression
		bool	bEvaluate = false;
		m_iCurrToken ++;
		if( m_iCurrToken >= m_pArrTokens->GetCount() )
			return;
		SimpleBooleanExpressionHelper( bEvaluate );
		AddCurrCodeLine();
		

		if( m_bErrorsOccured )
			return;

		// remove the matching DO from the state
		m_stackStates.RemoveAt( iStackSize - 1 );
		delete pState;
		ASSERT( m_symTables.GetSize() > 0);
		
		SymTable	*pDoBlockMap = m_symTables.GetAt( m_symTables.GetSize() - 1);
		VerifySymTableForUnusedSymbols(pDoBlockMap);
		m_symTables.RemoveAt(m_symTables.GetSize() - 1);
		delete pDoBlockMap;


		if( m_bExecuting )
		{
			if( !bEvaluate )
			{
				// go back to Do
				// remove DO from the stack
				stJmpDesc	*pJmp = reinterpret_cast<stJmpDesc*>(cmd.ptrSemanticData);
				ASSERT(pJmp);
				m_iCurrLine  = pJmp->jneLine;
				m_iCurrToken = pJmp->jneToken;
				return;
			}
		}
		else
		{
			// Add a JMP description as semantic info
			stJmpDesc	*pJmp = new stJmpDesc;
			pJmp->jneLine = state.iGotoLineNbr1;
			pJmp->jneToken = state.iToken1;
			cmd.ptrSemanticData	=	(DWORD_PTR)pJmp;
		}


		m_iCurrLine ++;
	}

	void IfHandler(stTurtleGraphicsCmd& cmd)
	{
		stState	*pState = NULL;
		
		
		pState = new stState;
		pState->cmd=	cmd.cmd;


		pState->iGotoLineNbr1 = m_iCurrLine;
		pState->iToken1 = m_iCurrToken;

		if( !m_bExecuting )
		{
			stJmpDesc	*pJmp = new stJmpDesc();
			pJmp->jneLine = -1;
			pJmp->jneToken = -1;
			pJmp->jeLine = -1;
			pJmp->jeToken = -1;
			pJmp->flag=0;
			cmd.ptrSemanticData	=	(DWORD_PTR)pJmp;
		}
		
		m_iCurrToken++;
		
		
		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		bool	bEvaluate = false;

		if( m_iCurrToken >= m_pArrTokens->GetCount() )
			return;
		SimpleBooleanExpressionHelper( bEvaluate );

		AddCurrCodeLine();
		
		m_iCurrIndent++;

		if( m_bErrorsOccured )
			return;

		m_stackStates.Add( pState );
		
		// Adding a new symbol table for the variables inside this block
		SymTable	*pIfBlockMap = new SymTable();
		m_symTables.Add( pIfBlockMap );

		if( m_bExecuting )
		{
			if(bEvaluate)
			{
				pState->flag |= eCONDITION_WAS_TRUE;
				m_iCurrLine ++;
			}
			else
			{
				pState->flag &= ~eCONDITION_WAS_TRUE;
				// condition was not true

				stJmpDesc	*pJmp = reinterpret_cast<stJmpDesc*>(cmd.ptrSemanticData);
				ASSERT(pJmp);
				if( pJmp->flag & eIF_HAS_ELSE )
				{
					// goto ELSE
					m_iCurrLine = pJmp->jneLine;
					m_iCurrToken = pJmp->jneToken;
				}
				else
				{
					// goto ENDIF
					m_iCurrLine = pJmp->jeLine;
					m_iCurrToken = pJmp->jeToken;
				}
			}
			return;
		}
		m_iCurrLine++;
	}



	void ElseHandler(stTurtleGraphicsCmd& cmd)
	{
		int iStackSize = (int)m_stackStates.GetSize();
		if( iStackSize == 0 )
		{
			GenerateError(eELSE_WITHOUT_IF);
			return;
		}
		
		stState	&state = *m_stackStates[iStackSize-1];
		if( state.cmd  != eIF )
		{
			GenerateError(eELSE_WITHOUT_IF);
			return;
		}

		m_iCurrIndent--;
		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();
		m_iCurrIndent++;

		// removing the IF sym table
		SymTable	*pIfBlockMap = m_symTables.GetAt( m_symTables.GetSize() - 1);
		VerifySymTableForUnusedSymbols( pIfBlockMap);
		m_symTables.RemoveAt(m_symTables.GetSize() - 1);
		delete pIfBlockMap;


		// Adding a new symbol table for the variables inside this block
		SymTable	*pDoBlockMap = new SymTable();
		m_symTables.Add( pDoBlockMap );


		ASSERT(state.iToken1 < m_pArrTokens->GetSize());
		stJmpDesc	*pJmp = reinterpret_cast<stJmpDesc*>(m_pArrTokens->GetAt(state.iToken1).ptrSemanticData);
		ASSERT(pJmp);
		
		if( m_bExecuting )
		{
			// executing
			ASSERT(pJmp->flag & eIF_HAS_ELSE);
			
			if(state.flag & eCONDITION_WAS_TRUE)
			{
				// if the condition was true, jump to ENDIF
				m_iCurrLine = pJmp->jeLine;
				m_iCurrToken = pJmp->jeToken;
			}
			else
			{
				m_iCurrToken ++;
				m_iCurrLine++;
			}
		}
		else
		{
			// compiling
			if( pJmp->flag & eIF_HAS_ELSE )
			{
				GenerateError(eDUPLICATE_ELSE_WITHIN_IF);
				return;
			}
			pJmp->flag  |= eIF_HAS_ELSE;
			pJmp->jneLine = m_iCurrLine;
			pJmp->jneToken = m_iCurrToken;

			m_iCurrToken ++;
			m_iCurrLine++;
		}
	}


	void EndIfHandler(stTurtleGraphicsCmd& cmd)
	{
		int iStackSize = (int)m_stackStates.GetSize();
		if( iStackSize == 0 )
		{
			GenerateError(eENDIF_WITHOUT_IF);
			return;
		}
		
		stState	*pState = m_stackStates[iStackSize-1];
		stState	state = *pState;

		if( state.cmd  != eIF )
		{
			GenerateError(eENDIF_WITHOUT_IF);
			return;
		}

		ASSERT(state.iToken1 < m_pArrTokens->GetSize());
		stJmpDesc	*pJmp = reinterpret_cast<stJmpDesc*>(m_pArrTokens->GetAt(state.iToken1).ptrSemanticData);
		ASSERT(pJmp);
		
		pJmp->jeLine = m_iCurrLine;
		pJmp->jeToken = m_iCurrToken;

		m_iCurrIndent--;
		
		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		// removing the IF or the ELSE symbol table
		SymTable	*pIfOrElseBlockMap = m_symTables.GetAt( m_symTables.GetSize() - 1);
		VerifySymTableForUnusedSymbols( pIfOrElseBlockMap);
		m_symTables.RemoveAt(m_symTables.GetSize() - 1);
		delete pIfOrElseBlockMap;

		m_stackStates.RemoveAt( iStackSize-1 );	
		delete pState;
		m_iCurrToken ++;
		m_iCurrLine++;
	}
	
	
	void SimpleBooleanExpressionHelper(bool& bEvalResult)
	{
		// syntax of a simple bool op : <variable> <operator> <value>
		stVar		var;
		ASSERT( m_iCurrToken < m_pArrTokens->GetCount() );
		stTurtleGraphicsCmd &cmd	=	(*m_pArrTokens)[m_iCurrToken];
		int iParamValue;


		if( cmd.strLVal.GetLength() == 0 )
		{
			GenerateError(eVAR_NAME_MISSING);
		}
		
		if( !SymLookup( cmd.strLVal, var) )
		{
			GenerateError(eUNKNOWN_IDENTIFIER);
		}

		if( !(var.dwFlags & eINITIALIZED) )
		{
			GenerateWarningEx( ewUNINIT_VAR, var.strName, m_iCurrLine);
		}

		// if the param is a string
		if( !cmd.strRVal.IsEmpty() )
		{
			if( !GetVarValue(cmd.strRVal, iParamValue) )
			{
				GenerateError(eUNKNOWN_IDENTIFIER);
				return;
			}
			
		}
		else
			iParamValue = cmd.iNumParam1;


		// Update the map, mark var as used
		var.dwFlags |= eUSED;
		SymSetAt(var.strName, var);

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);

		switch(cmd.cmd)
		{
			case eLEQ:// <=
				bEvalResult = var.iVal <= iParamValue;
				break;
			case eGEQ:	// >=
				bEvalResult = var.iVal >= iParamValue;
				break;
			case eEQ:	// ==
				bEvalResult = var.iVal == iParamValue;
				break;
			case eGT:	// >
				bEvalResult = var.iVal > iParamValue;
				break;
			case eLT:	// <
				bEvalResult = var.iVal < iParamValue;
				break;
			case eDIFF:	// !=*/
				bEvalResult = var.iVal != iParamValue;
				break;
			default:
				GenerateError(eEXPECTING_BOOLEAN_EXP);
				break;
		}
		
		CString strAdd;

		m_iCurrToken ++;
	}
	


	void ArithmeticHandler(stTurtleGraphicsCmd& cmd)
	{
		// syntax of a simple bool op : <variable> <operator> <value>
		stVar		var;
		int			iParamValue=  0;

		if( cmd.strLVal.GetLength() == 0 )
		{
			GenerateError(eVAR_NAME_MISSING);
		}
		
		if( !SymLookup( cmd.strLVal, var) )
		{
			GenerateError(eUNKNOWN_IDENTIFIER);
		}

		if( !(var.dwFlags & eINITIALIZED) )
		{
			GenerateWarning( ewUNINIT_VAR);
		}

		// if the param is a string
		if( !cmd.strRVal.IsEmpty() )
		{
			if( !GetVarValue(cmd.strRVal, iParamValue) )
			{
				GenerateError(eUNKNOWN_IDENTIFIER);
				return;
			}
			
		}
		else
			iParamValue = cmd.iNumParam1;



		// Update the map, mark var as used
		var.dwFlags |= eUSED;

		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);


		switch(cmd.cmd)
		{
			case eINCREMENT:// +=
				if( m_bExecuting )
				{
					var.iVal = var.iVal + iParamValue;
				}
				break;
			case eDECREMENT:// -=
				if( m_bExecuting )
				{
					var.iVal = var.iVal - iParamValue;
				}
				break;
			case eMULTIPLY:// *=
				if( m_bExecuting )
				{
					var.iVal = var.iVal * iParamValue;
				}
				break;
			case eDIVIDE:// /=
				if( m_bExecuting )
				{
					if( iParamValue != 0 )
					{
						var.iVal = var.iVal / iParamValue;
					}
					else
					{
						GenerateError(eDIVISION_BY_ZERO);
					}
				}
				break;

			default:
				GenerateError(eEXPECTING_BOOLEAN_EXP);
				break;
		}

		AddCurrCodeLine();

		SymSetAt(var.strName, var);
		m_iCurrToken ++;
		m_iCurrLine ++;
	}
	void GenerateError(eTurtleGraphicsError	err)
	{
		if( !m_bErrorsOccured )
		{
			// ony keep the first error
			m_bErrorsOccured = true;
			m_strErrorDescription = CTurtleGraphicsErrorProvider::GetErrorMessage( err );
			m_iErrLine = m_iCurrLine;
		}
	}

	void GenerateWarning(eTurtleGraphicsWarn	warn)
	{
		m_bWarningsOccured = true;
		stWarn	addWarn;
		addWarn.line = m_iCurrLine;
		addWarn.warn = CTurtleGraphicsErrorProvider::GetWarningMessage( warn );
		m_arrWarns.Add(addWarn);
	}

	void GenerateWarningEx(eTurtleGraphicsWarn	warn, CString& strExtra, int iLine)
	{
		m_bWarningsOccured = true;
		stWarn	addWarn;

		CString strFormat;
		strFormat = CTurtleGraphicsErrorProvider::GetWarningMessage( warn );
		addWarn.line = iLine;
		addWarn.warn.Format(strFormat, strExtra);
		
		m_arrWarns.Add(addWarn);
	}


	void AddCurrCodeLine()
	{
		CString strLine;

		MAKEINDENT( m_iCurrIndent);
		_TurtleGraphics_TRACE("%s\n", m_strCurrCodeLine);

		for(int __itmp = 0; __itmp < m_iCurrIndent; __itmp++)\
			strLine += ("    ");


		strLine += m_strCurrCodeLine;
		
		if( !m_bExecuting )
		{
			m_arrCodeLines.Add( strLine);
		}
		else
		{
			if( m_pEditorHandler)
				m_pEditorHandler->HighlightLine(m_iCurrLine);
		}
		m_strCurrCodeLine.Empty();
	}


	protected:

public:
		
	// actually, this is the only function using the DC
	// it treats all the simple primitives
	void SimpleTurtleGraphicsCommand( stTurtleGraphicsCmd& cmd )
	{
		int iStep;
		int iDelta;
		int iSleepTime;
		int iPen = 0;
		int iColor = 0;

		GetVarValue( VAR_SLEEP_TIME, iSleepTime);
		GetVarValue( VAR_STEP, iStep);
		GetVarValue( VAR_DELTA, iDelta);
		GetVarValue( VAR_COLOR, iColor);
		GetVarValue(VAR_PEN, iPen);

		int		iParamValue = 0;
		iColor = iColor %16;

		// if the param is a string
		if( !cmd.strRVal.IsEmpty() )
		{
			if( !GetVarValue(cmd.strRVal, iParamValue) )
			{
				GenerateError(eUNKNOWN_IDENTIFIER);
				return;
			}
			
		}
		else
			iParamValue = cmd.iNumParam1;
		
		CPoint	ptStart, ptEnd;
		if( m_bExecuting)
			ptStart.SetPoint( m_turtle.X(), m_turtle.Y() );
		
		TurtleGraphicsLex_GetCmdDescription( cmd, m_strCurrCodeLine);
		AddCurrCodeLine();

		switch( cmd.cmd )
		{
			// commands that work in both modes :
			case eCLS:
				{
					if( m_bExecuting && m_pDC)
					{
						CRect	rc;
						rc.left = m_turtle.m_nLeftBoundary;
						rc.top = m_turtle.m_nTopBoundary;
						rc.right = m_turtle.m_nRightBoundary;
						rc.bottom = m_turtle.m_nBottomBoundary;
						rc.InflateRect(50, 50);
						
						m_pDC->LPtoDP(&rc);

						CBrush	brush;
						brush.CreateSolidBrush(m_pDC->GetBkColor());
						m_pDC->FillRect(rc, &brush);
					}


				}
				break;
				// call CLS handler, whatever that is
			case eFORWARD:
				m_turtle.Forward( (iParamValue != 0 ) ? iParamValue : iStep);
				break;
			case eLEFT:
				m_turtle.OffsetAngle( (iParamValue != 0 ) ? -iParamValue : -iDelta);
				break;
			case eRIGHT:
				m_turtle.OffsetAngle( (iParamValue != 0 ) ? (iParamValue) : (iDelta));
				break;
			case ePENUP:
				m_turtle.m_bPenDown = false;
				break;
			case ePENDOWN:
				m_turtle.m_bPenDown = true;
				break;
			case eSLEEP:
				if( m_bExecuting && !m_bIgnoreSleep)
					::Sleep(iParamValue);
				break;
			default:
				ASSERT(FALSE);
		}


		if( m_bExecuting )
		{
			ptEnd.SetPoint( m_turtle.X(), m_turtle.Y() );
			m_pDC->LPtoDP(&ptStart);
			m_pDC->LPtoDP(&ptEnd);


			if( m_turtle.m_bPenDown && ptStart != ptEnd)
			{
				CPen	pen;
				
				pen.CreatePen( PS_SOLID, iPen, g_arrTurtleColors[iColor]);
				CPen* pOldPen = m_pDC->SelectObject(&pen);

				m_pDC->MoveTo(ptStart);
				m_pDC->LineTo(ptEnd);
				m_pDC->SelectObject( pOldPen );

			}
		}

		m_iCurrToken++;
		m_iCurrLine++;
	}



};

#endif LDNGRAMMAR_H_INCLUDED

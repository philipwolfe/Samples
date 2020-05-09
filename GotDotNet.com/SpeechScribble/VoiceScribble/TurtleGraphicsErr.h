#ifndef _TurtleGraphicsERR_H_INCLUDED
#define _TurtleGraphicsERR_H_INCLUDED

#pragma once

enum eTurtleGraphicsError
{
	eERR_UNK = 1,
	eVAR_NAME_MISSING,	// DECLARE without params 
	eDUPLICATE_IDENTIFIER,	// DECLARE twice or overriding std var
	eUNKNOWN_IDENTIFIER,
	eUNEXPECTED_EOF,
	eUNTIL_WITHOUT_DO,
	eDO_WITHOUT_UNTIL,
	eEXPECTING_BOOLEAN_EXP,
	eENDIF_WITHOUT_IF,
	eELSE_WITHOUT_IF,
	eIF_WITHOUT_ENDIF,
	eDUPLICATE_ELSE_WITHIN_IF,
	eEXPECTING_INSTRUCTION,
	eSUBPROCS_NOT_SUPPORTED,
	ePROC_UNKNOWN_IDENTIFIER,
	eEND_WITHOUT_START,
	eDIVISION_BY_ZERO,
	eRUNTIME_STACK_OVERFLOW,


	eLEX_UNKNOWN_CHAR,
	eLEX_COMMAND_EXPECTED,
	eLEX_PARAM_EXPECTED,
	eLEX_VARIABLE_EXPECTED,
	eLEX_OPERATOR_EXPECTED,

	eINTERNAL_ERROR_1,
	eINTERNAL_ERROR_2,
	eINTERNAL_ERROR_3,
};

enum eTurtleGraphicsWarn
{
	ewUNINIT_VAR,	// Uninitialized variable	
	ewVARIABLE_NOTUSED, // variable not used
};


class CTurtleGraphicsErrorProvider
{
protected:
	struct stErr
	{
		eTurtleGraphicsError err;
		LPCTSTR szMsg;
	};

	struct stWarn
	{
		eTurtleGraphicsWarn err;
		LPCTSTR szMsg;
	};

public:
	static LPCTSTR	GetErrorMessage(eTurtleGraphicsError err)
	{
		static stErr arrMsgs[] = 
		{
			{eERR_UNK, _T("Unknown error")},
			{eVAR_NAME_MISSING, _T("Variable name missing: You cannot declare, assign or evaluate without  specifying a variable name")},
			{eDUPLICATE_IDENTIFIER, _T("An identifier with this name already exists")},
			{eUNKNOWN_IDENTIFIER, _T("Unknown identifier")},
			{eUNEXPECTED_EOF, _T("Unexpected enf of file")},
			{eUNTIL_WITHOUT_DO, _T("'UNTIL' found without matching 'DO'")},
			{eDO_WITHOUT_UNTIL, _T("'DO' found without matching 'UNTIL'")},
			{eEXPECTING_BOOLEAN_EXP, _T("'IF' or 'DO' statements must be followed by a boolean expression")},
			{eENDIF_WITHOUT_IF, _T("'ENDIF' found without matching 'IF'")},
			{eELSE_WITHOUT_IF, _T("'ELSE' found without matching 'IF'")},
			{eIF_WITHOUT_ENDIF, _T("'IF' found without matching 'ENDIF'")},
			{eDUPLICATE_ELSE_WITHIN_IF, _T("One 'IF' may contain a single 'ELSE'. You should have known this!")},
			{eEXPECTING_INSTRUCTION, _T("An instruction was expected!")},
			{eSUBPROCS_NOT_SUPPORTED, _T("Procs inside procs are not supported")},
			{ePROC_UNKNOWN_IDENTIFIER, _T("Unknown identifier or not a procedure name")},
			{eEND_WITHOUT_START, _T("'END' found without matching 'START'")},
			{eDIVISION_BY_ZERO, _T("Runtime error: division by zero")},
			{eRUNTIME_STACK_OVERFLOW, _T("Runtime error: the internal stack overflowed")},
			{eLEX_UNKNOWN_CHAR, _T("Unrecognized character")},
			{eLEX_COMMAND_EXPECTED, _T("Keyword expected. A variable or a number was found")},
			{eLEX_PARAM_EXPECTED, _T("R-Value expected.")},
			{eLEX_VARIABLE_EXPECTED, _T("L-Value expected.")},
			{eLEX_OPERATOR_EXPECTED, _T("Assignment or Boolean operartor expected.")},
			{eINTERNAL_ERROR_1, _T("Internal compiler error: 0x0101")},
			{eINTERNAL_ERROR_2, _T("Internal compiler error: 0x0102")},
			{eINTERNAL_ERROR_3, _T("Internal compiler error: 0x0103")},
		};

		for( int iIndex = 0; iIndex  <sizeof(arrMsgs)/sizeof(stErr); iIndex ++ )
		{
			if( arrMsgs[iIndex].err == err )
				return arrMsgs[iIndex].szMsg;
		}
		return NULL;
	}
	
	
	static LPCTSTR	GetWarningMessage(eTurtleGraphicsWarn err)
	{
		static stWarn arrMsgs[] = 
		{
			{ewUNINIT_VAR, _T("A variable ('%s') is used before being initialized")},
			{ewVARIABLE_NOTUSED, _T("A variable ('%s') is never used")},

		};

		for( int iIndex = 0; iIndex  <sizeof(arrMsgs)/sizeof(stErr); iIndex ++ )
		{
			if( arrMsgs[iIndex].err == err )
				return arrMsgs[iIndex].szMsg;
		}
		return NULL;
	}


};
#endif// _TurtleGraphicsERR_H_INCLUDED
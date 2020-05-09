#ifndef TurtleGraphicsSCANNER_H_INCLUDED
#define TurtleGraphicsSCANNER_H_INCLUDED

#pragma once
#include "TurtleGraphicsGrammar.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif


enum eTokenType
{
	eTokenError,
	eTokenString,
	eTokenInt,
	eTokenOperator
};

#define MAX_OPERATOR_LENGTH 2

// VERY, VERY simple scanner for TurtleGraphics commands. The stream is an array. Can be replaced with any 
// stream, it is masked by GetNextChar() and PutBackChar()

class CTurtleGraphicsScanner
{
protected:
	// stream info
	CString	m_strStream;
	int		m_iCurrPos;	//	 for string class streaming
	int		m_iCurrLine;


	// the current cmd, to be filled by the scanner
	stTurtleGraphicsCmd	m_cmd;


public:
	bool	m_bErrorsOccured;
	CString m_strErrorDescription;
	int		m_iErrLine;
public:
	CTurtleGraphicsScanner(){}
	~CTurtleGraphicsScanner(){}

	

	// Override these three functions to change the source
	// sets the input data
public:	
	void	SetStream(CString&		str)
	{
		m_bErrorsOccured = false;
		m_strErrorDescription.Empty();
		m_iErrLine = -1;
		m_iCurrLine = 0;
		
		m_strStream	=	str;
		m_iCurrPos = 0;
	}

protected:
	// Can only return OK or EOF
	eLexError	GetNextChar(TCHAR& tch)
	{
		if( m_iCurrPos >= m_strStream.GetLength() )
			return eLEX_EOF;

		tch = m_strStream.GetAt( m_iCurrPos++ );
		if( tch == '\r' )
		{
			if( m_iCurrPos < m_strStream.GetLength() )
			{
				tch = '\n';
				
				if( tch == m_strStream.GetAt( m_iCurrPos ) )
				{
					m_iCurrPos ++;
				}
			}
		}
		return eLEX_OK;
	}

	void	PutBackChar()
	{
		if( m_iCurrPos > 0 )
			m_iCurrPos --;
	}

	// end 


public:
	eLexError	GetNextTurtleGraphicsCmd(stTurtleGraphicsCmd& cmd)
	{
		eLexError	ret = eLEX_EOF;

		m_cmd.Clean();

		ret = GetCommand();

		if( ret == eLEX_OK )
		{
			cmd = m_cmd;
			cmd.strLVal.MakeUpper();
			cmd.strRVal.MakeUpper();
		}

		return ret;
	}


protected:
	int			IsOperator(TCHAR tch)
	{
		int iRet = 0;
		iRet =	(tch == '+') ||
				(tch == '-') ||
				(tch == '/') ||
				(tch == '*') ||
				(tch == '<') ||
				(tch == '>') ||
				(tch == '!') ||
				(tch == '=');

		return iRet;
	}

	// GetNextSimpleToken
	eLexError	GetNextSimpleToken(CString& strTok, eTokenType& type)
	{
		eLexError ret = eLEX_OK;
		strTok.Empty();
		type = eTokenError;


		TCHAR tch;
		do
		{
			ret = GetNextChar(tch);
			if( tch == '\n' )
				m_iCurrLine ++;
		}while( ret == eLEX_OK && _istspace(tch));
		
		if( ret != eLEX_OK )
			return ret;

		// Int
		if( _istdigit(tch) )
		{
			// !!! No support for negatives
			type = eTokenInt;
			do
			{
				strTok += tch;
				ret = GetNextChar(tch);
			}while( ret == eLEX_OK && _istdigit(tch));
			// put back the last read char 
			if( ret == eLEX_OK)
				PutBackChar();

			if( ret == eLEX_EOF )
				ret = eLEX_OK;

			// return eLEXOK or error
			return ret;
		}

		// Var - string
		// Grammar : [_a-zA-Z][_a-zA-Z0-9]*
		if( _istalpha(tch) || (tch == '_') )
		{
			type = eTokenString;
			do
			{
				strTok += tch;
				ret = GetNextChar(tch);
			}while( ret == eLEX_OK && (_istdigit(tch) || _istalpha(tch) || (tch == '_')) );
			// put back the last read char 
			if( ret == eLEX_OK)
				PutBackChar();

			if( ret == eLEX_EOF )
				ret = eLEX_OK;
			// return eLEXOK or error
			return ret;
		}
		

		// Operator - <, <=, >, >=, ==, =, !=, +=, -=, *=, /=
		if( IsOperator(tch) )
		{
			type = eTokenOperator;
			do
			{
				strTok += tch;
				ret = GetNextChar(tch);
			}while( ret == eLEX_OK && IsOperator(tch) && strTok.GetLength() <= MAX_OPERATOR_LENGTH );
			// put back the last read char 
			PutBackChar();

			if( ret == eLEX_EOF )
				ret = eLEX_OK;
			// return eLEXOK or error
			return ret;
		}

		GenerateError(eLEX_UNKNOWN_CHAR);
		return eLEX_UNK;
	}

	eLL1State	GetLL1State( CString& strTok )
	{
		size_t iIndex, iSize;
		eLL1State	ret = eLL1VariableStmtStart;
		iSize	=	sizeof( m_arTurtleGraphicsLexDesc )/ sizeof(stLexDesc);

		for( iIndex = 0; (ret == eLL1VariableStmtStart) && (iIndex < iSize); iIndex ++ )
		{
			if( strTok.CompareNoCase(m_arTurtleGraphicsLexDesc[iIndex].szString) == 0 )
			{
				m_cmd.cmd	=	m_arTurtleGraphicsLexDesc[iIndex].instr;
				ret = m_arTurtleGraphicsLexDesc[iIndex].LL1State;
			}
		}
		
		return ret;
	}

	eLexError	GetCommand()
	{
		CString	strTok;
		m_cmd.Clean();
		
		eTokenType type;
		eLexError	err = GetNextSimpleToken(strTok, type);

		if( err != eLEX_OK )
			return err;

		if( type == eTokenString )
		{
			eLL1State	LL1State = GetLL1State(strTok);

			switch( LL1State )
			{
				case eLL1StmtCmd:
					return StmtCmd();
				case eLL1StmtCmdParam:
					return StmtCmdParam();
				case eLL1StmtCmdVarOperatorNbr:
					return StmtCmdVarOperatorNbr();
				case eLL1VariableStmtStart:
					return VariableStmtStart(strTok);
				default:;
			}
		}

		GenerateError(eLEX_COMMAND_EXPECTED);
		return eLEX_UNK;
	}




	// General form: CMD
	// DO
	// ELSE
	// IF
	eLexError	StmtCmd()
	{
		// simple cmds are clear
		return eLEX_OK;
	}

	// General form: CMD <SOMETHING>
	// FORWARD 100
	// DECLARE VARIABLE
	eLexError	StmtCmdParam()
	{
		// Get the next token
		CString	strTok;
		eTokenType type;
		eLexError	err = GetNextSimpleToken(strTok, type);

		if( err != eLEX_OK )
			return err;

		switch( m_cmd.cmd )
		{
			case eFORWARD:
			case eLEFT:
			case eRIGHT:
			case eSLEEP:
				switch( type )
				{
				case eTokenInt:
					m_cmd.iNumParam1 = _ttoi( strTok );
					break;
				case eTokenString:
					m_cmd.strRVal = strTok;
					break;
				default:
					{
						GenerateError(eLEX_PARAM_EXPECTED);
						err = eLEX_UNK;
					}
				}
				break;
			case eDECLARE:
			case ePROCEDURE:
			case eCALL:
			case eSTART:
				{
					if( type != eTokenString)
					{
						GenerateError(eLEX_VARIABLE_EXPECTED);
						err = eLEX_UNK;
					}
					else
					{
						m_cmd.strLVal = strTok;
					}
				}
				break;
			default:
				GenerateError(eLEX_COMMAND_EXPECTED);
				err = eLEX_UNK;
		}

		
		return err;
	}


	// General form: CMD <VARIABLE> <OPERATOR> <NBR>
	// SET VARIABLE = 100
	eLexError	StmtCmdVarOperatorNbr()
	{
		
		CString	strVariable, strOperator, strRVal;
		int		iNbr;
		
		eTokenType type;
		eLexError	err;
		
		// Getting the var name
		err = GetNextSimpleToken(strVariable, type);
		if( err != eLEX_OK || type != eTokenString )
			return err;

		// Getting the operator name
		err = GetNextSimpleToken(strOperator, type);
		if( err != eLEX_OK || type != eTokenOperator)
			return err;
		
		// Getting the number
		err = GetNextSimpleToken(strRVal, type);
		if( err != eLEX_OK || 
			( (type != eTokenInt) && (type != eTokenString)) )
			return err;

		

		switch( m_cmd.cmd )
		{
			case eSET:
				if( strOperator.CompareNoCase (_T("=") ) == 0)
				{
					if( type == eTokenInt )
					{
						iNbr = _ttoi(strRVal);
						m_cmd.iNumParam1 = iNbr;
					}
					else
					{
						m_cmd.strRVal = strRVal;
					}
					m_cmd.strLVal = strVariable;
					
				}
				else
				{
					GenerateError(eLEX_COMMAND_EXPECTED);
					err = eLEX_UNK;
				}
				break;
			default:
				err = eLEX_UNK;
		}

		return err;
	}

	// example :
	// var <= 123
	// a += 10
	eLexError VariableStmtStart(CString& strVarName)
	{
		// The statement started with a variable
		m_cmd.strLVal = strVarName;
		CString	strOperator, strRVal;
		int		iNbr;
		
		eTokenType type;
		eLexError	err = eLEX_OK;
		
		// Getting the var name
		err = GetNextSimpleToken(strOperator, type);
		if( err != eLEX_OK || type != eTokenOperator)
		{
			return err;
		}
		
		// Gets the LL1 State. It will set the cmd type
		eLL1State	LL1State = GetLL1State(strOperator);
		if( LL1State  != eLL1StmtRValCmdParam )
		{
			GenerateError(eLEX_OPERATOR_EXPECTED);
			err = eLEX_UNK;
			return err;
		}


		// Getting the number
		err = GetNextSimpleToken(strRVal, type);
		if( err != eLEX_OK || 
		    ( (type != eTokenInt) && (type != eTokenString) )  )
			return err;

		if( type == eTokenInt )
		{
			iNbr = _ttoi( strRVal );
			m_cmd.iNumParam1 = iNbr;
		}
		else
		{
			m_cmd.strRVal = strRVal;	
		}
		
		return err;
	}
	
	
	
	void GenerateError(eTurtleGraphicsError	err)
	{
		m_bErrorsOccured = true;
		m_strErrorDescription = CTurtleGraphicsErrorProvider::GetErrorMessage( err );
		m_iErrLine = m_iCurrLine;
	}

};







#endif //TurtleGraphicsSCANNER_H_INCLUDED
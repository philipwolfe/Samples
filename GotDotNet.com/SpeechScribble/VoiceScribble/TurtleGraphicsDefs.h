#ifndef TurtleGraphicsDEFS_H_INCLUDED
#define TurtleGraphicsDEFS_H_INCLUDED

#pragma once


#define TURTLE_START_X 100
#define TURTLE_START_Y 100

__declspec(selectany) COLORREF g_arrTurtleColors[] = 
{
	RGB(0x00, 0x00, 0x00),	//0
	RGB(0xff, 0x00, 0x00), //1
	RGB(0xff, 0xff, 0x00), //2
	RGB(0x00, 0x00, 0xff), //3
	RGB(0xff, 0xff, 0xff), //4
	RGB(0xff, 0xff, 0x00), //5
	RGB(0xff, 0x00, 0xff), //6
	RGB(0x00, 0xff, 0xff), //7
	RGB(0xff, 0x00, 0x80), //8
	RGB(0xff, 0x80, 0x40), //9
	RGB(0x80, 0x40, 0x00), //10
	RGB(0x00, 0x80, 0x80), //11
	RGB(0x80, 0x00, 0x00), //12
	RGB(0x80, 0x00, 0x80), //13
	RGB(0x80, 0x80, 0xff), //14
	RGB(0xcf, 0xcf, 0xcf), //15
};

// each TurtleGraphics .NET instruction takes / is one line
enum eTurtleGraphicsInstr
{
	eERR,
	
	// commands that work in both modes :
	eCLS,
	eFORWARD,
	eLEFT,
	eRIGHT,
	ePENUP,
	ePENDOWN,

	// runtime
	eSTOP,
	eSLEEP,

	
	// edit mode control
	eRESET,
	eRUN,
	eCHECK,
	
	// commands that work only in edit mode -- language elements
	// 1. statements
	eDECLARE,
	ePROCEDURE,
	eSTART,
	eEND,
	eSET,
	eCALL,
	eDO,
	eUNTIL,
	eIF,
	eELSE,
	eENDIF,
	
	//2. Operators
	eINCREMENT,
	eDECREMENT,
	eDIVIDE,
	eMULTIPLY,
	
	//3. Boolean operators for simple boole expressions
	eLEQ,	// <=
	eGEQ,	// >=
	eEQ,	// ==
	eGT,	// >
	eLT,	// <
	eDIFF	// !=
};

struct stTurtleGraphicsCmd
{
	stTurtleGraphicsCmd()
	{
		Clean();
	}

	void Clean()
	{
		cmd = eERR;
		strLVal.Empty();
		strRVal.Empty();
		iNumParam1 = 0;
		ptrSemanticData = NULL;
	}
	eTurtleGraphicsInstr	cmd;
	CString		strLVal;
	CString		strRVal;
	int			iNumParam1;

	// reserved for parsing
	DWORD_PTR	ptrSemanticData;
	
};


typedef CArray<stTurtleGraphicsCmd,stTurtleGraphicsCmd> arTurtleGraphicsCmds;

struct stWarn
{
	CString warn;
	int		line;
};





// interface to be implemented by the Editor Handler 
__interface ITurtleGraphicsEditorHandler
{
	void	SetFormattedCode(const CStringArray* pArrLines);
	void	HighlightLine(int iIndex);
	void	GetText(CString& strText);
	void	AddLine(CString strLine, COLORREF col = RGB(0, 0, 0), bool bScrollToEnd = true);
	void	ClearText();
	void	RemoveLastLine();
	void	SaveToFile(LPCTSTR szFile);

};


enum eLexError
{
	eLEX_UNK,
	eLEX_EOF,
	eLEX_OK,
};


enum eLL1State
{
	eLL1Error,
	eLL1StmtCmd,
	eLL1StmtCmdParam,
	eLL1StmtCmdVarOperatorNbr,
	eLL1StmtRValCmdParam,
	eLL1VariableStmtStart,
};

struct stLexDesc
{
	LPCTSTR		szString;
	eLL1State	LL1State;
	eTurtleGraphicsInstr	instr;
};

__declspec(selectany) stLexDesc m_arTurtleGraphicsLexDesc[] = 
{
	// commands that work in both modes :
	{_T("CLS"), eLL1StmtCmd, eCLS},
	{_T("END"), eLL1StmtCmd, eEND},
	{_T("FORWARD"), eLL1StmtCmdParam, eFORWARD},
	{_T("LEFT"), eLL1StmtCmdParam, eLEFT},
	{_T("RIGHT"), eLL1StmtCmdParam, eRIGHT},
	{_T("PEN_UP"), eLL1StmtCmd, ePENUP},	// this will cover both pen up and pen down
	{_T("PEN_DOWN"), eLL1StmtCmd, ePENDOWN},	// this will cover both pen up and pen down
	{_T("SLEEP"), eLL1StmtCmdParam, eSLEEP},
	{_T("DECLARE"), eLL1StmtCmdParam, eDECLARE},
	{_T("PROCEDURE"), eLL1StmtCmdParam, ePROCEDURE},
	{_T("CALL"), eLL1StmtCmdParam, eCALL},
	{_T("START"), eLL1StmtCmdParam, eSTART},
	{_T("SET"), eLL1StmtCmdVarOperatorNbr, eSET},
	{_T("DO"), eLL1StmtCmd, eDO},
	{_T("UNTIL"), eLL1StmtCmd, eUNTIL},
	{_T("IF"), eLL1StmtCmd, eIF},
	{_T("ELSE"), eLL1StmtCmd, eELSE},
	{_T("ENDIF"), eLL1StmtCmd, eENDIF},
	{_T("+="), eLL1StmtRValCmdParam, eINCREMENT},
	{_T("-="), eLL1StmtRValCmdParam, eDECREMENT},
	{_T("*="), eLL1StmtRValCmdParam, eMULTIPLY},
	{_T("/="), eLL1StmtRValCmdParam, eDIVIDE},
	{_T("<="), eLL1StmtRValCmdParam, eLEQ},
	{_T(">="), eLL1StmtRValCmdParam, eGEQ},
	{_T("=="), eLL1StmtRValCmdParam, eEQ},
	{_T(">"), eLL1StmtRValCmdParam, eGT},
	{_T("<"), eLL1StmtRValCmdParam, eLT},
	{_T("!="), eLL1StmtRValCmdParam, eDIFF},
};


// This appends to the command description
inline void TurtleGraphicsLex_GetCmdDescription(stTurtleGraphicsCmd&	cmd, CString& strCmd)
{
	stLexDesc	lexDesc;
	size_t		iSize, iIndex;
	bool		bFound = false;

	memset(&lexDesc, NULL, sizeof(lexDesc));
	
	iSize	=	sizeof(m_arTurtleGraphicsLexDesc) / sizeof(lexDesc);
	
	for( iIndex = 0; !bFound && iIndex < iSize; iIndex ++ )
	{
		if( m_arTurtleGraphicsLexDesc[iIndex].instr == cmd.cmd )
		{
			lexDesc = m_arTurtleGraphicsLexDesc[iIndex];
			bFound  = true;
		}
	}

	if( bFound )
	{
		switch( lexDesc.LL1State )
		{
			case eLL1StmtCmd:
				strCmd +=	lexDesc.szString;
				strCmd += _T(" ");
				break;
			case eLL1StmtCmdParam:
				{
					CString strAdd;
					// CMD x y
					if( cmd.strLVal.IsEmpty() )
					{
						// param is the RVal -- strRVal or iNumParam1
						if( cmd.strRVal.IsEmpty() )
						{
							strAdd.Format(_T("%s %d "), lexDesc.szString, cmd.iNumParam1);
						}
						else
						{
							strAdd.Format(_T("%s %s "), lexDesc.szString, cmd.strRVal);
						}
					}
					else
					{
						strAdd.Format(_T("%s %s "), lexDesc.szString, cmd.strLVal);
					}

					if( cmd.cmd == eSTART )
					{
						// Start of a function
						strCmd	+=	_T("\r\n\r\n");
					}
					strCmd  +=	strAdd;
				}
				break;

			case eLL1StmtCmdVarOperatorNbr:
				{
					CString strAdd;
					// SET x = y
					if( cmd.strRVal.IsEmpty() )
					{
						strAdd.Format(_T("%s %s = %d "), lexDesc.szString, cmd.strLVal, cmd.iNumParam1);
					}
					else
					{
						strAdd.Format(_T("%s %s = %s "), lexDesc.szString, cmd.strLVal, cmd.strRVal);
					}
					strCmd  +=	strAdd;
				}
				break;
			case eLL1StmtRValCmdParam:
				{
					CString strAdd;
					//  x OPERATOR y
					if( cmd.strRVal.IsEmpty() )
					{
						strAdd.Format(_T("%s %s %d "), cmd.strLVal, lexDesc.szString, cmd.iNumParam1);
					}
					else
					{
						strAdd.Format(_T("%s %s %s "), cmd.strLVal, lexDesc.szString, cmd.strRVal);
					}
					strCmd  +=	strAdd;
				}
				break;
			default:
				break;
		}
	}
}


#endif TurtleGraphicsDEFS_H_INCLUDED
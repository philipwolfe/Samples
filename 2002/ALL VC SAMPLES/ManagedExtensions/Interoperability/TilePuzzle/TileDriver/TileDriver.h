//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.


//TileDriver.h
#using <GameHistory.dll>

#define UI_DIRECTION_UP 	0
#define UI_DIRECTION_RIGHT	1
#define UI_DIRECTION_DOWN 	2
#define UI_DIRECTION_LEFT	3
#define UI_DIRECTION_ERROR	4

#ifndef HRESULT
typedef long HRESULT;
#endif

namespace TileDriver 
{

public __gc
class Driver 
{

public:
	Driver();

	//
	//C# accessible versions of functions - these are often wrappers for the original implementations
	//
	
	int NewGame(int sizeCol, int sizeRow, int Difficulty) __gc[];

	int NewGame(int sizeCol, int sizeRow) __gc[]
	{return NewGame(sizeCol, sizeRow, 1);}

	bool ClearHistory();
	
	void CancelSolve();

	int Solve(int __gc* AlgType) __gc[];

	bool CanUndo();
	bool CanRedo();
	
	bool SaveGame(String * strGameName, String * strBoardState)
	{
		m_pHistory->SaveGame(strGameName, strBoardState);
		return true;
	}
	
	bool LoadSavedGame(String * strGameName);

	int RedoMove() __gc[];

	int UndoMove() __gc[]
	{
		char chDirection;
		unsigned int uFromPosition;
		unsigned int uToPosition;
		unsigned long hr = UndoMove(&chDirection, &uFromPosition, &uToPosition);
			
		return PackageOut(FAILED(hr) ? UI_DIRECTION_ERROR : GetDirectionINT(chDirection)
			,uFromPosition, uToPosition, (hr==S_FALSE) ? 1: 0);
	}
	
	int MoveByDirection(int intDirection) __gc[]
	{
	//		where the return value is an array of three integers.
	//			out[0] - represents fValid.  0==FALSE, 1==TRUE
	//			out[1] - represents FromPosition.
	//			out[2] - represents ToPosition
		unsigned int FromPosition;
		unsigned int ToPosition;
		bool fValid;	
		bool fFinishesPuzzle;
		Move(GetDirectionCHAR(intDirection), &fValid, &FromPosition, &ToPosition, &fFinishesPuzzle);
		return PackageOut(fValid, intDirection, FromPosition, ToPosition, fFinishesPuzzle);
	}
	
	int MoveByPosition(int nFromPosition) __gc[]
	{
		bool fValid;
		char chDirection;
		unsigned int uToPosition;
		bool fFinishesPuzzle;
		Move((unsigned int) nFromPosition, &fValid, &chDirection, &uToPosition, &fFinishesPuzzle);
		return PackageOut(fValid, chDirection, nFromPosition, uToPosition, fFinishesPuzzle);	
	}
	
public:

	int PASS_Test(int x, int y)
	{
		int z;
		m_pHistory->Test2(x,y, &z);
		return z;
	}
	void PASS_PushMove(GameHistory::eDirection eDir)
	{
		m_pHistory->PushMove(eDir);
	}
	GameHistory::eDirection PASS_PopMove2()
	{
		GameHistory::eDirection eDir;
		m_pHistory->PopMove2(&eDir);
		return eDir;
	}
	GameHistory::eDirection PASS_PopMove()
	{
		return m_pHistory->PopMove();
	}
	char PASS_CanUndo()
	{
		char chRet;
		m_pHistory->CanUndo2(&chRet);
		return chRet;
	}
	char PASS_CanRedo()
	{
		char chRet;
		m_pHistory->CanRedo2(&chRet);
		return chRet;
	}
	
	
	
private://so they don't accidentally try to call these functions (otherwise they would be public)
	//
	//Functions that either won't or can't be accessed directly by C# (mostly old implementations that have been wrapped above)
	//
	bool NewGame(unsigned int sizeCol, unsigned int sizeRow, unsigned int * rgintBoard);
	long UndoMove(char * pchDirection, unsigned int * puPositionClicked, unsigned int * puPositionToMoveTo);
	bool Move(unsigned int uPositionClicked, bool * pfValid, char * pchDirection, unsigned int * puPositionToMoveTo, bool * pfFinishesPuzzle);
	bool Move(char chMoveDirection, bool * pfValid, unsigned int * puPositionClicked, unsigned int * puPositionToMoveTo, bool * pfFinishesPuzzle);

private:
	bool m_fHistoryDirty;
	int m_nDifficulty;
	GameHistory::CGameHistory * m_pHistory;
	Board * m_pBoard;
	SolverThreads * m_pSolverThreads;
	__wchar_t GetDirectionWCHAR(GameHistory::eDirection eDir);
	__wchar_t GetDirectionWCHAR(char chDir);
	char GetDirectionCHAR(GameHistory::eDirection eDir);
	char ReverseDirection(char chDirection);
	void CreateDefaultBoard(unsigned int * rgBoard, signed int iSize);
	char GetDirectionCHAR(int nDirection);
	int GetDirectionINT(char chDirection);
	int GetDirectionINT(__wchar_t chDirection);
	GameHistory::eDirection GetDirectionENUM(char chDirection);
	int PackageOut(bool fValid, char chDirection, int nFromPosition, int nToPosition) __gc[] {
		return PackageOut(fValid,chDirection,nFromPosition,nToPosition,0);
	}
	int PackageOut(bool fValid, char chDirection, int nFromPosition, int nToPosition, bool fFinishesBoard) __gc[]
	{
		return PackageOut(!fValid ? UI_DIRECTION_ERROR : GetDirectionINT(chDirection)
					, nFromPosition, nToPosition, fFinishesBoard ? 1 : 0);
	}
	int PackageOut(bool fValid, int nDirection, int nFromPosition, int nToPosition) __gc[] {
		return PackageOut(fValid,nDirection,nFromPosition,nToPosition,0);
	}
	int PackageOut(bool fValid, int nDirection, int nFromPosition, int nToPosition, bool fFinishesBoard) __gc[]
	{
		return PackageOut(!fValid ? UI_DIRECTION_ERROR : nDirection, nFromPosition, nToPosition, fFinishesBoard ? 1 : 0);
	}
	int PackageOut(int nDirection, int nFromPosition, int nToPosition) __gc[]
	{
		int rgOut __gc[] = new int __gc[3];
		rgOut[0] = nDirection;
		rgOut[1] = nFromPosition;
		rgOut[2] = nToPosition;
		return rgOut;
	}
	int PackageOut(int nDirection, int nFromPosition, int nToPosition, int nLastOne) __gc[]
	{
		int rgOut __gc[] = new int __gc[4];
		rgOut[0] = nDirection;
		rgOut[1] = nFromPosition;
		rgOut[2] = nToPosition;
		rgOut[3] = nLastOne;
		return rgOut;
	}
};

	
};//namespace TileDriver
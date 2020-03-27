//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.


namespace TilePuzzle {

public __gc
class Engine {

public:
//public methods

	Engine(int Col, int Row) : m_Columns(Col), m_Rows(Row), m_SolveAlgType(4) {};

	String*			SolvePuzzle(int start __gc[], int end __gc[]);

	static int		GenerateRandomBoard(int Seed, int NumRandomMoves, int Col, int Row, int Board __gc[]) __gc[];

//public data

	static bool		CancelThreads;

	int				m_SolveAlgType;

private:
//private methods

	Engine(AlgorithmType eAlgType, int Col, int Row, int StartState __gc[], int EndState __gc[]);

	void			Solve(void);

	void			AddLegalMovesToTree(String* LegalMoves, Node CurrNode);

	String*			GetLegalMoves(int RobotPosition);

	Node			MakeLegalMove(Node BeforeMoveNode, Char Direction);

	int				FindRobot(Node SrcNode);

	bool			IsOppositeMove(Char NextMove, Char PrevMove);

	//utility functions

	void			PrintState(int SrcState __gc[]);

	void			PrintStateHist(ArrayList* SrcList);

	String*			AlgorithmTypeToString(int i);

	String*			AlgorithmTypeToString(AlgorithmType eAlgType);

//private data

	GameTree*		m_pGameTree;

	TreeHash*		m_pTreeHash;

	int				m_Columns;

	int				m_Rows;

	AlgorithmType	m_eAlgType;

	Node			m_InitNode;

	Node			m_GoalNode;

	String*			m_Solution;

	//performance measurements

	int				m_iTimeSlice;

	int				m_iNumNodes;
};

};	//namespace TilePuzzle
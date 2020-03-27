//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.


//tweak for perfomance
#define INIT_QUEUE_SIZE 400
#define QUEUE_GROWTH_FACTOR 2.0
#define INIT_STACK_SIZE 400

//for depth first search
#define MAX_TREE_DEPTH 50
//utility macro
#define UNBOX(x) (*dynamic_cast<Node*>(x))


namespace TilePuzzle {


__value enum AlgorithmType {

	BREADTH_FIRST_SEARCH = 20,
	DEPTH_FIRST_SEARCH,
	A1_HEURISTIC_SEARCH,
	A2_HEURISTIC_SEARCH,

};  //__value enum AlgorithmType


__value struct Node {

	Char Move;
	int Parent __gc[];
	int	State __gc[];

	Node(int InitState __gc[]) : State(InitState), Parent(new int __gc[0]), Move(L'I') {}
	Node() : State(new int __gc[0]), Parent(new int __gc[0]), Move(L'I') {}

	inline bool EqualsState(int TargetState __gc[]) {
		for( int i=0; i < State->Length; i++ )
			if(State[i] != TargetState[i])
				return false;
		return true;
	}

};  //__value struct Node


__gc class GameTree {

public:
	GameTree(AlgorithmType eAlgType, int GoalState __gc[], int Cols, int Rows);
	void Push(Node NewNode);
	Node Pop();
	Node Top();
	bool IsEmpty();
	
	__property int get_TotalNodes() { return m_IDataStructure->Count; }

private:
	double GetCost(Node SrcNode);

	int m_GoalState __gc[];
	int				m_Cols;
	int				m_Rows;

	ICollection*	m_IDataStructure;
	AlgorithmType	m_eAlgType;

	Random*			m_Random;

}; //__gc class GameTree


//Can add states to a structure with no duplicates and have the ability to check if a state exists

__gc struct TreeHash : public Hashtable {

	//Slow string concatenation
	void AddState(Node SrcNode) {
		if(SrcNode.Parent->Length <= 0)
			Add( StateToString(SrcNode.State), SrcNode.Move.ToString() );
		else
			Add( StateToString(SrcNode.State), String::Concat(GetMoves(SrcNode.Parent), SrcNode.Move.ToString()) ); //keeps appending moves
	}

	String* GetMoves(int SrcState __gc[]) {
		return static_cast<String*>( Item[ StateToString(SrcState) ] );
	}

	bool StateExists(int SrcState __gc[]) {
		return ContainsKey( StateToString(SrcState) );
	}

private:

	String* StateToString(int SrcState __gc[]) {

		tmpStr = String::Empty;

		for(int i=0; i < SrcState->Length; i++) {
			tmpStr = String::Concat(tmpStr, S",", SrcState[i].ToString());
		}

		return tmpStr;
	}

	String* tmpStr;

};  //__gc struct TreeHash


};  //namespace TilePuzzle
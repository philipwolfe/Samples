#include "ostream"

using namespace System;

typedef struct {
	int nHumans; // number of human players
	int nRobots; // number of AI players
	WORD  arBoard[5][5];
	int   nHighScore;
	int nPlayers;	// number of players currently in the game
	int nAlives;	// number of players currently alive
} Game;

typedef struct {
	Game game[5];	// 5 tables of games 
} Server;


__value enum Status{A, P, R}; //A: available, P: pending, R:running
__value struct GameInfo{
	Game * game;
};
	

namespace GameManager
{
	static const Port=1020;
	public __gc class GMClass
	{
	private: 
		Server svr;
		Collections::Hashtable* gamepool;
		
	public:
		GMClass() {
			gamepool = new Collections::Hashtable;
		}
		bool createGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort);
	};
}

#include "GameManager.h"
using namespace System;
using namespace System::Threading;
using namespace GameManager;
public __gc class AIBunny
{
public:
	AIBunny(GameManager::GMClass* pgm, Int32 gameID, Int32 userID){
		_userID = userID;
		_gameID = gameID;
		_pgm = pgm;
		_pAIThread = new Thread(new ThreadStart(this, &AIBunny::doAIMove));
		bcount=0;
		dir=LEFT;
		EscapePath = new std::vector<int>();
		
	}

	~AIBunny(void){
		delete EscapePath;
	}

private:
	Int32 _userID;
	Int32 _gameID;
	GMClass* _pgm;
	Thread* _pAIThread;
	Int32 bcount; //the count of the bomb this guy droped
	
public:
	bool isActive() {
		int nPlayerID = _pgm->lookupBunnyID(_gameID, _userID);
		return _pgm->svr->game[_gameID].bunny[nPlayerID].status != DEAD;
	}
	void joinGame(void);
	void doAIMove(void);

	void Start();
	void Stop(){
		_pAIThread->Abort();
	}
private:
	bool validateAIBombDrop();
	bool validateMove(Int32 row, Int32 col);
	void escape();
	//Get the current escape path lengh
	bool canEscape(int row, int col, Int32 pathlen);
	void initEscapePath();
	void waitForSafe(int row, int col) {
		while (_pgm->lock[row][col][_gameID]) {
			_pAIThread->Sleep(10);
		}
	}
	//get the current escape path length
	int getCurrentXLen(){
		int len = 0;
		for (std::vector<int>::size_type i = 0; i < EscapePath->size(); i++) {
			switch (EscapePath->at(i)) {
				case LEFT:
					len--;
					break;
				case RIGHT:
					len++;
					break;
				default:
					break;
			}
		}
		return len;

	}
	int getCurrentYLen(){
		int len = 0;
		for (std::vector<int>::size_type i = 0; i < EscapePath->size(); i++) {
			switch (EscapePath->at(i)) {
				case UP:
					len--;
					break;
				case DOWN:
					len++;
					break;
				default:
					break;
			}
		}
		return len;

	}
	bool validateAIMove(BYTE row, BYTE col, BYTE ManRow, BYTE ManCol, bool *pboolSafeMove);
private:
	std::vector<int> __nogc* EscapePath;
	int EscapeDir;
	int dir;
};

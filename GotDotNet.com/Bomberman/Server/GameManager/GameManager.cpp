// This is the main DLL file.

#include "stdafx.h"

#include "GameManager.h"
#include "StreamObj.h"
#include "BombThread.h"
#include "AIBunny.h"
#include <vcclr.h>
#include <string>

WORD whichBunny[] = {BUNNY1, BUNNY2, BUNNY3, BUNNY4};

__value enum GEX {PLAYER_OVERFLOW, INVALID_PLAYERID};

__gc struct GameException: System::Exception {
	int e;
	GameException(int e) {
		this->e = e;
	}
};
namespace GameManager {

	bool GMClass::createGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort){
		System::Console::WriteLine(String::Concat(S"Enterig Creategame: \t", nHumans.ToString(), S"\t", nAIBunny.ToString()));
		svr->game[nGameID].nHumans = nHumans;
		svr->game[nGameID].nRobots = nAIBunny;
		svr->game[nGameID].nPlayers = 0;
		svr->game[nGameID].nAlives = nHumans + nAIBunny;
		const wchar_t __pin* gname = PtrToStringChars(name);
		wcsncpy(svr->game[nGameID].szGameName,gname,128);
		svr->game[nGameID].STATUS = PENDING;

		//init all cells to empty
		for (int i = 0; i<MAX_ROW; i++) 
			for (int j=0; j<MAX_COL; j++) 
				svr->game[nGameID].arBoard[i][j] = EMPTY;

		//fixed walls
		for ( int i = 1; i<MAX_ROW; i += 2) 
			for (int j=1; j<MAX_COL; j += 2) 
				svr->game[nGameID].arBoard[i][j] = HARDWALL;
		return true;
	}

	bool GMClass::joinGame(Int32 nGameID, Int32 nUserID){
		Console::WriteLine(S"entering joinGame2");
		Console::WriteLine(String::Concat("GameID=", nGameID.ToString(), " nUserID=", nUserID.ToString()));
		if (svr->game[nGameID].nHumans+svr->game[nGameID].nRobots == svr->game[nGameID].nPlayers) {
			Console::WriteLine(S"Couldn't join game, it is running.");
			return false;
		}
		if (svr->game[nGameID].nPlayers >= (svr->game[nGameID].nHumans+svr->game[nGameID].nRobots)) return false;

		StreamRecord rec_board(USER_JOINED, new NullObject());
		*(stream[nGameID-1]) << rec_board;
		initBunny(nGameID, nUserID);
		printBoard(nGameID);
		if (svr->game[nGameID].nPlayers == svr->game[nGameID].nHumans+svr->game[nGameID].nRobots) {
			try {
				Thread::Sleep(1000);
				startGame(nGameID);
			}
			catch (GameException* pe) {
				Console::WriteLine(pe->e);
				return false;
			}
			svr->game[nGameID].STATUS = RUNNING;
		}
		return true;
	}

	bool GMClass::moveBunny(Int32 nGameID, Int32 nUserID, Int32 nDirection){
		if (svr->game[nGameID].nPlayers < svr->game[nGameID].nHumans + svr->game[nGameID].nRobots) return false;
		Console::WriteLine( String::Concat(S"entering moveBunny ", nDirection.ToString()));

		int nPlayerID = lookupBunnyID(nGameID, nUserID);
		if (nPlayerID == -1) {
			Console::WriteLine(S"nPlayerID invalid: -1");
			throw new GameException(INVALID_PLAYERID);	
		}

		if ((svr->game[nGameID].bunny[nPlayerID].status == DEAD)) return false;

		int r = svr->game[nGameID].bunny[nPlayerID].r;
		int c = svr->game[nGameID].bunny[nPlayerID].c;
		WORD celObj;
		WORD BUNNY = whichBunny[nPlayerID];

		switch (nDirection) {
			case UP:
				if (0 >= r) break;	// already on top border
				celObj = getCellObject( nGameID, r-1, c );	// get target cell object
				if ( isNotBlock(celObj) ) {
					// update cells 
					updateCell(nGameID, celObj | BUNNY  , r-1, c);	
					celObj = getCellObject( nGameID, r, c );
					updateCell(nGameID, (celObj ^ BUNNY) | EMPTY, r, c);
					// update bunny
					svr->game[nGameID].bunny[nPlayerID].r = r-1;
				} 
				break;
			case DOWN:
				if (MAX_ROW <= (r+1)) break;	// already on bottom border
				// update cells
				celObj = getCellObject( nGameID, r+1, c );	// get target cell object
				if ( isNotBlock(celObj) ) {
					updateCell(nGameID, celObj | BUNNY, r+1, c);
					celObj = getCellObject( nGameID, r, c );
					updateCell(nGameID, (celObj ^ BUNNY) | EMPTY, r, c);
					//update bunny
					svr->game[nGameID].bunny[nPlayerID].r = r+1;
				} 
				break;
			case LEFT:
				if (0 >= c) break;	// already on left border
				celObj = getCellObject( nGameID, r, c-1 );	// get target cell object
				if ( isNotBlock(celObj) ) {
					// update cell
					updateCell(nGameID, celObj | BUNNY, r, c-1);
					celObj = getCellObject( nGameID, r, c );
					updateCell(nGameID, (celObj ^ BUNNY) | EMPTY, r, c);
					// update bunny
					svr->game[nGameID].bunny[nPlayerID].c = c-1;
				} 		
				break;
			case RIGHT:
				if (MAX_COL <= (c+1)) break;	// already on right border
				celObj = getCellObject( nGameID, r, c+1 );	// get target cell object
				if ( isNotBlock(celObj) ) {
					// update cell
					updateCell(nGameID, celObj | BUNNY, r, c+1);
					celObj = getCellObject( nGameID, r, c );
					updateCell(nGameID, (celObj ^ BUNNY) | EMPTY, r, c);
					// update bunny
					svr->game[nGameID].bunny[nPlayerID].c = c+1;
				}

			default:
				break;
		}

		return true;
	}

	bool GMClass::dropBomb(Int32 nGameID, Int32 nUserID){

		if (svr->game[nGameID].nPlayers < svr->game[nGameID].nHumans + svr->game[nGameID].nRobots) return false;
		Console::WriteLine(S"entering drop bomb");
		int nPlayerID = lookupBunnyID(nGameID, nUserID);
		if (nPlayerID == -1) {
			Console::WriteLine(S"Invadid PlayID: -1");
			return false;
		}
		if ((svr->game[nGameID].bunny[nPlayerID].status == DEAD)) return false;

		int r = svr->game[nGameID].bunny[nPlayerID].r;
		int c = svr->game[nGameID].bunny[nPlayerID].c;
		//If this still has bombs and then drop it
		if (svr->game[nGameID].bunny[nPlayerID].nBombs > 0) {
			svr->game[nGameID].bunny[nPlayerID].nBombs--;
			WORD celObj = getCellObject( nGameID, r, c);
			updateCell(nGameID, celObj | BOMB, r, c);
			Bomb bomb;
			int range = svr->game[nGameID].bunny[nPlayerID].range;	
			bomb.r = r; 
			bomb.c = c;
			bomb.range = range;
			bomb.counter = 3;
			bomb.owner = nPlayerID;
			bomb.nGameID = nGameID;
			svr->game[nGameID].bunny[nPlayerID].bomb.push_back(bomb);
			BombThread* pbt = new BombThread(bomb, this);
			pbt->Start();

		}

		return true;
	}

	void GMClass::initBunny(const int nGameID, const int nUserID){
		Console::WriteLine(S"Entering initBunny");
		Console::WriteLine(String::Concat(S"nUserID=", nUserID.ToString()));

		int nPlayerID = svr->game[nGameID].nPlayers;
		svr->game[nGameID].nPlayers++;
		Console::WriteLine(String::Concat(S"nPlayerID=", nPlayerID.ToString()));


		// init bunny status
		svr->game[nGameID].bunny[nPlayerID].nUserID = nUserID;
		svr->game[nGameID].bunny[nPlayerID].nGameID = nGameID;
		svr->game[nGameID].bunny[nPlayerID].nBombs = MAX_BOMBNBR;
		svr->game[nGameID].bunny[nPlayerID].range = 1;
		svr->game[nGameID].bunny[nPlayerID].status = ALIVE;

		switch (nPlayerID) {
			case 3:
				svr->game[nGameID].arBoard[MAX_ROW-1][0] = BUNNY4;
				svr->game[nGameID].bunny[nPlayerID].r = MAX_ROW-1;
				svr->game[nGameID].bunny[nPlayerID].c = 0;
				break;
			case 2:
				svr->game[nGameID].arBoard[0][MAX_COL-1] = BUNNY3;
				svr->game[nGameID].bunny[nPlayerID].r = 0;
				svr->game[nGameID].bunny[nPlayerID].c = MAX_COL-1;
				break;
			case 1:
				svr->game[nGameID].arBoard[MAX_ROW-1][MAX_COL-1] = BUNNY2;
				svr->game[nGameID].bunny[nPlayerID].r = MAX_ROW-1;
				svr->game[nGameID].bunny[nPlayerID].c = MAX_COL-1;
				break;
			case 0:
				svr->game[nGameID].arBoard[0][0] = BUNNY1;
				svr->game[nGameID].bunny[nPlayerID].r = 0;
				svr->game[nGameID].bunny[nPlayerID].c = 0;
			default:
				break;
		}
	}

	bool GMClass::addAIBunny(Int32 nGameID, Int32 nAIs){
		if(aiTable->Contains(__box(nGameID)))
			aiTable->Remove(__box(nGameID));

		AIBunny __gc* aib __gc[] = new AIBunny __gc* __gc[nAIs];
		
		for(int i=0; i< nAIs; i++){
			aib[i] = new AIBunny(this,nGameID,4-i);
			aib[i]->joinGame();
			aib[i]->Start();
		}
		// add to table to avoid GC
		aiTable->Add(__box(nGameID),aib);
		return true;
	}
}
void GameManager::GMClass::startGame(const Int32 nGameID)
{
	Console::WriteLine(S"entering startGame");
	int robotID = svr->game[nGameID].nRobots;

	if (svr->game[nGameID].nPlayers != svr->game[nGameID].nHumans + svr->game[nGameID].nRobots) {
		throw new GameException(PLAYER_OVERFLOW); 	
	}

	//generate random walls
	//tracks the number of walls we have populated so far.
	int intNumWalls = 0;

	//stores the random row and column we have picked to populated next (possibly).
	int row, col;

	while (intNumWalls < 80) {
		//pick a random raw and column.
		row = rand() % MAX_ROW;
		col = rand() % MAX_COL;

		//We must not put any soft walls in the corner cells nor the 2 cells next to them
		//this allows each man enuough room to bomb his way out.
		if (
			//verify that one of the 3 top-left coner squares was nto chosen.
			((row == 0) && (col == 0))||
			((row == 0) && (col == 1))||
			((row == 1) && (col == 0))||
			//verify that one of the 3 top-right corner squares was not chosen.
			((row == 0) && (col == MAX_COL - 1))||
			((row == 0) && (col == MAX_COL - 2))||
			((row == 1) && (col == MAX_COL - 1))||
			//verify that one of the 3 bottom-right coner squares was not chosen.
			((row == MAX_ROW - 1) && (col == MAX_COL - 1))||
			((row == MAX_ROW - 1) && (col == MAX_COL - 2))||
			((row == MAX_ROW - 2) && (col == MAX_COL - 1))||
			//verify that one of the 3 bottom-let corner squars was not chosen
			((row == MAX_ROW - 1) && (col == 0))||
			((row == MAX_ROW - 1) && (col == 1))||
			((row == MAX_ROW - 2) && (col == 0))

			)
			continue;
		//if the cell chosen doesn't already have something in it, we can put a soft wall there
		if (svr->game[nGameID].arBoard[row][col]=EMPTY)
		{
			svr->game[nGameID].arBoard[row][col] = SOFTWALL;
			intNumWalls++;
		}
	}
	Threading::Thread::Sleep(500);
	printBoard(nGameID);	
}


void GameManager::GMClass::printBoard(Int32 nGameID)
{
	IO::FileStream* pfs = IO::File::Open(S"text.txt", IO::FileMode::Append);
	IO::StreamWriter* psw = new IO::StreamWriter(pfs);
	for (int i = 0; i < 16; i++) {
		for (int j = 0; j < 16; j++) {
			psw->Write(svr->game[nGameID].arBoard[i][j].ToString());
		}
		psw->Write(S"\n");
	}
	psw->Close();
	pfs->Close();

	WholeMap *map = new WholeMap(svr->game[nGameID].arBoard);
	StreamRecord rec_board(WHOLE_MAP, map);
	*(stream[nGameID-1]) << rec_board;
}



Int32 GameManager::GMClass::lookupBunnyID(const Int32 nGameID, const Int32 nUserID)
{
	for (int i=0; i<svr->game[nGameID].nPlayers; i++)
		if (nUserID == svr->game[nGameID].bunny[i].nUserID) return i;
	return -1;
}

WORD GameManager::GMClass::getCellObject(const Int32 nGameID, Int32 r, Int32 c)
{
	return svr->game[nGameID].arBoard[r][c];
}

bool GameManager::GMClass::isNotBlock(WORD cell)
{
	return ((cell & (BOMB | SOFTWALL | HARDWALL | EXPLOSION)) == 0);
}

void GameManager::GMClass::updateCell(const Int32 nGameID, WORD cel, Int32 r , Int32 c)
{
	Monitor::Enter(this);
	svr->game[nGameID].arBoard[r][c] = cel;
	printBoard(nGameID);
	Monitor::Exit(this);
}

void GameManager::GMClass::explodeBomb(Bomb& bomb)
{
	Console::WriteLine(S"entering explodeBomb");
	int r = bomb.r;
	int c = bomb.c;
	int j;	// bunny index
	int range = bomb.range;
	int gameid = bomb.nGameID;
	int up = ((r - range) <= 0) ? 0 : (r - range);
	int down = ((r + range) >= MAX_ROW) ? (MAX_ROW - 1) : (r + range);
	int left = ((c - range) <= 0) ? 0 : (c - range);
	int right = ((c + range) >= MAX_COL) ? (MAX_COL - 1) : (c + range);
	svr->game[bomb.nGameID].bunny[bomb.owner].bomb.erase(svr->game[bomb.nGameID].bunny[bomb.owner].bomb.begin()); //Remvoe the exploded bomb
	int i = r;
	while ( i>=up ) {
		WORD celObj = getCellObject(gameid, i , c);
		if (HARDWALL & celObj) break;
		else {
			updateCell(gameid, EXPLOSION | celObj, i, c);
			for (j=0; j<3; j++) {
				if ((svr->game[gameid].bunny[j].r == i) && 
					(svr->game[gameid].bunny[j].c == c) &&
					(svr->game[gameid].bunny[j].status == ALIVE))
				{
					setBunnyStatus(gameid, j, DEAD);
					svr->game[gameid].nAlives --;
				}
			}
			if (celObj & SOFTWALL) break;	// bomb only explodes one softwall
		}
		i--;
	} // end while

	i = r;
	while ( i++<down ) {
		WORD celObj = getCellObject(gameid, i , c);
		if (HARDWALL & celObj) break;
		else {	
			updateCell(gameid, EXPLOSION | celObj, i, c);
			for (j=0; j<3; j++) {
				if ((svr->game[gameid].bunny[j].r == i) && 
					(svr->game[gameid].bunny[j].c == c) &&
					(svr->game[gameid].bunny[j].status == ALIVE))
				{
					setBunnyStatus(gameid, j, DEAD);
					svr->game[gameid].nAlives --;
				}
			}
			if (celObj & SOFTWALL) break;	// bomb only explodes one softwall
		}
	} // end while

	i = c;
	while ( i<=right ) {
		WORD celObj = getCellObject(gameid, r , i);
		if (HARDWALL & celObj) break;
		else {
			updateCell(gameid, EXPLOSION | celObj, r, i);
			for (j=0; j<3; j++) {
				if ((svr->game[gameid].bunny[j].r == r) && 
					(svr->game[gameid].bunny[j].c == i) &&
					(svr->game[gameid].bunny[j].status == ALIVE))
				{
					setBunnyStatus(gameid, j, DEAD);
					svr->game[gameid].nAlives --;
				}
			}
			if (celObj & SOFTWALL) break;	// bomb only explodes one softwall
		}
		i++;
	} // end while

	i = c;
	while ( i-->left ) {
		WORD celObj = getCellObject(gameid, r , i);
		if (HARDWALL & celObj) break;
		else {
			updateCell(gameid, EXPLOSION | celObj, r, i);
			for (j=0; j<3; j++) {
				if ((svr->game[gameid].bunny[j].r == r) && 
					(svr->game[gameid].bunny[j].c == i) &&
					(svr->game[gameid].bunny[j].status == ALIVE))
				{
					setBunnyStatus(gameid, j, DEAD);
					svr->game[gameid].nAlives --;
				}
			}
			if (celObj & SOFTWALL) break;	// bomb only explodes one softwall
		}
	} // end while

	if(svr->game[gameid].nAlives <= 1 && svr->game[gameid].STATUS == RUNNING){
		StreamRecord rec_over(GAME_OVER, new GameOver());	
		*(stream[gameid-1]) <<rec_over;
		svr->game[gameid].STATUS  = OPENED;
		svr->game[gameid].nPlayers = -1;
		svr->game[gameid].nHumans = 0;
		svr->game[gameid].nRobots = 0;

		// remove AI Bunny
		if(aiTable->Contains(__box(gameid)))
			aiTable->Remove(__box(gameid));
 	}
}

void GameManager::GMClass::clearExplosion(const Int32 nGameID)
{
	for (int r=0; r<MAX_ROW; r++)
		for (int c = 0; c<MAX_COL; c++) {
			WORD celObj = getCellObject(nGameID, r, c);
			if (celObj & EXPLOSION) {
				updateCell(nGameID, EMPTY, r, c);
				lock[r][c][nGameID] = false;
			}
		}
}

inline void GameManager::GMClass::setBunnyStatus(const Int32 nGameID, Int32 nBunnyID, Int32 status)
{
	svr->game[nGameID].bunny[nBunnyID].status = status;
}


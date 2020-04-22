// GameManager.h
#include "Global.h"
#include "UDPServer.h"
#include "..\BombermanWS\ServiceQuery.h"

#pragma once

using namespace System;

namespace GameManager
{
	static const Port=1020;
	[event_receiver(managed)]
	public __gc class GMClass
	{
	private public:
		UDPServer __nogc *stream[MAX_GAMES];
		Server __nogc* svr;
		BOOL lock __nogc[MAX_ROW][MAX_COL][MAX_GAMES+1];
		Collections::Hashtable* gamepool;

	public:
		GMClass() {
			for(int g = 1; g <= MAX_GAMES; g++){
				for (int i = 0; i < MAX_ROW; i++)
					for (int j = 0; j < MAX_COL; j++)
						lock[i][j][g]=false;
			}

			gamepool = new Collections::Hashtable;
			for(int i=0; i< MAX_GAMES;i++)
				stream[i] = new UDPServer(Port+i);
			svr = new Server;
			for(int i=1; i<= MAX_GAMES;i++)
				svr->game[i].STATUS = OPENED;

			aiTable = new Collections::Hashtable;
		}

		~GMClass(){
			if(svr != NULL)
				delete svr;

			if(stream != NULL)
				for(int i=0; i< MAX_GAMES;i++)
					delete stream[i];
		}

		void startGame(const Int32 nGameID);
		bool createGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort);
		bool joinGame(Int32 nGameID, Int32 nUserID);
		bool moveBunny(Int32 nGameID, Int32 nPlayer, Int32 nDirection);
		[System::Runtime::CompilerServices::MethodImpl(System::Runtime::CompilerServices::MethodImplOptions::Synchronized)]
		bool dropBomb(Int32 nGameID, Int32 nPlayer);
		bool addAIBunny(Int32 nGameID, Int32 nAIs);

		bool queryStatus(Int32 nGameID, BombermanWS::SessionStatus __gc* ss){ 
			if(svr == NULL) return false;

			(*ss).nHumans = svr->game[nGameID].nHumans;
			(*ss).nPlayers = svr->game[nGameID].nPlayers;
			(*ss).nRobots = svr->game[nGameID].nRobots;
			(*ss).szGameName = svr->game[nGameID].szGameName;
			(*ss).status = (BombermanWS::BMSTATUS)(Int32)svr->game[nGameID].STATUS;
			return true;
		}



	private public:
		void printBoard(Int32 nGameID);
		void explodeBomb(Bomb& bomb);
		void clearExplosion(const Int32 nGameID);

		Int32 lookupBunnyID(const Int32 nGameID, const Int32 nUserID);
		Int32 getNumberOfSoftwall(const Int32 nGameID) {
			Int32 count = 0;
			for (int r=0; r<MAX_ROW; r++)
				for (int c = 0; c<MAX_COL; c++) {
					WORD celObj = getCellObject(nGameID, r, c);
					if (celObj & SOFTWALL) {
						count++;
					}
				}
				return count;
		}

		[System::Runtime::CompilerServices::MethodImpl(System::Runtime::CompilerServices::MethodImplOptions::Synchronized)]
		void updateCell(const Int32 nGameID, WORD cel, Int32 r , Int32 c);
		WORD getCellObject(const Int32 nGameID, Int32 r, Int32 c);

	private:
		void initBunny(const int nGameID, const int nUserID);

		bool isNotBlock(WORD cell);
		void setBunnyStatus(const Int32 nGameID, Int32 nBunnyID, Int32 status);

		// hash table for ai bunnies
		Collections::Hashtable __gc* aiTable;
	};

}

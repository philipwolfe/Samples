#include "stdafx.h"
#include "BombermanWS.h"
#include "Global.asax.h"
#include "ServiceQuery.h"

#ifdef _DEBUG
#using "..\GameEvents\debug\GameEvents.dll"
#using "..\GameManager\debug\GameManager.dll"
#else
#using "..\GameEvents\Release\GameEvents.dll"
#using "..\GameManager\Release\GameManager.dll"
#endif


using namespace BombermanWS;
	
BombermanService::BombermanService(){
	if(Application->Item[S"BMSerivce"] == 0){
		GameManager::GMClass __gc* gm = new GameManager::GMClass();
		GameEvents::GEClass __gc* ge = new GameEvents::GEClass();
	
		ge->CG += new GameEvents::CreateGameEvent(gm,&GameManager::GMClass::createGame);
		ge->JG += new GameEvents::JoinGameEvent(gm,&GameManager::GMClass::joinGame);
		ge->MB+= new GameEvents::MoveBunnyEvent(gm,&GameManager::GMClass::moveBunny);
		ge->DB += new GameEvents::DropBombEvent(gm,&GameManager::GMClass::dropBomb);
		Application->Item[S"BMSerivce"]= gm;
		Application->Item[S"BomberMan"] = ge;
	}
}

Boolean BombermanService::CreateGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, String __gc* name, Int32 nPort){
	Boolean ret = dynamic_cast<GameEvents::GEClass __gc*>(Application->Item[S"BomberMan"])->CG(nGameID,nHumans,nAIBunny,name,nPort);
	if(ret && nAIBunny > 0)
		ret = dynamic_cast<GameManager::GMClass __gc*>(Application->Item[S"BMSerivce"])->addAIBunny(nGameID,nAIBunny);
	
	return ret;
}
		

Boolean BombermanService::JoinGame(Int32 nGameID, Int32 nUserID){
	return dynamic_cast<GameEvents::GEClass __gc*>(Application->Item[S"BomberMan"])->JG(nGameID,nUserID);
}

Boolean BombermanService::MoveBunny(Int32 nGameID, Int32 nPlayer, Int32 nDirection){
	return dynamic_cast<GameEvents::GEClass __gc*>(Application->Item[S"BomberMan"])->MB(nGameID,nPlayer,nDirection);
}


Boolean BombermanService::DropBomb(Int32 nGameID, Int32 nPlayer){	
	return dynamic_cast<GameEvents::GEClass __gc*>(Application->Item[S"BomberMan"])->DB(nGameID,nPlayer);
}

SessionStatus BombermanService::QueryStatus(Int32 nGameID){
	SessionStatus ss;
	dynamic_cast<GameManager::GMClass __gc*>(Application->Item[S"BMSerivce"])->queryStatus(nGameID,&ss);
	return ss;
}

Boolean BombermanService::ResetServer(){
		
		return true;
}



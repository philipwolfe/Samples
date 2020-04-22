// This is the main DLL file.

#include "stdafx.h"

#include "GameEvents.h"

namespace GameEvents {
	void GEClass::add_CG(CreateGameEvent* cg){
			_cg = dynamic_cast<CreateGameEvent*> (Delegate::Combine(_cg, cg));
	}
	void GEClass::remove_CG(CreateGameEvent* cg){
		_cg = dynamic_cast<CreateGameEvent*> (Delegate::Remove(_cg, cg));
	}
	bool GEClass::raise_CG(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort){
		if (_cg) {
				return _cg->Invoke(nGameID, nHumans, nAIBunny, name, nPort);
		}
		return false;
	}
		
	void GEClass::add_JG(JoinGameEvent* jg){
		_jg = dynamic_cast<JoinGameEvent*> (Delegate::Combine(_jg, jg));
	}
	void GEClass::remove_JG(JoinGameEvent* jg){
		_jg = dynamic_cast<JoinGameEvent*> (Delegate::Combine(_jg, jg));
	} 
	bool GEClass::raise_JG(Int32 nGameID, Int32 nUserID){
		if (_jg) {
				return _jg->Invoke(nGameID, nUserID);
		}
		return false;
	}
		
	void GEClass::add_MB(MoveBunnyEvent* mb){
			_mb = dynamic_cast<MoveBunnyEvent*> (Delegate::Combine(_mb, mb));
	}
	void GEClass::remove_MB(MoveBunnyEvent* mb){
		_mb = dynamic_cast<MoveBunnyEvent*> (Delegate::Remove(_mb, mb));
	} 
	bool GEClass::raise_MB(Int32 nGameID, Int32 nPlayer, Int32 nDirection){
		if (_mb) {
			return _mb->Invoke(nGameID, nPlayer, nDirection);
		}
		return false;
	}
		
	void GEClass::add_DB(DropBombEvent* db){
		_db = dynamic_cast<DropBombEvent*> (Delegate::Combine(_db, db));
	}
	void GEClass::remove_DB(DropBombEvent* db){
		_db = dynamic_cast<DropBombEvent*> (Delegate::Remove(_jg, db));
	} 
	bool GEClass::raise_DB(Int32 nGameID, Int32 nPlayer){
		if (_db) {
				return _db->Invoke(nGameID, nPlayer);
		}
		return false;
	}
}
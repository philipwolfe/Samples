// GameEvents.h

#pragma once

using namespace System;

namespace GameEvents
{
	
	public __delegate bool CreateGameEvent(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort);
	
	public __delegate bool JoinGameEvent(Int32 nGameID, Int32 nUserID);
	public __delegate bool MoveBunnyEvent(Int32 nGameID, Int32 nPlayer, Int32 nDirection);
	public __delegate bool DropBombEvent(Int32 nGameID, Int32 nPlayer);
	
	

	[event_source(managed)]
	public __gc class GEClass
	{
	private:
		CreateGameEvent* _cg;
		JoinGameEvent* _jg;
		MoveBunnyEvent* _mb;
		DropBombEvent* _db;
		
	public:
		
		__event void add_CG(CreateGameEvent* cg);
		__event void remove_CG(CreateGameEvent* cg);
		bool raise_CG(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, System::String __gc* name, Int32 nPort);
		

		__event void add_JG(JoinGameEvent* cg);
		__event void remove_JG(JoinGameEvent* cg); 
		bool raise_JG(Int32 nGameID, Int32 nUserID);
		
		__event void add_MB(MoveBunnyEvent* cg);
		__event void remove_MB(MoveBunnyEvent* cg); 
		bool raise_MB(Int32 nGameID, Int32 nPlayer, Int32 nDirection);
		
		__event void add_DB(DropBombEvent* cg);
		__event void remove_DB(DropBombEvent* cg); 
		bool raise_DB(Int32 nGameID, Int32 nPlayer);
				
	};	
}

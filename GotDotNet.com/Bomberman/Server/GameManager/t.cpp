// This is the main DLL file.
#using <mscorlib.dll>
using namespace System;
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include "ostream"

using namespace System;

typedef struct {
} Game;

typedef struct {
	Game game[5];	// 5 tables of games 
} Server;

namespace GameManager
{
	static const Port=1020;
	public __gc class GMClass
	{
	private: 
		Server svr;
		
	public:
		bool createGame(Int32 nGameID);
	};
}

namespace GameManager {
	bool GMClass::createGame(Int32 nGameID){
		for (int i=0; i<5; i++);
		Game __pin* p = &(svr.game[nGameID]);
		return true;
	}	
}

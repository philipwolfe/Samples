#pragma once

#using <mscorlib.dll>
using namespace System;

namespace BombermanWS{

public __value enum BMSTATUS{
	OPENED,
	RUNNING,
	PENDING
};

public __value struct SessionStatus {
	Int32 nHumans; // number of human players
	Int32 nRobots; // number of AI players
	Int32 nPlayers;	// number of players currently in the game
	String __gc* szGameName;
	BMSTATUS	status;
};

}
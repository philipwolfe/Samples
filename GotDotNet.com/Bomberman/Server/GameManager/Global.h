#pragma once

#ifndef __GLOBAL_H_
#define __GLOBAL_H_
#include <vector>
#define MAX_GAMES 5
#define MAX_ROW 11
#define MAX_COL 13

// define AI bunny UserIDs
#define AI_BUNNY1 1001
#define AI_BUNNY2 1002
#define AI_BUNNY3 1003
#define AI_BUNNY4 1004


#define MAX_BOMBNBR 50 //each bunny can only drop 45 bombs totally


//define custom messages
#define WM_CREATEGAME WM_APP+501
#define WM_JOINGAME   WM_APP+502
#define WM_MOVEBUNNY  WM_APP+503
#define WM_DROPBOMB   WM_APP+504

enum Cell {
		EMPTY		= 0x001,
		BUNNY1		= 0x002,
		BUNNY2		= 0x004,
		BUNNY3		= 0x008,
		BUNNY4		= 0x010,
		BOMB		= 0x020,
		SOFTWALL	= 0x040,
		EXPLOSION	= 0x080,
		HARDWALL	= 0x100,
		TREASURE	= 0x200,
		EXPLODED	= 0x400,
};



enum DIRECTION {
	LEFT = 0,
	UP,
	RIGHT,
	DOWN
};

enum STATUS {
	DEAD = 0,
	ALIVE,
	INVINCIBLE
};

typedef struct {
	int r;
	int c;
	int range;
	int counter;
	int owner;
	int nGameID;
} Bomb;

typedef struct {
	int nUserID;	// login id in database
	int nGameID;
	int r;	// row
	int c;	// col
	int nBombs;	// how many bombs bunny can lay
	int range;	// range of bomb
	TCHAR* strUserName;	// user name
	int status;
	std::vector<Bomb> bomb; //Store the current bombs havem't exploded
} Bunny;

enum GameStatus{
	OPENED,RUNNING,PENDING
};

typedef struct {
	int nHumans; // number of human players
	int nRobots; // number of AI players
	Bunny bunny[4];
	WORD  arBoard[MAX_ROW][MAX_COL];
	int   nHighScore;
	int nPlayers;	// number of players currently in the game
	int nAlives;	// number of players currently alive
	wchar_t szGameName[128];
	GameStatus STATUS;
} Game;



typedef struct {
	Game game[MAX_GAMES+1];	// tables of games 
} Server;



// Various buffer sizes
#define IN_BUF_SIZE        1000
#define OUT_BUF_SIZE       1000
#define PLEASE_READ        37 * sizeof(TCHAR)
#define PLEASE_WRITE       1000
#define LINE_LEN           80
#define NAME_SIZE          25
#define TIME_OUT			0
#endif

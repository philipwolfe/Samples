#include "StdAfx.h"
#include "aibunny.h"
#using <mscorlib.dll>

void AIBunny::joinGame(void){
	_pgm->joinGame(_gameID, _userID);
}
void AIBunny::Start(void)
{
	_pAIThread->Start();
}

void AIBunny::doAIMove(void)
{
	while (_pgm->svr->game[_gameID].nPlayers < (_pgm->svr->game[_gameID].nHumans+_pgm->svr->game[_gameID].nRobots) ){
		_pAIThread -> Sleep(100);
	}
	int _playerID = _pgm->lookupBunnyID(_gameID, _userID);
	
	while (isActive()) {
		int row = _pgm->svr->game[_gameID].bunny[_playerID].r;
		int col = _pgm->svr->game[_gameID].bunny[_playerID].c;

		// drop a bomb if it will be useful, if the man isn't at his limit, and if we can validate an escape path.
		if((_pgm->svr->game[_gameID].bunny[_playerID].nBombs>0) && validateAIBombDrop()) 
		{
			_pgm->lock[row][col][_gameID] = true;
			_pgm->dropBomb(_gameID, _userID);
			//_pgm->svr->game[_gameID].arBoard[row][col] = BOMB;
			escape();
			waitForSafe(row, col);

		}

		
		// tracks which moves are valid (left, up, right, down).
		bool boolValidMoves[4];
		// tracks which moves are safe (not in an explosion path).
		bool boolSafeMoves[4];
		// tracks how many moves are valid.
		BYTE intNumValidMoves = 0;
		// tracks how many moves are safe.
		BYTE intNumSafeMoves = 0;

		// figure out all the valid and safe moves based on where the walls, bombs, explosions, and pending explosions are.
		if(boolValidMoves[LEFT] = validateAIMove(row, col - 1, row, col, &boolSafeMoves[LEFT]))
		{
			intNumValidMoves++;
			intNumSafeMoves += boolSafeMoves[LEFT] ? 1 : 0;
		}
		if(boolValidMoves[UP] =
			validateAIMove(row - 1, col, row, col, &boolSafeMoves[UP]))
		{
			intNumValidMoves++;
			intNumSafeMoves += boolSafeMoves[UP] ? 1 : 0;
		}
		if(boolValidMoves[RIGHT] = 
			validateAIMove(row, col + 1,row, col, &boolSafeMoves[RIGHT]))
		{
			intNumValidMoves++;
			intNumSafeMoves += boolSafeMoves[RIGHT] ? 1 : 0;
		}
		if(boolValidMoves[DOWN] = 
			validateAIMove(row + 1, col, row, col, &boolSafeMoves[DOWN]))
		{
			intNumValidMoves++;
			intNumSafeMoves += boolSafeMoves[DOWN] ? 1 : 0;
		}

	
		// see if the man is stuck (ex. trapped by bombs and walls) in which case he can't do anything.
		if(intNumValidMoves == 0)
			return;

		// if at least one safe move exists, then we want to invalidate all the unsafe valid moves.
		// this way the safe move will always be chosen (ex. man will get out of explosion path quicker).
		if(intNumSafeMoves > 0)
		{
			// iterate through each move, invalidating all the unsafe ones.
			for(int move = 0; move < 3; move++)
			{
				if(boolValidMoves[move] && (!boolSafeMoves[move]))
				{
					boolValidMoves[move] = false;
					intNumValidMoves -= 1;
				}
			}
		}

		// if two or more moves are valid, remove the one in the opposite direction if necessary.
		if(intNumValidMoves >= 2)
		{
			// figure out the man's opposite direction offset.
			int intOppositeDirectionOffset;

			if(dir > 1)
				intOppositeDirectionOffset = -2;
			else
				intOppositeDirectionOffset = 2;

			// remove the opposite direction from the list of valid moves if necessary.
			if(boolValidMoves[dir + intOppositeDirectionOffset])
			{
				boolValidMoves[dir + intOppositeDirectionOffset] = false;
				intNumValidMoves--;
			}

			// 50% of the time the man will change to a non-opposite direction if possible.
			if(boolValidMoves[dir] && (intNumValidMoves >= 2))	
			{
				if((rand() % 2) == 0)
				{
					// remove the man's current direction from the list of possible moves if necessary.
					if(boolValidMoves[dir])
					{
						boolValidMoves[dir] = false;
						intNumValidMoves--;
					}
				}
			}
		}

		// if the current direction wasn't originally valid or we've chosen to change direction, then pick a new move.
		if(!boolValidMoves[dir])
		{	
			// pick one of the moves at random.
			UINT move = rand() % 4;

			// if an invalid move was picked, circulate through the moves clock-wise until we get a valid one.
			while(!boolValidMoves[move])
			{
				// if we've reached the end of the moves list (down), wrap-around back to the first one (left).
				if(move == DOWN)
					move = LEFT;
				else
					// otherwise increment to the next move.
					move++;
			}

			// update the man's direction.
			dir = move;
		}

		// perform the move.
		_pgm->moveBunny(_gameID, _userID, dir);
		_pAIThread->Sleep(100);	
	}
	
	
}

bool AIBunny::validateAIBombDrop() {

	bool boolValidDrop = false;
	Int32 nPlayerID = _pgm->lookupBunnyID(_gameID, _userID);
	int col = _pgm->svr->game[_gameID].bunny[nPlayerID].c;
	int row = _pgm->svr->game[_gameID].bunny[nPlayerID].r;
	// the drop is valid if the man is next to a soft wall.
	if(_pgm->getNumberOfSoftwall(_gameID) > 0)
	{
	
		if(
			((col > 0) && (_pgm->svr->game[_gameID].arBoard[row][col - 1] & SOFTWALL)) ||
			((row > 0) && (_pgm->svr->game[_gameID].arBoard[row - 1][col] & SOFTWALL)) ||
			((col < MAX_COL - 1) && (_pgm->svr->game[_gameID].arBoard[row][col + 1] & SOFTWALL)) ||
			((row < MAX_ROW - 1) && (_pgm->svr->game[_gameID].arBoard[row + 1][col] & SOFTWALL))
			)
			boolValidDrop = true;
	}
	// if no soft walls exist, the drop is valid if the man is on the edge of the map or all directions are valid moves.
	else	
	{
		int res = _pgm->svr->game[_gameID].arBoard[row][col + 1];
		if(
			// check if man is on left edge.
			((col == 0) && (!(_pgm->svr->game[_gameID].arBoard[row][col + 1] & HARDWALL))) ||
			// check if man is on upper edge.
			((row == 0) && (!(_pgm->svr->game[_gameID].arBoard[row + 1][col] & HARDWALL))) ||
			// check if man is on right edge.
			((col == (MAX_COL - 1)) && (!(_pgm->svr->game[_gameID].arBoard[row][col - 1] & HARDWALL))) ||
			// check if man is on the lower edge.
			((row == (MAX_ROW - 1)) && (!(_pgm->svr->game[_gameID].arBoard[row - 1][col] & HARDWALL))) ||
			// check if all directions are clear.
			(
				// check if the left direction is clear.
				(validateMove(row, col - 1)) &&
				// check if the up direction is clear.
				(validateMove(row - 1, col)) &&
				// check if the right direction is clear.
				(validateMove(row, col + 1)) &&
				// check if the down direction is clear.
				(validateMove(row + 1, col))
				)
				)
					boolValidDrop = true;
				
	}
	
	// the drop is also valid if the man is next to another man.
	if(!boolValidDrop)
	{
		// iterate through each man.
		for(int m = 0; m < _pgm->svr->game[_gameID].nPlayers; m++)
		{
			int myid = _pgm->lookupBunnyID(_gameID, _userID);
			// don't bother checking dead men nor whether the man is next to himself.
			if((m != myid) && (_pgm->svr->game[_gameID].bunny[m].status != DEAD))
			{
				int row = _pgm->svr->game[_gameID].bunny[m].r;
				int col = _pgm->svr->game[_gameID].bunny[m].c;
				int myrow = _pgm->svr->game[_gameID].bunny[myid].r;
				int mycol = _pgm->svr->game[_gameID].bunny[myid].c;
				if(
					((row == myrow) && (col == (mycol - 1))) ||
					((row == myrow - 1) && (col == (mycol))) ||
					((row == myrow) && (col == (mycol + 1))) ||
					((row == myrow + 1) && (col == mycol))
					)
					boolValidDrop = true;
			}
		}
	}
	
	
	// before dropping we need to make sure there is an escape route.
	if(boolValidDrop)
	{
		EscapePath->clear();
		if (canEscape(row, col, 2)) {
			Console::WriteLine(String::Concat(S"path = ", EscapePath->at(0).ToString(), S" ", EscapePath->at(1).ToString()));
				return true;
		}
	}
	return false;
}

bool AIBunny::validateMove(Int32 row, Int32 col){
	// man must not be trying to move off the map.
	if(!((row >= 0) && (row < MAX_ROW) && (col >= 0) && (col < MAX_COL)))
		return false;

	// man must also not be trying to move onto a bomb or wall.
	if((_pgm->svr->game[_gameID].arBoard[row][col] & BOMB) || (_pgm->svr->game[_gameID].arBoard[row][col] & HARDWALL) || (_pgm->svr->game[_gameID].arBoard[row][col] & SOFTWALL))
		return false;
	
	return true;
}


void AIBunny::initEscapePath(){
// initialize the escape map with the current state of the game map.
	EscapePath->clear();
}

//Found an escape path from cell(raw, col) with length pathlen
//save path we found to make the game more efficient.
bool AIBunny::canEscape(int row, int col, Int32 pathlen){
	//we can get there
	//define the offset of the move towards to each dir
	if (pathlen == 0) {
		return true;
	}
	bool foundpath = false;
	
	//make sure never go back
	//LEFT
	if ((abs(getCurrentXLen() - 1) > 0)||(abs(getCurrentYLen())> 0)) {
		if (validateMove(row, col-1)) {
			EscapePath->push_back(LEFT);
			foundpath = canEscape(row, col-1, pathlen-1);
			if (foundpath) return true;
		}
	}
	//Right
	if ((abs(getCurrentXLen() + 1) > 0)||(abs(getCurrentYLen())> 0)) {
		if (validateMove(row, col+1)) {
			EscapePath->push_back(RIGHT);
			foundpath = canEscape(row, col+1, pathlen-1);
			if (foundpath) return true;
		}
	}
	//Up
	if ((abs(getCurrentXLen()) > 0)||(abs(getCurrentYLen()-1)> 0)) {
			if (validateMove(row-1, col)) {
			EscapePath->push_back(UP);
			foundpath = canEscape(row-1, col, pathlen-1);
			if (foundpath) return true;
		}
	}
	//Down
	if ((abs(getCurrentXLen()) > 0)||(abs(getCurrentYLen()+1)> 0)) {
		if (validateMove(row+1, col)) {
			EscapePath->push_back(DOWN);
			foundpath = canEscape(row+1, col, pathlen-1);
		}
	}
	return foundpath;
}

void AIBunny::escape(){
	Console::Write(S"AIBunny escape path: ");
	Console::WriteLine(EscapePath->size());
	
	for (std::vector<int>::size_type i = 0; i < EscapePath->size(); i++){
		_pgm->moveBunny(_gameID, _userID, EscapePath->at(i));
		_pAIThread->Sleep(100);
	}
}

bool AIBunny::validateAIMove(BYTE row, BYTE col, BYTE ManRow, BYTE ManCol, bool *pboolSafeMove){
	// we assume the move is safe until checking all the pending bomb explosions.
	*pboolSafeMove = true;

	// verify that the cell is not blocked by a wall or bomb.
	if(!validateMove(row, col))
	{
		*pboolSafeMove = false;
		return false;
	}

	// verify that the cell does not contain an explosion.
	if(_pgm->svr->game[_gameID].arBoard[row][col] & EXPLOSION)
	{
		*pboolSafeMove = false;
		return false;
	}

	// iterate through each man.
	int playerID = _pgm->lookupBunnyID(_gameID, _userID);
	for(int m = 0; m < _pgm->svr->game[_gameID].nPlayers; m++)
	{
		// we don't need to bother checking a man's bombs if he doesn't have any dropped.
		if(_pgm->svr->game[_gameID].bunny[m].bomb.size() == 0) continue;

		// iterate through the man's bombs.
		for(vector<Bomb>::size_type b = 0; b < _pgm->svr->game[_gameID].bunny[m].bomb.size(); b++)
		{
			// check if the bomb is in the same row as the cell.
			if(_pgm->svr->game[_gameID].bunny[m].bomb[b].r == row)
			{
				// only worry about bombs that are big enough to reach the cell.
				if(_pgm->svr->game[_gameID].bunny[m].bomb[b].range > abs(_pgm->svr->game[_gameID].bunny[m].bomb[b].c - col))
				{
					// we assume a bomb is not blocked by a wall until we verify it.
					bool boolBombBlocked = false;

					// check if the bomb is to the left or right of the cell.
					if(_pgm->svr->game[_gameID].bunny[m].bomb[b].c < col)
					{
						// the bomb is on the left.
						// iterate through the columns between the bomb and the cell to see if a wall blocks the path.
						for(int c = _pgm->svr->game[_gameID].bunny[m].bomb[b].c + 1; c <= col; c++)
						{
							// if we find a wall, the bomb is blocked.
							if((_pgm->svr->game[_gameID].arBoard[row][c] & HARDWALL) || (_pgm->svr->game[_gameID].arBoard[row][c] & SOFTWALL))
							{
								boolBombBlocked = true;
								break;
							}
						}

						// if the bomb is not blocked by a wall, the cell will get hit by the explosion.
						if(!boolBombBlocked)
						{
							// the bomb is not blocked so the move is at least unsafe.
							*pboolSafeMove = false;

							// check if the man's row is the same as the bomb's, and if he's in the blast radius.
							// in that case we don't want to invalidate the move so he can run away.
							// but the move is considered unsafe, and another move should be chosen if possible.
							if((_pgm->svr->game[_gameID].bunny[m].bomb[b].r == ManRow) && (ManCol < col))
								return true;
						}
					}
					else
					{
						// the bomb is on the right.
						// iterate through the columns between the bomb and the cell to see if a wall blocks the path.
						for(int c = _pgm->svr->game[_gameID].bunny[m].bomb[b].c - 1; c >= col; c--)
						{
							// if we find a wall, the bomb is blocked.
							if((_pgm->svr->game[_gameID].arBoard[row][c] & HARDWALL) || (_pgm->svr->game[_gameID].arBoard[row][c] & SOFTWALL))
							{
								boolBombBlocked = true;
								break;
							}
						}

						// if the bomb is not blocked by a wall, the cell will get hit by the explosion.
						if(!boolBombBlocked)
						{
							// the bomb is not blocked so the move is at least unsafe.
							*pboolSafeMove = false;

							// check if the man's row is the same as the bomb's, and if he's in the blast radius.
							// in that case we don't want to invalidate the move so he can run away.
							// but the move is considered unsafe, and another move should be chosen if possible.
							if((_pgm->svr->game[_gameID].bunny[m].bomb[b].r == ManRow) && (ManCol > col))
								return true;
						}
					}
				}
			}

			// check if the bomb is in the same column as the cell.
			if(_pgm->svr->game[_gameID].bunny[m].bomb[b].c == col)

			{
				// only worry about bombs that are big enough to reach the cell.
				if(_pgm->svr->game[_gameID].bunny[m].bomb[b].range >= abs(_pgm->svr->game[_gameID].bunny[m].bomb[b].r - row))
				{
					// we assume a bomb is not blocked by a wall until we verify it.
					bool boolBombBlocked = false;

					// check if the bomb is above or below the cell.
					if(_pgm->svr->game[_gameID].bunny[m].bomb[b].r < row)
					
					{
						// the bomb is above.
						// iterate through the rows between the bomb and the cell to see if a wall blocks the path.
						for(int r = _pgm->svr->game[_gameID].bunny[m].bomb[b].r + 1; r <= row; r++)
						{
							// if we find a wall, the bomb is blocked.
							if((_pgm->svr->game[_gameID].arBoard[r][col] & HARDWALL) || (_pgm->svr->game[_gameID].arBoard[r][col] & SOFTWALL))
							{
								boolBombBlocked = true;
								break;
							}
						}

						// if the bomb is not blocked by a wall, the cell will get hit by the explosion.
						if(!boolBombBlocked)
						{
							// the bomb is not blocked so the move is at least unsafe.
							*pboolSafeMove = false;

							// check if the man's col is the same as the bomb's, and if he's in the blast radius.
							// in that case we don't want to invalidate the move so he can run away.
							// but the move is considered unsafe, and another move should be chosen if possible.
							if((_pgm->svr->game[_gameID].bunny[m].bomb[b].c == ManCol) && (ManRow < row))
								return true;
						}
					}

					else
					
					{
						// the bomb is below.
						// iterate through the rows between the bomb and the cell to see if a wall blocks the path.
						for(int r =_pgm->svr->game[_gameID].bunny[m].bomb[b].r - 1; r >= row; r--)
						{
							// if we find a wall, the bomb is blocked.
							if((_pgm->svr->game[_gameID].arBoard[r][col] & HARDWALL) || (_pgm->svr->game[_gameID].arBoard[r][col] & SOFTWALL))
							{
								boolBombBlocked = true;
								break;
							}
						}

						// if the bomb is not blocked by a wall, the cell will get hit by the explosion.
						if(!boolBombBlocked)

						{
							// the bomb is not blocked so the move is at least unsafe.
							*pboolSafeMove = false;

							// check if the man's col is the same as the bomb's, and if he's in the blast radius.
							// in that case we don't want to invalidate the move so he can run away.
							// but the move is considered unsafe, and another move should be chosen if possible.
							if((_pgm->svr->game[_gameID].bunny[m].bomb[b].c == ManCol) && (ManRow > row))
								return true;
						}
					}
				}
			}
		}
	}
    
	return *pboolSafeMove;
	return true;
}
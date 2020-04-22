__gc class CBomb
{
public:
	BYTE row;
	BYTE col;
	BYTE size;
	BYTE ticker;
	BYTE fuse;
	bool boolAlive;
};


__value enum
{
	DIRECTION_LEFT	= 0,
	DIRECTION_UP	= 1,
	DIRECTION_RIGHT	= 2,
	DIRECTION_DOWN	= 3
};


#define NUM_MEN				4
#define MAX_BOMB_COUNT		8
#define MAX_EXPLOSION_SIZE	7



__gc class CMan
{
public:
	CMan(void){}
	~CMan(void){}

	// the index of the man in the Men array.
	BYTE index;
	// the bitmask that points to the bitmap that represents the man.
	UINT bitmask;
	// maps to the cell that the man is occupying.
	BYTE row;
	BYTE col;
	// status of the bombs the man has dropped.
	//CBomb Bombs[MAX_BOMB_COUNT];
	// tracks whether the man is alive or dead.
	bool boolAlive;
	// tracks how many bombs the man has dropped.
	BYTE BombCount;
	// tracks the maximum number of bombs the man is allowed to drop at once.
	BYTE MaxBombCount;
	// tracks the size of the explosion (in cells) that the man's bombs will generate.
	BYTE BombSize;
	// tracks the length (in seconds) it will take for the man's bombs to explode.
	BYTE FuseSize;
	// only used for ai players so they travel along a given path for a bit.
	BYTE direction;

	// each man starts the game in this state.
	void Init(UINT ManBitmask, BYTE StartRow, BYTE StartCol)
	
	{
		bitmask = ManBitmask;
		Map[StartRow][StartCol] = bitmask;
		row = StartRow;
		col = StartCol;
		boolAlive = true;
		BombCount = 0;
		MaxBombCount = 1;
		BombSize = 2;
		FuseSize = 2;
		direction = DIRECTION_UP;

		// the man hasn't dropped any bombs yet.
		for(int i = 0; i < MAX_BOMB_COUNT; i++)
			Bombs[i].boolAlive = false;

		// set the man's index (0 - 3) based on his bitmask (0x002, 0x004, 0x008, 0x010).
		index = 0;

		while(ManBitmask > BITMASK_BOMBERMAN1)
		{
			ManBitmask /= 2;
			index++;
		}
	}

};
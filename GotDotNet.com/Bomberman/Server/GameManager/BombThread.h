#include "global.h"
#include "GameManager.h"
using namespace System::Threading;
using namespace GameManager;
__gc class BombThread
{
	private: 
			GMClass* pgm;
			Bomb __nogc* bomb;
			Thread* pthread;
	public:
		BombThread(Bomb& b, GMClass* _pgm){
			pgm = _pgm;
			bomb = new Bomb();
			bomb->c = b.c;
			bomb->counter = b.counter;
			bomb->nGameID = b.nGameID;
			bomb->owner = b.owner;
			bomb->r = b.r;
			bomb->range = b.range;
			pthread = new Thread(new ThreadStart(this, &BombThread::tick));
		}
		
		void Start() {
			pthread->Start();
		}
		
		void tick(){
			pthread->Sleep((bomb->counter)*1000);
			pgm->updateCell(bomb->nGameID, BOMB, bomb->r, bomb->c);
			pgm->explodeBomb(*bomb);
			pthread->Sleep(1000);
			pgm->clearExplosion(bomb->nGameID);
			Stop();
		}
		void Stop() {
			pthread->Abort();
		}
	~BombThread(void){ delete bomb;}
};


#include "objdispatcher.h"
#include "streamobjs.h"
#include "socket_init.h"


ObjectDispatcher *ObjectDispatcher::inst = 0;

ObjectDispatcher* ObjectDispatcher::instance()
{
	if(inst == 0) // if called first time...
		inst = new ObjectDispatcher();
	return inst;
}

// creates object of the specified type, reads it from the provided stream,
// and calls an appropriate user callback method
StreamObject* ObjectDispatcher::dispatchObject(char obj_type, DataStream *stream)
{
	StreamObject *obj = NULL;
	switch(obj_type) {
		/*
		case MAP_FRAME: //MapFrame
			obj = new MapFrame();
			*stream >> *obj;
			if(destination) destination->onMapFrame((MapFrame*)obj);
			break;
		*/
		case WHOLE_MAP: //WholeMap
			obj = new WholeMap();
			*stream >> *obj;
			if(destination) destination->onWholeMap((WholeMap*)obj);
			break;
		case GAME_OVER: //GameOver message that contains no data
			obj = new NullObject();
			*stream >> *obj;
			if(destination) destination->onGameOver((GameOver*)obj);
			break;
		case USER_JOINED:
			obj = new NullObject();
			*stream >> *obj;
			if(destination) destination->onUserJoined();
			break;
		default:
			throw UDPException("Unknown object has arrived!!!");
	}
	return obj;
}
#ifndef OBJFACTORY_H_INCLUDED
#define OBJFACTORY_H_INCLUDED
/***************************************************************************/
/*                                                                         */
/* Contains 2 classes:                                                     */
/*      EventSubscriber - is a callback class for ObjectDispatcher         */
/*      ObjectDispatcher - Each time new object arrives ObjectDispatcher   */
/*                is called to create new object and read it from a stream.*/
/*                It calls appropriate EventSubscriber's method after      */
/*                reading object                                           */
/***************************************************************************/
#include "datastream.h"
#include "streamobjs.h"

// EventSubscriber is a callback class for ObjectDispatcher
class EventSubscriber
{
public:
//	virtual void onMapFrame(const MapFrame*) = 0;
	virtual void onWholeMap(const WholeMap*) = 0;
	virtual void onGameOver(const GameOver*) = 0;
	virtual void onUserJoined() = 0;
};

// Each time new object arrives ObjectDispatcher is called to 
// create new object and read it from a stream.
// It calls appropriate EventSubscriber's method after reading
// object
class ObjectDispatcher
{
	static ObjectDispatcher *inst;
	EventSubscriber *destination;
protected:
	ObjectDispatcher() {};
public:
	static ObjectDispatcher* instance();
	// set callback
	void subscribe(EventSubscriber *dest) { destination = dest; }
	// dispatchs object: create, read it from the stream and call EventSubscriber
	virtual StreamObject* dispatchObject(char obj_type, DataStream *stream);
};

#endif
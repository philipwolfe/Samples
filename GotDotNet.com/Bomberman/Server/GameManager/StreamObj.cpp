#include "stdafx.h"
#include "StreamObj.h"
#include "ObjDispatcher.h"

#include <strstream>

#define BUFFER_SIZE 1024

////////////////////////////////////////////////////////////////////////////
// StreamRecord class provides packaging for StreamObject objects

void StreamRecord::read(DataStream* stream)
{
	*stream >> type; // get object type
	if(obj) //delete old object if any
		delete obj;
	// use object factory to create object and read it from the stream
	obj = ObjectDispatcher::instance()->dispatchObject(type, stream);
}

void StreamRecord::write(DataStream* stream) const 
{ 
	*stream << type; // send type
	*stream << *obj; // send object (ask object to send itself)
	stream->flush(); // notify stream that package is formed and can be sent
};

#ifdef _DEBUG
void StreamRecord::print(ostream& o) const
{
	o << "Record:\n";
	o << "\ttype: " << type << endl;
	if(obj)
		o << "\trecord: " << *obj << endl;
}
#endif


////////////////////////////////////////////////////////////////////////////
// MapFrame represents information about all the moveable objects on the
// board

void MapFrame::read(DataStream* stream)
{
	MapEntry entry;
	snapshot.clear(); // clear list of entries

	while(!stream->eof()) { // until end of stream reached
		*stream >> entry.type; // get entry type
		*stream >> entry.x; // get x coordinate
		*stream >> entry.y; // get y coordinate
		snapshot.push_back(entry); // add entry to the list
	}
}

void MapFrame::write(DataStream* stream) const
{
	// for all the entries in the list ...
	for(entrylist::const_iterator i = snapshot.begin(); i != snapshot.end(); ++i) {
		*stream << i->type << i->x << i->y; // send entry
	}
}

#ifdef _DEBUG
void MapFrame::print(ostream& o) const
{
	for(entrylist::const_iterator i = snapshot.begin(); i != snapshot.end(); ++i) {
		o << "\n\t\ttype: " << i->type << endl;
		o << "\t\tx: " << (int)i->x << endl;
		o << "\t\ty: " << (int)i->y << endl;
	}
}
#endif

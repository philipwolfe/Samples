#pragma once
#ifndef STREAMOBJS_H_INCLUDED
#define STREAMOBJS_H_INCLUDED
/***************************************************************************/
/*                                                                         */
/* Contains 3 classes:                                                     */
/*      StreamRecord - implements StreamObject protocol and acts as a      */
/*              decorator for a StreamObject object. It decorates object's */
/*              data with its type sent and received before object's data  */
/*      MapFrame - implements StreamObject interface, represents data to   */
/*              describe movebale objects presented at the game board      */
/*      NullObject - implements StreamObject interface, represents object  */
/*              that has no data (like "game over" notification)           */
/***************************************************************************/
#include "DataStream.h"
#include "Global.h"
#include <list>

using namespace std;

//StreamRecord - implements StreamObject protocol and acts as a
//decorator for a StreamObject object. It decorates object's
class StreamRecord : public StreamObject
{
	StreamObject *obj;
	char type;
public:
	StreamRecord(char aType, StreamObject* aObj): StreamObject(), type(aType), obj(aObj) {};
	StreamRecord(): StreamObject(), type('\0'), obj(0) {};
	~StreamRecord() { delete obj; };

	const StreamObject* getObject() const { return obj; }
private:
	virtual void read(DataStream* stream);
	virtual void write(DataStream* stream) const;
#ifdef _DEBUG
	virtual void print(ostream& o) const;
#endif

};

#define MAP_FRAME 1
#define WHOLE_MAP 2
#define GAME_OVER 3
#define USER_JOINED 4

// Whole map - provides information about the whole map,
// 2 bytes per sell
template<int sizex = 16, int sizey = 16>
class WholeMapXY : public StreamObject
{
private:
	unsigned __int16 *array;
	bool internal_array;
public:
	WholeMapXY();
	WholeMapXY(unsigned __int16 aArray[sizex][sizey]);
	~WholeMapXY();
	__int16 &operator () (int x, int y) { return array[x * sizex + y]; }
	const unsigned __int16 &operator () (int x, int y) const { return array[x * sizex + y]; }
private:
	virtual void read(DataStream* stream) { stream->read((char*)array, sizex*sizey*sizeof(__int16)); };
	virtual void write(DataStream* stream) const { stream->write((const char*)array, sizex*sizey*sizeof(__int16)); };
#ifdef _DEBUG
	virtual void print(ostream& o) const;
#endif
};

template<int sizex, int sizey>
WholeMapXY<sizex, sizey>::WholeMapXY(): StreamObject(), internal_array(true)
{
	array = new unsigned __int16[sizex*sizey];
}

template<int sizex, int sizey>
WholeMapXY<sizex, sizey>::WholeMapXY(unsigned __int16 aArray[sizex][sizey]): 
	StreamObject(), internal_array(false), array(reinterpret_cast<unsigned __int16 *>(aArray))
{
}

template<int sizex, int sizey>
WholeMapXY<sizex, sizey>::~WholeMapXY()
{
	if(internal_array)
		delete[] array;
}

#ifdef _DEBUG
template<int sizex, int sizey>
void WholeMapXY<sizex, sizey>::print(ostream& o) const
{
	for(int i = 0; i < sizex; i++) {
		for(int j = 0; j < sizey; j++)
			o << (*this)(i, j) << "   ";
		o << endl;
	}
}
#endif

typedef WholeMapXY<MAX_ROW, MAX_COL> WholeMap;

// MapFrame - implements StreamObject interface, represents data to
// describe movebale objects presented at the game board
class MapFrame : public StreamObject
{
public:
	struct MapEntry { // structure to describe game board element
		char type; // type '1' | '2' | '3' | '4' | 'B' | 'W' | ...
		char x, y; // coordinates
		MapEntry(char aType = 0, char aX = 0, char aY = 0): type(aType), x(aX), y(aY) {};
	};
	typedef list<MapEntry> entrylist;
private:
	entrylist snapshot;
public:
	MapFrame(): StreamObject() {};

	// get reference to the list of entries; called by client
	const entrylist& getEntries() const { return snapshot; };
	// add entry to the map; called by server to add entry
	void addEntry(char type, char x, char y) { snapshot.push_back(MapEntry(type, x, y)); }
	void clear()  { snapshot.clear(); }
private:
	virtual void read(DataStream* stream);
	virtual void write(DataStream* stream) const;
#ifdef _DEBUG
	virtual void print(ostream& o) const;
#endif
};


// NullObject - implements StreamObject interface, represents object
// that has no data (like "game over" notification)
class NullObject : public StreamObject
{
public:
	NullObject() : StreamObject() {};
	virtual void read(DataStream* stream) {}
	virtual void write(DataStream* stream) const {}
#ifdef _DEBUG
	virtual void print(ostream& o) const { o << "\n\t\tno data available\n"; };
#endif
};

// defines GameOver to be NullObject
typedef NullObject GameOver;

#endif
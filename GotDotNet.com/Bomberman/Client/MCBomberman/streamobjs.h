#ifndef STREAMOBJS_H_INCLUDED
#define STREAMOBJS_H_INCLUDED
/***************************************************************************/
/* Contains 3 classes:                                                     */
/*		StreamRecord - implements StreamObject protocol and acts as a      */
/*				decorator for a StreamObject object. It decorates object's */
/*				data with its type sent and received before object's data  */
/*		MapFrame - implements StreamObject interface, represents data to   */
/*				describe movebale objects presented at the game board      */
/*		NullObject - implements StreamObject interface, represents object  */
/*				that has no data (like "game over" notification)           */
/***************************************************************************/
#include "datastream.h"
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

#define MAP_ROWS 11
#define MAP_COLS 13


// Whole map - provides information about the whole map,
// 2 bytes per cell
template<int NumRows = MAP_ROWS, int NumCols = MAP_COLS>
class WholeMapXY : public StreamObject
{
private:
	__int16 array[NumRows][NumCols];
public:
	WholeMapXY(): StreamObject() {};
	const __int16 &operator () (int row, int col) const { return array[row][col]; }
	__int16 &operator () (int row, int col) { return array[row][col]; }
private:
	virtual void read(DataStream* stream) { stream->read((char*)array, NumRows*NumCols*sizeof(__int16)); };
	virtual void write(DataStream* stream) const { stream->write((const char*)array, NumRows*NumCols*sizeof(__int16)); };
#ifdef _DEBUG
	virtual void print(ostream& o) const;
#endif
};

#ifdef _DEBUG
template<int NumRows, int NumCols>
void WholeMapXY<NumRows, NumCols>::print(ostream& o) const
{
	for(int row = 0; row < NumRows; row++) {
		for(int col = 0; col < NumCols; col++)
			o << array[row][col] << "   ";
		o << endl;
	}
}
#endif

typedef WholeMapXY<MAP_ROWS, MAP_COLS> WholeMap;

/*
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
*/

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
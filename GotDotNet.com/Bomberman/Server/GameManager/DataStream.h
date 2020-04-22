#pragma once
#ifndef DATASTREAM_H_INCLUDED
#define DATASTREAM_H_INCLUDED
/***************************************************************************/
/* Contains 2 classes:                                                     */
/*		DataStream - defines abstract stream interface                     */
/*		StreamObject - defines abstract interface for the object that can  */
/*				be read from and written to DataStream                     */
/***************************************************************************/
#include <strstream>

#ifdef _DEBUG
#include <iostream>
#endif
using namespace std;

class DataStream;

// StreamObject is pure virtual class that defines interface for
// an object that can be read or written to the DataStream. Instead
// of using read and write methods user should use << and >> operators
// of DataStream
class StreamObject
{
public:
	virtual ~StreamObject() {};
private:
	virtual void read(DataStream* stream) = 0;
	virtual void write(DataStream* stream) const = 0;

	friend DataStream;
#ifdef _DEBUG
public:
	friend ostream& operator << (ostream& out, const StreamObject& obj);
	virtual void print(ostream& out) const {};
#endif
};

#ifdef _DEBUG
ostream& operator << (ostream& out, const StreamObject& obj);
#endif

// DataStream provides abstract class that defines generic stream interface.
// Class should be overwritten to provide real streaming media
class DataStream
{
public:
	DataStream(){};
	virtual ~DataStream() {};

	// DataStream's interface that is intended to be overwritten
	virtual void read(char *buffer, int size) = 0;
	virtual void write(const char *buffer, int size) = 0;
	virtual bool eof() { return false; }; // input stream should overwrite this method 
										// to return true when all the data extracted
	virtual void flush() {}; // user call this method to cause data to be flushed
							// UDPServer can use it for sending package to the network

	DataStream& operator << (StreamObject& obj) { obj.write(this); return *this; };
	DataStream& operator >> (StreamObject& obj){ obj.read(this); return *this; };
	DataStream& operator << (char data) { write(reinterpret_cast<const char*>(&data), sizeof data); return *this; };
	DataStream& operator >> (char& data) { read(reinterpret_cast<char*>(&data), sizeof data); return *this; };
};

#endif
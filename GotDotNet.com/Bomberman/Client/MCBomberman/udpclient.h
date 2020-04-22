#ifndef UPDCLIENT_H_INCLUDED
#define UPDCLIENT_H_INCLUDED
/***************************************************************************/
/* Contains 2 classes:                                                     */
/*		ClientSocket - represents client side of a UDP connection          */
/*		UDPClient - implements DataStream interface and using ClientSocket */
/*				as a media to read data from                               */
/***************************************************************************/
#include <winsock2.h>
#include "socket_init.h"
#include "datastream.h"

// UDP suggests packages less then 512 bytes !!!!
#define BUFFER_SIZE 1024 

//ClientSocket implements client site of the UDP protocol
class ClientSocket
{
	SOCKET sock;
	char buf[BUFFER_SIZE];
	strstream *str;
public:
	ClientSocket(int aPort);
	~ClientSocket();

	void recv(char *buffer, int size);
	bool eof() { return str->eof(); };
};

// UDPClient is DataStream that uses reads its data from the ClientSocket
// (and therefore from UDP "connection")
class UDPClient : public DataStream, private ClientSocket
{
public:
	UDPClient(int aPort) : DataStream(), ClientSocket(aPort) {};
	
	//imlement DataStream's pure virtual methods
	virtual void read(char *buffer, int size)
		{ return ClientSocket::recv(buffer, size);}
	virtual void write(const char *buffer, int size) { throw UDPException("Cannot write to the socket on the client size"); };
	virtual bool eof() { return ClientSocket::eof(); };
};

#endif
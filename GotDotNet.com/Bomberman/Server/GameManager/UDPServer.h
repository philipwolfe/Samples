#pragma once
#ifndef UPDCLIENT_H_INCLUDED
#define UPDCLIENT_H_INCLUDED
/***************************************************************************/
/* Contains 2 classes:                                                     */
/*      ServerSocket - represents server side of a UDP connection          */
/*      UDPServer - implements DataStream interface and using ServerSocket */
/*              as a media to write data to                                */
/***************************************************************************/
#include <winsock2.h>
#include "DataStream.h"
#include "WinsockInit.h"

 //UDP package must not exceed 512 bytes by default
#define BUFFER_SIZE 512

//ClientSocket implements server site of the UDP protocol
class ServerSocket
{
	SOCKET sock;
	sockaddr_in name;
	strstream str; // is used to operate on buffer
public:
	ServerSocket(int aPort);
	~ServerSocket();

	void send(const char *buffer, int size);
	void flush();
};

// UDPServer is DataStream that uses writes its data from the ServerSocket
// (and therefore to UDP "connection")
class UDPServer : public DataStream, private ServerSocket
{
public:
	UDPServer(int aPort) : DataStream(), ServerSocket(aPort) {};
	
	//imlement DataStream's pure virtual methods
	virtual void read(char *buffer, int size) { throw UDPException("Cannot read from the socket on the client side"); };
	virtual void write(const char *buffer, int size) { ServerSocket::send(buffer, size); };
	virtual void flush() { ServerSocket::flush(); }
};

#endif
#include "stdafx.h"
#include "UDPServer.h"

///////////////////////////////////////////////////////////////////////////////
// ServerSocket
ServerSocket::ServerSocket(int aPort)
{
     struct hostent;

     /* Create socket on which to send. */ 
     sock = socket(AF_INET, SOCK_DGRAM, 0); 
     if (sock < 0)
		 throw UDPException("Cannot create socket");
	
	 int true_value = 1;
	 // set socket to be bradcasting socket
	 if(setsockopt(sock, SOL_SOCKET, SO_BROADCAST, (char*)&true_value, sizeof(int)))
		 throw UDPException("Cannot set socket as a broadcast socket");

	 // fill name with appropriate data
	 memset(&name.sin_addr, INADDR_BROADCAST, sizeof(INADDR_BROADCAST));
     name.sin_family = AF_INET; 
     name.sin_port = htons(aPort);
}

ServerSocket::~ServerSocket()
{
	closesocket(sock);
}

void ServerSocket::send(const char *buffer, int size)
{
	// write data to internal cache buffer
	str.write(buffer, size);
}

void ServerSocket::flush()
{
	// send cached data to the stream
	if (sendto(sock, str.str(), str.pcount(), 0, (sockaddr*)&name, sizeof(name)) < 0) 
          throw UDPException("Cannot send data to client");
	str.freeze(false);
	//clean str
	str.seekp(0); // set cache pointer to the beginning of the buffer
}

#ifdef TEST_UDPSERVER
/***********************************************************************************/
//                             TEST STUB                                           //
/***********************************************************************************/
#include <iostream>
#include "StreamObj.h"

using namespace std;

#define SIZE 1024
void main()
{
	UDPServer stream(1020);

	WholeMap *map = new WholeMap();
	StreamRecord rec_map(WHOLE_MAP, map);
	int count = 0;
	for(int i = 0; i < 16; i++)
		for(int j = 0; j < 16; j++)
			(*map)(i, j) = count++;
	StreamRecord rec_over(GAME_OVER, new GameOver());
	cout << "Sending whole map: \n" << rec_map << endl;
	stream << rec_map;
	cout << "Sending \"game over\": \n" << rec_over << endl;
	stream << rec_over;
}

#endif

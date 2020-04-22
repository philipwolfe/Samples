#include "udpclient.h"
#include <winsock2.h>
////////////////////////////////////////////////////////////////////////////
// ClientSocket represents client side of the UDP "connection"
ClientSocket::ClientSocket(int aPort)
{
	str = new strstream; // used to operate on buf
	str->peek(); // set eof bit on
	struct sockaddr_in name;

	/* Create socket from which to read. */
	this->sock = socket(AF_INET, SOCK_DGRAM, 0);
	if (sock < 0)
		throw UDPException("Cannot create socket");

	/* Create name with specified port */
	name.sin_family = AF_INET;
	name.sin_addr.s_addr = INADDR_ANY;
	name.sin_port = htons(aPort);
	if (bind(sock, (sockaddr*)&name, sizeof(name)))
		throw UDPException("Cannot bind datagram socket");

}

ClientSocket::~ClientSocket()
{
	//delete str;
	closesocket(sock);
}

void ClientSocket::recv(char *buffer, int size)
{
	// check if our cache buffer is exauhsted
	if(str->eof()) {
		delete str;
		int count;
		// receive new package from a remote host
		if ((count = recvfrom(sock, buf, BUFFER_SIZE, 0, NULL, NULL)) < 0)
			throw UDPException("Error while receiving datagram");
		// make str to operate on the package
		
		str = new strstream(buf, count);
	}
	// Read data from the cached package
	str->read(buffer, size);
	str->peek(); // is it eof? we will check it next time or return from eof() method
}

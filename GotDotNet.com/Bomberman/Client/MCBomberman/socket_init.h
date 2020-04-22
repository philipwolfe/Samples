#ifndef SOCKET_INIT_H_INCLUDED
#define SOCKET_INIT_H_INCLUDED
/***************************************************************************/
/* Contains 2 classes:                                                     */
/*		WinsockInit - initializer for the WinSock library                  */
/*		UDPException - exception to be thrown by UDP classes               */
/***************************************************************************/
#include <exception>

// WinSock library initializer
class WinsockInit 
{
	static int count;
public:
	WinsockInit();
	~WinsockInit();
};

namespace {
	WinsockInit init;
}

// exception class to be used by all the UDP classes
class UDPException : public std::exception
{
	const char *msg;
public:
	UDPException(const char *aMsg) : std::exception(), msg(aMsg) {};
	virtual const char *what() const throw() { return msg; };
};

#endif
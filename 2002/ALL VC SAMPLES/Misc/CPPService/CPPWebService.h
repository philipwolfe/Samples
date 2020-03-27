// CPPWebService.h

#pragma once
#using "System.EnterpriseServices.dll"

namespace CPPWebService
{
	__value public struct ClientData
	{
		String *Name;
		int	ID;
	};

    __gc class MyService 
	{    
    public:
        [WebMethod] 
        int MyMethod();

		[WebMethod]
		ClientData GetClientData();

		/*
		[WebMethod]
		ClientData __gc[] GetClientsData(int Number)
		{
			ClientData  data[] = new ClientData [Number];
			return  data;
		}
		*/
	};
}
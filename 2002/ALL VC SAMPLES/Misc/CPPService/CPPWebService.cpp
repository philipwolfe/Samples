
#include "stdafx.h"
#using <mscorlib.dll>
#using "System.Web.dll"
#using "System.Web.Services.dll"

using namespace System;
using namespace System::Web;
using namespace System::Web::Services;

#include "CPPWebService.h"

namespace CPPWebService
{
	int MyService::MyMethod()
	{
		return 42;
	}

	ClientData MyService::GetClientData()
	{
		ClientData data;
		data.Name = new String("Client Name");
		data.ID = 1;

		return data;
	}

	/*
	ClientData __gc[] MyService::GetClientsData(int Number)
	{
		if (Number < 0 || Number > 10)
			return 0;

		ClientData __gc[] data = new ClientData __gc[Number];

		if (Number > 0 && Number <= 10)
		{
			for (int i = 0; i < Number; i++)
			{
				Client[i].Name = new String(L"Client ");
				Client[i].Name->Concat(i.ToString());
				Client[i].ID = i;
			}
		}

		return Clients;
	}
	*/
};

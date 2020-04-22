// BombermanWS.h

#pragma once

#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web;
using namespace System::Web::Services;

#include "ServiceQuery.h"

namespace BombermanWS
{
    public __gc 
        class BombermanService : public WebService
    {
        
    public:
		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string "Hello, World!".
		// To test this web service, ensure that the .asmx file in the deployment path is
		// set as your Debug HTTP URL, in project properties.
		// and press F5.
		BombermanService();

		[WebMethod(EnableSession=true)]
		 Boolean CreateGame(Int32 nGameID, Int32 nHumans, Int32 nAIBunny, String __gc* name, Int32 nPort);
		
		[WebMethod(EnableSession=true)]
		 Boolean JoinGame(Int32 nGameID, Int32 nUserID);
		
		[WebMethod(EnableSession=true)]
		 Boolean MoveBunny(Int32 nGameID, Int32 nPlayer, Int32 nDirection);
		
		[WebMethod(EnableSession=true)]
		 Boolean DropBomb(Int32 nGameID, Int32 nPlayer);

		[WebMethod(EnableSession=true)]
		 SessionStatus  QueryStatus(Int32 nGameID);    

		 [WebMethod(EnableSession=true)]
		 Boolean  ResetServer();    


    };


}
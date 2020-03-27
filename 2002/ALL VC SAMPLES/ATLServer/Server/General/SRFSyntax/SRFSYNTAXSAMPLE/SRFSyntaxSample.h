// SRFSyntaxSample.h : Defines the ATL Server request handler class
// (c) 2001 Microsoft Corporation
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

// Maximum number of iterations for a "while" loop
#define	MAX_ITERATIONS	3




[ request_handler("Default") ]
class CSRFSyntaxSampleHandler
{
private:
	// Put private members here

protected:
	// Put protected members here
	
	// protected variable holding the number of succesfull returns in 
	// passLoopCondition
	int		_iSteps;
	
public:

	// Initialization method. It is called by the stencil processor whenever 
	// this replacement handler is initialized 
	HTTP_CODE ValidateAndExchange()
	{
		// Set the content-type for the response
		m_HttpResponse.SetContentType("text/html");

		
		// initialize the iteration counter to 0
		_iSteps	=	0;
		
		return HTTP_SUCCESS;
	}




	/*
		Replacement method associated with a replacement tag.
		The tag_name attribute performs the association with the "Hello" replacement tag.
		The "name" parameter is required.
		
		The method is called whenever the "Hello" replacement tag occurs inside the SRF file. 
		It injects some characters in the response buffer (m_HttpResponse).
	*/
	[ tag_name(name="Hello") ]
	HTTP_CODE OnHello(void)
	{
		m_HttpResponse << "Hello World!";
		return HTTP_SUCCESS;
	}


	// Here is an example of a conditional replacement tag to be used as a IF parameter
	// this method (failCondition) will always return S_FALSE
	[ tag_name(name="failCondition") ]
	HTTP_CODE OnFailCondition(void)
	{
		return HTTP_S_FALSE;
	}

	// Here is an example of a conditional replacement tag to be used as a IF parameter
	// this method (passCondition) will always return HTTP_SUCCESS
	[ tag_name(name="passCondition") ]
	HTTP_CODE OnPassCondition(void)
	{
		return HTTP_SUCCESS;
	}


	// Here is an example of a conditional replacement tag to be used as a WHILE parameter
	// this method (failLoopCondition) will always return HTTP_S_FALSE
	[ tag_name(name="failLoopCondition") ]
	HTTP_CODE OnFailLoopCondition(void)
	{
		return HTTP_S_FALSE;
	}

	// Here is an example of a conditional replacement tag to be used as a WHILE parameter
	// this method (passLoopCondition) will return HTTP_SUCCESS 3(MAX_ITERATIONS) times, then HTTP_S_FALSE
	// For each HTTP_SUCCESS, the value of the internal variable _iSteps will be incremented
	// _iSteps is initialized with 0 in the ValidateAndExchange function
	[ tag_name(name="passLoopCondition") ]
	HTTP_CODE OnPassLoopCondition(void)
	{
		if( _iSteps < MAX_ITERATIONS )
		{
			// increment counter
			_iSteps	++;

			// return success code
			return HTTP_SUCCESS;
			
		}
		else
		{
			// counter exceeded, return FALSE
			return HTTP_S_FALSE;
		}
	}

}; // class CSRFSyntaxSampleHandler





// This is an alternate request handler 
// It has to be declared in the SRF file with the syntax :
// {{subhandler ID SRFSyntaxSample.dll/Alternate}}
[ request_handler("Alternate") ]
class CSRFSyntaxAlternateHandler
{
private:
	// Put private members here

protected:
	// Put protected members here
	
public:
	// Put public members here

	HTTP_CODE ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");

		return HTTP_SUCCESS;
	}
	// Here is an example of how to use a replacement tag with the stencil processor
	[ tag_name(name="Hello") ]
	HTTP_CODE OnHello(void)
	{
		m_HttpResponse << "Hello, World, from the Alternate subhandler!";
		return HTTP_SUCCESS;
	}
};



// This is a request handler to be used from inside the included SRF file
// It has to be declared in the included SRF file with the syntax :
// {{handler SRFSyntaxSample.dll/IncludedHandler}}
[ request_handler("IncludedHandler") ]
class CSRFSyntaxIncludedHandler
{
private:
	// Put private members here

protected:
	// Put protected members here
	
public:
	// Put public members here

	HTTP_CODE	ValidateAndExchange()
	{
		// TODO: Put all initialization and validation code here
		
		// Set the content-type
		m_HttpResponse.SetContentType("text/html");

		return HTTP_SUCCESS;
	}
	// Here is an example of how to use a replacement tag with the stencil processor
	[ tag_name(name="Hello") ]
	HTTP_CODE	OnHello(void)
	{
		m_HttpResponse << "Hello, World, from the Handler of the Included SRF file!";
		return HTTP_SUCCESS;
	}
};
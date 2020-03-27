// File: argparser.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "ArgParser.h"

ArgParser::ArgParser(void)
{
	Trace::TraceMsg("ArgParser constructor");
}

ArgParser::~ArgParser(void)
{	
	Trace::TraceMsg("ArgParser destructor");

	// delete the parameter list	
	m_attributes.RemoveAll();	
}

void ArgParser::GetAttribute(LPCSTR name, Params& value)
{
	ASSERT(name != NULL);

	if (name != NULL)
	{
		value = m_attributes[name];		
	}
}

int ArgParser::GetAttribute(LPCSTR name, StringList& values)
{
	ASSERT(name != NULL);
	if (name == NULL)
	{
		// we can't do anything if the name is null.
		return 0;
	}
	
	// if we don't have parameters, just return now
	Params params;
	GetAttribute(name, params);

	int attributeCount = params.GetCount();	
	if (attributeCount == 0)
	{
		return attributeCount;
	}

	// try to get our first element
	POSITION begin = params.GetHeadPosition();
	
	ASSERT(begin != NULL);
	if (begin == NULL)
	{
		// Getting here would imply that the size of our list reported by
		// GetCount() does not correspond to what is actually in the list.  
		// There's not much we can do here, return 0 since GetCount() was
		// not accurate.
		return 0;
	}

	Param ps;
	while (begin != NULL)
	{			
		// get our parameter information
		ps = params.GetNext(begin);
		
		if (ps.isLiteral)
		{				
			// if the parameter is a string value, wrap it in quotes
			CString value;
			value.Format("'%s'", ps.paramName);
	
			values.AddTail(value);						
		}
		else
		{				
			values.AddTail(ps.paramName);						
		}						
	}

	return attributeCount;
}

int ArgParser::GetAttribute(LPCSTR name, CStringA& value)
{
	ASSERT(name != NULL);
	if (name == NULL)
	{
		// We can't do anything if the name is null.
		return 0;
	}

	Params params;
	GetAttribute(name, params);

	// if we don't have parameters, just return now
	int attributeCount = params.GetCount();	
	if (attributeCount == 0)
	{
		return attributeCount;
	}
	
	// reset the value just in case
	value = "";

	// get the position to our first element
	POSITION begin = params.GetHeadPosition();
	
	ASSERT(begin != NULL);
	if (begin == NULL)
	{
		// Getting here would imply that the size of our list reported by
		// GetCount() does not correspond to what is actually in the list.  
		// There's not much we can do here, return 0 since GetCount() was
		// not accurate.
		return 0;
	}
	
	// Iterate through the parameters, we are going to build a string from these parameters
	// that looks like param1,param2,param3,param4,etc.
	Param ps;
	for (int i = 0; i < attributeCount; i++)	
	{		
		ps = params.GetNext(begin);
		
		// see if we have a string
		if (ps.isLiteral)
		{
			CStringA temp;
			temp.Format("'%s'", ps.paramName);				
			value += temp;
		}
		else
		{
			value += ps.paramName;
		}
			
		// add a comma if we're not at the end yet
		if (i + 1 != attributeCount)
			value += ",";
	}

	return attributeCount;
}

bool ArgParser::Parse(LPCSTR rawCmd)
{
	ASSERT(rawCmd != NULL);

	bool isValid = false;
	ParseState state = StartParseAttribute;

	int quoteCount = 0;
	int numValues = 0;
	CStringA attribute;
	CStringA value;
	Params params;

	// make sure we have an argument string (can't call IsBadStringPtr here because it isn't thread-safe)
	ASSERT(rawCmd != NULL);
	if (!rawCmd)	
	{
		return isValid;
	}

	while (*rawCmd != '\0')
	{
		// skip whitespace
		while (rawCmd != NULL && isspace(*rawCmd))
			rawCmd++;
			
		// get our state
		state = GetState(*rawCmd, state);

		switch(state)
		{
			case StartParseAttribute:
				{	
					// attributes can't have "'s in them
					if (*rawCmd == '"')
					{
						return false;
					}

					// build up our attribute name
					attribute += *rawCmd;
					break;
				}
			case StartParseValue:
				{				
					// we don't care about the = after an attribute name
					if (*rawCmd != '=')
					{						
						if (*rawCmd == '\'')						
							quoteCount++;		// keep track of how many quotes we hit, a quoted attribute value has 2 quotes
						else		
						{
							if (*rawCmd == '"')
							{		
								rawCmd++;
								while (rawCmd != NULL && *rawCmd != '"')
								{
									value += *rawCmd++;
								}
								rawCmd++;
							}
							else
							{
								value += *rawCmd;	// build up our attribute value						
							}
						}
					}
					break;
				}
			case EndParseValue:
				{					
					if (*rawCmd == ',')
					{
						// we've read 1 attribute parameter, add that to your current list
						AddAttributeParam(value, quoteCount, params);
						
						numValues++;
						state = StartParseValue;
						quoteCount = 0;
						value = "";
					}			
					break;
				}
			case EndParseAttribute:
				{
					// add our last parameter attribute
					AddAttributeParam(value, quoteCount, params);

					// we've read all the parameters for this attribute					
					// put an entry in our map for this attribute and its associate parameters
					m_attributes.SetAt(attribute, params);
																				
					// reset our values					
					params.RemoveAll();
					
					attribute = "";
					state = StartParseAttribute;
					quoteCount = 0;
					value = "";

					break;
				}
		}
		rawCmd++;
	}				

	if (state != StartParseAttribute)
	{
		// process the last attribute value
		AddAttributeParam(value, quoteCount, params);
		m_attributes.SetAt(attribute, params);
		
		isValid = true;
	}

	return isValid;
}

void ArgParser::AddAttributeParam(CStringA& value, int quoteCount, Params& params)
{
	// make sure we have a valid quote count (0 or 2)
	if (quoteCount != 0 && quoteCount != 2)
	{				
		return;
	}

	// we hit a valid attribute value, create a struct for it	
	Param ps;	
	ps.paramName = value;  

	if (quoteCount == 2)												
		ps.isLiteral = true;													
	else						
		ps.isLiteral = false;
								
	params.AddTail(ps);	
}

ParseState ArgParser::GetState(char currChar, ParseState currState)
{
	switch (currChar)
	{
	case ';':
		return EndParseAttribute;
		break;
	case '=':		
		return StartParseValue;
		break;		
	case ',':
		return EndParseValue;
		break;
	default:
		return currState;
		break;
	}
}
// File: argparser.h
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once
#include "stdafx.h"
#include "Trace.h"

struct Param
{
	CStringA paramName;
	bool	 isLiteral;

	Param()
	{
		Trace::TraceMsg("Param constructor");
		isLiteral = false;
		paramName = "";
	}

	Param(const Param& p)
	{
		Trace::TraceMsg("Param copy constructor");

		paramName = p.paramName;
		isLiteral = p.isLiteral;
	}

	~Param()
	{
		Trace::TraceMsg("Param destructor");
	}	

	Param& operator=(const Param p)
	{
		Trace::TraceMsg("Param operator =");
		
		paramName = p.paramName;
		isLiteral = p.isLiteral;

		return (*this);
	}
};

class Params : public CAtlList<Param>
{
public:
	Params() : CAtlList<Param>()
	{
		Trace::TraceMsg("Params constructor");
	}

	Params(const Params& p)
	{
		Trace::TraceMsg("Params copy constructor");

		POSITION begin = p.GetHeadPosition();
		ASSERT(begin != NULL);

		while (begin != NULL)
		{
			Param ps = p.GetNext(begin);

			Param newPs;
			newPs.isLiteral = ps.isLiteral;
			newPs.paramName = ps.paramName;

			AddTail(newPs);
		}			
	}

	~Params()
	{
		Trace::TraceMsg("Params destructor");
		RemoveAll();
	}

	Params& operator=(const Params& p)
	{
		Trace::TraceMsg("Params = operator");

		RemoveAll();

		POSITION begin = p.GetHeadPosition();
		ASSERT(begin != NULL);

		while (begin != NULL)
		{
			Param ps = p.GetNext(begin);

			Param newPs;
			newPs.isLiteral = ps.isLiteral;
			newPs.paramName = ps.paramName;

			AddTail(newPs);
		}			

		return (*this);
	}	
};

typedef CAtlMap<CStringA, Params, CStringElementTraits<CStringA> > Attributes;

enum ParseState
{
	StartState,
	StartParseAttribute,	
	EndParseAttribute,
	StartParseValue,
	EndParseValue	
};

class ArgParser
{
public:
	ArgParser(void);
	virtual ~ArgParser(void);

	void GetAttribute(LPCSTR name, Params& value);
	int GetAttribute(LPCSTR name, CStringA& value);	
	int GetAttribute(LPCSTR name, StringList& values);
	bool Parse(LPCSTR rawCmd);

private:
	void AddAttributeParam(CStringA& value, int quoteCount, Params& params);	
	ParseState GetState(char currChar, ParseState currState);	
	
	Attributes  m_attributes;
};

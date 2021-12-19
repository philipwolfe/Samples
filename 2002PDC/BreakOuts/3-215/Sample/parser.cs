//==========================================================================
//  File:		parser.cs
//
//--------------------------------------------------------------------------
//  This file is part of the Microsoft NGWS Samples.
//
//  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//==========================================================================
using System;

namespace PDCDemo.VersionAndDeploy.ParseUtil
{
	public class Arguments
	{
		private String m_arg1;
		private Char   m_op;
		private String m_arg2;

		public String Arg1
	    {
			get 
			{ 
				return m_arg1;
			}
			set 
			{ 
				m_arg1 = value;
				return; 
			}
		}

		public Char Op
	    {
			get 
			{ 
				return m_op;
			}
			set 
			{ 
				m_op = value;
				return; 
			}
		}

		public String Arg2
	    {
			get 
			{ 
				return m_arg2;
			}
			set 
			{ 
				m_arg2 = value;
				return; 
			}
		}
	}

	public class Parser
	{
		//
		// This parser is pretty unsophisticated!  It only understands formulas of the
		// format "number"<space><operator><space>"number"
		//
		public Arguments Parse(String formula)
		{
			Arguments args = new Arguments();
			// get the first arg
			int spacePos = formula.IndexOf(' ');
			args.Arg1 = formula.Substring(0, spacePos);

	
			// get the operator
			args.Op = formula.Substring(spacePos+1, 1).ToChar();

			// get the second arg
			args.Arg2 = formula.Substring(spacePos+3);

			return args;
		}

	}

}
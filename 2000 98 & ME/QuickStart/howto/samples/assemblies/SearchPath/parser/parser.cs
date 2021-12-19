using System;

namespace Samples.Math.Parser
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
		public Arguments Parse(String formula)
		{

			Arguments args = new Arguments();

			// get the first arg
			char [] opsAndSpace = {' ','+','-','*','/'};

			int pos = formula.IndexOf(opsAndSpace);
			args.Arg1 = formula.Substring(0, pos);
			args.Arg2 = args.Arg1;

			// skip whitespace to get to the operator	
			while (formula[pos] == ' ')
			{
				pos++;
			}
	
			// get the operator
			args.Op = formula.Substring(pos, 1).ToChar();

			// skip whitespace to get to the second arg
			pos++;
			while (formula[pos] == ' ')
			{
				pos++;
			}

			// get the second arg
			args.Arg2 = formula.Substring(pos);

			return args;

		}

	}

}
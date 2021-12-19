using System;

namespace Samples.Math.Calculator
{
   public class Calc
   {
		public String GetResult(int arg1, Char op, int arg2)
		{
			switch(op)
			{
				case '+':
					return String.Format("Result: {0:####}", arg1 + arg2);
				case '-':
					return String.Format("Result: {0:####}", arg1 - arg2);
				default:
					return "Invalid operator: "+ op;
			}
		}

   }

}
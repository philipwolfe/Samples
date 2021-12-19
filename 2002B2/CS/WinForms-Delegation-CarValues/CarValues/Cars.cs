using System;

namespace CarValues
{
	/// <summary>
	/// Summary description for Cars.
	/// </summary>
	public class Car
	{

		public delegate double BookValue(string Make, string Model, string Year);


	   public enum ConditionEnum
	   {
			condMint,
			condVeryGood,
			condGood,
			condPoor,
			condJunk
		}

		public double CalculateTotal(BookValue CurrentValue,string Make, string Model, string Year, ConditionEnum CurrentCondition)
		{

			//'*** In this sample, only current condition is used to determine the current  ***
			//'*** value of the car.  The current value is determined by multiplying the    ***
			//'*** the book value by a percentage (based on condition) and then subtracting ***
			//'*** that amount from the book value.                                         ***
        
			switch(CurrentCondition)
			{
				case ConditionEnum.condMint:
					return CurrentValue(Make, Model, Year);
				case ConditionEnum.condVeryGood:
					return CurrentValue(Make, Model, Year) - (CurrentValue(Make, Model, Year) * 0.2);
				case ConditionEnum.condGood:
					return CurrentValue(Make, Model, Year) - (CurrentValue(Make, Model, Year) * 0.4);
				case ConditionEnum.condPoor:
					return CurrentValue(Make, Model, Year) - (CurrentValue(Make, Model, Year) * 0.6);
				case ConditionEnum.condJunk:
					return CurrentValue(Make, Model, Year) - (CurrentValue(Make, Model, Year) * 0.9);
				default:
					return CurrentValue(Make, Model, Year) - (CurrentValue(Make, Model, Year) * 0.9);
			}
		}
		    
	}
}

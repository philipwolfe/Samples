using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Microsoft.Hol.Samples
{
    [ServiceContract(Namespace = "")]

    public interface ICheckWriter
    {
        [OperationContract]
        [WebGet()]
        string Write(decimal checkAmount);
    }
     public class CheckWriter : ICheckWriter
    {
        public string Write(decimal checkAmount)
        {
            return NumToStr(checkAmount);
        }

        //  These two methods are based upon code
        //  from "VBA Developer's Handbook, 2nd Edition"
        //  by Ken Getz and Mike Gilbert
        //  Copyright 2001; Sybex, Inc. All rights reserved.
        //  Used with permission of author.
        public static string NumToStr(decimal inputValue)
        {
            string[] magnitudeNames = { "", "Thousand", "Million" };
            string returnValue = string.Empty;

            if (inputValue > Decimal.MaxValue)
            {
                throw new ArgumentOutOfRangeException(
                        "inputValue", "The input value is too large.");
            }

            inputValue = Math.Abs(inputValue);
            long dollars = System.Convert.ToInt64(Math.Floor(inputValue));
            int cents = System.Convert.ToInt32((inputValue - dollars) * 100);

            if (dollars > 0)
            {
                int tempDollars = 0;
                int groupIndex = 0;
                do
                {
                    tempDollars = System.Convert.ToInt32(dollars % 1000);
                    dollars = System.Convert.ToInt64(
                      (Math.Floor((decimal)(dollars / 1000))));

                    if (tempDollars != 0)
                    {

                        returnValue = String.Format("{0} {1} {2}",
                            HandleGroup(tempDollars),
                            magnitudeNames[groupIndex],
                            returnValue);
                    }

                    groupIndex++;
                }

                while (dollars > 0);
                returnValue = string.Format(
                  "{0} and {1}/100", returnValue.TrimEnd(), cents);
            }
            return returnValue;
        }

        private static string HandleGroup(int valueToConvert)
        {
            string[] onesNames = 
      { "", "One", "Two", "Three", "Four", "Five", 
        "Six", "Seven", "Eight", "Nine", "Ten", 
        "Eleven", "Twelve", "Thirteen", 
        "Fourteen", "Fifteen", "Sixteen", "Seventeen", 
        "Eighteen", "Nineteen", "Twenty" };

            string[] tensNames = { "", "", "Twenty", 
      "Thirty", "Forty", "Fifty", "Sixty", 
      "Seventy", "Eighty", "Ninety" };
            string result = string.Empty;

            int digit = valueToConvert / 100;
            valueToConvert %= 100;
            if (digit > 0)
            {
                result = onesNames[digit] + " Hundred";
            }

            int selectVal = valueToConvert;
            if (((1 <= selectVal) && (selectVal <= 20)))
            {
                result += onesNames[valueToConvert];
            }
            else if (((21 <= selectVal) && (selectVal <= 99)))
            {
                digit = valueToConvert / 10;
                valueToConvert %= 10;

                if (digit > 0)
                {
                    result = string.Format(
                      "{0} {1}", result, tensNames[digit]);
                }

                if (valueToConvert > 0)
                {
                    result = string.Format(
                      "{0}-{1}", result, onesNames[valueToConvert]);
                }
            }
            return result;
        }
    }


}

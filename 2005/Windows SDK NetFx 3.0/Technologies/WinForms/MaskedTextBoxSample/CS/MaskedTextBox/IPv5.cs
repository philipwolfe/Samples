//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.Samples
{
	/// <summary>
	/// Summary description for IPv5.
	/// </summary>
	public class IPv5
	{
		// property fields
		int firstByteValue;
		int secondByteValue;
		int thirdByteValue;
		int fourthByteValue;

		public IPv5()
		{
		}

		public IPv5(string ip)
		{
		}

		public IPv5(int firstByte, int secondByte, int thirdByte, int fourthByte)
		{
			firstByteValue = firstByte;
			secondByteValue = secondByte;
			thirdByteValue = thirdByte;
			fourthByteValue = fourthByte;
		}

		public static IPv5 InvalidIPv5
		{
			get
			{
				return new IPv5(0, 0, 0, 0);
			}
		}

		// properties
		public int FirstByteValue
		{
			get
			{
				return firstByteValue;
			}
			set
			{
				firstByteValue = value;
			}
		}

		public int SecondByteValue
		{
			get
			{
				return secondByteValue;
			}
			set
			{
				secondByteValue = value;
			}
		}

		public int ThirdByteValue
		{
			get
			{
				return thirdByteValue;
			}
			set
			{
				thirdByteValue = value;
			}
		}

		public int FourthByteValue
		{
			get
			{
				return fourthByteValue;
			}
			set
			{
				fourthByteValue = value;
			}
		}

		// Methods
        public static IPv5 Parse(string s)
        {
            int[] bytes = new int[4];

            // Remove any spaces in the string
            s = s.Replace(" ", "");

            // Split the string into byte strings
            string[] strBytes = s.Split(new char[] { '.' });

            try
            {
                int byteIndex = 0;
                foreach (string strByte in strBytes)
                {
                    // Try to parse to an integer
                    bytes[byteIndex] = int.Parse(strByte);

                    // Check bounds
                    // Verify that the last byte is within the valid range 
                    // (1 - 255 for the first three bytes, 0 - 255 for the last byte)
                    if ((bytes[byteIndex] > 255) || ((bytes[byteIndex] < 1) && (byteIndex < 3)))
                    {
                        throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The provided string {0} is not a valid IPv5 IP address", s));
                    }
                    byteIndex++;
                }
            }
            catch
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The provided string {0} is not a valid IPv5 IP address", s));
            }

            return new IPv5(bytes[0], bytes[1], bytes[2], bytes[3]);

        }

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}.{1}.{2}.{3}", firstByteValue.ToString(CultureInfo.CurrentCulture), secondByteValue.ToString(CultureInfo.CurrentCulture), thirdByteValue.ToString(CultureInfo.CurrentCulture), fourthByteValue.ToString(CultureInfo.CurrentCulture));
		}

	}
}

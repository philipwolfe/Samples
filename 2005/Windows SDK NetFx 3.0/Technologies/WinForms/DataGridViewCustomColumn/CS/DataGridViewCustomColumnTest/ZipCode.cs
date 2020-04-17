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
using System.Text;

namespace Microsoft.Samples.Windows.Forms.DataGridViewCustomColumnTest
{
    //  Type that represents a US Zipcode to demonstrate
    //  the ValidatingType feature on the MaskedTextBox.
    public class ZipCode
    {
        private int zipCode;
        private int plusFour;

        public ZipCode()
        {
            this.zipCode = 0;
            this.plusFour = 0;
        }

        public ZipCode(string in_zipCode)
        {
            parseFromString(in_zipCode, out zipCode, out plusFour);
        }

        public ZipCode(int in_ivalue)
        {
            this.zipCode = in_ivalue;
            this.plusFour = 0;
        }


        public static implicit operator ZipCode(string s)
        {
            return new ZipCode(s);
        }

        public static implicit operator ZipCode(int i)
        {
            return new ZipCode(i);
        }


        protected static void parseFromString
        (
            string in_string,
            out int out_zipCode,
            out int out_plusFour
        )
        {
            int zc = 0, pf = 0;
            char[] charray;
            int x = 0;

            if (in_string == null || in_string.Equals(""))
            {
                throw new ArgumentException("Invalid String");
            }

            charray = in_string.Trim().ToCharArray();

            for (x = 0; x < 5; x++)
            {
                if (!Char.IsDigit(charray[x]))
                {
                    throw new ArgumentException("Invalid String");
                }

                zc = zc * 10 + numfromchar(charray[x]);
            }

            while (x < charray.Length && !Char.IsDigit(charray[x]))
            {
                x++;
            }
            
            if (x < charray.Length)
            {
                for (int y = x; y < 4; y++)
                {
                    if (!Char.IsDigit(charray[y]))
                    {
                        throw new ArgumentException("Invalid ZipCode String");
                    }

                    pf = pf * 10 + numfromchar(charray[y]);
                }
            }

            out_zipCode = zc;
            out_plusFour = pf;
        }


        private static int numfromchar(char c)
        {
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;

                default:
                    throw new ArgumentException("invalid digit");
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(10);

            sb.Append(zipCode.ToString("00000"));
            sb.Append("-");
            sb.Append(plusFour.ToString("0000"));

            return sb.ToString();
        }
    }
}

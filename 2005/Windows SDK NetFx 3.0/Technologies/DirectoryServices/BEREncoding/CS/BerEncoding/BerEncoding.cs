/*=====================================================================
  File:      BerEncoding.cs

  Summary:   Demonstrates BerConverter class usage to do ber encoding/decoding.

---------------------------------------------------------------------
  This file is part of the Microsoft .NET SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

// To compile: 
// csc.exe /out:App.exe /r:System.DirectoryServices.Protocols.dll BerEncoding.cs
// To run: App.exe


using System;
using System.Text;
using System.Security.Permissions;
using System.Globalization;

using System.DirectoryServices.Protocols;


[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]

namespace Microsoft.Samples.DirectoryServices
{
    
public static class App
{
    public static void Main()
    {
        try
        {
            DoBerEncoding();
            
            Console.WriteLine("\r\nApplication Finished Successfully!!!");
        }
        catch(Exception e)
        {
            Console.WriteLine("\r\nUnexpected exception occured:\r\n\t" + 
                              e.GetType().Name + ":" + e.Message);
        }        
    }
    
    static void DoBerEncoding()
    {    
        try
        {
            bool boolValue = true;
            int intValue = 5;
            byte[] binaryValue = new byte[] { 0x00, 0x01, 0x02, 0x03};
            string strValue = "abcdef";
            string[] strValues = {"abc", "def", "xyzw"};
            byte[][] binaryValues = {
                                     new byte[]{0x00, 0x01, 0x02, 0x03},
                                     new byte[]{0x04, 0x05, 0x06, 0x07},
                                     new byte[]{0x08, 0x09, 0x0A},
                                     new byte[]{0x0B, 0x0C}
                                    };

            Console.WriteLine("\r\nBer encoding objects...");
            byte[] berEncodedValue = BerConverter.Encode("{bios{v}{V}}", 
                                                         new object[]{
                                                           boolValue,
                                                           intValue,
                                                           binaryValue,
                                                           strValue,
                                                           strValues,
                                                           binaryValues});

            Console.WriteLine("\r\nBer decoding the byte array...");
            object[] decodedObjects = BerConverter.Decode("{biOavV}",
                                                          berEncodedValue);
            
            Console.WriteLine("\r\nThe decoded objects are:");
            foreach(object o in decodedObjects)
            {
                if(o is byte[])
                {
                    Console.WriteLine(ByteArrayToStringInHex((byte[])o));
                }
                else if (o is byte[][])
                {
                    byte[][] byteArrays = (byte[][])o;
                    for(int i=0;i<byteArrays.Length;i++)
                    {
                        Console.Write(ByteArrayToStringInHex(byteArrays[i])
                                      + " - ");
                    }
                    Console.WriteLine();
                }
                else if(o is string[])
                {
                    string[] strArray = (string[])o;
                    for(int i=0;i<strArray.Length;i++)
                    {
                        Console.Write(strArray[i] + " - ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(o);
                }
            }
        }
        catch(BerConversionException e)
        {
            Console.WriteLine("BerConversionException:" + e.Message);
        }
        catch(ArgumentException e)
        {
            Console.WriteLine("ArgumentException:" + e.Message);
        }
    }    



    //
    // Converts a byte[] to a hex string
    //
    public static string ByteArrayToStringInHex(byte[] bytes)
    {
        StringBuilder s = new StringBuilder(bytes.Length/2);
        foreach(byte b in bytes)
        {        
            s.Append(String.Format(CultureInfo.InvariantCulture, "0x{0:X2}," ,b));
        }
        string retStr = s.ToString();

        // remove the last comma character
        retStr = retStr.Remove(retStr.Length-1,1); 
        return retStr; 
    }     
    
}// end class App

}

/*=====================================================================
  File:      BerEncoding.cpp

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

// To run: App.exe

using namespace System;
using namespace System::Security::Permissions;
using namespace System::DirectoryServices::Protocols;

[assembly: System::Reflection::AssemblyVersion("1.0.0.0")];
[assembly: SecurityPermission(SecurityAction::RequestMinimum, 
                              Execution = true,
                              ControlAppDomain = true,
                              UnmanagedCode = true,
                              SkipVerification = true)];



namespace Microsoft
{

namespace Samples
{

namespace DirectoryServices
{


public ref class App sealed
{    

private:
    App(){};

public:
    static void DoBerEncoding()
    {    
        try
        {
            bool boolValue = true;
            int intValue = 5;
            array<unsigned char>^ binaryValue = {0x00, 0x01, 0x02, 0x03};

            
            String^ strValue = "abcdef";
            array<String^>^ strValues = {"abc", "def", "xyzw"};


            array<array<unsigned char>^>^  binaryValues = {
                                                 {0x00, 0x01, 0x02, 0x03},
                                                 {0x04, 0x05, 0x06, 0x07},
                                                 {0x08, 0x09, 0x0A},
                                                 {0x0B, 0x0C},
                                                };



            Console::WriteLine("\r\nBer encoding objects...");
            
            array<unsigned char>^ berEncodedValue = 
                                        BerConverter::Encode("{bios{v}{V}}", 
                                        gcnew array<Object^>{boolValue,
                                                             intValue, 
                                                             binaryValue,
                                                             strValue,
                                                             strValues,
                                                             binaryValues});

            Console::WriteLine("\r\nBer decoding the byte array...");
            array<Object^>^ decodedObjects = BerConverter::Decode("{biOavV}", 
                                                               berEncodedValue);
            Console::WriteLine("\r\nThe decoded objects are:");

            for(int i=0;i<decodedObjects->Length;i++)
            {
                Console::WriteLine(decodedObjects[i]);
            }            
        }
        catch(BerConversionException^ e)
        {
            Console::WriteLine("BerConversionException:{0}", e->Message);
        }
        catch(ArgumentException^ e)
        {
            Console::WriteLine("ArgumentException:{0}", e->Message);
        }
    }    
};// end class App

}}}


using namespace Microsoft::Samples::DirectoryServices;

void main()
{   
    try
    {
        App::DoBerEncoding();
        
        Console::WriteLine("\r\nApplication Finished Successfully!!!");
    }
    catch(Exception^ e)
    {
        Console::WriteLine("\r\nUnexpected exception occured:\r\n\t{0}:{1}", 
                            e->GetType()->Name, e->Message);
    }
}




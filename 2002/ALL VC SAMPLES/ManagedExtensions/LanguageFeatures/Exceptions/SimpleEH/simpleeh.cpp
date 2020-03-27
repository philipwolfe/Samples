///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows simple exception handling in .NET
//
///////////////////////////////////////////////////////////////////////////////


#using<mscorlib.dll>
using namespace System;

int main(int argc, char** argv) {

  try {
    try {
      Console::WriteLine(S"This is a test");
      throw new Exception(S"My exception");
    } __finally {
      ;
    }
  } catch(Exception* o) {
	  Console::Write(S"In catch. Exception caught: ");
	  Console::WriteLine(o->ToString());
  }__finally  {
    ;
  }
  return 0;
}

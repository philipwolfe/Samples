///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows how to re-throw an exception in .NET.
//
///////////////////////////////////////////////////////////////////////////////

#using<mscorlib.dll>
using namespace System;

__gc class X {
public:
        int func(int i) {
           switch(i) {
              case 0:
                throw new Exception();
              default:
                break;
           }
           return i;
        }

        virtual void handler(void) { Console::WriteLine(S"In handler 1\n"); }
};

int f(int i) {
    X* x = new X();
    try {
        x->func(i);
    } catch (Exception* e) {
        x->handler();
        throw e; //re-throw e
    }
    return 0;
}

int main(void) {
   try {
     f(0);
   } catch(...) {
        Console::WriteLine(S"In handler 2\n"); 
   }
   return 0;
}

///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /CLR cdel.cpp
//
//  Description: Shows how to create and use CLR Delegates in C++
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>
#using "bin\\csdel.dll"

using namespace System;

//
// Declare two types of delegates
//
__delegate void SCDelegate(double i);
__delegate void MCDelegate(int i);

public __gc class X {
public:
    void mf1(int i) {
        Console::Write(S"X::mf1: ");
        Console::WriteLine(i);
    }

    void mf2(double d) {
        Console::Write(S"X::mf2: ");
        Console::WriteLine(d);
    }
};

int main()
{
    //
    // Create an instance of the handler class
    //
    X* pX = new X;

    //
    // Create single-cast delegate
    //
    SCDelegate *pSCDelegate = new SCDelegate(pX, &X::mf2);

    //
    // Invoke the single-cast delegate
    //
    pSCDelegate->Invoke(3.14);

    //
    // Create an instance of the C# class
    //
    CDel *pCDel = new CDel;

    //
    // Create a multi-cast delegate with a C++ handler
    //
    MCDelegate *pMCDelegate = new MCDelegate(pX, &X::mf1);

    //
    // Combine this handler with the C# handler
    //
    pMCDelegate = static_cast<MCDelegate *>(Delegate::Combine(pMCDelegate, new MCDelegate(pCDel, &CDel::Handler)));

    //
    // Invoke the multi-cast Delegate
    //
    pMCDelegate->Invoke(13);

    return 0;
}

///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /CLR properties.cpp
//
//  Description: Shows how to create and use CLR properties in C++
//
///////////////////////////////////////////////////////////////////////////////

#using<mscorlib.dll>

using namespace System;

public __gc class X{
public:
    //
    // Regular property
    //
    __property int  get_Size();
    __property void set_Size(int value);

    //
    // Index property
    //
    __property int  get_Value(int i);
    __property void set_Value(int i, int value);

private: 
    int m_nSize;
    int m_rValues __nogc[10];
};

int X::get_Size()
{
    return m_nSize;
}

void X::set_Size(int value)
{
    m_nSize = value;
}

int X::get_Value(int i)
{
    return m_rValues[i];
}

void X::set_Value(int i, int value)
{
    m_rValues[i] = value;
}

int main()
{
    X *pX = new X();

    //
    // Set the properties
    //
    pX->Size = 4;
    pX->Value[5] = 2;

    //
    // Get and check the values
    //
    if ((pX->Size == 4) && (pX->Value[5] == 2)) {
        Console::WriteLine(S"Passed");
    }
    else { 
        Console::WriteLine(S"Failed");
    }

    return 0;
}

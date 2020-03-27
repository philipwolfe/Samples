///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /CLR arrays.cpp
//
//  Description: Show the creation and use of both single-dimensional
//     and multi-dimensional CLR arrays
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>

using namespace System;

///////////////////////////////////////////////////////////////////////////////////////////

int nFailures = 0;

int Assert(const char *pMsg)
{
    Console::Write(L"Test failed:\t");
    Console::WriteLine(pMsg);

    return ++nFailures;
}

#define ASSERT(f) ((f) || Assert(#f))

///////////////////////////////////////////////////////////////////////////////////////////

public __gc class X {
public:
    X(int nData)
        : m_nData(nData) {
    }

    int get() {
        return m_nData;
    }

    String * m_pStr;

private:
    int m_nData;
};

public __value class V {
public:
    String *s;
};

//
// Function returning a multi-dimensional CLR array
// The array is a CLR array because the base type is a managed class
//
X * func1() [,]
{ 
    X *rX[,] = new X *[10, 10];

    rX[5, 5] = new X(99);

    return rX;
}

//
// Function returning single-dimensional CLR array
// The array is a CLR array because the base type is a managed class
//
X * func2()[]
{
    X *rX[] = new X*[10];

    rX[5] = new X(55);

    return rX;
}

//
// Function returning a multi-dimensional CLR array
// The array is explicitly managed
//
int func3() __gc[,]
{
    int rInt __gc[,] = new int __gc[10, 10];

    rInt[5,5] = 123;

    return rInt;
}

//
// Function returning a single-dimensional CLR array
// The array is explicitly managed
//
int func4() __gc[]
{
    int rInt __gc[] = new int __gc[10];

    rInt[5] = 456;

    return rInt;
}

int main()
{
    //
    // Create a 1-dimensional managed array of int
    //
    int rInt __gc[] = new int __gc[10];

    ASSERT(rInt->Count == 10);
    ASSERT(rInt->Rank == 1);

    //
    // Create a 5-dimensional managed array of X
    //
    X * rX[,,,,] = new X *[3, 3, 3, 3, 3];

    rX[2, 2, 2, 2, 2] = new X(99);
    rX[2, 2, 2, 2, 2]->m_pStr = S"managedStr";

    //
    // Note: Double braces needed since the parameter for the ASSERT macro
    // contains commas (',')
    //
    ASSERT((rX[2, 2, 2, 2, 2]->get() == 99) );
    ASSERT((rX[2, 2, 2, 2, 2]->m_pStr->Equals(S"managedStr")));
    ASSERT((func1()[5, 5]->get() == 99));
    ASSERT((func2()[5]->get() == 55));
    ASSERT((func3()[5,5] == 123));
    ASSERT(func4()[5] == 456 );

    //
    // Create a multi-dimensional array of Strings
    //
    String * rStr[,] = new String *[10, 10];

    rStr[5, 5] = S"Hello";

    ASSERT((rStr[5, 5]->Equals(S"Hello")));

    //
    // Create a single-dimensional and multi-dimensional arrays of value-types
    //
    V rV1[]  = new V[10];
    V rV2[,] = new V[10, 10];

    ASSERT(rV1->Rank == 1);
    ASSERT(rV2->Rank == 2);

    if (nFailures == 0) {
        Console::WriteLine(L"Passed");
    }
	else {
        Console::WriteLine(L"Failed");
	}

    return nFailures;
}

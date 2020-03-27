///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /clr PinningPtrs.cpp
//
//  Description: Shows how register/pin memory in C++
//
///////////////////////////////////////////////////////////////////////////////

#using<mscorlib.dll>

using namespace System;

__gc class G {
public:
    int i;
};

__gc class H {
public:
    void func1(G *pG) {                   // pG is a gc pointer
        G __pin *pPinG = pG;            // pG is pinned
        G *pG2 = new G;                 // pG2 is gc pointer
        pG2 = pPinG;                    // OK: pinned gc pointer implicitly converted to a gc pointer
        int __pin *pPinInt = &pG2->i;   // OK: gc pointer implicitly converted to a pinned pointer
        int *pInt = pPinInt;            // OK: pinned variable implicitly converted to a nogc pointer
        int __nogc *pNoGCInt;
        pNoGCInt = pPinInt;
        pPinInt = pInt;                 // OK: Convert nogc pointer to pin pointer
    }

    void func2() {
        int __nogc * pNoGCInt = 0;
        int __gc   * pGCInt = 0;
        int __pin  * pPinInt = 0;

        // pNoGCInt = pGCInt;           // error C2440: '=' : cannot convert from 'int __gc *' to 'int *'
                                        //      Cannot convert a managed type to an unmanaged type
        pNoGCInt = pPinInt;             // OK: Converts pinned pointer to nogc pointer

        pGCInt = pNoGCInt;              // OK: Adding gc ness to a pointer to a value type is OK
        pGCInt = pPinInt;               // OK: Implicit conversion from pinned pointer to gc pointer

        pPinInt = pNoGCInt;             // OK: Converts nogc pointer to pinned pointer
        pPinInt = pGCInt;               // OK: Implicit conversion from gc pointer to pinned pointer (pinning)
    }
};

int main()
{
    H *pH = new H;                          // pH is a gc pointer
    G *pG = new G;                          // pG is a gc pointer

    pH->func1(pG);
    pH->func2();

    return 0;
}


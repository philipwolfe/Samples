/////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /CLR customattributes.cpp
//
//  Description: Shows how to create and use custom attributes in C# and C++
//
/////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>
#using "bin\ABC.dll"
#using "bin\Author.dll"

using namespace System;
using namespace System::Reflection;

[ABC(S"abc")]
//[Author(S"str", 1)] // -- should give error
[Author(1, version=1.2)]
[ABC(SomeStuff::e17)]
[ABC(1, rgdField={6, 1.2})]
[ABC]
[ABC(S"99")]
[ABC(1, rgnField={11, 17})]
[Author(1, rgdField={6, 1.2})]
[Author]
[Author(S"99")]
[Author(1, rgnField={1, 2})]
public __gc class SomeClass {
};

void main() {
    MemberInfo* pIR = (new SomeClass)->GetType();
    Object* objs __gc [] = pIR->GetCustomAttributes(false);
    Console::Write(S"objs.length=");
    Console::WriteLine(objs.Length);
    for (int i = 0; i < objs.Length; ++i) {
        Object* po = objs[i];
        Type* pt = po->GetType();
        String* ps = pt->FullName;
        Console::WriteLine(ps);
    }
}

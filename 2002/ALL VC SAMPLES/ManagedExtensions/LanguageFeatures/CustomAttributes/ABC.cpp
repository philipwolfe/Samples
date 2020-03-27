/////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: cl /CLR /LD ABC.cpp
//
//  Description: Shows how to create and use custom attributes in C# and C++
//
/////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Security::Permissions;

public __value enum SomeStuff { 
    e1 = 1, 
    e17 = 17 
};

[attribute(AttributeTargets::Class, AllowMultiple=true)]
public __gc class ABC {
public:
    ABC(int __gc[]) {}
    ABC() {}
    ABC(int) {}
    ABC(int, float) {}
    ABC(SomeStuff) {}
    ABC(String*) {}
    int rgnField __gc [];
    double rgdField __gc [];
    double dField;
};

[ABC(rgdField={11, 17})]
[ABC(dField=17)]
[ABC(1, rgnField={6, 2})]
[ABC(1, rgdField={3.14159, 1.2})]
[ABC({6, 1.2})]
[ABC(dField=1.2)]
[ABC({1,2})]
[ABC(SomeStuff::e17)]
[ABC(S"SomeString")]
[PermissionSetAttribute(SecurityAction::Deny)]
[FileIOPermissionAttribute(SecurityAction::Demand, Read = S"d:\\log.txt")]
[SecurityPermissionAttribute(SecurityAction::Assert, Unrestricted=true)]
public __gc struct AAA {
};

//
// Unused -- unless you just compile "cl /CLR ABC.cpp"
//  and then run "ABC.exe"
//
void main() {
    Reflection::MemberInfo* m = (new AAA)->GetType();
    Object * pObjs __gc[] = m->GetCustomAttributes(false);
    String * s = String::Empty;
    for(int i=0; i < pObjs->Length; i++) {
        Object* po = pObjs[i];
        Type* pt = po->GetType();
        String* ps = pt->FullName;
        Console::WriteLine(ps);
    }
}

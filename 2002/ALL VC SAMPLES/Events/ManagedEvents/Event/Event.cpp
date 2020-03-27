// This is the main DLL file.

#include "stdafx.h"

#include "Event.h"

#using "mscorlib.dll"
using namespace System;




void main() {
    Event* p = new Event;
    p->Hook();
    p->Fire_MyEvent(2, 3.3);
    p->Fire_MyEvent2("Hello");
    p->UnHook();
    p->Fire_MyEvent(2, 3.3);
    p->Fire_MyEvent2("Hello");
}


// This is the main project file for VC++ application project 
// generated using an Application Wizard.

#include "stdafx.h"

#using <mscorlib.dll>

using namespace System;
#using "Event.dll"

#using "CSEvent.dll"
using namespace CSEvent;
[ event_receiver(managed) ]
__gc class Receiver {
public:
    void Handler1(int x, double y) { 
        Console::Write("Receiver::Handler1(");
        Console::Write(x);
        Console::Write(",");
        Console::Write(y);
        Console::WriteLine(")");
    }
    void Handler2(int x, double y) {
        Console::Write("Receiver::Handler2(");
        Console::Write(x);
        Console::Write(",");
        Console::Write(y);
        Console::WriteLine(")");
    }
    void Handler3(int x) { 
        Console::Write("Receiver::Handler3(");
        Console::Write(x);
        Console::WriteLine(")");
    }
    void Handler4(int x) { 
        Console::Write("Receiver::Handler4(");
        Console::Write(x);
        Console::WriteLine(")");
    }
    void Handler5(String* s) {
        Console::Write("Receiver::Handler5(");
        Console::Write(s);
        Console::WriteLine(")");
    }

    void Hook(Event* p, CEvent* p2) {
        __hook(&Event::MyEvent, p, &Receiver::Handler1);
        __hook(&Event::MyEvent2, p, &Receiver::Handler5);
        p->MyEvent += new MyDelegate(this, &Receiver::Handler1);
        p->MyEvent += new MyDelegate(this, &Receiver::Handler2);
        
		p2->add_CMyEvent(new MyEventHandler(this, &Receiver::Handler3));
        p2->add_CMyEvent(new MyEventHandler(this, &Receiver::Handler4));
    }
    void Unhook(Event* p, CEvent* p2) {
        __unhook(&Event::MyEvent, p, &Receiver::Handler1);
        __unhook(&Event::MyEvent2, p, &Receiver::Handler5);
        p->MyEvent -= new MyDelegate(this, &Receiver::Handler1);
        p->MyEvent -= new MyDelegate(this, &Receiver::Handler2);
        p2->remove_CMyEvent(new MyEventHandler(this, &Receiver::Handler3));
        p2->remove_CMyEvent(new MyEventHandler(this, &Receiver::Handler4));
    }
};

// This is the entry point for this application
#ifdef _UNICODE
int wmain(void)
#else
int main(void)
#endif
{
	Event* pSrc = new Event;
    CEvent* pSrc2 = new CEvent;
    pSrc->Fire_MyEvent(7, 3.14159);
    Receiver* pSink = new Receiver;
    pSink->Hook(pSrc, pSrc2);
    pSrc->Hook();
    Console::WriteLine("\nHooked");
    pSrc->Fire_MyEvent(7, 3.14159);
    pSrc->Fire_MyEvent2("GoodBye");
    pSrc2->Fire(1313);
    pSrc->UnHook();
    pSink->Unhook(pSrc, pSrc2);
    Console::WriteLine("\nUnhooked");
    pSrc->Fire_MyEvent(7, 3.14159);
    pSrc2->Fire(1313);
    pSrc->Fire_MyEvent2("Hello");

	//Use unified event __hook/__unhook syntax for MyEvent3
	__hook(Event::MyEvent3, pSrc, Receiver::Handler2, pSink);
	Console::WriteLine("Hooked MyEvent3");
	Console::WriteLine("Fire MyEvent3");
	pSrc->MyEvent3(7, 3.14159);
	__unhook(Event::MyEvent3, pSrc, Receiver::Handler2, pSink);
	Console::WriteLine("Unhooked MyEvent3");
	pSrc->MyEvent3(7, 3.14159);
    return 0;
}
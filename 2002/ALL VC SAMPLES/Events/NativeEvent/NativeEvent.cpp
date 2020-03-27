/////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//  Description: Shows how to use native C++ events
//
/////////////////////////////////////////////////////////////////////
#include "stdafx.h"

#include <stdio.h>

namespace N {                       // namespace is optional
    [event_source(native)]          // event_source is optional for native events
    struct Source {
        __event long __stdcall event1(int i);
        __event void event2(int i, float j);
        void doSomething() {
            event1(7);
            event2(13, 3.14159);
        }
    };
}

namespace M {                       // namespace is optional
    [event_receiver(native)]        // event_receiver is optional for native events
    struct Receiver {
        long __stdcall handler1(int i) {
            printf("M::Receiver::handler1(this=%p,i=%d)\r\n", this, i);
            return 0;
        }
        void handler2(int i, float j) {
            printf("M::Receiver::handler2(this=%p,i=%d,j=%f)\r\n", this, i, j);
        }
        void Hook(N::Source* p) {
            __hook(&N::Source::event1, p ,&M::Receiver::handler1);
            __hook(&N::Source::event2, p ,&M::Receiver::handler2);
        }
        void RemoveEvent2(N::Source* p) {
            __unhook(&N::Source::event2, p ,&M::Receiver::handler2);
        }
        void RemoveAll(N::Source* p) {
            __unhook(p);
        }
    };
}

int main(int argc, char* argv[])
{    
	N::Source* p = new N::Source;
    M::Receiver* q = new M::Receiver;
    q->Hook(p); 
    p->doSomething();
    q->RemoveEvent2(p);
    p->doSomething();

	//Use Unified Syntax do __hook/__unhook again
	__hook(&N::Source::event1, p, &M::Receiver::handler1, q);
	__hook(&N::Source::event2, p, &M::Receiver::handler2, q);
	p->doSomething();
	__unhook(&N::Source::event1, p, &M::Receiver::handler1, q);
	__unhook(&N::Source::event2, p, &M::Receiver::handler2, q);

	return 0;
}

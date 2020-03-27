// Event.h

#pragma once

#using <mscorlib.dll>
using namespace System;
public __delegate void MyDelegate(int x, double y);

public __gc class Event {
private:
public:
    __event MyDelegate* MyEvent;
    __event void MyEvent2(String*);

	//Use advanced syntax
	MyDelegate* _pd;
	__event void add_MyEvent3(MyDelegate* pd) {
		_pd = dynamic_cast<MyDelegate*> (Delegate::Combine(_pd, pd));
	}
	__event void remove_MyEvent3(MyDelegate* pd) {
		_pd = dynamic_cast<MyDelegate*> (Delegate::Remove(_pd, pd));
	}
	__event void raise_MyEvent3(int x, double y) {
		if (_pd) {
				_pd->Invoke(x, y);
		}
	}

	void Fire_MyEvent(int x, double y) {
			MyEvent(x, y);
	}
	void Fire_MyEvent2(String *s) {
			MyEvent2(s);
	}
public:
    void Handler(int x, double y) { 
        Console::Write("Event::Handler("); 
        Console::Write(x);
        Console::Write(",");
        Console::Write(y);
        Console::WriteLine(")"); 
    }
    void Handler2(String* s) { 
        Console::Write("Event::Handler2("); 
        Console::Write(s); 
        Console::WriteLine(")"); 
    }

    void Hook() { 
        MyEvent += new MyDelegate(this, &Event::Handler); 
        MyEvent2 += new __Delegate_MyEvent2(this, &Event::Handler2);
    }
    void UnHook() { 
        MyEvent -= new MyDelegate(this, &Event::Handler); 
        MyEvent2 -= new __Delegate_MyEvent2(this, &Event::Handler2);
    }
};
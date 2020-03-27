///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows mixing unmanged exceptions with managed ones.
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>
using namespace System;

struct S {
};

void foo(int i) {
   if (i == 0) {
      throw (new S());
   }
   else {
      Exception *e = new Exception;
      throw e;
   }
}

int main() {
	int nRes = 1;
   for (int i = 0; i < 2; i++) {
       try {
           foo(i);
       }
       catch (S* s) {
		   (s);
		   Console::WriteLine(S"Caught an unmanaged exception!");
			nRes -= 2*i;
       }
       catch (Exception* e) {
		   Console::WriteLine(S"Caught a managed exception: {0}", e->ToString());
			nRes -= i;
       }
   }

   return nRes;
}

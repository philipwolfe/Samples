///////////////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Description: Shows how __finally blocks work.
//
///////////////////////////////////////////////////////////////////////////////

#using <mscorlib.dll>
using namespace System;

int main(){
        try {
                try{
					throw;
                }
                catch(Exception* e){
					Console::WriteLine(S"Inner Catch: {0}", e->Message);
					throw;
                }
                __finally { // is executed before the execution control is passed to the outside catch.
                        Console::WriteLine(S"Inner Finally");
                }
        }
        catch(Exception* e){
			Console::WriteLine(S"Outer Catch: {0}", e->Message);
        }
        __finally{
                Console::WriteLine(S"Outer Finally");
        }

        return 0;
}

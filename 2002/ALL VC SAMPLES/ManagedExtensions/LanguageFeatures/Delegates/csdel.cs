/////////////////////////////////////////////////////////////////////
//
//  Copyright (C) Microsoft Corp 2000.  All rights reserved.
//
//  Run: nmake -f delegate.mak
//
//  Description: Shows how to create and use CLR Delegates in C++
//
/////////////////////////////////////////////////////////////////////

public class CDel {
    public void Handler(int i) {
        System.Console.WriteLine("CDel::Handler: " + i);
    }
};

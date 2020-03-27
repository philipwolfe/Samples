//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//
// netJrnlClientB.cpp
//

// #using is how we import metadata.  mscorlib.dll must be passed to #using for any 
// C++ program that uses managed extensions.
#using <mscorlib.dll>

// import metadata for glposter's MGLPost class.
#ifdef _DEBUG
#using "..\JrnlPoster\debug\JrnlPoster.dll"
#else
#using "..\JrnlPoster\release\JrnlPoster.dll"
#endif

using namespace System;

void main()
{
	try {
		netJEPost* pJEPost = new netJEPost;
		pJEPost->OpenTransaction("JE #2 Pencil  rebate");
		pJEPost->AddEntry("111212", (float) 98.25);
		pJEPost->AddEntry("111213", (float) -98.25);
		pJEPost->Commit();
	}
	catch (System::Exception* pE) {
		Console::WriteLine("Exception {0}",pE->Message);
	}
}


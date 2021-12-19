'*===========================================================================
'  File:      VideoPlayer.CPP
' 
'  Summary:   This program demonstrates using a classic COM object 
'             from the Runtime.
' 
'  Functions: main
' 
'----------------------------------------------------------------------------
'  This file is part of the Microsoft NGWS Samples.
'
'  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
'===========================================================================*/

imports System
imports System.Runtime.InteropServices
imports System.Threading

imports QuartzTypeLib

Option Explicit
Option Strict Off


'******************************************************************************
'Function : main
'
'Abstract: This method collects the filename of an AVI to show then creates an 
'instance of the Quartz classic COM object.  To show the AVI, the program calls
'RenderFile and Run on IMediaControl.  Quartz uses its own thread and window
'to display the AVI.  The main thread blocks on a ReadLine until the user hits
'enter.
'
'Input Parameters: None
'
'Returns: int: Standard 32 bit process return code.
'******************************************************************************/


Public Module modmain

   Sub Main()
        ' Parse the command-line arguments
 '       dim ap as New VideoPlayerArgParser
        dim args as string()



        args = Environment.GetCommandLineArgs()
	if args.length <> 2 then
	' User did not provide enough parameters.
	' Display usage.
	Console.WriteLine("VideoPlayer: Plays AVI files.")
	Console.WriteLine("Usage: VIDEOPLAYER.EXE filename")
	Console.WriteLine("where filename is the full path and file name")
	Console.WriteLine("of the AVI to display.")
	exit sub
	endif

'        if not ap.Parse() then 
'            ' An error occurrend while parsing
'            exit sub
'        end if

	' Set thread to be STA instead of MTA
	Thread.CurrentThread.ApartmentState = ApartmentState.STA

	' Create instance of Quartz
	Dim mc as QuartzTypeLib.IMediaControl = new QuartzTypeLib.FilgraphManager()

	try

		' Pass in file to RenderFile method on Classic COM object.
		mc.RenderFile(args.GetValue(1))

		' Show file.
		mc.Run()

	catch e as COMException When e.ErrorCode = &h80040265
	
			' Quartz does not know how to render this file
			Console.WriteLine("VideoPlayer does not know how to render this file type.")

	Catch e as COMException when e.ErrorCode = &h80040216
		
			' Quartz could not find the file
			Console.WriteLine("VideoPlayer cannot find the file.")
	catch

		Console.WriteLine("Unknown error occured.")
		
		exit sub
	end try

	' Wait for completion.
	
	Console.WriteLine("Hit Enter to exit.")
	Console.ReadLine()
	
end sub

end Module



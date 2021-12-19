'
'	This program writes out a large file and then reads it back in
'	calculating the speed

Imports System
Imports System.IO

Public Class ReadWrite
    
    public Shared Sub Main ()

        dim origTestSize as double
        dim args  as string ()
        args = Environment.GetCommandLineArgs()
        If args.Length <= 1
        
            Console.WriteLine ("Usage:")
            Console.WriteLine ("   LargeReadWrite numberKB")
            Console.WriteLine ()
            Console.WriteLine ("Example:")
            Console.WriteLine ("   LargeReadWrite 1")
            Console.WriteLine ()
            Console.WriteLine ("Continuing with numberKB=1")
            origTestSize = 1
        
        Else  
        
           origTestSize = [Double].Parse(args(1))
        End If

        Dim testSize As double 
        testSize = origTestSize * 1024  
        Console.WriteLine ("Running test with size {0} KB", origTestSize.ToString())
        Console.WriteLine ("This may take a while...")
        Dim fs As FileStream 
        fs = new FileStream("data.bin", FileMode.OpenOrCreate)	
        fs.SetLength(0)
        Dim w As BinaryWriter 
        w = new BinaryWriter(fs)
        Dim r As BinaryReader 
        r = new BinaryReader(fs)
        w.BaseStream.Seek(0,SeekOrigin.Begin)
        
        Console.Write  ("Writing file..")
        Dim beginWrite as Integer 
        beginWrite = Environment.TickCount
        Dim I as Integer
        For i = 0 To CInt(testSize-1)
            w.Write( CByte(1))
        Next
        Console.WriteLine ()
        fs.Flush()
        
        Dim endWrite As Integer
        endWrite = Environment.TickCount
        Console.WriteLine ("For the Write...")	  
        Console.WriteLine ("Start Time: {0}", beginWrite.ToString())
        Console.WriteLine ("End Time: {0}", endWrite.ToString())
        Console.WriteLine ("Elapsed Time: {0} ms", endWrite-beginWrite)  'the time span in in ms


        Dim thruputWrite As double
	if (endWrite-beginWrite) > 0 then
        	thruputWrite = (origTestSize / (endWrite-beginWrite) * 1000)
	else
		thruputWrite = 0
	end if
	if thruputWrite = 0 then
		Console.WriteLine ( "Data Thruput: Infinity mb/sec")
	else
	        Console.WriteLine ("Data Thruput: {0} mb/sec",80 *thruputWrite)
	end if

        w.BaseStream.Seek(0,SeekOrigin.Begin)	'set the file pointer to the beginning
        dim  dummyInt As Integer
        
        Dim  beginRead As Integer
        beginRead = Environment.TickCount	  
        
        For I = 0 to CInt (testSize-1)
            dummyInt = r.ReadByte()
        Next
        fs.Flush()
        
        Dim endRead As Integer
        endRead = Environment.TickCount
        
        Console.WriteLine ()
        Console.WriteLine ("For the Read...")
        Console.WriteLine ("Start Time: {0}", beginRead.ToString())
        Console.WriteLine ("End Time: {0}", endRead.ToString())
        Console.WriteLine ("Elapsed Time: {0}", endRead-beginRead) ' the time span in in ms
        Dim thruputRead As double 

	if ((endRead-beginRead) * 1000) > 0 then
		thruputRead = (origTestSize / (endRead-beginRead) * 1000)
	else
		thruputread = 0
	end if

	if thruputread = 0 then
		Console.WriteLine ( "Data Thruput: Infinity mb/sec")
	else
		Console.WriteLine ("Data Thruput: {0} mb/sec", thruputRead)		
	end if

        
        fs.Close()
        System.IO.File.Delete("data.bin")
        
        Console.WriteLine ()
        Console.WriteLine ("Press Return to exit.")
        Console.Read()
    End Sub
End Class

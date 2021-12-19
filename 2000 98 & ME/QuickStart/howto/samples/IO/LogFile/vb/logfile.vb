Imports System
Imports System.IO

Module Directory

	
    Public Sub Main()
        Dim fs As FileStream = New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write)
        Dim w As StreamWriter = New StreamWriter(fs) ' create a Char writer 
        w.BaseStream.Seek(0, SeekOrigin.End) ' set the file pointer to the end
		
        Log("Test1", w)
        Log("Test2", w)
        w.Close() 'close the writer and underlying file  
		
		
        fs = New FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Read)
		
        Dim r As StreamReader = New StreamReader(fs) ' create a Char reader
        r.BaseStream.Seek(0, SeekOrigin.Begin) ' set the file pointer to the beginning
        DumpLog(r)
		
    End Sub

    Public Sub Log(ByVal logMessage As String, ByVal w As StreamWriter)
	
        w.WriteLine()
        w.Write("Log Entry : ")
		w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString())
		w.WriteLine("  :")
		w.WriteLine("  :{0}", logMessage)
		w.WriteLine("-------------------------------")
		w.Flush()  ' update underlying file
	End Sub

	Public Sub DumpLog(r As StreamReader)
	
		While r.Peek() > -1                      'while not at the end of the file
			Console.WriteLine(r.ReadLine())
		End While
		
		r.Close()
		
		Console.WriteLine()
		Console.WriteLine("Press Return to exit.")
		Console.Read()
	End Sub
End Module

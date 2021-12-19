using System;
using System.IO;

class Directory 
{
	
	public static void Main(String[] args)
	{ 
		FileStream fs = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write);
		StreamWriter w = new StreamWriter(fs);         // create a Char writer 
		w.BaseStream.Seek(0, SeekOrigin.End);      // set the file pointer to the end
		
		Log ("Test1", w);
		Log ("Test2", w);
		w.Close(); // close the writer and underlying file  
		
		
		fs = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Read);
		
		StreamReader r = new StreamReader(fs);        // create a Char reader
		r.BaseStream.Seek(0, SeekOrigin.Begin);   // set the file pointer to the beginning
		DumpLog (r);
		
	}
	public static void Log (String logMessage, StreamWriter w)
	{
		w.Write("\r\nLog Entry : ");
		w.WriteLine("{0} {1}", 
			DateTime.Now.ToLongTimeString(), 
			DateTime.Now.ToLongDateString());
		w.WriteLine("  :");
		w.WriteLine("  :{0}", logMessage);
		w.WriteLine ("-------------------------------");
		w.Flush();  // update underlying file
	}
	public static void DumpLog (StreamReader r)
	{
		while (r.Peek() > -1)                        // while not at the end of the file
		{
			Console.WriteLine(r.ReadLine());
		}
		
		r.Close();
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
}

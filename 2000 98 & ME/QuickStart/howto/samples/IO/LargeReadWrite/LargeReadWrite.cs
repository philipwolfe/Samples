//
//	This program writes out a large file and then reads it back in
//	calculating the speed
//

using System;
using System.IO;

class ReadWrite
{
    
    public static void Main(String[] args)
    {
        double origTestSize;
        if (args.Length == 0)
        {
            Console.WriteLine ("Usage:");
            Console.WriteLine ("   LargeReadWrite numberKB");
            Console.WriteLine ();
            Console.WriteLine ("Example:");
            Console.WriteLine ("   LargeReadWrite 1");
            Console.WriteLine ();
            Console.WriteLine ("Continuing with numberKB=1");
            origTestSize = 1;
        }
        else  origTestSize = Double.Parse(args[0]);

        double testSize = origTestSize * 1024 ; 
        Console.WriteLine ("Running test with size {0} KB", origTestSize.ToString());
        Console.WriteLine ("This may take a while...");
        FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);	
        fs.SetLength(0);
        BinaryWriter w = new BinaryWriter(fs);
        BinaryReader r = new BinaryReader(fs);
        w.BaseStream.Seek(0,SeekOrigin.Begin);
        
        Console.Write  ("Writing file..");
        int beginWrite = Environment.TickCount;
        for (int i = 0; i < testSize; i++)
        {
            w.Write( (byte) 1);
        }
        Console.WriteLine ();
        fs.Flush();
        
        int endWrite = Environment.TickCount;
        Console.WriteLine ("For the Write...");	  
        Console.WriteLine ("Start Time: {0}", beginWrite.ToString());
        Console.WriteLine ("End Time: {0}", endWrite.ToString());
        Console.WriteLine ("Elapsed Time: {0} ms", endWrite-beginWrite); // the time span in ms
        double thruputWrite = ((double)origTestSize / (((double)endWrite-(double)beginWrite)) * 1000);
        Console.WriteLine ("Data Thruput: {0} mb/sec", thruputWrite);
        w.BaseStream.Seek(0,SeekOrigin.Begin);	//set the file pointer to the beginning
        int dummyInt;
        
        int beginRead = Environment.TickCount;	  
        for (int i = 0; i < testSize; i++)
        {
            dummyInt = r.ReadByte();
        }
        fs.Flush();
        int endRead = Environment.TickCount;
        
        Console.WriteLine ();
        Console.WriteLine ("For the Read...");
        Console.WriteLine ("Start Time: {0}", beginRead.ToString());
        Console.WriteLine ("End Time: {0}", endRead.ToString());
        Console.WriteLine ("Elapsed Time: {0}", endRead-beginRead); // the time span in ms
        double thruputRead = ((double)origTestSize / (((double)endRead-(double)beginRead)) * 1000);
        Console.WriteLine ("Data Thruput: {0} mb/sec", thruputRead);
        
        fs.Close();
        System.IO.File.Delete("data.bin");
        
        
        Console.WriteLine ("\r\nPress Return to exit.");
        Console.Read();
    }
}

using System;
using System.IO;

class ReadWrite
{
    
    public static void Main(String[] args)
    {
        FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate);	
        BinaryWriter w = new BinaryWriter(fs);
        BinaryReader r = new BinaryReader(fs);
        for (int i = 0; i < 11; i++)
        {
            w.Write( (int) i);
        }
        
        w.BaseStream.Seek(0,SeekOrigin.Begin);	//set the file pointer to the beginning
        for (int i = 0; i < 11; i++)
        {
            Console.WriteLine( r.ReadInt32() );
        }
        fs.Close();

		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    }
    
}

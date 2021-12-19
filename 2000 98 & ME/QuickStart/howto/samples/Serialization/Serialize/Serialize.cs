using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class SerializeTest{
    
    public static void Main(String[] args)
    {
        Console.WriteLine ("Create object graph");
        ArrayList l = new ArrayList();
        for (int x=0; x< 10; x++) {
            Console.WriteLine (x);
            l.Add (x);
        } // end for
        Console.Write ("Serializing object graph to disk..");
        Stream s = (new File ("foo.bin")).Open(FileMode.Create);
        BinaryFormatter b = new BinaryFormatter();
        b.Serialize(s, l);
        s.Close();	
        Console.WriteLine ("Complete.");
        
        Console.Write ("Deserializing object graph from disk..");
        Stream r = (new File ("foo.bin")).Open(FileMode.Open);
        BinaryFormatter c = new BinaryFormatter();
        ArrayList p = (ArrayList) c.Deserialize(r);
        Console.WriteLine ("Complete.");
        foreach (int i in p)
        {
            Console.WriteLine (i);
        }
		
        r.Close();
        
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
    } // end main
    
} // end class 

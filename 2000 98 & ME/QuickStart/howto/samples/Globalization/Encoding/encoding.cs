using System;
using System.IO;
using System.Text;
 
class CultureAndRegion
{
 
    public static void Main(String[] args) 
    {
        //Create a text file for this example     
        Console.WriteLine ("Creating text.txt");
        FileStream fs = new FileStream("text.txt", FileMode.OpenOrCreate);
     
        Console.WriteLine ("Writing UTF8");
        StreamWriter t = new StreamWriter (fs, Encoding.UTF8);
        t.Write("This is in UTF8");
        t.Flush();

        Console.WriteLine ("Writing Unicode");
        StreamWriter t2 = new StreamWriter (fs, Encoding.Unicode);
        t2.Write("This is in Unicode");
        t2.Flush();	
 
        Console.WriteLine ("Writing Ascii");
        StreamWriter t3 = new StreamWriter (fs, Encoding.ASCII);
        t3.Write("This is in ASCII");
        t3.Flush();

        fs.Close();
 }
}
 

// interop1.cs
// Build with "csc /R:QuartzTypeLib.dll interop1.cs"
using System;
class MainClass 
{ 
    /************************************************************ 
    Abstract: This method collects the filename of an AVI to show
    then creates an instance of the Quartz COM object.
    To show the AVI, the program calls RenderFile and Run on 
    IMediaControl. Quartz uses its own thread and window to display 
    the AVI.The main thread blocks on a ReadLine until the user presses
    Enter.
        Input Parameters: None
        Returns: int: Standard 32 bit process return code. 
    **************************************************************/ 
    public static void Main(string[] args) 
    { 
        // Check to see if the user passed in a filename 
        if (args.Length != 1) 
        { 
            DisplayUsage();
            return;
        } 
    
        string filename = args[0]; 
        if (filename.Equals("/?")) 
        { 
            DisplayUsage();
            return;
        }
    
        // Create instance of Quartz
        // (Calls CoCreateInstance(E436EBB3-524F-11CE-9F53-0020AF0BA770,
        // NULL, CLSCTX_ALL, IID_IUnknown, &graphManager).
        // Returns null on failure): 
        QuartzTypeLib.FilgraphManager graphManager = 
                    new QuartzTypeLib.FilgraphManager();

        // QueryInterface for the IMediaControl interface:
        QuartzTypeLib.IMediaControl mc =
                   (QuartzTypeLib.IMediaControl)graphManager;

        // Call some methods on a COM interface 
        // Pass in file to RenderFile method on COM object. 
        mc.RenderFile(filename);

        // Show file. 
        mc.Run();
    
        // Wait for completion.
        Console.WriteLine("Press Enter to continue."); 
        Console.ReadLine();
    }
    
    private static void DisplayUsage() 
    { 
        // User did not provide enough parameters. 
        // Display usage: 
        Console.WriteLine("VideoPlayer: Plays AVI files."); 
        Console.WriteLine("Usage: VIDEOPLAYER.EXE filename"); 
        Console.WriteLine("where filename is the full path and"); 
        Console.WriteLine("file name of the AVI to display."); 
    } 
}

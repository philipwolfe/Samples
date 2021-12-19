using System;
using System.Runtime.InteropServices;

[structlayout(LayoutKind.Sequential)]
public class LOGFONT { 
    public const int LF_FACESIZE = 32;
    public int lfHeight; 
    public int lfWidth; 
    public int lfEscapement; 
    public int lfOrientation; 
    public int lfWeight; 
    public byte lfItalic; 
    public byte lfUnderline; 
    public byte lfStrikeOut; 
    public byte lfCharSet; 
    public byte lfOutPrecision; 
    public byte lfClipPrecision; 
    public byte lfQuality; 
    public byte lfPitchAndFamily;
    [marshal(UnmanagedType.ByValTStr, Size=LF_FACESIZE)]
		public string lfFaceName; 
}


class C
{
	[dllimport("gdi32.dll", CharSet=CharSet.Auto)]
	public static extern int CreateFontIndirect(
			[in, marshal(UnmanagedType.LPStruct)]
			LOGFONT lplf   // characteristics
			);

	public static void Main() {
		LOGFONT lf = new LOGFONT();
		lf.lfHeight = 9;
		lf.lfFaceName = "Arial";
		int i = CreateFontIndirect(lf);
		Console.WriteLine("Font Created, handle = {0}", int.Format(i, "X"));
		
		Console.WriteLine ("\r\nPress Return to exit.");
		Console.Read();
	}
}



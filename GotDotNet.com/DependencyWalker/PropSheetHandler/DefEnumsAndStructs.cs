using System;
using System.Runtime.InteropServices;

namespace Microsoft.PDC01Demo.PropSheetHandler
{
	/// <summary>
	/// Definitions for enumerations and structures.
	/// </summary>
	/// 

	public enum CLIPFORMAT : uint
	{
		TEXT			= 1,
		BITMAP			= 2,
		METAFILEPICT	= 3,
		SYLK			= 4,
		DIF				= 5,
		TIFF			= 6,
		OEMTEXT			= 7,
		DIB				= 8,
		PALETTE			= 9,
		PENDATA			= 10,
		RIFF			= 11,
		WAVE			= 12,
		UNICODETEXT		= 13,
		ENHMETAFILE		= 14,
		HDROP			= 15,
		LOCALE			= 16,
		MAX				= 17,

		OWNERDISPLAY	= 0x0080,
		DSPTEXT			= 0x0081,
		DSPBITMAP		= 0x0082,
		DSPMETAFILEPICT	= 0x0083,
		DSPENHMETAFILE	= 0x008E,

		PRIVATEFIRST	= 0x0200,
		PRIVATELAST		= 0x02FF,

		GDIOBJFIRST		= 0x0300,
		GDIOBJLAST		= 0x03FF
	}

	public enum DVASPECT : uint
	{
		CONTENT		= 1,
		THUMBNAIL	= 2,
		ICON		= 4,
		DOCPRINT	= 8
	}

	public enum TYMED : uint
	{
		HGLOBAL		= 1,
		FILE		= 2,
		ISTREAM		= 4,
		ISTORAGE	= 8,
		GDI			= 16,
		MFPICT		= 32,
		ENHMF		= 64,
		NULL		= 0
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct FORMATETC
	{
		public CLIPFORMAT	cfFormat;
		public IntPtr		ptd;
		public DVASPECT		dwAspect;
		public int			lindex;
		public TYMED		tymed;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct STGMEDIUM
	{
		public uint		tymed;
		public IntPtr	hGlobal;
		public IntPtr	pUnkForRelease;
	}

	public delegate bool DialogProc(IntPtr hwndDlg, WM uMsg, IntPtr wParam, IntPtr lParam); 
	public delegate uint Callback(IntPtr hwnd, PSPCB uMsg, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential)]
	public struct PROPSHEETPAGE
	{  
		public int			dwSize; 
		public PSP			dwFlags; 
		public IntPtr		hInstance; 
		public IntPtr		pResource;
		public IntPtr		hIcon;
		public String		pszTitle; 
		public DialogProc	pfnDlgProc;
		public IntPtr		lParam; 

		public Callback pfnCallback;

		public int			pcRefParent; 
		public String		pszHeaderTitle;
		public String		pszHeaderSubTitle;
	}

	public enum PSPCB : uint
	{
		ADDREF  = 0,
		RELEASE = 1,
		CREATE  = 2
	}

	// Constants for Window Messages
	public enum WM : uint
	{
		INITDIALOG	= 0x0110,
		COMMAND		= 0x0111,
		DESTROY		= 0x0002,
		NOTIFY		= 0x004E,
		PAINT		= 0x000F
	}

	[StructLayout(LayoutKind.Sequential, Pack=2, CharSet=CharSet.Auto)]
	internal struct DLGTEMPLATE
	{
		internal DS		style; 
		internal uint	extendedStyle; 
		internal ushort	cdit; 
		internal short	x; 
		internal short	y; 
		internal short	cx; 
		internal short	cy;
		internal short	menuResource;
		internal short	windowClass;
		internal short	titleArray;
		internal short	fontPointSize;
		[MarshalAs(UnmanagedType.LPWStr)]
		internal String	fontTypeface;
	}

	public enum PSP : uint
	{
		DEFAULT				= 0x00000000,
		DLGINDIRECT			= 0x00000001,
		USEHICON			= 0x00000002,
		USEICONID			= 0x00000004,
		USETITLE			= 0x00000008,
		RTLREADING			= 0x00000010,

		HASHELP				= 0x00000020,
		USEREFPARENT		= 0x00000040,
		USECALLBACK			= 0x00000080,
		PREMATURE			= 0x00000400,

		HIDEHEADER			= 0x00000800,
		USEHEADERTITLE		= 0x00001000,
		USEHEADERSUBTITLE	= 0x00002000
	}

	// Used in building dialog templates
	internal enum DS : uint
	{
		SETFONT		= 0x40,
		FIXEDSYS	= 0x0008
	}
}







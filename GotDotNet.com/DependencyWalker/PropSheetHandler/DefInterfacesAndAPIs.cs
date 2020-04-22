using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.PDC01Demo.PropSheetHandler
{
	/// <summary>
	/// Definitions for COM interfaces and API functions.
	/// </summary>

	[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
	GuidAttribute("0000010e-0000-0000-C000-000000000046")]
	public interface IDataObject
	{
		void GetData(ref FORMATETC a, ref STGMEDIUM b);
		void GetDataHere(int a, ref STGMEDIUM b);
		void QueryGetData(int a);
		void GetCanonicalFormatEtc(int a, ref int b);
		void SetData(int a, int b, int c);
		void EnumFormatEtc(uint a, ref Object b);
		void DAdvise(int a, uint b, Object c, ref uint d);
		void DUnadvise(uint a);
		void EnumDAdvise(ref Object a);
	}

	[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
	GuidAttribute("000214e8-0000-0000-c000-000000000046")]
	public interface IShellExtInit
	{
		void Initialize (IntPtr /*LPCITEMIDLIST*/ pidlFolder, IDataObject /*LPDATAOBJECT*/ lpdobj, uint /*HKEY*/ hKeyProgID);
	}

	[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
	GuidAttribute("000214e9-0000-0000-c000-000000000046")]
	public interface IShellPropSheetExt
	{
		void AddPages(IntPtr /*LPFNADDPROPSHEETPAGE*/ lpfnAddPage, IntPtr /*LPARAM*/ lParam);
		void ReplacePage(uint uPageID, IntPtr /*LPFNADDPROPSHEETPAGE*/ lpfnReplacePage, IntPtr /*LPARAM*/ lParam);
	}

	public class APIWrapper
	{
		[DllImport("comctl32.dll", EntryPoint="CreatePropertySheetPage")]
		private static extern IntPtr CreatePropertySheetPage_(ref PROPSHEETPAGE psp);

		public static IntPtr CreatePropertySheetPage(ref PROPSHEETPAGE psp) 
		{
			IntPtr hPage = APIWrapper.CreatePropertySheetPage_(ref psp);
			if(hPage == IntPtr.Zero) throw new Exception("CreatePropertySheetPage failed");
			return hPage;
		}

		[DllImport("user32")]
		public static extern int MessageBox(int hWnd, string text, string caption, int type);
		[DllImport("shell32")]
		public static extern uint DragQueryFile(IntPtr hDrop,uint iFile, StringBuilder buffer, int cch);
		[DllImport("ole32")]
		public static extern void ReleaseStgMedium(ref STGMEDIUM pmedium);

		// Wrapper needs to be on the path
		// Calls an unmanaged function using fptr
		[DllImport("Wrapper.dll", EntryPoint="CallCallback")]
		private static extern int CallCallback_(IntPtr lpfnAddPage, IntPtr hProp, IntPtr lParam);

		public static int CallCallback(IntPtr lpfnAddPage, IntPtr hProp, IntPtr lParam) 
		{
			int res = APIWrapper.CallCallback_(lpfnAddPage, hProp, lParam);
			if(res == 0) throw new Exception("Callback failed");
			return res;
		}
	}
}







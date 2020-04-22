using System;
using System.IO; 
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Microsoft.PDC01Demo.PropSheetHandler
{

/// <summary>
/// Adds a property page for DLL and EXE files that shows list of directly 
/// referenced assemblies. For EXE files, shows additional list of 
/// assemblies that are actually loaded (depends on installed policies 
/// and configuration files).
/// </summary>

[Guid("06A9E9C3-1A0A-4a99-BAF1-E46C1FED06F8"), ComVisible(true)]
public class PSHandler : IShellExtInit, IShellPropSheetExt
{
	private const string guid = "{06A9E9C3-1A0A-4a99-BAF1-E46C1FED06F8}";
	private string selectedFile = null;	// full name of the selected file

	public PSHandler()
	{
	}

	// Get data about file that user wants to see properties for
	void IShellExtInit.Initialize(IntPtr pidlFolder, IDataObject lpdobj, uint hKeyProgID)
	{
		selectedFile = GetFullFileName(lpdobj);
	}

	// Add property page for this file
	void IShellPropSheetExt.AddPages(IntPtr lpfnAddPage, IntPtr lParam)
	{
		try
		{
			PROPSHEETPAGE psp = new PROPSHEETPAGE();
			PropPage ppHandler = new PropPageDlls(selectedFile);

			psp.dwSize = Marshal.SizeOf(typeof(PROPSHEETPAGE));
			psp.hInstance = IntPtr.Zero;	//!!! MSDN says this should be non NULL
			psp.dwFlags = PSP.DEFAULT | PSP.USECALLBACK | PSP.DLGINDIRECT;

			// We're using just a plain resource file as a "placeholder" for our 
			// .NET Framework classes placed controls
			psp.pResource = ppHandler.GetDialogTemplate();

			psp.lParam = IntPtr.Zero;
			psp.pszTitle = ppHandler.Title();
			psp.hIcon = ppHandler.Icon();

			// Our delegate will be called when window message arrives
			psp.pfnDlgProc = ppHandler.DialogProc;
			psp.pfnCallback = ppHandler.Callback;

			// See if our property page uses a icon
			if(psp.hIcon != IntPtr.Zero)
				psp.dwFlags |= PSP.USEHICON;     
			// See if our property page uses a title
			if(psp.pszTitle != null)
				psp.dwFlags |= PSP.USETITLE;

			IntPtr hPage = APIWrapper.CreatePropertySheetPage(ref psp);
			APIWrapper.CallCallback(lpfnAddPage, hPage, lParam);

			// We'll add reference manualy only if there is no exceptions
			ppHandler.KeepAlive();
		}
		catch(Exception)
		{
			// APIWrapper.MessageBox(0, e.Message, "", 0); //!!!
			// This method needs to return NOERROR always
		}
	}

	// Not called
	void IShellPropSheetExt.ReplacePage(uint uPageID, IntPtr lpfnReplacePage, IntPtr lParam)
	{
	}

	private String GetFullFileName(IDataObject lpdobj)
	{
		IDataObject dataObject = lpdobj;

		FORMATETC fmt = new FORMATETC();
		fmt.cfFormat = CLIPFORMAT.HDROP;
		fmt.ptd		 = IntPtr.Zero;
		fmt.dwAspect = DVASPECT.CONTENT;
		fmt.lindex	 = -1;
		fmt.tymed	 = TYMED.HGLOBAL;

		STGMEDIUM medium = new STGMEDIUM();
		dataObject.GetData(ref fmt, ref medium);

		StringBuilder sb = new StringBuilder(1024);
		APIWrapper.DragQueryFile(medium.hGlobal, 0, sb, sb.Capacity + 1);
		APIWrapper.ReleaseStgMedium(ref medium); 

		return sb.ToString();
	}

	// Add keys needed to find a new property page handler
	[System.Runtime.InteropServices.ComRegisterFunctionAttribute()]
	static void RegisterServer(String str1)
	{
		try
		{
			RegistryKey root = Registry.LocalMachine;
			RegistryKey rk;

			// For WINNT set me as an approved shellex
			rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
			rk.SetValue(guid, "PDCDemo shell extension");
			rk.Close();
			root.Close();

			root = Registry.ClassesRoot;
			string subKey = "dllfile\\Shellex\\PropertySheetHandlers\\PDCDemo";	
			
			rk = root.CreateSubKey(subKey);
			rk.SetValue("", guid);
			rk.Close();

			subKey = "exefile\\Shellex\\PropertySheetHandlers\\PDCDemo";
			rk = root.CreateSubKey(subKey);
			rk.SetValue("", guid);

			rk.Close();
			root.Close();

		}
		catch(Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	// Remove keys added during registration
	[System.Runtime.InteropServices.ComUnregisterFunctionAttribute()]
	static void UnregisterServer(String str1)
	{
		try
		{
			RegistryKey root = Registry.LocalMachine;

			// For Winnt unset me as an approved shellex
			RegistryKey rk = root.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved", true);
			rk.DeleteValue(guid);
			rk.Close();
			root.Close();

			root = Registry.ClassesRoot;
			string subKey = "dllfile\\Shellex\\PropertySheetHandlers\\PDCDemo";
			root.DeleteSubKey(subKey);

			subKey = "exefile\\Shellex\\PropertySheetHandlers\\PDCDemo";
			root.DeleteSubKey(subKey);
			root.Close();
		}
		catch(Exception e)
		{
			System.Console.WriteLine(e.ToString());
		}
	}
}
}// namespace Microsoft.PDC01Demo.PropSheetHandler


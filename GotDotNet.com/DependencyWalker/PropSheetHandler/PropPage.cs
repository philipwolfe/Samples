using System;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace Microsoft.PDC01Demo.PropSheetHandler
{
/// <summary>
/// This file defines the base class that all property sheet pages
/// must derive from.
/// </summary>

public class PropPage
{
    protected String		title;			// The title of the property page
    protected IntPtr		hWnd;			// The window handle the page will be inserted on
    protected IntPtr		hIcon;			// Handle of the icon we should display
    protected DialogProc	dlgProc;		// The property page's window procedure  
    protected Callback		callback;		// The property page's callback procedure              
    protected IntPtr		dlgTemplate;	// The dialog template for this property page
	protected String		fullFileName;	// The file the property page represents

	protected UserControl	parent;			// The control we're going to parent everything too

	// Stop GC from collecting me until RELEASE message arrives
	static ArrayList arrKeepAlive = new ArrayList(); 

    public PropPage(String fileName)
    {
        title = ".NET References";
        hWnd = IntPtr.Zero;
        hIcon = IntPtr.Zero;
		dlgTemplate = IntPtr.Zero;
        fullFileName = fileName;

        dlgProc = new DialogProc(PropPageDialogProc);
		callback = new Callback(PropPageCallback);
    }

    //-------------------------------------------------
    // We need to tell the Win32 side of things to create a
    // empty dialog. The best way to do this is to give it a blank
    // dialog template. We'll create one here.
    //-------------------------------------------------
    public IntPtr GetDialogTemplate()
    {
        // If we're already created a template, don't bother doing it again
        if(dlgTemplate != IntPtr.Zero)
            return dlgTemplate;

        DLGTEMPLATE dlg = new DLGTEMPLATE();

        dlg.cx = 175;
        dlg.cy = 150;

        // Put in a the standard font 
        dlg.style = DS.SETFONT;
        dlg.fontPointSize = 8;
        byte[] bFontFace = StringToByteArray("MS Shell Dlg");

        
        int nSize = Marshal.SizeOf(typeof(DLGTEMPLATE));
        dlgTemplate = Marshal.AllocHGlobal(nSize + bFontFace.Length);
        Marshal.StructureToPtr(dlg, dlgTemplate, false);
        
        // Now copy the string into the IntPtr
        Marshal.Copy(bFontFace, 0, (IntPtr)((Int64)dlgTemplate + nSize), bFontFace.Length);
        return dlgTemplate;
    }

	//-------------------------------------------------
	//-------------------------------------------------
    public IntPtr WndHandle
    {
        get
        {
            return hWnd;
        }
    }

    //-------------------------------------------------
    // Create the Windows Forms controls and parent them to 
	// the passed in hWnd.
    //-------------------------------------------------
    public virtual void InsertPropSheetPageControls(IntPtr hWnd)
    {
    }

    //-------------------------------------------------
	//-------------------------------------------------
    public String Title()
    {
        return title;
    }

    //-------------------------------------------------
    // Return the icon that will be 
    // displayed in the "tab" of the property page. 
    //-------------------------------------------------
    public virtual IntPtr Icon()
    {
        return IntPtr.Zero;
    }

    //-------------------------------------------------
	//-------------------------------------------------
    public DialogProc DialogProc
    {
        get
        {
            return dlgProc;
        }
    }

	//-------------------------------------------------
	//-------------------------------------------------
	public Callback Callback
	{
		get
		{
			return callback;
		}
	}

    //-------------------------------------------------
    // Handle all messages coming sent to the property page
    //-------------------------------------------------
    public bool PropPageDialogProc(IntPtr hwndDlg, WM msg, IntPtr wParam, IntPtr lParam)
    {
        switch (msg)
        {
            case WM.INITDIALOG:
                InsertPropSheetPageControls(hwndDlg);
                break;
			case WM.PAINT:
				// WinForms has problems repainting managed controls on an unmanaged
				// form. We'll intercept every paint message and force all the 
				// managed controls to repaint themselves. This will create a little
				// flicker, but it's better (for now) than having controls not show
				// up at all.
				if(parent != null)
					parent.Refresh();
				return false;
            default:
                // We'll let the default windows message handler handle the rest of
                // the messages
                return false;
        }
        return true;
    }

	//-------------------------------------------------
	// Handle Page Initialization and destruction 
	//-------------------------------------------------
	public uint PropPageCallback(IntPtr hwnd, PSPCB uMsg, IntPtr lParam)
	{
		switch ((PSPCB)uMsg)
		{
			case PSPCB.ADDREF:
				break;
			case PSPCB.RELEASE:
				arrKeepAlive.Remove(this);
				break;
			case PSPCB.CREATE:
				return 1;
		}
		return 0;
	}

	//-------------------------------------------------
	// Add this object in the list of handlers that are
	// currently active. We'll remove it when PSPCB.RELEASE
	// arrives.
	//-------------------------------------------------
	public void KeepAlive()
	{
		arrKeepAlive.Add(this);
	}


	//-------------------------------------------------
	//-------------------------------------------------
    protected byte[] StringToByteArray(String input)
    {
        int i;
        int iStrLength = input.Length;

        // We'll treat all our strings as unicode, 
        // each character must be 2 bytes long
        byte[] output = new byte[(iStrLength + 1)*2];
        char[] cinput = input.ToCharArray();

        int j=0;
        
        for(i=0; i<iStrLength; i++)
        {
            output[j++] = (byte)cinput[i];
            output[j++] = 0;
        }

        output[j++]=0;
        // For the double null
        output[j]=0;
        
        return output;
     }

    //-------------------------------------------------
    // We need to import the Win32 API calls used to deal with
    // window messaging.
    //-------------------------------------------------
    [DllImport("user32.dll")]
    public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

}// PropPage
}// namespace Microsoft.PDC01Demo.PropSheetHandler



//-------------------------------------------------------------
// CPropPage.cs
//
// This file defines the base class that all property sheet pages
// must derive from.
//-------------------------------------------------------------

// the method to use for mapping between pixels and dialog units
#define METHOD4


using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Ironring.Management.MMC
{

    /// <summary>
    /// Wrapper for the MMC Property pages.  Requirs a UserControl type provided 
    /// to implement the PropertyPage behavior
    /// </summary>
    public class CPropPage
    {

        /// <summary>
        /// the type of control to activate
        /// </summary>
        protected Type m_ControlType;     

        /// <summary>
        /// the instance of the control once activated 
        /// </summary>
        protected UserControl m_Control = null;        

        /// <summary>
        /// Title to display in property sheet tab 
        /// </summary>
        protected string m_sTitle;         

        /// <summary>
        /// Parent window - the actual Win32 property page handle.
        /// The UserControl will be an immediate child of this window
        /// </summary>
        protected IntPtr m_hWnd = IntPtr.Zero;            
        /// <summary>
        /// Icon to display
        /// </summary>
        protected Icon m_Icon = null;            

        /// <summary>
        /// WindProc for the property page
        /// </summary>
        protected DialogProc m_dlgProc;

        /// <summary>
        /// The node the property page refers to
        /// </summary>
        protected BaseNode m_Node = null;    
 
        /// <summary>
        /// The dialog template for this property page
        /// </summary>
        protected IntPtr m_pDlgTemplate;


        ///////////////////////////////////////////////////////////////
        ///
        /// Implementation
        ///
 
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="title"></param>
        public CPropPage(string title)
        {
            m_sTitle = title;
            m_dlgProc = new DialogProc(PropPageDialogProc);
        }

        /// <summary>
        /// Set the type of User Control to serve as the property page guts
        /// </summary>
        public Type ControlType
        {
            get { return m_ControlType; } 
            set { m_ControlType = value; }
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get { return m_sTitle; }
            set { m_sTitle = value; } 
        }

        /// <summary>
        /// Icon
        /// </summary>
        public Icon Icon
        {
            get { return m_Icon; }
            set { m_Icon = value; } 
        }

        /// <summary>
        /// Create the property page resource and return an IntPtr
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IntPtr Create(BaseNode node)
        {
            m_Node = node;
               
            PROPSHEETPAGE psp;

            psp = new PROPSHEETPAGE();
            psp.dwSize = 48;
            psp.hInstance = IntPtr.Zero;

            //        m_hIcon = node.IconHandle;

            psp.dwFlags = (uint)PSP.DEFAULT | (uint)PSP.DLGINDIRECT;  // PSP.USECALLBACK | 

            // We're using just a plain resource file as a "placeholder" for our .NET Framework Classes
            // placed controls
            psp.pResource = GetDialogTemplate();
            psp.lParam = IntPtr.Zero;  
            psp.pfnDlgProc = m_dlgProc;

            // See if our property page uses a icon
            if (Icon != null)
            {
                psp.hIcon = Icon.Handle;
                psp.dwFlags |= (uint)PSP.USEHICON;
            }
                        
            // See if our property page uses a title
            if (Title != null)
            {
                psp.pszTitle = Title;
                psp.dwFlags |= (uint)PSP.USETITLE;
            }

            return CreatePropertySheetPage(ref psp);
        }

        /// <summary>
        /// Create a DIALOGTEMPLATE resource to give to MMC.  It must be initialized 
        /// to the correct dimensions to host the UserControl.
        /// </summary>
        /// <returns></returns>
        protected IntPtr GetDialogTemplate()
        {
            // If we're already created a template, don't bother doing it again
            if (m_pDlgTemplate != IntPtr.Zero)
                return m_pDlgTemplate;
        
            DLGTEMPLATE dlg = new DLGTEMPLATE();

            // try to synth the template from the user control properties 
            // so the propertysheet owned by MMC can size itself properly

            Font fnt = MainControl.Font;
            
            /////////////////////////////////////////////////////////////////
            // method #1 use a string to compute some avaerages 

#if METHOD1

            UserControl userControl = (UserControl)Activator.CreateInstance(ControlType);
            Graphics g = userControl.CreateGraphics();


            const string baseline = " ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                                    + "abcdefghijklmnopqrstuvwxyz"
                                    + "0123456789"
                                    + "~+=`][{})(*&^%$#@!_-|"
                                    + @"\""";

            const string baseline = " abcdefghijklmnopqrstuvwxyz";

            SizeF sz = g.MeasureString(baseline, fnt);
            int OffsetX = (int)(sz.Width / baseline.Length + 1);
            int OffsetY = (int)(fnt.GetHeight(g) + 1);

            // devine the prop page height and width in dlg units
            // based on the user control's dimensions

            int fx = userControl.Width;
            int fy = userControl.Height;

            dlg.cx = (short)(fx * 4 / OffsetX);
            dlg.cy = (short)(fy * 8 / OffsetY);

            userControl.Dispose();

#endif
            /////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////
            // method #2 using text metrics
    #if METHOD2

            UserControl userControl = (UserControl)Activator.CreateInstance(ControlType);
            Graphics g = userControl.CreateGraphics();

            TEXTMETRIC tm = new TEXTMETRIC();
            GetTextMetrics(g.GetHdc(), ref tm);
            
            float OffsetX = tm.tmAveCharWidth;
            float OffsetY = tm.tmHeight;

            // devine the prop page height and width in dlg units
            // based on the user control's dimensions

            float fx = (float )userControl.Width;
            float fy = (float )userControl.Height;

            dlg.cx = (short)(fx * 4 / OffsetX);
            dlg.cy = (short)(fy * 8 / OffsetY);


            userControl.Dispose();

    #endif    
            /////////////////////////////////////////////////////////////////

    #if METHOD3
            
            /////////////////////////////////////////////////////////////////
            // method #3 using system wide dialog units

            int nBaseUnits = GetDialogBaseUnits();

            int OffsetX = 0xFFFF & nBaseUnits;
            int OffsetY = nBaseUnits >> 16;

            // devine the prop page height and width in dlg units
            // based on the user control's dimensions
            dlg.cx = (short)(MainControl.Width * 4 / OffsetX);
            dlg.cy = (short)(MainControl.Height * 8 / OffsetY);

            /////////////////////////////////////////////////////////////////
    #endif

    #if METHOD4
            /////////////////////////////////////////////////////////////////
            // method #4 A variation on #2 with hard coded magic numbers
            // I got these from experiment - this really freaks me out
            // I need to understand this better to defend it but it 
            // works for now (I hate that).
            
            int OffsetX = 6;
            int OffsetY = 13;

            dlg.cx = (short)(MainControl.Width * 4 / OffsetX);
            dlg.cy = (short)(MainControl.Height * 8 / OffsetY);

            /////////////////////////////////////////////////////////////////
    #endif

            // Put in a the standard font 
            dlg.style = (uint)DS.SETFONT;
            dlg.wFontPointSize = (short)fnt.Size;
 
            // write the font name into the buffer
            MemoryStream stream = new MemoryStream(64);
            Encoding ue = new UnicodeEncoding();
            BinaryWriter writer = new BinaryWriter(stream, ue);
            writer.Write(fnt.Name);

            int nSize = Marshal.SizeOf(typeof(DLGTEMPLATE));
            m_pDlgTemplate = Marshal.AllocHGlobal(nSize + (int)stream.Length);
            Marshal.StructureToPtr(dlg, m_pDlgTemplate, false);
            
            // Now copy the string into the IntPtr
            Marshal.Copy(stream.GetBuffer(), 0, (IntPtr)((Int64)m_pDlgTemplate + nSize), (int)stream.Length);
            return m_pDlgTemplate;
        }

        /// <summary>
        /// The WindProc for the PropertyPage handles avtivation and PropertySheet 
        /// Messeges but mostly defers to the UserControl.
        /// </summary>
        /// <param name="hwndDlg"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public bool PropPageDialogProc(IntPtr hwndDlg, uint msg, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                WM m = (WM)msg;
                //System.Diagnostics.Debug.WriteLine("[" + hwndDlg.ToString() + "]" + " PP_MSG: " + m.ToString() + " wParam: " + wParam.ToString() + " lParam: " + lParam.ToString());
                switch (m)
                {
                    case WM.INITDIALOG:
                    {
                        m_hWnd = hwndDlg;

                        // Set up our parent managed control first
                        SetParent(MainControl.Handle, m_hWnd);

                        return true;
                    }
                    case WM.DESTROY:
                    {
                        // tell MMC that we're done with the property sheet 

                        //                if (m_Node != null)
                        //              {
                        //                m_Node.FreePropertySheetNotifyHandle();
                        //              return true;
                        //         }
                        // If we don't belong to a specific node, then we can't handle
                        // this message
                        return false;

                    }
                    case WM.NOTIFY:
                    {

                        // lParam really is a pointer to a NMHDR structure....
                        NMHDR nm = new NMHDR();
                        nm = (NMHDR)Marshal.PtrToStructure(lParam, nm.GetType());

                        // We're about to lose focus of this property page. Make sure the data
                        // is valid before we allow that
                        if (nm.code == PSN.KILLACTIVE)
                        {
                            if (!ValidateData())
                            {
                                // The data on the page had errors
                                SetWindowLong(hwndDlg, 0, 1);
                            }
                            return true;
                        }
                        
                            // If we're being told to apply changes made in the property pages....
                        else if (nm.code == PSN.APPLY)
                        {

                            // First, call a validate on the current page
                            if (ValidateData())
                                // 'Apply' this data
                                ApplyData();
                                // There were errors on this page...
                            else
                                // Set the appropriate return code here.
                                SetWindowLong(hwndDlg, 0, (uint)PSNRET.INVALID_NOCHANGEPAGE);
                            return true;
                        }
                        break;
                    }
                    default:
                    {
                        // We'll let the default windows message handler handle the rest of
                        // the messages
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("PropPage Proc Exception - " + e.ToString());
                throw e;
            }

            return false;
        }

        /// <summary>
        /// This function will turn on the apply button by sending a message to the parent window
        /// </summary>
        public void ActivateApply()
        {
            SendMessage(GetParent(m_hWnd), (uint)PSM.CHANGED, (uint)m_hWnd, 0);
        }


        /// <summary>
        /// This function gets called when someone clicks OK, APPLY,
        /// Finish, Next, or tries to move to a different property
        /// page. It should return 'true' if everything is ok,
        /// or false if things are not ok
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateData()
        {
            return MainControl.Validate();
        }

        /// <summary>
        /// This function gets called when somebody clicks 
        /// OK, APPLY, or FINISH on our property page/wizard.
        /// It should return true if everything is ok, or false
        /// if things are not ok.
        /// </summary>
        /// <returns></returns>
        public virtual bool ApplyData()
        {
            return true;
        }

        
        /// <summary>
        /// Return our parent HWND
        /// </summary>
        protected IntPtr hWnd
        {
            get { return m_hWnd; }
        }
         
        /// <summary>
        /// Called to lazy create the user control for this page
        /// </summary>
        protected UserControl MainControl 
        {
            get 
            { 
                try
                {
					if (m_Control == null)
					{
						m_Control = (UserControl)Activator.CreateInstance(ControlType);
						// check if the usercontrol implements ISnapinLink
						// if so provide a back reference to the base snapin.
						ISnapinLink snapinLink = m_Control as ISnapinLink;
						if(snapinLink != null)
							snapinLink.ContextNode = m_Node;
					}
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("PropertyPage Exception - " + e.ToString());
                    throw new SnapinException ("Failed to create user control", e);
                }
                return m_Control;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////
        /// P/Invoke methods to get at Win32 
        /// 
            
        /// <summary>
        /// Used to place the Usercontrol in the Windows heirarchy - under the 
        /// MMC Property page window
        /// </summary>
        [DllImport("user32.dll")]
        protected static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>
        /// Used to get the property sheet window
        /// </summary>
        [DllImport("user32.dll")]
        protected static extern IntPtr GetParent(IntPtr hWnd);  

        /// <summary>
        /// Used to communicate with the property sheet window
        /// </summary>
        [DllImport("user32.dll")]
        protected static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        /// <summary>
        /// Used to communicate with the property sheet
        /// </summary>
        [DllImport("user32.dll")]
        protected static extern int SetWindowLong(IntPtr hWnd, uint a, uint b);

        /// <summary>
        /// The underlying Win32 API to create a property page
        /// </summary>
        [DllImport("comctl32.dll")]
        protected static extern IntPtr CreatePropertySheetPage(ref PROPSHEETPAGE psp);

        /// <summary>
        /// Used in one scheme to dimension the in memory DIALOGTEMPLATE resource
        /// </summary>
        [DllImport("user32.dll")]
        protected static extern int GetDialogBaseUnits();

        /// <summary>
        /// Used in one scheme to dimension the in memory DIALOGTEMPLATE resource
        /// </summary>
        [DllImport("Gdi32.dll")]
        protected static extern int GetTextMetrics(IntPtr hDC, ref TEXTMETRIC lptm);
    }
}


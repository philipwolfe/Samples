using System;
using System.Runtime.InteropServices;

////////////////////////////////////////////////////////////////////////////////////
/// 
/// Interop Definitions
/// 
/// NOTE: these are hand rolled definition of MMC interfaces and related interfaces
/// structures, enums and constants.  They do not always model the underlying 
/// unmanaged object with 100% fidelity but are good enough for use by MMC snapins
/// As an Example the IDataObject implementation is slimmed down since we don't
/// need most of the services.
/// 
/// Several of these interfaces were gleaned from the MMC GotDotNet sample.
/// 


namespace Ironring.Management.MMC
{

    ////////////////////////////////////////////////////////////////////////////////////
    /// 
    /// Snapin Implemented Interfaces
    /// 

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("955AB28A-5218-11D0-A985-00C04FD8D565")
    ]
    public interface IComponentData
    {
        void Initialize([MarshalAs(UnmanagedType.Interface)] Object pUnknown);
        void CreateComponent(out IComponent ppComponent);
        [PreserveSig()]
        int Notify(IDataObject lpDataObject, uint aevent, IntPtr arg, IntPtr param);
        void Destroy();
        void QueryDataObject(int cookie, uint type, out IDataObject ppDataObject);
        void GetDisplayInfo(ref SCOPEDATAITEM ResultDataItem);
        [PreserveSig()]
        int CompareObjects(IDataObject lpDataObjectA, IDataObject lpDataObjectB);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("43136EB2-D36C-11CF-ADBC-00AA00A80033")
    ]
    public interface IComponent
    {
        void Initialize([MarshalAs(UnmanagedType.Interface)]Object lpConsole);
        [PreserveSig()]
        int Notify(IntPtr lpDataObject, uint aevent, IntPtr arg, IntPtr param);
        void Destroy(int cookie);
        void QueryDataObject(int cookie, uint type, out IDataObject ppDataObject);
        [PreserveSig()]
        int GetResultViewType(int cookie, out IntPtr ppViewType, out int pViewOptions);
        void GetDisplayInfo(ref RESULTDATAITEM ResultDataItem);
        [PreserveSig()]
        int CompareObjects(IDataObject lpDataObjectA, IDataObject lpDataObjectB);
    }

    [   
        ComImport,
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("1245208C-A151-11D0-A7D7-00C04FD909DD")
    ]
    public interface ISnapinAbout
    {
        void GetSnapinDescription(out IntPtr lpDescription);
        void GetProvider(out IntPtr pName);
        void GetSnapinVersion(out IntPtr lpVersion);
        void GetSnapinImage(out IntPtr hAppIcon);
        void GetStaticFolderImage(out IntPtr hSmallImage, out IntPtr hSmallImageOpen, out IntPtr hLargeImage, out uint cMask);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("0000010e-0000-0000-C000-000000000046")
    ]
    public interface IDataObject
    {
        [PreserveSig()]
        int GetData(ref FORMATETC pFormatEtc, ref STGMEDIUM b);
        void GetDataHere(ref FORMATETC pFormatEtc, ref STGMEDIUM b);
        [PreserveSig()]
        int QueryGetData(IntPtr a);
        [PreserveSig()]
        int GetCanonicalFormatEtc(IntPtr a, IntPtr b);
        [PreserveSig()]
        int SetData(IntPtr a, IntPtr b, int c);
        [PreserveSig()]
        int EnumFormatEtc(uint a, IntPtr b);
        [PreserveSig()]
        int DAdvise(IntPtr a, uint b, IntPtr c, ref uint d);
        [PreserveSig()]
        int DUnadvise(uint a);
        [PreserveSig()]
        int EnumDAdvise(IntPtr a);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("4861A010-20F9-11d2-A510-00C04FB6DD2C")
    ]
    public interface ISnapinHelp2
    {
        [PreserveSig()]
        int GetHelpTopic(out IntPtr lpCompiledHelpFile);
        [PreserveSig()]
        int GetLinkedTopics(out IntPtr lpCompiledHelpFiles);
    }


    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("cc593830-b926-11d1-8063-0000f875a9ce")
    ]
    public interface IDisplayHelp
    {
        void ShowTopic([MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] String pszHelpTopic);
    }


    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("4F3B7A4F-CFAC-11CF-B8E3-00C04FD8D5B0")
    ]
    public interface IExtendContextMenu
    {
        void AddMenuItems(IDataObject piDataObject, IContextMenuCallback piCallback, ref int pInsertionAllowed);
        void Command(int lCommandID, IDataObject piDataObject);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("49506520-6F40-11D0-A98B-00C04FD8D565")
    ]
    public interface IExtendControlbar
    {
        void SetControlbar(IControlbar pControlbar);
        [PreserveSig()]
        int ControlbarNotify(uint aevent, IntPtr arg, IntPtr param);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("85DE64DC-EF21-11cf-A285-00C04FD8DBE6")
    ]
    public interface IExtendPropertySheet
    {
        [PreserveSig()]
        int CreatePropertyPages(IPropertySheetCallback lpProvider, IntPtr handle, IDataObject lpIDataObject);
        [PreserveSig()]
        int QueryPagesFor(IDataObject lpDataObject);
    }


    ////////////////////////////////////////////////////////////////////////////////////
    /// 
    /// MMC Implemented Interfaces
    /// 


    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("85DE64DE-EF21-11cf-A285-00C04FD8DBE6")
    ]
    public interface IPropertySheetProvider
    {
        void CreatePropertySheet([MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] String title, int type, int cookie, IDataObject pIDataObjectm, uint dwOptions);
        void FindPropertySheet(int cookie, IComponent lpComponent, IDataObject lpDataObject);
        void AddPrimaryPages([MarshalAs(UnmanagedType.Interface)]Object lpUnknown, int bCreateHandle, int hNotifyWindow,int bScopePane);
        void AddExtensionPages();
        void Show(int window, int page);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("85DE64DD-EF21-11cf-A285-00C04FD8DBE6")
    ]
    public interface IPropertySheetCallback
    {
        void AddPage(IntPtr hPage);
        void RemovePage(IntPtr hPage);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("255F18CC-65DB-11D1-A7DC-00C04FD8D565")
    ]
    public interface IConsoleNameSpace2
    {
        void InsertItem(ref SCOPEDATAITEM a);
        void DeleteItem(uint a, int b);
        void SetItem(ref SCOPEDATAITEM a);
        void GetItem(ref SCOPEDATAITEM a);
        void GetChildItem(uint a, ref uint b, ref int c);
        void GetNextItem(uint a, ref uint b, ref int c);
        void GetParentItem(uint a, ref uint b, ref int c);
        void Expand(uint a);
        void AddExtension(CLSID a, ref SCOPEDATAITEM b); 
    }

																				
    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("9757abb8-1b32-11d1-a7ce-00c04fd8d565")
    ]
    public interface IHeaderCtrl2
    {
        void InsertColumn(int nCol, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string title, int nFormat,int nWidth);
        void DeleteColumn(int nCol);
        void SetColumnText(int nCol, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string title);
        void GetColumnText(int nCol, out int pText);
        void SetColumnWidth(int nCol, int nWidth);
        void GetColumnWidth(int nCol, out int pWidth);
        void SetChangeTimeOut( uint uTimeout);
        void SetColumnFilter(uint nColumn, uint dwType, IntPtr pFilterData);
        void GetColumnFilter(uint nColumn, ref uint pdwType, IntPtr pFilterData);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("31DA5FA0-E0EB-11cf-9F21-00AA003CA9F6")
    ]
    public interface IResultData 
    {
        void InsertItem(ref RESULTDATAITEM item);
        void DeleteItem(uint itemID, int nCol);
        void FindItemByLParam(int lParam, out uint pItemID);
        void DeleteAllRsltItems();
        void SetItem(ref RESULTDATAITEM item);
        void GetItem(ref RESULTDATAITEM item);
        void GetNextItem(ref RESULTDATAITEM item);
        void ModifyItemState(int nIndex, uint itemID, uint uAdd, uint uRemove);
        void ModifyViewStyle(int add, int remove);
        void SetViewMode(int lViewMode);
        void GetViewMode(out int lViewMode);
        void UpdateItem(uint itemID);
        void Sort(int nColumn, uint dwSortOptions, int lUserParam);
        void SetDescBarText([MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] ref String DescText);
        void SetItemCount(int nItemCount, uint dwOptions);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("43136EB8-D36C-11CF-ADBC-00AA00A80033")
    ]
    public interface IImageList
    {
        void ImageListSetIcon(IntPtr pIcon, int nLoc);
        void ImageListSetStrip(int pBMapSm, int pBMapLg, int nStartLoc, int cMask);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("103D842A-AA63-11D1-A7E1-00C04FD8D565")
    ]
    public interface IConsole2
    {
        void SetHeader(ref IHeaderCtrl2 pHeader);
        void SetToolbar([MarshalAs(UnmanagedType.Interface)] ref Object pToolbar); // Needs to be LPTOOLBAR 
        void QueryResultView([MarshalAs(UnmanagedType.Interface)] out Object pUnknown);
        void QueryScopeImageList(out IImageList ppImageList);
        void QueryResultImageList(out IImageList ppImageList);
        void UpdateAllViews(IDataObject lpDataObject, int data, int hint);
        void MessageBox([MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] String lpszText, [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] String lpszTitle, uint fuStyle, ref int piRetval);
        void QueryConsoleVerb(out IConsoleVerb ppConsoleVerb);
        void SelectScopeItem(int hScopeItem);
        void GetMainWindow(ref int phwnd);
        void NewWindow(int hScopeItem, uint lOptions);
        void Expand(int hItem, int bExpand);
        void IsTaskpadViewPreferred();
        void SetStatusText([MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]String pszStatusText);
    }



    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("43136EB6-D36C-11CF-ADBC-00AA00A80033")
    ]
    interface IContextMenuProvider : IContextMenuCallback
    {
        HRESULT EmptyMenuList();
        HRESULT AddPrimaryExtensionItems([MarshalAs(UnmanagedType.Interface)]Object lpUnknown, IDataObject lpDataObject);
        HRESULT AddThirdPartyExtensionItems(IDataObject lpDataObject);
        HRESULT ShowContextMenu(IntPtr hwndParent, int xPos, int yPos, ref long plSelected);
    };


    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("43136EB7-D36C-11CF-ADBC-00AA00A80033")
    ]
    public interface IContextMenuCallback
    {
        void AddItem(ref CONTEXTMENUITEM pItem);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("69FB811E-6C1C-11D0-A2CB-00C04FD909DD")
    ]
    public interface IControlbar
    {
        void Create(MMC_CONTROL_TYPE nType, IExtendControlbar pExtendControlbar, [MarshalAs(UnmanagedType.Interface)] out Object ppUnknown);
        void Attach(MMC_CONTROL_TYPE nType, [MarshalAs(UnmanagedType.Interface)] Object lpUnknown);
        void Detach([MarshalAs(UnmanagedType.Interface)] Object lpUnknown);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("43136EB9-D36C-11CF-ADBC-00AA00A80033")
    ]
    public interface IToolbar
    {
        void AddBitmap(int nImages, IntPtr hbmp, int cxSize, int cySize, int crMask);
        void AddButtons(int nButtons, ref MMCBUTTON lpButtons);
        void InsertButton(int nIndex, ref MMCBUTTON lpButton);
        void DeleteButton(int nIndex);
        void GetButtonState(int idCommand, MMC_BUTTON_STATE nState, out int pState);
        void SetButtonState(int idCommand, MMC_BUTTON_STATE nState, int bState);
    }

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("E49F7A60-74AF-11D0-A286-00C04FD8FE93")
    ]
    public interface IConsoleVerb 
    {
        void GetVerbState(uint eCmdID, uint nState, ref int pState);
        void SetVerbState(uint eCmdID, uint nState, int bState);
        void SetDefaultVerb(uint eCmdID);
        void GetDefaultVerb(ref uint peCmdID);
    }


    //////////////////////////////////////////////////////////////////
    /// Shim Control for hosting WinForms User Controls 
    /// in this ActiveX Controls

    [
        ComImport, 
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown), 
        Guid("B8F882F8-3D93-401c-A4D4-E3A9943E858D")
    ]
    public interface IMMCFormsShim
    {
		System.IntPtr HostUserControl(string Assembly, string Class); 
	}



    //////////////////////////////////////////////////////////////////
    ///
    /// Enumerations and Constants
    /// 

/*
    internal class DOBJ
    {
        internal const int NULL = 0;
        internal const int CUSTOMOCX = -1;
        internal const int CUSTOMWEB = -2;

    }
*/

    
    public enum MMCLV
    {
        AUTO                   = -1
    }

    public enum ColumnHeaderFormat
    {
        LEFT                   = 0x0000,
        RIGHT                  = 0x0001,
        CENTER                 = 0x0002,
        JUSTIFYMASK            = 0x0003,
        IMAGE                  = 0x0800,
        BITMAP_ON_RIGHT        = 0x1000,
        COL_HAS_IMAGES         = 0x8000
    }
/*
    public enum TBSTATE
    {
        CHECKED               = 0x01,
        PRESSED               = 0x02,
        ENABLED               = 0x04,
        HIDDEN                = 0x08,
        INDETERMINATE         = 0x10,
        WRAP                  = 0x20,
        ELLIPSES              = 0x40,
        MARKED                = 0x80,
    }// class TBSTATE
    public class TBSTYLE
    {
        public const byte BUTTON                = 0x0000;
        public const byte SEP                   = 0x0001;
        public const byte CHECK                 = 0x0002;
        public const byte GROUP                 = 0x0004;
        public const byte CHECKGROUP            = (GROUP | CHECK);
        public const byte DROPDOWN              = 0x0008;
        public const byte AUTOSIZE              = 0x0010;
        public const byte NOPREFIX              = 0x0020;
    }// class TBSTYLE

    public class EN
    {
        public const uint SETFOCUS           = 0x0100;
        public const uint KILLFOCUS          = 0x0200;
        public const uint CHANGE             = 0x0300;
        public const uint UPDATE             = 0x0400;
        public const uint ERRSPACE           = 0x0500;
        public const uint MAXTEXT            = 0x0501;
        public const uint HSCROLL            = 0x0601;
        public const uint VSCROLL            = 0x0602;
    }// EN
*/
    public enum PSM
    {
        SETCURSEL          = (0x0400 + 101),
        REMOVEPAGE         = (0x0400 + 102),
        ADDPAGE            = (0x0400 + 103),
        CHANGED            = (0x0400 + 104),
    }

    public enum PSNRET
    {
        NOERROR               = 0,
        INVALID               = 1,
        INVALID_NOCHANGEPAGE  = 2,
    }


    public class PSN
    {
        public const uint FIRST              = unchecked((0U-200U));
        public const uint LAST               = unchecked((0U-299U));
        public const uint SETACTIVE          = unchecked((FIRST-0));
        public const uint KILLACTIVE         = unchecked((FIRST-1));
        public const uint APPLY              = unchecked((FIRST-2));
        public const uint RESET              = unchecked((FIRST-3));
        public const uint HELP               = unchecked((FIRST-5));
        public const uint WIZBACK            = unchecked((FIRST-6));
        public const uint WIZNEXT            = unchecked((FIRST-7));
        public const uint WIZFINISH          = unchecked((FIRST-8));
        public const uint QUERYCANCEL        = unchecked((FIRST-9));
        public const uint GETOBJECT          = unchecked((FIRST-10));
    }


    public enum WM
    {
        WINDOWPOSCHANGING   = 0x0046,
        CHILDACTIVATE       = 0x0022,
        WINDOWPOSCHANGED    = 0x0047,
        NOTIFY              = 0x004E,
        SHOWWINDOW          = 0x0018,
        NCPAINT             = 0x0085,
        PAINT               = 0x000F,
        ERASEBKGND          = 0x0014,
        CTLCOLORDLG         = 0x0136,
        INITDIALOG          = 0x0110,
        COMMAND             = 0x0111,
        DESTROY             = 0x0002,
        CREATE              = 0x0001,
        MOVE                = 0x0003,
        SIZE                = 0x0005,
        ACTIVATEAPP         = 0x001C,
        ACTIVATE            = 0x0006,
    }


	// Used in building dialog templates
	public enum DS
	{
		SETFONT               = 0x40,
		FIXEDSYS              = 0x0008,
	}

	// Constants required for the Property Sheet Page Callback function
	public enum PSPCB
	{
		ADDREF                = 0,
		RELEASE               = 1,
		CREATE                = 2,
	}
    
	public enum PSP
	{
		DEFAULT               = 0x00000000,
		DLGINDIRECT           = 0x00000001,
		USEHICON              = 0x00000002,
		USEICONID             = 0x00000004,
		USETITLE              = 0x00000008,
		RTLREADING            = 0x00000010,

		HASHELP               = 0x00000020,
		USEREFPARENT          = 0x00000040,
		USECALLBACK           = 0x00000080,
		PREMATURE             = 0x00000400,

		HIDEHEADER            = 0x00000800,
		USEHEADERTITLE        = 0x00001000,
		USEHEADERSUBTITLE     = 0x00002000,
	}

	public class HRESULT
	{
		public const int S_OK                  = 0;
		public const int S_FALSE               = 1;
		public const int E_NOTIMPL             = unchecked((int)0x80004001);
	}

	public class IMAGE
	{
		public const int BITMAP                = 0;
		public const int CURSOR                = 1;
		public const int ICON                  = 2;
	}   

	public class CCT
	{
		public const uint SCOPE            = 0x8000; // Data object for scope pane context 
		public const uint RESULT           = 0x8001; // Data object for result pane context 
		public const uint SNAPIN_MANAGER   = 0x8002; // Data object for Snap-in Manager context 
		public const uint UNINITIALIZED    = 0xFFFF;  // Data object has an invalid type 
	}

	public class MMC_BUTTON_STATE
	{
		public const uint ENABLED                = 0x1;
		public const uint CHECKED                = 0x2;
		public const uint HIDDEN                = 0x4;
		public const uint INDETERMINATE            = 0x8;
		public const uint BUTTONPRESSED            = 0x10;
	}

	public class MMC_VERB                               
	{                                                            
		public const uint NONE            = 0x0000;                       
		public const uint OPEN            = 0x8000;                       
		public const uint COPY            = 0x8001;                       
		public const uint PASTE           = 0x8002;                       
		public const uint DELETE          = 0x8003;                       
		public const uint PROPERTIES      = 0x8004;                       
		public const uint RENAME          = 0x8005;                       
		public const uint REFRESH         = 0x8006;                       
		public const uint PRINT           = 0x8007;                       
		public const uint CUT             = 0x8008;
                                                             
		public const uint MAX             = 0x8009;                                            
		public const uint FIRST           = OPEN;                
		public const uint LAST            = MAX - 1;             
	}

   
   public enum ImageListOptions
   {
      LEAVE_LARGE_ICON = 0x40000000,
      LEAVE_SMALL_ICON =  0x20000000,
   }


   public enum ViewMode
   {
      Icon        = 0,
      Report      = 1,
      SmallIcon   = 2,
      List        = 3,
      Filtered    = 4,
   }


	public enum MMC_CONTROL_TYPE
	{
		TOOLBAR                    = 0,
		MENUBUTTON                = TOOLBAR + 1,
		COMBOBOXBAR                = MENUBUTTON + 1
	}

	public class CCM
	{    
		public const uint INSERTIONALLOWED_TOP    = 1;
		public const uint INSERTIONALLOWED_NEW    = 2;
		public const uint INSERTIONALLOWED_TASK    = 4;
		public const uint INSERTIONALLOWED_VIEW    = 8;

		public const uint INSERTIONPOINTID_PRIMARY_TOP    = 0xa0000000;
		public const uint INSERTIONPOINTID_PRIMARY_NEW    = 0xa0000001;
		public const uint INSERTIONPOINTID_PRIMARY_TASK    = 0xa0000002;
		public const uint INSERTIONPOINTID_PRIMARY_VIEW    = 0xa0000003;
		public const uint INSERTIONPOINTID_3RDPARTY_NEW    = 0x90000001;
		public const uint INSERTIONPOINTID_3RDPARTY_TASK = 0x90000002;
		public const uint INSERTIONPOINTID_ROOT_MENU     = 0x80000000;
	}


   public enum MMC_VIEW_OPTIONS
   {
      NONE                          = 0,
      CREATENEW                     = 0x00000010,
      EXCLUDE_SCOPE_ITEMS_FROM_LIST = 0x00000040,
      FILTERED                      = 0x00000008,
      LEXICAL_SORT                  = 0x00000080,
      NOLISTVIEWS                   = 0x00000001,
	  MULTISELECT                   = 0x00000002, // Not 4!
	  OWNERDATALIST                 = 0x00000004, // Not 2!
      USEFONTLINKING                = 0x00000020,
      ACTIVATE                      = 0x00000006,
   }

	public enum MMCN_Notifiy
	{
		//	Is sent when a window is being activated or deactivated.
		//	arg = TRUE if window is activated, false otherwise.
		//	param = Not used.
		ACTIVATE = 0x8001,

		//	Sent to IComponent to add images for the result pane. The primary snapin
		//	should add images for both folders and leaf items. Extension snapins
		//	should add only folder images. 
		//	arg = ptr to result panes IImageList.
		//	param = HSCOPEITEM of selected/deselected item
		ADD_IMAGES = 0x8002,
    
		//	This message is sent when a user clicks on a button.
		//	arg   = When sent to ExtendControlbar it is the data object of currently selected,
		//	when sent to IComponent/IComponentData it is 0.
		//	param = CmdID of the button equal to a value of the MMC_COMMANDS enum type.
		BTN_CLICK = 0x8003,
		
		CLICK     = 0x8004,

		//	This message is sent when the user clicks on a result listview column header.
		//	dataObject = NULL
		//	arg = Column number
		//	param = Sort option flags (RSI_xxx) 
		COLUMN_CLICK = 0x8005,

		// not used
		CONTEXTMENU = 0x8006,

		//	dataobject: NULL.
		//	arg: pointer to a dataobject. See multi-selection below.
		//	param: unused.
		CUTORMOVE = 0x8007,

		DBLCLICK = 0x8008,

		//	Sent to inform the snapin that the item needs to be deleted. As a result of
		//	the user hitting the 'Delete' key or delete button.
		//	dataobject: dataobject of the selected item(s) provided by the snap-in.
		//	arg, param: unused.
		DELETE = 0x8009,

		//	This message is sent when all items of an owner-data result pane
		//	are deselected.
		//	dataObject = NULL
		//	arg = 0
		//	param = 0
		DESELECT_ALL = 0x800A,

		//	arg = TRUE => expand, FALSE => contract
		//	param = parents HSCOPEITEM.
		EXPAND = 0x800B,

		// NOT USED
		HELP = 0x800C,   

		//	This message is sent when a user clicks on a button.
		//	arg   = Data object of currently selected.
		//	param = Structure (LPMENUBUTTONDATA).
		MENU_BTNCLICK = 0x800D, 

		//	Is sent when a window is being minimized or maximized.
		//	arg = TRUE if minimized, false otherwise.
		MINIMIZED = 0x800E, 

		//	dataobject & arg: are same as for QUERY_PASTE.
		//	param:
		//	NULL for move (as opposed to cut).
		//	For single item paste:
		//	BOOL* pPasted = (BOOL*)param; 
		//	Set this to TRUE here if the item was successfully pasted.
		//	For multi-item paste:
		//	LPDATAOBJECT* ppDataObj = (LPDATAOBJECT*)param;
		//	Use this to return a pointer to a dataobject consisting of the 
		//	items successfully pasted. (see CUTORMOVE below).
		PASTE = 0x800F,

		//	lpDataObject = NULL
		//	lParam = user object
		PROPERTY_CHANGE = 0x8010,

		//	dataobject: dataobject of the selected item provided by the snap-in.        
		//	arg: dataobject of the item(s) provided by the source snap-in that needs to be pasted.
		//	param: unused.
		//	Return S_OK if the data can be pasted, S_FALSE otherwise.
		QUERY_PASTE = 0x8011,


		REFRESH = 0x8012,

		//	Informs the snapin to delete all the cookies it has added below.
		//	arg = HSCOPEITEM of the node whose children needs to be deleted.
		//	param = unused.
		//	return = unused.
		REMOVE_CHILDREN = 0x8013,
    
		//	This gets called the first time to query for rename and a
		//	second time to do the rename.  For the query S_OK or S_FALSE for the
		//	return type.  After the rename, we will send the new name with a LPOLESTR.
		//	arg = 0 for query, 1 for rename action 
		//	param = LPOLESTR for containing new name   
		//	return = S_OK to allow rename and S_FALSE to disallow rename.                    
		RENAME = 0x8014,

		//	If sent to IComponent::Notify:
		//	arg:
		//	BOOL bScope = (BOOL) LOWORD(arg);
		//	BOOL bSelect = (BOOL) HIWORD(arg);
		//	bScope:     TRUE if an item the scope pane is selected, 
		//	FALSE if an item in the result pane is selected.
		//	bSelect:    TRUE if the item is selected, 
		//	FALSE if it is de-selected.
		//	param: 
		//	Ignored.                
		//                
		//	If sent to IExtendControlbar::ControlbarNotify:
		//	arg:
		//	BOOL bScope = (BOOL) LOWORD(arg);
		//	BOOL bSelect = (BOOL) HIWORD(arg);
		//	bScope:     TRUE if an item the scope pane is selected, 
		//	FALSE if an item in the result pane is selected.
		//	bSelect:    TRUE if the item is selected,
		//	FALSE if it is de-selected.  
		//	param:
		//	LPDATAOBJECT pDataobject = (LPDATAOBJECT)param;
		//	pDataobject data object of item getting selected/de-selected.
		SELECT = 0x8015,

		//	arg = <>0 if selecting, 0 if deselecting
		//	param = HSCOPEITEM of selected/deselected item
		SHOW = 0x8016,

		//	This message is sent to update all views of a change.
		//	arg = TRUE if Scope Item, FALSE if Result Item
		//	param = ptr to DataObject selected
		VIEW_CHANGE = 0x8017,

		//	This message is sent when the user requests help about the snapin.
		//	dataObject = NULL
		//	arg = 0
		//	param = 0
		SNAPINHELP = 0x8018,

		//	This message is sent when the user requests help about a selected item
		//	arg = 0
		//	param = 0 
		CONTEXTHELP = 0x8019,

		//	Sent to a snap-in when its custom OCX is initialized for the first time.
		INITOCX = 0x801A,
	
		//	This message is sent when the filter value for a result view column has been changed. 
		//	dataobject= NULL
		//	arg = Filter change code (see MMC_FILTER_CHANGE_CODE enumeration)
		//	param = column number of changed value, if change code is MFCC_VALUE_CHANGE
		FILTER_CHANGE = 0x801B,

		//	This message is sent to get the filter operators menu for a result view column.
		//	dataobject = NULL
		//	arg = Column number
		//	param = Pointer to returned menu handle (HMENU)
		GET_FILTER_MENU = 0x801C,

		//	This message is sent when the user selects an entry from a filter operator menu.
		//	dataobject = NULL
		//	arg = Column number
		//	param = Menu item ID  
		FILTER_OPERATOR = 0x801D,

	}

	public enum SDI
	{
		STR                = 0x2,
		IMAGE              = 0x4,
		OPENIMAGE          = 0x8,
		STATE              = 0x10,
		PARAM              = 0x20,
		CHILDREN           = 0x40,
		PARENT             = 0,
		PREVIOUS           = 0x10000000,
		NEXT               = 0x20000000,
		FIRST              = 0x8000000,
	}

	public enum RDI
	{
		STR                = 0x2,
		IMAGE              = 0x4,
		STATE              = 0x8,
		PARAM              = 0x10,
		INDEX              = 0x20,
		INDENT             = 0x40,
	}


	//////////////////////////////////////////////////////////////////////
	/// 
	/// Structures 
	/// 

    [
        StructLayout(LayoutKind.Sequential)
    ]
    public struct MENUBUTTONDATA
    {
        public int idCommand;
        public int x;
        public int y;
    } 


    [
    StructLayout(LayoutKind.Sequential)
    ]
    public struct MMCBUTTON
	{
		public int nBitmap;
		public int idCommand;
		public byte fsState;
		public byte fsType;
		[MarshalAs(UnmanagedType.LPWStr)]
		public String lpButtonText;
		[MarshalAs(UnmanagedType.LPWStr)]
		public String lpTooltipText;
	}

    [
        StructLayout(LayoutKind.Sequential, 
        CharSet=CharSet.Auto)
    ]
    struct LOGFONT
    {
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
        public string lfFaceName;
    }

    [
        StructLayout(LayoutKind.Sequential, 
        CharSet=CharSet.Auto)
    ]
    public struct TEXTMETRIC 
    { 
        public int tmHeight; 
        public int tmAscent; 
        public int tmDescent; 
        public int tmInternalLeading; 
        public int tmExternalLeading; 
        public int tmAveCharWidth; 
        public int tmMaxCharWidth; 
        public int tmWeight; 
        public int tmOverhang; 
        public int tmDigitizedAspectX; 
        public int tmDigitizedAspectY; 
        char   tmFirstChar; 
        char   tmLastChar; 
        char   tmDefaultChar; 
        char   tmBreakChar; 
        byte   tmItalic; 
        byte   tmUnderlined; 
        byte   tmStruckOut; 
        byte   tmPitchAndFamily; 
        byte   tmCharSet; 
    }


    [
        StructLayout(LayoutKind.Sequential)
    ]
    public struct CONTEXTMENUITEM
	{
		[MarshalAs(UnmanagedType.LPWStr)]
		public String   strName;
		[MarshalAs(UnmanagedType.LPWStr)]
		public String   strStatusBarText;
		public int      lCommandID;
		public uint     lInsertionPointID;
		public int      fFlags;
		public int      fSpecialFlags;
	}

    [
        StructLayout(LayoutKind.Sequential)
    ]
    public struct SCOPEDATAITEM
	{
		public uint  mask;
		public IntPtr displayname;
		public int  nImage;
		public int  nOpenImage;
		public uint nState;
		public int  cChildren;
		public int  lParam;
		public int relativeID;
		public int ID;
	}

    [
        StructLayout(LayoutKind.Sequential)
    ]
    public struct RESULTDATAITEM
	{
		public uint mask;
		public int bScopeItem;
		public int itemID;
		public int nIndex;
		public int nCol;
		public IntPtr str;
		public int nImage;
		public uint nState;
		public int lParam;
		public int iIndent;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct CLSID
	{
		public uint x;
		public ushort s1;
		public ushort s2;
		public byte[] c;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct FORMATETC
	{
		public int cfFormat;
		public int ptd;
		public uint dwAspect;
		public int  lindex;
		public uint tymed;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct PROPSHEETPAGE
	{  
		public uint            dwSize; 
		public uint            dwFlags; 
		public IntPtr          hInstance; 

		// This is a union of the following Data items
		// String          pszTemplate; 
		// IntPtr          pResource;

		public IntPtr      pResource;

		// This is a union of the following Data items
		// int             hIcon; 
		// String          pszIcon; 
		public IntPtr          hIcon;

		public String          pszTitle; 
		public DialogProc      pfnDlgProc;
		public IntPtr          lParam; 

		public PropSheetPageProc pfnCallback;
		public int             pcRefParent; 

		public String          pszHeaderTitle;
		public String          pszHeaderSubTitle;
	}

	[
        StructLayout(LayoutKind.Sequential, Pack=2, 
        CharSet=CharSet.Auto)
    ]
	internal struct DLGTEMPLATE
	{
		internal uint style; 
		internal uint dwExtendedStyle; 
		internal ushort cdit; 
		internal short x; 
		internal short y; 
		internal short cx; 
		internal short cy;
		internal short wMenuResource;
		internal short wWindowClass;
		internal short wTitleArray;
		internal short wFontPointSize;
		[MarshalAs(UnmanagedType.LPWStr)]
		internal String szFontTypeface;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct STGMEDIUM
	{
		public uint tymed;
		public int hGlobal;
		public Object pUnkForRelease;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct userFLAG_STGMEDIUM
	{
		public int ContextFlags;
		public int fPassOwnership;
		public STGMEDIUM Stgmed;
	}

	[
        StructLayout(LayoutKind.Sequential)
    ]
	public struct NMHDR
	{
		public int hwndFrom; 
		public uint idFrom; 
		public uint code; 
	}




	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
	internal struct DIBSECTION
	{
		internal BITMAP            dsBm;
		internal BITMAPINFOHEADER  dsBmih;
		internal uint              dsBitfields0;
		internal uint              dsBitfields1;
		internal uint              dsBitfields2;
		internal IntPtr            dshSection;
		internal uint              dsOffset;
	}
	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
	internal struct BITMAP
	{
		internal int      bmType;
		internal int      bmWidth;
		internal int      bmHeight;
		internal int      bmWidthBytes;
		internal ushort   bmPlanes;
		internal ushort   bmBitsPixel;
		internal IntPtr   bmBits;
	}
	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
	internal struct BITMAPINFOHEADER
	{
		internal int      biSize;
		internal int      biWidth;
		internal int      biHeight;
		internal ushort   biPlanes;
		internal ushort   biBitCount;
		internal uint     biCompression;
		internal uint     biSizeImage;
		internal int      biXPelsPerMeter;
		internal int      biYPelsPerMeter;
		internal uint     biClrUsed;
		internal uint     biClrImportant;
	}
	/// <summary>
	/// 
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
	internal struct BITMAPINFO
	{
		internal BITMAPINFOHEADER  bmiHeader;
		internal long              bmiColors0;
		internal long              bmiColors1;
		internal long              bmiColors2;
		internal long              bmiColors3;
	}






    //////////////////////////////////////////////////////////////////////
    /// 
    /// Delegates used for Windows Callbacks
    /// 

    public delegate bool DialogProc(IntPtr hwndDlg, uint uMsg, IntPtr wParam, IntPtr lParam); 
    public delegate uint PropSheetPageProc(IntPtr hwnd, uint uMsg, IntPtr lParam);



	//////////////////////////////////////////////////////////////////////
	/// 
	/// Linkage between usercontrols in a form node and the base snapin
	/// 
	/// 
	/// <summary>
	/// ISnapinLink is used to link a usercontrol to snapin objects.  Custom UserControls
	/// can choose to implement this interface called by the framework at control creation
	/// time.  The Base Sanpin instance is navigable from the Context Node
	/// </summary>
	[Guid("320879B0-AFD9-4277-9543-788AB588EDF0")]
	public interface ISnapinLink
	{
		/// <summary>
		/// The framework will provide the implementing object 
		/// with a reference to the node associated with the object.
		/// Implementing objects are likely UserControls use in FormNodes
		/// and propertyPages.
		/// </summary>
		BaseNode ContextNode
		{
			get;
			set;
		}
	}



	/// <summary>
	/// Implemented by UserControls used in propertypages to receive
	/// the PropertyPage object context.  Fromt hat context UserControsl can 
	/// navigate to the propertysheet, snapin node and base snapin object.
	/// </summary>
	public interface IPropertyPageContext
	{
		PropertyPage PropertyPage
		{
			get;
			set;
		}
	}

}

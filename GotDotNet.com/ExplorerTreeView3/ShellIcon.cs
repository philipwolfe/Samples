namespace ExplorerTreeViewTest
{
    #region Using directives

    using System;
    using System.Text;
    using System.Drawing;
    using System.Collections;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    #endregion Using directives

    public class ShellIcon
    {
        public enum IconSize
        {
            Small,
            Large
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        public enum CSIDL
        {
            /// <summary>
            /// Desktop
            /// </summary>
            CSIDL_DESKTOP = 0x0000,
            /// <summary>
            /// Internet Explorer (icon on desktop)
            /// </summary>
            CSIDL_INTERNET = 0x0001,
            /// <summary>
            /// Start Menu\Programs
            /// </summary>
            CSIDL_PROGRAMS = 0x0002,
            /// <summary>
            /// My Computer\Control Panel
            /// </summary>
            CSIDL_CONTROLS = 0x0003,
            /// <summary>
            /// My Computer\Printers
            /// </summary>
            CSIDL_PRINTERS = 0x0004,
            /// <summary>
            /// My Documents
            /// </summary>
            CSIDL_PERSONAL = 0x0005,
            /// <summary>
            /// user name\Favorites
            /// </summary>
            CSIDL_FAVORITES = 0x0006,
            /// <summary>
            /// Start Menu\Programs\Startup
            /// </summary>
            CSIDL_STARTUP = 0x0007,
            /// <summary>
            /// user name\Recent
            /// </summary>
            CSIDL_RECENT = 0x0008,
            /// <summary>
            /// user name\SendTo
            /// </summary>
            CSIDL_SENDTO = 0x0009,
            /// <summary>
            /// desktop\Recycle Bin
            /// </summary>
            CSIDL_BITBUCKET = 0x000a,
            /// <summary>
            /// user name\Start Menu
            /// </summary>
            CSIDL_STARTMENU = 0x000b,
            /// <summary>
            /// logical "My Documents" desktop icon
            /// </summary>
            CSIDL_MYDOCUMENTS = 0x000c,
            /// <summary>
            /// "My Music" folder
            /// </summary>
            CSIDL_MYMUSIC = 0x000d,
            /// <summary>
            /// "My Videos" folder
            /// </summary>
            CSIDL_MYVIDEO = 0x000e,
            /// <summary>
            /// user name\Desktop
            /// </summary>
            CSIDL_DESKTOPDIRECTORY = 0x0010,
            /// <summary>
            /// My Computer
            /// </summary>
            CSIDL_DRIVES = 0x0011,
            /// <summary>
            /// Network Neighborhood (My Network Places)
            /// </summary>
            CSIDL_NETWORK = 0x0012,
            /// <summary>
            /// user name>nethood
            /// </summary>
            CSIDL_NETHOOD = 0x0013,
            /// <summary>
            /// windows\fonts
            /// </summary>
            CSIDL_FONTS = 0x0014,
            CSIDL_TEMPLATES = 0x0015,
            /// <summary>
            /// All Users\Start Menu
            /// </summary>
            CSIDL_COMMON_STARTMENU = 0x0016,
            /// <summary>
            /// All Users\Start Menu\Programs
            /// </summary>
            CSIDL_COMMON_PROGRAMS = 0X0017,
            /// <summary>
            /// All Users\Startup
            /// </summary>
            CSIDL_COMMON_STARTUP = 0x0018,
            /// <summary>
            /// All Users\Desktop
            /// </summary>
            CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019,
            /// <summary>
            /// user name\Application Data
            /// </summary>
            CSIDL_APPDATA = 0x001a,
            /// <summary>
            /// user name\PrintHood
            /// </summary>
            CSIDL_PRINTHOOD = 0x001b,
            /// <summary>
            /// user name\Local Settings\Applicaiton Data (non roaming)
            /// </summary>
            CSIDL_LOCAL_APPDATA = 0x001c,
            /// <summary>
            /// non localized startup
            /// </summary>
            CSIDL_ALTSTARTUP = 0x001d,
            /// <summary>
            /// non localized common startup
            /// </summary>
            CSIDL_COMMON_ALTSTARTUP = 0x001e,
            CSIDL_COMMON_FAVORITES = 0x001f,
            CSIDL_INTERNET_CACHE = 0x0020,
            CSIDL_COOKIES = 0x0021,
            CSIDL_HISTORY = 0x0022,
            /// <summary>
            /// All Users\Application Data
            /// </summary>
            CSIDL_COMMON_APPDATA = 0x0023,
            /// <summary>
            /// GetWindowsDirectory()
            /// </summary>
            CSIDL_WINDOWS = 0x0024,
            /// <summary>
            /// GetSystemDirectory()
            /// </summary>
            CSIDL_SYSTEM = 0x0025,
            /// <summary>
            /// C:\Program Files
            /// </summary>
            CSIDL_PROGRAM_FILES = 0x0026,
            /// <summary>
            /// C:\Program Files\My Pictures
            /// </summary>
            CSIDL_MYPICTURES = 0x0027,
            /// <summary>
            /// USERPROFILE
            /// </summary>
            CSIDL_PROFILE = 0x0028,
            /// <summary>
            /// x86 system directory on RISC
            /// </summary>
            CSIDL_SYSTEMX86 = 0x0029,
            /// <summary>
            /// x86 C:\Program Files on RISC
            /// </summary>
            CSIDL_PROGRAM_FILESX86 = 0x002a,
            /// <summary>
            /// C:\Program Files\Common
            /// </summary>
            CSIDL_PROGRAM_FILES_COMMON = 0x002b,
            /// <summary>
            /// x86 Program Files\Common on RISC
            /// </summary>
            CSIDL_PROGRAM_FILES_COMMONX86 = 0x002c,
            /// <summary>
            /// All Users\Templates
            /// </summary>
            CSIDL_COMMON_TEMPLATES = 0x002d,
            /// <summary>
            /// All Users\Documents
            /// </summary>
            CSIDL_COMMON_DOCUMENTS = 0x002e,
            /// <summary>
            /// All Users\Start Menu\Programs\Administrative Tools
            /// </summary>
            CSIDL_COMMON_ADMINTOOLS = 0x002f,
            /// <summary>
            /// user name\Start Menu\Programs\Administrative Tools
            /// </summary>
            CSIDL_ADMINTOOLS = 0x0030,
            /// <summary>
            /// Network and Dial-up Connections
            /// </summary>
            CSIDL_CONNECTIONS = 0x0031,
            /// <summary>
            /// All Users\My Music
            /// </summary>
            CSIDL_COMMON_MUSIC = 0x0035,
            /// <summary>
            /// All Users\My Pictures
            /// </summary>
            CSIDL_COMMON_PICTURES = 0x0036,
            /// <summary>
            /// All Users\My Video
            /// </summary>
            CSIDL_COMMON_VIDEO = 0x0037,
            /// <summary>
            /// Resource Direcotry
            /// </summary>
            CSIDL_RESOURCES = 0x0038,
            /// <summary>
            /// Localized Resource Direcotry
            /// </summary>
            CSIDL_RESOURCES_LOCALIZED = 0x0039,
            /// <summary>
            /// Links to All Users OEM specific apps
            /// </summary>
            CSIDL_COMMON_OEM_LINKS = 0x003a,
            /// <summary>
            /// USERPROFILE\Local Settings\Application Data\Microsoft\CD Burning
            /// </summary>
            CSIDL_CDBURN_AREA = 0x003b,
            /// <summary>
            /// Computers Near Me (computered from Workgroup membership)
            /// </summary>
            CSIDL_COMPUTERSNEARME = 0x003d,
            /// <summary>
            /// combine with CSIDL_ value to force folder creation in SHGetFolderPath()
            /// </summary>
            CSIDL_FLAG_CREATE = 0x8000,
            /// <summary>
            /// combine with CSIDL_ value to return an unverified folder path
            /// </summary>
            CSIDL_FLAG_DONT_VERIFY = 0x4000,
            /// <summary>
            /// combine with CSIDL_ value to insure non-alias versions of the pidl
            /// </summary>
            CSIDL_FLAG_NO_ALIAS = 0x1000,
            /// <summary>
            /// combine with CSIDL_ value to indicate per-user init (eg. upgrade)
            /// </summary>
            CSIDL_FLAG_PER_USER_INIT = 0x0800,
            /// <summary>
            /// mask for all possible 
            /// </summary>
            CSIDL_FLAG_MASK = 0xFF00,
        }

        internal class Win32
        {
            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern uint SHGetSpecialFolderLocation(
                IntPtr hWnd,
                CSIDL nFolder,
                out IntPtr Pidl);

            [DllImport("Shell32.dll")] 
            public static extern bool SHGetSpecialFolderPath(
                IntPtr hwndOwner, 
                StringBuilder lpszPath,
                int nFolder,
                bool fCreate); 

            [DllImport("shell32.dll")]
            public static extern Int32 SHGetMalloc(out IntPtr hObject);

            internal const uint SHGFI_ICON = 0x000000100;  // get icon
            internal const uint SHGFI_DISPLAYNAME = 0x000000200;  // get display name
            internal const uint SHGFI_TYPENAME = 0x000000400;  // get type name
            internal const uint SHGFI_ATTRIBUTES = 0x000000800;  // get attributes
            internal const uint SHGFI_ICONLOCATION = 0x000001000;  // get icon location
            internal const uint SHGFI_EXETYPE = 0x000002000;  // return exe type
            internal const uint SHGFI_SYSICONINDEX = 0x000004000;  // get system icon index
            internal const uint SHGFI_LINKOVERLAY = 0x000008000;  // put a link overlay on icon
            internal const uint SHGFI_SELECTED = 0x000010000;  // show icon in selected state
            internal const uint SHGFI_ATTR_SPECIFIED = 0x000020000;  // get only specified attributes
            internal const uint SHGFI_LARGEICON = 0x000000000;  // get large icon
            internal const uint SHGFI_SMALLICON = 0x000000001;  // get small icon
            internal const uint SHGFI_OPENICON = 0x000000002;  // get open icon
            internal const uint SHGFI_SHELLICONSIZE = 0x000000004;  // get shell size icon
            internal const uint SHGFI_PIDL = 0x000000008;  // pszPath is a pidl
            internal const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;  // use passed dwFileAttribute
            internal const uint SHGFI_ADDOVERLAYS = 0x000000020;  // apply the appropriate overlays
            internal const uint SHGFI_OVERLAYINDEX = 0x000000040;  // Get the index of the overlay in 
            // the upper 8 bits of the iIcon

            [DllImport("shell32.dll")]
            internal static extern IntPtr SHGetFileInfo(
                string pszPath,
                uint dwFileAttributes,
                ref SHFILEINFO psfi,
                uint cbSizeFileInfo,
                uint uFlags);

            [DllImport("shell32.dll")]
            internal static extern IntPtr SHGetFileInfo(
                IntPtr Pidl,
                uint dwFileAttributes,
                ref SHFILEINFO psfi,
                uint cbSizeFileInfo,
                uint uFlags);

            [DllImport("User32.dll")]
            internal static extern int DestroyIcon(IntPtr hIcon);
        }

        private static int lookupIcon(
            ref SHFILEINFO shinfo,
            IntPtr sysImageList,
            ref string name,
            ref ImageList imageList,
            ref Hashtable systemIcons)
        {
            name = shinfo.szDisplayName;
            if ((int)sysImageList == 0)
                return -1;
            string key = String.Format("{0}:{1}", (int)sysImageList, (int)shinfo.iIcon);
            if (systemIcons.ContainsKey(key) == false)
            {
                System.Drawing.Icon.FromHandle(shinfo.hIcon);
                System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon).Clone();
                imageList.Images.Add(icon);
                systemIcons.Add(key, imageList.Images.Count - 1);
            }
            Win32.DestroyIcon(shinfo.hIcon);
            return (int)systemIcons[key];
        }

        public static int GetIconImageIndex(
            string fileName,
            IconSize size,
            ref string name,
            ref ImageList imageList,
            ref Hashtable systemIcons)
        {
            // get all the shell information for this object
            SHFILEINFO shinfo = new SHFILEINFO();
            uint flags = Win32.SHGFI_ICON | Win32.SHGFI_SYSICONINDEX | Win32.SHGFI_DISPLAYNAME;
            if (size == IconSize.Small)
                flags |= Win32.SHGFI_SMALLICON;
            else
                flags |= Win32.SHGFI_LARGEICON;
            IntPtr sysImageList = Win32.SHGetFileInfo(
                fileName,
                0,
                ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                flags);

            // update the image list and return an index to the icon
            return lookupIcon(ref shinfo, sysImageList, ref name, ref imageList, ref systemIcons);
        }

        public static int GetIconImageIndex(
            Environment.SpecialFolder sf,
            IconSize size,
            ref string name,
            ref ImageList imageList,
            ref Hashtable systemIcons)
        {
            ShellIcon.CSIDL pidl;
            switch (sf)
            {
                case Environment.SpecialFolder.ApplicationData:
                    pidl = CSIDL.CSIDL_APPDATA;
                    break;
                case Environment.SpecialFolder.CommonApplicationData:
                    pidl = CSIDL.CSIDL_COMMON_APPDATA;
                    break;
                case Environment.SpecialFolder.CommonProgramFiles:
                    pidl = CSIDL.CSIDL_COMMON_PROGRAMS;
                    break;
                case Environment.SpecialFolder.Cookies:
                    pidl = CSIDL.CSIDL_COOKIES;
                    break;
                case Environment.SpecialFolder.Desktop:
                    pidl = CSIDL.CSIDL_DESKTOP;
                    break;
                case Environment.SpecialFolder.DesktopDirectory:
                    pidl = CSIDL.CSIDL_DESKTOPDIRECTORY;
                    break;
                case Environment.SpecialFolder.Favorites:
                    pidl = CSIDL.CSIDL_FAVORITES;
                    break;
                case Environment.SpecialFolder.History:
                    pidl = CSIDL.CSIDL_HISTORY;
                    break;
                case Environment.SpecialFolder.InternetCache:
                    pidl = CSIDL.CSIDL_INTERNET_CACHE;
                    break;
                case Environment.SpecialFolder.LocalApplicationData:
                    pidl = CSIDL.CSIDL_LOCAL_APPDATA;
                    break;
                case Environment.SpecialFolder.MyComputer:
                    pidl = CSIDL.CSIDL_DESKTOP;
                    break;
                case Environment.SpecialFolder.MyMusic:
                    pidl = CSIDL.CSIDL_MYMUSIC;
                    break;
                case Environment.SpecialFolder.MyPictures:
                    pidl = CSIDL.CSIDL_MYPICTURES;
                    break;
                case Environment.SpecialFolder.Personal:
                    pidl = CSIDL.CSIDL_PERSONAL;
                    break;
                case Environment.SpecialFolder.ProgramFiles:
                    pidl = CSIDL.CSIDL_PROGRAM_FILES;
                    break;
                case Environment.SpecialFolder.Programs:
                    pidl = CSIDL.CSIDL_PROGRAMS;
                    break;
                case Environment.SpecialFolder.Recent:
                    pidl = CSIDL.CSIDL_RECENT;
                    break;
                case Environment.SpecialFolder.SendTo:
                    pidl = CSIDL.CSIDL_SENDTO;
                    break;
                case Environment.SpecialFolder.StartMenu:
                    pidl = CSIDL.CSIDL_STARTMENU;
                    break;
                case Environment.SpecialFolder.Startup:
                    pidl = CSIDL.CSIDL_STARTUP;
                    break;
                case Environment.SpecialFolder.System:
                    pidl = CSIDL.CSIDL_SYSTEM;
                    break;
                case Environment.SpecialFolder.Templates:
                    pidl = CSIDL.CSIDL_TEMPLATES;
                    break;
                default:
                    throw new InvalidOperationException("Unknown Environment.SpecialFolder value");
            }
            return GetIconImageIndex(
                pidl,
                size,
                ref name,
                ref imageList,
                ref systemIcons);
        }

        public static int GetIconImageIndex(
            ShellIcon.CSIDL pidl,
            IconSize size,
            ref string name,
            ref ImageList imageList,
            ref Hashtable systemIcons)
        {
            // get the IMalloc object
            IntPtr ptrRet;
            Win32.SHGetMalloc(out ptrRet);
            System.Type mallocType = System.Type.GetType("IMalloc");
            Object obj = Marshal.GetTypedObjectForIUnknown(ptrRet,mallocType);
            IMalloc pMalloc = (IMalloc)obj;
 
            // get the pidl root
            IntPtr pidlRoot;
            Win32.SHGetSpecialFolderLocation(IntPtr.Zero, pidl, out pidlRoot);

            // get all the shell information for this object
            SHFILEINFO shinfo = new SHFILEINFO();
            uint flags = Win32.SHGFI_PIDL | Win32.SHGFI_ICON | Win32.SHGFI_SYSICONINDEX | Win32.SHGFI_DISPLAYNAME;
            if (size == IconSize.Small)
                flags |= Win32.SHGFI_SMALLICON;
            else
                flags |= Win32.SHGFI_LARGEICON;
            IntPtr sysImageList = Win32.SHGetFileInfo(
                pidlRoot,
                0,
                ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                flags);

            // free the pidl
            if (pidlRoot != IntPtr.Zero)
                pMalloc.Free(pidlRoot);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pMalloc);

            // update the image list and return an index to the icon
            return lookupIcon(ref shinfo, sysImageList, ref name, ref imageList, ref systemIcons);
        }

        public static string GetSpecialFolderPath(ShellIcon.CSIDL pidl)
        {
            int MAX_PATH = 260; 
            StringBuilder sb = new StringBuilder(MAX_PATH); 
            Win32.SHGetSpecialFolderPath(IntPtr.Zero, sb, (int)pidl, false); 
            return sb.ToString(); 
        }
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000002-0000-0000-C000-000000000046")]
    public interface IMalloc 
    {
        [PreserveSig]
        IntPtr Alloc(UInt32 cb);
                
        [PreserveSig]
        IntPtr Realloc( IntPtr pv, UInt32 cb);

        [PreserveSig]
        void Free(IntPtr pv);

        [PreserveSig]
        UInt32 GetSize(IntPtr pv);

        [PreserveSig]
        Int16 DidAlloc(IntPtr pv);

        [PreserveSig]
        void HeapMinimize();
    }
}
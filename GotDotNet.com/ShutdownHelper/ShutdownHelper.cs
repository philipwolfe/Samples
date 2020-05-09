using System;
using System.Runtime.InteropServices;

namespace Util.Helpers {
	/// <summary>
	/// Summary description for SystemHelper.
	/// </summary>
	public class SystemHelper {
		private struct TokPriv1Luid {
			public int Count;
			public long Luid;
			public int Attr;
		}

		[DllImport("kernel32.dll", ExactSpelling=true) ]
		private static extern IntPtr GetCurrentProcess();

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		private static extern bool OpenProcessToken( IntPtr h, int acc, ref IntPtr phtok );

		[DllImport("advapi32.dll", SetLastError=true) ]
		private static extern bool LookupPrivilegeValue( string host, string name, ref long pluid );

		[DllImport("advapi32.dll", ExactSpelling=true, SetLastError=true) ]
		private static extern bool AdjustTokenPrivileges( IntPtr htok, bool disall,
			ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen );

		[DllImport("user32.dll", ExactSpelling=true, SetLastError=true) ]
		private static extern bool ExitWindowsEx (
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)] exitWindowsFlags uFlags, 
			[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U8)] ShutdownReasons dwReason);


		private const int SE_PRIVILEGE_ENABLED = 0x00000002;
		private const int TOKEN_QUERY = 0x00000008;
		private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
		private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

		#region exitWindowsFlags Enum
		[Flags()]
			private enum exitWindowsFlags : uint {
			Logoff = 0x0,
			Shutdown = 0x1,
			Reboot = 0x2,
			Force = 0x4,
			PowerOff = 0x8,
			ForceIfHung = 0x10,
			Reset = Logoff | Force | Reboot
		}
		#endregion

		#region ShutdownReasons Enum
		public enum ShutdownReasons : long {
			FlagCommentRequired = 0x1000000,
			FlagDirtyProblemIdRequired = 0x2000000,
			FlagCleanUI = 0x4000000,
			FlagDirtyUI = 0x8000000,
			FlagUserDefined = 0x40000000,
			FlagPlanned = 0x80000000,
			MajorOther = 0x0,
			MajorNone = 0x0,
			MajorHardware = 0x10000,
			MajorOperatingSystem = 0x20000,
			MajorSoftware = 0x30000,
			MajorApplication = 0x40000,
			MajorSystem = 0x50000,
			MajorPower = 0x60000,
			MajorLegacyAPI = 0x70000,
			MinorOther = 0x0,
			MinorNone = 0xFF,
			MinorMaintenance = 0x1,
			MinorInstallation = 0x2,
			MinorUpgrade = 0x3,
			MinorReconfig = 0x4,
			MinorHung = 0x5,
			MinorUnstable = 0x6,
			MinorDisk = 0x7,
			MinorProcessor = 0x8,
			MinorNetworkCard = 0x9,
			MinorPowerSupply = 0xA,
			MinorCordUnplugged = 0xB,
			MinorEnvironment = 0xC,
			MinorHardwareDriver = 0xD,
			MinorOtherDriver = 0xE,
			MinorBlueScreen = 0xF,
			MinorServicePack = 0x10,
			MinorHotfix = 0x11,
			MinorSecurityFix = 0x12,
			MinorSecurity = 0x13,
			MinorNetworkConnectivity = 0x14,
			MinorWMI = 0x15,
			MinorServicePackUninstall = 0x16,
			MinorHotfixUninstall = 0x17,
			MinorSecurityFixUninstall = 0x18,
			MinorMMC = 0x19,
			MinorTerminalServer = 0x20,
			Unknown = MinorNone ,
			LegacyAPI = (MajorLegacyAPI | FlagPlanned)
		}
		#endregion

		public static void Shutdown() {
			Shutdown(ShutdownReasons.FlagPlanned);
		}

		public static void Shutdown(ShutdownReasons reasonFlag){
			bool result;
			TokPriv1Luid tp;
			IntPtr hproc = GetCurrentProcess();
			IntPtr htok = IntPtr.Zero;
			result = OpenProcessToken( hproc, TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok );
			tp.Count = 1;
			tp.Luid = 0;
			tp.Attr = SE_PRIVILEGE_ENABLED;
			result = LookupPrivilegeValue( null, SE_SHUTDOWN_NAME, ref tp.Luid );
			result = AdjustTokenPrivileges( htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero );

			result = ExitWindowsEx(exitWindowsFlags.PowerOff | exitWindowsFlags.Shutdown, reasonFlag);
			if( !result ) {
				throw new ApplicationException("Shutdown Failed");
			}
		}

		public static void Logoff(){
			Logoff(ShutdownReasons.FlagPlanned);
		}

		public static void Logoff(ShutdownReasons reasonFlag) {
			bool result;
			result = ExitWindowsEx(exitWindowsFlags.Logoff, reasonFlag);
			if( !result ) {
				throw new ApplicationException("Logoff Failed");
			}
		}
	}
}

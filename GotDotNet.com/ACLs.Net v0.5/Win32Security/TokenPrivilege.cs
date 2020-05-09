using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.Security
{
	using Win32Structs;

	using HANDLE = System.IntPtr;
	using DWORD = System.UInt32;
	using BOOL = System.Int32;
	using LPVOID = System.IntPtr;
	using PSID = System.IntPtr;

	/// <summary>
	/// Summary description for TokenPrivilege.
	/// </summary>
	public class TokenPrivilege
	{
		public const string SE_CREATE_TOKEN_NAME              = "SeCreateTokenPrivilege";
		public const string SE_ASSIGNPRIMARYTOKEN_NAME        = "SeAssignPrimaryTokenPrivilege";
		public const string SE_LOCK_MEMORY_NAME               = "SeLockMemoryPrivilege";
		public const string SE_INCREASE_QUOTA_NAME            = "SeIncreaseQuotaPrivilege";
		public const string SE_UNSOLICITED_INPUT_NAME         = "SeUnsolicitedInputPrivilege";
		public const string SE_MACHINE_ACCOUNT_NAME           = "SeMachineAccountPrivilege";
		public const string SE_TCB_NAME                       = "SeTcbPrivilege";
		public const string SE_SECURITY_NAME                  = "SeSecurityPrivilege";
		public const string SE_TAKE_OWNERSHIP_NAME            = "SeTakeOwnershipPrivilege";
		public const string SE_LOAD_DRIVER_NAME               = "SeLoadDriverPrivilege";
		public const string SE_SYSTEM_PROFILE_NAME            = "SeSystemProfilePrivilege";
		public const string SE_SYSTEMTIME_NAME                = "SeSystemtimePrivilege";
		public const string SE_PROF_SINGLE_PROCESS_NAME       = "SeProfileSingleProcessPrivilege";
		public const string SE_INC_BASE_PRIORITY_NAME         = "SeIncreaseBasePriorityPrivilege";
		public const string SE_CREATE_PAGEFILE_NAME           = "SeCreatePagefilePrivilege";
		public const string SE_CREATE_PERMANENT_NAME          = "SeCreatePermanentPrivilege";
		public const string SE_BACKUP_NAME                    = "SeBackupPrivilege";
		public const string SE_RESTORE_NAME                   = "SeRestorePrivilege";
		public const string SE_SHUTDOWN_NAME                  = "SeShutdownPrivilege";
		public const string SE_DEBUG_NAME                     = "SeDebugPrivilege";
		public const string SE_AUDIT_NAME                     = "SeAuditPrivilege";
		public const string SE_SYSTEM_ENVIRONMENT_NAME        = "SeSystemEnvironmentPrivilege";
		public const string SE_CHANGE_NOTIFY_NAME             = "SeChangeNotifyPrivilege";
		public const string SE_REMOTE_SHUTDOWN_NAME           = "SeRemoteShutdownPrivilege";
		public const string SE_UNDOCK_NAME                    = "SeUndockPrivilege";
		public const string SE_SYNC_AGENT_NAME                = "SeSyncAgentPrivilege";
		public const string SE_ENABLE_DELEGATION_NAME         = "SeEnableDelegationPrivilege";
		public const string SE_MANAGE_VOLUME_NAME             = "SeManageVolumePrivilege";

		private readonly Luid _luid;
		private readonly PrivilegeAttributes _attributes;

		internal TokenPrivilege(MemoryMarshaler m)
		{
			LUID_AND_ATTRIBUTES la = (LUID_AND_ATTRIBUTES)m.ParseStruct(typeof(LUID_AND_ATTRIBUTES));
			_luid = new Luid(la.Luid);
			_attributes = (PrivilegeAttributes)la.Attributes;
		}
		public TokenPrivilege(string systemName, string privilege, bool enabled)
		{
			LUID luid;
			BOOL rc = Win32.LookupPrivilegeValue(systemName, privilege, out luid);
			Win32.CheckCall(rc);

			_luid = new Luid(luid);
			_attributes = (enabled ? PrivilegeAttributes.Enabled : 0);
		}
		public TokenPrivilege(string privilege, bool enabled) :
			this(null, privilege, enabled)
		{
		}
		public Luid Luid
		{
			get
			{
				return _luid;
			}
		}
		public PrivilegeAttributes Attributes
		{
			get
			{
				return _attributes;
			}
		}
		public string Name
		{
			get
			{
				DWORD cchName = 0;
				LUID luid = Luid.GetNativeLUID();
				BOOL rc = Win32.LookupPrivilegeName(null, ref luid, null, ref cchName);
				switch(Marshal.GetLastWin32Error())
				{
					case Win32.SUCCESS:
						throw new ArgumentException("Unexpected return code from LookupPrivilege");
					
					case Win32.ERROR_INSUFFICIENT_BUFFER:
						char[] name = new char[cchName];
						rc = Win32.LookupPrivilegeName(null, ref luid, name, ref cchName);
						Win32.CheckCall(rc);
						return new string(name, 0, (int)cchName);

					default:
						Win32.ThrowLastError();
						return null; // uneeded
				}
			}
		}
		public unsafe byte[] GetNativeLUID_AND_ATTRIBUTES()
		{
			LUID_AND_ATTRIBUTES la;
			la.Luid = _luid.GetNativeLUID();
			la.Attributes = (uint)_attributes;
			byte[] res = new byte[Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES))];
			fixed(byte *luida = res)
			{
				Marshal.StructureToPtr(la, (IntPtr)luida, false);
			}
			return res;
		}
	}
}

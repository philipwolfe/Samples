using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.Security;

namespace TestSecurity
{
	class Win32API
	{
		[DllImport("kernel32.dll", CallingConvention=CallingConvention.Winapi, SetLastError=true, CharSet=CharSet.Auto)]
		public static extern IntPtr CreateEvent(
			[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(SecurityAttributesMarshaler))]
			SecurityAttributes lpEventAttributes, // SA
			[In, MarshalAs(UnmanagedType.Bool)]
			bool bManualReset,                    // reset type
			[In, MarshalAs(UnmanagedType.Bool)]
			bool bInitialState,                   // initial state
			string lpName                         // object name
			);

	}

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestClass
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			TestGetSecurityInfo();
			TestRegistry();

            TestFileSec();
			TestSetFileSec();
            TestSecDesc();
		}
		/// <summary>
		///  Read the security descriptor of "c:\boot.ini" and display the sid of 
		///  each ACE of the DACL
		/// </summary>
		static void TestFileSec()
		{
			string filename = @"C:\boot.ini";
			SecurityDescriptor secDesc = SecurityDescriptor.GetFileSecurity(
				filename, 
				SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
			using(secDesc)
			{
				foreach(Ace ace in secDesc.Dacl)
				{
                    Console.WriteLine("ACE SID:        {0} ", ace.Sid.CanonicalName);
                    Console.WriteLine("ACE Type:       {0} ", ace.Type);
                    Console.WriteLine("ACE AccessType: {0} (0x{0:X})", (FileAccessType)ace.AccessType);
                }
			}
		}
		/// <summary>
		///  Read the security descriptor of "c:\boot.ini" and display the sid of 
		///  each ACE of the DACL
		/// </summary>
		static void TestSetFileSec ()
		{
			string filename = @"C:\boot.ini";
			SecurityDescriptor secDesc = SecurityDescriptor.GetFileSecurity (filename, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
			Dacl dacl = secDesc.Dacl;
			dacl.AddAce (new AceAccessAllowed (new Sid ("Administrator"), AccessType.GENERIC_ALL));

			//
			secDesc.SetDacl(dacl);

			// Uncomment this to actually apply the new DACL
			//secDesc.SetFileSecurity(filename, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
		}

		/// <summary>
		///  Create a named event with a specific security descriptor,
		///  then use GetKernelObjectSecurity to retrieve the security descriptor
		///  of the created event and display Owner, Group and DACL.
		/// </summary>
		static void TestSecDesc()
		{
			// Create DACL
			Dacl dacl = new Dacl();
			dacl.AddAce(new AceAccessAllowed(new Sid("Administrator"), AccessType.GENERIC_ALL));
			dacl.AddAce(new AceAccessDenied(Sids.RestrictedCode, AccessType.GENERIC_READ));
			dacl.AddAce(new AceAccessAllowed(Sids.AuthenticatedUser, AccessType.GENERIC_READ));
			dacl.AddAce(new AceAccessDenied(new Sid("guest"), AccessType.GENERIC_ALL));

			// Create Sec Desc
			using(SecurityDescriptor sd = new SecurityDescriptor())
			{
				sd.Owner = GetCurrentProcessUser();
				sd.Group = Sids.World;
				sd.Dacl = dacl;

				// Create Sec Attrs
				SecurityAttributes sa = new SecurityAttributes();
				sa.SecurityDescriptor = sd;

				// Create our named event
				IntPtr handle = Win32API.CreateEvent(sa, false, true, "test");
				Win32.CheckCall(handle);
				try
				{
					// Display owner, group and dacl information
					// List the SACL would require the SE_SECURITY_NAME privilege.
					Console.WriteLine ("Event object security information");
					SecurityDescriptor sdo = SecurityDescriptor.GetKernelObjectSecurity(handle);
					using(sdo)
					{
						Console.WriteLine ("Owner: {0}", sdo.Owner.CanonicalName);
						Console.WriteLine ("Group: {0}", sdo.Group.CanonicalName);
						foreach(Ace ace in sdo.Dacl)
						{
							Console.WriteLine("ACE SID:        {0} ", ace.Sid.CanonicalName);
							Console.WriteLine("ACE Type:       {0} ", ace.Type);
							Console.WriteLine("ACE AccessType: {0} (0x{0:X})", (EventAccessType)ace.AccessType);
						}
					}
				}
				finally
				{
					// Close it...
					Win32.CloseHandle(handle);
				}
			}
		}
		/// <summary>
		///  Return the SID of the user associated to the current process.
		/// </summary>
		/// <returns></returns>
		public static Sid GetCurrentProcessUser()
		{
			using (AccessToken at = new AccessTokenProcess(
					   System.Diagnostics.Process.GetCurrentProcess().Id,
					   TokenAccessType.TOKEN_QUERY))
			{
				return at.User;
			}
		}
		public static void TestGetSecurityInfo()
		{
			int rc;
			IntPtr hKey;
			rc = Win32.RegOpenKey(Win32Consts.HKEY_LOCAL_MACHINE, @"Software", out hKey);
			if (rc != Win32.SUCCESS)
			{
				Win32.SetLastError((uint)rc);
				Win32.ThrowLastError();
			}

			try
			{
				Console.WriteLine ("\"HKLM\\Software\" Security information");

				SecurityDescriptor sd = SecurityDescriptor.GetSecurityInfo (
					hKey, 
					SE_OBJECT_TYPE.SE_REGISTRY_KEY,
					SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | 
					SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | 
					SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION);

				using (sd)
				{
					Console.WriteLine ("Owner: {0}", sd.Owner.CanonicalName);
					Console.WriteLine ("Group: {0}", sd.Group.CanonicalName);
					foreach (Ace ace in sd.Dacl)
					{
						Console.WriteLine("ACE SID:        {0} ", ace.Sid.CanonicalName);
						Console.WriteLine("ACE Type:       {0} ", ace.Type);
						Console.WriteLine("ACE AccessType: {0} (0x{0:X})", (FileAccessType)ace.AccessType);
					}
				}
				//UpdateRegKeyDacl (hKey);
			}
			finally
			{
				Win32.RegCloseKey(hKey);
			}
		}

        public static void TestRegistry()
        {
			int rc;
            IntPtr hKey;
			rc = Win32.RegOpenKey(Win32Consts.HKEY_LOCAL_MACHINE, @"Software", out hKey);
			if (rc != Win32.SUCCESS)
			{
				Win32.SetLastError((uint)rc);
				Win32.ThrowLastError();
			}

			try
			{
				Console.WriteLine ("\"HKLM\\Software\" Security information");

				SecurityDescriptor sd = SecurityDescriptor.GetRegistryKeySecurity (
					hKey, 
					SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | 
					SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | 
					SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION);
				using (sd)
				{
					Console.WriteLine ("Owner: {0}", sd.Owner.CanonicalName);
					Console.WriteLine ("Group: {0}", sd.Group.CanonicalName);
					foreach (Ace ace in sd.Dacl)
					{
						Console.WriteLine("ACE SID:        {0} ", ace.Sid.CanonicalName);
						Console.WriteLine("ACE Type:       {0} ", ace.Type);
						Console.WriteLine("ACE AccessType: {0} (0x{0:X})", (FileAccessType)ace.AccessType);
					}
				}
				//UpdateRegKeyDacl (hKey);
			}
			finally
			{
				Win32.RegCloseKey(hKey);
			}
        }
        public static void UpdateRegKeyDacl(IntPtr hKey)
        {
            SecurityDescriptor sd = SecurityDescriptor.GetRegistryKeySecurity (hKey, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
            Dacl acl = sd.Dacl;
            acl.AddAce (new AceAccessAllowed(Sids.AnonymousLogon, AccessType.GENERIC_READ));
            sd.SetDacl(acl);
            sd.SetRegistryKeySecurity (hKey, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION);
        }
	}
}

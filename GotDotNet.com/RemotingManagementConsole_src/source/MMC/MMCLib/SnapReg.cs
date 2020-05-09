using System;
using System.Runtime;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Ironring.Management.MMC
{
	class SnapinRegistrar
	{
		public static void Register()
		{
			// ok start the big hunt
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
				Register(a);
		}
		public static void Register(Assembly a)
		{
			SnapReg reg = new SnapReg();
			reg.Register(a);
		}
			
		public static void UnRegister()
		{
			// ok start the big hunt
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
				UnRegister(a);
		}

		public static void UnRegister(Assembly a)
		{
			SnapReg reg = new SnapReg();
			reg.UnRegister(a);
		}
	}

    class SnapinRegInfo
    {
        public SnapinRegInfo()
        {
        }

        public Type fSnapinType;
        public string fGUID;
        public SnapinInAttribute fAttrib;
        public SnapinAboutRegistration fAboutReg;
    }


    class SnapinAboutRegistration
    {
        public SnapinAboutRegistration()
        {
        }

        public string fGUID;
        public AboutSnapinAttribute fAboutAttrib;
    }
    
    /// <summary>
	/// Summary description for SnapReg
	/// </summary>
	class SnapReg
	{
        ArrayList fSnapinRegInfos = new ArrayList();
        Hashtable fSnapinAboutRegistrations = new Hashtable();

		public void UnRegister(Assembly asm)
		{
			foreach(Type t in asm.GetTypes())
			{
				// must meet these requirements
				if (Marshal.IsTypeVisibleFromCom(t) && t.IsClass && (t.IsPublic || t.IsNestedPublic) && !t.IsImport)
					FindAttributes(t);
			}

			PrepareAttribute();

			UnRegister();
		}

        /// <summary>
        /// Register all snapins in the assemply
        /// </summary>
        /// <param name="asm">the assembly to register</param>
        public void Register(Assembly asm)
        {
            foreach(Type t in asm.GetTypes())
            {
                // must meet these requirements
                if (Marshal.IsTypeVisibleFromCom(t) && t.IsClass && (t.IsPublic || t.IsNestedPublic) && !t.IsImport)
                    FindAttributes(t);
            }

            PrepareAttribute();

			Register();
        }


        /// <summary>
        /// Register this type if it looks like it should be registered!
        /// </summary>
        /// <param name="t">the type</param>
        void FindAttributes(Type t)
        {
            // Creatable class - get Guid and ProgId
            string strClsId = "{" + Marshal.GenerateGuidForType(t).ToString().ToUpper() + "}";

            //////////////////////////////////////////////////////
            // Found a Snapin itself!

            object [] attribs = t.GetCustomAttributes(typeof(SnapinInAttribute), true);
            if (attribs.Length != 0) 
            {
                SnapinInAttribute snapinAttrib = attribs[0] as SnapinInAttribute;
                if (snapinAttrib != null)
                {
                    SnapinRegInfo snapReg = new SnapinRegInfo();
                    
                    snapReg.fAttrib = snapinAttrib;
                    snapReg.fGUID = strClsId.ToUpper();
                    snapReg.fSnapinType = t;
                    fSnapinRegInfos.Add(snapReg);
                }
            }


            //////////////////////////////////////////////////////
            // Found a Snapin About class

            attribs = t.GetCustomAttributes(typeof(AboutSnapinAttribute), true);
            if (attribs.Length != 0) 
            {
                // List the guid from the snapin we are associated with via the AboutSnapinAttribute

                AboutSnapinAttribute aboutAttrib = attribs[0] as AboutSnapinAttribute;
                if (aboutAttrib != null)
                {
                    SnapinAboutRegistration AboutReg = new SnapinAboutRegistration();
                    AboutReg.fAboutAttrib = aboutAttrib;
                    AboutReg.fGUID = strClsId.ToUpper();
                    fSnapinAboutRegistrations.Add(aboutAttrib.SnapinType.ToString(), AboutReg);
                }
            }
        }

        //match up the snapin with the snapin abouts
        void PrepareAttribute()
        {
            foreach(SnapinRegInfo snapin in fSnapinRegInfos)
            {            
                SnapinAboutRegistration aboutReg = fSnapinAboutRegistrations[snapin.fSnapinType.ToString()] as SnapinAboutRegistration;
                if (aboutReg == null)
                    throw new ApplicationException("Failed to locate a Snapin About object for the snapin: " + snapin.fSnapinType.ToString());

                snapin.fAboutReg = aboutReg;
            }
        }

        // we have all the data and its valid so go ahead and run it into the registry
        void Register()
        {
            foreach(SnapinRegInfo snapin in fSnapinRegInfos)
            {         
                RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\MMC\\Snapins", true);

                key = key.CreateSubKey(snapin.fGUID);

                // the name 
                key.SetValue("NameString", snapin.fAttrib.Namestring);

                // the CLSID for the ISnapinAbout implementation
                key.SetValue("About", snapin.fAboutReg.fGUID);

                // the snadalone attribute
                if (snapin.fAttrib.StandAlone)
                    key.CreateSubKey("StandAlone");

            }
        }

		void UnRegister()
		{
			foreach(SnapinRegInfo snapin in fSnapinRegInfos)
			{        
				try
				{
					RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\MMC\\Snapins", true);
					key.DeleteSubKeyTree(snapin.fGUID);
				}
				catch(ArgumentException)
				{
				}
				catch (System.Security.SecurityException)
				{
				}
			}
		}
    }
}

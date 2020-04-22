using System;
using System.Collections;
using System.Windows.Forms;
using System.Reflection;

namespace Microsoft.PDC01Demo.PropSheetHandler
{
/// <summary>
/// Helper class that will be created inside helper AppDomain
/// and handle all assembly loading for us. Needs to inherit from
/// MarshalByRefObject so it can be used across AppDomains.
/// </summary>

public class AssemblyHelper : MarshalByRefObject
{
//	private Hashtable loaded = new Hashtable();		// keep track of loaded assemblies because of circular references

	//-------------------------------------------------
	//-------------------------------------------------
	public AssemblyName[] GetNames(string filename, out AssemblyName asmName)
	{
//		APIWrapper.MessageBox(0, filename, "", 0);

		Assembly asm = Assembly.LoadFrom(filename); 
		asmName = asm.GetName();
		return asm.GetReferencedAssemblies();
	}

	//-------------------------------------------------
	//-------------------------------------------------
	public AssemblyName[] GetNames(AssemblyName asmName, ref string version)
	{
//		string msg = asmName.FullName + " references: ";

		version = null;
		Assembly asm = Assembly.Load(asmName);
 
		if(asmName.Version != asm.GetName().Version)
			version = asm.GetName().Version.ToString();
/*
		if(loaded.Contains(asmName.FullName))
		{
//			APIWrapper.MessageBox(0, "Contains " + asmName.FullName, "", 0);
			return new AssemblyName[0];
		}
		else
		{
//			APIWrapper.MessageBox(0, "Doesn't contain " + asmName.FullName, "", 0);
			loaded.Add(asmName.FullName, null);
		}
*/
/*
		foreach(AssemblyName name in asm.GetReferencedAssemblies())
		{
			msg += name.Name + ", ";
		}
		APIWrapper.MessageBox(0, msg, "", 0);
*/
		return asm.GetReferencedAssemblies();
	}

}
} // namespace Microsoft.PDC01Demo.PropSheetHandler

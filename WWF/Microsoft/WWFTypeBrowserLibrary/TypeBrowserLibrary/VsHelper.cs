using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using EnvDTE;
using System.Xml;
using System.Diagnostics;

namespace TypeBrowserLibrary
{
	/// <summary>
	/// Helper methods to deal with DTE to VSIP project model conversions.
	/// </summary>
	public static class VsHelper
	{
		public static IVsHierarchy GetCurrentHierarchy(IServiceProvider provider)
		{
			DTE vs = (DTE)provider.GetService(typeof(DTE));
			if (vs == null) throw new InvalidOperationException("DTE not found.");

			return ToHierarchy(vs.SelectedItems.Item(1).ProjectItem.ContainingProject);
		}

		public static IVsHierarchy ToHierarchy(EnvDTE.Project project)
		{
			if (project == null) throw new ArgumentNullException("project");

			string projectGuid = null;

			// DTE does not expose the project GUID that exists at in the msbuild project file.
			// Cannot use MSBuild object model because it uses a static instance of the Engine, 
			// and using the Project will cause it to be unloaded from the engine when the 
			// GC collects the variable that we declare.
			using (XmlReader projectReader = XmlReader.Create(project.FileName))
			{
				projectReader.MoveToContent();
				object nodeName = projectReader.NameTable.Add("ProjectGuid");
				while (projectReader.Read())
				{
					if (Object.Equals(projectReader.LocalName, nodeName))
					{
						projectGuid = projectReader.ReadElementContentAsString();
						break;
					}
				}
			}

			Debug.Assert(!String.IsNullOrEmpty(projectGuid));

			IServiceProvider serviceProvider = new ServiceProvider(project.DTE as
				Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
			
			return VsShellUtilities.GetHierarchy(serviceProvider, new Guid(projectGuid));
		}

		public static IVsProject3 ToVsProject(EnvDTE.Project project)
		{
			if (project == null) throw new ArgumentNullException("project");

			IVsProject3 vsProject = ToHierarchy(project) as IVsProject3;

			if (vsProject == null)
			{
				throw new ArgumentException("Project is not a VS project.");
			}

			return vsProject;
		}

		public static EnvDTE.Project ToDteProject(IVsHierarchy hierarchy)
		{
			if (hierarchy == null) throw new ArgumentNullException("hierarchy");

			object prjObject = null;
			if (hierarchy.GetProperty(0xfffffffe, -2027, out prjObject) >= 0)
			{
				return (EnvDTE.Project)prjObject;
			}
			else
			{
				throw new ArgumentException("Hierarchy is not a project.");
			}
		}

		public static EnvDTE.Project ToDteProject(IVsProject project)
		{
			if (project == null) throw new ArgumentNullException("project");

			return ToDteProject(project as IVsHierarchy);
		}

		public static IServiceProvider GetProjectServiceProvider(IVsHierarchy hierarchy)
		{
			if (hierarchy == null) throw new ArgumentNullException("hierarchy");
			
			Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleProvider;
			if (hierarchy.GetSite(out oleProvider) >= 0)
			{
				return new ServiceProvider(oleProvider);
			}
			else
			{
				throw new ArgumentException("Hierarchy is not sited.");
			}
		}

		public static IServiceProvider GetProjectServiceProvider(IVsProject project)
		{
			if (project == null) throw new ArgumentNullException("project");
			
			return GetProjectServiceProvider(project as IVsHierarchy);
		}

		public static IServiceProvider GetProjectServiceProvider(EnvDTE.Project project)
		{
			return GetProjectServiceProvider(ToHierarchy(project));
		}
	}
}

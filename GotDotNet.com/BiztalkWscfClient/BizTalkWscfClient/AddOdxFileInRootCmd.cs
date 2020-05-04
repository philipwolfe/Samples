using System.IO;
using EnvDTE;

namespace BizTalkWscfClient
{
	/// <summary>
	/// Implements the add odx file logic specific to
	/// the case when the file is added to the project root.
	/// </summary>
	public class AddOdxFileInRootCmd : IAddOdxFileCommand
	{
		Project project;

		public AddOdxFileInRootCmd(Project project)
		{
			this.project = project;
		}

		public string TargetDir
		{
			get { return Path.GetDirectoryName(project.FullName) + "\\"; }
		}

		public Project Project
		{
			get { return project; }
		}

		public void AddOdxFile(string filePath)
		{
			project.ProjectItems.AddFromFile(filePath);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is AddOdxFileInRootCmd))
			{
				return false;
			}

			return ((AddOdxFileInRootCmd) obj).TargetDir == TargetDir;
		}

		// overwritten because of the warning from compiler, I don't care
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

	}
}

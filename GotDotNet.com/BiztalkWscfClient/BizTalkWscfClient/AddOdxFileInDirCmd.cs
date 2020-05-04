using EnvDTE;

namespace BizTalkWscfClient
{
	/// <summary>
	/// Implements the add odx file logic specific to
	/// the case when the file is added to a directory from a project.
	/// </summary>
	public class AddOdxFileInDirCmd : IAddOdxFileCommand
	{
		private ProjectItem dir;

		public AddOdxFileInDirCmd(ProjectItem dir)
		{
			this.dir = dir;
		}

		public string TargetDir
		{
			get { return dir.get_FileNames(0); }
		}

		public Project Project
		{
			get { return dir.Collection.ContainingProject; }
		}

		public void AddOdxFile(string filePath)
		{
			dir.ProjectItems.AddFromFile(filePath);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || !(obj is AddOdxFileInDirCmd))
			{
				return false;
			}

			return ((AddOdxFileInDirCmd) obj).TargetDir == TargetDir;
		}

		// overwritten because of the warning from compiler, I don't care
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}
	}
}

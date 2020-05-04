using EnvDTE;

namespace BizTalkWscfClient
{
	/// <summary>
	/// Command used to create the .
	/// </summary>
	public interface IAddOdxFileCommand
	{
		/// <summary>
		/// The directory from where the file must be added,
		/// must end with '\'
		/// </summary>
		string TargetDir
		{
			get;
		}

		/// <summary>
		/// The project object to which the file will belong.
		/// </summary>
		Project Project
		{
			get;
		}
		
		/// <summary>
		/// Adds an odx file to the active project.
		/// </summary>
		/// <param name="filePath">The full path of the odx file.</param>
		void AddOdxFile(string filePath);
	}
}

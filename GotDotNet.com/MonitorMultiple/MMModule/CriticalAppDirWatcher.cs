using System;
using System.IO;

namespace MMModule
{
	internal sealed class CriticalAppDirWatcher
	{
		private FileSystemEventHandler callback;
		private PathConfig[] paths;

		internal CriticalAppDirWatcher( FileSystemEventHandler callback)
		{
			this.callback = callback;
			CreateWatchers();
		}

		private void ChangeHappened(object sender, FileSystemEventArgs e)
		{
			callback(sender, e);
		}

		private void RenameHappened(object sender, RenamedEventArgs e)
		{
			FileSystemEventArgs args = new FileSystemEventArgs( e.ChangeType, e.OldFullPath, e.OldName);
			ChangeHappened(sender, args);
		}

		private void CreateWatchers()
		{			
			FileSystemEventHandler handler = new FileSystemEventHandler(ChangeHappened);
			RenamedEventHandler renameHandler = new RenamedEventHandler(RenameHappened);
			paths = (PathConfig[])System.Configuration.ConfigurationSettings.GetConfig("MMModulePaths");			
			foreach(PathConfig path in paths)
			{
				foreach(string extension in path.extensions)
				{
					FileSystemWatcher fw = new FileSystemWatcher();
					fw.Path = path.fullPath;
					fw.Filter = "*." + extension;
					if(path.checkChange)
						fw.Changed += handler;				
					if(path.checkRename)
						fw.Renamed += renameHandler;
					if( path.checkCreate)
						fw.Created += handler;				
					fw.EnableRaisingEvents = true;				
				}
			}			
		}		
		
	}
}

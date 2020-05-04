#region Copyright MarketXS B.V. 2005

/* This code is distributed under the GNU Library General Public License.

http://www.gnu.org/copyleft/lgpl.html

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Library General Public
License as published by the Free Software Foundation; either
version 2 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Library General Public License for more details.

You should have received a copy of the GNU Library General Public
License along with this library; if not, write to the
Free Software Foundation, Inc., 59 Temple Place - Suite 330,
Boston, MA  02111-1307, USA.

Written by Zbigniew Babiej, zbabiej@yahoo.com.

*/

#endregion

#region Using

using System;
using System.IO;
using System.Resources;
using System.Security.Permissions;

#endregion

namespace TZ4Net
{
	/// <summary>
	/// Argumens class of <see cref="ZoneInfoResGenMessageHandler"/> delegate.
	/// </summary>
	public class ZoneInfoResGenUpdateArgs : System.EventArgs 
	{
		#region Fields

		/// <summary>
		/// Caches the message to be reported to the listeners;
		/// </summary>
		private string fileName;

		#endregion

		#region Constructors

		public ZoneInfoResGenUpdateArgs(string fileName) 
		{
			this.fileName = fileName;
		}

		#endregion

		/// <summary>
		/// Gets the message to be reported to the listeners;
		/// </summary>
		public string FileName
		{
			get 
			{
				return fileName;
			}
		}
	}

	/// <summary>
	/// Handler for the Message event of the <see cref="ZoneInfoResGen"/> class.
	/// </summary>
	public delegate void ZoneInfoResGenUpdateHandler(object sender, ZoneInfoResGenUpdateArgs args);

	/// <summary>
	/// Utility class that generates the .NET resource containig zoneinfo files.
	/// </summary>
	public class ZoneInfoResGen
	{
		#region Public interface

		/// <summary>
		/// Informs the clients about the generation progress. Fired when new zoneinfo file was added to resources.
		/// </summary>
		public static event  ZoneInfoResGenUpdateHandler Added;

		/// <summary>
		/// Informs the clients about the generation progress. Fired when file from zoneinfo dir was ommitted because of lack of 'TZIf' header.
		/// </summary>
		public static event  ZoneInfoResGenUpdateHandler Skipped;

		/// <summary>
		/// Informs the clients about the generation progress. Fired after resource file was generated.
		/// </summary>
		public static event  ZoneInfoResGenUpdateHandler Generated;

		/// <summary>
		/// This method scans the zoneinfo directory and its subdirectories and puts
		/// all found zoneinfo files into .NET resource file named zoneinfo.resources.
		/// </summary>
		/// <param name="zoneinfoDir">The zoneinfo directory.</param>
		/// <param name="resourcePath">Output directory of the .NET resource file to be generated.</param>
		[FileIOPermission(SecurityAction.Demand)]
		public static void Generate(string zoneinfoDir, string resourceDir)
		{
			DirectoryInfo zoneinfoDirInfo = new DirectoryInfo(zoneinfoDir);
			if (!zoneinfoDirInfo.Exists) 
			{
				throw new ArgumentException(string.Format("Input zoneinfo directory does not exist ({0}).", zoneinfoDir, "zoneinfoDir"));
			}

			DirectoryInfo resourceDirInfo = new DirectoryInfo(resourceDir);
			if (!resourceDirInfo.Exists) 
			{
				throw new ArgumentException(string.Format("Output resource directory does not exist ({0}).", resourceDir, "resourceDir"));
			}

			string resourceFile = string.Format("{0}\\{1}", resourceDir, ZoneInfo.ResourceFileName);
			ResourceWriter writer = new ResourceWriter(resourceFile);
			Generate(writer, zoneinfoDirInfo, null);
			writer.Generate();
			writer.Close();
			System.Diagnostics.Trace.Assert(File.Exists(resourceFile), "Resource file does not exist.");
			OnGenerated(resourceFile);
		}

		#endregion

		#region Implementation

		/// <summary>
		/// Gets the resource file name. Name it taken from <see cref="ZoneInfo"/> class.
		/// </summary>
		internal static string ResourceFileName
		{
				get 
				{
					return ZoneInfo.ResourceFileName;
				}
		}

		/// <summary>
		/// Helper recursive method which adds all zoneinfo files from the input directory to the given resource writer.
		/// </summary>
		/// <param name="writer">Resource writer to add zoneinfo files to.</param>
		/// <param name="dir">Directory info of the directory to be processed.</param>
		/// <param name="prefix">The prefix to add to each resource name.</param>
		private static void Generate(ResourceWriter writer, DirectoryInfo dir, string prefix) 
		{
			FileInfo[] files = dir.GetFiles();
			foreach(FileInfo file in files) 
			{
				FileStream stream = null;
				try 
				{
					stream = file.Open(FileMode.Open, FileAccess.Read);
					byte[] buf = new byte[stream.Length];
					stream.Position = 0;
					int bytesRead = stream.Read(buf, 0, buf.Length);
					System.Diagnostics.Trace.Assert(bytesRead == buf.Length);
					if (buf[0] == 84 && buf[1] == 90 && buf[2] == 105 && buf[3] == 102) // "TZif" signature
					{
						writer.AddResource(prefix == null ? file.Name : string.Format("{0}/{1}", prefix, file.Name), buf);
						OnAdded(file.FullName);
					} 
					else 
					{
						OnSkipped(file.FullName);
					}
				} 
				finally 
				{
					if (stream != null) 
					{
						stream.Close();
					}
				}
			}
			DirectoryInfo[] subDirs = dir.GetDirectories();
			foreach(DirectoryInfo subDir in subDirs) 
			{
				Generate(writer, subDir, prefix == null ? subDir.Name : string.Format("{0}/{1}", prefix, subDir.Name));
			}

		}

		/// <summary>
		/// Propagates the message to all listeners about added zoneinfo file.
		/// </summary>
		/// <param name="message">Name of the zoneinfo file which was addded to resources.</param>
		private static void OnAdded(string fileName) 
		{
			if (Added != null) 
			{
				Added(typeof(ZoneInfoResGen), new ZoneInfoResGenUpdateArgs(fileName));
			}
		}

		/// <summary>
		/// Propagates the message to all listeners about skipped file from zoneinfo directory.
		/// </summary>
		/// <param name="message">Name of the file which was skipped.</param>
		private static void OnSkipped(string fileName) 
		{
			if (Skipped != null) 
			{
				Skipped(typeof(ZoneInfoResGen), new ZoneInfoResGenUpdateArgs(fileName));
			}
		}

		/// <summary>
		/// Propagates the message to all listeners about new resource file being generated.
		/// </summary>
		/// <param name="message">Name of the newly generated resource file.</param>
		private static void OnGenerated(string fileName) 
		{
			if (Generated != null) 
			{
				Generated(typeof(ZoneInfoResGen), new ZoneInfoResGenUpdateArgs(fileName));
			}
		}

		#endregion
	}
}

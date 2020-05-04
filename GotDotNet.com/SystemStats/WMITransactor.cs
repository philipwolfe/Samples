using System;
using System.Management;
using System.Collections;

namespace SystemStats
{
	internal class WMITransactor
	{
		private static string scopePath = @"\\localhost\root\cimv2";

		public WMITransactor()
		{
		}

		public ArrayList ProcessTransaction(WMITransactionType type)
		{
			switch (type)
			{
				case WMITransactionType.OperatingSystem :
					return ProcessTransactionCore(scopePath, @"SELECT * FROM Win32_OperatingSystem", new string[][] {
						new string[] { "Operating System", "Caption" }, new string[] { "Version", "Version" }, new string[] { "Manufacturer", "Manufacturer" }, new string[] { "Computer Name", "csname" }, new string[] { "Windows Directory", "WindowsDirectory" }, new string[] { "Serial Number", "SerialNumber" }
					});

				case WMITransactionType.ComputerSystem :
					return ProcessTransactionCore(scopePath, @"SELECT * FROM Win32_ComputerSystem", new string[][] {
						new string[] { "Computer Manufacturer Name", "Manufacturer" }, new string[] { "Computer Model", "model" }, new string[] { "System Type", "SystemType" }, new string[] { "Total Physical Memory", "totalphysicalmemory" }, new string[] { "Domain", "Domain" }, new string[] { "User Name", "UserName" }
					});

				case WMITransactionType.SystemProcessor :
					return ProcessTransactionCore(scopePath, @"SELECT * FROM Win32_processor", new string[][] {
						new string[] { "Manufacturer", "Manufacturer" }, new string[] { "Computer Processor", "Caption" }, new string[] { "CPU Speed", "MaxClockSpeed" }, new string[] { "L2 Cache Size", "L2CacheSize" }
					});

				case WMITransactionType.VideoController :
					return ProcessTransactionCore(scopePath, @"SELECT * FROM Win32_VideoController", new string[][] {
						new string[] { "Name", "Name" }, new string[] { "Processor", "VideoProcessor" }, new string[] { "Mode", "VideoModeDescription" }, new string[] { "Video Ram", "AdapterRAM" }, new string[] { "PNP Device ID", "PNPDeviceID" }, new string[] { "Status", "Status" }
					});

				case WMITransactionType.Processes:
					return ProcessTransactionCore(scopePath, @"SELECT * FROM Win32_Process", new string[][] {
						new string[] { "Name", "Name" }, new string[] { "ID", "ProcessID" }, new string[] { "Parent", "ParentProcessID" }
					});
			}
			// Default
			return new ArrayList(0);
		}

		private ArrayList ProcessTransactionCore(string scope, string query, string[][] properties)
		{
			ArrayList list = new ArrayList();
			ManagementScope ms = new ManagementScope(scope);
			ObjectQuery oq = new ObjectQuery(query);
			ManagementObjectSearcher searcher = new ManagementObjectSearcher(ms, oq);;
			ManagementObjectCollection collection = searcher.Get();

			foreach(ManagementObject mo in collection)
			{
				foreach(string[] property in properties)
				{
					if(property.Length == 2 && property[0] != null && property[1] != string.Empty)
					{
						list.Add(property[0] + ": " + mo[property[1]]);
					}
				}
			}

			return list;
		}
	}

	internal enum WMITransactionType
	{
		OperatingSystem = 0,
		ComputerSystem,
		SystemProcessor,
		VideoController,
		Processes
	}
}
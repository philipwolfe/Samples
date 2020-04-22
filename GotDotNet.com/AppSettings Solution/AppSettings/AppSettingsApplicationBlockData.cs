//===============================================================================
// Robert Kokuti's AppSettings Application Block for 
//===============================================================================
// Robert Kokuti's AppSettings Application Block for 
// Microsoft patterns & practices Enterprise Library
// Comments? send to robertkokuti@hotmail.com
// Shared Library
//===============================================================================
// Copyright © Robert Kokuti.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;

using Microsoft.Practices.EnterpriseLibrary.Configuration;

namespace Kokuti.EnterpriseLibrary.AppSettings
{
	/// <summary>
	/// Summary description for AppSettingsData.
	/// </summary>
	[Serializable]
	public class AppSettingsData
	{
		private string _Key = string.Empty;
		private string _Value = string.Empty;
	
		public AppSettingsData(){}
		public AppSettingsData(string settingName, string settingValue)
		{
			this.Key = settingName;
			this.Value = settingValue;
		}

		[Category("Key/Value pairs - keep Key unique!")]
		[XmlAttribute("key")]
		public string Key
		{
			get
			{
				return _Key;
			}
			set
			{
				_Key = value;
			}
		}
		
		[Category("Key/Value pairs - keep Key unique!")]
		[XmlAttribute("value")]
		public string Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = value;
			}
		}
		
		public override string ToString()
		{
			const int maxValueLen = 15;
			string valueString = (this.Value.Length > maxValueLen) ? 
				this.Value.Substring(0, maxValueLen - 3) + "..." : 
				this.Value;
			
			return this.Key + ": " + valueString;
		}
	}

	[Serializable]
	[Description("Collection of key/value pairs"),
	Category("Key/Value pairs")]
	public class AppSettingsApplicationBlockData : CollectionBase
	{
		public const string SectionName = "AppSettingsApplicationBlockSection";

		#region collection implementation
		/// <summary>
		/// Adds/updates AppSettingData to the collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public  int Add( AppSettingsData value )  
		{
			lock (List.SyncRoot)
			{
				int index = Find( value.Key );
				if (index > -1)
					List[index] = value;
				else
					index = List.Add(value);
				return index;
			}
		}


		/// <summary>
		/// Default accessor required by the Xml serializer
		/// </summary>
		public AppSettingsData this[ int index ]  
		{
			get  
			{
				lock (this.SyncRoot)
				{
					return( (AppSettingsData) List[index] );
				}
			}
		}

		#endregion
		
		/// <summary>
		/// object to use for thread safe access
		/// </summary>
		public object SyncRoot
		{
			get
			{
				return List.SyncRoot;
			}
		}

		private int Find(string key)
		{
			lock (this.SyncRoot)
			{
				for (int i = 0; i < List.Count; i++)
				{
					if (((AppSettingsData)List[i]).Key == key)
					{
						return i; 
					}
				}
				return -1;
			}
		}

		public void Remove( AppSettingsData value )  
		{
			lock (this.SyncRoot)
			{
				int i = Find(value.Key);
				if (i > -1)
				{
					RemoveAt(i); 
					Remove(value); // remove possible others as well
				}
			}
		}


		/// <summary>
		/// provides HashTable style access to key/value pairs in AppSettingsApplicationBlock.
		/// </summary>
		[XmlIgnore()]
		public string this[ string key ]  
		{
			get  
			{
				lock (this.SyncRoot)
				{
					int index = Find(key);
					if (index > -1)
						return this[index].Value;
					else
						return string.Empty;
				}
			}
			set  
			{
				lock (this.SyncRoot)
				{
					int index = Find(key);
					if (index > -1)
						this[index].Value = value;
					else
						this.List.Add(new AppSettingsData(key, value));
				}
			}
		}
	}

}


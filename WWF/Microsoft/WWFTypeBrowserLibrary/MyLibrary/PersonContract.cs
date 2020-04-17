using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace MyLibrary
{
	[DataContract]
	public class PersonContract
	{
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}

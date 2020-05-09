using System;

namespace CustomAttributes
{
	/// <summary>
	/// Define Assembly author and contact information
	/// </summary>
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple=true)] 
	public class AssemblyAuthorAttribute : System.Attribute {
		private string _author;
		private string _contact;

		public AssemblyAuthorAttribute(string author) {
			this._author = author;
		}

		public string Author {
			get { return this._author; }
		}

		public string Contact {
			get { return this._contact; }
			set { this._contact = value; }
		}


	}
}

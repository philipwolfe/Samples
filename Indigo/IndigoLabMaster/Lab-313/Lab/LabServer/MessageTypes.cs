using System;
using System.MessageBus;
using System.MessageBus.Services;

namespace LabServer.MessageTypes
{
	[MessageAttribute(Namespace = "uri:LabServer:Types")]
	public class RegisterType: System.MessageBus.Services.TypedMessage
	{
		public int _StudentId;
		public string _name;
		public string _machineName;
		public string _emailName;

		public RegisterType() : base()
		{ }

		public RegisterType(string name, string machineName)
		{
			_name = name;
			_machineName = machineName;
		}
		
		public int StudentId
		{
			get { return this._StudentId; }
			set { this._StudentId = value; }
		}

		public string EmailName
		{
			get { return this._emailName; }
			set { this._emailName = value; }
		}

		[MessageBodyAttribute]
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		[MessageBodyAttribute]
		public string MachineName
		{
			get { return this._machineName; }
			set { this._machineName = value; }
		}
	}

	[MessageAttribute(Namespace = "uri:LabServer:Types")]
	public class RegisterResponseType: System.MessageBus.Services.TypedMessage
	{
		public string _password
		;
		public RegisterResponseType() : base()
		{ }
		public RegisterResponseType(string password)
		{
			_password = password;
		}
		[MessageBodyAttribute]
		public string Password
		{
			get { return this._password; }
			set { this._password = value; }
		}
	}
}

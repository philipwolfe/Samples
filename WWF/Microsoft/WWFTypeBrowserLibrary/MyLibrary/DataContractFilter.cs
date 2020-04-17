using System;
using System.Workflow.ComponentModel.Design;
using System.Runtime.Serialization;

namespace MyLibrary
{
	public class DataContractFilter : ITypeFilterProvider
	{
		public DataContractFilter()
		{
		}

		public DataContractFilter(IServiceProvider provider)
		{
			// Constructor required by the dialog.
		}

		#region ITypeFilterProvider Members

		public bool CanFilterType(Type type, bool throwOnError)
		{
			bool isDataContract = type.IsPublic && Attribute.IsDefined(type, typeof(DataContractAttribute));
			if (throwOnError && !isDataContract)
			{
				throw new ArgumentException("Type is not a data contract.");
			}

			return isDataContract;
		}

		public string FilterDescription
		{
			get { return "types that have DataContractAttribute"; }
		}

		#endregion
	}
}

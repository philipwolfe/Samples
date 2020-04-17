using System;
using System.Workflow.ComponentModel.Design;

namespace TypeBrowserLibrary
{
	public class ValueTypeFilter : ITypeFilterProvider
	{
		public ValueTypeFilter()
		{
		}

		public ValueTypeFilter(IServiceProvider provider)
		{
		}

		#region ITypeFilterProvider Members

		public bool CanFilterType(Type type, bool throwOnError)
		{
			if (throwOnError && !type.IsValueType)
			{
				throw new ArgumentException("Type is not a value type.");
			}

			return type.IsValueType;
		}

		public string FilterDescription
		{
			get { return "types that are value types"; }
		}

		#endregion
	}
}

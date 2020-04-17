using System;
using System.Workflow.ComponentModel.Design;

namespace TypeBrowserLibrary
{
	public class PublicTypeFilter : ITypeFilterProvider
	{
		public PublicTypeFilter()
		{
		}

		public PublicTypeFilter(IServiceProvider provider)
		{
		}

		#region ITypeFilterProvider Members

		public bool CanFilterType(Type type, bool throwOnError)
		{
			if (throwOnError && !type.IsPublic)
			{
				throw new ArgumentException("Type is not public.");
			}

			return type.IsPublic;
		}

		public string FilterDescription
		{
			get { return "public types"; }
		}

		#endregion
	}
}

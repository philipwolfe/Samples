using System;

namespace XSLQueryBuilderApp
{
	public interface IFieldUI:IPDOUI
	{
		IField field 
		{
			get;
			set;
		}
	}
}

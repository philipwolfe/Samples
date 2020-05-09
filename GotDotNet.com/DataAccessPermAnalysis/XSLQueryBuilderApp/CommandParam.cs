using System;

namespace XSLQueryBuilderApp
{
	public class CommandParam
	{
		public string label;
		public string type;
		public string name;
		public int size;
		public bool appearInData;

		public CommandParam()
		{
		}

		public CommandParam(CommandParam copied) 
		{
			label = copied.label;
			type = copied.type;
			name = copied.name;
			size = copied.size;
			appearInData = copied.appearInData;
		}

		public override string ToString() 
		{
			return label;
		}
	}
}

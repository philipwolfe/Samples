using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Workflow.ComponentModel;
using TypeBrowserLibrary;
using System.Workflow.ComponentModel.Design;

namespace MyLibrary
{
	public partial class MyControl : UserControl
	{
		public MyControl()
		{
			InitializeComponent();
		}

		private Type someType;

		[TypeFilterProvider(typeof(ValueTypeFilter))]
		[Editor(typeof(TypeBrowser), typeof(UITypeEditor))]
		public Type SomeValueType
		{
			get { return someType; }
			set { someType = value; }
		}
	}
}

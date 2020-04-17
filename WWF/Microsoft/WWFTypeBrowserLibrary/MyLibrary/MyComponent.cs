using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TypeBrowserLibrary;
using System.Drawing.Design;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;

namespace MyLibrary
{
	public partial class MyComponent : Component
	{
		public MyComponent()
		{
			InitializeComponent();
		}

		public MyComponent(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		private Type someType;

		[TypeFilterProvider(typeof(DataContractFilter))]
		[Editor(typeof(TypeBrowser), typeof(UITypeEditor))]
		public Type DataContractType
		{
			get { return someType; }
			set { someType = value; }
		}
	}
}

using System;
using System.ComponentModel;
using Windows.Forms.Reports.ReportLibrary;

namespace Windows.Forms.Reports.Export
{
	#region CustomExport
	[ToolboxItem(false)]
	public class CustomExport:Component
	{
		#region class variables
		int FFromPage;
		int FToPage;
		UserRep FRep;
		string FFileName;
		protected int LeftMargin;
		protected int RightMargin;
		protected int TopMargin;
		protected int BottomMargin;
		#endregion

		#region class methods
		public virtual void  Execute()
		{
			LeftMargin=(int)Math.Round((double)Rep.LeftMargin/2.6,0);
			RightMargin=(int)Math.Round((double)Rep.RightMargin/2.6,0);
			TopMargin=(int)Math.Round((double)Rep.TopMargin/2.6,0);
			BottomMargin=(int)Math.Round((double)Rep.BottomMargin/2.6,0);
		}
		#endregion

		#region class properties
		public RenderingMode RenderingMode
		{
			get
			{
				return UserRep.SrcRep.RenderingMode;
			}
		}

		public int FromPage
		{
			get
			{
				return FFromPage;
			}
			set
			{
				if(value>=0)
					FFromPage=value;
			}
		}

		public int ToPage
		{
			get
			{
				return FToPage;
			}
			set
			{
				if(value>=0)
					if(value>=FromPage)
						FToPage=value;
			}
		}

		public UserRep UserRep
		{
			get
			{
				return FRep;
			}
			set
			{
				FRep=value;
			}
		}

		[Browsable(false)]
		public SourceReport Rep
		{
			get
			{
				if(FRep!=null)
					return FRep.SourceRep;
				return null;
			}
		}

		public string FileName
		{
			get
			{
				return FFileName;
			}
			set
			{
				FFileName=value;
			}
		}
		#endregion
	}
	#endregion
}

using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region enums
	public enum RenderingMode
	{
		Normal,BlackAndWhite,Gray
	}

	[Flags]
	public enum BandState
	{
		BeginPara=2,EndPara=4,PageBreak=8
	}

	public enum Units
	{
		Pix, MM, Cm, In
	}

	[Flags]
	public enum FrameStyles
	{
		Left=2,Right=4,Top=8,Bottom=16
	}

	public enum LineStyle
	{
		Solid,Dash,Dot,DashDot,DashDotDot,Double11,Double21,
		Double12
	}

	public enum HAlign
	{
		Left,Right,Center
	}

	public enum VAlign
	{
		Top,Bottom,Center
	}
	#endregion

	#region event args
	public class ShowEditorEventArgs:EventArgs
	{
		public char ch;
	}

	public class CanEditEventArgs:EventArgs
	{
		public int IdxBand;
		public int IdxCell;
		public bool Canedit;
	}

	public class DrawBandTitleEventArgs:EventArgs
	{
		public int IdxBand;
		public System.Drawing.Graphics gr;
		public System.Drawing.RectangleF r;
	}

	public class SelectCellEventArgs:EventArgs
	{
		public int idxband;
		public int idxcell;
	}

	public class SelectBandEventArgs:EventArgs
	{
		public int idxband;
	}

	public class ResizeCellEventArgs:EventArgs
	{
		public int idxband;
		public int idxcell;
	}

	public class ResizeBantEventArgs:EventArgs
	{
		public int idxband;
	}
	#endregion

	#region delegates
	public delegate void ShoweditorEventHandler(object sender, ShowEditorEventArgs arg);
	public delegate void CanEditEventHandler(object sender,CanEditEventArgs arg);
	public delegate void DrawBandTitleEventHandler(object sender,DrawBandTitleEventArgs arg);
	public delegate void SelectCellEventHandler(object sender,SelectCellEventArgs arg);
	public delegate void SelectBandEventHandler(object sender,SelectBandEventArgs arg);
	public delegate void ResizeCellEventHandler(object sender,ResizeCellEventArgs arg);
	public delegate void ResizeBantEventHandler(object sender,ResizeBantEventArgs arg);
	#endregion	
}

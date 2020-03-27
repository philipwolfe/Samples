using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack=4)]
class RECT 
{
	public int left   = 0;
	public int top    = 0;
	public int right  = 0;
	public int bottom = 0;
}

[StructLayout(LayoutKind.Sequential, Pack=4)]
class Point 
{
	public int x;
	public int y;
	
	public Point(int _x, int _y) 
	{ 
	    x = _x; 
	    y = _y; 
	}
}

class Size 
{
	public Size(int x, int y) 
	{ 
	    cx = x; 
	    cy = y; 
	}
	
	public int cx;
	public int cy;
}

class Trail 
{
	public Point[] segments;
	public Size vel;
}
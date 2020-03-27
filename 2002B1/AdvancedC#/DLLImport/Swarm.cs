using System;
using System.Runtime.InteropServices;

/// <summary>
/// Swarm class.
/// </summary>
class Swarm 
{
	const int VK_SHIFT = 0x10;
	const int PS_SOLID = 0;

	private int       myScreenHandle;
	private int       myDCHandle;
	private RECT      myScreenRect;
	private SwarmInfo mySwarmInfo;
	
	/// <summary>
	/// Constructor for theSwarm class.
	/// </summary>
	public Swarm() 
	{
		mySwarmInfo    = new SwarmInfo();
		myScreenRect   = new RECT();
		
		myScreenHandle = DLLImports.GetDesktopWindow();		
		if (myScreenHandle == 0) 
		{
			throw new ApplicationException("GetDesktopWindow()");
		}

		myDCHandle = DLLImports.GetDC(0);
		if (myDCHandle == 0) 
		{
			throw new ApplicationException("GetDC()");
		}

		int err = DLLImports.GetClipBox(myDCHandle, myScreenRect);		
		if (err == 0) 
		{
			throw new ApplicationException("GetClipBox() - " + err.ToString());
		}
	}

	/// <summary>
	/// Run for the specified number of Frames
	/// </summary>
	/// <param name="nFrames"> The number of Frames to run </param>
	public void Go(int nFrames) 
	{
		int nStartTime = DLLImports.GetTickCount();
	
		mySwarmInfo.Initialize( 20,                                     // Bee Count
		                        2,                                      // Wasp Count
		                        myScreenRect.right-myScreenRect.left,   // Screen Width
			                    myScreenRect.bottom-myScreenRect.top,   // Screen Height
			                    4                                       // Segments
			                  );

		short keyDown;
		int nKey = VK_SHIFT;
		
		// Prime the end key for the Shift button
		DLLImports.GetAsyncKeyState(nKey); 
		
		do 
		{
			PaintWindow();
			DLLImports.GdiFlush();
			mySwarmInfo.Tick();
			
			if (mySwarmInfo.Age % 10 == 0) 
			{
				DLLImports.Sleep(1); 
			}
			
			keyDown = DLLImports.GetAsyncKeyState(nKey);
		} 
		while (keyDown == 0);				
	}

	public void ClearScreen() 
	{
		DLLImports.InvalidateRect(0, myScreenRect, 1);
	}

	/// <summary>
	/// Paint the Window with the Bees and the Wasp Trails
	/// </summary>
	void PaintWindow() 
	{
		int i;

		int penBlack;
		int penWasps;
		int penBees;	

		penBlack = DLLImports.CreatePen(PS_SOLID, 15, RGB(0, 0, 0));
		penWasps = DLLImports.CreatePen(PS_SOLID, 15, RGB(255, 255, 255));
		penBees  = DLLImports.CreatePen(PS_SOLID, 15, HSB((byte)(mySwarmInfo.Age % 256), 255, 255));

		// paint the wasps
		int nWasps = mySwarmInfo.WaspCount;
		for (i=0; i<nWasps; i++) 
		{
			Trail trail = mySwarmInfo.GetWaspTrail(i);
			PaintTrail(trail, penWasps, penBlack);
		}

		// paint the bees
		int nBees = mySwarmInfo.BeeCount;
		for (i=0; i<nBees; i++) 
		{
			Trail trail = mySwarmInfo.GetBeeTrail(i);
			PaintTrail(trail, penBees, penBlack);
		}

		DLLImports.DeleteObject(penBlack);
		DLLImports.DeleteObject(penWasps);
		DLLImports.DeleteObject(penBees);
	}

	/// <summary>
	/// Paint a Trail with the specified pens for the current trail and the 
	/// trail left behind.
	/// </summary>
	/// <param name="hPenTrail">The Pen to use for the trail</param>
	/// <param name="hPenBlack">The Pen to use for the Black Trail </param>
	void PaintTrail(Trail trail, int hPenTrail, int hPenBlack)
	{
		int hOldPen = DLLImports.SelectObject(myDCHandle, hPenTrail);

		MoveTo(myDCHandle, trail.segments[0].x, trail.segments[0].y);

		for (int i=0; i < mySwarmInfo.TrailLength; i++) 
		{
			if (i == mySwarmInfo.TrailLength-1) 
			{
				DLLImports.SelectObject(myDCHandle, hPenBlack);
			}
			
			DLLImports.LineTo(myDCHandle, trail.segments[i+1].x, trail.segments[i+1].y);
		}

		DLLImports.SelectObject(myDCHandle, hOldPen);
	}

	/// <summary>
	/// Return the combined RGB for the specified Red, Green and Blue colors.
	/// </summary>
	/// <param name="r"> The Red component of the colour</param>
	/// <param name="g"> The Green component of the colour</param>
	/// <param name="b"> The Blue component of the colour</param>
	static int RGB(byte r, byte g, byte b) 
	{ 
	    return((int)(((byte)(r)|((char)((byte)(g))<<8))|(((int)(byte)(b))<<16))); 
	}

	static int HSB(byte H, byte S, byte B)
	{
		byte p, q, t;

		int i = (int) H * 6 / 256;
		int F = H * 6 - i * 256;
		p = (byte) ((((int) B) * (255 - S)) / 255);
		q = (byte) ((((int) B) * (255 - (S * F) / 255)) / 255);
		t = (byte) ((((int) B) * (255 - (S * (255 - F) / 255)) / 255));

		switch (i) {
		case 0:
			return RGB(B, t, p);
		case 1:
			return RGB(q, B, p);
		case 2:
			return RGB(p, B, t);
		case 3:
			return RGB(p, q, B);
		case 4:
			return RGB(t, p, B);
		case 5:
			return RGB(B, p, q);
		}

		// should never reach here
		throw new ApplicationException("Dead Code");
	}

	/// <summary>
	/// Move to the specified location
	/// </summary>
	void MoveTo(int hdc, int x, int y)
	{
	    Point point = new Point(0,0);
	    int err = DLLImports.MoveToEx(hdc, x, y, point);
		if (err == 0) 
		{
			throw new ApplicationException("MoveToEx Failed!");
		}
	}	
}

class MainClass 
{
	public static void Main()
	{
	    Swarm swarm = new Swarm();
		swarm.Go(1000);
		swarm.ClearScreen();
	}
};
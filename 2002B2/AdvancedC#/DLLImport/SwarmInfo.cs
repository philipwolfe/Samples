using System;
using System.Runtime.InteropServices;

class SwarmInfo 
{
	private const int BEE_ACCELERATION = 2;
	private const int WASP_ACCELERATION = 5;
	private const int BEE_VELOCITY  = 12;
	private const int WASP_VELOCITY = 10;

    private int myAge;

    private int myScreenWidth;
    private int myScreenHeight;
    private int myBeeCount;
    private int myWaspCount;
    private int mySegmentCount;

    private int myBorder; // the wasp won't go any closer to the edge than this

	private Random rand;

    private Trail[] myWaspTrails; 
    private Trail[] myBeeTrails; 

	public void Initialize(int nBees, int nWasps, int nWidth, int nHeight, int nSegments) 
	{
		myWaspTrails = new Trail[nWasps];
		myBeeTrails  = new Trail[nBees];

		myAge          = 0;
		myBeeCount     = nBees;
		myWaspCount    = nWasps;
		myScreenHeight = nHeight;
		myScreenWidth  = nWidth;
		mySegmentCount = nSegments;

		myBorder = (myScreenWidth + myScreenHeight) / 50;

		rand = new Random( DLLImports.GetTickCount() );

		for (int i = 0; i < myWaspCount; i++) 
		{
			Trail t = new Trail();
			t.segments = new Point[mySegmentCount+1];
			t.vel = new Size(0, 0);
			t.segments[0] = t.segments[1] = new
				Point(myBorder + rand.Next(myScreenWidth - 2*myBorder), myBorder + rand.Next(myScreenHeight - 2*myBorder));

			myWaspTrails[i] = t;
		}

		for (int i = 0; i < myBeeCount; i++) {
			Trail t = new Trail();
			t.vel = new Size(BRand(7), BRand(7));
			t.segments = new Point[mySegmentCount+1];
			
			t.segments[0] = t.segments[1] = new
				Point(rand.Next(myScreenWidth), rand.Next(myScreenHeight));

			myBeeTrails[i] = t;
		}
	}

	public void Tick()
	{
		myAge++;

		// Don't let things settle down
		myBeeTrails[rand.Next(myBeeCount)].vel.cx += BRand(3);
		myBeeTrails[rand.Next(myBeeCount)].vel.cy += BRand(3);

		// Bees
		for (int i=0; i<myBeeCount; i++) 
		{
			int nClosestDist = Int32.MaxValue;

			Array.Copy(myBeeTrails[i].segments, 0, myBeeTrails[i].segments, 1, myBeeTrails[i].segments.Length-1);
			
			Point pb         = myBeeTrails[i].segments[1]; // pos of bee
			Point posClosest = null; // relative pos to closest wasp
			
			for (int w = 0; w < myWaspCount; w++) 
			{
				Point pw = myWaspTrails[w].segments[1]; // pos of wasp
				int nDist;
				Point prel = new Point(pw.x - pb.x, pw.y - pb.y);
				
				nDist = Math.Max(1, Math.Abs(prel.x) + Math.Abs(prel.y)); // approximation
				
				if (nDist < nClosestDist) 
				{
					nClosestDist = nDist;
					posClosest = prel;
				}
			}

			// Accelerate
			myBeeTrails[i].vel.cx += (posClosest.x * BEE_ACCELERATION) / nClosestDist;
			myBeeTrails[i].vel.cy += (posClosest.y * BEE_ACCELERATION) / nClosestDist;

			// Speed Limit Checks
			myBeeTrails[i].vel.cx = Math.Max(Math.Min(myBeeTrails[i].vel.cx, BEE_VELOCITY), -BEE_VELOCITY);
			myBeeTrails[i].vel.cy = Math.Max(Math.Min(myBeeTrails[i].vel.cy, BEE_VELOCITY), -BEE_VELOCITY);

			// Move
			myBeeTrails[i].segments[0] = new Point(pb.x + myBeeTrails[i].vel.cx, pb.y + myBeeTrails[i].vel.cy);
		}

		// Wasps
		for (int i=0; i<myWaspCount; i++) 
		{
			Array.Copy(myWaspTrails[i].segments, 0, myWaspTrails[i].segments, 1, myWaspTrails[i].segments.Length-1);

			// accelerate the wasp
			myWaspTrails[i].vel.cx += BRand(WASP_ACCELERATION);
			myWaspTrails[i].vel.cy += BRand(WASP_ACCELERATION);

			// Speed Limit Checks
			myWaspTrails[i].vel.cx = Math.Max(Math.Min(myWaspTrails[i].vel.cx, WASP_VELOCITY), -WASP_VELOCITY);
			myWaspTrails[i].vel.cy = Math.Max(Math.Min(myWaspTrails[i].vel.cy, WASP_VELOCITY), -WASP_VELOCITY);

			// Move
			Point pw = myWaspTrails[i].segments[1]; // pos of wasp
			myWaspTrails[i].segments[0] = new Point(pw.x + myWaspTrails[i].vel.cx, pw.y + myWaspTrails[i].vel.cy);

			// Bounce Checks
			Point rp = myWaspTrails[i].segments[0];
			if ((rp.x < myBorder) || (rp.x > myScreenWidth - myBorder - 1)) 
			{
				myWaspTrails[i].vel.cx = -myWaspTrails[i].vel.cx;
				rp.x += myWaspTrails[i].vel.cx;
			}
			if ((rp.y < myBorder) || (rp.y > myScreenHeight - myBorder - 1)) 
			{
				myWaspTrails[i].vel.cy = -myWaspTrails[i].vel.cy;
				rp.y += myWaspTrails[i].vel.cy;
			}
		}

	}

	public int TrailLength 
	{ 
	    get { return Math.Min(myAge+1, mySegmentCount); }
	}    
	
	public int Age 
	{ 
	    get { return myAge; }
	}
	
    public int BeeCount 
    { 
        get { return myBeeCount; }
    }
    
    public Trail GetBeeTrail(int nBee) 
	{
		if (nBee >= myBeeCount) 
		{
			throw new ApplicationException("nBee is > myBeeCount");
		}
		
		return myBeeTrails[nBee]; 
	}

    public int WaspCount 
    { 
        get { return myWaspCount; }
    }
    
    public Trail GetWaspTrail(int nWasp) 
	{
		if (nWasp >= myWaspCount) 
		{
			throw new ApplicationException("nWasp is > myWaspCount");
		}
		
		return myWaspTrails[nWasp]; 
	}

	private int BRand(int x) 
	{ 
	    return(rand.Next(x) - (x)/2); 
	}
};